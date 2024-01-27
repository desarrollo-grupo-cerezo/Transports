Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Class FrmPagoMultidocCxC
    Private ENTRA As Boolean = True
    Private ENVIA_ENTER As Boolean = False
    Private c_ As Integer
    Private Sub FrmPagoMultidocCxC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try
        BtnClie.FlatStyle = FlatStyle.Flat
        BtnClie.FlatAppearance.BorderSize = 0
        BtnConc.FlatStyle = FlatStyle.Flat
        BtnConc.FlatAppearance.BorderSize = 0
        BtnDocto.FlatStyle = FlatStyle.Flat
        BtnDocto.FlatAppearance.BorderSize = 0

        Fg.Styles.EmptyArea.BackColor = ColoFondoFG

        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        AssignValidation(Me.TNUM_CPTO, ValidationType.Only_Numbers)

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        FECHA_DEP.Value = Date.Today
        FECHA_DEP.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FECHA_DEP.CustomFormat = "dd/MM/yyyy"
        FECHA_DEP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FECHA_DEP.EditFormat.CustomFormat = "dd/MM/yyyy"

        If Not CargaCuentasBancarias() Then
            MsgBox("No existen cuentas bancarias registradas, favor de verificar")
            Me.Close()
            Return
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED 
                    FROM MONED" & Empresa & " WHERE STATUS = 'A' AND NOT CVE_MONED IS NULL ORDER BY NUM_MONED"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboMoneda.Items.Add(String.Format("{0} | {1} | {2}", dr("NUM_MONED"), dr("CVE_MONED"), dr("DESCR")))
                    End While
                End Using
                CboMoneda.SelectedIndex = 0
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        txTC.Value = 1
        txTC.ReadOnly = True
        'Fg.Cols(6).Visible = False

        If Var10 = "Compra" Then
            TCLIENTE.Enabled = False
            TDOCTO.Enabled = False
        End If
        Try
            Fg.Rows.Count = 1
            '                    concepto       f2        descr concep   docto       importe 
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            TCLIENTE.Select()
        Catch ex As Exception
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GUARDAR()
        BarGrabar_Click(Nothing, Nothing)
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Dim j As Integer, NUM_CPTO As Integer, IMPORTE As Decimal, NUM_PAGOS As Integer, SUMAPAGOS As Decimal
        Dim FORMAPAGO As String, DOCTO As String, REFER As String, NUM_CARGO As Integer
        Dim CVE_CTA As String
        Dim NUM_MONEDA As Integer, NUM_MONEDA_FAC As Integer
        Dim TC As Decimal, TC_FAC As Decimal

        If MsgBox("Realmente desea realizar el pago?", vbYesNo) = vbNo Then
            Return
        End If
        Try
            If IsNumeric(TNUM_CPTO.Text) Then
                NUM_CPTO = TNUM_CPTO.Text

                If NUM_CPTO = 0 Then
                    MsgBox("Por favor capture el concepto de la forma de pago")
                    TNUM_CPTO.Focus()
                    Return
                End If
            Else
                MsgBox("Por favor capture el concepto de la forma de pago")
                TNUM_CPTO.Focus()
                Return
            End If
            If TDOCTO.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el folio bancario")
                TDOCTO.Focus()
                Return
            End If

            DOCTO = TDOCTO.Text

            If CboCuentabancaria.SelectedIndex = -1 Then
                MsgBox("Por favor selecciones una cuenta bancaria")
                Return
            End If

            CVE_CTA = Split(CboCuentabancaria.Text, "|")(0).Trim
            NUM_MONEDA = Convert.ToInt32(Split(CboMoneda.Text, "|")(0).Trim)

            If NUM_MONEDA <> 1 Then
                If txTC.Value <= 1 Then
                    MsgBox("Por favor capture el Tipo de Cambio")
                    Return
                End If
            End If

            TC = txTC.Value

            NUM_PAGOS = 0 : SUMAPAGOS = 0
            ENTRA = False
            For j = 1 To Fg.Rows.Count - 1

                IMPORTE = 0
                If Not IsNothing(Fg(j, 4)) Then
                    If IsNumeric(Fg(j, 4)) Then
                        IMPORTE = Fg(j, 4)
                    End If
                End If
                REFER = ""
                If Not IsNothing(Fg(j, 1)) Then
                    REFER = Fg(j, 1)
                End If
                If IsNumeric(Fg(j, 3)) Then
                    NUM_CARGO = Fg(j, 3)
                Else
                    NUM_CARGO = 1
                End If

                If IsNumeric(Fg(j, 8)) Then
                    NUM_MONEDA_FAC = Fg(j, 8)
                Else
                    NUM_MONEDA_FAC = 1
                End If

                TC_FAC = 1

                If NUM_MONEDA <> 1 And NUM_MONEDA_FAC <> 1 Then
                    NUM_MONEDA_FAC = NUM_MONEDA
                    TC_FAC = TC
                End If


                If REFER.Trim.Length > 0 And IMPORTE > 0 Then
                    SUMAPAGOS = SUMAPAGOS + IMPORTE
                    CUEN_DET_COM(REFER, IMPORTE, NUM_CPTO, DOCTO, NUM_CARGO, CVE_CTA, NUM_MONEDA_FAC, TC_FAC)
                    NUM_PAGOS = NUM_PAGOS + 1
                End If
            Next

            ENTRA = True

            FORMAPAGO = "S"
            LIMPIAR()
            MsgBox("El pago se realizo satisfactoriamente")
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_DET_COM(fCVE_DOC As String, fIMPORTE As Decimal, fNUM_CPTO As Integer, fDOCTO As String, FNUM_CARGO As Integer, FCVE_CTA As String, FNUM_MONEDA As Integer, FTC As Decimal)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim IMPORTE As Decimal, AFEC_COI As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CTLPOL As Integer
        Dim CVE_FOLIO As String, TIPO_MOV As String, SIGNO As Integer, CVE_AUT As Integer, Usuario2 As Integer, REF_SIST As String, NO_PARTIDA As Integer

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        Try
            CVE_CLIE = TCLIENTE.Text
            REFER = fCVE_DOC
            NO_FACTURA = fCVE_DOC
            NUM_CPTO = fNUM_CPTO

            ID_MOV = 1

            NUM_CARGO = FNUM_CARGO
            CVE_OBS = 0
            If fDOCTO.Trim.Length = 0 Then fDOCTO = fCVE_DOC
            IMPORTE = fIMPORTE
            AFEC_COI = ""

            NUM_MONED = FNUM_MONEDA
            TCAMBIO = FTC
            IMPMON_EXT = IMPORTE / FTC

            CTLPOL = 0 : CVE_FOLIO = "" : TIPO_MOV = "A" : SIGNO = -1 : CVE_AUT = 0 : Usuario2 = 0 : REF_SIST = "" : NO_PARTIDA = 1

            SQL = "INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, 
                IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, 
                SIGNO, CVE_AUT, USUARIO, REF_SIST, NO_PARTIDA, CVE_CTA) VALUES('" & CVE_CLIE & "','" & REFER & "','" & ID_MOV & "','" &
                NUM_CPTO & "','" & NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & fDOCTO & "','" &
                Math.Round(IMPORTE, 6) & "','" & FSQL(FECHA_DEP.Value) & "','" & FSQL(F1.Value) & "','" & AFEC_COI & "','" &
                NUM_MONED & "','" & TCAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" & CTLPOL & "','" &
                CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','" & CVE_AUT & "','" & Usuario2 & "','" & REF_SIST & "',
                ISNULL((SELECT MAX(NO_PARTIDA) + 1 FROM CUEN_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "'),1), '" & FCVE_CTA & "')"

            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    UPDATE_DATOS_CLIE(IMPORTE, NO_FACTURA, CVE_CLIE, " - ")
                End If
            End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            TCLIENTE.Text = ""
            TDOCTO.Text = ""

            Fg.Rows.Count = 1
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            F1.Value = Now
            FECHA_DEP.Value = Now
            'LtTotalPagos.Text = ""
            LtNombre.Text = ""
            TIMPORTE.Value = 0
            TDOCTO.Text = ""

            TCLIENTE.Focus()

        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_CXP(FNO_PARTIDA As Integer)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxC" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxC.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = TDOCTO.Text
            StiReport1.Item("NO_PARTIDA") = FNO_PARTIDA
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
                Fg.Col = 1
            End If
        Catch ex As Exception
            Bitacora("18. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles BtnClie.Click
        Try
            Var2 = "CLIE"
            Var4 = ""
            Var5 = ""
            Var9 = ""

            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
                If Var9 <> "0" Then
                    TNUM_CPTO.Text = Var9
                    TNUM_CPTO_Validated(Nothing, Nothing)

                End If

                Var2 = ""
                Var4 = ""
                Var5 = ""
                Var9 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPagoMultidocCxC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                DESCR = TCLIENTE.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Text = DESCR
                End If
                TNUM_CPTO.Focus()
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TCLIENTE.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    Var11 = TCLIENTE.Text
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    TCLIENTE.Focus()
                    TCLIENTE.SelectAll()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function HayPartidas() As Boolean
        Dim SiHay As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 Then
                        SiHay = True
                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return SiHay
    End Function
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs) Handles BtnDocto.Click
        Try
            If HayPartidas() Then
                Return
            End If

            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un cliente")
                Return
            End If
            Var2 = "ClieDocTo"
            Var4 = TCLIENTE.Text
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TDOCTO.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TDOCTO.KeyDown
        Try
            'If e.KeyCode = Keys.F2 Then
            'BtnDoc_Click(Nothing, Nothing)
            'End If
            If e.KeyCode = 13 Then
                Fg.Select()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If
        Catch ex As Exception
            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TDOCTO.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Fg.Select()
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                Fg.StartEditing()
                'TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If

        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_Validated(sender As Object, e As EventArgs) Handles TDOCTO.Validated
        Dim FOLIOD As Long
        Try

            If TDOCTO.Text.Trim.Length > 9999 Then
                Dim DESCR As String

                If IsNumeric(TDOCTO.Text.Trim) Then
                    FOLIOD = TDOCTO.Text.Trim
                    TDOCTO.Text = Space(10) & Format(FOLIOD, "0000000000")
                End If
                Var4 = TCLIENTE.Text
                Var5 = ""

                DESCR = BUSCA_CAT("ClieDocto", TDOCTO.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    'Fg.Focus()
                    'Fg.Row = 1
                    'Fg.Col = 1
                    'SendKeys.Send("{ENTER}")
                Else
                    MsgBox("El documento no existe")
                    TDOCTO.Text = ""
                    TDOCTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnConc_Click(sender As Object, e As EventArgs) Handles BtnConc.Click
        Try
            Var2 = "ConcCxC"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUM_CPTO.Text = Var4
                LtConc.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                CboCuentabancaria.Focus()
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_CPTO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnConc_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxCRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    CboCuentabancaria.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    'TNUM_CPTO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_CPTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TNUM_CPTO.PreviewKeyDown
        Try
            If e.KeyCode = 13 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxCRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    CboCuentabancaria.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    TNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles TNUM_CPTO.Validated
        Try
            If TNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxCRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    CboCuentabancaria.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    TNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If (Fg.Col = 1 Or Fg.Col = 4) And ENTRA Then
                Fg.StartEditing()
            End If

            If Fg.Rows.Count = 1 Then
                '                     REFER          F2        NUM_CARGO      ABONO         saldo       importe
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
            End If

        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 4 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Or Fg.Col = 5 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 4 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_KeyDown(sender As Object, e As KeyEventArgs) Handles F1.KeyDown
        If e.KeyCode = 13 Then
            TNUM_CPTO.Focus()
        End If
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Var4 = ""
            Var5 = ""
            'Fg.FinishEditing()
            '2	10	13	15
            If Fg.Col = 2 Then

                ENVIA_ENTER = True
                SELDOC()
            End If
        Catch ex As Exception
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub SELDOC()
        If TCLIENTE.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione el cliente")
            TCLIENTE.Focus()
            Return
        End If
        Try    'REFER
            ReDim aTPV(0, 0)
            Dim HayMonedaExtranjera = False
            Dim Mda As String = "", MdaExt = ""
            Dim i As Integer

            Mda = Split(CboMoneda.Text, "|")(1).Trim
            MdaExt = Mda

            Var2 = "ClieDocSaldos2"
            Var4 = TCLIENTE.Text
            Var5 = ""
            FrmPagoMultSaldosItem.ShowDialog()
            If Var4.Trim.Length > 0 Then

                Dim z As Integer = 0

                Fg.Rows.Count = 1

                For k = 0 To aTPV.Length - 1
                    Try
                        If Not IsNothing(aTPV(k, 0)) Then
                            If aTPV(k, 0).ToString.Trim.Length > 0 Then
                                Fg.AddItem("" & vbTab & aTPV(k, 0) & vbTab & "" & vbTab & aTPV(k, 1) & vbTab & aTPV(k, 2) & vbTab & aTPV(k, 3) & vbTab & aTPV(k, 4) & vbTab & aTPV(k, 6) & vbTab & aTPV(k, 5))

                                If aTPV(k, 5) <> 1 Then
                                    HayMonedaExtranjera = True
                                    MdaExt = aTPV(k, 6)
                                End If

                                z += 1
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("4300. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next

                If Mda <> MdaExt Then
                    For i = 0 To CboMoneda.Items.Count
                        If CboMoneda.Items.Item(i).ToString().Contains(MdaExt) Then
                            CboMoneda.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If

                CalculaTotal()
                '                     REFER          F2        NUM_CARGO      ABONO         saldo       importe
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")

                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1

                'If EXISTE_DOC(Var4, Fg.Row) Then
                'MsgBox("El documento ya fue agregado, verifique por favor")
                'Fg(Fg.Row, 1) = ""
                'c_ = 1
                'TMagico.Focus()
                'Fg.Col = c_
                'If ENVIA_ENTER Then
                'SendKeys.Send("{ENTER}")
                'End If
                '   ENVIA_ENTER = False
                '  Return
                'End If
                'TXT.Value = Var4

                'Fg(Fg.Row, 1) = Var4
                'Fg(Fg.Row, 3) = Var6
                'Fg(Fg.Row, 4) = 0 'Var9
                'Fg(Fg.Row, 5) = 0 'Math.Round(CDec(Var9), 6)
                'Fg(Fg.Row, 6) = 0 'Math.Round(CDec(Var9), 6)
                Var2 = ""
                Var4 = ""
                Var5 = ""


                'SendKeys.Send("{ENTER}")
                ENTRA = True
            End If
            Return
        Catch Ex As Exception
            Bitacora("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 13 And e.Col = 6 Then
                    'Fg.Col = 4
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If Fg.Row > 0 And ENTRA Then
            If e.KeyCode = 9 And Fg.Col = 4 Then
                AGREGA_ROW()
            End If
            'If e.KeyCode = 13 And Fg.Col = 4 Then
            'AGREGA_ROW()
            'End If
        End If
    End Sub

    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F7
                    BarEliminar_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F3
                    BarGrabar_Click(Nothing, Nothing)
            End Select

            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                'Fg.Col = 4
                            End If
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                ENTRA = False
                                Fg.Col = 4
                            End If
                            SendKeys.Send("{ENTER}")
                            ENTRA = True
                            Return
                        Case 19
                            If Fg.Row = Fg.Rows.Count - 1 Then

                            Else
                                Fg.Row = Fg.Row + 1
                            End If

                            Fg.Col = 1
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = Keys.F2 Then
                    Select Case Fg.Col
                        Case 1
                            ENVIA_ENTER = True
                            SELDOC()
                            ENTRA = True
                            Return
                    End Select

                End If
                If e.KeyCode = Keys.Left Then
                    Select Case Fg.Col
                        Case 1
                            e.SuppressKeyPress = True
                        Case 4
                            Fg.Col = 1
                    End Select
                End If
                If e.KeyCode = Keys.Right Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.SuppressKeyPress = True
                            Else
                                Fg.Col = 4
                                'SendKeys.Send("{ENTER}")
                            End If
                    End Select
                End If
                If e.KeyCode = Keys.Up Then
                    If Fg.Row = 1 Then
                        e.SuppressKeyPress = True
                    Else
                        Select Case Fg.Col
                            Case 1
                                Fg.Row = Fg.Row - 1
                                Fg.Col = 1
                                e.SuppressKeyPress = True
                                'SendKeys.Send("{ENTER}")
                        End Select
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    Select Case Fg.Col
                        Case 1
                            Try
                                ENTRA = False
                                If Fg.Row = Fg.Rows.Count - 1 Then
                                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                                        Fg.Row = Fg.Rows.Count - 1
                                    Else

                                    End If
                                Else
                                    Fg.Row = Fg.Row + 1
                                End If
                                Fg.Col = 1
                                e.SuppressKeyPress = True
                                'SendKeys.Send("{ENTER}")
                                ENTRA = True
                            Catch ex As Exception
                                ENTRA = True
                                Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub

    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                'e.IsInputKey = True
                                'TXT.Focus()
                            Else
                                Fg.Col = 4
                            End If
                        Case 4
                            AGREGA_ROW()

                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function EXISTE_DOC(FREFER As String, FROW As Integer) As Boolean
        Dim existe As Boolean = False
        Try
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                If k <> FROW Then
                    If Fg(k, 1) = FREFER Then
                        existe = True
                        Exit For
                    End If
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return existe
    End Function
    Private Sub TXT_Validating(sender As Object, e As CancelEventArgs) Handles TXT.Validating
        '2
    End Sub
    Private Sub TXT_Validated(sender As Object, e As EventArgs) Handles TXT.Validated
        '3
    End Sub
    Private Sub TXTN_TextChanged(sender As Object, e As EventArgs) Handles TXTN.TextChanged
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 4 Then
                    If TXTN.Value > Fg(Fg.Row, 6) Then
                        MsgBox("El pago no puede ser mayor al saldo veifique por favor")
                        TXTN.Value = 0
                        TMagico.Focus()
                        SendKeys.Send("{ENTER}")
                    Else
                        Fg(Fg.Row, 5) = Fg(Fg.Row, 6) - TXTN.Value
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 4
                            If TXTN.Value > 0 Then
                                AGREGA_ROW()
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Try
            If Fg.Row > 0 Then
                If ENTRA Then

                End If
                If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 4
                            If TXTN.Value > 0 Then
                                AGREGA_ROW()
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub AGREGA_ROW()
        Try
            ENTRA = False
            If Fg.Row = Fg.Rows.Count - 1 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                Fg.Row = Fg.Rows.Count - 1
            Else
                Fg.Row = Fg.Row + 1
            End If

            Fg.Col = 1
            SendKeys.Send("{ENTER}")

            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_Validated(sender As Object, e As EventArgs) Handles TXTN.Validated

    End Sub
    Private Function CalculaPagos(FRow As Integer, Optional FPAGO As Decimal = 0) As Decimal
        Try
            Dim SUMA As Decimal
            ENTRA = False
            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                If k <> FRow Then
                    SUMA = SUMA + Fg(k, 4)
                Else
                    SUMA = SUMA + FPAGO
                End If
            Next
            ENTRA = True
            Return SUMA
        Catch ex As Exception
            ENTRA = True
            Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function


    Private Sub CalculaTotal()
        Try
            Dim SUMA As Decimal
            ENTRA = False
            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) <> "" Then
                    SUMA = SUMA + Fg(k, 4)
                End If
            Next

            TIMPORTE.Value = SUMA
        Catch ex As Exception

            Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try
    End Sub

    Private Sub FECHA_DEP_KeyDown(sender As Object, e As KeyEventArgs) Handles FECHA_DEP.KeyDown
        If e.KeyCode = 13 Then
            TNUM_CPTO.Focus()
        End If
    End Sub

    Private Sub TXT_Leave(sender As Object, e As EventArgs) Handles TXT.Leave
        '1
        Try
            If Fg.Row > 0 Then
                'ENTRA = False
                Select Case Fg.Col
                    Case 1
                        If TXT.Text.Trim.Length > 0 Then
                            If EXISTE_DOC(TXT.Text, Fg.Row) Then
                                MsgBox("El documento ya fue agregado, verifique por favor")
                                Fg(Fg.Row, 1) = ""
                                TXT.Value = ""
                                TXT.Text = ""
                                Fg(Fg.Row, 3) = ""
                                Fg(Fg.Row, 4) = ""
                                Fg(Fg.Row, 5) = ""
                                Fg(Fg.Row, 6) = ""
                                TMagico.Focus()
                                ENTRA = True
                                Return
                            End If
                        End If
                        If TXT.Text.Trim.Length > 0 And Fg(Fg.Row, 4) = 0 Then

                        End If
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Dim DESCR As String, MONTO As Decimal = 0

        If TXT.Text.Trim.Length > 0 Then

            If IsNumeric(Fg(Fg.Row, 4)) Then
                MONTO = Fg(Fg.Row, 4)
            Else
                MONTO = 0
            End If
            If MONTO = 0 And Fg.Col = 1 Then
                Var4 = TCLIENTE.Text
                DESCR = BUSCA_CAT("ClieDocSaldos", Fg.Editor.Text)
                If DESCR <> "" Then
                    'Var4 = Fg(Fg.Row, 1).ToString  'REFER
                    'Var8 = Fg(Fg.Row, 8) 'IMPORTE
                    'Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
                    'Var6 = Fg(Fg.Row, 11).ToString  'NUM_CARGO
                    Fg(Fg.Row, 3) = Var6
                    Fg(Fg.Row, 4) = 0 'Var9
                    If IsNumeric(Var9) Then
                        Fg(Fg.Row, 4) = Math.Round(CDec(Var9), 6)
                        Fg(Fg.Row, 5) = Math.Round(CDec(Var9), 6)
                        Fg(Fg.Row, 6) = Math.Round(CDec(Var9), 6)
                    End If
                Else
                    TXT.Value = ""
                    Fg(Fg.Row, 1) = ""
                    MsgBox("Documento inexistente")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub Fg_Validated(sender As Object, e As EventArgs) Handles Fg.Validated

    End Sub
    Private Sub TMagico_GotFocus(sender As Object, e As EventArgs) Handles TMagico.GotFocus

        TXT.Value = ""
        Fg.Focus()
        TXT.Focus()
    End Sub

    Private Sub LtNombre_Click(sender As Object, e As EventArgs) Handles LtNombre.Click

    End Sub

    Private Sub TXT_KeyUp(sender As Object, e As KeyEventArgs) Handles TXT.KeyUp

    End Sub

    Private Sub TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT.KeyPress

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Up
                If Fg.Row = 1 Then
                    'e.SuppressKeyPress = True
                Else
                    Select Case Fg.Col
                        Case 1
                            Fg.Row = Fg.Row - 1
                            Fg.Col = 1
                            'e.SuppressKeyPress = True
                            'SendKeys.Send("{ENTER}")
                    End Select
                End If
                Return True ' <-- If you want to suppress default handling of arrow keys

            Case Keys.Right
                Select Case Fg.Col
                    Case 1
                        If TXT.Text.Length = 0 Then
                            'e.SuppressKeyPress = True
                        Else
                            Fg.Col = 4
                            'SendKeys.Send("{ENTER}")
                        End If
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys

            Case Keys.Down
                Select Case Fg.Col
                    Case 1
                        Try
                            ENTRA = False
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                                    Fg.Row = Fg.Rows.Count - 1
                                Else

                                End If
                            Else
                                Fg.Row = Fg.Row + 1
                            End If
                            Fg.Col = 1
                            'e.SuppressKeyPress = True
                            'SendKeys.Send("{ENTER}")
                            ENTRA = True
                        Catch ex As Exception
                            ENTRA = True
                            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys

            Case Keys.Left
                Select Case Fg.Col
                    Case 1
                        'e.SuppressKeyPress = True
                    Case 4
                        Fg.Col = 1
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys

        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub TXTN_Validating(sender As Object, e As CancelEventArgs) Handles TXTN.Validating

    End Sub

    Private Sub TXTN_Leave(sender As Object, e As EventArgs) Handles TXTN.Leave
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 4 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                        If Not IsNothing(TXTN.Value) Then
                            If TXTN.Value > 0 Then
                                TIMPORTE.Value = CalculaPagos(Fg.Row, TXTN.Value)
                                'CalculaTotal()
                            Else
                                MsgBox("El monto no puede ser cero verifique por favor")
                                Fg.Col = 1
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ChangeEdit(sender As Object, e As EventArgs) Handles Fg.ChangeEdit

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

    Private Sub CboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMoneda.SelectedIndexChanged
        If CboMoneda.Text.Contains("MXN") Then
            txTC.Value = 1
            txTC.ReadOnly = True
        Else
            Try
                Dim NUM_MONEDA As Integer
                NUM_MONEDA = Convert.ToInt32(Split(CboMoneda.Text, "|")(0).Trim)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = String.Format("SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED FROM MONED" & Empresa & " WHERE STATUS = 'A' AND NUM_MONED = {0}", NUM_MONEDA)
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            txTC.Value = dr("TCAMBIO")
                            txTC.ReadOnly = False
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub F1_ValueChanged(sender As Object, e As EventArgs) Handles F1.ValueChanged
        FECHA_DEP.Value = F1.Value
    End Sub
End Class

