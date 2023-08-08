<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocumentos))
        Me.LtCompras = New System.Windows.Forms.Label()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDesplegar = New System.Windows.Forms.Button()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.BarraAbajo.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LtCompras
        '
        Me.LtCompras.AutoSize = True
        Me.LtCompras.Font = New System.Drawing.Font("Arial Black", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCompras.Location = New System.Drawing.Point(1154, 11)
        Me.LtCompras.Name = "LtCompras"
        Me.LtCompras.Size = New System.Drawing.Size(171, 27)
        Me.LtCompras.TabIndex = 11
        Me.LtCompras.Text = "Notas de venta"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 493)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1406, 25)
        Me.BarraAbajo.TabIndex = 12
        Me.BarraAbajo.Text = "ToolStrip1"
        '
        'BHoy
        '
        Me.BHoy.AutoSize = False
        Me.BHoy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BHoy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHoy.Name = "BHoy"
        Me.BHoy.Size = New System.Drawing.Size(80, 22)
        Me.BHoy.Text = "Hoy"
        '
        'BAyer
        '
        Me.BAyer.AutoSize = False
        Me.BAyer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BAyer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BAyer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAyer.Name = "BAyer"
        Me.BAyer.Size = New System.Drawing.Size(80, 22)
        Me.BAyer.Text = "Ayer"
        '
        'BEsteMes
        '
        Me.BEsteMes.AutoSize = False
        Me.BEsteMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BEsteMes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEsteMes.Name = "BEsteMes"
        Me.BEsteMes.Size = New System.Drawing.Size(80, 22)
        Me.BEsteMes.Text = "Este Mes"
        '
        'BMesAnterior
        '
        Me.BMesAnterior.AutoSize = False
        Me.BMesAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BMesAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMesAnterior.Name = "BMesAnterior"
        Me.BMesAnterior.Size = New System.Drawing.Size(80, 22)
        Me.BMesAnterior.Text = "Mes Anterior"
        '
        'BTodos
        '
        Me.BTodos.AutoSize = False
        Me.BTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTodos.Name = "BTodos"
        Me.BTodos.Size = New System.Drawing.Size(80, 22)
        Me.BTodos.Text = "Todos"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(599, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(229, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 13
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 5.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(44, 62)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(457, 314)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 312
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "11f7be6644e24c229a9263ccafa1406b"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(111, 22)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 308
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(3, 22)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 306
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 15)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Del"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnDesplegar)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(832, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(313, 51)
        Me.Panel1.TabIndex = 309
        '
        'btnDesplegar
        '
        Me.btnDesplegar.Location = New System.Drawing.Point(225, 14)
        Me.btnDesplegar.Name = "btnDesplegar"
        Me.btnDesplegar.Size = New System.Drawing.Size(75, 23)
        Me.btnDesplegar.TabIndex = 309
        Me.btnDesplegar.Text = "Desplegar"
        Me.btnDesplegar.UseVisualStyleBackColor = True
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarNuevo)
        Me.MenuHolder.Commands.Add(Me.BarEdit)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Edit"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutText = ""
        Me.BarActualizar.Text = "Actualizar"
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
        Me.C1ToolBar1.ButtonWidth = 75
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkActualizar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1406, 56)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.BarNuevo
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.Text = "Nuevo"
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.BarEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Edit"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.DefaultItem = True
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 2
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 3
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'FrmDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 518)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.LtCompras)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.BarraAbajo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDocumentos"
        Me.Text = "Compras"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LtCompras As Label
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDesplegar As Button
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Private WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
