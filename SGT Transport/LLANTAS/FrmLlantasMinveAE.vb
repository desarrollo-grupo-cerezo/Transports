Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports C1.Win.C1Command

Public Class FrmLlantasMinveAE
    Private Sub FrmLlantasMinveAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AssignValidation(Me.tCOSTO, ValidationType.Only_Numbers)

        For Each button In Me.Controls

            If button.GetType.ToString = "C1.Win.C1Input.C1Button" Then
                button.FlatStyle = FlatStyle.Flat
                button.FlatAppearance.BorderSize = 0
            End If
            Debug.Print(button.GetType.ToString)
        Next

        LtStstus_LLanta.Tag = "0"

    End Sub
    Private Sub FrmLlantasMinveAE_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tCOSTO.ReadOnly = True
        Me.CenterToScreen()

    End Sub
    Private Sub FrmLlantasMinveAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        If MsgBox("Realmente desea guardar el movimiento?", vbYesNo) = vbYes Then
            Try
                Dim ExistR As Boolean = False

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_DOC FROM GCLLANTAS_MINVE WHERE CVE_DOC = '" & TREFER.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            ExistR = True
                        End If
                    End Using
                End Using

                If ExistR Then
                    MsgBox("La referencia ya existe verifique por favor")
                    Return
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            SQL = "INSERT INTO GCLLANTAS_MINVE (CVE_DOC, CVE_ART, TIP_DOC, FECHA, CVE_UNI, NUM_ECONOMICO, CVE_TIPO, NUM_PAR, COSTO, SIGNO, USUARIO, 
                CVE_CPTO, FECHAELAB, UUID) VALUES (@CVE_DOC, @CVE_ART, @TIP_DOC, CONVERT(varchar, GETDATE(), 112), @CVE_UNI, @NUM_ECONOMICO, 
                @CVE_TIPO, 1, @COSTO, @SIGNO, @USUARIO, @CVE_CPTO, GETDATE(), NEWID())"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = TREFER.Text
                    cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = BUSCA_ARTICULO_EN_LLANTAS(TNUM_ECONOMICO.Text)
                    cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = "M"
                    cmd.Parameters.Add("@NUM_MOV", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
                    cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TNUM_ECONOMICO.Text
                    cmd.Parameters.Add("@CVE_TIPO", SqlDbType.VarChar).Value = tTIPO_LLANTA.Text
                    cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCOSTO.Text.Replace(",", ""))
                    cmd.Parameters.Add("@SIGNO", SqlDbType.SmallInt).Value = IIf(RadEntrada.Checked, 1, -1)
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                    cmd.Parameters.Add("@CVE_CPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            Try
                                '1   DIRECCION
                                '2   TRACCION
                                '3   SECCIONADA
                                '4   RENOVADO
                                '5   ORIGINAL
                                '6   TODAS POSICIONES
                                '7   GALLO
                                '8   RECHAZO
                                '9   TRACCCION
                                '10  SECCION
                                '11  ARRASTRE
                                If tTIPO_LLANTA.Text = "" Then

                                End If
                                'STATUS_LLANTA = 4 PARA RENOVAR
                                '1   ASIGNADA	A
                                '2   PENDIENTE POR ASIGNAR	A
                                '3   REPARACION	A
                                '4   PARA RENOVAR	A
                                '5   FIN DE VIDA UTIL	A
                                '6   DESECHO	A

                                Dim ST_LLANTA As Integer = 2
                                Try
                                    If Not IsNothing(LtStstus_LLanta.Tag) Then
                                        If IsNumeric(LtStstus_LLanta.Tag) Then
                                            ST_LLANTA = LtStstus_LLanta.Tag
                                        End If
                                    End If
                                Catch ex As Exception
                                End Try

                                SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = " & ST_LLANTA & ", TIPO_NUEVA_RENO = 1, POSICION = 0 
                                     WHERE NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
                                Using cmd4 As SqlCommand = cnSAE.CreateCommand
                                    cmd4.CommandText = SQL
                                    returnValue = cmd4.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using

                                GRABA_BITA("", tCVE_UNI.Text, 0, "M", "Movs. inv. llantas " & TNUM_ECONOMICO.Text & ", " &
                                           tTIPO_LLANTA.Text & ", " & tCOSTO.Text & ", concepto:" & tNUM_CPTO.Text, TREFER.Text)
                            Catch ex As Exception
                                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            MsgBox("El registro se grabo satisfactoriamente")
                            Me.Close()
                        Else
                            MsgBox("No se logro grabar el registro")
                        End If
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnNumEconomico_Click(sender As Object, e As EventArgs) Handles BtnNumEconomico.Click
        Try
Var2 = "Llantas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUM_ECONOMICO.Text = Var5
                LtArt.Text = Var8
                If IsNumeric(Var9) Then
                    tCOSTO.Text = Format(CDec(Var9), "###,###,##0.00")
                Else
                    tCOSTO.Text = "0"
                End If
                Var2 = "" : Var4 = "" : Var5 = ""
                tTIPO_LLANTA.Focus()
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_ECONOMICO_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_ECONOMICO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnNumEconomico_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TNUM_ECONOMICO_Validated(sender As Object, e As EventArgs) Handles TNUM_ECONOMICO.Validated
        Dim NoExist As Boolean
        Try
            If TNUM_ECONOMICO.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(CVE_ART,'') AS CVEART, NUM_ECONOMICO, COSTO_LLANTA_MN 
                        FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If Not dr.Read Then
                            NoExist = True
                            LtArt.Text = ""
                            tCOSTO.Text = ""
                        Else
                            NoExist = False
                            LtArt.Text = dr("CVEART")
                            tCOSTO.Text = Format(dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN"), "###,###,##0.00")
                        End If
                    End Using
                End Using
                If NoExist = True Then
                    MsgBox("Número económico inexistente verifique por favor")
                    TNUM_ECONOMICO.Text = ""
                    LtArt.Text = ""
                    TNUM_ECONOMICO.Select()
                Else
                    tTIPO_LLANTA.Focus()
                End If
            Else
                LtArt.Text = ""
                tCOSTO.Text = ""
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTipoLlanta_Click(sender As Object, e As EventArgs) Handles btnTipoLlanta.Click
        Try
            Var2 = "Tipo Llanta"
Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tTIPO_LLANTA.Text = Var4
                LtTipo.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCOSTO.Select()
            End If
        Catch ex As Exception
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tTIPO_LLANTA_KeyDown(sender As Object, e As KeyEventArgs) Handles tTIPO_LLANTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTipoLlanta_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            tCOSTO.Focus()
        End If
    End Sub

    Private Sub tTIPO_LLANTA_Validated(sender As Object, e As EventArgs) Handles tTIPO_LLANTA.Validated
        Try
            If tTIPO_LLANTA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo Llanta", tTIPO_LLANTA.Text)
                If DESCR <> "" Then
                    LtTipo.Text = DESCR
                    tCOSTO.Focus()
                Else
                    MsgBox("Tipo Llanta inexistente")
                    LtTipo.Text = ""
                    tTIPO_LLANTA.Text = ""
                    tTIPO_LLANTA.Select()
                End If
            Else
                LtTipo.Text = ""
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var5
                L2.Text = Var6
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TNUM_ECONOMICO.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                    TNUM_ECONOMICO.Focus()
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    L2.Text = ""
                End If
            Else
                L2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "GCLLANTAS_CONM"
            Var4 = ""
Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                LtStstus_LLanta.Text = Var6
                LtStstus_LLanta.Tag = Var7
                L1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If

        Catch Ex As Exception
            MsgBox("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNumCpto_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            RadEntrada.Focus()
        End If
    End Sub

    Private Sub tNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles tNUM_CPTO.Validated
        Try
            If tNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String

                Var6 = ""
                Var7 = ""

                DESCR = BUSCA_CAT("GCLLANTAS_CONM", tNUM_CPTO.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                    LtStstus_LLanta.Text = Var6
                    LtStstus_LLanta.Tag = Var7
                Else
                    MsgBox("Concepto inexistente")

                    LtStstus_LLanta.Text = ""
                    LtStstus_LLanta.Tag = "0"
                    tNUM_CPTO.Text = ""
                    tNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tNUM_CPTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tNUM_CPTO.PreviewKeyDown
        If e.KeyCode = 9 Then
            RadEntrada.Focus()
        End If

    End Sub
End Class
