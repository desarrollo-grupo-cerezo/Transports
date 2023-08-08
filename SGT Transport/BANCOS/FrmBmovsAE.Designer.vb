<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBmovsAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBmovsAE))
        Me.MenuHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarPolizaCheque = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkPolizaCheque = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TREF2 = New C1.Win.C1Input.C1TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TREF1 = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCLPV = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TFORMAPAGO = New C1.Win.C1Input.C1TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TCVE_CONCEP = New C1.Win.C1Input.C1TextBox()
        Me.TF_COBRO = New C1.Win.Calendar.C1DateEdit()
        Me.TFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtBenef = New System.Windows.Forms.Label()
        Me.LtConcep = New System.Windows.Forms.Label()
        Me.LtFormaPago = New System.Windows.Forms.Label()
        Me.TX_OBSER = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TNUM_REG = New C1.Win.C1Input.C1TextBox()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.BtnFormaPago = New C1.Win.C1Input.C1Button()
        Me.BtnConcep = New C1.Win.C1Input.C1Button()
        Me.BtnBenef = New C1.Win.C1Input.C1Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TNUM_CHEQUE = New C1.Win.C1Input.C1NumericEdit()
        Me.TMONTO_TOT = New C1.Win.C1Input.C1NumericEdit()
        Me.TMONTO_IVA_TOT = New C1.Win.C1Input.C1NumericEdit()
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TREF2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TREF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCLPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFORMAPAGO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_CONCEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TF_COBRO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_REG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnConcep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnBenef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_CHEQUE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMONTO_TOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMONTO_IVA_TOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder1
        '
        Me.MenuHolder1.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder1.Commands.Add(Me.BarGrabar)
        Me.MenuHolder1.Commands.Add(Me.BarSalir)
        Me.MenuHolder1.Commands.Add(Me.BarImprimir)
        Me.MenuHolder1.Commands.Add(Me.BarPolizaCheque)
        Me.MenuHolder1.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
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
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarPolizaCheque
        '
        Me.BarPolizaCheque.Image = Global.SGT_Transport.My.Resources.Resources.cheque9
        Me.BarPolizaCheque.Name = "BarPolizaCheque"
        Me.BarPolizaCheque.ShortcutText = ""
        Me.BarPolizaCheque.Text = "Poliza de cheque"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkImprimir, Me.LkPolizaCheque, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(798, 43)
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
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 1
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkPolizaCheque
        '
        Me.LkPolizaCheque.Command = Me.BarPolizaCheque
        Me.LkPolizaCheque.Delimiter = True
        Me.LkPolizaCheque.SortOrder = 2
        Me.LkPolizaCheque.Text = "Poliza de cheque"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 3
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 275)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "Monto total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(55, 246)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 413
        Me.Label7.Text = "Referencia 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TREF2
        '
        Me.TREF2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TREF2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREF2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TREF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREF2.Location = New System.Drawing.Point(141, 245)
        Me.TREF2.MaxLength = 20
        Me.TREF2.Name = "TREF2"
        Me.TREF2.Size = New System.Drawing.Size(249, 20)
        Me.TREF2.TabIndex = 7
        Me.TREF2.Tag = Nothing
        Me.TREF2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 217)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 411
        Me.Label3.Text = "Referencia 1"
        '
        'TREF1
        '
        Me.TREF1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TREF1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREF1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TREF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREF1.Location = New System.Drawing.Point(141, 216)
        Me.TREF1.MaxLength = 20
        Me.TREF1.Name = "TREF1"
        Me.TREF1.Size = New System.Drawing.Size(249, 20)
        Me.TREF1.TabIndex = 6
        Me.TREF1.Tag = Nothing
        Me.TREF1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 159)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Fecha de registro"
        '
        'TCLPV
        '
        Me.TCLPV.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCLPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLPV.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCLPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLPV.Location = New System.Drawing.Point(141, 187)
        Me.TCLPV.MaxLength = 10
        Me.TCLPV.Name = "TCLPV"
        Me.TCLPV.Size = New System.Drawing.Size(54, 20)
        Me.TCLPV.TabIndex = 5
        Me.TCLPV.Tag = Nothing
        Me.TCLPV.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Forma de pago"
        '
        'TFORMAPAGO
        '
        Me.TFORMAPAGO.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TFORMAPAGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFORMAPAGO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TFORMAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFORMAPAGO.Location = New System.Drawing.Point(141, 129)
        Me.TFORMAPAGO.MaxLength = 6
        Me.TFORMAPAGO.Name = "TFORMAPAGO"
        Me.TFORMAPAGO.Size = New System.Drawing.Size(108, 20)
        Me.TFORMAPAGO.TabIndex = 2
        Me.TFORMAPAGO.Tag = Nothing
        Me.TFORMAPAGO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(73, 101)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Concepto"
        '
        'TCVE_CONCEP
        '
        Me.TCVE_CONCEP.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCVE_CONCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CONCEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CONCEP.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_CONCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CONCEP.Location = New System.Drawing.Point(141, 100)
        Me.TCVE_CONCEP.MaxLength = 6
        Me.TCVE_CONCEP.Name = "TCVE_CONCEP"
        Me.TCVE_CONCEP.Size = New System.Drawing.Size(108, 20)
        Me.TCVE_CONCEP.TabIndex = 1
        Me.TCVE_CONCEP.Tag = Nothing
        Me.TCVE_CONCEP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TF_COBRO
        '
        Me.TF_COBRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TF_COBRO.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.TF_COBRO.Calendar.ShowClearButton = False
        Me.TF_COBRO.Calendar.ShowWeekNumbers = True
        Me.TF_COBRO.Calendar.TodayText = "&Hoy"
        Me.TF_COBRO.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TF_COBRO.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TF_COBRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TF_COBRO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TF_COBRO.Location = New System.Drawing.Point(418, 157)
        Me.TF_COBRO.Name = "TF_COBRO"
        Me.TF_COBRO.Size = New System.Drawing.Size(111, 20)
        Me.TF_COBRO.TabIndex = 4
        Me.TF_COBRO.Tag = Nothing
        Me.TF_COBRO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.TF_COBRO.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TF_COBRO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'TFECHA
        '
        Me.TFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.TFECHA.Calendar.ShowClearButton = False
        Me.TFECHA.Calendar.TodayText = "&Hoy"
        Me.TFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TFECHA.Location = New System.Drawing.Point(141, 158)
        Me.TFECHA.Name = "TFECHA"
        Me.TFECHA.Size = New System.Drawing.Size(113, 20)
        Me.TFECHA.TabIndex = 3
        Me.TFECHA.Tag = Nothing
        Me.TFECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.TFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(283, 159)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 16)
        Me.Label4.TabIndex = 420
        Me.Label4.Text = "Fecha de aplicación"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(60, 188)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Beneficiario"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(282, 275)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 16)
        Me.Label9.TabIndex = 423
        Me.Label9.Text = "Monto IVA"
        '
        'LtBenef
        '
        Me.LtBenef.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtBenef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtBenef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtBenef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtBenef.Location = New System.Drawing.Point(222, 186)
        Me.LtBenef.Name = "LtBenef"
        Me.LtBenef.Size = New System.Drawing.Size(423, 21)
        Me.LtBenef.TabIndex = 11
        Me.LtBenef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtConcep
        '
        Me.LtConcep.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtConcep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtConcep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtConcep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtConcep.Location = New System.Drawing.Point(279, 99)
        Me.LtConcep.Name = "LtConcep"
        Me.LtConcep.Size = New System.Drawing.Size(366, 21)
        Me.LtConcep.TabIndex = 9
        Me.LtConcep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtFormaPago
        '
        Me.LtFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFormaPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtFormaPago.Location = New System.Drawing.Point(279, 128)
        Me.LtFormaPago.Name = "LtFormaPago"
        Me.LtFormaPago.Size = New System.Drawing.Size(366, 21)
        Me.LtFormaPago.TabIndex = 10
        Me.LtFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TX_OBSER
        '
        Me.TX_OBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TX_OBSER.Location = New System.Drawing.Point(141, 330)
        Me.TX_OBSER.MaxLength = 255
        Me.TX_OBSER.Multiline = True
        Me.TX_OBSER.Name = "TX_OBSER"
        Me.TX_OBSER.Size = New System.Drawing.Size(504, 69)
        Me.TX_OBSER.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(39, 335)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 16)
        Me.Label11.TabIndex = 431
        Me.Label11.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(96, 72)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 434
        Me.Label5.Text = "Clave"
        '
        'TNUM_REG
        '
        Me.TNUM_REG.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TNUM_REG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUM_REG.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TNUM_REG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_REG.Location = New System.Drawing.Point(141, 71)
        Me.TNUM_REG.MaxLength = 6
        Me.TNUM_REG.Name = "TNUM_REG"
        Me.TNUM_REG.Size = New System.Drawing.Size(54, 20)
        Me.TNUM_REG.TabIndex = 0
        Me.TNUM_REG.Tag = Nothing
        Me.TNUM_REG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "0f662a7b9fd6465989783044c2c1cfeb"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'BtnFormaPago
        '
        Me.BtnFormaPago.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnFormaPago.Location = New System.Drawing.Point(252, 126)
        Me.BtnFormaPago.Name = "BtnFormaPago"
        Me.BtnFormaPago.Size = New System.Drawing.Size(23, 24)
        Me.BtnFormaPago.TabIndex = 428
        Me.BtnFormaPago.UseVisualStyleBackColor = True
        '
        'BtnConcep
        '
        Me.BtnConcep.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnConcep.Location = New System.Drawing.Point(252, 97)
        Me.BtnConcep.Name = "BtnConcep"
        Me.BtnConcep.Size = New System.Drawing.Size(23, 24)
        Me.BtnConcep.TabIndex = 427
        Me.BtnConcep.UseVisualStyleBackColor = True
        '
        'BtnBenef
        '
        Me.BtnBenef.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnBenef.Location = New System.Drawing.Point(198, 184)
        Me.BtnBenef.Name = "BtnBenef"
        Me.BtnBenef.Size = New System.Drawing.Size(23, 24)
        Me.BtnBenef.TabIndex = 426
        Me.BtnBenef.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 303)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 16)
        Me.Label10.TabIndex = 437
        Me.Label10.Text = "Número de cheque"
        '
        'TNUM_CHEQUE
        '
        Me.TNUM_CHEQUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TNUM_CHEQUE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TNUM_CHEQUE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_CHEQUE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_CHEQUE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TNUM_CHEQUE.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TNUM_CHEQUE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TNUM_CHEQUE.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TNUM_CHEQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_CHEQUE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TNUM_CHEQUE.InterceptArrowKeys = False
        Me.TNUM_CHEQUE.Location = New System.Drawing.Point(141, 302)
        Me.TNUM_CHEQUE.Name = "TNUM_CHEQUE"
        Me.TNUM_CHEQUE.Size = New System.Drawing.Size(129, 19)
        Me.TNUM_CHEQUE.TabIndex = 10
        Me.TNUM_CHEQUE.Tag = Nothing
        Me.TNUM_CHEQUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TNUM_CHEQUE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TNUM_CHEQUE.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_CHEQUE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TMONTO_TOT
        '
        Me.TMONTO_TOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TMONTO_TOT.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TMONTO_TOT.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_TOT.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_TOT.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TMONTO_TOT.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMONTO_TOT.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMONTO_TOT.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TMONTO_TOT.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMONTO_TOT.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMONTO_TOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMONTO_TOT.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TMONTO_TOT.InterceptArrowKeys = False
        Me.TMONTO_TOT.Location = New System.Drawing.Point(141, 274)
        Me.TMONTO_TOT.Name = "TMONTO_TOT"
        Me.TMONTO_TOT.Size = New System.Drawing.Size(129, 19)
        Me.TMONTO_TOT.TabIndex = 8
        Me.TMONTO_TOT.Tag = Nothing
        Me.TMONTO_TOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TMONTO_TOT.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TMONTO_TOT.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_TOT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TMONTO_IVA_TOT
        '
        Me.TMONTO_IVA_TOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TMONTO_IVA_TOT.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TMONTO_IVA_TOT.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_IVA_TOT.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_IVA_TOT.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TMONTO_IVA_TOT.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMONTO_IVA_TOT.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMONTO_IVA_TOT.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TMONTO_IVA_TOT.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMONTO_IVA_TOT.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMONTO_IVA_TOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMONTO_IVA_TOT.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TMONTO_IVA_TOT.InterceptArrowKeys = False
        Me.TMONTO_IVA_TOT.Location = New System.Drawing.Point(354, 274)
        Me.TMONTO_IVA_TOT.Name = "TMONTO_IVA_TOT"
        Me.TMONTO_IVA_TOT.Size = New System.Drawing.Size(129, 19)
        Me.TMONTO_IVA_TOT.TabIndex = 9
        Me.TMONTO_IVA_TOT.Tag = Nothing
        Me.TMONTO_IVA_TOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TMONTO_IVA_TOT.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TMONTO_IVA_TOT.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMONTO_IVA_TOT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmBmovsAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 548)
        Me.Controls.Add(Me.TMONTO_IVA_TOT)
        Me.Controls.Add(Me.TMONTO_TOT)
        Me.Controls.Add(Me.TNUM_CHEQUE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TNUM_REG)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TX_OBSER)
        Me.Controls.Add(Me.LtFormaPago)
        Me.Controls.Add(Me.LtConcep)
        Me.Controls.Add(Me.BtnFormaPago)
        Me.Controls.Add(Me.BtnConcep)
        Me.Controls.Add(Me.BtnBenef)
        Me.Controls.Add(Me.LtBenef)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TF_COBRO)
        Me.Controls.Add(Me.TFECHA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TREF2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TREF1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCLPV)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TFORMAPAGO)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TCVE_CONCEP)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBmovsAE"
        Me.ShowInTaskbar = False
        Me.Text = "Movimientos"
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TREF2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TREF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCLPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFORMAPAGO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_CONCEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TF_COBRO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_REG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnConcep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnBenef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_CHEQUE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMONTO_TOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMONTO_IVA_TOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder1 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Private WithEvents Label6 As Label
    Private WithEvents Label7 As Label
    Friend WithEvents TREF2 As C1.Win.C1Input.C1TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents TREF1 As C1.Win.C1Input.C1TextBox
    Private WithEvents Label2 As Label
    Friend WithEvents TCLPV As C1.Win.C1Input.C1TextBox
    Private WithEvents Label1 As Label
    Friend WithEvents TFORMAPAGO As C1.Win.C1Input.C1TextBox
    Private WithEvents Label16 As Label
    Friend WithEvents TCVE_CONCEP As C1.Win.C1Input.C1TextBox
    Friend WithEvents TF_COBRO As C1.Win.Calendar.C1DateEdit
    Friend WithEvents TFECHA As C1.Win.Calendar.C1DateEdit
    Private WithEvents Label4 As Label
    Private WithEvents Label8 As Label
    Private WithEvents Label9 As Label
    Friend WithEvents LtBenef As Label
    Friend WithEvents LtFormaPago As Label
    Friend WithEvents LtConcep As Label
    Friend WithEvents BtnFormaPago As C1.Win.C1Input.C1Button
    Friend WithEvents BtnConcep As C1.Win.C1Input.C1Button
    Friend WithEvents BtnBenef As C1.Win.C1Input.C1Button
    Private WithEvents Label11 As Label
    Friend WithEvents TX_OBSER As TextBox
    Private WithEvents Label5 As Label
    Friend WithEvents TNUM_REG As C1.Win.C1Input.C1TextBox
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarPolizaCheque As C1.Win.C1Command.C1Command
    Friend WithEvents LkPolizaCheque As C1.Win.C1Command.C1CommandLink
    Private WithEvents Label10 As Label
    Friend WithEvents TNUM_CHEQUE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TMONTO_IVA_TOT As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TMONTO_TOT As C1.Win.C1Input.C1NumericEdit
End Class
