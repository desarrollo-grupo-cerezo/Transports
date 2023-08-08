<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDescOperadorAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescOperadorAE))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tFOLIO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.LtTipoDesc = New System.Windows.Forms.Label()
        Me.btnTipoDesc = New C1.Win.C1Input.C1Button()
        Me.tCVE_TIP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LtNumCpto = New System.Windows.Forms.Label()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.btnOper = New C1.Win.C1Input.C1Button()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtFormaDesc = New System.Windows.Forms.Label()
        Me.btnFormaDesc = New C1.Win.C1Input.C1Button()
        Me.tCVE_FOR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tIMPORTE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.tSTR_OBS = New System.Windows.Forms.TextBox()
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.btnTipoDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFormaDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(657, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 9
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tFOLIO
        '
        Me.tFOLIO.AcceptsReturn = True
        Me.tFOLIO.AcceptsTab = True
        Me.tFOLIO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIO.Location = New System.Drawing.Point(145, 91)
        Me.tFOLIO.Name = "tFOLIO"
        Me.tFOLIO.Size = New System.Drawing.Size(110, 21)
        Me.tFOLIO.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(111, 94)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 13)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Folio"
        '
        'LtTipoDesc
        '
        Me.LtTipoDesc.BackColor = System.Drawing.Color.Transparent
        Me.LtTipoDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipoDesc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipoDesc.Location = New System.Drawing.Point(241, 210)
        Me.LtTipoDesc.Name = "LtTipoDesc"
        Me.LtTipoDesc.Size = New System.Drawing.Size(320, 20)
        Me.LtTipoDesc.TabIndex = 198
        Me.LtTipoDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTipoDesc
        '
        Me.btnTipoDesc.Image = CType(resources.GetObject("btnTipoDesc.Image"), System.Drawing.Image)
        Me.btnTipoDesc.Location = New System.Drawing.Point(215, 211)
        Me.btnTipoDesc.Name = "btnTipoDesc"
        Me.btnTipoDesc.Size = New System.Drawing.Size(23, 21)
        Me.btnTipoDesc.TabIndex = 197
        Me.btnTipoDesc.UseVisualStyleBackColor = True
        Me.btnTipoDesc.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnTipoDesc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_TIP
        '
        Me.tCVE_TIP.AcceptsReturn = True
        Me.tCVE_TIP.AcceptsTab = True
        Me.tCVE_TIP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TIP.Location = New System.Drawing.Point(145, 210)
        Me.tCVE_TIP.Name = "tCVE_TIP"
        Me.tCVE_TIP.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_TIP.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(58, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 196
        Me.Label10.Text = "Tipo descuento"
        '
        'LtNumCpto
        '
        Me.LtNumCpto.BackColor = System.Drawing.Color.Transparent
        Me.LtNumCpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumCpto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumCpto.Location = New System.Drawing.Point(241, 180)
        Me.LtNumCpto.Name = "LtNumCpto"
        Me.LtNumCpto.Size = New System.Drawing.Size(320, 20)
        Me.LtNumCpto.TabIndex = 195
        Me.LtNumCpto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNumCpto
        '
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(215, 181)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(23, 21)
        Me.btnNumCpto.TabIndex = 194
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(145, 180)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(69, 22)
        Me.tNUM_CPTO.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(86, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 193
        Me.Label5.Text = "Concepto"
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.Transparent
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(241, 150)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(320, 20)
        Me.LtOper.TabIndex = 192
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOper
        '
        Me.btnOper.Image = CType(resources.GetObject("btnOper.Image"), System.Drawing.Image)
        Me.btnOper.Location = New System.Drawing.Point(214, 150)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 21)
        Me.btnOper.TabIndex = 191
        Me.btnOper.UseVisualStyleBackColor = True
        Me.btnOper.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(145, 150)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_OPER.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(88, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "Operador"
        '
        'LtFormaDesc
        '
        Me.LtFormaDesc.BackColor = System.Drawing.Color.Transparent
        Me.LtFormaDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFormaDesc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFormaDesc.Location = New System.Drawing.Point(241, 240)
        Me.LtFormaDesc.Name = "LtFormaDesc"
        Me.LtFormaDesc.Size = New System.Drawing.Size(320, 20)
        Me.LtFormaDesc.TabIndex = 202
        Me.LtFormaDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFormaDesc
        '
        Me.btnFormaDesc.Image = CType(resources.GetObject("btnFormaDesc.Image"), System.Drawing.Image)
        Me.btnFormaDesc.Location = New System.Drawing.Point(215, 241)
        Me.btnFormaDesc.Name = "btnFormaDesc"
        Me.btnFormaDesc.Size = New System.Drawing.Size(23, 21)
        Me.btnFormaDesc.TabIndex = 201
        Me.btnFormaDesc.UseVisualStyleBackColor = True
        Me.btnFormaDesc.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnFormaDesc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_FOR
        '
        Me.tCVE_FOR.AcceptsReturn = True
        Me.tCVE_FOR.AcceptsTab = True
        Me.tCVE_FOR.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_FOR.Location = New System.Drawing.Point(145, 240)
        Me.tCVE_FOR.Name = "tCVE_FOR"
        Me.tCVE_FOR.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_FOR.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(53, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Forma descontar"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(145, 118)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(147, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(49, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 204
        Me.Label6.Text = "Descontar a partir"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(391, 118)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(147, 20)
        Me.F2.TabIndex = 2
        Me.F2.Tag = Nothing
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(309, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Hasta la fecha"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(16, 274)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "Importe total x descontar"
        '
        'tIMPORTE
        '
        Me.tIMPORTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tIMPORTE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tIMPORTE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tIMPORTE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tIMPORTE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.tIMPORTE.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tIMPORTE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIMPORTE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tIMPORTE.Location = New System.Drawing.Point(145, 270)
        Me.tIMPORTE.Name = "tIMPORTE"
        Me.tIMPORTE.Size = New System.Drawing.Size(161, 20)
        Me.tIMPORTE.TabIndex = 7
        Me.tIMPORTE.Tag = Nothing
        Me.tIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Location = New System.Drawing.Point(61, 327)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 13)
        Me.Label46.TabIndex = 273
        Me.Label46.Text = "Observaciones"
        '
        'tSTR_OBS
        '
        Me.tSTR_OBS.AcceptsReturn = True
        Me.tSTR_OBS.AcceptsTab = True
        Me.tSTR_OBS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSTR_OBS.Location = New System.Drawing.Point(145, 323)
        Me.tSTR_OBS.Multiline = True
        Me.tSTR_OBS.Name = "tSTR_OBS"
        Me.tSTR_OBS.Size = New System.Drawing.Size(432, 43)
        Me.tSTR_OBS.TabIndex = 9
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.Location = New System.Drawing.Point(145, 296)
        Me.tCUEN_CONT.MaxLength = 28
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 21)
        Me.tCUEN_CONT.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "Cuenta contable"
        '
        'frmDescOperadorAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 399)
        Me.Controls.Add(Me.tCUEN_CONT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.tSTR_OBS)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tIMPORTE)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtFormaDesc)
        Me.Controls.Add(Me.btnFormaDesc)
        Me.Controls.Add(Me.tCVE_FOR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtTipoDesc)
        Me.Controls.Add(Me.btnTipoDesc)
        Me.Controls.Add(Me.tCVE_TIP)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LtNumCpto)
        Me.Controls.Add(Me.btnNumCpto)
        Me.Controls.Add(Me.tNUM_CPTO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.btnOper)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tFOLIO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmDescOperadorAE"
        Me.Text = "Descuento operador"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.btnTipoDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFormaDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tFOLIO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents LtTipoDesc As Label
    Friend WithEvents btnTipoDesc As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_TIP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LtNumCpto As Label
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents btnOper As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents LtFormaDesc As Label
    Friend WithEvents btnFormaDesc As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_FOR As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents tIMPORTE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label46 As Label
    Friend WithEvents tSTR_OBS As TextBox
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents Label1 As Label
End Class
