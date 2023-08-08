<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLlantasConmAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLlantasConmAE))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboStatus = New C1.Win.C1Input.C1ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCVE_CPTO = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.TDescr = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadEntrada = New System.Windows.Forms.RadioButton()
        Me.RadSalida = New System.Windows.Forms.RadioButton()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboStatus)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TCVE_CPTO)
        Me.GroupBox2.Controls.Add(Me.Nombre)
        Me.GroupBox2.Controls.Add(Me.TDescr)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 144)
        Me.GroupBox2.TabIndex = 125
        Me.GroupBox2.TabStop = False
        '
        'CboStatus
        '
        Me.CboStatus.AllowSpinLoop = False
        Me.CboStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboStatus.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboStatus.GapHeight = 0
        Me.CboStatus.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboStatus.ItemsDisplayMember = ""
        Me.CboStatus.ItemsValueMember = ""
        Me.CboStatus.Location = New System.Drawing.Point(104, 97)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(243, 20)
        Me.CboStatus.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboStatus.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboStatus.TabIndex = 2
        Me.CboStatus.Tag = Nothing
        Me.CboStatus.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Asociado a"
        '
        'TCVE_CPTO
        '
        Me.TCVE_CPTO.AcceptsReturn = True
        Me.TCVE_CPTO.AcceptsTab = True
        Me.TCVE_CPTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CPTO.Location = New System.Drawing.Point(104, 22)
        Me.TCVE_CPTO.Name = "TCVE_CPTO"
        Me.TCVE_CPTO.Size = New System.Drawing.Size(52, 22)
        Me.TCVE_CPTO.TabIndex = 0
        Me.TCVE_CPTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(20, 60)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(79, 16)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Descripción"
        '
        'TDescr
        '
        Me.TDescr.AcceptsReturn = True
        Me.TDescr.AcceptsTab = True
        Me.TDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDescr.Location = New System.Drawing.Point(104, 57)
        Me.TDescr.MaxLength = 35
        Me.TDescr.Name = "TDescr"
        Me.TDescr.Size = New System.Drawing.Size(319, 22)
        Me.TDescr.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 26)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 16)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "No. concepto"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadEntrada)
        Me.GroupBox1.Controls.Add(Me.RadSalida)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 52)
        Me.GroupBox1.TabIndex = 124
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de movimiento"
        '
        'RadEntrada
        '
        Me.RadEntrada.AutoSize = True
        Me.RadEntrada.Checked = True
        Me.RadEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadEntrada.Location = New System.Drawing.Point(80, 22)
        Me.RadEntrada.Name = "RadEntrada"
        Me.RadEntrada.Size = New System.Drawing.Size(76, 21)
        Me.RadEntrada.TabIndex = 0
        Me.RadEntrada.TabStop = True
        Me.RadEntrada.Text = "Entrada"
        Me.RadEntrada.UseVisualStyleBackColor = False
        '
        'RadSalida
        '
        Me.RadSalida.AutoSize = True
        Me.RadSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSalida.Location = New System.Drawing.Point(271, 22)
        Me.RadSalida.Name = "RadSalida"
        Me.RadSalida.Size = New System.Drawing.Size(65, 21)
        Me.RadSalida.TabIndex = 1
        Me.RadSalida.Text = "Salida"
        Me.RadSalida.UseVisualStyleBackColor = False
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(453, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 123
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
        'FrmLlantasConmAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 277)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLlantasConmAE"
        Me.ShowInTaskbar = False
        Me.Text = "Concepto llanta"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CboStatus As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TCVE_CPTO As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents TDescr As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadEntrada As RadioButton
    Friend WithEvents RadSalida As RadioButton
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
End Class
