<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreOCCompra
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreOCCompra))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarGenOrdenCompra = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarTotales = New C1.Win.C1Command.C1Command()
        Me.BarOpciones = New C1.Win.C1Command.C1CommandMenu()
        Me.BarSeries = New C1.Win.C1Command.C1Command()
        Me.LkSeries = New C1.Win.C1Command.C1CommandLink()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkTotales = New C1.Win.C1Command.C1CommandLink()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkGenOrdenCompra = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.LtProv = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtEmpresa = New System.Windows.Forms.Label()
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.LtFecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtDescrLinea = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLinea = New C1.Win.C1Input.C1Button()
        Me.TLINEA = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.SplitP1.SuspendLayout()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitP2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarGenOrdenCompra)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarTotales)
        Me.MenuHolder.Commands.Add(Me.BarOpciones)
        Me.MenuHolder.Commands.Add(Me.BarSeries)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarGenOrdenCompra
        '
        Me.BarGenOrdenCompra.Image = Global.SGT_Transport.My.Resources.Resources.Ordencompra
        Me.BarGenOrdenCompra.Name = "BarGenOrdenCompra"
        Me.BarGenOrdenCompra.ShortcutText = ""
        Me.BarGenOrdenCompra.ShowShortcut = False
        Me.BarGenOrdenCompra.ShowTextAsToolTip = False
        Me.BarGenOrdenCompra.Text = "Generar orden de compra"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.ShowShortcut = False
        Me.BarExcel.ShowTextAsToolTip = False
        Me.BarExcel.Text = "Excel"
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
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarTotales
        '
        Me.BarTotales.Image = Global.SGT_Transport.My.Resources.Resources.calc1
        Me.BarTotales.Name = "BarTotales"
        Me.BarTotales.ShortcutText = ""
        Me.BarTotales.Text = "Totales"
        '
        'BarOpciones
        '
        Me.BarOpciones.HideNonRecentLinks = False
        Me.BarOpciones.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarOpciones.ImageBarWidth = 40
        Me.BarOpciones.Name = "BarOpciones"
        Me.BarOpciones.ShortcutText = ""
        Me.BarOpciones.Text = "Opciones"
        Me.BarOpciones.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarOpciones.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarOpciones.Width = 160
        '
        'BarSeries
        '
        Me.BarSeries.Image = Global.SGT_Transport.My.Resources.Resources.letras
        Me.BarSeries.Name = "BarSeries"
        Me.BarSeries.ShortcutText = ""
        Me.BarSeries.Text = "Series"
        '
        'LkSeries
        '
        Me.LkSeries.Command = Me.BarSeries
        Me.LkSeries.Delimiter = True
        Me.LkSeries.SortOrder = 4
        Me.LkSeries.Text = "Series"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1245, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(226, 38)
        Me.C1FlexGridSearchPanel1.TabIndex = 318
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 5
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 6
        Me.LkExcel.Text = "Excel"
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
        Me.C1ToolBar1.ButtonWidth = 120
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkTotales, Me.LkDesplegar, Me.LkGenOrdenCompra, Me.LkSeries, Me.LkImprimir, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1483, 46)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkTotales
        '
        Me.LkTotales.Command = Me.BarTotales
        Me.LkTotales.Delimiter = True
        Me.LkTotales.SortOrder = 1
        Me.LkTotales.Text = "Totales"
        '
        'LkDesplegar
        '
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.SortOrder = 2
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkGenOrdenCompra
        '
        Me.LkGenOrdenCompra.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGenOrdenCompra.Command = Me.BarGenOrdenCompra
        Me.LkGenOrdenCompra.Delimiter = True
        Me.LkGenOrdenCompra.NewColumn = True
        Me.LkGenOrdenCompra.SortOrder = 3
        Me.LkGenOrdenCompra.Text = "Gen. orden de compra"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 7
        Me.LkSalir.Text = " Salir"
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.Fg.Location = New System.Drawing.Point(9, 31)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(1237, 234)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 4
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsedToolTip = "Expander {0}"
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.CollapsingToolTip = "Minimizar {0}"
        Me.SplitM1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 50)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.SplitP1)
        Me.SplitM1.Panels.Add(Me.SplitP2)
        Me.SplitM1.Size = New System.Drawing.Size(1293, 548)
        Me.SplitM1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.TabIndex = 316
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitP1
        '
        Me.SplitP1.Collapsible = True
        Me.SplitP1.Controls.Add(Me.LtNombre)
        Me.SplitP1.Controls.Add(Me.LtProv)
        Me.SplitP1.Controls.Add(Me.Label8)
        Me.SplitP1.Controls.Add(Me.LtEmpresa)
        Me.SplitP1.Controls.Add(Me.C1List1)
        Me.SplitP1.Controls.Add(Me.Lt2)
        Me.SplitP1.Controls.Add(Me.LtFecha)
        Me.SplitP1.Controls.Add(Me.Label7)
        Me.SplitP1.Controls.Add(Me.Label4)
        Me.SplitP1.Controls.Add(Me.LtCVE_DOC)
        Me.SplitP1.Controls.Add(Me.Label5)
        Me.SplitP1.Controls.Add(Me.LtDescrLinea)
        Me.SplitP1.Controls.Add(Me.Label1)
        Me.SplitP1.Controls.Add(Me.BtnLinea)
        Me.SplitP1.Controls.Add(Me.TLINEA)
        Me.SplitP1.Controls.Add(Me.Label14)
        Me.SplitP1.Controls.Add(Me.Lt1)
        Me.SplitP1.Controls.Add(Me.Lt)
        Me.SplitP1.Controls.Add(Me.F2)
        Me.SplitP1.Controls.Add(Me.F1)
        Me.SplitP1.Controls.Add(Me.Label2)
        Me.SplitP1.Controls.Add(Me.Label3)
        Me.SplitP1.Height = 179
        Me.SplitP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitP1.Name = "SplitP1"
        Me.SplitP1.Size = New System.Drawing.Size(1291, 172)
        Me.SplitP1.SizeRatio = 33.026R
        Me.SplitP1.TabIndex = 0
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(160, 139)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(338, 22)
        Me.LtNombre.TabIndex = 358
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtProv
        '
        Me.LtProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtProv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtProv.Location = New System.Drawing.Point(95, 139)
        Me.LtProv.Name = "LtProv"
        Me.LtProv.Size = New System.Drawing.Size(59, 22)
        Me.LtProv.TabIndex = 357
        Me.LtProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(35, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 356
        Me.Label8.Text = "Nombre"
        '
        'LtEmpresa
        '
        Me.LtEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEmpresa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtEmpresa.Location = New System.Drawing.Point(95, 48)
        Me.LtEmpresa.Name = "LtEmpresa"
        Me.LtEmpresa.Size = New System.Drawing.Size(403, 22)
        Me.LtEmpresa.TabIndex = 355
        Me.LtEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione empresa"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(699, 1)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(300, 169)
        Me.C1List1.TabIndex = 354
        Me.C1List1.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Blue
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(990, 64)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(0, 17)
        Me.Lt2.TabIndex = 330
        '
        'LtFecha
        '
        Me.LtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFecha.Location = New System.Drawing.Point(276, 81)
        Me.LtFecha.Name = "LtFecha"
        Me.LtFecha.Size = New System.Drawing.Size(113, 24)
        Me.LtFecha.TabIndex = 329
        Me.LtFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(229, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 16)
        Me.Label7.TabIndex = 328
        Me.Label7.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(547, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 327
        Me.Label4.Text = "Rango de fechas"
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(97, 14)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(183, 24)
        Me.LtCVE_DOC.TabIndex = 326
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 325
        Me.Label5.Text = "Documento"
        '
        'LtDescrLinea
        '
        Me.LtDescrLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtDescrLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescrLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescrLinea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDescrLinea.Location = New System.Drawing.Point(95, 109)
        Me.LtDescrLinea.Name = "LtDescrLinea"
        Me.LtDescrLinea.Size = New System.Drawing.Size(403, 22)
        Me.LtDescrLinea.TabIndex = 324
        Me.LtDescrLinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 323
        Me.Label1.Text = "Descripción"
        '
        'BtnLinea
        '
        Me.BtnLinea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnLinea.Image = CType(resources.GetObject("BtnLinea.Image"), System.Drawing.Image)
        Me.BtnLinea.Location = New System.Drawing.Point(186, 79)
        Me.BtnLinea.Name = "BtnLinea"
        Me.BtnLinea.Size = New System.Drawing.Size(22, 22)
        Me.BtnLinea.TabIndex = 322
        Me.BtnLinea.UseVisualStyleBackColor = True
        Me.BtnLinea.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TLINEA
        '
        Me.TLINEA.AcceptsReturn = True
        Me.TLINEA.AcceptsTab = True
        Me.TLINEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLINEA.ForeColor = System.Drawing.Color.Black
        Me.TLINEA.Location = New System.Drawing.Point(95, 79)
        Me.TLINEA.Name = "TLINEA"
        Me.TLINEA.Size = New System.Drawing.Size(88, 22)
        Me.TLINEA.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(51, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 321
        Me.Label14.Text = "Linea"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(504, 144)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(120, 17)
        Me.Lt1.TabIndex = 319
        Me.Lt1.Text = "______________"
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.BackColor = System.Drawing.Color.Transparent
        Me.Lt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.ForeColor = System.Drawing.Color.Black
        Me.Lt.Location = New System.Drawing.Point(29, 48)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(62, 16)
        Me.Lt.TabIndex = 177
        Me.Lt.Text = "Empresa"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(550, 96)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 3
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
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(550, 56)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 2
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(530, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "al"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(521, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Del"
        '
        'SplitP2
        '
        Me.SplitP2.Controls.Add(Me.Fg)
        Me.SplitP2.Height = 363
        Me.SplitP2.Location = New System.Drawing.Point(1, 184)
        Me.SplitP2.Name = "SplitP2"
        Me.SplitP2.Size = New System.Drawing.Size(1291, 363)
        Me.SplitP2.SizeRatio = 80.0R
        Me.SplitP2.TabIndex = 1
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "db30f67c08244936874a5a3252dbab8f"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmPreOCCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1483, 621)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPreOCCompra"
        Me.Text = "Pre-Oreden de compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.SplitP1.ResumeLayout(False)
        Me.SplitP1.PerformLayout()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitP2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarGenOrdenCompra As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkGenOrdenCompra As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Lt As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Lt1 As Label
    Friend WithEvents LtDescrLinea As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLinea As C1.Win.C1Input.C1Button
    Friend WithEvents TLINEA As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents LtFecha As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BarTotales As C1.Win.C1Command.C1Command
    Friend WithEvents LkTotales As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Lt2 As Label
    Friend WithEvents BarOpciones As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents LkSeries As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarSeries As C1.Win.C1Command.C1Command
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents LtEmpresa As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents LtProv As Label
    Friend WithEvents Label8 As Label
End Class
