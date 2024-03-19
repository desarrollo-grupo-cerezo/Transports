Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports Stimulsoft.Report
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmFletesVsGastos

    Private _colTipoViaje As Integer = 4
    Private _colKmVacio As Integer = 22
    Private _colRendVacio As Integer = 23
    Private _colLitrosVacio As Integer = 24
    Private Sub FrmFletesVsGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Dim i As Integer = 1
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
            Me.CenterToScreen()

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String
            D1 = "01/" & Format(N.Month, "00") & "/" & N.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & N.Year

            SplitM1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill

            F1.Value = D1
            F2.Value = D2

            Fg.Rows(0).Height = 50
            Fg.Cols(1).Width = 70
            Fg.Cols(2).Width = 70
            Fg.Cols(3).Width = 270
            Fg.Cols(4).Width = 80
            Fg.Cols(5).Width = 80
            Fg.Cols(6).Width = 85
            Fg.Cols(7).Width = 280
            Fg.Cols(8).Width = 220
            Fg.Cols(9).Width = 85
            Fg.Cols(10).Width = 85
            Fg.Cols(11).Width = 85
            Fg.Cols(12).Width = 85
            Fg.Cols(13).Width = 85
            Fg.Cols(14).Width = 85
            Fg.Cols(15).Width = 85
            Fg.Cols(16).Width = 85
            Fg.Cols(17).Width = 85
            Fg.Cols(18).Width = 85

            If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                BarDiseno.Visible = True
            Else
                BarDiseno.Visible = False
            End If

            Me.Text = "Reporte " & VarFORM2
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmFletesVsGastos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Fletes vs Gastos")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim Reporte As New StiReport
            Dim RUTA_FORMATOS As String = ""

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportFletesVsGastos.mrt"

            If Not IO.File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            BarImprimir.Enabled = False


            Reporte.Load(RUTA_FORMATOS)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text

            Dim dt As DateTime = F1.Value, dt2 As DateTime = F2.Value
            Dim FF1 As String, FF2 As String

            FF1 = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00") & " 00:00:00"
            FF2 = dt2.Year & Format(dt2.Month, "00") & Format(dt2.Day, "00") & " 23:59:59"

            Reporte("F1") = FF1
            Reporte("F2") = FF2

            Reporte.Render()
            VisualizaReporte(Reporte)
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarDiseno_Click(sender As Object, e As ClickEventArgs) Handles BarDiseno.Click
        PrinterMRT("ReportFletesVsGastos")
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click

        Fg.Rows.Count = 1

        Fg.Redraw = False
        Fg.BeginUpdate()
        Me.Cursor = Cursors.WaitCursor

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Beige
        NewStyle1.ForeColor = Color.Black
        NewStyle1.DataType = GetType(Decimal)
        NewStyle1.Format = "N2"

        SQL = "SELECT A.CVE_VIAJE, A.FECHA, A.CONCILIADO, CASE WHEN A.TIPO_VIAJE = 1 THEN 'Cargado' ELSE 'Vacío' END AS TIP_VIAJE, A.CVE_OPER, A.CVE_TRACTOR, A.FECHA_CARGA,
            A.FECHA_DESCARGA, A.KM_RECORRIDOS,  A.CLIENTE, A.CVE_MONED, A.VOLUMEN_PESO, A.SUBTOTAL,  A.IVA, A.RETENCION, A.NETO, A.FLETE, 
            A.TIPO_CAMBIO, A.FECHA_REAL_CARGA,  A.FECHA_REAL_DESCARGA, A.KMS_VACIO, O.NOMBRE AS NOMBRE_OPER,  
            C.NOMBRE AS NOMBRE_CLIE, T.DESCR AS ORIGEN, T.DESCR2 AS DESTINO, 
            ISNULL((SELECT SUM(SUELDO) FROM GCLIQ_PARTIDAS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS SUELDO, 
            ROUND(ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_CASETAS LC WHERE LC.CVE_VIAJE = A.CVE_VIAJE)/1.16,0), 2) AS CASETAS,             
            ISNULL((SELECT SUM(SUBTOTAL) FROM GCCONCI_VALES_COMBUS_PAR VC WHERE VC.CVE_VIAJE = A.CVE_VIAJE AND VC.STATUS <> 'C'),0) AS COMBUSTIBLE,
            ISNULL((SELECT SUM(IMPORTE) FROM GCASIGNACION_VIAJE_GASTOS VG 
				WHERE VG.CVE_VIAJE = A.CVE_VIAJE AND STATUS = 'L' AND ST_GASTOS = 'DEPOSITADO'
				AND NOT VG.CVE_NUM IN ('64', '39', '42', '3', '63', '4', '5', '6')),0) AS GASTOS,			
            ISNULL(((SELECT KMS FROM GCTAB_RUTAS_F WHERE CVE_TAB = A.CVE_TAB_VIAJE) + (CASE WHEN A.TIPO_VIAJE = 0 THEN A.KMS_VACIO ELSE 0 END)),0) AS KMS_TOTALES,
            ISNULL((CASE WHEN A.TIPO_VIAJE = 1 THEN KMS_VACIO / ((SELECT KMS FROM GCTAB_RUTAS_F WHERE CVE_TAB = A.CVE_TAB_VIAJE) + KMS_VACIO) ELSE KMS_VACIO END),0) AS PORCEN_CARGADO,
            ISNULL((SELECT SUM(LITROS_REALES) FROM GCASIGNACION_VIAJE_VALES WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS LITROS, 
            T.KMS, T.AUTO_SENC, T.AUTO_SENC_LTS, A.KMS_VACIO, iif(A.TIPO_VIAJE = 0, 2.2,  0) as REND_VACIO, iif(A.TIPO_VIAJE = 0, A.KMS_VACIO/2.2,  0) LT_VACIO, CVE_LIQ = IIF(LP.CVE_LIQ IS NULL, '', CAST(LP.CVE_LIQ AS VARCHAR(20)))
            FROM GCASIGNACION_VIAJE A
            LEFT JOIN GCLIQ_PARTIDAS LP ON LP.CVE_VIAJE = A.CVE_VIAJE AND LP.STATUS = 'A'
            LEFT JOIN dbo.CLIE" & Empresa & " C ON A.CLIENTE = C.CLAVE 
            LEFT JOIN dbo.GCOPERADOR O ON A.CVE_OPER = O.CLAVE
            LEFT JOIN dbo.GCTAB_RUTAS_F T ON A.CVE_TAB_VIAJE = T.CVE_TAB
            WHERE A.STATUS <> 'C' AND A.FECHA_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND A.FECHA_CARGA <= '" & FSQL(F2.Value) & " 23:59:59'
            ORDER BY CVE_TRACTOR"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("TIPO_CAMBIO") = 0 Then
                            Debug.Print("")
                        End If
                        Fg.AddItem("" & vbTab & dr("CVE_TRACTOR") & vbTab & dr("CVE_VIAJE") & vbTab & dr("ORIGEN") & " - " & dr("DESTINO") & vbTab & dr("TIP_VIAJE") & vbTab &
                                   dr("FECHA_CARGA") & vbTab & dr("FECHA_DESCARGA") & vbTab & dr("NOMBRE_CLIE") & vbTab & dr("NOMBRE_OPER") & vbTab &
                                   IIf(dr("TIPO_CAMBIO") = 0, dr("FLETE"), dr("FLETE") * dr("TIPO_CAMBIO")) & vbTab & dr("SUELDO") & vbTab &
                                   dr("COMBUSTIBLE") & vbTab & dr("CASETAS") & vbTab & dr("GASTOS") & vbTab & dr("KMS_TOTALES") & vbTab & dr("PORCEN_CARGADO") / 100 & vbTab &
                                   dr("LITROS") & vbTab & IIf(dr("LITROS") > 0, dr("KMS_TOTALES") / dr("LITROS"), 0) & vbTab & dr("FLETE") - dr("SUELDO") - dr("COMBUSTIBLE") - dr("CASETAS") &
                                   vbTab & dr("KMS") & vbTab & dr("AUTO_SENC") & vbTab & dr("AUTO_SENC_LTS") & vbTab & dr("KMS_VACIO") & vbTab & dr("REND_VACIO") & vbTab & dr("LT_VACIO") & vbTab & dr("CVE_LIQ"))

                        If dr("TIP_VIAJE") = "Vacío" Then
                            Fg.SetCellStyle(Fg.Rows.Count - 1, _colRendVacio, NewStyle1)
                        End If

                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Fletes vs gastos")
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then

                If Not (Fg.Col = _colRendVacio And Fg(Fg.Row, _colTipoViaje) = "Vacío") Then
                    e.Cancel = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg.AfterEdit
        Try
            If Fg.Row > 0 Then

                If Fg.Col = _colRendVacio And Fg(Fg.Row, _colTipoViaje) = "Vacío" Then
                    Fg.FinishEditing()
                    If Convert.ToDecimal(Fg(Fg.Row, _colRendVacio)) > 0 Then
                        Fg(Fg.Row, _colLitrosVacio) = Fg(Fg.Row, _colKmVacio) / Fg(Fg.Row, _colRendVacio)
                    Else
                        Fg(Fg.Row, _colLitrosVacio) = 0
                    End If
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class