﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCasetasXRutaAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCasetasXRutaAE))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtPlaza2 = New System.Windows.Forms.Label()
        Me.BtnPlaza = New System.Windows.Forms.Button()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.tCVE_PLAZA = New System.Windows.Forms.TextBox()
        Me.BtnPlaza2 = New System.Windows.Forms.Button()
        Me.tCVE_PLAZA2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.TCVE_CXR = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboEjesTotal = New C1.Win.C1Input.C1ComboBox()
        Me.txDescripcion = New System.Windows.Forms.TextBox()
        Me.rbFull = New System.Windows.Forms.RadioButton()
        Me.rbSencillo = New System.Windows.Forms.RadioButton()
        Me.rbTractor = New System.Windows.Forms.RadioButton()
        Me.BtnRuta = New System.Windows.Forms.Button()
        Me.txRuta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TTIPO_RUTA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TIAVE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCLAVE_REM = New System.Windows.Forms.Button()
        Me.tCLAVE_O = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LtNombre1 = New System.Windows.Forms.Label()
        Me.LtImporte = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnAgregarCaseta = New C1.Win.C1Input.C1Button()
        Me.BtnRecargarCasetas = New C1.Win.C1Input.C1Button()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.barMenu.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.cboEjesTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAgregarCaseta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRecargarCasetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.BarExcel, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1452, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 11
        Me.barMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barMenu, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtPlaza2
        '
        Me.LtPlaza2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza2.Enabled = False
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza2.Location = New System.Drawing.Point(598, 63)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(305, 22)
        Me.LtPlaza2.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.LtPlaza2, "Office2010Blue")
        '
        'BtnPlaza
        '
        Me.BtnPlaza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPlaza.BackColor = System.Drawing.Color.Transparent
        Me.BtnPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnPlaza.Image = CType(resources.GetObject("BtnPlaza.Image"), System.Drawing.Image)
        Me.BtnPlaza.Location = New System.Drawing.Point(1385, 91)
        Me.BtnPlaza.Name = "BtnPlaza"
        Me.BtnPlaza.Size = New System.Drawing.Size(24, 23)
        Me.BtnPlaza.TabIndex = 450
        Me.C1ThemeController1.SetTheme(Me.BtnPlaza, "Office2010Blue")
        Me.BtnPlaza.UseVisualStyleBackColor = True
        Me.BtnPlaza.Visible = False
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Enabled = False
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(145, 64)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(382, 22)
        Me.LtPlaza.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'tCVE_PLAZA
        '
        Me.tCVE_PLAZA.AcceptsReturn = True
        Me.tCVE_PLAZA.AcceptsTab = True
        Me.tCVE_PLAZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA.Location = New System.Drawing.Point(1322, 92)
        Me.tCVE_PLAZA.Name = "tCVE_PLAZA"
        Me.tCVE_PLAZA.Size = New System.Drawing.Size(57, 22)
        Me.tCVE_PLAZA.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA, "Office2010Blue")
        Me.tCVE_PLAZA.Visible = False
        '
        'BtnPlaza2
        '
        Me.BtnPlaza2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPlaza2.BackColor = System.Drawing.Color.Transparent
        Me.BtnPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnPlaza2.Image = CType(resources.GetObject("BtnPlaza2.Image"), System.Drawing.Image)
        Me.BtnPlaza2.Location = New System.Drawing.Point(1385, 117)
        Me.BtnPlaza2.Name = "BtnPlaza2"
        Me.BtnPlaza2.Size = New System.Drawing.Size(24, 23)
        Me.BtnPlaza2.TabIndex = 451
        Me.C1ThemeController1.SetTheme(Me.BtnPlaza2, "Office2010Blue")
        Me.BtnPlaza2.UseVisualStyleBackColor = True
        Me.BtnPlaza2.Visible = False
        '
        'tCVE_PLAZA2
        '
        Me.tCVE_PLAZA2.AcceptsReturn = True
        Me.tCVE_PLAZA2.AcceptsTab = True
        Me.tCVE_PLAZA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA2.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA2.Location = New System.Drawing.Point(1322, 119)
        Me.tCVE_PLAZA2.Name = "tCVE_PLAZA2"
        Me.tCVE_PLAZA2.Size = New System.Drawing.Size(57, 22)
        Me.tCVE_PLAZA2.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA2, "Office2010Blue")
        Me.tCVE_PLAZA2.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(96, 64)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(47, 16)
        Me.Label41.TabIndex = 448
        Me.Label41.Text = "Origen"
        Me.C1ThemeController1.SetTheme(Me.Label41, "Office2010Blue")
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(539, 65)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(53, 16)
        Me.Lt1.TabIndex = 446
        Me.Lt1.Text = "Destino"
        Me.C1ThemeController1.SetTheme(Me.Lt1, "Office2010Blue")
        '
        'TCVE_CXR
        '
        Me.TCVE_CXR.AcceptsReturn = True
        Me.TCVE_CXR.AcceptsTab = True
        Me.TCVE_CXR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CXR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CXR.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CXR.Location = New System.Drawing.Point(145, 11)
        Me.TCVE_CXR.Name = "TCVE_CXR"
        Me.TCVE_CXR.Size = New System.Drawing.Size(57, 22)
        Me.TCVE_CXR.TabIndex = 0
        Me.TCVE_CXR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.TCVE_CXR, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(101, 14)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 445
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(8, 53)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1452, 390)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 15
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboEjesTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txDescripcion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbFull)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbSencillo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbTractor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnRuta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txRuta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TTIPO_RUTA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TIAVE)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnCLAVE_REM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCLAVE_O)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtNombre1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtImporte)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtPlaza2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TCVE_CXR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lt1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPlaza)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtPlaza)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCVE_PLAZA2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCVE_PLAZA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPlaza2)
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1.Panel1, "(default)")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAgregarCaseta)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnRecargarCasetas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg)
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1.Panel2, "(default)")
        Me.SplitContainer1.Size = New System.Drawing.Size(1452, 630)
        Me.SplitContainer1.SplitterDistance = 183
        Me.SplitContainer1.TabIndex = 456
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1, "(default)")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(558, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 468
        Me.Label5.Text = "Ejes"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'cboEjesTotal
        '
        Me.cboEjesTotal.AllowSpinLoop = False
        Me.cboEjesTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboEjesTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboEjesTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboEjesTotal.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboEjesTotal.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboEjesTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEjesTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboEjesTotal.GapHeight = 0
        Me.cboEjesTotal.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboEjesTotal.ItemsDisplayMember = ""
        Me.cboEjesTotal.ItemsValueMember = ""
        Me.cboEjesTotal.Location = New System.Drawing.Point(598, 92)
        Me.cboEjesTotal.Name = "cboEjesTotal"
        Me.cboEjesTotal.Size = New System.Drawing.Size(68, 20)
        Me.cboEjesTotal.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboEjesTotal.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboEjesTotal.TabIndex = 467
        Me.cboEjesTotal.Tag = Nothing
        Me.cboEjesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.cboEjesTotal, "Office2010Blue")
        Me.cboEjesTotal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'txDescripcion
        '
        Me.txDescripcion.AcceptsReturn = True
        Me.txDescripcion.AcceptsTab = True
        Me.txDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txDescripcion.ForeColor = System.Drawing.Color.Black
        Me.txDescripcion.Location = New System.Drawing.Point(238, 38)
        Me.txDescripcion.MaxLength = 150
        Me.txDescripcion.Name = "txDescripcion"
        Me.txDescripcion.Size = New System.Drawing.Size(289, 22)
        Me.txDescripcion.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.txDescripcion, "Office2010Blue")
        '
        'rbFull
        '
        Me.rbFull.AutoSize = True
        Me.rbFull.Location = New System.Drawing.Point(940, 111)
        Me.rbFull.Name = "rbFull"
        Me.rbFull.Size = New System.Drawing.Size(41, 17)
        Me.rbFull.TabIndex = 14
        Me.rbFull.TabStop = True
        Me.rbFull.Text = "Full"
        Me.C1ThemeController1.SetTheme(Me.rbFull, "(default)")
        Me.rbFull.UseVisualStyleBackColor = True
        '
        'rbSencillo
        '
        Me.rbSencillo.AutoSize = True
        Me.rbSencillo.Location = New System.Drawing.Point(940, 87)
        Me.rbSencillo.Name = "rbSencillo"
        Me.rbSencillo.Size = New System.Drawing.Size(62, 17)
        Me.rbSencillo.TabIndex = 13
        Me.rbSencillo.TabStop = True
        Me.rbSencillo.Text = "Sencillo"
        Me.C1ThemeController1.SetTheme(Me.rbSencillo, "(default)")
        Me.rbSencillo.UseVisualStyleBackColor = True
        '
        'rbTractor
        '
        Me.rbTractor.AutoSize = True
        Me.rbTractor.Location = New System.Drawing.Point(940, 63)
        Me.rbTractor.Name = "rbTractor"
        Me.rbTractor.Size = New System.Drawing.Size(59, 17)
        Me.rbTractor.TabIndex = 12
        Me.rbTractor.TabStop = True
        Me.rbTractor.Text = "Tractor"
        Me.C1ThemeController1.SetTheme(Me.rbTractor, "(default)")
        Me.rbTractor.UseVisualStyleBackColor = True
        '
        'BtnRuta
        '
        Me.BtnRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnRuta.BackColor = System.Drawing.Color.Transparent
        Me.BtnRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnRuta.Image = CType(resources.GetObject("BtnRuta.Image"), System.Drawing.Image)
        Me.BtnRuta.Location = New System.Drawing.Point(208, 37)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(24, 23)
        Me.BtnRuta.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.BtnRuta, "Office2010Blue")
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'txRuta
        '
        Me.txRuta.AcceptsReturn = True
        Me.txRuta.AcceptsTab = True
        Me.txRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txRuta.ForeColor = System.Drawing.Color.Black
        Me.txRuta.Location = New System.Drawing.Point(145, 38)
        Me.txRuta.Name = "txRuta"
        Me.txRuta.Size = New System.Drawing.Size(57, 22)
        Me.txRuta.TabIndex = 1
        Me.txRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.txRuta, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(108, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 16)
        Me.Label4.TabIndex = 466
        Me.Label4.Text = "Ruta"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'TTIPO_RUTA
        '
        Me.TTIPO_RUTA.AcceptsReturn = True
        Me.TTIPO_RUTA.AcceptsTab = True
        Me.TTIPO_RUTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RUTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RUTA.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RUTA.Location = New System.Drawing.Point(598, 117)
        Me.TTIPO_RUTA.Name = "TTIPO_RUTA"
        Me.TTIPO_RUTA.Size = New System.Drawing.Size(305, 22)
        Me.TTIPO_RUTA.TabIndex = 10
        Me.C1ThemeController1.SetTheme(Me.TTIPO_RUTA, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(539, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 465
        Me.Label2.Text = "Destino"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'TIAVE
        '
        Me.TIAVE.AcceptsReturn = True
        Me.TIAVE.AcceptsTab = True
        Me.TIAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIAVE.ForeColor = System.Drawing.Color.Black
        Me.TIAVE.Location = New System.Drawing.Point(145, 117)
        Me.TIAVE.Name = "TIAVE"
        Me.TIAVE.Size = New System.Drawing.Size(382, 22)
        Me.TIAVE.TabIndex = 9
        Me.C1ThemeController1.SetTheme(Me.TIAVE, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(96, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 463
        Me.Label1.Text = "Origen"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'BtnCLAVE_REM
        '
        Me.BtnCLAVE_REM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCLAVE_REM.BackColor = System.Drawing.Color.Transparent
        Me.BtnCLAVE_REM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCLAVE_REM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCLAVE_REM.Image = CType(resources.GetObject("BtnCLAVE_REM.Image"), System.Drawing.Image)
        Me.BtnCLAVE_REM.Location = New System.Drawing.Point(208, 89)
        Me.BtnCLAVE_REM.Name = "BtnCLAVE_REM"
        Me.BtnCLAVE_REM.Size = New System.Drawing.Size(24, 23)
        Me.BtnCLAVE_REM.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.BtnCLAVE_REM, "Office2010Blue")
        Me.BtnCLAVE_REM.UseVisualStyleBackColor = True
        '
        'tCLAVE_O
        '
        Me.tCLAVE_O.AcceptsReturn = True
        Me.tCLAVE_O.AcceptsTab = True
        Me.tCLAVE_O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCLAVE_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE_O.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE_O.Location = New System.Drawing.Point(145, 89)
        Me.tCLAVE_O.Name = "tCLAVE_O"
        Me.tCLAVE_O.Size = New System.Drawing.Size(57, 22)
        Me.tCLAVE_O.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.tCLAVE_O, "Office2010Blue")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(35, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 16)
        Me.Label19.TabIndex = 459
        Me.Label19.Text = "Cliente operativo"
        Me.C1ThemeController1.SetTheme(Me.Label19, "Office2010Blue")
        '
        'LtNombre1
        '
        Me.LtNombre1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre1.Location = New System.Drawing.Point(238, 89)
        Me.LtNombre1.Name = "LtNombre1"
        Me.LtNombre1.Size = New System.Drawing.Size(289, 22)
        Me.LtNombre1.TabIndex = 8
        Me.C1ThemeController1.SetTheme(Me.LtNombre1, "Office2010Blue")
        '
        'LtImporte
        '
        Me.LtImporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtImporte.Location = New System.Drawing.Point(751, 90)
        Me.LtImporte.Name = "LtImporte"
        Me.LtImporte.Size = New System.Drawing.Size(152, 22)
        Me.LtImporte.TabIndex = 11
        Me.LtImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtImporte, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(679, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 455
        Me.Label3.Text = "Total ruta"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'BtnAgregarCaseta
        '
        Me.BtnAgregarCaseta.Image = CType(resources.GetObject("BtnAgregarCaseta.Image"), System.Drawing.Image)
        Me.BtnAgregarCaseta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregarCaseta.Location = New System.Drawing.Point(212, 9)
        Me.BtnAgregarCaseta.Name = "BtnAgregarCaseta"
        Me.BtnAgregarCaseta.Size = New System.Drawing.Size(186, 27)
        Me.BtnAgregarCaseta.TabIndex = 22
        Me.BtnAgregarCaseta.Text = "Agregar nueva caseta"
        Me.C1ThemeController1.SetTheme(Me.BtnAgregarCaseta, "(default)")
        Me.BtnAgregarCaseta.UseVisualStyleBackColor = True
        Me.BtnAgregarCaseta.Visible = False
        Me.BtnAgregarCaseta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnRecargarCasetas
        '
        Me.BtnRecargarCasetas.Image = Global.SGT_Transport.My.Resources.Resources.refresh_20
        Me.BtnRecargarCasetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRecargarCasetas.Location = New System.Drawing.Point(12, 9)
        Me.BtnRecargarCasetas.Name = "BtnRecargarCasetas"
        Me.BtnRecargarCasetas.Size = New System.Drawing.Size(194, 27)
        Me.BtnRecargarCasetas.TabIndex = 21
        Me.BtnRecargarCasetas.Text = "Cargar todas las casetas"
        Me.C1ThemeController1.SetTheme(Me.BtnRecargarCasetas, "(default)")
        Me.BtnRecargarCasetas.UseVisualStyleBackColor = True
        Me.BtnRecargarCasetas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(579, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(466, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 20
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarExcel.Size = New System.Drawing.Size(54, 51)
        Me.BarExcel.Text = "Grabar"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FrmCasetasXRutaAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1452, 685)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.barMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmCasetasXRutaAE"
        Me.ShowInTaskbar = False
        Me.Text = "Asignación casetas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.cboEjesTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAgregarCaseta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRecargarCasetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents LtPlaza2 As Label
    Friend WithEvents BtnPlaza As Button
    Friend WithEvents LtPlaza As Label
    Friend WithEvents tCVE_PLAZA As TextBox
    Friend WithEvents BtnPlaza2 As Button
    Friend WithEvents tCVE_PLAZA2 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents TCVE_CXR As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents LtImporte As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TIAVE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCLAVE_REM As Button
    Friend WithEvents tCLAVE_O As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LtNombre1 As Label
    Friend WithEvents TTIPO_RUTA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnRuta As Button
    Friend WithEvents txRuta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkTractor As CheckBox
    Friend WithEvents chkFull As CheckBox
    Friend WithEvents chkSencillo As CheckBox
    Friend WithEvents rbFull As RadioButton
    Friend WithEvents rbSencillo As RadioButton
    Friend WithEvents rbTractor As RadioButton
    Friend WithEvents txDescripcion As TextBox
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BtnRecargarCasetas As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAgregarCaseta As C1.Win.C1Input.C1Button
    Friend WithEvents cboEjesTotal As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
End Class
