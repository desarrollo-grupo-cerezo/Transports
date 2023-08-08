<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFoliosfAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFoliosfAE))
        Me.tTIP_DOC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tULT_DOC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tFOLIOHASTA = New System.Windows.Forms.TextBox()
        Me.tCORREO = New System.Windows.Forms.Label()
        Me.tSERIE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tFOLIODESDE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.CboTipo = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.txCtaMN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txCtaUSD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tTIP_DOC
        '
        Me.tTIP_DOC.AcceptsReturn = True
        Me.tTIP_DOC.AcceptsTab = True
        Me.tTIP_DOC.Enabled = False
        Me.tTIP_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTIP_DOC.ForeColor = System.Drawing.Color.Black
        Me.tTIP_DOC.Location = New System.Drawing.Point(157, 90)
        Me.tTIP_DOC.Name = "tTIP_DOC"
        Me.tTIP_DOC.Size = New System.Drawing.Size(61, 22)
        Me.tTIP_DOC.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tTIP_DOC, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(86, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Tipo doc."
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'tULT_DOC
        '
        Me.tULT_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tULT_DOC.ForeColor = System.Drawing.Color.Black
        Me.tULT_DOC.Location = New System.Drawing.Point(157, 229)
        Me.tULT_DOC.Name = "tULT_DOC"
        Me.tULT_DOC.Size = New System.Drawing.Size(161, 22)
        Me.tULT_DOC.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tULT_DOC, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(35, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Ultimo documento"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'tFOLIOHASTA
        '
        Me.tFOLIOHASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIOHASTA.ForeColor = System.Drawing.Color.Black
        Me.tFOLIOHASTA.Location = New System.Drawing.Point(157, 201)
        Me.tFOLIOHASTA.Name = "tFOLIOHASTA"
        Me.tFOLIOHASTA.Size = New System.Drawing.Size(161, 22)
        Me.tFOLIOHASTA.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tFOLIOHASTA, "Office2010Blue")
        '
        'tCORREO
        '
        Me.tCORREO.AutoSize = True
        Me.tCORREO.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tCORREO.Location = New System.Drawing.Point(70, 204)
        Me.tCORREO.Name = "tCORREO"
        Me.tCORREO.Size = New System.Drawing.Size(80, 16)
        Me.tCORREO.TabIndex = 110
        Me.tCORREO.Text = "Folios hasta"
        Me.C1ThemeController1.SetTheme(Me.tCORREO, "Office2010Blue")
        '
        'tSERIE
        '
        Me.tSERIE.AcceptsReturn = True
        Me.tSERIE.AcceptsTab = True
        Me.tSERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSERIE.ForeColor = System.Drawing.Color.Black
        Me.tSERIE.Location = New System.Drawing.Point(157, 145)
        Me.tSERIE.Name = "tSERIE"
        Me.tSERIE.Size = New System.Drawing.Size(61, 22)
        Me.tSERIE.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tSERIE, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(111, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 16)
        Me.Label27.TabIndex = 109
        Me.Label27.Text = "Serie"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tFOLIODESDE
        '
        Me.tFOLIODESDE.AcceptsReturn = True
        Me.tFOLIODESDE.AcceptsTab = True
        Me.tFOLIODESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIODESDE.ForeColor = System.Drawing.Color.Black
        Me.tFOLIODESDE.Location = New System.Drawing.Point(157, 173)
        Me.tFOLIODESDE.Name = "tFOLIODESDE"
        Me.tFOLIODESDE.Size = New System.Drawing.Size(161, 22)
        Me.tFOLIODESDE.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tFOLIODESDE, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(64, 176)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(86, 16)
        Me.Nombre.TabIndex = 108
        Me.Nombre.Text = "Folios desde"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(453, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 107
        Me.BarraMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarraMenu, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'CboTipo
        '
        Me.CboTipo.AllowSpinLoop = False
        Me.CboTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipo.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboTipo.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboTipo.GapHeight = 0
        Me.CboTipo.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipo.ItemsDisplayMember = ""
        Me.CboTipo.ItemsValueMember = ""
        Me.CboTipo.Location = New System.Drawing.Point(157, 118)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(111, 21)
        Me.CboTipo.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboTipo.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboTipo.TabIndex = 1
        Me.CboTipo.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.CboTipo, "Office2010Blue")
        Me.CboTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(115, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 408
        Me.Label3.Text = "Tipo"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'txCtaMN
        '
        Me.txCtaMN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaMN.ForeColor = System.Drawing.Color.Black
        Me.txCtaMN.Location = New System.Drawing.Point(157, 257)
        Me.txCtaMN.MaxLength = 30
        Me.txCtaMN.Name = "txCtaMN"
        Me.txCtaMN.Size = New System.Drawing.Size(161, 22)
        Me.txCtaMN.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.txCtaMN, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(20, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 16)
        Me.Label4.TabIndex = 410
        Me.Label4.Text = "Cuenta Contable MN"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'txCtaUSD
        '
        Me.txCtaUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCtaUSD.ForeColor = System.Drawing.Color.Black
        Me.txCtaUSD.Location = New System.Drawing.Point(157, 285)
        Me.txCtaUSD.MaxLength = 30
        Me.txCtaUSD.Name = "txCtaUSD"
        Me.txCtaUSD.Size = New System.Drawing.Size(161, 22)
        Me.txCtaUSD.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.txCtaUSD, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 16)
        Me.Label5.TabIndex = 412
        Me.Label5.Text = "Cuenta Contable USD"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'FrmFoliosfAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 370)
        Me.Controls.Add(Me.txCtaUSD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txCtaMN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboTipo)
        Me.Controls.Add(Me.tTIP_DOC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tULT_DOC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tFOLIOHASTA)
        Me.Controls.Add(Me.tCORREO)
        Me.Controls.Add(Me.tSERIE)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tFOLIODESDE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFoliosfAE"
        Me.ShowInTaskbar = False
        Me.Text = "Series"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tTIP_DOC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tULT_DOC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tFOLIOHASTA As TextBox
    Friend WithEvents tCORREO As Label
    Friend WithEvents tSERIE As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tFOLIODESDE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents CboTipo As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents txCtaMN As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txCtaUSD As TextBox
    Friend WithEvents Label5 As Label
End Class
