<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolPagoProvAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolPagoProvAE))
        Me.MenuHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarReporte = New C1.Win.C1Command.C1Command()
        Me.BarDiseñoPeporte = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkReporte = New C1.Win.C1Command.C1CommandLink()
        Me.LkDiseñoPeporte = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.LtBenef = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TCVE_PROV = New C1.Win.C1Input.C1TextBox()
        Me.TFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtFormaPago = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TFORMAPAGO = New C1.Win.C1Input.C1TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TSOLICITA = New C1.Win.C1Input.C1TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCONCEPTO = New C1.Win.C1Input.C1TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TTRANSFIERE = New C1.Win.C1Input.C1TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TREV_AUT = New C1.Win.C1Input.C1TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TCLAVE = New C1.Win.C1Input.C1TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtSaldo = New System.Windows.Forms.Label()
        Me.BtnFormaPago = New C1.Win.C1Input.C1Button()
        Me.BtnProv = New C1.Win.C1Input.C1Button()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtMonto = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtSaldoGen = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TIMPORTE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_PROV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFORMAPAGO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSOLICITA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCONCEPTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTRANSFIERE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TREV_AUT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCLAVE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder1
        '
        Me.MenuHolder1.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder1.Commands.Add(Me.BarGrabar)
        Me.MenuHolder1.Commands.Add(Me.BarSalir)
        Me.MenuHolder1.Commands.Add(Me.BarReporte)
        Me.MenuHolder1.Commands.Add(Me.BarDiseñoPeporte)
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
        'BarReporte
        '
        Me.BarReporte.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarReporte.Name = "BarReporte"
        Me.BarReporte.ShortcutText = ""
        Me.BarReporte.Text = "Reimprimir"
        '
        'BarDiseñoPeporte
        '
        Me.BarDiseñoPeporte.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñoPeporte.Name = "BarDiseñoPeporte"
        Me.BarDiseñoPeporte.ShortcutText = ""
        Me.BarDiseñoPeporte.Text = "Diseño reporte"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkReporte, Me.LkDiseñoPeporte, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1161, 43)
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
        'LkReporte
        '
        Me.LkReporte.Command = Me.BarReporte
        Me.LkReporte.Delimiter = True
        Me.LkReporte.SortOrder = 1
        Me.LkReporte.Text = "Reimprimir"
        '
        'LkDiseñoPeporte
        '
        Me.LkDiseñoPeporte.Command = Me.BarDiseñoPeporte
        Me.LkDiseñoPeporte.Delimiter = True
        Me.LkDiseñoPeporte.SortOrder = 2
        Me.LkDiseñoPeporte.Text = "Diseño reporte"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 3
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'LtBenef
        '
        Me.LtBenef.BackColor = System.Drawing.Color.White
        Me.LtBenef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtBenef.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtBenef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtBenef.Location = New System.Drawing.Point(119, 143)
        Me.LtBenef.Name = "LtBenef"
        Me.LtBenef.Size = New System.Drawing.Size(437, 21)
        Me.LtBenef.TabIndex = 2
        Me.LtBenef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 116)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 17)
        Me.Label8.TabIndex = 429
        Me.Label8.Text = "Beneficiario"
        '
        'TCVE_PROV
        '
        Me.TCVE_PROV.BackColor = System.Drawing.Color.White
        Me.TCVE_PROV.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCVE_PROV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_PROV.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_PROV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV.Location = New System.Drawing.Point(119, 114)
        Me.TCVE_PROV.MaxLength = 10
        Me.TCVE_PROV.Name = "TCVE_PROV"
        Me.TCVE_PROV.Size = New System.Drawing.Size(54, 21)
        Me.TCVE_PROV.TabIndex = 1
        Me.TCVE_PROV.Tag = Nothing
        Me.TCVE_PROV.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA
        '
        Me.TFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.TFECHA.Calendar.ShowClearButton = False
        Me.TFECHA.Calendar.TodayText = "&Hoy"
        Me.TFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TFECHA.Location = New System.Drawing.Point(119, 173)
        Me.TFECHA.Name = "TFECHA"
        Me.TFECHA.Size = New System.Drawing.Size(113, 21)
        Me.TFECHA.TabIndex = 3
        Me.TFECHA.Tag = Nothing
        Me.TFECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.TFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 174)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Fecha de pago"
        '
        'LtFormaPago
        '
        Me.LtFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFormaPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtFormaPago.Location = New System.Drawing.Point(204, 202)
        Me.LtFormaPago.Name = "LtFormaPago"
        Me.LtFormaPago.Size = New System.Drawing.Size(352, 21)
        Me.LtFormaPago.TabIndex = 434
        Me.LtFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 203)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 435
        Me.Label1.Text = "Forma de pago"
        '
        'TFORMAPAGO
        '
        Me.TFORMAPAGO.BackColor = System.Drawing.Color.White
        Me.TFORMAPAGO.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TFORMAPAGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFORMAPAGO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TFORMAPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFORMAPAGO.Location = New System.Drawing.Point(119, 202)
        Me.TFORMAPAGO.MaxLength = 6
        Me.TFORMAPAGO.Name = "TFORMAPAGO"
        Me.TFORMAPAGO.Size = New System.Drawing.Size(54, 21)
        Me.TFORMAPAGO.TabIndex = 4
        Me.TFORMAPAGO.Tag = Nothing
        Me.TFORMAPAGO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(62, 232)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 438
        Me.Label6.Text = "Importe"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(64, 290)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 17)
        Me.Label7.TabIndex = 442
        Me.Label7.Text = "Solicita"
        '
        'TSOLICITA
        '
        Me.TSOLICITA.BackColor = System.Drawing.Color.White
        Me.TSOLICITA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TSOLICITA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TSOLICITA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TSOLICITA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSOLICITA.Location = New System.Drawing.Point(119, 289)
        Me.TSOLICITA.MaxLength = 80
        Me.TSOLICITA.Name = "TSOLICITA"
        Me.TSOLICITA.Size = New System.Drawing.Size(437, 21)
        Me.TSOLICITA.TabIndex = 7
        Me.TSOLICITA.Tag = Nothing
        Me.TSOLICITA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 261)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "Concepto"
        '
        'TCONCEPTO
        '
        Me.TCONCEPTO.BackColor = System.Drawing.Color.White
        Me.TCONCEPTO.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCONCEPTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCONCEPTO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCONCEPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCONCEPTO.Location = New System.Drawing.Point(119, 260)
        Me.TCONCEPTO.MaxLength = 60
        Me.TCONCEPTO.Name = "TCONCEPTO"
        Me.TCONCEPTO.Size = New System.Drawing.Size(437, 21)
        Me.TCONCEPTO.TabIndex = 6
        Me.TCONCEPTO.Tag = Nothing
        Me.TCONCEPTO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 348)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 446
        Me.Label4.Text = "Transfiere"
        '
        'TTRANSFIERE
        '
        Me.TTRANSFIERE.BackColor = System.Drawing.Color.White
        Me.TTRANSFIERE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TTRANSFIERE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTRANSFIERE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TTRANSFIERE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTRANSFIERE.Location = New System.Drawing.Point(119, 347)
        Me.TTRANSFIERE.MaxLength = 80
        Me.TTRANSFIERE.Name = "TTRANSFIERE"
        Me.TTRANSFIERE.Size = New System.Drawing.Size(437, 21)
        Me.TTRANSFIERE.TabIndex = 9
        Me.TTRANSFIERE.Tag = Nothing
        Me.TTRANSFIERE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 319)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 445
        Me.Label5.Text = "Revisa/autoriza"
        '
        'TREV_AUT
        '
        Me.TREV_AUT.BackColor = System.Drawing.Color.White
        Me.TREV_AUT.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TREV_AUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREV_AUT.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TREV_AUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREV_AUT.Location = New System.Drawing.Point(119, 318)
        Me.TREV_AUT.MaxLength = 80
        Me.TREV_AUT.Name = "TREV_AUT"
        Me.TREV_AUT.Size = New System.Drawing.Size(437, 21)
        Me.TREV_AUT.TabIndex = 8
        Me.TREV_AUT.Tag = Nothing
        Me.TREV_AUT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(59, 145)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 17)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Nombre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(74, 87)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 17)
        Me.Label10.TabIndex = 451
        Me.Label10.Text = "Clave"
        '
        'TCLAVE
        '
        Me.TCLAVE.BackColor = System.Drawing.Color.White
        Me.TCLAVE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCLAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.Location = New System.Drawing.Point(119, 85)
        Me.TCLAVE.MaxLength = 10
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(54, 21)
        Me.TCLAVE.TabIndex = 0
        Me.TCLAVE.Tag = Nothing
        Me.TCLAVE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(303, 96)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 16)
        Me.Label11.TabIndex = 454
        Me.Label11.Text = "Saldo disponible"
        '
        'LtSaldo
        '
        Me.LtSaldo.BackColor = System.Drawing.Color.White
        Me.LtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldo.ForeColor = System.Drawing.Color.Red
        Me.LtSaldo.Location = New System.Drawing.Point(418, 94)
        Me.LtSaldo.Name = "LtSaldo"
        Me.LtSaldo.Size = New System.Drawing.Size(138, 21)
        Me.LtSaldo.TabIndex = 453
        Me.LtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnFormaPago
        '
        Me.BtnFormaPago.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnFormaPago.Location = New System.Drawing.Point(176, 200)
        Me.BtnFormaPago.Name = "BtnFormaPago"
        Me.BtnFormaPago.Size = New System.Drawing.Size(23, 24)
        Me.BtnFormaPago.TabIndex = 436
        Me.BtnFormaPago.UseVisualStyleBackColor = True
        '
        'BtnProv
        '
        Me.BtnProv.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnProv.Location = New System.Drawing.Point(176, 110)
        Me.BtnProv.Name = "BtnProv"
        Me.BtnProv.Size = New System.Drawing.Size(23, 24)
        Me.BtnProv.TabIndex = 430
        Me.BtnProv.UseVisualStyleBackColor = True
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "e4ba7c1a79c24be593ea71fd3ec46df7"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(303, 66)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 16)
        Me.Label12.TabIndex = 457
        Me.Label12.Text = "Monto asignado"
        '
        'LtMonto
        '
        Me.LtMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMonto.ForeColor = System.Drawing.Color.Red
        Me.LtMonto.Location = New System.Drawing.Point(418, 64)
        Me.LtMonto.Name = "LtMonto"
        Me.LtMonto.Size = New System.Drawing.Size(138, 21)
        Me.LtMonto.TabIndex = 456
        Me.LtMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(580, 111)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 5
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(569, 329)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'LtSaldoGen
        '
        Me.LtSaldoGen.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSaldoGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldoGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldoGen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSaldoGen.Location = New System.Drawing.Point(777, 78)
        Me.LtSaldoGen.Name = "LtSaldoGen"
        Me.LtSaldoGen.Size = New System.Drawing.Size(160, 21)
        Me.LtSaldoGen.TabIndex = 460
        Me.LtSaldoGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(730, 80)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 461
        Me.Label14.Text = "Saldo"
        '
        'TIMPORTE
        '
        Me.TIMPORTE.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE.BorderColor = System.Drawing.Color.Blue
        Me.TIMPORTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPORTE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.CustomFormat = "###,###,###,##0.0000"
        Me.TIMPORTE.DisplayFormat.CustomFormat = "###,###,###,##0.0000"
        Me.TIMPORTE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.EditFormat.CustomFormat = "###,###,###,##0.0000"
        Me.TIMPORTE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPORTE.InterceptArrowKeys = False
        Me.TIMPORTE.Location = New System.Drawing.Point(119, 232)
        Me.TIMPORTE.Name = "TIMPORTE"
        Me.TIMPORTE.Size = New System.Drawing.Size(188, 21)
        Me.TIMPORTE.TabIndex = 5
        Me.TIMPORTE.Tag = Nothing
        Me.TIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPORTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(904, 458)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 17)
        Me.Label13.TabIndex = 464
        Me.Label13.Text = "Suma"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTotal.Location = New System.Drawing.Point(951, 456)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(160, 21)
        Me.LtTotal.TabIndex = 463
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmSolPagoProvAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 538)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.TIMPORTE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LtSaldoGen)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LtMonto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LtSaldo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TCLAVE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TTRANSFIERE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TREV_AUT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TSOLICITA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCONCEPTO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtFormaPago)
        Me.Controls.Add(Me.BtnFormaPago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TFORMAPAGO)
        Me.Controls.Add(Me.TFECHA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnProv)
        Me.Controls.Add(Me.LtBenef)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TCVE_PROV)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSolPagoProvAE"
        Me.ShowInTaskbar = False
        Me.Text = "Solicitud de pago a proveedores"
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_PROV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFORMAPAGO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSOLICITA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCONCEPTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTRANSFIERE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TREV_AUT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCLAVE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder1 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BtnProv As C1.Win.C1Input.C1Button
    Friend WithEvents LtBenef As Label
    Private WithEvents Label8 As Label
    Friend WithEvents TCVE_PROV As C1.Win.C1Input.C1TextBox
    Friend WithEvents TFECHA As C1.Win.Calendar.C1DateEdit
    Private WithEvents Label2 As Label
    Friend WithEvents LtFormaPago As Label
    Friend WithEvents BtnFormaPago As C1.Win.C1Input.C1Button
    Private WithEvents Label1 As Label
    Friend WithEvents TFORMAPAGO As C1.Win.C1Input.C1TextBox
    Private WithEvents Label6 As Label
    Private WithEvents Label7 As Label
    Friend WithEvents TSOLICITA As C1.Win.C1Input.C1TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents TCONCEPTO As C1.Win.C1Input.C1TextBox
    Private WithEvents Label4 As Label
    Friend WithEvents TTRANSFIERE As C1.Win.C1Input.C1TextBox
    Private WithEvents Label5 As Label
    Friend WithEvents TREV_AUT As C1.Win.C1Input.C1TextBox
    Private WithEvents Label9 As Label
    Private WithEvents Label10 As Label
    Friend WithEvents TCLAVE As C1.Win.C1Input.C1TextBox
    Private WithEvents Label11 As Label
    Friend WithEvents LtSaldo As Label
    Friend WithEvents BarReporte As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñoPeporte As C1.Win.C1Command.C1Command
    Friend WithEvents LkReporte As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Private WithEvents Label12 As Label
    Friend WithEvents LtMonto As Label
    Friend WithEvents LkDiseñoPeporte As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents Label14 As Label
    Friend WithEvents LtSaldoGen As Label
    Friend WithEvents TIMPORTE As C1.Win.C1Input.C1NumericEdit
    Private WithEvents Label13 As Label
    Friend WithEvents LtTotal As Label
End Class
