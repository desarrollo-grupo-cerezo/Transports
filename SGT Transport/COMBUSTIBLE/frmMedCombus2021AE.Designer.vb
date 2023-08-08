<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedCombus2021AE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedCombus2021AE))
        Me.LtTAQ_ANCHO = New System.Windows.Forms.Label()
        Me.tCVE_TAQ = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.BtnTAQ = New C1.Win.C1Input.C1Button()
        Me.Box3 = New System.Windows.Forms.GroupBox()
        Me.radSalida = New System.Windows.Forms.RadioButton()
        Me.radEntrada = New System.Windows.Forms.RadioButton()
        Me.LtCm2 = New System.Windows.Forms.Label()
        Me.LtCm1 = New System.Windows.Forms.Label()
        Me.tTanque2 = New System.Windows.Forms.TextBox()
        Me.btnTanque2 = New System.Windows.Forms.Button()
        Me.tTanque1 = New System.Windows.Forms.TextBox()
        Me.btnTanque1 = New System.Windows.Forms.Button()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.btnOper = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtSuma = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.tCLAVE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtTanque2 = New System.Windows.Forms.Label()
        Me.LtTanque1 = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.btnUni = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tTAQ2_CM = New System.Windows.Forms.TextBox()
        Me.tTAQ1_CM = New System.Windows.Forms.TextBox()
        Me.LtTAQ_ALTO = New System.Windows.Forms.Label()
        Me.LtTAQ_ALTO2 = New System.Windows.Forms.Label()
        Me.LtTAQ_ANCHO2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtTAQ_CAPACIDAD2 = New System.Windows.Forms.Label()
        Me.LtTAQ_CAPACIDAD = New System.Windows.Forms.Label()
        Me.BtnCalcTaq1 = New System.Windows.Forms.Button()
        Me.BtnCalcTaq2 = New System.Windows.Forms.Button()
        Me.BtnSumCalcTanqs = New System.Windows.Forms.Button()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.BtnTAQ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Box3.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LtTAQ_ANCHO
        '
        Me.LtTAQ_ANCHO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_ANCHO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_ANCHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_ANCHO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_ANCHO.Location = New System.Drawing.Point(249, 221)
        Me.LtTAQ_ANCHO.Name = "LtTAQ_ANCHO"
        Me.LtTAQ_ANCHO.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_ANCHO.TabIndex = 480
        Me.LtTAQ_ANCHO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_ANCHO, "Office2010Blue")
        '
        'tCVE_TAQ
        '
        Me.tCVE_TAQ.AcceptsReturn = True
        Me.tCVE_TAQ.AcceptsTab = True
        Me.tCVE_TAQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TAQ.ForeColor = System.Drawing.Color.Black
        Me.tCVE_TAQ.Location = New System.Drawing.Point(105, 221)
        Me.tCVE_TAQ.MaxLength = 10
        Me.tCVE_TAQ.Name = "tCVE_TAQ"
        Me.tCVE_TAQ.Size = New System.Drawing.Size(59, 21)
        Me.tCVE_TAQ.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tCVE_TAQ, "Office2010Blue")
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(12, 224)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 15)
        Me.Label37.TabIndex = 478
        Me.Label37.Text = "Tipo de tanque"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label37, "Office2010Blue")
        '
        'BtnTAQ
        '
        Me.BtnTAQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTAQ.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.BtnTAQ.Location = New System.Drawing.Point(166, 221)
        Me.BtnTAQ.Name = "BtnTAQ"
        Me.BtnTAQ.Size = New System.Drawing.Size(24, 21)
        Me.BtnTAQ.TabIndex = 479
        Me.C1ThemeController1.SetTheme(Me.BtnTAQ, "Office2010Blue")
        Me.BtnTAQ.UseVisualStyleBackColor = True
        Me.BtnTAQ.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Box3
        '
        Me.Box3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Box3.Controls.Add(Me.radSalida)
        Me.Box3.Controls.Add(Me.radEntrada)
        Me.Box3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Box3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Box3.Location = New System.Drawing.Point(138, 293)
        Me.Box3.Name = "Box3"
        Me.Box3.Size = New System.Drawing.Size(176, 45)
        Me.Box3.TabIndex = 477
        Me.Box3.TabStop = False
        Me.Box3.Text = "Tipo de litros"
        Me.C1ThemeController1.SetTheme(Me.Box3, "Office2010Blue")
        '
        'radSalida
        '
        Me.radSalida.AutoSize = True
        Me.radSalida.BackColor = System.Drawing.Color.Transparent
        Me.radSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radSalida.Location = New System.Drawing.Point(91, 20)
        Me.radSalida.Name = "radSalida"
        Me.radSalida.Size = New System.Drawing.Size(60, 19)
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
        Me.radEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radEntrada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radEntrada.Location = New System.Drawing.Point(17, 20)
        Me.radEntrada.Name = "radEntrada"
        Me.radEntrada.Size = New System.Drawing.Size(68, 19)
        Me.radEntrada.TabIndex = 8
        Me.radEntrada.TabStop = True
        Me.radEntrada.Text = "Entrada"
        Me.C1ThemeController1.SetTheme(Me.radEntrada, "Office2010Blue")
        Me.radEntrada.UseVisualStyleBackColor = False
        '
        'LtCm2
        '
        Me.LtCm2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCm2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCm2.Location = New System.Drawing.Point(192, 245)
        Me.LtCm2.Name = "LtCm2"
        Me.LtCm2.Size = New System.Drawing.Size(55, 20)
        Me.LtCm2.TabIndex = 475
        Me.LtCm2.Text = "Tanque 2"
        Me.LtCm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtCm2, "Office2010Blue")
        '
        'LtCm1
        '
        Me.LtCm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCm1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCm1.Location = New System.Drawing.Point(192, 221)
        Me.LtCm1.Name = "LtCm1"
        Me.LtCm1.Size = New System.Drawing.Size(55, 20)
        Me.LtCm1.TabIndex = 474
        Me.LtCm1.Text = "Tanque 1"
        Me.LtCm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtCm1, "Office2010Blue")
        '
        'tTanque2
        '
        Me.tTanque2.AcceptsReturn = True
        Me.tTanque2.AcceptsTab = True
        Me.tTanque2.Enabled = False
        Me.tTanque2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTanque2.ForeColor = System.Drawing.Color.Black
        Me.tTanque2.Location = New System.Drawing.Point(89, 406)
        Me.tTanque2.Name = "tTanque2"
        Me.tTanque2.Size = New System.Drawing.Size(49, 22)
        Me.tTanque2.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.tTanque2, "Office2010Blue")
        '
        'btnTanque2
        '
        Me.btnTanque2.AutoSize = True
        Me.btnTanque2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTanque2.BackColor = System.Drawing.Color.Transparent
        Me.btnTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnTanque2.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTanque2.Location = New System.Drawing.Point(138, 406)
        Me.btnTanque2.Name = "btnTanque2"
        Me.btnTanque2.Size = New System.Drawing.Size(24, 23)
        Me.btnTanque2.TabIndex = 472
        Me.C1ThemeController1.SetTheme(Me.btnTanque2, "Office2010Blue")
        Me.btnTanque2.UseVisualStyleBackColor = True
        Me.btnTanque2.Visible = False
        '
        'tTanque1
        '
        Me.tTanque1.AcceptsReturn = True
        Me.tTanque1.AcceptsTab = True
        Me.tTanque1.Enabled = False
        Me.tTanque1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTanque1.ForeColor = System.Drawing.Color.Black
        Me.tTanque1.Location = New System.Drawing.Point(89, 378)
        Me.tTanque1.Name = "tTanque1"
        Me.tTanque1.Size = New System.Drawing.Size(49, 22)
        Me.tTanque1.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.tTanque1, "Office2010Blue")
        '
        'btnTanque1
        '
        Me.btnTanque1.AutoSize = True
        Me.btnTanque1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTanque1.BackColor = System.Drawing.Color.Transparent
        Me.btnTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnTanque1.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTanque1.Location = New System.Drawing.Point(138, 377)
        Me.btnTanque1.Name = "btnTanque1"
        Me.btnTanque1.Size = New System.Drawing.Size(24, 23)
        Me.btnTanque1.TabIndex = 471
        Me.C1ThemeController1.SetTheme(Me.btnTanque1, "Office2010Blue")
        Me.btnTanque1.UseVisualStyleBackColor = True
        Me.btnTanque1.Visible = False
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.tCVE_OPER.Location = New System.Drawing.Point(105, 165)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(60, 22)
        Me.tCVE_OPER.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tCVE_OPER, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(42, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 468
        Me.Label4.Text = "Operador"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtOper.Location = New System.Drawing.Point(192, 165)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(179, 22)
        Me.LtOper.TabIndex = 469
        Me.C1ThemeController1.SetTheme(Me.LtOper, "Office2010Blue")
        '
        'btnOper
        '
        Me.btnOper.AutoSize = True
        Me.btnOper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOper.BackColor = System.Drawing.Color.Transparent
        Me.btnOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnOper.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnOper.Location = New System.Drawing.Point(166, 165)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 23)
        Me.btnOper.TabIndex = 470
        Me.C1ThemeController1.SetTheme(Me.btnOper, "Office2010Blue")
        Me.btnOper.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(234, 438)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 467
        Me.Label5.Text = "Suma"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'LtSuma
        '
        Me.LtSuma.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSuma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSuma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSuma.Location = New System.Drawing.Point(272, 433)
        Me.LtSuma.Name = "LtSuma"
        Me.LtSuma.Size = New System.Drawing.Size(100, 20)
        Me.LtSuma.TabIndex = 466
        Me.LtSuma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtSuma, "Office2010Blue")
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(105, 103)
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
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label108.Location = New System.Drawing.Point(60, 106)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(41, 15)
        Me.Label108.TabIndex = 465
        Me.Label108.Text = "Fecha"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label108, "Office2010Blue")
        '
        'tCLAVE
        '
        Me.tCLAVE.AcceptsReturn = True
        Me.tCLAVE.AcceptsTab = True
        Me.tCLAVE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE.Location = New System.Drawing.Point(105, 72)
        Me.tCLAVE.Name = "tCLAVE"
        Me.tCLAVE.Size = New System.Drawing.Size(60, 22)
        Me.tCLAVE.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCLAVE, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(64, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 464
        Me.Label8.Text = "Clave"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(272, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 25)
        Me.Label7.TabIndex = 463
        Me.Label7.Text = "Litros"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(89, 350)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 25)
        Me.Label6.TabIndex = 462
        Me.Label6.Text = "CM (Diametro)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'LtTanque2
        '
        Me.LtTanque2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque2.Location = New System.Drawing.Point(272, 406)
        Me.LtTanque2.Name = "LtTanque2"
        Me.LtTanque2.Size = New System.Drawing.Size(100, 20)
        Me.LtTanque2.TabIndex = 460
        Me.LtTanque2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTanque2, "Office2010Blue")
        '
        'LtTanque1
        '
        Me.LtTanque1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTanque1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTanque1.Location = New System.Drawing.Point(272, 378)
        Me.LtTanque1.Name = "LtTanque1"
        Me.LtTanque1.Size = New System.Drawing.Size(100, 20)
        Me.LtTanque1.TabIndex = 459
        Me.LtTanque1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTanque1, "Office2010Blue")
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.Black
        Me.tCVE_UNI.Location = New System.Drawing.Point(105, 135)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(60, 22)
        Me.tCVE_UNI.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 456
        Me.Label2.Text = "Unidad"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtUnidad.Location = New System.Drawing.Point(192, 135)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(179, 22)
        Me.LtUnidad.TabIndex = 457
        Me.C1ThemeController1.SetTheme(Me.LtUnidad, "Office2010Blue")
        '
        'btnUni
        '
        Me.btnUni.AutoSize = True
        Me.btnUni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUni.BackColor = System.Drawing.Color.Transparent
        Me.btnUni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnUni.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnUni.Location = New System.Drawing.Point(166, 134)
        Me.btnUni.Name = "btnUni"
        Me.btnUni.Size = New System.Drawing.Size(24, 23)
        Me.btnUni.TabIndex = 458
        Me.C1ThemeController1.SetTheme(Me.btnUni, "Office2010Blue")
        Me.btnUni.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(24, 385)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(59, 15)
        Me.Label27.TabIndex = 454
        Me.Label27.Text = "Tanque 1"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(24, 409)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(59, 15)
        Me.Nombre.TabIndex = 453
        Me.Nombre.Text = "Tanque 2"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(501, 39)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 452
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
        'tTAQ2_CM
        '
        Me.tTAQ2_CM.AcceptsReturn = True
        Me.tTAQ2_CM.AcceptsTab = True
        Me.tTAQ2_CM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTAQ2_CM.ForeColor = System.Drawing.Color.Black
        Me.tTAQ2_CM.Location = New System.Drawing.Point(163, 406)
        Me.tTAQ2_CM.Name = "tTAQ2_CM"
        Me.tTAQ2_CM.Size = New System.Drawing.Size(60, 22)
        Me.tTAQ2_CM.TabIndex = 482
        Me.tTAQ2_CM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tTAQ2_CM, "Office2010Blue")
        '
        'tTAQ1_CM
        '
        Me.tTAQ1_CM.AcceptsReturn = True
        Me.tTAQ1_CM.AcceptsTab = True
        Me.tTAQ1_CM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTAQ1_CM.ForeColor = System.Drawing.Color.Black
        Me.tTAQ1_CM.Location = New System.Drawing.Point(163, 378)
        Me.tTAQ1_CM.Name = "tTAQ1_CM"
        Me.tTAQ1_CM.Size = New System.Drawing.Size(60, 22)
        Me.tTAQ1_CM.TabIndex = 481
        Me.tTAQ1_CM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tTAQ1_CM, "Office2010Blue")
        '
        'LtTAQ_ALTO
        '
        Me.LtTAQ_ALTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_ALTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_ALTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_ALTO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_ALTO.Location = New System.Drawing.Point(311, 221)
        Me.LtTAQ_ALTO.Name = "LtTAQ_ALTO"
        Me.LtTAQ_ALTO.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_ALTO.TabIndex = 484
        Me.LtTAQ_ALTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_ALTO, "Office2010Blue")
        '
        'LtTAQ_ALTO2
        '
        Me.LtTAQ_ALTO2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_ALTO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_ALTO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_ALTO2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_ALTO2.Location = New System.Drawing.Point(311, 245)
        Me.LtTAQ_ALTO2.Name = "LtTAQ_ALTO2"
        Me.LtTAQ_ALTO2.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_ALTO2.TabIndex = 488
        Me.LtTAQ_ALTO2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_ALTO2, "Office2010Blue")
        '
        'LtTAQ_ANCHO2
        '
        Me.LtTAQ_ANCHO2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_ANCHO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_ANCHO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_ANCHO2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_ANCHO2.Location = New System.Drawing.Point(249, 245)
        Me.LtTAQ_ANCHO2.Name = "LtTAQ_ANCHO2"
        Me.LtTAQ_ANCHO2.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_ANCHO2.TabIndex = 487
        Me.LtTAQ_ANCHO2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_ANCHO2, "Office2010Blue")
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(311, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 25)
        Me.Label9.TabIndex = 492
        Me.Label9.Text = "Radio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(249, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 25)
        Me.Label10.TabIndex = 491
        Me.Label10.Text = "Ancho"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(373, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 25)
        Me.Label1.TabIndex = 495
        Me.Label1.Text = "Capacidad"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'LtTAQ_CAPACIDAD2
        '
        Me.LtTAQ_CAPACIDAD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_CAPACIDAD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_CAPACIDAD2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_CAPACIDAD2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_CAPACIDAD2.Location = New System.Drawing.Point(373, 245)
        Me.LtTAQ_CAPACIDAD2.Name = "LtTAQ_CAPACIDAD2"
        Me.LtTAQ_CAPACIDAD2.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_CAPACIDAD2.TabIndex = 494
        Me.LtTAQ_CAPACIDAD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_CAPACIDAD2, "Office2010Blue")
        '
        'LtTAQ_CAPACIDAD
        '
        Me.LtTAQ_CAPACIDAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTAQ_CAPACIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTAQ_CAPACIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTAQ_CAPACIDAD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTAQ_CAPACIDAD.Location = New System.Drawing.Point(373, 221)
        Me.LtTAQ_CAPACIDAD.Name = "LtTAQ_CAPACIDAD"
        Me.LtTAQ_CAPACIDAD.Size = New System.Drawing.Size(60, 20)
        Me.LtTAQ_CAPACIDAD.TabIndex = 493
        Me.LtTAQ_CAPACIDAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTAQ_CAPACIDAD, "Office2010Blue")
        '
        'BtnCalcTaq1
        '
        Me.BtnCalcTaq1.BackColor = System.Drawing.Color.Transparent
        Me.BtnCalcTaq1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCalcTaq1.Location = New System.Drawing.Point(378, 379)
        Me.BtnCalcTaq1.Name = "BtnCalcTaq1"
        Me.BtnCalcTaq1.Size = New System.Drawing.Size(20, 19)
        Me.BtnCalcTaq1.TabIndex = 496
        Me.BtnCalcTaq1.Text = "...."
        Me.C1ThemeController1.SetTheme(Me.BtnCalcTaq1, "Office2010Blue")
        Me.BtnCalcTaq1.UseVisualStyleBackColor = True
        '
        'BtnCalcTaq2
        '
        Me.BtnCalcTaq2.BackColor = System.Drawing.Color.Transparent
        Me.BtnCalcTaq2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCalcTaq2.Location = New System.Drawing.Point(378, 407)
        Me.BtnCalcTaq2.Name = "BtnCalcTaq2"
        Me.BtnCalcTaq2.Size = New System.Drawing.Size(20, 19)
        Me.BtnCalcTaq2.TabIndex = 497
        Me.BtnCalcTaq2.Text = "...."
        Me.C1ThemeController1.SetTheme(Me.BtnCalcTaq2, "Office2010Blue")
        Me.BtnCalcTaq2.UseVisualStyleBackColor = True
        '
        'BtnSumCalcTanqs
        '
        Me.BtnSumCalcTanqs.BackColor = System.Drawing.Color.Transparent
        Me.BtnSumCalcTanqs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnSumCalcTanqs.Location = New System.Drawing.Point(378, 435)
        Me.BtnSumCalcTanqs.Name = "BtnSumCalcTanqs"
        Me.BtnSumCalcTanqs.Size = New System.Drawing.Size(20, 19)
        Me.BtnSumCalcTanqs.TabIndex = 498
        Me.BtnSumCalcTanqs.Text = "...."
        Me.C1ThemeController1.SetTheme(Me.BtnSumCalcTanqs, "Office2010Blue")
        Me.BtnSumCalcTanqs.UseVisualStyleBackColor = True
        '
        'frmMedCombus2021AE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 479)
        Me.Controls.Add(Me.BtnSumCalcTanqs)
        Me.Controls.Add(Me.BtnCalcTaq2)
        Me.Controls.Add(Me.BtnCalcTaq1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtTAQ_CAPACIDAD2)
        Me.Controls.Add(Me.LtTAQ_CAPACIDAD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LtTAQ_ALTO2)
        Me.Controls.Add(Me.LtTAQ_ANCHO2)
        Me.Controls.Add(Me.LtTAQ_ALTO)
        Me.Controls.Add(Me.tTAQ2_CM)
        Me.Controls.Add(Me.tTAQ1_CM)
        Me.Controls.Add(Me.LtTAQ_ANCHO)
        Me.Controls.Add(Me.tCVE_TAQ)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.BtnTAQ)
        Me.Controls.Add(Me.Box3)
        Me.Controls.Add(Me.LtCm2)
        Me.Controls.Add(Me.LtCm1)
        Me.Controls.Add(Me.tTanque2)
        Me.Controls.Add(Me.btnTanque2)
        Me.Controls.Add(Me.tTanque1)
        Me.Controls.Add(Me.btnTanque1)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.btnOper)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtSuma)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.tCLAVE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtTanque2)
        Me.Controls.Add(Me.LtTanque1)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.btnUni)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMedCombus2021AE"
        Me.Text = "Medicion de combustible"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.BtnTAQ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Box3.ResumeLayout(False)
        Me.Box3.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LtTAQ_ANCHO As Label
    Friend WithEvents tCVE_TAQ As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents BtnTAQ As C1.Win.C1Input.C1Button
    Friend WithEvents Box3 As GroupBox
    Friend WithEvents radSalida As RadioButton
    Friend WithEvents radEntrada As RadioButton
    Friend WithEvents LtCm2 As Label
    Friend WithEvents LtCm1 As Label
    Friend WithEvents tTanque2 As TextBox
    Friend WithEvents btnTanque2 As Button
    Friend WithEvents tTanque1 As TextBox
    Friend WithEvents btnTanque1 As Button
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents btnOper As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents LtSuma As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label108 As Label
    Friend WithEvents tCLAVE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtTanque2 As Label
    Friend WithEvents LtTanque1 As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LtUnidad As Label
    Friend WithEvents btnUni As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tTAQ2_CM As TextBox
    Friend WithEvents tTAQ1_CM As TextBox
    Friend WithEvents LtTAQ_ALTO As Label
    Friend WithEvents LtTAQ_ALTO2 As Label
    Friend WithEvents LtTAQ_ANCHO2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LtTAQ_CAPACIDAD2 As Label
    Friend WithEvents LtTAQ_CAPACIDAD As Label
    Friend WithEvents BtnCalcTaq1 As Button
    Friend WithEvents BtnCalcTaq2 As Button
    Friend WithEvents BtnSumCalcTanqs As Button
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
