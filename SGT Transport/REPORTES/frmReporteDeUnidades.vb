Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmReporteDeUnidades

    Private Sub frmReportedeUtilidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim TIP_DOC_ANT As String = "", DOC_ANT As String = "", C1 As String = "", I1 As String = "", IMPORTE1 As Single = 0
        Dim TIP_DOC_ANT2 As String = "", DOC_ANT2 As String = "", FECHA2 As String = "", C2 As String = "", I2 As String = ""
        Dim TIP_DOC_ANT3 As String = "", DOC_ANT3 As String = "", FECHA3 As String = "", C3 As String = "", I3 As String = ""
        Dim TIP_DOC_ANT4 As String = "", DOC_ANT4 As String = "", FECHA4 As String = "", C4 As String = "", I4 As String = ""
        Dim NUM_PAR As Integer = 1, CVE_ORD As String = "", SIGUE As Boolean = True
        Dim CADENA1 As String = "", S1 As String = "", S2 As String = "", S3 As String = "", TIPO_SERVICIO As Integer
        Dim arr(-1) As String, j As Integer = 0, Existe As Boolean = False

        If tCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("Por favor selecciones la unidad")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Rows.Count = 1
            If tCVE_UNI.Text.Trim.Length > 0 Then
                S1 = " AND O.CVE_UNI = '" & tCVE_UNI.Text & "' "
            End If
            If chInterna.Checked And chExterna.Checked Then
            Else
                If chExterna.Checked Then
                    S2 = " AND ISNULL(A_M,'') = 'M'"
                Else
                    S2 = " AND ISNULL(A_M,'') <> 'M'"
                    chInterna.Checked =true
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
            SQL = "SELECT O.CVE_ORD, CASE WHEN O.STATUS = 'C' THEN 'Cancelada' ELSE O.ESTATUS END AS STA, O.FECHA, U.DESCR AS DES_UNI, " &
                "CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END AS TIPO_SERVICIO, O.CVE_UNI AS UNIDAD, " &
                "CASE WHEN ISNULL(A_M,'') = 'M' THEN 'EXTERNA' ELSE 'INTERNA' END AS 'TIPO_ORDEN' " &
                "FROM GCORDEN_TRABAJO_EXT O " &
                "LEFT JOIN GCUNIDADES U On U.CLAVE = O.CVE_UNI " &
                "WHERE O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' " & S1 & S2 & S3 &
                " ORDER BY O.CVE_UNI"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If SIGUE Then
                            SIGUE = False
                            CVE_ORD = dr("CVE_ORD")
                        End If
                        If DOC_ANT = "          0000006618" Then
                        End If
                        Try
                            Existe = False
                            For k = 0 To arr.Length - 1
                                If arr(k) = dr("FECHA") Then
                                    Existe = True
                                    Exit For
                                End If
                            Next
                            If Not Existe Then
                                ReDim Preserve arr(j)
                                arr(j) = dr("FECHA")
                                j = j + 1
                            End If
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        CVE_ORD = dr("CVE_ORD")

                        Fg.AddItem("" & vbTab & dr("UNIDAD") & vbTab & dr("DES_UNI") & vbTab & dr("CVE_ORD") & vbTab & dr("FECHA") & vbTab &
                           dr("TIPO_SERVICIO") & vbTab & dr("TIPO_ORDEN").ToString.ToUpper)
                    End While
                    Fg.AddItem("" & vbTab & "" & vbTab & "Tota entradas al taller " & arr.Length)
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
    Private Sub BUSCAR_DOC_ANT(ByVal fTIP_DOC_ANT As String, ByVal fDOC_ANT As String, ByRef fTIP_DOC_ANT_NEXT As String, ByRef fDOC_ANT_NEXT As String, ByRef fFECHA As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT FECHA_DOC, TIP_DOC_ANT, DOC_ANT FROM FACT" & fTIP_DOC_ANT & Empresa & " WHERE CVE_DOC = '" & fDOC_ANT & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        fTIP_DOC_ANT_NEXT = dr("TIP_DOC_ANT")
                        fDOC_ANT_NEXT = dr("DOC_ANT")
                        fFECHA = dr("FECHA_DOC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BUSCAR_DOC_SIG(ByVal fTIP_DOC_ANT As String, ByVal fDOC_ANT As String, ByRef fTIP_DOC_ANT_NEXT As String, ByRef fDOC_ANT_NEXT As String, ByRef fFECHA As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT FECHA_DOC, TIP_DOC_SIG, DOC_SIG FROM FACT" & fTIP_DOC_ANT & Empresa & " WHERE CVE_DOC = '" & fDOC_ANT & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        fTIP_DOC_ANT_NEXT = dr.ReadNullAsEmptyString("TIP_DOC_SIG")
                        fDOC_ANT_NEXT = dr.ReadNullAsEmptyString("DOC_SIG")
                        fFECHA = dr.ReadNullAsEmptyString("FECHA_DOC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmReportedeUtilidades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte de unidades")
        Me.Dispose()
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    DESPLEGAR()
                Case "Excel"
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "Repote ordenes de trabajo")
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
            Fg.PrintGrid("Reporte de unidades", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Reporte de unidades" & Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")
        Catch ex As Exception
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

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var3
                L2.Text = Var6
                L2.Tag = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                chInterna.Focus()
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
                    chInterna.Focus()
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
                    L2.Text = DESCR
                    L2.Tag = Var5
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
