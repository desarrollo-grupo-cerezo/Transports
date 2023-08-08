<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsigGastosImprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsigGastosImprimir))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnNoViaje = New System.Windows.Forms.Button()
        Me.tCVE_VIAJE2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnNoViaje2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtStatus = New System.Windows.Forms.Label()
        Me.cboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.cboStGastos = New C1.Win.C1Input.C1ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chEnviaXCorreo = New C1.Win.C1Input.C1CheckBox()
        Me.tCORREO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LOper = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.C1ComboBox2 = New C1.Win.C1Input.C1ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chEnviaXCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
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
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(571, 43)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(281, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(309, 90)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(132, 90)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(211, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Rango de fechas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "Estatus viaje"
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(132, 162)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(117, 22)
        Me.tCVE_VIAJE.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(99, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Del"
        '
        'BtnNoViaje
        '
        Me.BtnNoViaje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnNoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNoViaje.Image = CType(resources.GetObject("BtnNoViaje.Image"), System.Drawing.Image)
        Me.BtnNoViaje.Location = New System.Drawing.Point(252, 162)
        Me.BtnNoViaje.Name = "BtnNoViaje"
        Me.BtnNoViaje.Size = New System.Drawing.Size(24, 23)
        Me.BtnNoViaje.TabIndex = 217
        Me.BtnNoViaje.UseVisualStyleBackColor = True
        '
        'tCVE_VIAJE2
        '
        Me.tCVE_VIAJE2.AcceptsReturn = True
        Me.tCVE_VIAJE2.AcceptsTab = True
        Me.tCVE_VIAJE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE2.Location = New System.Drawing.Point(309, 162)
        Me.tCVE_VIAJE2.Name = "tCVE_VIAJE2"
        Me.tCVE_VIAJE2.Size = New System.Drawing.Size(117, 22)
        Me.tCVE_VIAJE2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(281, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "al"
        '
        'BtnNoViaje2
        '
        Me.BtnNoViaje2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnNoViaje2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNoViaje2.Image = CType(resources.GetObject("BtnNoViaje2.Image"), System.Drawing.Image)
        Me.BtnNoViaje2.Location = New System.Drawing.Point(429, 162)
        Me.BtnNoViaje2.Name = "BtnNoViaje2"
        Me.BtnNoViaje2.Size = New System.Drawing.Size(24, 23)
        Me.BtnNoViaje2.TabIndex = 221
        Me.BtnNoViaje2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(216, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 16)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "Rango de viajes"
        '
        'LtStatus
        '
        Me.LtStatus.AutoSize = True
        Me.LtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtStatus.Location = New System.Drawing.Point(443, 217)
        Me.LtStatus.Name = "LtStatus"
        Me.LtStatus.Size = New System.Drawing.Size(35, 16)
        Me.LtStatus.TabIndex = 225
        Me.LtStatus.Text = "____"
        '
        'cboStatus
        '
        Me.cboStatus.AcceptsTab = True
        Me.cboStatus.AllowSpinLoop = False
        Me.cboStatus.AutoChangePosition = False
        Me.cboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.GapHeight = 0
        Me.cboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboStatus.ItemsDisplayMember = ""
        Me.cboStatus.ItemsValueMember = ""
        Me.cboStatus.Location = New System.Drawing.Point(132, 213)
        Me.cboStatus.MaxDropDownItems = 15
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(299, 20)
        Me.cboStatus.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboStatus.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboStatus.TabIndex = 226
        Me.cboStatus.Tag = Nothing
        Me.cboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'cboStGastos
        '
        Me.cboStGastos.AcceptsTab = True
        Me.cboStGastos.AllowSpinLoop = False
        Me.cboStGastos.AutoChangePosition = False
        Me.cboStGastos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboStGastos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboStGastos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboStGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStGastos.GapHeight = 0
        Me.cboStGastos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboStGastos.ItemsDisplayMember = ""
        Me.cboStGastos.ItemsValueMember = ""
        Me.cboStGastos.Location = New System.Drawing.Point(132, 261)
        Me.cboStGastos.MaxDropDownItems = 15
        Me.cboStGastos.Name = "cboStGastos"
        Me.cboStGastos.Size = New System.Drawing.Size(166, 20)
        Me.cboStGastos.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboStGastos.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboStGastos.TabIndex = 229
        Me.cboStGastos.Tag = Nothing
        Me.cboStGastos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboStGastos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(39, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Estatus gasto"
        '
        'chEnviaXCorreo
        '
        Me.chEnviaXCorreo.BackColor = System.Drawing.Color.Transparent
        Me.chEnviaXCorreo.BorderColor = System.Drawing.Color.Transparent
        Me.chEnviaXCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chEnviaXCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chEnviaXCorreo.ForeColor = System.Drawing.Color.Black
        Me.chEnviaXCorreo.Location = New System.Drawing.Point(127, 451)
        Me.chEnviaXCorreo.Name = "chEnviaXCorreo"
        Me.chEnviaXCorreo.Padding = New System.Windows.Forms.Padding(1)
        Me.chEnviaXCorreo.Size = New System.Drawing.Size(104, 24)
        Me.chEnviaXCorreo.TabIndex = 261
        Me.chEnviaXCorreo.Text = "Envia x correo"
        Me.chEnviaXCorreo.UseVisualStyleBackColor = True
        Me.chEnviaXCorreo.Value = "False"
        Me.chEnviaXCorreo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCORREO
        '
        Me.tCORREO.AcceptsReturn = True
        Me.tCORREO.AcceptsTab = True
        Me.tCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREO.Location = New System.Drawing.Point(132, 406)
        Me.tCORREO.Name = "tCORREO"
        Me.tCORREO.Size = New System.Drawing.Size(351, 22)
        Me.tCORREO.TabIndex = 259
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(79, 409)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 260
        Me.Label12.Text = "Correo"
        '
        'LOper
        '
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.Location = New System.Drawing.Point(210, 307)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(273, 20)
        Me.LOper.TabIndex = 266
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(132, 307)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.tCVE_OPER.TabIndex = 263
        '
        'C1ComboBox2
        '
        Me.C1ComboBox2.AllowSpinLoop = False
        Me.C1ComboBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1ComboBox2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.C1ComboBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1ComboBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.C1ComboBox2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.C1ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ComboBox2.GapHeight = 0
        Me.C1ComboBox2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.C1ComboBox2.ItemsDisplayMember = ""
        Me.C1ComboBox2.ItemsValueMember = ""
        Me.C1ComboBox2.Location = New System.Drawing.Point(132, 361)
        Me.C1ComboBox2.Name = "C1ComboBox2"
        Me.C1ComboBox2.Size = New System.Drawing.Size(166, 20)
        Me.C1ComboBox2.TabIndex = 368
        Me.C1ComboBox2.Tag = Nothing
        Me.C1ComboBox2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 363)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 370
        Me.Label9.Text = "Tipo de gasto"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(62, 310)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 16)
        Me.Label41.TabIndex = 264
        Me.Label41.Text = "Operador"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(184, 306)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(24, 23)
        Me.BtnOper.TabIndex = 265
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmAsigGastosImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 517)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.C1ComboBox2)
        Me.Controls.Add(Me.LOper)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.chEnviaXCorreo)
        Me.Controls.Add(Me.tCORREO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboStGastos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.LtStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tCVE_VIAJE2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnNoViaje2)
        Me.Controls.Add(Me.tCVE_VIAJE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnNoViaje)
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
        Me.Name = "frmAsigGastosImprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir gastos de viaje"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chEnviaXCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnNoViaje As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents tCVE_VIAJE2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnNoViaje2 As Button
    Friend WithEvents LtStatus As Label
    Friend WithEvents cboStatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents cboStGastos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chEnviaXCorreo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents tCORREO As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents LOper As Label
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents C1ComboBox2 As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label9 As Label
End Class
