<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBConBanAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBConBanAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCLASIFICACION = New C1.Win.C1Input.C1TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TIVA = New C1.Win.C1Input.C1TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCTA_CONTAB = New C1.Win.C1Input.C1TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCONCEPSAE = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCONCEP = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TCVE_CONCEP = New C1.Win.C1Input.C1TextBox()
        Me.CboTipo = New C1.Win.C1Input.C1ComboBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCLASIFICACION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCTA_CONTAB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCONCEPSAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCONCEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_CONCEP, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(510, 43)
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
        Me.Label5.Location = New System.Drawing.Point(66, 227)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 417
        Me.Label5.Text = "Clasificción"
        '
        'TCLASIFICACION
        '
        Me.TCLASIFICACION.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCLASIFICACION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLASIFICACION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCLASIFICACION.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCLASIFICACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLASIFICACION.Location = New System.Drawing.Point(147, 225)
        Me.TCLASIFICACION.MaxLength = 3
        Me.TCLASIFICACION.Name = "TCLASIFICACION"
        Me.TCLASIFICACION.Size = New System.Drawing.Size(48, 20)
        Me.TCLASIFICACION.TabIndex = 6
        Me.TCLASIFICACION.Tag = Nothing
        Me.TCLASIFICACION.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(113, 202)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "IVA"
        '
        'TIVA
        '
        Me.TIVA.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIVA.DataType = GetType(Decimal)
        Me.TIVA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIVA.Location = New System.Drawing.Point(147, 199)
        Me.TIVA.Name = "TIVA"
        Me.TIVA.Size = New System.Drawing.Size(48, 20)
        Me.TIVA.TabIndex = 5
        Me.TIVA.Tag = Nothing
        Me.TIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TIVA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 176)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 413
        Me.Label7.Text = "Cuenta contable"
        '
        'TCTA_CONTAB
        '
        Me.TCTA_CONTAB.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCTA_CONTAB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCTA_CONTAB.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCTA_CONTAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCTA_CONTAB.Location = New System.Drawing.Point(147, 173)
        Me.TCTA_CONTAB.MaxLength = 40
        Me.TCTA_CONTAB.Name = "TCTA_CONTAB"
        Me.TCTA_CONTAB.Size = New System.Drawing.Size(303, 20)
        Me.TCTA_CONTAB.TabIndex = 4
        Me.TCTA_CONTAB.Tag = Nothing
        Me.TCTA_CONTAB.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 149)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 411
        Me.Label3.Text = "Concepto"
        '
        'TCONCEPSAE
        '
        Me.TCONCEPSAE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCONCEPSAE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCONCEPSAE.DataType = GetType(Decimal)
        Me.TCONCEPSAE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCONCEPSAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCONCEPSAE.Location = New System.Drawing.Point(147, 147)
        Me.TCONCEPSAE.Name = "TCONCEPSAE"
        Me.TCONCEPSAE.Size = New System.Drawing.Size(48, 20)
        Me.TCONCEPSAE.TabIndex = 3
        Me.TCONCEPSAE.Tag = Nothing
        Me.TCONCEPSAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TCONCEPSAE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 124)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "Descripción"
        '
        'TCONCEP
        '
        Me.TCONCEP.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCONCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCONCEP.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCONCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCONCEP.Location = New System.Drawing.Point(147, 121)
        Me.TCONCEP.MaxLength = 30
        Me.TCONCEP.Name = "TCONCEP"
        Me.TCONCEP.Size = New System.Drawing.Size(303, 20)
        Me.TCONCEP.TabIndex = 2
        Me.TCONCEP.Tag = Nothing
        Me.TCONCEP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 98)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 407
        Me.Label1.Text = "Tipo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(76, 72)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 405
        Me.Label16.Text = "Concepto"
        '
        'TCVE_CONCEP
        '
        Me.TCVE_CONCEP.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TCVE_CONCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CONCEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CONCEP.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_CONCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CONCEP.Location = New System.Drawing.Point(147, 70)
        Me.TCVE_CONCEP.MaxLength = 6
        Me.TCVE_CONCEP.Name = "TCVE_CONCEP"
        Me.TCVE_CONCEP.Size = New System.Drawing.Size(81, 20)
        Me.TCVE_CONCEP.TabIndex = 0
        Me.TCVE_CONCEP.Tag = Nothing
        Me.TCVE_CONCEP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CboTipo
        '
        Me.CboTipo.AllowSpinLoop = False
        Me.CboTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboTipo.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipo.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboTipo.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboTipo.GapHeight = 0
        Me.CboTipo.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipo.ItemsDisplayMember = ""
        Me.CboTipo.ItemsValueMember = ""
        Me.CboTipo.Location = New System.Drawing.Point(147, 96)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(81, 19)
        Me.CboTipo.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboTipo.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboTipo.TabIndex = 1
        Me.CboTipo.Tag = Nothing
        Me.CboTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmBConBanAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 276)
        Me.Controls.Add(Me.CboTipo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TCLASIFICACION)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TIVA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TCTA_CONTAB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCONCEPSAE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCONCEP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TCVE_CONCEP)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBConBanAE"
        Me.ShowInTaskbar = False
        Me.Text = "Concepto bancario"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCLASIFICACION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCTA_CONTAB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCONCEPSAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCONCEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_CONCEP, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TCLASIFICACION As C1.Win.C1Input.C1TextBox
    Private WithEvents Label6 As Label
    Friend WithEvents TIVA As C1.Win.C1Input.C1TextBox
    Private WithEvents Label7 As Label
    Friend WithEvents TCTA_CONTAB As C1.Win.C1Input.C1TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents TCONCEPSAE As C1.Win.C1Input.C1TextBox
    Private WithEvents Label2 As Label
    Friend WithEvents TCONCEP As C1.Win.C1Input.C1TextBox
    Private WithEvents Label1 As Label
    Private WithEvents Label16 As Label
    Friend WithEvents TCVE_CONCEP As C1.Win.C1Input.C1TextBox
    Friend WithEvents CboTipo As C1.Win.C1Input.C1ComboBox
End Class
