<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RibbonImprimiDisenador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonImprimiDisenador))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarDisenador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCVE_ART2 = New System.Windows.Forms.TextBox()
        Me.BtnArt2 = New C1.Win.C1Input.C1Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCVE_ART1 = New System.Windows.Forms.TextBox()
        Me.BtnArt1 = New C1.Win.C1Input.C1Button()
        Me.RadNoTerminada = New System.Windows.Forms.RadioButton()
        Me.RadTerminada = New System.Windows.Forms.RadioButton()
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
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnClie1 = New System.Windows.Forms.Button()
        Me.TCLIENTE1 = New System.Windows.Forms.TextBox()
        Me.BtnClie2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TCLIENTE2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LtTanque1 = New System.Windows.Forms.Label()
        Me.BtnTanque1 = New C1.Win.C1Input.C1Button()
        Me.TCVE_TANQUE1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnProd = New C1.Win.C1Input.C1Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TCVE_ART = New System.Windows.Forms.TextBox()
        Me.LtDescr = New System.Windows.Forms.Label()
        Me.LOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.LtTractor = New System.Windows.Forms.Label()
        Me.BtnTractor = New C1.Win.C1Input.C1Button()
        Me.TCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChSoloExist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTanque1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarDisenador)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutText = ""
        Me.BarDisenador.Text = "Diseñador"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "33db4604d377417ca53a25776aa43f00"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(864, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDisenador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 1
        Me.LkDisenador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(540, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 403
        Me.Label1.Text = "Rango de artículos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(607, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "al"
        '
        'TCVE_ART2
        '
        Me.TCVE_ART2.AcceptsReturn = True
        Me.TCVE_ART2.AcceptsTab = True
        Me.TCVE_ART2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART2.Location = New System.Drawing.Point(634, 91)
        Me.TCVE_ART2.MaxLength = 10
        Me.TCVE_ART2.Name = "TCVE_ART2"
        Me.TCVE_ART2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART2.TabIndex = 400
        '
        'BtnArt2
        '
        Me.BtnArt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt2.Image = CType(resources.GetObject("BtnArt2.Image"), System.Drawing.Image)
        Me.BtnArt2.Location = New System.Drawing.Point(759, 92)
        Me.BtnArt2.Name = "BtnArt2"
        Me.BtnArt2.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt2.TabIndex = 402
        Me.BtnArt2.UseVisualStyleBackColor = True
        Me.BtnArt2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(416, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 398
        Me.Label3.Text = "Del"
        '
        'TCVE_ART1
        '
        Me.TCVE_ART1.AcceptsReturn = True
        Me.TCVE_ART1.AcceptsTab = True
        Me.TCVE_ART1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART1.Location = New System.Drawing.Point(449, 93)
        Me.TCVE_ART1.MaxLength = 10
        Me.TCVE_ART1.Name = "TCVE_ART1"
        Me.TCVE_ART1.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART1.TabIndex = 397
        '
        'BtnArt1
        '
        Me.BtnArt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt1.Image = CType(resources.GetObject("BtnArt1.Image"), System.Drawing.Image)
        Me.BtnArt1.Location = New System.Drawing.Point(570, 93)
        Me.BtnArt1.Name = "BtnArt1"
        Me.BtnArt1.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt1.TabIndex = 399
        Me.BtnArt1.UseVisualStyleBackColor = True
        Me.BtnArt1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'RadNoTerminada
        '
        Me.RadNoTerminada.AutoSize = True
        Me.RadNoTerminada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadNoTerminada.Location = New System.Drawing.Point(214, 383)
        Me.RadNoTerminada.Name = "RadNoTerminada"
        Me.RadNoTerminada.Size = New System.Drawing.Size(113, 20)
        Me.RadNoTerminada.TabIndex = 396
        Me.RadNoTerminada.TabStop = True
        Me.RadNoTerminada.Text = "No terminadas"
        Me.RadNoTerminada.UseVisualStyleBackColor = False
        '
        'RadTerminada
        '
        Me.RadTerminada.AutoSize = True
        Me.RadTerminada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTerminada.Location = New System.Drawing.Point(47, 383)
        Me.RadTerminada.Name = "RadTerminada"
        Me.RadTerminada.Size = New System.Drawing.Size(98, 20)
        Me.RadTerminada.TabIndex = 395
        Me.RadTerminada.TabStop = True
        Me.RadTerminada.Text = "Terminadas"
        Me.RadTerminada.UseVisualStyleBackColor = False
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(140, 242)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(148, 16)
        Me.Lt5.TabIndex = 394
        Me.Lt5.Text = "Rango de proveedores"
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(207, 270)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(18, 16)
        Me.Lt7.TabIndex = 392
        Me.Lt7.Text = "al"
        '
        'TCVE_PROV2
        '
        Me.TCVE_PROV2.AcceptsReturn = True
        Me.TCVE_PROV2.AcceptsTab = True
        Me.TCVE_PROV2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_PROV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV2.Location = New System.Drawing.Point(234, 266)
        Me.TCVE_PROV2.MaxLength = 10
        Me.TCVE_PROV2.Name = "TCVE_PROV2"
        Me.TCVE_PROV2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_PROV2.TabIndex = 391
        '
        'BtnProv2
        '
        Me.BtnProv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProv2.Image = CType(resources.GetObject("BtnProv2.Image"), System.Drawing.Image)
        Me.BtnProv2.Location = New System.Drawing.Point(359, 266)
        Me.BtnProv2.Name = "BtnProv2"
        Me.BtnProv2.Size = New System.Drawing.Size(26, 20)
        Me.BtnProv2.TabIndex = 393
        Me.BtnProv2.UseVisualStyleBackColor = True
        Me.BtnProv2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(16, 271)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(28, 16)
        Me.Lt6.TabIndex = 389
        Me.Lt6.Text = "Del"
        '
        'TCVE_PROV1
        '
        Me.TCVE_PROV1.AcceptsReturn = True
        Me.TCVE_PROV1.AcceptsTab = True
        Me.TCVE_PROV1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_PROV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV1.Location = New System.Drawing.Point(49, 268)
        Me.TCVE_PROV1.MaxLength = 10
        Me.TCVE_PROV1.Name = "TCVE_PROV1"
        Me.TCVE_PROV1.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_PROV1.TabIndex = 388
        '
        'BtnProv1
        '
        Me.BtnProv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProv1.Image = CType(resources.GetObject("BtnProv1.Image"), System.Drawing.Image)
        Me.BtnProv1.Location = New System.Drawing.Point(170, 268)
        Me.BtnProv1.Name = "BtnProv1"
        Me.BtnProv1.Size = New System.Drawing.Size(26, 20)
        Me.BtnProv1.TabIndex = 390
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
        Me.ChSoloExist.Location = New System.Drawing.Point(41, 126)
        Me.ChSoloExist.Name = "ChSoloExist"
        Me.ChSoloExist.Padding = New System.Windows.Forms.Padding(1)
        Me.ChSoloExist.Size = New System.Drawing.Size(160, 24)
        Me.ChSoloExist.TabIndex = 387
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
        Me.LtDescUnidad.Location = New System.Drawing.Point(175, 158)
        Me.LtDescUnidad.Name = "LtDescUnidad"
        Me.LtDescUnidad.Size = New System.Drawing.Size(186, 22)
        Me.LtDescUnidad.TabIndex = 386
        Me.LtDescUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnUnidades
        '
        Me.BtnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidades.Image = CType(resources.GetObject("BtnUnidades.Image"), System.Drawing.Image)
        Me.BtnUnidades.Location = New System.Drawing.Point(148, 158)
        Me.BtnUnidades.Name = "BtnUnidades"
        Me.BtnUnidades.Size = New System.Drawing.Size(26, 22)
        Me.BtnUnidades.TabIndex = 385
        Me.BtnUnidades.UseVisualStyleBackColor = True
        Me.BtnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(67, 158)
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_UNI.TabIndex = 384
        '
        'LtUnidad
        '
        Me.LtUnidad.AutoSize = True
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(11, 161)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(51, 16)
        Me.LtUnidad.TabIndex = 383
        Me.LtUnidad.Text = "Unidad"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(172, 71)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 382
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(211, 97)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 381
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
        Me.F2.Location = New System.Drawing.Point(250, 95)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 379
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(35, 97)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 380
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
        Me.F1.Location = New System.Drawing.Point(68, 95)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 378
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione conceptos"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(464, 158)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(304, 175)
        Me.C1List1.TabIndex = 405
        Me.C1List1.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Blue
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(152, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 16)
        Me.Label4.TabIndex = 410
        Me.Label4.Text = "Rango de clientes"
        '
        'BtnClie1
        '
        Me.BtnClie1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClie1.FlatAppearance.BorderSize = 0
        Me.BtnClie1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie1.Image = CType(resources.GetObject("BtnClie1.Image"), System.Drawing.Image)
        Me.BtnClie1.Location = New System.Drawing.Point(160, 340)
        Me.BtnClie1.Name = "BtnClie1"
        Me.BtnClie1.Size = New System.Drawing.Size(25, 24)
        Me.BtnClie1.TabIndex = 412
        Me.BtnClie1.UseVisualStyleBackColor = True
        '
        'TCLIENTE1
        '
        Me.TCLIENTE1.AcceptsReturn = True
        Me.TCLIENTE1.AcceptsTab = True
        Me.TCLIENTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE1.Location = New System.Drawing.Point(83, 341)
        Me.TCLIENTE1.Name = "TCLIENTE1"
        Me.TCLIENTE1.Size = New System.Drawing.Size(77, 22)
        Me.TCLIENTE1.TabIndex = 407
        '
        'BtnClie2
        '
        Me.BtnClie2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClie2.FlatAppearance.BorderSize = 0
        Me.BtnClie2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie2.Image = CType(resources.GetObject("BtnClie2.Image"), System.Drawing.Image)
        Me.BtnClie2.Location = New System.Drawing.Point(307, 340)
        Me.BtnClie2.Name = "BtnClie2"
        Me.BtnClie2.Size = New System.Drawing.Size(25, 24)
        Me.BtnClie2.TabIndex = 413
        Me.BtnClie2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(36, 344)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 409
        Me.Label10.Text = "Desde"
        '
        'TCLIENTE2
        '
        Me.TCLIENTE2.AcceptsReturn = True
        Me.TCLIENTE2.AcceptsTab = True
        Me.TCLIENTE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE2.Location = New System.Drawing.Point(238, 341)
        Me.TCLIENTE2.Name = "TCLIENTE2"
        Me.TCLIENTE2.Size = New System.Drawing.Size(69, 22)
        Me.TCLIENTE2.TabIndex = 408
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(194, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 16)
        Me.Label13.TabIndex = 411
        Me.Label13.Text = "Hasta"
        '
        'LtTanque1
        '
        Me.LtTanque1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTanque1.Location = New System.Drawing.Point(565, 419)
        Me.LtTanque1.Name = "LtTanque1"
        Me.LtTanque1.Size = New System.Drawing.Size(262, 22)
        Me.LtTanque1.TabIndex = 428
        Me.LtTanque1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTanque1
        '
        Me.BtnTanque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTanque1.Image = CType(resources.GetObject("BtnTanque1.Image"), System.Drawing.Image)
        Me.BtnTanque1.Location = New System.Drawing.Point(537, 419)
        Me.BtnTanque1.Name = "BtnTanque1"
        Me.BtnTanque1.Size = New System.Drawing.Size(26, 22)
        Me.BtnTanque1.TabIndex = 430
        Me.BtnTanque1.UseVisualStyleBackColor = True
        Me.BtnTanque1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_TANQUE1
        '
        Me.TCVE_TANQUE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TANQUE1.Location = New System.Drawing.Point(455, 419)
        Me.TCVE_TANQUE1.Name = "TCVE_TANQUE1"
        Me.TCVE_TANQUE1.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_TANQUE1.TabIndex = 427
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(397, 422)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 429
        Me.Label5.Text = "Tanque"
        '
        'BtnProd
        '
        Me.BtnProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProd.Image = CType(resources.GetObject("BtnProd.Image"), System.Drawing.Image)
        Me.BtnProd.Location = New System.Drawing.Point(511, 504)
        Me.BtnProd.Name = "BtnProd"
        Me.BtnProd.Size = New System.Drawing.Size(26, 22)
        Me.BtnProd.TabIndex = 426
        Me.BtnProd.UseVisualStyleBackColor = True
        Me.BtnProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(390, 508)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(61, 16)
        Me.Label57.TabIndex = 425
        Me.Label57.Text = "Producto"
        '
        'TCVE_ART
        '
        Me.TCVE_ART.AcceptsReturn = True
        Me.TCVE_ART.AcceptsTab = True
        Me.TCVE_ART.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART.ForeColor = System.Drawing.Color.Black
        Me.TCVE_ART.Location = New System.Drawing.Point(455, 504)
        Me.TCVE_ART.Name = "TCVE_ART"
        Me.TCVE_ART.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_ART.TabIndex = 417
        '
        'LtDescr
        '
        Me.LtDescr.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDescr.Location = New System.Drawing.Point(543, 506)
        Me.LtDescr.Name = "LtDescr"
        Me.LtDescr.Size = New System.Drawing.Size(284, 22)
        Me.LtDescr.TabIndex = 420
        '
        'LOper
        '
        Me.LOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LOper.Location = New System.Drawing.Point(543, 459)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(284, 22)
        Me.LOper.TabIndex = 419
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(455, 459)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_OPER.TabIndex = 416
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(386, 462)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 16)
        Me.Label41.TabIndex = 423
        Me.Label41.Text = "Operador"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(512, 458)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 22)
        Me.BtnOper.TabIndex = 424
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtTractor
        '
        Me.LtTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTractor.Location = New System.Drawing.Point(565, 379)
        Me.LtTractor.Name = "LtTractor"
        Me.LtTractor.Size = New System.Drawing.Size(262, 22)
        Me.LtTractor.TabIndex = 418
        Me.LtTractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTractor
        '
        Me.BtnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTractor.Image = CType(resources.GetObject("BtnTractor.Image"), System.Drawing.Image)
        Me.BtnTractor.Location = New System.Drawing.Point(537, 379)
        Me.BtnTractor.Name = "BtnTractor"
        Me.BtnTractor.Size = New System.Drawing.Size(26, 22)
        Me.BtnTractor.TabIndex = 422
        Me.BtnTractor.UseVisualStyleBackColor = True
        Me.BtnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_TRACTOR
        '
        Me.TCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TRACTOR.Location = New System.Drawing.Point(455, 379)
        Me.TCVE_TRACTOR.Name = "TCVE_TRACTOR"
        Me.TCVE_TRACTOR.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_TRACTOR.TabIndex = 415
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(401, 382)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 421
        Me.Label6.Text = "Tractor"
        '
        'RibbonForm5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 597)
        Me.Controls.Add(Me.LtTanque1)
        Me.Controls.Add(Me.BtnTanque1)
        Me.Controls.Add(Me.TCVE_TANQUE1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnProd)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.TCVE_ART)
        Me.Controls.Add(Me.LtDescr)
        Me.Controls.Add(Me.LOper)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.LtTractor)
        Me.Controls.Add(Me.BtnTractor)
        Me.Controls.Add(Me.TCVE_TRACTOR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnClie1)
        Me.Controls.Add(Me.TCLIENTE1)
        Me.Controls.Add(Me.BtnClie2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TCLIENTE2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.C1List1)
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
        Me.Name = "RibbonForm5"
        Me.Text = "RibbonForm5"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChSoloExist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTanque1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarDisenador As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TCVE_ART2 As TextBox
    Friend WithEvents BtnArt2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TCVE_ART1 As TextBox
    Friend WithEvents BtnArt1 As C1.Win.C1Input.C1Button
    Friend WithEvents RadNoTerminada As RadioButton
    Friend WithEvents RadTerminada As RadioButton
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
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnClie1 As Button
    Friend WithEvents TCLIENTE1 As TextBox
    Friend WithEvents BtnClie2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TCLIENTE2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LtTanque1 As Label
    Friend WithEvents BtnTanque1 As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_TANQUE1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnProd As C1.Win.C1Input.C1Button
    Friend WithEvents Label57 As Label
    Friend WithEvents TCVE_ART As TextBox
    Friend WithEvents LtDescr As Label
    Friend WithEvents LOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents LtTractor As Label
    Friend WithEvents BtnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_TRACTOR As TextBox
    Friend WithEvents Label6 As Label
End Class
