<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConciValesUtilitario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConciValesUtilitario))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGas = New System.Windows.Forms.Button()
        Me.LtGas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tCVE_GAS = New System.Windows.Forms.TextBox()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtIEPS = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtIVA = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.LtFolio = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tObs = New System.Windows.Forms.TextBox()
        Me.L12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tLTS_INICIALES = New C1.Win.C1Input.C1TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tLTS_REALES = New C1.Win.C1Input.C1TextBox()
        Me.LtTractor = New System.Windows.Forms.Label()
        Me.BtnUnidad = New C1.Win.C1Input.C1Button()
        Me.tCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.LtSubtotal = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.C1ComboBox1 = New C1.Win.C1Input.C1ComboBox()
        Me.CboTipoGasolina = New C1.Win.C1Input.C1ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TFactor = New C1.Win.C1Input.C1TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LtXML = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LtFAC_CFDI = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LtFECHA_CFDI = New System.Windows.Forms.Label()
        Me.TPRECIO_X_LTS = New C1.Win.C1Input.C1TextBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TKM = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLTS_INICIALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLTS_REALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoGasolina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPRECIO_X_LTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TKM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 30
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(584, 48)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        Me.LkGrabar.ToolTipText = "Nuevo servicio"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.SortOrder = 1
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(110, 117)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(120, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 606
        Me.Label6.Text = "Fecha de carga"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FECHA
        '
        Me.FECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FECHA.Location = New System.Drawing.Point(110, 89)
        Me.FECHA.Name = "FECHA"
        Me.FECHA.Size = New System.Drawing.Size(120, 20)
        Me.FECHA.TabIndex = 0
        Me.FECHA.Tag = Nothing
        Me.FECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 604
        Me.Label4.Text = "Fecha"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGas
        '
        Me.btnGas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGas.Image = CType(resources.GetObject("btnGas.Image"), System.Drawing.Image)
        Me.btnGas.Location = New System.Drawing.Point(172, 207)
        Me.btnGas.Name = "btnGas"
        Me.btnGas.Size = New System.Drawing.Size(24, 23)
        Me.btnGas.TabIndex = 603
        Me.btnGas.UseVisualStyleBackColor = True
        '
        'LtGas
        '
        Me.LtGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGas.Location = New System.Drawing.Point(202, 209)
        Me.LtGas.Name = "LtGas"
        Me.LtGas.Size = New System.Drawing.Size(310, 20)
        Me.LtGas.TabIndex = 602
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 601
        Me.Label2.Text = "Gasolinera"
        '
        'tCVE_GAS
        '
        Me.tCVE_GAS.AcceptsReturn = True
        Me.tCVE_GAS.AcceptsTab = True
        Me.tCVE_GAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_GAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GAS.Location = New System.Drawing.Point(110, 205)
        Me.tCVE_GAS.Name = "tCVE_GAS"
        Me.tCVE_GAS.Size = New System.Drawing.Size(58, 22)
        Me.tCVE_GAS.TabIndex = 4
        '
        'LtTotal
        '
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.Location = New System.Drawing.Point(384, 348)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(127, 21)
        Me.LtTotal.TabIndex = 600
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(340, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 599
        Me.Label7.Text = "Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIEPS
        '
        Me.LtIEPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIEPS.Location = New System.Drawing.Point(384, 321)
        Me.LtIEPS.Name = "LtIEPS"
        Me.LtIEPS.Size = New System.Drawing.Size(127, 21)
        Me.LtIEPS.TabIndex = 598
        Me.LtIEPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(341, 322)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 597
        Me.Label9.Text = "IEPS"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIVA
        '
        Me.LtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIVA.Location = New System.Drawing.Point(384, 294)
        Me.LtIVA.Name = "LtIVA"
        Me.LtIVA.Size = New System.Drawing.Size(127, 21)
        Me.LtIVA.TabIndex = 596
        Me.LtIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(350, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 595
        Me.Label3.Text = "IVA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.AllowSpinLoop = False
        Me.cboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.GapHeight = 0
        Me.cboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboStatus.Items.Add("EDICION")
        Me.cboStatus.Items.Add("CAPTURADO")
        Me.cboStatus.Items.Add("ACEPTADO")
        Me.cboStatus.ItemsDisplayMember = ""
        Me.cboStatus.ItemsValueMember = ""
        Me.cboStatus.Location = New System.Drawing.Point(391, 115)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(120, 20)
        Me.cboStatus.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboStatus.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboStatus.TabIndex = 2
        Me.cboStatus.Tag = Nothing
        Me.cboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(333, 117)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(51, 16)
        Me.Lt2.TabIndex = 592
        Me.Lt2.Text = "Estatus"
        '
        'LtFolio
        '
        Me.LtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFolio.Location = New System.Drawing.Point(110, 60)
        Me.LtFolio.Name = "LtFolio"
        Me.LtFolio.Size = New System.Drawing.Size(100, 21)
        Me.LtFolio.TabIndex = 11
        Me.LtFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(71, 63)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(37, 16)
        Me.Label30.TabIndex = 590
        Me.Label30.Text = "Folio"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tObs
        '
        Me.tObs.AcceptsReturn = True
        Me.tObs.AcceptsTab = True
        Me.tObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tObs.Location = New System.Drawing.Point(109, 441)
        Me.tObs.MaxLength = 255
        Me.tObs.Name = "tObs"
        Me.tObs.Size = New System.Drawing.Size(403, 22)
        Me.tObs.TabIndex = 11
        '
        'L12
        '
        Me.L12.AutoSize = True
        Me.L12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L12.Location = New System.Drawing.Point(8, 443)
        Me.L12.Name = "L12"
        Me.L12.Size = New System.Drawing.Size(99, 16)
        Me.L12.TabIndex = 586
        Me.L12.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 566
        Me.Label5.Text = "Lts. reales"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 353)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 16)
        Me.Label8.TabIndex = 565
        Me.Label8.Text = "Precio x litro"
        '
        'tLTS_INICIALES
        '
        Me.tLTS_INICIALES.AcceptsReturn = True
        Me.tLTS_INICIALES.AcceptsTab = True
        Me.tLTS_INICIALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tLTS_INICIALES.CustomFormat = "###,###,##0.00"
        Me.tLTS_INICIALES.DataType = GetType(Decimal)
        Me.tLTS_INICIALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_INICIALES.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_INICIALES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_INICIALES.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_INICIALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLTS_INICIALES.Location = New System.Drawing.Point(110, 296)
        Me.tLTS_INICIALES.Name = "tLTS_INICIALES"
        Me.tLTS_INICIALES.Size = New System.Drawing.Size(100, 20)
        Me.tLTS_INICIALES.TabIndex = 7
        Me.tLTS_INICIALES.Tag = Nothing
        Me.tLTS_INICIALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLTS_INICIALES.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.tLTS_INICIALES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLTS_INICIALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLTS_INICIALES.WordWrap = False
        Me.tLTS_INICIALES.WrapDateTimeFields = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(318, 269)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 16)
        Me.Label10.TabIndex = 569
        Me.Label10.Text = "Sub-total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(29, 297)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 16)
        Me.Label11.TabIndex = 568
        Me.Label11.Text = "Lts. iniciales"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tLTS_REALES
        '
        Me.tLTS_REALES.AcceptsReturn = True
        Me.tLTS_REALES.AcceptsTab = True
        Me.tLTS_REALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tLTS_REALES.CustomFormat = "###,###,##0.000"
        Me.tLTS_REALES.DataType = GetType(Decimal)
        Me.tLTS_REALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_REALES.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_REALES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_REALES.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_REALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLTS_REALES.Location = New System.Drawing.Point(110, 324)
        Me.tLTS_REALES.Name = "tLTS_REALES"
        Me.tLTS_REALES.Size = New System.Drawing.Size(100, 20)
        Me.tLTS_REALES.TabIndex = 8
        Me.tLTS_REALES.Tag = Nothing
        Me.tLTS_REALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLTS_REALES.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.tLTS_REALES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLTS_REALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLTS_REALES.WordWrap = False
        Me.tLTS_REALES.WrapDateTimeFields = False
        '
        'LtTractor
        '
        Me.LtTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTractor.Location = New System.Drawing.Point(202, 142)
        Me.LtTractor.Name = "LtTractor"
        Me.LtTractor.Size = New System.Drawing.Size(310, 20)
        Me.LtTractor.TabIndex = 583
        Me.LtTractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnUnidad
        '
        Me.BtnUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidad.Image = CType(resources.GetObject("BtnUnidad.Image"), System.Drawing.Image)
        Me.BtnUnidad.Location = New System.Drawing.Point(173, 142)
        Me.BtnUnidad.Name = "BtnUnidad"
        Me.BtnUnidad.Size = New System.Drawing.Size(24, 22)
        Me.BtnUnidad.TabIndex = 584
        Me.BtnUnidad.UseVisualStyleBackColor = True
        Me.BtnUnidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_TRACTOR
        '
        Me.tCVE_TRACTOR.AcceptsReturn = True
        Me.tCVE_TRACTOR.AcceptsTab = True
        Me.tCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TRACTOR.Location = New System.Drawing.Point(110, 145)
        Me.tCVE_TRACTOR.Name = "tCVE_TRACTOR"
        Me.tCVE_TRACTOR.Size = New System.Drawing.Size(58, 22)
        Me.tCVE_TRACTOR.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(58, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 16)
        Me.Label13.TabIndex = 582
        Me.Label13.Text = "Tractor"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(173, 177)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(24, 22)
        Me.BtnOper.TabIndex = 587
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(43, 178)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 586
        Me.Label14.Text = "Operador"
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.Location = New System.Drawing.Point(110, 175)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(58, 22)
        Me.TCVE_OPER.TabIndex = 3
        '
        'LtOper
        '
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(202, 177)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(310, 20)
        Me.LtOper.TabIndex = 588
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtSubtotal
        '
        Me.LtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSubtotal.Location = New System.Drawing.Point(384, 267)
        Me.LtSubtotal.Name = "LtSubtotal"
        Me.LtSubtotal.Size = New System.Drawing.Size(127, 21)
        Me.LtSubtotal.TabIndex = 609
        Me.LtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(30, 269)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 16)
        Me.Label15.TabIndex = 613
        Me.Label15.Text = "Factor IEPS"
        '
        'C1ComboBox1
        '
        Me.C1ComboBox1.AllowSpinLoop = False
        Me.C1ComboBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1ComboBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.C1ComboBox1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.C1ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ComboBox1.GapHeight = 0
        Me.C1ComboBox1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.C1ComboBox1.Items.Add("EDICION")
        Me.C1ComboBox1.Items.Add("CAPTURADO")
        Me.C1ComboBox1.ItemsDisplayMember = ""
        Me.C1ComboBox1.ItemsValueMember = ""
        Me.C1ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.C1ComboBox1.Name = "C1ComboBox1"
        Me.C1ComboBox1.Size = New System.Drawing.Size(200, 20)
        Me.C1ComboBox1.Style.DropDownBackColor = System.Drawing.Color.White
        Me.C1ComboBox1.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.C1ComboBox1.TabIndex = 0
        Me.C1ComboBox1.Tag = Nothing
        Me.C1ComboBox1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1ComboBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboTipoGasolina
        '
        Me.CboTipoGasolina.AllowSpinLoop = False
        Me.CboTipoGasolina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipoGasolina.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipoGasolina.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipoGasolina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoGasolina.GapHeight = 0
        Me.CboTipoGasolina.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipoGasolina.ItemsDisplayMember = ""
        Me.CboTipoGasolina.ItemsValueMember = ""
        Me.CboTipoGasolina.Location = New System.Drawing.Point(110, 240)
        Me.CboTipoGasolina.Name = "CboTipoGasolina"
        Me.CboTipoGasolina.Size = New System.Drawing.Size(113, 20)
        Me.CboTipoGasolina.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboTipoGasolina.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboTipoGasolina.TabIndex = 5
        Me.CboTipoGasolina.Tag = Nothing
        Me.CboTipoGasolina.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboTipoGasolina.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 241)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 616
        Me.Label12.Text = "Tipo gasolina"
        '
        'TFactor
        '
        Me.TFactor.AcceptsReturn = True
        Me.TFactor.AcceptsTab = True
        Me.TFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFactor.CustomFormat = "###,###,##0.0000"
        Me.TFactor.DataType = GetType(Decimal)
        Me.TFactor.DateTimeInput = False
        Me.TFactor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TFactor.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFactor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TFactor.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFactor.Location = New System.Drawing.Point(110, 268)
        Me.TFactor.Name = "TFactor"
        Me.TFactor.Size = New System.Drawing.Size(100, 20)
        Me.TFactor.TabIndex = 6
        Me.TFactor.Tag = Nothing
        Me.TFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TFactor.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TFactor.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFactor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFactor.WordWrap = False
        Me.TFactor.WrapDateTimeFields = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(74, 473)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 16)
        Me.Label17.TabIndex = 618
        Me.Label17.Text = "XML"
        '
        'LtXML
        '
        Me.LtXML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtXML.Location = New System.Drawing.Point(109, 470)
        Me.LtXML.Name = "LtXML"
        Me.LtXML.Size = New System.Drawing.Size(402, 22)
        Me.LtXML.TabIndex = 619
        Me.LtXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(23, 414)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 16)
        Me.Label18.TabIndex = 621
        Me.Label18.Text = "Factura CFDI"
        '
        'LtFAC_CFDI
        '
        Me.LtFAC_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFAC_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFAC_CFDI.Location = New System.Drawing.Point(110, 410)
        Me.LtFAC_CFDI.Name = "LtFAC_CFDI"
        Me.LtFAC_CFDI.Size = New System.Drawing.Size(163, 22)
        Me.LtFAC_CFDI.TabIndex = 622
        Me.LtFAC_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(278, 415)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 16)
        Me.Label19.TabIndex = 624
        Me.Label19.Text = "Fecha CFDI"
        '
        'LtFECHA_CFDI
        '
        Me.LtFECHA_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFECHA_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFECHA_CFDI.Location = New System.Drawing.Point(359, 411)
        Me.LtFECHA_CFDI.Name = "LtFECHA_CFDI"
        Me.LtFECHA_CFDI.Size = New System.Drawing.Size(154, 22)
        Me.LtFECHA_CFDI.TabIndex = 625
        Me.LtFECHA_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TPRECIO_X_LTS
        '
        Me.TPRECIO_X_LTS.AcceptsReturn = True
        Me.TPRECIO_X_LTS.AcceptsTab = True
        Me.TPRECIO_X_LTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPRECIO_X_LTS.CustomFormat = "###,###,##0.000"
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
        Me.TPRECIO_X_LTS.Location = New System.Drawing.Point(110, 351)
        Me.TPRECIO_X_LTS.Name = "TPRECIO_X_LTS"
        Me.TPRECIO_X_LTS.Size = New System.Drawing.Size(100, 20)
        Me.TPRECIO_X_LTS.TabIndex = 9
        Me.TPRECIO_X_LTS.Tag = Nothing
        Me.TPRECIO_X_LTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRECIO_X_LTS.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRECIO_X_LTS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRECIO_X_LTS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRECIO_X_LTS.WordWrap = False
        Me.TPRECIO_X_LTS.WrapDateTimeFields = False
        '
        'Lt1
        '
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(352, 60)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(163, 27)
        Me.Lt1.TabIndex = 627
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lt1.Visible = False
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "b0a41a2c8fc94e9592b7db7a598a6df2"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'TKM
        '
        Me.TKM.AcceptsReturn = True
        Me.TKM.AcceptsTab = True
        Me.TKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM.CustomFormat = "###,###,##0.00"
        Me.TKM.DataType = GetType(Decimal)
        Me.TKM.DateTimeInput = False
        Me.TKM.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM.Location = New System.Drawing.Point(384, 237)
        Me.TKM.Name = "TKM"
        Me.TKM.Size = New System.Drawing.Size(127, 20)
        Me.TKM.TabIndex = 10
        Me.TKM.Tag = Nothing
        Me.TKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM.WordWrap = False
        Me.TKM.WrapDateTimeFields = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(352, 238)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 16)
        Me.Label1.TabIndex = 630
        Me.Label1.Text = "KM"
        '
        'FrmConciValesUtilitario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 537)
        Me.Controls.Add(Me.TKM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TPRECIO_X_LTS)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.LtFECHA_CFDI)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.LtFAC_CFDI)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LtXML)
        Me.Controls.Add(Me.TFactor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LtSubtotal)
        Me.Controls.Add(Me.tLTS_REALES)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.FECHA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tLTS_INICIALES)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tCVE_TRACTOR)
        Me.Controls.Add(Me.btnGas)
        Me.Controls.Add(Me.LtTractor)
        Me.Controls.Add(Me.BtnUnidad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtGas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCVE_GAS)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtIEPS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtIVA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.LtFolio)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tObs)
        Me.Controls.Add(Me.L12)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.CboTipoGasolina)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConciValesUtilitario"
        Me.ShowInTaskbar = False
        Me.Text = "Conciliación vehículos utilitarios"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLTS_INICIALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLTS_REALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoGasolina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPRECIO_X_LTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TKM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents FECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGas As Button
    Friend WithEvents LtGas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tCVE_GAS As TextBox
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LtIEPS As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtIVA As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboStatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Lt2 As Label
    Friend WithEvents LtFolio As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents tObs As TextBox
    Friend WithEvents L12 As Label
    Friend WithEvents TSUB_TOTAL As C1.Win.C1Input.C1TextBox
    Friend WithEvents tLTS_REALES As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tLTS_INICIALES As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents Label13 As Label
    Friend WithEvents tCVE_TRACTOR As TextBox
    Friend WithEvents LtTractor As Label
    Friend WithEvents BtnUnidad As C1.Win.C1Input.C1Button
    Friend WithEvents LtSubtotal As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents C1ComboBox1 As C1.Win.C1Input.C1ComboBox
    Friend WithEvents CboTipoGasolina As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents TFactor As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents LtXML As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents LtFAC_CFDI As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LtFECHA_CFDI As Label
    Friend WithEvents TPRECIO_X_LTS As C1.Win.C1Input.C1TextBox
    Friend WithEvents Lt1 As Label
    Friend WithEvents TKM As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label1 As Label
End Class
