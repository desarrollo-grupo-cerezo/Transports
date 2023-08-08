<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGrupoSanguineoAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrupoSanguineoAE))
        Me.BarSalir = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_GRUSAN = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarSalir
        '
        Me.BarSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.BarSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.MnuSalir})
        Me.BarSalir.Location = New System.Drawing.Point(0, 0)
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(528, 55)
        Me.BarSalir.Stretch = False
        Me.BarSalir.TabIndex = 3
        Me.BarSalir.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuSalir
        '
        Me.MnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MnuSalir.ForeColor = System.Drawing.Color.Black
        Me.MnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.MnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.MnuSalir.Text = "Salir"
        Me.MnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_GRUSAN
        '
        Me.tCVE_GRUSAN.AcceptsReturn = True
        Me.tCVE_GRUSAN.AcceptsTab = True
        Me.tCVE_GRUSAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GRUSAN.Location = New System.Drawing.Point(92, 87)
        Me.tCVE_GRUSAN.Name = "tCVE_GRUSAN"
        Me.tCVE_GRUSAN.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_GRUSAN.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(45, 90)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 123
        Me.Label27.Text = "Clave"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(92, 118)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(414, 22)
        Me.tDescr.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(31, 121)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 122
        Me.Nombre.Text = "Nombre"
        '
        'frmGrupoSanguineoAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 195)
        Me.Controls.Add(Me.tCVE_GRUSAN)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGrupoSanguineoAE"
        Me.Text = "Grupo sangineo"
        Me.BarSalir.ResumeLayout(False)
        Me.BarSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents BarGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tCVE_GRUSAN As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tDescr As System.Windows.Forms.TextBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
End Class
