Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports Stimulsoft
Imports Stimulsoft.Report

Public Class FrmDetalladoVentasJulio
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmDetalladoVentasJulio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmDetalladoVentasJulio_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.WindowState = FormWindowState.Maximized
        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150
        Fg.Rows.Count = 1
        Fg.Cols.Count = 9

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

        TITULOS()

        Dim N = DateTime.Now.AddMonths(-1)
        Dim D1 As String, D2 As String

        D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F1.Value = D1
        F2.Value = D2

        DESPLEGAR()

    End Sub
    Private Sub FrmDetalladoVentasJulio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Resumen de ventas")
        Me.Dispose()
    End Sub
    Sub DESPLEGAR()
        Try
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, CADENA As String, FECHA As Date
            Dim PR1 As Boolean = False, PR2 As Boolean = False

            Dim t As DataTable = DataSet1.Tables(0)
            Dim r As DataRow
            DataSet1.Clear()

            Fg.Rows.Count = 1

            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            If RadVentasFlete.Checked Then
                PR1 = True
            End If
            If RadVentasOtro.Checked Then
                PR2 = True
            End If
            If RadTodos.Checked Then
                PR1 = True
                PR2 = True
            End If

            If PR1 Then
                If RadFechaCarga.Checked Then
                    CADENA = "P.FECHA_CARGA_TIMBRE >= '" & FSQL(F1.Value) & " 00:00:00' AND P.FECHA_CARGA_TIMBRE <= '" & FSQL(F2.Value) & " 23:59:59'"
                Else
                    CADENA = "P.FECHA_TIMBRE >= '" & FSQL(F1.Value) & " 00:00:00' AND P.FECHA_TIMBRE <= '" & FSQL(F2.Value) & " 23:59:59'"
                End If

                SQL = "SELECT ISNULL(FACTURA,'') AS FAC, DOCUMENT, C.NOMBRE, F.SUBTOTAL, F.RETENCION, F.IVA, C.CLAVE,
                    ISNULL((SELECT CAMPLIB3 FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = P.CVE_MAT),'') AS LIB3,
                    P.FECHA_CARGA_TIMBRE, P.FECHA_TIMBRE 
                    FROM CFDI F
                    LEFT JOIN GCCARTA_PORTE P ON P.CVE_FOLIO = F.DOCUMENT
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                    WHERE ISNULL(F.ESTATUS,'A') <> 'C' AND " & CADENA & "
                    ORDER BY F.FACTURA"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                If dr("LIB3") = "F" Then
                                    If RadFechaCarga.Checked Then
                                        FECHA = dr("FECHA_CARGA_TIMBRE")
                                    Else
                                        FECHA = dr("FECHA_TIMBRE")
                                    End If
                                    Fg.AddItem("" & vbTab & dr("FAC") & vbTab & dr("CLAVE") & vbTab & dr("NOMBRE") & vbTab &
                                           dr("DOCUMENT") & vbTab & FECHA & vbTab & dr("SUBTOTAL") & vbTab & dr("RETENCION") & vbTab &
                                           dr("IVA") & vbTab & dr("SUBTOTAL") + dr("RETENCION") + dr("IVA"))
                                    S1 += dr("SUBTOTAL")
                                    S2 += dr("RETENCION")
                                    S3 += dr("IVA")
                                    S4 += dr("SUBTOTAL") + dr("RETENCION") + dr("IVA")

                                    r = t.NewRow()
                                    r("FACTURA") = dr("FAC")
                                    r("CLAVE") = dr("CLAVE")
                                    r("NOMBRE") = dr("NOMBRE")
                                    r("DOCUMENT") = dr("DOCUMENT")
                                    r("SUBTOTAL") = dr("SUBTOTAL")
                                    r("RETENCION") = dr("RETENCION")
                                    r("IVA") = dr("IVA")
                                    r("IMPORTE") = dr("SUBTOTAL") + dr("RETENCION") + dr("IVA")
                                    r("FECHA") = FECHA
                                    r("FEC1") = F1.Value
                                    r("FEC2") = F2.Value
                                    r("TITULO") = "Resumen de ventas flete"
                                    t.Rows.Add(r)
                                End If

                            End While
                            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab &
                                       S2 & vbTab & S3 & vbTab & S4)
                        End Using
                    End Using
                Catch SQLex As SqlException
                    Dim SSS As SqlError, Sqlcadena As String = ""
                    For Each SSS In SQLex.Errors
                        Sqlcadena += SSS.Message & vbNewLine
                    Next
                    BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If

            If PR2 Then
                SQL = "SELECT F.CVE_DOC, F.CVE_CLPV, F.CVE_PEDI, C.NOMBRE, F.CAN_TOT, F.FECHA_DOC, 
                    ISNULL(F.IMP_TOT1 + F.IMP_TOT4,0) AS IVA, ISNULL(F.IMP_TOT2 + F.IMP_TOT3,0) AS RETENCION, F.IMPORTE AS NETO, 
(SELECT TOP 1 CAMPLIB3 FROM INVE_CLIB" & Empresa & " L LEFT JOIN PAR_FACTF" & Empresa & " P ON P.CVE_ART = L.CVE_PROD WHERE P.CVE_DOC = F.CVE_DOC) AS LIB3
                FROM FACTF" & Empresa & " F
                LEFT JOIN CFDI CFD ON CFD.FACTURA = F.CVE_DOC
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = F.CVE_CLPV
                WHERE ISNULL(F.STATUS,'A') <> 'C' AND ISNULL(CFD.ESTATUS,'A')  <> 'C' AND
                F.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND F.FECHA_DOC <= '" & FSQL(F2.Value) & "'
                ORDER BY F.CVE_DOC"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            If dr("LIB3").ToString.Trim = "S" Then
                                Try
                                    Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab &
                                               dr("CVE_PEDI") & vbTab & dr("FECHA_DOC") & vbTab & dr("CAN_TOT") & vbTab & dr("RETENCION") & vbTab &
                                               dr("IVA") & vbTab & dr("NETO"))

                                    S1 += dr("CAN_TOT")
                                    S2 += dr("RETENCION")
                                    S3 += dr("IVA")
                                    S4 += dr("NETO")
                                    r = t.NewRow()
                                    r("FACTURA") = dr("CVE_DOC")
                                    r("CLAVE") = dr("CVE_CLPV")
                                    r("NOMBRE") = dr("NOMBRE")
                                    r("DOCUMENT") = dr("CVE_PEDI")
                                    r("SUBTOTAL") = dr("CAN_TOT")
                                    r("RETENCION") = dr("RETENCION")
                                    r("IVA") = dr("IVA")
                                    r("IMPORTE") = dr("NETO")
                                    r("FECHA") = dr("FECHA_DOC")
                                    r("FEC1") = F1.Value
                                    r("FEC2") = F2.Value
                                    r("TITULO") = "Resumen de ventas otros"
                                    t.Rows.Add(r)
                                Catch ex As Exception
                                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End While
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab &
                                       S2 & vbTab & S3 & vbTab & S4)
                    End Using
                End Using
            End If

            Fg.AutoSizeCols()

            LtNUm.Text = "Registros : " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("180. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim Reporte As New StiReport
            Dim RUTA_FORMATOS As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportResumenVentas.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS)

            Reporte.RegData(DataSet1)

            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte.Render()
            'Reporte.Show()
            VisualizaReporte(Reporte)
            'StiReport1.Design()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Resumen de ventas")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Sub TITULOS()

        Fg.Cols.Count = 12

        Fg(0, 1) = "Documento"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Proveedor"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Nombre"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Su refer."
        Dim c5 As Column = Fg.Cols(4)
        c5.DataType = GetType(String)

        Fg(0, 5) = "Fecha"
        Dim c6 As Column = Fg.Cols(5)
        c6.DataType = GetType(DateTime)

        Fg(0, 6) = "Sub. total"
        Dim c10 As Column = Fg.Cols(6)
        c10.DataType = GetType(Decimal)
        Fg.Cols(6).Format = "###,###,##0.00"

        Fg(0, 7) = "Retención IVA"
        Dim c13 As Column = Fg.Cols(7)
        c13.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "IVA"
        Dim c14 As Column = Fg.Cols(8)
        c14.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Importe"
        Dim c19 As Column = Fg.Cols(9)
        c19.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"
    End Sub

    Private Sub RadVentasFlete_CheckedChanged(sender As Object, e As EventArgs) Handles RadVentasFlete.CheckedChanged
        Fg.Rows.Count = 1
    End Sub

    Private Sub RadVentasOtro_CheckedChanged(sender As Object, e As EventArgs) Handles RadVentasOtro.CheckedChanged
        Fg.Rows.Count = 1
    End Sub
End Class
