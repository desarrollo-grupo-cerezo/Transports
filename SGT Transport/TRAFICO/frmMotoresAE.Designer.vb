<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotoresAE
    Inherits System.Windows.Forms.Form

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
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.tCVE_MOT = New System.Windows.Forms.TextBox()
        Me.tMOTOR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Box4 = New System.Windows.Forms.GroupBox()
        Me.radSencillo = New System.Windows.Forms.RadioButton()
        Me.radFull = New System.Windows.Forms.RadioButton()
        Me.RadFullSencillo = New System.Windows.Forms.RadioButton()
        Me.barMenu.SuspendLayout()
        Me.Box4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(75, 94)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 15)
        Me.Label27.TabIndex = 94
        Me.Label27.Text = "Clave"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(40, 148)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(72, 15)
        Me.Nombre.TabIndex = 93
        Me.Nombre.Text = "Descripción"
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(456, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 92
        Me.barMenu.Text = "MenuStrip1"
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
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(115, 145)
        Me.tDescr.MaxLength = 90
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(289, 21)
        Me.tDescr.TabIndex = 2
        '
        'tCVE_MOT
        '
        Me.tCVE_MOT.AcceptsReturn = True
        Me.tCVE_MOT.AcceptsTab = True
        Me.tCVE_MOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_MOT.Location = New System.Drawing.Point(115, 91)
        Me.tCVE_MOT.MaxLength = 10
        Me.tCVE_MOT.Name = "tCVE_MOT"
        Me.tCVE_MOT.Size = New System.Drawing.Size(50, 21)
        Me.tCVE_MOT.TabIndex = 0
        '
        'tMOTOR
        '
        Me.tMOTOR.AcceptsReturn = True
        Me.tMOTOR.AcceptsTab = True
        Me.tMOTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMOTOR.Location = New System.Drawing.Point(115, 118)
        Me.tMOTOR.MaxLength = 90
        Me.tMOTOR.Name = "tMOTOR"
        Me.tMOTOR.Size = New System.Drawing.Size(289, 21)
        Me.tMOTOR.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Motor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Tipo de viaje"
        '
        'Box4
        '
        Me.Box4.BackColor = System.Drawing.Color.Transparent
        Me.Box4.Controls.Add(Me.RadFullSencillo)
        Me.Box4.Controls.Add(Me.radSencillo)
        Me.Box4.Controls.Add(Me.radFull)
        Me.Box4.Location = New System.Drawing.Point(115, 172)
        Me.Box4.Name = "Box4"
        Me.Box4.Size = New System.Drawing.Size(289, 45)
        Me.Box4.TabIndex = 508
        Me.Box4.TabStop = False
        '
        'radSencillo
        '
        Me.radSencillo.AutoSize = True
        Me.radSencillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSencillo.Location = New System.Drawing.Point(89, 18)
        Me.radSencillo.Name = "radSencillo"
        Me.radSencillo.Size = New System.Drawing.Size(69, 19)
        Me.radSencillo.TabIndex = 4
        Me.radSencillo.TabStop = True
        Me.radSencillo.Text = "Sencillo"
        Me.radSencillo.UseVisualStyleBackColor = True
        '
        'radFull
        '
        Me.radFull.AutoSize = True
        Me.radFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radFull.Location = New System.Drawing.Point(17, 18)
        Me.radFull.Name = "radFull"
        Me.radFull.Size = New System.Drawing.Size(45, 19)
        Me.radFull.TabIndex = 3
        Me.radFull.TabStop = True
        Me.radFull.Text = "Full"
        Me.radFull.UseVisualStyleBackColor = True
        '
        'RadFullSencillo
        '
        Me.RadFullSencillo.AutoSize = True
        Me.RadFullSencillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFullSencillo.Location = New System.Drawing.Point(183, 18)
        Me.RadFullSencillo.Name = "RadFullSencillo"
        Me.RadFullSencillo.Size = New System.Drawing.Size(92, 19)
        Me.RadFullSencillo.TabIndex = 5
        Me.RadFullSencillo.TabStop = True
        Me.RadFullSencillo.Text = "Full/Sencillo"
        Me.RadFullSencillo.UseVisualStyleBackColor = True
        '
        'frmMotoresAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 241)
        Me.Controls.Add(Me.Box4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tMOTOR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_MOT)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotoresAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motor"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        Me.Box4.ResumeLayout(False)
        Me.Box4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tDescr As TextBox
    Friend WithEvents tCVE_MOT As TextBox
    Friend WithEvents tMOTOR As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Box4 As GroupBox
    Friend WithEvents RadFullSencillo As RadioButton
    Friend WithEvents radSencillo As RadioButton
    Friend WithEvents radFull As RadioButton
End Class
