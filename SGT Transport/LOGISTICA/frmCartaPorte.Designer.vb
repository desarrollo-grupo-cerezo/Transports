<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCartaPorte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartaPorte))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRepCartaPorte = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRepDifPeso = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCPTransferidas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.PAG1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.PAG2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraAbajo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.PAG1.SuspendLayout()
        Me.PAG2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.barEliminar, Me.BarActualizar, Me.ReportesToolStripMenuItem, Me.BarExcel, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1206, 55)
        Me.barSalir.TabIndex = 9
        Me.barSalir.Text = "MenuStrip1"
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(54, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'barEdit
        '
        Me.barEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEdit.ForeColor = System.Drawing.Color.Black
        Me.barEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.barEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEdit.Name = "barEdit"
        Me.barEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barEdit.Size = New System.Drawing.Size(44, 51)
        Me.barEdit.Text = "Edit"
        Me.barEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar1
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEliminar.Size = New System.Drawing.Size(65, 51)
        Me.barEliminar.Text = "Cancelar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarRepCartaPorte, Me.BarRepDifPeso, Me.BarCPTransferidas})
        Me.ReportesToolStripMenuItem.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.ReportesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(112, 51)
        Me.ReportesToolStripMenuItem.Text = "Reportes logística"
        Me.ReportesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRepCartaPorte
        '
        Me.BarRepCartaPorte.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarRepCartaPorte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRepCartaPorte.Name = "BarRepCartaPorte"
        Me.BarRepCartaPorte.Size = New System.Drawing.Size(230, 38)
        Me.BarRepCartaPorte.Text = "Carta porte por recibir"
        '
        'BarRepDifPeso
        '
        Me.BarRepDifPeso.Image = Global.SGT_Transport.My.Resources.Resources.impresora4
        Me.BarRepDifPeso.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRepDifPeso.Name = "BarRepDifPeso"
        Me.BarRepDifPeso.Size = New System.Drawing.Size(230, 38)
        Me.BarRepDifPeso.Text = "Reporte diferencia de peso"
        '
        'BarCPTransferidas
        '
        Me.BarCPTransferidas.Image = Global.SGT_Transport.My.Resources.Resources.printer22
        Me.BarCPTransferidas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCPTransferidas.Name = "BarCPTransferidas"
        Me.BarCPTransferidas.Size = New System.Drawing.Size(230, 38)
        Me.BarCPTransferidas.Text = "Carta porte transferidas"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(970, 397)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg.TabIndex = 10
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
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(957, 7)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(230, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 21
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 562)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1206, 25)
        Me.BarraAbajo.TabIndex = 22
        Me.BarraAbajo.Text = "ToolStrip1"
        '
        'BHoy
        '
        Me.BHoy.AutoSize = False
        Me.BHoy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BHoy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHoy.Name = "BHoy"
        Me.BHoy.Size = New System.Drawing.Size(80, 22)
        Me.BHoy.Text = "Hoy"
        '
        'BAyer
        '
        Me.BAyer.AutoSize = False
        Me.BAyer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BAyer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BAyer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAyer.Name = "BAyer"
        Me.BAyer.Size = New System.Drawing.Size(80, 22)
        Me.BAyer.Text = "Ayer"
        '
        'BEsteMes
        '
        Me.BEsteMes.AutoSize = False
        Me.BEsteMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BEsteMes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEsteMes.Name = "BEsteMes"
        Me.BEsteMes.Size = New System.Drawing.Size(80, 22)
        Me.BEsteMes.Text = "Este Mes"
        '
        'BMesAnterior
        '
        Me.BMesAnterior.AutoSize = False
        Me.BMesAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BMesAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMesAnterior.Name = "BMesAnterior"
        Me.BMesAnterior.Size = New System.Drawing.Size(80, 22)
        Me.BMesAnterior.Text = "Mes Anterior"
        '
        'BTodos
        '
        Me.BTodos.AutoSize = False
        Me.BTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTodos.Name = "BTodos"
        Me.BTodos.Size = New System.Drawing.Size(80, 22)
        Me.BTodos.Text = "Todos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.F2)
        Me.GroupBox1.Controls.Add(Me.F1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(1023, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 59)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(135, 28)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 21)
        Me.F2.TabIndex = 171
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(7, 28)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 170
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "al"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(269, 20)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 33)
        Me.btnFiltrar.TabIndex = 168
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Del"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(667, 268)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(49, 13)
        Me.Lt1.TabIndex = 24
        Me.Lt1.Text = "_______"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "bdf5555fd97745e1aed34a41dc4123bf"
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
        Me.TAB1.Location = New System.Drawing.Point(12, 61)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.SelectedTabBold = True
        Me.TAB1.Size = New System.Drawing.Size(972, 439)
        Me.TAB1.SplitterWidth = 6
        Me.TAB1.TabAreaBorder = True
        Me.TAB1.TabAreaSpacing = 10
        Me.TAB1.TabIndex = 25
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
        Me.PAG1.Image = Global.SGT_Transport.My.Resources.Resources.carta_porte
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
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.AutoClipboard = True
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(970, 397)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 11
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'FrmCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1206, 587)
        Me.Controls.Add(Me.TAB1)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCartaPorte"
        Me.Text = "Carta porte"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.PAG1.ResumeLayout(False)
        Me.PAG2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PAG1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PAG2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarRepCartaPorte As ToolStripMenuItem
    Friend WithEvents BarRepDifPeso As ToolStripMenuItem
    Friend WithEvents BarCPTransferidas As ToolStripMenuItem
End Class
