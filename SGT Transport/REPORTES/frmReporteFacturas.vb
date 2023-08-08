Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmReporteFacturas
    Private CADENA As String
    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub frmReporteFactutras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            CADENA = " WHERE F.FECHA_DOC = '" & FSQL(Date.Now) & "'"

            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CADENA1 As String, z As Integer = 1
        Dim CVE_UNI As String, CAN_TOT As Decimal, IVA As Decimal, IMPORTE As Decimal
        Dim S1 As Decimal, S2 As Decimal, S3 As Decimal

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White
        'Fg.SetCellStyle(0, 0, NewStyle1)

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Redraw = False

        Try
            Fg.Rows.Count = 1
            SQL = "SELECT F.CVE_DOC AS DOCF, F.CVE_CLPV, C.NOMBRE, ISNULL(F.DOC_ANT,'') AS DOC_ANTF, (CASE F.STATUS WHEN 'C' THEN 'CANCELADA' ELSE 'ORIGINAL' END) AS ST, " &
                "F.DAT_MOSTR, F.FECHA_DOC, F.CAN_TOT AS CANTOT, (F.IMP_TOT1 + F.IMP_TOT2 + F.IMP_TOT3 + F.IMP_TOT4) AS IVA, F.COM_TOT AS COMTOT, F.CVE_PEDI, " &
                "F.NUM_ALMA AS ALMACEN, (CASE F.FORMAENVIO WHEN 'I' THEN '' ELSE 'Ninguno' END) AS ENVIO, F.IMPORTE AS IMPORT, " &
                "(CASE WHEN F.STATUS = 'E' AND F.ESCFD = 'T' THEN 'Timbrado' ELSE '' END) AS TIMBRADA, F.FORMADEPAGOSAT AS PAGOSAT, F.METODODEPAGO, " &
                "V.NOMBRE AS NOMBRE_VEND, VERSION, NO_SERIE, FECHA_CERT, ISNULL(CVE_UNI,'') AS UNIDAD, ISNULL(R.CVE_PEDI,'') AS CVE_PEDI_R, " &
                "ISNULL(F.TIP_DOC_ANT,'') AS T_DOC_ANT, ISNULL(F.DOC_ANT,'') AS DOCANT " &
                "FROM FACTF" & Empresa & " F " &
                "LEFT JOIN CFDI" & Empresa & " CF ON CF.CVE_DOC = F.CVE_DOC " &
                "LEFT JOIN FACTR" & Empresa & " R ON R.CVE_DOC = F.DOC_ANT " &
                "LEFT JOIN GCORDEN_TRABAJO_EXT T ON T.DOC_ANTR = R.CVE_DOC " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV " &
                "LEFT JOIN VEND" & Empresa & " V ON V.CVE_VEND = F.CVE_VEND " &
                CADENA & " ORDER BY F.FECHAELAB"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.CommandTimeout = 300
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        CADENA1 = dr("CVE_PEDI_R")
                        If dr("UNIDAD").ToString.Length = 0 Then
                            If dr("CVE_PEDI_R").ToString.Trim.Length > 0 Then
                                CVE_UNI = BUSCA_UNIDAD_FAC(dr("CVE_PEDI_R"))
                            Else
                                If dr("T_DOC_ANT") = "C" Then
                                    CVE_UNI = "No transcg"
                                    CADENA1 = dr("T_DOC_ANT") & " " & dr("DOCANT")
                                Else
                                    If dr("T_DOC_ANT").ToString.Length = 0 And dr("DOCANT").ToString.Length = 0 Then
                                        CVE_UNI = "Directa"
                                    Else
                                        CVE_UNI = "Directa"
                                        CADENA1 = dr("T_DOC_ANT") & " " & dr("DOCANT")
                                    End If
                                End If
                            End If
                        Else
                            CVE_UNI = dr("UNIDAD").ToString
                        End If
                        If dr("ST") = "CANCELADA" Then
                            CAN_TOT = 0
                            IVA = 0
                            IMPORTE = 0
                        Else
                            CAN_TOT = dr("CANTOT")
                            IVA = dr("IVA")
                            IMPORTE = dr("IMPORT")
                        End If
                        S1 = S1 + CAN_TOT
                        S2 = S2 + IVA
                        S3 = S3 + IMPORTE

                        Fg.AddItem(z & vbTab & "Factura" & vbTab & dr("DOCF") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab &
                                   dr("ST") & vbTab & dr("DAT_MOSTR") & vbTab & dr("CVE_PEDI") & vbTab & dr("FECHA_DOC") & vbTab & CAN_TOT & vbTab &
                                   IVA & vbTab & dr("COMTOT") & vbTab & dr("ALMACEN") & vbTab & dr("TIMBRADA") & vbTab & dr("ENVIO") & vbTab &
                                   IMPORTE & vbTab & dr("VERSION") & vbTab & dr("NO_SERIE") & vbTab & dr("FECHA_CERT") & vbTab & dr("METODODEPAGO") & vbTab &
                                   dr("PAGOSAT") & vbTab & dr("NOMBRE_VEND") & vbTab & CVE_UNI & vbTab & CADENA1)
                        If dr("ST") = "CANCELADA" Then
                            Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                        End If
                        z = z + 1
                    End While
                    Fg.AddItem(z & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab &
                                   S2 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S3 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                   "" & vbTab & "" & vbTab & "" & vbTab & "")
                End Using
            End Using
            Fg.Cols(1).Width = 60
            Fg.Cols(2).Width = 110
            Fg.Cols(3).Width = 45
            Fg.Cols(4).Width = 160
            Fg.Cols(5).Width = 70 : Fg.Cols(6).Width = 60 : Fg.Cols(7).Width = 50

            Fg.Cols(9).Width = 80 : Fg.Cols(10).Width = 80 : Fg.Cols(11).Width = 60
            Fg.Cols(15).Width = 90
            Fg.Cols(21).Width = 100
            Fg.Cols(23).Width = 120

            Fg.AutoSizeRows()
            Fg.Rows(0).Height = 50
            MsgBox("Proceso terminado")
        Catch ex As Exception
            If ex.Message.ToString.IndexOf("tiempo de espera") = -1 Then
                MsgBox("14. El servidor no responde vuelva a intentar generar el repote de facturas por favor")
            Else
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End If

        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Function BUSCA_UNIDAD_FAC(fCVE_ORD As String) As String
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim UNID As String = ""
        Try
            SQL = "SELECT CVE_UNI FROM GCORDEN_TRABAJO_EXT WHERE CVE_ORD = '" & fCVE_ORD & "'"

            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                UNID = reader("CVE_UNI")
            End If
            reader.Close()
            Return UNID
        Catch ex As Exception
            Bitacora("18. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
            Return UNID
        End Try
    End Function
    Private Sub frmReporteFactutras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte facturas")
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    CADENA = " WHERE F.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND F.FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                    DESPLEGAR()
                Case "Excel"
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "Trazabilidad")
                Case "Imprimir"
                    'Imprimir()
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
        Dim pd As Printing.PrintDocument

        'DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        pd = Fg.PrintParameters.PrintDocument()
        'PrintPreviewDialog1.Document = pd
        '  Set up the page (landscape, 1.5" left margin).
        'Dim xCustomSize As New pd.PaperSize("Legal", 850, 1400)
        pd.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Letter", 600, 300)

        With pd.DefaultPageSettings
            .Landscape = True
            .Margins.Top = 40
            .Margins.Bottom = 40
            .Margins.Left = 25
            .Margins.Right = 25
        End With
        Try
            '  Set up the header and footer fonts.
            Fg.PrintParameters.HeaderFont = New Font("Arial Black", 10, FontStyle.Bold)
            Fg.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)
            '  Preview the grid.
            Fg.PrintGrid("Reporte de facturas", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Reporte de facturas " + Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            CADENA = " WHERE F.FECHA_DOC = '" & FSQL(Date.Now) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            CADENA = " WHERE F.FECHA_DOC = '" & FSQL(dt) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            CADENA = " WHERE MONTH(F.FECHA_DOC) = " & dt.Month & " AND YEAR(F.FECHA_DOC) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)

            CADENA = " WHERE MONTH(F.FECHA_DOC) = " & dt.Month & " AND YEAR(F.FECHA_DOC) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            CADENA = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
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
            StiReport1.Load(Application.StartupPath & "\" & Rreporte_MRT)
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
            StiReport1.Item("REFER") = Fg(Fg.Row, 1)
            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
