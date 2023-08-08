<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVendAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_VEND = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCORREOE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCOMI = New C1.Win.C1Input.C1NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tCLASIFIC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.tCOMI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(574, 55)
        Me.barSalir.TabIndex = 6
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
        'tCVE_VEND
        '
        Me.tCVE_VEND.AcceptsReturn = True
        Me.tCVE_VEND.AcceptsTab = True
        Me.tCVE_VEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VEND.Location = New System.Drawing.Point(148, 81)
        Me.tCVE_VEND.Name = "tCVE_VEND"
        Me.tCVE_VEND.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_VEND.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(100, 84)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 173
        Me.Label27.Text = "Clave"
        '
        'tNOMBRE
        '
        Me.tNOMBRE.AcceptsReturn = True
        Me.tNOMBRE.AcceptsTab = True
        Me.tNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOMBRE.Location = New System.Drawing.Point(148, 126)
        Me.tNOMBRE.Name = "tNOMBRE"
        Me.tNOMBRE.Size = New System.Drawing.Size(414, 22)
        Me.tNOMBRE.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(86, 129)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 172
        Me.Nombre.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tCORREOE
        '
        Me.tCORREOE.AcceptsReturn = True
        Me.tCORREOE.AcceptsTab = True
        Me.tCORREOE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREOE.Location = New System.Drawing.Point(148, 198)
        Me.tCORREOE.Name = "tCORREOE"
        Me.tCORREOE.Size = New System.Drawing.Size(414, 22)
        Me.tCORREOE.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Correo electrónico"
        '
        'tCOMI
        '
        Me.tCOMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tCOMI.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tCOMI.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tCOMI.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tCOMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOMI.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tCOMI.Location = New System.Drawing.Point(148, 165)
        Me.tCOMI.Name = "tCOMI"
        Me.tCOMI.Size = New System.Drawing.Size(98, 20)
        Me.tCOMI.TabIndex = 3
        Me.tCOMI.Tag = Nothing
        Me.tCOMI.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "%Comisión"
        '
        'tCLASIFIC
        '
        Me.tCLASIFIC.AcceptsReturn = True
        Me.tCLASIFIC.AcceptsTab = True
        Me.tCLASIFIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLASIFIC.Location = New System.Drawing.Point(452, 162)
        Me.tCLASIFIC.Name = "tCLASIFIC"
        Me.tCLASIFIC.Size = New System.Drawing.Size(110, 22)
        Me.tCLASIFIC.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(363, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Clasificación"
        '
        'frmVendAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 297)
        Me.Controls.Add(Me.tCLASIFIC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCOMI)
        Me.Controls.Add(Me.tCORREOE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_VEND)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVendAE"
        Me.Text = "Vendedores"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tCOMI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tCVE_VEND As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tNOMBRE As System.Windows.Forms.TextBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCORREOE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tCOMI As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tCLASIFIC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
