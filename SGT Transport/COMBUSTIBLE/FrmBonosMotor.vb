Imports System.Data.SqlClient
Imports C1.Win.C1Themes

Public Class FrmBonosMotor
    Private Sub FrmBonosMotor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Me.CenterToScreen()
        Fg.Dock = DockStyle.Fill

        Me.Text = Var2 & ".- " & Var3
        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCATEVA WHERE CVE_MOT = " & Var2
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL") & vbTab & dr.ReadNullAsEmptyDecimal("BONO"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL2") & vbTab & dr.ReadNullAsEmptyDecimal("BONO2"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL3") & vbTab & dr.ReadNullAsEmptyDecimal("BONO3"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL4") & vbTab & dr.ReadNullAsEmptyDecimal("BONO4"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL5") & vbTab & dr.ReadNullAsEmptyDecimal("BONO5"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL6") & vbTab & dr.ReadNullAsEmptyDecimal("BONO6"))
                        Fg.AddItem("" & vbTab & dr("CALIF_GLOBAL7") & vbTab & dr.ReadNullAsEmptyDecimal("BONO7"))
                    End If
                End Using
            End Using
            Fg.Cols(1).Sort = C1.Win.C1FlexGrid.SortFlags.Ascending

            Me.Height = Fg.Rows.Count * Fg.Rows.DefaultSize + 50

            'Fg.Rows.DefaultSize = 50

        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try
    End Sub
    Private Sub FrmBonosMotor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class