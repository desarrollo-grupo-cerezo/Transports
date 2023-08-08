Imports C1.Win.C1Themes
Public Class frmTabComCargadoVacio
    Private Sub frmTabComCargadoVacio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Fg(1, 1) = "Cargado"
            Fg(2, 1) = "Vacio"

            Location = New Point(Var20, Var21)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmTabComCargadoVacio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Var4 = Fg(Fg.Row, 1)
            Me.Close()
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub
End Class
