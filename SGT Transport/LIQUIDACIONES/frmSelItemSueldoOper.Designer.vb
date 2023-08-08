<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelItemSueldoOper
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelItemSueldoOper))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barRefresh = New System.Windows.Forms.ToolStripButton()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.tCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.btnPlaza1 = New System.Windows.Forms.Button()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.tCVE_PLAZA = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnPlaza2 = New System.Windows.Forms.Button()
        Me.LtPlaza2 = New System.Windows.Forms.Label()
        Me.tCVE_PLAZA2 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnCLIENTE = New System.Windows.Forms.Button()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoResize = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.ExtendLastCol = True
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(873, 452)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.ToolStripSeparator1, Me.barRefresh, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(877, 54)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.C1ThemeController1.SetTheme(Me.ToolStrip1, "Office2010Blue")
        '
        'barAceptar
        '
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok20
        Me.barAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.Size = New System.Drawing.Size(52, 51)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'barRefresh
        '
        Me.barRefresh.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.barRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barRefresh.Name = "barRefresh"
        Me.barRefresh.Size = New System.Drawing.Size(59, 51)
        Me.barRefresh.Text = "Refrescar"
        Me.barRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(460, 5)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(357, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 18
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'tCLIENTE
        '
        Me.tCLIENTE.AcceptsReturn = True
        Me.tCLIENTE.AcceptsTab = True
        Me.tCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLIENTE.ForeColor = System.Drawing.Color.Black
        Me.tCLIENTE.Location = New System.Drawing.Point(85, 17)
        Me.tCLIENTE.Name = "tCLIENTE"
        Me.tCLIENTE.Size = New System.Drawing.Size(46, 21)
        Me.tCLIENTE.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCLIENTE, "Office2010Blue")
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(36, 20)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 15)
        Me.Label25.TabIndex = 393
        Me.Label25.Text = "Cliente"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label25, "Office2010Blue")
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(159, 19)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(299, 20)
        Me.LtNombre.TabIndex = 394
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.HeaderLineWidth = 1
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 54)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.Split1)
        Me.C1SplitContainer1.Panels.Add(Me.Split2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(877, 570)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterMovingColor = System.Drawing.Color.Black
        Me.C1SplitContainer1.TabIndex = 396
        Me.C1ThemeController1.SetTheme(Me.C1SplitContainer1, "Office2010Blue")
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.BorderColor = System.Drawing.Color.Black
        Me.Split1.BorderWidth = 1
        Me.Split1.Controls.Add(Me.BtnFiltrar)
        Me.Split1.Controls.Add(Me.btnPlaza1)
        Me.Split1.Controls.Add(Me.LtPlaza)
        Me.Split1.Controls.Add(Me.tCVE_PLAZA)
        Me.Split1.Controls.Add(Me.Label22)
        Me.Split1.Controls.Add(Me.btnPlaza2)
        Me.Split1.Controls.Add(Me.LtPlaza2)
        Me.Split1.Controls.Add(Me.tCVE_PLAZA2)
        Me.Split1.Controls.Add(Me.Label36)
        Me.Split1.Controls.Add(Me.LtNombre)
        Me.Split1.Controls.Add(Me.btnCLIENTE)
        Me.Split1.Controls.Add(Me.Label25)
        Me.Split1.Controls.Add(Me.tCLIENTE)
        Me.Split1.Height = 110
        Me.Split1.Location = New System.Drawing.Point(2, 2)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(873, 108)
        Me.Split1.SizeRatio = 19.577R
        Me.Split1.TabIndex = 0
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnFiltrar.Image = Global.SGT_Transport.My.Resources.Resources.filtro2
        Me.BtnFiltrar.Location = New System.Drawing.Point(497, 32)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(64, 54)
        Me.BtnFiltrar.TabIndex = 404
        Me.C1ThemeController1.SetTheme(Me.BtnFiltrar, "Office2010Blue")
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'btnPlaza1
        '
        Me.btnPlaza1.AutoSize = True
        Me.btnPlaza1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza1.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza1.Image = CType(resources.GetObject("btnPlaza1.Image"), System.Drawing.Image)
        Me.btnPlaza1.Location = New System.Drawing.Point(132, 48)
        Me.btnPlaza1.Name = "btnPlaza1"
        Me.btnPlaza1.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza1.TabIndex = 402
        Me.C1ThemeController1.SetTheme(Me.btnPlaza1, "Office2010Blue")
        Me.btnPlaza1.UseVisualStyleBackColor = True
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(159, 51)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(299, 20)
        Me.LtPlaza.TabIndex = 399
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'tCVE_PLAZA
        '
        Me.tCVE_PLAZA.AcceptsReturn = True
        Me.tCVE_PLAZA.AcceptsTab = True
        Me.tCVE_PLAZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA.Location = New System.Drawing.Point(85, 49)
        Me.tCVE_PLAZA.Name = "tCVE_PLAZA"
        Me.tCVE_PLAZA.Size = New System.Drawing.Size(46, 21)
        Me.tCVE_PLAZA.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA, "Office2010Blue")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(32, 79)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 15)
        Me.Label22.TabIndex = 398
        Me.Label22.Text = "Destino"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label22, "Office2010Blue")
        '
        'btnPlaza2
        '
        Me.btnPlaza2.AutoSize = True
        Me.btnPlaza2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza2.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza2.Image = CType(resources.GetObject("btnPlaza2.Image"), System.Drawing.Image)
        Me.btnPlaza2.Location = New System.Drawing.Point(132, 75)
        Me.btnPlaza2.Name = "btnPlaza2"
        Me.btnPlaza2.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza2.TabIndex = 403
        Me.C1ThemeController1.SetTheme(Me.btnPlaza2, "Office2010Blue")
        Me.btnPlaza2.UseVisualStyleBackColor = True
        '
        'LtPlaza2
        '
        Me.LtPlaza2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza2.Location = New System.Drawing.Point(159, 78)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(299, 20)
        Me.LtPlaza2.TabIndex = 401
        Me.C1ThemeController1.SetTheme(Me.LtPlaza2, "Office2010Blue")
        '
        'tCVE_PLAZA2
        '
        Me.tCVE_PLAZA2.AcceptsReturn = True
        Me.tCVE_PLAZA2.AcceptsTab = True
        Me.tCVE_PLAZA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.tCVE_PLAZA2.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA2.Location = New System.Drawing.Point(85, 77)
        Me.tCVE_PLAZA2.Name = "tCVE_PLAZA2"
        Me.tCVE_PLAZA2.Size = New System.Drawing.Size(46, 21)
        Me.tCVE_PLAZA2.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA2, "Office2010Blue")
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(37, 51)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(44, 15)
        Me.Label36.TabIndex = 400
        Me.Label36.Text = "Origen"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label36, "Office2010Blue")
        '
        'btnCLIENTE
        '
        Me.btnCLIENTE.AutoSize = True
        Me.btnCLIENTE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCLIENTE.BackColor = System.Drawing.Color.Transparent
        Me.btnCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLIENTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnCLIENTE.Image = CType(resources.GetObject("btnCLIENTE.Image"), System.Drawing.Image)
        Me.btnCLIENTE.Location = New System.Drawing.Point(132, 15)
        Me.btnCLIENTE.Name = "btnCLIENTE"
        Me.btnCLIENTE.Size = New System.Drawing.Size(24, 23)
        Me.btnCLIENTE.TabIndex = 395
        Me.C1ThemeController1.SetTheme(Me.btnCLIENTE, "Office2010Blue")
        Me.btnCLIENTE.UseVisualStyleBackColor = True
        '
        'Split2
        '
        Me.Split2.BorderColor = System.Drawing.Color.Black
        Me.Split2.BorderWidth = 1
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 454
        Me.Split2.Location = New System.Drawing.Point(2, 116)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(873, 452)
        Me.Split2.TabIndex = 1
        '
        'frmSelItemSueldoOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 624)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSelItemSueldoOper"
        Me.Text = "Seleccione cliente"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barAceptar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barRefresh As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnCLIENTE As Button
    Friend WithEvents tCLIENTE As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents btnPlaza1 As Button
    Friend WithEvents LtPlaza As Label
    Friend WithEvents tCVE_PLAZA As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents btnPlaza2 As Button
    Friend WithEvents LtPlaza2 As Label
    Friend WithEvents tCVE_PLAZA2 As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents BtnFiltrar As Button
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
