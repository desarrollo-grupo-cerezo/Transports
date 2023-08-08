<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOTEAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOTEAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarEnlazarDoc = New C1.Win.C1Command.C1Command()
        Me.BarFinOT = New C1.Win.C1Command.C1Command()
        Me.BarRemisionar = New C1.Win.C1Command.C1Command()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.BarReimpresion = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkEnlazarDoc = New C1.Win.C1Command.C1CommandLink()
        Me.LkFinOT = New C1.Win.C1Command.C1CommandLink()
        Me.LkRemisionar = New C1.Win.C1Command.C1CommandLink()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.LkReimpresion = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.TabProductos = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtDocAnt = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.btnAltaProducto = New C1.Win.C1Input.C1Button()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnEliProd = New C1.Win.C1Input.C1Button()
        Me.TabDocDigitales = New C1.Win.C1Command.C1DockingTabPage()
        Me.btnBuscaDoc = New System.Windows.Forms.Button()
        Me.LtFotoDoc = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.tDescrFotDoc = New System.Windows.Forms.TextBox()
        Me.FgD = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFotDocE = New C1.Win.C1Input.C1Button()
        Me.btnFotDocA = New C1.Win.C1Input.C1Button()
        Me.TabObser = New C1.Win.C1Command.C1DockingTabPage()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.tBotonMagico = New System.Windows.Forms.TextBox()
        Me.tEstatus = New System.Windows.Forms.Label()
        Me.tFACTURA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtRem = New System.Windows.Forms.Label()
        Me.LProgServ = New System.Windows.Forms.Label()
        Me.BtnServProg = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROG = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tResponsable = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tNOTA = New System.Windows.Forms.TextBox()
        Me.tLUGAR_REP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.L4 = New System.Windows.Forms.Label()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tCVE_TIPO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tCVE_ORD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadPreventivo = New System.Windows.Forms.RadioButton()
        Me.RadCorrectivo = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.radSinistro = New System.Windows.Forms.RadioButton()
        Me.RadRescateCarr = New System.Windows.Forms.RadioButton()
        Me.RadLLantas = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.F1 = New C1.Win.C1Input.C1DateEdit()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.TabProductos.SuspendLayout()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocDigitales.SuspendLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabObser.SuspendLayout()
        CType(Me.BtnServProg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarEnlazarDoc)
        Me.MenuHolder.Commands.Add(Me.BarFinOT)
        Me.MenuHolder.Commands.Add(Me.BarRemisionar)
        Me.MenuHolder.Commands.Add(Me.BarEliminar)
        Me.MenuHolder.Commands.Add(Me.BarReimpresion)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
        '
        'BarEnlazarDoc
        '
        Me.BarEnlazarDoc.Image = Global.SGT_Transport.My.Resources.Resources.doc17
        Me.BarEnlazarDoc.Name = "BarEnlazarDoc"
        Me.BarEnlazarDoc.ShortcutText = ""
        Me.BarEnlazarDoc.Text = "Enlazar reporte"
        '
        'BarFinOT
        '
        Me.BarFinOT.Image = Global.SGT_Transport.My.Resources.Resources.A6
        Me.BarFinOT.Name = "BarFinOT"
        Me.BarFinOT.ShortcutText = ""
        Me.BarFinOT.ShowShortcut = False
        Me.BarFinOT.ShowTextAsToolTip = False
        Me.BarFinOT.Text = "Autorizar"
        '
        'BarRemisionar
        '
        Me.BarRemisionar.Image = Global.SGT_Transport.My.Resources.Resources.LETRA_R4
        Me.BarRemisionar.Name = "BarRemisionar"
        Me.BarRemisionar.ShortcutText = ""
        Me.BarRemisionar.Text = "Remisionar"
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.C1
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutText = ""
        Me.BarEliminar.Text = "Cancelar OT"
        '
        'BarReimpresion
        '
        Me.BarReimpresion.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.BarReimpresion.Name = "BarReimpresion"
        Me.BarReimpresion.ShortcutText = ""
        Me.BarReimpresion.Text = "Reimpresión"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
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
        'C1ThemeController1
        '
        Me.C1ThemeController1.Theme = "MacBlue"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookEnforceHorz = True
        Me.C1ToolBar1.ButtonLookEnforceVert = True
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 85
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkEnlazarDoc, Me.LkFinOT, Me.LkRemisionar, Me.LkEliminar, Me.LkReimpresion, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1163, 55)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "(default)")
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.OwnerDraw = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkEnlazarDoc
        '
        Me.LkEnlazarDoc.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEnlazarDoc.Command = Me.BarEnlazarDoc
        Me.LkEnlazarDoc.Delimiter = True
        Me.LkEnlazarDoc.SortOrder = 1
        Me.LkEnlazarDoc.Text = "Enlazar reporte de fallas"
        '
        'LkFinOT
        '
        Me.LkFinOT.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFinOT.Command = Me.BarFinOT
        Me.LkFinOT.Delimiter = True
        Me.LkFinOT.SortOrder = 2
        Me.LkFinOT.Text = "Autorizar"
        '
        'LkRemisionar
        '
        Me.LkRemisionar.Command = Me.BarRemisionar
        Me.LkRemisionar.Delimiter = True
        Me.LkRemisionar.SortOrder = 3
        Me.LkRemisionar.Text = "Remisionar"
        '
        'LkEliminar
        '
        Me.LkEliminar.Command = Me.BarEliminar
        Me.LkEliminar.Delimiter = True
        Me.LkEliminar.SortOrder = 4
        Me.LkEliminar.Text = "Cancelar OT"
        '
        'LkReimpresion
        '
        Me.LkReimpresion.Command = Me.BarReimpresion
        Me.LkReimpresion.SortOrder = 5
        Me.LkReimpresion.Text = "Reimpresión"
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
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(34, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 15)
        Me.Label27.TabIndex = 149
        Me.C1ThemeController1.SetTheme(Me.Label27, "(default)")
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label90.Location = New System.Drawing.Point(150, 26)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(41, 15)
        Me.Label90.TabIndex = 153
        Me.C1ThemeController1.SetTheme(Me.Label90, "(default)")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 22)
        Me.Label1.TabIndex = 156
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label1, "(default)")
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.TabProductos)
        Me.Tab1.Controls.Add(Me.TabDocDigitales)
        Me.Tab1.Controls.Add(Me.TabObser)
        Me.Tab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(4, 225)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(1151, 327)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1ThemeController1.SetTheme(Me.Tab1, "(default)")
        '
        'TabProductos
        '
        Me.TabProductos.Controls.Add(Me.LtDocAnt)
        Me.TabProductos.Controls.Add(Me.Label7)
        Me.TabProductos.Controls.Add(Me.Lt1)
        Me.TabProductos.Controls.Add(Me.L1)
        Me.TabProductos.Controls.Add(Me.btnAltaProducto)
        Me.TabProductos.Controls.Add(Me.Fg)
        Me.TabProductos.Controls.Add(Me.btnEliProd)
        Me.TabProductos.Location = New System.Drawing.Point(1, 25)
        Me.TabProductos.Name = "TabProductos"
        Me.TabProductos.Size = New System.Drawing.Size(1149, 301)
        Me.TabProductos.TabIndex = 0
        Me.TabProductos.Text = "Servicios"
        '
        'LtDocAnt
        '
        Me.LtDocAnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtDocAnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDocAnt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocAnt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtDocAnt.Location = New System.Drawing.Point(104, 267)
        Me.LtDocAnt.Name = "LtDocAnt"
        Me.LtDocAnt.Size = New System.Drawing.Size(164, 22)
        Me.LtDocAnt.TabIndex = 140
        Me.LtDocAnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtDocAnt, "(default)")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Doc. enlazado"
        Me.C1ThemeController1.SetTheme(Me.Label7, "(default)")
        '
        'Lt1
        '
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(967, 267)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(164, 22)
        Me.Lt1.TabIndex = 135
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Lt1, "(default)")
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L1.Location = New System.Drawing.Point(912, 270)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(49, 15)
        Me.L1.TabIndex = 134
        Me.L1.Text = "Importe"
        Me.C1ThemeController1.SetTheme(Me.L1, "(default)")
        '
        'btnAltaProducto
        '
        Me.btnAltaProducto.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaProducto.Location = New System.Drawing.Point(860, 2)
        Me.btnAltaProducto.Name = "btnAltaProducto"
        Me.btnAltaProducto.Size = New System.Drawing.Size(36, 33)
        Me.btnAltaProducto.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.btnAltaProducto, "(default)")
        Me.btnAltaProducto.UseVisualStyleBackColor = True
        Me.btnAltaProducto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(4, 39)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1127, 221)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.Fg, "(default)")
        '
        'btnEliProd
        '
        Me.btnEliProd.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.btnEliProd.Location = New System.Drawing.Point(936, 3)
        Me.btnEliProd.Name = "btnEliProd"
        Me.btnEliProd.Size = New System.Drawing.Size(36, 32)
        Me.btnEliProd.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.btnEliProd, "(default)")
        Me.btnEliProd.UseVisualStyleBackColor = True
        Me.btnEliProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TabDocDigitales
        '
        Me.TabDocDigitales.Controls.Add(Me.btnBuscaDoc)
        Me.TabDocDigitales.Controls.Add(Me.LtFotoDoc)
        Me.TabDocDigitales.Controls.Add(Me.Label8)
        Me.TabDocDigitales.Controls.Add(Me.Label78)
        Me.TabDocDigitales.Controls.Add(Me.tDescrFotDoc)
        Me.TabDocDigitales.Controls.Add(Me.FgD)
        Me.TabDocDigitales.Controls.Add(Me.Label4)
        Me.TabDocDigitales.Controls.Add(Me.btnFotDocE)
        Me.TabDocDigitales.Controls.Add(Me.btnFotDocA)
        Me.TabDocDigitales.Location = New System.Drawing.Point(1, 25)
        Me.TabDocDigitales.Name = "TabDocDigitales"
        Me.TabDocDigitales.Size = New System.Drawing.Size(1149, 301)
        Me.TabDocDigitales.TabIndex = 4
        Me.TabDocDigitales.Text = "Documentos digitales"
        '
        'btnBuscaDoc
        '
        Me.btnBuscaDoc.AutoSize = True
        Me.btnBuscaDoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscaDoc.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscaDoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnBuscaDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnBuscaDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnBuscaDoc.Image = CType(resources.GetObject("btnBuscaDoc.Image"), System.Drawing.Image)
        Me.btnBuscaDoc.Location = New System.Drawing.Point(550, 62)
        Me.btnBuscaDoc.Name = "btnBuscaDoc"
        Me.btnBuscaDoc.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscaDoc.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.btnBuscaDoc, "(default)")
        Me.btnBuscaDoc.UseVisualStyleBackColor = True
        '
        'LtFotoDoc
        '
        Me.LtFotoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtFotoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFotoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFotoDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtFotoDoc.Location = New System.Drawing.Point(83, 64)
        Me.LtFotoDoc.Name = "LtFotoDoc"
        Me.LtFotoDoc.Size = New System.Drawing.Size(466, 19)
        Me.LtFotoDoc.TabIndex = 270
        Me.LtFotoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtFotoDoc, "(default)")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 269
        Me.Label8.Text = "Documento"
        Me.C1ThemeController1.SetTheme(Me.Label8, "(default)")
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label78.Location = New System.Drawing.Point(8, 44)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(72, 15)
        Me.Label78.TabIndex = 268
        Me.Label78.Text = "Descripción"
        Me.C1ThemeController1.SetTheme(Me.Label78, "(default)")
        '
        'tDescrFotDoc
        '
        Me.tDescrFotDoc.AcceptsReturn = True
        Me.tDescrFotDoc.AcceptsTab = True
        Me.tDescrFotDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescrFotDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tDescrFotDoc.Location = New System.Drawing.Point(82, 41)
        Me.tDescrFotDoc.Multiline = True
        Me.tDescrFotDoc.Name = "tDescrFotDoc"
        Me.tDescrFotDoc.Size = New System.Drawing.Size(467, 20)
        Me.tDescrFotDoc.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tDescrFotDoc, "(default)")
        '
        'FgD
        '
        Me.FgD.AllowFiltering = True
        Me.FgD.BackColor = System.Drawing.Color.White
        Me.FgD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgD.ColumnInfo = resources.GetString("FgD.ColumnInfo")
        Me.FgD.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FgD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.FgD.Location = New System.Drawing.Point(8, 86)
        Me.FgD.Name = "FgD"
        Me.FgD.Rows.DefaultSize = 19
        Me.FgD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgD.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgD.Size = New System.Drawing.Size(839, 137)
        Me.FgD.StyleInfo = resources.GetString("FgD.StyleInfo")
        Me.FgD.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.FgD, "(default)")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(839, 20)
        Me.Label4.TabIndex = 267
        Me.Label4.Text = "Documentos digitales"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label4, "(default)")
        '
        'btnFotDocE
        '
        Me.btnFotDocE.Image = CType(resources.GetObject("btnFotDocE.Image"), System.Drawing.Image)
        Me.btnFotDocE.Location = New System.Drawing.Point(797, 44)
        Me.btnFotDocE.Name = "btnFotDocE"
        Me.btnFotDocE.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocE.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.btnFotDocE, "(default)")
        Me.btnFotDocE.UseVisualStyleBackColor = True
        Me.btnFotDocE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnFotDocA
        '
        Me.btnFotDocA.Image = CType(resources.GetObject("btnFotDocA.Image"), System.Drawing.Image)
        Me.btnFotDocA.Location = New System.Drawing.Point(743, 44)
        Me.btnFotDocA.Name = "btnFotDocA"
        Me.btnFotDocA.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocA.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.btnFotDocA, "(default)")
        Me.btnFotDocA.UseVisualStyleBackColor = True
        Me.btnFotDocA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TabObser
        '
        Me.TabObser.Controls.Add(Me.tOBSER)
        Me.TabObser.Location = New System.Drawing.Point(1, 25)
        Me.TabObser.Name = "TabObser"
        Me.TabObser.Size = New System.Drawing.Size(1149, 301)
        Me.TabObser.TabIndex = 2
        Me.TabObser.Text = "Observaciones"
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tOBSER.Location = New System.Drawing.Point(24, 27)
        Me.tOBSER.Multiline = True
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(695, 134)
        Me.tOBSER.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tOBSER, "(default)")
        '
        'tBotonMagico
        '
        Me.tBotonMagico.AcceptsReturn = True
        Me.tBotonMagico.AcceptsTab = True
        Me.tBotonMagico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBotonMagico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tBotonMagico.Location = New System.Drawing.Point(1082, 130)
        Me.tBotonMagico.Name = "tBotonMagico"
        Me.tBotonMagico.Size = New System.Drawing.Size(53, 22)
        Me.tBotonMagico.TabIndex = 148
        Me.C1ThemeController1.SetTheme(Me.tBotonMagico, "(default)")
        '
        'tEstatus
        '
        Me.tEstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tEstatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tEstatus.Location = New System.Drawing.Point(531, 51)
        Me.tEstatus.Name = "tEstatus"
        Me.tEstatus.Size = New System.Drawing.Size(187, 22)
        Me.tEstatus.TabIndex = 153
        Me.tEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.tEstatus, "(default)")
        '
        'tFACTURA
        '
        Me.tFACTURA.AcceptsReturn = True
        Me.tFACTURA.AcceptsTab = True
        Me.tFACTURA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFACTURA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tFACTURA.Location = New System.Drawing.Point(1250, 175)
        Me.tFACTURA.Name = "tFACTURA"
        Me.tFACTURA.Size = New System.Drawing.Size(174, 22)
        Me.tFACTURA.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tFACTURA, "(default)")
        Me.tFACTURA.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1247, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 15)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Factura proveedor"
        Me.C1ThemeController1.SetTheme(Me.Label5, "(default)")
        Me.Label5.Visible = False
        '
        'LtRem
        '
        Me.LtRem.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtRem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtRem.Location = New System.Drawing.Point(531, 78)
        Me.LtRem.Name = "LtRem"
        Me.LtRem.Size = New System.Drawing.Size(187, 22)
        Me.LtRem.TabIndex = 143
        Me.LtRem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtRem, "(default)")
        Me.LtRem.Visible = False
        '
        'LProgServ
        '
        Me.LProgServ.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LProgServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LProgServ.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LProgServ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LProgServ.Location = New System.Drawing.Point(196, 79)
        Me.LProgServ.Name = "LProgServ"
        Me.LProgServ.Size = New System.Drawing.Size(326, 22)
        Me.LProgServ.TabIndex = 150
        Me.LProgServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LProgServ, "(default)")
        '
        'BtnServProg
        '
        Me.BtnServProg.Image = CType(resources.GetObject("BtnServProg.Image"), System.Drawing.Image)
        Me.BtnServProg.Location = New System.Drawing.Point(168, 79)
        Me.BtnServProg.Name = "BtnServProg"
        Me.BtnServProg.Size = New System.Drawing.Size(26, 20)
        Me.BtnServProg.TabIndex = 149
        Me.C1ThemeController1.SetTheme(Me.BtnServProg, "(default)")
        Me.BtnServProg.UseVisualStyleBackColor = True
        Me.BtnServProg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_PROG
        '
        Me.tCVE_PROG.AcceptsReturn = True
        Me.tCVE_PROG.AcceptsTab = True
        Me.tCVE_PROG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_PROG.Enabled = False
        Me.tCVE_PROG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_PROG.Location = New System.Drawing.Point(90, 79)
        Me.tCVE_PROG.Name = "tCVE_PROG"
        Me.tCVE_PROG.Size = New System.Drawing.Size(74, 22)
        Me.tCVE_PROG.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROG, "(default)")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.tResponsable)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.tEstatus)
        Me.Panel2.Controls.Add(Me.LtRem)
        Me.Panel2.Controls.Add(Me.LProgServ)
        Me.Panel2.Controls.Add(Me.BtnServProg)
        Me.Panel2.Controls.Add(Me.tCVE_PROG)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.tNOTA)
        Me.Panel2.Controls.Add(Me.tLUGAR_REP)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.L3)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnProv)
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.tCVE_PROV)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.tCVE_TIPO)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.btnUnidades)
        Me.Panel2.Controls.Add(Me.tCVE_UNI)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(391, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(764, 161)
        Me.Panel2.TabIndex = 146
        Me.C1ThemeController1.SetTheme(Me.Panel2, "(default)")
        '
        'tResponsable
        '
        Me.tResponsable.AcceptsReturn = True
        Me.tResponsable.AcceptsTab = True
        Me.tResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tResponsable.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tResponsable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tResponsable.Location = New System.Drawing.Point(324, 106)
        Me.tResponsable.MaxLength = 50
        Me.tResponsable.Name = "tResponsable"
        Me.tResponsable.Size = New System.Drawing.Size(394, 21)
        Me.tResponsable.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tResponsable, "(default)")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(239, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 15)
        Me.Label16.TabIndex = 156
        Me.Label16.Text = "Responsable"
        Me.C1ThemeController1.SetTheme(Me.Label16, "(default)")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(5, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Prog. servicio"
        Me.C1ThemeController1.SetTheme(Me.Label6, "(default)")
        '
        'tNOTA
        '
        Me.tNOTA.AcceptsReturn = True
        Me.tNOTA.AcceptsTab = True
        Me.tNOTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNOTA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOTA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tNOTA.Location = New System.Drawing.Point(90, 106)
        Me.tNOTA.Name = "tNOTA"
        Me.tNOTA.Size = New System.Drawing.Size(146, 22)
        Me.tNOTA.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tNOTA, "(default)")
        '
        'tLUGAR_REP
        '
        Me.tLUGAR_REP.AcceptsReturn = True
        Me.tLUGAR_REP.AcceptsTab = True
        Me.tLUGAR_REP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tLUGAR_REP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLUGAR_REP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tLUGAR_REP.Location = New System.Drawing.Point(111, 133)
        Me.tLUGAR_REP.Name = "tLUGAR_REP"
        Me.tLUGAR_REP.Size = New System.Drawing.Size(607, 22)
        Me.tLUGAR_REP.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tLUGAR_REP, "(default)")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(23, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "Odómetro"
        Me.C1ThemeController1.SetTheme(Me.Label10, "(default)")
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L3.Location = New System.Drawing.Point(196, 53)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(326, 22)
        Me.L3.TabIndex = 133
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L3, "(default)")
        Me.L3.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(7, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 15)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Lugar reparación"
        Me.C1ThemeController1.SetTheme(Me.Label12, "(default)")
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(168, 53)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 20)
        Me.btnProv.TabIndex = 132
        Me.C1ThemeController1.SetTheme(Me.btnProv, "(default)")
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.Visible = False
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L4
        '
        Me.L4.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L4.Location = New System.Drawing.Point(196, 28)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(326, 22)
        Me.L4.TabIndex = 140
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L4, "(default)")
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_PROV.Location = New System.Drawing.Point(90, 53)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(74, 22)
        Me.tCVE_PROV.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROV, "(default)")
        Me.tCVE_PROV.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(598, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 15)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Estatus"
        Me.C1ThemeController1.SetTheme(Me.Label11, "(default)")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(40, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "Cliente"
        Me.C1ThemeController1.SetTheme(Me.Label9, "(default)")
        Me.Label9.Visible = False
        '
        'tCVE_TIPO
        '
        Me.tCVE_TIPO.AcceptsReturn = True
        Me.tCVE_TIPO.AcceptsTab = True
        Me.tCVE_TIPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_TIPO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TIPO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_TIPO.Location = New System.Drawing.Point(90, 28)
        Me.tCVE_TIPO.Name = "tCVE_TIPO"
        Me.tCVE_TIPO.ReadOnly = True
        Me.tCVE_TIPO.Size = New System.Drawing.Size(74, 22)
        Me.tCVE_TIPO.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_TIPO, "(default)")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(54, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "Tipo"
        Me.C1ThemeController1.SetTheme(Me.Label13, "(default)")
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L2.Location = New System.Drawing.Point(196, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(326, 22)
        Me.L2.TabIndex = 131
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L2, "(default)")
        '
        'btnUnidades
        '
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(168, 3)
        Me.btnUnidades.Name = "btnUnidades"
        Me.btnUnidades.Size = New System.Drawing.Size(26, 20)
        Me.btnUnidades.TabIndex = 130
        Me.C1ThemeController1.SetTheme(Me.btnUnidades, "(default)")
        Me.btnUnidades.UseVisualStyleBackColor = True
        Me.btnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_UNI.Location = New System.Drawing.Point(90, 3)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(74, 22)
        Me.tCVE_UNI.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "(default)")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(38, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 15)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "Unidad"
        Me.C1ThemeController1.SetTheme(Me.Label14, "(default)")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(34, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Folio"
        Me.C1ThemeController1.SetTheme(Me.Label3, "(default)")
        '
        'tCVE_ORD
        '
        Me.tCVE_ORD.AcceptsReturn = True
        Me.tCVE_ORD.AcceptsTab = True
        Me.tCVE_ORD.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tCVE_ORD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_ORD.Location = New System.Drawing.Point(74, 23)
        Me.tCVE_ORD.Name = "tCVE_ORD"
        Me.tCVE_ORD.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_ORD.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_ORD, "(default)")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(150, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label2, "(default)")
        '
        'RadPreventivo
        '
        Me.RadPreventivo.AutoSize = True
        Me.RadPreventivo.BackColor = System.Drawing.Color.Transparent
        Me.RadPreventivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadPreventivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadPreventivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPreventivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadPreventivo.Location = New System.Drawing.Point(16, 89)
        Me.RadPreventivo.Name = "RadPreventivo"
        Me.RadPreventivo.Size = New System.Drawing.Size(81, 19)
        Me.RadPreventivo.TabIndex = 1
        Me.RadPreventivo.TabStop = True
        Me.RadPreventivo.Text = "Preventivo"
        Me.C1ThemeController1.SetTheme(Me.RadPreventivo, "(default)")
        Me.RadPreventivo.UseVisualStyleBackColor = False
        '
        'RadCorrectivo
        '
        Me.RadCorrectivo.AutoSize = True
        Me.RadCorrectivo.BackColor = System.Drawing.Color.Transparent
        Me.RadCorrectivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadCorrectivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadCorrectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCorrectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadCorrectivo.Location = New System.Drawing.Point(128, 89)
        Me.RadCorrectivo.Name = "RadCorrectivo"
        Me.RadCorrectivo.Size = New System.Drawing.Size(79, 19)
        Me.RadCorrectivo.TabIndex = 2
        Me.RadCorrectivo.TabStop = True
        Me.RadCorrectivo.Text = "Correctivo"
        Me.C1ThemeController1.SetTheme(Me.RadCorrectivo, "(default)")
        Me.RadCorrectivo.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(0, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(389, 22)
        Me.Label15.TabIndex = 156
        Me.Label15.Text = "Tipo de servicio"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label15, "(default)")
        '
        'radExtra
        '
        Me.radExtra.AutoSize = True
        Me.radExtra.BackColor = System.Drawing.Color.Transparent
        Me.radExtra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radExtra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radExtra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radExtra.Location = New System.Drawing.Point(273, 89)
        Me.radExtra.Name = "radExtra"
        Me.radExtra.Size = New System.Drawing.Size(102, 19)
        Me.radExtra.TabIndex = 3
        Me.radExtra.TabStop = True
        Me.radExtra.Text = "Extraordinario"
        Me.C1ThemeController1.SetTheme(Me.radExtra, "(default)")
        Me.radExtra.UseVisualStyleBackColor = False
        '
        'radSinistro
        '
        Me.radSinistro.AutoSize = True
        Me.radSinistro.BackColor = System.Drawing.Color.Transparent
        Me.radSinistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radSinistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radSinistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSinistro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radSinistro.Location = New System.Drawing.Point(16, 116)
        Me.radSinistro.Name = "radSinistro"
        Me.radSinistro.Size = New System.Drawing.Size(73, 19)
        Me.radSinistro.TabIndex = 4
        Me.radSinistro.TabStop = True
        Me.radSinistro.Text = "Siniestro"
        Me.C1ThemeController1.SetTheme(Me.radSinistro, "(default)")
        Me.radSinistro.UseVisualStyleBackColor = False
        '
        'RadRescateCarr
        '
        Me.RadRescateCarr.AutoSize = True
        Me.RadRescateCarr.BackColor = System.Drawing.Color.Transparent
        Me.RadRescateCarr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadRescateCarr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadRescateCarr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadRescateCarr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadRescateCarr.Location = New System.Drawing.Point(127, 116)
        Me.RadRescateCarr.Name = "RadRescateCarr"
        Me.RadRescateCarr.Size = New System.Drawing.Size(122, 19)
        Me.RadRescateCarr.TabIndex = 5
        Me.RadRescateCarr.TabStop = True
        Me.RadRescateCarr.Text = "Rescate carretero"
        Me.C1ThemeController1.SetTheme(Me.RadRescateCarr, "(default)")
        Me.RadRescateCarr.UseVisualStyleBackColor = False
        '
        'RadLLantas
        '
        Me.RadLLantas.AutoSize = True
        Me.RadLLantas.BackColor = System.Drawing.Color.Transparent
        Me.RadLLantas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadLLantas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadLLantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLLantas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadLLantas.Location = New System.Drawing.Point(273, 116)
        Me.RadLLantas.Name = "RadLLantas"
        Me.RadLLantas.Size = New System.Drawing.Size(65, 19)
        Me.RadLLantas.TabIndex = 6
        Me.RadLLantas.TabStop = True
        Me.RadLLantas.Text = "Llantas"
        Me.C1ThemeController1.SetTheme(Me.RadLLantas, "(default)")
        Me.RadLLantas.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.RadLLantas)
        Me.Panel1.Controls.Add(Me.RadRescateCarr)
        Me.Panel1.Controls.Add(Me.radSinistro)
        Me.Panel1.Controls.Add(Me.radExtra)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.RadCorrectivo)
        Me.Panel1.Controls.Add(Me.RadPreventivo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tCVE_ORD)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(5, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 161)
        Me.Panel1.TabIndex = 145
        Me.C1ThemeController1.SetTheme(Me.Panel1, "(default)")
        '
        'F1
        '
        Me.F1.BackColor = System.Drawing.Color.White
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.F1.Calendar.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.F1.Calendar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.F1.Calendar.DayNamesFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.F1.Calendar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.F1.Calendar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.F1.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.F1.Calendar.SelectionForeColor = System.Drawing.Color.White
        Me.F1.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.F1.Calendar.TitleFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.F1.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.F1.Calendar.TodayBorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.GapHeight = 0
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(194, 26)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(104, 19)
        Me.F1.TabIndex = 157
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "(default)")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "80919448528640dfb709c7ec81792fc5"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'frmOTEAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 576)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tFACTURA)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.tBotonMagico)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOTEAE"
        Me.Text = "Orden de trabajo externa"
        Me.C1ThemeController1.SetTheme(Me, "(default)")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.TabProductos.ResumeLayout(False)
        Me.TabProductos.PerformLayout()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocDigitales.ResumeLayout(False)
        Me.TabDocDigitales.PerformLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabObser.ResumeLayout(False)
        Me.TabObser.PerformLayout()
        CType(Me.BtnServProg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarEnlazarDoc As C1.Win.C1Command.C1Command
    Friend WithEvents BarFinOT As C1.Win.C1Command.C1Command
    Friend WithEvents BarRemisionar As C1.Win.C1Command.C1Command
    Friend WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Friend WithEvents BarReimpresion As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Private WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEnlazarDoc As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFinOT As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkRemisionar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkReimpresion As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Label27 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents TabProductos As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents LtDocAnt As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents btnAltaProducto As C1.Win.C1Input.C1Button
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnEliProd As C1.Win.C1Input.C1Button
    Friend WithEvents TabDocDigitales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents btnBuscaDoc As Button
    Friend WithEvents LtFotoDoc As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents tDescrFotDoc As TextBox
    Friend WithEvents FgD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents btnFotDocE As C1.Win.C1Input.C1Button
    Friend WithEvents btnFotDocA As C1.Win.C1Input.C1Button
    Friend WithEvents TabObser As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents tBotonMagico As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tEstatus As Label
    Friend WithEvents tFACTURA As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LtRem As Label
    Friend WithEvents LProgServ As Label
    Friend WithEvents BtnServProg As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROG As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tNOTA As TextBox
    Friend WithEvents tLUGAR_REP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents L3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents L4 As Label
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tCVE_TIPO As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents C1DateEdit1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RadLLantas As RadioButton
    Friend WithEvents RadRescateCarr As RadioButton
    Friend WithEvents radSinistro As RadioButton
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents RadCorrectivo As RadioButton
    Friend WithEvents RadPreventivo As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents tCVE_ORD As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents F1 As C1.Win.C1Input.C1DateEdit
    Friend WithEvents tResponsable As TextBox
    Friend WithEvents Label16 As Label
End Class
