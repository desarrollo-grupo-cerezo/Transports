<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCtaBanOrdAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCtaBanOrdAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCTA_BANCARIA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TRFC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BtnCtaBan = New System.Windows.Forms.Button()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCLABE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(583, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 15
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
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
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TCTA_BANCARIA
        '
        Me.TCTA_BANCARIA.AcceptsReturn = True
        Me.TCTA_BANCARIA.AcceptsTab = True
        Me.TCTA_BANCARIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTA_BANCARIA.Location = New System.Drawing.Point(130, 94)
        Me.TCTA_BANCARIA.MaxLength = 60
        Me.TCTA_BANCARIA.Name = "TCTA_BANCARIA"
        Me.TCTA_BANCARIA.Size = New System.Drawing.Size(193, 22)
        Me.TCTA_BANCARIA.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "Cuenta bancaria"
        '
        'TRFC
        '
        Me.TRFC.AcceptsReturn = True
        Me.TRFC.AcceptsTab = True
        Me.TRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFC.Location = New System.Drawing.Point(130, 148)
        Me.TRFC.MaxLength = 20
        Me.TRFC.Name = "TRFC"
        Me.TRFC.Size = New System.Drawing.Size(168, 22)
        Me.TRFC.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(83, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "R.F.C."
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(130, 175)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(62, 22)
        Me.TCLIENTE.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(42, 177)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 16)
        Me.Label27.TabIndex = 144
        Me.Label27.Text = "Clave cliente"
        '
        'TNOMBRE
        '
        Me.TNOMBRE.AcceptsReturn = True
        Me.TNOMBRE.AcceptsTab = True
        Me.TNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRE.Location = New System.Drawing.Point(130, 121)
        Me.TNOMBRE.MaxLength = 90
        Me.TNOMBRE.Name = "TNOMBRE"
        Me.TNOMBRE.Size = New System.Drawing.Size(414, 22)
        Me.TNOMBRE.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(70, 123)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 143
        Me.Nombre.Text = "Nombre"
        '
        'BtnCtaBan
        '
        Me.BtnCtaBan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCtaBan.BackColor = System.Drawing.Color.Transparent
        Me.BtnCtaBan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCtaBan.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCtaBan.Location = New System.Drawing.Point(324, 92)
        Me.BtnCtaBan.Name = "BtnCtaBan"
        Me.BtnCtaBan.Size = New System.Drawing.Size(25, 25)
        Me.BtnCtaBan.TabIndex = 441
        Me.BtnCtaBan.UseVisualStyleBackColor = True
        Me.BtnCtaBan.Visible = False
        '
        'BtnCliente
        '
        Me.BtnCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCliente.BackColor = System.Drawing.Color.Transparent
        Me.BtnCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCliente.Location = New System.Drawing.Point(192, 174)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(24, 24)
        Me.BtnCliente.TabIndex = 442
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(130, 202)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(391, 20)
        Me.LtNombre.TabIndex = 443
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 444
        Me.Label4.Text = "Razón social"
        '
        'TCLABE
        '
        Me.TCLABE.AcceptsReturn = True
        Me.TCLABE.AcceptsTab = True
        Me.TCLABE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLABE.Location = New System.Drawing.Point(130, 234)
        Me.TCLABE.MaxLength = 20
        Me.TCLABE.Name = "TCLABE"
        Me.TCLABE.Size = New System.Drawing.Size(219, 22)
        Me.TCLABE.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 446
        Me.Label1.Text = "CLABE"
        '
        'FrmCtaBanOrdAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 287)
        Me.Controls.Add(Me.TCLABE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.BtnCtaBan)
        Me.Controls.Add(Me.TCTA_BANCARIA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TRFC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TCLIENTE)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCtaBanOrdAE"
        Me.ShowInTaskbar = False
        Me.Text = "Cuenta bancaria ordenante"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents TCTA_BANCARIA As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TRFC As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TNOMBRE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents BtnCtaBan As Button
    Friend WithEvents BtnCliente As Button
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TCLABE As TextBox
    Friend WithEvents Label1 As Label
End Class
