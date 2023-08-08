<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabRutasAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTabRutasAE))
        Me.tCVE_TAB = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.radSencillo = New System.Windows.Forms.RadioButton()
        Me.radFull = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.radVacio = New System.Windows.Forms.RadioButton()
        Me.radCargado = New System.Windows.Forms.RadioButton()
        Me.tCLIENTE = New System.Windows.Forms.TextBox()
        Me.LtCliente = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tFLETE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tSUELDO_OPER = New C1.Win.C1Input.C1NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tP_X_LITRO = New C1.Win.C1Input.C1NumericEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tRENDIMIENTO = New C1.Win.C1Input.C1NumericEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCliente = New C1.Win.C1Input.C1Button()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tLITROS_RUTA = New System.Windows.Forms.Label()
        Me.tCOSTO_DISEL = New System.Windows.Forms.Label()
        Me.LtCOSTO_CASETAS = New System.Windows.Forms.Label()
        Me.LtPlaza2 = New System.Windows.Forms.Label()
        Me.btnPlaza = New System.Windows.Forms.Button()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.tCVE_PLAZA = New System.Windows.Forms.TextBox()
        Me.btnPlaza2 = New System.Windows.Forms.Button()
        Me.tCVE_PLAZA2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.TEJES = New System.Windows.Forms.TextBox()
        Me.tKM_RECORRIDOS = New C1.Win.C1Input.C1TextBox()
        Me.tCOSTO_CASETAS = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TOBSER = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.barMenu.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tFLETE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSUELDO_OPER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tP_X_LITRO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tRENDIMIENTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM_RECORRIDOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCOSTO_CASETAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tCVE_TAB
        '
        Me.tCVE_TAB.AcceptsReturn = True
        Me.tCVE_TAB.AcceptsTab = True
        Me.tCVE_TAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TAB.ForeColor = System.Drawing.Color.Black
        Me.tCVE_TAB.Location = New System.Drawing.Point(160, 78)
        Me.tCVE_TAB.Name = "tCVE_TAB"
        Me.tCVE_TAB.Size = New System.Drawing.Size(91, 22)
        Me.tCVE_TAB.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_TAB, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(111, 81)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(651, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 10
        Me.barMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barMenu, "Office2010Blue")
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
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(160, 115)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(108, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 16)
        Me.Label7.TabIndex = 379
        Me.Label7.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.radSencillo)
        Me.GroupBox4.Controls.Add(Me.radFull)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(306, 81)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(141, 55)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo unidad"
        Me.C1ThemeController1.SetTheme(Me.GroupBox4, "Office2010Blue")
        '
        'radSencillo
        '
        Me.radSencillo.AutoSize = True
        Me.radSencillo.BackColor = System.Drawing.Color.Transparent
        Me.radSencillo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radSencillo.Location = New System.Drawing.Point(69, 23)
        Me.radSencillo.Name = "radSencillo"
        Me.radSencillo.Size = New System.Drawing.Size(74, 20)
        Me.radSencillo.TabIndex = 3
        Me.radSencillo.TabStop = True
        Me.radSencillo.Text = "Sencillo"
        Me.C1ThemeController1.SetTheme(Me.radSencillo, "Office2010Blue")
        Me.radSencillo.UseVisualStyleBackColor = False
        '
        'radFull
        '
        Me.radFull.AutoSize = True
        Me.radFull.BackColor = System.Drawing.Color.Transparent
        Me.radFull.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radFull.Location = New System.Drawing.Point(12, 23)
        Me.radFull.Name = "radFull"
        Me.radFull.Size = New System.Drawing.Size(47, 20)
        Me.radFull.TabIndex = 2
        Me.radFull.TabStop = True
        Me.radFull.Text = "Full"
        Me.C1ThemeController1.SetTheme(Me.radFull, "Office2010Blue")
        Me.radFull.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.radVacio)
        Me.GroupBox3.Controls.Add(Me.radCargado)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(454, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(165, 55)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo viaje"
        Me.C1ThemeController1.SetTheme(Me.GroupBox3, "Office2010Blue")
        '
        'radVacio
        '
        Me.radVacio.AutoSize = True
        Me.radVacio.BackColor = System.Drawing.Color.Transparent
        Me.radVacio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radVacio.Location = New System.Drawing.Point(97, 23)
        Me.radVacio.Name = "radVacio"
        Me.radVacio.Size = New System.Drawing.Size(61, 20)
        Me.radVacio.TabIndex = 5
        Me.radVacio.TabStop = True
        Me.radVacio.Text = "Vacio"
        Me.C1ThemeController1.SetTheme(Me.radVacio, "Office2010Blue")
        Me.radVacio.UseVisualStyleBackColor = False
        '
        'radCargado
        '
        Me.radCargado.AutoSize = True
        Me.radCargado.BackColor = System.Drawing.Color.Transparent
        Me.radCargado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radCargado.Location = New System.Drawing.Point(16, 23)
        Me.radCargado.Name = "radCargado"
        Me.radCargado.Size = New System.Drawing.Size(79, 20)
        Me.radCargado.TabIndex = 4
        Me.radCargado.TabStop = True
        Me.radCargado.Text = "Cargado"
        Me.C1ThemeController1.SetTheme(Me.radCargado, "Office2010Blue")
        Me.radCargado.UseVisualStyleBackColor = False
        '
        'tCLIENTE
        '
        Me.tCLIENTE.AcceptsReturn = True
        Me.tCLIENTE.AcceptsTab = True
        Me.tCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLIENTE.ForeColor = System.Drawing.Color.Black
        Me.tCLIENTE.Location = New System.Drawing.Point(160, 150)
        Me.tCLIENTE.Name = "tCLIENTE"
        Me.tCLIENTE.Size = New System.Drawing.Size(114, 22)
        Me.tCLIENTE.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.tCLIENTE, "Office2010Blue")
        '
        'LtCliente
        '
        Me.LtCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCliente.Location = New System.Drawing.Point(302, 151)
        Me.LtCliente.Name = "LtCliente"
        Me.LtCliente.Size = New System.Drawing.Size(305, 20)
        Me.LtCliente.TabIndex = 406
        Me.LtCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCliente, "Office2010Blue")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(105, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 16)
        Me.Label15.TabIndex = 405
        Me.Label15.Text = "Cliente"
        Me.C1ThemeController1.SetTheme(Me.Label15, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(57, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 408
        Me.Label2.Text = "KM Recorridos"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(60, 297)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 410
        Me.Label3.Text = "Costo casetas"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'tFLETE
        '
        Me.tFLETE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tFLETE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tFLETE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tFLETE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tFLETE.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tFLETE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tFLETE.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tFLETE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFLETE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFLETE.Location = New System.Drawing.Point(160, 353)
        Me.tFLETE.Name = "tFLETE"
        Me.tFLETE.Size = New System.Drawing.Size(142, 20)
        Me.tFLETE.TabIndex = 12
        Me.tFLETE.Tag = Nothing
        Me.tFLETE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tFLETE, "Office2010Blue")
        Me.tFLETE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tFLETE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(116, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 412
        Me.Label4.Text = "Flete"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'tSUELDO_OPER
        '
        Me.tSUELDO_OPER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tSUELDO_OPER.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tSUELDO_OPER.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tSUELDO_OPER.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tSUELDO_OPER.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tSUELDO_OPER.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tSUELDO_OPER.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tSUELDO_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUELDO_OPER.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tSUELDO_OPER.Location = New System.Drawing.Point(160, 380)
        Me.tSUELDO_OPER.Name = "tSUELDO_OPER"
        Me.tSUELDO_OPER.Size = New System.Drawing.Size(142, 20)
        Me.tSUELDO_OPER.TabIndex = 13
        Me.tSUELDO_OPER.Tag = Nothing
        Me.tSUELDO_OPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tSUELDO_OPER, "Office2010Blue")
        Me.tSUELDO_OPER.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tSUELDO_OPER.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(44, 382)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 16)
        Me.Label5.TabIndex = 414
        Me.Label5.Text = "Sueldo operador"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(381, 380)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 422
        Me.Label6.Text = "Costo diesel"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(399, 357)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 420
        Me.Label8.Text = "Litros ruta"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'tP_X_LITRO
        '
        Me.tP_X_LITRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tP_X_LITRO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tP_X_LITRO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tP_X_LITRO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tP_X_LITRO.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tP_X_LITRO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tP_X_LITRO.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tP_X_LITRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tP_X_LITRO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tP_X_LITRO.Location = New System.Drawing.Point(467, 326)
        Me.tP_X_LITRO.Name = "tP_X_LITRO"
        Me.tP_X_LITRO.Size = New System.Drawing.Size(142, 20)
        Me.tP_X_LITRO.TabIndex = 15
        Me.tP_X_LITRO.Tag = Nothing
        Me.tP_X_LITRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tP_X_LITRO, "Office2010Blue")
        Me.tP_X_LITRO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tP_X_LITRO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(408, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 418
        Me.Label9.Text = "P X Litro"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'tRENDIMIENTO
        '
        Me.tRENDIMIENTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tRENDIMIENTO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tRENDIMIENTO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tRENDIMIENTO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tRENDIMIENTO.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tRENDIMIENTO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tRENDIMIENTO.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tRENDIMIENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRENDIMIENTO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tRENDIMIENTO.Location = New System.Drawing.Point(467, 300)
        Me.tRENDIMIENTO.Name = "tRENDIMIENTO"
        Me.tRENDIMIENTO.Size = New System.Drawing.Size(142, 20)
        Me.tRENDIMIENTO.TabIndex = 14
        Me.tRENDIMIENTO.Tag = Nothing
        Me.tRENDIMIENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tRENDIMIENTO, "Office2010Blue")
        Me.tRENDIMIENTO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tRENDIMIENTO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(380, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 16)
        Me.Label10.TabIndex = 416
        Me.Label10.Text = "Rendimiento"
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'btnCliente
        '
        Me.btnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnCliente.Location = New System.Drawing.Point(277, 150)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(24, 23)
        Me.btnCliente.TabIndex = 404
        Me.C1ThemeController1.SetTheme(Me.btnCliente, "Office2010Blue")
        Me.btnCliente.UseVisualStyleBackColor = True
        Me.btnCliente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(119, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 16)
        Me.Label12.TabIndex = 429
        Me.Label12.Text = "Ejes"
        Me.C1ThemeController1.SetTheme(Me.Label12, "Office2010Blue")
        '
        'tLITROS_RUTA
        '
        Me.tLITROS_RUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tLITROS_RUTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tLITROS_RUTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLITROS_RUTA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tLITROS_RUTA.Location = New System.Drawing.Point(467, 353)
        Me.tLITROS_RUTA.Name = "tLITROS_RUTA"
        Me.tLITROS_RUTA.Size = New System.Drawing.Size(140, 22)
        Me.tLITROS_RUTA.TabIndex = 430
        Me.tLITROS_RUTA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tLITROS_RUTA, "Office2010Blue")
        '
        'tCOSTO_DISEL
        '
        Me.tCOSTO_DISEL.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tCOSTO_DISEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCOSTO_DISEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOSTO_DISEL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tCOSTO_DISEL.Location = New System.Drawing.Point(467, 380)
        Me.tCOSTO_DISEL.Name = "tCOSTO_DISEL"
        Me.tCOSTO_DISEL.Size = New System.Drawing.Size(140, 22)
        Me.tCOSTO_DISEL.TabIndex = 431
        Me.tCOSTO_DISEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.tCOSTO_DISEL, "Office2010Blue")
        '
        'LtCOSTO_CASETAS
        '
        Me.LtCOSTO_CASETAS.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCOSTO_CASETAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCOSTO_CASETAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCOSTO_CASETAS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCOSTO_CASETAS.Location = New System.Drawing.Point(160, 326)
        Me.LtCOSTO_CASETAS.Name = "LtCOSTO_CASETAS"
        Me.LtCOSTO_CASETAS.Size = New System.Drawing.Size(142, 22)
        Me.LtCOSTO_CASETAS.TabIndex = 433
        Me.LtCOSTO_CASETAS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtCOSTO_CASETAS, "Office2010Blue")
        '
        'LtPlaza2
        '
        Me.LtPlaza2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza2.Location = New System.Drawing.Point(301, 209)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(305, 21)
        Me.LtPlaza2.TabIndex = 439
        Me.C1ThemeController1.SetTheme(Me.LtPlaza2, "Office2010Blue")
        '
        'btnPlaza
        '
        Me.btnPlaza.AutoSize = True
        Me.btnPlaza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza.Image = CType(resources.GetObject("btnPlaza.Image"), System.Drawing.Image)
        Me.btnPlaza.Location = New System.Drawing.Point(277, 180)
        Me.btnPlaza.Name = "btnPlaza"
        Me.btnPlaza.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza.TabIndex = 440
        Me.C1ThemeController1.SetTheme(Me.btnPlaza, "Office2010Blue")
        Me.btnPlaza.UseVisualStyleBackColor = True
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(302, 181)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(305, 21)
        Me.LtPlaza.TabIndex = 436
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'tCVE_PLAZA
        '
        Me.tCVE_PLAZA.AcceptsReturn = True
        Me.tCVE_PLAZA.AcceptsTab = True
        Me.tCVE_PLAZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA.Location = New System.Drawing.Point(160, 180)
        Me.tCVE_PLAZA.Name = "tCVE_PLAZA"
        Me.tCVE_PLAZA.Size = New System.Drawing.Size(113, 22)
        Me.tCVE_PLAZA.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA, "Office2010Blue")
        '
        'btnPlaza2
        '
        Me.btnPlaza2.AutoSize = True
        Me.btnPlaza2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza2.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaza2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza2.Image = CType(resources.GetObject("btnPlaza2.Image"), System.Drawing.Image)
        Me.btnPlaza2.Location = New System.Drawing.Point(277, 208)
        Me.btnPlaza2.Name = "btnPlaza2"
        Me.btnPlaza2.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza2.TabIndex = 441
        Me.C1ThemeController1.SetTheme(Me.btnPlaza2, "Office2010Blue")
        Me.btnPlaza2.UseVisualStyleBackColor = True
        '
        'tCVE_PLAZA2
        '
        Me.tCVE_PLAZA2.AcceptsReturn = True
        Me.tCVE_PLAZA2.AcceptsTab = True
        Me.tCVE_PLAZA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA2.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA2.Location = New System.Drawing.Point(160, 209)
        Me.tCVE_PLAZA2.Name = "tCVE_PLAZA2"
        Me.tCVE_PLAZA2.Size = New System.Drawing.Size(113, 22)
        Me.tCVE_PLAZA2.TabIndex = 8
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA2, "Office2010Blue")
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(106, 185)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 16)
        Me.Label41.TabIndex = 437
        Me.Label41.Text = "Origen"
        Me.C1ThemeController1.SetTheme(Me.Label41, "Office2010Blue")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(100, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 434
        Me.Label13.Text = "Destino"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2010Blue")
        '
        'TEJES
        '
        Me.TEJES.AcceptsReturn = True
        Me.TEJES.AcceptsTab = True
        Me.TEJES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEJES.ForeColor = System.Drawing.Color.Black
        Me.TEJES.Location = New System.Drawing.Point(160, 247)
        Me.TEJES.Name = "TEJES"
        Me.TEJES.Size = New System.Drawing.Size(142, 22)
        Me.TEJES.TabIndex = 9
        Me.C1ThemeController1.SetTheme(Me.TEJES, "Office2010Blue")
        '
        'tKM_RECORRIDOS
        '
        Me.tKM_RECORRIDOS.AcceptsReturn = True
        Me.tKM_RECORRIDOS.AcceptsTab = True
        Me.tKM_RECORRIDOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tKM_RECORRIDOS.CustomFormat = "###,###,##0.00"
        Me.tKM_RECORRIDOS.DataType = GetType(Decimal)
        Me.tKM_RECORRIDOS.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tKM_RECORRIDOS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tKM_RECORRIDOS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM_RECORRIDOS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tKM_RECORRIDOS.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM_RECORRIDOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tKM_RECORRIDOS.Location = New System.Drawing.Point(160, 275)
        Me.tKM_RECORRIDOS.Name = "tKM_RECORRIDOS"
        Me.tKM_RECORRIDOS.Size = New System.Drawing.Size(142, 20)
        Me.tKM_RECORRIDOS.TabIndex = 10
        Me.tKM_RECORRIDOS.Tag = Nothing
        Me.tKM_RECORRIDOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tKM_RECORRIDOS, "Office2010Blue")
        Me.tKM_RECORRIDOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCOSTO_CASETAS
        '
        Me.tCOSTO_CASETAS.AcceptsReturn = True
        Me.tCOSTO_CASETAS.AcceptsTab = True
        Me.tCOSTO_CASETAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCOSTO_CASETAS.CustomFormat = "###,###,##0.00"
        Me.tCOSTO_CASETAS.DataType = GetType(Decimal)
        Me.tCOSTO_CASETAS.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tCOSTO_CASETAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tCOSTO_CASETAS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOSTO_CASETAS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tCOSTO_CASETAS.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOSTO_CASETAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOSTO_CASETAS.Location = New System.Drawing.Point(160, 300)
        Me.tCOSTO_CASETAS.Name = "tCOSTO_CASETAS"
        Me.tCOSTO_CASETAS.Size = New System.Drawing.Size(142, 20)
        Me.tCOSTO_CASETAS.TabIndex = 11
        Me.tCOSTO_CASETAS.Tag = Nothing
        Me.tCOSTO_CASETAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tCOSTO_CASETAS, "Office2010Blue")
        Me.tCOSTO_CASETAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(52, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 16)
        Me.Label1.TabIndex = 443
        Me.Label1.Text = "Casetas sin IVA"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TOBSER
        '
        Me.TOBSER.AcceptsReturn = True
        Me.TOBSER.AcceptsTab = True
        Me.TOBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBSER.ForeColor = System.Drawing.Color.Black
        Me.TOBSER.Location = New System.Drawing.Point(160, 415)
        Me.TOBSER.Multiline = True
        Me.TOBSER.Name = "TOBSER"
        Me.TOBSER.Size = New System.Drawing.Size(446, 53)
        Me.TOBSER.TabIndex = 16
        Me.C1ThemeController1.SetTheme(Me.TOBSER, "Office2010Blue")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(54, 418)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 16)
        Me.Label11.TabIndex = 445
        Me.Label11.Text = "Observaciones"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        '
        'frmTabRutasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 492)
        Me.Controls.Add(Me.TOBSER)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCOSTO_CASETAS)
        Me.Controls.Add(Me.tKM_RECORRIDOS)
        Me.Controls.Add(Me.TEJES)
        Me.Controls.Add(Me.LtPlaza2)
        Me.Controls.Add(Me.btnPlaza)
        Me.Controls.Add(Me.LtPlaza)
        Me.Controls.Add(Me.tCVE_PLAZA)
        Me.Controls.Add(Me.btnPlaza2)
        Me.Controls.Add(Me.tCVE_PLAZA2)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LtCOSTO_CASETAS)
        Me.Controls.Add(Me.tCOSTO_DISEL)
        Me.Controls.Add(Me.tLITROS_RUTA)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tP_X_LITRO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tRENDIMIENTO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tSUELDO_OPER)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tFLETE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCLIENTE)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.LtCliente)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tCVE_TAB)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTabRutasAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabulador de ruta"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tFLETE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSUELDO_OPER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tP_X_LITRO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tRENDIMIENTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM_RECORRIDOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCOSTO_CASETAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tCVE_TAB As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents radSencillo As RadioButton
    Friend WithEvents radFull As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents radVacio As RadioButton
    Friend WithEvents radCargado As RadioButton
    Friend WithEvents tCLIENTE As TextBox
    Friend WithEvents btnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents LtCliente As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tFLETE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents tSUELDO_OPER As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tP_X_LITRO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents tRENDIMIENTO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Label12 As Label
    Friend WithEvents tLITROS_RUTA As Label
    Friend WithEvents tCOSTO_DISEL As Label
    Friend WithEvents LtCOSTO_CASETAS As Label
    Friend WithEvents LtPlaza2 As Label
    Friend WithEvents btnPlaza As Button
    Friend WithEvents LtPlaza As Label
    Friend WithEvents tCVE_PLAZA As TextBox
    Friend WithEvents btnPlaza2 As Button
    Friend WithEvents tCVE_PLAZA2 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents TEJES As TextBox
    Friend WithEvents tKM_RECORRIDOS As C1.Win.C1Input.C1TextBox
    Friend WithEvents tCOSTO_CASETAS As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TOBSER As TextBox
    Friend WithEvents Label11 As Label
End Class
