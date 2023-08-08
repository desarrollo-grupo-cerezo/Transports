Imports System.ComponentModel
Imports C1.Win.C1Themes
Public Class FrmFiltroConciValCombus
    Private Sub FrmFiltroConciValCombus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            BtnProv.FlatStyle = FlatStyle.Flat
            BtnProv.FlatAppearance.BorderSize = 0

            BtnProv2.FlatStyle = FlatStyle.Flat
            BtnProv2.FlatAppearance.BorderSize = 0

            If Var8 = "UTILITARIOS" Then
                Lt1.Visible = False
                Lt2.Visible = False
                Lt3.Visible = False
                TCVE_PROV.Visible = False
                TCVE_PROV2.Visible = False
                BtnProv.Visible = False
                BtnProv2.Visible = False
            End If
            Me.CenterToScreen()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmFiltroConciValCombus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BarAplicarFiltro.Click
        Try
            If TCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV.Text.Trim) Then
                    DESCR = TCVE_PROV.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TCVE_PROV.Text)
                If DESCR = "" Then
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV2.Text = ""
                    Return
                End If
            End If
            If TCVE_PROV2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV2.Text.Trim) Then
                    DESCR = TCVE_PROV2.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TCVE_PROV2.Text)
                If DESCR = "" Then
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV2.Text = ""
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Var2 = FSQL(F1.Value)
            Var3 = FSQL(F2.Value)
            Var4 = TCVE_PROV.Text
            Var5 = TCVE_PROV2.Text

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles BtnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROV.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCVE_PROV2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                TCVE_PROV2.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_PROV_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV.Validated
        Try
            If TCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV.Text.Trim) Then
                    DESCR = TCVE_PROV.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TCVE_PROV.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProv2_Click(sender As Object, e As EventArgs) Handles BtnProv2.Click
        Try
            Var2 = "Prov"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROV2.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv2_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                TCVE_PROV.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_PROV2_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV2.Validated
        Try
            If TCVE_PROV2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV2.Text.Trim) Then
                    DESCR = TCVE_PROV2.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TCVE_PROV2.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV2.Text = ""
                End If
            Else
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_PROV2.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCVE_PROV.Focus()
        End If
    End Sub
    Private Sub TCVE_PROV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_PROV.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCVE_PROV2.Focus()
            e.IsInputKey = True
        End If
    End Sub
End Class
