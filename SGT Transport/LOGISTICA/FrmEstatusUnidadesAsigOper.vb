Public Class FrmEstatusUnidadesAsigOper
    Private Sub FrmEstatusUnidadesAsigOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

    End Sub

    Private Sub FrmEstatusUnidadesAsigOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click


        If Not IsNumeric(TCVE_OPER.Text) Then
            MsgBox("Por favor seleccione un operador")
            Return
        End If

        If BUSCA_CAT("Operador", TCVE_OPER.Text) = "" Then
            MsgBox("Operador inexistente, verifique por favor")
            Return
        End If

        Var26 = TCVE_OPER.Text.Trim

        Me.Close()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class