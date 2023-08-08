<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPolizaSeguroAE
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
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tIDPoliza = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tFolio = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.tTIPO_POL = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnTipoPol = New System.Windows.Forms.Button()
        Me.LtTipoPol = New System.Windows.Forms.Label()
        Me.tCVE_ASE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEquipoAseg = New System.Windows.Forms.Button()
        Me.LtEquiAse = New System.Windows.Forms.Label()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnProv = New System.Windows.Forms.Button()
        Me.LtProv = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tCOSTO = New C1.Win.C1Input.C1NumericEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCOBERTURA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.barSalir.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCOSTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(642, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 10
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
        'tIDPoliza
        '
        Me.tIDPoliza.AcceptsReturn = True
        Me.tIDPoliza.AcceptsTab = True
        Me.tIDPoliza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIDPoliza.Location = New System.Drawing.Point(117, 75)
        Me.tIDPoliza.Name = "tIDPoliza"
        Me.tIDPoliza.Size = New System.Drawing.Size(92, 21)
        Me.tIDPoliza.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(64, 78)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(49, 13)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "ID Poliza"
        '
        'tFolio
        '
        Me.tFolio.AcceptsReturn = True
        Me.tFolio.AcceptsTab = True
        Me.tFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFolio.Location = New System.Drawing.Point(117, 102)
        Me.tFolio.Name = "tFolio"
        Me.tFolio.Size = New System.Drawing.Size(92, 21)
        Me.tFolio.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(84, 105)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(29, 13)
        Me.Nombre.TabIndex = 87
        Me.Nombre.Text = "Folio"
        '
        'tTIPO_POL
        '
        Me.tTIPO_POL.AcceptsReturn = True
        Me.tTIPO_POL.AcceptsTab = True
        Me.tTIPO_POL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTIPO_POL.Location = New System.Drawing.Point(117, 154)
        Me.tTIPO_POL.Name = "tTIPO_POL"
        Me.tTIPO_POL.Size = New System.Drawing.Size(69, 21)
        Me.tTIPO_POL.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(41, 156)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 13)
        Me.Label31.TabIndex = 265
        Me.Label31.Text = "Tipo de poliza"
        '
        'btnTipoPol
        '
        Me.btnTipoPol.AutoSize = True
        Me.btnTipoPol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTipoPol.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTipoPol.Location = New System.Drawing.Point(185, 153)
        Me.btnTipoPol.Name = "btnTipoPol"
        Me.btnTipoPol.Size = New System.Drawing.Size(24, 23)
        Me.btnTipoPol.TabIndex = 267
        Me.btnTipoPol.UseVisualStyleBackColor = True
        '
        'LtTipoPol
        '
        Me.LtTipoPol.BackColor = System.Drawing.Color.LightGray
        Me.LtTipoPol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipoPol.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipoPol.Location = New System.Drawing.Point(210, 155)
        Me.LtTipoPol.Name = "LtTipoPol"
        Me.LtTipoPol.Size = New System.Drawing.Size(254, 20)
        Me.LtTipoPol.TabIndex = 268
        '
        'tCVE_ASE
        '
        Me.tCVE_ASE.AcceptsReturn = True
        Me.tCVE_ASE.AcceptsTab = True
        Me.tCVE_ASE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ASE.Location = New System.Drawing.Point(117, 179)
        Me.tCVE_ASE.Name = "tCVE_ASE"
        Me.tCVE_ASE.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_ASE.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Equipo asegurado"
        '
        'btnEquipoAseg
        '
        Me.btnEquipoAseg.AutoSize = True
        Me.btnEquipoAseg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEquipoAseg.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnEquipoAseg.Location = New System.Drawing.Point(185, 178)
        Me.btnEquipoAseg.Name = "btnEquipoAseg"
        Me.btnEquipoAseg.Size = New System.Drawing.Size(24, 23)
        Me.btnEquipoAseg.TabIndex = 271
        Me.btnEquipoAseg.UseVisualStyleBackColor = True
        '
        'LtEquiAse
        '
        Me.LtEquiAse.BackColor = System.Drawing.Color.LightGray
        Me.LtEquiAse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEquiAse.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEquiAse.Location = New System.Drawing.Point(210, 180)
        Me.LtEquiAse.Name = "LtEquiAse"
        Me.LtEquiAse.Size = New System.Drawing.Size(254, 20)
        Me.LtEquiAse.TabIndex = 272
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.Location = New System.Drawing.Point(117, 204)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_PROV.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 273
        Me.Label3.Text = "Aseguradora"
        '
        'btnProv
        '
        Me.btnProv.AutoSize = True
        Me.btnProv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnProv.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnProv.Location = New System.Drawing.Point(185, 203)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(24, 23)
        Me.btnProv.TabIndex = 275
        Me.btnProv.UseVisualStyleBackColor = True
        '
        'LtProv
        '
        Me.LtProv.BackColor = System.Drawing.Color.LightGray
        Me.LtProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtProv.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtProv.Location = New System.Drawing.Point(210, 205)
        Me.LtProv.Name = "LtProv"
        Me.LtProv.Size = New System.Drawing.Size(254, 20)
        Me.LtProv.TabIndex = 276
        '
        'F2
        '
        Me.F2.AllowSpinLoop = False
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(117, 255)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(170, 19)
        Me.F2.TabIndex = 7
        Me.F2.Tag = Nothing
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 280
        Me.Label6.Text = "Termino"
        '
        'tCOSTO
        '
        Me.tCOSTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tCOSTO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tCOSTO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOSTO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOSTO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tCOSTO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOSTO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tCOSTO.Location = New System.Drawing.Point(117, 280)
        Me.tCOSTO.Name = "tCOSTO"
        Me.tCOSTO.Size = New System.Drawing.Size(134, 18)
        Me.tCOSTO.TabIndex = 8
        Me.tCOSTO.Tag = Nothing
        Me.tCOSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 282
        Me.Label7.Text = "Costo"
        '
        'tCOBERTURA
        '
        Me.tCOBERTURA.AcceptsReturn = True
        Me.tCOBERTURA.AcceptsTab = True
        Me.tCOBERTURA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOBERTURA.Location = New System.Drawing.Point(117, 304)
        Me.tCOBERTURA.Name = "tCOBERTURA"
        Me.tCOBERTURA.Size = New System.Drawing.Size(494, 21)
        Me.tCOBERTURA.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 284
        Me.Label8.Text = "Tipo de cobertura"
        '
        'tFECHA
        '
        Me.tFECHA.AllowSpinLoop = False
        Me.tFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFECHA.Location = New System.Drawing.Point(117, 128)
        Me.tFECHA.Name = "tFECHA"
        Me.tFECHA.Size = New System.Drawing.Size(170, 19)
        Me.tFECHA.TabIndex = 2
        Me.tFECHA.Tag = Nothing
        Me.tFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(46, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 286
        Me.Label9.Text = "Fecha carga"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "Inicio"
        '
        'F1
        '
        Me.F1.AllowSpinLoop = False
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(117, 230)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(170, 19)
        Me.F1.TabIndex = 6
        Me.F1.Tag = Nothing
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'frmPolizaSeguroAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 347)
        Me.Controls.Add(Me.tFECHA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tCOBERTURA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tCOSTO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tCVE_PROV)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.LtProv)
        Me.Controls.Add(Me.tCVE_ASE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEquipoAseg)
        Me.Controls.Add(Me.LtEquiAse)
        Me.Controls.Add(Me.tTIPO_POL)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btnTipoPol)
        Me.Controls.Add(Me.LtTipoPol)
        Me.Controls.Add(Me.tIDPoliza)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tFolio)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmPolizaSeguroAE"
        Me.Text = "Poliza "
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCOSTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tIDPoliza As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tFolio As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents tTIPO_POL As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents btnTipoPol As Button
    Friend WithEvents LtTipoPol As Label
    Friend WithEvents tCVE_ASE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEquipoAseg As Button
    Friend WithEvents LtEquiAse As Label
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnProv As Button
    Friend WithEvents LtProv As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents tCOSTO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents tCOBERTURA As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tFECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Label5 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
End Class
