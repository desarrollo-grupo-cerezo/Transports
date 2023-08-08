Imports System.IO
Imports System.Data.SqlClient
Public Class FrmSQL
    Private ReadOnly BindingSource1 As New BindingSource

    Private ReadOnly Dt As New DataTable
    Private Sub FrmSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 50
            Fg.Height = Me.Height - TSQL3.Top - TSQL3.Height - 250

            CboConexiones.Items.Clear()
            CboConexiones.Items.Add("Querys 1, FACT")
            CboConexiones.Items.Add("Querys 2")

            Tab1.SelectedIndex = 0
            Tab2.SelectedIndex = 0

            Try
                If File.Exists(Application.StartupPath & "\SQ1.txt") Then TSQL.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ1.txt")
                If File.Exists(Application.StartupPath & "\SQ2.txt") Then TSQL2.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ2.txt")
                If File.Exists(Application.StartupPath & "\SQ3.txt") Then TSQL3.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ3.txt")
                If File.Exists(Application.StartupPath & "\SQ4.txt") Then TSQL4.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ4.txt")
                If File.Exists(Application.StartupPath & "\SQ5.txt") Then TSQL5.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ5.txt")
                If File.Exists(Application.StartupPath & "\SQ6.txt") Then TSQL6.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ6.txt")
                If File.Exists(Application.StartupPath & "\SQ7.txt") Then TSQL7.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ7.txt")
                If File.Exists(Application.StartupPath & "\SQ8.txt") Then TSQL8.Text = IO.File.ReadAllText(Application.StartupPath & "\SQ8.txt")
            Catch ex As Exception
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuExecute_Click(sender As Object, e As EventArgs) Handles MnuExecute.Click
        Try
            If TSQL.Text.Trim.Length > 0 Or TSQL2.Text.Trim.Length > 0 Or TSQL3.Text.Trim.Length > 0 Or TSQL4.Text.Trim.Length > 0 Or
                TSQL5.Text.Trim.Length > 0 Or TSQL6.Text.Trim.Length > 0 Or TSQL7.Text.Trim.Length > 0 Or TSQL8.Text.Trim.Length > 0 Then

                Select Case Tab2.SelectedIndex
                    Case 0
                        SQL = TSQL.Text
                    Case 1
                        SQL = TSQL2.Text
                    Case 2
                        SQL = TSQL3.Text
                    Case 3
                        SQL = TSQL4.Text
                    Case 4
                        SQL = TSQL5.Text
                    Case 5
                        SQL = TSQL6.Text
                    Case 6
                        SQL = TSQL7.Text
                    Case 7
                        SQL = TSQL8.Text
                    Case 8
                        SQL = Q9.Text
                End Select

                Dim cmd As New SqlCommand With {.Connection = cnSAE}

                Dim da As New SqlDataAdapter
                Dim dt As New DataTable

                da = New SqlDataAdapter(SQL, cnSAE)
                dt = New DataTable ' crear un DataTable
                da.Fill(dt)

                BindingSource1.DataSource = dt
                Select Case Tab1.SelectedIndex
                    Case 0
                        Fg.DataSource = BindingSource1.DataSource
                    Case 1
                        Fg.DataSource = BindingSource1.DataSource
                    Case 2
                        Fg.DataSource = BindingSource1.DataSource
                    Case 3
                        Fg.DataSource = BindingSource1.DataSource
                    Case 4
                        Fg.DataSource = BindingSource1.DataSource
                    Case 5
                        Fg.DataSource = BindingSource1.DataSource
                    Case 6
                        Fg.DataSource = BindingSource1.DataSource
                    Case 7
                        Fg.DataSource = BindingSource1.DataSource
                    Case 8
                        Fg.DataSource = BindingSource1.DataSource
                    Case 9
                        Fg.DataSource = BindingSource1.DataSource
                    Case 10
                        Fg.DataSource = BindingSource1.DataSource
                    Case 11
                        Fg.DataSource = BindingSource1.DataSource
                    Case 12
                        Fg.DataSource = BindingSource1.DataSource
                    Case 13
                        Fg.DataSource = BindingSource1.DataSource
                    Case 14
                        Fg.DataSource = BindingSource1.DataSource
                    Case 15
                        Fg.DataSource = BindingSource1.DataSource
                End Select

                Fg.AutoSizeCols()
                Lt.Text = "Registros encontrado " & Fg.Rows.Count - 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GRABA_QUERYS()
        Try
            If TSQL.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ1.TXT", TSQL.Text)
            End If
            If TSQL2.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ2.TXT", TSQL2.Text)
            End If
            If TSQL3.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ3.TXT", TSQL3.Text)
            End If
            If TSQL4.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ4.TXT", TSQL4.Text)
            End If
            If TSQL5.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ5.TXT", TSQL5.Text)
            End If
            If TSQL6.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ6.TXT", TSQL6.Text)
            End If
            If TSQL7.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ7.TXT", TSQL7.Text)
            End If
            If TSQL8.Text.Trim.Length > 0 Then
                BACKUP_OVER("SQ8.TXT", TSQL8.Text)
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmSQL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        GRABA_QUERYS()
        Me.Dispose()
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmSQL_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            MnuExecute_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub MnuNewSQL_Click(sender As Object, e As EventArgs) Handles MnuNewSQL.Click
        Try
            CREA_TABSQL("SQL2")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub CREA_TABSQL(fTab As String)
        Try
            Dim TabIndx As Integer

            Dim newpage As New C1.Win.C1Command.C1DockingTabPage With {
                .Text = fTab
            }
            'newpage.Tag = fFrm
            TabIndx = Tab1.SelectedIndex
            Tab1.TabPages.Add(newpage)
            If Fg Is Nothing Then
                TabIndx = 0
            Else
                If Fg2 Is Nothing Then
                    TabIndx = 1
                Else
                    If Fg3 Is Nothing Then
                        TabIndx = 2
                    Else
                        If Fg4 Is Nothing Then
                            TabIndx = 3
                        Else
                            If Fg5 Is Nothing Then
                                TabIndx = 4
                            End If
                        End If
                    End If
                End If
            End If
            Select Case TabIndx
                Case 0
                    Tab1.TabPages.Item(1).Controls.Add(Fg)
                    Fg.Dock = DockStyle.Fill
                    Fg.Rows.Count = 1
                    Fg.Rows(0).Height = 40
                Case 1
                    Tab1.TabPages.Item(1).Controls.Add(Fg2)
                    Fg2.Dock = DockStyle.Fill
                    Fg2.Rows.Count = 1
                    Fg2.Rows(0).Height = 40

                    Fg2.Styles.Alternate.BackColor = Color.LightBlue
                Case 2
                    Tab1.TabPages.Item(1).Controls.Add(Fg3)
                    Fg3.Dock = DockStyle.Fill
                    Fg3.Rows.Count = 1
                    Fg3.Rows(0).Height = 40
            End Select
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "SQL" & (Tab1.SelectedIndex + 1))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Tab1_SelectedTabChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedTabChanged
        Tab2.SelectedIndex = Tab1.SelectedIndex
    End Sub
    Private Sub Tab2_SelectedTabChanged(sender As Object, e As EventArgs) Handles Tab2.SelectedTabChanged
        Tab1.SelectedIndex = Tab2.SelectedIndex
        Select Case Tab2.SelectedIndex
            Case 0
                TSQL.Select()
            Case 1
                TSQL2.Select()
            Case 2
                TSQL3.Select()
            Case 3
                TSQL4.Select()
                TSQL4.Focus()
            Case 4
                TSQL5.Select()
            Case 5
                TSQL6.Select()
            Case 6
                TSQL7.Select()
            Case 7
                TSQL8.Select()
            Case 8
                Q9.Select()
            Case 9
                TSQL10.Select()
        End Select
    End Sub
    Private Sub CboConexiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConexiones.SelectedIndexChanged
        Try
            Select Case CboConexiones.SelectedIndex
                Case 0
                    TSQL.Text = "SELECT FIRST 20 * FROM FACTV01 ORDER BY FECHAELAB DESC"
                    TSQL2.Text = "SELECT FIRST 50 * FROM PAR_FACTV01 ORDER BY VERSION_SINC DESC "

                    TSQL3.Text = "SELECT FIRST 20 * FROM FACTP01 ORDER BY FECHAELAB DESC"
                    TSQL4.Text = "SELECT FIRST 50 * FROM PAR_FACTP01 ORDER BY VERSION_SINC DESC "

                    TSQL5.Text = "SELECT FIRST 20 * FROM FACTC01 ORDER BY FECHAELAB DESC"
                    TSQL6.Text = "SELECT FIRST 50 * FROM PAR_FACTC01 ORDER BY VERSION_SINC DESC"

                    TSQL7.Text = "SELECT FIRST 20 * FROM INVE01 WHERE CVE_ART = '"
                    TSQL8.Text = "SELECT FIRST 50 * FROM MINVE01 ORDER BY FECHAELAB DESC"
                Case 1
                    TSQL.Text = "SELECT FIRST 20 * FROM FACTV01 ORDER BY FECHAELAB DESC"
                    TSQL2.Text = "SELECT FIRST 50 * FROM PAR_FACTV01 ORDER BY VERSION_SINC DESC "

                    TSQL3.Text = "SELECT FIRST 20 * FROM CUEN_M01 ORDER BY FECHAELAB DESC"
                    TSQL4.Text = "SELECT FIRST 50 * FROM CUEN_DET01 ORDER BY FECHAELAB DESC"

                    TSQL5.Text = "SELECT FIRST 20 * FROM INVE01 WHERE CVE_ART = '"
                    TSQL6.Text = "SELECT FIRST 50 * FROM MINVE01 ORDER BY FECHAELAB DESC"
                Case 2

            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TSQL_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub TSQL2_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL2.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub TSQL3_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL3.KeyDown
        If e.KeyCode = Keys.F5 Then
            MnuExecute_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TSQL4_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL4.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub TSQL5_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL5.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub TSQL6_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL6.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub TSQL7_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL7.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub TSQL8_KeyDown(sender As Object, e As KeyEventArgs) Handles TSQL8.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                MnuExecute_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL.Text = TSQL.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg(0, Fg.Col) & " = " & Fg(Fg.Row, Fg.Col)
            Return
        End If
    End Sub
    Private Sub Fg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg2.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL2.Text = TSQL2.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg2(0, Fg2.Col) & " = " & Fg2(Fg6.Row, Fg2.Col)
            Return
        End If
    End Sub
    Private Sub Fg3_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg3.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL3.Text = TSQL3.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg3(0, Fg3.Col) & " = " & Fg3(Fg3.Row, Fg3.Col)
            Return
        End If
    End Sub
    Private Sub Fg4_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg4.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL4.Text = TSQL4.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg4(0, Fg4.Col) & " = " & Fg4(Fg4.Row, Fg4.Col)
            Return
        End If
    End Sub
    Private Sub Fg5_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg5.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL5.Text = TSQL5.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg5(0, Fg5.Col) & " = " & Fg5(Fg5.Row, Fg5.Col)
            Return
        End If
    End Sub
    Private Sub Fg6_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg6.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            'MsgBox("Control + D")
            TSQL6.Text = TSQL6.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg6(0, Fg6.Col) & " = " & Fg6(Fg6.Row, Fg6.Col)
            Return
        End If
    End Sub
    Private Sub Fg7_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg7.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL7.Text = TSQL7.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg7(0, Fg7.Col) & " = " & Fg7(Fg7.Row, Fg7.Col)
            Return
        End If
    End Sub
    Private Sub Fg8_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg8.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            TSQL8.Text = TSQL8.Text & vbNewLine & "DELETE FROM TABLA WHERE " & Fg8(0, Fg8.Col) & " = " & Fg8(Fg8.Row, Fg8.Col)
            Return
        End If
    End Sub
End Class
