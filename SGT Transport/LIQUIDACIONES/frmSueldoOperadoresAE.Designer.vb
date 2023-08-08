<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSueldoOperadoresAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSueldoOperadoresAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOrigen = New System.Windows.Forms.Button()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.tCLAVE_O = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LtPlaza2 = New System.Windows.Forms.Label()
        Me.Box4 = New System.Windows.Forms.GroupBox()
        Me.RadVacio = New System.Windows.Forms.RadioButton()
        Me.RadCargado = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadSencillo = New System.Windows.Forms.RadioButton()
        Me.RadFull = New System.Windows.Forms.RadioButton()
        Me.tSUELDO = New C1.Win.C1Input.C1TextBox()
        Me.L9 = New System.Windows.Forms.Label()
        Me.tCVE_SUOP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnPlazaO = New System.Windows.Forms.Button()
        Me.LtOrigen = New System.Windows.Forms.Label()
        Me.tPLAZA_O = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPlazaD = New System.Windows.Forms.Button()
        Me.tPLAZA_D = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.TOBSER = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TSUELDO_SENC = New C1.Win.C1Input.C1TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnTabRuta = New System.Windows.Forms.Button()
        Me.TCVE_TAB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        Me.Box4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tSUELDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSUELDO_SENC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Padding = New System.Windows.Forms.Padding(1, 1, 0, 1)
        Me.barSalir.Size = New System.Drawing.Size(576, 37)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 1
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 35)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 35)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnOrigen
        '
        Me.btnOrigen.AutoSize = True
        Me.btnOrigen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOrigen.BackColor = System.Drawing.Color.Transparent
        Me.btnOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnOrigen.Image = CType(resources.GetObject("btnOrigen.Image"), System.Drawing.Image)
        Me.btnOrigen.Location = New System.Drawing.Point(173, 119)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(24, 23)
        Me.btnOrigen.TabIndex = 444
        Me.C1ThemeController1.SetTheme(Me.btnOrigen, "Office2010Blue")
        Me.btnOrigen.UseVisualStyleBackColor = True
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(197, 153)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(316, 20)
        Me.LtPlaza.TabIndex = 441
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'tCLAVE_O
        '
        Me.tCLAVE_O.AcceptsReturn = True
        Me.tCLAVE_O.AcceptsTab = True
        Me.tCLAVE_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE_O.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE_O.Location = New System.Drawing.Point(122, 121)
        Me.tCLAVE_O.Name = "tCLAVE_O"
        Me.tCLAVE_O.Size = New System.Drawing.Size(50, 22)
        Me.tCLAVE_O.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCLAVE_O, "Office2010Blue")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(67, 124)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 16)
        Me.Label22.TabIndex = 440
        Me.Label22.Text = "Cliente"
        Me.C1ThemeController1.SetTheme(Me.Label22, "Office2010Blue")
        '
        'LtPlaza2
        '
        Me.LtPlaza2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza2.Location = New System.Drawing.Point(197, 187)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(316, 20)
        Me.LtPlaza2.TabIndex = 443
        Me.C1ThemeController1.SetTheme(Me.LtPlaza2, "Office2010Blue")
        '
        'Box4
        '
        Me.Box4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Box4.Controls.Add(Me.RadVacio)
        Me.Box4.Controls.Add(Me.RadCargado)
        Me.Box4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Box4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Box4.Location = New System.Drawing.Point(397, 219)
        Me.Box4.Name = "Box4"
        Me.Box4.Size = New System.Drawing.Size(116, 98)
        Me.Box4.TabIndex = 7
        Me.Box4.TabStop = False
        Me.Box4.Text = "Tipo viaje"
        Me.C1ThemeController1.SetTheme(Me.Box4, "Office2010Blue")
        '
        'RadVacio
        '
        Me.RadVacio.AutoSize = True
        Me.RadVacio.BackColor = System.Drawing.Color.Transparent
        Me.RadVacio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadVacio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadVacio.Location = New System.Drawing.Point(10, 63)
        Me.RadVacio.Name = "RadVacio"
        Me.RadVacio.Size = New System.Drawing.Size(61, 20)
        Me.RadVacio.TabIndex = 1
        Me.RadVacio.TabStop = True
        Me.RadVacio.Text = "Vacio"
        Me.C1ThemeController1.SetTheme(Me.RadVacio, "Office2010Blue")
        Me.RadVacio.UseVisualStyleBackColor = False
        '
        'RadCargado
        '
        Me.RadCargado.AutoSize = True
        Me.RadCargado.BackColor = System.Drawing.Color.Transparent
        Me.RadCargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCargado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadCargado.Location = New System.Drawing.Point(10, 28)
        Me.RadCargado.Name = "RadCargado"
        Me.RadCargado.Size = New System.Drawing.Size(79, 20)
        Me.RadCargado.TabIndex = 0
        Me.RadCargado.TabStop = True
        Me.RadCargado.Text = "Cargado"
        Me.C1ThemeController1.SetTheme(Me.RadCargado, "Office2010Blue")
        Me.RadCargado.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.RadSencillo)
        Me.GroupBox1.Controls.Add(Me.RadFull)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(271, 219)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(119, 98)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo viaje"
        Me.C1ThemeController1.SetTheme(Me.GroupBox1, "Office2010Blue")
        '
        'RadSencillo
        '
        Me.RadSencillo.AutoSize = True
        Me.RadSencillo.BackColor = System.Drawing.Color.Transparent
        Me.RadSencillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSencillo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadSencillo.Location = New System.Drawing.Point(10, 63)
        Me.RadSencillo.Name = "RadSencillo"
        Me.RadSencillo.Size = New System.Drawing.Size(74, 20)
        Me.RadSencillo.TabIndex = 1
        Me.RadSencillo.TabStop = True
        Me.RadSencillo.Text = "Sencillo"
        Me.C1ThemeController1.SetTheme(Me.RadSencillo, "Office2010Blue")
        Me.RadSencillo.UseVisualStyleBackColor = False
        '
        'RadFull
        '
        Me.RadFull.AutoSize = True
        Me.RadFull.BackColor = System.Drawing.Color.Transparent
        Me.RadFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFull.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.RadFull.Location = New System.Drawing.Point(10, 28)
        Me.RadFull.Name = "RadFull"
        Me.RadFull.Size = New System.Drawing.Size(47, 20)
        Me.RadFull.TabIndex = 0
        Me.RadFull.TabStop = True
        Me.RadFull.Text = "Full"
        Me.C1ThemeController1.SetTheme(Me.RadFull, "Office2010Blue")
        Me.RadFull.UseVisualStyleBackColor = False
        '
        'tSUELDO
        '
        Me.tSUELDO.AcceptsReturn = True
        Me.tSUELDO.AcceptsTab = True
        Me.tSUELDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tSUELDO.CustomFormat = "###,###,##0.00"
        Me.tSUELDO.DataType = GetType(Decimal)
        Me.tSUELDO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tSUELDO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tSUELDO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tSUELDO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tSUELDO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tSUELDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUELDO.Location = New System.Drawing.Point(122, 217)
        Me.tSUELDO.Name = "tSUELDO"
        Me.tSUELDO.Size = New System.Drawing.Size(127, 20)
        Me.tSUELDO.TabIndex = 5
        Me.tSUELDO.Tag = Nothing
        Me.tSUELDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tSUELDO, "Office2010Blue")
        Me.tSUELDO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L9
        '
        Me.L9.AutoSize = True
        Me.L9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L9.Location = New System.Drawing.Point(46, 219)
        Me.L9.Name = "L9"
        Me.L9.Size = New System.Drawing.Size(70, 16)
        Me.L9.TabIndex = 533
        Me.L9.Text = "Sueldo full"
        Me.C1ThemeController1.SetTheme(Me.L9, "Office2010Blue")
        '
        'tCVE_SUOP
        '
        Me.tCVE_SUOP.AcceptsReturn = True
        Me.tCVE_SUOP.AcceptsTab = True
        Me.tCVE_SUOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_SUOP.ForeColor = System.Drawing.Color.Black
        Me.tCVE_SUOP.Location = New System.Drawing.Point(122, 57)
        Me.tCVE_SUOP.Name = "tCVE_SUOP"
        Me.tCVE_SUOP.Size = New System.Drawing.Size(50, 22)
        Me.tCVE_SUOP.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_SUOP, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(73, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 535
        Me.Label1.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'BtnPlazaO
        '
        Me.BtnPlazaO.AutoSize = True
        Me.BtnPlazaO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPlazaO.BackColor = System.Drawing.Color.Transparent
        Me.BtnPlazaO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlazaO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnPlazaO.Image = CType(resources.GetObject("BtnPlazaO.Image"), System.Drawing.Image)
        Me.BtnPlazaO.Location = New System.Drawing.Point(173, 152)
        Me.BtnPlazaO.Name = "BtnPlazaO"
        Me.BtnPlazaO.Size = New System.Drawing.Size(24, 23)
        Me.BtnPlazaO.TabIndex = 542
        Me.C1ThemeController1.SetTheme(Me.BtnPlazaO, "Office2010Blue")
        Me.BtnPlazaO.UseVisualStyleBackColor = True
        '
        'LtOrigen
        '
        Me.LtOrigen.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtOrigen.Location = New System.Drawing.Point(197, 121)
        Me.LtOrigen.Name = "LtOrigen"
        Me.LtOrigen.Size = New System.Drawing.Size(316, 20)
        Me.LtOrigen.TabIndex = 539
        Me.C1ThemeController1.SetTheme(Me.LtOrigen, "Office2010Blue")
        '
        'tPLAZA_O
        '
        Me.tPLAZA_O.AcceptsReturn = True
        Me.tPLAZA_O.AcceptsTab = True
        Me.tPLAZA_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPLAZA_O.ForeColor = System.Drawing.Color.Black
        Me.tPLAZA_O.Location = New System.Drawing.Point(122, 153)
        Me.tPLAZA_O.Name = "tPLAZA_O"
        Me.tPLAZA_O.Size = New System.Drawing.Size(50, 22)
        Me.tPLAZA_O.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tPLAZA_O, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(74, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 538
        Me.Label3.Text = "Plaza"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'BtnPlazaD
        '
        Me.BtnPlazaD.AutoSize = True
        Me.BtnPlazaD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPlazaD.BackColor = System.Drawing.Color.Transparent
        Me.BtnPlazaD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlazaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnPlazaD.Image = CType(resources.GetObject("BtnPlazaD.Image"), System.Drawing.Image)
        Me.BtnPlazaD.Location = New System.Drawing.Point(172, 185)
        Me.BtnPlazaD.Name = "BtnPlazaD"
        Me.BtnPlazaD.Size = New System.Drawing.Size(24, 23)
        Me.BtnPlazaD.TabIndex = 543
        Me.C1ThemeController1.SetTheme(Me.BtnPlazaD, "Office2010Blue")
        Me.BtnPlazaD.UseVisualStyleBackColor = True
        '
        'tPLAZA_D
        '
        Me.tPLAZA_D.AcceptsReturn = True
        Me.tPLAZA_D.AcceptsTab = True
        Me.tPLAZA_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPLAZA_D.ForeColor = System.Drawing.Color.Black
        Me.tPLAZA_D.Location = New System.Drawing.Point(122, 185)
        Me.tPLAZA_D.Name = "tPLAZA_D"
        Me.tPLAZA_D.Size = New System.Drawing.Size(50, 22)
        Me.tPLAZA_D.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tPLAZA_D, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(74, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 540
        Me.Label5.Text = "Plaza"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'TOBSER
        '
        Me.TOBSER.AcceptsReturn = True
        Me.TOBSER.AcceptsTab = True
        Me.TOBSER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBSER.ForeColor = System.Drawing.Color.Black
        Me.TOBSER.Location = New System.Drawing.Point(122, 337)
        Me.TOBSER.MaxLength = 255
        Me.TOBSER.Name = "TOBSER"
        Me.TOBSER.Size = New System.Drawing.Size(391, 22)
        Me.TOBSER.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.TOBSER, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(18, 339)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 545
        Me.Label2.Text = "Observaciones"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'TSUELDO_SENC
        '
        Me.TSUELDO_SENC.AcceptsReturn = True
        Me.TSUELDO_SENC.AcceptsTab = True
        Me.TSUELDO_SENC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TSUELDO_SENC.CustomFormat = "###,###,##0.00"
        Me.TSUELDO_SENC.DataType = GetType(Decimal)
        Me.TSUELDO_SENC.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TSUELDO_SENC.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TSUELDO_SENC.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TSUELDO_SENC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TSUELDO_SENC.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TSUELDO_SENC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSUELDO_SENC.Location = New System.Drawing.Point(122, 247)
        Me.TSUELDO_SENC.Name = "TSUELDO_SENC"
        Me.TSUELDO_SENC.Size = New System.Drawing.Size(127, 20)
        Me.TSUELDO_SENC.TabIndex = 6
        Me.TSUELDO_SENC.Tag = Nothing
        Me.TSUELDO_SENC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.TSUELDO_SENC, "Office2010Blue")
        Me.TSUELDO_SENC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 547
        Me.Label4.Text = "Sueldo sencillo"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'BtnTabRuta
        '
        Me.BtnTabRuta.AutoSize = True
        Me.BtnTabRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnTabRuta.BackColor = System.Drawing.Color.Transparent
        Me.BtnTabRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTabRuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnTabRuta.Image = CType(resources.GetObject("BtnTabRuta.Image"), System.Drawing.Image)
        Me.BtnTabRuta.Location = New System.Drawing.Point(197, 88)
        Me.BtnTabRuta.Name = "BtnTabRuta"
        Me.BtnTabRuta.Size = New System.Drawing.Size(24, 23)
        Me.BtnTabRuta.TabIndex = 550
        Me.C1ThemeController1.SetTheme(Me.BtnTabRuta, "Office2010Blue")
        Me.BtnTabRuta.UseVisualStyleBackColor = True
        '
        'TCVE_TAB
        '
        Me.TCVE_TAB.AcceptsReturn = True
        Me.TCVE_TAB.AcceptsTab = True
        Me.TCVE_TAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TAB.ForeColor = System.Drawing.Color.Black
        Me.TCVE_TAB.Location = New System.Drawing.Point(122, 89)
        Me.TCVE_TAB.Name = "TCVE_TAB"
        Me.TCVE_TAB.Size = New System.Drawing.Size(75, 22)
        Me.TCVE_TAB.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.TCVE_TAB, "Office2010Blue")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(80, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 549
        Me.Label7.Text = "Ruta"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'frmSueldoOperadoresAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 387)
        Me.Controls.Add(Me.BtnTabRuta)
        Me.Controls.Add(Me.TCVE_TAB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TSUELDO_SENC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TOBSER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnPlazaO)
        Me.Controls.Add(Me.LtOrigen)
        Me.Controls.Add(Me.tPLAZA_O)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnPlazaD)
        Me.Controls.Add(Me.tPLAZA_D)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tCVE_SUOP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tSUELDO)
        Me.Controls.Add(Me.L9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOrigen)
        Me.Controls.Add(Me.LtPlaza)
        Me.Controls.Add(Me.tCLAVE_O)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.LtPlaza2)
        Me.Controls.Add(Me.Box4)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSueldoOperadoresAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sueldo operadores"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.Box4.ResumeLayout(False)
        Me.Box4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tSUELDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSUELDO_SENC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents btnOrigen As Button
    Friend WithEvents LtPlaza As Label
    Friend WithEvents tCLAVE_O As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents LtPlaza2 As Label
    Friend WithEvents Box4 As GroupBox
    Friend WithEvents RadVacio As RadioButton
    Friend WithEvents RadCargado As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadSencillo As RadioButton
    Friend WithEvents RadFull As RadioButton
    Friend WithEvents tSUELDO As C1.Win.C1Input.C1TextBox
    Friend WithEvents L9 As Label
    Friend WithEvents tCVE_SUOP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnPlazaO As Button
    Friend WithEvents LtOrigen As Label
    Friend WithEvents tPLAZA_O As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnPlazaD As Button
    Friend WithEvents tPLAZA_D As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents TOBSER As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TSUELDO_SENC As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnTabRuta As Button
    Friend WithEvents TCVE_TAB As TextBox
    Friend WithEvents Label7 As Label
End Class
