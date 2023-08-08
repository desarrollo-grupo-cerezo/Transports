<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsigValesImprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsigValesImprimir))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.cboStGastos = New C1.Win.C1Input.C1ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCVE_VIAJE2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNoViaje2 = New System.Windows.Forms.Button()
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNoViaje = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tCVE_GAS2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnGas2 = New System.Windows.Forms.Button()
        Me.tCVE_GAS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnGas1 = New System.Windows.Forms.Button()
        Me.tCORREO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chEnviaXCorreo = New C1.Win.C1Input.C1CheckBox()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CVE_DOC = New System.Data.DataColumn()
        Me.FECHA_VIAJE = New System.Data.DataColumn()
        Me.FECHA_TRASPASO = New System.Data.DataColumn()
        Me.NOMBRE_OPER = New System.Data.DataColumn()
        Me.CVE_OPER = New System.Data.DataColumn()
        Me.CVE_VIAJE = New System.Data.DataColumn()
        Me.FOLIO = New System.Data.DataColumn()
        Me.FECHA_VALE = New System.Data.DataColumn()
        Me.CVE_GAS = New System.Data.DataColumn()
        Me.LITROS = New System.Data.DataColumn()
        Me.LITROS_REALES = New System.Data.DataColumn()
        Me.P_X_LITRO = New System.Data.DataColumn()
        Me.SUBTOTAL = New System.Data.DataColumn()
        Me.IVA = New System.Data.DataColumn()
        Me.IPES = New System.Data.DataColumn()
        Me.IMPORTE = New System.Data.DataColumn()
        Me.FACTURA = New System.Data.DataColumn()
        Me.ST_VALES = New System.Data.DataColumn()
        Me.DESCR = New System.Data.DataColumn()
        Me.CVE_TRACTOR = New System.Data.DataColumn()
        Me.FF1 = New System.Data.DataColumn()
        Me.FF2 = New System.Data.DataColumn()
        Me.CVE_VIAJE1 = New System.Data.DataColumn()
        Me.CVE_VIAJE2 = New System.Data.DataColumn()
        Me.CVE_STATUS1 = New System.Data.DataColumn()
        Me.CVE_STATUS2 = New System.Data.DataColumn()
        Me.ST_GASTOS1 = New System.Data.DataColumn()
        Me.CVE_GAS11 = New System.Data.DataColumn()
        Me.CVE_GAS1 = New System.Data.DataColumn()
        Me.ST_GASTOS2 = New System.Data.DataColumn()
        Me.CVE_OPER1 = New System.Data.DataColumn()
        Me.CVE_OPER2 = New System.Data.DataColumn()
        Me.TCVE_OPER2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnOper2 = New System.Windows.Forms.Button()
        Me.TCVE_OPER1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnOper1 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chEnviaXCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(506, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'cboStGastos
        '
        Me.cboStGastos.AcceptsTab = True
        Me.cboStGastos.AllowSpinLoop = False
        Me.cboStGastos.AutoChangePosition = False
        Me.cboStGastos.AutoOpen = True
        Me.cboStGastos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboStGastos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboStGastos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboStGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStGastos.GapHeight = 0
        Me.cboStGastos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboStGastos.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
        Me.cboStGastos.ItemsDisplayMember = ""
        Me.cboStGastos.ItemsValueMember = ""
        Me.cboStGastos.Location = New System.Drawing.Point(117, 325)
        Me.cboStGastos.MaxDropDownItems = 15
        Me.cboStGastos.Name = "cboStGastos"
        Me.cboStGastos.ShowFocusRectangle = True
        Me.cboStGastos.Size = New System.Drawing.Size(166, 19)
        Me.cboStGastos.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboStGastos.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboStGastos.TabIndex = 9
        Me.cboStGastos.Tag = Nothing
        Me.cboStGastos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboStGastos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 245
        Me.Label8.Text = "Estatus gasto"
        '
        'cboStatus
        '
        Me.cboStatus.AcceptsTab = True
        Me.cboStatus.AllowSpinLoop = False
        Me.cboStatus.AutoChangePosition = False
        Me.cboStatus.AutoOpen = True
        Me.cboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.GapHeight = 0
        Me.cboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboStatus.ItemsDisplayMember = ""
        Me.cboStatus.ItemsValueMember = ""
        Me.cboStatus.Location = New System.Drawing.Point(117, 293)
        Me.cboStatus.MaxDropDownItems = 15
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.ShowFocusRectangle = True
        Me.cboStatus.Size = New System.Drawing.Size(299, 19)
        Me.cboStatus.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboStatus.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboStatus.TabIndex = 8
        Me.cboStatus.Tag = Nothing
        Me.cboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(206, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 15)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Rango de viajes"
        '
        'tCVE_VIAJE2
        '
        Me.tCVE_VIAJE2.AcceptsReturn = True
        Me.tCVE_VIAJE2.AcceptsTab = True
        Me.tCVE_VIAJE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE2.Location = New System.Drawing.Point(299, 131)
        Me.tCVE_VIAJE2.Name = "tCVE_VIAJE2"
        Me.tCVE_VIAJE2.Size = New System.Drawing.Size(117, 21)
        Me.tCVE_VIAJE2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(271, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 15)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "al"
        '
        'btnNoViaje2
        '
        Me.btnNoViaje2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNoViaje2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoViaje2.Image = CType(resources.GetObject("btnNoViaje2.Image"), System.Drawing.Image)
        Me.btnNoViaje2.Location = New System.Drawing.Point(416, 130)
        Me.btnNoViaje2.Name = "btnNoViaje2"
        Me.btnNoViaje2.Size = New System.Drawing.Size(24, 24)
        Me.btnNoViaje2.TabIndex = 240
        Me.btnNoViaje2.UseVisualStyleBackColor = True
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(117, 131)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(117, 21)
        Me.tCVE_VIAJE.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(90, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 15)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Del"
        '
        'btnNoViaje
        '
        Me.btnNoViaje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoViaje.Image = CType(resources.GetObject("btnNoViaje.Image"), System.Drawing.Image)
        Me.btnNoViaje.Location = New System.Drawing.Point(234, 130)
        Me.btnNoViaje.Name = "btnNoViaje"
        Me.btnNoViaje.Size = New System.Drawing.Size(24, 24)
        Me.btnNoViaje.TabIndex = 238
        Me.btnNoViaje.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 237
        Me.Label4.Text = "Estatus viaje"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "Rango de fechas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(271, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 15)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(299, 77)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 19)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(90, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 15)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(117, 77)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 19)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(231, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 254
        Me.Label9.Text = "Gasolineras"
        '
        'tCVE_GAS2
        '
        Me.tCVE_GAS2.AcceptsReturn = True
        Me.tCVE_GAS2.AcceptsTab = True
        Me.tCVE_GAS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GAS2.Location = New System.Drawing.Point(299, 188)
        Me.tCVE_GAS2.Name = "tCVE_GAS2"
        Me.tCVE_GAS2.Size = New System.Drawing.Size(117, 21)
        Me.tCVE_GAS2.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(271, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 15)
        Me.Label10.TabIndex = 253
        Me.Label10.Text = "al"
        '
        'BtnGas2
        '
        Me.BtnGas2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnGas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGas2.Image = CType(resources.GetObject("BtnGas2.Image"), System.Drawing.Image)
        Me.BtnGas2.Location = New System.Drawing.Point(416, 187)
        Me.BtnGas2.Name = "BtnGas2"
        Me.BtnGas2.Size = New System.Drawing.Size(24, 24)
        Me.BtnGas2.TabIndex = 252
        Me.BtnGas2.UseVisualStyleBackColor = True
        '
        'tCVE_GAS
        '
        Me.tCVE_GAS.AcceptsReturn = True
        Me.tCVE_GAS.AcceptsTab = True
        Me.tCVE_GAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GAS.Location = New System.Drawing.Point(117, 188)
        Me.tCVE_GAS.Name = "tCVE_GAS"
        Me.tCVE_GAS.Size = New System.Drawing.Size(117, 21)
        Me.tCVE_GAS.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(90, 190)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 15)
        Me.Label11.TabIndex = 251
        Me.Label11.Text = "Del"
        '
        'BtnGas1
        '
        Me.BtnGas1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnGas1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGas1.Image = CType(resources.GetObject("BtnGas1.Image"), System.Drawing.Image)
        Me.BtnGas1.Location = New System.Drawing.Point(234, 187)
        Me.BtnGas1.Name = "BtnGas1"
        Me.BtnGas1.Size = New System.Drawing.Size(24, 24)
        Me.BtnGas1.TabIndex = 250
        Me.BtnGas1.UseVisualStyleBackColor = True
        '
        'tCORREO
        '
        Me.tCORREO.AcceptsReturn = True
        Me.tCORREO.AcceptsTab = True
        Me.tCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREO.Location = New System.Drawing.Point(117, 354)
        Me.tCORREO.Name = "tCORREO"
        Me.tCORREO.Size = New System.Drawing.Size(351, 21)
        Me.tCORREO.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(72, 357)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 257
        Me.Label12.Text = "Correo"
        '
        'chEnviaXCorreo
        '
        Me.chEnviaXCorreo.BackColor = System.Drawing.Color.Transparent
        Me.chEnviaXCorreo.BorderColor = System.Drawing.Color.Transparent
        Me.chEnviaXCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chEnviaXCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chEnviaXCorreo.ForeColor = System.Drawing.Color.Black
        Me.chEnviaXCorreo.Location = New System.Drawing.Point(117, 392)
        Me.chEnviaXCorreo.Name = "chEnviaXCorreo"
        Me.chEnviaXCorreo.Padding = New System.Windows.Forms.Padding(1)
        Me.chEnviaXCorreo.Size = New System.Drawing.Size(104, 24)
        Me.chEnviaXCorreo.TabIndex = 11
        Me.chEnviaXCorreo.Text = "Envia x correo"
        Me.chEnviaXCorreo.UseVisualStyleBackColor = True
        Me.chEnviaXCorreo.Value = "False"
        Me.chEnviaXCorreo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = """"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_DOC, Me.FECHA_VIAJE, Me.FECHA_TRASPASO, Me.NOMBRE_OPER, Me.CVE_OPER, Me.CVE_VIAJE, Me.FOLIO, Me.FECHA_VALE, Me.CVE_GAS, Me.LITROS, Me.LITROS_REALES, Me.P_X_LITRO, Me.SUBTOTAL, Me.IVA, Me.IPES, Me.IMPORTE, Me.FACTURA, Me.ST_VALES, Me.DESCR, Me.CVE_TRACTOR, Me.FF1, Me.FF2, Me.CVE_VIAJE1, Me.CVE_VIAJE2, Me.CVE_STATUS1, Me.CVE_STATUS2, Me.ST_GASTOS1, Me.CVE_GAS11, Me.CVE_GAS1, Me.ST_GASTOS2, Me.CVE_OPER1, Me.CVE_OPER2})
        Me.DataTable1.TableName = "Table1"
        '
        'CVE_DOC
        '
        Me.CVE_DOC.ColumnName = "CVE_DOC"
        '
        'FECHA_VIAJE
        '
        Me.FECHA_VIAJE.ColumnName = "FECHA_VIAJE"
        Me.FECHA_VIAJE.DataType = GetType(Date)
        '
        'FECHA_TRASPASO
        '
        Me.FECHA_TRASPASO.ColumnName = "FECHA_TRASPASO"
        '
        'NOMBRE_OPER
        '
        Me.NOMBRE_OPER.ColumnName = "NOMBRE_OPER"
        Me.NOMBRE_OPER.DefaultValue = ""
        '
        'CVE_OPER
        '
        Me.CVE_OPER.ColumnName = "CVE_OPER"
        Me.CVE_OPER.DataType = GetType(Integer)
        '
        'CVE_VIAJE
        '
        Me.CVE_VIAJE.ColumnName = "CVE_VIAJE"
        '
        'FOLIO
        '
        Me.FOLIO.ColumnName = "FOLIO"
        '
        'FECHA_VALE
        '
        Me.FECHA_VALE.ColumnName = "FECHA_VALE"
        Me.FECHA_VALE.DataType = GetType(Date)
        '
        'CVE_GAS
        '
        Me.CVE_GAS.ColumnName = "CVE_GAS"
        '
        'LITROS
        '
        Me.LITROS.ColumnName = "LITROS"
        Me.LITROS.DataType = GetType(Decimal)
        '
        'LITROS_REALES
        '
        Me.LITROS_REALES.ColumnName = "LITROS_REALES"
        Me.LITROS_REALES.DataType = GetType(Decimal)
        '
        'P_X_LITRO
        '
        Me.P_X_LITRO.ColumnName = "P_X_LITRO"
        Me.P_X_LITRO.DataType = GetType(Decimal)
        '
        'SUBTOTAL
        '
        Me.SUBTOTAL.ColumnName = "SUBTOTAL"
        Me.SUBTOTAL.DataType = GetType(Decimal)
        '
        'IVA
        '
        Me.IVA.ColumnName = "IVA"
        Me.IVA.DataType = GetType(Decimal)
        '
        'IPES
        '
        Me.IPES.ColumnName = "IEPS"
        Me.IPES.DataType = GetType(Decimal)
        '
        'IMPORTE
        '
        Me.IMPORTE.ColumnName = "IMPORTE"
        Me.IMPORTE.DataType = GetType(Decimal)
        '
        'FACTURA
        '
        Me.FACTURA.ColumnName = "FACTURA"
        '
        'ST_VALES
        '
        Me.ST_VALES.ColumnName = "ST_VALES"
        '
        'DESCR
        '
        Me.DESCR.ColumnName = "DESCR"
        '
        'CVE_TRACTOR
        '
        Me.CVE_TRACTOR.ColumnName = "CVE_TRACTOR"
        '
        'FF1
        '
        Me.FF1.ColumnName = "F1"
        '
        'FF2
        '
        Me.FF2.Caption = "F2"
        Me.FF2.ColumnName = "F2"
        '
        'CVE_VIAJE1
        '
        Me.CVE_VIAJE1.ColumnName = "CVE_VIAJE1"
        '
        'CVE_VIAJE2
        '
        Me.CVE_VIAJE2.ColumnName = "CVE_VIAJE2"
        '
        'CVE_STATUS1
        '
        Me.CVE_STATUS1.ColumnName = "CVE_STATUS1"
        '
        'CVE_STATUS2
        '
        Me.CVE_STATUS2.ColumnName = "CVE_STATUS2"
        '
        'ST_GASTOS1
        '
        Me.ST_GASTOS1.ColumnName = "ST_GASTOS1"
        '
        'CVE_GAS11
        '
        Me.CVE_GAS11.ColumnName = "CVE_GAS1"
        '
        'CVE_GAS1
        '
        Me.CVE_GAS1.ColumnName = "CVE_GAS2"
        '
        'ST_GASTOS2
        '
        Me.ST_GASTOS2.ColumnName = "ST_GASTOS2"
        '
        'CVE_OPER1
        '
        Me.CVE_OPER1.Caption = "CVE_OPER1"
        Me.CVE_OPER1.ColumnName = "CVE_OPER1"
        Me.CVE_OPER1.DataType = GetType(Integer)
        '
        'CVE_OPER2
        '
        Me.CVE_OPER2.ColumnName = "CVE_OPER2"
        Me.CVE_OPER2.DataType = GetType(Integer)
        '
        'TCVE_OPER2
        '
        Me.TCVE_OPER2.AcceptsReturn = True
        Me.TCVE_OPER2.AcceptsTab = True
        Me.TCVE_OPER2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER2.Location = New System.Drawing.Point(299, 247)
        Me.TCVE_OPER2.Name = "TCVE_OPER2"
        Me.TCVE_OPER2.Size = New System.Drawing.Size(117, 21)
        Me.TCVE_OPER2.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(271, 249)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 15)
        Me.Label13.TabIndex = 265
        Me.Label13.Text = "al"
        '
        'BtnOper2
        '
        Me.BtnOper2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnOper2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper2.Image = CType(resources.GetObject("BtnOper2.Image"), System.Drawing.Image)
        Me.BtnOper2.Location = New System.Drawing.Point(416, 246)
        Me.BtnOper2.Name = "BtnOper2"
        Me.BtnOper2.Size = New System.Drawing.Size(24, 24)
        Me.BtnOper2.TabIndex = 264
        Me.BtnOper2.UseVisualStyleBackColor = True
        '
        'TCVE_OPER1
        '
        Me.TCVE_OPER1.AcceptsReturn = True
        Me.TCVE_OPER1.AcceptsTab = True
        Me.TCVE_OPER1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER1.Location = New System.Drawing.Point(117, 247)
        Me.TCVE_OPER1.Name = "TCVE_OPER1"
        Me.TCVE_OPER1.Size = New System.Drawing.Size(117, 21)
        Me.TCVE_OPER1.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(90, 249)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 15)
        Me.Label14.TabIndex = 263
        Me.Label14.Text = "Del"
        '
        'BtnOper1
        '
        Me.BtnOper1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnOper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper1.Image = CType(resources.GetObject("BtnOper1.Image"), System.Drawing.Image)
        Me.BtnOper1.Location = New System.Drawing.Point(234, 246)
        Me.BtnOper1.Name = "BtnOper1"
        Me.BtnOper1.Size = New System.Drawing.Size(24, 24)
        Me.BtnOper1.TabIndex = 262
        Me.BtnOper1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(228, 223)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 266
        Me.Label15.Text = "Operadores"
        '
        'frmAsigValesImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 446)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TCVE_OPER2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BtnOper2)
        Me.Controls.Add(Me.TCVE_OPER1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtnOper1)
        Me.Controls.Add(Me.chEnviaXCorreo)
        Me.Controls.Add(Me.tCORREO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tCVE_GAS2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BtnGas2)
        Me.Controls.Add(Me.tCVE_GAS)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnGas1)
        Me.Controls.Add(Me.cboStGastos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tCVE_VIAJE2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnNoViaje2)
        Me.Controls.Add(Me.tCVE_VIAJE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnNoViaje)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsigValesImprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir vales de combustible"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chEnviaXCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents cboStGastos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboStatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tCVE_VIAJE2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnNoViaje2 As Button
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnNoViaje As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents tCVE_GAS2 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnGas2 As Button
    Friend WithEvents tCVE_GAS As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnGas1 As Button
    Friend WithEvents tCORREO As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chEnviaXCorreo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents CVE_DOC As DataColumn
    Friend WithEvents FECHA_VIAJE As DataColumn
    Friend WithEvents FECHA_TRASPASO As DataColumn
    Friend WithEvents NOMBRE_OPER As DataColumn
    Friend WithEvents CVE_OPER As DataColumn
    Friend WithEvents CVE_VIAJE As DataColumn
    Friend WithEvents FOLIO As DataColumn
    Friend WithEvents FECHA_VALE As DataColumn
    Friend WithEvents CVE_GAS As DataColumn
    Friend WithEvents LITROS As DataColumn
    Friend WithEvents LITROS_REALES As DataColumn
    Friend WithEvents P_X_LITRO As DataColumn
    Friend WithEvents SUBTOTAL As DataColumn
    Friend WithEvents IVA As DataColumn
    Friend WithEvents IPES As DataColumn
    Friend WithEvents IMPORTE As DataColumn
    Friend WithEvents FACTURA As DataColumn
    Friend WithEvents ST_VALES As DataColumn
    Friend WithEvents DESCR As DataColumn
    Friend WithEvents CVE_TRACTOR As DataColumn
    Friend WithEvents FF1 As DataColumn
    Friend WithEvents FF2 As DataColumn
    Friend WithEvents CVE_VIAJE1 As DataColumn
    Friend WithEvents CVE_VIAJE2 As DataColumn
    Friend WithEvents CVE_STATUS1 As DataColumn
    Friend WithEvents CVE_STATUS2 As DataColumn
    Friend WithEvents ST_GASTOS1 As DataColumn
    Friend WithEvents CVE_GAS11 As DataColumn
    Friend WithEvents CVE_GAS1 As DataColumn
    Friend WithEvents ST_GASTOS2 As DataColumn
    Friend WithEvents Label15 As Label
    Friend WithEvents TCVE_OPER2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BtnOper2 As Button
    Friend WithEvents TCVE_OPER1 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnOper1 As Button
    Friend WithEvents CVE_OPER1 As DataColumn
    Friend WithEvents CVE_OPER2 As DataColumn
End Class
