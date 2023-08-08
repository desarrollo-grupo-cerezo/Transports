<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRmTraficUpdatePrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRmTraficUpdatePrecio))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TPRECIO = New C1.Win.C1Input.C1TextBox()
        Me.tCVE_ESQIMPU = New System.Windows.Forms.TextBox()
        Me.btnEsquema = New C1.Win.C1Input.C1Button()
        Me.LtEsquema = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtArt = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtDescr = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPRECIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.traza4
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
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
        Me.C1ToolBar1.Border.BottomEdge = False
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(532, 46)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "Office2010Blue")
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar F3"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.Text = "Salir F5"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(127, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 16)
        Me.Label7.TabIndex = 260
        Me.Label7.Text = "Precio"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(50, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 16)
        Me.Label1.TabIndex = 261
        Me.Label1.Text = "Esquema impuesto"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TPRECIO
        '
        Me.TPRECIO.AcceptsReturn = True
        Me.TPRECIO.AcceptsTab = True
        Me.TPRECIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPRECIO.CustomFormat = "###,###,##0.00"
        Me.TPRECIO.DataType = GetType(Decimal)
        Me.TPRECIO.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TPRECIO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRECIO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRECIO.Location = New System.Drawing.Point(180, 161)
        Me.TPRECIO.Name = "TPRECIO"
        Me.TPRECIO.Size = New System.Drawing.Size(129, 20)
        Me.TPRECIO.TabIndex = 0
        Me.TPRECIO.Tag = Nothing
        Me.TPRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.TPRECIO, "Office2010Blue")
        Me.TPRECIO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_ESQIMPU
        '
        Me.tCVE_ESQIMPU.AcceptsReturn = True
        Me.tCVE_ESQIMPU.AcceptsTab = True
        Me.tCVE_ESQIMPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ESQIMPU.ForeColor = System.Drawing.Color.Black
        Me.tCVE_ESQIMPU.Location = New System.Drawing.Point(180, 208)
        Me.tCVE_ESQIMPU.MaxLength = 5
        Me.tCVE_ESQIMPU.Name = "tCVE_ESQIMPU"
        Me.tCVE_ESQIMPU.Size = New System.Drawing.Size(55, 22)
        Me.tCVE_ESQIMPU.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tCVE_ESQIMPU, "Office2010Blue")
        '
        'btnEsquema
        '
        Me.btnEsquema.AutoSize = True
        Me.btnEsquema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEsquema.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.btnEsquema.Location = New System.Drawing.Point(240, 208)
        Me.btnEsquema.Name = "btnEsquema"
        Me.btnEsquema.Size = New System.Drawing.Size(22, 22)
        Me.btnEsquema.TabIndex = 283
        Me.C1ThemeController1.SetTheme(Me.btnEsquema, "Office2010Blue")
        Me.btnEsquema.UseVisualStyleBackColor = True
        Me.btnEsquema.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtEsquema
        '
        Me.LtEsquema.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtEsquema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEsquema.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtEsquema.Location = New System.Drawing.Point(180, 243)
        Me.LtEsquema.Name = "LtEsquema"
        Me.LtEsquema.Size = New System.Drawing.Size(258, 19)
        Me.LtEsquema.TabIndex = 282
        Me.C1ThemeController1.SetTheme(Me.LtEsquema, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(94, 243)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 285
        Me.Label2.Text = "Descripción"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(53, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "Articulo"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'LtArt
        '
        Me.LtArt.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtArt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtArt.Location = New System.Drawing.Point(111, 70)
        Me.LtArt.Name = "LtArt"
        Me.LtArt.Size = New System.Drawing.Size(124, 19)
        Me.LtArt.TabIndex = 287
        Me.C1ThemeController1.SetTheme(Me.LtArt, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(25, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 290
        Me.Label5.Text = "Descripción"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'LtDescr
        '
        Me.LtDescr.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDescr.Location = New System.Drawing.Point(111, 101)
        Me.LtDescr.Name = "LtDescr"
        Me.LtDescr.Size = New System.Drawing.Size(409, 19)
        Me.LtDescr.TabIndex = 289
        Me.C1ThemeController1.SetTheme(Me.LtDescr, "Office2010Blue")
        '
        'FRmTraficUpdatePrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 328)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtDescr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtArt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCVE_ESQIMPU)
        Me.Controls.Add(Me.btnEsquema)
        Me.Controls.Add(Me.LtEsquema)
        Me.Controls.Add(Me.TPRECIO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRmTraficUpdatePrecio"
        Me.ShowInTaskbar = False
        Me.Text = "Actualizar precio"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPRECIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TPRECIO As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tCVE_ESQIMPU As TextBox
    Friend WithEvents btnEsquema As C1.Win.C1Input.C1Button
    Friend WithEvents LtEsquema As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtDescr As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtArt As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
