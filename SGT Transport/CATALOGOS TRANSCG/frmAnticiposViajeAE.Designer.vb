<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnticiposViajeAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnticiposViajeAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_ANTVI = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LtViaje = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtAutoriza = New System.Windows.Forms.Label()
        Me.tCVE_AUT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtNumCpto = New System.Windows.Forms.Label()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tIMPORTE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.tCVE_OBS = New System.Windows.Forms.TextBox()
        Me.btnOper = New C1.Win.C1Input.C1Button()
        Me.btnViaje = New C1.Win.C1Input.C1Button()
        Me.btnAutoriza = New C1.Win.C1Input.C1Button()
        Me.barSalir.SuspendLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(564, 55)
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
        'tCVE_ANTVI
        '
        Me.tCVE_ANTVI.AcceptsReturn = True
        Me.tCVE_ANTVI.AcceptsTab = True
        Me.tCVE_ANTVI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ANTVI.Location = New System.Drawing.Point(107, 68)
        Me.tCVE_ANTVI.Name = "tCVE_ANTVI"
        Me.tCVE_ANTVI.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_ANTVI.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(68, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Clave"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tFECHA
        '
        Me.tFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFECHA.Location = New System.Drawing.Point(107, 93)
        Me.tFECHA.Name = "tFECHA"
        Me.tFECHA.Size = New System.Drawing.Size(147, 20)
        Me.tFECHA.TabIndex = 1
        Me.tFECHA.Tag = Nothing
        Me.tFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(65, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 146
        Me.Label18.Text = "Fecha"
        '
        'LtViaje
        '
        Me.LtViaje.BackColor = System.Drawing.Color.Transparent
        Me.LtViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtViaje.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtViaje.Location = New System.Drawing.Point(203, 145)
        Me.LtViaje.Name = "LtViaje"
        Me.LtViaje.Size = New System.Drawing.Size(333, 20)
        Me.LtViaje.TabIndex = 154
        Me.LtViaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.Transparent
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(203, 119)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(333, 20)
        Me.LtOper.TabIndex = 153
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(107, 118)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_OPER.TabIndex = 2
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(107, 144)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_VIAJE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(72, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Viaje"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(51, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Operador"
        '
        'LtAutoriza
        '
        Me.LtAutoriza.BackColor = System.Drawing.Color.Transparent
        Me.LtAutoriza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtAutoriza.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAutoriza.Location = New System.Drawing.Point(203, 171)
        Me.LtAutoriza.Name = "LtAutoriza"
        Me.LtAutoriza.Size = New System.Drawing.Size(333, 20)
        Me.LtAutoriza.TabIndex = 158
        Me.LtAutoriza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_AUT
        '
        Me.tCVE_AUT.AcceptsReturn = True
        Me.tCVE_AUT.AcceptsTab = True
        Me.tCVE_AUT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_AUT.Location = New System.Drawing.Point(107, 170)
        Me.tCVE_AUT.Name = "tCVE_AUT"
        Me.tCVE_AUT.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_AUT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(57, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Autoriza"
        '
        'LtNumCpto
        '
        Me.LtNumCpto.BackColor = System.Drawing.Color.Transparent
        Me.LtNumCpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumCpto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumCpto.Location = New System.Drawing.Point(203, 228)
        Me.LtNumCpto.Name = "LtNumCpto"
        Me.LtNumCpto.Size = New System.Drawing.Size(333, 20)
        Me.LtNumCpto.TabIndex = 162
        Me.LtNumCpto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNumCpto
        '
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(176, 227)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(24, 21)
        Me.btnNumCpto.TabIndex = 161
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(107, 226)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(69, 22)
        Me.tNUM_CPTO.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(49, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 160
        Me.Label6.Text = "Concepto"
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
        Me.tIMPORTE.Location = New System.Drawing.Point(107, 199)
        Me.tIMPORTE.Name = "tIMPORTE"
        Me.tIMPORTE.Size = New System.Drawing.Size(161, 20)
        Me.tIMPORTE.TabIndex = 5
        Me.tIMPORTE.Tag = Nothing
        Me.tIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(60, 202)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 13)
        Me.Label26.TabIndex = 265
        Me.Label26.Text = "Importe"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Location = New System.Drawing.Point(24, 257)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 13)
        Me.Label46.TabIndex = 267
        Me.Label46.Text = "Observaciones"
        '
        'tCVE_OBS
        '
        Me.tCVE_OBS.AcceptsReturn = True
        Me.tCVE_OBS.AcceptsTab = True
        Me.tCVE_OBS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OBS.Location = New System.Drawing.Point(108, 251)
        Me.tCVE_OBS.Multiline = True
        Me.tCVE_OBS.Name = "tCVE_OBS"
        Me.tCVE_OBS.Size = New System.Drawing.Size(432, 43)
        Me.tCVE_OBS.TabIndex = 7
        '
        'btnOper
        '
        Me.btnOper.Image = CType(resources.GetObject("btnOper.Image"), System.Drawing.Image)
        Me.btnOper.Location = New System.Drawing.Point(176, 119)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 21)
        Me.btnOper.TabIndex = 151
        Me.btnOper.UseVisualStyleBackColor = True
        Me.btnOper.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnViaje
        '
        Me.btnViaje.Image = CType(resources.GetObject("btnViaje.Image"), System.Drawing.Image)
        Me.btnViaje.Location = New System.Drawing.Point(176, 145)
        Me.btnViaje.Name = "btnViaje"
        Me.btnViaje.Size = New System.Drawing.Size(24, 21)
        Me.btnViaje.TabIndex = 152
        Me.btnViaje.UseVisualStyleBackColor = True
        Me.btnViaje.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnViaje.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Image = CType(resources.GetObject("btnAutoriza.Image"), System.Drawing.Image)
        Me.btnAutoriza.Location = New System.Drawing.Point(177, 171)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(23, 21)
        Me.btnAutoriza.TabIndex = 157
        Me.btnAutoriza.UseVisualStyleBackColor = True
        Me.btnAutoriza.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnAutoriza.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'frmAnticiposViajeAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 335)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.tCVE_OBS)
        Me.Controls.Add(Me.tIMPORTE)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.LtNumCpto)
        Me.Controls.Add(Me.btnNumCpto)
        Me.Controls.Add(Me.tNUM_CPTO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtAutoriza)
        Me.Controls.Add(Me.btnAutoriza)
        Me.Controls.Add(Me.tCVE_AUT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtViaje)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.btnViaje)
        Me.Controls.Add(Me.btnOper)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.tCVE_VIAJE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tFECHA)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tCVE_ANTVI)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAnticiposViajeAE"
        Me.Text = "frmAnticiposViajeAE"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_ANTVI As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tFECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label18 As Label
    Friend WithEvents LtViaje As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtAutoriza As Label
    Friend WithEvents tCVE_AUT As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LtNumCpto As Label
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tIMPORTE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label26 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents tCVE_OBS As TextBox
    Friend WithEvents btnOper As C1.Win.C1Input.C1Button
    Friend WithEvents btnViaje As C1.Win.C1Input.C1Button
    Friend WithEvents btnAutoriza As C1.Win.C1Input.C1Button
End Class
