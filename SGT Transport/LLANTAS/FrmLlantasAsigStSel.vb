Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmLlantasAsigStSel
    Private Sub FrmLlantasAsigStSel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_STATUS, DESCR FROM GCLLANTA_STATUS WHERE STATUS = 'A' ORDER BY CVE_STATUS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_STATUS") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using

            Fg.Glyphs(C1.Win.C1FlexGrid.GlyphEnum.Checked) = My.Resources.CheckRadio
            Fg.Glyphs(C1.Win.C1FlexGrid.GlyphEnum.Unchecked) = My.Resources.UncheckRadio

            Lt1.Visible = False
            CboPilaStatus.Visible = False

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Clave", GetType(System.String))
            dt.Columns.Add("Descripcion", GetType(System.String))

            dt.Rows.Add("", "NO APLICA")
            CboPilaStatus.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PILA, DESCR FROM GCPILADESECHO WHERE STATUS = 'A' ORDER BY CVE_PILA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_PILA"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboPilaStatus.TextDetached = True
            CboPilaStatus.ItemsDataSource = dt.DefaultView
            CboPilaStatus.ItemsDisplayMember = "Descripcion"
            CboPilaStatus.ItemsValueMember = "Clave"
            CboPilaStatus.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboPilaStatus.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboPilaStatus.SelectedIndex = 0

        Catch ex As Exception
            Bitacora("54. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("54. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmLlantasAsigStSel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim CVE_ST As Integer = 0
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg.GetCellCheck(k, 1) = CheckEnum.Checked Then
                    CVE_ST = Fg(k, 2)
                End If
            Next
            If CVE_ST = 0 Then
                MsgBox("Por favor seleccione una opción")
                Return
            End If

            Var10 = CVE_ST
            Var11 = CboPilaStatus.Items(CboPilaStatus.SelectedIndex)

            Me.Close()
        Catch ex As Exception
            Bitacora("54. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("54. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        If e.Col = 1 Then

            For i As Integer = 1 To Fg.Rows.Count - 1
                If i <> e.Row Then
                    Fg.SetCellCheck(i, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                End If
            Next
            If Fg(Fg.Row, 2) = "6" Then
                Lt1.Visible = True
                CboPilaStatus.Visible = True
            Else
                Lt1.Visible = False
                CboPilaStatus.Visible = False
            End If

        End If
    End Sub
End Class