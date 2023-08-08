<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBBenefAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBBenefAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TREFERENCIA = New C1.Win.C1Input.C1TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCTA_CONTAB = New C1.Win.C1Input.C1TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TRFC = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TNOMBRE = New C1.Win.C1Input.C1TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TNUM_REG = New C1.Win.C1Input.C1TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TCLABE = New C1.Win.C1Input.C1TextBox()
        Me.TCUENTA = New C1.Win.C1Input.C1TextBox()
        Me.BtnBanco = New C1.Win.C1Input.C1Button()
        Me.CboTipo = New C1.Win.C1Input.C1ComboBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TREFERENCIA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCTA_CONTAB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNOMBRE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_REG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCLABE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCUENTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(674, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(57, 234)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 431
        Me.Label5.Text = "Referencia"
        '
        'TREFERENCIA
        '
        Me.TREFERENCIA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TREFERENCIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TREFERENCIA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TREFERENCIA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TREFERENCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TREFERENCIA.Location = New System.Drawing.Point(135, 234)
        Me.TREFERENCIA.MaxLength = 20
        Me.TREFERENCIA.Name = "TREFERENCIA"
        Me.TREFERENCIA.Size = New System.Drawing.Size(303, 20)
        Me.TREFERENCIA.TabIndex = 5
        Me.TREFERENCIA.Tag = Nothing
        Me.TREFERENCIA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(95, 206)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 16)
        Me.Label6.TabIndex = 430
        Me.Label6.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 178)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 429
        Me.Label7.Text = "Cuenta contable"
        '
        'TCTA_CONTAB
        '
        Me.TCTA_CONTAB.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCTA_CONTAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTA_CONTAB.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCTA_CONTAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTA_CONTAB.Location = New System.Drawing.Point(135, 177)
        Me.TCTA_CONTAB.MaxLength = 40
        Me.TCTA_CONTAB.Name = "TCTA_CONTAB"
        Me.TCTA_CONTAB.Size = New System.Drawing.Size(303, 20)
        Me.TCTA_CONTAB.TabIndex = 3
        Me.TCTA_CONTAB.Tag = Nothing
        Me.TCTA_CONTAB.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 150)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "RFC"
        '
        'TRFC
        '
        Me.TRFC.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TRFC.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRFC.Location = New System.Drawing.Point(135, 149)
        Me.TRFC.Name = "TRFC"
        Me.TRFC.Size = New System.Drawing.Size(168, 20)
        Me.TRFC.TabIndex = 2
        Me.TRFC.Tag = Nothing
        Me.TRFC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 427
        Me.Label2.Text = "Nombre"
        '
        'TNOMBRE
        '
        Me.TNOMBRE.BackColor = System.Drawing.Color.White
        Me.TNOMBRE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TNOMBRE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNOMBRE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TNOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNOMBRE.Location = New System.Drawing.Point(135, 121)
        Me.TNOMBRE.MaxLength = 60
        Me.TNOMBRE.Name = "TNOMBRE"
        Me.TNOMBRE.Size = New System.Drawing.Size(510, 20)
        Me.TNOMBRE.TabIndex = 1
        Me.TNOMBRE.Tag = Nothing
        Me.TNOMBRE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(88, 94)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 16)
        Me.Label16.TabIndex = 425
        Me.Label16.Text = "Clave"
        '
        'TNUM_REG
        '
        Me.TNUM_REG.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TNUM_REG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUM_REG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TNUM_REG.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TNUM_REG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_REG.Location = New System.Drawing.Point(135, 93)
        Me.TNUM_REG.MaxLength = 6
        Me.TNUM_REG.Name = "TNUM_REG"
        Me.TNUM_REG.Size = New System.Drawing.Size(81, 20)
        Me.TNUM_REG.TabIndex = 0
        Me.TNUM_REG.Tag = Nothing
        Me.TNUM_REG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 262)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 16)
        Me.Label8.TabIndex = 434
        Me.Label8.Text = "Cuenta bancaria"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(87, 295)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 16)
        Me.Label9.TabIndex = 439
        Me.Label9.Text = "Clabe"
        '
        'TCLABE
        '
        Me.TCLABE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCLABE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLABE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCLABE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCLABE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLABE.Location = New System.Drawing.Point(135, 292)
        Me.TCLABE.MaxLength = 30
        Me.TCLABE.Name = "TCLABE"
        Me.TCLABE.Size = New System.Drawing.Size(217, 20)
        Me.TCLABE.TabIndex = 9
        Me.TCLABE.Tag = Nothing
        Me.TCLABE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCUENTA
        '
        Me.TCUENTA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCUENTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCUENTA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCUENTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUENTA.Location = New System.Drawing.Point(135, 264)
        Me.TCUENTA.MaxLength = 30
        Me.TCUENTA.Name = "TCUENTA"
        Me.TCUENTA.Size = New System.Drawing.Size(217, 20)
        Me.TCUENTA.TabIndex = 8
        Me.TCUENTA.Tag = Nothing
        Me.TCUENTA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnBanco
        '
        Me.BtnBanco.FlatAppearance.BorderSize = 0
        Me.BtnBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBanco.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnBanco.Location = New System.Drawing.Point(358, 260)
        Me.BtnBanco.Name = "BtnBanco"
        Me.BtnBanco.Size = New System.Drawing.Size(23, 24)
        Me.BtnBanco.TabIndex = 443
        Me.BtnBanco.UseVisualStyleBackColor = True
        '
        'CboTipo
        '
        Me.CboTipo.AcceptsTab = True
        Me.CboTipo.AllowSpinLoop = False
        Me.CboTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipo.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.GapHeight = 0
        Me.CboTipo.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipo.ItemsDisplayMember = ""
        Me.CboTipo.ItemsValueMember = ""
        Me.CboTipo.Location = New System.Drawing.Point(135, 205)
        Me.CboTipo.MaxDropDownItems = 15
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(122, 21)
        Me.CboTipo.TabIndex = 4
        Me.CboTipo.Tag = Nothing
        Me.CboTipo.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmBBenefAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 388)
        Me.Controls.Add(Me.CboTipo)
        Me.Controls.Add(Me.BtnBanco)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TCLABE)
        Me.Controls.Add(Me.TCUENTA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TREFERENCIA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TCTA_CONTAB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TRFC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TNOMBRE)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TNUM_REG)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBBenefAE"
        Me.ShowInTaskbar = False
        Me.Text = "Beneficiario"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TREFERENCIA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCTA_CONTAB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNOMBRE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_REG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCLABE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCUENTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Private WithEvents Label5 As Label
    Friend WithEvents TREFERENCIA As C1.Win.C1Input.C1TextBox
    Private WithEvents Label6 As Label
    Private WithEvents Label7 As Label
    Friend WithEvents TCTA_CONTAB As C1.Win.C1Input.C1TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents TRFC As C1.Win.C1Input.C1TextBox
    Private WithEvents Label2 As Label
    Friend WithEvents TNOMBRE As C1.Win.C1Input.C1TextBox
    Private WithEvents Label16 As Label
    Friend WithEvents TNUM_REG As C1.Win.C1Input.C1TextBox
    Private WithEvents Label8 As Label
    Private WithEvents Label9 As Label
    Friend WithEvents TCLABE As C1.Win.C1Input.C1TextBox
    Friend WithEvents TCUENTA As C1.Win.C1Input.C1TextBox
    Friend WithEvents BtnBanco As C1.Win.C1Input.C1Button
    Friend WithEvents CboTipo As C1.Win.C1Input.C1ComboBox
End Class
