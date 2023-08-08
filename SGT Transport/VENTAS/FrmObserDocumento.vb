Imports C1.Win.C1Themes
Public Class FrmObserDocumento
    Private Sub frmObserDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Me.CenterToScreen()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If TIPO_OTI = 0 Then
            TObser.MaxLength = 32767
        Else
            TObser.MaxLength = 255
        End If
        TObser.Text = Var4
        TObser.SelectionStart = 0

        If TIPO_COMPRA <> "o" And TIPO_COMPRA <> "q" Then
            If Var5 <> "NUEVO" Then
                TObser.Enabled = False
            End If
        End If
        'tObser.Select()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Var4 = TObser.Text
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmObserDocumento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub TObser_KeyDown(sender As Object, e As KeyEventArgs) Handles TObser.KeyDown
        Try
            'If e.KeyCode = 13 Then
            'e.SuppressKeyPress = True
            'btnAceptar.Focus()
            'e.Handled = True
            'End If
            'BtnAceptar.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TObser_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TObser.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                C1SplitterPanel2.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
