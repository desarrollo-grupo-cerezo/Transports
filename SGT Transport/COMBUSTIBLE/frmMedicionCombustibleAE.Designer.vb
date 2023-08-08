<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMedicionCombustibleAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicionCombustibleAE))
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.btnUni = New System.Windows.Forms.Button()
        Me.LtTanque1 = New System.Windows.Forms.Label()
        Me.LtTanque2 = New System.Windows.Forms.Label()
        Me.LtTanque3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCLAVE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtNivel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtSuma = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.btnOper = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtNivel2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtNivel3 = New System.Windows.Forms.Label()
        Me.tTanque1 = New System.Windows.Forms.TextBox()
        Me.btnTanque1 = New System.Windows.Forms.Button()
        Me.tTanque2 = New System.Windows.Forms.TextBox()
        Me.btnTanque2 = New System.Windows.Forms.Button()
        Me.tTanque3 = New System.Windows.Forms.TextBox()
        Me.btnTanque3 = New System.Windows.Forms.Button()
        Me.LtCm3 = New System.Windows.Forms.Label()
        Me.LtCm2 = New System.Windows.Forms.Label()
        Me.LtCm1 = New System.Windows.Forms.Label()
        Me.Box3 = New System.Windows.Forms.GroupBox()
        Me.radSalida = New System.Windows.Forms.RadioButton()
        Me.radEntrada = New System.Windows.Forms.RadioButton()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Box3.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(64, 304)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 16)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Tanque 1"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(64, 328)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(65, 16)
        Me.Nombre.TabIndex = 88
        Me.Nombre.Text = "Tanque 2"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(492, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 7
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(64, 358)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Tanque 3"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.Black
        Me.tCVE_UNI.Location = New System.Drawing.Point(105, 141)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(60, 22)
        Me.tCVE_UNI.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(47, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 244
        Me.Label2.Text = "Unidad"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtUnidad.Location = New System.Drawing.Point(192, 141)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(272, 20)
        Me.LtUnidad.TabIndex = 245
        Me.C1ThemeController1.SetTheme(Me.LtUnidad, "Office2010Blue")
        '
        'btnUni
        '
        Me.btnUni.AutoSize = True
        Me.btnUni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUni.BackColor = System.Drawing.Color.Transparent
        Me.btnUni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnUni.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnUni.Location = New System.Drawing.Point(166, 139)
        Me.btnUni.Name = "btnUni"
        Me.btnUni.Size = New System.Drawing.Size(24, 23)
        Me.btnUni.TabIndex = 246
        Me.C1ThemeController1.SetTheme(Me.btnUni, "Office2010Blue")
        Me.btnUni.UseVisualStyleBackColor = True
        '
        'LtTanque1
        '
        Me.LtTanque1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque1.Location = New System.Drawing.Point(318, 297)
        Me.LtTanque1.Name = "LtTanque1"
        Me.LtTanque1.Size = New System.Drawing.Size(100, 20)
        Me.LtTanque1.TabIndex = 248
        Me.LtTanque1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtTanque1, "Office2010Blue")
        '
        'LtTanque2
        '
        Me.LtTanque2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque2.Location = New System.Drawing.Point(318, 325)
        Me.LtTanque2.Name = "LtTanque2"
        Me.LtTanque2.Size = New System.Drawing.Size(100, 20)
        Me.LtTanque2.TabIndex = 249
        Me.LtTanque2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtTanque2, "Office2010Blue")
        '
        'LtTanque3
        '
        Me.LtTanque3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque3.Location = New System.Drawing.Point(318, 353)
        Me.LtTanque3.Name = "LtTanque3"
        Me.LtTanque3.Size = New System.Drawing.Size(100, 20)
        Me.LtTanque3.TabIndex = 250
        Me.LtTanque3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtTanque3, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(135, 274)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 20)
        Me.Label6.TabIndex = 251
        Me.Label6.Text = "CM"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(318, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "LT"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'tCLAVE
        '
        Me.tCLAVE.AcceptsReturn = True
        Me.tCLAVE.AcceptsTab = True
        Me.tCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE.Location = New System.Drawing.Point(105, 78)
        Me.tCLAVE.Name = "tCLAVE"
        Me.tCLAVE.Size = New System.Drawing.Size(60, 22)
        Me.tCLAVE.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCLAVE, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(56, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 254
        Me.Label8.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'LtNivel
        '
        Me.LtNivel.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNivel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNivel.Location = New System.Drawing.Point(609, 209)
        Me.LtNivel.Name = "LtNivel"
        Me.LtNivel.Size = New System.Drawing.Size(50, 20)
        Me.LtNivel.TabIndex = 255
        Me.LtNivel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtNivel, "Office2010Blue")
        Me.LtNivel.Visible = False
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(105, 109)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(121, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label108.Location = New System.Drawing.Point(53, 112)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(46, 16)
        Me.Label108.TabIndex = 262
        Me.Label108.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label108, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(589, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "ID"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        Me.Label3.Visible = False
        '
        'LtSuma
        '
        Me.LtSuma.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSuma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSuma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSuma.Location = New System.Drawing.Point(318, 384)
        Me.LtSuma.Name = "LtSuma"
        Me.LtSuma.Size = New System.Drawing.Size(100, 20)
        Me.LtSuma.TabIndex = 267
        Me.LtSuma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtSuma, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(269, 387)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 268
        Me.Label5.Text = "Suma"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.tCVE_OPER.Location = New System.Drawing.Point(105, 171)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(60, 22)
        Me.tCVE_OPER.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCVE_OPER, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(33, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 270
        Me.Label4.Text = "Operador"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtOper.Location = New System.Drawing.Point(192, 171)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(272, 20)
        Me.LtOper.TabIndex = 271
        Me.C1ThemeController1.SetTheme(Me.LtOper, "Office2010Blue")
        '
        'btnOper
        '
        Me.btnOper.AutoSize = True
        Me.btnOper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOper.BackColor = System.Drawing.Color.Transparent
        Me.btnOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnOper.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnOper.Location = New System.Drawing.Point(166, 169)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 23)
        Me.btnOper.TabIndex = 272
        Me.C1ThemeController1.SetTheme(Me.btnOper, "Office2010Blue")
        Me.btnOper.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(689, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "ID2"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        Me.Label9.Visible = False
        '
        'LtNivel2
        '
        Me.LtNivel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNivel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNivel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNivel2.Location = New System.Drawing.Point(719, 209)
        Me.LtNivel2.Name = "LtNivel2"
        Me.LtNivel2.Size = New System.Drawing.Size(50, 20)
        Me.LtNivel2.TabIndex = 273
        Me.LtNivel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtNivel2, "Office2010Blue")
        Me.LtNivel2.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(808, 213)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 276
        Me.Label11.Text = "ID3"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        Me.Label11.Visible = False
        '
        'LtNivel3
        '
        Me.LtNivel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNivel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNivel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNivel3.Location = New System.Drawing.Point(836, 209)
        Me.LtNivel3.Name = "LtNivel3"
        Me.LtNivel3.Size = New System.Drawing.Size(50, 20)
        Me.LtNivel3.TabIndex = 275
        Me.LtNivel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtNivel3, "Office2010Blue")
        Me.LtNivel3.Visible = False
        '
        'tTanque1
        '
        Me.tTanque1.AcceptsReturn = True
        Me.tTanque1.AcceptsTab = True
        Me.tTanque1.Enabled = False
        Me.tTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTanque1.ForeColor = System.Drawing.Color.Black
        Me.tTanque1.Location = New System.Drawing.Point(135, 297)
        Me.tTanque1.Name = "tTanque1"
        Me.tTanque1.Size = New System.Drawing.Size(49, 22)
        Me.tTanque1.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tTanque1, "Office2010Blue")
        '
        'btnTanque1
        '
        Me.btnTanque1.AutoSize = True
        Me.btnTanque1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTanque1.BackColor = System.Drawing.Color.Transparent
        Me.btnTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnTanque1.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTanque1.Location = New System.Drawing.Point(184, 296)
        Me.btnTanque1.Name = "btnTanque1"
        Me.btnTanque1.Size = New System.Drawing.Size(24, 23)
        Me.btnTanque1.TabIndex = 278
        Me.C1ThemeController1.SetTheme(Me.btnTanque1, "Office2010Blue")
        Me.btnTanque1.UseVisualStyleBackColor = True
        '
        'tTanque2
        '
        Me.tTanque2.AcceptsReturn = True
        Me.tTanque2.AcceptsTab = True
        Me.tTanque2.Enabled = False
        Me.tTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTanque2.ForeColor = System.Drawing.Color.Black
        Me.tTanque2.Location = New System.Drawing.Point(135, 325)
        Me.tTanque2.Name = "tTanque2"
        Me.tTanque2.Size = New System.Drawing.Size(49, 22)
        Me.tTanque2.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.tTanque2, "Office2010Blue")
        '
        'btnTanque2
        '
        Me.btnTanque2.AutoSize = True
        Me.btnTanque2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTanque2.BackColor = System.Drawing.Color.Transparent
        Me.btnTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnTanque2.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTanque2.Location = New System.Drawing.Point(184, 325)
        Me.btnTanque2.Name = "btnTanque2"
        Me.btnTanque2.Size = New System.Drawing.Size(24, 23)
        Me.btnTanque2.TabIndex = 280
        Me.C1ThemeController1.SetTheme(Me.btnTanque2, "Office2010Blue")
        Me.btnTanque2.UseVisualStyleBackColor = True
        '
        'tTanque3
        '
        Me.tTanque3.AcceptsReturn = True
        Me.tTanque3.AcceptsTab = True
        Me.tTanque3.Enabled = False
        Me.tTanque3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTanque3.ForeColor = System.Drawing.Color.Black
        Me.tTanque3.Location = New System.Drawing.Point(135, 353)
        Me.tTanque3.Name = "tTanque3"
        Me.tTanque3.Size = New System.Drawing.Size(49, 22)
        Me.tTanque3.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.tTanque3, "Office2010Blue")
        '
        'btnTanque3
        '
        Me.btnTanque3.AutoSize = True
        Me.btnTanque3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTanque3.BackColor = System.Drawing.Color.Transparent
        Me.btnTanque3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnTanque3.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTanque3.Location = New System.Drawing.Point(184, 353)
        Me.btnTanque3.Name = "btnTanque3"
        Me.btnTanque3.Size = New System.Drawing.Size(24, 23)
        Me.btnTanque3.TabIndex = 282
        Me.C1ThemeController1.SetTheme(Me.btnTanque3, "Office2010Blue")
        Me.btnTanque3.UseVisualStyleBackColor = True
        '
        'LtCm3
        '
        Me.LtCm3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCm3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCm3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCm3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCm3.Location = New System.Drawing.Point(210, 353)
        Me.LtCm3.Name = "LtCm3"
        Me.LtCm3.Size = New System.Drawing.Size(62, 20)
        Me.LtCm3.TabIndex = 285
        Me.LtCm3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtCm3, "Office2010Blue")
        '
        'LtCm2
        '
        Me.LtCm2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCm2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCm2.Location = New System.Drawing.Point(210, 325)
        Me.LtCm2.Name = "LtCm2"
        Me.LtCm2.Size = New System.Drawing.Size(62, 20)
        Me.LtCm2.TabIndex = 284
        Me.LtCm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtCm2, "Office2010Blue")
        '
        'LtCm1
        '
        Me.LtCm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCm1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCm1.Location = New System.Drawing.Point(210, 297)
        Me.LtCm1.Name = "LtCm1"
        Me.LtCm1.Size = New System.Drawing.Size(62, 20)
        Me.LtCm1.TabIndex = 283
        Me.LtCm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtCm1, "Office2010Blue")
        '
        'Box3
        '
        Me.Box3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Box3.Controls.Add(Me.radSalida)
        Me.Box3.Controls.Add(Me.radEntrada)
        Me.Box3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Box3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Box3.Location = New System.Drawing.Point(195, 209)
        Me.Box3.Name = "Box3"
        Me.Box3.Size = New System.Drawing.Size(176, 51)
        Me.Box3.TabIndex = 439
        Me.Box3.TabStop = False
        Me.Box3.Text = "Tipo de litros"
        Me.C1ThemeController1.SetTheme(Me.Box3, "Office2010Blue")
        '
        'radSalida
        '
        Me.radSalida.AutoSize = True
        Me.radSalida.BackColor = System.Drawing.Color.Transparent
        Me.radSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radSalida.Location = New System.Drawing.Point(91, 22)
        Me.radSalida.Name = "radSalida"
        Me.radSalida.Size = New System.Drawing.Size(65, 20)
        Me.radSalida.TabIndex = 9
        Me.radSalida.TabStop = True
        Me.radSalida.Text = "Salida"
        Me.C1ThemeController1.SetTheme(Me.radSalida, "Office2010Blue")
        Me.radSalida.UseVisualStyleBackColor = False
        '
        'radEntrada
        '
        Me.radEntrada.AutoSize = True
        Me.radEntrada.BackColor = System.Drawing.Color.Transparent
        Me.radEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radEntrada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radEntrada.Location = New System.Drawing.Point(17, 22)
        Me.radEntrada.Name = "radEntrada"
        Me.radEntrada.Size = New System.Drawing.Size(73, 20)
        Me.radEntrada.TabIndex = 8
        Me.radEntrada.TabStop = True
        Me.radEntrada.Text = "Entrada"
        Me.C1ThemeController1.SetTheme(Me.radEntrada, "Office2010Blue")
        Me.radEntrada.UseVisualStyleBackColor = False
        '
        'frmMedicionCombustibleAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 426)
        Me.Controls.Add(Me.Box3)
        Me.Controls.Add(Me.LtCm3)
        Me.Controls.Add(Me.LtCm2)
        Me.Controls.Add(Me.LtCm1)
        Me.Controls.Add(Me.tTanque3)
        Me.Controls.Add(Me.btnTanque3)
        Me.Controls.Add(Me.tTanque2)
        Me.Controls.Add(Me.btnTanque2)
        Me.Controls.Add(Me.tTanque1)
        Me.Controls.Add(Me.btnTanque1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LtNivel3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtNivel2)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.btnOper)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtSuma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.LtNivel)
        Me.Controls.Add(Me.tCLAVE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtTanque3)
        Me.Controls.Add(Me.LtTanque2)
        Me.Controls.Add(Me.LtTanque1)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.btnUni)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMedicionCombustibleAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Medición Combustible"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Box3.ResumeLayout(False)
        Me.Box3.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Label1 As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LtUnidad As Label
    Friend WithEvents btnUni As Button
    Friend WithEvents LtTanque1 As Label
    Friend WithEvents LtTanque2 As Label
    Friend WithEvents LtTanque3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tCLAVE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents LtNivel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label108 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtSuma As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents btnOper As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents LtNivel2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LtNivel3 As Label
    Friend WithEvents tTanque1 As TextBox
    Friend WithEvents btnTanque1 As Button
    Friend WithEvents tTanque2 As TextBox
    Friend WithEvents btnTanque2 As Button
    Friend WithEvents tTanque3 As TextBox
    Friend WithEvents btnTanque3 As Button
    Friend WithEvents LtCm3 As Label
    Friend WithEvents LtCm2 As Label
    Friend WithEvents LtCm1 As Label
    Friend WithEvents Box3 As GroupBox
    Friend WithEvents radSalida As RadioButton
    Friend WithEvents radEntrada As RadioButton
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
