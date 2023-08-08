Imports System.Data.SqlClient
Public Class frmGasolinerasAE
    Private Sub frmGasolinerasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        Try
            tCVE_GAS.Text = ""
            tPRECIO.Value = 0
            tKM.Value = 0
            tNORMA.Text = ""
            tDescr.Text = ""
            tCUEN_CONT.Text = ""
            tCORREO.Text = ""
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tCVE_GAS.Text = GET_MAX("GCGASOLINERAS", "CVE_GAS")
                tCVE_GAS.Enabled = False
                tDescr.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT G.CVE_GAS, G.STATUS, G.DESCR, ISNULL(G.CVE_PROV,'') AS CVE_PRO, ISNULL(NOMBRE,'') AS NOMB, G.PRECIO, G.KM, G.NORMA, CUEN_CONT, CORREO 
                    FROM GCGASOLINERAS G 
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                    WHERE CVE_GAS = '" & Var2 & "' AND G.STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_GAS.Text = dr("CVE_GAS")
                    tDescr.Text = dr("DESCR")
                    tCVE_PROV.Text = dr("CVE_PRO")
                    L3.Text = dr("NOMB")
                    If IsNumeric(dr("PRECIO").ToString) Then
                        tPRECIO.Value = dr("PRECIO").ToString
                    End If
                    If IsNumeric(dr("KM").ToString) Then
                        tKM.Value = dr("KM").ToString
                    End If
                    tNORMA.Text = dr("NORMA").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                    tCORREO.Text = dr.ReadNullAsEmptyString("CORREO")
                End If
                dr.Close()

                tCVE_GAS.Enabled = False
                tDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Me.CenterToScreen()

    End Sub

    Private Sub frmGasolinerasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmGasolinerasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCGASOLINERAS SET CVE_GAS = @CVE_GAS, DESCR = @DESCR, CVE_PROV = @CVE_PROV, CUEN_CONT = @CUEN_CONT,
            PRECIO = @PRECIO, KM = @KM, NORMA = @NORMA, CORREO = @CORREO
            WHERE CVE_GAS = @CVE_GAS
            IF @@ROWCOUNT = 0
            INSERT INTO GCGASOLINERAS (CVE_GAS, STATUS, DESCR, CVE_PROV, PRECIO, KM, NORMA, CUEN_CONT, CORREO)
            VALUES (@CVE_GAS, 'A', @DESCR, @CVE_PROV, @PRECIO, @KM, @NORMA, @CUEN_CONT, @CORREO)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = tCVE_GAS.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = tCVE_PROV.Text
            cmd.Parameters.Add("@PRECIO", SqlDbType.Float).Value = tPRECIO.Text
            cmd.Parameters.Add("@KM", SqlDbType.Float).Value = tKM.Text
            cmd.Parameters.Add("@NORMA", SqlDbType.VarChar).Value = tNORMA.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = tCORREO.Text
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
    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                L3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tPRECIO.Focus()
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnProv_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(tCVE_PROV.Text.Trim) Then
                    DESCR = tCVE_PROV.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    tCVE_PROV.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", tCVE_PROV.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    tCVE_PROV.Text = ""
                    L3.Text = ""
                End If
            Else
                L3.Text = ""
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCORREO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCORREO.KeyDown
        If e.KeyCode = 13 Then
            tDescr.Focus()
        End If
    End Sub

    Private Sub tCORREO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCORREO.PreviewKeyDown
        If e.KeyCode = 9 Then
            tDescr.Focus()
        End If
    End Sub
End Class
