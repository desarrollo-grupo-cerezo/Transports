<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGastoRenovadoAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGastoRenovadoAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminarPart = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCVE_GASTO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.BtnUnidades = New C1.Win.C1Input.C1Button()
        Me.TCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT = New System.Windows.Forms.TextBox()
        Me.TXTN = New C1.Win.C1Input.C1TextBox()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.TMAGICO = New System.Windows.Forms.TextBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtObs = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarEliminarPart, Me.BarXls, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1037, 55)
        Me.BarraMenu.TabIndex = 3
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminarPart
        '
        Me.BarEliminarPart.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminarPart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminarPart.Name = "BarEliminarPart"
        Me.BarEliminarPart.ShortcutKeyDisplayString = ""
        Me.BarEliminarPart.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEliminarPart.Size = New System.Drawing.Size(102, 51)
        Me.BarEliminarPart.Text = "Eliminar partida"
        Me.BarEliminarPart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarXls
        '
        Me.BarXls.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarXls.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarXls.Name = "BarXls"
        Me.BarXls.ShortcutKeyDisplayString = ""
        Me.BarXls.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarXls.Size = New System.Drawing.Size(46, 51)
        Me.BarXls.Text = "Excel"
        Me.BarXls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TCVE_GASTO
        '
        Me.TCVE_GASTO.AcceptsReturn = True
        Me.TCVE_GASTO.AcceptsTab = True
        Me.TCVE_GASTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_GASTO.Location = New System.Drawing.Point(92, 79)
        Me.TCVE_GASTO.Name = "TCVE_GASTO"
        Me.TCVE_GASTO.Size = New System.Drawing.Size(100, 22)
        Me.TCVE_GASTO.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Clave"
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(213, 113)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(258, 22)
        Me.L2.TabIndex = 157
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnUnidades
        '
        Me.BtnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidades.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnUnidades.Location = New System.Drawing.Point(185, 114)
        Me.BtnUnidades.Name = "BtnUnidades"
        Me.BtnUnidades.Size = New System.Drawing.Size(26, 20)
        Me.BtnUnidades.TabIndex = 156
        Me.BtnUnidades.UseVisualStyleBackColor = True
        Me.BtnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.AcceptsReturn = True
        Me.TCVE_UNI.AcceptsTab = True
        Me.TCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(93, 113)
        Me.TCVE_UNI.MaxLength = 10
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(90, 22)
        Me.TCVE_UNI.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Unidad"
        '
        'TXT
        '
        Me.TXT.AcceptsReturn = True
        Me.TXT.AcceptsTab = True
        Me.TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT.Location = New System.Drawing.Point(1037, 138)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(100, 22)
        Me.TXT.TabIndex = 3
        '
        'TXTN
        '
        Me.TXTN.AcceptsReturn = True
        Me.TXTN.AcceptsTab = True
        Me.TXTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTN.CustomFormat = "###,###,##0.00"
        Me.TXTN.DataType = GetType(Decimal)
        Me.TXTN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TXTN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TXTN.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TXTN.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TXTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTN.Location = New System.Drawing.Point(1037, 175)
        Me.TXTN.Name = "TXTN"
        Me.TXTN.Size = New System.Drawing.Size(100, 20)
        Me.TXTN.TabIndex = 5
        Me.TXTN.Tag = Nothing
        Me.TXTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTN.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(1, 162)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 24
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Inherit
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1024, 284)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 2
        '
        'CboAlmacen
        '
        Me.CboAlmacen.AcceptsTab = True
        Me.CboAlmacen.AllowSpinLoop = False
        Me.CboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlmacen.GapHeight = 0
        Me.CboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboAlmacen.ItemsDisplayMember = ""
        Me.CboAlmacen.ItemsValueMember = ""
        Me.CboAlmacen.Location = New System.Drawing.Point(518, 113)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(200, 19)
        Me.CboAlmacen.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboAlmacen.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboAlmacen.TabIndex = 4
        Me.CboAlmacen.Tag = Nothing
        Me.CboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TMAGICO
        '
        Me.TMAGICO.AcceptsReturn = True
        Me.TMAGICO.AcceptsTab = True
        Me.TMAGICO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMAGICO.Location = New System.Drawing.Point(1037, 110)
        Me.TMAGICO.Name = "TMAGICO"
        Me.TMAGICO.Size = New System.Drawing.Size(100, 22)
        Me.TMAGICO.TabIndex = 158
        '
        'F1
        '
        Me.F1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.F1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(347, 78)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(124, 22)
        Me.F1.TabIndex = 203
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(221, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 17)
        Me.Label14.TabIndex = 204
        Me.Label14.Text = "Fecha carta porte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 459)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Observaciones"
        '
        'LtObs
        '
        Me.LtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtObs.Location = New System.Drawing.Point(118, 459)
        Me.LtObs.Name = "LtObs"
        Me.LtObs.Size = New System.Drawing.Size(871, 50)
        Me.LtObs.TabIndex = 206
        '
        'FrmGastoRenovadoAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 518)
        Me.Controls.Add(Me.LtObs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TMAGICO)
        Me.Controls.Add(Me.CboAlmacen)
        Me.Controls.Add(Me.TXT)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.BtnUnidades)
        Me.Controls.Add(Me.TCVE_UNI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.TCVE_GASTO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.TXTN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGastoRenovadoAE"
        Me.ShowInTaskbar = False
        Me.Text = "Gastos renovado"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents TCVE_GASTO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents BtnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT As TextBox
    Friend WithEvents TXTN As C1.Win.C1Input.C1TextBox
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents TMAGICO As TextBox
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarEliminarPart As ToolStripMenuItem
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label14 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LtObs As Label
    Friend WithEvents BarXls As ToolStripMenuItem
End Class
