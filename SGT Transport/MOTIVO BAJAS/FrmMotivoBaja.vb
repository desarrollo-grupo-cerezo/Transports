Imports C1.C1Preview
Imports C1.Win.C1Editor
Imports C1.Win.C1Themes
Public Class FrmMotivoBaja
    Private Sub FrmMotivoBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        TObser.MaxLength = 255

        TObser.Text = Var4
        Me.Text = Var5

        TObser.SelectionStart = 0

        TObser.Select()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Dim d As New Dictionary(Of String, Integer)
        Dim i As Integer, CADENA As String = "", NumRep As Boolean = False

        Try
            Var4 = TObser.Text.Trim

            For i = 0 To Var4.Length - 1
                If d.ContainsKey(Var4.Substring(i, 1)) Then
                    d.Item(Var4.Substring(i, 1)) += 1
                Else
                    d.Add(Var4.Substring(i, 1), 1)
                End If
            Next

            For Each pair As KeyValuePair(Of String, Integer) In d
                CADENA += pair.Key.ToString & " " & pair.Value & ", "
                If pair.Value > 99 Then
                    NumRep = True
                End If
            Next

            If NumRep Then
                MsgBox("Por favor no repita caracteres")
                Var4 = ""
                Return
            End If
            If Var4.Trim.Length < 30 Then
                MsgBox("Por favor capture al menos 30 caracteres")
                Var4 = ""
                Return
            End If

        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Close()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Var4 = ""
        Me.Close()
    End Sub

    Private Sub FrmMotivoBaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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
    Private Sub FrmMotivoBaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If Var4.Trim.Length > 0 Then
        'If Var4.Trim.Length < 30 Then
        'MsgBox("Por favor capture al menos 30 caracteres")
        'cancel = True
        'End If
        'End If
    End Sub
End Class
