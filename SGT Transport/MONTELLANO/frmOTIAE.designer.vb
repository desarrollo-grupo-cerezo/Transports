<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOTIAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOTIAE))
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.LkEnlazarDoc = New C1.Win.C1Command.C1CommandLink()
        Me.BarEnlazarDoc = New C1.Win.C1Command.C1Command()
        Me.LkEnlazarProgSer = New C1.Win.C1Command.C1CommandLink()
        Me.BarEnlazarProgSer = New C1.Win.C1Command.C1Command()
        Me.LkFinOT = New C1.Win.C1Command.C1CommandLink()
        Me.BarFinOT = New C1.Win.C1Command.C1Command()
        Me.LkRemisionar = New C1.Win.C1Command.C1CommandLink()
        Me.BarRemisionar = New C1.Win.C1Command.C1Command()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.LkKardex = New C1.Win.C1Command.C1CommandLink()
        Me.BarKardex = New C1.Win.C1Command.C1Command()
        Me.LkReimpresion = New C1.Win.C1Command.C1CommandLink()
        Me.BarReimpresion = New C1.Win.C1Command.C1Command()
        Me.LkCancPartNoEntr = New C1.Win.C1Command.C1CommandLink()
        Me.BarCancPartNoEntr = New C1.Win.C1Command.C1Command()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tResponsable = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LtAlm = New System.Windows.Forms.Label()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.LProgServ = New System.Windows.Forms.Label()
        Me.tNOTA = New System.Windows.Forms.TextBox()
        Me.tLUGAR_REP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tCVE_PROG = New System.Windows.Forms.TextBox()
        Me.L3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.L4 = New System.Windows.Forms.Label()
        Me.btnTipo = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.tEstatus = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tCVE_TIPO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadLLantas = New System.Windows.Forms.RadioButton()
        Me.RadRescateCarr = New System.Windows.Forms.RadioButton()
        Me.radSinistro = New System.Windows.Forms.RadioButton()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radCorrectivo = New System.Windows.Forms.RadioButton()
        Me.radPreventivo = New System.Windows.Forms.RadioButton()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.tCVE_ORD = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.TabProductos = New C1.Win.C1Command.C1DockingTabPage()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.LtPar = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.LtPiezas = New System.Windows.Forms.Label()
        Me.LtDocAnt = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabServicios = New C1.Win.C1Command.C1DockingTabPage()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.FgS = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnAltaServicio = New C1.Win.C1Input.C1Button()
        Me.btnEliSer = New C1.Win.C1Input.C1Button()
        Me.TabDocDigitales = New C1.Win.C1Command.C1DockingTabPage()
        Me.btnBuscaDoc = New System.Windows.Forms.Button()
        Me.LtFotoDoc = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.tDescrFotDoc = New System.Windows.Forms.TextBox()
        Me.FgD = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnFotDocE = New C1.Win.C1Input.C1Button()
        Me.btnFotDocA = New C1.Win.C1Input.C1Button()
        Me.TabObser = New C1.Win.C1Command.C1DockingTabPage()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.tBotonMagico = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnEliProd = New C1.Win.C1Input.C1Button()
        Me.btnAltaProducto = New C1.Win.C1Input.C1Button()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.TabProductos.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabServicios.SuspendLayout()
        CType(Me.FgS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocDigitales.SuspendLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabObser.SuspendLayout()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.C1ToolBar1.ButtonWidth = 124
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkEnlazarDoc, Me.LkEnlazarProgSer, Me.LkFinOT, Me.LkRemisionar, Me.LkEliminar, Me.LkKardex, Me.LkReimpresion, Me.LkCancPartNoEntr, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 28
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1369, 60)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "(default)")
        Me.C1ToolBar1.Wrap = True
        Me.C1ToolBar1.WrapText = True
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.OwnerDraw = True
        Me.LkGrabar.Text = "Grabar"
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
        'LkEnlazarDoc
        '
        Me.LkEnlazarDoc.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEnlazarDoc.Command = Me.BarEnlazarDoc
        Me.LkEnlazarDoc.SortOrder = 1
        Me.LkEnlazarDoc.Text = "Enlazar rep. de fallas"
        '
        'BarEnlazarDoc
        '
        Me.BarEnlazarDoc.Image = Global.SGT_Transport.My.Resources.Resources.doc17
        Me.BarEnlazarDoc.Name = "BarEnlazarDoc"
        Me.BarEnlazarDoc.ShortcutText = ""
        Me.BarEnlazarDoc.Text = "Enlazar rep. fallas"
        '
        'LkEnlazarProgSer
        '
        Me.LkEnlazarProgSer.Command = Me.BarEnlazarProgSer
        Me.LkEnlazarProgSer.SortOrder = 2
        Me.LkEnlazarProgSer.Text = "Enlazar prog.  servicios"
        '
        'BarEnlazarProgSer
        '
        Me.BarEnlazarProgSer.Image = Global.SGT_Transport.My.Resources.Resources.P13
        Me.BarEnlazarProgSer.Name = "BarEnlazarProgSer"
        Me.BarEnlazarProgSer.ShortcutText = ""
        Me.BarEnlazarProgSer.Text = "Enlazar prog. servicios"
        '
        'LkFinOT
        '
        Me.LkFinOT.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFinOT.Command = Me.BarFinOT
        Me.LkFinOT.SortOrder = 3
        Me.LkFinOT.Text = "Generar movs. al inventario"
        '
        'BarFinOT
        '
        Me.BarFinOT.Image = Global.SGT_Transport.My.Resources.Resources.docu7
        Me.BarFinOT.Name = "BarFinOT"
        Me.BarFinOT.ShortcutText = ""
        Me.BarFinOT.ShowShortcut = False
        Me.BarFinOT.ShowTextAsToolTip = False
        Me.BarFinOT.Text = "Generar movs. al inventario"
        '
        'LkRemisionar
        '
        Me.LkRemisionar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkRemisionar.Command = Me.BarRemisionar
        Me.LkRemisionar.SortOrder = 4
        Me.LkRemisionar.Text = " Remisionar"
        '
        'BarRemisionar
        '
        Me.BarRemisionar.Image = Global.SGT_Transport.My.Resources.Resources.LETRA_R4
        Me.BarRemisionar.Name = "BarRemisionar"
        Me.BarRemisionar.ShortcutText = ""
        Me.BarRemisionar.Text = "Remisionar"
        '
        'LkEliminar
        '
        Me.LkEliminar.Command = Me.BarEliminar
        Me.LkEliminar.SortOrder = 5
        Me.LkEliminar.Text = "Cancelar OT"
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.C1
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutText = ""
        Me.BarEliminar.Text = "Cancelar OT"
        '
        'LkKardex
        '
        Me.LkKardex.Command = Me.BarKardex
        Me.LkKardex.SortOrder = 6
        Me.LkKardex.Text = "Kardex"
        '
        'BarKardex
        '
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.ShortcutText = ""
        Me.BarKardex.Text = "Kardex"
        '
        'LkReimpresion
        '
        Me.LkReimpresion.Command = Me.BarReimpresion
        Me.LkReimpresion.SortOrder = 7
        Me.LkReimpresion.Text = " Reimpresión"
        '
        'BarReimpresion
        '
        Me.BarReimpresion.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarReimpresion.Name = "BarReimpresion"
        Me.BarReimpresion.ShortcutText = ""
        Me.BarReimpresion.Text = "Reimpresión"
        '
        'LkCancPartNoEntr
        '
        Me.LkCancPartNoEntr.Command = Me.BarCancPartNoEntr
        Me.LkCancPartNoEntr.SortOrder = 8
        Me.LkCancPartNoEntr.Text = "Cancelar part. no entregadas"
        '
        'BarCancPartNoEntr
        '
        Me.BarCancPartNoEntr.Image = Global.SGT_Transport.My.Resources.Resources.c6
        Me.BarCancPartNoEntr.Name = "BarCancPartNoEntr"
        Me.BarCancPartNoEntr.ShortcutText = ""
        Me.BarCancPartNoEntr.Text = "Cancelar part. no entregadas"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.SortOrder = 9
        Me.LkExcel.Text = " Excel"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel "
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.SortOrder = 10
        Me.LkSalir.Text = " Salir"
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
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarEnlazarDoc)
        Me.MenuHolder.Commands.Add(Me.BarEnlazarProgSer)
        Me.MenuHolder.Commands.Add(Me.BarFinOT)
        Me.MenuHolder.Commands.Add(Me.BarRemisionar)
        Me.MenuHolder.Commands.Add(Me.BarEliminar)
        Me.MenuHolder.Commands.Add(Me.BarKardex)
        Me.MenuHolder.Commands.Add(Me.BarReimpresion)
        Me.MenuHolder.Commands.Add(Me.BarCancPartNoEntr)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'C1ThemeController1
        '
        Me.C1ThemeController1.Theme = "MacBlue"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.tResponsable)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.LtAlm)
        Me.Panel2.Controls.Add(Me.cboAlmacen)
        Me.Panel2.Controls.Add(Me.LProgServ)
        Me.Panel2.Controls.Add(Me.tNOTA)
        Me.Panel2.Controls.Add(Me.tLUGAR_REP)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.tCVE_PROG)
        Me.Panel2.Controls.Add(Me.L3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnProv)
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.btnTipo)
        Me.Panel2.Controls.Add(Me.tCVE_PROV)
        Me.Panel2.Controls.Add(Me.tEstatus)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tCVE_TIPO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.btnUnidades)
        Me.Panel2.Controls.Add(Me.tCVE_UNI)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(338, 62)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(753, 152)
        Me.Panel2.TabIndex = 146
        Me.C1ThemeController1.SetTheme(Me.Panel2, "(default)")
        '
        'tResponsable
        '
        Me.tResponsable.AcceptsReturn = True
        Me.tResponsable.AcceptsTab = True
        Me.tResponsable.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tResponsable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tResponsable.Location = New System.Drawing.Point(91, 78)
        Me.tResponsable.MaxLength = 50
        Me.tResponsable.Name = "tResponsable"
        Me.tResponsable.Size = New System.Drawing.Size(382, 21)
        Me.tResponsable.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tResponsable, "(default)")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(6, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 15)
        Me.Label15.TabIndex = 154
        Me.Label15.Text = "Responsable"
        Me.C1ThemeController1.SetTheme(Me.Label15, "(default)")
        '
        'LtAlm
        '
        Me.LtAlm.AutoSize = True
        Me.LtAlm.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtAlm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAlm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtAlm.Location = New System.Drawing.Point(476, 128)
        Me.LtAlm.Name = "LtAlm"
        Me.LtAlm.Size = New System.Drawing.Size(55, 15)
        Me.LtAlm.TabIndex = 152
        Me.LtAlm.Text = "Almacen"
        Me.C1ThemeController1.SetTheme(Me.LtAlm, "(default)")
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(537, 126)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(200, 18)
        Me.cboAlmacen.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboAlmacen.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboAlmacen.TabIndex = 6
        Me.cboAlmacen.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboAlmacen, "(default)")
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LProgServ
        '
        Me.LProgServ.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LProgServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LProgServ.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LProgServ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LProgServ.Location = New System.Drawing.Point(408, 102)
        Me.LProgServ.Name = "LProgServ"
        Me.LProgServ.Size = New System.Drawing.Size(65, 22)
        Me.LProgServ.TabIndex = 150
        Me.LProgServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LProgServ, "(default)")
        '
        'tNOTA
        '
        Me.tNOTA.AcceptsReturn = True
        Me.tNOTA.AcceptsTab = True
        Me.tNOTA.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOTA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tNOTA.Location = New System.Drawing.Point(106, 102)
        Me.tNOTA.MaxLength = 100
        Me.tNOTA.Name = "tNOTA"
        Me.tNOTA.Size = New System.Drawing.Size(161, 21)
        Me.tNOTA.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tNOTA, "(default)")
        '
        'tLUGAR_REP
        '
        Me.tLUGAR_REP.AcceptsReturn = True
        Me.tLUGAR_REP.AcceptsTab = True
        Me.tLUGAR_REP.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLUGAR_REP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tLUGAR_REP.Location = New System.Drawing.Point(106, 125)
        Me.tLUGAR_REP.MaxLength = 50
        Me.tLUGAR_REP.Name = "tLUGAR_REP"
        Me.tLUGAR_REP.Size = New System.Drawing.Size(367, 21)
        Me.tLUGAR_REP.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tLUGAR_REP, "(default)")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(42, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "Odómetro"
        Me.C1ThemeController1.SetTheme(Me.Label10, "(default)")
        '
        'tCVE_PROG
        '
        Me.tCVE_PROG.AcceptsReturn = True
        Me.tCVE_PROG.AcceptsTab = True
        Me.tCVE_PROG.Enabled = False
        Me.tCVE_PROG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_PROG.Location = New System.Drawing.Point(354, 101)
        Me.tCVE_PROG.MaxLength = 10
        Me.tCVE_PROG.Name = "tCVE_PROG"
        Me.tCVE_PROG.ReadOnly = True
        Me.tCVE_PROG.Size = New System.Drawing.Size(46, 22)
        Me.tCVE_PROG.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROG, "(default)")
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L3.Location = New System.Drawing.Point(215, 53)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(258, 22)
        Me.L3.TabIndex = 133
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L3, "(default)")
        Me.L3.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(273, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Prog. servicio"
        Me.C1ThemeController1.SetTheme(Me.Label6, "(default)")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(3, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 15)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Lugar reparacion"
        Me.C1ThemeController1.SetTheme(Me.Label12, "(default)")
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(187, 53)
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
        Me.L4.Location = New System.Drawing.Point(215, 28)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(258, 22)
        Me.L4.TabIndex = 140
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L4, "(default)")
        '
        'btnTipo
        '
        Me.btnTipo.Image = CType(resources.GetObject("btnTipo.Image"), System.Drawing.Image)
        Me.btnTipo.Location = New System.Drawing.Point(187, 28)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.Size = New System.Drawing.Size(26, 20)
        Me.btnTipo.TabIndex = 139
        Me.C1ThemeController1.SetTheme(Me.btnTipo, "(default)")
        Me.btnTipo.UseVisualStyleBackColor = True
        Me.btnTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_PROV.Location = New System.Drawing.Point(91, 53)
        Me.tCVE_PROV.MaxLength = 10
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_PROV.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROV, "(default)")
        Me.tCVE_PROV.Visible = False
        '
        'tEstatus
        '
        Me.tEstatus.AcceptsReturn = True
        Me.tEstatus.AcceptsTab = True
        Me.tEstatus.Enabled = False
        Me.tEstatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tEstatus.Location = New System.Drawing.Point(518, 26)
        Me.tEstatus.Name = "tEstatus"
        Me.tEstatus.Size = New System.Drawing.Size(187, 22)
        Me.tEstatus.TabIndex = 2
        Me.tEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.tEstatus, "(default)")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(585, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 15)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Estatus"
        Me.C1ThemeController1.SetTheme(Me.Label11, "(default)")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(40, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Cliente"
        Me.C1ThemeController1.SetTheme(Me.Label5, "(default)")
        Me.Label5.Visible = False
        '
        'tCVE_TIPO
        '
        Me.tCVE_TIPO.AcceptsReturn = True
        Me.tCVE_TIPO.AcceptsTab = True
        Me.tCVE_TIPO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TIPO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_TIPO.Location = New System.Drawing.Point(91, 28)
        Me.tCVE_TIPO.Name = "tCVE_TIPO"
        Me.tCVE_TIPO.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_TIPO.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_TIPO, "(default)")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(54, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Tipo"
        Me.C1ThemeController1.SetTheme(Me.Label9, "(default)")
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L2.Location = New System.Drawing.Point(215, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(258, 22)
        Me.L2.TabIndex = 131
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L2, "(default)")
        '
        'btnUnidades
        '
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(187, 3)
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
        Me.tCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_UNI.Location = New System.Drawing.Point(91, 3)
        Me.tCVE_UNI.MaxLength = 10
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_UNI.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "(default)")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(38, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Unidad"
        Me.C1ThemeController1.SetTheme(Me.Label4, "(default)")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadLLantas)
        Me.Panel1.Controls.Add(Me.RadRescateCarr)
        Me.Panel1.Controls.Add(Me.radSinistro)
        Me.Panel1.Controls.Add(Me.radExtra)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.radCorrectivo)
        Me.Panel1.Controls.Add(Me.radPreventivo)
        Me.Panel1.Controls.Add(Me.Label90)
        Me.Panel1.Controls.Add(Me.tCVE_ORD)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(2, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 152)
        Me.Panel1.TabIndex = 145
        Me.C1ThemeController1.SetTheme(Me.Panel1, "(default)")
        '
        'RadLLantas
        '
        Me.RadLLantas.AutoSize = True
        Me.RadLLantas.BackColor = System.Drawing.Color.Transparent
        Me.RadLLantas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadLLantas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadLLantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLLantas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadLLantas.Location = New System.Drawing.Point(230, 104)
        Me.RadLLantas.Name = "RadLLantas"
        Me.RadLLantas.Size = New System.Drawing.Size(65, 19)
        Me.RadLLantas.TabIndex = 6
        Me.RadLLantas.TabStop = True
        Me.RadLLantas.Text = "Llantas"
        Me.C1ThemeController1.SetTheme(Me.RadLLantas, "(default)")
        Me.RadLLantas.UseVisualStyleBackColor = False
        '
        'RadRescateCarr
        '
        Me.RadRescateCarr.AutoSize = True
        Me.RadRescateCarr.BackColor = System.Drawing.Color.Transparent
        Me.RadRescateCarr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.RadRescateCarr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.RadRescateCarr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadRescateCarr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.RadRescateCarr.Location = New System.Drawing.Point(97, 104)
        Me.RadRescateCarr.Name = "RadRescateCarr"
        Me.RadRescateCarr.Size = New System.Drawing.Size(122, 19)
        Me.RadRescateCarr.TabIndex = 5
        Me.RadRescateCarr.TabStop = True
        Me.RadRescateCarr.Text = "Rescate carretero"
        Me.C1ThemeController1.SetTheme(Me.RadRescateCarr, "(default)")
        Me.RadRescateCarr.UseVisualStyleBackColor = False
        '
        'radSinistro
        '
        Me.radSinistro.AutoSize = True
        Me.radSinistro.BackColor = System.Drawing.Color.Transparent
        Me.radSinistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radSinistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radSinistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSinistro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radSinistro.Location = New System.Drawing.Point(8, 104)
        Me.radSinistro.Name = "radSinistro"
        Me.radSinistro.Size = New System.Drawing.Size(73, 19)
        Me.radSinistro.TabIndex = 4
        Me.radSinistro.TabStop = True
        Me.radSinistro.Text = "Siniestro"
        Me.C1ThemeController1.SetTheme(Me.radSinistro, "(default)")
        Me.radSinistro.UseVisualStyleBackColor = False
        '
        'radExtra
        '
        Me.radExtra.AutoSize = True
        Me.radExtra.BackColor = System.Drawing.Color.Transparent
        Me.radExtra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radExtra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radExtra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radExtra.Location = New System.Drawing.Point(230, 77)
        Me.radExtra.Name = "radExtra"
        Me.radExtra.Size = New System.Drawing.Size(102, 19)
        Me.radExtra.TabIndex = 3
        Me.radExtra.TabStop = True
        Me.radExtra.Text = "Extraordinario"
        Me.C1ThemeController1.SetTheme(Me.radExtra, "(default)")
        Me.radExtra.UseVisualStyleBackColor = False
        '
        'F1
        '
        Me.F1.BackColor = System.Drawing.Color.White
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(173, 13)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(147, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "(default)")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 22)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Tipo de servicio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label1, "(default)")
        '
        'radCorrectivo
        '
        Me.radCorrectivo.AutoSize = True
        Me.radCorrectivo.BackColor = System.Drawing.Color.Transparent
        Me.radCorrectivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radCorrectivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radCorrectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCorrectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radCorrectivo.Location = New System.Drawing.Point(98, 77)
        Me.radCorrectivo.Name = "radCorrectivo"
        Me.radCorrectivo.Size = New System.Drawing.Size(79, 19)
        Me.radCorrectivo.TabIndex = 2
        Me.radCorrectivo.TabStop = True
        Me.radCorrectivo.Text = "Correctivo"
        Me.C1ThemeController1.SetTheme(Me.radCorrectivo, "(default)")
        Me.radCorrectivo.UseVisualStyleBackColor = False
        '
        'radPreventivo
        '
        Me.radPreventivo.AutoSize = True
        Me.radPreventivo.BackColor = System.Drawing.Color.Transparent
        Me.radPreventivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.radPreventivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.radPreventivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPreventivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.radPreventivo.Location = New System.Drawing.Point(8, 77)
        Me.radPreventivo.Name = "radPreventivo"
        Me.radPreventivo.Size = New System.Drawing.Size(81, 19)
        Me.radPreventivo.TabIndex = 1
        Me.radPreventivo.TabStop = True
        Me.radPreventivo.Text = "Preventivo"
        Me.C1ThemeController1.SetTheme(Me.radPreventivo, "(default)")
        Me.radPreventivo.UseVisualStyleBackColor = False
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label90.Location = New System.Drawing.Point(126, 16)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(41, 15)
        Me.Label90.TabIndex = 153
        Me.Label90.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label90, "(default)")
        '
        'tCVE_ORD
        '
        Me.tCVE_ORD.AcceptsReturn = True
        Me.tCVE_ORD.AcceptsTab = True
        Me.tCVE_ORD.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tCVE_ORD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.tCVE_ORD.Location = New System.Drawing.Point(44, 12)
        Me.tCVE_ORD.Name = "tCVE_ORD"
        Me.tCVE_ORD.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_ORD.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_ORD, "(default)")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(10, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 15)
        Me.Label27.TabIndex = 149
        Me.Label27.Text = "Folio"
        Me.C1ThemeController1.SetTheme(Me.Label27, "(default)")
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.TabProductos)
        Me.Tab1.Controls.Add(Me.TabServicios)
        Me.Tab1.Controls.Add(Me.TabDocDigitales)
        Me.Tab1.Controls.Add(Me.TabObser)
        Me.Tab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(0, 217)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(1185, 330)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1ThemeController1.SetTheme(Me.Tab1, "(default)")
        '
        'TabProductos
        '
        Me.TabProductos.Controls.Add(Me.Lt4)
        Me.TabProductos.Controls.Add(Me.LtPar)
        Me.TabProductos.Controls.Add(Me.Lt3)
        Me.TabProductos.Controls.Add(Me.LtPiezas)
        Me.TabProductos.Controls.Add(Me.LtDocAnt)
        Me.TabProductos.Controls.Add(Me.Label7)
        Me.TabProductos.Controls.Add(Me.Lt1)
        Me.TabProductos.Controls.Add(Me.L1)
        Me.TabProductos.Controls.Add(Me.Fg)
        Me.TabProductos.Location = New System.Drawing.Point(1, 25)
        Me.TabProductos.Name = "TabProductos"
        Me.TabProductos.Size = New System.Drawing.Size(1183, 304)
        Me.TabProductos.TabIndex = 0
        Me.TabProductos.Text = "Productos"
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Lt4.Location = New System.Drawing.Point(316, 274)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(81, 15)
        Me.Lt4.TabIndex = 144
        Me.Lt4.Text = "Total partidas"
        Me.C1ThemeController1.SetTheme(Me.Lt4, "(default)")
        '
        'LtPar
        '
        Me.LtPar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtPar.Location = New System.Drawing.Point(401, 271)
        Me.LtPar.Name = "LtPar"
        Me.LtPar.Size = New System.Drawing.Size(51, 22)
        Me.LtPar.TabIndex = 143
        Me.LtPar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtPar, "(default)")
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Lt3.Location = New System.Drawing.Point(478, 274)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(73, 15)
        Me.Lt3.TabIndex = 142
        Me.Lt3.Text = "Total piezas"
        Me.C1ThemeController1.SetTheme(Me.Lt3, "(default)")
        '
        'LtPiezas
        '
        Me.LtPiezas.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtPiezas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPiezas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtPiezas.Location = New System.Drawing.Point(553, 271)
        Me.LtPiezas.Name = "LtPiezas"
        Me.LtPiezas.Size = New System.Drawing.Size(111, 22)
        Me.LtPiezas.TabIndex = 141
        Me.LtPiezas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtPiezas, "(default)")
        '
        'LtDocAnt
        '
        Me.LtDocAnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LtDocAnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDocAnt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocAnt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.LtDocAnt.Location = New System.Drawing.Point(104, 271)
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
        Me.Label7.Location = New System.Drawing.Point(12, 274)
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
        Me.Lt1.Location = New System.Drawing.Point(967, 271)
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
        Me.L1.Location = New System.Drawing.Point(912, 274)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(49, 15)
        Me.L1.TabIndex = 134
        Me.L1.Text = "Importe"
        Me.C1ThemeController1.SetTheme(Me.L1, "(default)")
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
        Me.Fg.Location = New System.Drawing.Point(4, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1160, 261)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.Fg, "(default)")
        '
        'TabServicios
        '
        Me.TabServicios.Controls.Add(Me.Lt5)
        Me.TabServicios.Controls.Add(Me.L5)
        Me.TabServicios.Controls.Add(Me.FgS)
        Me.TabServicios.Controls.Add(Me.btnAltaServicio)
        Me.TabServicios.Controls.Add(Me.btnEliSer)
        Me.TabServicios.Location = New System.Drawing.Point(1, 25)
        Me.TabServicios.Name = "TabServicios"
        Me.TabServicios.Size = New System.Drawing.Size(1183, 304)
        Me.TabServicios.TabIndex = 0
        Me.TabServicios.Text = "Servicios"
        '
        'Lt5
        '
        Me.Lt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Lt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Lt5.Location = New System.Drawing.Point(969, 274)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(164, 22)
        Me.Lt5.TabIndex = 140
        Me.Lt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Lt5, "(default)")
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.L5.Location = New System.Drawing.Point(914, 277)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(49, 15)
        Me.L5.TabIndex = 139
        Me.L5.Text = "Importe"
        Me.C1ThemeController1.SetTheme(Me.L5, "(default)")
        '
        'FgS
        '
        Me.FgS.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgS.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.FgS.BackColor = System.Drawing.Color.White
        Me.FgS.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgS.ColumnInfo = resources.GetString("FgS.ColumnInfo")
        Me.FgS.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.FgS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.FgS.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgS.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgS.Location = New System.Drawing.Point(6, 40)
        Me.FgS.Name = "FgS"
        Me.FgS.PreserveEditMode = True
        Me.FgS.Rows.Count = 2
        Me.FgS.Rows.DefaultSize = 21
        Me.FgS.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgS.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgS.ShowCellLabels = True
        Me.FgS.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgS.Size = New System.Drawing.Size(1127, 221)
        Me.FgS.StyleInfo = resources.GetString("FgS.StyleInfo")
        Me.FgS.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.FgS, "(default)")
        '
        'btnAltaServicio
        '
        Me.btnAltaServicio.Image = CType(resources.GetObject("btnAltaServicio.Image"), System.Drawing.Image)
        Me.btnAltaServicio.Location = New System.Drawing.Point(921, 4)
        Me.btnAltaServicio.Name = "btnAltaServicio"
        Me.btnAltaServicio.Size = New System.Drawing.Size(27, 30)
        Me.btnAltaServicio.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.btnAltaServicio, "(default)")
        Me.btnAltaServicio.UseVisualStyleBackColor = True
        Me.btnAltaServicio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliSer
        '
        Me.btnEliSer.Image = CType(resources.GetObject("btnEliSer.Image"), System.Drawing.Image)
        Me.btnEliSer.Location = New System.Drawing.Point(967, 7)
        Me.btnEliSer.Name = "btnEliSer"
        Me.btnEliSer.Size = New System.Drawing.Size(35, 27)
        Me.btnEliSer.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.btnEliSer, "(default)")
        Me.btnEliSer.UseVisualStyleBackColor = True
        Me.btnEliSer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TabDocDigitales
        '
        Me.TabDocDigitales.Controls.Add(Me.btnBuscaDoc)
        Me.TabDocDigitales.Controls.Add(Me.LtFotoDoc)
        Me.TabDocDigitales.Controls.Add(Me.Label8)
        Me.TabDocDigitales.Controls.Add(Me.Label78)
        Me.TabDocDigitales.Controls.Add(Me.tDescrFotDoc)
        Me.TabDocDigitales.Controls.Add(Me.FgD)
        Me.TabDocDigitales.Controls.Add(Me.btnFotDocE)
        Me.TabDocDigitales.Controls.Add(Me.btnFotDocA)
        Me.TabDocDigitales.Location = New System.Drawing.Point(1, 25)
        Me.TabDocDigitales.Name = "TabDocDigitales"
        Me.TabDocDigitales.Size = New System.Drawing.Size(1183, 304)
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
        Me.btnBuscaDoc.Location = New System.Drawing.Point(550, 30)
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
        Me.LtFotoDoc.Location = New System.Drawing.Point(83, 32)
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
        Me.Label8.Location = New System.Drawing.Point(8, 35)
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
        Me.Label78.Location = New System.Drawing.Point(9, 65)
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
        Me.tDescrFotDoc.Location = New System.Drawing.Point(83, 62)
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
        Me.FgD.Location = New System.Drawing.Point(8, 100)
        Me.FgD.Name = "FgD"
        Me.FgD.Rows.DefaultSize = 19
        Me.FgD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgD.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgD.Size = New System.Drawing.Size(839, 152)
        Me.FgD.StyleInfo = resources.GetString("FgD.StyleInfo")
        Me.FgD.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.FgD, "(default)")
        '
        'btnFotDocE
        '
        Me.btnFotDocE.Image = CType(resources.GetObject("btnFotDocE.Image"), System.Drawing.Image)
        Me.btnFotDocE.Location = New System.Drawing.Point(797, 31)
        Me.btnFotDocE.Name = "btnFotDocE"
        Me.btnFotDocE.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocE.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.btnFotDocE, "(default)")
        Me.btnFotDocE.UseVisualStyleBackColor = True
        Me.btnFotDocE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnFotDocA
        '
        Me.btnFotDocA.Image = CType(resources.GetObject("btnFotDocA.Image"), System.Drawing.Image)
        Me.btnFotDocA.Location = New System.Drawing.Point(743, 31)
        Me.btnFotDocA.Name = "btnFotDocA"
        Me.btnFotDocA.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocA.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.btnFotDocA, "(default)")
        Me.btnFotDocA.UseVisualStyleBackColor = True
        Me.btnFotDocA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TabObser
        '
        Me.TabObser.Controls.Add(Me.tOBSER)
        Me.TabObser.Location = New System.Drawing.Point(1, 25)
        Me.TabObser.Name = "TabObser"
        Me.TabObser.Size = New System.Drawing.Size(1183, 304)
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
        Me.tBotonMagico.Location = New System.Drawing.Point(972, 141)
        Me.tBotonMagico.Name = "tBotonMagico"
        Me.tBotonMagico.Size = New System.Drawing.Size(53, 22)
        Me.tBotonMagico.TabIndex = 152
        Me.C1ThemeController1.SetTheme(Me.tBotonMagico, "(default)")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(743, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 308
        Me.Label2.Text = "Almacen"
        Me.C1ThemeController1.SetTheme(Me.Label2, "(default)")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(743, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Almacen"
        Me.C1ThemeController1.SetTheme(Me.Label3, "(default)")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(743, 198)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 15)
        Me.Label13.TabIndex = 308
        Me.Label13.Text = "Almacen"
        Me.C1ThemeController1.SetTheme(Me.Label13, "(default)")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(743, 198)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 15)
        Me.Label14.TabIndex = 308
        Me.Label14.Text = "Almacen"
        Me.C1ThemeController1.SetTheme(Me.Label14, "(default)")
        '
        'btnEliProd
        '
        Me.btnEliProd.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.btnEliProd.Location = New System.Drawing.Point(1146, 201)
        Me.btnEliProd.Name = "btnEliProd"
        Me.btnEliProd.Size = New System.Drawing.Size(35, 33)
        Me.btnEliProd.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.btnEliProd, "(default)")
        Me.btnEliProd.UseVisualStyleBackColor = True
        Me.btnEliProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnAltaProducto
        '
        Me.btnAltaProducto.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaProducto.Location = New System.Drawing.Point(1097, 201)
        Me.btnAltaProducto.Name = "btnAltaProducto"
        Me.btnAltaProducto.Size = New System.Drawing.Size(35, 35)
        Me.btnAltaProducto.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.btnAltaProducto, "(default)")
        Me.btnAltaProducto.UseVisualStyleBackColor = True
        Me.btnAltaProducto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "778d1ba5f0404b5f84c84c5eb62ed020"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmOTIAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1369, 558)
        Me.Controls.Add(Me.btnEliProd)
        Me.Controls.Add(Me.btnAltaProducto)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.tBotonMagico)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOTIAE"
        Me.Text = "Orden de trabajo interna"
        Me.C1ThemeController1.SetTheme(Me, "(default)")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.TabProductos.ResumeLayout(False)
        Me.TabProductos.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabServicios.ResumeLayout(False)
        Me.TabServicios.PerformLayout()
        CType(Me.FgS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocDigitales.ResumeLayout(False)
        Me.TabDocDigitales.PerformLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabObser.ResumeLayout(False)
        Me.TabObser.PerformLayout()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEnlazarDoc As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFinOT As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkRemisionar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarFinOT As C1.Win.C1Command.C1Command
    Private WithEvents BarRemisionar As C1.Win.C1Command.C1Command
    Private WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Private WithEvents BarExcel As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Private WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LProgServ As Label
    Friend WithEvents tCVE_PROG As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tNOTA As TextBox
    Friend WithEvents tLUGAR_REP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents L3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents L4 As Label
    Friend WithEvents btnTipo As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents tEstatus As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tCVE_TIPO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RadLLantas As RadioButton
    Friend WithEvents RadRescateCarr As RadioButton
    Friend WithEvents radSinistro As RadioButton
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents radCorrectivo As RadioButton
    Friend WithEvents radPreventivo As RadioButton
    Friend WithEvents Label90 As Label
    Friend WithEvents tCVE_ORD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents TabProductos As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Lt4 As Label
    Friend WithEvents LtPar As Label
    Friend WithEvents Lt3 As Label
    Friend WithEvents LtPiezas As Label
    Friend WithEvents LtDocAnt As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TabServicios As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Lt5 As Label
    Friend WithEvents L5 As Label
    Friend WithEvents FgS As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnAltaServicio As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliSer As C1.Win.C1Input.C1Button
    Friend WithEvents TabDocDigitales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents btnBuscaDoc As Button
    Friend WithEvents LtFotoDoc As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents tDescrFotDoc As TextBox
    Friend WithEvents FgD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnFotDocE As C1.Win.C1Input.C1Button
    Friend WithEvents btnFotDocA As C1.Win.C1Input.C1Button
    Friend WithEvents TabObser As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents tBotonMagico As TextBox
    Friend WithEvents btnEliProd As C1.Win.C1Input.C1Button
    Friend WithEvents btnAltaProducto As C1.Win.C1Input.C1Button
    Friend WithEvents LkReimpresión As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkKardex As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancPartNoEntr As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkReimpresion As C1.Win.C1Command.C1CommandLink
    Private WithEvents BarKardex As C1.Win.C1Command.C1Command
    Private WithEvents BarReimpresion As C1.Win.C1Command.C1Command
    Private WithEvents BarCancPartNoEntr As C1.Win.C1Command.C1Command
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LtAlm As Label
    Friend WithEvents LkEnlazarProgSer As C1.Win.C1Command.C1CommandLink
    Private WithEvents BarEnlazarProgSer As C1.Win.C1Command.C1Command
    Private WithEvents BarEnlazarDoc As C1.Win.C1Command.C1Command
    Friend WithEvents tResponsable As TextBox
    Friend WithEvents Label15 As Label
End Class
