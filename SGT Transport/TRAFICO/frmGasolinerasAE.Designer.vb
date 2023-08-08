<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGasolinerasAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGasolinerasAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_GAS = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tNORMA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tPRECIO = New C1.Win.C1Input.C1NumericEdit()
        Me.tKM = New C1.Win.C1Input.C1NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tCORREO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        CType(Me.tPRECIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(624, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 6
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
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
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_GAS
        '
        Me.tCVE_GAS.AcceptsReturn = True
        Me.tCVE_GAS.AcceptsTab = True
        Me.tCVE_GAS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GAS.ForeColor = System.Drawing.Color.Black
        Me.tCVE_GAS.Location = New System.Drawing.Point(127, 80)
        Me.tCVE_GAS.MaxLength = 10
        Me.tCVE_GAS.Name = "tCVE_GAS"
        Me.tCVE_GAS.Size = New System.Drawing.Size(110, 21)
        Me.tCVE_GAS.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tCVE_GAS, "Office2010Blue")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(87, 82)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label27, "Office2010Blue")
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.ForeColor = System.Drawing.Color.Black
        Me.tDescr.Location = New System.Drawing.Point(127, 106)
        Me.tDescr.MaxLength = 120
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(482, 21)
        Me.tDescr.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tDescr, "Office2010Blue")
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Nombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Nombre.Location = New System.Drawing.Point(77, 109)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Nombre, "Office2010Blue")
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'tNORMA
        '
        Me.tNORMA.AcceptsReturn = True
        Me.tNORMA.AcceptsTab = True
        Me.tNORMA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNORMA.ForeColor = System.Drawing.Color.Black
        Me.tNORMA.Location = New System.Drawing.Point(127, 222)
        Me.tNORMA.Name = "tNORMA"
        Me.tNORMA.Size = New System.Drawing.Size(141, 21)
        Me.tNORMA.TabIndex = 5
        Me.C1ThemeController1.SetTheme(Me.tNORMA, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(83, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Norma"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'tPRECIO
        '
        Me.tPRECIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tPRECIO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tPRECIO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPRECIO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tPRECIO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tPRECIO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tPRECIO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tPRECIO.Location = New System.Drawing.Point(127, 166)
        Me.tPRECIO.Name = "tPRECIO"
        Me.tPRECIO.Size = New System.Drawing.Size(141, 18)
        Me.tPRECIO.TabIndex = 3
        Me.tPRECIO.Tag = Nothing
        Me.tPRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tPRECIO, "Office2010Blue")
        Me.tPRECIO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tPRECIO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tKM
        '
        Me.tKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKM.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tKM.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tKM.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tKM.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKM.Location = New System.Drawing.Point(127, 194)
        Me.tKM.Name = "tKM"
        Me.tKM.Size = New System.Drawing.Size(141, 18)
        Me.tKM.TabIndex = 4
        Me.tKM.Tag = Nothing
        Me.tKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tKM, "Office2010Blue")
        Me.tKM.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tKM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(84, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 318
        Me.Label2.Text = "Precio"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(71, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 317
        Me.Label3.Text = "Kilometro"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.ForeColor = System.Drawing.Color.Black
        Me.tCUEN_CONT.Location = New System.Drawing.Point(127, 254)
        Me.tCUEN_CONT.MaxLength = 28
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 21)
        Me.tCUEN_CONT.TabIndex = 6
        Me.C1ThemeController1.SetTheme(Me.tCUEN_CONT, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(25, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 320
        Me.Label4.Text = "Cuenta contable"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'tCORREO
        '
        Me.tCORREO.AcceptsReturn = True
        Me.tCORREO.AcceptsTab = True
        Me.tCORREO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCORREO.ForeColor = System.Drawing.Color.Black
        Me.tCORREO.Location = New System.Drawing.Point(127, 284)
        Me.tCORREO.MaxLength = 28
        Me.tCORREO.Name = "tCORREO"
        Me.tCORREO.Size = New System.Drawing.Size(482, 21)
        Me.tCORREO.TabIndex = 7
        Me.C1ThemeController1.SetTheme(Me.tCORREO, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 15)
        Me.Label5.TabIndex = 322
        Me.Label5.Text = "Correo electronico"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.L3.Location = New System.Drawing.Point(208, 134)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(338, 20)
        Me.L3.TabIndex = 326
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.L3, "Office2010Blue")
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(182, 134)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 20)
        Me.btnProv.TabIndex = 325
        Me.C1ThemeController1.SetTheme(Me.btnProv, "Office2010Blue")
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PROV.Location = New System.Drawing.Point(126, 134)
        Me.tCVE_PROV.MaxLength = 10
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(54, 20)
        Me.tCVE_PROV.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROV, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(64, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 324
        Me.Label6.Text = "Proveedor"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'frmGasolinerasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 324)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.tCVE_PROV)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tCORREO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tCUEN_CONT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tKM)
        Me.Controls.Add(Me.tPRECIO)
        Me.Controls.Add(Me.tNORMA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_GAS)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmGasolinerasAE"
        Me.Text = "Gasolineras"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tPRECIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_GAS As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tNORMA As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tPRECIO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tKM As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tCORREO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents L3 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label6 As Label
End Class
