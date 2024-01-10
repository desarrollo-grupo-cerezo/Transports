<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClientesAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGrabarYSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmEstadoCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEstadoCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.TCLAVE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TNOMBRE = New System.Windows.Forms.TextBox()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.PAG1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.BtnApli = New C1.Win.C1Input.C1Button()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.TAPLICACION = New System.Windows.Forms.TextBox()
        Me.BtnMetodoPago = New C1.Win.C1Input.C1Button()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.LtUsoCFDI = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TDIAREV = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TDIAPAGO = New System.Windows.Forms.TextBox()
        Me.TDiasCred = New C1.Win.C1Input.C1NumericEdit()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TLimCred = New C1.Win.C1Input.C1NumericEdit()
        Me.chCON_CREDITO = New C1.Win.C1Input.C1CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LtSaldo = New System.Windows.Forms.Label()
        Me.TCUENTA_CONTABLE = New System.Windows.Forms.TextBox()
        Me.TUSO_CFDI = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BtnListaPrec = New C1.Win.C1Input.C1Button()
        Me.TCVE_VEND = New System.Windows.Forms.TextBox()
        Me.TLISTA_PREC = New System.Windows.Forms.TextBox()
        Me.BtnVend = New C1.Win.C1Input.C1Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnUsoCFDI = New C1.Win.C1Input.C1Button()
        Me.LtVend = New System.Windows.Forms.Label()
        Me.TMETODODEPAGO = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.BtnPagoSAT = New C1.Win.C1Input.C1Button()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.tDESCUENTO = New C1.Win.C1Input.C1NumericEdit()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TNUMCTAPAGO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TFORMADEPAGOSAT = New System.Windows.Forms.TextBox()
        Me.TFax = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TTELEFONO = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TALIAS = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BtnCP = New C1.Win.C1Input.C1Button()
        Me.BtnEstado = New C1.Win.C1Input.C1Button()
        Me.BtnLocalidad = New C1.Win.C1Input.C1Button()
        Me.BtnMunicipio = New C1.Win.C1Input.C1Button()
        Me.BtnColonia = New C1.Win.C1Input.C1Button()
        Me.LtMX = New System.Windows.Forms.Label()
        Me.TNUM_MON = New C1.Win.C1Input.C1NumericEdit()
        Me.BtnMoneda = New C1.Win.C1Input.C1Button()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.BtnPais = New C1.Win.C1Input.C1Button()
        Me.LtMoneda = New System.Windows.Forms.Label()
        Me.TPAIS_SAT = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.TCVE_ESQIMPU = New C1.Win.C1Input.C1NumericEdit()
        Me.BtnEsquema = New C1.Win.C1Input.C1Button()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.LtEsquema = New System.Windows.Forms.Label()
        Me.TESTADO_SAT = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.TFLETE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.TNOMBRECOMERCIAL = New System.Windows.Forms.TextBox()
        Me.LtRegFis = New System.Windows.Forms.Label()
        Me.BtnRFC = New C1.Win.C1Input.C1Button()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.TLOCALIDAD_SAT = New System.Windows.Forms.TextBox()
        Me.BtnRegimenFiscal = New C1.Win.C1Input.C1Button()
        Me.TMUNICIPIO_SAT = New System.Windows.Forms.TextBox()
        Me.TREGIMEN_FISCAL = New System.Windows.Forms.TextBox()
        Me.TCRUZAMIENTOS2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCALLE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TRFC = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TCRUZAMIENTOS = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TCOLONIA_SAT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TMunicipio = New System.Windows.Forms.TextBox()
        Me.TCURP = New System.Windows.Forms.TextBox()
        Me.TNumInt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TNumExt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TPais = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TCODIGO = New System.Windows.Forms.TextBox()
        Me.TLOCALIDAD = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TCOLONIA = New System.Windows.Forms.TextBox()
        Me.TEstado = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.PAG2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GpoDatosEnvio = New System.Windows.Forms.GroupBox()
        Me.TCALLE_ENVIO = New System.Windows.Forms.TextBox()
        Me.tZonaEnvio = New System.Windows.Forms.Label()
        Me.TCOLONIA_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.TCRUZAMIENTOS_ENVIO2 = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.LtZonaEnvio = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.TMUNICIPIO_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TESTADO_ENVIO = New System.Windows.Forms.TextBox()
        Me.TNUMEXT_ENVIO = New System.Windows.Forms.TextBox()
        Me.BtnZonaEnvio = New C1.Win.C1Input.C1Button()
        Me.TCRUZAMIENTOS_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TREFERENCIA_ENVIO = New System.Windows.Forms.TextBox()
        Me.TLOCALIDAD_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TCODIGO_ENVIO = New System.Windows.Forms.TextBox()
        Me.TCVE_ZONA_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TPAIS_ENVIO = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.TNUMINT_ENVIO = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New C1.Win.C1Input.C1Button()
        Me.btnAgregar = New C1.Win.C1Input.C1Button()
        Me.BtnBancos = New C1.Win.C1Input.C1Button()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TRFCFiscal = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TBancoFiscal = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TCtaBanFiscal = New System.Windows.Forms.TextBox()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TCVE_OBS = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.BtnPaisResiFiscal = New C1.Win.C1Input.C1Button()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.T = New System.Windows.Forms.TextBox()
        Me.TCVE_PAIS_SAT = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.C1Button1 = New C1.Win.C1Input.C1Button()
        Me.TNUMIDREGFISCAL = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.PAG4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FgL = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.PAG3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.TCOLAI = New System.Windows.Forms.TextBox()
        Me.TCOLAC = New System.Windows.Forms.TextBox()
        Me.TCOLAG = New System.Windows.Forms.TextBox()
        Me.TCOLAH = New System.Windows.Forms.TextBox()
        Me.TCOLAF = New System.Windows.Forms.TextBox()
        Me.TCOLAJ = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.TCOLAE = New System.Windows.Forms.TextBox()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.TCOLAD = New System.Windows.Forms.TextBox()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.TCOLU = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.TCOLAB = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.TCOLO = New System.Windows.Forms.TextBox()
        Me.TCOLS = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.TCOLT = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.TCOLAA = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.TCOLR = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TCOLV = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.TCOLZ = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.TCOLQ = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.TCOLW = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.TCOLY = New System.Windows.Forms.TextBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.TCOLP = New System.Windows.Forms.TextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.TCOLX = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.TCOLN = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Lt14 = New System.Windows.Forms.Label()
        Me.TCOLM = New System.Windows.Forms.TextBox()
        Me.Lt13 = New System.Windows.Forms.Label()
        Me.TCOLA = New System.Windows.Forms.TextBox()
        Me.TCOLE = New System.Windows.Forms.TextBox()
        Me.Lt12 = New System.Windows.Forms.Label()
        Me.TCOLF = New System.Windows.Forms.TextBox()
        Me.Lt11 = New System.Windows.Forms.Label()
        Me.TCOLL = New System.Windows.Forms.TextBox()
        Me.Lt10 = New System.Windows.Forms.Label()
        Me.TCOLD = New System.Windows.Forms.TextBox()
        Me.Lt9 = New System.Windows.Forms.Label()
        Me.TCOLG = New System.Windows.Forms.TextBox()
        Me.Lt8 = New System.Windows.Forms.Label()
        Me.TCOLK = New System.Windows.Forms.TextBox()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCOLC = New System.Windows.Forms.TextBox()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.TCOLH = New System.Windows.Forms.TextBox()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.TCOLJ = New System.Windows.Forms.TextBox()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.TCOLB = New System.Windows.Forms.TextBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.TCOLI = New System.Windows.Forms.TextBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.FCH_ULTCOM = New C1.Win.Calendar.C1DateEdit()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.ULT_PAGOF = New C1.Win.Calendar.C1DateEdit()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TULT_VENTAD = New System.Windows.Forms.TextBox()
        Me.TULT_COMPM = New C1.Win.C1Input.C1NumericEdit()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TULT_PAGOD = New System.Windows.Forms.TextBox()
        Me.ChCPPesoKg = New C1.Win.C1Input.C1CheckBox()
        Me.TULT_PAGOM = New C1.Win.C1Input.C1NumericEdit()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TVENTAS = New C1.Win.C1Input.C1NumericEdit()
        Me.chImprir = New C1.Win.C1Input.C1CheckBox()
        Me.TEMAILPRED = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.chMail = New C1.Win.C1Input.C1CheckBox()
        Me.LMatriz = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BtnMatriz = New C1.Win.C1Input.C1Button()
        Me.TMODELO = New System.Windows.Forms.TextBox()
        Me.TMATRIZ = New System.Windows.Forms.TextBox()
        Me.BtnDocModelo = New C1.Win.C1Input.C1Button()
        Me.LtMatriz = New System.Windows.Forms.Label()
        Me.radSuc = New System.Windows.Forms.RadioButton()
        Me.radMatriz = New System.Windows.Forms.RadioButton()
        Me.LtZona = New System.Windows.Forms.Label()
        Me.BtnZona = New C1.Win.C1Input.C1Button()
        Me.TCVE_ZONA = New System.Windows.Forms.TextBox()
        Me.TPAG_WEB = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtImss = New System.Windows.Forms.Label()
        Me.TNacionalidad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TREFERDIR = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TClasific = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.LtPais = New System.Windows.Forms.Label()
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.BtnActivo = New C1.Win.C1Input.C1Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.btnAnterior = New C1.Win.C1Input.C1Button()
        Me.btnSiguiente = New C1.Win.C1Input.C1Button()
        Me.btnInicial = New C1.Win.C1Input.C1Button()
        Me.btnFinal = New C1.Win.C1Input.C1Button()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1XLBook1 = New C1.C1Excel.C1XLBook()
        Me.TCUENTA_CONTABLE_FISCAL = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.PAG1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.BtnApli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMetodoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDiasCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLimCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chCON_CREDITO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnListaPrec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUsoCFDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPagoSAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDESCUENTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.BtnCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnColonia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_MON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_ESQIMPU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFLETE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRegimenFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PAG2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GpoDatosEnvio.SuspendLayout()
        CType(Me.BtnZonaEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.btnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.BtnPaisResiFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PAG4.SuspendLayout()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.FgL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PAG3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FCH_ULTCOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ULT_PAGOF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TULT_COMPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChCPPesoKg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TULT_PAGOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVENTAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chImprir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMatriz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDocModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnZona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.btnAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSiguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.BtnGrabarYSalir, Me.frmEstadoCuenta, Me.BarEstadoCuenta, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Padding = New System.Windows.Forms.Padding(6, 12, 0, 0)
        Me.BarraMenu.Size = New System.Drawing.Size(1463, 63)
        Me.BarraMenu.TabIndex = 5
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnGrabarYSalir
        '
        Me.BtnGrabarYSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnGrabarYSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabarYSalir.Image = Global.SGT_Transport.My.Resources.Resources.grabardoc11
        Me.BtnGrabarYSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnGrabarYSalir.Name = "BtnGrabarYSalir"
        Me.BtnGrabarYSalir.ShortcutKeyDisplayString = "Grabar registro"
        Me.BtnGrabarYSalir.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BtnGrabarYSalir.Size = New System.Drawing.Size(87, 51)
        Me.BtnGrabarYSalir.Text = "Grabar y salir"
        Me.BtnGrabarYSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmEstadoCuenta
        '
        Me.frmEstadoCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.frmEstadoCuenta.ForeColor = System.Drawing.Color.Black
        Me.frmEstadoCuenta.Image = Global.SGT_Transport.My.Resources.Resources.rep29
        Me.frmEstadoCuenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.frmEstadoCuenta.Name = "frmEstadoCuenta"
        Me.frmEstadoCuenta.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.frmEstadoCuenta.Size = New System.Drawing.Size(109, 51)
        Me.frmEstadoCuenta.Text = "Estado de cuenta"
        Me.frmEstadoCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEstadoCuenta
        '
        Me.BarEstadoCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEstadoCuenta.ForeColor = System.Drawing.Color.Black
        Me.BarEstadoCuenta.Image = Global.SGT_Transport.My.Resources.Resources.Polizacompras
        Me.BarEstadoCuenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEstadoCuenta.Name = "BarEstadoCuenta"
        Me.BarEstadoCuenta.ShortcutKeyDisplayString = "Grabar"
        Me.BarEstadoCuenta.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEstadoCuenta.Size = New System.Drawing.Size(54, 51)
        Me.BarEstadoCuenta.Text = "Grabar"
        Me.BarEstadoCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'TCLAVE
        '
        Me.TCLAVE.AcceptsReturn = True
        Me.TCLAVE.AcceptsTab = True
        Me.TCLAVE.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.Location = New System.Drawing.Point(162, 13)
        Me.TCLAVE.MaxLength = 10
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(56, 24)
        Me.TCLAVE.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(118, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 105
        Me.Label27.Text = "Clave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Nombre"
        '
        'TNOMBRE
        '
        Me.TNOMBRE.AcceptsReturn = True
        Me.TNOMBRE.AcceptsTab = True
        Me.TNOMBRE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRE.Location = New System.Drawing.Point(285, 13)
        Me.TNOMBRE.Name = "TNOMBRE"
        Me.TNOMBRE.Size = New System.Drawing.Size(430, 22)
        Me.TNOMBRE.TabIndex = 1
        '
        'TAB1
        '
        Me.TAB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB1.Controls.Add(Me.PAG1)
        Me.TAB1.Controls.Add(Me.PAG2)
        Me.TAB1.Controls.Add(Me.PAG4)
        Me.TAB1.Controls.Add(Me.PAG3)
        Me.TAB1.HotTrack = True
        Me.TAB1.Location = New System.Drawing.Point(2, 0)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.Size = New System.Drawing.Size(1376, 457)
        Me.TAB1.TabIndex = 0
        Me.TAB1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.TAB1.TabsShowFocusCues = False
        Me.TAB1.TabsSpacing = 2
        Me.TAB1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.TAB1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'PAG1
        '
        Me.PAG1.Controls.Add(Me.GroupBox7)
        Me.PAG1.Controls.Add(Me.GroupBox8)
        Me.PAG1.Location = New System.Drawing.Point(1, 24)
        Me.PAG1.Name = "PAG1"
        Me.PAG1.Size = New System.Drawing.Size(1374, 432)
        Me.PAG1.TabIndex = 0
        Me.PAG1.Text = "Datos Generales"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TCUENTA_CONTABLE_FISCAL)
        Me.GroupBox7.Controls.Add(Me.Label102)
        Me.GroupBox7.Controls.Add(Me.Label78)
        Me.GroupBox7.Controls.Add(Me.BtnApli)
        Me.GroupBox7.Controls.Add(Me.Label80)
        Me.GroupBox7.Controls.Add(Me.TAPLICACION)
        Me.GroupBox7.Controls.Add(Me.BtnMetodoPago)
        Me.GroupBox7.Controls.Add(Me.Label70)
        Me.GroupBox7.Controls.Add(Me.LtUsoCFDI)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.TDIAREV)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.TDIAPAGO)
        Me.GroupBox7.Controls.Add(Me.TDiasCred)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.TLimCred)
        Me.GroupBox7.Controls.Add(Me.chCON_CREDITO)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.LtSaldo)
        Me.GroupBox7.Controls.Add(Me.TCUENTA_CONTABLE)
        Me.GroupBox7.Controls.Add(Me.TUSO_CFDI)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.BtnListaPrec)
        Me.GroupBox7.Controls.Add(Me.TCVE_VEND)
        Me.GroupBox7.Controls.Add(Me.TLISTA_PREC)
        Me.GroupBox7.Controls.Add(Me.BtnVend)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.BtnUsoCFDI)
        Me.GroupBox7.Controls.Add(Me.LtVend)
        Me.GroupBox7.Controls.Add(Me.TMETODODEPAGO)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.BtnPagoSAT)
        Me.GroupBox7.Controls.Add(Me.Label51)
        Me.GroupBox7.Controls.Add(Me.tDESCUENTO)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.TNUMCTAPAGO)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.TFORMADEPAGOSAT)
        Me.GroupBox7.Controls.Add(Me.TFax)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.TTELEFONO)
        Me.GroupBox7.Location = New System.Drawing.Point(742, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(660, 426)
        Me.GroupBox7.TabIndex = 28
        Me.GroupBox7.TabStop = False
        '
        'Label78
        '
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Location = New System.Drawing.Point(217, 293)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(209, 21)
        Me.Label78.TabIndex = 293
        '
        'BtnApli
        '
        Me.BtnApli.AutoSize = True
        Me.BtnApli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnApli.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApli.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnApli.Location = New System.Drawing.Point(188, 292)
        Me.BtnApli.Name = "BtnApli"
        Me.BtnApli.Size = New System.Drawing.Size(22, 22)
        Me.BtnApli.TabIndex = 292
        Me.BtnApli.UseVisualStyleBackColor = True
        Me.BtnApli.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(69, 297)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(70, 16)
        Me.Label80.TabIndex = 291
        Me.Label80.Text = "Aplicación"
        '
        'TAPLICACION
        '
        Me.TAPLICACION.AcceptsReturn = True
        Me.TAPLICACION.AcceptsTab = True
        Me.TAPLICACION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAPLICACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TAPLICACION.Location = New System.Drawing.Point(143, 293)
        Me.TAPLICACION.Name = "TAPLICACION"
        Me.TAPLICACION.Size = New System.Drawing.Size(43, 21)
        Me.TAPLICACION.TabIndex = 16
        Me.TAPLICACION.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnMetodoPago
        '
        Me.BtnMetodoPago.AutoSize = True
        Me.BtnMetodoPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnMetodoPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMetodoPago.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnMetodoPago.Location = New System.Drawing.Point(192, 112)
        Me.BtnMetodoPago.Name = "BtnMetodoPago"
        Me.BtnMetodoPago.Size = New System.Drawing.Size(22, 22)
        Me.BtnMetodoPago.TabIndex = 289
        Me.BtnMetodoPago.UseVisualStyleBackColor = True
        Me.BtnMetodoPago.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label70
        '
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Location = New System.Drawing.Point(217, 266)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(209, 21)
        Me.Label70.TabIndex = 286
        '
        'LtUsoCFDI
        '
        Me.LtUsoCFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUsoCFDI.Location = New System.Drawing.Point(217, 240)
        Me.LtUsoCFDI.Name = "LtUsoCFDI"
        Me.LtUsoCFDI.Size = New System.Drawing.Size(209, 21)
        Me.LtUsoCFDI.TabIndex = 285
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(41, 67)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 16)
        Me.Label20.TabIndex = 250
        Me.Label20.Text = "Dias de crédito"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(266, 94)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 15)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Saldo"
        '
        'TDIAREV
        '
        Me.TDIAREV.AcceptsReturn = True
        Me.TDIAREV.AcceptsTab = True
        Me.TDIAREV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAREV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAREV.Location = New System.Drawing.Point(548, 113)
        Me.TDIAREV.Name = "TDIAREV"
        Me.TDIAREV.Size = New System.Drawing.Size(48, 22)
        Me.TDIAREV.TabIndex = 6
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(52, 243)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(87, 16)
        Me.Label48.TabIndex = 277
        Me.Label48.Text = "Uso del CFDI"
        '
        'TDIAPAGO
        '
        Me.TDIAPAGO.AcceptsReturn = True
        Me.TDIAPAGO.AcceptsTab = True
        Me.TDIAPAGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAPAGO.Location = New System.Drawing.Point(548, 139)
        Me.TDIAPAGO.Name = "TDIAPAGO"
        Me.TDIAPAGO.Size = New System.Drawing.Size(48, 22)
        Me.TDIAPAGO.TabIndex = 8
        '
        'TDiasCred
        '
        Me.TDiasCred.AcceptsTab = True
        Me.TDiasCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDiasCred.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDiasCred.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDiasCred.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDiasCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDiasCred.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDiasCred.Location = New System.Drawing.Point(143, 65)
        Me.TDiasCred.Name = "TDiasCred"
        Me.TDiasCred.Size = New System.Drawing.Size(96, 19)
        Me.TDiasCred.TabIndex = 2
        Me.TDiasCred.Tag = Nothing
        Me.TDiasCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDiasCred.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDiasCred.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDiasCred.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDiasCred.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(34, 91)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 16)
        Me.Label26.TabIndex = 263
        Me.Label26.Text = "Límite de crédito"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(440, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Dias de revisión"
        '
        'TLimCred
        '
        Me.TLimCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TLimCred.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TLimCred.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLimCred.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLimCred.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TLimCred.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLimCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLimCred.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TLimCred.Location = New System.Drawing.Point(143, 89)
        Me.TLimCred.Name = "TLimCred"
        Me.TLimCred.Size = New System.Drawing.Size(117, 19)
        Me.TLimCred.TabIndex = 4
        Me.TLimCred.Tag = Nothing
        Me.TLimCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TLimCred.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TLimCred.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLimCred.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chCON_CREDITO
        '
        Me.chCON_CREDITO.BackColor = System.Drawing.Color.Transparent
        Me.chCON_CREDITO.BorderColor = System.Drawing.Color.Transparent
        Me.chCON_CREDITO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chCON_CREDITO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chCON_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chCON_CREDITO.ForeColor = System.Drawing.Color.Black
        Me.chCON_CREDITO.Location = New System.Drawing.Point(316, 60)
        Me.chCON_CREDITO.Name = "chCON_CREDITO"
        Me.chCON_CREDITO.Padding = New System.Windows.Forms.Padding(1)
        Me.chCON_CREDITO.Size = New System.Drawing.Size(138, 26)
        Me.chCON_CREDITO.TabIndex = 3
        Me.chCON_CREDITO.Text = "Manejo de crédito"
        Me.chCON_CREDITO.UseVisualStyleBackColor = True
        Me.chCON_CREDITO.Value = Nothing
        Me.chCON_CREDITO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(462, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 16)
        Me.Label15.TabIndex = 256
        Me.Label15.Text = "Día de pago"
        '
        'LtSaldo
        '
        Me.LtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldo.Location = New System.Drawing.Point(306, 92)
        Me.LtSaldo.Name = "LtSaldo"
        Me.LtSaldo.Size = New System.Drawing.Size(120, 20)
        Me.LtSaldo.TabIndex = 8
        Me.LtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TCUENTA_CONTABLE
        '
        Me.TCUENTA_CONTABLE.AcceptsReturn = True
        Me.TCUENTA_CONTABLE.AcceptsTab = True
        Me.TCUENTA_CONTABLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCUENTA_CONTABLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUENTA_CONTABLE.Location = New System.Drawing.Point(143, 191)
        Me.TCUENTA_CONTABLE.Name = "TCUENTA_CONTABLE"
        Me.TCUENTA_CONTABLE.Size = New System.Drawing.Size(283, 21)
        Me.TCUENTA_CONTABLE.TabIndex = 11
        '
        'TUSO_CFDI
        '
        Me.TUSO_CFDI.AcceptsReturn = True
        Me.TUSO_CFDI.AcceptsTab = True
        Me.TUSO_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUSO_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUSO_CFDI.Location = New System.Drawing.Point(143, 240)
        Me.TUSO_CFDI.MaxLength = 5
        Me.TUSO_CFDI.Name = "TUSO_CFDI"
        Me.TUSO_CFDI.Size = New System.Drawing.Size(43, 21)
        Me.TUSO_CFDI.TabIndex = 14
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(72, 168)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 16)
        Me.Label32.TabIndex = 267
        Me.Label32.Text = "Vendedor"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(35, 194)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 16)
        Me.Label17.TabIndex = 255
        Me.Label17.Text = "Cuenta contable"
        '
        'BtnListaPrec
        '
        Me.BtnListaPrec.AutoSize = True
        Me.BtnListaPrec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnListaPrec.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnListaPrec.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnListaPrec.Location = New System.Drawing.Point(602, 190)
        Me.BtnListaPrec.Name = "BtnListaPrec"
        Me.BtnListaPrec.Size = New System.Drawing.Size(22, 22)
        Me.BtnListaPrec.TabIndex = 275
        Me.BtnListaPrec.UseVisualStyleBackColor = True
        Me.BtnListaPrec.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_VEND
        '
        Me.TCVE_VEND.AcceptsReturn = True
        Me.TCVE_VEND.AcceptsTab = True
        Me.TCVE_VEND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_VEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_VEND.Location = New System.Drawing.Point(143, 165)
        Me.TCVE_VEND.Name = "TCVE_VEND"
        Me.TCVE_VEND.Size = New System.Drawing.Size(55, 21)
        Me.TCVE_VEND.TabIndex = 9
        '
        'TLISTA_PREC
        '
        Me.TLISTA_PREC.AcceptsReturn = True
        Me.TLISTA_PREC.AcceptsTab = True
        Me.TLISTA_PREC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLISTA_PREC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLISTA_PREC.Location = New System.Drawing.Point(548, 191)
        Me.TLISTA_PREC.Name = "TLISTA_PREC"
        Me.TLISTA_PREC.Size = New System.Drawing.Size(48, 22)
        Me.TLISTA_PREC.TabIndex = 12
        Me.TLISTA_PREC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnVend
        '
        Me.BtnVend.AutoSize = True
        Me.BtnVend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnVend.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVend.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnVend.Location = New System.Drawing.Point(201, 165)
        Me.BtnVend.Name = "BtnVend"
        Me.BtnVend.Size = New System.Drawing.Size(22, 22)
        Me.BtnVend.TabIndex = 268
        Me.BtnVend.UseVisualStyleBackColor = True
        Me.BtnVend.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(442, 196)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 16)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Lista de precios"
        '
        'BtnUsoCFDI
        '
        Me.BtnUsoCFDI.AutoSize = True
        Me.BtnUsoCFDI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnUsoCFDI.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUsoCFDI.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnUsoCFDI.Location = New System.Drawing.Point(188, 239)
        Me.BtnUsoCFDI.Name = "BtnUsoCFDI"
        Me.BtnUsoCFDI.Size = New System.Drawing.Size(22, 22)
        Me.BtnUsoCFDI.TabIndex = 278
        Me.BtnUsoCFDI.UseVisualStyleBackColor = True
        Me.BtnUsoCFDI.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtVend
        '
        Me.LtVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtVend.Location = New System.Drawing.Point(226, 165)
        Me.LtVend.Name = "LtVend"
        Me.LtVend.Size = New System.Drawing.Size(200, 21)
        Me.LtVend.TabIndex = 269
        '
        'TMETODODEPAGO
        '
        Me.TMETODODEPAGO.AcceptsReturn = True
        Me.TMETODODEPAGO.AcceptsTab = True
        Me.TMETODODEPAGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMETODODEPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMETODODEPAGO.Location = New System.Drawing.Point(143, 113)
        Me.TMETODODEPAGO.Name = "TMETODODEPAGO"
        Me.TMETODODEPAGO.Size = New System.Drawing.Size(43, 21)
        Me.TMETODODEPAGO.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(460, 169)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 16)
        Me.Label33.TabIndex = 270
        Me.Label33.Text = "%Descuento"
        '
        'BtnPagoSAT
        '
        Me.BtnPagoSAT.AutoSize = True
        Me.BtnPagoSAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPagoSAT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPagoSAT.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnPagoSAT.Location = New System.Drawing.Point(188, 265)
        Me.BtnPagoSAT.Name = "BtnPagoSAT"
        Me.BtnPagoSAT.Size = New System.Drawing.Size(22, 22)
        Me.BtnPagoSAT.TabIndex = 281
        Me.BtnPagoSAT.UseVisualStyleBackColor = True
        Me.BtnPagoSAT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(9, 271)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(130, 16)
        Me.Label51.TabIndex = 280
        Me.Label51.Text = "Forma de pago SAT"
        '
        'tDESCUENTO
        '
        Me.tDESCUENTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDESCUENTO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tDESCUENTO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCUENTO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESCUENTO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDESCUENTO.Location = New System.Drawing.Point(548, 165)
        Me.tDESCUENTO.Name = "tDESCUENTO"
        Me.tDESCUENTO.Size = New System.Drawing.Size(61, 20)
        Me.tDESCUENTO.TabIndex = 10
        Me.tDESCUENTO.Tag = Nothing
        Me.tDESCUENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDESCUENTO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.tDESCUENTO.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCUENTO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(32, 116)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 16)
        Me.Label23.TabIndex = 252
        Me.Label23.Text = "Método de pago"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(22, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 16)
        Me.Label22.TabIndex = 251
        Me.Label22.Text = "Número de cuenta"
        '
        'TNUMCTAPAGO
        '
        Me.TNUMCTAPAGO.AcceptsReturn = True
        Me.TNUMCTAPAGO.AcceptsTab = True
        Me.TNUMCTAPAGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMCTAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMCTAPAGO.Location = New System.Drawing.Point(143, 139)
        Me.TNUMCTAPAGO.Name = "TNUMCTAPAGO"
        Me.TNUMCTAPAGO.Size = New System.Drawing.Size(283, 21)
        Me.TNUMCTAPAGO.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(341, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 256
        Me.Label13.Text = "Celular"
        '
        'TFORMADEPAGOSAT
        '
        Me.TFORMADEPAGOSAT.AcceptsReturn = True
        Me.TFORMADEPAGOSAT.AcceptsTab = True
        Me.TFORMADEPAGOSAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFORMADEPAGOSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFORMADEPAGOSAT.Location = New System.Drawing.Point(143, 266)
        Me.TFORMADEPAGOSAT.MaxLength = 10
        Me.TFORMADEPAGOSAT.Name = "TFORMADEPAGOSAT"
        Me.TFORMADEPAGOSAT.Size = New System.Drawing.Size(43, 21)
        Me.TFORMADEPAGOSAT.TabIndex = 15
        Me.TFORMADEPAGOSAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TFax
        '
        Me.TFax.AcceptsReturn = True
        Me.TFax.AcceptsTab = True
        Me.TFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFax.Location = New System.Drawing.Point(396, 32)
        Me.TFax.Name = "TFax"
        Me.TFax.Size = New System.Drawing.Size(188, 22)
        Me.TFax.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(76, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 16)
        Me.Label21.TabIndex = 238
        Me.Label21.Text = "Teléfono"
        '
        'TTELEFONO
        '
        Me.TTELEFONO.AcceptsReturn = True
        Me.TTELEFONO.AcceptsTab = True
        Me.TTELEFONO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTELEFONO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTELEFONO.Location = New System.Drawing.Point(143, 32)
        Me.TTELEFONO.Name = "TTELEFONO"
        Me.TTELEFONO.Size = New System.Drawing.Size(188, 22)
        Me.TTELEFONO.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TALIAS)
        Me.GroupBox8.Controls.Add(Me.Label31)
        Me.GroupBox8.Controls.Add(Me.BtnCP)
        Me.GroupBox8.Controls.Add(Me.BtnEstado)
        Me.GroupBox8.Controls.Add(Me.BtnLocalidad)
        Me.GroupBox8.Controls.Add(Me.BtnMunicipio)
        Me.GroupBox8.Controls.Add(Me.BtnColonia)
        Me.GroupBox8.Controls.Add(Me.LtMX)
        Me.GroupBox8.Controls.Add(Me.TNUM_MON)
        Me.GroupBox8.Controls.Add(Me.BtnMoneda)
        Me.GroupBox8.Controls.Add(Me.Label79)
        Me.GroupBox8.Controls.Add(Me.BtnPais)
        Me.GroupBox8.Controls.Add(Me.LtMoneda)
        Me.GroupBox8.Controls.Add(Me.TPAIS_SAT)
        Me.GroupBox8.Controls.Add(Me.Label76)
        Me.GroupBox8.Controls.Add(Me.TCVE_ESQIMPU)
        Me.GroupBox8.Controls.Add(Me.BtnEsquema)
        Me.GroupBox8.Controls.Add(Me.Label81)
        Me.GroupBox8.Controls.Add(Me.LtEsquema)
        Me.GroupBox8.Controls.Add(Me.TESTADO_SAT)
        Me.GroupBox8.Controls.Add(Me.Label75)
        Me.GroupBox8.Controls.Add(Me.TFLETE)
        Me.GroupBox8.Controls.Add(Me.Label73)
        Me.GroupBox8.Controls.Add(Me.Label71)
        Me.GroupBox8.Controls.Add(Me.TNOMBRECOMERCIAL)
        Me.GroupBox8.Controls.Add(Me.LtRegFis)
        Me.GroupBox8.Controls.Add(Me.BtnRFC)
        Me.GroupBox8.Controls.Add(Me.Label85)
        Me.GroupBox8.Controls.Add(Me.Label83)
        Me.GroupBox8.Controls.Add(Me.TLOCALIDAD_SAT)
        Me.GroupBox8.Controls.Add(Me.BtnRegimenFiscal)
        Me.GroupBox8.Controls.Add(Me.TMUNICIPIO_SAT)
        Me.GroupBox8.Controls.Add(Me.TREGIMEN_FISCAL)
        Me.GroupBox8.Controls.Add(Me.TCRUZAMIENTOS2)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.TCALLE)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Controls.Add(Me.TRFC)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.TCRUZAMIENTOS)
        Me.GroupBox8.Controls.Add(Me.Label87)
        Me.GroupBox8.Controls.Add(Me.Label30)
        Me.GroupBox8.Controls.Add(Me.TCOLONIA_SAT)
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.TMunicipio)
        Me.GroupBox8.Controls.Add(Me.TCURP)
        Me.GroupBox8.Controls.Add(Me.TNumInt)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.TNumExt)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.TPais)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label18)
        Me.GroupBox8.Controls.Add(Me.TCODIGO)
        Me.GroupBox8.Controls.Add(Me.TLOCALIDAD)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.Label44)
        Me.GroupBox8.Controls.Add(Me.TCOLONIA)
        Me.GroupBox8.Controls.Add(Me.TEstado)
        Me.GroupBox8.Controls.Add(Me.Label34)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(740, 426)
        Me.GroupBox8.TabIndex = 258
        Me.GroupBox8.TabStop = False
        '
        'TALIAS
        '
        Me.TALIAS.AcceptsReturn = True
        Me.TALIAS.AcceptsTab = True
        Me.TALIAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TALIAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TALIAS.ForeColor = System.Drawing.Color.Black
        Me.TALIAS.Location = New System.Drawing.Point(123, 37)
        Me.TALIAS.MaxLength = 120
        Me.TALIAS.Name = "TALIAS"
        Me.TALIAS.Size = New System.Drawing.Size(602, 23)
        Me.TALIAS.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(81, 40)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 17)
        Me.Label31.TabIndex = 664
        Me.Label31.Text = "Alias"
        '
        'BtnCP
        '
        Me.BtnCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCP.FlatAppearance.BorderSize = 0
        Me.BtnCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCP.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCP.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCP.Location = New System.Drawing.Point(590, 214)
        Me.BtnCP.Name = "BtnCP"
        Me.BtnCP.Size = New System.Drawing.Size(22, 22)
        Me.BtnCP.TabIndex = 290
        Me.BtnCP.UseVisualStyleBackColor = True
        Me.BtnCP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnEstado
        '
        Me.BtnEstado.FlatAppearance.BorderSize = 0
        Me.BtnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEstado.Image = CType(resources.GetObject("BtnEstado.Image"), System.Drawing.Image)
        Me.BtnEstado.Location = New System.Drawing.Point(590, 294)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(22, 22)
        Me.BtnEstado.TabIndex = 662
        Me.BtnEstado.UseVisualStyleBackColor = True
        '
        'BtnLocalidad
        '
        Me.BtnLocalidad.FlatAppearance.BorderSize = 0
        Me.BtnLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLocalidad.Image = CType(resources.GetObject("BtnLocalidad.Image"), System.Drawing.Image)
        Me.BtnLocalidad.Location = New System.Drawing.Point(590, 268)
        Me.BtnLocalidad.Name = "BtnLocalidad"
        Me.BtnLocalidad.Size = New System.Drawing.Size(22, 22)
        Me.BtnLocalidad.TabIndex = 661
        Me.BtnLocalidad.UseVisualStyleBackColor = True
        '
        'BtnMunicipio
        '
        Me.BtnMunicipio.FlatAppearance.BorderSize = 0
        Me.BtnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMunicipio.Image = CType(resources.GetObject("BtnMunicipio.Image"), System.Drawing.Image)
        Me.BtnMunicipio.Location = New System.Drawing.Point(590, 241)
        Me.BtnMunicipio.Name = "BtnMunicipio"
        Me.BtnMunicipio.Size = New System.Drawing.Size(22, 22)
        Me.BtnMunicipio.TabIndex = 660
        Me.BtnMunicipio.UseVisualStyleBackColor = True
        '
        'BtnColonia
        '
        Me.BtnColonia.FlatAppearance.BorderSize = 0
        Me.BtnColonia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnColonia.Image = CType(resources.GetObject("BtnColonia.Image"), System.Drawing.Image)
        Me.BtnColonia.Location = New System.Drawing.Point(590, 348)
        Me.BtnColonia.Name = "BtnColonia"
        Me.BtnColonia.Size = New System.Drawing.Size(22, 22)
        Me.BtnColonia.TabIndex = 659
        Me.BtnColonia.UseVisualStyleBackColor = True
        '
        'LtMX
        '
        Me.LtMX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMX.Location = New System.Drawing.Point(594, 91)
        Me.LtMX.Name = "LtMX"
        Me.LtMX.Size = New System.Drawing.Size(131, 23)
        Me.LtMX.TabIndex = 310
        '
        'TNUM_MON
        '
        Me.TNUM_MON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TNUM_MON.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TNUM_MON.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_MON.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_MON.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TNUM_MON.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TNUM_MON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_MON.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TNUM_MON.Location = New System.Drawing.Point(388, 91)
        Me.TNUM_MON.Name = "TNUM_MON"
        Me.TNUM_MON.Size = New System.Drawing.Size(43, 20)
        Me.TNUM_MON.TabIndex = 4
        Me.TNUM_MON.Tag = Nothing
        Me.TNUM_MON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TNUM_MON.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TNUM_MON.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_MON.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnMoneda
        '
        Me.BtnMoneda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnMoneda.Image = CType(resources.GetObject("BtnMoneda.Image"), System.Drawing.Image)
        Me.BtnMoneda.Location = New System.Drawing.Point(432, 91)
        Me.BtnMoneda.Name = "BtnMoneda"
        Me.BtnMoneda.Size = New System.Drawing.Size(22, 22)
        Me.BtnMoneda.TabIndex = 309
        Me.BtnMoneda.UseVisualStyleBackColor = True
        Me.BtnMoneda.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(432, 323)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(74, 17)
        Me.Label79.TabIndex = 656
        Me.Label79.Text = "Clave SAT"
        '
        'BtnPais
        '
        Me.BtnPais.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPais.FlatAppearance.BorderSize = 0
        Me.BtnPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPais.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnPais.Location = New System.Drawing.Point(590, 321)
        Me.BtnPais.Name = "BtnPais"
        Me.BtnPais.Size = New System.Drawing.Size(22, 22)
        Me.BtnPais.TabIndex = 258
        Me.BtnPais.UseVisualStyleBackColor = True
        Me.BtnPais.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtMoneda
        '
        Me.LtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMoneda.Location = New System.Drawing.Point(458, 91)
        Me.LtMoneda.Name = "LtMoneda"
        Me.LtMoneda.Size = New System.Drawing.Size(131, 23)
        Me.LtMoneda.TabIndex = 308
        '
        'TPAIS_SAT
        '
        Me.TPAIS_SAT.AcceptsReturn = True
        Me.TPAIS_SAT.AcceptsTab = True
        Me.TPAIS_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAIS_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAIS_SAT.ForeColor = System.Drawing.Color.Black
        Me.TPAIS_SAT.Location = New System.Drawing.Point(508, 320)
        Me.TPAIS_SAT.MaxLength = 10
        Me.TPAIS_SAT.Name = "TPAIS_SAT"
        Me.TPAIS_SAT.ReadOnly = True
        Me.TPAIS_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TPAIS_SAT.TabIndex = 16
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(327, 97)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(57, 16)
        Me.Label76.TabIndex = 307
        Me.Label76.Text = "Moneda"
        '
        'TCVE_ESQIMPU
        '
        Me.TCVE_ESQIMPU.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCVE_ESQIMPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCVE_ESQIMPU.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TCVE_ESQIMPU.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCVE_ESQIMPU.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCVE_ESQIMPU.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_ESQIMPU.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TCVE_ESQIMPU.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCVE_ESQIMPU.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TCVE_ESQIMPU.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCVE_ESQIMPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ESQIMPU.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCVE_ESQIMPU.Location = New System.Drawing.Point(369, 139)
        Me.TCVE_ESQIMPU.Name = "TCVE_ESQIMPU"
        Me.TCVE_ESQIMPU.Size = New System.Drawing.Size(27, 21)
        Me.TCVE_ESQIMPU.TabIndex = 305
        Me.TCVE_ESQIMPU.Tag = Nothing
        Me.TCVE_ESQIMPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TCVE_ESQIMPU.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCVE_ESQIMPU.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnEsquema
        '
        Me.BtnEsquema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnEsquema.Image = CType(resources.GetObject("BtnEsquema.Image"), System.Drawing.Image)
        Me.BtnEsquema.Location = New System.Drawing.Point(399, 138)
        Me.BtnEsquema.Name = "BtnEsquema"
        Me.BtnEsquema.Size = New System.Drawing.Size(22, 22)
        Me.BtnEsquema.TabIndex = 293
        Me.BtnEsquema.UseVisualStyleBackColor = True
        Me.BtnEsquema.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Location = New System.Drawing.Point(432, 297)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(74, 17)
        Me.Label81.TabIndex = 654
        Me.Label81.Text = "Clave SAT"
        '
        'LtEsquema
        '
        Me.LtEsquema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEsquema.Location = New System.Drawing.Point(426, 139)
        Me.LtEsquema.Name = "LtEsquema"
        Me.LtEsquema.Size = New System.Drawing.Size(297, 23)
        Me.LtEsquema.TabIndex = 292
        '
        'TESTADO_SAT
        '
        Me.TESTADO_SAT.AcceptsReturn = True
        Me.TESTADO_SAT.AcceptsTab = True
        Me.TESTADO_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TESTADO_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESTADO_SAT.ForeColor = System.Drawing.Color.Black
        Me.TESTADO_SAT.Location = New System.Drawing.Point(508, 294)
        Me.TESTADO_SAT.MaxLength = 10
        Me.TESTADO_SAT.Name = "TESTADO_SAT"
        Me.TESTADO_SAT.ReadOnly = True
        Me.TESTADO_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TESTADO_SAT.TabIndex = 14
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(300, 141)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(67, 17)
        Me.Label75.TabIndex = 291
        Me.Label75.Text = "Esquema"
        '
        'TFLETE
        '
        Me.TFLETE.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TFLETE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TFLETE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TFLETE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TFLETE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFLETE.CustomFormat = "###,###,##0.00"
        Me.TFLETE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TFLETE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TFLETE.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFLETE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TFLETE.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFLETE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFLETE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TFLETE.Location = New System.Drawing.Point(123, 139)
        Me.TFLETE.Name = "TFLETE"
        Me.TFLETE.Size = New System.Drawing.Size(124, 21)
        Me.TFLETE.TabIndex = 5
        Me.TFLETE.Tag = Nothing
        Me.TFLETE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TFLETE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TFLETE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Black
        Me.Label73.Location = New System.Drawing.Point(82, 141)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(37, 16)
        Me.Label73.TabIndex = 302
        Me.Label73.Text = "Flete"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(1, 13)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(118, 16)
        Me.Label71.TabIndex = 282
        Me.Label71.Text = "Nombre comercial"
        '
        'TNOMBRECOMERCIAL
        '
        Me.TNOMBRECOMERCIAL.AcceptsReturn = True
        Me.TNOMBRECOMERCIAL.AcceptsTab = True
        Me.TNOMBRECOMERCIAL.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRECOMERCIAL.Location = New System.Drawing.Point(123, 11)
        Me.TNOMBRECOMERCIAL.MaxLength = 254
        Me.TNOMBRECOMERCIAL.Name = "TNOMBRECOMERCIAL"
        Me.TNOMBRECOMERCIAL.Size = New System.Drawing.Size(602, 22)
        Me.TNOMBRECOMERCIAL.TabIndex = 0
        '
        'LtRegFis
        '
        Me.LtRegFis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRegFis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRegFis.Location = New System.Drawing.Point(458, 64)
        Me.LtRegFis.Name = "LtRegFis"
        Me.LtRegFis.Size = New System.Drawing.Size(267, 23)
        Me.LtRegFis.TabIndex = 264
        '
        'BtnRFC
        '
        Me.BtnRFC.FlatAppearance.BorderSize = 0
        Me.BtnRFC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRFC.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnRFC.Location = New System.Drawing.Point(248, 64)
        Me.BtnRFC.Name = "BtnRFC"
        Me.BtnRFC.Size = New System.Drawing.Size(23, 24)
        Me.BtnRFC.TabIndex = 263
        Me.BtnRFC.UseVisualStyleBackColor = True
        Me.BtnRFC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(432, 271)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(74, 17)
        Me.Label85.TabIndex = 650
        Me.Label85.Text = "Clave SAT"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(432, 245)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(74, 17)
        Me.Label83.TabIndex = 652
        Me.Label83.Text = "Clave SAT"
        '
        'TLOCALIDAD_SAT
        '
        Me.TLOCALIDAD_SAT.AcceptsReturn = True
        Me.TLOCALIDAD_SAT.AcceptsTab = True
        Me.TLOCALIDAD_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLOCALIDAD_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD_SAT.ForeColor = System.Drawing.Color.Black
        Me.TLOCALIDAD_SAT.Location = New System.Drawing.Point(508, 268)
        Me.TLOCALIDAD_SAT.MaxLength = 10
        Me.TLOCALIDAD_SAT.Name = "TLOCALIDAD_SAT"
        Me.TLOCALIDAD_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TLOCALIDAD_SAT.TabIndex = 640
        '
        'BtnRegimenFiscal
        '
        Me.BtnRegimenFiscal.FlatAppearance.BorderSize = 0
        Me.BtnRegimenFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegimenFiscal.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnRegimenFiscal.Location = New System.Drawing.Point(432, 64)
        Me.BtnRegimenFiscal.Name = "BtnRegimenFiscal"
        Me.BtnRegimenFiscal.Size = New System.Drawing.Size(23, 24)
        Me.BtnRegimenFiscal.TabIndex = 192
        Me.BtnRegimenFiscal.UseVisualStyleBackColor = True
        Me.BtnRegimenFiscal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TMUNICIPIO_SAT
        '
        Me.TMUNICIPIO_SAT.AcceptsReturn = True
        Me.TMUNICIPIO_SAT.AcceptsTab = True
        Me.TMUNICIPIO_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMUNICIPIO_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMUNICIPIO_SAT.ForeColor = System.Drawing.Color.Black
        Me.TMUNICIPIO_SAT.Location = New System.Drawing.Point(508, 242)
        Me.TMUNICIPIO_SAT.MaxLength = 10
        Me.TMUNICIPIO_SAT.Name = "TMUNICIPIO_SAT"
        Me.TMUNICIPIO_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TMUNICIPIO_SAT.TabIndex = 12
        '
        'TREGIMEN_FISCAL
        '
        Me.TREGIMEN_FISCAL.AcceptsReturn = True
        Me.TREGIMEN_FISCAL.AcceptsTab = True
        Me.TREGIMEN_FISCAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREGIMEN_FISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREGIMEN_FISCAL.Location = New System.Drawing.Point(388, 64)
        Me.TREGIMEN_FISCAL.Name = "TREGIMEN_FISCAL"
        Me.TREGIMEN_FISCAL.Size = New System.Drawing.Size(43, 23)
        Me.TREGIMEN_FISCAL.TabIndex = 3
        '
        'TCRUZAMIENTOS2
        '
        Me.TCRUZAMIENTOS2.AcceptsReturn = True
        Me.TCRUZAMIENTOS2.AcceptsTab = True
        Me.TCRUZAMIENTOS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCRUZAMIENTOS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCRUZAMIENTOS2.Location = New System.Drawing.Point(122, 190)
        Me.TCRUZAMIENTOS2.Name = "TCRUZAMIENTOS2"
        Me.TCRUZAMIENTOS2.Size = New System.Drawing.Size(601, 22)
        Me.TCRUZAMIENTOS2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Régimen fiscal"
        '
        'TCALLE
        '
        Me.TCALLE.AcceptsReturn = True
        Me.TCALLE.AcceptsTab = True
        Me.TCALLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALLE.Location = New System.Drawing.Point(123, 115)
        Me.TCALLE.MaxLength = 255
        Me.TCALLE.Name = "TCALLE"
        Me.TCALLE.Size = New System.Drawing.Size(602, 20)
        Me.TCALLE.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 232
        Me.Label6.Text = "Dirección 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 228
        Me.Label2.Text = "Y Calle"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(52, 271)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 16)
        Me.Label29.TabIndex = 233
        Me.Label29.Text = "Localidad"
        '
        'TRFC
        '
        Me.TRFC.AcceptsReturn = True
        Me.TRFC.AcceptsTab = True
        Me.TRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFC.Location = New System.Drawing.Point(123, 64)
        Me.TRFC.Name = "TRFC"
        Me.TRFC.Size = New System.Drawing.Size(124, 23)
        Me.TRFC.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(74, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 16)
        Me.Label12.TabIndex = 254
        Me.Label12.Text = "CURP"
        '
        'TCRUZAMIENTOS
        '
        Me.TCRUZAMIENTOS.AcceptsReturn = True
        Me.TCRUZAMIENTOS.AcceptsTab = True
        Me.TCRUZAMIENTOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCRUZAMIENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCRUZAMIENTOS.Location = New System.Drawing.Point(123, 164)
        Me.TCRUZAMIENTOS.Name = "TCRUZAMIENTOS"
        Me.TCRUZAMIENTOS.Size = New System.Drawing.Size(600, 22)
        Me.TCRUZAMIENTOS.TabIndex = 12
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(432, 350)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(74, 17)
        Me.Label87.TabIndex = 648
        Me.Label87.Text = "Clave SAT"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(475, 219)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 16)
        Me.Label30.TabIndex = 234
        Me.Label30.Text = "C.P."
        '
        'TCOLONIA_SAT
        '
        Me.TCOLONIA_SAT.AcceptsReturn = True
        Me.TCOLONIA_SAT.AcceptsTab = True
        Me.TCOLONIA_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLONIA_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLONIA_SAT.ForeColor = System.Drawing.Color.Black
        Me.TCOLONIA_SAT.Location = New System.Drawing.Point(508, 346)
        Me.TCOLONIA_SAT.MaxLength = 10
        Me.TCOLONIA_SAT.Name = "TCOLONIA_SAT"
        Me.TCOLONIA_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TCOLONIA_SAT.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(45, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 16)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Dirección 2"
        '
        'TMunicipio
        '
        Me.TMunicipio.AcceptsReturn = True
        Me.TMunicipio.AcceptsTab = True
        Me.TMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMunicipio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMunicipio.Location = New System.Drawing.Point(123, 242)
        Me.TMunicipio.Name = "TMunicipio"
        Me.TMunicipio.Size = New System.Drawing.Size(296, 22)
        Me.TMunicipio.TabIndex = 11
        '
        'TCURP
        '
        Me.TCURP.AcceptsReturn = True
        Me.TCURP.AcceptsTab = True
        Me.TCURP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCURP.Location = New System.Drawing.Point(123, 91)
        Me.TCURP.Name = "TCURP"
        Me.TCURP.Size = New System.Drawing.Size(174, 20)
        Me.TCURP.TabIndex = 4
        '
        'TNumInt
        '
        Me.TNumInt.AcceptsReturn = True
        Me.TNumInt.AcceptsTab = True
        Me.TNumInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNumInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNumInt.Location = New System.Drawing.Point(238, 216)
        Me.TNumInt.Name = "TNumInt"
        Me.TNumInt.Size = New System.Drawing.Size(69, 22)
        Me.TNumInt.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(76, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "R.F.C."
        '
        'TNumExt
        '
        Me.TNumExt.AcceptsReturn = True
        Me.TNumExt.AcceptsTab = True
        Me.TNumExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNumExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNumExt.Location = New System.Drawing.Point(123, 216)
        Me.TNumExt.Name = "TNumExt"
        Me.TNumExt.Size = New System.Drawing.Size(48, 22)
        Me.TNumExt.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "Núm. Ext."
        '
        'TPais
        '
        Me.TPais.AcceptsReturn = True
        Me.TPais.AcceptsTab = True
        Me.TPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPais.Location = New System.Drawing.Point(123, 320)
        Me.TPais.Name = "TPais"
        Me.TPais.Size = New System.Drawing.Size(296, 22)
        Me.TPais.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(66, 349)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 16)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "Colonia"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(178, 219)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 16)
        Me.Label18.TabIndex = 235
        Me.Label18.Text = "Núm. Int."
        '
        'TCODIGO
        '
        Me.TCODIGO.AcceptsReturn = True
        Me.TCODIGO.AcceptsTab = True
        Me.TCODIGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCODIGO.Location = New System.Drawing.Point(508, 216)
        Me.TCODIGO.Name = "TCODIGO"
        Me.TCODIGO.Size = New System.Drawing.Size(81, 22)
        Me.TCODIGO.TabIndex = 10
        Me.TCODIGO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLOCALIDAD
        '
        Me.TLOCALIDAD.AcceptsReturn = True
        Me.TLOCALIDAD.AcceptsTab = True
        Me.TLOCALIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLOCALIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD.Location = New System.Drawing.Point(123, 268)
        Me.TLOCALIDAD.Name = "TLOCALIDAD"
        Me.TLOCALIDAD.Size = New System.Drawing.Size(296, 22)
        Me.TLOCALIDAD.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(86, 323)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 16)
        Me.Label16.TabIndex = 240
        Me.Label16.Text = "País"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(69, 297)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(50, 16)
        Me.Label44.TabIndex = 237
        Me.Label44.Text = "Estado"
        '
        'TCOLONIA
        '
        Me.TCOLONIA.AcceptsReturn = True
        Me.TCOLONIA.AcceptsTab = True
        Me.TCOLONIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLONIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLONIA.Location = New System.Drawing.Point(123, 346)
        Me.TCOLONIA.Name = "TCOLONIA"
        Me.TCOLONIA.Size = New System.Drawing.Size(296, 22)
        Me.TCOLONIA.TabIndex = 17
        '
        'TEstado
        '
        Me.TEstado.AcceptsReturn = True
        Me.TEstado.AcceptsTab = True
        Me.TEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEstado.Location = New System.Drawing.Point(123, 294)
        Me.TEstado.Name = "TEstado"
        Me.TEstado.Size = New System.Drawing.Size(296, 22)
        Me.TEstado.TabIndex = 13
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(55, 245)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(64, 16)
        Me.Label34.TabIndex = 239
        Me.Label34.Text = "Municipio"
        '
        'PAG2
        '
        Me.PAG2.Controls.Add(Me.GroupBox9)
        Me.PAG2.Location = New System.Drawing.Point(1, 24)
        Me.PAG2.Name = "PAG2"
        Me.PAG2.Size = New System.Drawing.Size(1374, 432)
        Me.PAG2.TabIndex = 1
        Me.PAG2.Text = "Datos de Ventas"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.GpoDatosEnvio)
        Me.GroupBox9.Controls.Add(Me.GroupBox5)
        Me.GroupBox9.Controls.Add(Me.TCVE_OBS)
        Me.GroupBox9.Controls.Add(Me.Label46)
        Me.GroupBox9.Controls.Add(Me.GroupBox4)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(1374, 432)
        Me.GroupBox9.TabIndex = 276
        Me.GroupBox9.TabStop = False
        '
        'GpoDatosEnvio
        '
        Me.GpoDatosEnvio.Controls.Add(Me.TCALLE_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.tZonaEnvio)
        Me.GpoDatosEnvio.Controls.Add(Me.TCOLONIA_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label67)
        Me.GpoDatosEnvio.Controls.Add(Me.TCRUZAMIENTOS_ENVIO2)
        Me.GpoDatosEnvio.Controls.Add(Me.Label56)
        Me.GpoDatosEnvio.Controls.Add(Me.Label62)
        Me.GpoDatosEnvio.Controls.Add(Me.LtZonaEnvio)
        Me.GpoDatosEnvio.Controls.Add(Me.Label53)
        Me.GpoDatosEnvio.Controls.Add(Me.TMUNICIPIO_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label52)
        Me.GpoDatosEnvio.Controls.Add(Me.Label66)
        Me.GpoDatosEnvio.Controls.Add(Me.Label61)
        Me.GpoDatosEnvio.Controls.Add(Me.TESTADO_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.TNUMEXT_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.BtnZonaEnvio)
        Me.GpoDatosEnvio.Controls.Add(Me.TCRUZAMIENTOS_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label55)
        Me.GpoDatosEnvio.Controls.Add(Me.TREFERENCIA_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.TLOCALIDAD_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label60)
        Me.GpoDatosEnvio.Controls.Add(Me.Label58)
        Me.GpoDatosEnvio.Controls.Add(Me.TCODIGO_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.TCVE_ZONA_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label54)
        Me.GpoDatosEnvio.Controls.Add(Me.TPAIS_ENVIO)
        Me.GpoDatosEnvio.Controls.Add(Me.Label50)
        Me.GpoDatosEnvio.Controls.Add(Me.Label65)
        Me.GpoDatosEnvio.Controls.Add(Me.TNUMINT_ENVIO)
        Me.GpoDatosEnvio.Location = New System.Drawing.Point(617, 9)
        Me.GpoDatosEnvio.Name = "GpoDatosEnvio"
        Me.GpoDatosEnvio.Size = New System.Drawing.Size(619, 235)
        Me.GpoDatosEnvio.TabIndex = 5
        Me.GpoDatosEnvio.TabStop = False
        Me.GpoDatosEnvio.Text = "Datos de envio"
        '
        'TCALLE_ENVIO
        '
        Me.TCALLE_ENVIO.AcceptsReturn = True
        Me.TCALLE_ENVIO.AcceptsTab = True
        Me.TCALLE_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALLE_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALLE_ENVIO.Location = New System.Drawing.Point(94, 19)
        Me.TCALLE_ENVIO.Name = "TCALLE_ENVIO"
        Me.TCALLE_ENVIO.Size = New System.Drawing.Size(519, 22)
        Me.TCALLE_ENVIO.TabIndex = 0
        '
        'tZonaEnvio
        '
        Me.tZonaEnvio.AutoSize = True
        Me.tZonaEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tZonaEnvio.Location = New System.Drawing.Point(52, 198)
        Me.tZonaEnvio.Name = "tZonaEnvio"
        Me.tZonaEnvio.Size = New System.Drawing.Size(38, 16)
        Me.tZonaEnvio.TabIndex = 295
        Me.tZonaEnvio.Text = "Zona"
        '
        'TCOLONIA_ENVIO
        '
        Me.TCOLONIA_ENVIO.AcceptsReturn = True
        Me.TCOLONIA_ENVIO.AcceptsTab = True
        Me.TCOLONIA_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLONIA_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLONIA_ENVIO.Location = New System.Drawing.Point(375, 69)
        Me.TCOLONIA_ENVIO.Name = "TCOLONIA_ENVIO"
        Me.TCOLONIA_ENVIO.Size = New System.Drawing.Size(237, 22)
        Me.TCOLONIA_ENVIO.TabIndex = 5
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(52, 23)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(38, 16)
        Me.Label67.TabIndex = 274
        Me.Label67.Text = "Calle"
        '
        'TCRUZAMIENTOS_ENVIO2
        '
        Me.TCRUZAMIENTOS_ENVIO2.AcceptsReturn = True
        Me.TCRUZAMIENTOS_ENVIO2.AcceptsTab = True
        Me.TCRUZAMIENTOS_ENVIO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCRUZAMIENTOS_ENVIO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCRUZAMIENTOS_ENVIO2.Location = New System.Drawing.Point(94, 69)
        Me.TCRUZAMIENTOS_ENVIO2.Name = "TCRUZAMIENTOS_ENVIO2"
        Me.TCRUZAMIENTOS_ENVIO2.Size = New System.Drawing.Size(215, 22)
        Me.TCRUZAMIENTOS_ENVIO2.TabIndex = 4
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(26, 173)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(64, 16)
        Me.Label56.TabIndex = 281
        Me.Label56.Text = "Municipio"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(28, 47)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(62, 16)
        Me.Label62.TabIndex = 271
        Me.Label62.Text = "Num. Ext."
        '
        'LtZonaEnvio
        '
        Me.LtZonaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtZonaEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtZonaEnvio.Location = New System.Drawing.Point(177, 194)
        Me.LtZonaEnvio.Name = "LtZonaEnvio"
        Me.LtZonaEnvio.Size = New System.Drawing.Size(391, 20)
        Me.LtZonaEnvio.TabIndex = 294
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(317, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(53, 16)
        Me.Label53.TabIndex = 286
        Me.Label53.Text = "Colonia"
        '
        'TMUNICIPIO_ENVIO
        '
        Me.TMUNICIPIO_ENVIO.AcceptsReturn = True
        Me.TMUNICIPIO_ENVIO.AcceptsTab = True
        Me.TMUNICIPIO_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMUNICIPIO_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMUNICIPIO_ENVIO.Location = New System.Drawing.Point(94, 169)
        Me.TMUNICIPIO_ENVIO.Name = "TMUNICIPIO_ENVIO"
        Me.TMUNICIPIO_ENVIO.Size = New System.Drawing.Size(276, 22)
        Me.TMUNICIPIO_ENVIO.TabIndex = 11
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(17, 97)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(73, 16)
        Me.Label52.TabIndex = 288
        Me.Label52.Text = "Referencia"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(22, 122)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(68, 16)
        Me.Label66.TabIndex = 275
        Me.Label66.Text = "Población"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(40, 72)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(50, 16)
        Me.Label61.TabIndex = 270
        Me.Label61.Text = "Y Calle"
        '
        'TESTADO_ENVIO
        '
        Me.TESTADO_ENVIO.AcceptsReturn = True
        Me.TESTADO_ENVIO.AcceptsTab = True
        Me.TESTADO_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TESTADO_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESTADO_ENVIO.Location = New System.Drawing.Point(94, 144)
        Me.TESTADO_ENVIO.Name = "TESTADO_ENVIO"
        Me.TESTADO_ENVIO.Size = New System.Drawing.Size(276, 22)
        Me.TESTADO_ENVIO.TabIndex = 9
        '
        'TNUMEXT_ENVIO
        '
        Me.TNUMEXT_ENVIO.AcceptsReturn = True
        Me.TNUMEXT_ENVIO.AcceptsTab = True
        Me.TNUMEXT_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMEXT_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMEXT_ENVIO.Location = New System.Drawing.Point(94, 44)
        Me.TNUMEXT_ENVIO.Name = "TNUMEXT_ENVIO"
        Me.TNUMEXT_ENVIO.Size = New System.Drawing.Size(48, 22)
        Me.TNUMEXT_ENVIO.TabIndex = 1
        '
        'BtnZonaEnvio
        '
        Me.BtnZonaEnvio.AutoSize = True
        Me.BtnZonaEnvio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnZonaEnvio.FlatAppearance.BorderSize = 0
        Me.BtnZonaEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnZonaEnvio.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnZonaEnvio.Location = New System.Drawing.Point(149, 194)
        Me.BtnZonaEnvio.Name = "BtnZonaEnvio"
        Me.BtnZonaEnvio.Size = New System.Drawing.Size(22, 22)
        Me.BtnZonaEnvio.TabIndex = 293
        Me.BtnZonaEnvio.UseVisualStyleBackColor = True
        Me.BtnZonaEnvio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCRUZAMIENTOS_ENVIO
        '
        Me.TCRUZAMIENTOS_ENVIO.AcceptsReturn = True
        Me.TCRUZAMIENTOS_ENVIO.AcceptsTab = True
        Me.TCRUZAMIENTOS_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCRUZAMIENTOS_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCRUZAMIENTOS_ENVIO.Location = New System.Drawing.Point(375, 44)
        Me.TCRUZAMIENTOS_ENVIO.Name = "TCRUZAMIENTOS_ENVIO"
        Me.TCRUZAMIENTOS_ENVIO.Size = New System.Drawing.Size(237, 22)
        Me.TCRUZAMIENTOS_ENVIO.TabIndex = 3
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(433, 148)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(34, 16)
        Me.Label55.TabIndex = 282
        Me.Label55.Text = "País"
        '
        'TREFERENCIA_ENVIO
        '
        Me.TREFERENCIA_ENVIO.AcceptsReturn = True
        Me.TREFERENCIA_ENVIO.AcceptsTab = True
        Me.TREFERENCIA_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREFERENCIA_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREFERENCIA_ENVIO.Location = New System.Drawing.Point(94, 94)
        Me.TREFERENCIA_ENVIO.Name = "TREFERENCIA_ENVIO"
        Me.TREFERENCIA_ENVIO.Size = New System.Drawing.Size(519, 22)
        Me.TREFERENCIA_ENVIO.TabIndex = 6
        '
        'TLOCALIDAD_ENVIO
        '
        Me.TLOCALIDAD_ENVIO.AcceptsReturn = True
        Me.TLOCALIDAD_ENVIO.AcceptsTab = True
        Me.TLOCALIDAD_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLOCALIDAD_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD_ENVIO.Location = New System.Drawing.Point(94, 119)
        Me.TLOCALIDAD_ENVIO.Name = "TLOCALIDAD_ENVIO"
        Me.TLOCALIDAD_ENVIO.Size = New System.Drawing.Size(321, 22)
        Me.TLOCALIDAD_ENVIO.TabIndex = 7
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(150, 48)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(57, 16)
        Me.Label60.TabIndex = 277
        Me.Label60.Text = "Num. Int."
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(40, 147)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(50, 16)
        Me.Label58.TabIndex = 279
        Me.Label58.Text = "Estado"
        '
        'TCODIGO_ENVIO
        '
        Me.TCODIGO_ENVIO.AcceptsReturn = True
        Me.TCODIGO_ENVIO.AcceptsTab = True
        Me.TCODIGO_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCODIGO_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCODIGO_ENVIO.Location = New System.Drawing.Point(542, 119)
        Me.TCODIGO_ENVIO.Name = "TCODIGO_ENVIO"
        Me.TCODIGO_ENVIO.Size = New System.Drawing.Size(70, 22)
        Me.TCODIGO_ENVIO.TabIndex = 8
        '
        'TCVE_ZONA_ENVIO
        '
        Me.TCVE_ZONA_ENVIO.AcceptsReturn = True
        Me.TCVE_ZONA_ENVIO.AcceptsTab = True
        Me.TCVE_ZONA_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ZONA_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ZONA_ENVIO.Location = New System.Drawing.Point(94, 194)
        Me.TCVE_ZONA_ENVIO.Name = "TCVE_ZONA_ENVIO"
        Me.TCVE_ZONA_ENVIO.Size = New System.Drawing.Size(55, 22)
        Me.TCVE_ZONA_ENVIO.TabIndex = 12
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(296, 47)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(70, 16)
        Me.Label54.TabIndex = 284
        Me.Label54.Text = "Entre calle"
        '
        'TPAIS_ENVIO
        '
        Me.TPAIS_ENVIO.AcceptsReturn = True
        Me.TPAIS_ENVIO.AcceptsTab = True
        Me.TPAIS_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAIS_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAIS_ENVIO.Location = New System.Drawing.Point(472, 144)
        Me.TPAIS_ENVIO.Name = "TPAIS_ENVIO"
        Me.TPAIS_ENVIO.Size = New System.Drawing.Size(140, 22)
        Me.TPAIS_ENVIO.TabIndex = 10
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(224, 197)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(38, 16)
        Me.Label50.TabIndex = 292
        Me.Label50.Text = "Zona"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(505, 122)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(31, 16)
        Me.Label65.TabIndex = 276
        Me.Label65.Text = "C.P."
        '
        'TNUMINT_ENVIO
        '
        Me.TNUMINT_ENVIO.AcceptsReturn = True
        Me.TNUMINT_ENVIO.AcceptsTab = True
        Me.TNUMINT_ENVIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMINT_ENVIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMINT_ENVIO.Location = New System.Drawing.Point(212, 44)
        Me.TNUMINT_ENVIO.Name = "TNUMINT_ENVIO"
        Me.TNUMINT_ENVIO.Size = New System.Drawing.Size(45, 22)
        Me.TNUMINT_ENVIO.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnEliminar)
        Me.GroupBox5.Controls.Add(Me.btnAgregar)
        Me.GroupBox5.Controls.Add(Me.BtnBancos)
        Me.GroupBox5.Controls.Add(Me.Label63)
        Me.GroupBox5.Controls.Add(Me.TRFCFiscal)
        Me.GroupBox5.Controls.Add(Me.Label47)
        Me.GroupBox5.Controls.Add(Me.TBancoFiscal)
        Me.GroupBox5.Controls.Add(Me.Label49)
        Me.GroupBox5.Controls.Add(Me.TCtaBanFiscal)
        Me.GroupBox5.Controls.Add(Me.Fg)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 194)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(597, 195)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos bancarios"
        '
        'btnEliminar
        '
        Me.btnEliminar.AutoSize = True
        Me.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEliminar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.eli5
        Me.btnEliminar.Location = New System.Drawing.Point(512, 60)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(26, 26)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.SGT_Transport.My.Resources.Resources.ok20
        Me.btnAgregar.Location = New System.Drawing.Point(474, 60)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(26, 26)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.UseVisualStyleBackColor = True
        Me.btnAgregar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnBancos
        '
        Me.BtnBancos.AutoSize = True
        Me.BtnBancos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnBancos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBancos.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnBancos.Location = New System.Drawing.Point(412, 28)
        Me.BtnBancos.Name = "BtnBancos"
        Me.BtnBancos.Size = New System.Drawing.Size(22, 22)
        Me.BtnBancos.TabIndex = 283
        Me.BtnBancos.UseVisualStyleBackColor = True
        Me.BtnBancos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(19, 50)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(87, 13)
        Me.Label63.TabIndex = 235
        Me.Label63.Text = "R.F.C. del banco"
        '
        'TRFCFiscal
        '
        Me.TRFCFiscal.AcceptsReturn = True
        Me.TRFCFiscal.AcceptsTab = True
        Me.TRFCFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRFCFiscal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFCFiscal.Location = New System.Drawing.Point(16, 66)
        Me.TRFCFiscal.Name = "TRFCFiscal"
        Me.TRFCFiscal.Size = New System.Drawing.Size(175, 20)
        Me.TRFCFiscal.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(220, 16)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(94, 13)
        Me.Label47.TabIndex = 232
        Me.Label47.Text = "Nombre del banco"
        '
        'TBancoFiscal
        '
        Me.TBancoFiscal.AcceptsReturn = True
        Me.TBancoFiscal.AcceptsTab = True
        Me.TBancoFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBancoFiscal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBancoFiscal.Location = New System.Drawing.Point(195, 30)
        Me.TBancoFiscal.Name = "TBancoFiscal"
        Me.TBancoFiscal.Size = New System.Drawing.Size(214, 20)
        Me.TBancoFiscal.TabIndex = 1
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(19, 14)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(85, 13)
        Me.Label49.TabIndex = 234
        Me.Label49.Text = "Cuenta bancaria"
        '
        'TCtaBanFiscal
        '
        Me.TCtaBanFiscal.AcceptsReturn = True
        Me.TCtaBanFiscal.AcceptsTab = True
        Me.TCtaBanFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCtaBanFiscal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCtaBanFiscal.Location = New System.Drawing.Point(16, 30)
        Me.TCtaBanFiscal.Name = "TCtaBanFiscal"
        Me.TCtaBanFiscal.Size = New System.Drawing.Size(175, 20)
        Me.TCtaBanFiscal.TabIndex = 0
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.Fg.ColumnInfo = "4,1,0,0,0,95,Columns:1{Width:191;Caption:""Cuenta del Banco"";AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) &
    "2{Width:212;Caption:""Nombre del banco"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Width:121;Caption:""RFC del Banco"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.IgnoreDiacritics = True
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(6, 90)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(581, 99)
        Me.Fg.TabIndex = 3
        '
        'TCVE_OBS
        '
        Me.TCVE_OBS.AcceptsReturn = True
        Me.TCVE_OBS.AcceptsTab = True
        Me.TCVE_OBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_OBS.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OBS.Location = New System.Drawing.Point(617, 264)
        Me.TCVE_OBS.Multiline = True
        Me.TCVE_OBS.Name = "TCVE_OBS"
        Me.TCVE_OBS.Size = New System.Drawing.Size(585, 35)
        Me.TCVE_OBS.TabIndex = 6
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(627, 248)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 13)
        Me.Label46.TabIndex = 1
        Me.Label46.Text = "Observaciones"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label74)
        Me.GroupBox4.Controls.Add(Me.BtnPaisResiFiscal)
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.T)
        Me.GroupBox4.Controls.Add(Me.TCVE_PAIS_SAT)
        Me.GroupBox4.Controls.Add(Me.Label57)
        Me.GroupBox4.Controls.Add(Me.C1Button1)
        Me.GroupBox4.Controls.Add(Me.TNUMIDREGFISCAL)
        Me.GroupBox4.Controls.Add(Me.Label77)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 32)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(606, 151)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Residente en el extranjero"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(80, 75)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(70, 16)
        Me.Label74.TabIndex = 291
        Me.Label74.Text = "Addendas"
        '
        'BtnPaisResiFiscal
        '
        Me.BtnPaisResiFiscal.AutoSize = True
        Me.BtnPaisResiFiscal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPaisResiFiscal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaisResiFiscal.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnPaisResiFiscal.Location = New System.Drawing.Point(283, 41)
        Me.BtnPaisResiFiscal.Name = "BtnPaisResiFiscal"
        Me.BtnPaisResiFiscal.Size = New System.Drawing.Size(22, 22)
        Me.BtnPaisResiFiscal.TabIndex = 282
        Me.BtnPaisResiFiscal.UseVisualStyleBackColor = True
        Me.BtnPaisResiFiscal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(11, 44)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(139, 15)
        Me.Label59.TabIndex = 1
        Me.Label59.Text = "País (Residencia Fiscal)"
        '
        'T
        '
        Me.T.AcceptsReturn = True
        Me.T.AcceptsTab = True
        Me.T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T.Location = New System.Drawing.Point(153, 72)
        Me.T.Name = "T"
        Me.T.Size = New System.Drawing.Size(55, 21)
        Me.T.TabIndex = 290
        '
        'TCVE_PAIS_SAT
        '
        Me.TCVE_PAIS_SAT.AcceptsReturn = True
        Me.TCVE_PAIS_SAT.AcceptsTab = True
        Me.TCVE_PAIS_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_PAIS_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PAIS_SAT.Location = New System.Drawing.Point(153, 41)
        Me.TCVE_PAIS_SAT.Name = "TCVE_PAIS_SAT"
        Me.TCVE_PAIS_SAT.Size = New System.Drawing.Size(124, 21)
        Me.TCVE_PAIS_SAT.TabIndex = 1
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(9, 17)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(224, 15)
        Me.Label57.TabIndex = 230
        Me.Label57.Text = "Número de Registro de Identidad Fiscal"
        '
        'C1Button1
        '
        Me.C1Button1.AutoSize = True
        Me.C1Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.C1Button1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.C1Button1.Location = New System.Drawing.Point(211, 72)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(22, 22)
        Me.C1Button1.TabIndex = 292
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TNUMIDREGFISCAL
        '
        Me.TNUMIDREGFISCAL.AcceptsReturn = True
        Me.TNUMIDREGFISCAL.AcceptsTab = True
        Me.TNUMIDREGFISCAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMIDREGFISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMIDREGFISCAL.Location = New System.Drawing.Point(236, 14)
        Me.TNUMIDREGFISCAL.Name = "TNUMIDREGFISCAL"
        Me.TNUMIDREGFISCAL.Size = New System.Drawing.Size(364, 21)
        Me.TNUMIDREGFISCAL.TabIndex = 0
        '
        'Label77
        '
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label77.Location = New System.Drawing.Point(236, 72)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(364, 21)
        Me.Label77.TabIndex = 293
        '
        'PAG4
        '
        Me.PAG4.Controls.Add(Me.FgA)
        Me.PAG4.Controls.Add(Me.GroupBox3)
        Me.PAG4.Location = New System.Drawing.Point(1, 24)
        Me.PAG4.Name = "PAG4"
        Me.PAG4.Size = New System.Drawing.Size(1374, 432)
        Me.PAG4.TabIndex = 3
        Me.PAG4.Text = "Datos Adicionales"
        '
        'FgA
        '
        Me.FgA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgA.AutoGenerateColumns = False
        Me.FgA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgA.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:118;AllowSorting:False;Caption:""Campo libre"";AllowDr" &
    "agging:False;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:466;Caption:""Descripción"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.FgA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgA.IgnoreDiacritics = True
        Me.FgA.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.FgA.Location = New System.Drawing.Point(21, 266)
        Me.FgA.Name = "FgA"
        Me.FgA.Rows.DefaultSize = 19
        Me.FgA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgA.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgA.Size = New System.Drawing.Size(641, 163)
        Me.FgA.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FgL)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(663, 248)
        Me.GroupBox3.TabIndex = 249
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Campos libres del usuario"
        '
        'FgL
        '
        Me.FgL.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgL.AutoGenerateColumns = False
        Me.FgL.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgL.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:118;AllowSorting:False;Caption:""Campo libre"";AllowDr" &
    "agging:False;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:466;Caption:""Descripción"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.FgL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgL.IgnoreDiacritics = True
        Me.FgL.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.FgL.Location = New System.Drawing.Point(6, 19)
        Me.FgL.Name = "FgL"
        Me.FgL.Rows.DefaultSize = 19
        Me.FgL.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgL.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgL.Size = New System.Drawing.Size(638, 224)
        Me.FgL.TabIndex = 0
        '
        'PAG3
        '
        Me.PAG3.Controls.Add(Me.GroupBox1)
        Me.PAG3.Location = New System.Drawing.Point(1, 24)
        Me.PAG3.Name = "PAG3"
        Me.PAG3.Size = New System.Drawing.Size(1374, 432)
        Me.PAG3.TabIndex = 4
        Me.PAG3.Text = "Mercancias"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label101)
        Me.GroupBox1.Controls.Add(Me.Label100)
        Me.GroupBox1.Controls.Add(Me.Label99)
        Me.GroupBox1.Controls.Add(Me.TCOLAI)
        Me.GroupBox1.Controls.Add(Me.TCOLAC)
        Me.GroupBox1.Controls.Add(Me.TCOLAG)
        Me.GroupBox1.Controls.Add(Me.TCOLAH)
        Me.GroupBox1.Controls.Add(Me.TCOLAF)
        Me.GroupBox1.Controls.Add(Me.TCOLAJ)
        Me.GroupBox1.Controls.Add(Me.Label106)
        Me.GroupBox1.Controls.Add(Me.Label107)
        Me.GroupBox1.Controls.Add(Me.TCOLAE)
        Me.GroupBox1.Controls.Add(Me.Label108)
        Me.GroupBox1.Controls.Add(Me.Label109)
        Me.GroupBox1.Controls.Add(Me.Label110)
        Me.GroupBox1.Controls.Add(Me.TCOLAD)
        Me.GroupBox1.Controls.Add(Me.Label111)
        Me.GroupBox1.Controls.Add(Me.Label112)
        Me.GroupBox1.Controls.Add(Me.Label82)
        Me.GroupBox1.Controls.Add(Me.TCOLU)
        Me.GroupBox1.Controls.Add(Me.Label84)
        Me.GroupBox1.Controls.Add(Me.TCOLAB)
        Me.GroupBox1.Controls.Add(Me.Label86)
        Me.GroupBox1.Controls.Add(Me.TCOLO)
        Me.GroupBox1.Controls.Add(Me.TCOLS)
        Me.GroupBox1.Controls.Add(Me.Label88)
        Me.GroupBox1.Controls.Add(Me.TCOLT)
        Me.GroupBox1.Controls.Add(Me.Label89)
        Me.GroupBox1.Controls.Add(Me.TCOLAA)
        Me.GroupBox1.Controls.Add(Me.Label90)
        Me.GroupBox1.Controls.Add(Me.TCOLR)
        Me.GroupBox1.Controls.Add(Me.Label91)
        Me.GroupBox1.Controls.Add(Me.TCOLV)
        Me.GroupBox1.Controls.Add(Me.Label92)
        Me.GroupBox1.Controls.Add(Me.TCOLZ)
        Me.GroupBox1.Controls.Add(Me.Label93)
        Me.GroupBox1.Controls.Add(Me.TCOLQ)
        Me.GroupBox1.Controls.Add(Me.Label94)
        Me.GroupBox1.Controls.Add(Me.TCOLW)
        Me.GroupBox1.Controls.Add(Me.Label95)
        Me.GroupBox1.Controls.Add(Me.TCOLY)
        Me.GroupBox1.Controls.Add(Me.Label96)
        Me.GroupBox1.Controls.Add(Me.TCOLP)
        Me.GroupBox1.Controls.Add(Me.Label97)
        Me.GroupBox1.Controls.Add(Me.TCOLX)
        Me.GroupBox1.Controls.Add(Me.Label98)
        Me.GroupBox1.Controls.Add(Me.Label72)
        Me.GroupBox1.Controls.Add(Me.TCOLN)
        Me.GroupBox1.Controls.Add(Me.Label69)
        Me.GroupBox1.Controls.Add(Me.Lt14)
        Me.GroupBox1.Controls.Add(Me.TCOLM)
        Me.GroupBox1.Controls.Add(Me.Lt13)
        Me.GroupBox1.Controls.Add(Me.TCOLA)
        Me.GroupBox1.Controls.Add(Me.TCOLE)
        Me.GroupBox1.Controls.Add(Me.Lt12)
        Me.GroupBox1.Controls.Add(Me.TCOLF)
        Me.GroupBox1.Controls.Add(Me.Lt11)
        Me.GroupBox1.Controls.Add(Me.TCOLL)
        Me.GroupBox1.Controls.Add(Me.Lt10)
        Me.GroupBox1.Controls.Add(Me.TCOLD)
        Me.GroupBox1.Controls.Add(Me.Lt9)
        Me.GroupBox1.Controls.Add(Me.TCOLG)
        Me.GroupBox1.Controls.Add(Me.Lt8)
        Me.GroupBox1.Controls.Add(Me.TCOLK)
        Me.GroupBox1.Controls.Add(Me.Lt7)
        Me.GroupBox1.Controls.Add(Me.TCOLC)
        Me.GroupBox1.Controls.Add(Me.Lt5)
        Me.GroupBox1.Controls.Add(Me.TCOLH)
        Me.GroupBox1.Controls.Add(Me.Lt4)
        Me.GroupBox1.Controls.Add(Me.TCOLJ)
        Me.GroupBox1.Controls.Add(Me.Lt3)
        Me.GroupBox1.Controls.Add(Me.TCOLB)
        Me.GroupBox1.Controls.Add(Me.Lt2)
        Me.GroupBox1.Controls.Add(Me.TCOLI)
        Me.GroupBox1.Controls.Add(Me.Lt1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 403)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importar"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.Location = New System.Drawing.Point(638, 13)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(89, 15)
        Me.Label101.TabIndex = 693
        Me.Label101.Text = "Columna excel"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(395, 13)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(89, 15)
        Me.Label100.TabIndex = 692
        Me.Label100.Text = "Columna excel"
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(566, 164)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(76, 15)
        Me.Label99.TabIndex = 691
        Me.Label99.Text = "Tipo Materia"
        '
        'TCOLAI
        '
        Me.TCOLAI.AcceptsReturn = True
        Me.TCOLAI.AcceptsTab = True
        Me.TCOLAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAI.ForeColor = System.Drawing.Color.Black
        Me.TCOLAI.Location = New System.Drawing.Point(647, 162)
        Me.TCOLAI.MaxLength = 2
        Me.TCOLAI.Name = "TCOLAI"
        Me.TCOLAI.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAI.TabIndex = 678
        Me.TCOLAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLAC
        '
        Me.TCOLAC.AcceptsReturn = True
        Me.TCOLAC.AcceptsTab = True
        Me.TCOLAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAC.ForeColor = System.Drawing.Color.Black
        Me.TCOLAC.Location = New System.Drawing.Point(647, 30)
        Me.TCOLAC.MaxLength = 2
        Me.TCOLAC.Name = "TCOLAC"
        Me.TCOLAC.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAC.TabIndex = 666
        Me.TCOLAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLAG
        '
        Me.TCOLAG.AcceptsReturn = True
        Me.TCOLAG.AcceptsTab = True
        Me.TCOLAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAG.ForeColor = System.Drawing.Color.Black
        Me.TCOLAG.Location = New System.Drawing.Point(647, 118)
        Me.TCOLAG.MaxLength = 2
        Me.TCOLAG.Name = "TCOLAG"
        Me.TCOLAG.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAG.TabIndex = 673
        Me.TCOLAG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLAH
        '
        Me.TCOLAH.AcceptsReturn = True
        Me.TCOLAH.AcceptsTab = True
        Me.TCOLAH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAH.ForeColor = System.Drawing.Color.Black
        Me.TCOLAH.Location = New System.Drawing.Point(647, 140)
        Me.TCOLAH.MaxLength = 2
        Me.TCOLAH.Name = "TCOLAH"
        Me.TCOLAH.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAH.TabIndex = 675
        Me.TCOLAH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLAF
        '
        Me.TCOLAF.AcceptsReturn = True
        Me.TCOLAF.AcceptsTab = True
        Me.TCOLAF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAF.ForeColor = System.Drawing.Color.Black
        Me.TCOLAF.Location = New System.Drawing.Point(647, 96)
        Me.TCOLAF.MaxLength = 2
        Me.TCOLAF.Name = "TCOLAF"
        Me.TCOLAF.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAF.TabIndex = 672
        Me.TCOLAF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLAJ
        '
        Me.TCOLAJ.AcceptsReturn = True
        Me.TCOLAJ.AcceptsTab = True
        Me.TCOLAJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAJ.ForeColor = System.Drawing.Color.Black
        Me.TCOLAJ.Location = New System.Drawing.Point(647, 185)
        Me.TCOLAJ.MaxLength = 2
        Me.TCOLAJ.Name = "TCOLAJ"
        Me.TCOLAJ.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAJ.TabIndex = 679
        Me.TCOLAJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(525, 187)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(117, 15)
        Me.Label106.TabIndex = 676
        Me.Label106.Text = "Descripción Materia"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.Location = New System.Drawing.Point(552, 142)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(90, 15)
        Me.Label107.TabIndex = 674
        Me.Label107.Text = "Uso Autorizado"
        '
        'TCOLAE
        '
        Me.TCOLAE.AcceptsReturn = True
        Me.TCOLAE.AcceptsTab = True
        Me.TCOLAE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAE.ForeColor = System.Drawing.Color.Black
        Me.TCOLAE.Location = New System.Drawing.Point(647, 74)
        Me.TCOLAE.MaxLength = 2
        Me.TCOLAE.Name = "TCOLAE"
        Me.TCOLAE.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAE.TabIndex = 670
        Me.TCOLAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.Location = New System.Drawing.Point(537, 120)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(105, 15)
        Me.Label108.TabIndex = 671
        Me.Label108.Text = "Datos Maquilador"
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.Location = New System.Drawing.Point(536, 98)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(106, 15)
        Me.Label109.TabIndex = 669
        Me.Label109.Text = "Datos Formulador"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.Location = New System.Drawing.Point(542, 76)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(100, 15)
        Me.Label110.TabIndex = 668
        Me.Label110.Text = "Datos Fabricante"
        '
        'TCOLAD
        '
        Me.TCOLAD.AcceptsReturn = True
        Me.TCOLAD.AcceptsTab = True
        Me.TCOLAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAD.ForeColor = System.Drawing.Color.Black
        Me.TCOLAD.Location = New System.Drawing.Point(647, 52)
        Me.TCOLAD.MaxLength = 2
        Me.TCOLAD.Name = "TCOLAD"
        Me.TCOLAD.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAD.TabIndex = 667
        Me.TCOLAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.Location = New System.Drawing.Point(487, 54)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(155, 15)
        Me.Label111.TabIndex = 665
        Me.Label111.Text = "Reg. San. Plag. COFEPRIS"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.Location = New System.Drawing.Point(503, 32)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(139, 15)
        Me.Label112.TabIndex = 664
        Me.Label112.Text = "Razón Social Emp. Imp."
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(297, 164)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(103, 15)
        Me.Label82.TabIndex = 663
        Me.Label82.Text = "Fecha Caducidad"
        '
        'TCOLU
        '
        Me.TCOLU.AcceptsReturn = True
        Me.TCOLU.AcceptsTab = True
        Me.TCOLU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLU.ForeColor = System.Drawing.Color.Black
        Me.TCOLU.Location = New System.Drawing.Point(405, 162)
        Me.TCOLU.MaxLength = 2
        Me.TCOLU.Name = "TCOLU"
        Me.TCOLU.Size = New System.Drawing.Size(70, 21)
        Me.TCOLU.TabIndex = 650
        Me.TCOLU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.Location = New System.Drawing.Point(339, 319)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(61, 15)
        Me.Label84.TabIndex = 660
        Me.Label84.Text = "Num. Cas"
        '
        'TCOLAB
        '
        Me.TCOLAB.AcceptsReturn = True
        Me.TCOLAB.AcceptsTab = True
        Me.TCOLAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAB.ForeColor = System.Drawing.Color.Black
        Me.TCOLAB.Location = New System.Drawing.Point(405, 317)
        Me.TCOLAB.MaxLength = 2
        Me.TCOLAB.Name = "TCOLAB"
        Me.TCOLAB.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAB.TabIndex = 662
        Me.TCOLAB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(292, 297)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(111, 15)
        Me.Label86.TabIndex = 657
        Me.Label86.Text = "Folio Impo VUCEM"
        '
        'TCOLO
        '
        Me.TCOLO.AcceptsReturn = True
        Me.TCOLO.AcceptsTab = True
        Me.TCOLO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLO.ForeColor = System.Drawing.Color.Black
        Me.TCOLO.Location = New System.Drawing.Point(405, 30)
        Me.TCOLO.MaxLength = 2
        Me.TCOLO.Name = "TCOLO"
        Me.TCOLO.Size = New System.Drawing.Size(70, 21)
        Me.TCOLO.TabIndex = 638
        Me.TCOLO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLS
        '
        Me.TCOLS.AcceptsReturn = True
        Me.TCOLS.AcceptsTab = True
        Me.TCOLS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLS.ForeColor = System.Drawing.Color.Black
        Me.TCOLS.Location = New System.Drawing.Point(405, 118)
        Me.TCOLS.MaxLength = 2
        Me.TCOLS.Name = "TCOLS"
        Me.TCOLS.Size = New System.Drawing.Size(70, 21)
        Me.TCOLS.TabIndex = 645
        Me.TCOLS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(282, 274)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(121, 15)
        Me.Label88.TabIndex = 655
        Me.Label88.Text = "Permiso Importación"
        '
        'TCOLT
        '
        Me.TCOLT.AcceptsReturn = True
        Me.TCOLT.AcceptsTab = True
        Me.TCOLT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLT.ForeColor = System.Drawing.Color.Black
        Me.TCOLT.Location = New System.Drawing.Point(405, 140)
        Me.TCOLT.MaxLength = 2
        Me.TCOLT.Name = "TCOLT"
        Me.TCOLT.Size = New System.Drawing.Size(70, 21)
        Me.TCOLT.TabIndex = 647
        Me.TCOLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(265, 253)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(135, 15)
        Me.Label89.TabIndex = 653
        Me.Label89.Text = "Reg. Sanitario Folio Aut"
        '
        'TCOLAA
        '
        Me.TCOLAA.AcceptsReturn = True
        Me.TCOLAA.AcceptsTab = True
        Me.TCOLAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLAA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLAA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLAA.ForeColor = System.Drawing.Color.Black
        Me.TCOLAA.Location = New System.Drawing.Point(405, 295)
        Me.TCOLAA.MaxLength = 2
        Me.TCOLAA.Name = "TCOLAA"
        Me.TCOLAA.Size = New System.Drawing.Size(70, 21)
        Me.TCOLAA.TabIndex = 661
        Me.TCOLAA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(281, 229)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(119, 15)
        Me.Label90.TabIndex = 652
        Me.Label90.Text = "ID Cond. Esp Transp"
        '
        'TCOLR
        '
        Me.TCOLR.AcceptsReturn = True
        Me.TCOLR.AcceptsTab = True
        Me.TCOLR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLR.ForeColor = System.Drawing.Color.Black
        Me.TCOLR.Location = New System.Drawing.Point(405, 96)
        Me.TCOLR.MaxLength = 2
        Me.TCOLR.Name = "TCOLR"
        Me.TCOLR.Size = New System.Drawing.Size(70, 21)
        Me.TCOLR.TabIndex = 644
        Me.TCOLR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.Location = New System.Drawing.Point(267, 207)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(136, 15)
        Me.Label91.TabIndex = 649
        Me.Label91.Text = "ID Forma Farmaceutica"
        '
        'TCOLV
        '
        Me.TCOLV.AcceptsReturn = True
        Me.TCOLV.AcceptsTab = True
        Me.TCOLV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLV.ForeColor = System.Drawing.Color.Black
        Me.TCOLV.Location = New System.Drawing.Point(405, 185)
        Me.TCOLV.MaxLength = 2
        Me.TCOLV.Name = "TCOLV"
        Me.TCOLV.Size = New System.Drawing.Size(70, 21)
        Me.TCOLV.TabIndex = 651
        Me.TCOLV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.Location = New System.Drawing.Point(290, 187)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(110, 15)
        Me.Label92.TabIndex = 648
        Me.Label92.Text = "Lote Medicamento"
        '
        'TCOLZ
        '
        Me.TCOLZ.AcceptsReturn = True
        Me.TCOLZ.AcceptsTab = True
        Me.TCOLZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLZ.ForeColor = System.Drawing.Color.Black
        Me.TCOLZ.Location = New System.Drawing.Point(405, 273)
        Me.TCOLZ.MaxLength = 2
        Me.TCOLZ.Name = "TCOLZ"
        Me.TCOLZ.Size = New System.Drawing.Size(70, 21)
        Me.TCOLZ.TabIndex = 659
        Me.TCOLZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.Location = New System.Drawing.Point(335, 142)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(65, 15)
        Me.Label93.TabIndex = 646
        Me.Label93.Text = "Fabricante"
        '
        'TCOLQ
        '
        Me.TCOLQ.AcceptsReturn = True
        Me.TCOLQ.AcceptsTab = True
        Me.TCOLQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLQ.ForeColor = System.Drawing.Color.Black
        Me.TCOLQ.Location = New System.Drawing.Point(405, 74)
        Me.TCOLQ.MaxLength = 2
        Me.TCOLQ.Name = "TCOLQ"
        Me.TCOLQ.Size = New System.Drawing.Size(70, 21)
        Me.TCOLQ.TabIndex = 642
        Me.TCOLQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(286, 120)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(117, 15)
        Me.Label94.TabIndex = 643
        Me.Label94.Text = "Den. Distintiva Prod."
        '
        'TCOLW
        '
        Me.TCOLW.AcceptsReturn = True
        Me.TCOLW.AcceptsTab = True
        Me.TCOLW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLW.ForeColor = System.Drawing.Color.Black
        Me.TCOLW.Location = New System.Drawing.Point(405, 207)
        Me.TCOLW.MaxLength = 2
        Me.TCOLW.Name = "TCOLW"
        Me.TCOLW.Size = New System.Drawing.Size(70, 21)
        Me.TCOLW.TabIndex = 654
        Me.TCOLW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(285, 98)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(118, 15)
        Me.Label95.TabIndex = 641
        Me.Label95.Text = "Den. Genérica Prod."
        '
        'TCOLY
        '
        Me.TCOLY.AcceptsReturn = True
        Me.TCOLY.AcceptsTab = True
        Me.TCOLY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLY.ForeColor = System.Drawing.Color.Black
        Me.TCOLY.Location = New System.Drawing.Point(405, 251)
        Me.TCOLY.MaxLength = 2
        Me.TCOLY.Name = "TCOLY"
        Me.TCOLY.Size = New System.Drawing.Size(70, 21)
        Me.TCOLY.TabIndex = 658
        Me.TCOLY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.Location = New System.Drawing.Point(317, 77)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(86, 15)
        Me.Label96.TabIndex = 640
        Me.Label96.Text = "Nom. Quimico"
        '
        'TCOLP
        '
        Me.TCOLP.AcceptsReturn = True
        Me.TCOLP.AcceptsTab = True
        Me.TCOLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLP.ForeColor = System.Drawing.Color.Black
        Me.TCOLP.Location = New System.Drawing.Point(405, 52)
        Me.TCOLP.MaxLength = 2
        Me.TCOLP.Name = "TCOLP"
        Me.TCOLP.Size = New System.Drawing.Size(70, 21)
        Me.TCOLP.TabIndex = 639
        Me.TCOLP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.Location = New System.Drawing.Point(312, 54)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(91, 15)
        Me.Label97.TabIndex = 637
        Me.Label97.Text = "Nom Ing. Activo"
        '
        'TCOLX
        '
        Me.TCOLX.AcceptsReturn = True
        Me.TCOLX.AcceptsTab = True
        Me.TCOLX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLX.ForeColor = System.Drawing.Color.Black
        Me.TCOLX.Location = New System.Drawing.Point(405, 229)
        Me.TCOLX.MaxLength = 2
        Me.TCOLX.Name = "TCOLX"
        Me.TCOLX.Size = New System.Drawing.Size(70, 21)
        Me.TCOLX.TabIndex = 656
        Me.TCOLX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(283, 32)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(120, 15)
        Me.Label98.TabIndex = 636
        Me.Label98.Text = "ID Sector COFEPRIS"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(48, 164)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(112, 15)
        Me.Label72.TabIndex = 635
        Me.Label72.Text = "Cve. mat. Peligroso"
        '
        'TCOLN
        '
        Me.TCOLN.AcceptsReturn = True
        Me.TCOLN.AcceptsTab = True
        Me.TCOLN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLN.ForeColor = System.Drawing.Color.Black
        Me.TCOLN.Location = New System.Drawing.Point(165, 162)
        Me.TCOLN.MaxLength = 2
        Me.TCOLN.Name = "TCOLN"
        Me.TCOLN.Size = New System.Drawing.Size(70, 21)
        Me.TCOLN.TabIndex = 7
        Me.TCOLN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(157, 13)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(89, 15)
        Me.Label69.TabIndex = 633
        Me.Label69.Text = "Columna excel"
        '
        'Lt14
        '
        Me.Lt14.AutoSize = True
        Me.Lt14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt14.Location = New System.Drawing.Point(71, 319)
        Me.Lt14.Name = "Lt14"
        Me.Lt14.Size = New System.Drawing.Size(89, 15)
        Me.Lt14.TabIndex = 12
        Me.Lt14.Text = "UUID Com. Ext"
        '
        'TCOLM
        '
        Me.TCOLM.AcceptsReturn = True
        Me.TCOLM.AcceptsTab = True
        Me.TCOLM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLM.ForeColor = System.Drawing.Color.Black
        Me.TCOLM.Location = New System.Drawing.Point(165, 317)
        Me.TCOLM.MaxLength = 2
        Me.TCOLM.Name = "TCOLM"
        Me.TCOLM.Size = New System.Drawing.Size(70, 21)
        Me.TCOLM.TabIndex = 14
        Me.TCOLM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt13
        '
        Me.Lt13.AutoSize = True
        Me.Lt13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt13.Location = New System.Drawing.Point(40, 296)
        Me.Lt13.Name = "Lt13"
        Me.Lt13.Size = New System.Drawing.Size(120, 15)
        Me.Lt13.TabIndex = 11
        Me.Lt13.Text = "ID Fracc. arancelaria"
        '
        'TCOLA
        '
        Me.TCOLA.AcceptsReturn = True
        Me.TCOLA.AcceptsTab = True
        Me.TCOLA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLA.ForeColor = System.Drawing.Color.Black
        Me.TCOLA.Location = New System.Drawing.Point(165, 30)
        Me.TCOLA.MaxLength = 2
        Me.TCOLA.Name = "TCOLA"
        Me.TCOLA.Size = New System.Drawing.Size(70, 21)
        Me.TCOLA.TabIndex = 1
        Me.TCOLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCOLE
        '
        Me.TCOLE.AcceptsReturn = True
        Me.TCOLE.AcceptsTab = True
        Me.TCOLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLE.ForeColor = System.Drawing.Color.Black
        Me.TCOLE.Location = New System.Drawing.Point(165, 118)
        Me.TCOLE.MaxLength = 2
        Me.TCOLE.Name = "TCOLE"
        Me.TCOLE.Size = New System.Drawing.Size(70, 21)
        Me.TCOLE.TabIndex = 5
        Me.TCOLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt12
        '
        Me.Lt12.AutoSize = True
        Me.Lt12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt12.Location = New System.Drawing.Point(107, 274)
        Me.Lt12.Name = "Lt12"
        Me.Lt12.Size = New System.Drawing.Size(53, 15)
        Me.Lt12.TabIndex = 10
        Me.Lt12.Text = "Moneda"
        '
        'TCOLF
        '
        Me.TCOLF.AcceptsReturn = True
        Me.TCOLF.AcceptsTab = True
        Me.TCOLF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLF.ForeColor = System.Drawing.Color.Black
        Me.TCOLF.Location = New System.Drawing.Point(165, 140)
        Me.TCOLF.MaxLength = 2
        Me.TCOLF.Name = "TCOLF"
        Me.TCOLF.Size = New System.Drawing.Size(70, 21)
        Me.TCOLF.TabIndex = 6
        Me.TCOLF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt11
        '
        Me.Lt11.AutoSize = True
        Me.Lt11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt11.Location = New System.Drawing.Point(58, 252)
        Me.Lt11.Name = "Lt11"
        Me.Lt11.Size = New System.Drawing.Size(102, 15)
        Me.Lt11.TabIndex = 9
        Me.Lt11.Text = "Valor mercancias"
        '
        'TCOLL
        '
        Me.TCOLL.AcceptsReturn = True
        Me.TCOLL.AcceptsTab = True
        Me.TCOLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLL.ForeColor = System.Drawing.Color.Black
        Me.TCOLL.Location = New System.Drawing.Point(165, 295)
        Me.TCOLL.MaxLength = 2
        Me.TCOLL.Name = "TCOLL"
        Me.TCOLL.Size = New System.Drawing.Size(70, 21)
        Me.TCOLL.TabIndex = 13
        Me.TCOLL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt10
        '
        Me.Lt10.AutoSize = True
        Me.Lt10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt10.Location = New System.Drawing.Point(125, 230)
        Me.Lt10.Name = "Lt10"
        Me.Lt10.Size = New System.Drawing.Size(35, 15)
        Me.Lt10.TabIndex = 8
        Me.Lt10.Text = "Peso"
        '
        'TCOLD
        '
        Me.TCOLD.AcceptsReturn = True
        Me.TCOLD.AcceptsTab = True
        Me.TCOLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLD.ForeColor = System.Drawing.Color.Black
        Me.TCOLD.Location = New System.Drawing.Point(165, 96)
        Me.TCOLD.MaxLength = 2
        Me.TCOLD.Name = "TCOLD"
        Me.TCOLD.Size = New System.Drawing.Size(70, 21)
        Me.TCOLD.TabIndex = 4
        Me.TCOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt9
        '
        Me.Lt9.AutoSize = True
        Me.Lt9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt9.Location = New System.Drawing.Point(66, 208)
        Me.Lt9.Name = "Lt9"
        Me.Lt9.Size = New System.Drawing.Size(94, 15)
        Me.Lt9.TabIndex = 7
        Me.Lt9.Text = "Desc. Embalaje"
        '
        'TCOLG
        '
        Me.TCOLG.AcceptsReturn = True
        Me.TCOLG.AcceptsTab = True
        Me.TCOLG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLG.ForeColor = System.Drawing.Color.Black
        Me.TCOLG.Location = New System.Drawing.Point(165, 185)
        Me.TCOLG.MaxLength = 2
        Me.TCOLG.Name = "TCOLG"
        Me.TCOLG.Size = New System.Drawing.Size(70, 21)
        Me.TCOLG.TabIndex = 8
        Me.TCOLG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt8
        '
        Me.Lt8.AutoSize = True
        Me.Lt8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt8.Location = New System.Drawing.Point(85, 186)
        Me.Lt8.Name = "Lt8"
        Me.Lt8.Size = New System.Drawing.Size(75, 15)
        Me.Lt8.TabIndex = 6
        Me.Lt8.Text = "ID Embalaje"
        '
        'TCOLK
        '
        Me.TCOLK.AcceptsReturn = True
        Me.TCOLK.AcceptsTab = True
        Me.TCOLK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLK.ForeColor = System.Drawing.Color.Black
        Me.TCOLK.Location = New System.Drawing.Point(165, 273)
        Me.TCOLK.MaxLength = 2
        Me.TCOLK.Name = "TCOLK"
        Me.TCOLK.Size = New System.Drawing.Size(70, 21)
        Me.TCOLK.TabIndex = 12
        Me.TCOLK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(57, 142)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(103, 15)
        Me.Lt7.TabIndex = 5
        Me.Lt7.Text = "Es Mat. Peligroso"
        '
        'TCOLC
        '
        Me.TCOLC.AcceptsReturn = True
        Me.TCOLC.AcceptsTab = True
        Me.TCOLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLC.ForeColor = System.Drawing.Color.Black
        Me.TCOLC.Location = New System.Drawing.Point(165, 74)
        Me.TCOLC.MaxLength = 2
        Me.TCOLC.Name = "TCOLC"
        Me.TCOLC.Size = New System.Drawing.Size(70, 21)
        Me.TCOLC.TabIndex = 3
        Me.TCOLC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(47, 120)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(113, 15)
        Me.Lt5.TabIndex = 4
        Me.Lt5.Text = "Descrip. mercancia"
        '
        'TCOLH
        '
        Me.TCOLH.AcceptsReturn = True
        Me.TCOLH.AcceptsTab = True
        Me.TCOLH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLH.ForeColor = System.Drawing.Color.Black
        Me.TCOLH.Location = New System.Drawing.Point(165, 207)
        Me.TCOLH.MaxLength = 2
        Me.TCOLH.Name = "TCOLH"
        Me.TCOLH.Size = New System.Drawing.Size(70, 21)
        Me.TCOLH.TabIndex = 9
        Me.TCOLH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.Location = New System.Drawing.Point(80, 98)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(80, 15)
        Me.Lt4.TabIndex = 3
        Me.Lt4.Text = "ID mercancia"
        '
        'TCOLJ
        '
        Me.TCOLJ.AcceptsReturn = True
        Me.TCOLJ.AcceptsTab = True
        Me.TCOLJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLJ.ForeColor = System.Drawing.Color.Black
        Me.TCOLJ.Location = New System.Drawing.Point(165, 251)
        Me.TCOLJ.MaxLength = 2
        Me.TCOLJ.Name = "TCOLJ"
        Me.TCOLJ.Size = New System.Drawing.Size(70, 21)
        Me.TCOLJ.TabIndex = 11
        Me.TCOLJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.Location = New System.Drawing.Point(67, 77)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(93, 15)
        Me.Lt3.TabIndex = 2
        Me.Lt3.Text = "Descrip. unidad"
        '
        'TCOLB
        '
        Me.TCOLB.AcceptsReturn = True
        Me.TCOLB.AcceptsTab = True
        Me.TCOLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLB.ForeColor = System.Drawing.Color.Black
        Me.TCOLB.Location = New System.Drawing.Point(165, 52)
        Me.TCOLB.MaxLength = 2
        Me.TCOLB.Name = "TCOLB"
        Me.TCOLB.Size = New System.Drawing.Size(70, 21)
        Me.TCOLB.TabIndex = 2
        Me.TCOLB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(98, 54)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(62, 15)
        Me.Lt2.TabIndex = 1
        Me.Lt2.Text = "ID Unidad"
        '
        'TCOLI
        '
        Me.TCOLI.AcceptsReturn = True
        Me.TCOLI.AcceptsTab = True
        Me.TCOLI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCOLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLI.ForeColor = System.Drawing.Color.Black
        Me.TCOLI.Location = New System.Drawing.Point(165, 229)
        Me.TCOLI.MaxLength = 2
        Me.TCOLI.Name = "TCOLI"
        Me.TCOLI.Size = New System.Drawing.Size(70, 21)
        Me.TCOLI.TabIndex = 10
        Me.TCOLI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(104, 32)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(56, 15)
        Me.Lt1.TabIndex = 0
        Me.Lt1.Text = "Cantidad"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(1138, 949)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 17)
        Me.Label36.TabIndex = 288
        Me.Label36.Text = "Ultima venta"
        Me.Label36.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(860, 950)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(83, 17)
        Me.Label35.TabIndex = 287
        Me.Label35.Text = "Ultimo pago"
        Me.Label35.Visible = False
        '
        'FCH_ULTCOM
        '
        Me.FCH_ULTCOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FCH_ULTCOM.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FCH_ULTCOM.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FCH_ULTCOM.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FCH_ULTCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FCH_ULTCOM.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FCH_ULTCOM.Location = New System.Drawing.Point(1119, 969)
        Me.FCH_ULTCOM.Name = "FCH_ULTCOM"
        Me.FCH_ULTCOM.Size = New System.Drawing.Size(150, 20)
        Me.FCH_ULTCOM.TabIndex = 18
        Me.FCH_ULTCOM.Tag = Nothing
        Me.FCH_ULTCOM.Visible = False
        Me.FCH_ULTCOM.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FCH_ULTCOM.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FCH_ULTCOM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(1067, 970)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(45, 16)
        Me.Label43.TabIndex = 264
        Me.Label43.Text = "Fecha"
        Me.Label43.Visible = False
        '
        'ULT_PAGOF
        '
        Me.ULT_PAGOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ULT_PAGOF.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.ULT_PAGOF.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.ULT_PAGOF.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.ULT_PAGOF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ULT_PAGOF.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.ULT_PAGOF.Location = New System.Drawing.Point(845, 970)
        Me.ULT_PAGOF.Name = "ULT_PAGOF"
        Me.ULT_PAGOF.Size = New System.Drawing.Size(145, 20)
        Me.ULT_PAGOF.TabIndex = 15
        Me.ULT_PAGOF.Tag = Nothing
        Me.ULT_PAGOF.Visible = False
        Me.ULT_PAGOF.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.ULT_PAGOF.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.ULT_PAGOF.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(1066, 994)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(46, 16)
        Me.Label41.TabIndex = 262
        Me.Label41.Text = "Docto."
        Me.Label41.Visible = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(795, 972)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(45, 16)
        Me.Label42.TabIndex = 264
        Me.Label42.Text = "Fecha"
        Me.Label42.Visible = False
        '
        'TULT_VENTAD
        '
        Me.TULT_VENTAD.AcceptsReturn = True
        Me.TULT_VENTAD.AcceptsTab = True
        Me.TULT_VENTAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TULT_VENTAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TULT_VENTAD.Location = New System.Drawing.Point(1119, 994)
        Me.TULT_VENTAD.Name = "TULT_VENTAD"
        Me.TULT_VENTAD.Size = New System.Drawing.Size(150, 22)
        Me.TULT_VENTAD.TabIndex = 19
        Me.TULT_VENTAD.Visible = False
        '
        'TULT_COMPM
        '
        Me.TULT_COMPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TULT_COMPM.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TULT_COMPM.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_COMPM.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_COMPM.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TULT_COMPM.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TULT_COMPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TULT_COMPM.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TULT_COMPM.Location = New System.Drawing.Point(1119, 1020)
        Me.TULT_COMPM.Name = "TULT_COMPM"
        Me.TULT_COMPM.Size = New System.Drawing.Size(150, 20)
        Me.TULT_COMPM.TabIndex = 20
        Me.TULT_COMPM.Tag = Nothing
        Me.TULT_COMPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TULT_COMPM.Visible = False
        Me.TULT_COMPM.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TULT_COMPM.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_COMPM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(794, 998)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(46, 16)
        Me.Label40.TabIndex = 262
        Me.Label40.Text = "Docto."
        Me.Label40.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(1068, 1020)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(44, 16)
        Me.Label39.TabIndex = 259
        Me.Label39.Text = "Monto"
        Me.Label39.Visible = False
        '
        'TULT_PAGOD
        '
        Me.TULT_PAGOD.AcceptsReturn = True
        Me.TULT_PAGOD.AcceptsTab = True
        Me.TULT_PAGOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TULT_PAGOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TULT_PAGOD.Location = New System.Drawing.Point(845, 995)
        Me.TULT_PAGOD.Name = "TULT_PAGOD"
        Me.TULT_PAGOD.Size = New System.Drawing.Size(145, 22)
        Me.TULT_PAGOD.TabIndex = 16
        Me.TULT_PAGOD.Visible = False
        '
        'ChCPPesoKg
        '
        Me.ChCPPesoKg.BackColor = System.Drawing.Color.Transparent
        Me.ChCPPesoKg.BorderColor = System.Drawing.Color.Transparent
        Me.ChCPPesoKg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChCPPesoKg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChCPPesoKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCPPesoKg.ForeColor = System.Drawing.Color.Black
        Me.ChCPPesoKg.Location = New System.Drawing.Point(1070, 922)
        Me.ChCPPesoKg.Name = "ChCPPesoKg"
        Me.ChCPPesoKg.Padding = New System.Windows.Forms.Padding(1)
        Me.ChCPPesoKg.Size = New System.Drawing.Size(184, 22)
        Me.ChCPPesoKg.TabIndex = 13
        Me.ChCPPesoKg.Text = "Carta porte peso en Kgs."
        Me.ChCPPesoKg.UseVisualStyleBackColor = True
        Me.ChCPPesoKg.Value = Nothing
        Me.ChCPPesoKg.Visible = False
        Me.ChCPPesoKg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TULT_PAGOM
        '
        Me.TULT_PAGOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TULT_PAGOM.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TULT_PAGOM.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_PAGOM.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_PAGOM.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TULT_PAGOM.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TULT_PAGOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TULT_PAGOM.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TULT_PAGOM.Location = New System.Drawing.Point(845, 1021)
        Me.TULT_PAGOM.Name = "TULT_PAGOM"
        Me.TULT_PAGOM.Size = New System.Drawing.Size(145, 20)
        Me.TULT_PAGOM.TabIndex = 17
        Me.TULT_PAGOM.Tag = Nothing
        Me.TULT_PAGOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TULT_PAGOM.Visible = False
        Me.TULT_PAGOM.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TULT_PAGOM.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TULT_PAGOM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(787, 928)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(100, 16)
        Me.Label38.TabIndex = 255
        Me.Label38.Text = "Ventas anuales"
        Me.Label38.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(796, 1024)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(44, 16)
        Me.Label37.TabIndex = 259
        Me.Label37.Text = "Monto"
        Me.Label37.Visible = False
        '
        'TVENTAS
        '
        Me.TVENTAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TVENTAS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TVENTAS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TVENTAS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TVENTAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TVENTAS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TVENTAS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TVENTAS.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TVENTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TVENTAS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TVENTAS.Location = New System.Drawing.Point(893, 926)
        Me.TVENTAS.Name = "TVENTAS"
        Me.TVENTAS.Size = New System.Drawing.Size(124, 21)
        Me.TVENTAS.TabIndex = 14
        Me.TVENTAS.Tag = Nothing
        Me.TVENTAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TVENTAS.Visible = False
        Me.TVENTAS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TVENTAS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TVENTAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chImprir
        '
        Me.chImprir.AutoSize = True
        Me.chImprir.BackColor = System.Drawing.Color.Transparent
        Me.chImprir.BorderColor = System.Drawing.Color.Transparent
        Me.chImprir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chImprir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chImprir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chImprir.ForeColor = System.Drawing.Color.Black
        Me.chImprir.Location = New System.Drawing.Point(35, 950)
        Me.chImprir.Name = "chImprir"
        Me.chImprir.Padding = New System.Windows.Forms.Padding(1)
        Me.chImprir.Size = New System.Drawing.Size(75, 23)
        Me.chImprir.TabIndex = 27
        Me.chImprir.Text = "Imprimir"
        Me.chImprir.UseVisualStyleBackColor = True
        Me.chImprir.Value = Nothing
        Me.chImprir.Visible = False
        Me.chImprir.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TEMAILPRED
        '
        Me.TEMAILPRED.AcceptsReturn = True
        Me.TEMAILPRED.AcceptsTab = True
        Me.TEMAILPRED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMAILPRED.Location = New System.Drawing.Point(204, 979)
        Me.TEMAILPRED.Name = "TEMAILPRED"
        Me.TEMAILPRED.Size = New System.Drawing.Size(488, 20)
        Me.TEMAILPRED.TabIndex = 30
        Me.TEMAILPRED.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(38, 981)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(161, 15)
        Me.Label28.TabIndex = 280
        Me.Label28.Text = "Cuenta de correo para envio"
        Me.Label28.Visible = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(28, 931)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(92, 16)
        Me.Label68.TabIndex = 262
        Me.Label68.Text = "Tipo empresa"
        Me.Label68.Visible = False
        '
        'chMail
        '
        Me.chMail.AutoSize = True
        Me.chMail.BackColor = System.Drawing.Color.Transparent
        Me.chMail.BorderColor = System.Drawing.Color.Transparent
        Me.chMail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chMail.ForeColor = System.Drawing.Color.Black
        Me.chMail.Location = New System.Drawing.Point(117, 950)
        Me.chMail.Name = "chMail"
        Me.chMail.Padding = New System.Windows.Forms.Padding(1)
        Me.chMail.Size = New System.Drawing.Size(177, 21)
        Me.chMail.TabIndex = 28
        Me.chMail.Text = "Envío por correo electrónico"
        Me.chMail.UseVisualStyleBackColor = True
        Me.chMail.Value = Nothing
        Me.chMail.Visible = False
        Me.chMail.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LMatriz
        '
        Me.LMatriz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LMatriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LMatriz.Location = New System.Drawing.Point(455, 928)
        Me.LMatriz.Name = "LMatriz"
        Me.LMatriz.Size = New System.Drawing.Size(271, 22)
        Me.LMatriz.TabIndex = 256
        Me.LMatriz.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(318, 955)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(130, 17)
        Me.Label25.TabIndex = 261
        Me.Label25.Text = "Documento modelo"
        Me.Label25.Visible = False
        '
        'BtnMatriz
        '
        Me.BtnMatriz.AutoSize = True
        Me.BtnMatriz.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnMatriz.FlatAppearance.BorderSize = 0
        Me.BtnMatriz.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMatriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMatriz.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnMatriz.Location = New System.Drawing.Point(427, 928)
        Me.BtnMatriz.Name = "BtnMatriz"
        Me.BtnMatriz.Size = New System.Drawing.Size(22, 22)
        Me.BtnMatriz.TabIndex = 255
        Me.BtnMatriz.UseVisualStyleBackColor = True
        Me.BtnMatriz.Visible = False
        Me.BtnMatriz.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TMODELO
        '
        Me.TMODELO.AcceptsReturn = True
        Me.TMODELO.AcceptsTab = True
        Me.TMODELO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO.Location = New System.Drawing.Point(455, 953)
        Me.TMODELO.Name = "TMODELO"
        Me.TMODELO.Size = New System.Drawing.Size(255, 21)
        Me.TMODELO.TabIndex = 29
        Me.TMODELO.Visible = False
        '
        'TMATRIZ
        '
        Me.TMATRIZ.AcceptsReturn = True
        Me.TMATRIZ.AcceptsTab = True
        Me.TMATRIZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMATRIZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMATRIZ.Location = New System.Drawing.Point(370, 928)
        Me.TMATRIZ.Name = "TMATRIZ"
        Me.TMATRIZ.Size = New System.Drawing.Size(55, 22)
        Me.TMATRIZ.TabIndex = 26
        Me.TMATRIZ.Visible = False
        '
        'BtnDocModelo
        '
        Me.BtnDocModelo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDocModelo.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnDocModelo.Location = New System.Drawing.Point(714, 952)
        Me.BtnDocModelo.Name = "BtnDocModelo"
        Me.BtnDocModelo.Size = New System.Drawing.Size(28, 22)
        Me.BtnDocModelo.TabIndex = 273
        Me.BtnDocModelo.UseVisualStyleBackColor = True
        Me.BtnDocModelo.Visible = False
        Me.BtnDocModelo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtMatriz
        '
        Me.LtMatriz.AutoSize = True
        Me.LtMatriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMatriz.Location = New System.Drawing.Point(323, 931)
        Me.LtMatriz.Name = "LtMatriz"
        Me.LtMatriz.Size = New System.Drawing.Size(42, 16)
        Me.LtMatriz.TabIndex = 2
        Me.LtMatriz.Text = "Matriz"
        Me.LtMatriz.Visible = False
        '
        'radSuc
        '
        Me.radSuc.AutoSize = True
        Me.radSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSuc.Location = New System.Drawing.Point(219, 931)
        Me.radSuc.Name = "radSuc"
        Me.radSuc.Size = New System.Drawing.Size(77, 20)
        Me.radSuc.TabIndex = 25
        Me.radSuc.TabStop = True
        Me.radSuc.Text = "Sucursal"
        Me.radSuc.UseVisualStyleBackColor = False
        Me.radSuc.Visible = False
        '
        'radMatriz
        '
        Me.radMatriz.AutoSize = True
        Me.radMatriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMatriz.Location = New System.Drawing.Point(130, 931)
        Me.radMatriz.Name = "radMatriz"
        Me.radMatriz.Size = New System.Drawing.Size(60, 20)
        Me.radMatriz.TabIndex = 24
        Me.radMatriz.TabStop = True
        Me.radMatriz.Text = "Matriz"
        Me.radMatriz.UseVisualStyleBackColor = False
        Me.radMatriz.Visible = False
        '
        'LtZona
        '
        Me.LtZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtZona.Location = New System.Drawing.Point(298, 889)
        Me.LtZona.Name = "LtZona"
        Me.LtZona.Size = New System.Drawing.Size(183, 22)
        Me.LtZona.TabIndex = 252
        Me.LtZona.Visible = False
        '
        'BtnZona
        '
        Me.BtnZona.AutoSize = True
        Me.BtnZona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnZona.FlatAppearance.BorderSize = 0
        Me.BtnZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnZona.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnZona.Location = New System.Drawing.Point(272, 891)
        Me.BtnZona.Name = "BtnZona"
        Me.BtnZona.Size = New System.Drawing.Size(22, 22)
        Me.BtnZona.TabIndex = 251
        Me.BtnZona.UseVisualStyleBackColor = True
        Me.BtnZona.Visible = False
        Me.BtnZona.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_ZONA
        '
        Me.TCVE_ZONA.AcceptsReturn = True
        Me.TCVE_ZONA.AcceptsTab = True
        Me.TCVE_ZONA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ZONA.Location = New System.Drawing.Point(227, 889)
        Me.TCVE_ZONA.Name = "TCVE_ZONA"
        Me.TCVE_ZONA.Size = New System.Drawing.Size(41, 22)
        Me.TCVE_ZONA.TabIndex = 20
        Me.TCVE_ZONA.Visible = False
        '
        'TPAG_WEB
        '
        Me.TPAG_WEB.AcceptsReturn = True
        Me.TPAG_WEB.AcceptsTab = True
        Me.TPAG_WEB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAG_WEB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAG_WEB.Location = New System.Drawing.Point(204, 1001)
        Me.TPAG_WEB.Name = "TPAG_WEB"
        Me.TPAG_WEB.Size = New System.Drawing.Size(488, 22)
        Me.TPAG_WEB.TabIndex = 31
        Me.TPAG_WEB.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(185, 892)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Zona"
        Me.Label11.Visible = False
        '
        'LtImss
        '
        Me.LtImss.AutoSize = True
        Me.LtImss.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImss.Location = New System.Drawing.Point(113, 1003)
        Me.LtImss.Name = "LtImss"
        Me.LtImss.Size = New System.Drawing.Size(84, 16)
        Me.LtImss.TabIndex = 230
        Me.LtImss.Text = "Pagina WEB"
        Me.LtImss.Visible = False
        '
        'TNacionalidad
        '
        Me.TNacionalidad.AcceptsReturn = True
        Me.TNacionalidad.AcceptsTab = True
        Me.TNacionalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNacionalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNacionalidad.Location = New System.Drawing.Point(589, 889)
        Me.TNacionalidad.Name = "TNacionalidad"
        Me.TNacionalidad.Size = New System.Drawing.Size(130, 22)
        Me.TNacionalidad.TabIndex = 21
        Me.TNacionalidad.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(498, 894)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 248
        Me.Label10.Text = "Nacionalidad"
        Me.Label10.Visible = False
        '
        'TREFERDIR
        '
        Me.TREFERDIR.AcceptsReturn = True
        Me.TREFERDIR.AcceptsTab = True
        Me.TREFERDIR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREFERDIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREFERDIR.Location = New System.Drawing.Point(830, 903)
        Me.TREFERDIR.Name = "TREFERDIR"
        Me.TREFERDIR.Size = New System.Drawing.Size(602, 22)
        Me.TREFERDIR.TabIndex = 14
        Me.TREFERDIR.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(754, 906)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 16)
        Me.Label9.TabIndex = 246
        Me.Label9.Text = "Referencia"
        Me.Label9.Visible = False
        '
        'TClasific
        '
        Me.TClasific.AcceptsReturn = True
        Me.TClasific.AcceptsTab = True
        Me.TClasific.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TClasific.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TClasific.Location = New System.Drawing.Point(117, 889)
        Me.TClasific.Name = "TClasific"
        Me.TClasific.Size = New System.Drawing.Size(65, 22)
        Me.TClasific.TabIndex = 19
        Me.TClasific.Visible = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(31, 891)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(83, 16)
        Me.Label45.TabIndex = 236
        Me.Label45.Text = "Clasificación"
        Me.Label45.Visible = False
        '
        'LtPais
        '
        Me.LtPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPais.Location = New System.Drawing.Point(63, 1026)
        Me.LtPais.Name = "LtPais"
        Me.LtPais.Size = New System.Drawing.Size(218, 22)
        Me.LtPais.TabIndex = 259
        Me.LtPais.Visible = False
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Owner = Me
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(922, 17)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(51, 16)
        Me.Label64.TabIndex = 263
        Me.Label64.Text = "Estatus"
        '
        'BtnActivo
        '
        Me.BtnActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActivo.Location = New System.Drawing.Point(980, 11)
        Me.BtnActivo.Name = "BtnActivo"
        Me.BtnActivo.Size = New System.Drawing.Size(97, 27)
        Me.BtnActivo.TabIndex = 2
        Me.BtnActivo.Text = "Activo"
        Me.BtnActivo.UseVisualStyleBackColor = True
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 75)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.Split1)
        Me.SplitM1.Panels.Add(Me.Split2)
        Me.SplitM1.Size = New System.Drawing.Size(1434, 546)
        Me.SplitM1.TabIndex = 192
        '
        'Split1
        '
        Me.Split1.AutoScroll = True
        Me.Split1.Controls.Add(Me.Label64)
        Me.Split1.Controls.Add(Me.btnAnterior)
        Me.Split1.Controls.Add(Me.TCLAVE)
        Me.Split1.Controls.Add(Me.BtnActivo)
        Me.Split1.Controls.Add(Me.btnSiguiente)
        Me.Split1.Controls.Add(Me.btnInicial)
        Me.Split1.Controls.Add(Me.Label27)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Controls.Add(Me.TNOMBRE)
        Me.Split1.Controls.Add(Me.btnFinal)
        Me.Split1.Height = 57
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1432, 57)
        Me.Split1.SizeRatio = 10.556R
        Me.Split1.TabIndex = 0
        '
        'btnAnterior
        '
        Me.btnAnterior.AutoSize = True
        Me.btnAnterior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAnterior.Image = Global.SGT_Transport.My.Resources.Resources.flecha_izq24
        Me.btnAnterior.Location = New System.Drawing.Point(57, 9)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(30, 30)
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.UseVisualStyleBackColor = True
        Me.btnAnterior.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AutoSize = True
        Me.btnSiguiente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSiguiente.Image = Global.SGT_Transport.My.Resources.Resources.flecha_der24
        Me.btnSiguiente.Location = New System.Drawing.Point(720, 9)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(30, 30)
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.UseVisualStyleBackColor = True
        Me.btnSiguiente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnInicial
        '
        Me.btnInicial.AutoSize = True
        Me.btnInicial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnInicial.Image = Global.SGT_Transport.My.Resources.Resources.flechaIzqD_e
        Me.btnInicial.Location = New System.Drawing.Point(13, 9)
        Me.btnInicial.Name = "btnInicial"
        Me.btnInicial.Size = New System.Drawing.Size(30, 30)
        Me.btnInicial.TabIndex = 0
        Me.btnInicial.UseVisualStyleBackColor = True
        Me.btnInicial.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnFinal
        '
        Me.btnFinal.AutoSize = True
        Me.btnFinal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFinal.Image = Global.SGT_Transport.My.Resources.Resources.flecha_derD24
        Me.btnFinal.Location = New System.Drawing.Point(764, 9)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(30, 30)
        Me.btnFinal.TabIndex = 3
        Me.btnFinal.UseVisualStyleBackColor = True
        Me.btnFinal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Split2
        '
        Me.Split2.AutoScroll = True
        Me.Split2.Controls.Add(Me.TAB1)
        Me.Split2.Height = 483
        Me.Split2.Location = New System.Drawing.Point(1, 62)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1432, 483)
        Me.Split2.TabIndex = 1
        '
        'TCUENTA_CONTABLE_FISCAL
        '
        Me.TCUENTA_CONTABLE_FISCAL.AcceptsReturn = True
        Me.TCUENTA_CONTABLE_FISCAL.AcceptsTab = True
        Me.TCUENTA_CONTABLE_FISCAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCUENTA_CONTABLE_FISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUENTA_CONTABLE_FISCAL.Location = New System.Drawing.Point(143, 215)
        Me.TCUENTA_CONTABLE_FISCAL.Name = "TCUENTA_CONTABLE_FISCAL"
        Me.TCUENTA_CONTABLE_FISCAL.Size = New System.Drawing.Size(283, 21)
        Me.TCUENTA_CONTABLE_FISCAL.TabIndex = 13
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.Location = New System.Drawing.Point(1, 217)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(138, 16)
        Me.Label102.TabIndex = 295
        Me.Label102.Text = "Cuenta contable fiscal"
        '
        'frmClientesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1463, 1091)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.ChCPPesoKg)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.FCH_ULTCOM)
        Me.Controls.Add(Me.LtPais)
        Me.Controls.Add(Me.TVENTAS)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.ULT_PAGOF)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.LtImss)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.TPAG_WEB)
        Me.Controls.Add(Me.TULT_VENTAD)
        Me.Controls.Add(Me.radMatriz)
        Me.Controls.Add(Me.radSuc)
        Me.Controls.Add(Me.TULT_COMPM)
        Me.Controls.Add(Me.LtMatriz)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.BtnDocModelo)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.TMATRIZ)
        Me.Controls.Add(Me.TMODELO)
        Me.Controls.Add(Me.TULT_PAGOD)
        Me.Controls.Add(Me.BtnMatriz)
        Me.Controls.Add(Me.chImprir)
        Me.Controls.Add(Me.TULT_PAGOM)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.LtZona)
        Me.Controls.Add(Me.TREFERDIR)
        Me.Controls.Add(Me.LMatriz)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.BtnZona)
        Me.Controls.Add(Me.chMail)
        Me.Controls.Add(Me.TEMAILPRED)
        Me.Controls.Add(Me.TCVE_ZONA)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TClasific)
        Me.Controls.Add(Me.TNacionalidad)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label10)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClientesAE"
        Me.ShowInTaskbar = False
        Me.Text = "Clientes"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.PAG1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.BtnApli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMetodoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDiasCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLimCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chCON_CREDITO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnListaPrec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUsoCFDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPagoSAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDESCUENTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.BtnCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnColonia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_MON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_ESQIMPU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFLETE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRegimenFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PAG2.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GpoDatosEnvio.ResumeLayout(False)
        Me.GpoDatosEnvio.PerformLayout()
        CType(Me.BtnZonaEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.btnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnBancos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.BtnPaisResiFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PAG4.ResumeLayout(False)
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.FgL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PAG3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FCH_ULTCOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ULT_PAGOF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TULT_COMPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChCPPesoKg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TULT_PAGOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVENTAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chImprir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMatriz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDocModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnZona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        CType(Me.btnAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSiguiente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents barGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnInicial As C1.Win.C1Input.C1Button
    Friend WithEvents btnAnterior As C1.Win.C1Input.C1Button
    Friend WithEvents btnSiguiente As C1.Win.C1Input.C1Button
    Friend WithEvents btnFinal As C1.Win.C1Input.C1Button
    Friend WithEvents TCLAVE As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TNOMBRE As System.Windows.Forms.TextBox
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PAG1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PAG2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PAG4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents chCON_CREDITO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TFax As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents LtZona As System.Windows.Forms.Label
    Friend WithEvents BtnZona As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_ZONA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TREFERDIR As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TCRUZAMIENTOS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TCODIGO As System.Windows.Forms.TextBox
    Friend WithEvents TCOLONIA As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TEstado As System.Windows.Forms.TextBox
    Friend WithEvents TCALLE As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TLOCALIDAD As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TTELEFONO As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TClasific As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TCRUZAMIENTOS2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TNumExt As System.Windows.Forms.TextBox
    Friend WithEvents LtImss As System.Windows.Forms.Label
    Friend WithEvents TPAG_WEB As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TNumInt As System.Windows.Forms.TextBox
    Friend WithEvents TCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents radSuc As System.Windows.Forms.RadioButton
    Friend WithEvents radMatriz As System.Windows.Forms.RadioButton
    Friend WithEvents LtSaldo As System.Windows.Forms.Label
    Friend WithEvents TLimCred As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TDIAPAGO As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TDIAREV As System.Windows.Forms.TextBox
    Friend WithEvents TDiasCred As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TCUENTA_CONTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TLISTA_PREC As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TMETODODEPAGO As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TNUMCTAPAGO As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tDESCUENTO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents LtVend As System.Windows.Forms.Label
    Friend WithEvents BtnVend As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_VEND As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents BtnDocModelo As C1.Win.C1Input.C1Button
    Friend WithEvents TMODELO As System.Windows.Forms.TextBox
    Friend WithEvents BtnListaPrec As C1.Win.C1Input.C1Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TVENTAS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TULT_VENTAD As System.Windows.Forms.TextBox
    Friend WithEvents TULT_COMPM As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TULT_PAGOD As System.Windows.Forms.TextBox
    Friend WithEvents TULT_PAGOM As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents FCH_ULTCOM As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents ULT_PAGOF As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TCVE_OBS As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents FgL As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtZonaEnvio As System.Windows.Forms.Label
    Friend WithEvents BtnZonaEnvio As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_ZONA_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents TREFERENCIA_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents TCOLONIA_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents TCRUZAMIENTOS_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TPAIS_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents TMUNICIPIO_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TESTADO_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TNUMINT_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents TCALLE_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TCRUZAMIENTOS_ENVIO2 As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents TNUMEXT_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents TCODIGO_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents TLOCALIDAD_ENVIO As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents tZonaEnvio As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPagoSAT As C1.Win.C1Input.C1Button
    Friend WithEvents TFORMADEPAGOSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents BtnUsoCFDI As C1.Win.C1Input.C1Button
    Friend WithEvents TUSO_CFDI As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents BtnPaisResiFiscal As C1.Win.C1Input.C1Button
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents TCVE_PAIS_SAT As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents TNUMIDREGFISCAL As System.Windows.Forms.TextBox
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents chMail As C1.Win.C1Input.C1CheckBox
    Friend WithEvents chImprir As C1.Win.C1Input.C1CheckBox
    Friend WithEvents TEMAILPRED As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LMatriz As System.Windows.Forms.Label
    Friend WithEvents BtnMatriz As C1.Win.C1Input.C1Button
    Friend WithEvents TMATRIZ As System.Windows.Forms.TextBox
    Friend WithEvents LtMatriz As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents TRFCFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TBancoFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TCtaBanFiscal As System.Windows.Forms.TextBox
    Friend WithEvents BtnBancos As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents btnAgregar As C1.Win.C1Input.C1Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LtPais As Label
    Friend WithEvents frmEstadoCuenta As ToolStripMenuItem
    Friend WithEvents ChCPPesoKg As C1.Win.C1Input.C1CheckBox
    Friend WithEvents FgA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BtnPais As C1.Win.C1Input.C1Button
    Friend WithEvents TPais As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TREGIMEN_FISCAL As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnRegimenFiscal As C1.Win.C1Input.C1Button
    Friend WithEvents Label64 As Label
    Friend WithEvents BtnActivo As C1.Win.C1Input.C1Button
    Friend WithEvents Label68 As Label
    Friend WithEvents BtnGrabarYSalir As ToolStripMenuItem
    Friend WithEvents BtnRFC As C1.Win.C1Input.C1Button
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents GpoDatosEnvio As GroupBox
    Friend WithEvents LtRegFis As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label70 As Label
    Friend WithEvents LtUsoCFDI As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents BtnMetodoPago As C1.Win.C1Input.C1Button
    Friend WithEvents PAG3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label69 As Label
    Friend WithEvents TCOLM As TextBox
    Friend WithEvents TCOLA As TextBox
    Friend WithEvents TCOLE As TextBox
    Friend WithEvents TCOLF As TextBox
    Friend WithEvents TCOLL As TextBox
    Friend WithEvents TCOLD As TextBox
    Friend WithEvents TCOLG As TextBox
    Friend WithEvents TCOLK As TextBox
    Friend WithEvents TCOLC As TextBox
    Friend WithEvents TCOLH As TextBox
    Friend WithEvents TCOLJ As TextBox
    Friend WithEvents TCOLB As TextBox
    Friend WithEvents TCOLI As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Lt14 As Label
    Friend WithEvents Lt13 As Label
    Friend WithEvents Lt12 As Label
    Friend WithEvents Lt11 As Label
    Friend WithEvents Lt10 As Label
    Friend WithEvents Lt9 As Label
    Friend WithEvents Lt8 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt4 As Label
    Friend WithEvents Lt3 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents C1XLBook1 As C1.C1Excel.C1XLBook
    Friend WithEvents Label71 As Label
    Friend WithEvents TNOMBRECOMERCIAL As TextBox
    Friend WithEvents Label72 As Label
    Friend WithEvents TCOLN As TextBox
    Friend WithEvents BarEstadoCuenta As ToolStripMenuItem
    Friend WithEvents TFLETE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label73 As Label
    Friend WithEvents BtnEsquema As C1.Win.C1Input.C1Button
    Friend WithEvents LtEsquema As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents TCVE_ESQIMPU As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TNUM_MON As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents BtnMoneda As C1.Win.C1Input.C1Button
    Friend WithEvents LtMoneda As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents LtMX As Label
    Friend WithEvents BtnCP As C1.Win.C1Input.C1Button
    Friend WithEvents Label74 As Label
    Friend WithEvents T As TextBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents Label77 As Label
    Friend WithEvents BtnEstado As C1.Win.C1Input.C1Button
    Friend WithEvents BtnLocalidad As C1.Win.C1Input.C1Button
    Friend WithEvents BtnMunicipio As C1.Win.C1Input.C1Button
    Friend WithEvents Label79 As Label
    Friend WithEvents TPAIS_SAT As TextBox
    Friend WithEvents Label81 As Label
    Friend WithEvents TESTADO_SAT As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents TMUNICIPIO_SAT As TextBox
    Friend WithEvents Label85 As Label
    Friend WithEvents TLOCALIDAD_SAT As TextBox
    Friend WithEvents BtnColonia As C1.Win.C1Input.C1Button
    Friend WithEvents Label87 As Label
    Friend WithEvents TCOLONIA_SAT As TextBox
    Friend WithEvents TALIAS As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents BtnApli As C1.Win.C1Input.C1Button
    Friend WithEvents Label80 As Label
    Friend WithEvents TAPLICACION As TextBox
    Friend WithEvents Label99 As Label
    Friend WithEvents TCOLAI As TextBox
    Friend WithEvents TCOLAC As TextBox
    Friend WithEvents TCOLAG As TextBox
    Friend WithEvents TCOLAH As TextBox
    Friend WithEvents TCOLAF As TextBox
    Friend WithEvents TCOLAJ As TextBox
    Friend WithEvents Label106 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents TCOLAE As TextBox
    Friend WithEvents Label108 As Label
    Friend WithEvents Label109 As Label
    Friend WithEvents Label110 As Label
    Friend WithEvents TCOLAD As TextBox
    Friend WithEvents Label111 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents TCOLU As TextBox
    Friend WithEvents Label84 As Label
    Friend WithEvents TCOLAB As TextBox
    Friend WithEvents Label86 As Label
    Friend WithEvents TCOLO As TextBox
    Friend WithEvents TCOLS As TextBox
    Friend WithEvents Label88 As Label
    Friend WithEvents TCOLT As TextBox
    Friend WithEvents Label89 As Label
    Friend WithEvents TCOLAA As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents TCOLR As TextBox
    Friend WithEvents Label91 As Label
    Friend WithEvents TCOLV As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents TCOLZ As TextBox
    Friend WithEvents Label93 As Label
    Friend WithEvents TCOLQ As TextBox
    Friend WithEvents Label94 As Label
    Friend WithEvents TCOLW As TextBox
    Friend WithEvents Label95 As Label
    Friend WithEvents TCOLY As TextBox
    Friend WithEvents Label96 As Label
    Friend WithEvents TCOLP As TextBox
    Friend WithEvents Label97 As Label
    Friend WithEvents TCOLX As TextBox
    Friend WithEvents Label98 As Label
    Friend WithEvents Label100 As Label
    Friend WithEvents Label101 As Label
    Friend WithEvents TCUENTA_CONTABLE_FISCAL As TextBox
    Friend WithEvents Label102 As Label
End Class
