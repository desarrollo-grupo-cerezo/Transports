<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagoComplementoAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoComplementoAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarVarios = New C1.Win.C1Command.C1CommandMenu()
        Me.LkTotales = New C1.Win.C1Command.C1CommandLink()
        Me.BarTotales = New C1.Win.C1Command.C1Command()
        Me.LkObsDoc = New C1.Win.C1Command.C1CommandLink()
        Me.BarObsDoc = New C1.Win.C1Command.C1Command()
        Me.LkObsPart = New C1.Win.C1Command.C1CommandLink()
        Me.BarObsPart = New C1.Win.C1Command.C1Command()
        Me.LkEliminarPart = New C1.Win.C1Command.C1CommandLink()
        Me.BarEliminarPart = New C1.Win.C1Command.C1Command()
        Me.LkDatosCliente = New C1.Win.C1Command.C1CommandLink()
        Me.BarDatosCliente = New C1.Win.C1Command.C1Command()
        Me.LkAltaCliente = New C1.Win.C1Command.C1CommandLink()
        Me.BarAltaCliente = New C1.Win.C1Command.C1Command()
        Me.LkAltaCtaOrdenante = New C1.Win.C1Command.C1CommandLink()
        Me.BarAltaCtaOrdenante = New C1.Win.C1Command.C1Command()
        Me.LkAltaCtaBeneficiario = New C1.Win.C1Command.C1CommandLink()
        Me.BatAltaCtaBeneficiario = New C1.Win.C1Command.C1Command()
        Me.BarFolioDigital = New C1.Win.C1Command.C1Command()
        Me.BarRecepPagoMult = New C1.Win.C1Command.C1Command()
        Me.BarCFDIRel = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkVarios = New C1.Win.C1Command.C1CommandLink()
        Me.LkFolioDigital = New C1.Win.C1Command.C1CommandLink()
        Me.LkRecepPagoMult = New C1.Win.C1Command.C1CommandLink()
        Me.LkCFDIRel = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtCorreo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnRefreshCliente = New C1.Win.C1Input.C1Button()
        Me.LtCP = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtUSO_CFDI = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtRegimenReceptor = New System.Windows.Forms.Label()
        Me.LtRegimenEmisor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.btnClie = New C1.Win.C1Input.C1Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.LtTimbrado = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtRFC = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TMagico = New System.Windows.Forms.TextBox()
        Me.Labl2 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ldocu = New System.Windows.Forms.Label()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TXT = New C1.Win.C1Input.C1TextBox()
        Me.TXTN = New C1.Win.C1Input.C1NumericEdit()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgDR = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Lt2 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.BtnRefreshCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split3.SuspendLayout()
        CType(Me.FgDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarVarios)
        Me.MenuHolder.Commands.Add(Me.BarFolioDigital)
        Me.MenuHolder.Commands.Add(Me.BarRecepPagoMult)
        Me.MenuHolder.Commands.Add(Me.BarCFDIRel)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarObsDoc)
        Me.MenuHolder.Commands.Add(Me.BarTotales)
        Me.MenuHolder.Commands.Add(Me.BarObsPart)
        Me.MenuHolder.Commands.Add(Me.BarEliminarPart)
        Me.MenuHolder.Commands.Add(Me.BarDatosCliente)
        Me.MenuHolder.Commands.Add(Me.BarAltaCliente)
        Me.MenuHolder.Commands.Add(Me.BarAltaCtaOrdenante)
        Me.MenuHolder.Commands.Add(Me.BatAltaCtaBeneficiario)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.guardar2
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
        '
        'BarVarios
        '
        Me.BarVarios.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkTotales, Me.LkObsDoc, Me.LkObsPart, Me.LkEliminarPart, Me.LkDatosCliente, Me.LkAltaCliente, Me.LkAltaCtaOrdenante, Me.LkAltaCtaBeneficiario})
        Me.BarVarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarVarios.HideNonRecentLinks = False
        Me.BarVarios.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarVarios.ImageBarWidth = 60
        Me.BarVarios.Name = "BarVarios"
        Me.BarVarios.ShortcutText = ""
        Me.BarVarios.ShowToolTips = True
        Me.BarVarios.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarVarios.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarVarios.Width = 25
        '
        'LkTotales
        '
        Me.LkTotales.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkTotales.Command = Me.BarTotales
        Me.LkTotales.Text = "Totales"
        '
        'BarTotales
        '
        Me.BarTotales.Image = Global.SGT_Transport.My.Resources.Resources.kpagos
        Me.BarTotales.Name = "BarTotales"
        Me.BarTotales.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.BarTotales.ShortcutText = ""
        Me.BarTotales.Text = "BarTotales"
        '
        'LkObsDoc
        '
        Me.LkObsDoc.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkObsDoc.Command = Me.BarObsDoc
        Me.LkObsDoc.SortOrder = 1
        Me.LkObsDoc.Text = "Observaciones documento"
        '
        'BarObsDoc
        '
        Me.BarObsDoc.Image = Global.SGT_Transport.My.Resources.Resources.kobser
        Me.BarObsDoc.Name = "BarObsDoc"
        Me.BarObsDoc.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarObsDoc.ShortcutText = ""
        Me.BarObsDoc.Text = "Observaciones documento"
        '
        'LkObsPart
        '
        Me.LkObsPart.Command = Me.BarObsPart
        Me.LkObsPart.SortOrder = 2
        Me.LkObsPart.Text = "observaciones partida"
        '
        'BarObsPart
        '
        Me.BarObsPart.Image = Global.SGT_Transport.My.Resources.Resources.kobser
        Me.BarObsPart.Name = "BarObsPart"
        Me.BarObsPart.Shortcut = System.Windows.Forms.Shortcut.F6
        Me.BarObsPart.ShortcutText = ""
        Me.BarObsPart.Text = "Observaciones partida"
        '
        'LkEliminarPart
        '
        Me.LkEliminarPart.Command = Me.BarEliminarPart
        Me.LkEliminarPart.SortOrder = 3
        Me.LkEliminarPart.Text = "Eliminar partida"
        '
        'BarEliminarPart
        '
        Me.BarEliminarPart.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminarPart.Name = "BarEliminarPart"
        Me.BarEliminarPart.Shortcut = System.Windows.Forms.Shortcut.F7
        Me.BarEliminarPart.ShortcutText = ""
        Me.BarEliminarPart.Text = "Eliminar partida"
        '
        'LkDatosCliente
        '
        Me.LkDatosCliente.Command = Me.BarDatosCliente
        Me.LkDatosCliente.SortOrder = 4
        Me.LkDatosCliente.Text = "Datos del cliente"
        '
        'BarDatosCliente
        '
        Me.BarDatosCliente.Image = Global.SGT_Transport.My.Resources.Resources.empleados1
        Me.BarDatosCliente.Name = "BarDatosCliente"
        Me.BarDatosCliente.Shortcut = System.Windows.Forms.Shortcut.F8
        Me.BarDatosCliente.ShortcutText = ""
        Me.BarDatosCliente.Text = "Dato cliente"
        '
        'LkAltaCliente
        '
        Me.LkAltaCliente.Command = Me.BarAltaCliente
        Me.LkAltaCliente.SortOrder = 5
        Me.LkAltaCliente.Text = "Alta del cliente"
        '
        'BarAltaCliente
        '
        Me.BarAltaCliente.Image = Global.SGT_Transport.My.Resources.Resources.altacliente1
        Me.BarAltaCliente.Name = "BarAltaCliente"
        Me.BarAltaCliente.Shortcut = System.Windows.Forms.Shortcut.F9
        Me.BarAltaCliente.ShortcutText = ""
        Me.BarAltaCliente.Text = "Alta cliente"
        '
        'LkAltaCtaOrdenante
        '
        Me.LkAltaCtaOrdenante.Command = Me.BarAltaCtaOrdenante
        Me.LkAltaCtaOrdenante.SortOrder = 6
        Me.LkAltaCtaOrdenante.Text = "Alta cuenta ordenante"
        '
        'BarAltaCtaOrdenante
        '
        Me.BarAltaCtaOrdenante.Image = Global.SGT_Transport.My.Resources.Resources.metodo_pago2
        Me.BarAltaCtaOrdenante.Name = "BarAltaCtaOrdenante"
        Me.BarAltaCtaOrdenante.Shortcut = System.Windows.Forms.Shortcut.F10
        Me.BarAltaCtaOrdenante.ShortcutText = ""
        Me.BarAltaCtaOrdenante.Text = "Alta cuenta Ordenate"
        '
        'LkAltaCtaBeneficiario
        '
        Me.LkAltaCtaBeneficiario.Command = Me.BatAltaCtaBeneficiario
        Me.LkAltaCtaBeneficiario.SortOrder = 7
        Me.LkAltaCtaBeneficiario.Text = "Alta cuenta beneficiario"
        '
        'BatAltaCtaBeneficiario
        '
        Me.BatAltaCtaBeneficiario.Image = Global.SGT_Transport.My.Resources.Resources.banco1
        Me.BatAltaCtaBeneficiario.Name = "BatAltaCtaBeneficiario"
        Me.BatAltaCtaBeneficiario.Shortcut = System.Windows.Forms.Shortcut.F11
        Me.BatAltaCtaBeneficiario.ShortcutText = ""
        Me.BatAltaCtaBeneficiario.Text = "Alta cuenta beneficiario"
        '
        'BarFolioDigital
        '
        Me.BarFolioDigital.Image = Global.SGT_Transport.My.Resources.Resources.foliodig1
        Me.BarFolioDigital.Name = "BarFolioDigital"
        Me.BarFolioDigital.ShortcutText = ""
        Me.BarFolioDigital.Text = "Folio digital"
        '
        'BarRecepPagoMult
        '
        Me.BarRecepPagoMult.Image = Global.SGT_Transport.My.Resources.Resources.pago
        Me.BarRecepPagoMult.Name = "BarRecepPagoMult"
        Me.BarRecepPagoMult.ShortcutText = ""
        Me.BarRecepPagoMult.Text = "Recepción pagos"
        '
        'BarCFDIRel
        '
        Me.BarCFDIRel.Image = Global.SGT_Transport.My.Resources.Resources.cfdiN1
        Me.BarCFDIRel.Name = "BarCFDIRel"
        Me.BarCFDIRel.ShortcutText = ""
        Me.BarCFDIRel.Text = "Totales"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora61
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 120
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkVarios, Me.LkFolioDigital, Me.LkRecepPagoMult, Me.LkCFDIRel, Me.LkImprimir, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 35
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1228, 57)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.Wrap = True
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkVarios
        '
        Me.LkVarios.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkVarios.Command = Me.BarVarios
        Me.LkVarios.Delimiter = True
        Me.LkVarios.SortOrder = 1
        Me.LkVarios.Text = "Opciones"
        '
        'LkFolioDigital
        '
        Me.LkFolioDigital.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFolioDigital.Command = Me.BarFolioDigital
        Me.LkFolioDigital.Delimiter = True
        Me.LkFolioDigital.SortOrder = 2
        Me.LkFolioDigital.Text = "Folio digital"
        '
        'LkRecepPagoMult
        '
        Me.LkRecepPagoMult.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkRecepPagoMult.Command = Me.BarRecepPagoMult
        Me.LkRecepPagoMult.Delimiter = True
        Me.LkRecepPagoMult.SortOrder = 3
        Me.LkRecepPagoMult.Text = "Recepción pagos"
        '
        'LkCFDIRel
        '
        Me.LkCFDIRel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCFDIRel.Command = Me.BarCFDIRel
        Me.LkCFDIRel.Delimiter = True
        Me.LkCFDIRel.SortOrder = 4
        Me.LkCFDIRel.Text = "CFDI relacionados"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 5
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 6
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 7
        Me.LkSalir.Text = "Salir"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(0, 57)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Panels.Add(Me.Split3)
        Me.SplitM.Size = New System.Drawing.Size(1228, 502)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitM.TabIndex = 2
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitM.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.TAB1)
        Me.Split1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Split1.Height = 163
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1226, 163)
        Me.Split1.SizeRatio = 32.863R
        Me.Split1.TabIndex = 0
        '
        'TAB1
        '
        Me.TAB1.Controls.Add(Me.Pag1)
        Me.TAB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TAB1.Location = New System.Drawing.Point(0, 0)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.Size = New System.Drawing.Size(1226, 163)
        Me.TAB1.TabIndex = 0
        Me.TAB1.TabsSpacing = 5
        Me.TAB1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.TAB1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.Lt2)
        Me.Pag1.Controls.Add(Me.LtCorreo)
        Me.Pag1.Controls.Add(Me.Label7)
        Me.Pag1.Controls.Add(Me.BtnRefreshCliente)
        Me.Pag1.Controls.Add(Me.LtCP)
        Me.Pag1.Controls.Add(Me.Label9)
        Me.Pag1.Controls.Add(Me.LtUSO_CFDI)
        Me.Pag1.Controls.Add(Me.Label8)
        Me.Pag1.Controls.Add(Me.LtRegimenReceptor)
        Me.Pag1.Controls.Add(Me.LtRegimenEmisor)
        Me.Pag1.Controls.Add(Me.Label2)
        Me.Pag1.Controls.Add(Me.LtCVE_DOC)
        Me.Pag1.Controls.Add(Me.btnClie)
        Me.Pag1.Controls.Add(Me.Label5)
        Me.Pag1.Controls.Add(Me.TCLIENTE)
        Me.Pag1.Controls.Add(Me.LtTimbrado)
        Me.Pag1.Controls.Add(Me.Label14)
        Me.Pag1.Controls.Add(Me.LtRFC)
        Me.Pag1.Controls.Add(Me.LtNombre)
        Me.Pag1.Controls.Add(Me.Label3)
        Me.Pag1.Controls.Add(Me.TMagico)
        Me.Pag1.Controls.Add(Me.Labl2)
        Me.Pag1.Controls.Add(Me.F1)
        Me.Pag1.Controls.Add(Me.Label1)
        Me.Pag1.Controls.Add(Me.Ldocu)
        Me.Pag1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pag1.Location = New System.Drawing.Point(1, 26)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(1224, 136)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Pagos"
        '
        'LtCorreo
        '
        Me.LtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCorreo.Location = New System.Drawing.Point(97, 112)
        Me.LtCorreo.Name = "LtCorreo"
        Me.LtCorreo.Size = New System.Drawing.Size(391, 20)
        Me.LtCorreo.TabIndex = 608
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(42, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 607
        Me.Label7.Text = "Correo"
        '
        'BtnRefreshCliente
        '
        Me.BtnRefreshCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefreshCliente.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BtnRefreshCliente.Location = New System.Drawing.Point(234, 28)
        Me.BtnRefreshCliente.Name = "BtnRefreshCliente"
        Me.BtnRefreshCliente.Size = New System.Drawing.Size(26, 26)
        Me.BtnRefreshCliente.TabIndex = 606
        Me.BtnRefreshCliente.UseVisualStyleBackColor = True
        Me.BtnRefreshCliente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCP
        '
        Me.LtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP.Location = New System.Drawing.Point(275, 88)
        Me.LtCP.Name = "LtCP"
        Me.LtCP.Size = New System.Drawing.Size(53, 20)
        Me.LtCP.TabIndex = 605
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(241, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 16)
        Me.Label9.TabIndex = 604
        Me.Label9.Text = "C.P."
        '
        'LtUSO_CFDI
        '
        Me.LtUSO_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUSO_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUSO_CFDI.Location = New System.Drawing.Point(406, 87)
        Me.LtUSO_CFDI.Name = "LtUSO_CFDI"
        Me.LtUSO_CFDI.Size = New System.Drawing.Size(82, 20)
        Me.LtUSO_CFDI.TabIndex = 603
        Me.LtUSO_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(334, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 602
        Me.Label8.Text = "Uso CFDI"
        '
        'LtRegimenReceptor
        '
        Me.LtRegimenReceptor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRegimenReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRegimenReceptor.Location = New System.Drawing.Point(668, 87)
        Me.LtRegimenReceptor.Name = "LtRegimenReceptor"
        Me.LtRegimenReceptor.Size = New System.Drawing.Size(82, 20)
        Me.LtRegimenReceptor.TabIndex = 601
        Me.LtRegimenReceptor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtRegimenEmisor
        '
        Me.LtRegimenEmisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRegimenEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRegimenEmisor.Location = New System.Drawing.Point(668, 64)
        Me.LtRegimenEmisor.Name = "LtRegimenEmisor"
        Me.LtRegimenEmisor.Size = New System.Drawing.Size(82, 20)
        Me.LtRegimenEmisor.TabIndex = 600
        Me.LtRegimenEmisor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 16)
        Me.Label2.TabIndex = 599
        Me.Label2.Text = "Regimen fiscal receptor"
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(338, 25)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(165, 29)
        Me.LtCVE_DOC.TabIndex = 356
        Me.LtCVE_DOC.Text = "0000000009"
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClie
        '
        Me.btnClie.BackColor = System.Drawing.Color.Transparent
        Me.btnClie.FlatAppearance.BorderSize = 0
        Me.btnClie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClie.ForeColor = System.Drawing.Color.Transparent
        Me.btnClie.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.btnClie.Location = New System.Drawing.Point(187, 26)
        Me.btnClie.Name = "btnClie"
        Me.btnClie.Size = New System.Drawing.Size(26, 26)
        Me.btnClie.TabIndex = 348
        Me.btnClie.UseVisualStyleBackColor = False
        Me.btnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(523, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 16)
        Me.Label5.TabIndex = 593
        Me.Label5.Text = "Regimen fiscal emisor"
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(97, 28)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(88, 22)
        Me.TCLIENTE.TabIndex = 1
        '
        'LtTimbrado
        '
        Me.LtTimbrado.AutoSize = True
        Me.LtTimbrado.BackColor = System.Drawing.Color.Transparent
        Me.LtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTimbrado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTimbrado.Location = New System.Drawing.Point(1059, 49)
        Me.LtTimbrado.Name = "LtTimbrado"
        Me.LtTimbrado.Size = New System.Drawing.Size(56, 16)
        Me.LtTimbrado.TabIndex = 588
        Me.LtTimbrado.Text = "_______"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 16)
        Me.Label14.TabIndex = 347
        Me.Label14.Text = "Clave"
        '
        'LtRFC
        '
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.Location = New System.Drawing.Point(97, 88)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(140, 20)
        Me.LtRFC.TabIndex = 352
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(97, 64)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(391, 20)
        Me.LtNombre.TabIndex = 350
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 351
        Me.Label3.Text = "R.F.C."
        '
        'TMagico
        '
        Me.TMagico.AcceptsReturn = True
        Me.TMagico.AcceptsTab = True
        Me.TMagico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMagico.Location = New System.Drawing.Point(352, 28)
        Me.TMagico.Name = "TMagico"
        Me.TMagico.Size = New System.Drawing.Size(57, 22)
        Me.TMagico.TabIndex = 3
        '
        'Labl2
        '
        Me.Labl2.AutoSize = True
        Me.Labl2.BackColor = System.Drawing.Color.Transparent
        Me.Labl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labl2.Location = New System.Drawing.Point(5, 67)
        Me.Labl2.Name = "Labl2"
        Me.Labl2.Size = New System.Drawing.Size(85, 16)
        Me.Labl2.TabIndex = 349
        Me.Labl2.Text = "Razón social"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(668, 25)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(110, 20)
        Me.F1.TabIndex = 2
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(618, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 354
        Me.Label1.Text = "Fecha"
        '
        'Ldocu
        '
        Me.Ldocu.AutoSize = True
        Me.Ldocu.BackColor = System.Drawing.Color.Transparent
        Me.Ldocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ldocu.Location = New System.Drawing.Point(378, 5)
        Me.Ldocu.Name = "Ldocu"
        Me.Ldocu.Size = New System.Drawing.Size(89, 17)
        Me.Ldocu.TabIndex = 355
        Me.Ldocu.Text = "Documento"
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Controls.Add(Me.TXT)
        Me.Split2.Controls.Add(Me.TXTN)
        Me.Split2.Height = 156
        Me.Split2.Location = New System.Drawing.Point(1, 168)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1226, 156)
        Me.Split2.SizeRatio = 47.416R
        Me.Split2.TabIndex = 1
        '
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 5
        Me.Fg.Rows.DefaultSize = 22
        Me.Fg.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCursor = True
        Me.Fg.ShowErrors = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.Both
        Me.Fg.Size = New System.Drawing.Size(1226, 156)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'TXT
        '
        Me.TXT.BackColor = System.Drawing.Color.PaleTurquoise
        Me.TXT.BorderColor = System.Drawing.Color.Black
        Me.TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT.Location = New System.Drawing.Point(1329, 67)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(41, 18)
        Me.TXT.TabIndex = 359
        Me.TXT.Tag = Nothing
        Me.TXT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TXTN
        '
        Me.TXTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TXTN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TXTN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TXTN.ImagePadding = New System.Windows.Forms.Padding(45, 0, 0, 0)
        Me.TXTN.Location = New System.Drawing.Point(1297, 67)
        Me.TXTN.Name = "TXTN"
        Me.TXTN.Size = New System.Drawing.Size(26, 18)
        Me.TXTN.TabIndex = 358
        Me.TXTN.Tag = Nothing
        Me.TXTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTN.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TXTN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TXTN.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Split3
        '
        Me.Split3.Controls.Add(Me.FgDR)
        Me.Split3.Height = 173
        Me.Split3.Location = New System.Drawing.Point(1, 349)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1226, 152)
        Me.Split3.TabIndex = 2
        Me.Split3.Text = "Documentos relacionados"
        '
        'FgDR
        '
        Me.FgDR.AllowNodeCellCheck = False
        Me.FgDR.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgDR.AutoClipboard = True
        Me.FgDR.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgDR.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.FgDR.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgDR.ColumnInfo = resources.GetString("FgDR.ColumnInfo")
        Me.FgDR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgDR.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FgDR.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgDR.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgDR.Location = New System.Drawing.Point(0, 0)
        Me.FgDR.Name = "FgDR"
        Me.FgDR.Rows.Count = 5
        Me.FgDR.Rows.DefaultSize = 22
        Me.FgDR.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
        Me.FgDR.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgDR.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgDR.ShowCursor = True
        Me.FgDR.ShowErrors = True
        Me.FgDR.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.Both
        Me.FgDR.Size = New System.Drawing.Size(1226, 152)
        Me.FgDR.StyleInfo = resources.GetString("FgDR.StyleInfo")
        Me.FgDR.TabIndex = 608
        Me.FgDR.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "41145b081bc34521b94ec07ae73288e7"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.Transparent
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(786, 93)
        Me.Lt2.Margin = New System.Windows.Forms.Padding(3)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(71, 15)
        Me.Lt2.TabIndex = 609
        Me.Lt2.Text = "________"
        Me.Lt2.Visible = False
        '
        'FrmPagoComplementoAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 559)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPagoComplementoAE"
        Me.Text = "Pago Complemento"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.BtnRefreshCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split3.ResumeLayout(False)
        CType(Me.FgDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents BarRecepPagoMult As C1.Win.C1Command.C1Command
    Friend WithEvents BarCFDIRel As C1.Win.C1Command.C1Command
    Friend WithEvents BarFolioDigital As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarVarios As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents LkObsDoc As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkTotales As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFolioDigital As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkRecepPagoMult As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCFDIRel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents btnClie As C1.Win.C1Input.C1Button
    Friend WithEvents Labl2 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtRFC As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Ldocu As Label
    Friend WithEvents LkObsPart As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminarPart As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDatosCliente As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkAltaCliente As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarObsDoc As C1.Win.C1Command.C1Command
    Friend WithEvents LkVarios As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarTotales As C1.Win.C1Command.C1Command
    Friend WithEvents BarObsPart As C1.Win.C1Command.C1Command
    Friend WithEvents BarEliminarPart As C1.Win.C1Command.C1Command
    Friend WithEvents BarDatosCliente As C1.Win.C1Command.C1Command
    Friend WithEvents BarAltaCliente As C1.Win.C1Command.C1Command
    Friend WithEvents TXTN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TXT As C1.Win.C1Input.C1TextBox
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents LtTimbrado As Label
    Friend WithEvents LkAltaCtaOrdenante As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarAltaCtaOrdenante As C1.Win.C1Command.C1Command
    Friend WithEvents LkAltaCtaBeneficiario As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BatAltaCtaBeneficiario As C1.Win.C1Command.C1Command
    Friend WithEvents Label5 As Label
    Friend WithEvents TMagico As TextBox
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents LtRegimenReceptor As Label
    Friend WithEvents LtRegimenEmisor As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtUSO_CFDI As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LtCP As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnRefreshCliente As C1.Win.C1Input.C1Button
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents FgDR As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtCorreo As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Private WithEvents Lt2 As Label
End Class
