Imports C1.Win.C1Themes
Public Class FrmEfectivo
    Private Sub FrmCapturaEfectivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            TIMPORTE_RECIBIDO.Value = Var48

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCapturaEfectivo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            Var48 = TIMPORTE_RECIBIDO.Value
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub TIMPORTE_RECIBIDO_TextChanged(sender As Object, e As EventArgs) Handles TIMPORTE_RECIBIDO.TextChanged
        Dim IMPORTE As Decimal = 0
        Try

            If IsNumeric(LtImporteTotal.Text.Replace(",", "")) Then
                IMPORTE = Convert.ToDecimal(LtImporteTotal.Text.Replace(",", ""))
            End If

            LtCambio.Text = IMPORTE - Convert.ToDecimal(TIMPORTE_RECIBIDO.Text)

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub
End Class