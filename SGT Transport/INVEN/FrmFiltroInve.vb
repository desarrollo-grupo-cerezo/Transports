Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Public Class FrmFiltroInve
    Private Sub FrmFiltroInve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
        C1ThemeController.ApplyThemeToControlTree(Me, theme)

        Me.CenterToScreen()

        Fg.Dock = DockStyle.Fill

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_LIN, DESC_LIN FROM CLIN" & Empresa & " WHERE STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_LIN") & vbTab & dr("DESC_LIN"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmFiltroInve_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BarAplicarFiltro.Click
        Try
            Dim z As Integer = 0
            Var47 = ""

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    Var47 += "LIN_PROD = '" & Fg(k, 2) & "' OR "
                End If
            Next
            If Var47 <> "" Then
                Var47 = " AND (" & Var47.Substring(0, Var47.Length - 4) & ")"
            End If
            If ChExist.Checked Then
                Var3 = "S"
            Else
                Var3 = "N"
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If e.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class