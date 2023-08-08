<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCasetasAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCasetasAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_CAS = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tImporte = New C1.Win.C1Input.C1NumericEdit()
        Me.cboTipoPago = New C1.Win.C1Input.C1ComboBox()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tImporte2 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tImporte5 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tImporte8 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tImporte7 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tImporte4 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tImporte3 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tImporte6 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtPlaza = New System.Windows.Forms.Label()
        Me.btnPlaza = New System.Windows.Forms.Button()
        Me.tCVE_PLAZA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tIMPORTE1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.TIAVE = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCLAVE_REM = New System.Windows.Forms.Button()
        Me.tCLAVE_O = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LtNombre1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.tImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tIMPORTE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(715, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 5
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
        'tCVE_CAS
        '
        Me.tCVE_CAS.AcceptsReturn = True
        Me.tCVE_CAS.AcceptsTab = True
        Me.tCVE_CAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_CAS.ForeColor = System.Drawing.Color.Black
        Me.tCVE_CAS.Location = New System.Drawing.Point(127, 86)
        Me.tCVE_CAS.Name = "tCVE_CAS"
        Me.tCVE_CAS.Size = New System.Drawing.Size(55, 22)
        Me.tCVE_CAS.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_CAS, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(78, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.ForeColor = System.Drawing.Color.Black
        Me.tDescr.Location = New System.Drawing.Point(127, 118)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(395, 22)
        Me.tDescr.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tDescr, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(64, 121)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Multitag/Efectivo"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(262, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Costo eje 2"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'tImporte
        '
        Me.tImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte.Location = New System.Drawing.Point(342, 222)
        Me.tImporte.Name = "tImporte"
        Me.tImporte.Size = New System.Drawing.Size(110, 20)
        Me.tImporte.TabIndex = 7
        Me.tImporte.Tag = Nothing
        Me.tImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte, "Office2010Blue")
        Me.tImporte.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'cboTipoPago
        '
        Me.cboTipoPago.AllowSpinLoop = False
        Me.cboTipoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboTipoPago.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboTipoPago.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboTipoPago.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboTipoPago.GapHeight = 0
        Me.cboTipoPago.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboTipoPago.ItemsDisplayMember = ""
        Me.cboTipoPago.ItemsValueMember = ""
        Me.cboTipoPago.Location = New System.Drawing.Point(126, 187)
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(55, 20)
        Me.cboTipoPago.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboTipoPago.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboTipoPago.TabIndex = 5
        Me.cboTipoPago.Tag = Nothing
        Me.cboTipoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.C1ThemeController1.SetTheme(Me.cboTipoPago, "Office2010Blue")
        Me.cboTipoPago.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'tImporte2
        '
        Me.tImporte2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte2.Location = New System.Drawing.Point(557, 222)
        Me.tImporte2.Name = "tImporte2"
        Me.tImporte2.Size = New System.Drawing.Size(110, 20)
        Me.tImporte2.TabIndex = 8
        Me.tImporte2.Tag = Nothing
        Me.tImporte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte2, "Office2010Blue")
        Me.tImporte2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(478, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Costo eje 3"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'tImporte5
        '
        Me.tImporte5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte5.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte5.Location = New System.Drawing.Point(557, 260)
        Me.tImporte5.Name = "tImporte5"
        Me.tImporte5.Size = New System.Drawing.Size(110, 20)
        Me.tImporte5.TabIndex = 11
        Me.tImporte5.Tag = Nothing
        Me.tImporte5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte5, "Office2010Blue")
        Me.tImporte5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(478, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Costo eje 9"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'tImporte8
        '
        Me.tImporte8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte8.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte8.Location = New System.Drawing.Point(557, 297)
        Me.tImporte8.Name = "tImporte8"
        Me.tImporte8.Size = New System.Drawing.Size(110, 20)
        Me.tImporte8.TabIndex = 14
        Me.tImporte8.Tag = Nothing
        Me.tImporte8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte8, "Office2010Blue")
        Me.tImporte8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(478, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Costo eje 6"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'tImporte7
        '
        Me.tImporte7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte7.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte7.Location = New System.Drawing.Point(342, 297)
        Me.tImporte7.Name = "tImporte7"
        Me.tImporte7.Size = New System.Drawing.Size(110, 20)
        Me.tImporte7.TabIndex = 13
        Me.tImporte7.Tag = Nothing
        Me.tImporte7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte7, "Office2010Blue")
        Me.tImporte7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(262, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Costo eje 8"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'tImporte4
        '
        Me.tImporte4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte4.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte4.Location = New System.Drawing.Point(342, 260)
        Me.tImporte4.Name = "tImporte4"
        Me.tImporte4.Size = New System.Drawing.Size(110, 20)
        Me.tImporte4.TabIndex = 10
        Me.tImporte4.Tag = Nothing
        Me.tImporte4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte4, "Office2010Blue")
        Me.tImporte4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(262, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 16)
        Me.Label7.TabIndex = 130
        Me.Label7.Text = "Costo eje 5"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'tImporte3
        '
        Me.tImporte3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte3.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte3.Location = New System.Drawing.Point(126, 260)
        Me.tImporte3.Name = "tImporte3"
        Me.tImporte3.Size = New System.Drawing.Size(110, 20)
        Me.tImporte3.TabIndex = 9
        Me.tImporte3.Tag = Nothing
        Me.tImporte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte3, "Office2010Blue")
        Me.tImporte3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(46, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 16)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Costo eje 4"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'tImporte6
        '
        Me.tImporte6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tImporte6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte6.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tImporte6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte6.Location = New System.Drawing.Point(126, 297)
        Me.tImporte6.Name = "tImporte6"
        Me.tImporte6.Size = New System.Drawing.Size(110, 20)
        Me.tImporte6.TabIndex = 12
        Me.tImporte6.Tag = Nothing
        Me.tImporte6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tImporte6, "Office2010Blue")
        Me.tImporte6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(46, 300)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 16)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = "Costo eje 7"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'LtPlaza
        '
        Me.LtPlaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPlaza.Location = New System.Drawing.Point(215, 150)
        Me.LtPlaza.Name = "LtPlaza"
        Me.LtPlaza.Size = New System.Drawing.Size(307, 22)
        Me.LtPlaza.TabIndex = 440
        Me.LtPlaza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtPlaza, "Office2010Blue")
        '
        'btnPlaza
        '
        Me.btnPlaza.AutoSize = True
        Me.btnPlaza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza.BackColor = System.Drawing.Color.Transparent
        Me.btnPlaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPlaza.Image = CType(resources.GetObject("btnPlaza.Image"), System.Drawing.Image)
        Me.btnPlaza.Location = New System.Drawing.Point(185, 149)
        Me.btnPlaza.Name = "btnPlaza"
        Me.btnPlaza.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza.TabIndex = 439
        Me.C1ThemeController1.SetTheme(Me.btnPlaza, "Office2010Blue")
        Me.btnPlaza.UseVisualStyleBackColor = True
        '
        'tCVE_PLAZA
        '
        Me.tCVE_PLAZA.AcceptsReturn = True
        Me.tCVE_PLAZA.AcceptsTab = True
        Me.tCVE_PLAZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PLAZA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PLAZA.Location = New System.Drawing.Point(127, 150)
        Me.tCVE_PLAZA.Name = "tCVE_PLAZA"
        Me.tCVE_PLAZA.Size = New System.Drawing.Size(54, 22)
        Me.tCVE_PLAZA.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PLAZA, "Office2010Blue")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(79, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 438
        Me.Label10.Text = "Plaza"
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'tIMPORTE1
        '
        Me.tIMPORTE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tIMPORTE1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tIMPORTE1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tIMPORTE1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tIMPORTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIMPORTE1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tIMPORTE1.Location = New System.Drawing.Point(126, 222)
        Me.tIMPORTE1.Name = "tIMPORTE1"
        Me.tIMPORTE1.Size = New System.Drawing.Size(110, 20)
        Me.tIMPORTE1.TabIndex = 6
        Me.tIMPORTE1.Tag = Nothing
        Me.tIMPORTE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tIMPORTE1, "Office2010Blue")
        Me.tIMPORTE1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tIMPORTE1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(46, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 442
        Me.Label11.Text = "Costo eje 1"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        '
        'TIAVE
        '
        Me.TIAVE.AcceptsReturn = True
        Me.TIAVE.AcceptsTab = True
        Me.TIAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIAVE.ForeColor = System.Drawing.Color.Black
        Me.TIAVE.Location = New System.Drawing.Point(127, 455)
        Me.TIAVE.Name = "TIAVE"
        Me.TIAVE.Size = New System.Drawing.Size(148, 21)
        Me.TIAVE.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.TIAVE, "Office2010Blue")
        Me.TIAVE.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(89, 458)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 15)
        Me.Label12.TabIndex = 469
        Me.Label12.Text = "IAVE"
        Me.C1ThemeController1.SetTheme(Me.Label12, "Office2010Blue")
        Me.Label12.Visible = False
        '
        'btnCLAVE_REM
        '
        Me.btnCLAVE_REM.AutoSize = True
        Me.btnCLAVE_REM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCLAVE_REM.BackColor = System.Drawing.Color.Transparent
        Me.btnCLAVE_REM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLAVE_REM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnCLAVE_REM.Image = CType(resources.GetObject("btnCLAVE_REM.Image"), System.Drawing.Image)
        Me.btnCLAVE_REM.Location = New System.Drawing.Point(188, 423)
        Me.btnCLAVE_REM.Name = "btnCLAVE_REM"
        Me.btnCLAVE_REM.Size = New System.Drawing.Size(24, 23)
        Me.btnCLAVE_REM.TabIndex = 468
        Me.C1ThemeController1.SetTheme(Me.btnCLAVE_REM, "Office2010Blue")
        Me.btnCLAVE_REM.UseVisualStyleBackColor = True
        Me.btnCLAVE_REM.Visible = False
        '
        'tCLAVE_O
        '
        Me.tCLAVE_O.AcceptsReturn = True
        Me.tCLAVE_O.AcceptsTab = True
        Me.tCLAVE_O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCLAVE_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE_O.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE_O.Location = New System.Drawing.Point(127, 424)
        Me.tCLAVE_O.Name = "tCLAVE_O"
        Me.tCLAVE_O.Size = New System.Drawing.Size(57, 21)
        Me.tCLAVE_O.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCLAVE_O, "Office2010Blue")
        Me.tCLAVE_O.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(23, 427)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 15)
        Me.Label19.TabIndex = 466
        Me.Label19.Text = "Cliente operativo"
        Me.C1ThemeController1.SetTheme(Me.Label19, "Office2010Blue")
        Me.Label19.Visible = False
        '
        'LtNombre1
        '
        Me.LtNombre1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre1.Location = New System.Drawing.Point(215, 424)
        Me.LtNombre1.Name = "LtNombre1"
        Me.LtNombre1.Size = New System.Drawing.Size(307, 21)
        Me.LtNombre1.TabIndex = 467
        Me.C1ThemeController1.SetTheme(Me.LtNombre1, "Office2010Blue")
        Me.LtNombre1.Visible = False
        '
        'frmCasetasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 376)
        Me.Controls.Add(Me.TIAVE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnCLAVE_REM)
        Me.Controls.Add(Me.tCLAVE_O)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.LtNombre1)
        Me.Controls.Add(Me.tIMPORTE1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LtPlaza)
        Me.Controls.Add(Me.btnPlaza)
        Me.Controls.Add(Me.tCVE_PLAZA)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tImporte6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tImporte3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tImporte4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tImporte7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tImporte8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tImporte5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tImporte2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoPago)
        Me.Controls.Add(Me.tImporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCVE_CAS)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCasetasAE"
        Me.ShowInTaskbar = False
        Me.Text = "Casetas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tIMPORTE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_CAS As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tImporte As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cboTipoPago As C1.Win.C1Input.C1ComboBox
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tImporte2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents tImporte5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents tImporte8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents tImporte7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents tImporte4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents tImporte3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents tImporte6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents LtPlaza As Label
    Friend WithEvents btnPlaza As Button
    Friend WithEvents tCVE_PLAZA As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tIMPORTE1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents TIAVE As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCLAVE_REM As Button
    Friend WithEvents tCLAVE_O As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LtNombre1 As Label
End Class
