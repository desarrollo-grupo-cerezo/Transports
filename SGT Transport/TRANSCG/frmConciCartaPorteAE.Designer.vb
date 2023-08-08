<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConciCartaPorteAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConciCartaPorteAE))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_CCP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.tCVE_DOC = New System.Windows.Forms.TextBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tNETO = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tIVA = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tSUBTOTAL = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.tCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCliente = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tRETENCION = New System.Windows.Forms.Label()
        Me.SplitMain = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitFMain = New System.Windows.Forms.SplitContainer()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barMenu.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMain.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        CType(Me.SplitFMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitFMain.Panel1.SuspendLayout()
        Me.SplitFMain.Panel2.SuspendLayout()
        Me.SplitFMain.SuspendLayout()
        Me.Split3.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barActualizar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1105, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 27
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
        'barActualizar
        '
        Me.barActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barActualizar.ForeColor = System.Drawing.Color.Black
        Me.barActualizar.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.barActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barActualizar.Name = "barActualizar"
        Me.barActualizar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barActualizar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barActualizar.Size = New System.Drawing.Size(71, 51)
        Me.barActualizar.Text = "Actualizar"
        Me.barActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'tCVE_CCP
        '
        Me.tCVE_CCP.AcceptsReturn = True
        Me.tCVE_CCP.AcceptsTab = True
        Me.tCVE_CCP.Enabled = False
        Me.tCVE_CCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_CCP.ForeColor = System.Drawing.Color.Black
        Me.tCVE_CCP.Location = New System.Drawing.Point(78, 16)
        Me.tCVE_CCP.Name = "tCVE_CCP"
        Me.tCVE_CCP.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_CCP.TabIndex = 213
        Me.tCVE_CCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.tCVE_CCP, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Concilaición"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 20
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(553, 319)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 212
        Me.C1ThemeController1.SetTheme(Me.Fg2, "Office2010Blue")
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.ShowClearButton = False
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Culture = 2058
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(819, 41)
        Me.F1.Name = "F1"
        Me.F1.ShowFocusRectangle = True
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 210
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label112.Location = New System.Drawing.Point(772, 44)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(41, 15)
        Me.Label112.TabIndex = 211
        Me.Label112.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label112, "Office2010Blue")
        '
        'tCVE_DOC
        '
        Me.tCVE_DOC.AcceptsReturn = True
        Me.tCVE_DOC.AcceptsTab = True
        Me.tCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_DOC.ForeColor = System.Drawing.Color.Black
        Me.tCVE_DOC.Location = New System.Drawing.Point(818, 11)
        Me.tCVE_DOC.Name = "tCVE_DOC"
        Me.tCVE_DOC.Size = New System.Drawing.Size(123, 22)
        Me.tCVE_DOC.TabIndex = 208
        Me.C1ThemeController1.SetTheme(Me.tCVE_DOC, "Office2010Blue")
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label114.Location = New System.Drawing.Point(766, 14)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(48, 15)
        Me.Label114.TabIndex = 209
        Me.Label114.Text = "Factura"
        Me.C1ThemeController1.SetTheme(Me.Label114, "Office2010Blue")
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(546, 319)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 203
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'tNETO
        '
        Me.tNETO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tNETO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNETO.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNETO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tNETO.Location = New System.Drawing.Point(843, 66)
        Me.tNETO.Name = "tNETO"
        Me.tNETO.Size = New System.Drawing.Size(152, 21)
        Me.tNETO.TabIndex = 222
        Me.tNETO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tNETO, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(801, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 17)
        Me.Label8.TabIndex = 221
        Me.Label8.Text = "Neto"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'tIVA
        '
        Me.tIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tIVA.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIVA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tIVA.Location = New System.Drawing.Point(843, 22)
        Me.tIVA.Name = "tIVA"
        Me.tIVA.Size = New System.Drawing.Size(152, 21)
        Me.tIVA.TabIndex = 220
        Me.tIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tIVA, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(815, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 15)
        Me.Label6.TabIndex = 219
        Me.Label6.Text = "IVA"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'tSUBTOTAL
        '
        Me.tSUBTOTAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tSUBTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tSUBTOTAL.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUBTOTAL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tSUBTOTAL.Location = New System.Drawing.Point(843, 0)
        Me.tSUBTOTAL.Name = "tSUBTOTAL"
        Me.tSUBTOTAL.Size = New System.Drawing.Size(152, 21)
        Me.tSUBTOTAL.TabIndex = 218
        Me.tSUBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tSUBTOTAL, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(783, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "Sub-total"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(309, 20)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(283, 20)
        Me.LtNombre.TabIndex = 226
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'tCLIENTE
        '
        Me.tCLIENTE.AcceptsReturn = True
        Me.tCLIENTE.AcceptsTab = True
        Me.tCLIENTE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLIENTE.ForeColor = System.Drawing.Color.Black
        Me.tCLIENTE.Location = New System.Drawing.Point(228, 19)
        Me.tCLIENTE.Name = "tCLIENTE"
        Me.tCLIENTE.Size = New System.Drawing.Size(53, 22)
        Me.tCLIENTE.TabIndex = 223
        Me.tCLIENTE.Text = "         1"
        Me.C1ThemeController1.SetTheme(Me.tCLIENTE, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(183, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 224
        Me.Label5.Text = "Cliente"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'btnRegresar
        '
        Me.btnRegresar.BackColor = System.Drawing.Color.Transparent
        Me.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnRegresar.Image = Global.SGT_Transport.My.Resources.Resources.fechaizq2
        Me.btnRegresar.Location = New System.Drawing.Point(536, 57)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(56, 44)
        Me.btnRegresar.TabIndex = 216
        Me.C1ThemeController1.SetTheme(Me.btnRegresar, "Office2010Blue")
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnAgregar.Image = Global.SGT_Transport.My.Resources.Resources.flechader
        Me.btnAgregar.Location = New System.Drawing.Point(423, 57)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(56, 44)
        Me.btnAgregar.TabIndex = 215
        Me.C1ThemeController1.SetTheme(Me.btnAgregar, "Office2010Blue")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(282, 20)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(23, 21)
        Me.btnCliente.TabIndex = 225
        Me.C1ThemeController1.SetTheme(Me.btnCliente, "Office2010Blue")
        Me.btnCliente.UseVisualStyleBackColor = True
        Me.btnCliente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(776, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Retención"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'tRETENCION
        '
        Me.tRETENCION.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tRETENCION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRETENCION.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRETENCION.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tRETENCION.Location = New System.Drawing.Point(843, 44)
        Me.tRETENCION.Name = "tRETENCION"
        Me.tRETENCION.Size = New System.Drawing.Size(152, 21)
        Me.tRETENCION.TabIndex = 224
        Me.tRETENCION.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tRETENCION, "Office2010Blue")
        '
        'SplitMain
        '
        Me.SplitMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitMain.BorderWidth = 1
        Me.SplitMain.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitMain.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMain.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitMain.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitMain.HeaderLineWidth = 1
        Me.SplitMain.Location = New System.Drawing.Point(0, 55)
        Me.SplitMain.Name = "SplitMain"
        Me.SplitMain.Panels.Add(Me.Split1)
        Me.SplitMain.Panels.Add(Me.Split2)
        Me.SplitMain.Panels.Add(Me.Split3)
        Me.SplitMain.Size = New System.Drawing.Size(1105, 592)
        Me.SplitMain.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMain.SplitterMovingColor = System.Drawing.Color.Black
        Me.SplitMain.TabIndex = 231
        Me.C1ThemeController1.SetTheme(Me.SplitMain, "Office2010Blue")
        Me.SplitMain.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitMain.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.tCVE_CCP)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Controls.Add(Me.Label114)
        Me.Split1.Controls.Add(Me.Label5)
        Me.Split1.Controls.Add(Me.LtNombre)
        Me.Split1.Controls.Add(Me.tCLIENTE)
        Me.Split1.Controls.Add(Me.btnRegresar)
        Me.Split1.Controls.Add(Me.Label112)
        Me.Split1.Controls.Add(Me.tCVE_DOC)
        Me.Split1.Controls.Add(Me.btnCliente)
        Me.Split1.Controls.Add(Me.btnAgregar)
        Me.Split1.Height = 135
        Me.Split1.KeepRelativeSize = False
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1103, 135)
        Me.Split1.SizeRatio = 22.843R
        Me.Split1.TabIndex = 0
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.SplitFMain)
        Me.Split2.Height = 319
        Me.Split2.Location = New System.Drawing.Point(1, 140)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1103, 319)
        Me.Split2.SizeRatio = 71.366R
        Me.Split2.TabIndex = 1
        '
        'SplitFMain
        '
        Me.SplitFMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitFMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitFMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.SplitFMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitFMain.Name = "SplitFMain"
        '
        'SplitFMain.Panel1
        '
        Me.SplitFMain.Panel1.Controls.Add(Me.Fg)
        '
        'SplitFMain.Panel2
        '
        Me.SplitFMain.Panel2.Controls.Add(Me.Fg2)
        Me.SplitFMain.Size = New System.Drawing.Size(1103, 319)
        Me.SplitFMain.SplitterDistance = 546
        Me.SplitFMain.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.SplitFMain, "Office2010Blue")
        '
        'Split3
        '
        Me.Split3.Controls.Add(Me.Label2)
        Me.Split3.Controls.Add(Me.Label3)
        Me.Split3.Controls.Add(Me.tRETENCION)
        Me.Split3.Controls.Add(Me.Label8)
        Me.Split3.Controls.Add(Me.tSUBTOTAL)
        Me.Split3.Controls.Add(Me.tIVA)
        Me.Split3.Controls.Add(Me.tNETO)
        Me.Split3.Controls.Add(Me.Label6)
        Me.Split3.Height = 128
        Me.Split3.Location = New System.Drawing.Point(1, 463)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1103, 128)
        Me.Split3.TabIndex = 2
        '
        'frmConciCartaPorteAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 647)
        Me.Controls.Add(Me.SplitMain)
        Me.Controls.Add(Me.barMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmConciCartaPorteAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conciliacion carta porte"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMain.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.SplitFMain.Panel1.ResumeLayout(False)
        Me.SplitFMain.Panel2.ResumeLayout(False)
        CType(Me.SplitFMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitFMain.ResumeLayout(False)
        Me.Split3.ResumeLayout(False)
        Me.Split3.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents btnRegresar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents tCVE_CCP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label112 As Label
    Friend WithEvents tCVE_DOC As TextBox
    Friend WithEvents Label114 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents tNETO As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tIVA As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tSUBTOTAL As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents btnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents tCLIENTE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tRETENCION As Label
    Friend WithEvents barActualizar As ToolStripMenuItem
    Friend WithEvents SplitMain As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitFMain As SplitContainer
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
