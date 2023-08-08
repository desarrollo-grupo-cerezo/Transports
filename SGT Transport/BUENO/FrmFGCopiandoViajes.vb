Public Class FrmFGCopiandoViajes
    Private Sub FrmFGCopiandoViajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Fg.Cols(1).StarWidth = "3*"
        Fg.Cols(2).StarWidth = "*"

    End Sub

    Private Sub FrmFGCopiandoViajes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub
End Class