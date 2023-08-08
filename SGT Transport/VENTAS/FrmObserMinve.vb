Public Class FrmObserMinve
    Private Sub frmObserMinve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Me.CenterToScreen()

        TObser.Text = Var4
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Var4 = TObser.Text
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Var4 = "-99"
        Me.Close()
    End Sub

    Private Sub tObser_KeyDown(sender As Object, e As KeyEventArgs) Handles TObser.KeyDown
        If e.KeyCode = 9 Then
            BtnAceptar.Focus()
        End If
    End Sub

    Private Sub tObser_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TObser.PreviewKeyDown
        If e.KeyCode = 9 Then
            BtnAceptar.Focus()
        End If
    End Sub
End Class
