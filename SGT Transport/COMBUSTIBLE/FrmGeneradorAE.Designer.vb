<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGeneradorAE
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeneradorAE))
        Me.TCVE_GEN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCVE_GEN
        '
        Me.TCVE_GEN.AcceptsReturn = True
        Me.TCVE_GEN.AcceptsTab = True
        Me.TCVE_GEN.BackColor = System.Drawing.Color.White
        Me.TCVE_GEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_GEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_GEN.ForeColor = System.Drawing.Color.Black
        Me.TCVE_GEN.Location = New System.Drawing.Point(122, 99)
        Me.TCVE_GEN.Name = "TCVE_GEN"
        Me.TCVE_GEN.Size = New System.Drawing.Size(110, 22)
        Me.TCVE_GEN.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(73, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Clave"
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(425, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 100
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.BackColor = System.Drawing.Color.White
        Me.TDESCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.ForeColor = System.Drawing.Color.Black
        Me.TDESCR.Location = New System.Drawing.Point(122, 127)
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(270, 22)
        Me.TDESCR.TabIndex = 97
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(36, 129)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(79, 16)
        Me.Nombre.TabIndex = 99
        Me.Nombre.Text = "Descripcíon"
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
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FrmGeneradorAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 196)
        Me.Controls.Add(Me.TCVE_GEN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.Nombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGeneradorAE"
        Me.ShowInTaskbar = False
        Me.Text = "Generador"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TCVE_GEN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Nombre As Label
End Class
