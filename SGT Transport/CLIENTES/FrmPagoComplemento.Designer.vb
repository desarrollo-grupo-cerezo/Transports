<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagoComplemento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoComplemento))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDesplegar = New System.Windows.Forms.Button()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.BarraCompras = New System.Windows.Forms.MenuStrip()
        Me.barNueva = New System.Windows.Forms.ToolStripMenuItem()
        Me.barModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTimbrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelarDocumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelarPagoCFDI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarConsultaSATStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEnviarPorCorreoComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDescargarXMLYPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.BarDisenador = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraAbajo.SuspendLayout()
        Me.BarraCompras.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnDesplegar)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(724, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(313, 51)
        Me.Panel1.TabIndex = 314
        '
        'btnDesplegar
        '
        Me.btnDesplegar.Location = New System.Drawing.Point(225, 14)
        Me.btnDesplegar.Name = "btnDesplegar"
        Me.btnDesplegar.Size = New System.Drawing.Size(75, 23)
        Me.btnDesplegar.TabIndex = 309
        Me.btnDesplegar.Text = "Desplegar"
        Me.btnDesplegar.UseVisualStyleBackColor = True
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(3, 22)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 306
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(111, 22)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 308
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 15)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1051, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(203, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 313
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.Location = New System.Drawing.Point(0, 53)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 5
        Me.Fg.Rows.DefaultSize = 25
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1349, 463)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 311
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 491)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1349, 25)
        Me.BarraAbajo.TabIndex = 312
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
        'BarraCompras
        '
        Me.BarraCompras.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNueva, Me.barModificar, Me.BarTimbrar, Me.ToolStripMenuItem1, Me.barRefresh, Me.BarDisenador, Me.barSalir})
        Me.BarraCompras.Location = New System.Drawing.Point(0, 0)
        Me.BarraCompras.Name = "BarraCompras"
        Me.BarraCompras.Size = New System.Drawing.Size(1349, 53)
        Me.BarraCompras.TabIndex = 310
        Me.BarraCompras.Text = "MenuStrip1"
        '
        'barNueva
        '
        Me.barNueva.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barNueva.ForeColor = System.Drawing.Color.Black
        Me.barNueva.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNueva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNueva.Name = "barNueva"
        Me.barNueva.ShortcutKeyDisplayString = ""
        Me.barNueva.ShowShortcutKeys = False
        Me.barNueva.Size = New System.Drawing.Size(51, 49)
        Me.barNueva.Text = "Nueva"
        Me.barNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNueva.ToolTipText = "F2-Nuevo"
        '
        'barModificar
        '
        Me.barModificar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barModificar.ForeColor = System.Drawing.Color.Black
        Me.barModificar.Image = Global.SGT_Transport.My.Resources.Resources.bus5
        Me.barModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barModificar.Name = "barModificar"
        Me.barModificar.Size = New System.Drawing.Size(65, 49)
        Me.barModificar.Text = "Consulta"
        Me.barModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarTimbrar
        '
        Me.BarTimbrar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarTimbrar.ForeColor = System.Drawing.Color.Black
        Me.BarTimbrar.Image = Global.SGT_Transport.My.Resources.Resources.cfdi15
        Me.BarTimbrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTimbrar.Name = "BarTimbrar"
        Me.BarTimbrar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarTimbrar.Size = New System.Drawing.Size(58, 49)
        Me.BarTimbrar.Text = "Timbrar"
        Me.BarTimbrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarCancelarDocumento, Me.BarCancelarPagoCFDI, Me.BarConsultaSATStatus, Me.BarExcel, Me.BarEnviarPorCorreoComprobante, Me.BarDescargarXMLYPDF})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem1.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(68, 49)
        Me.ToolStripMenuItem1.Text = "Opciones"
        Me.ToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCancelarDocumento
        '
        Me.BarCancelarDocumento.Image = Global.SGT_Transport.My.Resources.Resources.cancel1
        Me.BarCancelarDocumento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelarDocumento.Name = "BarCancelarDocumento"
        Me.BarCancelarDocumento.Size = New System.Drawing.Size(250, 38)
        Me.BarCancelarDocumento.Text = "Cancelar documento"
        '
        'BarCancelarPagoCFDI
        '
        Me.BarCancelarPagoCFDI.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarCancelarPagoCFDI.ForeColor = System.Drawing.Color.Black
        Me.BarCancelarPagoCFDI.Image = Global.SGT_Transport.My.Resources.Resources.cancel8
        Me.BarCancelarPagoCFDI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelarPagoCFDI.Name = "BarCancelarPagoCFDI"
        Me.BarCancelarPagoCFDI.Size = New System.Drawing.Size(250, 38)
        Me.BarCancelarPagoCFDI.Text = "Cancelar pago CFDI"
        Me.BarCancelarPagoCFDI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarConsultaSATStatus
        '
        Me.BarConsultaSATStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarConsultaSATStatus.ForeColor = System.Drawing.Color.Black
        Me.BarConsultaSATStatus.Image = Global.SGT_Transport.My.Resources.Resources.status14
        Me.BarConsultaSATStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarConsultaSATStatus.Name = "BarConsultaSATStatus"
        Me.BarConsultaSATStatus.Size = New System.Drawing.Size(250, 38)
        Me.BarConsultaSATStatus.Text = "Consulta Estatus SAT"
        Me.BarConsultaSATStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(250, 38)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEnviarPorCorreoComprobante
        '
        Me.BarEnviarPorCorreoComprobante.Image = Global.SGT_Transport.My.Resources.Resources.correo1
        Me.BarEnviarPorCorreoComprobante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEnviarPorCorreoComprobante.Name = "BarEnviarPorCorreoComprobante"
        Me.BarEnviarPorCorreoComprobante.Size = New System.Drawing.Size(250, 38)
        Me.BarEnviarPorCorreoComprobante.Text = "Enviar por correo comprobante"
        '
        'BarDescargarXMLYPDF
        '
        Me.BarDescargarXMLYPDF.Image = Global.SGT_Transport.My.Resources.Resources.cfdi8
        Me.BarDescargarXMLYPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDescargarXMLYPDF.Name = "BarDescargarXMLYPDF"
        Me.BarDescargarXMLYPDF.Size = New System.Drawing.Size(250, 38)
        Me.BarDescargarXMLYPDF.Text = "Descargar XML y PDF"
        '
        'barRefresh
        '
        Me.barRefresh.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barRefresh.ForeColor = System.Drawing.Color.Black
        Me.barRefresh.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.barRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRefresh.Name = "barRefresh"
        Me.barRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barRefresh.Size = New System.Drawing.Size(66, 49)
        Me.barRefresh.Text = "Refrescar"
        Me.barRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 49)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "5eed13623f134001ae1d5b1e63d99857"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'BarDisenador
        '
        Me.BarDisenador.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarDisenador.ForeColor = System.Drawing.Color.Black
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDisenador.Size = New System.Drawing.Size(72, 49)
        Me.BarDisenador.Text = "Diseñador"
        Me.BarDisenador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarDisenador.Visible = False
        '
        'FrmPagoComplemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1349, 516)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraCompras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPagoComplemento"
        Me.Text = " "
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.BarraCompras.ResumeLayout(False)
        Me.BarraCompras.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDesplegar As Button
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents BarraCompras As MenuStrip
    Friend WithEvents barNueva As ToolStripMenuItem
    Friend WithEvents barModificar As ToolStripMenuItem
    Friend WithEvents barRefresh As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents BarTimbrar As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BarCancelarPagoCFDI As ToolStripMenuItem
    Friend WithEvents BarConsultaSATStatus As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarEnviarPorCorreoComprobante As ToolStripMenuItem
    Friend WithEvents BarDescargarXMLYPDF As ToolStripMenuItem
    Friend WithEvents BarCancelarDocumento As ToolStripMenuItem
    Friend WithEvents BarDisenador As ToolStripMenuItem
End Class
