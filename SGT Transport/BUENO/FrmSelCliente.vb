Public Class FrmSelCliente
    Private Sub FrmSelCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        'Me.ShowInTaskbar = False
    End Sub
    Private Sub FrmSelCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnCliente_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                BtnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = TCLIENTE.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Value = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                Else
                    LtNombre.Text = DESCR
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un cliente")
                Return
            End If

            Try
                If TCLIENTE.Text.Trim.Length > 0 Then
                    Dim DESCR As String
                    If IsNumeric(TCLIENTE.Text.Trim) Then
                        DESCR = TCLIENTE.Text.Trim
                        DESCR = Space(10 - DESCR.Length) & DESCR
                        TCLIENTE.Value = DESCR
                    End If
                    DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                    If DESCR = "" Then
                        MsgBox("Cliente inexistente")
                        TCLIENTE.Text = ""
                        LtNombre.Text = ""
                    Else
                        LtNombre.Text = DESCR
                    End If
                Else
                    LtNombre.Text = ""
                End If
            Catch ex As Exception
                Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


            Var4 = TCLIENTE.Text
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "CLIE"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""

            'FrmSelItem.ShowDialog()
            Dim f As New FrmSelItem With {.MdiParent = MainRibbonForm.Owner, .TopLevel = True, .TopMost = True}
            f.ShowDialog()

            MainRibbonForm.Tab1.BringToFront()

            'Me.BringToFront()
            'MainRibbonForm.BringToFront()
            'Me.BringToFront()

            If Var4.Trim.Length > 0 Then
                TCLIENTE.Value = Var4
                LtNombre.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class