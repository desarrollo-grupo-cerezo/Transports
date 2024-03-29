﻿Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmAltaCxCAE
    Private Entra As Boolean
    Private Sub frmAltaCxCAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.CenterToScreen()

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Entra = True
            tCVE_CLIE.MaxLength = 10
            tREFER.MaxLength = 20
            tNO_FACTURA.MaxLength = 20
            tDOCTO.MaxLength = 20
            tFolio.Enabled = False
            tTCAMBIO.Text = "1"
            tNUM_MONED.Text = "1"
            tIMPORTE.Tag = "0"
            tTCAMBIO.Enabled = False
            tNO_FACTURA.Enabled = False
            tIMPMON_EXT.Enabled = False

            If Not CargaCuentasBancarias() Then
                MsgBox("No existen cuentas bancarias registradas, favor de verificar")
                Me.Close()
                Return
            End If

            Me.KeyPreview = True

            tCVE_CLIE.Select()

        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAltaCxCAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmAltaCxCAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And Entra Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_BITA As Long
        Dim TIPO_MOV As String
        Dim SIGNO As Integer
        Dim CVE_AUT As Integer
        Dim USUARIO2 As Integer
        Dim NO_PARTIDA As Integer
        Dim NUM_CARGO As Integer
        Dim ID_MOV As Integer
        Dim CVE_FOLIO As String
        Dim CVE_OBS As Long
        Dim NO_FACTURA As String
        Dim CON_REFER As String
        Dim SIGNO_CADENA As String
        Dim IMPORTE As Decimal
        Dim CVE_CTA As String

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tREFER.Text.Trim.Length = 0 Then
            MsgBox("El campo referencia no debe quedar vacio, verifique por favor")
            Return
        End If
        If TDOCTO.Text.Trim.Length = 0 Then
            MsgBox("El campo no. documento no debe quedar vacio, verifique por favor")
            Return
        End If
        If tNUM_CPTO.Text.Trim.Length = 0 Then
            MsgBox("El campo concepto no debe ser cero ni quedar vacio ")
            Return
        End If
        If tNO_FACTURA.Text.Trim.Length = 0 Then
            MsgBox("El campo NO FACTURA no debe de quedar vacio")
            Return
        End If
        If tIMPORTE.Text = 0 Then
            MsgBox("El importe no debe ser cero")
            Return
        End If
        If CboCuentabancaria.SelectedIndex = -1 Then
            MsgBox("Por favor selecciones una cuenta bancaria")
            Return
        End If

        CVE_CTA = Split(CboCuentabancaria.Text, "|")(0).Trim

        CVE_BITA = 0 : TIPO_MOV = "" : SIGNO = 1 : CVE_AUT = 0 : USUARIO2 = 0 : NO_PARTIDA = 1 : ID_MOV = 1 : CVE_FOLIO = "" : CVE_OBS = 0 : NO_FACTURA = ""
        TIPO_MOV = "A"
        SIGNO = -1
        CON_REFER = ""
        SIGNO_CADENA = ""
        NUM_CARGO = 1
        tObs.Select()

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CONC" & Empresa & " WHERE NUM_CPTO = " & tNUM_CPTO.Text
                cmd2.CommandText = SQL
                Using dr As SqlDataReader = cmd2.ExecuteReader
                    If dr.Read Then
                        CON_REFER = dr("CON_REFER")
                        SIGNO = dr("SIGNO")
                        If SIGNO = -1 Then
                            SIGNO_CADENA = " - "
                        Else
                            SIGNO_CADENA = " + "
                        End If
                        TIPO_MOV = dr("TIPO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If tObs.Text.Trim.Length > 0 Then
            CVE_OBS = GRABA_OBSER(tObs.Text)
        Else
            CVE_OBS = 0
        End If
        If IsNumeric(tIMPORTE.Text) Then
            IMPORTE = tIMPORTE.Text
        Else
            IMPORTE = tIMPORTE.Value
        End If


        If CON_REFER = "S" Then
            Try
                SQL = "INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, ID_MOV, CVE_FOLIO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE,
                    FECHA_APLI, FECHA_VENC, NUM_MONED, TCAMBIO, IMPMON_EXT, TIPO_MOV, SIGNO, USUARIO, NO_PARTIDA, FECHAELAB, UUID, VERSION_SINC, CVE_CTA) 
                    VALUES (@CVE_CLIE, @REFER, @NUM_CPTO, @NUM_CARGO, @ID_MOV, @CVE_FOLIO, @CVE_OBS, @NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC,
                    @NUM_MONED, @TCAMBIO, @IMPMON_EXT, @TIPO_MOV, @SIGNO, @USUARIO, 
                    ISNULL((SELECT ISNULL(MAX(NO_PARTIDA),0) + 1 FROM CUEN_DET" & Empresa & " WHERE REFER = @REFER AND CVE_CLIE = @CVE_CLIE),0), GETDATE(), NEWID(), GETDATE(), @CVE_CTA)"

                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_CLIE", SqlDbType.VarChar).Value = tCVE_CLIE.Text
                cmd.Parameters.Add("@REFER", SqlDbType.VarChar).Value = tREFER.Text
                cmd.Parameters.Add("@NUM_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
                cmd.Parameters.Add("@NUM_CARGO", SqlDbType.Int).Value = NUM_CARGO
                cmd.Parameters.Add("@ID_MOV", SqlDbType.Int).Value = ID_MOV
                cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                cmd.Parameters.Add("@NO_FACTURA", SqlDbType.VarChar).Value = tNO_FACTURA.Text
                cmd.Parameters.Add("@DOCTO", SqlDbType.VarChar).Value = tDOCTO.Text
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPORTE
                cmd.Parameters.Add("@FECHA_APLI", SqlDbType.DateTime).Value = F1.Value
                cmd.Parameters.Add("@FECHA_VENC", SqlDbType.DateTime).Value = F2.Value
                cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_MONED.Text)
                cmd.Parameters.Add("@TCAMBIO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTCAMBIO.Text)
                cmd.Parameters.Add("@IMPMON_EXT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tIMPMON_EXT.Text)
                cmd.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = TIPO_MOV
                cmd.Parameters.Add("@SIGNO", SqlDbType.Int).Value = SIGNO
                cmd.Parameters.Add("@USUARIO", SqlDbType.SmallInt).Value = USUARIO2
                cmd.Parameters.Add("@CVE_CTA", SqlDbType.VarChar).Value = CVE_CTA
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se grabo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                SQL = "INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO,
                  CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, FECHA_VENC, NUM_MONED, TCAMBIO,
                  IMPMON_EXT, FECHAELAB, TIPO_MOV, SIGNO, USUARIO) Values('" & tCVE_CLIE.Text & "','" &
                  tREFER.Text & "','" & tNUM_CPTO.Text & "','" & NUM_CARGO & "','" & CVE_OBS & "','" &
                  tNO_FACTURA.Text & "','" & tDOCTO.Text & "','" & tIMPORTE.Text & "','" & F1.Value & "','" &
                  F2.Text & "','" & tNUM_MONED.Text & "','" & tTCAMBIO.Text & "','" & tIMPORTE.Text &
                  "',GETDATE(),'" & TIPO_MOV & "','" & SIGNO & "','" & USUARIO2 & "')      "
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se grabo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If

            Catch ex As Exception
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Try
            If TIPO_MOV = "N" Then
                UPDATE_DATOS_CLIE(tIMPORTE.Text, NO_FACTURA, tCVE_CLIE.Text, SIGNO_CADENA)
            Else
                UPDATE_DATOS_CLIE(tIMPORTE.Text, NO_FACTURA, tCVE_CLIE.Text, SIGNO_CADENA)
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub frmAltaCxCAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TCVE_CLIE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnClie_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_CLIE_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE.Validated
        Try

            If TCVE_CLIE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_CLIE.Text.Trim) Then
                    DESCR = TCVE_CLIE.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_CLIE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE.Text = ""
                    TCVE_CLIE.Select()
                End If

            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "ConcCxC"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                LtConp.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tREFER.Focus()
            End If
        Catch Ex As Exception
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnNumCpto_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles tNUM_CPTO.Validated
        Try
            If tNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ConcCxC", tNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConp.Text = DESCR
                Else
                    MsgBox("Concepto inexistente")
                    tNUM_CPTO.Text = ""
                    tNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnNoFactura_Click(sender As Object, e As EventArgs) Handles btnNoFactura.Click
        Try
            Var2 = "ClieDocSaldos"
            Var4 = ""
            Var5 = ""
            Var4 = tCVE_CLIE.Text
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tREFER.Text = Var4
                tNO_FACTURA.Text = Var4
                'Var4 = Fg(Fg.Row, 1).ToString  'REFER
                'Var5 = Fg(Fg.Row, 2).ToString  'CLIENTE
                'Var7 = Fg(Fg.Row, 7) 'ABONOS
                'Var8 = Fg(Fg.Row, 8) 'IMPORTE
                'Var9 = Fg(Fg.Row, 8) - Fg(Fg.Row, 7)  'SALDO
                'Var6 = Fg(Fg.Row, 11).ToString  'NUM_CPTO
                L3.Text = Var5
                Lt1.Text = Format(Val(Var8), "###,###,##0.00")
                Lt2.Text = Format(Val(Var9), "###,###,##0.00") 'SALDO
                Lt2.Tag = Var9
                tIMPORTE.Value = Var9
                tIMPORTE.Tag = Var9

                tIMPMON_EXT.Text = Lt2.Text
                Var2 = "" : Var4 = "" : Var5 = ""
                tDOCTO.Focus()
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tREFER_KeyDown(sender As Object, e As KeyEventArgs) Handles tREFER.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnNoFactura_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tREFER_Validated(sender As Object, e As EventArgs) Handles tREFER.Validated
        Try
            If tREFER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                Var4 = tCVE_CLIE.Text

                DESCR = BUSCA_CAT("ClieDocSaldos", tREFER.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("El documento no existe o se encuentra saldado")
                    tREFER.Text = ""
                    tREFER.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnMoneda_Click(sender As Object, e As EventArgs) Handles btnMoneda.Click
        Try
            Var2 = "Meneda"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_MONED.Text = Var4
                L3.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tTCAMBIO.Focus()
            End If
        Catch Ex As Exception
            MsgBox("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_MONED_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_MONED.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnMoneda_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tNUM_MONED_Validated(sender As Object, e As EventArgs) Handles tNUM_MONED.Validated
        Try
            If tNUM_MONED.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Moneda", tNUM_MONED.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("Moneda no encontrada")
                    tNUM_MONED.Text = ""
                    tNUM_MONED.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTipoCambio_Click(sender As Object, e As EventArgs) Handles btnTipoCambio.Click
        Try
            Var2 = "ProvDocSaldos"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tTCAMBIO.Text = Var4
                L3.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tIMPORTE.Focus()
            End If
        Catch Ex As Exception
            MsgBox("190. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("190. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tTCAMBIO_KeyDown(sender As Object, e As KeyEventArgs) Handles tTCAMBIO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnTipoCambio_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tTCAMBIO_Validated(sender As Object, e As EventArgs) Handles tTCAMBIO.Validated
        Try
            If tTCAMBIO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ProvDocSaldos", tTCAMBIO.Text)
                If DESCR <> "" Then
                    LtCambio.Text = DESCR
                Else
                    MsgBox("El documento no existe o se encuentra saldado")
                    tTCAMBIO.Text = ""
                    tTCAMBIO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tNUM_CPTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tNUM_CPTO.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            GroupBox2.Select()
            'tREFER.Select()
        End If
    End Sub

    Private Sub chAplicarFolio_CheckedChanged(sender As Object, e As EventArgs) Handles chAplicarFolio.CheckedChanged
        Try
            If chAplicarFolio.Checked Then
                tFolio.Enabled = True
            Else
                tFolio.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tNUM_CPTO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tNUM_CPTO.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tREFER_LostFocus(sender As Object, e As EventArgs) Handles tREFER.LostFocus
        tNO_FACTURA.Text = tREFER.Text
    End Sub

    Private Sub tNUM_CPTO_GotFocus(sender As Object, e As EventArgs) Handles tNUM_CPTO.GotFocus
        Entra = False
    End Sub

    Private Sub tNUM_CPTO_LostFocus(sender As Object, e As EventArgs) Handles tNUM_CPTO.LostFocus
        Entra = True
    End Sub

    Private Sub tIMPORTE_ValueChanged(sender As Object, e As EventArgs) Handles tIMPORTE.ValueChanged
        tIMPMON_EXT.Value = tIMPORTE.Text.ToString.Replace(",", "")
    End Sub

    Private Sub tIMPORTE_KeyDown(sender As Object, e As KeyEventArgs) Handles tIMPORTE.KeyDown
        Try
            If e.KeyCode = 13 Then
                GroupBox3.Select()
                GroupBox3.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tIMPORTE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tIMPORTE.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                GroupBox3.Select()
                GroupBox3.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tIMPORTE_Validating(sender As Object, e As CancelEventArgs) Handles tIMPORTE.Validating
        Try
            If tIMPORTE.Value > CDec(tIMPORTE.Tag) Then
                MsgBox("El monto no puede ser mayor al saldo verifique por favor")
                tIMPORTE.Value = CDec(tIMPORTE.Tag)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles BtnClie.Click
        Try
            Var2 = "CLIE"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE.Text = Var4
                L3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tNUM_CPTO.Focus()
            End If

        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Function CargaCuentasBancarias() As Boolean
        Try
            Dim dt As DataTable
            Dim exist As Boolean = False

            CboCuentabancaria.Items.Clear()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT TRY_PARSE(ISNULL(CLAVE,'0') AS INT) AS CVE, CUENTA_BANCARIA, ISNULL(NOMBRE_BANCO,'') AS NOMBRE
                    FROM CUENTA_BENEF" & Empresa & " 
                    WHERE ISNULL(STATUS,'A') = 'A' 
                    ORDER BY TRY_PARSE(CLAVE AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboCuentabancaria.Items.Add(String.Format("{0} | {1} | {2}", dr("CVE"), dr("CUENTA_BANCARIA"), dr("NOMBRE")))
                        exist = True
                    End While
                End Using
            End Using

            If CboCuentabancaria.Items.Count = 1 Then
                CboCuentabancaria.SelectedIndex = 0
            End If

            Return exist
        Catch ex As Exception
            Bitacora("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return False
        End Try
    End Function
End Class
