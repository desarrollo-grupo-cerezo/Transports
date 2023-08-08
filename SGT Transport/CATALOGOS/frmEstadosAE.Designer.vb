<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstadosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadosAE))
        Me.tNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.TCLAVE_SAT_EST = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCLAVE_SAT_PAIS = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TPAIS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'tNOMBRE
        '
        Me.tNOMBRE.AcceptsReturn = True
        Me.tNOMBRE.AcceptsTab = True
        Me.tNOMBRE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOMBRE.Location = New System.Drawing.Point(90, 125)
        Me.tNOMBRE.Name = "tNOMBRE"
        Me.tNOMBRE.Size = New System.Drawing.Size(270, 22)
        Me.tNOMBRE.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(27, 127)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(50, 16)
        Me.Nombre.TabIndex = 87
        Me.Nombre.Text = "Estado"
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(530, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 89
        Me.barSalir.Text = "MenuStrip1"
        '
        'tID
        '
        Me.tID.AcceptsReturn = True
        Me.tID.AcceptsTab = True
        Me.tID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tID.Location = New System.Drawing.Point(90, 97)
        Me.tID.Name = "tID"
        Me.tID.Size = New System.Drawing.Size(110, 22)
        Me.tID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Clave"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'TCLAVE_SAT_EST
        '
        Me.TCLAVE_SAT_EST.AcceptsReturn = True
        Me.TCLAVE_SAT_EST.AcceptsTab = True
        Me.TCLAVE_SAT_EST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE_SAT_EST.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE_SAT_EST.Location = New System.Drawing.Point(444, 127)
        Me.TCLAVE_SAT_EST.Name = "TCLAVE_SAT_EST"
        Me.TCLAVE_SAT_EST.Size = New System.Drawing.Size(62, 22)
        Me.TCLAVE_SAT_EST.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Clave SAT"
        '
        'TCLAVE_SAT_PAIS
        '
        Me.TCLAVE_SAT_PAIS.AcceptsReturn = True
        Me.TCLAVE_SAT_PAIS.AcceptsTab = True
        Me.TCLAVE_SAT_PAIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE_SAT_PAIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE_SAT_PAIS.Location = New System.Drawing.Point(298, 153)
        Me.TCLAVE_SAT_PAIS.Name = "TCLAVE_SAT_PAIS"
        Me.TCLAVE_SAT_PAIS.Size = New System.Drawing.Size(62, 22)
        Me.TCLAVE_SAT_PAIS.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Clave SAT"
        '
        'TPAIS
        '
        Me.TPAIS.AcceptsReturn = True
        Me.TPAIS.AcceptsTab = True
        Me.TPAIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPAIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TPAIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPAIS.Location = New System.Drawing.Point(90, 153)
        Me.TPAIS.Name = "TPAIS"
        Me.TPAIS.Size = New System.Drawing.Size(110, 22)
        Me.TPAIS.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 16)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Pais"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
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
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmEstadosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 234)
        Me.Controls.Add(Me.TCLAVE_SAT_PAIS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TPAIS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TCLAVE_SAT_EST)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstadosAE"
        Me.ShowInTaskbar = False
        Me.Text = "Estados"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tNOMBRE As System.Windows.Forms.TextBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents TCLAVE_SAT_EST As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TCLAVE_SAT_PAIS As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TPAIS As TextBox
    Friend WithEvents Label4 As Label
End Class
