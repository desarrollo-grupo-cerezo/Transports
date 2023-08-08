<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstatusOperCaptura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstatusOperCaptura))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTanque2 = New C1.Win.C1Input.C1Button()
        Me.btnTanque1 = New C1.Win.C1Input.C1Button()
        Me.LtTanque1 = New System.Windows.Forms.Label()
        Me.tCVE_TANQUE2 = New System.Windows.Forms.TextBox()
        Me.LTanque1 = New System.Windows.Forms.Label()
        Me.LaTractor = New System.Windows.Forms.Label()
        Me.tCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.LtTractor = New System.Windows.Forms.Label()
        Me.btnTractor = New C1.Win.C1Input.C1Button()
        Me.LTanque2 = New System.Windows.Forms.Label()
        Me.LtTanque2 = New System.Windows.Forms.Label()
        Me.tCVE_TANQUE1 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.LtClave = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.tCVE_OBS = New System.Windows.Forms.TextBox()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTanque2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTanque1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(623, 43)
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
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 437
        Me.Label1.Text = "Observaciones"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'btnTanque2
        '
        Me.btnTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTanque2.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnTanque2.Location = New System.Drawing.Point(201, 200)
        Me.btnTanque2.Name = "btnTanque2"
        Me.btnTanque2.Size = New System.Drawing.Size(24, 21)
        Me.btnTanque2.TabIndex = 430
        Me.C1ThemeController1.SetTheme(Me.btnTanque2, "Office2010Blue")
        Me.btnTanque2.UseVisualStyleBackColor = True
        Me.btnTanque2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnTanque1
        '
        Me.btnTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTanque1.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnTanque1.Location = New System.Drawing.Point(201, 174)
        Me.btnTanque1.Name = "btnTanque1"
        Me.btnTanque1.Size = New System.Drawing.Size(24, 21)
        Me.btnTanque1.TabIndex = 428
        Me.C1ThemeController1.SetTheme(Me.btnTanque1, "Office2010Blue")
        Me.btnTanque1.UseVisualStyleBackColor = True
        Me.btnTanque1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtTanque1
        '
        Me.LtTanque1.AutoSize = True
        Me.LtTanque1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque1.Location = New System.Drawing.Point(65, 177)
        Me.LtTanque1.Name = "LtTanque1"
        Me.LtTanque1.Size = New System.Drawing.Size(59, 15)
        Me.LtTanque1.TabIndex = 429
        Me.LtTanque1.Text = "Tanque 1"
        Me.C1ThemeController1.SetTheme(Me.LtTanque1, "Office2010Blue")
        '
        'tCVE_TANQUE2
        '
        Me.tCVE_TANQUE2.AcceptsReturn = True
        Me.tCVE_TANQUE2.AcceptsTab = True
        Me.tCVE_TANQUE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_TANQUE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TANQUE2.ForeColor = System.Drawing.Color.Black
        Me.tCVE_TANQUE2.Location = New System.Drawing.Point(130, 200)
        Me.tCVE_TANQUE2.MaxLength = 10
        Me.tCVE_TANQUE2.Name = "tCVE_TANQUE2"
        Me.tCVE_TANQUE2.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_TANQUE2.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCVE_TANQUE2, "Office2010Blue")
        '
        'LTanque1
        '
        Me.LTanque1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LTanque1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LTanque1.Location = New System.Drawing.Point(229, 174)
        Me.LTanque1.Name = "LTanque1"
        Me.LTanque1.Size = New System.Drawing.Size(226, 21)
        Me.LTanque1.TabIndex = 431
        Me.LTanque1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LTanque1, "Office2010Blue")
        '
        'LaTractor
        '
        Me.LaTractor.AutoSize = True
        Me.LaTractor.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LaTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaTractor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LaTractor.Location = New System.Drawing.Point(79, 151)
        Me.LaTractor.Name = "LaTractor"
        Me.LaTractor.Size = New System.Drawing.Size(45, 15)
        Me.LaTractor.TabIndex = 432
        Me.LaTractor.Text = "Tractor"
        Me.C1ThemeController1.SetTheme(Me.LaTractor, "Office2010Blue")
        '
        'tCVE_TRACTOR
        '
        Me.tCVE_TRACTOR.AcceptsReturn = True
        Me.tCVE_TRACTOR.AcceptsTab = True
        Me.tCVE_TRACTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TRACTOR.ForeColor = System.Drawing.Color.Black
        Me.tCVE_TRACTOR.Location = New System.Drawing.Point(130, 148)
        Me.tCVE_TRACTOR.MaxLength = 10
        Me.tCVE_TRACTOR.Name = "tCVE_TRACTOR"
        Me.tCVE_TRACTOR.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_TRACTOR.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_TRACTOR, "Office2010Blue")
        '
        'LtTractor
        '
        Me.LtTractor.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTractor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTractor.Location = New System.Drawing.Point(229, 148)
        Me.LtTractor.Name = "LtTractor"
        Me.LtTractor.Size = New System.Drawing.Size(226, 21)
        Me.LtTractor.TabIndex = 433
        Me.LtTractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtTractor, "Office2010Blue")
        '
        'btnTractor
        '
        Me.btnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTractor.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnTractor.Location = New System.Drawing.Point(201, 148)
        Me.btnTractor.Name = "btnTractor"
        Me.btnTractor.Size = New System.Drawing.Size(24, 21)
        Me.btnTractor.TabIndex = 435
        Me.C1ThemeController1.SetTheme(Me.btnTractor, "Office2010Blue")
        Me.btnTractor.UseVisualStyleBackColor = True
        Me.btnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LTanque2
        '
        Me.LTanque2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LTanque2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LTanque2.Location = New System.Drawing.Point(229, 200)
        Me.LTanque2.Name = "LTanque2"
        Me.LTanque2.Size = New System.Drawing.Size(226, 21)
        Me.LTanque2.TabIndex = 436
        Me.LTanque2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LTanque2, "Office2010Blue")
        '
        'LtTanque2
        '
        Me.LtTanque2.AutoSize = True
        Me.LtTanque2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque2.Location = New System.Drawing.Point(65, 203)
        Me.LtTanque2.Name = "LtTanque2"
        Me.LtTanque2.Size = New System.Drawing.Size(59, 15)
        Me.LtTanque2.TabIndex = 434
        Me.LtTanque2.Text = "Tanque 2"
        Me.C1ThemeController1.SetTheme(Me.LtTanque2, "Office2010Blue")
        '
        'tCVE_TANQUE1
        '
        Me.tCVE_TANQUE1.AcceptsReturn = True
        Me.tCVE_TANQUE1.AcceptsTab = True
        Me.tCVE_TANQUE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_TANQUE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TANQUE1.ForeColor = System.Drawing.Color.Black
        Me.tCVE_TANQUE1.Location = New System.Drawing.Point(130, 174)
        Me.tCVE_TANQUE1.MaxLength = 10
        Me.tCVE_TANQUE1.Name = "tCVE_TANQUE1"
        Me.tCVE_TANQUE1.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_TANQUE1.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_TANQUE1, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(87, 81)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 15)
        Me.Label27.TabIndex = 427
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(72, 115)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(52, 15)
        Me.Nombre.TabIndex = 426
        Me.Nombre.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'LtClave
        '
        Me.LtClave.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtClave.Location = New System.Drawing.Point(130, 81)
        Me.LtClave.Name = "LtClave"
        Me.LtClave.Size = New System.Drawing.Size(69, 21)
        Me.LtClave.TabIndex = 439
        Me.LtClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtClave, "Office2010Blue")
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(130, 112)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(325, 21)
        Me.LtNombre.TabIndex = 440
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'tCVE_OBS
        '
        Me.tCVE_OBS.AcceptsReturn = True
        Me.tCVE_OBS.AcceptsTab = True
        Me.tCVE_OBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_OBS.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OBS.ForeColor = System.Drawing.Color.Black
        Me.tCVE_OBS.Location = New System.Drawing.Point(130, 242)
        Me.tCVE_OBS.Multiline = True
        Me.tCVE_OBS.Name = "tCVE_OBS"
        Me.tCVE_OBS.Size = New System.Drawing.Size(481, 99)
        Me.tCVE_OBS.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tCVE_OBS, "Office2010Blue")
        '
        'frmEstatusOperCaptura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 353)
        Me.Controls.Add(Me.tCVE_OBS)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.LtClave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTanque2)
        Me.Controls.Add(Me.btnTanque1)
        Me.Controls.Add(Me.LtTanque1)
        Me.Controls.Add(Me.tCVE_TANQUE2)
        Me.Controls.Add(Me.LTanque1)
        Me.Controls.Add(Me.LaTractor)
        Me.Controls.Add(Me.tCVE_TRACTOR)
        Me.Controls.Add(Me.LtTractor)
        Me.Controls.Add(Me.btnTractor)
        Me.Controls.Add(Me.LTanque2)
        Me.Controls.Add(Me.LtTanque2)
        Me.Controls.Add(Me.tCVE_TANQUE1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstatusOperCaptura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estatus Operador"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTanque2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTanque1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label1 As Label
    Friend WithEvents btnTanque2 As C1.Win.C1Input.C1Button
    Friend WithEvents btnTanque1 As C1.Win.C1Input.C1Button
    Friend WithEvents LtTanque1 As Label
    Friend WithEvents tCVE_TANQUE2 As TextBox
    Friend WithEvents LTanque1 As Label
    Friend WithEvents LaTractor As Label
    Friend WithEvents tCVE_TRACTOR As TextBox
    Friend WithEvents LtTractor As Label
    Friend WithEvents btnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents LTanque2 As Label
    Friend WithEvents LtTanque2 As Label
    Friend WithEvents tCVE_TANQUE1 As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents LtClave As Label
    Friend WithEvents tCVE_OBS As TextBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
