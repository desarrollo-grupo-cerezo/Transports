Public Class FrmVentanaTipoVenta
    Private Sub frmVentanaTipoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub frmVentanaTipoVenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If radContado.Checked Then
            VarFORM = "CONTADO"
        Else
            VarFORM = "CREDITO"
        End If

        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        VarFORM = ""
        Me.Close()
    End Sub
    Private Sub frmVentanaTipoVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = 13 Then
                btnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub radContado_KeyDown(sender As Object, e As KeyEventArgs) Handles radContado.KeyDown
        Try
            If e.KeyCode = 13 Then
                btnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub radCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles radCredito.KeyDown
        Try
            If e.KeyCode = 13 Then
                btnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
