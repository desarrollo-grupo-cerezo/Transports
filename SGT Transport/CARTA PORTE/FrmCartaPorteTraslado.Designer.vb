<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartaPorteTraslado
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartaPorteTraslado))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtCompras = New System.Windows.Forms.Label()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDesplegar = New System.Windows.Forms.Button()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarEstatusCFDI = New C1.Win.C1Command.C1Command()
        Me.BarTimbrar = New C1.Win.C1Command.C1Command()
        Me.BarOpciones = New C1.Win.C1Command.C1CommandMenu()
        Me.BarOImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarOEnviarcorreo = New C1.Win.C1Command.C1CommandLink()
        Me.BarSendMail = New C1.Win.C1Command.C1Command()
        Me.BarOImpresionMasiva = New C1.Win.C1Command.C1CommandLink()
        Me.BarImpresionMasiva = New C1.Win.C1Command.C1Command()
        Me.BarODescargarXMLyPDF = New C1.Win.C1Command.C1CommandLink()
        Me.BarDescargarXMLyPDF = New C1.Win.C1Command.C1Command()
        Me.BarOExcel = New C1.Win.C1Command.C1CommandLink()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarODiseñador = New C1.Win.C1Command.C1CommandLink()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkEstatusCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.LkTimbrar = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkOpciones = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraAbajo.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.Split3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(32, 37)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(391, 118)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'LtCompras
        '
        Me.LtCompras.AutoSize = True
        Me.LtCompras.Font = New System.Drawing.Font("Arial Black", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCompras.Location = New System.Drawing.Point(587, 417)
        Me.LtCompras.Name = "LtCompras"
        Me.LtCompras.Size = New System.Drawing.Size(55, 27)
        Me.LtCompras.TabIndex = 11
        Me.LtCompras.Text = "TEA"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 5)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1345, 25)
        Me.BarraAbajo.TabIndex = 12
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
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1148, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(162, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 13
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "11f7be6644e24c229a9263ccafa1406b"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnDesplegar)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(825, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(313, 51)
        Me.Panel1.TabIndex = 309
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
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarNuevo)
        Me.MenuHolder.Commands.Add(Me.BarEdit)
        Me.MenuHolder.Commands.Add(Me.BarEstatusCFDI)
        Me.MenuHolder.Commands.Add(Me.BarTimbrar)
        Me.MenuHolder.Commands.Add(Me.BarOpciones)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarSendMail)
        Me.MenuHolder.Commands.Add(Me.BarDescargarXMLyPDF)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarImpresionMasiva)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador)
        Me.MenuHolder.Owner = Me
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.bus5
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Consultar"
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
        Me.BarTimbrar.Image = Global.SGT_Transport.My.Resources.Resources.cfdi20_e
        Me.BarTimbrar.Name = "BarTimbrar"
        Me.BarTimbrar.ShortcutText = ""
        Me.BarTimbrar.Text = "Timbrar"
        '
        'BarOpciones
        '
        Me.BarOpciones.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.BarOImprimir, Me.BarOEnviarcorreo, Me.BarOImpresionMasiva, Me.BarODescargarXMLyPDF, Me.BarOExcel, Me.BarODiseñador})
        Me.BarOpciones.HideNonRecentLinks = False
        Me.BarOpciones.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarOpciones.ImageBarWidth = 60
        Me.BarOpciones.Name = "BarOpciones"
        Me.BarOpciones.ShortcutText = ""
        Me.BarOpciones.Text = "Opciones"
        Me.BarOpciones.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.BarOpciones.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarOpciones.Width = 40
        '
        'BarOImprimir
        '
        Me.BarOImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.BarOImprimir.Command = Me.BarImprimir
        Me.BarOImprimir.Delimiter = True
        Me.BarOImprimir.Text = "Imprimir"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarOEnviarcorreo
        '
        Me.BarOEnviarcorreo.Command = Me.BarSendMail
        Me.BarOEnviarcorreo.SortOrder = 1
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
        Me.BarOImpresionMasiva.SortOrder = 2
        Me.BarOImpresionMasiva.Text = "Impresión masiva"
        '
        'BarImpresionMasiva
        '
        Me.BarImpresionMasiva.Image = Global.SGT_Transport.My.Resources.Resources.impresora17
        Me.BarImpresionMasiva.Name = "BarImpresionMasiva"
        Me.BarImpresionMasiva.ShortcutText = ""
        Me.BarImpresionMasiva.Text = "Impresión masiva"
        '
        'BarODescargarXMLyPDF
        '
        Me.BarODescargarXMLyPDF.Command = Me.BarDescargarXMLyPDF
        Me.BarODescargarXMLyPDF.SortOrder = 3
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
        Me.BarOExcel.Command = Me.BarExcel
        Me.BarOExcel.SortOrder = 4
        Me.BarOExcel.Text = "Excel"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarODiseñador
        '
        Me.BarODiseñador.Command = Me.BarDiseñador
        Me.BarODiseñador.SortOrder = 5
        Me.BarODiseñador.Text = "Diseñador"
        '
        'BarDiseñador
        '
        Me.BarDiseñador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador.Name = "BarDiseñador"
        Me.BarDiseñador.ShortcutText = ""
        Me.BarDiseñador.Text = "Diseñador"
        '
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutText = ""
        Me.BarActualizar.Text = "Actualizar"
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
        Me.C1ToolBar1.ButtonWidth = 96
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkEstatusCFDI, Me.LkTimbrar, Me.LkActualizar, Me.LkOpciones, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1345, 56)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.BarNuevo
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.Text = "Nuevo"
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.BarEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Consultar"
        '
        'LkEstatusCFDI
        '
        Me.LkEstatusCFDI.Command = Me.BarEstatusCFDI
        Me.LkEstatusCFDI.Delimiter = True
        Me.LkEstatusCFDI.SortOrder = 2
        Me.LkEstatusCFDI.Text = "Estatus CFDI"
        '
        'LkTimbrar
        '
        Me.LkTimbrar.Command = Me.BarTimbrar
        Me.LkTimbrar.Delimiter = True
        Me.LkTimbrar.SortOrder = 3
        Me.LkTimbrar.Text = "Timbrar"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.DefaultItem = True
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 4
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkOpciones
        '
        Me.LkOpciones.Command = Me.BarOpciones
        Me.LkOpciones.SortOrder = 5
        Me.LkOpciones.Text = "Opciones"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 6
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM1.HeaderHeight = 0
        Me.SplitM1.LineBelowHeader = False
        Me.SplitM1.Location = New System.Drawing.Point(12, 30)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.Split1)
        Me.SplitM1.Panels.Add(Me.Split2)
        Me.SplitM1.Panels.Add(Me.Split3)
        Me.SplitM1.Size = New System.Drawing.Size(1347, 327)
        Me.SplitM1.SplitterWidth = 1
        Me.SplitM1.TabIndex = 311
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Split1.Controls.Add(Me.Panel1)
        Me.Split1.Controls.Add(Me.C1ToolBar1)
        Me.Split1.Height = 49
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.MinHeight = 10
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1345, 49)
        Me.Split1.SizeRatio = 15.0R
        Me.Split1.TabIndex = 0
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 244
        Me.Split2.Location = New System.Drawing.Point(1, 51)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1345, 244)
        Me.Split2.SizeRatio = 89.051R
        Me.Split2.TabIndex = 1
        '
        'Split3
        '
        Me.Split3.Controls.Add(Me.BarraAbajo)
        Me.Split3.Height = 30
        Me.Split3.Location = New System.Drawing.Point(1, 296)
        Me.Split3.MinHeight = 2
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1345, 30)
        Me.Split3.SizeRatio = 10.0R
        Me.Split3.TabIndex = 2
        '
        'FrmCartaPorteTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1521, 518)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.LtCompras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCartaPorteTraslado"
        Me.Text = "Carta porte traslado"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split2.ResumeLayout(False)
        Me.Split3.ResumeLayout(False)
        Me.Split3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtCompras As Label
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDesplegar As Button
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarEstatusCFDI As C1.Win.C1Command.C1Command
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Private WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkEstatusCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarTimbrar As C1.Win.C1Command.C1Command
    Friend WithEvents LkTimbrar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarOpciones As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents BarOImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarOEnviarcorreo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarSendMail As C1.Win.C1Command.C1Command
    Friend WithEvents BarOExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents LkOpciones As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarODescargarXMLyPDF As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDescargarXMLyPDF As C1.Win.C1Command.C1Command
    Friend WithEvents BarOImpresionMasiva As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarImpresionMasiva As C1.Win.C1Command.C1Command
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarODiseñador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDiseñador As C1.Win.C1Command.C1Command
End Class
