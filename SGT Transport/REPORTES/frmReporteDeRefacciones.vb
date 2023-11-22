Imports C1.Win.C1Themes
Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class frmReporteDeRefacciones
    Private Sub frmReporteDeRefacciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try

            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

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

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - 50
            Fg.Rows(0).Height = 50
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim TIPO_SERVICIO As Integer
        Dim C1 As String = "", C2 As String = "", C3 As String = ""

        Dim CADENA1 As String = "", S1 As String = "", S2 As String = "", S3 As String = "", S4 As String = "", S5 As String = ""

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Fg.Styles(CellStyleEnum.Normal).WordWrap = True

        Try
            Fg.Rows.Count = 1
            If TCVE_UNI.Text.Trim.Length > 0 Then
                S1 = " AND O.CVE_UNI = '" & TCVE_UNI.Text & "' "
            End If
            If chInterna.Checked And chExterna.Checked Then
            Else
                If chExterna.Checked Then
                    S2 = " AND ISNULL(A_M,'') = 'M'"
                Else
                    S2 = " AND ISNULL(A_M,'') <> 'M'"
                    chInterna.Checked = True
                End If
            End If
            If TLIN_PROD.Text.Trim.Length > 0 Then
                S3 = " AND LIN_PROD = '" & TLIN_PROD.Text & "' "
            End If
            If TCVE_ORDEN1.Text.Trim.Length > 0 And TCVE_ORDEN2.Text.Trim.Length > 0 Then
                S4 = " AND CAST(P.CVE_ORD AS INT) >= '" & TCVE_ORDEN1.Text & "' AND CAST(P.CVE_ORD AS INT) <= '" & TCVE_ORDEN2.Text & "' "
            Else
                If TCVE_ORDEN1.Text.Trim.Length > 0 And TCVE_ORDEN2.Text.Trim.Length = 0 Then
                    S4 = " AND CAST(P.CVE_ORD AS INT) >= '" & TCVE_ORDEN1.Text & "' "
                End If
                If TCVE_ORDEN1.Text.Trim.Length = 0 And TCVE_ORDEN2.Text.Trim.Length > 0 Then
                    S4 = " AND CAST(P.CVE_ORD AS INT) <= '" & TCVE_ORDEN2.Text & "' "
                End If
            End If

            If Not RadTodos.Checked Then
                Try
                    TIPO_SERVICIO = 0
                    If radPreventivo.Checked = True Then
                        TIPO_SERVICIO = 0
                    End If
                    If radCorrectivo.Checked = True Then
                        TIPO_SERVICIO = 1
                    End If
                    If radExtra.Checked = True Then
                        TIPO_SERVICIO = 2
                    End If
                    If radSinistro.Checked = True Then
                        TIPO_SERVICIO = 3
                    End If
                    If RadRescateCarr.Checked = True Then
                        TIPO_SERVICIO = 4
                    End If
                    If RadLLantas.Checked = True Then
                        TIPO_SERVICIO = 5
                    End If
                    S3 = " AND TIPO_SERVICIO = " & TIPO_SERVICIO & " "
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            SQL = "SELECT CAST(O.CVE_ORD AS INT) AS CVE_ORDEN, P.CVE_ART, I.DESCR, P.CANT, O.FECHA, O.CVE_UNI,
                CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END AS TIPO_SERVICIO, O.CVE_UNI AS UNIDAD,
                CASE WHEN ISNULL(A_M,'') = 'M' THEN 'EXTERNA' ELSE 'INTERNA' END AS 'TIPO_ORDEN', COSTO
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN GCORDEN_TRABAJO_EXT O On O.CVE_ORD = P.CVE_ORD
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                WHERE O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' " & S1 & S2 & S3 & S4 &
                "ORDER BY CAST(O.CVE_ORD AS INT)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("CANT") & vbTab &
                           dr("CVE_ORDEN") & vbTab & dr("CVE_UNI") & vbTab & dr("FECHA") & vbTab &
                           dr("TIPO_ORDEN").ToString.ToUpper & vbTab & dr("TIPO_SERVICIO") & vbTab & dr("COSTO"))
                    End While
                End Using
            End Using

            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub frmReporteDeRefacciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte de refacciones")
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    DESPLEGAR()
                Case "Excel"
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "Repote de refacciones")
                Case "Imprimir"
                    ImprimirGrid()
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirGrid()
        '  Get the grid's PrintDocument object.
        Dim printDialog1 As PrintDialog = New PrintDialog()
        Dim pd As PrintDocument
        'DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        pd = Fg.PrintParameters.PrintDocument()
        'printDialog1.Document = pd

        If printDialog1.ShowDialog = DialogResult.OK Then 'Open the print dialog box  
            pd.PrinterSettings = printDialog1.PrinterSettings
        Else
            Return
        End If

        '  Set up the page (landscape, 1.5" left margin).
        With pd.DefaultPageSettings
            .Landscape = False
            .Margins.Top = 40
            .Margins.Bottom = 40
            .Margins.Left = 35
            .Margins.Right = 35
        End With
        Try
            '  Set up the header and footer fonts.
            Fg.PrintParameters.HeaderFont = New Font("Arial Black", 10, FontStyle.Bold)
            Fg.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)
            '  Preview the grid.
            Fg.PrintGrid("Reporte de refacciones", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Reporte de refacciones" & Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_PROD.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                TCVE_ORDEN1.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tLIN_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_PROD.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnLinea_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    TCVE_ORDEN1.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tLIN_PROD_Validated(sender As Object, e As EventArgs) Handles TLIN_PROD.Validated
        Try
            If TLIN_PROD.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Linea", TLIN_PROD.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Linea inexistente")
                    TLIN_PROD.Text = ""
                    TLIN_PROD.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnOrden1_Click(sender As Object, e As EventArgs) Handles BtnOrden1.Click
        Try
            Var2 = "OT"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If IsNumeric(TCVE_ORDEN1.Text) Then
                    If CLng(TCVE_ORDEN1.Text) > 0 Then
                        If Val(Var4) > CLng(TCVE_ORDEN2.Text) Then
                            MsgBox("La orden no puede ser mayor la segunda orden")
                            Return
                        End If
                    End If
                End If

                TCVE_ORDEN1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                TCVE_ORDEN2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_ORDEN1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ORDEN1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnOrden1_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    TCVE_ORDEN2.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_ORDEN1_Validated(sender As Object, e As EventArgs) Handles TCVE_ORDEN1.Validated
        Try
            If TCVE_ORDEN1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("OT", TCVE_ORDEN1.Text)
                If DESCR <> "" Then
                    If IsNumeric(TCVE_ORDEN1.Text) Then
                        If CLng(TCVE_ORDEN1.Text) > 0 Then
                            If IsNumeric(TCVE_ORDEN1.Text) And IsNumeric(TCVE_ORDEN2.Text) Then
                                If CLng(TCVE_ORDEN1.Text) > CLng(TCVE_ORDEN2.Text) Then
                                    MsgBox("La orden no puede ser mayor la segunda orden")
                                    TCVE_ORDEN1.Text = ""
                                    TCVE_ORDEN1.Select()
                                    Return
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Orden inexistente")
                    TCVE_ORDEN1.Text = ""
                    TCVE_ORDEN1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnOrden2_Click(sender As Object, e As EventArgs) Handles BtnOrden2.Click
        Try
            Var2 = "OT"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If IsNumeric(TCVE_ORDEN2.Text) Then
                    If CLng(TCVE_ORDEN2.Text) > 0 Then
                        If IsNumeric(TCVE_ORDEN1.Text) Then
                            If Val(Var4) < CLng(TCVE_ORDEN1.Text) Then
                                MsgBox("La orden no puede ser menor la primera orden")
                                TCVE_ORDEN2.Text = ""
                                TCVE_ORDEN2.Select()
                                Return
                            End If
                        End If
                    End If
                End If
                TCVE_ORDEN2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                chInterna.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_ORDEN2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ORDEN2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnOrden2_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    chInterna.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_ORDEN2_Validated(sender As Object, e As EventArgs) Handles TCVE_ORDEN2.Validated
        Try
            If TCVE_ORDEN2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("OT", TCVE_ORDEN2.Text)
                If DESCR <> "" Then
                    If IsNumeric(TCVE_ORDEN2.Text) Then
                        If CLng(TCVE_ORDEN2.Text) > 0 Then
                            If IsNumeric(TCVE_ORDEN1.Text) And IsNumeric(TCVE_ORDEN2.Text) Then
                                If CLng(TCVE_ORDEN2.Text) < CLng(TCVE_ORDEN1.Text) Then
                                    MsgBox("La orden no puede ser menor la primera orden")
                                    Return
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Orden inexistente")
                    TCVE_ORDEN2.Text = ""
                    TCVE_ORDEN2.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterFilter(sender As Object, e As EventArgs) Handles Fg.AfterFilter
        Try
            Lt1.Text = "Registros encontrados " & FilterCountRows()
        Catch ex As Exception
        End Try
    End Sub
    Private Function FilterCountRows() As Long
        Try
            Dim rows As Integer = 0

            For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
                If Fg.Rows(row).IsVisible AndAlso Not Fg.Rows(row).IsNode AndAlso Not Fg.Rows(row).IsNew Then rows += 1
            Next

            Return rows
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var3
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                chInterna.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    chInterna.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_UNI.Text = ""
                    TCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
