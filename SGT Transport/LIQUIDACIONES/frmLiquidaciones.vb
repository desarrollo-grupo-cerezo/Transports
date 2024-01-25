Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Windows.Media.Media3D
Imports Stimulsoft.Report.StiOptions.Export
Imports Stimulsoft.Report

Public Class FrmLiquidaciones
    Private CADENA As String = ""
    Private NRow As Long = 0
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG

            SplitM1.Dock = DockStyle.Fill

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg2.DrawMode = DrawModeEnum.OwnerDraw

            Tab1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill
            Tab1.ItemSize = New Size(140, 40)

            Tab1.HotTrack = True
            Tab1.SelectedTabBold = True
            Tab1.TabAreaBorder = True

            Try
                C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

            TITULOS()
            TITULOS2()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLiquidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub DESPLEGAR()

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Fg2.Redraw = False
            Fg2.Rows.Count = 1

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT L.CVE_LIQ, ISNULL(L.STATUS,'A') AS ST, L.FECHA, L.CVE_OPER, O.NOMBRE, ISNULL(S.DESCR,'EDICION') AS DESCR_ST_LIQ, 
                L.CVE_UNI, L.CVE_RES, IMPORTE, ISNULL((SELECT COUNT(*) FROM GCLIQ_PARTIDAS WHERE CVE_LIQ = L.CVE_LIQ),0) AS NUM_VIAJES,
                CASE WHEN L.STATUS = 'L' THEN 'LIQUIDADO' ELSE '' END AS ESTATUS
                FROM GCLIQUIDACIONES L
                LEFT JOIN GCSTATUS_LIQUIDACION S ON S.CVE_LIQ = L.CVE_ST_LIQ
                LEFT JOIN GCOPERADOR O ON O.CLAVE = L.CVE_OPER " & CADENA & "
                ORDER BY CVE_LIQ DESC"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If dr("ST") <> "C" Then
                    Fg.AddItem("" & vbTab & dr("CVE_LIQ") & vbTab & dr("FECHA") & vbTab & dr("CVE_OPER") & vbTab & dr("NOMBRE") & vbTab &
                           dr("CVE_UNI") & vbTab & dr("CVE_RES") & vbTab & dr("DESCR_ST_LIQ") & vbTab & dr("IMPORTE") & vbTab &
                           dr("NUM_VIAJES") & vbTab & dr("ESTATUS"))
                Else
                    Fg2.AddItem("" & vbTab & dr("CVE_LIQ") & vbTab & IIf(dr("ST") = "C", "Cancelada", "") & vbTab & dr("FECHA") & vbTab &
                        dr("CVE_OPER") & vbTab & dr("NOMBRE") & vbTab & dr("CVE_UNI") & vbTab & dr("CVE_RES") & vbTab & dr("DESCR_ST_LIQ") & vbTab &
                        dr("IMPORTE") & vbTab & dr("NUM_VIAJES") & vbTab & dr("ESTATUS"))
                End If
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            Fg2.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If NRow > 0 Then
            Fg.Row = NRow
        End If

        Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
        Fg.Subtotal(AggregateEnum.Clear)

        '  Get a Grand total (use -1 instead of column index).
        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 8, "Grand Total")

        Fg.Redraw = True
        Fg2.Redraw = True
        NRow = 0

    End Sub
    Private Sub FrmLiquidaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Liquidaciones")
        Me.Dispose()
    End Sub
    Private Sub FrmLiquidaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    'barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    BarSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    Try
                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
                    Catch ex As Exception
                    End Try

                    BarEdit.Enabled = True
                    SetTabColor(1)
                Case 1
                    Try
                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)
                    Catch ex As Exception
                    End Try
                    BarEdit.Enabled = False
                    SetTabColor(2)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetTabColor(FPAG As Integer)
        If FPAG = 1 Then
            'Pag1.TabBackColor = Color.SteelBlue
            'Pag1.TabBackColorSelected = Color.SteelBlue
            'Pag1.TabForeColor = Color.White
            'Pag1.TabForeColorSelected = Color.White

            'Pag2.TabBackColor = Color.FromArgb(234, 241, 250)
            'Pag2.TabBackColorSelected = Color.FromArgb(234, 241, 250)
            'Pag2.TabForeColor = Color.Black
            'Pag2.TabForeColorSelected = Color.Black
        Else
            'Pag1.TabBackColor = Color.FromArgb(234, 241, 250)
            'Pag1.TabBackColorSelected = Color.FromArgb(234, 241, 250)
            'Pag1.TabForeColor = Color.Black
            'pag1.TabForeColorSelected = Color.Black

            'Pag2.TabBackColor = Color.SteelBlue
            'Pag2.TabBackColorSelected = Color.SteelBlue
            'Pag2.TabForeColor = Color.White
            'Pag2.TabForeColorSelected = Color.White
        End If

    End Sub

    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg2(Fg2.Row, 1)
                CREA_TAB(FrmLiquidacionesAE, "Liquidación")
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Tab1.SelectedIndex = 0
            NRow = 0
            Var1 = "Nuevo"
            CREA_TAB(FrmLiquidacionesAE, "Liquidación")
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                NRow = Fg.Row
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                CREA_TAB(FrmLiquidacionesAE, "Liquidación")
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "LIQUIDACIONES")
                Case 1
                    EXPORTAR_EXCEL_TRANSPORT(Fg2, "LIQUIDACIONES CANCELADAS")
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11
            Fg.Rows(0).Height = 40

            Fg(0, 1) = "Folio"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Fecha"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(DateTime)

            Fg(0, 3) = "Operador"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Nombre"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Unidad"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Reseteo"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Estatus liq."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Importe a liquidar"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            c8.Format = "N2"

            Fg(0, 9) = "Viajes realizados"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)

            Fg(0, 10) = "Estatus"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            'c9.Format = "N2"
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS2()
        Try
            Fg2.Rows.Count = 1
            Fg2.Cols.Count = 1
            Fg2.Cols.Count = 11

            Fg2.Rows(0).Height = 40

            Fg2(0, 1) = "Folio"
            Dim cc1 As Column = Fg2.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg2(0, 2) = "Estatus"
            Dim c2 As Column = Fg2.Cols(2)
            c2.DataType = GetType(String)

            Fg2(0, 3) = "Fecha"
            Dim cc2 As Column = Fg2.Cols(3)
            cc2.DataType = GetType(DateTime)

            Fg2(0, 4) = "Operador"
            Dim c3 As Column = Fg2.Cols(4)
            c3.DataType = GetType(Int32)

            Fg2(0, 5) = "Nombre"
            Dim c4 As Column = Fg2.Cols(5)
            c4.DataType = GetType(String)

            Fg2(0, 6) = "Unidad"
            Dim c5 As Column = Fg2.Cols(6)
            c5.DataType = GetType(String)

            Fg2(0, 7) = "Reseteo"
            Dim c6 As Column = Fg2.Cols(7)
            c6.DataType = GetType(String)

            Fg2(0, 8) = "Estatus liq."
            Dim c7 As Column = Fg2.Cols(8)
            c7.DataType = GetType(String)

            Fg2(0, 9) = "Importe a liquidar"
            Dim c8 As Column = Fg2.Cols(9)
            c8.DataType = GetType(Decimal)
            c8.Format = "N2"

            Fg2(0, 10) = "Viajes realizados"
            Dim c9 As Column = Fg2.Cols(10)
            c9.DataType = GetType(Decimal)
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        CADENA = " WHERE FECHA = '" & FSQL(Date.Now) & "' "
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)

        CADENA = " WHERE FECHA = '" & FSQL(dt) & "' "
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today

        CADENA = " WHERE YEAR(FECHA) = " & dt.Year & " AND MONTH(FECHA) = " & dt.Month
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        CADENA = " WHERE YEAR(FECHA) = " & dt.Year & " AND MONTH(FECHA) = " & dt.Month
        DESPLEGAR()
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        CADENA = ""
        DESPLEGAR()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

        End If
    End Sub
    Private Sub Fg2_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg2.OwnerDrawCell
        If e.Row >= Fg2.Rows.Fixed And e.Col = Fg2.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg2.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

        End If
    End Sub

    Private Sub BarImpLiq_Click(sender As Object, e As EventArgs) Handles BarImpLiq.Click
        Dim RUTA_FORMATOS As String = "", CVE_LIQ As String = "", CVE_OPER As Integer, CVE_TRACTOR As String
        Dim Report As New StiReport

        CVE_LIQ = Fg(Fg.Row, 1)

        If CVE_LIQ.Trim.Length > 0 Then

            CVE_OPER = Fg(Fg.Row, 3)
            CVE_TRACTOR = ""

            Try
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportLiquidacion.mrt"
                If Not IO.File.Exists(RUTA_FORMATOS) Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                    Return
                End If

                Report.Load(RUTA_FORMATOS)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                Report.Dictionary.Databases.Clear()
                Report.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                Report.Compile()
                Report.Dictionary.Synchronize()
                Report.ReportName = Me.Text
                Report.Item("CVE_LIQ1") = CLng(CVE_LIQ)
                Report.Item("CVE_LIQ2") = CLng(CVE_LIQ)
                Report.Item("CVE_LIQ3") = CLng(CVE_LIQ)
                Report.Item("CVE_LIQ4") = CLng(CVE_LIQ)
                Report.Item("CVE_LIQ5") = CLng(CVE_LIQ)
                Report.Item("CVE_OPER") = CLng(CVE_OPER)
                Report.Item("CVE_TRACTOR") = CVE_TRACTOR
                Report.Item("CVE_OPER_DED") = CLng(CVE_OPER)
                Report.Render()
                'StiReport1.Print(True)
                VisualizaReporte(Report)

            Catch ex As Exception
                BITACORA_LIQ("1840. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("1840. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione un reseteo")
        End If
    End Sub
End Class
