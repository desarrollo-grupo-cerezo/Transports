<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEsquemasAE
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEsquemasAE))
        Me.TCVE_ESQIMPU = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.TDESCRIPESQ = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TIMPUESTO2 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TIMPUESTO1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TIMPUESTO4 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TIMPUESTO3 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboIMP2APLICA = New C1.Win.C1Input.C1ComboBox()
        Me.CboIMP1APLICA = New C1.Win.C1Input.C1ComboBox()
        Me.CboIMP4APLICA = New C1.Win.C1Input.C1ComboBox()
        Me.CboIMP3APLICA = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txCtaVtas1 = New System.Windows.Forms.TextBox()
        Me.txCtaComp1 = New System.Windows.Forms.TextBox()
        Me.txCtaComp2 = New System.Windows.Forms.TextBox()
        Me.txCtaVtas2 = New System.Windows.Forms.TextBox()
        Me.txCtaComp3 = New System.Windows.Forms.TextBox()
        Me.txCtaVtas3 = New System.Windows.Forms.TextBox()
        Me.txCtaComp4 = New System.Windows.Forms.TextBox()
        Me.txCtaVtas4 = New System.Windows.Forms.TextBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPUESTO2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPUESTO1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPUESTO4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPUESTO3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboIMP2APLICA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboIMP1APLICA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboIMP4APLICA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboIMP3APLICA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCVE_ESQIMPU
        '
        Me.TCVE_ESQIMPU.AcceptsReturn = True
        Me.TCVE_ESQIMPU.AcceptsTab = True
        Me.TCVE_ESQIMPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ESQIMPU.Location = New System.Drawing.Point(152, 87)
        Me.TCVE_ESQIMPU.Name = "TCVE_ESQIMPU"
        Me.TCVE_ESQIMPU.Size = New System.Drawing.Size(68, 22)
        Me.TCVE_ESQIMPU.TabIndex = 0
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(71, 122)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(79, 16)
        Me.Nombre.TabIndex = 119
        Me.Nombre.Text = "Descripción"
        '
        'TDESCRIPESQ
        '
        Me.TDESCRIPESQ.AcceptsReturn = True
        Me.TDESCRIPESQ.AcceptsTab = True
        Me.TDESCRIPESQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCRIPESQ.Location = New System.Drawing.Point(152, 117)
        Me.TDESCRIPESQ.Name = "TDESCRIPESQ"
        Me.TDESCRIPESQ.Size = New System.Drawing.Size(289, 22)
        Me.TDESCRIPESQ.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(17, 90)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(133, 16)
        Me.Label27.TabIndex = 120
        Me.Label27.Text = "Número de concepto"
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
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
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(821, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TIMPUESTO2
        '
        Me.TIMPUESTO2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO2.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TIMPUESTO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPUESTO2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO2.CustomFormat = "###,##0.000000"
        Me.TIMPUESTO2.DisplayFormat.CustomFormat = "###,###,##0.0000"
        Me.TIMPUESTO2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO2.EditFormat.CustomFormat = "###,###,##0.00000000"
        Me.TIMPUESTO2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPUESTO2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPUESTO2.InterceptArrowKeys = False
        Me.TIMPUESTO2.Location = New System.Drawing.Point(152, 215)
        Me.TIMPUESTO2.Name = "TIMPUESTO2"
        Me.TIMPUESTO2.Size = New System.Drawing.Size(92, 20)
        Me.TIMPUESTO2.TabIndex = 6
        Me.TIMPUESTO2.Tag = Nothing
        Me.TIMPUESTO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPUESTO2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPUESTO2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(121, 212)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(29, 16)
        Me.Label51.TabIndex = 338
        Me.Label51.Text = "ISR"
        '
        'TIMPUESTO1
        '
        Me.TIMPUESTO1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TIMPUESTO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPUESTO1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO1.CustomFormat = "###,##0.000000"
        Me.TIMPUESTO1.DisplayFormat.CustomFormat = "###,###,##0.0000"
        Me.TIMPUESTO1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO1.EditFormat.CustomFormat = "###,###,##0.00000000"
        Me.TIMPUESTO1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPUESTO1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPUESTO1.InterceptArrowKeys = False
        Me.TIMPUESTO1.Location = New System.Drawing.Point(152, 181)
        Me.TIMPUESTO1.Name = "TIMPUESTO1"
        Me.TIMPUESTO1.Size = New System.Drawing.Size(92, 20)
        Me.TIMPUESTO1.TabIndex = 2
        Me.TIMPUESTO1.Tag = Nothing
        Me.TIMPUESTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPUESTO1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPUESTO1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(101, 184)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 16)
        Me.Label15.TabIndex = 337
        Me.Label15.Text = "I.E.P.S."
        '
        'TIMPUESTO4
        '
        Me.TIMPUESTO4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO4.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TIMPUESTO4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPUESTO4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO4.CustomFormat = "###,##0.000000"
        Me.TIMPUESTO4.DisplayFormat.CustomFormat = "###,###,##0.0000"
        Me.TIMPUESTO4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO4.EditFormat.CustomFormat = "###,###,##0.00000000"
        Me.TIMPUESTO4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPUESTO4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPUESTO4.InterceptArrowKeys = False
        Me.TIMPUESTO4.Location = New System.Drawing.Point(152, 283)
        Me.TIMPUESTO4.Name = "TIMPUESTO4"
        Me.TIMPUESTO4.Size = New System.Drawing.Size(92, 20)
        Me.TIMPUESTO4.TabIndex = 14
        Me.TIMPUESTO4.Tag = Nothing
        Me.TIMPUESTO4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPUESTO4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPUESTO4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 342
        Me.Label1.Text = "IVA"
        '
        'TIMPUESTO3
        '
        Me.TIMPUESTO3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO3.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TIMPUESTO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPUESTO3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPUESTO3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPUESTO3.CustomFormat = "###,##0.000000"
        Me.TIMPUESTO3.DisplayFormat.CustomFormat = "###,###,##0.0000"
        Me.TIMPUESTO3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO3.EditFormat.CustomFormat = "###,###,##0.00000000"
        Me.TIMPUESTO3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPUESTO3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPUESTO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPUESTO3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPUESTO3.InterceptArrowKeys = False
        Me.TIMPUESTO3.Location = New System.Drawing.Point(152, 249)
        Me.TIMPUESTO3.Name = "TIMPUESTO3"
        Me.TIMPUESTO3.Size = New System.Drawing.Size(92, 20)
        Me.TIMPUESTO3.TabIndex = 10
        Me.TIMPUESTO3.Tag = Nothing
        Me.TIMPUESTO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPUESTO3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPUESTO3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(88, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "RET. IVA"
        '
        'CboIMP2APLICA
        '
        Me.CboIMP2APLICA.AllowSpinLoop = False
        Me.CboIMP2APLICA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboIMP2APLICA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboIMP2APLICA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CboIMP2APLICA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboIMP2APLICA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIMP2APLICA.GapHeight = 0
        Me.CboIMP2APLICA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboIMP2APLICA.ItemsDisplayMember = ""
        Me.CboIMP2APLICA.ItemsValueMember = ""
        Me.CboIMP2APLICA.Location = New System.Drawing.Point(284, 215)
        Me.CboIMP2APLICA.Name = "CboIMP2APLICA"
        Me.CboIMP2APLICA.Size = New System.Drawing.Size(133, 20)
        Me.CboIMP2APLICA.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboIMP2APLICA.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboIMP2APLICA.TabIndex = 7
        Me.CboIMP2APLICA.Tag = Nothing
        Me.CboIMP2APLICA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboIMP1APLICA
        '
        Me.CboIMP1APLICA.AllowSpinLoop = False
        Me.CboIMP1APLICA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboIMP1APLICA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboIMP1APLICA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CboIMP1APLICA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboIMP1APLICA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIMP1APLICA.GapHeight = 0
        Me.CboIMP1APLICA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboIMP1APLICA.ItemsDisplayMember = ""
        Me.CboIMP1APLICA.ItemsValueMember = ""
        Me.CboIMP1APLICA.Location = New System.Drawing.Point(284, 181)
        Me.CboIMP1APLICA.Name = "CboIMP1APLICA"
        Me.CboIMP1APLICA.Size = New System.Drawing.Size(133, 20)
        Me.CboIMP1APLICA.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboIMP1APLICA.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboIMP1APLICA.TabIndex = 3
        Me.CboIMP1APLICA.Tag = Nothing
        Me.CboIMP1APLICA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboIMP4APLICA
        '
        Me.CboIMP4APLICA.AllowSpinLoop = False
        Me.CboIMP4APLICA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboIMP4APLICA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboIMP4APLICA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CboIMP4APLICA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboIMP4APLICA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIMP4APLICA.GapHeight = 0
        Me.CboIMP4APLICA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboIMP4APLICA.ItemsDisplayMember = ""
        Me.CboIMP4APLICA.ItemsValueMember = ""
        Me.CboIMP4APLICA.Location = New System.Drawing.Point(284, 283)
        Me.CboIMP4APLICA.Name = "CboIMP4APLICA"
        Me.CboIMP4APLICA.Size = New System.Drawing.Size(133, 20)
        Me.CboIMP4APLICA.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboIMP4APLICA.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboIMP4APLICA.TabIndex = 15
        Me.CboIMP4APLICA.Tag = Nothing
        Me.CboIMP4APLICA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboIMP3APLICA
        '
        Me.CboIMP3APLICA.AllowSpinLoop = False
        Me.CboIMP3APLICA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboIMP3APLICA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboIMP3APLICA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CboIMP3APLICA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboIMP3APLICA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIMP3APLICA.GapHeight = 0
        Me.CboIMP3APLICA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboIMP3APLICA.ItemsDisplayMember = ""
        Me.CboIMP3APLICA.ItemsValueMember = ""
        Me.CboIMP3APLICA.Location = New System.Drawing.Point(284, 249)
        Me.CboIMP3APLICA.Name = "CboIMP3APLICA"
        Me.CboIMP3APLICA.Size = New System.Drawing.Size(133, 20)
        Me.CboIMP3APLICA.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboIMP3APLICA.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboIMP3APLICA.TabIndex = 11
        Me.CboIMP3APLICA.Tag = Nothing
        Me.CboIMP3APLICA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 16)
        Me.Label3.TabIndex = 378
        Me.Label3.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(245, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(245, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 16)
        Me.Label5.TabIndex = 376
        Me.Label5.Text = "%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(245, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 16)
        Me.Label6.TabIndex = 375
        Me.Label6.Text = "%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(172, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 379
        Me.Label7.Text = "Porcentaje"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(309, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 16)
        Me.Label8.TabIndex = 380
        Me.Label8.Text = "Aplica sobre"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(457, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 16)
        Me.Label9.TabIndex = 382
        Me.Label9.Text = "Cuenta Conrable Vtas."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(634, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 16)
        Me.Label10.TabIndex = 383
        Me.Label10.Text = "Cuenta Contable Comp."
        '
        'txCtaVtas1
        '
        Me.txCtaVtas1.AcceptsReturn = True
        Me.txCtaVtas1.AcceptsTab = True
        Me.txCtaVtas1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaVtas1.Location = New System.Drawing.Point(449, 180)
        Me.txCtaVtas1.MaxLength = 28
        Me.txCtaVtas1.Name = "txCtaVtas1"
        Me.txCtaVtas1.Size = New System.Drawing.Size(157, 22)
        Me.txCtaVtas1.TabIndex = 4
        '
        'txCtaComp1
        '
        Me.txCtaComp1.AcceptsReturn = True
        Me.txCtaComp1.AcceptsTab = True
        Me.txCtaComp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaComp1.Location = New System.Drawing.Point(630, 180)
        Me.txCtaComp1.MaxLength = 28
        Me.txCtaComp1.Name = "txCtaComp1"
        Me.txCtaComp1.Size = New System.Drawing.Size(157, 22)
        Me.txCtaComp1.TabIndex = 5
        '
        'txCtaComp2
        '
        Me.txCtaComp2.AcceptsReturn = True
        Me.txCtaComp2.AcceptsTab = True
        Me.txCtaComp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaComp2.Location = New System.Drawing.Point(630, 214)
        Me.txCtaComp2.MaxLength = 28
        Me.txCtaComp2.Name = "txCtaComp2"
        Me.txCtaComp2.Size = New System.Drawing.Size(157, 22)
        Me.txCtaComp2.TabIndex = 9
        '
        'txCtaVtas2
        '
        Me.txCtaVtas2.AcceptsReturn = True
        Me.txCtaVtas2.AcceptsTab = True
        Me.txCtaVtas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaVtas2.Location = New System.Drawing.Point(449, 214)
        Me.txCtaVtas2.MaxLength = 28
        Me.txCtaVtas2.Name = "txCtaVtas2"
        Me.txCtaVtas2.Size = New System.Drawing.Size(157, 22)
        Me.txCtaVtas2.TabIndex = 8
        '
        'txCtaComp3
        '
        Me.txCtaComp3.AcceptsReturn = True
        Me.txCtaComp3.AcceptsTab = True
        Me.txCtaComp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaComp3.Location = New System.Drawing.Point(630, 248)
        Me.txCtaComp3.MaxLength = 28
        Me.txCtaComp3.Name = "txCtaComp3"
        Me.txCtaComp3.Size = New System.Drawing.Size(157, 22)
        Me.txCtaComp3.TabIndex = 13
        '
        'txCtaVtas3
        '
        Me.txCtaVtas3.AcceptsReturn = True
        Me.txCtaVtas3.AcceptsTab = True
        Me.txCtaVtas3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaVtas3.Location = New System.Drawing.Point(449, 249)
        Me.txCtaVtas3.MaxLength = 28
        Me.txCtaVtas3.Name = "txCtaVtas3"
        Me.txCtaVtas3.Size = New System.Drawing.Size(157, 22)
        Me.txCtaVtas3.TabIndex = 12
        '
        'txCtaComp4
        '
        Me.txCtaComp4.AcceptsReturn = True
        Me.txCtaComp4.AcceptsTab = True
        Me.txCtaComp4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaComp4.Location = New System.Drawing.Point(630, 282)
        Me.txCtaComp4.MaxLength = 28
        Me.txCtaComp4.Name = "txCtaComp4"
        Me.txCtaComp4.Size = New System.Drawing.Size(157, 22)
        Me.txCtaComp4.TabIndex = 17
        '
        'txCtaVtas4
        '
        Me.txCtaVtas4.AcceptsReturn = True
        Me.txCtaVtas4.AcceptsTab = True
        Me.txCtaVtas4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaVtas4.Location = New System.Drawing.Point(449, 282)
        Me.txCtaVtas4.MaxLength = 28
        Me.txCtaVtas4.Name = "txCtaVtas4"
        Me.txCtaVtas4.Size = New System.Drawing.Size(157, 22)
        Me.txCtaVtas4.TabIndex = 16
        '
        'FrmEsquemasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 345)
        Me.Controls.Add(Me.txCtaComp4)
        Me.Controls.Add(Me.txCtaVtas4)
        Me.Controls.Add(Me.txCtaComp3)
        Me.Controls.Add(Me.txCtaVtas3)
        Me.Controls.Add(Me.txCtaComp2)
        Me.Controls.Add(Me.txCtaVtas2)
        Me.Controls.Add(Me.txCtaComp1)
        Me.Controls.Add(Me.txCtaVtas1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboIMP2APLICA)
        Me.Controls.Add(Me.CboIMP1APLICA)
        Me.Controls.Add(Me.CboIMP4APLICA)
        Me.Controls.Add(Me.CboIMP3APLICA)
        Me.Controls.Add(Me.TIMPUESTO4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TIMPUESTO3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TIMPUESTO2)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.TIMPUESTO1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.TCVE_ESQIMPU)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.TDESCRIPESQ)
        Me.Controls.Add(Me.Label27)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEsquemasAE"
        Me.ShowInTaskbar = False
        Me.Text = "Impuestos"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPUESTO2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPUESTO1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPUESTO4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPUESTO3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboIMP2APLICA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboIMP1APLICA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboIMP4APLICA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboIMP3APLICA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TCVE_ESQIMPU As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents TDESCRIPESQ As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TIMPUESTO2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label51 As Label
    Friend WithEvents TIMPUESTO1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents TIMPUESTO4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents TIMPUESTO3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents CboIMP2APLICA As C1.Win.C1Input.C1ComboBox
    Friend WithEvents CboIMP1APLICA As C1.Win.C1Input.C1ComboBox
    Friend WithEvents CboIMP4APLICA As C1.Win.C1Input.C1ComboBox
    Friend WithEvents CboIMP3APLICA As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txCtaComp4 As TextBox
    Friend WithEvents txCtaVtas4 As TextBox
    Friend WithEvents txCtaComp3 As TextBox
    Friend WithEvents txCtaVtas3 As TextBox
    Friend WithEvents txCtaComp2 As TextBox
    Friend WithEvents txCtaVtas2 As TextBox
    Friend WithEvents txCtaComp1 As TextBox
    Friend WithEvents txCtaVtas1 As TextBox
End Class
