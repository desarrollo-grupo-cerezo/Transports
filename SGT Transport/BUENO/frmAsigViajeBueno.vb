Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports C1.Win.C1Command

Public Class FrmAsigViajeBueno

    Private ReadOnly BindingSource1 As New BindingSource
    Private CADENA As String
    Private FG_NUMBER As Boolean = True
    Private WithEvents MenuCV As New ContextMenuStrip

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().   
    End Sub
    Private Sub FrmAsigViajeBueno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            FgR.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg3.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg4.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg2.AllowEditing = True
            Fg4.AllowEditing = True

            BarTimbrar.Enabled = False
            BarCancFactura.Enabled = False
            BarOpciones.Enabled = False

            SplitM.Dock = DockStyle.Fill

            SplitM.BorderWidth = 0
            SplitM.FixedLineWidth = 0
            SplitM.HeaderLineWidth = 0
            SplitM.SplitterWidth = 0

            SplitP1.BorderWidth = 0
            SplitP2.BorderWidth = 0

            TAB1.SelectedIndex = 0

            Dim SPOR1 As Decimal
            SPOR1 = (C1ToolBar1.Height / Me.Height) * 100
            SplitP1.SizeRatio = SPOR1 + 1
            SplitP2.SizeRatio = 100 - SplitP1.SizeRatio - 1

            SplitM5.Dock = DockStyle.Fill

            SPOR1 = (C1ToolBar1.Height / Me.Height) * 100
            SplitMP1.SizeRatio = SPOR1 - 2
            SplitMP2.SizeRatio = 100 - SplitMP1.SizeRatio

            C1FlexGridSearchPanel1.Top = 10
        Catch ex As Exception
        End Try
    End Sub

    Sub CARGAR_DATOS1()
        Try
            Fg.BeginUpdate()
            Fg2.BeginUpdate()
            Fg3.BeginUpdate()
            Fg4.BeginUpdate()
            FgR.BeginUpdate()

            Fg.Redraw = False
            Fg2.Redraw = False
            Fg3.Redraw = False
            Fg4.Redraw = False
            FgR.Redraw = False


            Me.TAB1.Dock = DockStyle.Fill

            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1
            Fg3.Rows.Count = 1
            Fg4.Rows.Count = 1
            FgR.Rows.Count = 1
            FgR.Dock = DockStyle.Fill
            Fg4.Dock = DockStyle.Fill

            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg3.Styles.EmptyArea.BackColor = ColoFondoFG


            SplitM5.BorderWidth = 0
            SplitM5.FixedLineWidth = 1
            SplitM5.HeaderLineWidth = 0
            SplitM5.SplitterWidth = 0

            SplitMP1.BorderWidth = 0
            SplitMP2.BorderWidth = 0


            C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Styles("Focus").BackColor = Color.PowderBlue
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg.FocusRect = FocusRectEnum.Solid
            Fg.Transpose()
            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg.Styles.Fixed.WordWrap = True
            Fg.ContextMenuStrip = MenuCV
            Fg.Rows(0).Height = 40
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg2.Styles("Focus").BackColor = Color.PowderBlue
            Fg2.Styles("Focus").Border.Color = Color.Red
            Fg2.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg2.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg2.FocusRect = FocusRectEnum.Solid
            Fg2.Transpose()
            Fg2.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg2.Styles.Fixed.WordWrap = True
            Fg2.ContextMenuStrip = MenuCV
            Fg2.Rows(0).Height = 40
            Fg2.DrawMode = DrawModeEnum.OwnerDraw

            Fg3.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg3.Styles("Focus").BackColor = Color.PowderBlue
            Fg3.Styles("Focus").Border.Color = Color.Red
            Fg3.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg3.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg3.FocusRect = FocusRectEnum.Solid
            Fg3.Transpose()
            Fg3.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg3.Styles.Fixed.WordWrap = True
            Fg3.ContextMenuStrip = MenuCV
            Fg3.Rows(0).Height = 40
            Fg3.DrawMode = DrawModeEnum.OwnerDraw

            Fg4.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg4.Styles("Focus").BackColor = Color.PowderBlue
            Fg4.Styles("Focus").Border.Color = Color.Red
            Fg4.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg4.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg4.FocusRect = FocusRectEnum.Solid
            Fg4.Transpose()
            Fg4.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg4.Styles.Fixed.WordWrap = True
            Fg4.ContextMenuStrip = MenuCV
            Fg4.Rows(0).Height = 40
            Fg4.DrawMode = DrawModeEnum.OwnerDraw

            FgR.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            FgR.Styles("Focus").BackColor = Color.PowderBlue
            FgR.Styles("Focus").Border.Color = Color.Red
            FgR.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            FgR.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            FgR.FocusRect = FocusRectEnum.Solid
            FgR.Transpose()
            FgR.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            FgR.Styles.Fixed.WordWrap = True
            FgR.ContextMenuStrip = MenuCV
            FgR.Rows(0).Height = 40
            FgR.DrawMode = DrawModeEnum.OwnerDraw

            BarReactivarFactura.Enabled = False
            MenuCV.Items.Add("Consultar viaje")

            DERECHOS()

            CADENA = "WHERE A.STATUS = 'A' AND ISNULL(A.FACTURADO,'') <> 'S' AND ISNULL(A.TIMBRADO,'') <> 'S'"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.EndUpdate()
        Fg2.EndUpdate()
        Fg3.EndUpdate()
        Fg4.EndUpdate()
        FgR.EndUpdate()

        Fg.Redraw = True
        Fg2.Redraw = True
        Fg3.Redraw = True
        Fg4.Redraw = True
        FgR.Redraw = True

    End Sub
    Private Sub MenuCV_Opening(sender As Object, e As CancelEventArgs) Handles MenuCV.Opening
        MenuCV.Items.Clear()

        MenuCV.Items.AddRange({New ToolStripMenuItem("Consultar viaje " & Fg(Fg.Row, 2).ToString)})
    End Sub
    Private Sub MenuCV_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuCV.ItemClicked
        Try
            Var1 = "Edit"

            Select Case TAB1.SelectedIndex
                Case 0
                    Var2 = Fg(Fg.Row, 1)
                    Var10 = "VVM"
                Case 1
                    Var2 = Fg2(Fg2.Row, 2)
                    Var10 = "SEFACTURA"
                Case 2
                    Var2 = Fg4(Fg4.Row, 14)
                    Var10 = "SEFACTURA_MULT"
                Case 3
                    Var2 = Fg3(Fg3.Row, 1)
                    Var10 = "SEFACTURA 3"
            End Select

            Var17 = "C"

            Var11 = "Viaje no facturado"

            'Closo_Form_Open(FrmAsigViajeBuenoAE)

            FrmAsigViajeBuenoAE.ShowDialog()
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            '(SELECT CASE WHEN COUNT(*) = 0 THEN '' ELSE CAST(COUNT(*) AS VARCHAR(3)) END FROM GCASIGNACION_VIAJE_GASTOS GV WHERE CVE_VIAJE = A.CVE_VIAJE AND ISNULL(GV.STATUS,'A') = 'A') AS 'Gastos capturados',
            '(SELECT CASE WHEN COUNT(*) = 0 THEN '' ELSE CAST(COUNT(*) AS VARCHAR(3)) END FROM GCASIGNACION_VIAJE_VALES GV WHERE GV.CVE_VIAJE = A.CVE_VIAJE AND ISNULL(GV.STATUS,'A') = 'A') AS 'Vales capturados', 
            '@TIPO_FACTURACION

            Select Case TAB1.SelectedIndex
                Case 0 'VIAJES NO FACTURADOS
                    SQL = "SELECT TOP 5000 A.CVE_VIAJE AS 'Clave viaje', A.CLIENTE AS 'Cliente', C.NOMBRE AS 'Nombre cliente', C1.NOMBRE AS ORIGEN, 
                        C2.NOMBRE AS DESTINO, O.NOMBRE AS 'Operador', U.CLAVEMONTE AS 'Tractor', A.FECHA_CARGA AS 'Fecha carga', 
                        A.FECHA_DESCARGA AS 'Fecha descarga', A.FECHA AS 'Fecha creación',                 
                        (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS 'Tipo unidad', 
                        TIPO_FACTURACION AS 'Tipo de facturación', A.SERIE + CAST(A.FOLIO AS VARCHAR(10)) AS 'Factura', 
                        CASE 
                        WHEN ISNULL(ESTATUS,'N') = 'C' THEN 'CANCELADA' 
                        WHEN ISNULL(CFD.TIMBRADO,'N') = 'S' THEN 'TIMBRADA' 
                        WHEN ISNULL(CFD.TIMBRADO,'N') = 'N' THEN 'Pendiente' ELSE 'Cancelada' END AS 'Estatus CFDI', 
                        A.SUBTOTAL AS 'Subtotal', A.IVA AS 'IVA', A.RETENCION AS 'Retención', A.NETO AS 'Importe', 
                        ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS 'Abonos',
                        (A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS 'Saldo',
                        C.RFC, C.USO_CFDI, C.REG_FISC, C.CODIGO, AA.STATUS
                        FROM GCASIGNACION_VIAJE A 
                        LEFT JOIN GCASIGNACION_VIAJE_ABONOS AA ON AA.CVE_VIAJE = A.CVE_VIAJE
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN CFDI CFD ON CFD.FACTURA = A.FACTURA_CFDI
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = A.CLIENTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                        LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                        " & CADENA & " ORDER BY TRY_PARSE(A.CVE_VIAJE AS INT) DESC"
                Case 1 'VIAJES FACTURADOS ESCENARIO 1 Y 2
                    SQL = "SELECT TOP 5000 ISNULL(COM_TOT_PORC,0) AS 'Seleccione', A.CVE_VIAJE AS 'Clave viaje', C.CLAVE AS 'Cliente', C.NOMBRE AS 'Nombre cliente', 
                        C1.NOMBRE AS ORIGEN, F.TIMBRADO, C2.NOMBRE AS DESTINO, O.NOMBRE AS 'Operador', U.CLAVEMONTE AS 'Tractor', A.FECHA_CARGA AS 'Fecha carga', 
                        A.FECHA_DESCARGA AS 'Fecha descarga', A.FECHA AS 'Fecha creación',                 
                        (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS 'Tipo unidad', 
                        TIPO_FACTURACION AS 'Tipo de facturación', ISNULL(F.CVE_DOC,'')  AS 'Factura', 
                        CASE WHEN TIPO_FACTURACION = 3 THEN F.CAN_TOT ELSE A.SUBTOTAL END AS 'Subtotal',
                        CASE WHEN TIPO_FACTURACION = 3 THEN F.IMP_TOT4 ELSE A.IVA END AS 'IVA',
                        CASE WHEN TIPO_FACTURACION = 3 THEN F.IMP_TOT3 ELSE A.RETENCION END AS 'Retención',
                        CASE WHEN TIPO_FACTURACION = 3 THEN F.IMPORTE ELSE A.NETO END AS 'Importe',
                        ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = F.CVE_VIAJE AND CVE_DOC = F.CVE_DOC),0) AS 'Abonos',
                        (F.IMPORTE - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = F.CVE_VIAJE AND CVE_DOC = F.CVE_DOC),0)) AS 'Saldo',
                        C.RFC, C.USO_CFDI, C.REG_FISC, C.CODIGO, AA.STATUS
                        FROM FACTF" & Empresa & " F 
                        LEFT JOIN GCASIGNACION_VIAJE A ON F.CVE_VIAJE = A.CVE_VIAJE
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = F.CVE_CLPV
                        LEFT JOIN GCASIGNACION_VIAJE_ABONOS AA ON AA.CVE_VIAJE = A.CVE_VIAJE AND AA.STATUS = 'L'
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                        LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                        " & CADENA &
                        " ORDER BY TRY_PARSE(A.CVE_VIAJE AS INT) DESC"
                    Debug.Print("")
                    'CADENA = "WHERE A.STATUS <> 'C' AND ISNULL(A.FACTURADO,'') = 'S' AND ISNULL(A.TIMBRADO,'') <> 'S' AND ISNULL(TIPO_FACTURACION,0) <> 2"
                Case 2 ' VIAJES FACTURADOS CON MAS DE UN VIAJE
                    'ESCENARIO 3
                    SQL = "SELECT TOP 5000 ISNULL(COM_TOT_PORC,0) AS 'Seleccione', A.CVE_VIAJE AS 'Clave viaje', C.CLAVE AS 'Cliente', 
                        C.NOMBRE AS 'Nombre cliente', C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO, O.NOMBRE AS 'Operador', U.CLAVEMONTE AS 'Tractor', 
                        A.FECHA_CARGA AS 'Fecha carga', A.FECHA_DESCARGA AS 'Fecha descarga', A.FECHA AS 'Fecha creación',                 
                        (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS 'Tipo unidad', 
                        TIPO_FACTURACION AS 'Tipo de facturación', F.CVE_DOC AS 'Factura', 
                        F.CAN_TOT AS 'Subtotal', F.IMP_TOT4 AS 'IVA', F.IMP_TOT3 AS 'Retención', F.IMPORTE AS 'Importe', 
                        ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS 'Abonos',
                        (A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS 'Saldo',
                        C.RFC, C.USO_CFDI, C.REG_FISC, C.CODIGO
                        FROM FACTF" & Empresa & " F
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = F.CVE_CLPV
                        LEFT JOIN GCASIGNACION_VIAJE A ON F.CVE_VIAJE = A.CVE_VIAJE
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE                        
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                        LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                        " & CADENA &
                        " ORDER BY TRY_PARSE(A.CVE_VIAJE AS INT) DESC"
                Case 3 'VIAJES FACTURADOS Y TIMBRADOS CORRECTO 31 JULIO 2023
                    SQL = "SELECT TOP 5000 A.CVE_VIAJE AS 'Clave viajes', C.CLAVE AS 'Cliente', C.NOMBRE AS 'Nombre cliente', C1.NOMBRE AS ORIGEN, 
                        C2.NOMBRE AS DESTINO, O.NOMBRE AS 'Operador', U.CLAVEMONTE AS 'Tractor', A.FECHA_CARGA AS 'Fecha carga', 
                        A.FECHA_DESCARGA AS 'Fecha descarga', A.FECHA AS 'Fecha creación',                 
                        (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS 'Tipo unidad', 
                        CASE WHEN ISNULL(TIPO_FACTURACION,0) = 2 THEN ISNULL(TIPO_FACTURACION,0) ELSE '2' END AS 'Tipo de facturación', 
                        A.SERIE + CAST(A.FOLIO AS VARCHAR(10)) AS 'Factura', 
                        CASE 
                        WHEN ISNULL(ESTATUS,'N') = 'C' THEN 'CANCELADA' 
                        WHEN ISNULL(CFD.TIMBRADO,'N') = 'S' THEN 'TIMBRADA' 
                        WHEN ISNULL(CFD.TIMBRADO,'N') = 'N' THEN 'Pendiente' ELSE 'Cancelada' END AS 'Estatus CFDI', 
                        A.SUBTOTAL AS 'Subtotal', A.IVA AS 'IVA', A.RETENCION AS 'Retención', A.NETO AS 'Importe', 
                        ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS 'Abonos',
                        (A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS 'Saldo',
                        C.RFC, C.USO_CFDI, C.REG_FISC, C.CODIGO
                        FROM CFDI CFD 
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = CFD.CLIENTE
                        LEFT JOIN GCASIGNACION_VIAJE A ON CFD.FACTURA  = A.CVE_DOC
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                        LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                        " & CADENA & " 
                        ORDER BY TRY_PARSE(A.CVE_VIAJE AS INT) DESC"
                Case 4 'RELACION COBRANZA
                    SQL = "SELECT CVE_REL AS 'Clave', R.CLIENTE AS 'Cliente', C.NOMBRE AS 'Nombre', 
                        CASE WHEN R.STATUS = 'A' THEN 'Activo' ELSE 'Eliminado' END AS 'Estatus', FECHA AS 'Fecha', 
                        FECHA_ENVIO AS 'Fecha envió', FECHA_RECEP AS 'Fecha recepción', GUIA AS 'Guía', SUBTOTAL AS 'Subtotal', 
                        IVA, RET AS 'IVA Retenido', TOTAL AS 'Total', R.USUARIO AS 'Usuario'
                        FROM GCREL_FACTURAS R
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = R.CLIENTE
                        WHERE ISNULL(R.STATUS,'') = 'A'
                        ORDER BY FECHAELAB"
            End Select

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt

            Select Case TAB1.SelectedIndex
                Case 0

                    Fg.Redraw = False
                    Fg.BeginUpdate()

                    Try
                        Fg.DataSource = BindingSource1.DataSource
                        Fg.Cols(10).Visible = False
                        Fg.Cols(12).Visible = False
                        Fg.Cols(13).Visible = False
                        Fg.Cols(14).Visible = False
                        Fg.Cols(19).Visible = False
                        Fg.Cols(20).Visible = False
                        Fg.Cols(21).Visible = False
                        Fg.Cols(22).Visible = False
                        Fg.Cols(23).Visible = False
                        Fg.Cols(24).Visible = False
                        Fg.Cols(25).Visible = False

                        Fg.Cols(5).Visible = True
                        Fg.Cols(6).Visible = True
                        Fg.Cols(7).Visible = True
                        Fg.Cols(8).Visible = True

                        Fg.Cols(15).Format = "###,###,##0.00"
                        Fg.Cols(16).Format = "###,###,##0.00"
                        Fg.Cols(17).Format = "###,###,##0.00"
                        Fg.Cols(18).Format = "###,###,##0.00"

                        For k = 1 To Fg.Cols.Count - 1
                            Fg.Cols(k).StarWidth = "*"
                        Next
                        Fg.Cols(3).StarWidth = "3*"
                        Fg.Cols(4).StarWidth = "2*"
                        Fg.Cols(5).StarWidth = "2*"
                        Fg.Cols(6).StarWidth = "2*"

                        Fg.Styles.Fixed.WordWrap = True
                        Fg.Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
                        Fg.Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter
                        Fg.Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter

                        Fg.Cols(7).TextAlign = TextAlignEnum.CenterCenter
                        Fg.Cols(11).TextAlign = TextAlignEnum.CenterCenter
                        Fg.Cols(12).TextAlign = TextAlignEnum.CenterCenter

                        Fg.Focus()

                        Fg.Redraw = True
                        Fg.EndUpdate()
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Fg.Redraw = True
                    Fg.EndUpdate()
                Case 1 'FACTURADOS
                    Try
                        Fg2.Redraw = False
                        Fg2.BeginUpdate()

                        Fg2.DataSource = BindingSource1.DataSource

                        Fg2.Cols(10).Visible = False
                        'Fg2.Cols(14).Visible = False
                        Fg2.Cols(21).Visible = False
                        Fg2.Cols(22).Visible = False
                        Fg2.Cols(23).Visible = False
                        Fg2.Cols(24).Visible = False
                        Fg2.Cols(25).Visible = False

                        Fg2.Cols(15).Format = "###,###,##0.00"
                        Fg2.Cols(16).Format = "###,###,##0.00"
                        Fg2.Cols(17).Format = "###,###,##0.00"
                        Fg2.Cols(18).Format = "###,###,##0.00"
                        Fg2.Cols(19).Format = "###,###,##0.00"
                        Fg2.Cols(20).Format = "###,###,##0.00"

                        For k = 1 To Fg2.Rows.Count - 1
                            Fg2.Cols(k).StarWidth = "*"
                        Next
                        Fg2.Cols(3).StarWidth = "3*"
                        Fg2.Cols(4).StarWidth = "2*"
                        Fg2.Cols(5).StarWidth = "2*"
                        Fg2.Cols(6).StarWidth = "2*"

                        Fg2.Styles.Fixed.WordWrap = True
                        Fg2.Cols(7).TextAlign = TextAlignEnum.CenterCenter
                        Fg2.Cols(11).TextAlign = TextAlignEnum.CenterCenter
                        Fg2.Cols(12).TextAlign = TextAlignEnum.CenterCenter

                        Dim c11 As Column = Fg2.Cols(1)
                        c11.DataType = GetType(Boolean)
                        c11.AllowEditing = True

                        Fg2.Focus()
                        Fg2.Redraw = True
                        Fg2.EndUpdate()

                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Fg.Redraw = True
                    Fg.EndUpdate()
                Case 2 'ESCENARIO 2
                    Fg4.Redraw = False
                    Fg4.BeginUpdate()

                    Try
                        Fg4.DataSource = BindingSource1.DataSource

                        For k = 1 To Fg4.Cols.Count - 1
                            Fg4.Cols(k).StarWidth = "*"
                        Next

                        Fg4.Cols(1).StarWidth = "*"
                        Fg4.Cols(3).StarWidth = "3*"
                        Fg4.Cols(4).StarWidth = "2*"
                        Fg4.Cols(5).StarWidth = "2*"
                        Fg4.Cols(6).StarWidth = "2*"

                        Fg4.Cols(10).Visible = False
                        Fg4.Cols(14).Visible = True
                        Fg4.Cols(21).Visible = False
                        Fg4.Cols(22).Visible = False
                        Fg4.Cols(23).Visible = False
                        Fg4.Cols(24).Visible = False

                        Fg4.Cols(15).Format = "###,###,##0.00"
                        Fg4.Cols(16).Format = "###,###,##0.00"
                        Fg4.Cols(17).Format = "###,###,##0.00"
                        Fg4.Cols(18).Format = "###,###,##0.00"
                        Fg4.Cols(19).Format = "###,###,##0.00"
                        Fg4.Cols(20).Format = "###,###,##0.00"

                        Fg4.Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
                        Fg4.Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter
                        Fg4.Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter

                        Fg4.Cols(7).TextAlign = TextAlignEnum.CenterCenter
                        Fg4.Cols(11).TextAlign = TextAlignEnum.CenterCenter
                        Fg4.Cols(12).TextAlign = TextAlignEnum.CenterCenter
                        Fg4.Styles.Fixed.WordWrap = True

                        Dim c11 As Column = Fg4.Cols(1)
                        c11.DataType = GetType(Boolean)
                        c11.AllowEditing = True

                        Fg4.Focus()
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Fg4.Redraw = True
                    Fg4.EndUpdate()
                Case 3 'TIMBRADOS
                    Try
                        Fg3.Redraw = False
                        Fg3.BeginUpdate()

                        Fg3.DataSource = BindingSource1.DataSource

                        Fg3.Cols(14).Format = "###,###,##0.00"
                        Fg3.Cols(15).Format = "###,###,##0.00"
                        Fg3.Cols(16).Format = "###,###,##0.00"
                        Fg3.Cols(17).Format = "###,###,##0.00"
                        Fg3.Cols(18).Format = "###,###,##0.00"
                        Fg3.Cols(19).Format = "###,###,##0.00"
                        Fg3.Cols(20).Format = "###,###,##0.00"

                        Fg3.Cols(1).Visible = True
                        Fg3.Cols(2).Visible = True
                        Fg3.Cols(10).Visible = False
                        Fg3.Cols(18).Visible = False
                        Fg3.Cols(21).Visible = False
                        Fg3.Cols(22).Visible = False
                        Fg3.Cols(23).Visible = False

                        For k = 1 To Fg3.Cols.Count - 1
                            Fg3.Cols(k).StarWidth = "*"
                        Next

                        Fg3.Cols(1).StarWidth = "3*"
                        Fg3.Cols(3).StarWidth = "3*"
                        Fg3.Cols(4).StarWidth = "2*"
                        Fg3.Cols(5).StarWidth = "2*"
                        Fg3.Cols(6).StarWidth = "2*"
                        Fg3.Cols(7).TextAlign = TextAlignEnum.CenterCenter
                        Fg3.Cols(11).TextAlign = TextAlignEnum.CenterCenter
                        Fg3.Cols(12).TextAlign = TextAlignEnum.CenterCenter

                        Fg3.Focus()

                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Fg3.Redraw = True
                    Fg3.EndUpdate()

                Case 4

                    FgR.Redraw = False
                    FgR.BeginUpdate()

                    Try
                        FgR.DataSource = BindingSource1.DataSource

                        SQL = "SELECT CVE_REL AS 'Clave', R.CLIENTE AS 'Cliente', C.NOMBRE AS 'Nombre', 
                            CASE WHEN R.STATUS = 'A' THEN 'Activo' ELSE 'Eliminado' END AS 'Estatus', FECHA AS 'Fecha', 
                            FECHA_ENVIO AS 'Fecha envió', FECHA_RECEP AS 'Fecha recepción', GUIA AS 'Guía', SUBTOTAL AS 'Subtotal', 
                            IVA, RET AS 'IVA Retenido', TOTAL AS 'Total', R.USUARIO AS 'Usuario'
                            FROM GCREL_FACTURAS R
                            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = R.CLIENTE
                            WHERE ISNULL(R.STATUS,'') = 'A'
                            ORDER BY FECHAELAB"

                        FgR.Cols(9).Format = "###,###,##0.00"
                        FgR.Cols(10).Format = "###,###,##0.00"
                        FgR.Cols(11).Format = "###,###,##0.00"
                        FgR.Cols(12).Format = "###,###,##0.00"

                        FgR.Cols(1).StarWidth = "*" 'CLAVE
                        FgR.Cols(2).StarWidth = "*" 'CLIENTE
                        FgR.Cols(3).StarWidth = "3*" 'NOMBRE
                        FgR.Cols(4).StarWidth = "*" 'ESTATUS
                        FgR.Cols(5).StarWidth = "*" 'FECHA
                        FgR.Cols(6).StarWidth = "*" 'FECHA ENVIO
                        FgR.Cols(7).StarWidth = "*" 'FECHA RECEP
                        FgR.Cols(8).StarWidth = "*" 'GUIA
                        FgR.Cols(9).StarWidth = "*" 'SUBTOTAL
                        FgR.Cols(10).StarWidth = "*" 'IVA
                        FgR.Cols(11).StarWidth = "*" 'RETENCIO
                        FgR.Cols(12).StarWidth = "*" 'TOTAL

                        FgR.Cols(1).TextAlign = TextAlignEnum.CenterCenter
                        FgR.Cols(4).TextAlign = TextAlignEnum.CenterCenter
                        FgR.Cols(5).TextAlign = TextAlignEnum.CenterCenter
                        FgR.Cols(6).TextAlign = TextAlignEnum.CenterCenter
                        FgR.Cols(7).TextAlign = TextAlignEnum.CenterCenter

                        FgR.SubtotalPosition = SubtotalPositionEnum.BelowData
                        FgR.Subtotal(AggregateEnum.Clear)
                        FgR.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
                        FgR.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
                        FgR.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
                        FgR.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")

                        FgR.Focus()

                        FgR.Redraw = True
                        FgR.EndUpdate()
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    FgR.Redraw = True
                    FgR.EndUpdate()
            End Select

            If PASS_GRUPOCE.ToUpper = "BUS" Then

                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
                For k = 1 To Fg2.Cols.Count - 1
                    Fg2(0, k) = k & "." & Fg2(0, k)
                Next
                For k = 1 To Fg3.Cols.Count - 1
                    Fg3(0, k) = k & "." & Fg3(0, k)
                Next
                For k = 1 To Fg4.Cols.Count - 1
                    Fg4(0, k) = k & "." & Fg4(0, k)
                Next
            ElseIf PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                BarDiseñador.Visible = True
            Else
                BarDiseñador.Visible = False
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarNuevo.Visible = False
                BarConsultar.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                (CLAVE >= 22000 AND CLAVE < 22990 OR CLAVE >= 222000 AND CLAVE < 222400)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 22000  'ASIGNACION DE VIAJE

                                Case 22010  'NUEVO VIAJE
                                    BarNuevo.Visible = True
                                Case 22020  'EDIT VIAJE
                                    BarConsultar.Visible = True
                                Case 22030  'CANCELAR VIAJE
                                    'barEliminar.Visible = True
                                Case 22040  'GRABAR VIAJE
                                Case 22050  'DATOS GENERALES
                                Case 22070  'OBSERVACIONES VIAJE
                                Case 22080  'GASTOS DE CIAJE
                                Case 22090  'DATOS DE LA BITACORA
                                Case 22100  'IMPRIMIR BITACORA DE VIAJE
                                Case 22110  'IMPIRMIR CARTA PORTE

                                Case 222050 'CONSULTAR 

                                Case 222070 'CONSULTAR 

                                Case 222090 'CONSULTAR 

                                Case 222110 'CONSULTAR 

                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmAsigViajeBueno_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Facturar viaje")
        Me.Dispose()
    End Sub
    Private Sub FrmAsigViajeBueno_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F12
                    C1FlexGridSearchPanel1.Controls.Item(0).Focus()
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            Select Case TAB1.SelectedIndex
                Case 0
                    CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND ISNULL(A.FACTURADO,'') <> 'S' AND ISNULL(A.TIMBRADO,'') <> 'S'"
                Case 1
                    CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND A.STATUS <> 'C' AND ISNULL(A.FACTURADO,'') = 'S' AND ISNULL(TIPO_FACTURACION,0) <> 2"
                Case 2
                    CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND A.STATUS <> 'C' AND ISNULL(A.FACTURADO,'') = 'S' AND ISNULL(TIPO_FACTURACION,0) = 2"
                Case 3
                    CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND A.STATUS <> 'C' AND (ISNULL(A.TIMBRADO,'') = 'S'"
            End Select

            If tCVE_TRACTOR.Text.Trim.Length > 0 Then
                CADENA = CADENA & " AND A.STATUS = 'A' AND U.CLAVEMONTE = '" & tCVE_TRACTOR.Text & "'"
            End If

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles btnTractor.Click
        Try
            Var2 = "Unidades2"
            Var3 = ""
            Var4 = "1"
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TRACTOR.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles tCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If tCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    tCVE_TRACTOR.Text = Var5
                End If
            Else
                tCVE_TRACTOR.Text = ""
            End If
        Catch ex As Exception
            Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("145. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Dim HayError As Boolean = False
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try

        Try
            Var1 = "Edit"
            ESCENARIO = 0
            Select Case TAB1.SelectedIndex
                Case 0
                    If Fg.Row > 0 Then

                        Var2 = Fg(Fg.Row, 1)
                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"

                    End If
                Case 1
                    If Fg2.Row > 0 Then

                        Var2 = Fg2(Fg2.Row, 2)
                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"
                    End If
                Case 2
                    If Fg4.Row > 0 Then
                        Var2 = Fg4(Fg4.Row, 14)

                        Var17 = "C"
                        Var10 = "VIAJE BUENO"
                        Var11 = "Viaje no facturado"
                    End If
                Case 3
                    If Fg3.Row > 0 Then
                        Var2 = Fg3(Fg3.Row, 1)

                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"
                    End If
            End Select

            HayError = False

            FrmAsigViajeBuenoAE.ShowDialog()

        Catch ex As Exception
            HayError = True
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If HayError Then
            FrmAsigViajeBuenoAE.Show()
        End If

    End Sub
    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            If Fg2.Row > 0 Then
                If Fg2.Col > 1 Then
                    Clipboard.Clear()
                    Clipboard.SetText(Fg2(Fg2.Row, Fg2.Col))

                    Fg_DoubleClick(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg3_DoubleClick(sender As Object, e As EventArgs) Handles Fg3.DoubleClick
        Try
            If Fg3.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg3(Fg3.Row, Fg3.Col))
            End If
        Catch ex As Exception
        End Try

        Fg_DoubleClick(Nothing, Nothing)
    End Sub
    Private Sub Fg4_DoubleClick(sender As Object, e As EventArgs) Handles Fg4.DoubleClick
        Try
            If Fg4.Row > 0 Then
                If Fg2.Col > 1 Then
                    Clipboard.Clear()
                    Clipboard.SetText(Fg2(Fg2.Row, Fg2.Col))

                    Fg_DoubleClick(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg2_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg2.BeforeEdit
        Try
            If e.Row > 0 Then
                If Fg2.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg4_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg4.BeforeEdit
        Try
            If e.Row > 0 Then
                If Fg4.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarActualizar.Click

        TAB1_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub TAB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged
        Try
            Select Case TAB1.SelectedIndex
                Case 0
                    Try 'VIAJES NO FACTURADOS
                        BarReactivarFactura.Enabled = False
                        BarTimbrar.Enabled = False
                        BarCancFactura.Enabled = False
                        BarOpciones.Enabled = False

                        CADENA = "WHERE A.STATUS = 'A' AND ISNULL(A.FACTURADO,'') <> 'S' AND ISNULL(A.TIMBRADO,'') <> 'S'"
                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
                        DESPLEGAR()
                    Catch ex As Exception
                        Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 1 'VIAJES FACTURADOS
                    Try
                        BarReactivarFactura.Enabled = True
                        BarCancFactura.Enabled = True
                        BarOpciones.Enabled = False
                        BarTimbrar.Enabled = True
                        BarOImprimir.Text = "Imprimir factura"
                        BarImprimir.Image = My.Resources.impresora27

                        CADENA = "WHERE A.STATUS = 'A' AND ISNULL(F.STATUS,'') = 'E' AND ISNULL(TIPO_FACTURACION,0) <> 2 AND ISNULL(F.TIMBRADO,'') = ''"

                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)
                        DESPLEGAR()
                    Catch ex As Exception
                        Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 2 ' ESCENARIO 2  FACTURAS CON MAS DE UN VIAJE
                    Try
                        BarReactivarFactura.Enabled = True
                        BarCancFactura.Enabled = True
                        BarOpciones.Enabled = False
                        BarTimbrar.Enabled = True
                        BarOImprimir.Text = "Imprimir factura"
                        BarImprimir.Image = My.Resources.impresora27

                        CADENA = "WHERE A.STATUS = 'A' AND ISNULL(F.STATUS,'') <> 'C' AND  ISNULL(F.TIMBRADO,'') = '' AND ISNULL(TIPO_FACTURACION,0) = 2"
                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)

                        DESPLEGAR()

                    Catch ex As Exception
                        Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 3 'VIAJES TIMBRADOS
                    Try
                        BarReactivarFactura.Enabled = False
                        BarCancFactura.Enabled = False
                        BarTimbrar.Enabled = False
                        BarOpciones.Enabled = True
                        BarOImprimir.Text = "Imprimir CFDI"
                        BarImprimir.Image = My.Resources.impresora29

                        CADENA = "WHERE ISNULL(CFD.ESTATUS,'') <> 'C'"
                        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg3, C1FlexGridSearchPanel1)

                        DESPLEGAR()

                    Catch ex As Exception
                        Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 4
                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(FgR, C1FlexGridSearchPanel1)
                    DESPLEGAR()
            End Select
        Catch ex As Exception
            Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("CS2")
        cs2.BackColor = Color.Red
        cs2.ForeColor = Color.White
        cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs3 As CellStyle
        cs3 = Fg.Styles.Add("CS3")
        cs3.BackColor = Color.Blue
        cs3.ForeColor = Color.White

        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarFFacXViaje_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarFFacXViaje.Click
        Try
            Var2 = "VIAJE"
            Var10 = ""
            Var24 = ""
            Var17 = "C"
            Var19 = "NO MOSTRAR TODOS"
            ESCENARIO = 1

            FrmSelViaje.ShowDialog()
            If Var24.Trim.Length > 0 Then

                Var1 = "Edit"
                Var2 = Var24
                Var17 = "C"

                Var20 = TAB1.SelectedIndex + 1
                Var10 = "SEFACTURA"
                Var11 = "Viaje a facturar"

                Using options = New FrmAsigViajeBuenoAE()
                    If DialogResult.OK = options.ShowDialog() Then
                        TAB1.SelectedIndex = 1
                    End If
                End Using
                Var10 = ""
                Var11 = ""
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarFacViajesSel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarFacViajesSel.Click
        Try
            Var2 = ""
            Var4 = "" 'CLIENTE
            Var10 = ""
            ESCENARIO = 2
            Var19 = "NO MOSTRAR TODOS"

            Dim f As New FrmSelCliente With {.MdiParent = MainRibbonForm.Owner, .TopLevel = True}
            f.ShowDialog(MainRibbonForm)

            MainRibbonForm.Tab1.BringToFront()

            If Var4.Trim.Length > 0 Then
                Var1 = "Edit"
                Var2 = ""
                Var17 = "C" ' SE COLOCA EN EL TAB O MUESTRA EN UN SHOWDIALOG EN ESTE CASO EN UN SHOWDIALOG
                Var20 = TAB1.SelectedIndex + 1
                Var10 = "SEFACTURA_MULT"
                Var11 = "Viajes a facturar"

                Using options = New FrmAsigViajeBuenoAE()
                    If DialogResult.OK = options.ShowDialog() Then
                        TAB1.SelectedIndex = 1
                    End If
                End Using

                Var10 = ""
                Var11 = ""
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarFacViajeParcial_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarFacViajeParcial.Click
        Try
            Var2 = "VIAJE PARCIAL"
            Var10 = ""
            Var24 = ""
            Var25 = "ABONO"
            ESCENARIO = 3
            Var19 = "NO MOSTRAR TODOS"

            Dim f As New FrmSelViaje With {.MdiParent = MainRibbonForm.Owner, .TopLevel = True}
            f.ShowDialog(MainRibbonForm)

            MainRibbonForm.Tab1.BringToFront()

            If Var24.Trim.Length > 0 Then

                Var1 = "Edit"
                Var2 = Var24  'viaje
                Var17 = "C"
                Var20 = TAB1.SelectedIndex + 1

                Var10 = "SEFACTURA 3"
                Var11 = "Viaje a facturar"

                Closo_Form_Open(FrmAsigViajeBuenoAE)

                Using options = New FrmAsigViajeBuenoAE()
                    If DialogResult.OK = options.ShowDialog() Then
                        TAB1.SelectedIndex = 2
                    End If
                End Using
                Var10 = ""
                Var11 = ""
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarConsultar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarConsultar.Click
        Dim HayError As Boolean

        Try
            Var1 = "Edit"

            ESCENARIO = 0

            Select Case TAB1.SelectedIndex
                Case 0
                    If Fg.Row > 0 Then
                        Var2 = Fg(Fg.Row, 1)

                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"

                    End If
                Case 1
                    If Fg2.Row > 0 Then
                        Var2 = Fg2(Fg2.Row, 2)

                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"
                    End If
                Case 2
                    If Fg4.Row > 0 Then
                        Var2 = Fg4(Fg4.Row, 14)

                        Var17 = "C"
                        Var10 = "VIAJE BUENO"
                        Var11 = "Viaje no facturado"
                    End If
                Case 3
                    If Fg3.Row > 0 Then
                        Var2 = Fg3(Fg3.Row, 1)

                        Var17 = "C"
                        Var10 = "VVM"
                        Var11 = "Viaje no facturado"
                    End If
            End Select

            HayError = False

            FrmAsigViajeBuenoAE.ShowDialog()

        Catch ex As Exception
            HayError = True
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If HayError Then
            FrmAsigViajeBuenoAE.Show()
        End If

    End Sub

    Private Sub BarEstatusCFDI_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEstatusCFDI.Click
        If Fg.Row = 0 Then
            MsgBox("Por favor seleccione un documento")
            Return
        End If
        Dim EMISOR_RAZON_SOCIAL As String = "", EMISOR_RFC As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr("EMISOR_RFC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("10. " & vbNewLine & ex.StackTrace)
        End Try

        PassData1 = "FACTURA"

        Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
        Var3 = EMISOR_RAZON_SOCIAL
        Var4 = EMISOR_RFC
        Var5 = Fg(Fg.Row, 7) 'RFC RECEPTOR
        Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

        FrmEstatusCFDI.ShowDialog()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click
        Try
            PassData1 = "CARTA PORTE BUENO"

            Select Case TAB1.SelectedIndex
                Case 0
                Case 1 'FACTURACION
                    If Fg2.Row > 0 Then
                        IMPRIMIR_CFDI_40(Fg2(Fg2.Row, 15), "CARTA PORTE BUENO", Fg2(Fg2.Row, 2))
                    Else
                        MsgBox("Por favor seleccione el documento a timbrar")
                    End If
                Case 2 'MULTIVIAJES FACTURADOS

                    If Fg4.Row > 0 Then
                        IMPRIMIR_CFDI_40(Fg4(Fg4.Row, 14), "CARTA PORTE BUENO", Fg4(Fg4.Row, 2))
                    Else
                        MsgBox("Por favor seleccione el documento a timbrar")
                    End If
                Case 3 'TIMBRADAS
                    If Fg3.Row > 0 Then
                        IMPRIMIR_CFDI_40(Fg3(Fg3.Row, 13), "CARTA PORTE BUENO", Fg3(Fg3.Row, 1))
                    Else
                        MsgBox("Por favor seleccione el documento a timbrar")
                    End If
            End Select
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try
    End Sub

    Private Sub BarSendMail_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSendMail.Click
        Dim FILE_XML As String = "", PDF As String = ""
        Dim Err As Boolean = False
        Dim CORREO_CLIENTE As String = "", RAZON_SOCIAL As String = "", NOMBRE_CLIENTE As String = ""

        Try
            Var2 = Fg(Fg.Row, 2) 'CVE_DOC
            Var4 = ""
            Var5 = ""
            Var6 = Fg(Fg.Row, 3) 'NOMBRE_CLIENTE
            Var7 = Fg(Fg.Row, 7) 'RFC
            Var8 = ""
            Var9 = Fg(Fg.Row, 27) 'CORREO_CLIENTE
            Var10 = ""

            FrmCorreo.ShowDialog()

            If Var4 = "NO" Then
                Return
            End If
        Catch ex As Exception
            Err = True
            Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        Try
            Dim aCorreo As New ArrayList From {PDF, FILE_XML}
            Dim horaActual As String, SALUDO As String, MensaDia As String = ""

            Try
                horaActual = DateTime.Now.ToString("HH:mm")

                If horaActual >= "24:00" And horaActual <= "12:00" Then
                    SALUDO = "Buenos Días"
                ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                    SALUDO = "Buenas Tardes"
                ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                    SALUDO = "Buenas Noches"
                End If
                MensaDia = horaActual
            Catch ex As Exception
                Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CORREO_CLIENTE.Trim.Length > 0 Or Var7.Trim.Length > 0 Or Var8.Trim.Length > 0 Or Var9.Trim.Length > 0 Or Var10.Trim.Length > 0 Then
                SendEmail(CORREO_CLIENTE, "CFDI Carta porte",
                        MensaDia & vbCrLf & vbCrLf &
                        "CFDI Carta porte " & CTA_PORT1 & vbCrLf &
                        "Adjunto se envía representación CFDI Carta porte en formato PDF" & vbCrLf & vbCrLf &
                         RAZON_SOCIAL,
                        aCorreo, Var7, Var8, Var9, Var10)

                MsgBox("Correo enviado")
            Else
                MsgBox("El cliente " & NOMBRE_CLIENTE & " no tiene correo capturado")
            End If
        Catch ex As Exception
            Bitacora("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImpresionMasiva_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImpresionMasiva.Click
        Try
            FrmFiltroReimpMasiva.ShowDialog()

        Catch ex As Exception
            Bitacora("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDescargarXMLyPDF_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarDescargarXMLyPDF.Click
        Try
            If Fg3.Rows.Selected.Count > 0 Then
                Try
                    Dim r_ As Row

                    FrmDescargarXmlPDF.C1List1.ClearItems()



                    For k = 0 To Fg3.Rows.Selected.Count - 1
                        r_ = Fg3.Rows.Selected(k)

                        FrmDescargarXmlPDF.C1List1.AddItem(Fg3(r_.Index, 13) & ";" & Fg3(r_.Index, 1) & ";" & Fg3(r_.Index, 3))
                    Next

                    Var4 = "CARTA PORTE BUENO"

                    FrmDescargarXmlPDF.ShowDialog()

                Catch ex As Exception
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                MsgBox("Por favor seleccione al menos un documento")
            End If

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click
        Try
            Select Case TAB1.SelectedIndex
                Case 0
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "ASIGNACION VIAJES")
                Case 1
                    EXPORTAR_EXCEL_TRANSPORT(Fg2, "ASIGNACION VIAJES FACTURADOS")
                Case 2
                    EXPORTAR_EXCEL_TRANSPORT(Fg4, "ASIGNACION VIAJES FACTURADOS ESCENARIO MULTIVIAJES")
                Case 3
                    EXPORTAR_EXCEL_TRANSPORT(Fg3, "ASIGNACION VIAJES TIMBRADOS")
            End Select

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarProcStatusCFDI_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarProcStatusCFDI.Click
        Dim EMISOR_RAZON_SOCIAL As String = "", EMISOR_RFC As String = ""

        If Fg3.Row = 0 Then
            MsgBox("Por favor seleccione un documento")
            Return
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr("EMISOR_RFC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
        End Try

        PassData1 = "FACTURA"

        Var2 = Fg3(Fg3.Row, 13) 'DOCUMENTO
        Var3 = EMISOR_RAZON_SOCIAL
        Var4 = EMISOR_RFC
        Var5 = Fg3(Fg3.Row, 22) 'RFC RECEPTOR
        Var6 = Fg3(Fg3.Row, 4) 'NOMBRE RECEPTOR

        FrmEstatusCFDI.ShowDialog()
    End Sub

    Private Sub BarProcCancCFDI_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarProcCancCFDI.Click
        Try
            Var24 = ""
            FrmSelFactura.ShowDialog()

            If Var24.Trim.Length > 0 Then

                Var2 = Var24 ' Fg2(Fg2.Row, 13) 'FACTURA
                Var3 = "N"  'CATA PORTE 1
                Var4 = "N"  'CATA PORTE 2
                Var6 = "FBUENO"  'FACTURA BUENO
                Var10 = "4.0" 'VERSION
                PassData9 = "TIMBRADA"
                Var5 = ""

                FrmCFDICancFAC.ShowDialog()
                If Var5 = "ok" Then
                    'TIPO DE FACTURACION
                    If Fg3(Fg3.Row, 12) = "3" Then
                        SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_DOC = '" & Fg3(Fg3.Row, 13) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        SQL = "UPDATE GCASIGNACION_VIAJE_ABONOS SET STATUS = 'C' WHERE CVE_DOC = '" & Fg3(Fg3.Row, 13) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                    Else
                        If Fg3(Fg3.Row, 12) = "2" Then
                            SQL = "UPDATE GCASIGNACION_BUENO SET TIMBRADO = 'N' WHERE CVE_DOC = '" & Fg3(Fg3.Row, 13) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                        Else
                            SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'N' WHERE CVE_DOC = '" & Fg3(Fg3.Row, 13) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                        End If

                        SQL = "DELETE FROM CUEN_M" & Empresa & " WHERE REFER = '" & Fg3(Fg3.Row, 13) & "'"
                        EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & Fg3(Fg3.Row, 13) & "'"
                        EXECUTE_QUERY_NET(SQL)

                        TAB1.SelectedIndex = 1
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarReactivarFactura_Click(sender As Object, e As ClickEventArgs) Handles BarReactivarFactura.Click

        Try
            Select Case TAB1.SelectedIndex
                Case 1 'FACTURADA
                    If MsgBox("Realmente desea reactivar la factura " & Fg2(Fg2.Row, 14) & "?", vbYesNo) = vbYes Then

                        Var4 = ""
                        Var5 = "Motivo de la reactivación"

                        'FrmMotivoBaja.ShowDialog()
                        'If Var4.Trim.Length > 0 Then

                        If Fg2(Fg2.Row, 14) = "3" Then 'ESCENARIO 3

                            'ESCENARIO 3
                            Dim SSUBT As Decimal = 0
                            '                                                                    FACTURA
                            SQL = "DELETE FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand '                                                      VIAJE
                                SQL = "SELECT SUBTOTAL, IVA, RET,  NETO FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        SSUBT += dr2.ReadNullAsEmptyDecimal("SUBTOTAL")
                                    End While
                                End Using
                            End Using
                            If SSUBT > 0 Then

                            Else '                                                                                                                  VIAJE
                                SQL = "UPDATE GCASIGNACION_VIAJE SET SERIE = '', FOLIO = 0, CVE_DOC = '', FACTURADO = 'N' WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                Debug.Print("")
                            End If
                        Else '                                                                                                                 FACTURA
                            SQL = "UPDATE GCASIGNACION_VIAJE SET SERIE = '', FOLIO = 0, CVE_DOC = '', FACTURADO = 'N' WHERE CVE_DOC  = '" & Fg2(Fg2.Row, 15) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")
                        End If
                        '                                                                                         FACTURA
                        SQL = "DELETE FROM GCASIGNACION_BUENO WHERE SERIE + CAST(FOLIO AS VARCHAR(10)) = '" & Fg2(Fg2.Row, 15) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        '                                                                    FACTURA
                        SQL = "DELETE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        Debug.Print("")
                        '                                                                    FACTURA
                        SQL = "DELETE FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"

                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                        '            clave cliente          Observaciones         factura                Motivo
                        GRABA_BITA(Fg2(Fg2.Row, 3), "Reactivación factura " & Fg2(Fg2.Row, 15), 0, "F", Var4)

                        TAB1.SelectedIndex = 0
                    End If
                    'End If

                Case 2 'FACTURAS CON MAS DE UN VIAJE
                    If MsgBox("Realmente desea reactivar el viaje " & Fg4(Fg4.Row, 14) & "?", vbYesNo) = vbYes Then

                        SQL = "UPDATE GCASIGNACION_VIAJE SET SERIE = '', FOLIO = 0, CVE_DOC = '', FACTURADO = 'N' WHERE CVE_VIAJE = '" & Fg4(Fg4.Row, 2) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM GCASIGNACION_BUENO WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        TAB1.SelectedIndex = 0
                    End If
            End Select


        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarProcCancFactura_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarCancFactura.Click
        Try
            Var24 = ""
            Var19 = "CANCELAR FACTURA"
            Var2 = "CANCELAR FACTURA"
            FrmSelViaje.ShowDialog()

            'Var24 = TCVE_VIAJE.Text
            'Var44 = TNUM_VIAJES_COPIAR.Value
            'Var47 = TCVE_DOC.Text
            If Var24.Trim.Length > 0 Then
                If MsgBox("Realmente desea cancelar factura " & Var24 & "?", vbYesNo) = vbYes Then
                    If Valida_Conexion() Then

                        Var4 = ""
                        Var5 = "Motivo de cancelación"

                        FrmMotivoBaja.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'ESCENARIO 3
                            Dim SSUBT As Decimal = 0
                            '                                                                FACTURA
                            SQL = "DELETE FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_DOC = '" & Var47 & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand '                                                  VIAJE
                                SQL = "SELECT SUBTOTAL, IVA, RET,  NETO FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = '" & Var24 & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        SSUBT += dr2.ReadNullAsEmptyDecimal("SUBTOTAL")
                                    End While
                                End Using
                            End Using
                            If SSUBT > 0 Then

                            Else '                                                                                                              FACTURA
                                SQL = "UPDATE GCASIGNACION_VIAJE SET SERIE = '', FOLIO = 0, CVE_DOC = '', FACTURADO = 'N', 
                                USUARIO = '" & USER_GRUPOCE & "' 
                                WHERE CVE_VIAJE = '" & Var24 & "'"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                Debug.Print("")
                            End If

                            SQL = "DELETE FROM GCASIGNACION_BUENO WHERE CVE_DOC = '" & Var47 & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")

                            '                                                          FACTURA
                            SQL = "DELETE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & 47 & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")
                            '                                                               FACTURA
                            SQL = "DELETE FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & Var47 & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            Debug.Print("")
                            TAB1.SelectedIndex = 0

                            GRABA_BITA("", "Cancelación factura " & Var47, 0, "F", Var4)

                            MsgBox("El viaje de cancelo correctamente")
                            TAB1.SelectedIndex = 0
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarFiltrarCliente_Click(sender As Object, e As ClickEventArgs) Handles BarFiltrarCliente.Click
        Try
            Var4 = ""
            Var10 = ""
            FrmSelCliente.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Var1 = "Edit"
                Var2 = Var24
                Var17 = ""

                CADENA = "WHERE A.STATUS = 'A' AND ISNULL(A.FACTURADO,'') <> 'S' AND ISNULL(A.TIMBRADO,'') <> 'S' AND A.CLIENTE = '" & Var4 & "'"
                DESPLEGAR()
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTimbrar_Click(sender As Object, e As ClickEventArgs) Handles BarTimbrar.Click
        Try
            Dim Sigue As Boolean = False, DOCUMENT As String

            If TAB1.SelectedIndex = 2 Then
                If Fg4.Row > 0 Then
                    Sigue = True
                    DOCUMENT = Fg4(Fg4.Row, 13)
                End If
            Else
                If Fg2.Row > 0 Then
                    Sigue = True
                    DOCUMENT = Fg2(Fg2.Row, 14)
                End If
            End If
            If Sigue = True Then

                If MsgBox("Realmente desea timbrar el documento " & DOCUMENT & "?", vbYesNo) = vbYes Then

                    PassData1 = "CARTA PORTE BUENO"

                    If TAB1.SelectedIndex = 2 Then

                        Var4 = Fg4(Fg4.Row, 2) 'CVE_DOC
                        PassData8 = Fg4(Fg4.Row, 2) 'CVE_VIAJE
                        PassData4 = Fg4(Fg4.Row, 15) 'CVE_DOC FACTURA DEL VIAJE
                        PassData3 = 2 'TIPO DE FACTURACION ESCENARIO

                        Var5 = ""  'CORREO
                        Var18 = ""
                        Var16 = ""

                        ' INICA PROCESO DE TIMBRAR 
                        'c.RFC, c.USO_CFDI, c.REG_FISC, c.CODIGO

                        FrmTimbrarCdeP.LtNombre.Text = Fg4(Fg4.Row, 4)
                        FrmTimbrarCdeP.LtRFC.Text = Fg4(Fg4.Row, 22)
                        Try
                            If Not IsDBNull(Fg4(Fg4.Row, 22)) Then
                                FrmTimbrarCdeP.LtUSO_CFDI.Text = Fg4(Fg4.Row, 22)
                            End If

                            FrmTimbrarCdeP.LtRegimenReceptor.Text = Fg4(Fg4.Row, 24)
                            FrmTimbrarCdeP.LtCP.Text = Fg4(Fg4.Row, 25)
                        Catch ex As Exception
                            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        Var4 = Fg2(Fg2.Row, 2) 'viaje
                        PassData8 = Fg2(Fg2.Row, 2) 'CVE_VIAJE
                        PassData4 = Fg2(Fg2.Row, 15) 'CVE_DOC FACTURA DEL VIAJE
                        PassData3 = Fg2(Fg2.Row, 14) 'TIPO DE FACTURACION ESCENARIO

                        Var5 = ""  'CORREO
                        Var18 = ""
                        Var16 = ""

                        '21         22          23         24        25
                        'c.RFC, c.USO_CFDI, c.REG_FISC, c.CODIGO, aa.STATUS

                        FrmTimbrarCdeP.LtNombre.Text = Fg2(Fg2.Row, 4)
                        FrmTimbrarCdeP.LtRFC.Text = Fg2(Fg2.Row, 22)
                        Try
                            If Not IsDBNull(Fg2(Fg2.Row, 23)) Then
                                FrmTimbrarCdeP.LtUSO_CFDI.Text = Fg2(Fg2.Row, 23)
                            End If

                            FrmTimbrarCdeP.LtRegimenReceptor.Text = Fg2(Fg2.Row, 24)
                            FrmTimbrarCdeP.LtCP.Text = Fg2(Fg2.Row, 25)
                        Catch ex As Exception
                            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    Var2 = ""

                    FrmTimbrarCdeP.ShowDialog()
                    If Var18 = "SI" Then

                        Try
                            Select Case TAB1.SelectedIndex
                                Case 0
                                    'VIAJES NO FACTURADOS
                                Case 1
                                    'VIAJES FACTURADOS
                                    'Fg2
                                    If ESCENARIO = 3 Then
                                        SQL = "SELECT ISNULL((A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)),0) AS SALDO
                                            FROM GCASIGNACION_VIAJE A 
                                            WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "' AND A.STATUS <> 'C' AND ISNULL(FACTURADO,'') = 'S' AND A.TIPO_FACTURACION = 3"
                                        Try
                                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                                cmd.CommandText = SQL
                                                Using dr As SqlDataReader = cmd.ExecuteReader
                                                    If dr.Read Then
                                                        If dr("SALDO") > 1 Then
                                                            'NO SALDADO
                                                            SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                            SQL = "UPDATE GCASIGNACION_VIAJE_ABONOS SET STATUS = 'A' WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                            SQL = "UPDATE FACTF" & Empresa & " SET TIMBRADO = 'S' WHERE CVE_DOC = '" & PassData4 & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                                        Else
                                                            SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                            SQL = "UPDATE GCASIGNACION_VIAJE_ABONOS SET STATUS = 'Q' WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                            SQL = "UPDATE FACTF" & Empresa & " SET TIMBRADO = 'S' WHERE CVE_DOC = '" & PassData4 & "'"
                                                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                        End If
                                                    Else
                                                        SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                                        SQL = "UPDATE FACTF" & Empresa & " SET TIMBRADO = 'S' WHERE CVE_DOC = '" & PassData4 & "'"
                                                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                                    End If
                                                End Using
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                        End Try
                                    Else
                                        SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_VIAJE = '" & Fg2(Fg2.Row, 2) & "'"
                                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                    End If
                                Case 2
                                    'FACTURAS CON MAS DE UN VIAJE
                                    'Fg4
                                    Try
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                                            cmd.CommandText = SQL
                                            Using dr As SqlDataReader = cmd.ExecuteReader
                                                While dr.Read
                                                    SQL = "UPDATE GCASIGNACION_VIAJE SET TIMBRADO = 'S' WHERE CVE_VIAJE = '" & dr("CVE_VIAJE") & "'"
                                                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                                End While
                                            End Using
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Case 3
                                    'VIAJES TIMBRADOS
                                    'Fg3
                            End Select

                            SQL = "UPDATE FACTF" & Empresa & " SET TIMBRADO = 'S' WHERE CVE_DOC = '" & PassData4 & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    If Fg2(Fg2.Row, 13) = "2" Then
                                        SQL = "SELECT CVE_CLPV, IMPORTE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg4(Fg4.Row, 14) & "'"
                                    Else
                                        SQL = "SELECT CVE_CLPV, IMPORTE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg2(Fg2.Row, 15) & "'"
                                    End If
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read Then
                                            CUEN_M(Fg2(Fg2.Row, 15), dr("CVE_CLPV"), dr("IMPORTE"), "", 0)
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try


                            If Ruta_Framework = "SI" Then
                                FILE_PDF = Var16
                                FrmOPenPDFGrapecity.Show()
                            End If

                        Catch ex As Exception
                            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        TAB1_SelectedIndexChanged(Nothing, Nothing)
                    End If
                End If
            Else
                MsgBox("Por favor seleccione el documento a timbrar")
            End If

        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_M(FCVE_DOC As String, FCLAVE As String, FIMPORTE As Decimal, FCVE_VEND As String, FCVE_BITA As Long)

        Dim CVE_CLIE As String, REFER As String, NUM_CPTO As Integer, CVE_OBS As Long, NO_FACTURA As String, DOCTO As String, IMPORTE As Decimal
        Dim AFEC_COI As String, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, ENTREGADA As String
        Dim cmd As New SqlCommand
        Dim cmdT As New SqlCommand

        Try
            CVE_CLIE = FCLAVE
            REFER = FCVE_DOC
            NO_FACTURA = REFER
            DOCTO = REFER
            IMPORTE = FIMPORTE
            IMPMON_EXT = FIMPORTE

            SIGNO = 1
            NUM_CPTO = 1
            CVE_OBS = 0 : AFEC_COI = "S" : STRCVEVEND = FCVE_VEND : NUM_MONED = 1 : TCAMBIO = 1
            CVE_FOLIO = "" : TIPO_MOV = "C" : ENTREGADA = "S"

            SQL = "IF NOT EXISTS(SELECT REFER FROM CUEN_M" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND 
                NUM_CPTO = " & NUM_CPTO & " AND NUM_CARGO = 1) 
                INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, 
                FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, CVE_BITA, SIGNO, USUARIO, ENTREGADA, 
                FECHA_ENTREGA, STATUS, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & NUM_CPTO & "','1','" &
                CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(FIMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112)," &
                "CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" & TCAMBIO & "','" &
                Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & FCVE_BITA & "','" & SIGNO & "','" &
                CLAVE_SAE & "','" & ENTREGADA & "',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"
            Try
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            Catch ex As Exception
                BITACORATPV("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_DET(FCVE_DOC As String, FDOCTO As String, FCLAVE As String, FIMPORTE As Decimal, FNUM_CPTO_PAGO As Integer, FCVE_VEND As String)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim DOCTO As String, IMPORTE As Decimal, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, NO_PARTIDA As Integer, AFEC_COI As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim cmdT As New SqlCommand

        CVE_CLIE = FCLAVE
        REFER = FCVE_DOC
        NO_FACTURA = REFER

        If FNUM_CPTO_PAGO = 0 Then
            NUM_CPTO = 10
        Else
            NUM_CPTO = FNUM_CPTO_PAGO
        End If

        CVE_OBS = 0 : DOCTO = FDOCTO : NUM_MONED = 1 : TCAMBIO = 1 : AFEC_COI = "S" : ID_MOV = 1
        CVE_FOLIO = "" : TIPO_MOV = "A" : NO_PARTIDA = 1 : NUM_CARGO = 1 : SIGNO = -1

        IMPORTE = FIMPORTE
        STRCVEVEND = FCVE_VEND
        IMPMON_EXT = IMPORTE

        cmd.Connection = cnSAE
        SQL = "SELECT COALESCE(MAX(NO_PARTIDA),0) + 1 AS NO_PAR FROM CUEN_DET" & Empresa & " 
            WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "'"
        Try
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                NO_PARTIDA = dr("NO_PAR")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("2030. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2030. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "IF NOT EXISTS (SELECT REFER FROM CUEN_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND
            ID_MOV = " & ID_MOV & " AND NUM_CPTO = " & NUM_CPTO & " AND NO_PARTIDA = " & NO_PARTIDA & ")
            INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE,
            FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, SIGNO,
            CVE_AUT, USUARIO, NO_PARTIDA, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & ID_MOV & "','" & NUM_CPTO & "','" &
            NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(FIMPORTE, 6) &
            "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" &
            TCAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'0','" & CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','0','" &
            CLAVE_SAE & "','" & NO_PARTIDA & "',NEWID(), GETDATE())"
        Try
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg2_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg2.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg2.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg2.Styles.Add("CS2")
        cs2.BackColor = Color.Red
        cs2.ForeColor = Color.White
        cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs3 As CellStyle
        cs3 = Fg2.Styles.Add("CS3")
        cs3.BackColor = Color.Blue
        cs3.ForeColor = Color.White

        Dim rs As C1.Win.C1FlexGrid.CellStyle
        rs = Fg2.Styles.Add("RowColor")
        rs.BackColor = Color.PowderBlue

        Try
            If e.Row >= Fg2.Rows.Fixed And e.Col = Fg2.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg2.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg3_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg3.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg3.Styles.Add("CS2")
        cs2.BackColor = Color.Red
        cs2.ForeColor = Color.White
        cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs3 As CellStyle
        cs3 = Fg3.Styles.Add("CS3")
        cs3.BackColor = Color.Blue
        cs3.ForeColor = Color.White

        Try
            If e.Row >= Fg3.Rows.Fixed And e.Col = Fg3.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg3.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BarImprimir5_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir5.Click
        Dim Rreporte_MRT As String

        Try
            If FgR.Row > 0 Then
                Rreporte_MRT = GET_RUTA_FORMATOS() & "\" & "ReportRelCobranza.mrt"
                If Not IO.File.Exists(Rreporte_MRT) Then
                    MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(Rreporte_MRT)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                        Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1("CVE_REL") = FgR(FgR.Row, 1)
                StiReport1.Render()
                StiReport1.Show()
            Else
                MsgBox("Seleccione una clave de la relación de cobranza")
            End If

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevoCob_Click(sender As Object, e As ClickEventArgs) Handles BarNuevoCob.Click

        Var2 = "Nuevo"
        Var3 = ""
        Dim f As New FrmRelacionACobranza With {.MdiParent = Me.Owner, .TopLevel = True}
        f.ShowDialog()

        TAB1_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Private Sub BarEditCob_Click(sender As Object, e As ClickEventArgs) Handles BarEditCob.Click
        Try
            If Fg.Row > 0 Then
                Var2 = "Edit"
                Var3 = FgR(FgR.Row, 1)
                Dim f As New FrmRelacionACobranza With {.MdiParent = Me.Owner, .TopLevel = True}
                f.ShowDialog()

                TAB1_SelectedIndexChanged(Nothing, Nothing)
            Else
                MsgBox("Por favor seleccione una relación de cobranza")
            End If
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEliminar5_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar5.Click
        Try
            If FgR.Row > 0 Then
                If MsgBox("Realmente desea eliminar la relación de cobranza?", vbYesNo) = vbYes Then

                    If Not IsNothing(FgR(FgR.Row, 1)) AndAlso Not IsDBNull(FgR(FgR.Row, 1)) Then

                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_DOC FROM GCREL_FACTURAS_PAR WHERE CVE_REL = '" & FgR(FgR.Row, 1) & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read

                                        SQL = "UPDATE CFDI SET CVE_REL = '' WHERE FACTURA = '" & dr("CVE_DOC") & "'"
                                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                        SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_REL = '' WHERE CVE_DOC = '" & dr("CVE_DOC") & "'"
                                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                        SQL = "UPDATE GCREL_FACTURAS SET STATUS = 'C' WHERE CVE_REL = '" & FgR(FgR.Row, 1) & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using

                        MsgBox("La relación de cobranza se elimino correctamente")

                        TAB1_SelectedIndexChanged(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        'agrega a la tabla, crea el reporte y abre Diseñador  (SI NO EXISTEN)
        PrinterMRT("ReportRelCobranza")
    End Sub

End Class
