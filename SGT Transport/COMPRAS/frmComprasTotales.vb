Imports C1.Win.C1Themes
Public Class frmComprasTotales
    Private Sub frmComprasTotales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            If Var7 = "TOTALES" Then
                btnGrabar.Visible = False
                btnCancelar.Text = "Cerrar"
            Else
                btnGrabar.Visible = True
                btnCancelar.Text = "Cancelar"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Var8 = "GRABAR"
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Var8 = "CANCELAR"
        Me.Close()
    End Sub
End Class
