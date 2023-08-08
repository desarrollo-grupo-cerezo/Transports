<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDeduccionesAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeduccionesAE))
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCVE_DED = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCTA_CONTABLE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(152, 114)
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(270, 22)
        Me.TDESCR.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(67, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 544
        Me.Label5.Text = "Descripción"
        '
        'TCVE_DED
        '
        Me.TCVE_DED.AcceptsReturn = True
        Me.TCVE_DED.AcceptsTab = True
        Me.TCVE_DED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DED.Location = New System.Drawing.Point(152, 84)
        Me.TCVE_DED.Name = "TCVE_DED"
        Me.TCVE_DED.Size = New System.Drawing.Size(50, 22)
        Me.TCVE_DED.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 543
        Me.Label1.Text = "Clave"
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.MnuSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Padding = New System.Windows.Forms.Padding(1, 1, 0, 1)
        Me.BarraMenu.Size = New System.Drawing.Size(484, 53)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 545
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuSalir
        '
        Me.MnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MnuSalir.ForeColor = System.Drawing.Color.Black
        Me.MnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.MnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.MnuSalir.Text = "Salir"
        Me.MnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TCTA_CONTABLE
        '
        Me.TCTA_CONTABLE.AcceptsReturn = True
        Me.TCTA_CONTABLE.AcceptsTab = True
        Me.TCTA_CONTABLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTA_CONTABLE.Location = New System.Drawing.Point(152, 144)
        Me.TCTA_CONTABLE.Name = "TCTA_CONTABLE"
        Me.TCTA_CONTABLE.Size = New System.Drawing.Size(270, 22)
        Me.TCTA_CONTABLE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 547
        Me.Label2.Text = "Cuenta contable"
        '
        'frmDeduccionesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 219)
        Me.Controls.Add(Me.TCTA_CONTABLE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TCVE_DED)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeduccionesAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura deducción"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TCVE_DED As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents MnuSalir As ToolStripMenuItem
    Friend WithEvents TCTA_CONTABLE As TextBox
    Friend WithEvents Label2 As Label
End Class
