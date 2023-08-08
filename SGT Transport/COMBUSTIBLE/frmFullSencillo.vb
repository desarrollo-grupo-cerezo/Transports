Public Class frmFullSencillo
    Private Sub frmFullSencillo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Fg(1, 1) = "Full"
            Fg(2, 1) = "Sencillo"
            Location = New Point(Var20, Var21)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Var4 = Fg(Fg.Row, 1)
            Me.Close()
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub frmFullSencillo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
