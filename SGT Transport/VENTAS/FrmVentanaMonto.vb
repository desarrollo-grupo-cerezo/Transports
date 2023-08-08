Public Class FrmVentanaMonto
    Dim PAGOS As Decimal
    Dim NUM_CP As Integer
    Private Sub frmVentanaMonto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AssignValidation(TMONTO, ValidationType.Only_Numbers)
        NUM_CP = Var21
        PAGOS = Var22
        TMONTO.Text = PAGOS
    End Sub
    Private Sub frmVentanaMonto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        VarFORM2 = ""
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            If CDec(TMONTO.Text) > PAGOS And NUM_CP <> 10 Then
                MsgBox("El pago no puede ser mayor a importe, verifique por favor")
                Return
            End If
            If CDec(TMONTO.Text) = 0 Then
                MsgBox("El pago no puede ser cero, verifique por favor")
                Return
            End If
            VarFORM2 = TMONTO.Text
            Me.Close()
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub tMONTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMONTO.KeyDown
        Try
            If e.KeyCode = 13 Then
                btnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tMONTO_GotFocus(sender As Object, e As EventArgs) Handles TMONTO.GotFocus
        TMONTO.SelectAll()
    End Sub

    Private Sub frmVentanaMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmVentanaMonto_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
