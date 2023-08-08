<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCxPAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCxPAE))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGenConc = New System.Windows.Forms.Button()
        Me.tGEN_CPTO = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chCON_REFER = New System.Windows.Forms.CheckBox()
        Me.chAUTORIZACION = New System.Windows.Forms.CheckBox()
        Me.chES_FMA_PAG = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radAbono = New System.Windows.Forms.RadioButton()
        Me.radCargo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.barSalir.Size = New System.Drawing.Size(456, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 26
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.btnGenConc)
        Me.GroupBox4.Controls.Add(Me.tGEN_CPTO)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 272)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(438, 64)
        Me.GroupBox4.TabIndex = 130
        Me.GroupBox4.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 14)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Genera concepto número"
        '
        'btnGenConc
        '
        Me.btnGenConc.AutoSize = True
        Me.btnGenConc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenConc.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnGenConc.Location = New System.Drawing.Point(270, 24)
        Me.btnGenConc.Name = "btnGenConc"
        Me.btnGenConc.Size = New System.Drawing.Size(24, 23)
        Me.btnGenConc.TabIndex = 126
        Me.btnGenConc.UseVisualStyleBackColor = True
        '
        'tGEN_CPTO
        '
        Me.tGEN_CPTO.AcceptsReturn = True
        Me.tGEN_CPTO.AcceptsTab = True
        Me.tGEN_CPTO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGEN_CPTO.Location = New System.Drawing.Point(161, 25)
        Me.tGEN_CPTO.Name = "tGEN_CPTO"
        Me.tGEN_CPTO.Size = New System.Drawing.Size(110, 21)
        Me.tGEN_CPTO.TabIndex = 125
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chCON_REFER)
        Me.GroupBox3.Controls.Add(Me.chAUTORIZACION)
        Me.GroupBox3.Controls.Add(Me.chES_FMA_PAG)
        Me.GroupBox3.Location = New System.Drawing.Point(128, 169)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(316, 104)
        Me.GroupBox3.TabIndex = 129
        Me.GroupBox3.TabStop = False
        '
        'chCON_REFER
        '
        Me.chCON_REFER.AutoSize = True
        Me.chCON_REFER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chCON_REFER.Location = New System.Drawing.Point(20, 42)
        Me.chCON_REFER.Name = "chCON_REFER"
        Me.chCON_REFER.Size = New System.Drawing.Size(105, 18)
        Me.chCON_REFER.TabIndex = 122
        Me.chCON_REFER.Text = "Con referencia"
        Me.chCON_REFER.UseVisualStyleBackColor = True
        '
        'chAUTORIZACION
        '
        Me.chAUTORIZACION.AutoSize = True
        Me.chAUTORIZACION.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chAUTORIZACION.Location = New System.Drawing.Point(20, 66)
        Me.chAUTORIZACION.Name = "chAUTORIZACION"
        Me.chAUTORIZACION.Size = New System.Drawing.Size(92, 18)
        Me.chAUTORIZACION.TabIndex = 121
        Me.chAUTORIZACION.Text = "Autorización"
        Me.chAUTORIZACION.UseVisualStyleBackColor = True
        '
        'chES_FMA_PAG
        '
        Me.chES_FMA_PAG.AutoSize = True
        Me.chES_FMA_PAG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chES_FMA_PAG.Location = New System.Drawing.Point(20, 19)
        Me.chES_FMA_PAG.Name = "chES_FMA_PAG"
        Me.chES_FMA_PAG.Size = New System.Drawing.Size(122, 18)
        Me.chES_FMA_PAG.TabIndex = 120
        Me.chES_FMA_PAG.Text = "Es forma de pago"
        Me.chES_FMA_PAG.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radAbono)
        Me.GroupBox2.Controls.Add(Me.radCargo)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(112, 103)
        Me.GroupBox2.TabIndex = 128
        Me.GroupBox2.TabStop = False
        '
        'radAbono
        '
        Me.radAbono.AutoSize = True
        Me.radAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAbono.Location = New System.Drawing.Point(23, 65)
        Me.radAbono.Name = "radAbono"
        Me.radAbono.Size = New System.Drawing.Size(61, 18)
        Me.radAbono.TabIndex = 1
        Me.radAbono.TabStop = True
        Me.radAbono.Text = "Abono"
        Me.radAbono.UseVisualStyleBackColor = True
        '
        'radCargo
        '
        Me.radCargo.AutoSize = True
        Me.radCargo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCargo.Location = New System.Drawing.Point(23, 19)
        Me.radCargo.Name = "radCargo"
        Me.radCargo.Size = New System.Drawing.Size(56, 18)
        Me.radCargo.TabIndex = 0
        Me.radCargo.TabStop = True
        Me.radCargo.Text = "Cargo"
        Me.radCargo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tNUM_CPTO)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Controls.Add(Me.tDescr)
        Me.GroupBox1.Controls.Add(Me.tCUEN_CONT)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 113)
        Me.GroupBox1.TabIndex = 127
        Me.GroupBox1.TabStop = False
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(142, 24)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(68, 22)
        Me.tNUM_CPTO.TabIndex = 113
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(68, 59)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(68, 14)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Descripción"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(142, 54)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(289, 22)
        Me.tDescr.TabIndex = 114
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.Location = New System.Drawing.Point(142, 82)
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 22)
        Me.tCUEN_CONT.TabIndex = 117
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 27)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 14)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Número de concepto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Cuenta contable"
        '
        'frmCxPAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 350)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCxPAE"
        Me.ShowInTaskbar = False
        Me.Text = "Conceptos de cuentas por pagar"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnGenConc As Button
    Friend WithEvents tGEN_CPTO As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chCON_REFER As CheckBox
    Friend WithEvents chAUTORIZACION As CheckBox
    Friend WithEvents chES_FMA_PAG As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents radAbono As RadioButton
    Friend WithEvents radCargo As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label1 As Label
End Class
