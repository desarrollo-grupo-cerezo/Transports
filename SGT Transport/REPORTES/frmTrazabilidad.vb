Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmTrazabilidad
    Private TIPO_VENTA_LOCAL As String
    Private CADENA As String
    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub frmTrazabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            TIPO_VENTA_LOCAL = "V"

            Select Case TIPO_VENTA_LOCAL
                Case "V"
                    LtCompras.Text = "Nota de venta"
                Case "P"
                    LtCompras.Text = "Pedido"
                Case "R"
                    LtCompras.Text = "Remisión"
                Case "C"
                    LtCompras.Text = "Cotización"
            End Select

            Fg.Rows.Count = 1

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - 50
            Fg.Rows(0).Height = 50

            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"

            DESPLEGAR()
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
        Dim TIP_DOC_ANT2 As String = "", DOC_ANT2 As String = "", IMPORTE2 As Single = 0, C2 As String = "", I2 As String = ""
        Dim TIP_DOC_ANT3 As String = "", DOC_ANT3 As String = "", IMPORTE3 As Single = 0, C3 As String = "", I3 As String = ""
        Dim TIP_DOC_ANT4 As String = "", DOC_ANT4 As String = "", IMPORTE4 As Single = 0, C4 As String = "", I4 As String = ""
        Dim CADENA1 As String = "", CADENA2 As String = "", CADENA3 As String = ""
        Me.Cursor = Cursors.WaitCursor

        Try
            Fg.Rows.Count = 1
            'SQL = "SELECT P.CVE_DOC, F.CVE_CLPV, NOMBRE, ISNULL(CASE F.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END,'') AS ST, " &
            '    "F.FECHA_DOC, C.IMPORTE, ISNULL(F.TIP_DOC_ANT,'') AS T_D_A, ISNULL(F.DOC_ANT,'') AS DO_ANT " &
            '    "ISNULL(CASE ISNULL(F.TIP_DOC_ANT,'') WHEN 'C' THEN 'Cotizacion' WHEN 'P' THEN 'Pedido' WHEN 'R' THEN 'Remision' ELSE '' END,'') AS T_DOC_ANT, " &
            '    "P.CVE_ART, I.DESCR, COSTO_PROM, PREC " &
            '    "FROM PAR_FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " P " &
            '    "INNER JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE__DOC " &
            '    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = F.CVE_CLPV " &
            'CADENA & " ORDER BY FECHAELAB DESC"
            SQL = "SELECT P.CVE_DOC, ISNULL(F.TIP_DOC_ANT,'') AS T_D_A, ISNULL(F.DOC_ANT,'') AS DO_ANT, " &
                "P.CVE_ART, I.DESCR, COSTO_PROM, PREC " &
                "FROM PAR_FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " P " &
                "INNER JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                CADENA & " ORDER BY F.FECHAELAB"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        TIP_DOC_ANT = dr("T_D_A")
                        DOC_ANT = dr("DO_ANT")
                        C1 = "" : C2 = "" : I2 = "" : I3 = ""
                        TIP_DOC_ANT2 = "" : DOC_ANT2 = "" : IMPORTE2 = 0
                        TIP_DOC_ANT3 = "" : DOC_ANT3 = "" : IMPORTE3 = 0

                        If DOC_ANT.Trim.Length > 0 Then

                            IMPORTE1 = BUSCAR_IMPORTE(TIP_DOC_ANT, DOC_ANT)

                            C1 = Format(IMPORTE1, "###,###,##0.00")

                            BUSCAR_DOC_ANT(TIP_DOC_ANT, DOC_ANT, TIP_DOC_ANT2, DOC_ANT2, IMPORTE2)
                            If DOC_ANT2.Trim.Length > 0 Then
                                BUSCAR_DOC_ANT(TIP_DOC_ANT2, DOC_ANT2, TIP_DOC_ANT3, DOC_ANT3, IMPORTE3)
                                If DOC_ANT3.Trim.Length > 0 Then
                                    BUSCAR_DOC_ANT(TIP_DOC_ANT3, DOC_ANT3, TIP_DOC_ANT4, DOC_ANT4, IMPORTE4)
                                End If
                            End If
                            If DOC_ANT2.Trim.Length > 0 Then
                                Select Case TIP_DOC_ANT2
                                    Case "V"
                                        C2 = "Nota de venta"
                                    Case "P"
                                        C2 = "Pedido"
                                    Case "R"
                                        C2 = "Remisión"
                                    Case "C"
                                        C2 = "Cotización"
                                End Select
                                I2 = Format(IMPORTE2, "###,###,##0.00")
                            End If
                            If DOC_ANT3.Trim.Length > 0 Then
                                Select Case TIP_DOC_ANT3
                                    Case "V"
                                        C2 = "Nota de venta"
                                    Case "P"
                                        C2 = "Pedido"
                                    Case "R"
                                        C2 = "Remisión"
                                    Case "C"
                                        C2 = "Cotización"
                                End Select
                                I3 = Format(IMPORTE3, "###,###,##0.00")
                            End If
                            If DOC_ANT4.Trim.Length > 0 Then
                                Select Case TIP_DOC_ANT4
                                    Case "V"
                                        C4 = "Nota de venta"
                                    Case "P"
                                        C4 = "Pedido"
                                    Case "R"
                                        C4 = "Remisión"
                                    Case "C"
                                        C4 = "Cotización"
                                End Select
                                I4 = Format(IMPORTE4, "###,###,##0.00")
                            End If
                        End If
                        If TIP_DOC_ANT = "R" Then
                            CADENA2 = DOC_ANT & vbTab
                        Else
                            If TIP_DOC_ANT2 = "R" Then
                                CADENA2 = DOC_ANT2 & vbTab
                            Else
                                If TIP_DOC_ANT3 = "R" Then
                                    CADENA2 = DOC_ANT3 & vbTab
                                Else
                                    CADENA2 = "" & vbTab
                                End If
                            End If
                        End If
                        If TIP_DOC_ANT = "P" Then
                            CADENA2 = CADENA2 & DOC_ANT & vbTab
                        Else
                            If TIP_DOC_ANT2 = "P" Then
                                CADENA2 = CADENA2 & DOC_ANT2 & vbTab
                            Else
                                If TIP_DOC_ANT3 = "P" Then
                                    CADENA2 = CADENA2 & DOC_ANT3 & vbTab
                                Else
                                    CADENA2 = CADENA2 & "" & vbTab
                                End If
                            End If
                        End If
                        If TIP_DOC_ANT = "C" Then
                            CADENA2 = CADENA2 & DOC_ANT & vbTab
                        Else
                            If TIP_DOC_ANT2 = "C" Then
                                CADENA2 = CADENA2 & DOC_ANT2 & vbTab
                            Else
                                If TIP_DOC_ANT3 = "C" Then
                                    CADENA2 = CADENA2 & DOC_ANT3 & vbTab
                                Else
                                    CADENA2 = CADENA2 & "" & vbTab
                                End If
                            End If
                        End If
                        Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("COSTO_PROM") & vbTab & dr("PREC") & vbTab &
                                   dr("CVE_DOC") & vbTab & CADENA2)
                    End While
                End Using
            End Using
            'Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 70
            ';Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 60 : Fg.Cols(8).Width = 110 : Fg.Cols(9).Width = 90
            'Fg.Cols(10).Width = 60 : Fg.Cols(11).Width = 110 : Fg.Cols(12).Width = 90
            'Fg.Cols(13).Width = 60 : Fg.Cols(14).Width = 110 : Fg.Cols(15).Width = 90
            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub BUSCAR_DOC_ANT(ByVal fTIP_DOC_ANT As String, ByVal fDOC_ANT As String, ByRef fTIP_DOC_ANT_NEXT As String, ByRef fDOC_ANT_NEXT As String, ByRef fIMPORTE As Single)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPORTE, TIP_DOC_ANT, DOC_ANT FROM FACT" & fTIP_DOC_ANT & Empresa & " WHERE CVE_DOC = '" & fDOC_ANT & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        fTIP_DOC_ANT_NEXT = dr("TIP_DOC_ANT")
                        fDOC_ANT_NEXT = dr("DOC_ANT")
                        fIMPORTE = dr("IMPORTE")
                    End If
                    If fDOC_ANT = "CL7078" Then
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCAR_IMPORTE(fTIPO As String, fCVE_DOC As String) As Single
        Dim IMPORT As Single = 0

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPORTE FROM FACT" & fTIPO & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        IMPORT = dr("IMPORTE")
                    End If
                End Using
            End Using
            Return IMPORT
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return IMPORT
        End Try
    End Function

    Private Sub frmTrazabilidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Trazabilidad")
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
            Fg.PrintGrid("Trazabilidad " & Var1, PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Trazabilidad de saldos " & Var1 + Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"
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
            CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
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

            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
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
            'barModificar_Click(Nothing, Nothing)
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

    Private Sub btnDesplegar_Click(sender As Object, e As EventArgs)
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
