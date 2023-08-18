<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAsigViajeBueno
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsigViajeBueno))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.tCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.PAG1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.MnuConsultarViaje = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BarConsultarViaje = New System.Windows.Forms.ToolStripMenuItem()
        Me.PAG2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.PAG4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.PAG3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.PAG5 = New C1.Win.C1Command.C1DockingTabPage()
        Me.SplitM5 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitMP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1ToolBar2 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevoCob = New C1.Win.C1Command.C1CommandLink()
        Me.BarNuevoCob = New C1.Win.C1Command.C1Command()
        Me.LkEditCob = New C1.Win.C1Command.C1CommandLink()
        Me.BarEditCob = New C1.Win.C1Command.C1Command()
        Me.LkEliminar5 = New C1.Win.C1Command.C1CommandLink()
        Me.BarEliminar5 = New C1.Win.C1Command.C1Command()
        Me.LkImprimir5 = New C1.Win.C1Command.C1CommandLink()
        Me.BarImprimir5 = New C1.Win.C1Command.C1Command()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.SplitMP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.FgR = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarSalir5 = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarConsultar = New C1.Win.C1Command.C1Command()
        Me.BarEstatusCFDI = New C1.Win.C1Command.C1Command()
        Me.BarTimbrar = New C1.Win.C1Command.C1Command()
        Me.BarOpciones = New C1.Win.C1Command.C1CommandMenu()
        Me.LkOProcStatusCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.BarProcStatusCFDI = New C1.Win.C1Command.C1Command()
        Me.LkOProcCancCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.BarProcCancCFDI = New C1.Win.C1Command.C1Command()
        Me.BarOEnviarcorreo = New C1.Win.C1Command.C1CommandLink()
        Me.BarSendMail = New C1.Win.C1Command.C1Command()
        Me.BarOImpresionMasiva = New C1.Win.C1Command.C1CommandLink()
        Me.BarImpresionMasiva = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.BarDescargarXMLyPDF = New C1.Win.C1Command.C1Command()
        Me.BarOExcel = New C1.Win.C1Command.C1CommandLink()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.BarFacturacion = New C1.Win.C1Command.C1CommandMenu()
        Me.LkFFacturaXViaje = New C1.Win.C1Command.C1CommandLink()
        Me.BarFFacXViaje = New C1.Win.C1Command.C1Command()
        Me.LkFFacturaViajesSel = New C1.Win.C1Command.C1CommandLink()
        Me.BarFacViajesSel = New C1.Win.C1Command.C1Command()
        Me.LkFFacViajeParcial = New C1.Win.C1Command.C1CommandLink()
        Me.BarFacViajeParcial = New C1.Win.C1Command.C1Command()
        Me.BarProcesos = New C1.Win.C1Command.C1CommandMenu()
        Me.LkProcStatusCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.LkProcCancCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.BarCancFactura = New C1.Win.C1Command.C1Command()
        Me.BarReactivarFactura = New C1.Win.C1Command.C1Command()
        Me.BarFiltrarCliente = New C1.Win.C1Command.C1Command()
        Me.BarRelacionFacturas = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.LkCancFactura = New C1.Win.C1Command.C1CommandLink()
        Me.BarOImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkFacturacion = New C1.Win.C1Command.C1CommandLink()
        Me.LkConsulta = New C1.Win.C1Command.C1CommandLink()
        Me.LkTimbrar = New C1.Win.C1Command.C1CommandLink()
        Me.LkReactivarFactura = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkOpciones = New C1.Win.C1Command.C1CommandLink()
        Me.LkRelacionFacturas = New C1.Win.C1Command.C1CommandLink()
        Me.LkFiltrarCliente = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.LtNumViajes = New C1.Win.C1Input.C1Label()
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.btnTractor = New C1.Win.C1Input.C1Button()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.PAG1.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnuConsultarViaje.SuspendLayout()
        Me.PAG2.SuspendLayout()
        Me.PAG4.SuspendLayout()
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PAG3.SuspendLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PAG5.SuspendLayout()
        CType(Me.SplitM5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM5.SuspendLayout()
        Me.SplitMP1.SuspendLayout()
        Me.SplitMP2.SuspendLayout()
        CType(Me.FgR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtNumViajes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.SplitP1.SuspendLayout()
        Me.SplitP2.SuspendLayout()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(910, 26)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(225, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 13
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
        Me.Fg2.ShowCellLabels = True
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(1182, 397)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 13
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
        Me.TAB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB1.Controls.Add(Me.PAG1)
        Me.TAB1.Controls.Add(Me.PAG2)
        Me.TAB1.Controls.Add(Me.PAG4)
        Me.TAB1.Controls.Add(Me.PAG3)
        Me.TAB1.Controls.Add(Me.PAG5)
        Me.TAB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TAB1.Indent = 1
        Me.TAB1.ItemSize = New System.Drawing.Size(210, 50)
        Me.TAB1.Location = New System.Drawing.Point(4, 17)
        Me.TAB1.Margin = New System.Windows.Forms.Padding(2)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.Padding = New System.Drawing.Point(3, 3)
        Me.TAB1.SelectedTabBold = True
        Me.TAB1.Size = New System.Drawing.Size(1184, 449)
        Me.TAB1.SplitterWidth = 1
        Me.TAB1.TabAreaBorder = True
        Me.TAB1.TabAreaSpacing = 0
        Me.TAB1.TabIndex = 14
        Me.TAB1.TabLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.TAB1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Normal
        Me.TAB1.TabsSpacing = 1
        Me.TAB1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.TAB1.TabTextAlignment = System.Drawing.StringAlignment.Near
        Me.TAB1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.TAB1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'PAG1
        '
        Me.PAG1.Controls.Add(Me.Fg)
        Me.PAG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAG1.Image = Global.SGT_Transport.My.Resources.Resources.track11
        Me.PAG1.Location = New System.Drawing.Point(1, 51)
        Me.PAG1.Name = "PAG1"
        Me.PAG1.Size = New System.Drawing.Size(1182, 397)
        Me.PAG1.TabIndex = 0
        Me.PAG1.Text = "Viajes no facturados"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ContextMenuStrip = Me.MnuConsultarViaje
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1182, 397)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        '
        'MnuConsultarViaje
        '
        Me.MnuConsultarViaje.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarConsultarViaje})
        Me.MnuConsultarViaje.Name = "MnuConsultarViaje"
        Me.MnuConsultarViaje.Size = New System.Drawing.Size(169, 42)
        Me.MnuConsultarViaje.Text = "Consultar viaje"
        '
        'BarConsultarViaje
        '
        Me.BarConsultarViaje.Image = Global.SGT_Transport.My.Resources.Resources.camion17
        Me.BarConsultarViaje.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarConsultarViaje.Name = "BarConsultarViaje"
        Me.BarConsultarViaje.Size = New System.Drawing.Size(168, 38)
        Me.BarConsultarViaje.Text = "Consultar viaje"
        '
        'PAG2
        '
        Me.PAG2.Controls.Add(Me.Fg2)
        Me.PAG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAG2.Image = Global.SGT_Transport.My.Resources.Resources.camion22
        Me.PAG2.Location = New System.Drawing.Point(1, 51)
        Me.PAG2.Name = "PAG2"
        Me.PAG2.Size = New System.Drawing.Size(1182, 397)
        Me.PAG2.TabIndex = 1
        Me.PAG2.Text = "Viajes facturados"
        '
        'PAG4
        '
        Me.PAG4.Controls.Add(Me.Fg4)
        Me.PAG4.Image = Global.SGT_Transport.My.Resources.Resources.camion71
        Me.PAG4.Location = New System.Drawing.Point(1, 51)
        Me.PAG4.Name = "PAG4"
        Me.PAG4.Size = New System.Drawing.Size(1182, 397)
        Me.PAG4.TabIndex = 3
        Me.PAG4.Text = "Factura con mas de un viaje"
        '
        'Fg4
        '
        Me.Fg4.AllowEditing = False
        Me.Fg4.AllowFiltering = True
        Me.Fg4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg4.ColumnInfo = resources.GetString("Fg4.ColumnInfo")
        Me.Fg4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg4.Location = New System.Drawing.Point(-1, 3)
        Me.Fg4.Name = "Fg4"
        Me.Fg4.Rows.DefaultSize = 19
        Me.Fg4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg4.ShowCellLabels = True
        Me.Fg4.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg4.Size = New System.Drawing.Size(970, 303)
        Me.Fg4.StyleInfo = resources.GetString("Fg4.StyleInfo")
        Me.Fg4.TabIndex = 14
        '
        'PAG3
        '
        Me.PAG3.Controls.Add(Me.Fg3)
        Me.PAG3.Image = Global.SGT_Transport.My.Resources.Resources.delivery2
        Me.PAG3.Location = New System.Drawing.Point(1, 51)
        Me.PAG3.Name = "PAG3"
        Me.PAG3.Size = New System.Drawing.Size(1182, 397)
        Me.PAG3.TabIndex = 2
        Me.PAG3.Text = "Viajes facturados y timbrados"
        '
        'Fg3
        '
        Me.Fg3.AllowEditing = False
        Me.Fg3.AllowFiltering = True
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg3.Location = New System.Drawing.Point(0, 0)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.Rows.DefaultSize = 19
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg3.ShowCellLabels = True
        Me.Fg3.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg3.Size = New System.Drawing.Size(1182, 397)
        Me.Fg3.StyleInfo = resources.GetString("Fg3.StyleInfo")
        Me.Fg3.TabIndex = 13
        '
        'PAG5
        '
        Me.PAG5.Controls.Add(Me.SplitM5)
        Me.PAG5.Image = Global.SGT_Transport.My.Resources.Resources.pagoenlinea
        Me.PAG5.Location = New System.Drawing.Point(1, 51)
        Me.PAG5.Name = "PAG5"
        Me.PAG5.Size = New System.Drawing.Size(1182, 397)
        Me.PAG5.TabIndex = 4
        Me.PAG5.Text = "Relación a cobranza"
        '
        'SplitM5
        '
        Me.SplitM5.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM5.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM5.BorderWidth = 1
        Me.SplitM5.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM5.Location = New System.Drawing.Point(3, 3)
        Me.SplitM5.Name = "SplitM5"
        Me.SplitM5.Panels.Add(Me.SplitMP1)
        Me.SplitM5.Panels.Add(Me.SplitMP2)
        Me.SplitM5.Size = New System.Drawing.Size(1166, 376)
        Me.SplitM5.TabIndex = 16
        '
        'SplitMP1
        '
        Me.SplitMP1.Controls.Add(Me.C1ToolBar2)
        Me.SplitMP1.Height = 45
        Me.SplitMP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitMP1.Name = "SplitMP1"
        Me.SplitMP1.Size = New System.Drawing.Size(1164, 45)
        Me.SplitMP1.SizeRatio = 12.162R
        Me.SplitMP1.TabIndex = 0
        '
        'C1ToolBar2
        '
        Me.C1ToolBar2.AccessibleName = "Tool Bar"
        Me.C1ToolBar2.AutoSize = False
        Me.C1ToolBar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar2.BackImageInImageBar = True
        Me.C1ToolBar2.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar2.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar2.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar2.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar2.ButtonWidth = 90
        Me.C1ToolBar2.CommandHolder = Nothing
        Me.C1ToolBar2.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevoCob, Me.LkEditCob, Me.LkEliminar5, Me.LkImprimir5, Me.LkDisenador})
        Me.C1ToolBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar2.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar2.Movable = False
        Me.C1ToolBar2.Name = "C1ToolBar2"
        Me.C1ToolBar2.Size = New System.Drawing.Size(1164, 43)
        Me.C1ToolBar2.Text = "C1ToolBar2"
        Me.C1ToolBar2.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkNuevoCob
        '
        Me.LkNuevoCob.Command = Me.BarNuevoCob
        Me.LkNuevoCob.Delimiter = True
        Me.LkNuevoCob.Text = "Nuevo"
        '
        'BarNuevoCob
        '
        Me.BarNuevoCob.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevoCob.Name = "BarNuevoCob"
        Me.BarNuevoCob.ShortcutText = ""
        Me.BarNuevoCob.Text = "Nuevo"
        '
        'LkEditCob
        '
        Me.LkEditCob.Command = Me.BarEditCob
        Me.LkEditCob.SortOrder = 1
        '
        'BarEditCob
        '
        Me.BarEditCob.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEditCob.Name = "BarEditCob"
        Me.BarEditCob.ShortcutText = ""
        Me.BarEditCob.Text = "Edit"
        '
        'LkEliminar5
        '
        Me.LkEliminar5.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEliminar5.Command = Me.BarEliminar5
        Me.LkEliminar5.Delimiter = True
        Me.LkEliminar5.SortOrder = 2
        Me.LkEliminar5.Text = "Eliminar"
        '
        'BarEliminar5
        '
        Me.BarEliminar5.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.BarEliminar5.Name = "BarEliminar5"
        Me.BarEliminar5.ShortcutText = ""
        Me.BarEliminar5.Text = "Eliminar"
        '
        'LkImprimir5
        '
        Me.LkImprimir5.Command = Me.BarImprimir5
        Me.LkImprimir5.Delimiter = True
        Me.LkImprimir5.SortOrder = 3
        '
        'BarImprimir5
        '
        Me.BarImprimir5.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir5.Name = "BarImprimir5"
        Me.BarImprimir5.ShortcutText = ""
        Me.BarImprimir5.Text = "Imprimir"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDiseñador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 4
        Me.LkDisenador.Text = "Diseñador"
        '
        'BarDiseñador
        '
        Me.BarDiseñador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador.Name = "BarDiseñador"
        Me.BarDiseñador.ShortcutText = ""
        Me.BarDiseñador.Text = "Diseñador"
        '
        'SplitMP2
        '
        Me.SplitMP2.Controls.Add(Me.FgR)
        Me.SplitMP2.Height = 325
        Me.SplitMP2.Location = New System.Drawing.Point(1, 50)
        Me.SplitMP2.Name = "SplitMP2"
        Me.SplitMP2.Size = New System.Drawing.Size(1164, 325)
        Me.SplitMP2.TabIndex = 1
        '
        'FgR
        '
        Me.FgR.AllowEditing = False
        Me.FgR.AllowFiltering = True
        Me.FgR.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgR.ColumnInfo = resources.GetString("FgR.ColumnInfo")
        Me.FgR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgR.Location = New System.Drawing.Point(3, 14)
        Me.FgR.Name = "FgR"
        Me.FgR.Rows.DefaultSize = 19
        Me.FgR.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgR.ShowCellLabels = True
        Me.FgR.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgR.Size = New System.Drawing.Size(1141, 231)
        Me.FgR.StyleInfo = resources.GetString("FgR.StyleInfo")
        Me.FgR.TabIndex = 15
        Me.FgR.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BarSalir5
        '
        Me.BarSalir5.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir5.Name = "BarSalir5"
        Me.BarSalir5.ShortcutText = ""
        Me.BarSalir5.ShowShortcut = False
        Me.BarSalir5.ShowTextAsToolTip = False
        Me.BarSalir5.Text = "Salir"
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
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Eliminar"
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarNuevo)
        Me.MenuHolder.Commands.Add(Me.BarConsultar)
        Me.MenuHolder.Commands.Add(Me.BarEstatusCFDI)
        Me.MenuHolder.Commands.Add(Me.BarTimbrar)
        Me.MenuHolder.Commands.Add(Me.BarOpciones)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSendMail)
        Me.MenuHolder.Commands.Add(Me.BarImpresionMasiva)
        Me.MenuHolder.Commands.Add(Me.BarDescargarXMLyPDF)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarFacturacion)
        Me.MenuHolder.Commands.Add(Me.BarFFacXViaje)
        Me.MenuHolder.Commands.Add(Me.BarFacViajesSel)
        Me.MenuHolder.Commands.Add(Me.BarFacViajeParcial)
        Me.MenuHolder.Commands.Add(Me.BarProcesos)
        Me.MenuHolder.Commands.Add(Me.BarCancFactura)
        Me.MenuHolder.Commands.Add(Me.BarProcCancCFDI)
        Me.MenuHolder.Commands.Add(Me.BarProcStatusCFDI)
        Me.MenuHolder.Commands.Add(Me.BarReactivarFactura)
        Me.MenuHolder.Commands.Add(Me.BarFiltrarCliente)
        Me.MenuHolder.Commands.Add(Me.BarRelacionFacturas)
        Me.MenuHolder.Commands.Add(Me.BarNuevoCob)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador)
        Me.MenuHolder.Commands.Add(Me.BarSalir5)
        Me.MenuHolder.Commands.Add(Me.BarImprimir5)
        Me.MenuHolder.Commands.Add(Me.BarEliminar5)
        Me.MenuHolder.Commands.Add(Me.BarEditCob)
        Me.MenuHolder.Owner = Me
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarConsultar
        '
        Me.BarConsultar.Image = Global.SGT_Transport.My.Resources.Resources.bus5
        Me.BarConsultar.Name = "BarConsultar"
        Me.BarConsultar.ShortcutText = ""
        Me.BarConsultar.Text = "Consultar"
        '
        'BarEstatusCFDI
        '
        Me.BarEstatusCFDI.Image = Global.SGT_Transport.My.Resources.Resources.status14
        Me.BarEstatusCFDI.Name = "BarEstatusCFDI"
        Me.BarEstatusCFDI.ShortcutText = ""
        Me.BarEstatusCFDI.Text = "Estatus CFDI"
        '
        'BarTimbrar
        '
        Me.BarTimbrar.Image = Global.SGT_Transport.My.Resources.Resources.images22_e1
        Me.BarTimbrar.Name = "BarTimbrar"
        Me.BarTimbrar.ShortcutText = ""
        Me.BarTimbrar.Text = "Timbrar"
        '
        'BarOpciones
        '
        Me.BarOpciones.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkOProcStatusCFDI, Me.LkOProcCancCFDI, Me.BarOEnviarcorreo, Me.BarOImpresionMasiva, Me.C1CommandLink1, Me.BarOExcel})
        Me.BarOpciones.HideNonRecentLinks = False
        Me.BarOpciones.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarOpciones.ImageBarWidth = 60
        Me.BarOpciones.Name = "BarOpciones"
        Me.BarOpciones.ShortcutText = ""
        Me.BarOpciones.Text = "Opciones"
        Me.BarOpciones.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarOpciones.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarOpciones.Width = 40
        '
        'LkOProcStatusCFDI
        '
        Me.LkOProcStatusCFDI.Command = Me.BarProcStatusCFDI
        '
        'BarProcStatusCFDI
        '
        Me.BarProcStatusCFDI.Image = Global.SGT_Transport.My.Resources.Resources.status14
        Me.BarProcStatusCFDI.Name = "BarProcStatusCFDI"
        Me.BarProcStatusCFDI.ShortcutText = ""
        Me.BarProcStatusCFDI.Text = "Estatus CFDI"
        '
        'LkOProcCancCFDI
        '
        Me.LkOProcCancCFDI.Command = Me.BarProcCancCFDI
        Me.LkOProcCancCFDI.SortOrder = 1
        '
        'BarProcCancCFDI
        '
        Me.BarProcCancCFDI.Image = Global.SGT_Transport.My.Resources.Resources.cfdi6
        Me.BarProcCancCFDI.Name = "BarProcCancCFDI"
        Me.BarProcCancCFDI.ShortcutText = ""
        Me.BarProcCancCFDI.Text = "Cancelar CFDI"
        '
        'BarOEnviarcorreo
        '
        Me.BarOEnviarcorreo.Command = Me.BarSendMail
        Me.BarOEnviarcorreo.SortOrder = 2
        Me.BarOEnviarcorreo.Text = "Enviar correo"
        '
        'BarSendMail
        '
        Me.BarSendMail.Image = Global.SGT_Transport.My.Resources.Resources.correo1
        Me.BarSendMail.Name = "BarSendMail"
        Me.BarSendMail.ShortcutText = ""
        Me.BarSendMail.Text = "Imprimir"
        '
        'BarOImpresionMasiva
        '
        Me.BarOImpresionMasiva.Command = Me.BarImpresionMasiva
        Me.BarOImpresionMasiva.SortOrder = 3
        Me.BarOImpresionMasiva.Text = "Impresión masiva"
        '
        'BarImpresionMasiva
        '
        Me.BarImpresionMasiva.Image = Global.SGT_Transport.My.Resources.Resources.impresora17
        Me.BarImpresionMasiva.Name = "BarImpresionMasiva"
        Me.BarImpresionMasiva.ShortcutText = ""
        Me.BarImpresionMasiva.Text = "Impresión masiva"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.BarDescargarXMLyPDF
        Me.C1CommandLink1.SortOrder = 4
        '
        'BarDescargarXMLyPDF
        '
        Me.BarDescargarXMLyPDF.Image = Global.SGT_Transport.My.Resources.Resources.cfdi8
        Me.BarDescargarXMLyPDF.Name = "BarDescargarXMLyPDF"
        Me.BarDescargarXMLyPDF.ShortcutText = ""
        Me.BarDescargarXMLyPDF.Text = "Descargar XML y PDF"
        '
        'BarOExcel
        '
        Me.BarOExcel.SortOrder = 5
        Me.BarOExcel.Text = "Excel"
        '
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutText = ""
        Me.BarActualizar.Text = "Actualizar"
        '
        'BarFacturacion
        '
        Me.BarFacturacion.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkFFacturaXViaje, Me.LkFFacturaViajesSel, Me.LkFFacViajeParcial})
        Me.BarFacturacion.HideNonRecentLinks = False
        Me.BarFacturacion.Image = Global.SGT_Transport.My.Resources.Resources.factura5
        Me.BarFacturacion.ImageBarWidth = 60
        Me.BarFacturacion.Name = "BarFacturacion"
        Me.BarFacturacion.ShortcutText = ""
        Me.BarFacturacion.Text = "Facturación"
        Me.BarFacturacion.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.BarFacturacion.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarFacturacion.Width = 30
        '
        'LkFFacturaXViaje
        '
        Me.LkFFacturaXViaje.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFFacturaXViaje.Command = Me.BarFFacXViaje
        Me.LkFFacturaXViaje.Text = "Facturación por viaje"
        '
        'BarFFacXViaje
        '
        Me.BarFFacXViaje.Image = Global.SGT_Transport.My.Resources.Resources.camion22
        Me.BarFFacXViaje.Name = "BarFFacXViaje"
        Me.BarFFacXViaje.ShortcutText = ""
        Me.BarFFacXViaje.Text = "Facturación por viaje"
        '
        'LkFFacturaViajesSel
        '
        Me.LkFFacturaViajesSel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFFacturaViajesSel.Command = Me.BarFacViajesSel
        Me.LkFFacturaViajesSel.SortOrder = 1
        Me.LkFFacturaViajesSel.Text = "Facturación viajes seleccionados"
        '
        'BarFacViajesSel
        '
        Me.BarFacViajesSel.Image = Global.SGT_Transport.My.Resources.Resources.camion7
        Me.BarFacViajesSel.Name = "BarFacViajesSel"
        Me.BarFacViajesSel.ShortcutText = ""
        Me.BarFacViajesSel.Text = "Facturación viajes seleccionados"
        '
        'LkFFacViajeParcial
        '
        Me.LkFFacViajeParcial.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFFacViajeParcial.Command = Me.BarFacViajeParcial
        Me.LkFFacViajeParcial.SortOrder = 2
        Me.LkFFacViajeParcial.Text = "Facturación de viaje parcial"
        '
        'BarFacViajeParcial
        '
        Me.BarFacViajeParcial.Image = Global.SGT_Transport.My.Resources.Resources.camion23
        Me.BarFacViajeParcial.Name = "BarFacViajeParcial"
        Me.BarFacViajeParcial.ShortcutText = ""
        Me.BarFacViajeParcial.Text = "Facturación de viaje parcial"
        '
        'BarProcesos
        '
        Me.BarProcesos.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkProcStatusCFDI, Me.LkProcCancCFDI})
        Me.BarProcesos.HideNonRecentLinks = False
        Me.BarProcesos.Image = Global.SGT_Transport.My.Resources.Resources.desplegar13
        Me.BarProcesos.ImageBarWidth = 60
        Me.BarProcesos.Name = "BarProcesos"
        Me.BarProcesos.ShortcutText = ""
        Me.BarProcesos.Text = "Procesos"
        Me.BarProcesos.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarProcesos.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarProcesos.Width = 40
        '
        'LkProcStatusCFDI
        '
        Me.LkProcStatusCFDI.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkProcStatusCFDI.Command = Me.BarProcStatusCFDI
        Me.LkProcStatusCFDI.Text = "Estatus CFDI"
        '
        'LkProcCancCFDI
        '
        Me.LkProcCancCFDI.Command = Me.BarProcCancCFDI
        Me.LkProcCancCFDI.SortOrder = 1
        Me.LkProcCancCFDI.Text = "Cancelar CFDI"
        '
        'BarCancFactura
        '
        Me.BarCancFactura.Image = Global.SGT_Transport.My.Resources.Resources.cancel1
        Me.BarCancFactura.Name = "BarCancFactura"
        Me.BarCancFactura.ShortcutText = ""
        Me.BarCancFactura.Text = "Cancelar factura"
        '
        'BarReactivarFactura
        '
        Me.BarReactivarFactura.Image = Global.SGT_Transport.My.Resources.Resources.fin41
        Me.BarReactivarFactura.Name = "BarReactivarFactura"
        Me.BarReactivarFactura.ShortcutText = ""
        Me.BarReactivarFactura.Text = "Reactivar factura"
        '
        'BarFiltrarCliente
        '
        Me.BarFiltrarCliente.Image = Global.SGT_Transport.My.Resources.Resources.filtro21
        Me.BarFiltrarCliente.Name = "BarFiltrarCliente"
        Me.BarFiltrarCliente.ShortcutText = ""
        Me.BarFiltrarCliente.Text = "Filtrar cliente"
        '
        'BarRelacionFacturas
        '
        Me.BarRelacionFacturas.Image = Global.SGT_Transport.My.Resources.Resources.factura1
        Me.BarRelacionFacturas.Name = "BarRelacionFacturas"
        Me.BarRelacionFacturas.ShortcutText = ""
        Me.BarRelacionFacturas.Text = "Relación de facturas"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.ShowShortcut = False
        Me.BarExcel.ShowTextAsToolTip = False
        Me.BarExcel.Text = "Excel"
        '
        'LkCancFactura
        '
        Me.LkCancFactura.Command = Me.BarCancFactura
        Me.LkCancFactura.Delimiter = True
        Me.LkCancFactura.SortOrder = 4
        Me.LkCancFactura.Text = "Cancelar factura"
        '
        'BarOImprimir
        '
        Me.BarOImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.BarOImprimir.Command = Me.BarImprimir
        Me.BarOImprimir.Delimiter = True
        Me.BarOImprimir.SortOrder = 7
        Me.BarOImprimir.Text = "Imprimir"
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
        Me.C1ToolBar1.ButtonWidth = 95
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkFacturacion, Me.LkConsulta, Me.LkTimbrar, Me.LkReactivarFactura, Me.LkCancFactura, Me.LkActualizar, Me.LkExcel, Me.BarOImprimir, Me.LkOpciones, Me.LkRelacionFacturas, Me.LkFiltrarCliente, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Padding = New System.Windows.Forms.Padding(0, 9, 0, 0)
        Me.C1ToolBar1.Size = New System.Drawing.Size(1201, 68)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.Wrap = True
        Me.C1ToolBar1.WrapText = True
        '
        'LkFacturacion
        '
        Me.LkFacturacion.Command = Me.BarFacturacion
        Me.LkFacturacion.Text = "Facturación"
        '
        'LkConsulta
        '
        Me.LkConsulta.Command = Me.BarConsultar
        Me.LkConsulta.Delimiter = True
        Me.LkConsulta.SortOrder = 1
        Me.LkConsulta.Text = " Consultar"
        '
        'LkTimbrar
        '
        Me.LkTimbrar.Command = Me.BarTimbrar
        Me.LkTimbrar.Delimiter = True
        Me.LkTimbrar.SortOrder = 2
        Me.LkTimbrar.Text = "Timbrar"
        '
        'LkReactivarFactura
        '
        Me.LkReactivarFactura.Command = Me.BarReactivarFactura
        Me.LkReactivarFactura.Delimiter = True
        Me.LkReactivarFactura.SortOrder = 3
        Me.LkReactivarFactura.Text = "Reactivar factura"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.DefaultItem = True
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 5
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 6
        Me.LkExcel.Text = "Excel"
        '
        'LkOpciones
        '
        Me.LkOpciones.Command = Me.BarOpciones
        Me.LkOpciones.Delimiter = True
        Me.LkOpciones.SortOrder = 8
        Me.LkOpciones.Text = "Opciones"
        '
        'LkRelacionFacturas
        '
        Me.LkRelacionFacturas.Command = Me.BarRelacionFacturas
        Me.LkRelacionFacturas.Delimiter = True
        Me.LkRelacionFacturas.SortOrder = 9
        Me.LkRelacionFacturas.Text = "Relacionar facturas"
        '
        'LkFiltrarCliente
        '
        Me.LkFiltrarCliente.Command = Me.BarFiltrarCliente
        Me.LkFiltrarCliente.DefaultItem = True
        Me.LkFiltrarCliente.Delimiter = True
        Me.LkFiltrarCliente.SortOrder = 10
        Me.LkFiltrarCliente.Text = "Filtrar cliente"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 11
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'LtNumViajes
        '
        Me.LtNumViajes.AutoSize = True
        Me.LtNumViajes.BackColor = System.Drawing.Color.Transparent
        Me.LtNumViajes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LtNumViajes.DataType = GetType(Short)
        Me.LtNumViajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumViajes.ForeColor = System.Drawing.Color.Black
        Me.LtNumViajes.Location = New System.Drawing.Point(1053, 23)
        Me.LtNumViajes.Name = "LtNumViajes"
        Me.LtNumViajes.Size = New System.Drawing.Size(0, 17)
        Me.LtNumViajes.TabIndex = 15
        Me.LtNumViajes.Tag = Nothing
        Me.LtNumViajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LtNumViajes.TextDetached = True
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.SortOrder = 8
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM.HeaderHeight = 1
        Me.SplitM.HeaderTextOffset = 1
        Me.SplitM.Location = New System.Drawing.Point(3, 23)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.SplitP1)
        Me.SplitM.Panels.Add(Me.SplitP2)
        Me.SplitM.Size = New System.Drawing.Size(1203, 559)
        Me.SplitM.SplitterWidth = 0
        Me.SplitM.TabIndex = 17
        '
        'SplitP1
        '
        Me.SplitP1.Controls.Add(Me.C1ToolBar1)
        Me.SplitP1.Height = 84
        Me.SplitP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitP1.Name = "SplitP1"
        Me.SplitP1.Size = New System.Drawing.Size(1201, 84)
        Me.SplitP1.SizeRatio = 15.0R
        Me.SplitP1.TabIndex = 0
        '
        'SplitP2
        '
        Me.SplitP2.Controls.Add(Me.TAB1)
        Me.SplitP2.Height = 473
        Me.SplitP2.Location = New System.Drawing.Point(1, 85)
        Me.SplitP2.Name = "SplitP2"
        Me.SplitP2.Size = New System.Drawing.Size(1201, 473)
        Me.SplitP2.SizeRatio = 90.0R
        Me.SplitP2.TabIndex = 1
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
        'FrmAsigViajeBueno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 614)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.LtNumViajes)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAsigViajeBueno"
        Me.Text = "Asignacionde Viajes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.PAG1.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MnuConsultarViaje.ResumeLayout(False)
        Me.PAG2.ResumeLayout(False)
        Me.PAG4.ResumeLayout(False)
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PAG3.ResumeLayout(False)
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PAG5.ResumeLayout(False)
        CType(Me.SplitM5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM5.ResumeLayout(False)
        Me.SplitMP1.ResumeLayout(False)
        Me.SplitMP2.ResumeLayout(False)
        CType(Me.FgR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtNumViajes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.SplitP1.ResumeLayout(False)
        Me.SplitP2.ResumeLayout(False)
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents tCVE_TRACTOR As TextBox
    Friend WithEvents btnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PAG1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PAG2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarConsultar As C1.Win.C1Command.C1Command
    Friend WithEvents BarEstatusCFDI As C1.Win.C1Command.C1Command
    Friend WithEvents BarTimbrar As C1.Win.C1Command.C1Command
    Friend WithEvents BarOpciones As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents BarOImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarOEnviarcorreo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarSendMail As C1.Win.C1Command.C1Command
    Friend WithEvents BarOImpresionMasiva As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarImpresionMasiva As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDescargarXMLyPDF As C1.Win.C1Command.C1Command
    Friend WithEvents BarOExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkConsulta As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkOpciones As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarFacturacion As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents LkFFacturaXViaje As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFFacturaViajesSel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFFacViajeParcial As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFacturacion As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarFFacXViaje As C1.Win.C1Command.C1Command
    Friend WithEvents BarFacViajesSel As C1.Win.C1Command.C1Command
    Friend WithEvents BarFacViajeParcial As C1.Win.C1Command.C1Command
    Private WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Private WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents PAG3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents MnuConsultarViaje As ContextMenuStrip
    Friend WithEvents BarConsultarViaje As ToolStripMenuItem
    Friend WithEvents LtNumViajes As C1.Win.C1Input.C1Label
    Friend WithEvents BarProcesos As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents LkProcStatusCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancFactura As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkProcCancCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarProcStatusCFDI As C1.Win.C1Command.C1Command
    Friend WithEvents BarCancFactura As C1.Win.C1Command.C1Command
    Friend WithEvents BarProcCancCFDI As C1.Win.C1Command.C1Command
    Friend WithEvents BarReactivarFactura As C1.Win.C1Command.C1Command
    Friend WithEvents LkReactivarFactura As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarFiltrarCliente As C1.Win.C1Command.C1Command
    Friend WithEvents LkFiltrarCliente As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkTimbrar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkOProcStatusCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkOProcCancCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents PAG4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents PAG5 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BarRelacionFacturas As C1.Win.C1Command.C1Command
    Friend WithEvents LkRelacionFacturas As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents FgR As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitM5 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitMP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitMP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar2 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevoCob As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar5 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir5 As C1.Win.C1Command.C1CommandLink
    Private WithEvents BarNuevoCob As C1.Win.C1Command.C1Command
    Private WithEvents BarDiseñador As C1.Win.C1Command.C1Command
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Private WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir5 As C1.Win.C1Command.C1Command
    Private WithEvents BarImprimir5 As C1.Win.C1Command.C1Command
    Private WithEvents BarEliminar5 As C1.Win.C1Command.C1Command
    Friend WithEvents LkEditCob As C1.Win.C1Command.C1CommandLink
    Private WithEvents BarEditCob As C1.Win.C1Command.C1Command
End Class
