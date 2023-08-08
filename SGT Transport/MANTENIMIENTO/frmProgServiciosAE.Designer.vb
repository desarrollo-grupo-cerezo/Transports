<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProgServiciosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgServiciosAE))
        Me.tCVE_PROG = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tKM_ACTUAL = New C1.Win.C1Input.C1NumericEdit()
        Me.tKM_PROX_SERVICIO = New C1.Win.C1Input.C1NumericEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.btnUnidad = New System.Windows.Forms.Button()
        Me.LtStatus = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.F3 = New C1.Win.Calendar.C1DateEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.F4 = New C1.Win.Calendar.C1DateEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarFinalizado = New C1.Win.C1Command.C1Command()
        Me.BarCancelar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkFinalizarservicio = New C1.Win.C1Command.C1CommandLink()
        Me.LkCancelar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tBotonMagico = New System.Windows.Forms.TextBox()
        Me.btnAltaProducto = New C1.Win.C1Input.C1Button()
        Me.btnEliProd = New C1.Win.C1Input.C1Button()
        Me.BtnActManto = New System.Windows.Forms.Button()
        Me.LtActMante = New System.Windows.Forms.Label()
        Me.tCVE_SER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM_ACTUAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM_PROX_SERVICIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tCVE_PROG
        '
        Me.tCVE_PROG.AcceptsReturn = True
        Me.tCVE_PROG.AcceptsTab = True
        Me.tCVE_PROG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROG.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PROG.Location = New System.Drawing.Point(156, 60)
        Me.tCVE_PROG.Name = "tCVE_PROG"
        Me.tCVE_PROG.Size = New System.Drawing.Size(68, 21)
        Me.tCVE_PROG.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROG, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(116, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 15)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.ForeColor = System.Drawing.Color.Black
        Me.tCVE_UNI.Location = New System.Drawing.Point(156, 165)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_UNI.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.tCVE_UNI, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(106, 169)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(47, 15)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Unidad"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'F1
        '
        Me.F1.AcceptsTab = True
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime
        Me.F1.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.F1.Enabled = False
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(156, 89)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(166, 19)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(45, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 15)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Fecha de creacion"
        Me.C1ThemeController1.SetTheme(Me.Label14, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(45, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Kilometraje actual"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 15)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Fecha de programacion"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(340, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 15)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Kilometraje proximo servicio"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtUnidad.Location = New System.Drawing.Point(253, 166)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(232, 20)
        Me.LtUnidad.TabIndex = 180
        Me.C1ThemeController1.SetTheme(Me.LtUnidad, "Office2010Blue")
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.ForeColor = System.Drawing.Color.Black
        Me.tOBSER.Location = New System.Drawing.Point(156, 218)
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(505, 21)
        Me.tOBSER.TabIndex = 9
        Me.C1ThemeController1.SetTheme(Me.tOBSER, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(62, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 185
        Me.Label8.Text = "Observaciones"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'tKM_ACTUAL
        '
        Me.tKM_ACTUAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKM_ACTUAL.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tKM_ACTUAL.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM_ACTUAL.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tKM_ACTUAL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tKM_ACTUAL.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM_ACTUAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tKM_ACTUAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKM_ACTUAL.Location = New System.Drawing.Point(156, 139)
        Me.tKM_ACTUAL.Name = "tKM_ACTUAL"
        Me.tKM_ACTUAL.Size = New System.Drawing.Size(134, 19)
        Me.tKM_ACTUAL.TabIndex = 3
        Me.tKM_ACTUAL.Tag = Nothing
        Me.tKM_ACTUAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tKM_ACTUAL, "Office2010Blue")
        Me.tKM_ACTUAL.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tKM_ACTUAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tKM_PROX_SERVICIO
        '
        Me.tKM_PROX_SERVICIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKM_PROX_SERVICIO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tKM_PROX_SERVICIO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM_PROX_SERVICIO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tKM_PROX_SERVICIO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tKM_PROX_SERVICIO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM_PROX_SERVICIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tKM_PROX_SERVICIO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKM_PROX_SERVICIO.Location = New System.Drawing.Point(507, 142)
        Me.tKM_PROX_SERVICIO.Name = "tKM_PROX_SERVICIO"
        Me.tKM_PROX_SERVICIO.Size = New System.Drawing.Size(134, 19)
        Me.tKM_PROX_SERVICIO.TabIndex = 6
        Me.tKM_PROX_SERVICIO.Tag = Nothing
        Me.tKM_PROX_SERVICIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tKM_PROX_SERVICIO, "Office2010Blue")
        Me.tKM_PROX_SERVICIO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tKM_PROX_SERVICIO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(156, 114)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(166, 19)
        Me.F2.TabIndex = 2
        Me.F2.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F2, "Office2010Blue")
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnUnidad
        '
        Me.btnUnidad.AutoSize = True
        Me.btnUnidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUnidad.BackColor = System.Drawing.Color.Transparent
        Me.btnUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnUnidad.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnUnidad.Location = New System.Drawing.Point(226, 164)
        Me.btnUnidad.Name = "btnUnidad"
        Me.btnUnidad.Size = New System.Drawing.Size(24, 23)
        Me.btnUnidad.TabIndex = 186
        Me.C1ThemeController1.SetTheme(Me.btnUnidad, "Office2010Blue")
        Me.btnUnidad.UseVisualStyleBackColor = True
        '
        'LtStatus
        '
        Me.LtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtStatus.Location = New System.Drawing.Point(516, 55)
        Me.LtStatus.Name = "LtStatus"
        Me.LtStatus.Size = New System.Drawing.Size(134, 24)
        Me.LtStatus.TabIndex = 189
        Me.LtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtStatus, "Office2010Blue")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(464, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 15)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Estatus"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'F3
        '
        Me.F3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F3.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F3.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F3.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F3.Enabled = False
        Me.F3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F3.Location = New System.Drawing.Point(507, 92)
        Me.F3.Name = "F3"
        Me.F3.Size = New System.Drawing.Size(166, 19)
        Me.F3.TabIndex = 4
        Me.F3.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F3, "Office2010Blue")
        Me.F3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(353, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 15)
        Me.Label10.TabIndex = 191
        Me.Label10.Text = "Fecha de incio del servicio"
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'F4
        '
        Me.F4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F4.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F4.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F4.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F4.Enabled = False
        Me.F4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F4.Location = New System.Drawing.Point(507, 117)
        Me.F4.Name = "F4"
        Me.F4.Size = New System.Drawing.Size(166, 19)
        Me.F4.TabIndex = 5
        Me.F4.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F4, "Office2010Blue")
        Me.F4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(379, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 15)
        Me.Label11.TabIndex = 193
        Me.Label11.Text = "Fecha de finalizacion"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarEdit)
        Me.MenuHolder.Commands.Add(Me.BarFinalizado)
        Me.MenuHolder.Commands.Add(Me.BarCancelar)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        Me.MenuHolder.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.ToolTipText = "Grabar "
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Edit"
        '
        'BarFinalizado
        '
        Me.BarFinalizado.Image = Global.SGT_Transport.My.Resources.Resources.images
        Me.BarFinalizado.Name = "BarFinalizado"
        Me.BarFinalizado.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.BarFinalizado.ShortcutText = ""
        Me.BarFinalizado.Text = "Finalizar servicio"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.C1
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutText = ""
        Me.BarCancelar.Text = "Cancelar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarSalir
        '
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 95
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkFinalizarservicio, Me.LkCancelar, Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(833, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "Office2010Blue")
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkFinalizarservicio
        '
        Me.LkFinalizarservicio.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkFinalizarservicio.Command = Me.BarFinalizado
        Me.LkFinalizarservicio.DefaultItem = True
        Me.LkFinalizarservicio.NewColumn = True
        Me.LkFinalizarservicio.SortOrder = 1
        Me.LkFinalizarservicio.Text = "Finalizar servicio"
        '
        'LkCancelar
        '
        Me.LkCancelar.Command = Me.BarCancelar
        Me.LkCancelar.Delimiter = True
        Me.LkCancelar.SortOrder = 2
        Me.LkCancelar.Text = "Cancelar"
        Me.LkCancelar.ToolTipText = ""
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 3
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.Fg.Location = New System.Drawing.Point(0, 256)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(816, 221)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'tBotonMagico
        '
        Me.tBotonMagico.AcceptsReturn = True
        Me.tBotonMagico.AcceptsTab = True
        Me.tBotonMagico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBotonMagico.ForeColor = System.Drawing.Color.Black
        Me.tBotonMagico.Location = New System.Drawing.Point(861, 63)
        Me.tBotonMagico.Name = "tBotonMagico"
        Me.tBotonMagico.Size = New System.Drawing.Size(68, 21)
        Me.tBotonMagico.TabIndex = 198
        Me.C1ThemeController1.SetTheme(Me.tBotonMagico, "Office2010Blue")
        '
        'btnAltaProducto
        '
        Me.btnAltaProducto.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaProducto.Location = New System.Drawing.Point(735, 220)
        Me.btnAltaProducto.Name = "btnAltaProducto"
        Me.btnAltaProducto.Size = New System.Drawing.Size(27, 30)
        Me.btnAltaProducto.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.btnAltaProducto, "Office2010Blue")
        Me.btnAltaProducto.UseVisualStyleBackColor = True
        Me.btnAltaProducto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliProd
        '
        Me.btnEliProd.Image = CType(resources.GetObject("btnEliProd.Image"), System.Drawing.Image)
        Me.btnEliProd.Location = New System.Drawing.Point(781, 223)
        Me.btnEliProd.Name = "btnEliProd"
        Me.btnEliProd.Size = New System.Drawing.Size(35, 27)
        Me.btnEliProd.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.btnEliProd, "Office2010Blue")
        Me.btnEliProd.UseVisualStyleBackColor = True
        Me.btnEliProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnActManto
        '
        Me.BtnActManto.AutoSize = True
        Me.BtnActManto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnActManto.BackColor = System.Drawing.Color.Transparent
        Me.BtnActManto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnActManto.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.BtnActManto.Location = New System.Drawing.Point(226, 192)
        Me.BtnActManto.Name = "BtnActManto"
        Me.BtnActManto.Size = New System.Drawing.Size(24, 23)
        Me.BtnActManto.TabIndex = 206
        Me.C1ThemeController1.SetTheme(Me.BtnActManto, "Office2010Blue")
        Me.BtnActManto.UseVisualStyleBackColor = True
        '
        'LtActMante
        '
        Me.LtActMante.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtActMante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtActMante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtActMante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtActMante.Location = New System.Drawing.Point(253, 194)
        Me.LtActMante.Name = "LtActMante"
        Me.LtActMante.Size = New System.Drawing.Size(232, 20)
        Me.LtActMante.TabIndex = 205
        Me.C1ThemeController1.SetTheme(Me.LtActMante, "Office2010Blue")
        '
        'tCVE_SER
        '
        Me.tCVE_SER.AcceptsReturn = True
        Me.tCVE_SER.AcceptsTab = True
        Me.tCVE_SER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_SER.ForeColor = System.Drawing.Color.Black
        Me.tCVE_SER.Location = New System.Drawing.Point(156, 193)
        Me.tCVE_SER.Name = "tCVE_SER"
        Me.tCVE_SER.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_SER.TabIndex = 8
        Me.C1ThemeController1.SetTheme(Me.tCVE_SER, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 15)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Actividad mantenimiento"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "7ee1eacdc56d49cc9c67772a8e0b07ee"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'frmProgServiciosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 510)
        Me.Controls.Add(Me.BtnActManto)
        Me.Controls.Add(Me.LtActMante)
        Me.Controls.Add(Me.tCVE_SER)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnAltaProducto)
        Me.Controls.Add(Me.btnEliProd)
        Me.Controls.Add(Me.tBotonMagico)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.F4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.F3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LtStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.tKM_PROX_SERVICIO)
        Me.Controls.Add(Me.tKM_ACTUAL)
        Me.Controls.Add(Me.btnUnidad)
        Me.Controls.Add(Me.tOBSER)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tCVE_PROG)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.Nombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgServiciosAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación de Servicios"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM_ACTUAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM_PROX_SERVICIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tCVE_PROG As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label14 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtUnidad As Label
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnUnidad As Button
    Friend WithEvents tKM_ACTUAL As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tKM_PROX_SERVICIO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtStatus As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents F3 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents F4 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents BarCancelar As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkFinalizarservicio As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancelar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents BarFinalizado As C1.Win.C1Command.C1Command
    Friend WithEvents tBotonMagico As TextBox
    Friend WithEvents btnAltaProducto As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliProd As C1.Win.C1Input.C1Button
    Friend WithEvents BtnActManto As Button
    Friend WithEvents LtActMante As Label
    Friend WithEvents tCVE_SER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
