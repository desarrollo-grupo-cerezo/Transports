<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLiquidacionesAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquidacionesAE))
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarDesplegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarFinalizarLiq = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimirResteo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimirLiq = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReseteo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.TCVE_RES = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.TCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtTipoCrobro = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCVE_LIQ = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Page1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Page2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.SplitG = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitG1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnGastosViajeEliminar = New C1.Win.C1Input.C1Button()
        Me.BtnGastosViaje = New C1.Win.C1Input.C1Button()
        Me.SplitG2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgG = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Page3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgV = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Page4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.SplitGasto = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitGasto3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnAddGC = New C1.Win.C1Input.C1Button()
        Me.BtnEliminarGasto = New C1.Win.C1Input.C1Button()
        Me.SplitGasto1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgGC = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Page6 = New C1.Win.C1Command.C1DockingTabPage()
        Me.SplitDedM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitDedM1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnEliminar = New C1.Win.C1Input.C1Button()
        Me.BtnAddDec = New C1.Win.C1Input.C1Button()
        Me.SplitDedM2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgD = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag8 = New C1.Win.C1Command.C1DockingTabPage()
        Me.SplitPension = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitPension1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnEliPartPA = New C1.Win.C1Input.C1Button()
        Me.BtnAltaPA = New C1.Win.C1Input.C1Button()
        Me.SplitPension2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgPA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Page5 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TOBS = New System.Windows.Forms.TextBox()
        Me.Pag7 = New C1.Win.C1Command.C1DockingTabPage()
        Me.GpoCamposAdic = New System.Windows.Forms.GroupBox()
        Me.TCARGO_X_PUNTO_MUERTO = New System.Windows.Forms.Label()
        Me.TLITROS_UREA = New System.Windows.Forms.Label()
        Me.TVELMAX = New System.Windows.Forms.Label()
        Me.TLTS_UREA_REAL = New System.Windows.Forms.Label()
        Me.LL10 = New System.Windows.Forms.Label()
        Me.TTIEMPO_MARCH_INERCIA = New System.Windows.Forms.Label()
        Me.L10 = New System.Windows.Forms.Label()
        Me.TCALIF = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.TDESCT = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.LL3 = New System.Windows.Forms.Label()
        Me.LL1 = New System.Windows.Forms.Label()
        Me.LL4 = New System.Windows.Forms.Label()
        Me.L11 = New System.Windows.Forms.Label()
        Me.LL9 = New System.Windows.Forms.Label()
        Me.L9 = New System.Windows.Forms.Label()
        Me.GpoEvento2 = New System.Windows.Forms.GroupBox()
        Me.RadLTS_TAB = New System.Windows.Forms.RadioButton()
        Me.RadLTS_ECM = New System.Windows.Forms.RadioButton()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.LtLTS_VALES2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TLTS_DESCONTAR2 = New C1.Win.C1Input.C1TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TPRECIO_X_LTS2 = New C1.Win.C1Input.C1TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TLTS_AUTORIZADOS2 = New C1.Win.C1Input.C1TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.LtDescXLitros2 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TLTS_SALIDA = New System.Windows.Forms.Label()
        Me.TLTS_TAB = New System.Windows.Forms.Label()
        Me.TLTS_FORANEOS = New System.Windows.Forms.Label()
        Me.TLTS_VALES = New System.Windows.Forms.Label()
        Me.TLTS_LLEGADA = New System.Windows.Forms.Label()
        Me.TFECHA = New System.Windows.Forms.Label()
        Me.TLTS_REAL = New System.Windows.Forms.Label()
        Me.TLTS_ECM = New System.Windows.Forms.Label()
        Me.TKM_ECM = New System.Windows.Forms.Label()
        Me.TODOMETRO = New System.Windows.Forms.Label()
        Me.TCVE_MOT = New System.Windows.Forms.Label()
        Me.TCVE_TRACTOR2 = New System.Windows.Forms.Label()
        Me.TCVE_OPER2 = New System.Windows.Forms.Label()
        Me.TCVE_RES2 = New System.Windows.Forms.Label()
        Me.GpoEvento1 = New System.Windows.Forms.GroupBox()
        Me.TPRECIO_X_LTS = New System.Windows.Forms.Label()
        Me.TPORC_RALENTI = New System.Windows.Forms.Label()
        Me.TLTS_DESCONTAR = New System.Windows.Forms.Label()
        Me.TLTS_AUTORIZADOS = New System.Windows.Forms.Label()
        Me.LtLTS_VALES = New System.Windows.Forms.Label()
        Me.TPORC_TOLERANCIA = New System.Windows.Forms.Label()
        Me.LtLTS_RALENTI = New System.Windows.Forms.Label()
        Me.LtLTS_ECM = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.LL7 = New System.Windows.Forms.Label()
        Me.LtDescXLitros = New System.Windows.Forms.Label()
        Me.L7 = New System.Windows.Forms.Label()
        Me.L6 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.LL6 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.LL5 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.L8 = New System.Windows.Forms.Label()
        Me.LL8 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Pag9Casetas = New C1.Win.C1Command.C1DockingTabPage()
        Me.btnGuardarCasetas = New System.Windows.Forms.Button()
        Me.FgCasetas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtGastosComprobados = New System.Windows.Forms.Label()
        Me.SplitMult = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitMult1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.TBOTONMAGICO_PA = New System.Windows.Forms.TextBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnUnidad = New System.Windows.Forms.Button()
        Me.BtnOper = New System.Windows.Forms.Button()
        Me.SplitMult2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitMult3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.LtLotaLts = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.LtLtsEfectivo = New System.Windows.Forms.Label()
        Me.BtnImporteLiquidar = New System.Windows.Forms.Button()
        Me.BtnSubTotal = New System.Windows.Forms.Button()
        Me.BtnDifCompro = New System.Windows.Forms.Button()
        Me.BtnToTPercep = New System.Windows.Forms.Button()
        Me.Lm4 = New System.Windows.Forms.Label()
        Me.BtnOTrasPercep = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LtPA = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.LtLitros = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtImporteLiquidar = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtValesCombustible = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.LtGastosDeViaje = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtDifCompro = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtTotalPercep = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtOtrasPercep = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LtSubtotal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtTotDeduc = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtPerXViaje = New System.Windows.Forms.Label()
        Me.TBotonMagicoD = New System.Windows.Forms.TextBox()
        Me.TABONAR = New C1.Win.C1Input.C1TextBox()
        Me.TBotonMagico = New System.Windows.Forms.TextBox()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.tMagic = New SGT_Transport.TextBoxEx()
        Me.TOBSER = New SGT_Transport.TextBoxEx()
        Me.BarMenu.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Page1.SuspendLayout()
        Me.Page2.SuspendLayout()
        CType(Me.SplitG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitG.SuspendLayout()
        Me.SplitG1.SuspendLayout()
        CType(Me.BtnGastosViajeEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGastosViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitG2.SuspendLayout()
        CType(Me.FgG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page3.SuspendLayout()
        CType(Me.FgV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page4.SuspendLayout()
        CType(Me.SplitGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitGasto.SuspendLayout()
        Me.SplitGasto3.SuspendLayout()
        CType(Me.BtnAddGC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminarGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitGasto1.SuspendLayout()
        CType(Me.FgGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page6.SuspendLayout()
        CType(Me.SplitDedM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDedM.SuspendLayout()
        Me.SplitDedM1.SuspendLayout()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAddDec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDedM2.SuspendLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag8.SuspendLayout()
        CType(Me.SplitPension, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPension.SuspendLayout()
        Me.SplitPension1.SuspendLayout()
        CType(Me.BtnEliPartPA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAltaPA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPension2.SuspendLayout()
        CType(Me.FgPA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page5.SuspendLayout()
        Me.Pag7.SuspendLayout()
        Me.GpoCamposAdic.SuspendLayout()
        Me.GpoEvento2.SuspendLayout()
        CType(Me.TLTS_DESCONTAR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPRECIO_X_LTS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLTS_AUTORIZADOS2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpoEvento1.SuspendLayout()
        Me.Pag9Casetas.SuspendLayout()
        CType(Me.FgCasetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitMult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMult.SuspendLayout()
        Me.SplitMult1.SuspendLayout()
        Me.SplitMult2.SuspendLayout()
        Me.SplitMult3.SuspendLayout()
        CType(Me.TABONAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarMenu
        '
        Me.BarMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDesplegar, Me.BarGrabar, Me.BarFinalizarLiq, Me.BarImprimirResteo, Me.BarImprimirLiq, Me.BarCancelacion, Me.BarReseteo, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(1454, 55)
        Me.BarMenu.Stretch = False
        Me.BarMenu.TabIndex = 0
        Me.BarMenu.Text = "MenuStrip1"
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarDesplegar.ForeColor = System.Drawing.Color.Black
        Me.BarDesplegar.Image = CType(resources.GetObject("BarDesplegar.Image"), System.Drawing.Image)
        Me.BarDesplegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarDesplegar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDesplegar.Size = New System.Drawing.Size(71, 51)
        Me.BarDesplegar.Text = "Desplegar"
        Me.BarDesplegar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = CType(resources.GetObject("BarGrabar.Image"), System.Drawing.Image)
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = ""
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarFinalizarLiq
        '
        Me.BarFinalizarLiq.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarFinalizarLiq.ForeColor = System.Drawing.Color.Black
        Me.BarFinalizarLiq.Image = CType(resources.GetObject("BarFinalizarLiq.Image"), System.Drawing.Image)
        Me.BarFinalizarLiq.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarFinalizarLiq.Name = "BarFinalizarLiq"
        Me.BarFinalizarLiq.ShortcutKeyDisplayString = ""
        Me.BarFinalizarLiq.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarFinalizarLiq.Size = New System.Drawing.Size(62, 51)
        Me.BarFinalizarLiq.Text = "Finalizar"
        Me.BarFinalizarLiq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimirResteo
        '
        Me.BarImprimirResteo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImprimirResteo.ForeColor = System.Drawing.Color.Black
        Me.BarImprimirResteo.Image = CType(resources.GetObject("BarImprimirResteo.Image"), System.Drawing.Image)
        Me.BarImprimirResteo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimirResteo.Name = "BarImprimirResteo"
        Me.BarImprimirResteo.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarImprimirResteo.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.BarImprimirResteo.Size = New System.Drawing.Size(60, 51)
        Me.BarImprimirResteo.Text = "Reseteo"
        Me.BarImprimirResteo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimirLiq
        '
        Me.BarImprimirLiq.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImprimirLiq.ForeColor = System.Drawing.Color.Black
        Me.BarImprimirLiq.Image = Global.SGT_Transport.My.Resources.Resources.impresora17
        Me.BarImprimirLiq.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimirLiq.Name = "BarImprimirLiq"
        Me.BarImprimirLiq.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarImprimirLiq.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.BarImprimirLiq.Size = New System.Drawing.Size(81, 51)
        Me.BarImprimirLiq.Text = "Liquidación"
        Me.BarImprimirLiq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCancelacion
        '
        Me.BarCancelacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCancelacion.ForeColor = System.Drawing.Color.Black
        Me.BarCancelacion.Image = Global.SGT_Transport.My.Resources.Resources.cancel8
        Me.BarCancelacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelacion.Name = "BarCancelacion"
        Me.BarCancelacion.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarCancelacion.Size = New System.Drawing.Size(84, 51)
        Me.BarCancelacion.Text = "Cancelación"
        Me.BarCancelacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarReseteo
        '
        Me.BarReseteo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarReseteo.ForeColor = System.Drawing.Color.Black
        Me.BarReseteo.Image = Global.SGT_Transport.My.Resources.Resources.reset1
        Me.BarReseteo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReseteo.Name = "BarReseteo"
        Me.BarReseteo.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarReseteo.Size = New System.Drawing.Size(115, 51)
        Me.BarReseteo.Text = "Consulta Reseteos"
        Me.BarReseteo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'TCVE_RES
        '
        Me.TCVE_RES.AcceptsReturn = True
        Me.TCVE_RES.AcceptsTab = True
        Me.TCVE_RES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_RES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_RES.ForeColor = System.Drawing.Color.Black
        Me.TCVE_RES.Location = New System.Drawing.Point(703, 23)
        Me.TCVE_RES.Name = "TCVE_RES"
        Me.TCVE_RES.Size = New System.Drawing.Size(61, 21)
        Me.TCVE_RES.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(648, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Reseteo"
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtUnidad.Location = New System.Drawing.Point(403, 49)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(232, 20)
        Me.LtUnidad.TabIndex = 235
        '
        'TCVE_TRACTOR
        '
        Me.TCVE_TRACTOR.AcceptsReturn = True
        Me.TCVE_TRACTOR.AcceptsTab = True
        Me.TCVE_TRACTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_TRACTOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TRACTOR.ForeColor = System.Drawing.Color.Black
        Me.TCVE_TRACTOR.Location = New System.Drawing.Point(307, 50)
        Me.TCVE_TRACTOR.Name = "TCVE_TRACTOR"
        Me.TCVE_TRACTOR.Size = New System.Drawing.Size(70, 21)
        Me.TCVE_TRACTOR.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(258, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 233
        Me.Label5.Text = "Unidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(28, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Estatus liq."
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtOper.Location = New System.Drawing.Point(403, 22)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(232, 20)
        Me.LtOper.TabIndex = 226
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(307, 22)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(70, 21)
        Me.TCVE_OPER.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(246, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 224
        Me.Label4.Text = "Operador"
        '
        'LtTipoCrobro
        '
        Me.LtTipoCrobro.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTipoCrobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipoCrobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipoCrobro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTipoCrobro.Location = New System.Drawing.Point(109, 54)
        Me.LtTipoCrobro.Name = "LtTipoCrobro"
        Me.LtTipoCrobro.Size = New System.Drawing.Size(115, 28)
        Me.LtTipoCrobro.TabIndex = 222
        Me.LtTipoCrobro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(109, 24)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(102, 19)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(107, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 15)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Fecha liquidación"
        '
        'TCVE_LIQ
        '
        Me.TCVE_LIQ.AcceptsReturn = True
        Me.TCVE_LIQ.AcceptsTab = True
        Me.TCVE_LIQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_LIQ.ForeColor = System.Drawing.Color.Black
        Me.TCVE_LIQ.Location = New System.Drawing.Point(19, 23)
        Me.TCVE_LIQ.Name = "TCVE_LIQ"
        Me.TCVE_LIQ.Size = New System.Drawing.Size(72, 29)
        Me.TCVE_LIQ.TabIndex = 201
        Me.TCVE_LIQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(29, 7)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 15)
        Me.Label27.TabIndex = 202
        Me.Label27.Text = "Folio"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Raised
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Never
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1287, 264)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 5
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Page1)
        Me.Tab1.Controls.Add(Me.Page2)
        Me.Tab1.Controls.Add(Me.Page3)
        Me.Tab1.Controls.Add(Me.Page4)
        Me.Tab1.Controls.Add(Me.Page6)
        Me.Tab1.Controls.Add(Me.Pag8)
        Me.Tab1.Controls.Add(Me.Page5)
        Me.Tab1.Controls.Add(Me.Pag7)
        Me.Tab1.Controls.Add(Me.Pag9Casetas)
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(1302, 323)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Silver
        '
        'Page1
        '
        Me.Page1.Controls.Add(Me.Fg)
        Me.Page1.Location = New System.Drawing.Point(1, 25)
        Me.Page1.Name = "Page1"
        Me.Page1.Size = New System.Drawing.Size(1300, 297)
        Me.Page1.TabIndex = 4
        Me.Page1.Text = "Liquidacion de viajes"
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.SplitG)
        Me.Page2.Location = New System.Drawing.Point(1, 25)
        Me.Page2.Name = "Page2"
        Me.Page2.Size = New System.Drawing.Size(1300, 297)
        Me.Page2.TabIndex = 6
        Me.Page2.Text = "Gastos de viaje"
        '
        'SplitG
        '
        Me.SplitG.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitG.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitG.BorderWidth = 1
        Me.SplitG.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitG.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitG.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitG.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitG.HeaderLineWidth = 1
        Me.SplitG.Location = New System.Drawing.Point(0, 0)
        Me.SplitG.Name = "SplitG"
        Me.SplitG.Panels.Add(Me.SplitG1)
        Me.SplitG.Panels.Add(Me.SplitG2)
        Me.SplitG.Size = New System.Drawing.Size(1300, 297)
        Me.SplitG.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitG.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitG.TabIndex = 8
        Me.SplitG.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitG.UseParentVisualStyle = False
        '
        'SplitG1
        '
        Me.SplitG1.Controls.Add(Me.BtnGastosViajeEliminar)
        Me.SplitG1.Controls.Add(Me.BtnGastosViaje)
        Me.SplitG1.Height = 44
        Me.SplitG1.Location = New System.Drawing.Point(1, 1)
        Me.SplitG1.Name = "SplitG1"
        Me.SplitG1.Size = New System.Drawing.Size(1298, 44)
        Me.SplitG1.SizeRatio = 15.0R
        Me.SplitG1.TabIndex = 0
        '
        'BtnGastosViajeEliminar
        '
        Me.BtnGastosViajeEliminar.Image = CType(resources.GetObject("BtnGastosViajeEliminar.Image"), System.Drawing.Image)
        Me.BtnGastosViajeEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGastosViajeEliminar.Location = New System.Drawing.Point(659, 9)
        Me.BtnGastosViajeEliminar.Name = "BtnGastosViajeEliminar"
        Me.BtnGastosViajeEliminar.Size = New System.Drawing.Size(189, 27)
        Me.BtnGastosViajeEliminar.TabIndex = 18
        Me.BtnGastosViajeEliminar.Text = "Eliminar gasto pendiente"
        Me.BtnGastosViajeEliminar.UseVisualStyleBackColor = True
        Me.BtnGastosViajeEliminar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnGastosViaje
        '
        Me.BtnGastosViaje.Image = CType(resources.GetObject("BtnGastosViaje.Image"), System.Drawing.Image)
        Me.BtnGastosViaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGastosViaje.Location = New System.Drawing.Point(366, 9)
        Me.BtnGastosViaje.Name = "BtnGastosViaje"
        Me.BtnGastosViaje.Size = New System.Drawing.Size(227, 27)
        Me.BtnGastosViaje.TabIndex = 17
        Me.BtnGastosViaje.Text = "Gastos pendientes de liquidar"
        Me.BtnGastosViaje.UseVisualStyleBackColor = True
        Me.BtnGastosViaje.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitG2
        '
        Me.SplitG2.Controls.Add(Me.FgG)
        Me.SplitG2.Height = 247
        Me.SplitG2.Location = New System.Drawing.Point(1, 49)
        Me.SplitG2.Name = "SplitG2"
        Me.SplitG2.Size = New System.Drawing.Size(1298, 247)
        Me.SplitG2.SizeRatio = 86.0R
        Me.SplitG2.TabIndex = 1
        '
        'FgG
        '
        Me.FgG.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgG.AutoClipboard = True
        Me.FgG.BackColor = System.Drawing.Color.White
        Me.FgG.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgG.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgG.ColumnInfo = resources.GetString("FgG.ColumnInfo")
        Me.FgG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgG.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgG.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgG.ForeColor = System.Drawing.Color.Black
        Me.FgG.Location = New System.Drawing.Point(0, 0)
        Me.FgG.Name = "FgG"
        Me.FgG.Rows.DefaultSize = 19
        Me.FgG.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgG.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgG.Size = New System.Drawing.Size(1298, 247)
        Me.FgG.StyleInfo = resources.GetString("FgG.StyleInfo")
        Me.FgG.TabIndex = 7
        '
        'Page3
        '
        Me.Page3.Controls.Add(Me.FgV)
        Me.Page3.Location = New System.Drawing.Point(1, 25)
        Me.Page3.Name = "Page3"
        Me.Page3.Size = New System.Drawing.Size(1300, 297)
        Me.Page3.TabIndex = 8
        Me.Page3.Text = "Vales combustible"
        '
        'FgV
        '
        Me.FgV.AllowEditing = False
        Me.FgV.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgV.AutoClipboard = True
        Me.FgV.BackColor = System.Drawing.Color.White
        Me.FgV.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgV.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgV.ColumnInfo = resources.GetString("FgV.ColumnInfo")
        Me.FgV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgV.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.FgV.ForeColor = System.Drawing.Color.Black
        Me.FgV.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgV.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgV.Location = New System.Drawing.Point(0, 0)
        Me.FgV.Name = "FgV"
        Me.FgV.Rows.Count = 1
        Me.FgV.Rows.DefaultSize = 21
        Me.FgV.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgV.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgV.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgV.Size = New System.Drawing.Size(1300, 297)
        Me.FgV.StyleInfo = resources.GetString("FgV.StyleInfo")
        Me.FgV.TabIndex = 9
        '
        'Page4
        '
        Me.Page4.Controls.Add(Me.SplitGasto)
        Me.Page4.Location = New System.Drawing.Point(1, 25)
        Me.Page4.Name = "Page4"
        Me.Page4.Size = New System.Drawing.Size(1300, 297)
        Me.Page4.TabIndex = 10
        Me.Page4.Text = "Gastos comprobados"
        '
        'SplitGasto
        '
        Me.SplitGasto.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitGasto.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitGasto.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitGasto.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitGasto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitGasto.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitGasto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitGasto.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitGasto.HeaderLineWidth = 1
        Me.SplitGasto.Location = New System.Drawing.Point(0, 0)
        Me.SplitGasto.Name = "SplitGasto"
        Me.SplitGasto.Panels.Add(Me.SplitGasto3)
        Me.SplitGasto.Panels.Add(Me.SplitGasto1)
        Me.SplitGasto.Size = New System.Drawing.Size(1300, 297)
        Me.SplitGasto.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitGasto.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitGasto.TabIndex = 1
        Me.SplitGasto.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitGasto.UseParentVisualStyle = False
        '
        'SplitGasto3
        '
        Me.SplitGasto3.BorderColor = System.Drawing.Color.Black
        Me.SplitGasto3.Controls.Add(Me.BtnAddGC)
        Me.SplitGasto3.Controls.Add(Me.BtnEliminarGasto)
        Me.SplitGasto3.Height = 44
        Me.SplitGasto3.Location = New System.Drawing.Point(0, 0)
        Me.SplitGasto3.Name = "SplitGasto3"
        Me.SplitGasto3.Size = New System.Drawing.Size(1300, 44)
        Me.SplitGasto3.SizeRatio = 15.0R
        Me.SplitGasto3.TabIndex = 2
        '
        'BtnAddGC
        '
        Me.BtnAddGC.Image = CType(resources.GetObject("BtnAddGC.Image"), System.Drawing.Image)
        Me.BtnAddGC.Location = New System.Drawing.Point(542, 9)
        Me.BtnAddGC.Name = "BtnAddGC"
        Me.BtnAddGC.Size = New System.Drawing.Size(35, 25)
        Me.BtnAddGC.TabIndex = 12
        Me.BtnAddGC.UseVisualStyleBackColor = True
        Me.BtnAddGC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnEliminarGasto
        '
        Me.BtnEliminarGasto.Image = CType(resources.GetObject("BtnEliminarGasto.Image"), System.Drawing.Image)
        Me.BtnEliminarGasto.Location = New System.Drawing.Point(614, 9)
        Me.BtnEliminarGasto.Name = "BtnEliminarGasto"
        Me.BtnEliminarGasto.Size = New System.Drawing.Size(35, 25)
        Me.BtnEliminarGasto.TabIndex = 13
        Me.BtnEliminarGasto.UseVisualStyleBackColor = True
        Me.BtnEliminarGasto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitGasto1
        '
        Me.SplitGasto1.BorderColor = System.Drawing.Color.Black
        Me.SplitGasto1.BorderWidth = 1
        Me.SplitGasto1.Controls.Add(Me.FgGC)
        Me.SplitGasto1.Height = 249
        Me.SplitGasto1.Location = New System.Drawing.Point(1, 49)
        Me.SplitGasto1.Name = "SplitGasto1"
        Me.SplitGasto1.Size = New System.Drawing.Size(1298, 247)
        Me.SplitGasto1.SizeRatio = 86.0R
        Me.SplitGasto1.TabIndex = 0
        '
        'FgGC
        '
        Me.FgGC.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgGC.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgGC.AutoClipboard = True
        Me.FgGC.BackColor = System.Drawing.Color.White
        Me.FgGC.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgGC.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgGC.ColumnInfo = resources.GetString("FgGC.ColumnInfo")
        Me.FgGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgGC.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Raised
        Me.FgGC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgGC.ForeColor = System.Drawing.Color.Black
        Me.FgGC.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgGC.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgGC.Location = New System.Drawing.Point(0, 0)
        Me.FgGC.Name = "FgGC"
        Me.FgGC.Rows.DefaultSize = 19
        Me.FgGC.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgGC.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgGC.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgGC.Size = New System.Drawing.Size(1298, 247)
        Me.FgGC.StyleInfo = resources.GetString("FgGC.StyleInfo")
        Me.FgGC.TabIndex = 11
        '
        'Page6
        '
        Me.Page6.Controls.Add(Me.SplitDedM)
        Me.Page6.Location = New System.Drawing.Point(1, 25)
        Me.Page6.Name = "Page6"
        Me.Page6.Size = New System.Drawing.Size(1300, 297)
        Me.Page6.TabIndex = 14
        Me.Page6.Text = "Deducciones"
        '
        'SplitDedM
        '
        Me.SplitDedM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitDedM.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitDedM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitDedM.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitDedM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitDedM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitDedM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitDedM.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitDedM.HeaderLineWidth = 1
        Me.SplitDedM.Location = New System.Drawing.Point(0, 0)
        Me.SplitDedM.Name = "SplitDedM"
        Me.SplitDedM.Panels.Add(Me.SplitDedM1)
        Me.SplitDedM.Panels.Add(Me.SplitDedM2)
        Me.SplitDedM.Size = New System.Drawing.Size(1300, 297)
        Me.SplitDedM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitDedM.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitDedM.TabIndex = 141
        Me.SplitDedM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitDedM.UseParentVisualStyle = False
        '
        'SplitDedM1
        '
        Me.SplitDedM1.BorderColor = System.Drawing.Color.Black
        Me.SplitDedM1.Controls.Add(Me.BtnEliminar)
        Me.SplitDedM1.Controls.Add(Me.BtnAddDec)
        Me.SplitDedM1.Height = 44
        Me.SplitDedM1.Location = New System.Drawing.Point(0, 0)
        Me.SplitDedM1.Name = "SplitDedM1"
        Me.SplitDedM1.Size = New System.Drawing.Size(1300, 44)
        Me.SplitDedM1.SizeRatio = 15.0R
        Me.SplitDedM1.TabIndex = 0
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(614, 9)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(25, 25)
        Me.BtnEliminar.TabIndex = 17
        Me.BtnEliminar.UseVisualStyleBackColor = True
        Me.BtnEliminar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnAddDec
        '
        Me.BtnAddDec.Image = CType(resources.GetObject("BtnAddDec.Image"), System.Drawing.Image)
        Me.BtnAddDec.Location = New System.Drawing.Point(542, 9)
        Me.BtnAddDec.Name = "BtnAddDec"
        Me.BtnAddDec.Size = New System.Drawing.Size(25, 25)
        Me.BtnAddDec.TabIndex = 16
        Me.BtnAddDec.UseVisualStyleBackColor = True
        Me.BtnAddDec.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitDedM2
        '
        Me.SplitDedM2.AutoScroll = True
        Me.SplitDedM2.BorderColor = System.Drawing.Color.Black
        Me.SplitDedM2.Controls.Add(Me.FgD)
        Me.SplitDedM2.Height = 249
        Me.SplitDedM2.Location = New System.Drawing.Point(0, 48)
        Me.SplitDedM2.Name = "SplitDedM2"
        Me.SplitDedM2.Size = New System.Drawing.Size(1300, 249)
        Me.SplitDedM2.SizeRatio = 86.0R
        Me.SplitDedM2.TabIndex = 1
        '
        'FgD
        '
        Me.FgD.AllowDelete = True
        Me.FgD.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgD.AutoClipboard = True
        Me.FgD.BackColor = System.Drawing.Color.White
        Me.FgD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgD.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgD.ColumnInfo = resources.GetString("FgD.ColumnInfo")
        Me.FgD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgD.EditOptions = CType((((((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.MultiCheck) _
            Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit) _
            Or C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys) _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest), C1.Win.C1FlexGrid.EditFlags)
        Me.FgD.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Raised
        Me.FgD.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgD.ForeColor = System.Drawing.Color.Black
        Me.FgD.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgD.Location = New System.Drawing.Point(0, 0)
        Me.FgD.Name = "FgD"
        Me.FgD.Rows.DefaultSize = 19
        Me.FgD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgD.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgD.Size = New System.Drawing.Size(1300, 249)
        Me.FgD.StyleInfo = resources.GetString("FgD.StyleInfo")
        Me.FgD.TabIndex = 0
        '
        'Pag8
        '
        Me.Pag8.Controls.Add(Me.SplitPension)
        Me.Pag8.Location = New System.Drawing.Point(1, 25)
        Me.Pag8.Name = "Pag8"
        Me.Pag8.Size = New System.Drawing.Size(1300, 297)
        Me.Pag8.TabIndex = 16
        Me.Pag8.Text = "Pensión alimenticia"
        '
        'SplitPension
        '
        Me.SplitPension.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitPension.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitPension.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitPension.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitPension.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPension.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitPension.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitPension.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitPension.HeaderLineWidth = 1
        Me.SplitPension.Location = New System.Drawing.Point(0, 0)
        Me.SplitPension.Name = "SplitPension"
        Me.SplitPension.Panels.Add(Me.SplitPension1)
        Me.SplitPension.Panels.Add(Me.SplitPension2)
        Me.SplitPension.Size = New System.Drawing.Size(1300, 297)
        Me.SplitPension.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitPension.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitPension.TabIndex = 142
        Me.SplitPension.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitPension.UseParentVisualStyle = False
        '
        'SplitPension1
        '
        Me.SplitPension1.BorderColor = System.Drawing.Color.Black
        Me.SplitPension1.Controls.Add(Me.BtnEliPartPA)
        Me.SplitPension1.Controls.Add(Me.BtnAltaPA)
        Me.SplitPension1.Height = 44
        Me.SplitPension1.Location = New System.Drawing.Point(0, 0)
        Me.SplitPension1.Name = "SplitPension1"
        Me.SplitPension1.Size = New System.Drawing.Size(1300, 44)
        Me.SplitPension1.SizeRatio = 15.0R
        Me.SplitPension1.TabIndex = 0
        '
        'BtnEliPartPA
        '
        Me.BtnEliPartPA.Image = CType(resources.GetObject("BtnEliPartPA.Image"), System.Drawing.Image)
        Me.BtnEliPartPA.Location = New System.Drawing.Point(614, 9)
        Me.BtnEliPartPA.Name = "BtnEliPartPA"
        Me.BtnEliPartPA.Size = New System.Drawing.Size(25, 25)
        Me.BtnEliPartPA.TabIndex = 17
        Me.BtnEliPartPA.UseVisualStyleBackColor = True
        Me.BtnEliPartPA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnAltaPA
        '
        Me.BtnAltaPA.Image = CType(resources.GetObject("BtnAltaPA.Image"), System.Drawing.Image)
        Me.BtnAltaPA.Location = New System.Drawing.Point(542, 9)
        Me.BtnAltaPA.Name = "BtnAltaPA"
        Me.BtnAltaPA.Size = New System.Drawing.Size(25, 25)
        Me.BtnAltaPA.TabIndex = 16
        Me.BtnAltaPA.UseVisualStyleBackColor = True
        Me.BtnAltaPA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitPension2
        '
        Me.SplitPension2.AutoScroll = True
        Me.SplitPension2.BorderColor = System.Drawing.Color.Black
        Me.SplitPension2.Controls.Add(Me.FgPA)
        Me.SplitPension2.Height = 249
        Me.SplitPension2.Location = New System.Drawing.Point(0, 48)
        Me.SplitPension2.Name = "SplitPension2"
        Me.SplitPension2.Size = New System.Drawing.Size(1300, 249)
        Me.SplitPension2.SizeRatio = 86.0R
        Me.SplitPension2.TabIndex = 1
        '
        'FgPA
        '
        Me.FgPA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgPA.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgPA.AutoClipboard = True
        Me.FgPA.BackColor = System.Drawing.Color.White
        Me.FgPA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgPA.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgPA.ColumnInfo = resources.GetString("FgPA.ColumnInfo")
        Me.FgPA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgPA.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Raised
        Me.FgPA.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgPA.ForeColor = System.Drawing.Color.Black
        Me.FgPA.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgPA.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgPA.Location = New System.Drawing.Point(0, 0)
        Me.FgPA.Name = "FgPA"
        Me.FgPA.Rows.DefaultSize = 19
        Me.FgPA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgPA.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgPA.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgPA.Size = New System.Drawing.Size(1300, 249)
        Me.FgPA.StyleInfo = resources.GetString("FgPA.StyleInfo")
        Me.FgPA.TabIndex = 12
        '
        'Page5
        '
        Me.Page5.Controls.Add(Me.TOBS)
        Me.Page5.Location = New System.Drawing.Point(1, 25)
        Me.Page5.Name = "Page5"
        Me.Page5.Size = New System.Drawing.Size(1300, 297)
        Me.Page5.TabIndex = 2
        Me.Page5.Text = "Observaciones"
        '
        'TOBS
        '
        Me.TOBS.AcceptsReturn = True
        Me.TOBS.AcceptsTab = True
        Me.TOBS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBS.ForeColor = System.Drawing.Color.Black
        Me.TOBS.Location = New System.Drawing.Point(30, 24)
        Me.TOBS.Multiline = True
        Me.TOBS.Name = "TOBS"
        Me.TOBS.Size = New System.Drawing.Size(865, 194)
        Me.TOBS.TabIndex = 18
        '
        'Pag7
        '
        Me.Pag7.Controls.Add(Me.GpoCamposAdic)
        Me.Pag7.Controls.Add(Me.GpoEvento2)
        Me.Pag7.Controls.Add(Me.TLTS_SALIDA)
        Me.Pag7.Controls.Add(Me.TLTS_TAB)
        Me.Pag7.Controls.Add(Me.TLTS_FORANEOS)
        Me.Pag7.Controls.Add(Me.TLTS_VALES)
        Me.Pag7.Controls.Add(Me.TLTS_LLEGADA)
        Me.Pag7.Controls.Add(Me.TFECHA)
        Me.Pag7.Controls.Add(Me.TLTS_REAL)
        Me.Pag7.Controls.Add(Me.TLTS_ECM)
        Me.Pag7.Controls.Add(Me.TKM_ECM)
        Me.Pag7.Controls.Add(Me.TODOMETRO)
        Me.Pag7.Controls.Add(Me.TCVE_MOT)
        Me.Pag7.Controls.Add(Me.TCVE_TRACTOR2)
        Me.Pag7.Controls.Add(Me.TCVE_OPER2)
        Me.Pag7.Controls.Add(Me.TCVE_RES2)
        Me.Pag7.Controls.Add(Me.GpoEvento1)
        Me.Pag7.Controls.Add(Me.Label51)
        Me.Pag7.Controls.Add(Me.Label23)
        Me.Pag7.Controls.Add(Me.Lt5)
        Me.Pag7.Controls.Add(Me.Label24)
        Me.Pag7.Controls.Add(Me.Nombre)
        Me.Pag7.Controls.Add(Me.Label13)
        Me.Pag7.Controls.Add(Me.Label15)
        Me.Pag7.Controls.Add(Me.Label19)
        Me.Pag7.Controls.Add(Me.Label16)
        Me.Pag7.Controls.Add(Me.Label17)
        Me.Pag7.Controls.Add(Me.Label18)
        Me.Pag7.Controls.Add(Me.Label20)
        Me.Pag7.Controls.Add(Me.Label21)
        Me.Pag7.Controls.Add(Me.Label22)
        Me.Pag7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pag7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Pag7.Location = New System.Drawing.Point(1, 25)
        Me.Pag7.Name = "Pag7"
        Me.Pag7.Size = New System.Drawing.Size(1300, 297)
        Me.Pag7.TabIndex = 15
        Me.Pag7.Text = "Reseteo"
        '
        'GpoCamposAdic
        '
        Me.GpoCamposAdic.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GpoCamposAdic.Controls.Add(Me.TCARGO_X_PUNTO_MUERTO)
        Me.GpoCamposAdic.Controls.Add(Me.TLITROS_UREA)
        Me.GpoCamposAdic.Controls.Add(Me.TVELMAX)
        Me.GpoCamposAdic.Controls.Add(Me.TLTS_UREA_REAL)
        Me.GpoCamposAdic.Controls.Add(Me.LL10)
        Me.GpoCamposAdic.Controls.Add(Me.TTIEMPO_MARCH_INERCIA)
        Me.GpoCamposAdic.Controls.Add(Me.L10)
        Me.GpoCamposAdic.Controls.Add(Me.TCALIF)
        Me.GpoCamposAdic.Controls.Add(Me.L3)
        Me.GpoCamposAdic.Controls.Add(Me.TDESCT)
        Me.GpoCamposAdic.Controls.Add(Me.L1)
        Me.GpoCamposAdic.Controls.Add(Me.L2)
        Me.GpoCamposAdic.Controls.Add(Me.L4)
        Me.GpoCamposAdic.Controls.Add(Me.LL3)
        Me.GpoCamposAdic.Controls.Add(Me.LL1)
        Me.GpoCamposAdic.Controls.Add(Me.LL4)
        Me.GpoCamposAdic.Controls.Add(Me.L11)
        Me.GpoCamposAdic.Controls.Add(Me.LL9)
        Me.GpoCamposAdic.Controls.Add(Me.L9)
        Me.GpoCamposAdic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpoCamposAdic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GpoCamposAdic.Location = New System.Drawing.Point(409, 8)
        Me.GpoCamposAdic.Name = "GpoCamposAdic"
        Me.GpoCamposAdic.Size = New System.Drawing.Size(597, 116)
        Me.GpoCamposAdic.TabIndex = 557
        Me.GpoCamposAdic.TabStop = False
        Me.GpoCamposAdic.Text = "Campos adicionales"
        '
        'TCARGO_X_PUNTO_MUERTO
        '
        Me.TCARGO_X_PUNTO_MUERTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCARGO_X_PUNTO_MUERTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCARGO_X_PUNTO_MUERTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCARGO_X_PUNTO_MUERTO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCARGO_X_PUNTO_MUERTO.Location = New System.Drawing.Point(456, 65)
        Me.TCARGO_X_PUNTO_MUERTO.Name = "TCARGO_X_PUNTO_MUERTO"
        Me.TCARGO_X_PUNTO_MUERTO.Size = New System.Drawing.Size(101, 21)
        Me.TCARGO_X_PUNTO_MUERTO.TabIndex = 588
        Me.TCARGO_X_PUNTO_MUERTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLITROS_UREA
        '
        Me.TLITROS_UREA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLITROS_UREA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLITROS_UREA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLITROS_UREA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLITROS_UREA.Location = New System.Drawing.Point(456, 17)
        Me.TLITROS_UREA.Name = "TLITROS_UREA"
        Me.TLITROS_UREA.Size = New System.Drawing.Size(101, 21)
        Me.TLITROS_UREA.TabIndex = 587
        Me.TLITROS_UREA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TVELMAX
        '
        Me.TVELMAX.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TVELMAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TVELMAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TVELMAX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TVELMAX.Location = New System.Drawing.Point(161, 65)
        Me.TVELMAX.Name = "TVELMAX"
        Me.TVELMAX.Size = New System.Drawing.Size(101, 21)
        Me.TVELMAX.TabIndex = 586
        Me.TVELMAX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_UREA_REAL
        '
        Me.TLTS_UREA_REAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_UREA_REAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_UREA_REAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_UREA_REAL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_UREA_REAL.Location = New System.Drawing.Point(456, 41)
        Me.TLTS_UREA_REAL.Name = "TLTS_UREA_REAL"
        Me.TLTS_UREA_REAL.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_UREA_REAL.TabIndex = 586
        Me.TLTS_UREA_REAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LL10
        '
        Me.LL10.AutoSize = True
        Me.LL10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LL10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL10.Location = New System.Drawing.Point(556, 47)
        Me.LL10.Name = "LL10"
        Me.LL10.Size = New System.Drawing.Size(24, 13)
        Me.LL10.TabIndex = 540
        Me.LL10.Text = "Lts."
        '
        'TTIEMPO_MARCH_INERCIA
        '
        Me.TTIEMPO_MARCH_INERCIA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TTIEMPO_MARCH_INERCIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIEMPO_MARCH_INERCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIEMPO_MARCH_INERCIA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TTIEMPO_MARCH_INERCIA.Location = New System.Drawing.Point(161, 89)
        Me.TTIEMPO_MARCH_INERCIA.Name = "TTIEMPO_MARCH_INERCIA"
        Me.TTIEMPO_MARCH_INERCIA.Size = New System.Drawing.Size(101, 21)
        Me.TTIEMPO_MARCH_INERCIA.TabIndex = 585
        Me.TTIEMPO_MARCH_INERCIA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L10
        '
        Me.L10.AutoSize = True
        Me.L10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L10.Location = New System.Drawing.Point(359, 45)
        Me.L10.Name = "L10"
        Me.L10.Size = New System.Drawing.Size(94, 16)
        Me.L10.TabIndex = 539
        Me.L10.Text = "Lts. UREA real"
        '
        'TCALIF
        '
        Me.TCALIF.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCALIF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCALIF.Location = New System.Drawing.Point(161, 41)
        Me.TCALIF.Name = "TCALIF"
        Me.TCALIF.Size = New System.Drawing.Size(101, 21)
        Me.TCALIF.TabIndex = 583
        Me.TCALIF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L3.Location = New System.Drawing.Point(38, 68)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(119, 16)
        Me.L3.TabIndex = 311
        Me.L3.Text = "Velocidad máxima"
        '
        'TDESCT
        '
        Me.TDESCT.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TDESCT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TDESCT.Location = New System.Drawing.Point(161, 17)
        Me.TDESCT.Name = "TDESCT"
        Me.TDESCT.Size = New System.Drawing.Size(101, 21)
        Me.TDESCT.TabIndex = 584
        Me.TDESCT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L1.Location = New System.Drawing.Point(85, 20)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(72, 16)
        Me.L1.TabIndex = 313
        Me.L1.Text = "Descuento"
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L2.Location = New System.Drawing.Point(81, 44)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(76, 16)
        Me.L2.TabIndex = 310
        Me.L2.Text = "Calificación"
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L4.Location = New System.Drawing.Point(3, 92)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(154, 16)
        Me.L4.TabIndex = 309
        Me.L4.Text = "Tiempo marcha x inercia"
        '
        'LL3
        '
        Me.LL3.AutoSize = True
        Me.LL3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LL3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL3.Location = New System.Drawing.Point(264, 71)
        Me.LL3.Name = "LL3"
        Me.LL3.Size = New System.Drawing.Size(40, 13)
        Me.LL3.TabIndex = 314
        Me.LL3.Text = "km/hrs"
        '
        'LL1
        '
        Me.LL1.AutoSize = True
        Me.LL1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LL1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL1.Location = New System.Drawing.Point(264, 22)
        Me.LL1.Name = "LL1"
        Me.LL1.Size = New System.Drawing.Size(19, 13)
        Me.LL1.TabIndex = 316
        Me.LL1.Text = "($)"
        '
        'LL4
        '
        Me.LL4.AutoSize = True
        Me.LL4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LL4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL4.Location = New System.Drawing.Point(264, 94)
        Me.LL4.Name = "LL4"
        Me.LL4.Size = New System.Drawing.Size(21, 13)
        Me.LL4.TabIndex = 317
        Me.LL4.Text = "hrs"
        '
        'L11
        '
        Me.L11.AutoSize = True
        Me.L11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L11.Location = New System.Drawing.Point(320, 67)
        Me.L11.Name = "L11"
        Me.L11.Size = New System.Drawing.Size(133, 16)
        Me.L11.TabIndex = 534
        Me.L11.Text = "Cargo x punto muerto"
        '
        'LL9
        '
        Me.LL9.AutoSize = True
        Me.LL9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LL9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL9.Location = New System.Drawing.Point(556, 24)
        Me.LL9.Name = "LL9"
        Me.LL9.Size = New System.Drawing.Size(24, 13)
        Me.LL9.TabIndex = 532
        Me.LL9.Text = "Lts."
        '
        'L9
        '
        Me.L9.AutoSize = True
        Me.L9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L9.Location = New System.Drawing.Point(385, 20)
        Me.L9.Name = "L9"
        Me.L9.Size = New System.Drawing.Size(68, 16)
        Me.L9.TabIndex = 531
        Me.L9.Text = "Lts. UREA"
        '
        'GpoEvento2
        '
        Me.GpoEvento2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GpoEvento2.Controls.Add(Me.RadLTS_TAB)
        Me.GpoEvento2.Controls.Add(Me.RadLTS_ECM)
        Me.GpoEvento2.Controls.Add(Me.Label72)
        Me.GpoEvento2.Controls.Add(Me.LtLTS_VALES2)
        Me.GpoEvento2.Controls.Add(Me.Label26)
        Me.GpoEvento2.Controls.Add(Me.TLTS_DESCONTAR2)
        Me.GpoEvento2.Controls.Add(Me.Label28)
        Me.GpoEvento2.Controls.Add(Me.TPRECIO_X_LTS2)
        Me.GpoEvento2.Controls.Add(Me.Label30)
        Me.GpoEvento2.Controls.Add(Me.TLTS_AUTORIZADOS2)
        Me.GpoEvento2.Controls.Add(Me.Label31)
        Me.GpoEvento2.Controls.Add(Me.Label68)
        Me.GpoEvento2.Controls.Add(Me.Label32)
        Me.GpoEvento2.Controls.Add(Me.LtDescXLitros2)
        Me.GpoEvento2.Controls.Add(Me.Label47)
        Me.GpoEvento2.Controls.Add(Me.Label49)
        Me.GpoEvento2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GpoEvento2.Location = New System.Drawing.Point(902, 123)
        Me.GpoEvento2.Name = "GpoEvento2"
        Me.GpoEvento2.Size = New System.Drawing.Size(297, 171)
        Me.GpoEvento2.TabIndex = 583
        Me.GpoEvento2.TabStop = False
        '
        'RadLTS_TAB
        '
        Me.RadLTS_TAB.AutoSize = True
        Me.RadLTS_TAB.BackColor = System.Drawing.Color.Transparent
        Me.RadLTS_TAB.Enabled = False
        Me.RadLTS_TAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLTS_TAB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadLTS_TAB.Location = New System.Drawing.Point(6, 295)
        Me.RadLTS_TAB.Name = "RadLTS_TAB"
        Me.RadLTS_TAB.Size = New System.Drawing.Size(117, 20)
        Me.RadLTS_TAB.TabIndex = 585
        Me.RadLTS_TAB.TabStop = True
        Me.RadLTS_TAB.Text = "Litros tabulador"
        Me.RadLTS_TAB.UseVisualStyleBackColor = False
        '
        'RadLTS_ECM
        '
        Me.RadLTS_ECM.AutoSize = True
        Me.RadLTS_ECM.BackColor = System.Drawing.Color.Transparent
        Me.RadLTS_ECM.Enabled = False
        Me.RadLTS_ECM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLTS_ECM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadLTS_ECM.Location = New System.Drawing.Point(6, 323)
        Me.RadLTS_ECM.Name = "RadLTS_ECM"
        Me.RadLTS_ECM.Size = New System.Drawing.Size(89, 20)
        Me.RadLTS_ECM.TabIndex = 584
        Me.RadLTS_ECM.TabStop = True
        Me.RadLTS_ECM.Text = "Litros ECM"
        Me.RadLTS_ECM.UseVisualStyleBackColor = False
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label72.Location = New System.Drawing.Point(69, 386)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(68, 16)
        Me.Label72.TabIndex = 583
        Me.Label72.Text = "Lts. fisicos"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtLTS_VALES2
        '
        Me.LtLTS_VALES2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLTS_VALES2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLTS_VALES2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLTS_VALES2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLTS_VALES2.Location = New System.Drawing.Point(142, 34)
        Me.LtLTS_VALES2.Name = "LtLTS_VALES2"
        Me.LtLTS_VALES2.Size = New System.Drawing.Size(100, 21)
        Me.LtLTS_VALES2.TabIndex = 582
        Me.LtLTS_VALES2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(37, 358)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 16)
        Me.Label26.TabIndex = 577
        Me.Label26.Text = "Lts. autorizados"
        '
        'TLTS_DESCONTAR2
        '
        Me.TLTS_DESCONTAR2.AcceptsReturn = True
        Me.TLTS_DESCONTAR2.AcceptsTab = True
        Me.TLTS_DESCONTAR2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TLTS_DESCONTAR2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_DESCONTAR2.CustomFormat = "###,###,##0.00"
        Me.TLTS_DESCONTAR2.DataType = GetType(Decimal)
        Me.TLTS_DESCONTAR2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TLTS_DESCONTAR2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_DESCONTAR2.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_DESCONTAR2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_DESCONTAR2.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_DESCONTAR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_DESCONTAR2.Location = New System.Drawing.Point(142, 59)
        Me.TLTS_DESCONTAR2.Name = "TLTS_DESCONTAR2"
        Me.TLTS_DESCONTAR2.Size = New System.Drawing.Size(100, 20)
        Me.TLTS_DESCONTAR2.TabIndex = 570
        Me.TLTS_DESCONTAR2.Tag = Nothing
        Me.TLTS_DESCONTAR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TLTS_DESCONTAR2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(248, 353)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(27, 16)
        Me.Label28.TabIndex = 578
        Me.Label28.Text = "Lts."
        '
        'TPRECIO_X_LTS2
        '
        Me.TPRECIO_X_LTS2.AcceptsReturn = True
        Me.TPRECIO_X_LTS2.AcceptsTab = True
        Me.TPRECIO_X_LTS2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TPRECIO_X_LTS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPRECIO_X_LTS2.CustomFormat = "###,###,##0.00"
        Me.TPRECIO_X_LTS2.DataType = GetType(Decimal)
        Me.TPRECIO_X_LTS2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TPRECIO_X_LTS2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO_X_LTS2.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO_X_LTS2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO_X_LTS2.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO_X_LTS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRECIO_X_LTS2.Location = New System.Drawing.Point(142, 84)
        Me.TPRECIO_X_LTS2.Name = "TPRECIO_X_LTS2"
        Me.TPRECIO_X_LTS2.Size = New System.Drawing.Size(100, 20)
        Me.TPRECIO_X_LTS2.TabIndex = 572
        Me.TPRECIO_X_LTS2.Tag = Nothing
        Me.TPRECIO_X_LTS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRECIO_X_LTS2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(248, 404)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(27, 16)
        Me.Label30.TabIndex = 575
        Me.Label30.Text = "Lts."
        '
        'TLTS_AUTORIZADOS2
        '
        Me.TLTS_AUTORIZADOS2.AcceptsReturn = True
        Me.TLTS_AUTORIZADOS2.AcceptsTab = True
        Me.TLTS_AUTORIZADOS2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TLTS_AUTORIZADOS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_AUTORIZADOS2.CustomFormat = "###,###,##0.00"
        Me.TLTS_AUTORIZADOS2.DataType = GetType(Decimal)
        Me.TLTS_AUTORIZADOS2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TLTS_AUTORIZADOS2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_AUTORIZADOS2.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_AUTORIZADOS2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_AUTORIZADOS2.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_AUTORIZADOS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_AUTORIZADOS2.Location = New System.Drawing.Point(141, 134)
        Me.TLTS_AUTORIZADOS2.Name = "TLTS_AUTORIZADOS2"
        Me.TLTS_AUTORIZADOS2.Size = New System.Drawing.Size(100, 20)
        Me.TLTS_AUTORIZADOS2.TabIndex = 571
        Me.TLTS_AUTORIZADOS2.Tag = Nothing
        Me.TLTS_AUTORIZADOS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TLTS_AUTORIZADOS2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(255, 446)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(22, 16)
        Me.Label31.TabIndex = 576
        Me.Label31.Text = "($)"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label68.Location = New System.Drawing.Point(231, 453)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(22, 16)
        Me.Label68.TabIndex = 581
        Me.Label68.Text = "($)"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(36, 411)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(101, 16)
        Me.Label32.TabIndex = 574
        Me.Label32.Text = "Lts. a descontar"
        '
        'LtDescXLitros2
        '
        Me.LtDescXLitros2.BackColor = System.Drawing.Color.Yellow
        Me.LtDescXLitros2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescXLitros2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescXLitros2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDescXLitros2.Location = New System.Drawing.Point(142, 108)
        Me.LtDescXLitros2.Name = "LtDescXLitros2"
        Me.LtDescXLitros2.Size = New System.Drawing.Size(99, 21)
        Me.LtDescXLitros2.TabIndex = 580
        Me.LtDescXLitros2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(41, 438)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(79, 16)
        Me.Label47.TabIndex = 573
        Me.Label47.Text = "Precio x litro"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(38, 458)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(82, 16)
        Me.Label49.TabIndex = 579
        Me.Label49.Text = "Desc. x litros"
        '
        'TLTS_SALIDA
        '
        Me.TLTS_SALIDA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_SALIDA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_SALIDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_SALIDA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_SALIDA.Location = New System.Drawing.Point(300, 123)
        Me.TLTS_SALIDA.Name = "TLTS_SALIDA"
        Me.TLTS_SALIDA.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_SALIDA.TabIndex = 582
        Me.TLTS_SALIDA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_TAB
        '
        Me.TLTS_TAB.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_TAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_TAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_TAB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_TAB.Location = New System.Drawing.Point(174, 263)
        Me.TLTS_TAB.Name = "TLTS_TAB"
        Me.TLTS_TAB.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_TAB.TabIndex = 581
        Me.TLTS_TAB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_FORANEOS
        '
        Me.TLTS_FORANEOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_FORANEOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_FORANEOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_FORANEOS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_FORANEOS.Location = New System.Drawing.Point(300, 98)
        Me.TLTS_FORANEOS.Name = "TLTS_FORANEOS"
        Me.TLTS_FORANEOS.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_FORANEOS.TabIndex = 580
        Me.TLTS_FORANEOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_VALES
        '
        Me.TLTS_VALES.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_VALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_VALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_VALES.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_VALES.Location = New System.Drawing.Point(300, 73)
        Me.TLTS_VALES.Name = "TLTS_VALES"
        Me.TLTS_VALES.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_VALES.TabIndex = 579
        Me.TLTS_VALES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_LLEGADA
        '
        Me.TLTS_LLEGADA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_LLEGADA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_LLEGADA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_LLEGADA.Location = New System.Drawing.Point(300, 48)
        Me.TLTS_LLEGADA.Name = "TLTS_LLEGADA"
        Me.TLTS_LLEGADA.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_LLEGADA.TabIndex = 577
        Me.TLTS_LLEGADA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TFECHA
        '
        Me.TFECHA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TFECHA.Location = New System.Drawing.Point(300, 23)
        Me.TFECHA.Name = "TFECHA"
        Me.TFECHA.Size = New System.Drawing.Size(101, 21)
        Me.TFECHA.TabIndex = 578
        Me.TFECHA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TLTS_REAL
        '
        Me.TLTS_REAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_REAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_REAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_REAL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_REAL.Location = New System.Drawing.Point(174, 239)
        Me.TLTS_REAL.Name = "TLTS_REAL"
        Me.TLTS_REAL.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_REAL.TabIndex = 576
        Me.TLTS_REAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_ECM
        '
        Me.TLTS_ECM.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_ECM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_ECM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_ECM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_ECM.Location = New System.Drawing.Point(174, 215)
        Me.TLTS_ECM.Name = "TLTS_ECM"
        Me.TLTS_ECM.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_ECM.TabIndex = 575
        Me.TLTS_ECM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TKM_ECM
        '
        Me.TKM_ECM.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TKM_ECM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_ECM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ECM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TKM_ECM.Location = New System.Drawing.Point(174, 191)
        Me.TKM_ECM.Name = "TKM_ECM"
        Me.TKM_ECM.Size = New System.Drawing.Size(101, 21)
        Me.TKM_ECM.TabIndex = 573
        Me.TKM_ECM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TODOMETRO
        '
        Me.TODOMETRO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TODOMETRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TODOMETRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TODOMETRO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TODOMETRO.Location = New System.Drawing.Point(174, 167)
        Me.TODOMETRO.Name = "TODOMETRO"
        Me.TODOMETRO.Size = New System.Drawing.Size(101, 21)
        Me.TODOMETRO.TabIndex = 574
        Me.TODOMETRO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TCVE_MOT
        '
        Me.TCVE_MOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCVE_MOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_MOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_MOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCVE_MOT.Location = New System.Drawing.Point(79, 98)
        Me.TCVE_MOT.Name = "TCVE_MOT"
        Me.TCVE_MOT.Size = New System.Drawing.Size(88, 21)
        Me.TCVE_MOT.TabIndex = 572
        Me.TCVE_MOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TCVE_TRACTOR2
        '
        Me.TCVE_TRACTOR2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCVE_TRACTOR2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_TRACTOR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TRACTOR2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCVE_TRACTOR2.Location = New System.Drawing.Point(79, 73)
        Me.TCVE_TRACTOR2.Name = "TCVE_TRACTOR2"
        Me.TCVE_TRACTOR2.Size = New System.Drawing.Size(88, 21)
        Me.TCVE_TRACTOR2.TabIndex = 571
        Me.TCVE_TRACTOR2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TCVE_OPER2
        '
        Me.TCVE_OPER2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCVE_OPER2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_OPER2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCVE_OPER2.Location = New System.Drawing.Point(79, 48)
        Me.TCVE_OPER2.Name = "TCVE_OPER2"
        Me.TCVE_OPER2.Size = New System.Drawing.Size(88, 21)
        Me.TCVE_OPER2.TabIndex = 570
        Me.TCVE_OPER2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TCVE_RES2
        '
        Me.TCVE_RES2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCVE_RES2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_RES2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_RES2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TCVE_RES2.Location = New System.Drawing.Point(79, 23)
        Me.TCVE_RES2.Name = "TCVE_RES2"
        Me.TCVE_RES2.Size = New System.Drawing.Size(88, 21)
        Me.TCVE_RES2.TabIndex = 570
        Me.TCVE_RES2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GpoEvento1
        '
        Me.GpoEvento1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GpoEvento1.Controls.Add(Me.TPRECIO_X_LTS)
        Me.GpoEvento1.Controls.Add(Me.TPORC_RALENTI)
        Me.GpoEvento1.Controls.Add(Me.TLTS_DESCONTAR)
        Me.GpoEvento1.Controls.Add(Me.TLTS_AUTORIZADOS)
        Me.GpoEvento1.Controls.Add(Me.LtLTS_VALES)
        Me.GpoEvento1.Controls.Add(Me.TPORC_TOLERANCIA)
        Me.GpoEvento1.Controls.Add(Me.LtLTS_RALENTI)
        Me.GpoEvento1.Controls.Add(Me.LtLTS_ECM)
        Me.GpoEvento1.Controls.Add(Me.Label50)
        Me.GpoEvento1.Controls.Add(Me.Label48)
        Me.GpoEvento1.Controls.Add(Me.Label46)
        Me.GpoEvento1.Controls.Add(Me.LL7)
        Me.GpoEvento1.Controls.Add(Me.LtDescXLitros)
        Me.GpoEvento1.Controls.Add(Me.L7)
        Me.GpoEvento1.Controls.Add(Me.L6)
        Me.GpoEvento1.Controls.Add(Me.L5)
        Me.GpoEvento1.Controls.Add(Me.LL6)
        Me.GpoEvento1.Controls.Add(Me.Label45)
        Me.GpoEvento1.Controls.Add(Me.LL5)
        Me.GpoEvento1.Controls.Add(Me.Label33)
        Me.GpoEvento1.Controls.Add(Me.L8)
        Me.GpoEvento1.Controls.Add(Me.LL8)
        Me.GpoEvento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpoEvento1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GpoEvento1.Location = New System.Drawing.Point(409, 124)
        Me.GpoEvento1.Name = "GpoEvento1"
        Me.GpoEvento1.Size = New System.Drawing.Size(493, 167)
        Me.GpoEvento1.TabIndex = 558
        Me.GpoEvento1.TabStop = False
        Me.GpoEvento1.Text = "Evento"
        '
        'TPRECIO_X_LTS
        '
        Me.TPRECIO_X_LTS.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TPRECIO_X_LTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPRECIO_X_LTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRECIO_X_LTS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TPRECIO_X_LTS.Location = New System.Drawing.Point(362, 95)
        Me.TPRECIO_X_LTS.Name = "TPRECIO_X_LTS"
        Me.TPRECIO_X_LTS.Size = New System.Drawing.Size(101, 21)
        Me.TPRECIO_X_LTS.TabIndex = 584
        Me.TPRECIO_X_LTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPORC_RALENTI
        '
        Me.TPORC_RALENTI.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TPORC_RALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPORC_RALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPORC_RALENTI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TPORC_RALENTI.Location = New System.Drawing.Point(362, 20)
        Me.TPORC_RALENTI.Name = "TPORC_RALENTI"
        Me.TPORC_RALENTI.Size = New System.Drawing.Size(101, 21)
        Me.TPORC_RALENTI.TabIndex = 583
        Me.TPORC_RALENTI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_DESCONTAR
        '
        Me.TLTS_DESCONTAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_DESCONTAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_DESCONTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_DESCONTAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_DESCONTAR.Location = New System.Drawing.Point(127, 95)
        Me.TLTS_DESCONTAR.Name = "TLTS_DESCONTAR"
        Me.TLTS_DESCONTAR.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_DESCONTAR.TabIndex = 585
        Me.TLTS_DESCONTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_AUTORIZADOS
        '
        Me.TLTS_AUTORIZADOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TLTS_AUTORIZADOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_AUTORIZADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_AUTORIZADOS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TLTS_AUTORIZADOS.Location = New System.Drawing.Point(127, 70)
        Me.TLTS_AUTORIZADOS.Name = "TLTS_AUTORIZADOS"
        Me.TLTS_AUTORIZADOS.Size = New System.Drawing.Size(101, 21)
        Me.TLTS_AUTORIZADOS.TabIndex = 584
        Me.TLTS_AUTORIZADOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtLTS_VALES
        '
        Me.LtLTS_VALES.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLTS_VALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLTS_VALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLTS_VALES.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLTS_VALES.Location = New System.Drawing.Point(362, 70)
        Me.LtLTS_VALES.Name = "LtLTS_VALES"
        Me.LtLTS_VALES.Size = New System.Drawing.Size(100, 21)
        Me.LtLTS_VALES.TabIndex = 569
        Me.LtLTS_VALES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPORC_TOLERANCIA
        '
        Me.TPORC_TOLERANCIA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TPORC_TOLERANCIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPORC_TOLERANCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPORC_TOLERANCIA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.TPORC_TOLERANCIA.Location = New System.Drawing.Point(127, 20)
        Me.TPORC_TOLERANCIA.Name = "TPORC_TOLERANCIA"
        Me.TPORC_TOLERANCIA.Size = New System.Drawing.Size(101, 21)
        Me.TPORC_TOLERANCIA.TabIndex = 583
        Me.TPORC_TOLERANCIA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtLTS_RALENTI
        '
        Me.LtLTS_RALENTI.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLTS_RALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLTS_RALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLTS_RALENTI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLTS_RALENTI.Location = New System.Drawing.Point(362, 45)
        Me.LtLTS_RALENTI.Name = "LtLTS_RALENTI"
        Me.LtLTS_RALENTI.Size = New System.Drawing.Size(101, 21)
        Me.LtLTS_RALENTI.TabIndex = 568
        Me.LtLTS_RALENTI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtLTS_ECM
        '
        Me.LtLTS_ECM.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLTS_ECM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLTS_ECM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLTS_ECM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLTS_ECM.Location = New System.Drawing.Point(127, 45)
        Me.LtLTS_ECM.Name = "LtLTS_ECM"
        Me.LtLTS_ECM.Size = New System.Drawing.Size(101, 21)
        Me.LtLTS_ECM.TabIndex = 567
        Me.LtLTS_ECM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(259, 48)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 16)
        Me.Label50.TabIndex = 564
        Me.Label50.Text = "Lts. Ralenti aut."
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(30, 48)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(89, 16)
        Me.Label48.TabIndex = 562
        Me.Label48.Text = "Lts. tolerancia"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(287, 73)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(68, 16)
        Me.Label46.TabIndex = 561
        Me.Label46.Text = "Lts. fisicos"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LL7
        '
        Me.LL7.AutoSize = True
        Me.LL7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL7.Location = New System.Drawing.Point(465, 123)
        Me.LL7.Name = "LL7"
        Me.LL7.Size = New System.Drawing.Size(22, 15)
        Me.LL7.TabIndex = 537
        Me.LL7.Text = "($)"
        '
        'LtDescXLitros
        '
        Me.LtDescXLitros.BackColor = System.Drawing.Color.Yellow
        Me.LtDescXLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescXLitros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescXLitros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDescXLitros.Location = New System.Drawing.Point(362, 120)
        Me.LtDescXLitros.Name = "LtDescXLitros"
        Me.LtDescXLitros.Size = New System.Drawing.Size(99, 21)
        Me.LtDescXLitros.TabIndex = 536
        Me.LtDescXLitros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L7
        '
        Me.L7.AutoSize = True
        Me.L7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L7.Location = New System.Drawing.Point(273, 123)
        Me.L7.Name = "L7"
        Me.L7.Size = New System.Drawing.Size(82, 16)
        Me.L7.TabIndex = 535
        Me.L7.Text = "Desc. x litros"
        '
        'L6
        '
        Me.L6.AutoSize = True
        Me.L6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L6.Location = New System.Drawing.Point(276, 98)
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(79, 16)
        Me.L6.TabIndex = 523
        Me.L6.Text = "Precio x litro"
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L5.Location = New System.Drawing.Point(18, 98)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(101, 16)
        Me.L5.TabIndex = 524
        Me.L5.Text = "Lts. a descontar"
        '
        'LL6
        '
        Me.LL6.AutoSize = True
        Me.LL6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL6.Location = New System.Drawing.Point(465, 98)
        Me.LL6.Name = "LL6"
        Me.LL6.Size = New System.Drawing.Size(22, 15)
        Me.LL6.TabIndex = 526
        Me.LL6.Text = "($)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(35, 23)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(84, 16)
        Me.Label45.TabIndex = 546
        Me.Label45.Text = "%Tolerancia"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LL5
        '
        Me.LL5.AutoSize = True
        Me.LL5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL5.Location = New System.Drawing.Point(231, 97)
        Me.LL5.Name = "LL5"
        Me.LL5.Size = New System.Drawing.Size(26, 15)
        Me.LL5.TabIndex = 525
        Me.LL5.Text = "Lts."
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(294, 23)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(61, 16)
        Me.Label33.TabIndex = 547
        Me.Label33.Text = "%Ralenti"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L8
        '
        Me.L8.AutoSize = True
        Me.L8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L8.Location = New System.Drawing.Point(19, 73)
        Me.L8.Name = "L8"
        Me.L8.Size = New System.Drawing.Size(100, 16)
        Me.L8.TabIndex = 528
        Me.L8.Text = "Lts. autorizados"
        '
        'LL8
        '
        Me.LL8.AutoSize = True
        Me.LL8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LL8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LL8.Location = New System.Drawing.Point(231, 73)
        Me.LL8.Name = "LL8"
        Me.LL8.Size = New System.Drawing.Size(26, 15)
        Me.LL8.TabIndex = 529
        Me.LL8.Text = "Lts."
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(201, 101)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(95, 16)
        Me.Label51.TabIndex = 338
        Me.Label51.Text = "Litros foráneos"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(198, 126)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 16)
        Me.Label23.TabIndex = 335
        Me.Label23.Text = "Litros de salida"
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt5.Location = New System.Drawing.Point(189, 51)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(107, 16)
        Me.Lt5.TabIndex = 337
        Me.Lt5.Text = "Litros de entrada"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(173, 76)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 16)
        Me.Label24.TabIndex = 336
        Me.Label24.Text = "Litros autoconsumo"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(34, 100)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(41, 16)
        Me.Nombre.TabIndex = 306
        Me.Nombre.Text = "Motor"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(251, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 16)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Fecha"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(10, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 16)
        Me.Label15.TabIndex = 308
        Me.Label15.Text = "Operador"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(33, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 16)
        Me.Label19.TabIndex = 315
        Me.Label19.Text = "Clave"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(25, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 16)
        Me.Label16.TabIndex = 309
        Me.Label16.Text = "Tractor"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(26, 169)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(145, 15)
        Me.Label17.TabIndex = 310
        Me.Label17.Text = "ODOMETRO "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(26, 194)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 15)
        Me.Label18.TabIndex = 311
        Me.Label18.Text = "KMS ECM "
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(26, 217)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(145, 15)
        Me.Label20.TabIndex = 312
        Me.Label20.Text = "LTS ECM "
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(26, 242)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 15)
        Me.Label21.TabIndex = 313
        Me.Label21.Text = "LTS FISICOS "
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(26, 265)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(145, 15)
        Me.Label22.TabIndex = 314
        Me.Label22.Text = "LITROS TABULADOR "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Pag9Casetas
        '
        Me.Pag9Casetas.Controls.Add(Me.btnGuardarCasetas)
        Me.Pag9Casetas.Controls.Add(Me.FgCasetas)
        Me.Pag9Casetas.Location = New System.Drawing.Point(1, 25)
        Me.Pag9Casetas.Name = "Pag9Casetas"
        Me.Pag9Casetas.Size = New System.Drawing.Size(1300, 297)
        Me.Pag9Casetas.TabIndex = 17
        Me.Pag9Casetas.Text = "Casetas"
        '
        'btnGuardarCasetas
        '
        Me.btnGuardarCasetas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGuardarCasetas.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarCasetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCasetas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnGuardarCasetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarCasetas.Location = New System.Drawing.Point(33, 6)
        Me.btnGuardarCasetas.Name = "btnGuardarCasetas"
        Me.btnGuardarCasetas.Size = New System.Drawing.Size(161, 23)
        Me.btnGuardarCasetas.TabIndex = 379
        Me.btnGuardarCasetas.Text = "Guardar Casetas"
        Me.btnGuardarCasetas.UseVisualStyleBackColor = True
        Me.btnGuardarCasetas.Visible = False
        '
        'FgCasetas
        '
        Me.FgCasetas.AllowFiltering = True
        Me.FgCasetas.AutoClipboard = True
        Me.FgCasetas.BackColor = System.Drawing.Color.White
        Me.FgCasetas.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.FgCasetas, Me.C1FlexGridSearchPanel1)
        Me.FgCasetas.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgCasetas.ColumnInfo = resources.GetString("FgCasetas.ColumnInfo")
        Me.FgCasetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgCasetas.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgCasetas.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgCasetas.ForeColor = System.Drawing.Color.Black
        Me.FgCasetas.Location = New System.Drawing.Point(0, 0)
        Me.FgCasetas.Name = "FgCasetas"
        Me.FgCasetas.Rows.DefaultSize = 19
        Me.FgCasetas.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgCasetas.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgCasetas.Size = New System.Drawing.Size(1300, 297)
        Me.FgCasetas.StyleInfo = resources.GetString("FgCasetas.StyleInfo")
        Me.FgCasetas.TabIndex = 8
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(26, 78)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(124, 15)
        Me.Lt1.TabIndex = 232
        Me.Lt1.Text = "Gastos comprobados"
        '
        'LtGastosComprobados
        '
        Me.LtGastosComprobados.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtGastosComprobados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGastosComprobados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGastosComprobados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtGastosComprobados.Location = New System.Drawing.Point(156, 75)
        Me.LtGastosComprobados.Name = "LtGastosComprobados"
        Me.LtGastosComprobados.Size = New System.Drawing.Size(115, 20)
        Me.LtGastosComprobados.TabIndex = 232
        Me.LtGastosComprobados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitMult
        '
        Me.SplitMult.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitMult.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitMult.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitMult.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMult.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitMult.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitMult.HeaderLineWidth = 1
        Me.SplitMult.Location = New System.Drawing.Point(27, 80)
        Me.SplitMult.Name = "SplitMult"
        Me.SplitMult.Panels.Add(Me.SplitMult1)
        Me.SplitMult.Panels.Add(Me.SplitMult2)
        Me.SplitMult.Panels.Add(Me.SplitMult3)
        Me.SplitMult.Size = New System.Drawing.Size(1324, 635)
        Me.SplitMult.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMult.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitMult.TabIndex = 262
        Me.SplitMult.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitMult.UseParentVisualStyle = False
        '
        'SplitMult1
        '
        Me.SplitMult1.AutoScroll = True
        Me.SplitMult1.BackColor = System.Drawing.Color.Transparent
        Me.SplitMult1.BorderColor = System.Drawing.Color.Black
        Me.SplitMult1.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.SplitMult1.Controls.Add(Me.TBOTONMAGICO_PA)
        Me.SplitMult1.Controls.Add(Me.BtnReset)
        Me.SplitMult1.Controls.Add(Me.Label3)
        Me.SplitMult1.Controls.Add(Me.TCVE_RES)
        Me.SplitMult1.Controls.Add(Me.Label27)
        Me.SplitMult1.Controls.Add(Me.Label1)
        Me.SplitMult1.Controls.Add(Me.TCVE_LIQ)
        Me.SplitMult1.Controls.Add(Me.LtUnidad)
        Me.SplitMult1.Controls.Add(Me.F1)
        Me.SplitMult1.Controls.Add(Me.BtnUnidad)
        Me.SplitMult1.Controls.Add(Me.LtTipoCrobro)
        Me.SplitMult1.Controls.Add(Me.TCVE_TRACTOR)
        Me.SplitMult1.Controls.Add(Me.Label4)
        Me.SplitMult1.Controls.Add(Me.Label5)
        Me.SplitMult1.Controls.Add(Me.TCVE_OPER)
        Me.SplitMult1.Controls.Add(Me.Label2)
        Me.SplitMult1.Controls.Add(Me.BtnOper)
        Me.SplitMult1.Controls.Add(Me.LtOper)
        Me.SplitMult1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitMult1.Height = 95
        Me.SplitMult1.Location = New System.Drawing.Point(0, 0)
        Me.SplitMult1.Name = "SplitMult1"
        Me.SplitMult1.ShowCloseButton = True
        Me.SplitMult1.Size = New System.Drawing.Size(1324, 95)
        Me.SplitMult1.SizeRatio = 15.0R
        Me.SplitMult1.TabIndex = 0
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(969, 7)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(248, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 378
        Me.C1FlexGridSearchPanel1.Visible = False
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'TBOTONMAGICO_PA
        '
        Me.TBOTONMAGICO_PA.AcceptsReturn = True
        Me.TBOTONMAGICO_PA.AcceptsTab = True
        Me.TBOTONMAGICO_PA.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBOTONMAGICO_PA.ForeColor = System.Drawing.Color.Black
        Me.TBOTONMAGICO_PA.Location = New System.Drawing.Point(996, 27)
        Me.TBOTONMAGICO_PA.Name = "TBOTONMAGICO_PA"
        Me.TBOTONMAGICO_PA.Size = New System.Drawing.Size(93, 20)
        Me.TBOTONMAGICO_PA.TabIndex = 377
        Me.TBOTONMAGICO_PA.Visible = False
        '
        'BtnReset
        '
        Me.BtnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnReset.BackColor = System.Drawing.Color.Transparent
        Me.BtnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnReset.Image = CType(resources.GetObject("BtnReset.Image"), System.Drawing.Image)
        Me.BtnReset.Location = New System.Drawing.Point(770, 23)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(24, 23)
        Me.BtnReset.TabIndex = 238
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnUnidad
        '
        Me.BtnUnidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnUnidad.BackColor = System.Drawing.Color.Transparent
        Me.BtnUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnUnidad.Image = CType(resources.GetObject("BtnUnidad.Image"), System.Drawing.Image)
        Me.BtnUnidad.Location = New System.Drawing.Point(379, 48)
        Me.BtnUnidad.Name = "BtnUnidad"
        Me.BtnUnidad.Size = New System.Drawing.Size(24, 23)
        Me.BtnUnidad.TabIndex = 234
        Me.BtnUnidad.UseVisualStyleBackColor = True
        '
        'BtnOper
        '
        Me.BtnOper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnOper.BackColor = System.Drawing.Color.Transparent
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(379, 21)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(24, 23)
        Me.BtnOper.TabIndex = 225
        Me.BtnOper.UseVisualStyleBackColor = True
        '
        'SplitMult2
        '
        Me.SplitMult2.AutoScroll = True
        Me.SplitMult2.BorderColor = System.Drawing.Color.Black
        Me.SplitMult2.BorderWidth = 1
        Me.SplitMult2.Controls.Add(Me.Tab1)
        Me.SplitMult2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitMult2.ForeColor = System.Drawing.Color.White
        Me.SplitMult2.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitMult2.HeaderForeColor = System.Drawing.Color.White
        Me.SplitMult2.HeaderLineColor = System.Drawing.Color.Black
        Me.SplitMult2.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center
        Me.SplitMult2.Height = 346
        Me.SplitMult2.Location = New System.Drawing.Point(1, 100)
        Me.SplitMult2.Name = "SplitMult2"
        Me.SplitMult2.Size = New System.Drawing.Size(1322, 344)
        Me.SplitMult2.SizeRatio = 65.0R
        Me.SplitMult2.TabIndex = 1
        '
        'SplitMult3
        '
        Me.SplitMult3.AutoScroll = True
        Me.SplitMult3.BorderColor = System.Drawing.Color.Black
        Me.SplitMult3.Controls.Add(Me.Label36)
        Me.SplitMult3.Controls.Add(Me.LtLotaLts)
        Me.SplitMult3.Controls.Add(Me.Label34)
        Me.SplitMult3.Controls.Add(Me.LtLtsEfectivo)
        Me.SplitMult3.Controls.Add(Me.BtnImporteLiquidar)
        Me.SplitMult3.Controls.Add(Me.BtnSubTotal)
        Me.SplitMult3.Controls.Add(Me.BtnDifCompro)
        Me.SplitMult3.Controls.Add(Me.BtnToTPercep)
        Me.SplitMult3.Controls.Add(Me.Lm4)
        Me.SplitMult3.Controls.Add(Me.BtnOTrasPercep)
        Me.SplitMult3.Controls.Add(Me.Label29)
        Me.SplitMult3.Controls.Add(Me.LtPA)
        Me.SplitMult3.Controls.Add(Me.Label25)
        Me.SplitMult3.Controls.Add(Me.LtLitros)
        Me.SplitMult3.Controls.Add(Me.Lt1)
        Me.SplitMult3.Controls.Add(Me.LtGastosComprobados)
        Me.SplitMult3.Controls.Add(Me.Label11)
        Me.SplitMult3.Controls.Add(Me.LtImporteLiquidar)
        Me.SplitMult3.Controls.Add(Me.Label9)
        Me.SplitMult3.Controls.Add(Me.LtValesCombustible)
        Me.SplitMult3.Controls.Add(Me.Lt2)
        Me.SplitMult3.Controls.Add(Me.LtGastosDeViaje)
        Me.SplitMult3.Controls.Add(Me.Label7)
        Me.SplitMult3.Controls.Add(Me.LtDifCompro)
        Me.SplitMult3.Controls.Add(Me.Label14)
        Me.SplitMult3.Controls.Add(Me.LtTotalPercep)
        Me.SplitMult3.Controls.Add(Me.Label12)
        Me.SplitMult3.Controls.Add(Me.LtOtrasPercep)
        Me.SplitMult3.Controls.Add(Me.Label10)
        Me.SplitMult3.Controls.Add(Me.LtSubtotal)
        Me.SplitMult3.Controls.Add(Me.Label8)
        Me.SplitMult3.Controls.Add(Me.LtTotDeduc)
        Me.SplitMult3.Controls.Add(Me.Label6)
        Me.SplitMult3.Controls.Add(Me.LtPerXViaje)
        Me.SplitMult3.Height = 186
        Me.SplitMult3.Location = New System.Drawing.Point(0, 449)
        Me.SplitMult3.Name = "SplitMult3"
        Me.SplitMult3.Size = New System.Drawing.Size(1324, 186)
        Me.SplitMult3.SizeRatio = 20.0R
        Me.SplitMult3.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(335, 77)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(63, 15)
        Me.Label36.TabIndex = 295
        Me.Label36.Text = "Total litros"
        '
        'LtLotaLts
        '
        Me.LtLotaLts.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLotaLts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLotaLts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLotaLts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLotaLts.Location = New System.Drawing.Point(403, 74)
        Me.LtLotaLts.Name = "LtLotaLts"
        Me.LtLotaLts.Size = New System.Drawing.Size(115, 20)
        Me.LtLotaLts.TabIndex = 294
        Me.LtLotaLts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(317, 30)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(81, 15)
        Me.Label34.TabIndex = 293
        Me.Label34.Text = "Litros efectivo"
        '
        'LtLtsEfectivo
        '
        Me.LtLtsEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLtsEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLtsEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLtsEfectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLtsEfectivo.Location = New System.Drawing.Point(403, 27)
        Me.LtLtsEfectivo.Name = "LtLtsEfectivo"
        Me.LtLtsEfectivo.Size = New System.Drawing.Size(115, 20)
        Me.LtLtsEfectivo.TabIndex = 292
        Me.LtLtsEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnImporteLiquidar
        '
        Me.BtnImporteLiquidar.Location = New System.Drawing.Point(831, 100)
        Me.BtnImporteLiquidar.Name = "BtnImporteLiquidar"
        Me.BtnImporteLiquidar.Size = New System.Drawing.Size(25, 20)
        Me.BtnImporteLiquidar.TabIndex = 291
        Me.BtnImporteLiquidar.Text = "....."
        Me.BtnImporteLiquidar.UseVisualStyleBackColor = True
        '
        'BtnSubTotal
        '
        Me.BtnSubTotal.Location = New System.Drawing.Point(831, 76)
        Me.BtnSubTotal.Name = "BtnSubTotal"
        Me.BtnSubTotal.Size = New System.Drawing.Size(25, 20)
        Me.BtnSubTotal.TabIndex = 290
        Me.BtnSubTotal.Text = "....."
        Me.BtnSubTotal.UseVisualStyleBackColor = True
        '
        'BtnDifCompro
        '
        Me.BtnDifCompro.Location = New System.Drawing.Point(831, 53)
        Me.BtnDifCompro.Name = "BtnDifCompro"
        Me.BtnDifCompro.Size = New System.Drawing.Size(25, 20)
        Me.BtnDifCompro.TabIndex = 289
        Me.BtnDifCompro.Text = "....."
        Me.BtnDifCompro.UseVisualStyleBackColor = True
        '
        'BtnToTPercep
        '
        Me.BtnToTPercep.Location = New System.Drawing.Point(831, 28)
        Me.BtnToTPercep.Name = "BtnToTPercep"
        Me.BtnToTPercep.Size = New System.Drawing.Size(25, 20)
        Me.BtnToTPercep.TabIndex = 288
        Me.BtnToTPercep.Text = "....."
        Me.BtnToTPercep.UseVisualStyleBackColor = True
        '
        'Lm4
        '
        Me.Lm4.AutoSize = True
        Me.Lm4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lm4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lm4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lm4.Location = New System.Drawing.Point(19, 143)
        Me.Lm4.Name = "Lm4"
        Me.Lm4.Size = New System.Drawing.Size(28, 15)
        Me.Lm4.TabIndex = 287
        Me.Lm4.Text = "___"
        Me.Lm4.Visible = False
        '
        'BtnOTrasPercep
        '
        Me.BtnOTrasPercep.Location = New System.Drawing.Point(831, 6)
        Me.BtnOTrasPercep.Name = "BtnOTrasPercep"
        Me.BtnOTrasPercep.Size = New System.Drawing.Size(25, 20)
        Me.BtnOTrasPercep.TabIndex = 286
        Me.BtnOTrasPercep.Text = "....."
        Me.BtnOTrasPercep.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(283, 101)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 15)
        Me.Label29.TabIndex = 284
        Me.Label29.Text = "Pensión alimenticia"
        '
        'LtPA
        '
        Me.LtPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPA.Location = New System.Drawing.Point(403, 98)
        Me.LtPA.Name = "LtPA"
        Me.LtPA.Size = New System.Drawing.Size(115, 20)
        Me.LtPA.TabIndex = 285
        Me.LtPA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(330, 55)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 15)
        Me.Label25.TabIndex = 283
        Me.Label25.Text = "Litros vales"
        '
        'LtLitros
        '
        Me.LtLitros.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLitros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLitros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLitros.Location = New System.Drawing.Point(403, 52)
        Me.LtLitros.Name = "LtLitros"
        Me.LtLitros.Size = New System.Drawing.Size(115, 20)
        Me.LtLitros.TabIndex = 282
        Me.LtLitros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(604, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 280
        Me.Label11.Text = "Importe a liquidar"
        '
        'LtImporteLiquidar
        '
        Me.LtImporteLiquidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtImporteLiquidar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporteLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporteLiquidar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtImporteLiquidar.Location = New System.Drawing.Point(710, 98)
        Me.LtImporteLiquidar.Name = "LtImporteLiquidar"
        Me.LtImporteLiquidar.Size = New System.Drawing.Size(115, 20)
        Me.LtImporteLiquidar.TabIndex = 279
        Me.LtImporteLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(26, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 15)
        Me.Label9.TabIndex = 278
        Me.Label9.Text = "Vales de combustible"
        '
        'LtValesCombustible
        '
        Me.LtValesCombustible.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtValesCombustible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtValesCombustible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtValesCombustible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtValesCombustible.Location = New System.Drawing.Point(156, 52)
        Me.LtValesCombustible.Name = "LtValesCombustible"
        Me.LtValesCombustible.Size = New System.Drawing.Size(115, 20)
        Me.LtValesCombustible.TabIndex = 277
        Me.LtValesCombustible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt2.Location = New System.Drawing.Point(32, 32)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(118, 15)
        Me.Lt2.TabIndex = 235
        Me.Lt2.Text = "Total gastos de viaje"
        '
        'LtGastosDeViaje
        '
        Me.LtGastosDeViaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtGastosDeViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGastosDeViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGastosDeViaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtGastosDeViaje.Location = New System.Drawing.Point(156, 29)
        Me.LtGastosDeViaje.Name = "LtGastosDeViaje"
        Me.LtGastosDeViaje.Size = New System.Drawing.Size(115, 20)
        Me.LtGastosDeViaje.TabIndex = 233
        Me.LtGastosDeViaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(583, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 15)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "Dif. de comprobación"
        '
        'LtDifCompro
        '
        Me.LtDifCompro.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtDifCompro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDifCompro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDifCompro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDifCompro.Location = New System.Drawing.Point(710, 52)
        Me.LtDifCompro.Name = "LtDifCompro"
        Me.LtDifCompro.Size = New System.Drawing.Size(115, 20)
        Me.LtDifCompro.TabIndex = 270
        Me.LtDifCompro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(596, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 15)
        Me.Label14.TabIndex = 269
        Me.Label14.Text = "Total percepciones"
        '
        'LtTotalPercep
        '
        Me.LtTotalPercep.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTotalPercep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotalPercep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotalPercep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTotalPercep.Location = New System.Drawing.Point(710, 29)
        Me.LtTotalPercep.Name = "LtTotalPercep"
        Me.LtTotalPercep.Size = New System.Drawing.Size(115, 20)
        Me.LtTotalPercep.TabIndex = 268
        Me.LtTotalPercep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(594, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 15)
        Me.Label12.TabIndex = 267
        Me.Label12.Text = "Otras percepciones"
        '
        'LtOtrasPercep
        '
        Me.LtOtrasPercep.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtOtrasPercep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOtrasPercep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOtrasPercep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtOtrasPercep.Location = New System.Drawing.Point(710, 6)
        Me.LtOtrasPercep.Name = "LtOtrasPercep"
        Me.LtOtrasPercep.Size = New System.Drawing.Size(115, 20)
        Me.LtOtrasPercep.TabIndex = 266
        Me.LtOtrasPercep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(655, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 265
        Me.Label10.Text = "Subtotal"
        '
        'LtSubtotal
        '
        Me.LtSubtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSubtotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSubtotal.Location = New System.Drawing.Point(710, 75)
        Me.LtSubtotal.Name = "LtSubtotal"
        Me.LtSubtotal.Size = New System.Drawing.Size(115, 20)
        Me.LtSubtotal.TabIndex = 264
        Me.LtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(49, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 15)
        Me.Label8.TabIndex = 263
        Me.Label8.Text = "Total deduciones"
        '
        'LtTotDeduc
        '
        Me.LtTotDeduc.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTotDeduc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotDeduc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTotDeduc.Location = New System.Drawing.Point(156, 98)
        Me.LtTotDeduc.Name = "LtTotDeduc"
        Me.LtTotDeduc.Size = New System.Drawing.Size(115, 20)
        Me.LtTotDeduc.TabIndex = 262
        Me.LtTotDeduc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(19, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 15)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "Percepciones por viaje"
        '
        'LtPerXViaje
        '
        Me.LtPerXViaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPerXViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPerXViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPerXViaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPerXViaje.Location = New System.Drawing.Point(156, 6)
        Me.LtPerXViaje.Name = "LtPerXViaje"
        Me.LtPerXViaje.Size = New System.Drawing.Size(115, 20)
        Me.LtPerXViaje.TabIndex = 239
        Me.LtPerXViaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBotonMagicoD
        '
        Me.TBotonMagicoD.AcceptsReturn = True
        Me.TBotonMagicoD.AcceptsTab = True
        Me.TBotonMagicoD.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBotonMagicoD.ForeColor = System.Drawing.Color.Black
        Me.TBotonMagicoD.Location = New System.Drawing.Point(927, 29)
        Me.TBotonMagicoD.Name = "TBotonMagicoD"
        Me.TBotonMagicoD.Size = New System.Drawing.Size(93, 20)
        Me.TBotonMagicoD.TabIndex = 376
        '
        'TABONAR
        '
        Me.TABONAR.AcceptsReturn = True
        Me.TABONAR.AcceptsTab = True
        Me.TABONAR.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TABONAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TABONAR.CustomFormat = "###,###,##0.0000"
        Me.TABONAR.DataType = GetType(Decimal)
        Me.TABONAR.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TABONAR.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TABONAR.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TABONAR.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TABONAR.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TABONAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TABONAR.Location = New System.Drawing.Point(593, 11)
        Me.TABONAR.Name = "TABONAR"
        Me.TABONAR.Size = New System.Drawing.Size(100, 19)
        Me.TABONAR.TabIndex = 2
        Me.TABONAR.Tag = Nothing
        Me.TABONAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TABONAR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TBotonMagico
        '
        Me.TBotonMagico.AcceptsReturn = True
        Me.TBotonMagico.AcceptsTab = True
        Me.TBotonMagico.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBotonMagico.ForeColor = System.Drawing.Color.Black
        Me.TBotonMagico.Location = New System.Drawing.Point(927, 12)
        Me.TBotonMagico.Name = "TBotonMagico"
        Me.TBotonMagico.Size = New System.Drawing.Size(53, 20)
        Me.TBotonMagico.TabIndex = 375
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "1f539fdfc8dd4bfe862e2cec9005fd1e"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'tMagic
        '
        Me.tMagic.ForeColor = System.Drawing.Color.Black
        Me.tMagic.Location = New System.Drawing.Point(927, 29)
        Me.tMagic.Name = "tMagic"
        Me.tMagic.Size = New System.Drawing.Size(100, 20)
        Me.tMagic.TabIndex = 239
        '
        'TOBSER
        '
        Me.TOBSER.ForeColor = System.Drawing.Color.Black
        Me.TOBSER.Location = New System.Drawing.Point(710, 12)
        Me.TOBSER.Name = "TOBSER"
        Me.TOBSER.Size = New System.Drawing.Size(100, 20)
        Me.TOBSER.TabIndex = 3
        '
        'FrmLiquidacionesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 762)
        Me.Controls.Add(Me.SplitMult)
        Me.Controls.Add(Me.BarMenu)
        Me.Controls.Add(Me.TBotonMagico)
        Me.Controls.Add(Me.tMagic)
        Me.Controls.Add(Me.TABONAR)
        Me.Controls.Add(Me.TOBSER)
        Me.Controls.Add(Me.TBotonMagicoD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLiquidacionesAE"
        Me.ShowInTaskbar = False
        Me.Text = "Liquidaciones"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Page1.ResumeLayout(False)
        Me.Page2.ResumeLayout(False)
        CType(Me.SplitG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitG.ResumeLayout(False)
        Me.SplitG1.ResumeLayout(False)
        CType(Me.BtnGastosViajeEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGastosViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitG2.ResumeLayout(False)
        CType(Me.FgG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page3.ResumeLayout(False)
        CType(Me.FgV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page4.ResumeLayout(False)
        CType(Me.SplitGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitGasto.ResumeLayout(False)
        Me.SplitGasto3.ResumeLayout(False)
        CType(Me.BtnAddGC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminarGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitGasto1.ResumeLayout(False)
        CType(Me.FgGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page6.ResumeLayout(False)
        CType(Me.SplitDedM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDedM.ResumeLayout(False)
        Me.SplitDedM1.ResumeLayout(False)
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAddDec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDedM2.ResumeLayout(False)
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag8.ResumeLayout(False)
        CType(Me.SplitPension, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPension.ResumeLayout(False)
        Me.SplitPension1.ResumeLayout(False)
        CType(Me.BtnEliPartPA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAltaPA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPension2.ResumeLayout(False)
        CType(Me.FgPA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page5.ResumeLayout(False)
        Me.Page5.PerformLayout()
        Me.Pag7.ResumeLayout(False)
        Me.Pag7.PerformLayout()
        Me.GpoCamposAdic.ResumeLayout(False)
        Me.GpoCamposAdic.PerformLayout()
        Me.GpoEvento2.ResumeLayout(False)
        Me.GpoEvento2.PerformLayout()
        CType(Me.TLTS_DESCONTAR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPRECIO_X_LTS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLTS_AUTORIZADOS2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpoEvento1.ResumeLayout(False)
        Me.GpoEvento1.PerformLayout()
        Me.Pag9Casetas.ResumeLayout(False)
        CType(Me.FgCasetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitMult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMult.ResumeLayout(False)
        Me.SplitMult1.ResumeLayout(False)
        Me.SplitMult1.PerformLayout()
        Me.SplitMult2.ResumeLayout(False)
        Me.SplitMult3.ResumeLayout(False)
        Me.SplitMult3.PerformLayout()
        CType(Me.TABONAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents TCVE_LIQ As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents LtTipoCrobro As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents BtnOper As Button
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Page2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Page3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Page5 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgG As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents FgD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TOBS As TextBox
    Friend WithEvents Page4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents SplitMult As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitMult1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitMult2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitMult3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarDesplegar As ToolStripMenuItem
    Friend WithEvents LtGastosDeViaje As Label
    Friend WithEvents LtGastosComprobados As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents FgV As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtUnidad As Label
    Friend WithEvents BtnUnidad As Button
    Friend WithEvents TCVE_TRACTOR As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Page1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Page6 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BtnReset As Button
    Friend WithEvents TCVE_RES As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BarImprimirResteo As ToolStripMenuItem
    Friend WithEvents BarImprimirLiq As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Label14 As Label
    Friend WithEvents LtTotalPercep As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LtOtrasPercep As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LtSubtotal As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LtTotDeduc As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtPerXViaje As Label
    Friend WithEvents BtnEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAddDec As C1.Win.C1Input.C1Button
    Friend WithEvents SplitDedM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitDedM1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitDedM2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitGasto As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Label7 As Label
    Friend WithEvents LtDifCompro As Label
    Friend WithEvents SplitGasto3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BtnEliminarGasto As C1.Win.C1Input.C1Button
    Friend WithEvents Label9 As Label
    Friend WithEvents LtValesCombustible As Label
    Friend WithEvents BtnAddGC As C1.Win.C1Input.C1Button
    Friend WithEvents BarFinalizarLiq As ToolStripMenuItem
    Friend WithEvents Label11 As Label
    Friend WithEvents LtImporteLiquidar As Label
    Friend WithEvents TBotonMagico As TextBox
    Friend WithEvents SplitGasto1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents FgGC As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarCancelacion As ToolStripMenuItem
    Friend WithEvents TOBSER As TextBoxEx
    Friend WithEvents TABONAR As C1.Win.C1Input.C1TextBox
    Friend WithEvents tMagic As TextBoxEx
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents SplitG As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitG1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitG2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BtnGastosViaje As C1.Win.C1Input.C1Button
    Friend WithEvents BtnGastosViajeEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents TBotonMagicoD As TextBox
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Pag7 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Nombre As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Lt5 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents GpoEvento1 As GroupBox
    Friend WithEvents LtLTS_VALES As Label
    Friend WithEvents LtLTS_RALENTI As Label
    Friend WithEvents LtLTS_ECM As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents LL7 As Label
    Friend WithEvents LtDescXLitros As Label
    Friend WithEvents L7 As Label
    Friend WithEvents L6 As Label
    Friend WithEvents L5 As Label
    Friend WithEvents LL6 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents LL5 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents L8 As Label
    Friend WithEvents LL8 As Label
    Friend WithEvents GpoCamposAdic As GroupBox
    Friend WithEvents LL10 As Label
    Friend WithEvents L10 As Label
    Friend WithEvents L3 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents L4 As Label
    Friend WithEvents LL3 As Label
    Friend WithEvents LL1 As Label
    Friend WithEvents LL4 As Label
    Friend WithEvents L11 As Label
    Friend WithEvents LL9 As Label
    Friend WithEvents L9 As Label
    Friend WithEvents TLTS_SALIDA As Label
    Friend WithEvents TLTS_TAB As Label
    Friend WithEvents TLTS_FORANEOS As Label
    Friend WithEvents TLTS_VALES As Label
    Friend WithEvents TLTS_LLEGADA As Label
    Friend WithEvents TFECHA As Label
    Friend WithEvents TLTS_REAL As Label
    Friend WithEvents TLTS_ECM As Label
    Friend WithEvents TKM_ECM As Label
    Friend WithEvents TODOMETRO As Label
    Friend WithEvents TCVE_MOT As Label
    Friend WithEvents TCVE_TRACTOR2 As Label
    Friend WithEvents TCVE_OPER2 As Label
    Friend WithEvents TCVE_RES2 As Label
    Friend WithEvents TVELMAX As Label
    Friend WithEvents TTIEMPO_MARCH_INERCIA As Label
    Friend WithEvents TCALIF As Label
    Friend WithEvents TDESCT As Label
    Friend WithEvents TLTS_DESCONTAR As Label
    Friend WithEvents TLTS_AUTORIZADOS As Label
    Friend WithEvents TPORC_TOLERANCIA As Label
    Friend WithEvents TPRECIO_X_LTS As Label
    Friend WithEvents TPORC_RALENTI As Label
    Friend WithEvents TCARGO_X_PUNTO_MUERTO As Label
    Friend WithEvents TLITROS_UREA As Label
    Friend WithEvents TLTS_UREA_REAL As Label
    Friend WithEvents GpoEvento2 As GroupBox
    Friend WithEvents RadLTS_TAB As RadioButton
    Friend WithEvents RadLTS_ECM As RadioButton
    Friend WithEvents Label72 As Label
    Friend WithEvents LtLTS_VALES2 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents TLTS_DESCONTAR2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TPRECIO_X_LTS2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents TLTS_AUTORIZADOS2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents LtDescXLitros2 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents LtLitros As Label
    Friend WithEvents Pag8 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents SplitPension As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitPension1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BtnEliPartPA As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAltaPA As C1.Win.C1Input.C1Button
    Friend WithEvents SplitPension2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents FgPA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label29 As Label
    Friend WithEvents LtPA As Label
    Friend WithEvents TBOTONMAGICO_PA As TextBox
    Friend WithEvents BtnOTrasPercep As Button
    Friend WithEvents Lm4 As Label
    Friend WithEvents BtnToTPercep As Button
    Friend WithEvents BtnDifCompro As Button
    Friend WithEvents BtnSubTotal As Button
    Friend WithEvents BtnImporteLiquidar As Button
    Friend WithEvents BarReseteo As ToolStripMenuItem
    Friend WithEvents Label36 As Label
    Friend WithEvents LtLotaLts As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents LtLtsEfectivo As Label
    Friend WithEvents Pag9Casetas As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgCasetas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnGuardarCasetas As Button
End Class
