<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAltaCxCAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaCxCAE))
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TObs = New C1.Win.C1Input.C1TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TIMPORTE = New C1.Win.C1Input.C1TextBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TIMPMON_EXT = New C1.Win.C1Input.C1NumericEdit()
        Me.LtNumcpto = New System.Windows.Forms.Label()
        Me.LtCambio = New System.Windows.Forms.Label()
        Me.BtnTipoCambio = New C1.Win.C1Input.C1Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TTCAMBIO = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LtNoCargo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LtMoneda = New System.Windows.Forms.Label()
        Me.BtnMoneda = New C1.Win.C1Input.C1Button()
        Me.TNUM_MONED = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.BtnReferencia = New C1.Win.C1Input.C1Button()
        Me.TNO_FACTURA = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TDOCTO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnNoFactura = New C1.Win.C1Input.C1Button()
        Me.TREFER = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TTIPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtConp = New System.Windows.Forms.Label()
        Me.BtnNumCpto = New C1.Win.C1Input.C1Button()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.BtnClie = New C1.Win.C1Input.C1Button()
        Me.TCVE_CLIE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Box1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TFolio = New C1.Win.C1Input.C1TextBox()
        Me.chAplicarFolio = New C1.Win.C1Input.C1CheckBox()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CboCuentabancaria = New C1.Win.C1Input.C1ComboBox()
        Me.BarMenu.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TObs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPMON_EXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNoFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BtnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Box1.SuspendLayout()
        CType(Me.TFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAplicarFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCuentabancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarMenu
        '
        Me.BarMenu.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.mnuSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(591, 37)
        Me.BarMenu.Stretch = False
        Me.BarMenu.TabIndex = 0
        Me.BarMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 33)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 33)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TObs)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 433)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(556, 72)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Observaciones"
        '
        'TObs
        '
        Me.TObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs.Location = New System.Drawing.Point(11, 22)
        Me.TObs.Multiline = True
        Me.TObs.Name = "TObs"
        Me.TObs.Size = New System.Drawing.Size(519, 41)
        Me.TObs.TabIndex = 8
        Me.TObs.Tag = Nothing
        Me.TObs.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TObs.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboCuentabancaria)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TIMPORTE)
        Me.GroupBox2.Controls.Add(Me.Lt2)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Lt1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TIMPMON_EXT)
        Me.GroupBox2.Controls.Add(Me.LtNumcpto)
        Me.GroupBox2.Controls.Add(Me.LtCambio)
        Me.GroupBox2.Controls.Add(Me.BtnTipoCambio)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TTCAMBIO)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.LtNoCargo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.LtMoneda)
        Me.GroupBox2.Controls.Add(Me.BtnMoneda)
        Me.GroupBox2.Controls.Add(Me.TNUM_MONED)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.F2)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.F1)
        Me.GroupBox2.Controls.Add(Me.Label90)
        Me.GroupBox2.Controls.Add(Me.BtnReferencia)
        Me.GroupBox2.Controls.Add(Me.TNO_FACTURA)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TDOCTO)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.btnNoFactura)
        Me.GroupBox2.Controls.Add(Me.TREFER)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(556, 246)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'TIMPORTE
        '
        Me.TIMPORTE.AcceptsReturn = True
        Me.TIMPORTE.AcceptsTab = True
        Me.TIMPORTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIMPORTE.CustomFormat = "###,###,##0.00"
        Me.TIMPORTE.DataType = GetType(Decimal)
        Me.TIMPORTE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE.Location = New System.Drawing.Point(107, 204)
        Me.TIMPORTE.Name = "TIMPORTE"
        Me.TIMPORTE.Size = New System.Drawing.Size(120, 19)
        Me.TIMPORTE.TabIndex = 3
        Me.TIMPORTE.Tag = Nothing
        Me.TIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt2
        '
        Me.Lt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(377, 177)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(153, 20)
        Me.Lt2.TabIndex = 177
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(330, 180)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 16)
        Me.Label16.TabIndex = 176
        Me.Label16.Text = "Saldo"
        '
        'Lt1
        '
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(107, 173)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(120, 20)
        Me.Lt1.TabIndex = 175
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 174
        Me.Label10.Text = "Importe doc."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(245, 206)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 16)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Monto en mon. base"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(60, 206)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 16)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "Monto"
        '
        'TIMPMON_EXT
        '
        Me.TIMPMON_EXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPMON_EXT.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPMON_EXT.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPMON_EXT.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPMON_EXT.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TIMPMON_EXT.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPMON_EXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPMON_EXT.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPMON_EXT.Location = New System.Drawing.Point(377, 204)
        Me.TIMPMON_EXT.Name = "TIMPMON_EXT"
        Me.TIMPMON_EXT.Size = New System.Drawing.Size(153, 20)
        Me.TIMPMON_EXT.TabIndex = 8
        Me.TIMPMON_EXT.Tag = Nothing
        Me.TIMPMON_EXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPMON_EXT.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.TIMPMON_EXT.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPMON_EXT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtNumcpto
        '
        Me.LtNumcpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumcpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumcpto.Location = New System.Drawing.Point(478, 89)
        Me.LtNumcpto.Name = "LtNumcpto"
        Me.LtNumcpto.Size = New System.Drawing.Size(52, 20)
        Me.LtNumcpto.TabIndex = 148
        Me.LtNumcpto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtCambio
        '
        Me.LtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCambio.Enabled = False
        Me.LtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCambio.Location = New System.Drawing.Point(432, 143)
        Me.LtCambio.Name = "LtCambio"
        Me.LtCambio.Size = New System.Drawing.Size(100, 20)
        Me.LtCambio.TabIndex = 165
        Me.LtCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTipoCambio
        '
        Me.BtnTipoCambio.AutoSize = True
        Me.BtnTipoCambio.Enabled = False
        Me.BtnTipoCambio.FlatAppearance.BorderSize = 0
        Me.BtnTipoCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTipoCambio.Image = CType(resources.GetObject("BtnTipoCambio.Image"), System.Drawing.Image)
        Me.BtnTipoCambio.Location = New System.Drawing.Point(405, 143)
        Me.BtnTipoCambio.Name = "BtnTipoCambio"
        Me.BtnTipoCambio.Size = New System.Drawing.Size(26, 22)
        Me.BtnTipoCambio.TabIndex = 9
        Me.BtnTipoCambio.UseVisualStyleBackColor = True
        Me.BtnTipoCambio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(412, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 147
        Me.Label11.Text = "Concepto"
        '
        'TTCAMBIO
        '
        Me.TTCAMBIO.AcceptsReturn = True
        Me.TTCAMBIO.AcceptsTab = True
        Me.TTCAMBIO.Enabled = False
        Me.TTCAMBIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTCAMBIO.Location = New System.Drawing.Point(377, 143)
        Me.TTCAMBIO.Name = "TTCAMBIO"
        Me.TTCAMBIO.Size = New System.Drawing.Size(28, 22)
        Me.TTCAMBIO.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(271, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 16)
        Me.Label19.TabIndex = 163
        Me.Label19.Text = "Tipo de cambio"
        '
        'LtNoCargo
        '
        Me.LtNoCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNoCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNoCargo.Location = New System.Drawing.Point(478, 63)
        Me.LtNoCargo.Name = "LtNoCargo"
        Me.LtNoCargo.Size = New System.Drawing.Size(52, 20)
        Me.LtNoCargo.TabIndex = 146
        Me.LtNoCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(412, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 16)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "No. cargo"
        '
        'LtMoneda
        '
        Me.LtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMoneda.Location = New System.Drawing.Point(165, 143)
        Me.LtMoneda.Name = "LtMoneda"
        Me.LtMoneda.Size = New System.Drawing.Size(100, 20)
        Me.LtMoneda.TabIndex = 161
        Me.LtMoneda.Text = "Pesos"
        Me.LtMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnMoneda
        '
        Me.BtnMoneda.AutoSize = True
        Me.BtnMoneda.Enabled = False
        Me.BtnMoneda.FlatAppearance.BorderSize = 0
        Me.BtnMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoneda.Image = CType(resources.GetObject("BtnMoneda.Image"), System.Drawing.Image)
        Me.BtnMoneda.Location = New System.Drawing.Point(138, 143)
        Me.BtnMoneda.Name = "BtnMoneda"
        Me.BtnMoneda.Size = New System.Drawing.Size(26, 22)
        Me.BtnMoneda.TabIndex = 8
        Me.BtnMoneda.UseVisualStyleBackColor = True
        Me.BtnMoneda.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TNUM_MONED
        '
        Me.TNUM_MONED.AcceptsReturn = True
        Me.TNUM_MONED.AcceptsTab = True
        Me.TNUM_MONED.Enabled = False
        Me.TNUM_MONED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_MONED.Location = New System.Drawing.Point(107, 143)
        Me.TNUM_MONED.Name = "TNUM_MONED"
        Me.TNUM_MONED.Size = New System.Drawing.Size(30, 22)
        Me.TNUM_MONED.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(47, 146)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 16)
        Me.Label17.TabIndex = 159
        Me.Label17.Text = "Moneda"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.ShowClearButton = False
        Me.F2.Calendar.ShowWeekNumbers = True
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(421, 115)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(111, 20)
        Me.F2.TabIndex = 7
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(328, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 16)
        Me.Label15.TabIndex = 157
        Me.Label15.Text = "Fecha"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.ShowClearButton = False
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(107, 116)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 20)
        Me.F1.TabIndex = 4
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(59, 119)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(45, 16)
        Me.Label90.TabIndex = 155
        Me.Label90.Text = "Fecha"
        '
        'BtnReferencia
        '
        Me.BtnReferencia.AutoSize = True
        Me.BtnReferencia.FlatAppearance.BorderSize = 0
        Me.BtnReferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReferencia.Image = CType(resources.GetObject("BtnReferencia.Image"), System.Drawing.Image)
        Me.BtnReferencia.Location = New System.Drawing.Point(333, 92)
        Me.BtnReferencia.Name = "BtnReferencia"
        Me.BtnReferencia.Size = New System.Drawing.Size(26, 22)
        Me.BtnReferencia.TabIndex = 11
        Me.BtnReferencia.UseVisualStyleBackColor = True
        Me.BtnReferencia.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TNO_FACTURA
        '
        Me.TNO_FACTURA.AcceptsReturn = True
        Me.TNO_FACTURA.AcceptsTab = True
        Me.TNO_FACTURA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNO_FACTURA.Location = New System.Drawing.Point(107, 90)
        Me.TNO_FACTURA.Name = "TNO_FACTURA"
        Me.TNO_FACTURA.Size = New System.Drawing.Size(224, 22)
        Me.TNO_FACTURA.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "No. Referecia"
        '
        'TDOCTO
        '
        Me.TDOCTO.AcceptsReturn = True
        Me.TDOCTO.AcceptsTab = True
        Me.TDOCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDOCTO.Location = New System.Drawing.Point(107, 64)
        Me.TDOCTO.Name = "TDOCTO"
        Me.TDOCTO.Size = New System.Drawing.Size(224, 22)
        Me.TDOCTO.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "No. Documento"
        '
        'btnNoFactura
        '
        Me.btnNoFactura.AutoSize = True
        Me.btnNoFactura.FlatAppearance.BorderSize = 0
        Me.btnNoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoFactura.Image = CType(resources.GetObject("btnNoFactura.Image"), System.Drawing.Image)
        Me.btnNoFactura.Location = New System.Drawing.Point(333, 40)
        Me.btnNoFactura.Name = "btnNoFactura"
        Me.btnNoFactura.Size = New System.Drawing.Size(26, 22)
        Me.btnNoFactura.TabIndex = 10
        Me.btnNoFactura.UseVisualStyleBackColor = True
        Me.btnNoFactura.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TREFER
        '
        Me.TREFER.AcceptsReturn = True
        Me.TREFER.AcceptsTab = True
        Me.TREFER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREFER.Location = New System.Drawing.Point(107, 38)
        Me.TREFER.Name = "TREFER"
        Me.TREFER.Size = New System.Drawing.Size(224, 22)
        Me.TREFER.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 16)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "No. Factura"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TTIPO)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LtConp)
        Me.GroupBox1.Controls.Add(Me.BtnNumCpto)
        Me.GroupBox1.Controls.Add(Me.tNUM_CPTO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.L3)
        Me.GroupBox1.Controls.Add(Me.BtnClie)
        Me.GroupBox1.Controls.Add(Me.TCVE_CLIE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 74)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de cliente"
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(573, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(234, 20)
        Me.Label4.TabIndex = 144
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTIPO
        '
        Me.TTIPO.AcceptsReturn = True
        Me.TTIPO.AcceptsTab = True
        Me.TTIPO.Enabled = False
        Me.TTIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO.Location = New System.Drawing.Point(478, 45)
        Me.TTIPO.Name = "TTIPO"
        Me.TTIPO.Size = New System.Drawing.Size(54, 22)
        Me.TTIPO.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(438, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 16)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Tipo"
        '
        'LtConp
        '
        Me.LtConp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtConp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtConp.Location = New System.Drawing.Point(161, 45)
        Me.LtConp.Name = "LtConp"
        Me.LtConp.Size = New System.Drawing.Size(246, 20)
        Me.LtConp.TabIndex = 141
        Me.LtConp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnNumCpto
        '
        Me.BtnNumCpto.AutoSize = True
        Me.BtnNumCpto.FlatAppearance.BorderSize = 0
        Me.BtnNumCpto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNumCpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNumCpto.Image = CType(resources.GetObject("BtnNumCpto.Image"), System.Drawing.Image)
        Me.BtnNumCpto.Location = New System.Drawing.Point(135, 45)
        Me.BtnNumCpto.Name = "BtnNumCpto"
        Me.BtnNumCpto.Size = New System.Drawing.Size(26, 22)
        Me.BtnNumCpto.TabIndex = 140
        Me.BtnNumCpto.UseVisualStyleBackColor = True
        Me.BtnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(79, 45)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(54, 22)
        Me.tNUM_CPTO.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Concepto"
        '
        'L3
        '
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(161, 19)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(371, 20)
        Me.L3.TabIndex = 137
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnClie
        '
        Me.BtnClie.AutoSize = True
        Me.BtnClie.FlatAppearance.BorderSize = 0
        Me.BtnClie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie.Image = CType(resources.GetObject("BtnClie.Image"), System.Drawing.Image)
        Me.BtnClie.Location = New System.Drawing.Point(135, 19)
        Me.BtnClie.Name = "BtnClie"
        Me.BtnClie.Size = New System.Drawing.Size(26, 22)
        Me.BtnClie.TabIndex = 136
        Me.BtnClie.UseVisualStyleBackColor = True
        Me.BtnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_CLIE
        '
        Me.TCVE_CLIE.AcceptsReturn = True
        Me.TCVE_CLIE.AcceptsTab = True
        Me.TCVE_CLIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE.Location = New System.Drawing.Point(79, 19)
        Me.TCVE_CLIE.Name = "TCVE_CLIE"
        Me.TCVE_CLIE.Size = New System.Drawing.Size(54, 22)
        Me.TCVE_CLIE.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "Clave"
        '
        'Box1
        '
        Me.Box1.Controls.Add(Me.Label1)
        Me.Box1.Controls.Add(Me.TFolio)
        Me.Box1.Controls.Add(Me.chAplicarFolio)
        Me.Box1.Location = New System.Drawing.Point(12, 40)
        Me.Box1.Name = "Box1"
        Me.Box1.Size = New System.Drawing.Size(556, 61)
        Me.Box1.TabIndex = 0
        Me.Box1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(242, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Folio"
        '
        'TFolio
        '
        Me.TFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFolio.Location = New System.Drawing.Point(286, 26)
        Me.TFolio.Name = "TFolio"
        Me.TFolio.Size = New System.Drawing.Size(100, 20)
        Me.TFolio.TabIndex = 1
        Me.TFolio.Tag = Nothing
        Me.TFolio.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFolio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chAplicarFolio
        '
        Me.chAplicarFolio.BackColor = System.Drawing.Color.Transparent
        Me.chAplicarFolio.BorderColor = System.Drawing.Color.Transparent
        Me.chAplicarFolio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chAplicarFolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chAplicarFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chAplicarFolio.ForeColor = System.Drawing.Color.Black
        Me.chAplicarFolio.Location = New System.Drawing.Point(51, 20)
        Me.chAplicarFolio.Name = "chAplicarFolio"
        Me.chAplicarFolio.Padding = New System.Windows.Forms.Padding(1)
        Me.chAplicarFolio.Size = New System.Drawing.Size(104, 24)
        Me.chAplicarFolio.TabIndex = 0
        Me.chAplicarFolio.Text = "Aplicar folio"
        Me.chAplicarFolio.UseVisualStyleBackColor = True
        Me.chAplicarFolio.Value = Nothing
        Me.chAplicarFolio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 16)
        Me.Label12.TabIndex = 179
        Me.Label12.Text = "Cta. Bancaria"
        '
        'CboCuentabancaria
        '
        Me.CboCuentabancaria.AcceptsTab = True
        Me.CboCuentabancaria.AllowSpinLoop = False
        Me.CboCuentabancaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboCuentabancaria.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboCuentabancaria.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboCuentabancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCuentabancaria.GapHeight = 0
        Me.CboCuentabancaria.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboCuentabancaria.ItemsDisplayMember = ""
        Me.CboCuentabancaria.ItemsValueMember = ""
        Me.CboCuentabancaria.Location = New System.Drawing.Point(107, 13)
        Me.CboCuentabancaria.MaxDropDownItems = 15
        Me.CboCuentabancaria.Name = "CboCuentabancaria"
        Me.CboCuentabancaria.Size = New System.Drawing.Size(300, 19)
        Me.CboCuentabancaria.TabIndex = 0
        Me.CboCuentabancaria.Tag = Nothing
        Me.CboCuentabancaria.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboCuentabancaria.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmAltaCxCAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 527)
        Me.Controls.Add(Me.BarMenu)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Box1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAltaCxCAE"
        Me.ShowInTaskbar = False
        Me.Text = "Altas cuentas x cobrar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.TObs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPMON_EXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNoFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BtnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Box1.ResumeLayout(False)
        Me.Box1.PerformLayout()
        CType(Me.TFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAplicarFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCuentabancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TObs As C1.Win.C1Input.C1TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TIMPMON_EXT As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents LtNumcpto As Label
    Friend WithEvents LtCambio As Label
    Friend WithEvents BtnTipoCambio As C1.Win.C1Input.C1Button
    Friend WithEvents Label11 As Label
    Friend WithEvents TTCAMBIO As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LtNoCargo As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LtMoneda As Label
    Friend WithEvents BtnMoneda As C1.Win.C1Input.C1Button
    Friend WithEvents TNUM_MONED As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label90 As Label
    Friend WithEvents BtnReferencia As C1.Win.C1Input.C1Button
    Friend WithEvents TNO_FACTURA As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TDOCTO As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnNoFactura As C1.Win.C1Input.C1Button
    Friend WithEvents TREFER As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TTIPO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LtConp As Label
    Friend WithEvents BtnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents L3 As Label
    Friend WithEvents BtnClie As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_CLIE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Box1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TFolio As C1.Win.C1Input.C1TextBox
    Friend WithEvents chAplicarFolio As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Lt2 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TIMPORTE As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CboCuentabancaria As C1.Win.C1Input.C1ComboBox
End Class
