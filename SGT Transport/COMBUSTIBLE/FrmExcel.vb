
Imports C1.Win.C1Themes
Imports C1.C1Excel
Imports C1.Win.C1Command

Public Class FrmExcel
    Private Sub FrmExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

    End Sub

    Private Sub FrmExcel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog()
            openExcelFileDialog.Filter = "Excel files (*.xls or .xlsx)|*.xls;*.xlsx"
            openExcelFileDialog.FilterIndex = 1
            openExcelFileDialog.RestoreDirectory = True
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                tExcel.Text = openExcelFileDialog.FileName
                CARGAR_HOJAS()
            Else
                tExcel.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_HOJAS()
        Try
            C1XLBook1.Clear()
            C1XLBook1.Load(tExcel.Text)

            Dim source As XLSheet = C1XLBook1.Sheets(0)
            cboHojas.Items.Clear()
            For k = 0 To C1XLBook1.Sheets.Count - 1
                cboHojas.Items.Add(C1XLBook1.Sheets(k).Name)
            Next
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As ClickEventArgs) Handles BarAceptar.Click
        Try

            If cboHojas.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione una hoja del libro de excel")
                Return
            End If
            If tExcel.Text.Trim.Length = 0 Then
                MsgBox("Por favor caqpture el archivo de excel")
                btnExcel.Focus()
                Return
            End If

            Var2 = tExcel.Text
            Var4 = cboHojas.Text
            Me.Close()

        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
