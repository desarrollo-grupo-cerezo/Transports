Imports System.Data.SqlClient
Public Class frmPolizaSeguroAE
    Private Sub frmPolizaSeguroAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

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

        tFECHA.Value = Date.Today
        tFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.CustomFormat = "dd/MM/yyyy"
        tFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

        tCVE_PROV.MaxLength = 10
        tCOBERTURA.MaxLength = 255

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        tIDPoliza.Text = ""
        tFolio.Text = ""
        tTIPO_POL.Text = ""
        tCVE_ASE.Text = ""
        tCVE_PROV.Text = ""
        F1.Value = Now
        F2.Value = Now
        tCOSTO.Value = 0
        tCOBERTURA.Text = ""
        LtTipoPol.Text = ""
        LtEquiAse.Text = ""
        LtProv.Text = ""

        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tIDPoliza.Text = GET_MAX("GCPOLIZAS", "IDPOLIZA")
                tIDPoliza.Enabled = False
                tFolio.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.IDPOLIZA, P.STATUS, P.FOLIO, P.TIPO_POL, P.CVE_ASE, P.CVE_PROV, P.INICIO, P.TERMINO, P.COSTO, P.TIPO_COBERTURA " &
                    "FROM GCPOLIZAS P WHERE IDPOLIZA = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tIDPoliza.Text = dr("IDPOLIZA").ToString
                    tFolio.Text = dr("FOLIO").ToString
                    tTIPO_POL.Text = dr("TIPO_POL").ToString
                    If tTIPO_POL.Text = "0" Then tTIPO_POL.Text = ""
                    LtTipoPol.Text = BUSCA_CAT("Tipo poliza", tTIPO_POL.Text)

                    tCVE_ASE.Text = dr("CVE_ASE").ToString
                    If tCVE_ASE.Text = "0" Then tCVE_ASE.Text = ""
                    LtEquiAse.Text = BUSCA_CAT("Equipo Asegurado", tCVE_ASE.Text)

                    tCVE_PROV.Text = dr("CVE_PROV").ToString
                    LtProv.Text = BUSCA_CAT("Aseguradoras", tCVE_PROV.Text)

                    F1.Value = dr("INICIO").ToString
                    F2.Value = dr("TERMINO").ToString
                    tCOSTO.Value = dr("COSTO").ToString
                    tCOBERTURA.Text = dr("TIPO_COBERTURA").ToString
                End If
                dr.Close()

                tIDPoliza.Enabled = False
                tFolio.Select()
            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmPolizaSeguroAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmPolizaSeguroAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim cmd As New SqlCommand

        cmd.Connection = cnSAE

        SQL = "UPDATE GCPOLIZAS SET FOLIO = @FOLIO, TIPO_POL = @TIPO_POL, CVE_ASE = @CVE_ASE, CVE_PROV = @CVE_PROV, " &
            "INICIO = @INICIO, TERMINO = @TERMINO, COSTO = @COSTO, TIPO_COBERTURA = @TIPO_COBERTURA " &
            " WHERE IDPOLIZA = @IDPOLIZA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPOLIZAS (IDPOLIZA, STATUS, FOLIO, TIPO_POL, CVE_ASE, CVE_PROV, INICIO, TERMINO, COSTO, TIPO_COBERTURA, GUID)" &
            " VALUES(@IDPOLIZA, 'A', @FOLIO, @TIPO_POL, @CVE_ASE, @CVE_PROV, @INICIO, @TERMINO, @COSTO, @TIPO_COBERTURA, NEWID())"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@IDPOLIZA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tIDPoliza.Text)
            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFolio.Text)
            cmd.Parameters.Add("@TIPO_POL", SqlDbType.Int).Value = CONVERTIR_TO_INT(tTIPO_POL.Text)
            cmd.Parameters.Add("@CVE_ASE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_ASE.Text)
            cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = tCVE_PROV.Text
            cmd.Parameters.Add("@INICIO", SqlDbType.Date).Value = F1.Value
            cmd.Parameters.Add("@TERMINO", SqlDbType.Date).Value = F2.Value
            cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = tCOSTO.Value
            cmd.Parameters.Add("@TIPO_COBERTURA", SqlDbType.VarChar).Value = tCOBERTURA.Text
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

    Private Sub btnTipoPol_Click(sender As Object, e As EventArgs) Handles btnTipoPol.Click
        Try
            Var2 = "Tipo Poliza"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tTIPO_POL.Text = Var4
                LtTipoPol.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_ASE.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEquipoAseg_Click(sender As Object, e As EventArgs) Handles btnEquipoAseg.Click
        Try
            Var2 = "Equipo Asegurado"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ASE.Text = Var4
                LtEquiAse.Text = Var5
                Var2 = "" : Var4 = ""
                tCVE_PROV.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "GCASEGURADORAS"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                LtProv.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tTIPO_POL_KeyDown(sender As Object, e As KeyEventArgs) Handles tTIPO_POL.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTipoPol_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tTIPO_POL_Validated(sender As Object, e As EventArgs) Handles tTIPO_POL.Validated
        Try
            If tTIPO_POL.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo poliza", tTIPO_POL.Text)
                If DESCR <> "" Then
                    LtTipoPol.Text = DESCR
                Else
                    MsgBox("Tipo de poliza inexistente")
                    tTIPO_POL.Text = ""
                    tTIPO_POL.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_ASE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ASE.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnEquipoAseg_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_ASE_Validated(sender As Object, e As EventArgs) Handles tCVE_ASE.Validated
        Try
            If tCVE_ASE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Equipo Asegurado", tCVE_ASE.Text)
                If DESCR <> "" Then
                    LtEquiAse.Text = DESCR
                Else
                    MsgBox("Equipo asegurado inexistente")
                    tCVE_ASE.Text = ""
                    tCVE_ASE.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnProv_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Aseguradoras", tCVE_PROV.Text)
                If DESCR <> "" Then
                    LtProv.Text = DESCR
                Else
                    MsgBox("Aseuradora inexistente")
                    tCVE_PROV.Text = ""
                    tCVE_PROV.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
