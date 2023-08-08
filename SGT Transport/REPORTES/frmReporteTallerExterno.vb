Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class frmReporteTallerExterno
    Private Sub frmReporteTallerExterno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim CVE_DOC_ODEN_COMPRA As String = ""
        Dim TIP_DOC_ANT As String = "", DOC_ANT As String = "", PROV2 As String = "", PROV3 As String = ""
        Dim TIP_DOC_ANT2 As String = "", DOC_ANT2 As String = "", FECHA2 As String = "", C2 As String = ""
        Dim TIP_DOC_ANT3 As String = "", DOC_ANT3 As String = "", FECHA3 As String = "", C3 As String = ""
        Dim NOMBRE_PROV As String
        Dim S1 As String = "", S2 As String = "", S3 As String = "", S4 As String = "", S5 As String = ""

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Fg.Styles(CellStyleEnum.Normal).WordWrap = True

        Try
            Fg.Rows.Count = 1
            If tCVE_UNI.Text.Trim.Length > 0 Then
                S1 = " AND O.CVE_UNI = '" & tCVE_UNI.Text & "' "
            End If

            S2 = " AND ISNULL(A_M,'') = 'M'"

            If tCVE_PROV.Text.Trim.Length > 0 Then
                S3 = " AND LIN_PROD = '" & tCVE_PROV.Text & "' "
            End If
            If tCVE_ORDEN1.Text.Trim.Length > 0 And tCVE_ORDEN2.Text.Trim.Length > 0 Then
                S4 = " AND CAST(P.CVE_ORD AS INT) >= '" & tCVE_ORDEN1.Text & "' AND CAST(P.CVE_ORD AS INT) <= '" & tCVE_ORDEN2.Text & "' "
            Else
                If tCVE_ORDEN1.Text.Trim.Length > 0 And tCVE_ORDEN2.Text.Trim.Length = 0 Then
                    S4 = " AND CAST(P.CVE_ORD AS INT) >= '" & tCVE_ORDEN1.Text & "' "
                End If
                If tCVE_ORDEN1.Text.Trim.Length = 0 And tCVE_ORDEN2.Text.Trim.Length > 0 Then
                    S4 = " AND CAST(P.CVE_ORD AS INT) <= '" & tCVE_ORDEN2.Text & "' "
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
            SQL = "SELECT CAST(O.CVE_ORD AS INT) AS CVE_ORDEN, O.FECHA, O.CVE_UNI, ISNULL(TIEMPO_REAL,'') AS CVE_DOC, " &
                "CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END AS TIPO_SERVICIO, O.CVE_UNI AS UNIDAD, " &
                "CASE WHEN ISNULL(A_M,'') = 'M' THEN 'EXTERNA' ELSE 'INTERNA' END AS 'TIPO_ORDEN' " &
                "FROM GCORDEN_TRA_SER_EXT P " &
                "LEFT JOIN GCORDEN_TRABAJO_EXT O On O.CVE_ORD = P.CVE_ORD " &
                "WHERE O.STATUS <> 'C' AND CVE_ART = 'TOT' AND O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' " & S1 & S2 & S3 & S4 &
                " ORDER BY CAST(O.CVE_ORD AS INT)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CVE_DOC_ODEN_COMPRA = dr("CVE_DOC")

                        If dr("CVE_ORDEN") = "2056" Then
                        End If
                        TIP_DOC_ANT3 = "" : DOC_ANT3 = "" : FECHA3 = "" : PROV3 = ""
                        BUSCAR_DOC_SIG("O", CVE_DOC_ODEN_COMPRA, TIP_DOC_ANT2, DOC_ANT2, FECHA2, PROV2)
                        If DOC_ANT2.Trim.Length > 0 Then
                            BUSCAR_DOC_SIG(TIP_DOC_ANT2, DOC_ANT2, TIP_DOC_ANT3, DOC_ANT3, FECHA3, PROV3)
                        End If

                        NOMBRE_PROV = BUSCA_NOMBRE_PROV(PROV3)
                        If dr("CVE_ORDEN") = "2056" Then
                        End If

                        Fg.AddItem("" & vbTab & dr("CVE_ORDEN") & vbTab & dr("FECHA") & vbTab & dr("TIPO_SERVICIO") & vbTab & dr("CVE_DOC") & vbTab &
                            FECHA2 & vbTab & DOC_ANT2 & vbTab & FECHA3 & vbTab & PROV3 & vbTab & NOMBRE_PROV)
                    End While
                End Using
            End Using

            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

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
    Private Sub BUSCAR_DOC_ANT(ByVal fTIP_DOC_ANT As String, ByVal fDOC_ANT As String, ByRef fTIP_DOC_ANT_NEXT As String,
                               ByRef fDOC_ANT_NEXT As String, ByRef fFECHA As String, fPROV As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CLPV, FECHA_DOC, TIP_DOC_ANT, DOC_ANT FROM COMP" & fTIP_DOC_ANT.ToUpper & Empresa & " WHERE CVE_DOC = '" & fDOC_ANT & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        fTIP_DOC_ANT_NEXT = dr("TIP_DOC_ANT")
                        fDOC_ANT_NEXT = dr("DOC_ANT")
                        fFECHA = dr("FECHA_DOC")
                        fPROV = dr.ReadNullAsEmptyString("CVE_CLPV")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BUSCAR_DOC_SIG(ByVal fTIP_DOC_ANT As String, ByVal fDOC_ANT As String, ByRef fTIP_DOC_ANT_NEXT As String,
                               ByRef fDOC_ANT_NEXT As String, ByRef fFECHA As String, ByRef fPROV As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CLPV, FECHA_DOC, TIP_DOC_SIG, DOC_SIG FROM COMP" & fTIP_DOC_ANT.ToUpper & Empresa & " WHERE CVE_DOC = '" & fDOC_ANT & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        fTIP_DOC_ANT_NEXT = dr.ReadNullAsEmptyString("TIP_DOC_SIG")
                        fDOC_ANT_NEXT = dr.ReadNullAsEmptyString("DOC_SIG")
                        fFECHA = dr.ReadNullAsEmptyString("FECHA_DOC")
                        fPROV = dr.ReadNullAsEmptyString("CVE_CLPV")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmReporteTallerExterno_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte de taller externo")
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
            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System

            Fg.PrintParameters.HeaderFont = New Font("Arial Black", 10, FontStyle.Bold)
            Fg.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)
            '  Preview the grid.
            Fg.PrintGrid("Reporte taller externo", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Reporte taller externo" & Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Styles.Alternate.BackColor = Color.LightSkyBlue

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var3
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                tCVE_PROV.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    tCVE_PROV.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                tCVE_ORDEN1.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    tCVE_ORDEN1.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String, CLAVE = tCVE_PROV.Text
                If IsNumeric(tCVE_PROV.Text) Then
                    CLAVE = Space(10 - tCVE_PROV.Text.Trim.Length) & tCVE_PROV.Text.Trim
                End If
                DESCR = BUSCA_CAT("Prov", CLAVE)
                If DESCR <> "" Then
                    tCVE_PROV.Text = CLAVE
                Else
                    MsgBox("Proveedor inexistente")
                    tCVE_PROV.Text = ""
                    tCVE_PROV.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnOrden1_Click(sender As Object, e As EventArgs) Handles btnOrden1.Click
        Try
            Var2 = "OT"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If IsNumeric(tCVE_ORDEN1.Text) Then
                    If CLng(tCVE_ORDEN1.Text) > 0 Then
                        If Val(Var4) > CLng(tCVE_ORDEN2.Text) Then
                            MsgBox("La orden no puede ser mayor la segunda orden")
                            Return
                        End If
                    End If
                End If

                tCVE_ORDEN1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                tCVE_ORDEN2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ORDEN1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ORDEN1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnOrden1_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    tCVE_ORDEN2.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_ORDEN1_Validated(sender As Object, e As EventArgs) Handles tCVE_ORDEN1.Validated
        Try
            If tCVE_ORDEN1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("OT", tCVE_ORDEN1.Text)
                If DESCR <> "" Then
                    If IsNumeric(tCVE_ORDEN1.Text) Then
                        If CLng(tCVE_ORDEN1.Text) > 0 Then
                            If IsNumeric(tCVE_ORDEN1.Text) And IsNumeric(tCVE_ORDEN2.Text) Then
                                If CLng(tCVE_ORDEN1.Text) > CLng(tCVE_ORDEN2.Text) Then
                                    MsgBox("La orden no puede ser mayor la segunda orden")
                                    tCVE_ORDEN1.Text = ""
                                    tCVE_ORDEN1.Select()
                                    Return
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Orden inexistente")
                    tCVE_ORDEN1.Text = ""
                    tCVE_ORDEN1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnOrden2_Click(sender As Object, e As EventArgs) Handles btnOrden2.Click
        Try
            Var2 = "OT"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If IsNumeric(Var4) Then
                    If CLng(Var4) > 0 Then
                        If IsNumeric(tCVE_ORDEN1.Text) Then
                            If Val(Var4) < CLng(tCVE_ORDEN1.Text) Then
                                MsgBox("La orden no puede ser menor la primera orden")
                                tCVE_ORDEN2.Text = ""
                                tCVE_ORDEN2.Select()
                                Return
                            End If
                        End If
                    End If
                End If
                tCVE_ORDEN2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                radPreventivo.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ORDEN2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ORDEN2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnOrden2_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    radPreventivo.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_ORDEN2_Validated(sender As Object, e As EventArgs) Handles tCVE_ORDEN2.Validated
        Try
            If tCVE_ORDEN2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("OT", tCVE_ORDEN2.Text)
                If DESCR <> "" Then
                    If IsNumeric(tCVE_ORDEN2.Text) Then
                        If CLng(tCVE_ORDEN2.Text) > 0 Then
                            If IsNumeric(tCVE_ORDEN1.Text) And IsNumeric(tCVE_ORDEN2.Text) Then
                                If CLng(tCVE_ORDEN2.Text) < CLng(tCVE_ORDEN1.Text) Then
                                    MsgBox("La orden no puede ser menor la primera orden")
                                    Return
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Orden inexistente")
                    tCVE_ORDEN2.Text = ""
                    tCVE_ORDEN2.Select()
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
