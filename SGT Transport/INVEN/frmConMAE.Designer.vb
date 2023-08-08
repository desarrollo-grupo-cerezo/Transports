<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConMAE
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
        Me.tCVE_CPTO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.radEntrada = New System.Windows.Forms.RadioButton()
        Me.radSalida = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCPN = New C1.Win.C1Input.C1ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboCPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(402, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 0
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
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
        'tCVE_CPTO
        '
        Me.tCVE_CPTO.AcceptsReturn = True
        Me.tCVE_CPTO.AcceptsTab = True
        Me.tCVE_CPTO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_CPTO.ForeColor = System.Drawing.Color.Black
        Me.tCVE_CPTO.Location = New System.Drawing.Point(102, 36)
        Me.tCVE_CPTO.Name = "tCVE_CPTO"
        Me.tCVE_CPTO.Size = New System.Drawing.Size(86, 21)
        Me.tCVE_CPTO.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_CPTO, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(24, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 13)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "No. concepto"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.ForeColor = System.Drawing.Color.Black
        Me.tDescr.Location = New System.Drawing.Point(102, 92)
        Me.tDescr.MaxLength = 18
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(234, 21)
        Me.tDescr.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tDescr, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(33, 95)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(63, 13)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Descripción"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'radEntrada
        '
        Me.radEntrada.AutoSize = True
        Me.radEntrada.BackColor = System.Drawing.Color.Transparent
        Me.radEntrada.Checked = True
        Me.radEntrada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radEntrada.Location = New System.Drawing.Point(26, 27)
        Me.radEntrada.Name = "radEntrada"
        Me.radEntrada.Size = New System.Drawing.Size(62, 17)
        Me.radEntrada.TabIndex = 0
        Me.radEntrada.TabStop = True
        Me.radEntrada.Text = "Entrada"
        Me.C1ThemeController1.SetTheme(Me.radEntrada, "Office2010Blue")
        Me.radEntrada.UseVisualStyleBackColor = False
        '
        'radSalida
        '
        Me.radSalida.AutoSize = True
        Me.radSalida.BackColor = System.Drawing.Color.Transparent
        Me.radSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radSalida.Location = New System.Drawing.Point(240, 27)
        Me.radSalida.Name = "radSalida"
        Me.radSalida.Size = New System.Drawing.Size(54, 17)
        Me.radSalida.TabIndex = 1
        Me.radSalida.Text = "Salida"
        Me.C1ThemeController1.SetTheme(Me.radSalida, "Office2010Blue")
        Me.radSalida.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.radEntrada)
        Me.GroupBox1.Controls.Add(Me.radSalida)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 62)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de movimiento"
        Me.C1ThemeController1.SetTheme(Me.GroupBox1, "Office2010Blue")
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.cboCPN)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tCUEN_CONT)
        Me.GroupBox2.Controls.Add(Me.tCVE_CPTO)
        Me.GroupBox2.Controls.Add(Me.Nombre)
        Me.GroupBox2.Controls.Add(Me.tDescr)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(18, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 195)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox2, "Office2010Blue")
        '
        'cboCPN
        '
        Me.cboCPN.AllowSpinLoop = False
        Me.cboCPN.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboCPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboCPN.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboCPN.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboCPN.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboCPN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCPN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboCPN.GapHeight = 0
        Me.cboCPN.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboCPN.ItemsDisplayMember = ""
        Me.cboCPN.ItemsValueMember = ""
        Me.cboCPN.Location = New System.Drawing.Point(102, 146)
        Me.cboCPN.Name = "cboCPN"
        Me.cboCPN.Size = New System.Drawing.Size(163, 20)
        Me.cboCPN.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboCPN.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboCPN.TabIndex = 4
        Me.cboCPN.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboCPN, "Office2010Blue")
        Me.cboCPN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Asociado a"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Cuenta contable"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.ForeColor = System.Drawing.Color.Black
        Me.tCUEN_CONT.Location = New System.Drawing.Point(102, 119)
        Me.tCUEN_CONT.MaxLength = 28
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(234, 21)
        Me.tCUEN_CONT.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tCUEN_CONT, "Office2010Blue")
        '
        'frmConMAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 348)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConMAE"
        Me.Text = "Conceptos de movimiento al inventario"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cboCPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_CPTO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents radEntrada As RadioButton
    Friend WithEvents radSalida As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents cboCPN As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
