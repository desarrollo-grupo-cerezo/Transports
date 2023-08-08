Imports C1.Win.C1Themes

Public Class FrmRepLlantasSinAsignar
    Private Sub FrmRepLlantasSinAsignar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmRepLlantasSinAsignar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
