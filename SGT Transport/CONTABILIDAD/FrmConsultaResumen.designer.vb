<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConsultaResumen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaResumen))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarGenPoliza = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarCopy = New C1.Win.C1Command.C1Command()
        Me.BarCarpeta = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.txClienteNombre = New System.Windows.Forms.Label()
        Me.lbEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New C1.Win.C1Input.C1ComboBox()
        Me.lbSerie = New System.Windows.Forms.Label()
        Me.CboSeries = New C1.Win.C1Input.C1ComboBox()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lbTimbrada = New System.Windows.Forms.Label()
        Me.cboTimbrada = New C1.Win.C1Input.C1ComboBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.CboEstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTimbrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarGenPoliza)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarCopy)
        Me.MenuHolder.Commands.Add(Me.BarCarpeta)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.traza4
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.ShowShortcut = False
        Me.BarDesplegar.ShowTextAsToolTip = False
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarGenPoliza
        '
        Me.BarGenPoliza.Image = Global.SGT_Transport.My.Resources.Resources.poliza6
        Me.BarGenPoliza.Name = "BarGenPoliza"
        Me.BarGenPoliza.ShortcutText = ""
        Me.BarGenPoliza.Text = "Generar poliza"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarCopy
        '
        Me.BarCopy.Image = Global.SGT_Transport.My.Resources.Resources.images3
        Me.BarCopy.ImageTransparentColor = System.Drawing.Color.White
        Me.BarCopy.Name = "BarCopy"
        Me.BarCopy.ShortcutText = ""
        Me.BarCopy.Text = "Copiar"
        '
        'BarCarpeta
        '
        Me.BarCarpeta.Image = Global.SGT_Transport.My.Resources.Resources.folder3
        Me.BarCarpeta.Name = "BarCarpeta"
        Me.BarCarpeta.ShortcutText = ""
        Me.BarCarpeta.ShowShortcut = False
        Me.BarCarpeta.ShowTextAsToolTip = False
        Me.BarCarpeta.Text = "Carpeta polizas"
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
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1193, 45)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 1
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbTimbrada)
        Me.Panel1.Controls.Add(Me.cboTimbrada)
        Me.Panel1.Controls.Add(Me.lbCliente)
        Me.Panel1.Controls.Add(Me.BtnCliente)
        Me.Panel1.Controls.Add(Me.txCliente)
        Me.Panel1.Controls.Add(Me.txClienteNombre)
        Me.Panel1.Controls.Add(Me.lbEstatus)
        Me.Panel1.Controls.Add(Me.CboEstatus)
        Me.Panel1.Controls.Add(Me.lbSerie)
        Me.Panel1.Controls.Add(Me.CboSeries)
        Me.Panel1.Controls.Add(Me.LtNUm)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(7, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(923, 85)
        Me.Panel1.TabIndex = 338
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(343, 6)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(45, 15)
        Me.lbCliente.TabIndex = 351
        Me.lbCliente.Text = "Cliente"
        '
        'BtnCliente
        '
        Me.BtnCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCliente.BackColor = System.Drawing.Color.Transparent
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCliente.Image = CType(resources.GetObject("BtnCliente.Image"), System.Drawing.Image)
        Me.BtnCliente.Location = New System.Drawing.Point(422, 28)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(24, 23)
        Me.BtnCliente.TabIndex = 3
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'txCliente
        '
        Me.txCliente.AcceptsReturn = True
        Me.txCliente.AcceptsTab = True
        Me.txCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCliente.ForeColor = System.Drawing.Color.Black
        Me.txCliente.Location = New System.Drawing.Point(346, 29)
        Me.txCliente.Name = "txCliente"
        Me.txCliente.Size = New System.Drawing.Size(70, 21)
        Me.txCliente.TabIndex = 2
        '
        'txClienteNombre
        '
        Me.txClienteNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txClienteNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txClienteNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txClienteNombre.Location = New System.Drawing.Point(452, 30)
        Me.txClienteNombre.Name = "txClienteNombre"
        Me.txClienteNombre.Size = New System.Drawing.Size(319, 20)
        Me.txClienteNombre.TabIndex = 350
        '
        'lbEstatus
        '
        Me.lbEstatus.AutoSize = True
        Me.lbEstatus.BackColor = System.Drawing.Color.Transparent
        Me.lbEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstatus.ForeColor = System.Drawing.Color.Black
        Me.lbEstatus.Location = New System.Drawing.Point(343, 56)
        Me.lbEstatus.Name = "lbEstatus"
        Me.lbEstatus.Size = New System.Drawing.Size(47, 15)
        Me.lbEstatus.TabIndex = 343
        Me.lbEstatus.Text = "Estatus"
        '
        'CboEstatus
        '
        Me.CboEstatus.AllowSpinLoop = False
        Me.CboEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboEstatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboEstatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstatus.GapHeight = 0
        Me.CboEstatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboEstatus.ItemsDisplayMember = ""
        Me.CboEstatus.ItemsValueMember = ""
        Me.CboEstatus.Location = New System.Drawing.Point(422, 54)
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(100, 19)
        Me.CboEstatus.TabIndex = 5
        Me.CboEstatus.Tag = Nothing
        Me.CboEstatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboEstatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'lbSerie
        '
        Me.lbSerie.AutoSize = True
        Me.lbSerie.BackColor = System.Drawing.Color.Transparent
        Me.lbSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSerie.ForeColor = System.Drawing.Color.Black
        Me.lbSerie.Location = New System.Drawing.Point(7, 56)
        Me.lbSerie.Name = "lbSerie"
        Me.lbSerie.Size = New System.Drawing.Size(36, 15)
        Me.lbSerie.TabIndex = 341
        Me.lbSerie.Text = "Serie"
        '
        'CboSeries
        '
        Me.CboSeries.AllowSpinLoop = False
        Me.CboSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSeries.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSeries.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSeries.GapHeight = 0
        Me.CboSeries.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSeries.ItemsDisplayMember = ""
        Me.CboSeries.ItemsValueMember = ""
        Me.CboSeries.Location = New System.Drawing.Point(55, 56)
        Me.CboSeries.Name = "CboSeries"
        Me.CboSeries.Size = New System.Drawing.Size(100, 19)
        Me.CboSeries.TabIndex = 4
        Me.CboSeries.Tag = Nothing
        Me.CboSeries.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSeries.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtNUm
        '
        Me.LtNUm.AutoSize = True
        Me.LtNUm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNUm.Location = New System.Drawing.Point(582, 56)
        Me.LtNUm.Name = "LtNUm"
        Me.LtNUm.Size = New System.Drawing.Size(63, 15)
        Me.LtNUm.TabIndex = 339
        Me.LtNUm.Text = "________"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Rango de fechas"
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
        Me.F1.Location = New System.Drawing.Point(55, 30)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 0
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
        Me.F2.Location = New System.Drawing.Point(230, 28)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(7, 31)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(26, 15)
        Me.label2.TabIndex = 305
        Me.label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(180, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(497, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(325, 39)
        Me.C1FlexGridSearchPanel1.TabIndex = 340
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(7, 142)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(923, 294)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 341
        '
        'lbTimbrada
        '
        Me.lbTimbrada.AutoSize = True
        Me.lbTimbrada.BackColor = System.Drawing.Color.Transparent
        Me.lbTimbrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTimbrada.ForeColor = System.Drawing.Color.Black
        Me.lbTimbrada.Location = New System.Drawing.Point(164, 56)
        Me.lbTimbrada.Name = "lbTimbrada"
        Me.lbTimbrada.Size = New System.Drawing.Size(60, 15)
        Me.lbTimbrada.TabIndex = 353
        Me.lbTimbrada.Text = "Timbrada"
        '
        'cboTimbrada
        '
        Me.cboTimbrada.AllowSpinLoop = False
        Me.cboTimbrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboTimbrada.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboTimbrada.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboTimbrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTimbrada.GapHeight = 0
        Me.cboTimbrada.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboTimbrada.ItemsDisplayMember = ""
        Me.cboTimbrada.ItemsValueMember = ""
        Me.cboTimbrada.Location = New System.Drawing.Point(230, 56)
        Me.cboTimbrada.Name = "cboTimbrada"
        Me.cboTimbrada.Size = New System.Drawing.Size(100, 19)
        Me.cboTimbrada.TabIndex = 352
        Me.cboTimbrada.Tag = Nothing
        Me.cboTimbrada.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboTimbrada.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmConsultaResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 524)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmConsultaResumen"
        Me.Text = "FrmConsultaResumen"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CboEstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTimbrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarGenPoliza As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarCarpeta As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents LtNUm As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarCopy As C1.Win.C1Command.C1Command
    Friend WithEvents lbSerie As Label
    Friend WithEvents CboSeries As C1.Win.C1Input.C1ComboBox
    Friend WithEvents lbEstatus As Label
    Friend WithEvents CboEstatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents lbCliente As Label
    Friend WithEvents BtnCliente As Button
    Friend WithEvents txCliente As TextBox
    Friend WithEvents txClienteNombre As Label
    Friend WithEvents lbTimbrada As Label
    Friend WithEvents cboTimbrada As C1.Win.C1Input.C1ComboBox
End Class
