<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatusLlantasAE
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
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tClave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(547, 55)
        Me.barSalir.TabIndex = 4
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Location = New System.Drawing.Point(103, 136)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(330, 20)
        Me.tDescr.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Descripción"
        '
        'tClave
        '
        Me.tClave.AcceptsReturn = True
        Me.tClave.AcceptsTab = True
        Me.tClave.Location = New System.Drawing.Point(103, 94)
        Me.tClave.Name = "tClave"
        Me.tClave.Size = New System.Drawing.Size(100, 20)
        Me.tClave.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Clave"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'frmStatusLlantasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 273)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tClave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmStatusLlantasAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStatusLlantasAE"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
End Class
