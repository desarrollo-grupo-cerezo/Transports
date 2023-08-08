<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAsignacionViaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignacionViaje))
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuValesDeCombustible = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGastosDeViaje = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.btnTractor = New C1.Win.C1Input.C1Button()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.PAG1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.PAG2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnClear = New C1.Win.C1Input.C1Button()
        Me.TBUSCAR = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.PAG1.SuspendLayout()
        Me.PAG2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BtnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBUSCAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarMenu
        '
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarActualizar, Me.BarFiltro, Me.BarReportes, Me.BarExcel, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Padding = New System.Windows.Forms.Padding(6, 12, 0, 0)
        Me.BarMenu.Size = New System.Drawing.Size(1405, 63)
        Me.BarMenu.TabIndex = 11
        Me.BarMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(54, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 51)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(65, 51)
        Me.BarEliminar.Text = "Cancelar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarFiltro
        '
        Me.BarFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarFiltro.ForeColor = System.Drawing.Color.Black
        Me.BarFiltro.Image = Global.SGT_Transport.My.Resources.Resources.filtro21
        Me.BarFiltro.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarFiltro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarFiltro.Name = "BarFiltro"
        Me.BarFiltro.Size = New System.Drawing.Size(49, 51)
        Me.BarFiltro.Text = "Filtrar"
        Me.BarFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarReportes
        '
        Me.BarReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuReporte, Me.MnuValesDeCombustible, Me.MnuGastosDeViaje})
        Me.BarReportes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarReportes.ForeColor = System.Drawing.Color.Black
        Me.BarReportes.Image = Global.SGT_Transport.My.Resources.Resources.impresora32
        Me.BarReportes.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReportes.Name = "BarReportes"
        Me.BarReportes.ShortcutKeyDisplayString = ""
        Me.BarReportes.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarReportes.Size = New System.Drawing.Size(65, 51)
        Me.BarReportes.Text = "Reportes"
        Me.BarReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuReporte
        '
        Me.MnuReporte.Image = Global.SGT_Transport.My.Resources.Resources.printer22
        Me.MnuReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuReporte.Name = "MnuReporte"
        Me.MnuReporte.Size = New System.Drawing.Size(201, 38)
        Me.MnuReporte.Text = "Reporte"
        '
        'MnuValesDeCombustible
        '
        Me.MnuValesDeCombustible.Image = Global.SGT_Transport.My.Resources.Resources.impresora16
        Me.MnuValesDeCombustible.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuValesDeCombustible.Name = "MnuValesDeCombustible"
        Me.MnuValesDeCombustible.Size = New System.Drawing.Size(201, 38)
        Me.MnuValesDeCombustible.Text = "Vales de combustible"
        '
        'MnuGastosDeViaje
        '
        Me.MnuGastosDeViaje.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.MnuGastosDeViaje.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuGastosDeViaje.Name = "MnuGastosDeViaje"
        Me.MnuGastosDeViaje.Size = New System.Drawing.Size(201, 38)
        Me.MnuGastosDeViaje.Text = "Gastos de viaje"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(970, 397)
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(900, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(234, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 13
        Me.C1FlexGridSearchPanel1.Visible = False
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg2, Me.C1FlexGridSearchPanel1)
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 22
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(970, 397)
        Me.Fg2.TabIndex = 13
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(412, 15)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 33)
        Me.btnFiltrar.TabIndex = 168
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 1
        '
        'tCVE_TRACTOR
        '
        Me.tCVE_TRACTOR.AcceptsReturn = True
        Me.tCVE_TRACTOR.AcceptsTab = True
        Me.tCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TRACTOR.Location = New System.Drawing.Point(317, 20)
        Me.tCVE_TRACTOR.Name = "tCVE_TRACTOR"
        Me.tCVE_TRACTOR.Size = New System.Drawing.Size(66, 23)
        Me.tCVE_TRACTOR.TabIndex = 165
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(6, 25)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnTractor
        '
        Me.btnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTractor.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnTractor.Location = New System.Drawing.Point(385, 20)
        Me.btnTractor.Name = "btnTractor"
        Me.btnTractor.Size = New System.Drawing.Size(21, 24)
        Me.btnTractor.TabIndex = 164
        Me.btnTractor.UseVisualStyleBackColor = True
        Me.btnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(268, 24)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(47, 15)
        Me.Label100.TabIndex = 166
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "7df5a7ee418740b9aa9479d175d9940b"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'TAB1
        '
        Me.TAB1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TAB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB1.Controls.Add(Me.PAG1)
        Me.TAB1.Controls.Add(Me.PAG2)
        Me.TAB1.Indent = 10
        Me.TAB1.ItemSize = New System.Drawing.Size(140, 30)
        Me.TAB1.Location = New System.Drawing.Point(12, 73)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.SelectedTabBold = True
        Me.TAB1.Size = New System.Drawing.Size(972, 439)
        Me.TAB1.SplitterWidth = 6
        Me.TAB1.TabAreaBorder = True
        Me.TAB1.TabAreaSpacing = 10
        Me.TAB1.TabIndex = 14
        Me.TAB1.TabLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.TAB1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Normal
        Me.TAB1.TabsSpacing = 10
        Me.TAB1.TabTextAlignment = System.Drawing.StringAlignment.Center
        Me.TAB1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.TAB1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'PAG1
        '
        Me.PAG1.Controls.Add(Me.Fg)
        Me.PAG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAG1.Image = Global.SGT_Transport.My.Resources.Resources.track29
        Me.PAG1.Location = New System.Drawing.Point(1, 1)
        Me.PAG1.Name = "PAG1"
        Me.PAG1.Size = New System.Drawing.Size(970, 397)
        Me.PAG1.TabIndex = 0
        Me.PAG1.Text = "ACTIVOS"
        '
        'PAG2
        '
        Me.PAG2.Controls.Add(Me.Fg2)
        Me.PAG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAG2.Image = Global.SGT_Transport.My.Resources.Resources.eli5
        Me.PAG2.Location = New System.Drawing.Point(1, 1)
        Me.PAG2.Name = "PAG2"
        Me.PAG2.Size = New System.Drawing.Size(970, 397)
        Me.PAG2.TabIndex = 1
        Me.PAG2.Text = "CANCELADOS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnClear)
        Me.GroupBox1.Controls.Add(Me.TBUSCAR)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(553, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 51)
        Me.GroupBox1.TabIndex = 210
        Me.GroupBox1.TabStop = False
        '
        'BtnClear
        '
        Me.BtnClear.Image = Global.SGT_Transport.My.Resources.Resources.equis
        Me.BtnClear.Location = New System.Drawing.Point(204, 15)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(33, 27)
        Me.BtnClear.TabIndex = 175
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'TBUSCAR
        '
        Me.TBUSCAR.AcceptsReturn = True
        Me.TBUSCAR.AcceptsTab = True
        Me.TBUSCAR.AllowDrop = True
        Me.TBUSCAR.AutoSize = False
        Me.TBUSCAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TBUSCAR.BorderColor = System.Drawing.Color.Red
        Me.TBUSCAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBUSCAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBUSCAR.Location = New System.Drawing.Point(86, 15)
        Me.TBUSCAR.MaxLength = 50
        Me.TBUSCAR.Name = "TBUSCAR"
        Me.TBUSCAR.Padding = New System.Windows.Forms.Padding(4)
        Me.TBUSCAR.ShowFocusRectangle = True
        Me.TBUSCAR.Size = New System.Drawing.Size(112, 27)
        Me.TBUSCAR.TabIndex = 1
        Me.TBUSCAR.Tag = Nothing
        Me.TBUSCAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TBUSCAR.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        Me.TBUSCAR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TBUSCAR.WordWrap = False
        Me.TBUSCAR.WrapDateTimeFields = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Buscar viaje"
        '
        'FrmAsignacionViaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1405, 542)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TAB1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BarMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAsignacionViaje"
        Me.Text = "Asignacionde Viajes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.PAG1.ResumeLayout(False)
        Me.PAG2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BtnClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBUSCAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents tCVE_TRACTOR As TextBox
    Friend WithEvents btnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents Label100 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarReportes As ToolStripMenuItem
    Friend WithEvents MnuReporte As ToolStripMenuItem
    Friend WithEvents MnuValesDeCombustible As ToolStripMenuItem
    Friend WithEvents MnuGastosDeViaje As ToolStripMenuItem
    Friend WithEvents BarFiltro As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PAG1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PAG2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TBUSCAR As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnClear As C1.Win.C1Input.C1Button
End Class
