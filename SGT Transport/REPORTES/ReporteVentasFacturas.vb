
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class ReporteVentasFacturas
    Private TIPO_VENTA_LOCAL As String
    Private CADENA As String
    Private Sub ReporteVentasFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim FECHA_DOC As String
        Dim CADENA1 As String = "", CADENA2 As String = "", CADENA3 As String = ""
        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Rows.Count = 1

            SQL = "SELECT P.CVE_DOC, F.FECHA_DOC, P.CVE_ART, I.DESCR, F.CVE_CLPV, C.NOMBRE, F.TIP_DOC_ANT, F.DOC_ANT, I.LIN_PROD " &
                "FROM PAR_FACTF" & Empresa & " P " &
                "INNER JOIN FACTF" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV " &
                "WHERE F.STATUS <> 'C' AND FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' ORDER BY F.CVE_DOC"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        TIP_DOC_ANT = dr("TIP_DOC_ANT")
                        DOC_ANT = dr("DOC_ANT")
                        FECHA_DOC = dr("FECHA_DOC")
                        CADENA1 = ""

                        If dr("CVE_DOC") = "AM0000006009" Then
                        End If
                        If DOC_ANT.Trim.Length > 0 Then
                            Try
                                BUSCAR_DOC_ANT(TIP_DOC_ANT, DOC_ANT, TIP_DOC_ANT2, DOC_ANT2, FECHA2)
                                If DOC_ANT2.Trim.Length > 0 Then
                                    BUSCAR_DOC_ANT(TIP_DOC_ANT2, DOC_ANT2, TIP_DOC_ANT3, DOC_ANT3, FECHA3)
                                    If DOC_ANT3.Trim.Length > 0 Then
                                        BUSCAR_DOC_ANT(TIP_DOC_ANT3, DOC_ANT3, TIP_DOC_ANT4, DOC_ANT4, FECHA4)
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try 'INCIAL     INCIAL     INCIAL     
                                Select Case TIP_DOC_ANT
                                    Case "V"
                                        CADENA1 = vbTab & DOC_ANT & vbTab & FECHA_DOC
                                    Case "R"
                                        CADENA1 = vbTab & "" & vbTab & "" & vbTab & DOC_ANT & vbTab & FECHA_DOC
                                    Case "C"
                                        CADENA1 = vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & DOC_ANT & vbTab & FECHA_DOC
                                End Select
                                If DOC_ANT2.Trim.Length > 0 Then
                                    Select Case TIP_DOC_ANT2
                                        Case "V"
                                            CADENA1 = CADENA1 & vbTab & DOC_ANT2 & vbTab & FECHA2 & "" & vbTab & "" & vbTab
                                        Case "R"
                                            CADENA1 = CADENA1 & vbTab & DOC_ANT2 & vbTab & FECHA2
                                        Case "C"
                                            Select Case TIP_DOC_ANT
                                                Case "V"
                                                    CADENA1 = CADENA1 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & DOC_ANT2 & vbTab & FECHA2
                                                Case "R"
                                                    CADENA1 = CADENA1 & vbTab & DOC_ANT2 & vbTab & FECHA2
                                            End Select
                                        Case "P"
                                            Select Case TIP_DOC_ANT
                                                Case "V"
                                                    CADENA1 = CADENA1 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                                                Case "R"
                                                    CADENA1 = CADENA1 & vbTab & "" & vbTab & ""
                                            End Select
                                    End Select
                                Else
                                    Select Case TIP_DOC_ANT
                                        Case "R"
                                            CADENA1 = CADENA1 & vbTab & "" & vbTab & ""
                                        Case "V"
                                            CADENA1 = CADENA1 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                                    End Select
                                End If
                                If DOC_ANT3.Trim.Length > 0 Then
                                    Select Case TIP_DOC_ANT3
                                        Case "V"
                                            CADENA1 = CADENA1 & vbTab & DOC_ANT3 & vbTab & FECHA3
                                        Case "R"
                                            CADENA1 = CADENA1 & vbTab & "" & vbTab & "" & vbTab & DOC_ANT3 & vbTab & FECHA3 & "" & vbTab & "" & vbTab
                                        Case "C"
                                            CADENA1 = CADENA1 & vbTab & DOC_ANT & vbTab & FECHA4
                                    End Select
                                End If
                            Catch ex As Exception
                                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Else
                            CADENA1 = vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                        End If

                        Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("FECHA_DOC") & CADENA1 & vbTab &
                                   dr("LIN_PROD") & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE"))
                    End While
                End Using
            End Using

            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            MsgBox("Proceso terminado")
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub ReporteVentasFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Reporte notas facturas")
            Me.Dispose()
        Catch ex As Exception
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                    DESPLEGAR()
                Case "Excel"
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "RepoteNotasFacturas")
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
    Private Sub Imprimir()
        Dim Rreporte_MRT As String = ""
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()
        Try
            Rreporte_MRT = "ReportTrazabilidad.mrt"
            If Not File.Exists(RUTA_FORMATOS & "\" & Rreporte_MRT) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\" & Rreporte_MRT & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\" & Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            For k = 1 To Fg.Rows.Count - 1
                'StiUserData1.a.Columns.Item(0) = Fg(k, 1)

            Next
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCAR_FECHA(fTIPO As String, fCVE_DOC As String) As String
        Dim FECHA As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                Select Case fTIPO
                    Case "V"
                        SQL = "SELECT FECHA_DOC FROM FACTV" & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
                    Case "R"
                        SQL = "SELECT FECHA_DOC FROM FACTR" & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
                    Case "C"
                        SQL = "SELECT FECHA_DOC FROM FACTC" & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
                End Select
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        FECHA = dr.ReadNullAsEmptyString("FECHA_DOC")
                    End If
                End Using
            End Using
            Return FECHA
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return FECHA
        End Try
    End Function
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
    Sub ImprimirGrid()
        '  Get the grid's PrintDocument object.
        'Dim pd As Printing.PrintDocument
        'DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        'pd = Fg.PrintParameters.PrintDocument()
        Dim printDialog1 As PrintDialog = New PrintDialog()
        Dim pd As Printing.PrintDocument
        'DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        pd = Fg.PrintParameters.PrintDocument()
        'printDialog1.Document = pd

        If printDialog1.ShowDialog = DialogResult.OK Then 'Open the print dialog box  
            pd.PrinterSettings = printDialog1.PrinterSettings
        Else
            Return
        End If
        'PrintPreviewDialog1.Document = pd
        '  Set up the page (landscape, 1.5" left margin).
        With pd.DefaultPageSettings
            .Landscape = True
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
            Fg.PrintGrid("Reporte de ventas facturas", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Reporte de ventas facturas" & Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")
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
End Class
