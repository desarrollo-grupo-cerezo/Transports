<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConciValesComEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConciValesComEdit))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TObs = New System.Windows.Forms.TextBox()
        Me.L12 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.LtIVA = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtIEPS = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnGas = New System.Windows.Forms.Button()
        Me.LtGas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCVE_GAS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FECHA = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtSubtotal = New System.Windows.Forms.Label()
        Me.LtViaje = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TLTS_REALES = New C1.Win.C1Input.C1TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TPRECIO_X_LTS = New C1.Win.C1Input.C1TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LtLts_Inic = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtFactorIEPS = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TFOLIO = New System.Windows.Forms.TextBox()
        Me.btnAnterior = New C1.Win.C1Input.C1Button()
        Me.btnInicial = New C1.Win.C1Input.C1Button()
        Me.btnSiguiente = New C1.Win.C1Input.C1Button()
        Me.btnFinal = New C1.Win.C1Input.C1Button()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLTS_REALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPRECIO_X_LTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSiguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar {F3}"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarSalir.ShortcutText = ""
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(630, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar {F3}"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.Text = "Salir {F5}"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TObs
        '
        Me.TObs.AcceptsReturn = True
        Me.TObs.AcceptsTab = True
        Me.TObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs.Location = New System.Drawing.Point(128, 445)
        Me.TObs.MaxLength = 255
        Me.TObs.Name = "TObs"
        Me.TObs.Size = New System.Drawing.Size(437, 22)
        Me.TObs.TabIndex = 7
        '
        'L12
        '
        Me.L12.AutoSize = True
        Me.L12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L12.Location = New System.Drawing.Point(22, 447)
        Me.L12.Name = "L12"
        Me.L12.Size = New System.Drawing.Size(99, 16)
        Me.L12.TabIndex = 551
        Me.L12.Text = "Observaciones"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(84, 109)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(37, 16)
        Me.Label30.TabIndex = 555
        Me.Label30.Text = "Folio"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 416)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 558
        Me.Label1.Text = "Estatus"
        '
        'CboStatus
        '
        Me.CboStatus.AllowSpinLoop = False
        Me.CboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboStatus.GapHeight = 0
        Me.CboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboStatus.Items.Add("CAPTURADO")
        Me.CboStatus.Items.Add("ACEPTADO")
        Me.CboStatus.ItemsDisplayMember = ""
        Me.CboStatus.ItemsValueMember = ""
        Me.CboStatus.Location = New System.Drawing.Point(128, 415)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(142, 20)
        Me.CboStatus.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboStatus.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboStatus.TabIndex = 6
        Me.CboStatus.Tag = Nothing
        Me.CboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtIVA
        '
        Me.LtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIVA.Location = New System.Drawing.Point(128, 322)
        Me.LtIVA.Name = "LtIVA"
        Me.LtIVA.Size = New System.Drawing.Size(100, 21)
        Me.LtIVA.TabIndex = 564
        Me.LtIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 563
        Me.Label3.Text = "IVA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(65, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 561
        Me.Label5.Text = "Subtotal"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtTotal
        '
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.Location = New System.Drawing.Point(128, 384)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(100, 21)
        Me.LtTotal.TabIndex = 568
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(83, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 567
        Me.Label7.Text = "Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIEPS
        '
        Me.LtIEPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIEPS.Location = New System.Drawing.Point(128, 353)
        Me.LtIEPS.Name = "LtIEPS"
        Me.LtIEPS.Size = New System.Drawing.Size(100, 21)
        Me.LtIEPS.TabIndex = 566
        Me.LtIEPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(84, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 565
        Me.Label9.Text = "IEPS"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnGas
        '
        Me.BtnGas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGas.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnGas.Location = New System.Drawing.Point(176, 168)
        Me.BtnGas.Name = "BtnGas"
        Me.BtnGas.Size = New System.Drawing.Size(24, 23)
        Me.BtnGas.TabIndex = 573
        Me.BtnGas.UseVisualStyleBackColor = True
        '
        'LtGas
        '
        Me.LtGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGas.Location = New System.Drawing.Point(201, 170)
        Me.LtGas.Name = "LtGas"
        Me.LtGas.Size = New System.Drawing.Size(364, 20)
        Me.LtGas.TabIndex = 572
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 571
        Me.Label2.Text = "Gasolinera"
        '
        'TCVE_GAS
        '
        Me.TCVE_GAS.AcceptsReturn = True
        Me.TCVE_GAS.AcceptsTab = True
        Me.TCVE_GAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_GAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_GAS.Location = New System.Drawing.Point(128, 168)
        Me.TCVE_GAS.MaxLength = 10
        Me.TCVE_GAS.Name = "TCVE_GAS"
        Me.TCVE_GAS.Size = New System.Drawing.Size(43, 22)
        Me.TCVE_GAS.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(76, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 575
        Me.Label4.Text = "Fecha"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FECHA
        '
        Me.FECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FECHA.Location = New System.Drawing.Point(128, 138)
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Size = New System.Drawing.Size(113, 20)
        Me.FECHA.TabIndex = 1
        Me.FECHA.Tag = Nothing
        Me.FECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(128, 200)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 20)
        Me.F1.TabIndex = 3
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 578
        Me.Label6.Text = "Fecha de carga"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtSubtotal
        '
        Me.LtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSubtotal.Location = New System.Drawing.Point(128, 291)
        Me.LtSubtotal.Name = "LtSubtotal"
        Me.LtSubtotal.Size = New System.Drawing.Size(100, 21)
        Me.LtSubtotal.TabIndex = 596
        Me.LtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtViaje
        '
        Me.LtViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtViaje.Location = New System.Drawing.Point(128, 76)
        Me.LtViaje.Name = "LtViaje"
        Me.LtViaje.Size = New System.Drawing.Size(100, 21)
        Me.LtViaje.TabIndex = 598
        Me.LtViaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(83, 79)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 16)
        Me.Label31.TabIndex = 597
        Me.Label31.Text = "Viaje"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TLTS_REALES
        '
        Me.TLTS_REALES.AcceptsReturn = True
        Me.TLTS_REALES.AcceptsTab = True
        Me.TLTS_REALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLTS_REALES.CustomFormat = "###,###,##0.0000"
        Me.TLTS_REALES.DataType = GetType(Decimal)
        Me.TLTS_REALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_REALES.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_REALES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TLTS_REALES.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLTS_REALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLTS_REALES.Location = New System.Drawing.Point(128, 261)
        Me.TLTS_REALES.Name = "TLTS_REALES"
        Me.TLTS_REALES.Size = New System.Drawing.Size(100, 20)
        Me.TLTS_REALES.TabIndex = 4
        Me.TLTS_REALES.Tag = Nothing
        Me.TLTS_REALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TLTS_REALES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLTS_REALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 600
        Me.Label8.Text = "Lts. reales"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPRECIO_X_LTS
        '
        Me.TPRECIO_X_LTS.AcceptsReturn = True
        Me.TPRECIO_X_LTS.AcceptsTab = True
        Me.TPRECIO_X_LTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPRECIO_X_LTS.CustomFormat = "###,###,##0.0000"
        Me.TPRECIO_X_LTS.DataType = GetType(Decimal)
        Me.TPRECIO_X_LTS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO_X_LTS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO_X_LTS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO_X_LTS.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO_X_LTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRECIO_X_LTS.Location = New System.Drawing.Point(340, 261)
        Me.TPRECIO_X_LTS.Name = "TPRECIO_X_LTS"
        Me.TPRECIO_X_LTS.Size = New System.Drawing.Size(100, 20)
        Me.TPRECIO_X_LTS.TabIndex = 5
        Me.TPRECIO_X_LTS.Tag = Nothing
        Me.TPRECIO_X_LTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRECIO_X_LTS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRECIO_X_LTS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(257, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 567
        Me.Label10.Text = "Precio x litro"
        '
        'LtLts_Inic
        '
        Me.LtLts_Inic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLts_Inic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLts_Inic.Location = New System.Drawing.Point(128, 230)
        Me.LtLts_Inic.Name = "LtLts_Inic"
        Me.LtLts_Inic.Size = New System.Drawing.Size(100, 21)
        Me.LtLts_Inic.TabIndex = 603
        Me.LtLts_Inic.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(33, 231)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 602
        Me.Label12.Text = "Litros inciales"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtFactorIEPS
        '
        Me.LtFactorIEPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFactorIEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFactorIEPS.Location = New System.Drawing.Point(340, 230)
        Me.LtFactorIEPS.Name = "LtFactorIEPS"
        Me.LtFactorIEPS.Size = New System.Drawing.Size(63, 21)
        Me.LtFactorIEPS.TabIndex = 606
        Me.LtFactorIEPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(258, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 16)
        Me.Label13.TabIndex = 605
        Me.Label13.Text = "Factor IEPS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TFOLIO
        '
        Me.TFOLIO.Location = New System.Drawing.Point(128, 108)
        Me.TFOLIO.Name = "TFOLIO"
        Me.TFOLIO.Size = New System.Drawing.Size(100, 20)
        Me.TFOLIO.TabIndex = 0
        '
        'btnAnterior
        '
        Me.btnAnterior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.Image = Global.SGT_Transport.My.Resources.Resources.flecha_izq
        Me.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnterior.Location = New System.Drawing.Point(473, 65)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(38, 49)
        Me.btnAnterior.TabIndex = 609
        Me.btnAnterior.Text = "F10"
        Me.btnAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnterior.UseVisualStyleBackColor = True
        Me.btnAnterior.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnInicial
        '
        Me.btnInicial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicial.Image = Global.SGT_Transport.My.Resources.Resources.flechaIzqD
        Me.btnInicial.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInicial.Location = New System.Drawing.Point(431, 65)
        Me.btnInicial.Name = "btnInicial"
        Me.btnInicial.Size = New System.Drawing.Size(38, 49)
        Me.btnInicial.TabIndex = 608
        Me.btnInicial.Text = "F9"
        Me.btnInicial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInicial.UseVisualStyleBackColor = True
        Me.btnInicial.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Image = Global.SGT_Transport.My.Resources.Resources.flecha_der
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSiguiente.Location = New System.Drawing.Point(526, 67)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(38, 49)
        Me.btnSiguiente.TabIndex = 610
        Me.btnSiguiente.Text = "F11"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSiguiente.UseVisualStyleBackColor = True
        Me.btnSiguiente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnFinal
        '
        Me.btnFinal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinal.Image = Global.SGT_Transport.My.Resources.Resources.flecha_derD
        Me.btnFinal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFinal.Location = New System.Drawing.Point(567, 67)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(38, 49)
        Me.btnFinal.TabIndex = 611
        Me.btnFinal.Text = "F12"
        Me.btnFinal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFinal.UseVisualStyleBackColor = True
        Me.btnFinal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmConciValesComEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 511)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnInicial)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnFinal)
        Me.Controls.Add(Me.TFOLIO)
        Me.Controls.Add(Me.LtFactorIEPS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LtLts_Inic)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TPRECIO_X_LTS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TLTS_REALES)
        Me.Controls.Add(Me.LtViaje)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.LtSubtotal)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FECHA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnGas)
        Me.Controls.Add(Me.LtGas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCVE_GAS)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtIEPS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtIVA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TObs)
        Me.Controls.Add(Me.L12)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConciValesComEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edicion"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLTS_REALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPRECIO_X_LTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSiguiente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TObs As TextBox
    Friend WithEvents L12 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CboStatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LtIEPS As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtIVA As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnGas As Button
    Friend WithEvents LtGas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TCVE_GAS As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents FECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents C1TextBox1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents C1TextBox2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents LtSubtotal As Label
    Friend WithEvents LtViaje As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents TLTS_REALES As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TPRECIO_X_LTS As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LtLts_Inic As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LtFactorIEPS As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TFOLIO As TextBox
    Friend WithEvents btnAnterior As C1.Win.C1Input.C1Button
    Friend WithEvents btnInicial As C1.Win.C1Input.C1Button
    Friend WithEvents btnSiguiente As C1.Win.C1Input.C1Button
    Friend WithEvents btnFinal As C1.Win.C1Input.C1Button
End Class
