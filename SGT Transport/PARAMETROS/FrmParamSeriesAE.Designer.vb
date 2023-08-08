<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParamSeriesAE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParamSeriesAE))
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.TSERIE = New System.Windows.Forms.TextBox()
        Me.TFOLIOINICIAL = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TLONGITUD = New C1.Win.C1Input.C1NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFtoEmision = New System.Windows.Forms.Button()
        Me.TFTOEMISION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnFtoEmisionCFDI = New System.Windows.Forms.Button()
        Me.TFTOEMISION_CFDI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboMascara = New C1.Win.C1Input.C1ComboBox()
        Me.RadDigital = New System.Windows.Forms.RadioButton()
        Me.RadImpreso = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.BtnDisenador1 = New C1.Win.C1Input.C1Button()
        Me.BtnDisenador2 = New C1.Win.C1Input.C1Button()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFOLIOINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLONGITUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMascara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDisenador1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDisenador2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(882, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Commands.Add(Me.BarGrabar)
        Me.C1CommandHolder1.Commands.Add(Me.BarSalir)
        Me.C1CommandHolder1.Owner = Me
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(144, 70)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(41, 15)
        Me.Lt6.TabIndex = 365
        Me.Lt6.Text = "Serie"
        '
        'TSERIE
        '
        Me.TSERIE.AcceptsReturn = True
        Me.TSERIE.AcceptsTab = True
        Me.TSERIE.BackColor = System.Drawing.Color.White
        Me.TSERIE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TSERIE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TSERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSERIE.ForeColor = System.Drawing.Color.Black
        Me.TSERIE.Location = New System.Drawing.Point(188, 68)
        Me.TSERIE.MaxLength = 10
        Me.TSERIE.Name = "TSERIE"
        Me.TSERIE.Size = New System.Drawing.Size(70, 21)
        Me.TSERIE.TabIndex = 0
        Me.TSERIE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TFOLIOINICIAL
        '
        Me.TFOLIOINICIAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TFOLIOINICIAL.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TFOLIOINICIAL.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFOLIOINICIAL.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFOLIOINICIAL.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFOLIOINICIAL.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TFOLIOINICIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFOLIOINICIAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TFOLIOINICIAL.InterceptArrowKeys = False
        Me.TFOLIOINICIAL.Location = New System.Drawing.Point(188, 148)
        Me.TFOLIOINICIAL.Name = "TFOLIOINICIAL"
        Me.TFOLIOINICIAL.Size = New System.Drawing.Size(85, 19)
        Me.TFOLIOINICIAL.TabIndex = 3
        Me.TFOLIOINICIAL.Tag = Nothing
        Me.TFOLIOINICIAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TFOLIOINICIAL.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TFOLIOINICIAL.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TFOLIOINICIAL.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFOLIOINICIAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(103, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 572
        Me.Label15.Text = "Folio inicial"
        '
        'TLONGITUD
        '
        Me.TLONGITUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TLONGITUD.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TLONGITUD.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLONGITUD.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLONGITUD.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLONGITUD.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TLONGITUD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLONGITUD.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TLONGITUD.InterceptArrowKeys = False
        Me.TLONGITUD.Location = New System.Drawing.Point(600, 148)
        Me.TLONGITUD.Name = "TLONGITUD"
        Me.TLONGITUD.Size = New System.Drawing.Size(46, 19)
        Me.TLONGITUD.TabIndex = 5
        Me.TLONGITUD.Tag = Nothing
        Me.TLONGITUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TLONGITUD.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TLONGITUD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TLONGITUD.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TLONGITUD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(495, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 574
        Me.Label1.Text = "Longitud del folio"
        '
        'BtnFtoEmision
        '
        Me.BtnFtoEmision.Location = New System.Drawing.Point(788, 192)
        Me.BtnFtoEmision.Name = "BtnFtoEmision"
        Me.BtnFtoEmision.Size = New System.Drawing.Size(27, 20)
        Me.BtnFtoEmision.TabIndex = 579
        Me.BtnFtoEmision.Text = "....."
        Me.BtnFtoEmision.UseVisualStyleBackColor = True
        '
        'TFTOEMISION
        '
        Me.TFTOEMISION.AcceptsReturn = True
        Me.TFTOEMISION.AcceptsTab = True
        Me.TFTOEMISION.BackColor = System.Drawing.Color.White
        Me.TFTOEMISION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFTOEMISION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFTOEMISION.ForeColor = System.Drawing.Color.Black
        Me.TFTOEMISION.Location = New System.Drawing.Point(188, 192)
        Me.TFTOEMISION.Name = "TFTOEMISION"
        Me.TFTOEMISION.Size = New System.Drawing.Size(596, 20)
        Me.TFTOEMISION.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(70, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 15)
        Me.Label3.TabIndex = 577
        Me.Label3.Text = "Formato emisión"
        '
        'BtnFtoEmisionCFDI
        '
        Me.BtnFtoEmisionCFDI.Location = New System.Drawing.Point(788, 243)
        Me.BtnFtoEmisionCFDI.Name = "BtnFtoEmisionCFDI"
        Me.BtnFtoEmisionCFDI.Size = New System.Drawing.Size(27, 20)
        Me.BtnFtoEmisionCFDI.TabIndex = 582
        Me.BtnFtoEmisionCFDI.Text = "....."
        Me.BtnFtoEmisionCFDI.UseVisualStyleBackColor = True
        '
        'TFTOEMISION_CFDI
        '
        Me.TFTOEMISION_CFDI.AcceptsReturn = True
        Me.TFTOEMISION_CFDI.AcceptsTab = True
        Me.TFTOEMISION_CFDI.BackColor = System.Drawing.Color.White
        Me.TFTOEMISION_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFTOEMISION_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFTOEMISION_CFDI.ForeColor = System.Drawing.Color.Black
        Me.TFTOEMISION_CFDI.Location = New System.Drawing.Point(188, 243)
        Me.TFTOEMISION_CFDI.Name = "TFTOEMISION_CFDI"
        Me.TFTOEMISION_CFDI.Size = New System.Drawing.Size(596, 20)
        Me.TFTOEMISION_CFDI.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 15)
        Me.Label4.TabIndex = 580
        Me.Label4.Text = "Formato emisión CFDI 4.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(286, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 584
        Me.Label5.Text = "Alineación"
        '
        'CboMascara
        '
        Me.CboMascara.AllowSpinLoop = False
        Me.CboMascara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboMascara.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboMascara.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboMascara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMascara.GapHeight = 0
        Me.CboMascara.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboMascara.ItemsDisplayMember = ""
        Me.CboMascara.ItemsValueMember = ""
        Me.CboMascara.Location = New System.Drawing.Point(354, 148)
        Me.CboMascara.Name = "CboMascara"
        Me.CboMascara.Size = New System.Drawing.Size(127, 19)
        Me.CboMascara.TabIndex = 4
        Me.CboMascara.Tag = Nothing
        Me.CboMascara.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboMascara.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'RadDigital
        '
        Me.RadDigital.AutoSize = True
        Me.RadDigital.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadDigital.Location = New System.Drawing.Point(288, 107)
        Me.RadDigital.Name = "RadDigital"
        Me.RadDigital.Size = New System.Drawing.Size(60, 19)
        Me.RadDigital.TabIndex = 2
        Me.RadDigital.TabStop = True
        Me.RadDigital.Text = "Digital"
        Me.RadDigital.UseVisualStyleBackColor = False
        '
        'RadImpreso
        '
        Me.RadImpreso.AutoSize = True
        Me.RadImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadImpreso.Location = New System.Drawing.Point(198, 107)
        Me.RadImpreso.Name = "RadImpreso"
        Me.RadImpreso.Size = New System.Drawing.Size(70, 19)
        Me.RadImpreso.TabIndex = 1
        Me.RadImpreso.TabStop = True
        Me.RadImpreso.Text = "Impreso"
        Me.RadImpreso.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(150, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 587
        Me.Label6.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 589
        Me.Label2.Text = "Estatus"
        '
        'CboStatus
        '
        Me.CboStatus.AllowSpinLoop = False
        Me.CboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboStatus.GapHeight = 0
        Me.CboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboStatus.ItemsDisplayMember = ""
        Me.CboStatus.ItemsValueMember = ""
        Me.CboStatus.Location = New System.Drawing.Point(188, 287)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(111, 19)
        Me.CboStatus.TabIndex = 8
        Me.CboStatus.Tag = Nothing
        Me.CboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnDisenador1
        '
        Me.BtnDisenador1.FlatAppearance.BorderSize = 0
        Me.BtnDisenador1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDisenador1.Image = Global.SGT_Transport.My.Resources.Resources.diseñador24
        Me.BtnDisenador1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDisenador1.Location = New System.Drawing.Point(830, 182)
        Me.BtnDisenador1.Name = "BtnDisenador1"
        Me.BtnDisenador1.Size = New System.Drawing.Size(27, 30)
        Me.BtnDisenador1.TabIndex = 591
        Me.BtnDisenador1.Text = "|"
        Me.BtnDisenador1.UseVisualStyleBackColor = True
        Me.BtnDisenador1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnDisenador2
        '
        Me.BtnDisenador2.FlatAppearance.BorderSize = 0
        Me.BtnDisenador2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDisenador2.Image = Global.SGT_Transport.My.Resources.Resources.diseñador24
        Me.BtnDisenador2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDisenador2.Location = New System.Drawing.Point(830, 233)
        Me.BtnDisenador2.Name = "BtnDisenador2"
        Me.BtnDisenador2.Size = New System.Drawing.Size(27, 30)
        Me.BtnDisenador2.TabIndex = 592
        Me.BtnDisenador2.Text = "|"
        Me.BtnDisenador2.UseVisualStyleBackColor = True
        Me.BtnDisenador2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmParamSeriesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 326)
        Me.Controls.Add(Me.BtnDisenador2)
        Me.Controls.Add(Me.BtnDisenador1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.RadDigital)
        Me.Controls.Add(Me.RadImpreso)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboMascara)
        Me.Controls.Add(Me.BtnFtoEmisionCFDI)
        Me.Controls.Add(Me.TFTOEMISION_CFDI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnFtoEmision)
        Me.Controls.Add(Me.TFTOEMISION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TLONGITUD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TFOLIOINICIAL)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.TSERIE)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParamSeriesAE"
        Me.ShowInTaskbar = False
        Me.Text = "Serie"
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFOLIOINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLONGITUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMascara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDisenador1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDisenador2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents Lt6 As Label
    Friend WithEvents TSERIE As TextBox
    Friend WithEvents TFOLIOINICIAL As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents TLONGITUD As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFtoEmision As Button
    Friend WithEvents TFTOEMISION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnFtoEmisionCFDI As Button
    Friend WithEvents TFTOEMISION_CFDI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CboMascara As C1.Win.C1Input.C1ComboBox
    Friend WithEvents RadDigital As RadioButton
    Friend WithEvents RadImpreso As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CboStatus As C1.Win.C1Input.C1ComboBox
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents BtnDisenador2 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnDisenador1 As C1.Win.C1Input.C1Button
End Class
