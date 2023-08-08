<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParamVentas
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParamVentas))
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.ChUTILIZAR_LECTOR_HUELLA = New C1.Win.C1Input.C1CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FgC = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ChACTIVAR_GAD = New C1.Win.C1Input.C1CheckBox()
        Me.ChACTIVAR_POLITICAS = New C1.Win.C1Input.C1CheckBox()
        Me.ChHABILITAR_DESC = New C1.Win.C1Input.C1CheckBox()
        Me.ChPER_VEND_ABA_MIN = New C1.Win.C1Input.C1CheckBox()
        Me.ChNOVALIDAR_LIM_CRED = New C1.Win.C1Input.C1CheckBox()
        Me.ChVENDER_SIN_EXIST = New C1.Win.C1Input.C1CheckBox()
        Me.ChPER_VEND_ABA_COST = New C1.Win.C1Input.C1CheckBox()
        Me.ChART_CON_IMP_INCLU = New C1.Win.C1Input.C1CheckBox()
        Me.ChBLOQEAR_LISTA_PREC = New C1.Win.C1Input.C1CheckBox()
        Me.ChOCULTAR_CRE_ENG = New C1.Win.C1Input.C1CheckBox()
        Me.ChOCULTAR_CREDITO = New C1.Win.C1Input.C1CheckBox()
        Me.Pag8 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnArtFG = New System.Windows.Forms.Button()
        Me.CboPeriodicidad = New C1.Win.C1Input.C1ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CboSerieFacGlobal = New C1.Win.C1Input.C1ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CboListaPrecPred = New C1.Win.C1Input.C1ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.ChALTA_CTE_POS = New C1.Win.C1Input.C1CheckBox()
        Me.ChALTA_PROD_POS = New C1.Win.C1Input.C1CheckBox()
        Me.TCVE_ART_FG = New SGT_Transport.TextBoxEx()
        Me.TCLIE_MOSTR = New SGT_Transport.TextBoxEx()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LSerieDoc = New System.Windows.Forms.Label()
        Me.BtnSeriesPorDoc = New C1.Win.C1Input.C1Button()
        Me.Tab2 = New C1.Win.C1Command.C1DockingTab()
        Me.PagFacturas = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagNV = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagRem = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagPed = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagCot = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagDev = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagNC = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagComPago = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagCPT = New C1.Win.C1Command.C1DockingTabPage()
        Me.ChObser_x_doc = New C1.Win.C1Input.C1CheckBox()
        Me.CboSeriesPorDoc = New C1.Win.C1Input.C1ComboBox()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtDocus = New System.Windows.Forms.Label()
        Me.BarraMenuFolios = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarNotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRemisiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDevoluciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPagoComplemento = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCartaPorteTras = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.ChALMACEN = New C1.Win.C1Input.C1CheckBox()
        Me.ChOBSER_X_PARTIDA = New C1.Win.C1Input.C1CheckBox()
        Me.ChIMPUESTOS = New C1.Win.C1Input.C1CheckBox()
        Me.ChINDIRECTOS_X_PARTIDA = New C1.Win.C1Input.C1CheckBox()
        Me.Pag5 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Pag6 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.Pag7 = New C1.Win.C1Command.C1DockingTabPage()
        Me.CboSerieFactura = New C1.Win.C1Input.C1ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BtnUnidadSAT = New C1.Win.C1Input.C1Button()
        Me.TCVE_UNIDAD = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TCVE_PRODSERV = New System.Windows.Forms.TextBox()
        Me.BtnClaveSAT = New C1.Win.C1Input.C1Button()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.TLIN_FAC_CFDI = New System.Windows.Forms.TextBox()
        Me.CboSeriePedidos = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CboSerieRemisionExt = New C1.Win.C1Input.C1ComboBox()
        Me.CboSerieCartaPorte = New C1.Win.C1Input.C1ComboBox()
        Me.TLIN_VENTAS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboSerieRemision = New C1.Win.C1Input.C1ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboSerieCAPFactura = New C1.Win.C1Input.C1ComboBox()
        Me.CboSerieProgPedidos = New C1.Win.C1Input.C1ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnProducto = New System.Windows.Forms.Button()
        Me.BtnLinea = New C1.Win.C1Input.C1Button()
        Me.BtnLineaEnVentas = New C1.Win.C1Input.C1Button()
        Me.TCVE_ART = New SGT_Transport.TextBoxEx()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BarraMenu = New System.Windows.Forms.ToolStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripButton()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.ChUTILIZAR_LECTOR_HUELLA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChACTIVAR_GAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChACTIVAR_POLITICAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChHABILITAR_DESC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPER_VEND_ABA_MIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChNOVALIDAR_LIM_CRED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChVENDER_SIN_EXIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPER_VEND_ABA_COST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChART_CON_IMP_INCLU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChBLOQEAR_LISTA_PREC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChOCULTAR_CRE_ENG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChOCULTAR_CREDITO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag8.SuspendLayout()
        CType(Me.CboPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieFacGlobal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboListaPrecPred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChALTA_CTE_POS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChALTA_PROD_POS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.BtnSeriesPorDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        CType(Me.ChObser_x_doc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSeriesPorDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag3.SuspendLayout()
        Me.BarraMenuFolios.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag4.SuspendLayout()
        CType(Me.ChALMACEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChOBSER_X_PARTIDA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChIMPUESTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChINDIRECTOS_X_PARTIDA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag6.SuspendLayout()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag7.SuspendLayout()
        CType(Me.CboSerieFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUnidadSAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClaveSAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSeriePedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieRemisionExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieCartaPorte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieCAPFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieProgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLineaEnVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.BarraMenu.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag8)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Controls.Add(Me.Pag4)
        Me.Tab1.Controls.Add(Me.Pag5)
        Me.Tab1.Controls.Add(Me.Pag6)
        Me.Tab1.Controls.Add(Me.Pag7)
        Me.Tab1.Location = New System.Drawing.Point(3, 3)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(766, 406)
        Me.Tab1.TabIndex = 1
        Me.Tab1.TabsSpacing = 5
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.ChUTILIZAR_LECTOR_HUELLA)
        Me.Pag1.Controls.Add(Me.Label10)
        Me.Pag1.Controls.Add(Me.FgC)
        Me.Pag1.Controls.Add(Me.ChACTIVAR_GAD)
        Me.Pag1.Controls.Add(Me.ChACTIVAR_POLITICAS)
        Me.Pag1.Controls.Add(Me.ChHABILITAR_DESC)
        Me.Pag1.Controls.Add(Me.ChPER_VEND_ABA_MIN)
        Me.Pag1.Controls.Add(Me.ChNOVALIDAR_LIM_CRED)
        Me.Pag1.Controls.Add(Me.ChVENDER_SIN_EXIST)
        Me.Pag1.Controls.Add(Me.ChPER_VEND_ABA_COST)
        Me.Pag1.Controls.Add(Me.ChART_CON_IMP_INCLU)
        Me.Pag1.Controls.Add(Me.ChBLOQEAR_LISTA_PREC)
        Me.Pag1.Controls.Add(Me.ChOCULTAR_CRE_ENG)
        Me.Pag1.Controls.Add(Me.ChOCULTAR_CREDITO)
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(764, 381)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Generales"
        '
        'ChUTILIZAR_LECTOR_HUELLA
        '
        Me.ChUTILIZAR_LECTOR_HUELLA.BackColor = System.Drawing.Color.Transparent
        Me.ChUTILIZAR_LECTOR_HUELLA.BorderColor = System.Drawing.Color.Transparent
        Me.ChUTILIZAR_LECTOR_HUELLA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChUTILIZAR_LECTOR_HUELLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChUTILIZAR_LECTOR_HUELLA.ForeColor = System.Drawing.Color.Black
        Me.ChUTILIZAR_LECTOR_HUELLA.Location = New System.Drawing.Point(23, 317)
        Me.ChUTILIZAR_LECTOR_HUELLA.Name = "ChUTILIZAR_LECTOR_HUELLA"
        Me.ChUTILIZAR_LECTOR_HUELLA.Padding = New System.Windows.Forms.Padding(1)
        Me.ChUTILIZAR_LECTOR_HUELLA.Size = New System.Drawing.Size(295, 22)
        Me.ChUTILIZAR_LECTOR_HUELLA.TabIndex = 371
        Me.ChUTILIZAR_LECTOR_HUELLA.Text = "Utilizar lector de huella digital"
        Me.ChUTILIZAR_LECTOR_HUELLA.UseVisualStyleBackColor = False
        Me.ChUTILIZAR_LECTOR_HUELLA.Value = Nothing
        Me.ChUTILIZAR_LECTOR_HUELLA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(514, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 370
        Me.Label10.Text = "Conceptos"
        '
        'FgC
        '
        Me.FgC.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgC.AllowFiltering = True
        Me.FgC.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.FgC.AutoClipboard = True
        Me.FgC.AutoResize = True
        Me.FgC.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.FgC.AutoSearchDelay = 9.0R
        Me.FgC.BackColor = System.Drawing.Color.White
        Me.FgC.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgC.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders
        Me.FgC.ColumnInfo = resources.GetString("FgC.ColumnInfo")
        Me.FgC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgC.ForeColor = System.Drawing.Color.Black
        Me.FgC.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgC.Location = New System.Drawing.Point(386, 30)
        Me.FgC.Name = "FgC"
        Me.FgC.Rows.Count = 1
        Me.FgC.Rows.DefaultSize = 19
        Me.FgC.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgC.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgC.Size = New System.Drawing.Size(364, 271)
        Me.FgC.StyleInfo = resources.GetString("FgC.StyleInfo")
        Me.FgC.TabIndex = 332
        '
        'ChACTIVAR_GAD
        '
        Me.ChACTIVAR_GAD.BackColor = System.Drawing.Color.Transparent
        Me.ChACTIVAR_GAD.BorderColor = System.Drawing.Color.Transparent
        Me.ChACTIVAR_GAD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChACTIVAR_GAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChACTIVAR_GAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChACTIVAR_GAD.ForeColor = System.Drawing.Color.Black
        Me.ChACTIVAR_GAD.Location = New System.Drawing.Point(23, 209)
        Me.ChACTIVAR_GAD.Name = "ChACTIVAR_GAD"
        Me.ChACTIVAR_GAD.Padding = New System.Windows.Forms.Padding(1)
        Me.ChACTIVAR_GAD.Size = New System.Drawing.Size(246, 22)
        Me.ChACTIVAR_GAD.TabIndex = 331
        Me.ChACTIVAR_GAD.Text = "Activar GAD"
        Me.ChACTIVAR_GAD.UseVisualStyleBackColor = True
        Me.ChACTIVAR_GAD.Value = Nothing
        Me.ChACTIVAR_GAD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChACTIVAR_POLITICAS
        '
        Me.ChACTIVAR_POLITICAS.BackColor = System.Drawing.Color.Transparent
        Me.ChACTIVAR_POLITICAS.BorderColor = System.Drawing.Color.Transparent
        Me.ChACTIVAR_POLITICAS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChACTIVAR_POLITICAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChACTIVAR_POLITICAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChACTIVAR_POLITICAS.ForeColor = System.Drawing.Color.Black
        Me.ChACTIVAR_POLITICAS.Location = New System.Drawing.Point(23, 182)
        Me.ChACTIVAR_POLITICAS.Name = "ChACTIVAR_POLITICAS"
        Me.ChACTIVAR_POLITICAS.Padding = New System.Windows.Forms.Padding(1)
        Me.ChACTIVAR_POLITICAS.Size = New System.Drawing.Size(246, 22)
        Me.ChACTIVAR_POLITICAS.TabIndex = 330
        Me.ChACTIVAR_POLITICAS.Text = "Activar políticas"
        Me.ChACTIVAR_POLITICAS.UseVisualStyleBackColor = True
        Me.ChACTIVAR_POLITICAS.Value = Nothing
        Me.ChACTIVAR_POLITICAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChHABILITAR_DESC
        '
        Me.ChHABILITAR_DESC.BackColor = System.Drawing.Color.Transparent
        Me.ChHABILITAR_DESC.BorderColor = System.Drawing.Color.Transparent
        Me.ChHABILITAR_DESC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChHABILITAR_DESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChHABILITAR_DESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChHABILITAR_DESC.ForeColor = System.Drawing.Color.Black
        Me.ChHABILITAR_DESC.Location = New System.Drawing.Point(23, 101)
        Me.ChHABILITAR_DESC.Name = "ChHABILITAR_DESC"
        Me.ChHABILITAR_DESC.Padding = New System.Windows.Forms.Padding(1)
        Me.ChHABILITAR_DESC.Size = New System.Drawing.Size(246, 22)
        Me.ChHABILITAR_DESC.TabIndex = 329
        Me.ChHABILITAR_DESC.Text = "Habilitar descuento"
        Me.ChHABILITAR_DESC.UseVisualStyleBackColor = True
        Me.ChHABILITAR_DESC.Value = Nothing
        Me.ChHABILITAR_DESC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChPER_VEND_ABA_MIN
        '
        Me.ChPER_VEND_ABA_MIN.BackColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_MIN.BorderColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_MIN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPER_VEND_ABA_MIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChPER_VEND_ABA_MIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPER_VEND_ABA_MIN.ForeColor = System.Drawing.Color.Black
        Me.ChPER_VEND_ABA_MIN.Location = New System.Drawing.Point(23, 155)
        Me.ChPER_VEND_ABA_MIN.Name = "ChPER_VEND_ABA_MIN"
        Me.ChPER_VEND_ABA_MIN.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPER_VEND_ABA_MIN.Size = New System.Drawing.Size(246, 22)
        Me.ChPER_VEND_ABA_MIN.TabIndex = 328
        Me.ChPER_VEND_ABA_MIN.Text = "Permiri vender abajo del mínimo"
        Me.ChPER_VEND_ABA_MIN.UseVisualStyleBackColor = True
        Me.ChPER_VEND_ABA_MIN.Value = Nothing
        Me.ChPER_VEND_ABA_MIN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChNOVALIDAR_LIM_CRED
        '
        Me.ChNOVALIDAR_LIM_CRED.BackColor = System.Drawing.Color.Transparent
        Me.ChNOVALIDAR_LIM_CRED.BorderColor = System.Drawing.Color.Transparent
        Me.ChNOVALIDAR_LIM_CRED.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChNOVALIDAR_LIM_CRED.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChNOVALIDAR_LIM_CRED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChNOVALIDAR_LIM_CRED.ForeColor = System.Drawing.Color.Black
        Me.ChNOVALIDAR_LIM_CRED.Location = New System.Drawing.Point(23, 74)
        Me.ChNOVALIDAR_LIM_CRED.Name = "ChNOVALIDAR_LIM_CRED"
        Me.ChNOVALIDAR_LIM_CRED.Padding = New System.Windows.Forms.Padding(1)
        Me.ChNOVALIDAR_LIM_CRED.Size = New System.Drawing.Size(246, 22)
        Me.ChNOVALIDAR_LIM_CRED.TabIndex = 327
        Me.ChNOVALIDAR_LIM_CRED.Text = "No validar límite de crédito"
        Me.ChNOVALIDAR_LIM_CRED.UseVisualStyleBackColor = True
        Me.ChNOVALIDAR_LIM_CRED.Value = Nothing
        Me.ChNOVALIDAR_LIM_CRED.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChVENDER_SIN_EXIST
        '
        Me.ChVENDER_SIN_EXIST.BackColor = System.Drawing.Color.Transparent
        Me.ChVENDER_SIN_EXIST.BorderColor = System.Drawing.Color.Transparent
        Me.ChVENDER_SIN_EXIST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChVENDER_SIN_EXIST.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChVENDER_SIN_EXIST.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChVENDER_SIN_EXIST.ForeColor = System.Drawing.Color.Black
        Me.ChVENDER_SIN_EXIST.Location = New System.Drawing.Point(23, 263)
        Me.ChVENDER_SIN_EXIST.Name = "ChVENDER_SIN_EXIST"
        Me.ChVENDER_SIN_EXIST.Padding = New System.Windows.Forms.Padding(1)
        Me.ChVENDER_SIN_EXIST.Size = New System.Drawing.Size(295, 22)
        Me.ChVENDER_SIN_EXIST.TabIndex = 326
        Me.ChVENDER_SIN_EXIST.Text = "Vender sin existencias"
        Me.ChVENDER_SIN_EXIST.UseVisualStyleBackColor = True
        Me.ChVENDER_SIN_EXIST.Value = Nothing
        Me.ChVENDER_SIN_EXIST.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChPER_VEND_ABA_COST
        '
        Me.ChPER_VEND_ABA_COST.BackColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_COST.BorderColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_COST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPER_VEND_ABA_COST.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChPER_VEND_ABA_COST.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPER_VEND_ABA_COST.ForeColor = System.Drawing.Color.Black
        Me.ChPER_VEND_ABA_COST.Location = New System.Drawing.Point(23, 128)
        Me.ChPER_VEND_ABA_COST.Name = "ChPER_VEND_ABA_COST"
        Me.ChPER_VEND_ABA_COST.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPER_VEND_ABA_COST.Size = New System.Drawing.Size(295, 22)
        Me.ChPER_VEND_ABA_COST.TabIndex = 325
        Me.ChPER_VEND_ABA_COST.Text = "Permirir vender abajo del costo"
        Me.ChPER_VEND_ABA_COST.UseVisualStyleBackColor = True
        Me.ChPER_VEND_ABA_COST.Value = Nothing
        Me.ChPER_VEND_ABA_COST.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChART_CON_IMP_INCLU
        '
        Me.ChART_CON_IMP_INCLU.BackColor = System.Drawing.Color.Transparent
        Me.ChART_CON_IMP_INCLU.BorderColor = System.Drawing.Color.Transparent
        Me.ChART_CON_IMP_INCLU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChART_CON_IMP_INCLU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChART_CON_IMP_INCLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChART_CON_IMP_INCLU.ForeColor = System.Drawing.Color.Black
        Me.ChART_CON_IMP_INCLU.Location = New System.Drawing.Point(23, 236)
        Me.ChART_CON_IMP_INCLU.Name = "ChART_CON_IMP_INCLU"
        Me.ChART_CON_IMP_INCLU.Padding = New System.Windows.Forms.Padding(1)
        Me.ChART_CON_IMP_INCLU.Size = New System.Drawing.Size(295, 22)
        Me.ChART_CON_IMP_INCLU.TabIndex = 323
        Me.ChART_CON_IMP_INCLU.Text = "Artículos con impuesto incluido"
        Me.ChART_CON_IMP_INCLU.UseVisualStyleBackColor = True
        Me.ChART_CON_IMP_INCLU.Value = Nothing
        Me.ChART_CON_IMP_INCLU.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChBLOQEAR_LISTA_PREC
        '
        Me.ChBLOQEAR_LISTA_PREC.BackColor = System.Drawing.Color.Transparent
        Me.ChBLOQEAR_LISTA_PREC.BorderColor = System.Drawing.Color.Transparent
        Me.ChBLOQEAR_LISTA_PREC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChBLOQEAR_LISTA_PREC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChBLOQEAR_LISTA_PREC.ForeColor = System.Drawing.Color.Black
        Me.ChBLOQEAR_LISTA_PREC.Location = New System.Drawing.Point(23, 290)
        Me.ChBLOQEAR_LISTA_PREC.Name = "ChBLOQEAR_LISTA_PREC"
        Me.ChBLOQEAR_LISTA_PREC.Padding = New System.Windows.Forms.Padding(1)
        Me.ChBLOQEAR_LISTA_PREC.Size = New System.Drawing.Size(216, 22)
        Me.ChBLOQEAR_LISTA_PREC.TabIndex = 2
        Me.ChBLOQEAR_LISTA_PREC.Text = "Bloquear seleccionar lista de precios"
        Me.ChBLOQEAR_LISTA_PREC.UseVisualStyleBackColor = False
        Me.ChBLOQEAR_LISTA_PREC.Value = Nothing
        Me.ChBLOQEAR_LISTA_PREC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChOCULTAR_CRE_ENG
        '
        Me.ChOCULTAR_CRE_ENG.BackColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CRE_ENG.BorderColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CRE_ENG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChOCULTAR_CRE_ENG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChOCULTAR_CRE_ENG.ForeColor = System.Drawing.Color.Black
        Me.ChOCULTAR_CRE_ENG.Location = New System.Drawing.Point(23, 20)
        Me.ChOCULTAR_CRE_ENG.Name = "ChOCULTAR_CRE_ENG"
        Me.ChOCULTAR_CRE_ENG.Padding = New System.Windows.Forms.Padding(1)
        Me.ChOCULTAR_CRE_ENG.Size = New System.Drawing.Size(246, 22)
        Me.ChOCULTAR_CRE_ENG.TabIndex = 0
        Me.ChOCULTAR_CRE_ENG.Text = "Ocultar crédito con enganche"
        Me.ChOCULTAR_CRE_ENG.UseVisualStyleBackColor = False
        Me.ChOCULTAR_CRE_ENG.Value = Nothing
        Me.ChOCULTAR_CRE_ENG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChOCULTAR_CREDITO
        '
        Me.ChOCULTAR_CREDITO.BackColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CREDITO.BorderColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CREDITO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChOCULTAR_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChOCULTAR_CREDITO.ForeColor = System.Drawing.Color.Black
        Me.ChOCULTAR_CREDITO.Location = New System.Drawing.Point(23, 47)
        Me.ChOCULTAR_CREDITO.Name = "ChOCULTAR_CREDITO"
        Me.ChOCULTAR_CREDITO.Padding = New System.Windows.Forms.Padding(1)
        Me.ChOCULTAR_CREDITO.Size = New System.Drawing.Size(184, 22)
        Me.ChOCULTAR_CREDITO.TabIndex = 1
        Me.ChOCULTAR_CREDITO.Text = "Ocultar crédito"
        Me.ChOCULTAR_CREDITO.UseVisualStyleBackColor = False
        Me.ChOCULTAR_CREDITO.Value = Nothing
        Me.ChOCULTAR_CREDITO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Pag8
        '
        Me.Pag8.Controls.Add(Me.Label14)
        Me.Pag8.Controls.Add(Me.BtnArtFG)
        Me.Pag8.Controls.Add(Me.CboPeriodicidad)
        Me.Pag8.Controls.Add(Me.Label21)
        Me.Pag8.Controls.Add(Me.CboSerieFacGlobal)
        Me.Pag8.Controls.Add(Me.Label13)
        Me.Pag8.Controls.Add(Me.CboListaPrecPred)
        Me.Pag8.Controls.Add(Me.Label12)
        Me.Pag8.Controls.Add(Me.Label11)
        Me.Pag8.Controls.Add(Me.BtnCliente)
        Me.Pag8.Controls.Add(Me.ChALTA_CTE_POS)
        Me.Pag8.Controls.Add(Me.ChALTA_PROD_POS)
        Me.Pag8.Controls.Add(Me.TCVE_ART_FG)
        Me.Pag8.Controls.Add(Me.TCLIE_MOSTR)
        Me.Pag8.Location = New System.Drawing.Point(1, 24)
        Me.Pag8.Name = "Pag8"
        Me.Pag8.Size = New System.Drawing.Size(764, 381)
        Me.Pag8.TabIndex = 7
        Me.Pag8.Text = "Punto de venta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(324, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(172, 16)
        Me.Label14.TabIndex = 606
        Me.Label14.Text = "Clave articulo factura global"
        '
        'BtnArtFG
        '
        Me.BtnArtFG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnArtFG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArtFG.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnArtFG.Location = New System.Drawing.Point(584, 86)
        Me.BtnArtFG.Name = "BtnArtFG"
        Me.BtnArtFG.Size = New System.Drawing.Size(23, 24)
        Me.BtnArtFG.TabIndex = 607
        Me.BtnArtFG.UseVisualStyleBackColor = True
        '
        'CboPeriodicidad
        '
        Me.CboPeriodicidad.AllowSpinLoop = False
        Me.CboPeriodicidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboPeriodicidad.BorderColor = System.Drawing.Color.DodgerBlue
        Me.CboPeriodicidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboPeriodicidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboPeriodicidad.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboPeriodicidad.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboPeriodicidad.DropDownWidth = 90
        Me.CboPeriodicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboPeriodicidad.GapHeight = 0
        Me.CboPeriodicidad.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboPeriodicidad.ItemsDisplayMember = ""
        Me.CboPeriodicidad.ItemsValueMember = ""
        Me.CboPeriodicidad.Location = New System.Drawing.Point(502, 55)
        Me.CboPeriodicidad.Name = "CboPeriodicidad"
        Me.CboPeriodicidad.Size = New System.Drawing.Size(120, 19)
        Me.CboPeriodicidad.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboPeriodicidad.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboPeriodicidad.TabIndex = 603
        Me.CboPeriodicidad.Tag = Nothing
        Me.CboPeriodicidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(420, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 15)
        Me.Label21.TabIndex = 604
        Me.Label21.Text = "Periodicidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'CboSerieFacGlobal
        '
        Me.CboSerieFacGlobal.AllowSpinLoop = False
        Me.CboSerieFacGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieFacGlobal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieFacGlobal.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieFacGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieFacGlobal.GapHeight = 0
        Me.CboSerieFacGlobal.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieFacGlobal.ItemsDisplayMember = ""
        Me.CboSerieFacGlobal.ItemsValueMember = ""
        Me.CboSerieFacGlobal.Location = New System.Drawing.Point(502, 22)
        Me.CboSerieFacGlobal.Name = "CboSerieFacGlobal"
        Me.CboSerieFacGlobal.Size = New System.Drawing.Size(79, 21)
        Me.CboSerieFacGlobal.TabIndex = 330
        Me.CboSerieFacGlobal.Tag = Nothing
        Me.CboSerieFacGlobal.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieFacGlobal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(343, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(153, 15)
        Me.Label13.TabIndex = 331
        Me.Label13.Text = "Serie factura global del dia"
        '
        'CboListaPrecPred
        '
        Me.CboListaPrecPred.AllowSpinLoop = False
        Me.CboListaPrecPred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboListaPrecPred.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboListaPrecPred.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboListaPrecPred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboListaPrecPred.GapHeight = 0
        Me.CboListaPrecPred.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboListaPrecPred.ItemsDisplayMember = ""
        Me.CboListaPrecPred.ItemsValueMember = ""
        Me.CboListaPrecPred.Location = New System.Drawing.Point(502, 166)
        Me.CboListaPrecPred.Name = "CboListaPrecPred"
        Me.CboListaPrecPred.Size = New System.Drawing.Size(250, 20)
        Me.CboListaPrecPred.TabIndex = 328
        Me.CboListaPrecPred.Tag = Nothing
        Me.CboListaPrecPred.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboListaPrecPred.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(295, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 16)
        Me.Label12.TabIndex = 329
        Me.Label12.Text = "Lista de precios predeterminada"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(384, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 326
        Me.Label11.Text = "Cliente mostrador"
        '
        'BtnCliente
        '
        Me.BtnCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCliente.Location = New System.Drawing.Point(585, 130)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(23, 24)
        Me.BtnCliente.TabIndex = 327
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'ChALTA_CTE_POS
        '
        Me.ChALTA_CTE_POS.BackColor = System.Drawing.Color.Transparent
        Me.ChALTA_CTE_POS.BorderColor = System.Drawing.Color.Transparent
        Me.ChALTA_CTE_POS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChALTA_CTE_POS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChALTA_CTE_POS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChALTA_CTE_POS.ForeColor = System.Drawing.Color.Black
        Me.ChALTA_CTE_POS.Location = New System.Drawing.Point(30, 42)
        Me.ChALTA_CTE_POS.Name = "ChALTA_CTE_POS"
        Me.ChALTA_CTE_POS.Padding = New System.Windows.Forms.Padding(1)
        Me.ChALTA_CTE_POS.Size = New System.Drawing.Size(195, 22)
        Me.ChALTA_CTE_POS.TabIndex = 324
        Me.ChALTA_CTE_POS.Text = "Alta de cliente"
        Me.ChALTA_CTE_POS.UseVisualStyleBackColor = True
        Me.ChALTA_CTE_POS.Value = Nothing
        Me.ChALTA_CTE_POS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChALTA_PROD_POS
        '
        Me.ChALTA_PROD_POS.BackColor = System.Drawing.Color.Transparent
        Me.ChALTA_PROD_POS.BorderColor = System.Drawing.Color.Transparent
        Me.ChALTA_PROD_POS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChALTA_PROD_POS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChALTA_PROD_POS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChALTA_PROD_POS.ForeColor = System.Drawing.Color.Black
        Me.ChALTA_PROD_POS.Location = New System.Drawing.Point(30, 68)
        Me.ChALTA_PROD_POS.Name = "ChALTA_PROD_POS"
        Me.ChALTA_PROD_POS.Padding = New System.Windows.Forms.Padding(1)
        Me.ChALTA_PROD_POS.Size = New System.Drawing.Size(195, 22)
        Me.ChALTA_PROD_POS.TabIndex = 323
        Me.ChALTA_PROD_POS.Text = "Alta de productos"
        Me.ChALTA_PROD_POS.UseVisualStyleBackColor = True
        Me.ChALTA_PROD_POS.Value = Nothing
        Me.ChALTA_PROD_POS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_ART_FG
        '
        Me.TCVE_ART_FG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ART_FG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART_FG.Location = New System.Drawing.Point(502, 89)
        Me.TCVE_ART_FG.Name = "TCVE_ART_FG"
        Me.TCVE_ART_FG.Size = New System.Drawing.Size(79, 22)
        Me.TCVE_ART_FG.TabIndex = 605
        '
        'TCLIE_MOSTR
        '
        Me.TCLIE_MOSTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIE_MOSTR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIE_MOSTR.Location = New System.Drawing.Point(502, 132)
        Me.TCLIE_MOSTR.Name = "TCLIE_MOSTR"
        Me.TCLIE_MOSTR.Size = New System.Drawing.Size(79, 22)
        Me.TCLIE_MOSTR.TabIndex = 325
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.LSerieDoc)
        Me.Pag2.Controls.Add(Me.BtnSeriesPorDoc)
        Me.Pag2.Controls.Add(Me.Tab2)
        Me.Pag2.Controls.Add(Me.ChObser_x_doc)
        Me.Pag2.Controls.Add(Me.CboSeriesPorDoc)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(764, 381)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Por documento"
        '
        'LSerieDoc
        '
        Me.LSerieDoc.AutoSize = True
        Me.LSerieDoc.BackColor = System.Drawing.Color.Transparent
        Me.LSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSerieDoc.ForeColor = System.Drawing.Color.Black
        Me.LSerieDoc.Location = New System.Drawing.Point(214, 178)
        Me.LSerieDoc.Name = "LSerieDoc"
        Me.LSerieDoc.Size = New System.Drawing.Size(41, 17)
        Me.LSerieDoc.TabIndex = 332
        Me.LSerieDoc.Text = "Serie"
        '
        'BtnSeriesPorDoc
        '
        Me.BtnSeriesPorDoc.FlatAppearance.BorderSize = 0
        Me.BtnSeriesPorDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSeriesPorDoc.Image = Global.SGT_Transport.My.Resources.Resources.menu1
        Me.BtnSeriesPorDoc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSeriesPorDoc.Location = New System.Drawing.Point(367, 171)
        Me.BtnSeriesPorDoc.Name = "BtnSeriesPorDoc"
        Me.BtnSeriesPorDoc.Size = New System.Drawing.Size(27, 30)
        Me.BtnSeriesPorDoc.TabIndex = 331
        Me.BtnSeriesPorDoc.Text = "|"
        Me.BtnSeriesPorDoc.UseVisualStyleBackColor = True
        Me.BtnSeriesPorDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.PagFacturas)
        Me.Tab2.Controls.Add(Me.PagNV)
        Me.Tab2.Controls.Add(Me.PagRem)
        Me.Tab2.Controls.Add(Me.PagPed)
        Me.Tab2.Controls.Add(Me.PagCot)
        Me.Tab2.Controls.Add(Me.PagDev)
        Me.Tab2.Controls.Add(Me.PagNC)
        Me.Tab2.Controls.Add(Me.PagComPago)
        Me.Tab2.Controls.Add(Me.PagCPT)
        Me.Tab2.HotTrack = True
        Me.Tab2.Location = New System.Drawing.Point(6, 32)
        Me.Tab2.MultiLine = True
        Me.Tab2.Name = "Tab2"
        Me.Tab2.SelectedIndex = 1
        Me.Tab2.SelectedTabBold = True
        Me.Tab2.Size = New System.Drawing.Size(681, 88)
        Me.Tab2.SplitterWidth = 1
        Me.Tab2.TabAreaBorder = True
        Me.Tab2.TabAreaSpacing = 10
        Me.Tab2.TabIndex = 10
        Me.Tab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab2.TabsShowFocusCues = False
        Me.Tab2.TabsSpacing = 2
        Me.Tab2.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab2.TabTextAlignment = System.Drawing.StringAlignment.Center
        Me.Tab2.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'PagFacturas
        '
        Me.PagFacturas.Location = New System.Drawing.Point(1, 53)
        Me.PagFacturas.Name = "PagFacturas"
        Me.PagFacturas.Size = New System.Drawing.Size(679, 34)
        Me.PagFacturas.TabIndex = 0
        Me.PagFacturas.Text = "Facturas"
        '
        'PagNV
        '
        Me.PagNV.Location = New System.Drawing.Point(1, 53)
        Me.PagNV.Name = "PagNV"
        Me.PagNV.Size = New System.Drawing.Size(679, 34)
        Me.PagNV.TabIndex = 1
        Me.PagNV.Text = "Notas de venta"
        '
        'PagRem
        '
        Me.PagRem.Location = New System.Drawing.Point(1, 53)
        Me.PagRem.Name = "PagRem"
        Me.PagRem.Size = New System.Drawing.Size(679, 34)
        Me.PagRem.TabIndex = 2
        Me.PagRem.Text = "Remisión"
        '
        'PagPed
        '
        Me.PagPed.Location = New System.Drawing.Point(1, 53)
        Me.PagPed.Name = "PagPed"
        Me.PagPed.Size = New System.Drawing.Size(679, 34)
        Me.PagPed.TabIndex = 3
        Me.PagPed.Text = "Pedidos"
        '
        'PagCot
        '
        Me.PagCot.Location = New System.Drawing.Point(1, 53)
        Me.PagCot.Name = "PagCot"
        Me.PagCot.Size = New System.Drawing.Size(679, 34)
        Me.PagCot.TabIndex = 4
        Me.PagCot.Text = "Cotizaciones"
        '
        'PagDev
        '
        Me.PagDev.Location = New System.Drawing.Point(1, 53)
        Me.PagDev.Name = "PagDev"
        Me.PagDev.Size = New System.Drawing.Size(679, 34)
        Me.PagDev.TabIndex = 5
        Me.PagDev.Text = "Devoluciones"
        '
        'PagNC
        '
        Me.PagNC.Location = New System.Drawing.Point(1, 53)
        Me.PagNC.Name = "PagNC"
        Me.PagNC.Size = New System.Drawing.Size(679, 34)
        Me.PagNC.TabIndex = 6
        Me.PagNC.Text = "Notas de crédito"
        '
        'PagComPago
        '
        Me.PagComPago.Location = New System.Drawing.Point(1, 53)
        Me.PagComPago.Name = "PagComPago"
        Me.PagComPago.Size = New System.Drawing.Size(679, 34)
        Me.PagComPago.TabIndex = 7
        Me.PagComPago.Text = "Comprobantes de pago"
        '
        'PagCPT
        '
        Me.PagCPT.Location = New System.Drawing.Point(1, 53)
        Me.PagCPT.Name = "PagCPT"
        Me.PagCPT.Size = New System.Drawing.Size(679, 34)
        Me.PagCPT.TabIndex = 8
        Me.PagCPT.Text = "Carta porte traslado"
        '
        'ChObser_x_doc
        '
        Me.ChObser_x_doc.BackColor = System.Drawing.Color.Transparent
        Me.ChObser_x_doc.BorderColor = System.Drawing.Color.Transparent
        Me.ChObser_x_doc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChObser_x_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChObser_x_doc.ForeColor = System.Drawing.Color.Black
        Me.ChObser_x_doc.Location = New System.Drawing.Point(19, 344)
        Me.ChObser_x_doc.Name = "ChObser_x_doc"
        Me.ChObser_x_doc.Padding = New System.Windows.Forms.Padding(1)
        Me.ChObser_x_doc.Size = New System.Drawing.Size(256, 34)
        Me.ChObser_x_doc.TabIndex = 9
        Me.ChObser_x_doc.Text = "Observaciones y campos libres"
        Me.ChObser_x_doc.UseVisualStyleBackColor = False
        Me.ChObser_x_doc.Value = Nothing
        Me.ChObser_x_doc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CboSeriesPorDoc
        '
        Me.CboSeriesPorDoc.AllowSpinLoop = False
        Me.CboSeriesPorDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSeriesPorDoc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSeriesPorDoc.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSeriesPorDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSeriesPorDoc.GapHeight = 0
        Me.CboSeriesPorDoc.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSeriesPorDoc.ItemsDisplayMember = ""
        Me.CboSeriesPorDoc.ItemsValueMember = ""
        Me.CboSeriesPorDoc.Location = New System.Drawing.Point(261, 175)
        Me.CboSeriesPorDoc.Name = "CboSeriesPorDoc"
        Me.CboSeriesPorDoc.Size = New System.Drawing.Size(100, 21)
        Me.CboSeriesPorDoc.TabIndex = 314
        Me.CboSeriesPorDoc.Tag = Nothing
        Me.CboSeriesPorDoc.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSeriesPorDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Pag3
        '
        Me.Pag3.Controls.Add(Me.LtDocus)
        Me.Pag3.Controls.Add(Me.BarraMenuFolios)
        Me.Pag3.Controls.Add(Me.Fg)
        Me.Pag3.Location = New System.Drawing.Point(1, 24)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(764, 381)
        Me.Pag3.TabIndex = 2
        Me.Pag3.Text = "Folios"
        '
        'LtDocus
        '
        Me.LtDocus.AutoSize = True
        Me.LtDocus.BackColor = System.Drawing.Color.Transparent
        Me.LtDocus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocus.ForeColor = System.Drawing.Color.Black
        Me.LtDocus.Location = New System.Drawing.Point(215, 74)
        Me.LtDocus.Name = "LtDocus"
        Me.LtDocus.Size = New System.Drawing.Size(233, 17)
        Me.LtDocus.TabIndex = 317
        Me.LtDocus.Text = "_________________________"
        '
        'BarraMenuFolios
        '
        Me.BarraMenuFolios.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenuFolios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarFacturas, Me.BarNotas, Me.BarRemisiones, Me.BarPedidos, Me.BarCotizaciones, Me.BarDevoluciones, Me.BarPagoComplemento, Me.BarCartaPorteTras})
        Me.BarraMenuFolios.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenuFolios.Name = "BarraMenuFolios"
        Me.BarraMenuFolios.Size = New System.Drawing.Size(764, 52)
        Me.BarraMenuFolios.TabIndex = 17
        Me.BarraMenuFolios.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarNuevo.Size = New System.Drawing.Size(45, 48)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEdit.Size = New System.Drawing.Size(44, 48)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarFacturas
        '
        Me.BarFacturas.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarFacturas.ForeColor = System.Drawing.Color.Black
        Me.BarFacturas.Image = Global.SGT_Transport.My.Resources.Resources.recibo
        Me.BarFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarFacturas.Name = "BarFacturas"
        Me.BarFacturas.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarFacturas.Size = New System.Drawing.Size(54, 48)
        Me.BarFacturas.Text = "Facturas"
        Me.BarFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarNotas
        '
        Me.BarNotas.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarNotas.ForeColor = System.Drawing.Color.Black
        Me.BarNotas.Image = Global.SGT_Transport.My.Resources.Resources.lista_de_precios2
        Me.BarNotas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNotas.Name = "BarNotas"
        Me.BarNotas.ShortcutKeyDisplayString = ""
        Me.BarNotas.ShowShortcutKeys = False
        Me.BarNotas.Size = New System.Drawing.Size(44, 48)
        Me.BarNotas.Text = "Notas"
        Me.BarNotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRemisiones
        '
        Me.BarRemisiones.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarRemisiones.ForeColor = System.Drawing.Color.Black
        Me.BarRemisiones.Image = Global.SGT_Transport.My.Resources.Resources.reporte
        Me.BarRemisiones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRemisiones.Name = "BarRemisiones"
        Me.BarRemisiones.Size = New System.Drawing.Size(66, 48)
        Me.BarRemisiones.Text = "Remisiones"
        Me.BarRemisiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarPedidos
        '
        Me.BarPedidos.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarPedidos.ForeColor = System.Drawing.Color.Black
        Me.BarPedidos.Image = Global.SGT_Transport.My.Resources.Resources.lista_de_precios3
        Me.BarPedidos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPedidos.Name = "BarPedidos"
        Me.BarPedidos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarPedidos.Size = New System.Drawing.Size(50, 48)
        Me.BarPedidos.Text = "Pedidos"
        Me.BarPedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCotizaciones
        '
        Me.BarCotizaciones.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarCotizaciones.ForeColor = System.Drawing.Color.Black
        Me.BarCotizaciones.Image = Global.SGT_Transport.My.Resources.Resources.licencia
        Me.BarCotizaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCotizaciones.Name = "BarCotizaciones"
        Me.BarCotizaciones.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarCotizaciones.Size = New System.Drawing.Size(70, 48)
        Me.BarCotizaciones.Text = "Cotizaciones"
        Me.BarCotizaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDevoluciones
        '
        Me.BarDevoluciones.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarDevoluciones.ForeColor = System.Drawing.Color.Black
        Me.BarDevoluciones.Image = Global.SGT_Transport.My.Resources.Resources.regreso2
        Me.BarDevoluciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDevoluciones.Name = "BarDevoluciones"
        Me.BarDevoluciones.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDevoluciones.Size = New System.Drawing.Size(74, 48)
        Me.BarDevoluciones.Text = "Devoluciones"
        Me.BarDevoluciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarPagoComplemento
        '
        Me.BarPagoComplemento.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarPagoComplemento.ForeColor = System.Drawing.Color.Black
        Me.BarPagoComplemento.Image = Global.SGT_Transport.My.Resources.Resources.dinero23
        Me.BarPagoComplemento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPagoComplemento.Name = "BarPagoComplemento"
        Me.BarPagoComplemento.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarPagoComplemento.Size = New System.Drawing.Size(97, 48)
        Me.BarPagoComplemento.Text = "Pago complemento"
        Me.BarPagoComplemento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCartaPorteTras
        '
        Me.BarCartaPorteTras.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarCartaPorteTras.ForeColor = System.Drawing.Color.Black
        Me.BarCartaPorteTras.Image = Global.SGT_Transport.My.Resources.Resources.docporte19
        Me.BarCartaPorteTras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCartaPorteTras.Name = "BarCartaPorteTras"
        Me.BarCartaPorteTras.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarCartaPorteTras.Size = New System.Drawing.Size(100, 48)
        Me.BarCartaPorteTras.Text = "Carta porte traslado"
        Me.BarCartaPorteTras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(3, 106)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(650, 246)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 16
        '
        'Pag4
        '
        Me.Pag4.Controls.Add(Me.ChALMACEN)
        Me.Pag4.Controls.Add(Me.ChOBSER_X_PARTIDA)
        Me.Pag4.Controls.Add(Me.ChIMPUESTOS)
        Me.Pag4.Controls.Add(Me.ChINDIRECTOS_X_PARTIDA)
        Me.Pag4.Location = New System.Drawing.Point(1, 24)
        Me.Pag4.Name = "Pag4"
        Me.Pag4.Size = New System.Drawing.Size(764, 381)
        Me.Pag4.TabIndex = 3
        Me.Pag4.Text = "Por partida"
        '
        'ChALMACEN
        '
        Me.ChALMACEN.BackColor = System.Drawing.Color.Transparent
        Me.ChALMACEN.BorderColor = System.Drawing.Color.Transparent
        Me.ChALMACEN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChALMACEN.ForeColor = System.Drawing.Color.Black
        Me.ChALMACEN.Location = New System.Drawing.Point(28, 109)
        Me.ChALMACEN.Name = "ChALMACEN"
        Me.ChALMACEN.Padding = New System.Windows.Forms.Padding(1)
        Me.ChALMACEN.Size = New System.Drawing.Size(179, 20)
        Me.ChALMACEN.TabIndex = 9
        Me.ChALMACEN.Text = "Almacén"
        Me.ChALMACEN.UseVisualStyleBackColor = False
        Me.ChALMACEN.Value = Nothing
        Me.ChALMACEN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChOBSER_X_PARTIDA
        '
        Me.ChOBSER_X_PARTIDA.BackColor = System.Drawing.Color.Transparent
        Me.ChOBSER_X_PARTIDA.BorderColor = System.Drawing.Color.Transparent
        Me.ChOBSER_X_PARTIDA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChOBSER_X_PARTIDA.ForeColor = System.Drawing.Color.Black
        Me.ChOBSER_X_PARTIDA.Location = New System.Drawing.Point(28, 31)
        Me.ChOBSER_X_PARTIDA.Name = "ChOBSER_X_PARTIDA"
        Me.ChOBSER_X_PARTIDA.Padding = New System.Windows.Forms.Padding(1)
        Me.ChOBSER_X_PARTIDA.Size = New System.Drawing.Size(221, 20)
        Me.ChOBSER_X_PARTIDA.TabIndex = 8
        Me.ChOBSER_X_PARTIDA.Text = "Observaciones y campos libres"
        Me.ChOBSER_X_PARTIDA.UseVisualStyleBackColor = False
        Me.ChOBSER_X_PARTIDA.Value = Nothing
        Me.ChOBSER_X_PARTIDA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChIMPUESTOS
        '
        Me.ChIMPUESTOS.BackColor = System.Drawing.Color.Transparent
        Me.ChIMPUESTOS.BorderColor = System.Drawing.Color.Transparent
        Me.ChIMPUESTOS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChIMPUESTOS.ForeColor = System.Drawing.Color.Black
        Me.ChIMPUESTOS.Location = New System.Drawing.Point(28, 83)
        Me.ChIMPUESTOS.Name = "ChIMPUESTOS"
        Me.ChIMPUESTOS.Padding = New System.Windows.Forms.Padding(1)
        Me.ChIMPUESTOS.Size = New System.Drawing.Size(179, 20)
        Me.ChIMPUESTOS.TabIndex = 6
        Me.ChIMPUESTOS.Text = "Impuestos"
        Me.ChIMPUESTOS.UseVisualStyleBackColor = False
        Me.ChIMPUESTOS.Value = Nothing
        Me.ChIMPUESTOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChINDIRECTOS_X_PARTIDA
        '
        Me.ChINDIRECTOS_X_PARTIDA.BackColor = System.Drawing.Color.Transparent
        Me.ChINDIRECTOS_X_PARTIDA.BorderColor = System.Drawing.Color.Transparent
        Me.ChINDIRECTOS_X_PARTIDA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChINDIRECTOS_X_PARTIDA.ForeColor = System.Drawing.Color.Black
        Me.ChINDIRECTOS_X_PARTIDA.Location = New System.Drawing.Point(28, 57)
        Me.ChINDIRECTOS_X_PARTIDA.Name = "ChINDIRECTOS_X_PARTIDA"
        Me.ChINDIRECTOS_X_PARTIDA.Padding = New System.Windows.Forms.Padding(1)
        Me.ChINDIRECTOS_X_PARTIDA.Size = New System.Drawing.Size(179, 20)
        Me.ChINDIRECTOS_X_PARTIDA.TabIndex = 7
        Me.ChINDIRECTOS_X_PARTIDA.Text = "Indirectos por partida"
        Me.ChINDIRECTOS_X_PARTIDA.UseVisualStyleBackColor = False
        Me.ChINDIRECTOS_X_PARTIDA.Value = Nothing
        Me.ChINDIRECTOS_X_PARTIDA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Pag5
        '
        Me.Pag5.Location = New System.Drawing.Point(1, 24)
        Me.Pag5.Name = "Pag5"
        Me.Pag5.Size = New System.Drawing.Size(764, 381)
        Me.Pag5.TabIndex = 4
        Me.Pag5.Text = "Campos libres"
        '
        'Pag6
        '
        Me.Pag6.Controls.Add(Me.C1List1)
        Me.Pag6.Location = New System.Drawing.Point(1, 24)
        Me.Pag6.Name = "Pag6"
        Me.Pag6.Size = New System.Drawing.Size(764, 381)
        Me.Pag6.TabIndex = 5
        Me.Pag6.Text = "Lineas Factura CFDI"
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.SystemColors.Control
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione lineas"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.Control
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.Location = New System.Drawing.Point(96, 3)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Color = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(375, 279)
        Me.C1List1.TabIndex = 365
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'Pag7
        '
        Me.Pag7.Controls.Add(Me.CboSerieFactura)
        Me.Pag7.Controls.Add(Me.Label15)
        Me.Pag7.Controls.Add(Me.BtnUnidadSAT)
        Me.Pag7.Controls.Add(Me.TCVE_UNIDAD)
        Me.Pag7.Controls.Add(Me.Label66)
        Me.Pag7.Controls.Add(Me.TCVE_PRODSERV)
        Me.Pag7.Controls.Add(Me.BtnClaveSAT)
        Me.Pag7.Controls.Add(Me.Label67)
        Me.Pag7.Controls.Add(Me.TLIN_FAC_CFDI)
        Me.Pag7.Controls.Add(Me.CboSeriePedidos)
        Me.Pag7.Controls.Add(Me.Label3)
        Me.Pag7.Controls.Add(Me.Label9)
        Me.Pag7.Controls.Add(Me.CboSerieRemisionExt)
        Me.Pag7.Controls.Add(Me.CboSerieCartaPorte)
        Me.Pag7.Controls.Add(Me.TLIN_VENTAS)
        Me.Pag7.Controls.Add(Me.Label1)
        Me.Pag7.Controls.Add(Me.Label4)
        Me.Pag7.Controls.Add(Me.Label8)
        Me.Pag7.Controls.Add(Me.CboSerieRemision)
        Me.Pag7.Controls.Add(Me.Label5)
        Me.Pag7.Controls.Add(Me.Label7)
        Me.Pag7.Controls.Add(Me.Label2)
        Me.Pag7.Controls.Add(Me.CboSerieCAPFactura)
        Me.Pag7.Controls.Add(Me.CboSerieProgPedidos)
        Me.Pag7.Controls.Add(Me.Label6)
        Me.Pag7.Controls.Add(Me.BtnProducto)
        Me.Pag7.Controls.Add(Me.BtnLinea)
        Me.Pag7.Controls.Add(Me.BtnLineaEnVentas)
        Me.Pag7.Controls.Add(Me.TCVE_ART)
        Me.Pag7.Location = New System.Drawing.Point(1, 24)
        Me.Pag7.Name = "Pag7"
        Me.Pag7.Size = New System.Drawing.Size(764, 381)
        Me.Pag7.TabIndex = 6
        Me.Pag7.Text = "Transport"
        '
        'CboSerieFactura
        '
        Me.CboSerieFactura.AllowSpinLoop = False
        Me.CboSerieFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieFactura.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieFactura.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieFactura.GapHeight = 0
        Me.CboSerieFactura.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieFactura.ItemsDisplayMember = ""
        Me.CboSerieFactura.ItemsValueMember = ""
        Me.CboSerieFactura.Location = New System.Drawing.Point(510, 98)
        Me.CboSerieFactura.Name = "CboSerieFactura"
        Me.CboSerieFactura.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieFactura.TabIndex = 598
        Me.CboSerieFactura.Tag = Nothing
        Me.CboSerieFactura.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieFactura.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(428, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 15)
        Me.Label15.TabIndex = 599
        Me.Label15.Text = "Serie factura"
        '
        'BtnUnidadSAT
        '
        Me.BtnUnidadSAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnUnidadSAT.FlatAppearance.BorderSize = 0
        Me.BtnUnidadSAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUnidadSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidadSAT.Image = CType(resources.GetObject("BtnUnidadSAT.Image"), System.Drawing.Image)
        Me.BtnUnidadSAT.Location = New System.Drawing.Point(577, 66)
        Me.BtnUnidadSAT.Name = "BtnUnidadSAT"
        Me.BtnUnidadSAT.Size = New System.Drawing.Size(22, 22)
        Me.BtnUnidadSAT.TabIndex = 597
        Me.BtnUnidadSAT.UseVisualStyleBackColor = True
        Me.BtnUnidadSAT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNIDAD
        '
        Me.TCVE_UNIDAD.AcceptsReturn = True
        Me.TCVE_UNIDAD.AcceptsTab = True
        Me.TCVE_UNIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_UNIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNIDAD.Location = New System.Drawing.Point(511, 67)
        Me.TCVE_UNIDAD.MaxLength = 4
        Me.TCVE_UNIDAD.Name = "TCVE_UNIDAD"
        Me.TCVE_UNIDAD.Size = New System.Drawing.Size(65, 21)
        Me.TCVE_UNIDAD.TabIndex = 593
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(430, 70)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(78, 15)
        Me.Label66.TabIndex = 596
        Me.Label66.Text = "Clave unidad"
        '
        'TCVE_PRODSERV
        '
        Me.TCVE_PRODSERV.AcceptsReturn = True
        Me.TCVE_PRODSERV.AcceptsTab = True
        Me.TCVE_PRODSERV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_PRODSERV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PRODSERV.Location = New System.Drawing.Point(511, 36)
        Me.TCVE_PRODSERV.MaxLength = 9
        Me.TCVE_PRODSERV.Name = "TCVE_PRODSERV"
        Me.TCVE_PRODSERV.Size = New System.Drawing.Size(99, 21)
        Me.TCVE_PRODSERV.TabIndex = 592
        '
        'BtnClaveSAT
        '
        Me.BtnClaveSAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClaveSAT.FlatAppearance.BorderSize = 0
        Me.BtnClaveSAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClaveSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClaveSAT.Image = CType(resources.GetObject("BtnClaveSAT.Image"), System.Drawing.Image)
        Me.BtnClaveSAT.Location = New System.Drawing.Point(611, 35)
        Me.BtnClaveSAT.Name = "BtnClaveSAT"
        Me.BtnClaveSAT.Size = New System.Drawing.Size(22, 22)
        Me.BtnClaveSAT.TabIndex = 595
        Me.BtnClaveSAT.UseVisualStyleBackColor = True
        Me.BtnClaveSAT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(446, 38)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(62, 15)
        Me.Label67.TabIndex = 594
        Me.Label67.Text = "Clave SAT"
        '
        'TLIN_FAC_CFDI
        '
        Me.TLIN_FAC_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLIN_FAC_CFDI.ForeColor = System.Drawing.Color.Black
        Me.TLIN_FAC_CFDI.Location = New System.Drawing.Point(200, 195)
        Me.TLIN_FAC_CFDI.MaxLength = 5
        Me.TLIN_FAC_CFDI.Name = "TLIN_FAC_CFDI"
        Me.TLIN_FAC_CFDI.Size = New System.Drawing.Size(100, 22)
        Me.TLIN_FAC_CFDI.TabIndex = 5
        Me.TLIN_FAC_CFDI.Visible = False
        '
        'CboSeriePedidos
        '
        Me.CboSeriePedidos.AllowSpinLoop = False
        Me.CboSeriePedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSeriePedidos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSeriePedidos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSeriePedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSeriePedidos.GapHeight = 0
        Me.CboSeriePedidos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSeriePedidos.ItemsDisplayMember = ""
        Me.CboSeriePedidos.ItemsValueMember = ""
        Me.CboSeriePedidos.Location = New System.Drawing.Point(200, 34)
        Me.CboSeriePedidos.Name = "CboSeriePedidos"
        Me.CboSeriePedidos.Size = New System.Drawing.Size(100, 21)
        Me.CboSeriePedidos.TabIndex = 6
        Me.CboSeriePedidos.Tag = Nothing
        Me.CboSeriePedidos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSeriePedidos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(43, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 15)
        Me.Label3.TabIndex = 316
        Me.Label3.Text = "Serie remisión OT Externa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(15, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(181, 16)
        Me.Label9.TabIndex = 330
        Me.Label9.Text = "Linea a filtrar en Factura CFDI"
        Me.Label9.Visible = False
        '
        'CboSerieRemisionExt
        '
        Me.CboSerieRemisionExt.AllowSpinLoop = False
        Me.CboSerieRemisionExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieRemisionExt.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieRemisionExt.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieRemisionExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieRemisionExt.GapHeight = 0
        Me.CboSerieRemisionExt.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieRemisionExt.ItemsDisplayMember = ""
        Me.CboSerieRemisionExt.ItemsValueMember = ""
        Me.CboSerieRemisionExt.Location = New System.Drawing.Point(200, 224)
        Me.CboSerieRemisionExt.Name = "CboSerieRemisionExt"
        Me.CboSerieRemisionExt.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieRemisionExt.TabIndex = 9
        Me.CboSerieRemisionExt.Tag = Nothing
        Me.CboSerieRemisionExt.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieRemisionExt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboSerieCartaPorte
        '
        Me.CboSerieCartaPorte.AllowSpinLoop = False
        Me.CboSerieCartaPorte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieCartaPorte.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieCartaPorte.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieCartaPorte.GapHeight = 0
        Me.CboSerieCartaPorte.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieCartaPorte.ItemsDisplayMember = ""
        Me.CboSerieCartaPorte.ItemsValueMember = ""
        Me.CboSerieCartaPorte.Location = New System.Drawing.Point(200, 256)
        Me.CboSerieCartaPorte.Name = "CboSerieCartaPorte"
        Me.CboSerieCartaPorte.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieCartaPorte.TabIndex = 10
        Me.CboSerieCartaPorte.Tag = Nothing
        Me.CboSerieCartaPorte.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieCartaPorte.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TLIN_VENTAS
        '
        Me.TLIN_VENTAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLIN_VENTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLIN_VENTAS.ForeColor = System.Drawing.Color.Black
        Me.TLIN_VENTAS.Location = New System.Drawing.Point(200, 162)
        Me.TLIN_VENTAS.MaxLength = 5
        Me.TLIN_VENTAS.Name = "TLIN_VENTAS"
        Me.TLIN_VENTAS.Size = New System.Drawing.Size(100, 22)
        Me.TLIN_VENTAS.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(88, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Serie remisión OT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(46, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 15)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "Serie remision carta porte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(42, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 15)
        Me.Label8.TabIndex = 327
        Me.Label8.Text = "Linea en módulo de ventas"
        '
        'CboSerieRemision
        '
        Me.CboSerieRemision.AllowSpinLoop = False
        Me.CboSerieRemision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieRemision.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieRemision.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieRemision.GapHeight = 0
        Me.CboSerieRemision.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieRemision.ItemsDisplayMember = ""
        Me.CboSerieRemision.ItemsValueMember = ""
        Me.CboSerieRemision.Location = New System.Drawing.Point(200, 98)
        Me.CboSerieRemision.Name = "CboSerieRemision"
        Me.CboSerieRemision.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieRemision.TabIndex = 8
        Me.CboSerieRemision.Tag = Nothing
        Me.CboSerieRemision.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieRemision.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(86, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 319
        Me.Label5.Text = "Artículo carta porte"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(80, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 15)
        Me.Label7.TabIndex = 325
        Me.Label7.Text = "Serie prog. pedidos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(111, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Serie pedidos"
        '
        'CboSerieCAPFactura
        '
        Me.CboSerieCAPFactura.AllowSpinLoop = False
        Me.CboSerieCAPFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieCAPFactura.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieCAPFactura.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieCAPFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieCAPFactura.GapHeight = 0
        Me.CboSerieCAPFactura.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieCAPFactura.ItemsDisplayMember = ""
        Me.CboSerieCAPFactura.ItemsValueMember = ""
        Me.CboSerieCAPFactura.Location = New System.Drawing.Point(200, 130)
        Me.CboSerieCAPFactura.Name = "CboSerieCAPFactura"
        Me.CboSerieCAPFactura.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieCAPFactura.TabIndex = 3
        Me.CboSerieCAPFactura.Tag = Nothing
        Me.CboSerieCAPFactura.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieCAPFactura.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboSerieProgPedidos
        '
        Me.CboSerieProgPedidos.AllowSpinLoop = False
        Me.CboSerieProgPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieProgPedidos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieProgPedidos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieProgPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieProgPedidos.GapHeight = 0
        Me.CboSerieProgPedidos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieProgPedidos.ItemsDisplayMember = ""
        Me.CboSerieProgPedidos.ItemsValueMember = ""
        Me.CboSerieProgPedidos.Location = New System.Drawing.Point(200, 66)
        Me.CboSerieProgPedidos.Name = "CboSerieProgPedidos"
        Me.CboSerieProgPedidos.Size = New System.Drawing.Size(100, 21)
        Me.CboSerieProgPedidos.TabIndex = 7
        Me.CboSerieProgPedidos.Tag = Nothing
        Me.CboSerieProgPedidos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerieProgPedidos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(67, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 15)
        Me.Label6.TabIndex = 323
        Me.Label6.Text = "Serie remisión factura"
        '
        'BtnProducto
        '
        Me.BtnProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProducto.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnProducto.Location = New System.Drawing.Point(301, 286)
        Me.BtnProducto.Name = "BtnProducto"
        Me.BtnProducto.Size = New System.Drawing.Size(23, 24)
        Me.BtnProducto.TabIndex = 321
        Me.BtnProducto.UseVisualStyleBackColor = True
        '
        'BtnLinea
        '
        Me.BtnLinea.AutoSize = True
        Me.BtnLinea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLinea.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnLinea.Location = New System.Drawing.Point(304, 196)
        Me.BtnLinea.Name = "BtnLinea"
        Me.BtnLinea.Size = New System.Drawing.Size(22, 22)
        Me.BtnLinea.TabIndex = 331
        Me.BtnLinea.UseVisualStyleBackColor = True
        Me.BtnLinea.Visible = False
        Me.BtnLinea.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnLineaEnVentas
        '
        Me.BtnLineaEnVentas.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnLineaEnVentas.Location = New System.Drawing.Point(303, 161)
        Me.BtnLineaEnVentas.Name = "BtnLineaEnVentas"
        Me.BtnLineaEnVentas.Size = New System.Drawing.Size(23, 24)
        Me.BtnLineaEnVentas.TabIndex = 328
        Me.BtnLineaEnVentas.UseVisualStyleBackColor = True
        Me.BtnLineaEnVentas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TCVE_ART
        '
        Me.TCVE_ART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ART.Location = New System.Drawing.Point(200, 288)
        Me.TCVE_ART.Name = "TCVE_ART"
        Me.TCVE_ART.Size = New System.Drawing.Size(100, 20)
        Me.TCVE_ART.TabIndex = 11
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 12)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.Split1)
        Me.SplitM1.Panels.Add(Me.Split2)
        Me.SplitM1.Size = New System.Drawing.Size(806, 494)
        Me.SplitM1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.TabIndex = 4
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.BarraMenu)
        Me.Split1.Height = 54
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(804, 54)
        Me.Split1.SizeRatio = 11.066R
        Me.Split1.TabIndex = 0
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(804, 54)
        Me.BarraMenu.TabIndex = 3
        Me.BarraMenu.Text = "ToolStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Size = New System.Drawing.Size(46, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(36, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Tab1)
        Me.Split2.Height = 434
        Me.Split2.Location = New System.Drawing.Point(1, 59)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(804, 434)
        Me.Split2.TabIndex = 1
        '
        'FrmParamVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 555)
        Me.Controls.Add(Me.SplitM1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmParamVentas"
        Me.Text = "Ventas"
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.ChUTILIZAR_LECTOR_HUELLA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChACTIVAR_GAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChACTIVAR_POLITICAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChHABILITAR_DESC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPER_VEND_ABA_MIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChNOVALIDAR_LIM_CRED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChVENDER_SIN_EXIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPER_VEND_ABA_COST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChART_CON_IMP_INCLU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChBLOQEAR_LISTA_PREC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChOCULTAR_CRE_ENG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChOCULTAR_CREDITO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag8.ResumeLayout(False)
        Me.Pag8.PerformLayout()
        CType(Me.CboPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieFacGlobal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboListaPrecPred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChALTA_CTE_POS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChALTA_PROD_POS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        Me.Pag2.PerformLayout()
        CType(Me.BtnSeriesPorDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        CType(Me.ChObser_x_doc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSeriesPorDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag3.ResumeLayout(False)
        Me.Pag3.PerformLayout()
        Me.BarraMenuFolios.ResumeLayout(False)
        Me.BarraMenuFolios.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag4.ResumeLayout(False)
        CType(Me.ChALMACEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChOBSER_X_PARTIDA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChIMPUESTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChINDIRECTOS_X_PARTIDA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag6.ResumeLayout(False)
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag7.ResumeLayout(False)
        Me.Pag7.PerformLayout()
        CType(Me.CboSerieFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUnidadSAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClaveSAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSeriePedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieRemisionExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieCartaPorte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieCAPFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieProgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLineaEnVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents CboSeriePedidos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents ChOCULTAR_CRE_ENG As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChOCULTAR_CREDITO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents ChALMACEN As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChOBSER_X_PARTIDA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChIMPUESTOS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChINDIRECTOS_X_PARTIDA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Pag5 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents CboSerieRemision As C1.Win.C1Input.C1ComboBox
    Friend WithEvents ChObser_x_doc As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChBLOQEAR_LISTA_PREC As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CboSerieRemisionExt As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CboSerieCartaPorte As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TCVE_ART As TextBoxEx
    Friend WithEvents BtnProducto As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents CboSerieCAPFactura As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CboSerieProgPedidos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnLineaEnVentas As C1.Win.C1Input.C1Button
    Friend WithEvents TLIN_VENTAS As TextBox
    Friend WithEvents BtnLinea As C1.Win.C1Input.C1Button
    Friend WithEvents TLIN_FAC_CFDI As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Pag6 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents Tab2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PagFacturas As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagNV As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagRem As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagPed As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagCot As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagDev As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagNC As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagComPago As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents CboSeriesPorDoc As C1.Win.C1Input.C1ComboBox
    Friend WithEvents PagCPT As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BtnSeriesPorDoc As C1.Win.C1Input.C1Button
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarraMenu As ToolStrip
    Friend WithEvents BarGrabar As ToolStripButton
    Friend WithEvents BarSalir As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BarraMenuFolios As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarFacturas As ToolStripMenuItem
    Friend WithEvents BarNotas As ToolStripMenuItem
    Friend WithEvents BarRemisiones As ToolStripMenuItem
    Friend WithEvents BarPedidos As ToolStripMenuItem
    Friend WithEvents BarCotizaciones As ToolStripMenuItem
    Friend WithEvents BarDevoluciones As ToolStripMenuItem
    Friend WithEvents BarPagoComplemento As ToolStripMenuItem
    Friend WithEvents BarCartaPorteTras As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtDocus As Label
    Friend WithEvents Pag7 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents LSerieDoc As Label
    Friend WithEvents Pag8 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents ChVENDER_SIN_EXIST As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPER_VEND_ABA_COST As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChART_CON_IMP_INCLU As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChALTA_CTE_POS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChALTA_PROD_POS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChACTIVAR_POLITICAS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChHABILITAR_DESC As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPER_VEND_ABA_MIN As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChNOVALIDAR_LIM_CRED As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChACTIVAR_GAD As C1.Win.C1Input.C1CheckBox
    Friend WithEvents FgC As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnCliente As Button
    Friend WithEvents TCLIE_MOSTR As TextBoxEx
    Friend WithEvents ChUTILIZAR_LECTOR_HUELLA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents CboListaPrecPred As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CboSerieFacGlobal As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CboPeriodicidad As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnArtFG As Button
    Friend WithEvents TCVE_ART_FG As TextBoxEx
    Friend WithEvents BtnUnidadSAT As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_UNIDAD As TextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents TCVE_PRODSERV As TextBox
    Friend WithEvents BtnClaveSAT As C1.Win.C1Input.C1Button
    Friend WithEvents Label67 As Label
    Friend WithEvents CboSerieFactura As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label15 As Label
End Class
