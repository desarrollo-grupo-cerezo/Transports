Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmValeCombustibleAE
    Private PassDataForm As String
    Private NewRecord As Boolean = False
    Private Sub frmValeCombustibleAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        PassDataForm = PassData
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy hh:mm:ss"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.EditFormat.CustomFormat = "dd/MM/yyyy hh:mm:ss"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If


        tCVE_FOLIO.Text = ""
        F1.Value = Now
        F2.Value = Now
        tVALE_GAS.Text = ""
        tCVE_UNI.Text = ""
        tCVE_GAS.Text = ""
        tCVE_CAR.Text = ""
        tPrecio.Value = 0
        tImporte.Value = 0
        tLITROS.Value = 0
        tLITROS.Value = 0
        tOBSER.Text = ""
        tNUM_CPTO.Text = ""
        If Var1 = "Nuevo" Then
            Try
                tCVE_FOLIO.Text = GET_MAX("GCVALE_COMBUSTIBLE", "CVE_FOLIO", 0, " WHERE TIPO = 'VC'")
                tCVE_FOLIO.Enabled = False
                tVALE_GAS.Select()
            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT V.CVE_FOLIO, V.FECHA_VALE, V.FECHA_CARGA, V.VALE_GAS, V.CVE_UNI, V.CVE_GAS, V.CVE_CAR, V.PRECIO, V.IMPORTE, " &
                    "V.LITROS, V.LITROS_REAL, ISNULL(OB.DESCR,'') AS OBS_STR, V.CVE_OBS, V.NUM_CPTO " &
                    "FROM GCVALE_COMBUSTIBLE V " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = V.CVE_OBS " &
                    "WHERE CVE_FOLIO = '" & Var2 & "' AND STATUS = 'A' AND TIPO = 'VC'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_FOLIO.Text = dr("CVE_FOLIO")
                    If IsDate(dr("FECHA_VALE")) Then
                        F1.Value = dr("FECHA_VALE")
                    Else
                        F1.Value = Now
                    End If
                    If IsDate(dr("FECHA_CARGA")) Then
                        F2.Value = dr("FECHA_CARGA")
                    Else
                        F2.Value = Now
                    End If
                    tVALE_GAS.Text = dr("VALE_GAS")
                    tCVE_UNI.Text = dr("CVE_UNI")
                    LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Text)

                    tCVE_GAS.Text = dr("CVE_GAS")
                    LtGas.Text = BUSCA_CAT("Gasolinera", tCVE_GAS.Text)

                    tCVE_CAR.Text = dr("CVE_CAR")
                    Var10 = 99999
                    LtCartaPorte.Text = BUSCA_CAT("Carta Porte", tCVE_CAR.Text)

                    tPrecio.Value = dr("PRECIO")
                    tImporte.Value = dr("IMPORTE")
                    tLITROS.Value = dr("LITROS")
                    tLITROS.Value = dr("LITROS_REAL")
                    tOBSER.Text = dr("OBS_STR")
                    tOBSER.Tag = dr("CVE_OBS")
                    tNUM_CPTO.Text = dr("NUM_CPTO")
                    LtConc.Text = BUSCA_CAT("ConcCxP", tNUM_CPTO.Text)
                End If
                dr.Close()

                tCVE_FOLIO.Enabled = False
                tVALE_GAS.Select()
            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmValeCombustibleAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmValeCombustibleAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_OBS As Long
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            If tOBSER.Text.Trim.Length > 0 Then
                If IsNumeric(tOBSER.Tag) Then
                    CVE_OBS = tOBSER.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tOBSER.Text & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tOBSER.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If

            tOBSER.Tag = CVE_OBS

        Catch ex As Exception
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCVALE_COMBUSTIBLE SET FECHA_VALE = @FECHA_VALE, NUM_CPTO = @NUM_CPTO,
            FECHA_CARGA = @FECHA_CARGA, VALE_GAS = @VALE_GAS, CVE_UNI = @CVE_UNI, CVE_GAS = @CVE_GAS, CVE_CAR = @CVE_CAR,
            PRECIO = @PRECIO, IMPORTE = @IMPORTE, LITROS = @LITROS, LITROS_REAL = @LITROS_REAL, CVE_OBS = @CVE_OBS
            WHERE CVE_FOLIO = @CVE_FOLIO AND TIPO = 'VC'
            IF @@ROWCOUNT = 0
            INSERT INTO GCVALE_COMBUSTIBLE (TIPO, CVE_FOLIO, STATUS, FECHA, FECHA_VALE, FECHA_CARGA, VALE_GAS, CVE_UNI, CVE_GAS, CVE_CAR, PRECIO,
            IMPORTE, LITROS, LITROS_REAL, CVE_OBS, NUM_CPTO) VALUES(@TIPO, @CVE_FOLIO, 'A', CONVERT(varchar, GETDATE(), 112), @FECHA_VALE,
            @FECHA_CARGA, @VALE_GAS, @CVE_UNI, @CVE_GAS, @CVE_CAR, @PRECIO, @IMPORTE, @LITROS, @LITROS_REAL, @CVE_OBS, @NUM_CPTO)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_FOLIO.Text)
            cmd.Parameters.Add("@FECHA_VALE", SqlDbType.DateTime).Value = F1.Value
            cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.Date).Value = F2.Value
            cmd.Parameters.Add("@VALE_GAS", SqlDbType.VarChar).Value = tVALE_GAS.Text
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
            cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = tCVE_GAS.Text
            cmd.Parameters.Add("@CVE_CAR", SqlDbType.VarChar).Value = tCVE_CAR.Text
            cmd.Parameters.Add("@PRECIO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tPrecio.Text)
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte.Text)
            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tLITROS.Text)
            cmd.Parameters.Add("@LITROS_REAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tLITROS.Text)
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "VC"
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_DECIMAL(tNUM_CPTO.Text)
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
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub btnCarPorte_Click(sender As Object, e As EventArgs) Handles btnCarPorte.Click
        Try
            Var2 = "Carta Porte"
            Var4 = ""
            Var5 = ""
            Var10 = "0"
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CAR.Text = Var4
                LtCartaPorte.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tPrecio.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnUnidad_Click(sender As Object, e As EventArgs) Handles btnUnidad.Click
        Try
            Var2 = "Unidades"
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var4
                LtUnidad.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_GAS.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tOBSER_KeyDown(sender As Object, e As KeyEventArgs) Handles tOBSER.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If CType(sender, TextBox).Multiline Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUnidad_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnGas_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_CAR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_CAR.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCarPorte_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub btnFormaPago_Click(sender As Object, e As EventArgs) Handles btnFormaPago.Click
        Try
            Var2 = "ConcCxP"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                LtConc.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnFormaPago_Click(Nothing, Nothing)
                Return
            End If

        Catch ex As Exception
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles tNUM_CPTO.Validated
        Try
            BUSCA_UNIDAD(tNUM_CPTO.Text)
            If Var4 <> "NO" Then
                LtConc.Text = Var5
            Else
                MsgBox("Concepto inexistente")
            End If
        Catch ex As Exception
            Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("104. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnGas_Click(sender As Object, e As EventArgs) Handles btnGas.Click
        Try
            Var2 = "Gasolinera"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_GAS.Text = Var4
                LtGas.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_CAR.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_CAR_Validated(sender As Object, e As EventArgs) Handles tCVE_CAR.Validated
        Try
            Dim DESCR As String
            If tCVE_GAS.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", tCVE_GAS.Text)
                If DESCR <> "" Then
                    Var3 = ""
                Else
                    MsgBox("Gasolinera inexistente")
                    tCVE_GAS.Text = ""
                End If
            Else
                tCVE_GAS.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
