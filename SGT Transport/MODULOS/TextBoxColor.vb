Public Class TextBoxEx
    Inherits TextBox
    Private Sub TextBoxEx_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Me.BackColor = Color.LightCyan
    End Sub

    Private Sub TextBoxEx_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        If Me.Text <> "" Then
            Me.BackColor = Color.LightGreen
        Else
            Me.BackColor = Color.White
        End If
    End Sub
End Class