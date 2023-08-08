<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCatEvaluacionesAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatEvaluacionesAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TPORC_USO_RALENTI = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL1 = New System.Windows.Forms.TextBox()
        Me.TCALIF_RALENTI = New System.Windows.Forms.TextBox()
        Me.TCALIF_FACTOR_CARGA = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCVE_EVA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TFACTOR_CARGA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BtnMotor = New System.Windows.Forms.Button()
        Me.LtMotor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCVE_MOT = New System.Windows.Forms.TextBox()
        Me.TBONO1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TPONDE_RALENTI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TPONDE_FC = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TPON_VEL_MAX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TVEL_MAX = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TCALIF_VEL_MAX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Box4 = New System.Windows.Forms.GroupBox()
        Me.RadSencillo = New System.Windows.Forms.RadioButton()
        Me.RadFull = New System.Windows.Forms.RadioButton()
        Me.TBONO2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TBONO3 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TBONO6 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL6 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TBONO5 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL5 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TBONO4 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL4 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBONO7 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TCALIF_GLOBAL7 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ChCalculo_positivo = New C1.Win.C1Input.C1CheckBox()
        Me.TRPM_MAX = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TPON_RPM_MAX = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TCALIF_RPM_MAX = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.RadFull_Sencillo = New System.Windows.Forms.RadioButton()
        Me.BarraMenu.SuspendLayout()
        Me.Box4.SuspendLayout()
        CType(Me.ChCalculo_positivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(674, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 453
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
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
        'TPORC_USO_RALENTI
        '
        Me.TPORC_USO_RALENTI.AcceptsReturn = True
        Me.TPORC_USO_RALENTI.AcceptsTab = True
        Me.TPORC_USO_RALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPORC_USO_RALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPORC_USO_RALENTI.Location = New System.Drawing.Point(219, 180)
        Me.TPORC_USO_RALENTI.MaxLength = 10
        Me.TPORC_USO_RALENTI.Name = "TPORC_USO_RALENTI"
        Me.TPORC_USO_RALENTI.Size = New System.Drawing.Size(50, 22)
        Me.TPORC_USO_RALENTI.TabIndex = 3
        Me.TPORC_USO_RALENTI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(98, 182)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(115, 16)
        Me.Label37.TabIndex = 490
        Me.Label37.Text = "2. Porc. uso ralenti"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TCALIF_GLOBAL1
        '
        Me.TCALIF_GLOBAL1.AcceptsReturn = True
        Me.TCALIF_GLOBAL1.AcceptsTab = True
        Me.TCALIF_GLOBAL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL1.Location = New System.Drawing.Point(394, 155)
        Me.TCALIF_GLOBAL1.Name = "TCALIF_GLOBAL1"
        Me.TCALIF_GLOBAL1.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL1.TabIndex = 14
        Me.TCALIF_GLOBAL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TCALIF_RALENTI
        '
        Me.TCALIF_RALENTI.AcceptsReturn = True
        Me.TCALIF_RALENTI.AcceptsTab = True
        Me.TCALIF_RALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_RALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_RALENTI.Location = New System.Drawing.Point(219, 380)
        Me.TCALIF_RALENTI.Name = "TCALIF_RALENTI"
        Me.TCALIF_RALENTI.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_RALENTI.TabIndex = 11
        Me.TCALIF_RALENTI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TCALIF_FACTOR_CARGA
        '
        Me.TCALIF_FACTOR_CARGA.AcceptsReturn = True
        Me.TCALIF_FACTOR_CARGA.AcceptsTab = True
        Me.TCALIF_FACTOR_CARGA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_FACTOR_CARGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_FACTOR_CARGA.Location = New System.Drawing.Point(219, 405)
        Me.TCALIF_FACTOR_CARGA.Name = "TCALIF_FACTOR_CARGA"
        Me.TCALIF_FACTOR_CARGA.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_FACTOR_CARGA.TabIndex = 12
        Me.TCALIF_FACTOR_CARGA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(84, 408)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 16)
        Me.Label4.TabIndex = 489
        Me.Label4.Text = "Calif. factor de carga"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TCVE_EVA
        '
        Me.TCVE_EVA.AcceptsReturn = True
        Me.TCVE_EVA.AcceptsTab = True
        Me.TCVE_EVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_EVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_EVA.Location = New System.Drawing.Point(219, 63)
        Me.TCVE_EVA.Name = "TCVE_EVA"
        Me.TCVE_EVA.Size = New System.Drawing.Size(50, 22)
        Me.TCVE_EVA.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(171, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 488
        Me.Label8.Text = "Clave"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TFACTOR_CARGA
        '
        Me.TFACTOR_CARGA.AcceptsReturn = True
        Me.TFACTOR_CARGA.AcceptsTab = True
        Me.TFACTOR_CARGA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFACTOR_CARGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFACTOR_CARGA.Location = New System.Drawing.Point(219, 155)
        Me.TFACTOR_CARGA.Name = "TFACTOR_CARGA"
        Me.TFACTOR_CARGA.Size = New System.Drawing.Size(50, 22)
        Me.TFACTOR_CARGA.TabIndex = 2
        Me.TFACTOR_CARGA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(98, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 487
        Me.Label2.Text = "1. Factor de carga"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(138, 383)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 16)
        Me.Label27.TabIndex = 486
        Me.Label27.Text = "Calif. ralenti"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(298, 156)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(87, 16)
        Me.Nombre.TabIndex = 485
        Me.Nombre.Text = "Calif. global 1"
        '
        'BtnMotor
        '
        Me.BtnMotor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnMotor.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnMotor.Location = New System.Drawing.Point(270, 117)
        Me.BtnMotor.Name = "BtnMotor"
        Me.BtnMotor.Size = New System.Drawing.Size(24, 23)
        Me.BtnMotor.TabIndex = 494
        Me.BtnMotor.UseVisualStyleBackColor = True
        '
        'LtMotor
        '
        Me.LtMotor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMotor.Location = New System.Drawing.Point(295, 119)
        Me.LtMotor.Name = "LtMotor"
        Me.LtMotor.Size = New System.Drawing.Size(337, 20)
        Me.LtMotor.TabIndex = 493
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 492
        Me.Label1.Text = "Motor"
        '
        'TCVE_MOT
        '
        Me.TCVE_MOT.AcceptsReturn = True
        Me.TCVE_MOT.AcceptsTab = True
        Me.TCVE_MOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_MOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_MOT.Location = New System.Drawing.Point(219, 118)
        Me.TCVE_MOT.Name = "TCVE_MOT"
        Me.TCVE_MOT.Size = New System.Drawing.Size(50, 22)
        Me.TCVE_MOT.TabIndex = 1
        '
        'TBONO1
        '
        Me.TBONO1.AcceptsReturn = True
        Me.TBONO1.AcceptsTab = True
        Me.TBONO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO1.Location = New System.Drawing.Point(582, 155)
        Me.TBONO1.Name = "TBONO1"
        Me.TBONO1.Size = New System.Drawing.Size(50, 22)
        Me.TBONO1.TabIndex = 15
        Me.TBONO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(463, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 496
        Me.Label3.Text = "Bono asignado 1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TPONDE_RALENTI
        '
        Me.TPONDE_RALENTI.AcceptsReturn = True
        Me.TPONDE_RALENTI.AcceptsTab = True
        Me.TPONDE_RALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPONDE_RALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPONDE_RALENTI.Location = New System.Drawing.Point(219, 280)
        Me.TPONDE_RALENTI.Name = "TPONDE_RALENTI"
        Me.TPONDE_RALENTI.Size = New System.Drawing.Size(50, 22)
        Me.TPONDE_RALENTI.TabIndex = 7
        Me.TPONDE_RALENTI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(77, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 16)
        Me.Label5.TabIndex = 500
        Me.Label5.Text = "2. Ponderación ralenti"
        '
        'TPONDE_FC
        '
        Me.TPONDE_FC.AcceptsReturn = True
        Me.TPONDE_FC.AcceptsTab = True
        Me.TPONDE_FC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPONDE_FC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPONDE_FC.Location = New System.Drawing.Point(219, 255)
        Me.TPONDE_FC.Name = "TPONDE_FC"
        Me.TPONDE_FC.Size = New System.Drawing.Size(50, 22)
        Me.TPONDE_FC.TabIndex = 6
        Me.TPONDE_FC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(96, 258)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 16)
        Me.Label6.TabIndex = 499
        Me.Label6.Text = "1. Ponderación FC"
        '
        'TPON_VEL_MAX
        '
        Me.TPON_VEL_MAX.AcceptsReturn = True
        Me.TPON_VEL_MAX.AcceptsTab = True
        Me.TPON_VEL_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPON_VEL_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPON_VEL_MAX.Location = New System.Drawing.Point(219, 305)
        Me.TPON_VEL_MAX.Name = "TPON_VEL_MAX"
        Me.TPON_VEL_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TPON_VEL_MAX.TabIndex = 8
        Me.TPON_VEL_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(61, 308)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 16)
        Me.Label7.TabIndex = 504
        Me.Label7.Text = "3. Ponderacion vel. max."
        '
        'TVEL_MAX
        '
        Me.TVEL_MAX.AcceptsReturn = True
        Me.TVEL_MAX.AcceptsTab = True
        Me.TVEL_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TVEL_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TVEL_MAX.Location = New System.Drawing.Point(219, 205)
        Me.TVEL_MAX.Name = "TVEL_MAX"
        Me.TVEL_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TVEL_MAX.TabIndex = 4
        Me.TVEL_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(81, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 16)
        Me.Label9.TabIndex = 503
        Me.Label9.Text = "3. Velocidad maxima"
        '
        'TCALIF_VEL_MAX
        '
        Me.TCALIF_VEL_MAX.AcceptsReturn = True
        Me.TCALIF_VEL_MAX.AcceptsTab = True
        Me.TCALIF_VEL_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_VEL_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_VEL_MAX.Location = New System.Drawing.Point(219, 355)
        Me.TCALIF_VEL_MAX.Name = "TCALIF_VEL_MAX"
        Me.TCALIF_VEL_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_VEL_MAX.TabIndex = 10
        Me.TCALIF_VEL_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(122, 358)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 16)
        Me.Label10.TabIndex = 506
        Me.Label10.Text = "Calif. vel. max."
        '
        'Box4
        '
        Me.Box4.Controls.Add(Me.RadFull_Sencillo)
        Me.Box4.Controls.Add(Me.RadSencillo)
        Me.Box4.Controls.Add(Me.RadFull)
        Me.Box4.Location = New System.Drawing.Point(295, 345)
        Me.Box4.Name = "Box4"
        Me.Box4.Size = New System.Drawing.Size(310, 57)
        Me.Box4.TabIndex = 25
        Me.Box4.TabStop = False
        Me.Box4.Text = "Tipo viaje"
        '
        'RadSencillo
        '
        Me.RadSencillo.AutoSize = True
        Me.RadSencillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSencillo.Location = New System.Drawing.Point(91, 19)
        Me.RadSencillo.Name = "RadSencillo"
        Me.RadSencillo.Size = New System.Drawing.Size(75, 21)
        Me.RadSencillo.TabIndex = 29
        Me.RadSencillo.TabStop = True
        Me.RadSencillo.Text = "Sencillo"
        Me.RadSencillo.UseVisualStyleBackColor = False
        '
        'RadFull
        '
        Me.RadFull.AutoSize = True
        Me.RadFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFull.Location = New System.Drawing.Point(18, 19)
        Me.RadFull.Name = "RadFull"
        Me.RadFull.Size = New System.Drawing.Size(48, 21)
        Me.RadFull.TabIndex = 28
        Me.RadFull.TabStop = True
        Me.RadFull.Text = "Full"
        Me.RadFull.UseVisualStyleBackColor = False
        '
        'TBONO2
        '
        Me.TBONO2.AcceptsReturn = True
        Me.TBONO2.AcceptsTab = True
        Me.TBONO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO2.Location = New System.Drawing.Point(582, 180)
        Me.TBONO2.Name = "TBONO2"
        Me.TBONO2.Size = New System.Drawing.Size(50, 22)
        Me.TBONO2.TabIndex = 17
        Me.TBONO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(463, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 16)
        Me.Label11.TabIndex = 511
        Me.Label11.Text = "Bono asignado 2"
        '
        'TCALIF_GLOBAL2
        '
        Me.TCALIF_GLOBAL2.AcceptsReturn = True
        Me.TCALIF_GLOBAL2.AcceptsTab = True
        Me.TCALIF_GLOBAL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL2.Location = New System.Drawing.Point(394, 180)
        Me.TCALIF_GLOBAL2.Name = "TCALIF_GLOBAL2"
        Me.TCALIF_GLOBAL2.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL2.TabIndex = 16
        Me.TCALIF_GLOBAL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(298, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 16)
        Me.Label12.TabIndex = 510
        Me.Label12.Text = "Calif. global 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TBONO3
        '
        Me.TBONO3.AcceptsReturn = True
        Me.TBONO3.AcceptsTab = True
        Me.TBONO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO3.Location = New System.Drawing.Point(582, 205)
        Me.TBONO3.Name = "TBONO3"
        Me.TBONO3.Size = New System.Drawing.Size(50, 22)
        Me.TBONO3.TabIndex = 19
        Me.TBONO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(463, 207)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 16)
        Me.Label13.TabIndex = 515
        Me.Label13.Text = "Bono asignado 3"
        '
        'TCALIF_GLOBAL3
        '
        Me.TCALIF_GLOBAL3.AcceptsReturn = True
        Me.TCALIF_GLOBAL3.AcceptsTab = True
        Me.TCALIF_GLOBAL3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL3.Location = New System.Drawing.Point(394, 205)
        Me.TCALIF_GLOBAL3.Name = "TCALIF_GLOBAL3"
        Me.TCALIF_GLOBAL3.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL3.TabIndex = 18
        Me.TCALIF_GLOBAL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(298, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 16)
        Me.Label14.TabIndex = 514
        Me.Label14.Text = "Calif. global 3"
        '
        'TBONO6
        '
        Me.TBONO6.AcceptsReturn = True
        Me.TBONO6.AcceptsTab = True
        Me.TBONO6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO6.Location = New System.Drawing.Point(582, 280)
        Me.TBONO6.Name = "TBONO6"
        Me.TBONO6.Size = New System.Drawing.Size(50, 22)
        Me.TBONO6.TabIndex = 25
        Me.TBONO6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(463, 282)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 16)
        Me.Label15.TabIndex = 527
        Me.Label15.Text = "Bono asignado 6"
        '
        'TCALIF_GLOBAL6
        '
        Me.TCALIF_GLOBAL6.AcceptsReturn = True
        Me.TCALIF_GLOBAL6.AcceptsTab = True
        Me.TCALIF_GLOBAL6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL6.Location = New System.Drawing.Point(394, 280)
        Me.TCALIF_GLOBAL6.Name = "TCALIF_GLOBAL6"
        Me.TCALIF_GLOBAL6.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL6.TabIndex = 24
        Me.TCALIF_GLOBAL6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(298, 282)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 16)
        Me.Label16.TabIndex = 526
        Me.Label16.Text = "Calif. global 6"
        '
        'TBONO5
        '
        Me.TBONO5.AcceptsReturn = True
        Me.TBONO5.AcceptsTab = True
        Me.TBONO5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO5.Location = New System.Drawing.Point(582, 255)
        Me.TBONO5.Name = "TBONO5"
        Me.TBONO5.Size = New System.Drawing.Size(50, 22)
        Me.TBONO5.TabIndex = 23
        Me.TBONO5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(463, 257)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 16)
        Me.Label17.TabIndex = 523
        Me.Label17.Text = "Bono asignado 5"
        '
        'TCALIF_GLOBAL5
        '
        Me.TCALIF_GLOBAL5.AcceptsReturn = True
        Me.TCALIF_GLOBAL5.AcceptsTab = True
        Me.TCALIF_GLOBAL5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL5.Location = New System.Drawing.Point(394, 255)
        Me.TCALIF_GLOBAL5.Name = "TCALIF_GLOBAL5"
        Me.TCALIF_GLOBAL5.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL5.TabIndex = 22
        Me.TCALIF_GLOBAL5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(298, 257)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 16)
        Me.Label18.TabIndex = 522
        Me.Label18.Text = "Calif. global 5"
        '
        'TBONO4
        '
        Me.TBONO4.AcceptsReturn = True
        Me.TBONO4.AcceptsTab = True
        Me.TBONO4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO4.Location = New System.Drawing.Point(582, 230)
        Me.TBONO4.Name = "TBONO4"
        Me.TBONO4.Size = New System.Drawing.Size(50, 22)
        Me.TBONO4.TabIndex = 21
        Me.TBONO4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(463, 232)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 16)
        Me.Label19.TabIndex = 519
        Me.Label19.Text = "Bono asignado 4"
        '
        'TCALIF_GLOBAL4
        '
        Me.TCALIF_GLOBAL4.AcceptsReturn = True
        Me.TCALIF_GLOBAL4.AcceptsTab = True
        Me.TCALIF_GLOBAL4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL4.Location = New System.Drawing.Point(394, 230)
        Me.TCALIF_GLOBAL4.Name = "TCALIF_GLOBAL4"
        Me.TCALIF_GLOBAL4.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL4.TabIndex = 20
        Me.TCALIF_GLOBAL4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(298, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 16)
        Me.Label20.TabIndex = 518
        Me.Label20.Text = "Calif. global 4"
        '
        'TBONO7
        '
        Me.TBONO7.AcceptsReturn = True
        Me.TBONO7.AcceptsTab = True
        Me.TBONO7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBONO7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBONO7.Location = New System.Drawing.Point(582, 305)
        Me.TBONO7.Name = "TBONO7"
        Me.TBONO7.Size = New System.Drawing.Size(50, 22)
        Me.TBONO7.TabIndex = 27
        Me.TBONO7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(463, 307)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 16)
        Me.Label21.TabIndex = 531
        Me.Label21.Text = "Bono asignado 7"
        '
        'TCALIF_GLOBAL7
        '
        Me.TCALIF_GLOBAL7.AcceptsReturn = True
        Me.TCALIF_GLOBAL7.AcceptsTab = True
        Me.TCALIF_GLOBAL7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_GLOBAL7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_GLOBAL7.Location = New System.Drawing.Point(394, 305)
        Me.TCALIF_GLOBAL7.Name = "TCALIF_GLOBAL7"
        Me.TCALIF_GLOBAL7.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_GLOBAL7.TabIndex = 26
        Me.TCALIF_GLOBAL7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(298, 307)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 16)
        Me.Label22.TabIndex = 530
        Me.Label22.Text = "Calif. global 7"
        '
        'ChCalculo_positivo
        '
        Me.ChCalculo_positivo.BackColor = System.Drawing.Color.Transparent
        Me.ChCalculo_positivo.BorderColor = System.Drawing.Color.Transparent
        Me.ChCalculo_positivo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChCalculo_positivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCalculo_positivo.ForeColor = System.Drawing.Color.Black
        Me.ChCalculo_positivo.Location = New System.Drawing.Point(295, 425)
        Me.ChCalculo_positivo.Name = "ChCalculo_positivo"
        Me.ChCalculo_positivo.Padding = New System.Windows.Forms.Padding(1)
        Me.ChCalculo_positivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChCalculo_positivo.Size = New System.Drawing.Size(128, 24)
        Me.ChCalculo_positivo.TabIndex = 28
        Me.ChCalculo_positivo.Text = "Cálculo positivo"
        Me.ChCalculo_positivo.UseVisualStyleBackColor = True
        Me.ChCalculo_positivo.Value = Nothing
        Me.ChCalculo_positivo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TRPM_MAX
        '
        Me.TRPM_MAX.AcceptsReturn = True
        Me.TRPM_MAX.AcceptsTab = True
        Me.TRPM_MAX.BackColor = System.Drawing.Color.LightCyan
        Me.TRPM_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRPM_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRPM_MAX.Location = New System.Drawing.Point(219, 230)
        Me.TRPM_MAX.Name = "TRPM_MAX"
        Me.TRPM_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TRPM_MAX.TabIndex = 5
        Me.TRPM_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(113, 232)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 16)
        Me.Label23.TabIndex = 533
        Me.Label23.Text = "4. RPM Máxima"
        '
        'TPON_RPM_MAX
        '
        Me.TPON_RPM_MAX.AcceptsReturn = True
        Me.TPON_RPM_MAX.AcceptsTab = True
        Me.TPON_RPM_MAX.BackColor = System.Drawing.Color.LightCyan
        Me.TPON_RPM_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPON_RPM_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPON_RPM_MAX.Location = New System.Drawing.Point(219, 330)
        Me.TPON_RPM_MAX.Name = "TPON_RPM_MAX"
        Me.TPON_RPM_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TPON_RPM_MAX.TabIndex = 9
        Me.TPON_RPM_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(33, 333)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(180, 16)
        Me.Label24.TabIndex = 535
        Me.Label24.Text = "4. Ponderacion RPM Máxima"
        '
        'TCALIF_RPM_MAX
        '
        Me.TCALIF_RPM_MAX.AcceptsReturn = True
        Me.TCALIF_RPM_MAX.AcceptsTab = True
        Me.TCALIF_RPM_MAX.BackColor = System.Drawing.Color.LightCyan
        Me.TCALIF_RPM_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCALIF_RPM_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCALIF_RPM_MAX.Location = New System.Drawing.Point(219, 430)
        Me.TCALIF_RPM_MAX.Name = "TCALIF_RPM_MAX"
        Me.TCALIF_RPM_MAX.Size = New System.Drawing.Size(50, 22)
        Me.TCALIF_RPM_MAX.TabIndex = 13
        Me.TCALIF_RPM_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(94, 433)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(119, 16)
        Me.Label25.TabIndex = 537
        Me.Label25.Text = "Calif. RPM máxima"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(65, 94)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(148, 16)
        Me.Label26.TabIndex = 539
        Me.Label26.Text = "Descripción evaluación"
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(219, 91)
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(413, 22)
        Me.TDESCR.TabIndex = 538
        '
        'RadFull_Sencillo
        '
        Me.RadFull_Sencillo.AutoSize = True
        Me.RadFull_Sencillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFull_Sencillo.Location = New System.Drawing.Point(191, 19)
        Me.RadFull_Sencillo.Name = "RadFull_Sencillo"
        Me.RadFull_Sencillo.Size = New System.Drawing.Size(101, 21)
        Me.RadFull_Sencillo.TabIndex = 30
        Me.RadFull_Sencillo.TabStop = True
        Me.RadFull_Sencillo.Text = "Full/Sencillo"
        Me.RadFull_Sencillo.UseVisualStyleBackColor = False
        '
        'FrmCatEvaluacionesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 465)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.TCALIF_RPM_MAX)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TPON_RPM_MAX)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TRPM_MAX)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ChCalculo_positivo)
        Me.Controls.Add(Me.TBONO7)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TCALIF_GLOBAL7)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TBONO6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TCALIF_GLOBAL6)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TBONO5)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TCALIF_GLOBAL5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TBONO4)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TCALIF_GLOBAL4)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TBONO3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TCALIF_GLOBAL3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TBONO2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TCALIF_GLOBAL2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Box4)
        Me.Controls.Add(Me.TCALIF_VEL_MAX)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TPON_VEL_MAX)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TVEL_MAX)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TPONDE_RALENTI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TPONDE_FC)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBONO1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnMotor)
        Me.Controls.Add(Me.LtMotor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCVE_MOT)
        Me.Controls.Add(Me.TPORC_USO_RALENTI)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.TCALIF_GLOBAL1)
        Me.Controls.Add(Me.TCALIF_RALENTI)
        Me.Controls.Add(Me.TCALIF_FACTOR_CARGA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TCVE_EVA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TFACTOR_CARGA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCatEvaluacionesAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálago evaluación"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.Box4.ResumeLayout(False)
        Me.Box4.PerformLayout()
        CType(Me.ChCalculo_positivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents TPORC_USO_RALENTI As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TCALIF_GLOBAL1 As TextBox
    Friend WithEvents TCALIF_RALENTI As TextBox
    Friend WithEvents TCALIF_FACTOR_CARGA As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TCVE_EVA As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TFACTOR_CARGA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents BtnMotor As Button
    Friend WithEvents LtMotor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TCVE_MOT As TextBox
    Friend WithEvents TBONO1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TPONDE_RALENTI As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TPONDE_FC As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TPON_VEL_MAX As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TVEL_MAX As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TCALIF_VEL_MAX As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Box4 As GroupBox
    Friend WithEvents RadSencillo As RadioButton
    Friend WithEvents RadFull As RadioButton
    Friend WithEvents TBONO2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TCALIF_GLOBAL2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TBONO3 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TCALIF_GLOBAL3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TBONO6 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TCALIF_GLOBAL6 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TBONO5 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TCALIF_GLOBAL5 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TBONO4 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TCALIF_GLOBAL4 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TBONO7 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TCALIF_GLOBAL7 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents ChCalculo_positivo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents TRPM_MAX As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TPON_RPM_MAX As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TCALIF_RPM_MAX As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents RadFull_Sencillo As RadioButton
End Class
