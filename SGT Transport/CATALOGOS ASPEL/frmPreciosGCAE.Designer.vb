<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPreciosGCAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreciosGCAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_PRECIO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
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
        Me.barSalir.Size = New System.Drawing.Size(417, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 113
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
        'tCVE_PRECIO
        '
        Me.tCVE_PRECIO.AcceptsReturn = True
        Me.tCVE_PRECIO.AcceptsTab = True
        Me.tCVE_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PRECIO.Location = New System.Drawing.Point(98, 86)
        Me.tCVE_PRECIO.Name = "tCVE_PRECIO"
        Me.tCVE_PRECIO.Size = New System.Drawing.Size(43, 22)
        Me.tCVE_PRECIO.TabIndex = 114
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(50, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 117
        Me.Label27.Text = "Clave"
        '
        'tDESCRIPCION
        '
        Me.tDESCRIPCION.AcceptsReturn = True
        Me.tDESCRIPCION.AcceptsTab = True
        Me.tDESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESCRIPCION.Location = New System.Drawing.Point(98, 116)
        Me.tDESCRIPCION.MaxLength = 25
        Me.tDESCRIPCION.Name = "tDESCRIPCION"
        Me.tDESCRIPCION.Size = New System.Drawing.Size(289, 22)
        Me.tDESCRIPCION.TabIndex = 115
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(36, 119)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 116
        Me.Nombre.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'FrmPreciosGCAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 173)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tCVE_PRECIO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDESCRIPCION)
        Me.Controls.Add(Me.Nombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPreciosGCAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio refacción"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_PRECIO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDESCRIPCION As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
End Class
