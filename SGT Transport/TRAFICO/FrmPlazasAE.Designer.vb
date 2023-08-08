<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPlazasAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlazasAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.LtEstado = New System.Windows.Forms.Label()
        Me.TMUNICIPIO = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TLOCALIDAD = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TCLAVE = New System.Windows.Forms.TextBox()
        Me.TCVE_ESTADO = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnEstado = New System.Windows.Forms.Button()
        Me.TCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCLAVE_SAT_MUN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCLAVE_SAT_LOC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtPais = New System.Windows.Forms.Label()
        Me.LtClaveSatEstado = New System.Windows.Forms.Label()
        Me.LtClaveSatPais = New System.Windows.Forms.Label()
        Me.BtnMunicipio = New C1.Win.C1Input.C1Button()
        Me.BtnLocalidad = New C1.Win.C1Input.C1Button()
        Me.BarraMenu.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(758, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 4
        Me.BarraMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarraMenu, "Office2010Blue")
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
        'LtEstado
        '
        Me.LtEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtEstado.Location = New System.Drawing.Point(201, 170)
        Me.LtEstado.Name = "LtEstado"
        Me.LtEstado.Size = New System.Drawing.Size(306, 22)
        Me.LtEstado.TabIndex = 266
        Me.LtEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtEstado, "Office2010Blue")
        '
        'TMUNICIPIO
        '
        Me.TMUNICIPIO.AcceptsReturn = True
        Me.TMUNICIPIO.AcceptsTab = True
        Me.TMUNICIPIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TMUNICIPIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.TMUNICIPIO.Location = New System.Drawing.Point(127, 141)
        Me.TMUNICIPIO.Name = "TMUNICIPIO"
        Me.TMUNICIPIO.Size = New System.Drawing.Size(380, 22)
        Me.TMUNICIPIO.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.TMUNICIPIO, "Office2010Blue")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(58, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 261
        Me.Label21.Text = "Municipio"
        Me.C1ThemeController1.SetTheme(Me.Label21, "Office2010Blue")
        '
        'TLOCALIDAD
        '
        Me.TLOCALIDAD.AcceptsReturn = True
        Me.TLOCALIDAD.AcceptsTab = True
        Me.TLOCALIDAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TLOCALIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLOCALIDAD.ForeColor = System.Drawing.Color.Black
        Me.TLOCALIDAD.Location = New System.Drawing.Point(127, 112)
        Me.TLOCALIDAD.Name = "TLOCALIDAD"
        Me.TLOCALIDAD.Size = New System.Drawing.Size(380, 22)
        Me.TLOCALIDAD.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.TLOCALIDAD, "Office2010Blue")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(55, 114)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 16)
        Me.Label22.TabIndex = 262
        Me.Label22.Text = "Localidad"
        Me.C1ThemeController1.SetTheme(Me.Label22, "Office2010Blue")
        '
        'TCLAVE
        '
        Me.TCLAVE.AcceptsReturn = True
        Me.TCLAVE.AcceptsTab = True
        Me.TCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.ForeColor = System.Drawing.Color.Black
        Me.TCLAVE.Location = New System.Drawing.Point(127, 83)
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(67, 22)
        Me.TCLAVE.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.TCLAVE, "Office2010Blue")
        '
        'TCVE_ESTADO
        '
        Me.TCVE_ESTADO.AcceptsReturn = True
        Me.TCVE_ESTADO.AcceptsTab = True
        Me.TCVE_ESTADO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ESTADO.ForeColor = System.Drawing.Color.Black
        Me.TCVE_ESTADO.Location = New System.Drawing.Point(127, 170)
        Me.TCVE_ESTADO.Name = "TCVE_ESTADO"
        Me.TCVE_ESTADO.Size = New System.Drawing.Size(50, 22)
        Me.TCVE_ESTADO.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.TCVE_ESTADO, "Office2010Blue")
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(80, 86)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(42, 16)
        Me.Label42.TabIndex = 264
        Me.Label42.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label42, "Office2010Blue")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(72, 172)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 16)
        Me.Label19.TabIndex = 263
        Me.Label19.Text = "Estado"
        Me.C1ThemeController1.SetTheme(Me.Label19, "Office2010Blue")
        '
        'BtnEstado
        '
        Me.BtnEstado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnEstado.BackColor = System.Drawing.Color.Transparent
        Me.BtnEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnEstado.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnEstado.Location = New System.Drawing.Point(177, 170)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(24, 23)
        Me.BtnEstado.TabIndex = 265
        Me.C1ThemeController1.SetTheme(Me.BtnEstado, "Office2010Blue")
        Me.BtnEstado.UseVisualStyleBackColor = True
        '
        'TCUEN_CONT
        '
        Me.TCUEN_CONT.AcceptsReturn = True
        Me.TCUEN_CONT.AcceptsTab = True
        Me.TCUEN_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUEN_CONT.ForeColor = System.Drawing.Color.Black
        Me.TCUEN_CONT.Location = New System.Drawing.Point(127, 226)
        Me.TCUEN_CONT.MaxLength = 28
        Me.TCUEN_CONT.Name = "TCUEN_CONT"
        Me.TCUEN_CONT.Size = New System.Drawing.Size(289, 22)
        Me.TCUEN_CONT.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.TCUEN_CONT, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(18, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "Cuenta contable"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'TCLAVE_SAT_MUN
        '
        Me.TCLAVE_SAT_MUN.AcceptsReturn = True
        Me.TCLAVE_SAT_MUN.AcceptsTab = True
        Me.TCLAVE_SAT_MUN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE_SAT_MUN.ForeColor = System.Drawing.Color.Black
        Me.TCLAVE_SAT_MUN.Location = New System.Drawing.Point(602, 141)
        Me.TCLAVE_SAT_MUN.Name = "TCLAVE_SAT_MUN"
        Me.TCLAVE_SAT_MUN.Size = New System.Drawing.Size(97, 22)
        Me.TCLAVE_SAT_MUN.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.TCLAVE_SAT_MUN, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(525, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TCLAVE_SAT_LOC
        '
        Me.TCLAVE_SAT_LOC.AcceptsReturn = True
        Me.TCLAVE_SAT_LOC.AcceptsTab = True
        Me.TCLAVE_SAT_LOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE_SAT_LOC.ForeColor = System.Drawing.Color.Black
        Me.TCLAVE_SAT_LOC.Location = New System.Drawing.Point(602, 112)
        Me.TCLAVE_SAT_LOC.Name = "TCLAVE_SAT_LOC"
        Me.TCLAVE_SAT_LOC.Size = New System.Drawing.Size(97, 22)
        Me.TCLAVE_SAT_LOC.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.TCLAVE_SAT_LOC, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(525, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(321, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 295
        Me.Label4.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(88, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 294
        Me.Label5.Text = "Pais"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(525, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Clave SAT"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'LtPais
        '
        Me.LtPais.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPais.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPais.Location = New System.Drawing.Point(127, 199)
        Me.LtPais.Name = "LtPais"
        Me.LtPais.Size = New System.Drawing.Size(175, 22)
        Me.LtPais.TabIndex = 296
        Me.LtPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtPais, "Office2010Blue")
        '
        'LtClaveSatEstado
        '
        Me.LtClaveSatEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtClaveSatEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClaveSatEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtClaveSatEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtClaveSatEstado.Location = New System.Drawing.Point(602, 170)
        Me.LtClaveSatEstado.Name = "LtClaveSatEstado"
        Me.LtClaveSatEstado.Size = New System.Drawing.Size(96, 22)
        Me.LtClaveSatEstado.TabIndex = 297
        Me.LtClaveSatEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtClaveSatEstado, "Office2010Blue")
        '
        'LtClaveSatPais
        '
        Me.LtClaveSatPais.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtClaveSatPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClaveSatPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtClaveSatPais.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtClaveSatPais.Location = New System.Drawing.Point(397, 199)
        Me.LtClaveSatPais.Name = "LtClaveSatPais"
        Me.LtClaveSatPais.Size = New System.Drawing.Size(110, 22)
        Me.LtClaveSatPais.TabIndex = 298
        Me.LtClaveSatPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtClaveSatPais, "Office2010Blue")
        '
        'BtnMunicipio
        '
        Me.BtnMunicipio.FlatAppearance.BorderSize = 0
        Me.BtnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMunicipio.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnMunicipio.Location = New System.Drawing.Point(706, 139)
        Me.BtnMunicipio.Name = "BtnMunicipio"
        Me.BtnMunicipio.Size = New System.Drawing.Size(23, 24)
        Me.BtnMunicipio.TabIndex = 428
        Me.C1ThemeController1.SetTheme(Me.BtnMunicipio, "(default)")
        Me.BtnMunicipio.UseVisualStyleBackColor = True
        '
        'BtnLocalidad
        '
        Me.BtnLocalidad.FlatAppearance.BorderSize = 0
        Me.BtnLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLocalidad.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnLocalidad.Location = New System.Drawing.Point(706, 109)
        Me.BtnLocalidad.Name = "BtnLocalidad"
        Me.BtnLocalidad.Size = New System.Drawing.Size(23, 24)
        Me.BtnLocalidad.TabIndex = 429
        Me.C1ThemeController1.SetTheme(Me.BtnLocalidad, "(default)")
        Me.BtnLocalidad.UseVisualStyleBackColor = True
        '
        'frmPlazasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 286)
        Me.Controls.Add(Me.BtnLocalidad)
        Me.Controls.Add(Me.BtnMunicipio)
        Me.Controls.Add(Me.LtClaveSatPais)
        Me.Controls.Add(Me.LtClaveSatEstado)
        Me.Controls.Add(Me.LtPais)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TCLAVE_SAT_MUN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCLAVE_SAT_LOC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCUEN_CONT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtEstado)
        Me.Controls.Add(Me.TMUNICIPIO)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TLOCALIDAD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TCLAVE)
        Me.Controls.Add(Me.TCVE_ESTADO)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.BtnEstado)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlazasAE"
        Me.Text = "Plazas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents LtEstado As Label
    Friend WithEvents TMUNICIPIO As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TLOCALIDAD As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TCLAVE As TextBox
    Friend WithEvents TCVE_ESTADO As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents BtnEstado As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents TCUEN_CONT As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TCLAVE_SAT_MUN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TCLAVE_SAT_LOC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtPais As Label
    Friend WithEvents LtClaveSatEstado As Label
    Friend WithEvents LtClaveSatPais As Label
    Friend WithEvents BtnMunicipio As C1.Win.C1Input.C1Button
    Friend WithEvents BtnLocalidad As C1.Win.C1Input.C1Button
End Class
