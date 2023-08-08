Imports C1.Win.C1Themes
Public Class FrmVencDocAE
    Private Sub FrmVencDocAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Var13 = ""
        Var14 = ""
        Var15 = ""
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Var13 = tBox1.Text.Trim
            Var14 = tBox2.Text.Trim
            Var15 = F1.Value

            If Var13.Length = 0 Then
                MsgBox("El documento no puede quedar vacio")
                Return
            End If

            If Var14.Length = 0 Then
                MsgBox("El nombre no puede quedar vacio")
                Return
            End If

            Me.Close()
            Me.Dispose()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
End Class
