<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCXCAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCXCAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radAbono = New System.Windows.Forms.RadioButton()
        Me.radCargo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConSAT = New System.Windows.Forms.Button()
        Me.tFORMADEPAGOSAT = New System.Windows.Forms.TextBox()
        Me.chDAR_CAMBIO = New System.Windows.Forms.CheckBox()
        Me.chAUTORIZACION = New System.Windows.Forms.CheckBox()
        Me.chCON_REFER = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chES_FMA_PAG = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGenConc = New System.Windows.Forms.Button()
        Me.tGEN_CPTO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.BarraMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(428, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 26
        Me.BarraMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarraMenu, "Office2010Blue")
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
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.ForeColor = System.Drawing.Color.Black
        Me.tNUM_CPTO.Location = New System.Drawing.Point(110, 24)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(110, 22)
        Me.tNUM_CPTO.TabIndex = 113
        Me.C1ThemeController1.SetTheme(Me.tNUM_CPTO, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(71, 27)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(35, 14)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.ForeColor = System.Drawing.Color.Black
        Me.tDescr.Location = New System.Drawing.Point(110, 83)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(289, 22)
        Me.tDescr.TabIndex = 114
        Me.C1ThemeController1.SetTheme(Me.tDescr, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(56, 87)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(50, 14)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.ForeColor = System.Drawing.Color.Black
        Me.tCUEN_CONT.Location = New System.Drawing.Point(110, 115)
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 22)
        Me.tCUEN_CONT.TabIndex = 117
        Me.C1ThemeController1.SetTheme(Me.tCUEN_CONT, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Cuenta contable"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.tNUM_CPTO)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Controls.Add(Me.tDescr)
        Me.GroupBox1.Controls.Add(Me.tCUEN_CONT)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 152)
        Me.GroupBox1.TabIndex = 119
        Me.GroupBox1.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox1, "Office2010Blue")
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.radAbono)
        Me.GroupBox2.Controls.Add(Me.radCargo)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(106, 171)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox2, "Office2010Blue")
        '
        'radAbono
        '
        Me.radAbono.AutoSize = True
        Me.radAbono.BackColor = System.Drawing.Color.Transparent
        Me.radAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAbono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radAbono.Location = New System.Drawing.Point(28, 106)
        Me.radAbono.Name = "radAbono"
        Me.radAbono.Size = New System.Drawing.Size(61, 18)
        Me.radAbono.TabIndex = 1
        Me.radAbono.TabStop = True
        Me.radAbono.Text = "Abono"
        Me.C1ThemeController1.SetTheme(Me.radAbono, "Office2010Blue")
        Me.radAbono.UseVisualStyleBackColor = False
        '
        'radCargo
        '
        Me.radCargo.AutoSize = True
        Me.radCargo.BackColor = System.Drawing.Color.Transparent
        Me.radCargo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radCargo.Location = New System.Drawing.Point(28, 38)
        Me.radCargo.Name = "radCargo"
        Me.radCargo.Size = New System.Drawing.Size(56, 18)
        Me.radCargo.TabIndex = 0
        Me.radCargo.TabStop = True
        Me.radCargo.Text = "Cargo"
        Me.C1ThemeController1.SetTheme(Me.radCargo, "Office2010Blue")
        Me.radCargo.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btnConSAT)
        Me.GroupBox3.Controls.Add(Me.tFORMADEPAGOSAT)
        Me.GroupBox3.Controls.Add(Me.chDAR_CAMBIO)
        Me.GroupBox3.Controls.Add(Me.chAUTORIZACION)
        Me.GroupBox3.Controls.Add(Me.chCON_REFER)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.chES_FMA_PAG)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(134, 210)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 171)
        Me.GroupBox3.TabIndex = 121
        Me.GroupBox3.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox3, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(45, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 10)
        Me.Label4.TabIndex = 119
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'btnConSAT
        '
        Me.btnConSAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnConSAT.BackColor = System.Drawing.Color.Transparent
        Me.btnConSAT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnConSAT.Image = CType(resources.GetObject("btnConSAT.Image"), System.Drawing.Image)
        Me.btnConSAT.Location = New System.Drawing.Point(137, 66)
        Me.btnConSAT.Name = "btnConSAT"
        Me.btnConSAT.Size = New System.Drawing.Size(24, 23)
        Me.btnConSAT.TabIndex = 124
        Me.C1ThemeController1.SetTheme(Me.btnConSAT, "Office2010Blue")
        Me.btnConSAT.UseVisualStyleBackColor = True
        '
        'tFORMADEPAGOSAT
        '
        Me.tFORMADEPAGOSAT.AcceptsReturn = True
        Me.tFORMADEPAGOSAT.AcceptsTab = True
        Me.tFORMADEPAGOSAT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFORMADEPAGOSAT.ForeColor = System.Drawing.Color.Black
        Me.tFORMADEPAGOSAT.Location = New System.Drawing.Point(27, 67)
        Me.tFORMADEPAGOSAT.Name = "tFORMADEPAGOSAT"
        Me.tFORMADEPAGOSAT.Size = New System.Drawing.Size(110, 22)
        Me.tFORMADEPAGOSAT.TabIndex = 123
        Me.C1ThemeController1.SetTheme(Me.tFORMADEPAGOSAT, "Office2010Blue")
        '
        'chDAR_CAMBIO
        '
        Me.chDAR_CAMBIO.AutoSize = True
        Me.chDAR_CAMBIO.BackColor = System.Drawing.Color.Transparent
        Me.chDAR_CAMBIO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chDAR_CAMBIO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chDAR_CAMBIO.Location = New System.Drawing.Point(27, 145)
        Me.chDAR_CAMBIO.Name = "chDAR_CAMBIO"
        Me.chDAR_CAMBIO.Size = New System.Drawing.Size(86, 18)
        Me.chDAR_CAMBIO.TabIndex = 122
        Me.chDAR_CAMBIO.Text = "Dar cambio"
        Me.C1ThemeController1.SetTheme(Me.chDAR_CAMBIO, "Office2010Blue")
        Me.chDAR_CAMBIO.UseVisualStyleBackColor = False
        '
        'chAUTORIZACION
        '
        Me.chAUTORIZACION.AutoSize = True
        Me.chAUTORIZACION.BackColor = System.Drawing.Color.Transparent
        Me.chAUTORIZACION.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chAUTORIZACION.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chAUTORIZACION.Location = New System.Drawing.Point(27, 122)
        Me.chAUTORIZACION.Name = "chAUTORIZACION"
        Me.chAUTORIZACION.Size = New System.Drawing.Size(92, 18)
        Me.chAUTORIZACION.TabIndex = 121
        Me.chAUTORIZACION.Text = "Autorización"
        Me.C1ThemeController1.SetTheme(Me.chAUTORIZACION, "Office2010Blue")
        Me.chAUTORIZACION.UseVisualStyleBackColor = False
        '
        'chCON_REFER
        '
        Me.chCON_REFER.AutoSize = True
        Me.chCON_REFER.BackColor = System.Drawing.Color.Transparent
        Me.chCON_REFER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chCON_REFER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chCON_REFER.Location = New System.Drawing.Point(27, 99)
        Me.chCON_REFER.Name = "chCON_REFER"
        Me.chCON_REFER.Size = New System.Drawing.Size(105, 18)
        Me.chCON_REFER.TabIndex = 120
        Me.chCON_REFER.Text = "Con referencia"
        Me.C1ThemeController1.SetTheme(Me.chCON_REFER, "Office2010Blue")
        Me.chCON_REFER.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 14)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Forma de pago SAT"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'chES_FMA_PAG
        '
        Me.chES_FMA_PAG.AutoSize = True
        Me.chES_FMA_PAG.BackColor = System.Drawing.Color.Transparent
        Me.chES_FMA_PAG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chES_FMA_PAG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chES_FMA_PAG.Location = New System.Drawing.Point(27, 20)
        Me.chES_FMA_PAG.Name = "chES_FMA_PAG"
        Me.chES_FMA_PAG.Size = New System.Drawing.Size(122, 18)
        Me.chES_FMA_PAG.TabIndex = 0
        Me.chES_FMA_PAG.Text = "Es forma de pago"
        Me.C1ThemeController1.SetTheme(Me.chES_FMA_PAG, "Office2010Blue")
        Me.chES_FMA_PAG.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.btnGenConc)
        Me.GroupBox4.Controls.Add(Me.tGEN_CPTO)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 387)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(406, 64)
        Me.GroupBox4.TabIndex = 122
        Me.GroupBox4.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox4, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 14)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Genera concepto número"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'btnGenConc
        '
        Me.btnGenConc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenConc.BackColor = System.Drawing.Color.Transparent
        Me.btnGenConc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnGenConc.Image = CType(resources.GetObject("btnGenConc.Image"), System.Drawing.Image)
        Me.btnGenConc.Location = New System.Drawing.Point(272, 24)
        Me.btnGenConc.Name = "btnGenConc"
        Me.btnGenConc.Size = New System.Drawing.Size(24, 23)
        Me.btnGenConc.TabIndex = 126
        Me.C1ThemeController1.SetTheme(Me.btnGenConc, "Office2010Blue")
        Me.btnGenConc.UseVisualStyleBackColor = True
        '
        'tGEN_CPTO
        '
        Me.tGEN_CPTO.AcceptsReturn = True
        Me.tGEN_CPTO.AcceptsTab = True
        Me.tGEN_CPTO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGEN_CPTO.ForeColor = System.Drawing.Color.Black
        Me.tGEN_CPTO.Location = New System.Drawing.Point(161, 25)
        Me.tGEN_CPTO.Name = "tGEN_CPTO"
        Me.tGEN_CPTO.Size = New System.Drawing.Size(110, 21)
        Me.tGEN_CPTO.TabIndex = 125
        Me.C1ThemeController1.SetTheme(Me.tGEN_CPTO, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(23, 455)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 14)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Datos fiscales requeridos"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 457)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 10)
        Me.Label5.TabIndex = 125
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'frmCXCAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 484)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCXCAE"
        Me.ShowInTaskbar = False
        Me.Text = "Concpeto de cuentas por cobrar"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents barGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tNUM_CPTO As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tDescr As System.Windows.Forms.TextBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCUEN_CONT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents radAbono As System.Windows.Forms.RadioButton
    Friend WithEvents radCargo As System.Windows.Forms.RadioButton
    Friend WithEvents btnConSAT As System.Windows.Forms.Button
    Friend WithEvents tFORMADEPAGOSAT As System.Windows.Forms.TextBox
    Friend WithEvents chDAR_CAMBIO As System.Windows.Forms.CheckBox
    Friend WithEvents chAUTORIZACION As System.Windows.Forms.CheckBox
    Friend WithEvents chCON_REFER As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chES_FMA_PAG As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGenConc As System.Windows.Forms.Button
    Friend WithEvents tGEN_CPTO As System.Windows.Forms.TextBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
