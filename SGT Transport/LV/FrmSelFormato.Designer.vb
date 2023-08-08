<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelFormato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelFormato))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TFORMATO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CboFormatos = New C1.Win.C1Input.C1ComboBox()
        Me.BtnFormato = New C1.Win.C1Input.C1Button()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.CboFormatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.ToolStripSeparator1, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(437, 54)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.C1ThemeController1.SetTheme(Me.ToolStrip1, "Office2010Blue")
        '
        'barAceptar
        '
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.Size = New System.Drawing.Size(52, 51)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(17, 227)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Formato"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'TFORMATO
        '
        Me.TFORMATO.AcceptsReturn = True
        Me.TFORMATO.AcceptsTab = True
        Me.TFORMATO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFORMATO.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFORMATO.ForeColor = System.Drawing.Color.Black
        Me.TFORMATO.Location = New System.Drawing.Point(14, 255)
        Me.TFORMATO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TFORMATO.Name = "TFORMATO"
        Me.TFORMATO.Size = New System.Drawing.Size(384, 24)
        Me.TFORMATO.TabIndex = 407
        Me.C1ThemeController1.SetTheme(Me.TFORMATO, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 92)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 17)
        Me.Label1.TabIndex = 409
        Me.Label1.Text = "Seleccione formnato"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CboFormatos
        '
        Me.CboFormatos.AllowSpinLoop = False
        Me.CboFormatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboFormatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboFormatos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboFormatos.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboFormatos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboFormatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFormatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboFormatos.GapHeight = 0
        Me.CboFormatos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboFormatos.ItemsDisplayMember = ""
        Me.CboFormatos.ItemsValueMember = ""
        Me.CboFormatos.Location = New System.Drawing.Point(20, 121)
        Me.CboFormatos.Name = "CboFormatos"
        Me.CboFormatos.Size = New System.Drawing.Size(353, 22)
        Me.CboFormatos.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboFormatos.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboFormatos.TabIndex = 406
        Me.CboFormatos.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.CboFormatos, "Office2010Blue")
        Me.CboFormatos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnFormato
        '
        Me.BtnFormato.Location = New System.Drawing.Point(350, 228)
        Me.BtnFormato.Name = "BtnFormato"
        Me.BtnFormato.Size = New System.Drawing.Size(48, 23)
        Me.BtnFormato.TabIndex = 410
        Me.BtnFormato.Text = "...."
        Me.C1ThemeController1.SetTheme(Me.BtnFormato, "Office2010Blue")
        Me.BtnFormato.UseVisualStyleBackColor = True
        Me.BtnFormato.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmSelFormato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 345)
        Me.Controls.Add(Me.BtnFormato)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TFORMATO)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.CboFormatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelFormato"
        Me.ShowInTaskbar = False
        Me.Text = "Seleccione formato"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.CboFormatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barAceptar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label5 As Label
    Friend WithEvents TFORMATO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CboFormatos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents BtnFormato As C1.Win.C1Input.C1Button
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
