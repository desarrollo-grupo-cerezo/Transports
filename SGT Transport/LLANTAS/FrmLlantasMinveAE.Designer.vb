<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLlantasMinveAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLlantasMinveAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.RadEntrada = New System.Windows.Forms.RadioButton()
        Me.RadSalida = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TREFER = New System.Windows.Forms.TextBox()
        Me.TNUM_ECONOMICO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnNumEconomico = New C1.Win.C1Input.C1Button()
        Me.LtArt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tCOSTO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tTIPO_LLANTA = New System.Windows.Forms.TextBox()
        Me.btnTipoLlanta = New C1.Win.C1Input.C1Button()
        Me.LtTipo = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtStstus_LLanta = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnNumEconomico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTipoLlanta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.add
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(466, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "Office2010Blue")
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        '
        'RadEntrada
        '
        Me.RadEntrada.AutoSize = True
        Me.RadEntrada.BackColor = System.Drawing.Color.Transparent
        Me.RadEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadEntrada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadEntrada.Location = New System.Drawing.Point(119, 64)
        Me.RadEntrada.Name = "RadEntrada"
        Me.RadEntrada.Size = New System.Drawing.Size(68, 19)
        Me.RadEntrada.TabIndex = 0
        Me.RadEntrada.TabStop = True
        Me.RadEntrada.Text = "Entrada"
        Me.C1ThemeController1.SetTheme(Me.RadEntrada, "Office2010Blue")
        Me.RadEntrada.UseVisualStyleBackColor = False
        '
        'RadSalida
        '
        Me.RadSalida.AutoSize = True
        Me.RadSalida.BackColor = System.Drawing.Color.Transparent
        Me.RadSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadSalida.Location = New System.Drawing.Point(269, 64)
        Me.RadSalida.Name = "RadSalida"
        Me.RadSalida.Size = New System.Drawing.Size(60, 19)
        Me.RadSalida.TabIndex = 1
        Me.RadSalida.TabStop = True
        Me.RadSalida.Text = "Salida"
        Me.C1ThemeController1.SetTheme(Me.RadSalida, "Office2010Blue")
        Me.RadSalida.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(64, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Referencia"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TREFER
        '
        Me.TREFER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREFER.ForeColor = System.Drawing.Color.Black
        Me.TREFER.Location = New System.Drawing.Point(135, 105)
        Me.TREFER.MaxLength = 20
        Me.TREFER.Name = "TREFER"
        Me.TREFER.Size = New System.Drawing.Size(194, 21)
        Me.TREFER.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.TREFER, "Office2010Blue")
        '
        'TNUM_ECONOMICO
        '
        Me.TNUM_ECONOMICO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_ECONOMICO.ForeColor = System.Drawing.Color.Black
        Me.TNUM_ECONOMICO.Location = New System.Drawing.Point(135, 201)
        Me.TNUM_ECONOMICO.MaxLength = 30
        Me.TNUM_ECONOMICO.Name = "TNUM_ECONOMICO"
        Me.TNUM_ECONOMICO.Size = New System.Drawing.Size(158, 21)
        Me.TNUM_ECONOMICO.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.TNUM_ECONOMICO, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(30, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Num. economico"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'BtnNumEconomico
        '
        Me.BtnNumEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNumEconomico.Image = CType(resources.GetObject("BtnNumEconomico.Image"), System.Drawing.Image)
        Me.BtnNumEconomico.Location = New System.Drawing.Point(296, 201)
        Me.BtnNumEconomico.Name = "BtnNumEconomico"
        Me.BtnNumEconomico.Size = New System.Drawing.Size(23, 20)
        Me.BtnNumEconomico.TabIndex = 213
        Me.C1ThemeController1.SetTheme(Me.BtnNumEconomico, "Office2010Blue")
        Me.BtnNumEconomico.UseVisualStyleBackColor = True
        Me.BtnNumEconomico.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtArt
        '
        Me.LtArt.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtArt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtArt.Location = New System.Drawing.Point(135, 237)
        Me.LtArt.Name = "LtArt"
        Me.LtArt.Size = New System.Drawing.Size(158, 21)
        Me.LtArt.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.LtArt, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(84, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 216
        Me.Label3.Text = "Artículo"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'tCOSTO
        '
        Me.tCOSTO.Enabled = False
        Me.tCOSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOSTO.ForeColor = System.Drawing.Color.Black
        Me.tCOSTO.Location = New System.Drawing.Point(135, 315)
        Me.tCOSTO.MaxLength = 9
        Me.tCOSTO.Name = "tCOSTO"
        Me.tCOSTO.Size = New System.Drawing.Size(115, 21)
        Me.tCOSTO.TabIndex = 6
        Me.tCOSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tCOSTO, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(93, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "Costo"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'tTIPO_LLANTA
        '
        Me.tTIPO_LLANTA.AcceptsReturn = True
        Me.tTIPO_LLANTA.AcceptsTab = True
        Me.tTIPO_LLANTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tTIPO_LLANTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTIPO_LLANTA.ForeColor = System.Drawing.Color.Black
        Me.tTIPO_LLANTA.Location = New System.Drawing.Point(135, 274)
        Me.tTIPO_LLANTA.MaxLength = 10
        Me.tTIPO_LLANTA.Name = "tTIPO_LLANTA"
        Me.tTIPO_LLANTA.Size = New System.Drawing.Size(46, 21)
        Me.tTIPO_LLANTA.TabIndex = 5
        Me.tTIPO_LLANTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.tTIPO_LLANTA, "Office2010Blue")
        '
        'btnTipoLlanta
        '
        Me.btnTipoLlanta.AutoSize = True
        Me.btnTipoLlanta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTipoLlanta.Image = CType(resources.GetObject("btnTipoLlanta.Image"), System.Drawing.Image)
        Me.btnTipoLlanta.Location = New System.Drawing.Point(183, 273)
        Me.btnTipoLlanta.Name = "btnTipoLlanta"
        Me.btnTipoLlanta.Size = New System.Drawing.Size(22, 22)
        Me.btnTipoLlanta.TabIndex = 220
        Me.C1ThemeController1.SetTheme(Me.btnTipoLlanta, "Office2010Blue")
        Me.btnTipoLlanta.UseVisualStyleBackColor = True
        Me.btnTipoLlanta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtTipo
        '
        Me.LtTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTipo.Location = New System.Drawing.Point(209, 274)
        Me.LtTipo.Name = "LtTipo"
        Me.LtTipo.Size = New System.Drawing.Size(197, 21)
        Me.LtTipo.TabIndex = 222
        Me.C1ThemeController1.SetTheme(Me.LtTipo, "Office2010Blue")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(67, 277)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 15)
        Me.Label14.TabIndex = 221
        Me.Label14.Text = "Tipo llanta"
        Me.C1ThemeController1.SetTheme(Me.Label14, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(59, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 228
        Me.Label5.Text = "Descripción"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L2.Location = New System.Drawing.Point(135, 170)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(271, 20)
        Me.L2.TabIndex = 227
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L2, "Office2010Blue")
        '
        'btnUnidades
        '
        Me.btnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(228, 137)
        Me.btnUnidades.Name = "btnUnidades"
        Me.btnUnidades.Size = New System.Drawing.Size(23, 20)
        Me.btnUnidades.TabIndex = 226
        Me.C1ThemeController1.SetTheme(Me.btnUnidades, "Office2010Blue")
        Me.btnUnidades.UseVisualStyleBackColor = True
        Me.btnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.Black
        Me.tCVE_UNI.Location = New System.Drawing.Point(135, 137)
        Me.tCVE_UNI.MaxLength = 10
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(87, 21)
        Me.tCVE_UNI.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(84, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Unidad"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'btnNumCpto
        '
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(184, 347)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(26, 20)
        Me.btnNumCpto.TabIndex = 386
        Me.C1ThemeController1.SetTheme(Me.btnNumCpto, "Office2010Blue")
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L1.Location = New System.Drawing.Point(213, 346)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(193, 20)
        Me.L1.TabIndex = 387
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L1, "Office2010Blue")
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.ForeColor = System.Drawing.Color.Black
        Me.tNUM_CPTO.Location = New System.Drawing.Point(135, 346)
        Me.tNUM_CPTO.MaxLength = 3
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(47, 22)
        Me.tNUM_CPTO.TabIndex = 6
        Me.tNUM_CPTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.tNUM_CPTO, "Office2010Blue")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(65, 349)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 388
        Me.Label7.Text = "Num.  cpto"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'LtStstus_LLanta
        '
        Me.LtStstus_LLanta.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtStstus_LLanta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtStstus_LLanta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtStstus_LLanta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtStstus_LLanta.Location = New System.Drawing.Point(213, 380)
        Me.LtStstus_LLanta.Name = "LtStstus_LLanta"
        Me.LtStstus_LLanta.Size = New System.Drawing.Size(193, 20)
        Me.LtStstus_LLanta.TabIndex = 390
        Me.LtStstus_LLanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtStstus_LLanta, "Office2010Blue")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(132, 382)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Estatus llanta"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'FrmLlantasMinveAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 423)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtStstus_LLanta)
        Me.Controls.Add(Me.btnNumCpto)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.tNUM_CPTO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.btnUnidades)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tTIPO_LLANTA)
        Me.Controls.Add(Me.btnTipoLlanta)
        Me.Controls.Add(Me.LtTipo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tCOSTO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtArt)
        Me.Controls.Add(Me.BtnNumEconomico)
        Me.Controls.Add(Me.TNUM_ECONOMICO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TREFER)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadSalida)
        Me.Controls.Add(Me.RadEntrada)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLlantasMinveAE"
        Me.Text = "Movimiento al inventario llantas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnNumEconomico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTipoLlanta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents RadEntrada As RadioButton
    Friend WithEvents RadSalida As RadioButton
    Friend WithEvents TREFER As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TNUM_ECONOMICO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnNumEconomico As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LtArt As Label
    Friend WithEvents tCOSTO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tTIPO_LLANTA As TextBox
    Friend WithEvents btnTipoLlanta As C1.Win.C1Input.C1Button
    Friend WithEvents LtTipo As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Label5 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents C1ComboBox1 As C1.Win.C1Input.C1ComboBox
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents L1 As Label
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtStstus_LLanta As Label
End Class
