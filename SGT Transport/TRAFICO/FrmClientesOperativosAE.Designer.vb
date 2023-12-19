<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClientesOperativosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesOperativosAE))
        Me.TCLAVE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TRFC = New System.Windows.Forms.TextBox()
        Me.TPLANTA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TNOTA = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TDOMICILIO = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TNUMEXT = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCOLONIA = New System.Windows.Forms.TextBox()
        Me.TCOLONIA_SAT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TLOCALIDAD_SAT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TLOCALIDAD = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TMUNICIPIO_SAT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TMUNICIPIO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TESTADO_SAT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TESTADO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TPAIS_SAT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TPAIS = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCP_SAT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TCP = New System.Windows.Forms.TextBox()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.BtnCP = New C1.Win.C1Input.C1Button()
        Me.BtnColonia = New C1.Win.C1Input.C1Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TNUMINT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TDOMICILIO2 = New System.Windows.Forms.TextBox()
        Me.BtnMunicipio = New C1.Win.C1Input.C1Button()
        Me.BtnLocalidad = New C1.Win.C1Input.C1Button()
        Me.BtnEstado = New C1.Win.C1Input.C1Button()
        Me.BtnPais = New C1.Win.C1Input.C1Button()
        Me.BtnCP2 = New C1.Win.C1Input.C1Button()
        Me.BtnGrabarCteFiscal = New C1.Win.C1Input.C1Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TNUMREGIDTRIB = New C1.Win.C1Input.C1TextBox()
        Me.BtnISTMO = New C1.Win.C1Input.C1Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxCveRegistroISTMO = New System.Windows.Forms.TextBox()
        Me.RadialMenuItem1 = New C1.Win.C1Command.RadialMenuItem()
        Me.RadialMenuItem2 = New C1.Win.C1Command.RadialMenuItem()
        Me.BarMenu.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnColonia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGrabarCteFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUMREGIDTRIB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnISTMO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCLAVE
        '
        Me.TCLAVE.AcceptsReturn = True
        Me.TCLAVE.AcceptsTab = True
        Me.TCLAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.ForeColor = System.Drawing.Color.Black
        Me.TCLAVE.Location = New System.Drawing.Point(109, 92)
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(110, 23)
        Me.TCLAVE.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.TCLAVE, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(62, 95)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 17)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'TNOMBRE
        '
        Me.TNOMBRE.AcceptsReturn = True
        Me.TNOMBRE.AcceptsTab = True
        Me.TNOMBRE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRE.ForeColor = System.Drawing.Color.Black
        Me.TNOMBRE.Location = New System.Drawing.Point(109, 146)
        Me.TNOMBRE.Name = "TNOMBRE"
        Me.TNOMBRE.Size = New System.Drawing.Size(465, 23)
        Me.TNOMBRE.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.TNOMBRE, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(47, 149)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(58, 17)
        Me.Nombre.TabIndex = 88
        Me.Nombre.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'BarMenu
        '
        Me.BarMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(619, 55)
        Me.BarMenu.Stretch = False
        Me.BarMenu.TabIndex = 21
        Me.BarMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarMenu, "Office2010Blue")
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(37, 175)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 17)
        Me.Label29.TabIndex = 246
        Me.Label29.Text = "Domicilio "
        Me.C1ThemeController1.SetTheme(Me.Label29, "Office2010Blue")
        '
        'TRFC
        '
        Me.TRFC.AcceptsReturn = True
        Me.TRFC.AcceptsTab = True
        Me.TRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFC.ForeColor = System.Drawing.Color.Black
        Me.TRFC.Location = New System.Drawing.Point(109, 440)
        Me.TRFC.Name = "TRFC"
        Me.TRFC.Size = New System.Drawing.Size(151, 23)
        Me.TRFC.TabIndex = 16
        Me.C1ThemeController1.SetTheme(Me.TRFC, "Office2010Blue")
        '
        'TPLANTA
        '
        Me.TPLANTA.AcceptsReturn = True
        Me.TPLANTA.AcceptsTab = True
        Me.TPLANTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPLANTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPLANTA.ForeColor = System.Drawing.Color.Black
        Me.TPLANTA.Location = New System.Drawing.Point(109, 414)
        Me.TPLANTA.Name = "TPLANTA"
        Me.TPLANTA.Size = New System.Drawing.Size(464, 23)
        Me.TPLANTA.TabIndex = 15
        Me.C1ThemeController1.SetTheme(Me.TPLANTA, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(58, 443)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "R.F.C."
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'TNOTA
        '
        Me.TNOTA.AcceptsReturn = True
        Me.TNOTA.AcceptsTab = True
        Me.TNOTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOTA.ForeColor = System.Drawing.Color.Black
        Me.TNOTA.Location = New System.Drawing.Point(109, 119)
        Me.TNOTA.MaxLength = 120
        Me.TNOTA.Name = "TNOTA"
        Me.TNOTA.Size = New System.Drawing.Size(464, 23)
        Me.TNOTA.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.TNOTA, "Office2010Blue")
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(67, 124)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(38, 17)
        Me.Label45.TabIndex = 247
        Me.Label45.Text = "Alias"
        Me.C1ThemeController1.SetTheme(Me.Label45, "Office2010Blue")
        '
        'TDOMICILIO
        '
        Me.TDOMICILIO.AcceptsReturn = True
        Me.TDOMICILIO.AcceptsTab = True
        Me.TDOMICILIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDOMICILIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDOMICILIO.ForeColor = System.Drawing.Color.Black
        Me.TDOMICILIO.Location = New System.Drawing.Point(109, 173)
        Me.TDOMICILIO.Name = "TDOMICILIO"
        Me.TDOMICILIO.Size = New System.Drawing.Size(465, 23)
        Me.TDOMICILIO.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.TDOMICILIO, "Office2010Blue")
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(38, 230)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(67, 17)
        Me.Label44.TabIndex = 248
        Me.Label44.Text = "Num. ext."
        Me.C1ThemeController1.SetTheme(Me.Label44, "Office2010Blue")
        '
        'TNUMEXT
        '
        Me.TNUMEXT.AcceptsReturn = True
        Me.TNUMEXT.AcceptsTab = True
        Me.TNUMEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMEXT.ForeColor = System.Drawing.Color.Black
        Me.TNUMEXT.Location = New System.Drawing.Point(109, 227)
        Me.TNUMEXT.Name = "TNUMEXT"
        Me.TNUMEXT.Size = New System.Drawing.Size(110, 23)
        Me.TNUMEXT.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.TNUMEXT, "Office2010Blue")
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(57, 417)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 17)
        Me.Label34.TabIndex = 249
        Me.Label34.Text = "Planta"
        Me.C1ThemeController1.SetTheme(Me.Label34, "Office2010Blue")
        '
        'TCUEN_CONT
        '
        Me.TCUEN_CONT.AcceptsReturn = True
        Me.TCUEN_CONT.AcceptsTab = True
        Me.TCUEN_CONT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCUEN_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUEN_CONT.ForeColor = System.Drawing.Color.Black
        Me.TCUEN_CONT.Location = New System.Drawing.Point(379, 440)
        Me.TCUEN_CONT.MaxLength = 28
        Me.TCUEN_CONT.Name = "TCUEN_CONT"
        Me.TCUEN_CONT.Size = New System.Drawing.Size(195, 23)
        Me.TCUEN_CONT.TabIndex = 17
        Me.C1ThemeController1.SetTheme(Me.TCUEN_CONT, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(264, 445)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "Cuenta contable"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(50, 390)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "Colonia"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TCOLONIA
        '
        Me.TCOLONIA.AcceptsReturn = True
        Me.TCOLONIA.AcceptsTab = True
        Me.TCOLONIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLONIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLONIA.ForeColor = System.Drawing.Color.Black
        Me.TCOLONIA.Location = New System.Drawing.Point(109, 387)
        Me.TCOLONIA.MaxLength = 50
        Me.TCOLONIA.Name = "TCOLONIA"
        Me.TCOLONIA.Size = New System.Drawing.Size(303, 23)
        Me.TCOLONIA.TabIndex = 14
        Me.C1ThemeController1.SetTheme(Me.TCOLONIA, "Office2010Blue")
        '
        'TCOLONIA_SAT
        '
        Me.TCOLONIA_SAT.AcceptsReturn = True
        Me.TCOLONIA_SAT.AcceptsTab = True
        Me.TCOLONIA_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCOLONIA_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOLONIA_SAT.ForeColor = System.Drawing.Color.Black
        Me.TCOLONIA_SAT.Location = New System.Drawing.Point(493, 387)
        Me.TCOLONIA_SAT.MaxLength = 10
        Me.TCOLONIA_SAT.Name = "TCOLONIA_SAT"
        Me.TCOLONIA_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TCOLONIA_SAT.TabIndex = 13
        Me.C1ThemeController1.SetTheme(Me.TCOLONIA_SAT, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(417, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(417, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 296
        Me.Label4.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'TLOCALIDAD_SAT
        '
        Me.TLOCALIDAD_SAT.AcceptsReturn = True
        Me.TLOCALIDAD_SAT.AcceptsTab = True
        Me.TLOCALIDAD_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLOCALIDAD_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD_SAT.ForeColor = System.Drawing.Color.Black
        Me.TLOCALIDAD_SAT.Location = New System.Drawing.Point(493, 307)
        Me.TLOCALIDAD_SAT.MaxLength = 10
        Me.TLOCALIDAD_SAT.Name = "TLOCALIDAD_SAT"
        Me.TLOCALIDAD_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TLOCALIDAD_SAT.TabIndex = 10
        Me.C1ThemeController1.SetTheme(Me.TLOCALIDAD_SAT, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(36, 310)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 17)
        Me.Label6.TabIndex = 294
        Me.Label6.Text = "Localidad"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'TLOCALIDAD
        '
        Me.TLOCALIDAD.AcceptsReturn = True
        Me.TLOCALIDAD.AcceptsTab = True
        Me.TLOCALIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLOCALIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD.ForeColor = System.Drawing.Color.Black
        Me.TLOCALIDAD.Location = New System.Drawing.Point(109, 307)
        Me.TLOCALIDAD.MaxLength = 50
        Me.TLOCALIDAD.Name = "TLOCALIDAD"
        Me.TLOCALIDAD.ReadOnly = True
        Me.TLOCALIDAD.Size = New System.Drawing.Size(303, 23)
        Me.TLOCALIDAD.TabIndex = 9
        Me.C1ThemeController1.SetTheme(Me.TLOCALIDAD, "Office2010Blue")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(417, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 300
        Me.Label7.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'TMUNICIPIO_SAT
        '
        Me.TMUNICIPIO_SAT.AcceptsReturn = True
        Me.TMUNICIPIO_SAT.AcceptsTab = True
        Me.TMUNICIPIO_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMUNICIPIO_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMUNICIPIO_SAT.ForeColor = System.Drawing.Color.Black
        Me.TMUNICIPIO_SAT.Location = New System.Drawing.Point(493, 280)
        Me.TMUNICIPIO_SAT.MaxLength = 10
        Me.TMUNICIPIO_SAT.Name = "TMUNICIPIO_SAT"
        Me.TMUNICIPIO_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TMUNICIPIO_SAT.TabIndex = 9
        Me.C1ThemeController1.SetTheme(Me.TMUNICIPIO_SAT, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(38, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 17)
        Me.Label8.TabIndex = 298
        Me.Label8.Text = "Municipio"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'TMUNICIPIO
        '
        Me.TMUNICIPIO.AcceptsReturn = True
        Me.TMUNICIPIO.AcceptsTab = True
        Me.TMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMUNICIPIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.TMUNICIPIO.Location = New System.Drawing.Point(109, 280)
        Me.TMUNICIPIO.MaxLength = 50
        Me.TMUNICIPIO.Name = "TMUNICIPIO"
        Me.TMUNICIPIO.ReadOnly = True
        Me.TMUNICIPIO.Size = New System.Drawing.Size(303, 23)
        Me.TMUNICIPIO.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.TMUNICIPIO, "Office2010Blue")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(417, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 304
        Me.Label9.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'TESTADO_SAT
        '
        Me.TESTADO_SAT.AcceptsReturn = True
        Me.TESTADO_SAT.AcceptsTab = True
        Me.TESTADO_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TESTADO_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESTADO_SAT.ForeColor = System.Drawing.Color.Black
        Me.TESTADO_SAT.Location = New System.Drawing.Point(493, 334)
        Me.TESTADO_SAT.MaxLength = 10
        Me.TESTADO_SAT.Name = "TESTADO_SAT"
        Me.TESTADO_SAT.ReadOnly = True
        Me.TESTADO_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TESTADO_SAT.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.TESTADO_SAT, "Office2010Blue")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(53, 337)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 302
        Me.Label10.Text = "Estado"
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'TESTADO
        '
        Me.TESTADO.AcceptsReturn = True
        Me.TESTADO.AcceptsTab = True
        Me.TESTADO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESTADO.ForeColor = System.Drawing.Color.Black
        Me.TESTADO.Location = New System.Drawing.Point(109, 334)
        Me.TESTADO.MaxLength = 50
        Me.TESTADO.Name = "TESTADO"
        Me.TESTADO.ReadOnly = True
        Me.TESTADO.Size = New System.Drawing.Size(303, 23)
        Me.TESTADO.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.TESTADO, "Office2010Blue")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(417, 364)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 17)
        Me.Label11.TabIndex = 308
        Me.Label11.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        '
        'TPAIS_SAT
        '
        Me.TPAIS_SAT.AcceptsReturn = True
        Me.TPAIS_SAT.AcceptsTab = True
        Me.TPAIS_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAIS_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAIS_SAT.ForeColor = System.Drawing.Color.Black
        Me.TPAIS_SAT.Location = New System.Drawing.Point(493, 361)
        Me.TPAIS_SAT.MaxLength = 10
        Me.TPAIS_SAT.Name = "TPAIS_SAT"
        Me.TPAIS_SAT.ReadOnly = True
        Me.TPAIS_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TPAIS_SAT.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.TPAIS_SAT, "Office2010Blue")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(70, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 17)
        Me.Label13.TabIndex = 306
        Me.Label13.Text = "Pais"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2010Blue")
        '
        'TPAIS
        '
        Me.TPAIS.AcceptsReturn = True
        Me.TPAIS.AcceptsTab = True
        Me.TPAIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAIS.ForeColor = System.Drawing.Color.Black
        Me.TPAIS.Location = New System.Drawing.Point(109, 361)
        Me.TPAIS.MaxLength = 50
        Me.TPAIS.Name = "TPAIS"
        Me.TPAIS.ReadOnly = True
        Me.TPAIS.Size = New System.Drawing.Size(303, 23)
        Me.TPAIS.TabIndex = 13
        Me.C1ThemeController1.SetTheme(Me.TPAIS, "Office2010Blue")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(700, 313)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 17)
        Me.Label14.TabIndex = 312
        Me.Label14.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label14, "Office2010Blue")
        Me.Label14.Visible = False
        '
        'TCP_SAT
        '
        Me.TCP_SAT.AcceptsReturn = True
        Me.TCP_SAT.AcceptsTab = True
        Me.TCP_SAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCP_SAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCP_SAT.ForeColor = System.Drawing.Color.Black
        Me.TCP_SAT.Location = New System.Drawing.Point(776, 310)
        Me.TCP_SAT.MaxLength = 5
        Me.TCP_SAT.Name = "TCP_SAT"
        Me.TCP_SAT.Size = New System.Drawing.Size(81, 23)
        Me.TCP_SAT.TabIndex = 15
        Me.C1ThemeController1.SetTheme(Me.TCP_SAT, "Office2010Blue")
        Me.TCP_SAT.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(457, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 17)
        Me.Label15.TabIndex = 310
        Me.Label15.Text = "C.P."
        Me.C1ThemeController1.SetTheme(Me.Label15, "Office2010Blue")
        '
        'TCP
        '
        Me.TCP.AcceptsReturn = True
        Me.TCP.AcceptsTab = True
        Me.TCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCP.ForeColor = System.Drawing.Color.Black
        Me.TCP.Location = New System.Drawing.Point(493, 254)
        Me.TCP.MaxLength = 5
        Me.TCP.Name = "TCP"
        Me.TCP.Size = New System.Drawing.Size(80, 23)
        Me.TCP.TabIndex = 8
        Me.C1ThemeController1.SetTheme(Me.TCP, "Office2010Blue")
        '
        'BtnCP
        '
        Me.BtnCP.FlatAppearance.BorderSize = 0
        Me.BtnCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCP.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnCP.Location = New System.Drawing.Point(574, 252)
        Me.BtnCP.Name = "BtnCP"
        Me.BtnCP.Size = New System.Drawing.Size(23, 24)
        Me.BtnCP.TabIndex = 619
        Me.C1ThemeController1.SetTheme(Me.BtnCP, "(default)")
        Me.BtnCP.UseVisualStyleBackColor = True
        '
        'BtnColonia
        '
        Me.BtnColonia.FlatAppearance.BorderSize = 0
        Me.BtnColonia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnColonia.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnColonia.Location = New System.Drawing.Point(574, 386)
        Me.BtnColonia.Name = "BtnColonia"
        Me.BtnColonia.Size = New System.Drawing.Size(23, 24)
        Me.BtnColonia.TabIndex = 622
        Me.C1ThemeController1.SetTheme(Me.BtnColonia, "(default)")
        Me.BtnColonia.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(228, 230)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 17)
        Me.Label16.TabIndex = 624
        Me.Label16.Text = "Num. int."
        Me.C1ThemeController1.SetTheme(Me.Label16, "Office2010Blue")
        '
        'TNUMINT
        '
        Me.TNUMINT.AcceptsReturn = True
        Me.TNUMINT.AcceptsTab = True
        Me.TNUMINT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMINT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMINT.ForeColor = System.Drawing.Color.Black
        Me.TNUMINT.Location = New System.Drawing.Point(300, 227)
        Me.TNUMINT.Name = "TNUMINT"
        Me.TNUMINT.Size = New System.Drawing.Size(110, 23)
        Me.TNUMINT.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.TNUMINT, "Office2010Blue")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(29, 203)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 17)
        Me.Label17.TabIndex = 626
        Me.Label17.Text = "Domicilio 2"
        Me.C1ThemeController1.SetTheme(Me.Label17, "Office2010Blue")
        '
        'TDOMICILIO2
        '
        Me.TDOMICILIO2.AcceptsReturn = True
        Me.TDOMICILIO2.AcceptsTab = True
        Me.TDOMICILIO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDOMICILIO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDOMICILIO2.ForeColor = System.Drawing.Color.Black
        Me.TDOMICILIO2.Location = New System.Drawing.Point(109, 200)
        Me.TDOMICILIO2.Name = "TDOMICILIO2"
        Me.TDOMICILIO2.Size = New System.Drawing.Size(465, 23)
        Me.TDOMICILIO2.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.TDOMICILIO2, "Office2010Blue")
        '
        'BtnMunicipio
        '
        Me.BtnMunicipio.FlatAppearance.BorderSize = 0
        Me.BtnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMunicipio.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnMunicipio.Location = New System.Drawing.Point(575, 279)
        Me.BtnMunicipio.Name = "BtnMunicipio"
        Me.BtnMunicipio.Size = New System.Drawing.Size(23, 24)
        Me.BtnMunicipio.TabIndex = 627
        Me.C1ThemeController1.SetTheme(Me.BtnMunicipio, "(default)")
        Me.BtnMunicipio.UseVisualStyleBackColor = True
        '
        'BtnLocalidad
        '
        Me.BtnLocalidad.FlatAppearance.BorderSize = 0
        Me.BtnLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLocalidad.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnLocalidad.Location = New System.Drawing.Point(575, 306)
        Me.BtnLocalidad.Name = "BtnLocalidad"
        Me.BtnLocalidad.Size = New System.Drawing.Size(23, 24)
        Me.BtnLocalidad.TabIndex = 628
        Me.C1ThemeController1.SetTheme(Me.BtnLocalidad, "(default)")
        Me.BtnLocalidad.UseVisualStyleBackColor = True
        '
        'BtnEstado
        '
        Me.BtnEstado.FlatAppearance.BorderSize = 0
        Me.BtnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEstado.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnEstado.Location = New System.Drawing.Point(575, 333)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(23, 24)
        Me.BtnEstado.TabIndex = 629
        Me.C1ThemeController1.SetTheme(Me.BtnEstado, "(default)")
        Me.BtnEstado.UseVisualStyleBackColor = True
        '
        'BtnPais
        '
        Me.BtnPais.FlatAppearance.BorderSize = 0
        Me.BtnPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPais.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnPais.Location = New System.Drawing.Point(575, 360)
        Me.BtnPais.Name = "BtnPais"
        Me.BtnPais.Size = New System.Drawing.Size(23, 24)
        Me.BtnPais.TabIndex = 630
        Me.C1ThemeController1.SetTheme(Me.BtnPais, "(default)")
        Me.BtnPais.UseVisualStyleBackColor = True
        '
        'BtnCP2
        '
        Me.BtnCP2.FlatAppearance.BorderSize = 0
        Me.BtnCP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCP2.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnCP2.Location = New System.Drawing.Point(751, 333)
        Me.BtnCP2.Name = "BtnCP2"
        Me.BtnCP2.Size = New System.Drawing.Size(23, 24)
        Me.BtnCP2.TabIndex = 631
        Me.C1ThemeController1.SetTheme(Me.BtnCP2, "(default)")
        Me.BtnCP2.UseVisualStyleBackColor = True
        Me.BtnCP2.Visible = False
        '
        'BtnGrabarCteFiscal
        '
        Me.BtnGrabarCteFiscal.FlatAppearance.BorderSize = 0
        Me.BtnGrabarCteFiscal.Location = New System.Drawing.Point(493, 12)
        Me.BtnGrabarCteFiscal.Name = "BtnGrabarCteFiscal"
        Me.BtnGrabarCteFiscal.Size = New System.Drawing.Size(86, 37)
        Me.BtnGrabarCteFiscal.TabIndex = 632
        Me.BtnGrabarCteFiscal.Text = "Grabar como cliente fiscal"
        Me.C1ThemeController1.SetTheme(Me.BtnGrabarCteFiscal, "(default)")
        Me.BtnGrabarCteFiscal.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 260)
        Me.Label43.Margin = New System.Windows.Forms.Padding(3)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 16)
        Me.Label43.TabIndex = 634
        Me.Label43.Text = "NumRegIdTrib"
        Me.C1ThemeController1.SetTheme(Me.Label43, "(default)")
        '
        'TNUMREGIDTRIB
        '
        Me.TNUMREGIDTRIB.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TNUMREGIDTRIB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUMREGIDTRIB.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.TNUMREGIDTRIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUMREGIDTRIB.Location = New System.Drawing.Point(109, 256)
        Me.TNUMREGIDTRIB.MaxLength = 40
        Me.TNUMREGIDTRIB.Name = "TNUMREGIDTRIB"
        Me.TNUMREGIDTRIB.Size = New System.Drawing.Size(303, 20)
        Me.TNUMREGIDTRIB.TabIndex = 7
        Me.TNUMREGIDTRIB.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.TNUMREGIDTRIB, "(default)")
        Me.TNUMREGIDTRIB.Value = ""
        Me.TNUMREGIDTRIB.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnISTMO
        '
        Me.BtnISTMO.FlatAppearance.BorderSize = 0
        Me.BtnISTMO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnISTMO.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnISTMO.Location = New System.Drawing.Point(573, 468)
        Me.BtnISTMO.Name = "BtnISTMO"
        Me.BtnISTMO.Size = New System.Drawing.Size(23, 24)
        Me.BtnISTMO.TabIndex = 637
        Me.C1ThemeController1.SetTheme(Me.BtnISTMO, "(default)")
        Me.BtnISTMO.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(352, 472)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 17)
        Me.Label12.TabIndex = 636
        Me.Label12.Text = "Registro ISTMO SAT"
        Me.C1ThemeController1.SetTheme(Me.Label12, "Office2010Blue")
        '
        'TxCveRegistroISTMO
        '
        Me.TxCveRegistroISTMO.AcceptsReturn = True
        Me.TxCveRegistroISTMO.AcceptsTab = True
        Me.TxCveRegistroISTMO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxCveRegistroISTMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxCveRegistroISTMO.ForeColor = System.Drawing.Color.Black
        Me.TxCveRegistroISTMO.Location = New System.Drawing.Point(492, 469)
        Me.TxCveRegistroISTMO.MaxLength = 10
        Me.TxCveRegistroISTMO.Name = "TxCveRegistroISTMO"
        Me.TxCveRegistroISTMO.Size = New System.Drawing.Size(81, 23)
        Me.TxCveRegistroISTMO.TabIndex = 635
        Me.C1ThemeController1.SetTheme(Me.TxCveRegistroISTMO, "Office2010Blue")
        '
        'RadialMenuItem1
        '
        Me.RadialMenuItem1.Name = "RadialMenuItem1"
        Me.RadialMenuItem1.Text = "Remitente"
        '
        'RadialMenuItem2
        '
        Me.RadialMenuItem2.Name = "RadialMenuItem2"
        Me.RadialMenuItem2.Text = "Destinatario"
        '
        'FrmClientesOperativosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 504)
        Me.Controls.Add(Me.BtnISTMO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxCveRegistroISTMO)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.TNUMREGIDTRIB)
        Me.Controls.Add(Me.BtnGrabarCteFiscal)
        Me.Controls.Add(Me.BtnCP2)
        Me.Controls.Add(Me.BtnPais)
        Me.Controls.Add(Me.BtnEstado)
        Me.Controls.Add(Me.BtnLocalidad)
        Me.Controls.Add(Me.BtnMunicipio)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TDOMICILIO2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TNUMINT)
        Me.Controls.Add(Me.BtnColonia)
        Me.Controls.Add(Me.BtnCP)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TCP_SAT)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TCP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TPAIS_SAT)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TPAIS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TESTADO_SAT)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TESTADO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TMUNICIPIO_SAT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TMUNICIPIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TLOCALIDAD_SAT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TLOCALIDAD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCOLONIA_SAT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCOLONIA)
        Me.Controls.Add(Me.TCUEN_CONT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.TRFC)
        Me.Controls.Add(Me.TPLANTA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TNOTA)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.TDOMICILIO)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.TNUMEXT)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.TCLAVE)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClientesOperativosAE"
        Me.ShowInTaskbar = False
        Me.Text = "Cliente operativo"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnColonia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGrabarCteFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUMREGIDTRIB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnISTMO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCLAVE As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TNOMBRE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Label29 As Label
    Friend WithEvents TRFC As TextBox
    Friend WithEvents TPLANTA As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TNOTA As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents TDOMICILIO As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents TNUMEXT As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TCUEN_CONT As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TCOLONIA As TextBox
    Friend WithEvents TCOLONIA_SAT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TLOCALIDAD_SAT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TLOCALIDAD As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TMUNICIPIO_SAT As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TMUNICIPIO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TESTADO_SAT As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TESTADO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TPAIS_SAT As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TPAIS As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TCP_SAT As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TCP As TextBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BtnCP As C1.Win.C1Input.C1Button
    Friend WithEvents BtnColonia As C1.Win.C1Input.C1Button
    Friend WithEvents Label16 As Label
    Friend WithEvents TNUMINT As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TDOMICILIO2 As TextBox
    Friend WithEvents BtnMunicipio As C1.Win.C1Input.C1Button
    Friend WithEvents BtnLocalidad As C1.Win.C1Input.C1Button
    Friend WithEvents BtnEstado As C1.Win.C1Input.C1Button
    Friend WithEvents BtnPais As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCP2 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnGrabarCteFiscal As C1.Win.C1Input.C1Button
    Friend WithEvents RadialMenuItem1 As C1.Win.C1Command.RadialMenuItem
    Friend WithEvents RadialMenuItem2 As C1.Win.C1Command.RadialMenuItem
    Private WithEvents Label43 As Label
    Friend WithEvents TNUMREGIDTRIB As C1.Win.C1Input.C1TextBox
    Friend WithEvents BtnISTMO As C1.Win.C1Input.C1Button
    Friend WithEvents Label12 As Label
    Friend WithEvents TxCveRegistroISTMO As TextBox
End Class
