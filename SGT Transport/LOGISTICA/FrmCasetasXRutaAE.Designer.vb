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
        Me.btnPlaza = New System.Windows.Forms.Button()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.tCVE_PLAZA = New System.Windows.Forms.TextBox()
        Me.btnPlaza2 = New System.Windows.Forms.Button()
        Me.tCVE_PLAZA2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TCVE_CXR = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TIAVE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCLAVE_REM = New System.Windows.Forms.Button()
        Me.tCLAVE_O = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LtNombre1 = New System.Windows.Forms.Label()
        Me.LtImporte = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.barMenu.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1184, 55)
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
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza2.Location = New System.Drawing.Point(660, 44)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(305, 21)
        Me.LtPlaza2.TabIndex = 449
        Me.C1ThemeController1.SetTheme(Me.LtPlaza2, "Office2010Blue")
        '
        'btnPlaza
        '
        Me.btnPlaza.AutoSize = True
        Me.btnPlaza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza.Image = CType(resources.GetObject("btnPlaza.Image"), System.Drawing.Image)
        Me.btnPlaza.Location = New System.Drawing.Point(154, 39)
        Me.btnPlaza.Name = "btnPlaza"
        Me.btnPlaza.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza.TabIndex = 450
        Me.C1ThemeController1.SetTheme(Me.btnPlaza, "Office2010Blue")
        Me.btnPlaza.UseVisualStyleBackColor = True
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(184, 40)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(299, 21)
        Me.LtPlaza.TabIndex = 447
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'tCVE_PLAZA
        '
        Me.tCVE_PLAZA.AcceptsReturn = True
        Me.tCVE_PLAZA.AcceptsTab = True
        Me.tCVE_PLAZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA.Location = New System.Drawing.Point(91, 40)
        Me.tCVE_PLAZA.Name = "tCVE_PLAZA"
        Me.tCVE_PLAZA.Size = New System.Drawing.Size(57, 22)
        Me.tCVE_PLAZA.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA, "Office2010Blue")
        '
        'btnPlaza2
        '
        Me.btnPlaza2.AutoSize = True
        Me.btnPlaza2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza2.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza2.Image = CType(resources.GetObject("btnPlaza2.Image"), System.Drawing.Image)
        Me.btnPlaza2.Location = New System.Drawing.Point(630, 41)
        Me.btnPlaza2.Name = "btnPlaza2"
        Me.btnPlaza2.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza2.TabIndex = 451
        Me.C1ThemeController1.SetTheme(Me.btnPlaza2, "Office2010Blue")
        Me.btnPlaza2.UseVisualStyleBackColor = True
        '
        'tCVE_PLAZA2
        '
        Me.tCVE_PLAZA2.AcceptsReturn = True
        Me.tCVE_PLAZA2.AcceptsTab = True
        Me.tCVE_PLAZA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA2.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA2.Location = New System.Drawing.Point(567, 42)
        Me.tCVE_PLAZA2.Name = "tCVE_PLAZA2"
        Me.tCVE_PLAZA2.Size = New System.Drawing.Size(57, 22)
        Me.tCVE_PLAZA2.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA2, "Office2010Blue")
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(37, 42)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 16)
        Me.Label41.TabIndex = 448
        Me.Label41.Text = "Origen"
        Me.C1ThemeController1.SetTheme(Me.Label41, "Office2010Blue")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(507, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 446
        Me.Label13.Text = "Destino"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2010Blue")
        '
        'TCVE_CXR
        '
        Me.TCVE_CXR.AcceptsReturn = True
        Me.TCVE_CXR.AcceptsTab = True
        Me.TCVE_CXR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CXR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CXR.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CXR.Location = New System.Drawing.Point(91, 11)
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
        Me.Label27.Location = New System.Drawing.Point(42, 14)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 445
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1184, 362)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 455
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TIAVE)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCLAVE_REM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCLAVE_O)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtNombre1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtImporte)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtPlaza2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TCVE_CXR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPlaza)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LtPlaza)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCVE_PLAZA2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tCVE_PLAZA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPlaza2)
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1.Panel1, "(default)")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg)
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1.Panel2, "(default)")
        Me.SplitContainer1.Size = New System.Drawing.Size(1184, 498)
        Me.SplitContainer1.SplitterDistance = 132
        Me.SplitContainer1.TabIndex = 456
        Me.C1ThemeController1.SetTheme(Me.SplitContainer1, "(default)")
        '
        'TIAVE
        '
        Me.TIAVE.AcceptsReturn = True
        Me.TIAVE.AcceptsTab = True
        Me.TIAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIAVE.ForeColor = System.Drawing.Color.Black
        Me.TIAVE.Location = New System.Drawing.Point(91, 105)
        Me.TIAVE.Name = "TIAVE"
        Me.TIAVE.Size = New System.Drawing.Size(148, 21)
        Me.TIAVE.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.TIAVE, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(53, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 463
        Me.Label1.Text = "IAVE"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'btnCLAVE_REM
        '
        Me.btnCLAVE_REM.AutoSize = True
        Me.btnCLAVE_REM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCLAVE_REM.BackColor = System.Drawing.Color.Transparent
        Me.btnCLAVE_REM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLAVE_REM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnCLAVE_REM.Image = CType(resources.GetObject("btnCLAVE_REM.Image"), System.Drawing.Image)
        Me.btnCLAVE_REM.Location = New System.Drawing.Point(154, 76)
        Me.btnCLAVE_REM.Name = "btnCLAVE_REM"
        Me.btnCLAVE_REM.Size = New System.Drawing.Size(24, 23)
        Me.btnCLAVE_REM.TabIndex = 461
        Me.C1ThemeController1.SetTheme(Me.btnCLAVE_REM, "Office2010Blue")
        Me.btnCLAVE_REM.UseVisualStyleBackColor = True
        '
        'tCLAVE_O
        '
        Me.tCLAVE_O.AcceptsReturn = True
        Me.tCLAVE_O.AcceptsTab = True
        Me.tCLAVE_O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCLAVE_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE_O.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE_O.Location = New System.Drawing.Point(91, 76)
        Me.tCLAVE_O.Name = "tCLAVE_O"
        Me.tCLAVE_O.Size = New System.Drawing.Size(57, 21)
        Me.tCLAVE_O.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCLAVE_O, "Office2010Blue")
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(28, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 30)
        Me.Label19.TabIndex = 459
        Me.Label19.Text = "Cliente operativo"
        Me.C1ThemeController1.SetTheme(Me.Label19, "Office2010Blue")
        '
        'LtNombre1
        '
        Me.LtNombre1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre1.Location = New System.Drawing.Point(184, 76)
        Me.LtNombre1.Name = "LtNombre1"
        Me.LtNombre1.Size = New System.Drawing.Size(299, 21)
        Me.LtNombre1.TabIndex = 460
        Me.C1ThemeController1.SetTheme(Me.LtNombre1, "Office2010Blue")
        '
        'LtImporte
        '
        Me.LtImporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtImporte.Location = New System.Drawing.Point(567, 77)
        Me.LtImporte.Name = "LtImporte"
        Me.LtImporte.Size = New System.Drawing.Size(152, 21)
        Me.LtImporte.TabIndex = 456
        Me.LtImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtImporte, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(497, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 455
        Me.Label3.Text = "Total ruta"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'FrmCasetasXRutaAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 553)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.barMenu)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents LtPlaza2 As Label
    Friend WithEvents btnPlaza As Button
    Friend WithEvents LtPlaza As Label
    Friend WithEvents tCVE_PLAZA As TextBox
    Friend WithEvents btnPlaza2 As Button
    Friend WithEvents tCVE_PLAZA2 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TCVE_CXR As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents LtImporte As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TIAVE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCLAVE_REM As Button
    Friend WithEvents tCLAVE_O As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LtNombre1 As Label
End Class
