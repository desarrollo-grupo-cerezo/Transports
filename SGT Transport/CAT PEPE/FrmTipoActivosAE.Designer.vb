<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoActivosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoActivosAE))
        Me.TCLAVE = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TDEPPROY = New C1.Win.C1Input.C1NumericEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TMAXDED = New C1.Win.C1Input.C1NumericEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TDEDIMED = New C1.Win.C1Input.C1NumericEdit()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TDEDNORMAL = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.RadLineaReacta = New System.Windows.Forms.RadioButton()
        Me.RadDobleSaldo = New System.Windows.Forms.RadioButton()
        Me.RadSuma = New System.Windows.Forms.RadioButton()
        Me.TCTAPERGAN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCTADEPRE = New System.Windows.Forms.TextBox()
        Me.TCTAGASTOS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCTAAACTV = New System.Windows.Forms.TextBox()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.TDEPPROY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMAXDED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDEDIMED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDEDNORMAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCLAVE
        '
        Me.TCLAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.Location = New System.Drawing.Point(139, 68)
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(81, 24)
        Me.TCLAVE.TabIndex = 127
        Me.TCLAVE.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(53, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 17)
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "Descripcion"
        '
        'TDESCR
        '
        Me.TDESCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(139, 97)
        Me.TDESCR.MaxLength = 40
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(312, 23)
        Me.TDESCR.TabIndex = 0
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(92, 71)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(43, 17)
        Me.Label38.TabIndex = 126
        Me.Label38.Text = "Clave"
        '
        'TDEPPROY
        '
        Me.TDEPPROY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDEPPROY.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDEPPROY.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEPPROY.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEPPROY.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDEPPROY.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Percent
        Me.TDEPPROY.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEPPROY.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDEPPROY.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Percent
        Me.TDEPPROY.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEPPROY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDEPPROY.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDEPPROY.InterceptArrowKeys = False
        Me.TDEPPROY.Location = New System.Drawing.Point(605, 335)
        Me.TDEPPROY.Name = "TDEPPROY"
        Me.TDEPPROY.Size = New System.Drawing.Size(106, 21)
        Me.TDEPPROY.TabIndex = 11
        Me.TDEPPROY.Tag = Nothing
        Me.TDEPPROY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDEPPROY.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.Modal
        Me.TDEPPROY.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEPPROY.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(456, 336)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "%Deprec. proyectada"
        '
        'TMAXDED
        '
        Me.TMAXDED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TMAXDED.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TMAXDED.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMAXDED.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMAXDED.CustomFormat = "###,##0.00"
        Me.TMAXDED.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TMAXDED.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMAXDED.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMAXDED.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TMAXDED.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TMAXDED.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TMAXDED.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMAXDED.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TMAXDED.InterceptArrowKeys = False
        Me.TMAXDED.Location = New System.Drawing.Point(139, 180)
        Me.TMAXDED.Name = "TMAXDED"
        Me.TMAXDED.Size = New System.Drawing.Size(133, 21)
        Me.TMAXDED.TabIndex = 3
        Me.TMAXDED.Tag = Nothing
        Me.TMAXDED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TMAXDED.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.Modal
        Me.TMAXDED.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TMAXDED.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 17)
        Me.Label11.TabIndex = 582
        Me.Label11.Text = "Máximo deducible"
        '
        'TDEDIMED
        '
        Me.TDEDIMED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDEDIMED.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDEDIMED.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDIMED.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDIMED.CustomFormat = "###,##0.00"
        Me.TDEDIMED.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDEDIMED.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDEDIMED.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEDIMED.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDEDIMED.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDEDIMED.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEDIMED.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDEDIMED.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDEDIMED.InterceptArrowKeys = False
        Me.TDEDIMED.Location = New System.Drawing.Point(139, 153)
        Me.TDEDIMED.Name = "TDEDIMED"
        Me.TDEDIMED.Size = New System.Drawing.Size(133, 21)
        Me.TDEDIMED.TabIndex = 2
        Me.TDEDIMED.Tag = Nothing
        Me.TDEDIMED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDEDIMED.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.Modal
        Me.TDEDIMED.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDIMED.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(59, 155)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(76, 17)
        Me.Label51.TabIndex = 579
        Me.Label51.Text = "Tasa fiscal"
        '
        'TDEDNORMAL
        '
        Me.TDEDNORMAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDEDNORMAL.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDEDNORMAL.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDNORMAL.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDNORMAL.CustomFormat = "###,##0.00"
        Me.TDEDNORMAL.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDEDNORMAL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDEDNORMAL.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEDNORMAL.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDEDNORMAL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDEDNORMAL.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDEDNORMAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDEDNORMAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDEDNORMAL.InterceptArrowKeys = False
        Me.TDEDNORMAL.Location = New System.Drawing.Point(139, 126)
        Me.TDEDNORMAL.Name = "TDEDNORMAL"
        Me.TDEDNORMAL.Size = New System.Drawing.Size(133, 21)
        Me.TDEDNORMAL.TabIndex = 1
        Me.TDEDNORMAL.Tag = Nothing
        Me.TDEDNORMAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDEDNORMAL.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.Modal
        Me.TDEDNORMAL.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDEDNORMAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(37, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 17)
        Me.Label15.TabIndex = 578
        Me.Label15.Text = "Tasa contable"
        '
        'RadLineaReacta
        '
        Me.RadLineaReacta.AutoSize = True
        Me.RadLineaReacta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLineaReacta.Location = New System.Drawing.Point(456, 252)
        Me.RadLineaReacta.Name = "RadLineaReacta"
        Me.RadLineaReacta.Size = New System.Drawing.Size(97, 21)
        Me.RadLineaReacta.TabIndex = 8
        Me.RadLineaReacta.TabStop = True
        Me.RadLineaReacta.Text = "Linea recta"
        Me.RadLineaReacta.UseVisualStyleBackColor = True
        '
        'RadDobleSaldo
        '
        Me.RadDobleSaldo.AutoSize = True
        Me.RadDobleSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadDobleSaldo.Location = New System.Drawing.Point(456, 280)
        Me.RadDobleSaldo.Name = "RadDobleSaldo"
        Me.RadDobleSaldo.Size = New System.Drawing.Size(170, 21)
        Me.RadDobleSaldo.TabIndex = 9
        Me.RadDobleSaldo.TabStop = True
        Me.RadDobleSaldo.Text = "Doble saldo declinante"
        Me.RadDobleSaldo.UseVisualStyleBackColor = True
        '
        'RadSuma
        '
        Me.RadSuma.AutoSize = True
        Me.RadSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSuma.Location = New System.Drawing.Point(456, 308)
        Me.RadSuma.Name = "RadSuma"
        Me.RadSuma.Size = New System.Drawing.Size(162, 21)
        Me.RadSuma.TabIndex = 10
        Me.RadSuma.TabStop = True
        Me.RadSuma.Text = "Suma de años dígitos"
        Me.RadSuma.UseVisualStyleBackColor = True
        '
        'TCTAPERGAN
        '
        Me.TCTAPERGAN.BackColor = System.Drawing.Color.White
        Me.TCTAPERGAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTAPERGAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTAPERGAN.Location = New System.Drawing.Point(167, 331)
        Me.TCTAPERGAN.MaxLength = 30
        Me.TCTAPERGAN.Name = "TCTAPERGAN"
        Me.TCTAPERGAN.Size = New System.Drawing.Size(268, 23)
        Me.TCTAPERGAN.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 17)
        Me.Label1.TabIndex = 594
        Me.Label1.Text = "Baja o venta de activos"
        '
        'TCTADEPRE
        '
        Me.TCTADEPRE.BackColor = System.Drawing.Color.White
        Me.TCTADEPRE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTADEPRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTADEPRE.Location = New System.Drawing.Point(167, 273)
        Me.TCTADEPRE.MaxLength = 30
        Me.TCTADEPRE.Name = "TCTADEPRE"
        Me.TCTADEPRE.Size = New System.Drawing.Size(268, 23)
        Me.TCTADEPRE.TabIndex = 5
        '
        'TCTAGASTOS
        '
        Me.TCTAGASTOS.BackColor = System.Drawing.Color.White
        Me.TCTAGASTOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTAGASTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTAGASTOS.Location = New System.Drawing.Point(167, 302)
        Me.TCTAGASTOS.MaxLength = 30
        Me.TCTAGASTOS.Name = "TCTAGASTOS"
        Me.TCTAGASTOS.Size = New System.Drawing.Size(268, 23)
        Me.TCTAGASTOS.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 17)
        Me.Label2.TabIndex = 591
        Me.Label2.Text = "Depreciación del activo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(23, 305)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(138, 17)
        Me.Label14.TabIndex = 593
        Me.Label14.Text = "Gastos depreciación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 17)
        Me.Label3.TabIndex = 592
        Me.Label3.Text = "Cuenta del activo"
        '
        'TCTAAACTV
        '
        Me.TCTAAACTV.BackColor = System.Drawing.Color.White
        Me.TCTAAACTV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTAAACTV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTAAACTV.Location = New System.Drawing.Point(167, 244)
        Me.TCTAAACTV.MaxLength = 30
        Me.TCTAAACTV.Name = "TCTAAACTV"
        Me.TCTAAACTV.Size = New System.Drawing.Size(268, 23)
        Me.TCTAAACTV.TabIndex = 4
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(737, 43)
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
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(233, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 17)
        Me.Label4.TabIndex = 595
        Me.Label4.Text = "Cuentas contables"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(453, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 17)
        Me.Label5.TabIndex = 596
        Me.Label5.Text = "Metodo de depreciación"
        '
        'FrmTipoActivosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 382)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.TCTAPERGAN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCTADEPRE)
        Me.Controls.Add(Me.TCTAGASTOS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCTAAACTV)
        Me.Controls.Add(Me.RadSuma)
        Me.Controls.Add(Me.RadDobleSaldo)
        Me.Controls.Add(Me.RadLineaReacta)
        Me.Controls.Add(Me.TDEPPROY)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TMAXDED)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TDEDIMED)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.TDEDNORMAL)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TCLAVE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.Label38)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTipoActivosAE"
        Me.Text = "Activo"
        CType(Me.TDEPPROY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMAXDED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDEDIMED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDEDNORMAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCLAVE As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents TDEPPROY As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents TMAXDED As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents TDEDIMED As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label51 As Label
    Friend WithEvents TDEDNORMAL As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents RadLineaReacta As RadioButton
    Friend WithEvents RadDobleSaldo As RadioButton
    Friend WithEvents RadSuma As RadioButton
    Friend WithEvents TCTAPERGAN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TCTADEPRE As TextBox
    Friend WithEvents TCTAGASTOS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TCTAAACTV As TextBox
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
