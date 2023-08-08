<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSeriesAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeriesAE))
        Me.TFOLIOHASTA = New System.Windows.Forms.TextBox()
        Me.tCORREO = New System.Windows.Forms.Label()
        Me.TSERIE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TFOLIODESDE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TULT_DOC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TTIP_DOC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TFOLIOHASTA
        '
        Me.TFOLIOHASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFOLIOHASTA.Location = New System.Drawing.Point(151, 169)
        Me.TFOLIOHASTA.Name = "TFOLIOHASTA"
        Me.TFOLIOHASTA.Size = New System.Drawing.Size(97, 22)
        Me.TFOLIOHASTA.TabIndex = 3
        '
        'tCORREO
        '
        Me.tCORREO.AutoSize = True
        Me.tCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREO.Location = New System.Drawing.Point(64, 174)
        Me.tCORREO.Name = "tCORREO"
        Me.tCORREO.Size = New System.Drawing.Size(80, 16)
        Me.tCORREO.TabIndex = 97
        Me.tCORREO.Text = "Folios hasta"
        '
        'TSERIE
        '
        Me.TSERIE.AcceptsReturn = True
        Me.TSERIE.AcceptsTab = True
        Me.TSERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSERIE.Location = New System.Drawing.Point(151, 113)
        Me.TSERIE.Name = "TSERIE"
        Me.TSERIE.Size = New System.Drawing.Size(61, 22)
        Me.TSERIE.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(105, 115)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 16)
        Me.Label27.TabIndex = 96
        Me.Label27.Text = "Serie"
        '
        'TFOLIODESDE
        '
        Me.TFOLIODESDE.AcceptsReturn = True
        Me.TFOLIODESDE.AcceptsTab = True
        Me.TFOLIODESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFOLIODESDE.Location = New System.Drawing.Point(151, 141)
        Me.TFOLIODESDE.Name = "TFOLIODESDE"
        Me.TFOLIODESDE.Size = New System.Drawing.Size(97, 22)
        Me.TFOLIODESDE.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(58, 147)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(86, 16)
        Me.Nombre.TabIndex = 95
        Me.Nombre.Text = "Folios desde"
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(328, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 5
        Me.BarraMenu.Text = "MenuStrip1"
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
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TULT_DOC
        '
        Me.TULT_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TULT_DOC.Location = New System.Drawing.Point(151, 197)
        Me.TULT_DOC.Name = "TULT_DOC"
        Me.TULT_DOC.Size = New System.Drawing.Size(97, 22)
        Me.TULT_DOC.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Ultimo documento"
        '
        'TTIP_DOC
        '
        Me.TTIP_DOC.AcceptsReturn = True
        Me.TTIP_DOC.AcceptsTab = True
        Me.TTIP_DOC.Enabled = False
        Me.TTIP_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIP_DOC.Location = New System.Drawing.Point(151, 85)
        Me.TTIP_DOC.Name = "TTIP_DOC"
        Me.TTIP_DOC.Size = New System.Drawing.Size(61, 22)
        Me.TTIP_DOC.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(80, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Tipo doc."
        '
        'frmSeriesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 253)
        Me.Controls.Add(Me.TTIP_DOC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TULT_DOC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TFOLIOHASTA)
        Me.Controls.Add(Me.tCORREO)
        Me.Controls.Add(Me.TSERIE)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TFOLIODESDE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeriesAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Series"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TFOLIOHASTA As TextBox
    Friend WithEvents tCORREO As Label
    Friend WithEvents TSERIE As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TFOLIODESDE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents TULT_DOC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TTIP_DOC As TextBox
    Friend WithEvents Label2 As Label
End Class
