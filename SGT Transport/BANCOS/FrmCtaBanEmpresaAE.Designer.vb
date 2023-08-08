<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCtaBanEmpresaAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCtaBanEmpresaAE))
        Me.TCTA_BANCARIA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TRFC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCVE_BANCO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.TSUCURSAL = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TEJECUTIVO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TALIAS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TCLABE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TCorreo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TTelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCiudad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TCalle = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TSALDO = New C1.Win.C1Input.C1NumericEdit()
        Me.CboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSALDO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCTA_BANCARIA
        '
        Me.TCTA_BANCARIA.AcceptsReturn = True
        Me.TCTA_BANCARIA.AcceptsTab = True
        Me.TCTA_BANCARIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTA_BANCARIA.Location = New System.Drawing.Point(158, 118)
        Me.TCTA_BANCARIA.MaxLength = 60
        Me.TCTA_BANCARIA.Name = "TCTA_BANCARIA"
        Me.TCTA_BANCARIA.Size = New System.Drawing.Size(290, 23)
        Me.TCTA_BANCARIA.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Cuenta bancaria"
        '
        'TRFC
        '
        Me.TRFC.AcceptsReturn = True
        Me.TRFC.AcceptsTab = True
        Me.TRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFC.Location = New System.Drawing.Point(159, 346)
        Me.TRFC.MaxLength = 20
        Me.TRFC.Name = "TRFC"
        Me.TRFC.Size = New System.Drawing.Size(168, 23)
        Me.TRFC.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(110, 350)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "R.F.C."
        '
        'TCVE_BANCO
        '
        Me.TCVE_BANCO.AcceptsReturn = True
        Me.TCVE_BANCO.AcceptsTab = True
        Me.TCVE_BANCO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_BANCO.Location = New System.Drawing.Point(159, 89)
        Me.TCVE_BANCO.Name = "TCVE_BANCO"
        Me.TCVE_BANCO.Size = New System.Drawing.Size(65, 23)
        Me.TCVE_BANCO.TabIndex = 0
        Me.TCVE_BANCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(114, 92)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 17)
        Me.Label27.TabIndex = 153
        Me.Label27.Text = "Clave"
        '
        'TNOMBRE
        '
        Me.TNOMBRE.AcceptsReturn = True
        Me.TNOMBRE.AcceptsTab = True
        Me.TNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRE.Location = New System.Drawing.Point(159, 147)
        Me.TNOMBRE.MaxLength = 90
        Me.TNOMBRE.Name = "TNOMBRE"
        Me.TNOMBRE.Size = New System.Drawing.Size(414, 23)
        Me.TNOMBRE.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(99, 150)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(58, 17)
        Me.Nombre.TabIndex = 152
        Me.Nombre.Text = "Nombre"
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(658, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 151
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(159, 205)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(138, 21)
        Me.F1.TabIndex = 4
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'TSUCURSAL
        '
        Me.TSUCURSAL.AcceptsReturn = True
        Me.TSUCURSAL.AcceptsTab = True
        Me.TSUCURSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSUCURSAL.Location = New System.Drawing.Point(159, 317)
        Me.TSUCURSAL.MaxLength = 80
        Me.TSUCURSAL.Name = "TSUCURSAL"
        Me.TSUCURSAL.Size = New System.Drawing.Size(414, 23)
        Me.TSUCURSAL.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(94, 321)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 17)
        Me.Label11.TabIndex = 467
        Me.Label11.Text = "Sucursal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(119, 292)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 17)
        Me.Label12.TabIndex = 466
        Me.Label12.Text = "Alias"
        '
        'TEJECUTIVO
        '
        Me.TEJECUTIVO.AcceptsReturn = True
        Me.TEJECUTIVO.AcceptsTab = True
        Me.TEJECUTIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEJECUTIVO.Location = New System.Drawing.Point(159, 259)
        Me.TEJECUTIVO.MaxLength = 120
        Me.TEJECUTIVO.Name = "TEJECUTIVO"
        Me.TEJECUTIVO.Size = New System.Drawing.Size(414, 23)
        Me.TEJECUTIVO.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(92, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 464
        Me.Label7.Text = "Ejecutivo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(74, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 17)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Saldo inicial"
        '
        'TALIAS
        '
        Me.TALIAS.AcceptsReturn = True
        Me.TALIAS.AcceptsTab = True
        Me.TALIAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TALIAS.Location = New System.Drawing.Point(159, 288)
        Me.TALIAS.MaxLength = 60
        Me.TALIAS.Name = "TALIAS"
        Me.TALIAS.Size = New System.Drawing.Size(414, 23)
        Me.TALIAS.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 17)
        Me.Label9.TabIndex = 462
        Me.Label9.Text = "Fecha apertura"
        '
        'TCLABE
        '
        Me.TCLABE.AcceptsReturn = True
        Me.TCLABE.AcceptsTab = True
        Me.TCLABE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLABE.Location = New System.Drawing.Point(159, 176)
        Me.TCLABE.MaxLength = 80
        Me.TCLABE.Name = "TCLABE"
        Me.TCLABE.Size = New System.Drawing.Size(289, 23)
        Me.TCLABE.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(105, 179)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 461
        Me.Label10.Text = "CLABE"
        '
        'TCorreo
        '
        Me.TCorreo.AcceptsReturn = True
        Me.TCorreo.AcceptsTab = True
        Me.TCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCorreo.Location = New System.Drawing.Point(159, 462)
        Me.TCorreo.MaxLength = 60
        Me.TCorreo.Name = "TCorreo"
        Me.TCorreo.Size = New System.Drawing.Size(414, 23)
        Me.TCorreo.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(106, 466)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 459
        Me.Label4.Text = "Correo"
        '
        'TTelefono
        '
        Me.TTelefono.AcceptsReturn = True
        Me.TTelefono.AcceptsTab = True
        Me.TTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTelefono.Location = New System.Drawing.Point(159, 433)
        Me.TTelefono.MaxLength = 60
        Me.TTelefono.Name = "TTelefono"
        Me.TTelefono.Size = New System.Drawing.Size(289, 23)
        Me.TTelefono.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 458
        Me.Label3.Text = "Telefono"
        '
        'TCiudad
        '
        Me.TCiudad.AcceptsReturn = True
        Me.TCiudad.AcceptsTab = True
        Me.TCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCiudad.Location = New System.Drawing.Point(159, 404)
        Me.TCiudad.MaxLength = 60
        Me.TCiudad.Name = "TCiudad"
        Me.TCiudad.Size = New System.Drawing.Size(289, 23)
        Me.TCiudad.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(105, 408)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 17)
        Me.Label13.TabIndex = 457
        Me.Label13.Text = "Ciudad"
        '
        'TCalle
        '
        Me.TCalle.AcceptsReturn = True
        Me.TCalle.AcceptsTab = True
        Me.TCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCalle.Location = New System.Drawing.Point(159, 375)
        Me.TCalle.MaxLength = 120
        Me.TCalle.Name = "TCalle"
        Me.TCalle.Size = New System.Drawing.Size(414, 23)
        Me.TCalle.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(118, 379)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 17)
        Me.Label14.TabIndex = 456
        Me.Label14.Text = "Calle"
        '
        'TSALDO
        '
        Me.TSALDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TSALDO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.TSALDO.Calculator.ButtonFlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TSALDO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TSALDO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.TSALDO.CustomFormat = "###,###,##0.00"
        Me.TSALDO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TSALDO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TSALDO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TSALDO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TSALDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSALDO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TSALDO.Location = New System.Drawing.Point(159, 232)
        Me.TSALDO.Name = "TSALDO"
        Me.TSALDO.Size = New System.Drawing.Size(138, 21)
        Me.TSALDO.TabIndex = 5
        Me.TSALDO.Tag = Nothing
        Me.TSALDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TSALDO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CboMoneda
        '
        Me.CboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoneda.DropDownWidth = 200
        Me.CboMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMoneda.FormattingEnabled = True
        Me.CboMoneda.Location = New System.Drawing.Point(378, 229)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(195, 24)
        Me.CboMoneda.TabIndex = 469
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(310, 234)
        Me.Label24.Margin = New System.Windows.Forms.Padding(3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 16)
        Me.Label24.TabIndex = 468
        Me.Label24.Text = "*Moneda"
        '
        'FrmCtaBanEmpresaAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 495)
        Me.Controls.Add(Me.CboMoneda)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TSALDO)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.TSUCURSAL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TEJECUTIVO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TALIAS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TCLABE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TCorreo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TTelefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCiudad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TCalle)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TCTA_BANCARIA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TRFC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TCVE_BANCO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCtaBanEmpresaAE"
        Me.ShowInTaskbar = False
        Me.Text = "Cuenta bancaria de la empresa"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSALDO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCTA_BANCARIA As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TRFC As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TCVE_BANCO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TNOMBRE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents TSUCURSAL As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TEJECUTIVO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TALIAS As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TCLABE As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TCorreo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TTelefono As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TCiudad As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TCalle As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TSALDO As C1.Win.C1Input.C1NumericEdit
    Private WithEvents CboMoneda As ComboBox
    Private WithEvents Label24 As Label
End Class
