Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmRutasExcelXUsuario
    Private Sub FrmRutasExcelXUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            SplitM.SplitterWidth = 1
        Catch ex As Exception
        End Try
        Try
            Dim SQLstr As String = "SELECT NIVEL, USUARIO, NOMBRE FROM GCUSUARIOS ORDER BY USUARIO"
            Dim z As Integer = 0, RUTA_EX As String

            Fg.Rows.Count = 1
            Fg.Dock = DockStyle.Fill

            Fg.Cols(1).Width = 120
            Fg.Cols(2).Width = 250
            Fg.Cols(3).Width = 600
            Fg.Cols(3).ComboList = "|..."
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Me.Width = Fg.Cols(0).Width + Fg.Cols(1).Width + Fg.Cols(2).Width + Fg.Cols(3).Width + 100
            Me.CenterToScreen()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQLstr
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read()
                        RUTA_EX = ""
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT ISNULL(RUTA_EXCEL,'') AS RUTA_EX 
                                FROM GCPARAM_RUTA_EXCEL_USER 
                                WHERE USUARIO = '" & dr("USUARIO") & "'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    RUTA_EX = dr2("RUTA_EX")
                                End If
                            End Using
                        End Using
                        Fg.AddItem("" & vbTab & dr.ReadNullAsEmptyString("USUARIO") & vbTab &
                                    dr.ReadNullAsEmptyString("NOMBRE") & vbTab & RUTA_EX)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmRutasExcelXUsuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) And Not IsNothing(Fg(k, 3)) Then
                    SQL = "UPDATE GCPARAM_RUTA_EXCEL_USER SET RUTA_EXCEL = '" & Fg(k, 3) & "' 
                        WHERE USUARIO = '" & Fg(k, 1) & "' 
                        IF @@ROWCOUNT = 0 
                        INSERT INTO GCPARAM_RUTA_EXCEL_USER (USUARIO, RUTA_EXCEL) VALUES('" &
                        Fg(k, 1) & "','" & Fg(k, 3) & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            Next
            MsgBox("Las rutas por usuario se grabaron correctamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            FolderBrowserDialog1.SelectedPath = Application.StartupPath
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                Fg(Fg.Row, 3) = FolderBrowserDialog1.SelectedPath
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                Fg.SetCellImage(rowNumber, 4, My.Resources.equis)
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 4 Then
                    Fg(Fg.Row, 3) = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
