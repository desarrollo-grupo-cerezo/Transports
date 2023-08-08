<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResumenMovsInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResumenMovsInv))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarDisenador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCVE_ART2 = New System.Windows.Forms.TextBox()
        Me.BtnArt2 = New C1.Win.C1Input.C1Button()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.TCVE_ART1 = New System.Windows.Forms.TextBox()
        Me.BtnArt1 = New C1.Win.C1Input.C1Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.ChEntradas = New C1.Win.C1Input.C1CheckBox()
        Me.ChSalidas = New C1.Win.C1Input.C1CheckBox()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarDisenador)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutText = ""
        Me.BarDisenador.Text = "Diseñador"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(541, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDisenador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 1
        Me.LkDisenador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione conceptos"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(159, 181)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(370, 332)
        Me.C1List1.TabIndex = 371
        Me.C1List1.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Blue
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(205, 110)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(120, 16)
        Me.Lt5.TabIndex = 370
        Me.Lt5.Text = "Rango de artículos"
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(272, 138)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(18, 16)
        Me.Lt7.TabIndex = 368
        Me.Lt7.Text = "al"
        '
        'TCVE_ART2
        '
        Me.TCVE_ART2.AcceptsReturn = True
        Me.TCVE_ART2.AcceptsTab = True
        Me.TCVE_ART2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART2.Location = New System.Drawing.Point(299, 134)
        Me.TCVE_ART2.MaxLength = 10
        Me.TCVE_ART2.Name = "TCVE_ART2"
        Me.TCVE_ART2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART2.TabIndex = 367
        '
        'BtnArt2
        '
        Me.BtnArt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt2.Image = CType(resources.GetObject("BtnArt2.Image"), System.Drawing.Image)
        Me.BtnArt2.Location = New System.Drawing.Point(424, 135)
        Me.BtnArt2.Name = "BtnArt2"
        Me.BtnArt2.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt2.TabIndex = 369
        Me.BtnArt2.UseVisualStyleBackColor = True
        Me.BtnArt2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(81, 139)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(28, 16)
        Me.Lt6.TabIndex = 365
        Me.Lt6.Text = "Del"
        '
        'TCVE_ART1
        '
        Me.TCVE_ART1.AcceptsReturn = True
        Me.TCVE_ART1.AcceptsTab = True
        Me.TCVE_ART1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART1.Location = New System.Drawing.Point(114, 136)
        Me.TCVE_ART1.MaxLength = 10
        Me.TCVE_ART1.Name = "TCVE_ART1"
        Me.TCVE_ART1.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_ART1.TabIndex = 364
        '
        'BtnArt1
        '
        Me.BtnArt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt1.Image = CType(resources.GetObject("BtnArt1.Image"), System.Drawing.Image)
        Me.BtnArt1.Location = New System.Drawing.Point(235, 136)
        Me.BtnArt1.Name = "BtnArt1"
        Me.BtnArt1.Size = New System.Drawing.Size(26, 20)
        Me.BtnArt1.TabIndex = 366
        Me.BtnArt1.UseVisualStyleBackColor = True
        Me.BtnArt1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(221, 55)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 358
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(260, 81)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 357
        Me.LtAl.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(299, 79)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 355
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(84, 81)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 356
        Me.LtDel.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(117, 79)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 354
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChEntradas
        '
        Me.ChEntradas.BackColor = System.Drawing.Color.Transparent
        Me.ChEntradas.BorderColor = System.Drawing.Color.Transparent
        Me.ChEntradas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChEntradas.Checked = True
        Me.ChEntradas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChEntradas.ForeColor = System.Drawing.Color.Black
        Me.ChEntradas.Location = New System.Drawing.Point(42, 242)
        Me.ChEntradas.Name = "ChEntradas"
        Me.ChEntradas.Padding = New System.Windows.Forms.Padding(1)
        Me.ChEntradas.Size = New System.Drawing.Size(111, 25)
        Me.ChEntradas.TabIndex = 372
        Me.ChEntradas.Text = "Entradas"
        Me.ChEntradas.UseVisualStyleBackColor = False
        Me.ChEntradas.Value = True
        Me.ChEntradas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChSalidas
        '
        Me.ChSalidas.BackColor = System.Drawing.Color.Transparent
        Me.ChSalidas.BorderColor = System.Drawing.Color.Transparent
        Me.ChSalidas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChSalidas.Checked = True
        Me.ChSalidas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChSalidas.ForeColor = System.Drawing.Color.Black
        Me.ChSalidas.Location = New System.Drawing.Point(42, 285)
        Me.ChSalidas.Name = "ChSalidas"
        Me.ChSalidas.Padding = New System.Windows.Forms.Padding(1)
        Me.ChSalidas.Size = New System.Drawing.Size(111, 25)
        Me.ChSalidas.TabIndex = 373
        Me.ChSalidas.Text = "Salidas"
        Me.ChSalidas.UseVisualStyleBackColor = False
        Me.ChSalidas.Value = True
        Me.ChSalidas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "6a9605cb01a64a12a7c9523588742044"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmResumenMovsInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 525)
        Me.Controls.Add(Me.ChSalidas)
        Me.Controls.Add(Me.ChEntradas)
        Me.Controls.Add(Me.C1List1)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt7)
        Me.Controls.Add(Me.TCVE_ART2)
        Me.Controls.Add(Me.BtnArt2)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.TCVE_ART1)
        Me.Controls.Add(Me.BtnArt1)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.LtAl)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.LtDel)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmResumenMovsInv"
        Me.ShowInTaskbar = False
        Me.Text = "Resumen de movimientos al inventario"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents TCVE_ART2 As TextBox
    Friend WithEvents BtnArt2 As C1.Win.C1Input.C1Button
    Friend WithEvents Lt6 As Label
    Friend WithEvents TCVE_ART1 As TextBox
    Friend WithEvents BtnArt1 As C1.Win.C1Input.C1Button
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents ChEntradas As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChSalidas As C1.Win.C1Input.C1CheckBox
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarDisenador As C1.Win.C1Command.C1Command
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
End Class
