Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmLLantasShowNumEcoCompras
    Private Sub FrmLLantasShowNumEcoCompras_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Dim z As Integer = 0, SIGNO As Integer

            If Var25 = "c" Then
                SIGNO = 1
            Else
                SIGNO = -1
            End If
            PassData4 = "no"
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO 
                    FROM GCLLA_REN_COMP WHERE CVE_DOC = '" & Var24 & "' AND TIPO_DOC = '" & Var25 & "' ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            z += 1
                            Fg.AddItem(z & vbTab & dr("NUM_ECONOMICO"))
                        Catch ex As Exception
                            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            Me.CenterToParent()

        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmLLantasShowNumEcoCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
