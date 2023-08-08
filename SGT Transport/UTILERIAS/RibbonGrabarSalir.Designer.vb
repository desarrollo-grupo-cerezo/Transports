<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RibbonGrabarSalir
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonGrabarSalir))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCVE_PROV2 = New System.Windows.Forms.TextBox()
        Me.BtnProv2 = New C1.Win.C1Input.C1Button()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.TCVE_PROV1 = New System.Windows.Forms.TextBox()
        Me.BtnProv1 = New C1.Win.C1Input.C1Button()
        Me.ChSoloExist = New C1.Win.C1Input.C1CheckBox()
        Me.LtDescUnidad = New System.Windows.Forms.Label()
        Me.BtnUnidades = New C1.Win.C1Input.C1Button()
        Me.TCVE_UNI = New System.Windows.Forms.TextBox()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.RadNoTerminada = New System.Windows.Forms.RadioButton()
        Me.RadTerminada = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCVE_ART2 = New System.Windows.Forms.TextBox()
        Me.BtnArt2 = New C1.Win.C1Input.C1Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCVE_ART1 = New System.Windows.Forms.TextBox()
        Me.BtnArt1 = New C1.Win.C1Input.C1Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnProd2 = New C1.Win.C1Input.C1Button()
        Me.TCLIENTE2 = New System.Windows.Forms.TextBox()
        Me.TCLIENTE1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BTnCliente2 = New C1.Win.C1Input.C1Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnProd1 = New C1.Win.C1Input.C1Button()
        Me.BTnCliente1 = New C1.Win.C1Input.C1Button()
        Me.LtTanque1 = New System.Windows.Forms.Label()
        Me.BtnTanque1 = New C1.Win.C1Input.C1Button()
        Me.TCVE_TANQUE1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.LtTractor = New System.Windows.Forms.Label()
        Me.BtnTractor = New C1.Win.C1Input.C1Button()
        Me.TCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChSoloExist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTnCliente2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTnCliente1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTanque1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(140, 194)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(148, 16)
        Me.Lt5.TabIndex = 368
        Me.Lt5.Text = "Rango de proveedores"
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(207, 222)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(18, 16)
        Me.Lt7.TabIndex = 366
        Me.Lt7.Text = "al"
        '
        'TCVE_PROV2
        '
        Me.TCVE_PROV2.AcceptsReturn = True
        Me.TCVE_PROV2.AcceptsTab = True
        Me.TCVE_PROV2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_PROV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV2.Location = New System.Drawing.Point(234, 218)
        Me.TCVE_PROV2.MaxLength = 10
        Me.TCVE_PROV2.Name = "TCVE_PROV2"
        Me.TCVE_PROV2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_PROV2.TabIndex = 365
        '
        'BtnProv2
        '
        Me.BtnProv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProv2.Image = CType(resources.GetObject("BtnProv2.Image"), System.Drawing.Image)
        Me.BtnProv2.Location = New System.Drawing.Point(359, 219)
        Me.BtnProv2.Name = "BtnProv2"
        Me.BtnProv2.Size = New System.Drawing.Size(26, 20)
        Me.BtnProv2.TabIndex = 367
        Me.BtnProv2.UseVisualStyleBackColor = True
        Me.BtnProv2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(16, 223)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(28, 16)
        Me.Lt6.TabIndex = 363
        Me.Lt6.Text = "Del"
        '
        'TCVE_PROV1
        '
        Me.TCVE_PROV1.AcceptsReturn = True
        Me.TCVE_PROV1.AcceptsTab = True
        Me.TCVE_PROV1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_PROV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV1.Location = New System.Drawing.Point(49, 220)
        Me.TCVE_PROV1.MaxLength = 10
        Me.TCVE_PROV1.Name = "TCVE_PROV1"
        Me.TCVE_PROV1.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_PROV1.TabIndex = 362
        '
        'BtnProv1
        '
        Me.BtnProv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProv1.Image = CType(resources.GetObject("BtnProv1.Image"), System.Drawing.Image)
        Me.BtnProv1.Location = New System.Drawing.Point(170, 220)
        Me.BtnProv1.Name = "BtnProv1"
        Me.BtnProv1.Size = New System.Drawing.Size(26, 20)
        Me.BtnProv1.TabIndex = 364
        Me.BtnProv1.UseVisualStyleBackColor = True
        Me.BtnProv1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChSoloExist
        '
        Me.ChSoloExist.BackColor = System.Drawing.Color.Transparent
        Me.ChSoloExist.BorderColor = System.Drawing.Color.Transparent
        Me.ChSoloExist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChSoloExist.Checked = True
        Me.ChSoloExist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChSoloExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChSoloExist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChSoloExist.ForeColor = System.Drawing.Color.Black
        Me.ChSoloExist.Location = New System.Drawing.Point(36, 116)
        Me.ChSoloExist.Name = "ChSoloExist"
        Me.ChSoloExist.Padding = New System.Windows.Forms.Padding(1)
        Me.ChSoloExist.Size = New System.Drawing.Size(160, 24)
        Me.ChSoloExist.TabIndex = 361
        Me.ChSoloExist.TabStop = False
        Me.ChSoloExist.Text = "Solo con existencias"
        Me.ChSoloExist.UseVisualStyleBackColor = True
        Me.ChSoloExist.Value = True
        Me.ChSoloExist.Visible = False
        Me.ChSoloExist.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDescUnidad
        '
        Me.LtDescUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescUnidad.Location = New System.Drawing.Point(170, 148)
        Me.LtDescUnidad.Name = "LtDescUnidad"
        Me.LtDescUnidad.Size = New System.Drawing.Size(186, 22)
        Me.LtDescUnidad.TabIndex = 360
        Me.LtDescUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnUnidades
        '
        Me.BtnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidades.Image = CType(resources.GetObject("BtnUnidades.Image"), System.Drawing.Image)
        Me.BtnUnidades.Location = New System.Drawing.Point(143, 148)
        Me.BtnUnidades.Name = "BtnUnidades"
        Me.BtnUnidades.Size = New System.Drawing.Size(26, 22)
        Me.BtnUnidades.TabIndex = 359
        Me.BtnUnidades.UseVisualStyleBackColor = True
        Me.BtnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(62, 148)
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_UNI.TabIndex = 358
        '
        'LtUnidad
        '
        Me.LtUnidad.AutoSize = True
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(6, 151)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(51, 16)
        Me.LtUnidad.TabIndex = 357
        Me.LtUnidad.Text = "Unidad"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(167, 61)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 356
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(206, 87)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 355
        Me.LtAl.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(245, 85)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 353
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(30, 87)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 354
        Me.LtDel.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(63, 85)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 352
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'RadNoTerminada
        '
        Me.RadNoTerminada.AutoSize = True
        Me.RadNoTerminada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadNoTerminada.Location = New System.Drawing.Point(224, 388)
        Me.RadNoTerminada.Name = "RadNoTerminada"
        Me.RadNoTerminada.Size = New System.Drawing.Size(113, 20)
        Me.RadNoTerminada.TabIndex = 370
        Me.RadNoTerminada.TabStop = True
        Me.RadNoTerminada.Text = "No terminadas"
        Me.RadNoTerminada.UseVisualStyleBackColor = False
        '
        'RadTerminada
        '
        Me.RadTerminada.AutoSize = True
        Me.RadTerminada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTerminada.Location = New System.Drawing.Point(57, 388)
        Me.RadTerminada.Name = "RadTerminada"
        Me.RadTerminada.Size = New System.Drawing.Size(98, 20)
        Me.RadTerminada.TabIndex = 369
        Me.RadTerminada.TabStop = True
        Me.RadTerminada.Text = "Terminadas"
        Me.RadTerminada.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(577, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 377
        Me.Label1.Text = "Rango de artículos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(644, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 375
        Me.Label2.Text = "al"
        '
        'TCVE_ART2
        '
        Me.TCVE_ART2.AcceptsReturn = True
        Me.TCVE_ART2.AcceptsTab = True
        Me.TCVE_ART2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART2.Location = New System.Drawing.Point(671, 81)
        Me.TCVE_ART2.MaxLength = 10
        Me.TCVE_ART2.Name = "TCVE_ART2"
        Me.TCVE_ART2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART2.TabIndex = 374
        '
        'BtnArt2
        '
        Me.BtnArt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt2.Image = CType(resources.GetObject("BtnArt2.Image"), System.Drawing.Image)
        Me.BtnArt2.Location = New System.Drawing.Point(796, 82)
        Me.BtnArt2.Name = "BtnArt2"
        Me.BtnArt2.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt2.TabIndex = 376
        Me.BtnArt2.UseVisualStyleBackColor = True
        Me.BtnArt2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(453, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 372
        Me.Label3.Text = "Del"
        '
        'TCVE_ART1
        '
        Me.TCVE_ART1.AcceptsReturn = True
        Me.TCVE_ART1.AcceptsTab = True
        Me.TCVE_ART1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART1.Location = New System.Drawing.Point(486, 83)
        Me.TCVE_ART1.MaxLength = 10
        Me.TCVE_ART1.Name = "TCVE_ART1"
        Me.TCVE_ART1.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART1.TabIndex = 371
        '
        'BtnArt1
        '
        Me.BtnArt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt1.Image = CType(resources.GetObject("BtnArt1.Image"), System.Drawing.Image)
        Me.BtnArt1.Location = New System.Drawing.Point(607, 83)
        Me.BtnArt1.Name = "BtnArt1"
        Me.BtnArt1.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt1.TabIndex = 373
        Me.BtnArt1.UseVisualStyleBackColor = True
        Me.BtnArt1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(273, 313)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 23)
        Me.TextBox1.TabIndex = 388
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(208, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Producto"
        '
        'BtnProd2
        '
        Me.BtnProd2.AutoSize = True
        Me.BtnProd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProd2.Image = CType(resources.GetObject("BtnProd2.Image"), System.Drawing.Image)
        Me.BtnProd2.Location = New System.Drawing.Point(354, 312)
        Me.BtnProd2.Name = "BtnProd2"
        Me.BtnProd2.Size = New System.Drawing.Size(26, 24)
        Me.BtnProd2.TabIndex = 390
        Me.BtnProd2.UseVisualStyleBackColor = True
        Me.BtnProd2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCLIENTE2
        '
        Me.TCLIENTE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE2.Location = New System.Drawing.Point(273, 259)
        Me.TCLIENTE2.Name = "TCLIENTE2"
        Me.TCLIENTE2.Size = New System.Drawing.Size(80, 23)
        Me.TCLIENTE2.TabIndex = 381
        '
        'TCLIENTE1
        '
        Me.TCLIENTE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE1.Location = New System.Drawing.Point(85, 262)
        Me.TCLIENTE1.Name = "TCLIENTE1"
        Me.TCLIENTE1.Size = New System.Drawing.Size(80, 23)
        Me.TCLIENTE1.TabIndex = 380
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(221, 262)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 17)
        Me.Label11.TabIndex = 382
        Me.Label11.Text = "Cliente"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(85, 316)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(80, 23)
        Me.TextBox2.TabIndex = 379
        '
        'BTnCliente2
        '
        Me.BTnCliente2.AutoSize = True
        Me.BTnCliente2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTnCliente2.Image = CType(resources.GetObject("BTnCliente2.Image"), System.Drawing.Image)
        Me.BTnCliente2.Location = New System.Drawing.Point(354, 258)
        Me.BTnCliente2.Name = "BTnCliente2"
        Me.BTnCliente2.Size = New System.Drawing.Size(26, 24)
        Me.BTnCliente2.TabIndex = 384
        Me.BTnCliente2.UseVisualStyleBackColor = True
        Me.BTnCliente2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(33, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 386
        Me.Label7.Text = "Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 383
        Me.Label4.Text = "Producto"
        '
        'BtnProd1
        '
        Me.BtnProd1.AutoSize = True
        Me.BtnProd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProd1.Image = CType(resources.GetObject("BtnProd1.Image"), System.Drawing.Image)
        Me.BtnProd1.Location = New System.Drawing.Point(166, 315)
        Me.BtnProd1.Name = "BtnProd1"
        Me.BtnProd1.Size = New System.Drawing.Size(26, 24)
        Me.BtnProd1.TabIndex = 385
        Me.BtnProd1.UseVisualStyleBackColor = True
        Me.BtnProd1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BTnCliente1
        '
        Me.BTnCliente1.AutoSize = True
        Me.BTnCliente1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTnCliente1.Image = CType(resources.GetObject("BTnCliente1.Image"), System.Drawing.Image)
        Me.BTnCliente1.Location = New System.Drawing.Point(166, 260)
        Me.BTnCliente1.Name = "BTnCliente1"
        Me.BTnCliente1.Size = New System.Drawing.Size(26, 24)
        Me.BTnCliente1.TabIndex = 387
        Me.BTnCliente1.UseVisualStyleBackColor = True
        Me.BTnCliente1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtTanque1
        '
        Me.LtTanque1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque1.Location = New System.Drawing.Point(606, 185)
        Me.LtTanque1.Name = "LtTanque1"
        Me.LtTanque1.Size = New System.Drawing.Size(262, 22)
        Me.LtTanque1.TabIndex = 401
        Me.LtTanque1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTanque1
        '
        Me.BtnTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTanque1.Image = CType(resources.GetObject("BtnTanque1.Image"), System.Drawing.Image)
        Me.BtnTanque1.Location = New System.Drawing.Point(578, 185)
        Me.BtnTanque1.Name = "BtnTanque1"
        Me.BtnTanque1.Size = New System.Drawing.Size(26, 22)
        Me.BtnTanque1.TabIndex = 403
        Me.BtnTanque1.UseVisualStyleBackColor = True
        Me.BtnTanque1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_TANQUE1
        '
        Me.TCVE_TANQUE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TANQUE1.Location = New System.Drawing.Point(496, 185)
        Me.TCVE_TANQUE1.Name = "TCVE_TANQUE1"
        Me.TCVE_TANQUE1.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_TANQUE1.TabIndex = 400
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(438, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 402
        Me.Label6.Text = "Tanque"
        '
        'LOper
        '
        Me.LOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LOper.Location = New System.Drawing.Point(584, 225)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(284, 22)
        Me.LOper.TabIndex = 395
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(496, 225)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_OPER.TabIndex = 393
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(427, 228)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 16)
        Me.Label41.TabIndex = 398
        Me.Label41.Text = "Operador"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(553, 224)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 22)
        Me.BtnOper.TabIndex = 399
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtTractor
        '
        Me.LtTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTractor.Location = New System.Drawing.Point(606, 145)
        Me.LtTractor.Name = "LtTractor"
        Me.LtTractor.Size = New System.Drawing.Size(262, 22)
        Me.LtTractor.TabIndex = 394
        Me.LtTractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTractor
        '
        Me.BtnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTractor.Image = CType(resources.GetObject("BtnTractor.Image"), System.Drawing.Image)
        Me.BtnTractor.Location = New System.Drawing.Point(578, 145)
        Me.BtnTractor.Name = "BtnTractor"
        Me.BtnTractor.Size = New System.Drawing.Size(26, 22)
        Me.BtnTractor.TabIndex = 397
        Me.BtnTractor.UseVisualStyleBackColor = True
        Me.BtnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_TRACTOR
        '
        Me.TCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TRACTOR.Location = New System.Drawing.Point(496, 145)
        Me.TCVE_TRACTOR.Name = "TCVE_TRACTOR"
        Me.TCVE_TRACTOR.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_TRACTOR.TabIndex = 392
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(442, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 16)
        Me.Label8.TabIndex = 396
        Me.Label8.Text = "Tractor"
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(936, 43)
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
        'RibbonForm4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(936, 445)
        Me.Controls.Add(Me.LtTanque1)
        Me.Controls.Add(Me.BtnTanque1)
        Me.Controls.Add(Me.TCVE_TANQUE1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LOper)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.LtTractor)
        Me.Controls.Add(Me.BtnTractor)
        Me.Controls.Add(Me.TCVE_TRACTOR)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnProd2)
        Me.Controls.Add(Me.TCLIENTE2)
        Me.Controls.Add(Me.TCLIENTE1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.BTnCliente2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnProd1)
        Me.Controls.Add(Me.BTnCliente1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCVE_ART2)
        Me.Controls.Add(Me.BtnArt2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCVE_ART1)
        Me.Controls.Add(Me.BtnArt1)
        Me.Controls.Add(Me.RadNoTerminada)
        Me.Controls.Add(Me.RadTerminada)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt7)
        Me.Controls.Add(Me.TCVE_PROV2)
        Me.Controls.Add(Me.BtnProv2)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.TCVE_PROV1)
        Me.Controls.Add(Me.BtnProv1)
        Me.Controls.Add(Me.ChSoloExist)
        Me.Controls.Add(Me.LtDescUnidad)
        Me.Controls.Add(Me.BtnUnidades)
        Me.Controls.Add(Me.TCVE_UNI)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.LtAl)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.LtDel)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RibbonForm4"
        Me.Text = "Llenar bienes transportados"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChSoloExist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTnCliente2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTnCliente1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTanque1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents TCVE_PROV2 As TextBox
    Friend WithEvents BtnProv2 As C1.Win.C1Input.C1Button
    Friend WithEvents Lt6 As Label
    Friend WithEvents TCVE_PROV1 As TextBox
    Friend WithEvents BtnProv1 As C1.Win.C1Input.C1Button
    Friend WithEvents ChSoloExist As C1.Win.C1Input.C1CheckBox
    Friend WithEvents LtDescUnidad As Label
    Friend WithEvents BtnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_UNI As TextBox
    Friend WithEvents LtUnidad As Label
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents RadNoTerminada As RadioButton
    Friend WithEvents RadTerminada As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TCVE_ART2 As TextBox
    Friend WithEvents BtnArt2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TCVE_ART1 As TextBox
    Friend WithEvents BtnArt1 As C1.Win.C1Input.C1Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnProd2 As C1.Win.C1Input.C1Button
    Friend WithEvents TCLIENTE2 As TextBox
    Friend WithEvents TCLIENTE1 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents BTnCliente2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnProd1 As C1.Win.C1Input.C1Button
    Friend WithEvents BTnCliente1 As C1.Win.C1Input.C1Button
    Friend WithEvents LtTanque1 As Label
    Friend WithEvents BtnTanque1 As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_TANQUE1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents LtTractor As Label
    Friend WithEvents BtnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_TRACTOR As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
End Class
