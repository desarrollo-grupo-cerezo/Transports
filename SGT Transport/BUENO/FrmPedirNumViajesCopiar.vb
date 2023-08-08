Public Class FrmPedirNumViajesCopiar
    Private Sub FrmPedirNumViajesCopiar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        TNUM_VIAJES_COPIAR.Value = 0
        Var44 = 0
    End Sub

    Private Sub FrmPedirNumViajesCopiar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        Try
            TNUM_VIAJES_COPIAR.UpdateValueWithCurrentText()

            If TNUM_VIAJES_COPIAR.Value = 0 And TNUM_VIAJES_COPIAR.Value < 20 Then
                MsgBox("Por favor capture un número mayor a cero")
                Return
            End If

            Var44 = TNUM_VIAJES_COPIAR.Value
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class