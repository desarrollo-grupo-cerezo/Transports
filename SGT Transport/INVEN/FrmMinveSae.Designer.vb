<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMinveSae
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMinveSae))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barHoy = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEsteMes = New System.Windows.Forms.ToolStripMenuItem()
        Me.barMesAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.barTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.barKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.BarRefrescar, Me.barHoy, Me.barEsteMes, Me.barMesAnterior, Me.barTodos, Me.barKardex, Me.mnuReimprimir, Me.BarExcel, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1303, 55)
        Me.barMenu.TabIndex = 11
        Me.barMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barMenu, "Office2010Blue")
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(56, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarRefrescar
        '
        Me.BarRefrescar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarRefrescar.ForeColor = System.Drawing.Color.Black
        Me.BarRefrescar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarRefrescar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefrescar.Name = "BarRefrescar"
        Me.BarRefrescar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRefrescar.Size = New System.Drawing.Size(74, 51)
        Me.BarRefrescar.Text = "Actualizar"
        Me.BarRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barHoy
        '
        Me.barHoy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barHoy.ForeColor = System.Drawing.Color.Black
        Me.barHoy.Image = Global.SGT_Transport.My.Resources.Resources.carta8
        Me.barHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barHoy.Name = "barHoy"
        Me.barHoy.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barHoy.Size = New System.Drawing.Size(44, 51)
        Me.barHoy.Text = "Hoy"
        Me.barHoy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEsteMes
        '
        Me.barEsteMes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEsteMes.ForeColor = System.Drawing.Color.Black
        Me.barEsteMes.Image = Global.SGT_Transport.My.Resources.Resources.carta7
        Me.barEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEsteMes.Name = "barEsteMes"
        Me.barEsteMes.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEsteMes.Size = New System.Drawing.Size(68, 51)
        Me.barEsteMes.Text = "Este mes"
        Me.barEsteMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barMesAnterior
        '
        Me.barMesAnterior.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barMesAnterior.ForeColor = System.Drawing.Color.Black
        Me.barMesAnterior.Image = Global.SGT_Transport.My.Resources.Resources.carta3
        Me.barMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barMesAnterior.Name = "barMesAnterior"
        Me.barMesAnterior.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barMesAnterior.Size = New System.Drawing.Size(90, 51)
        Me.barMesAnterior.Text = "Mes anterior"
        Me.barMesAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barTodos
        '
        Me.barTodos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barTodos.ForeColor = System.Drawing.Color.Black
        Me.barTodos.Image = Global.SGT_Transport.My.Resources.Resources.doc271
        Me.barTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barTodos.Name = "barTodos"
        Me.barTodos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barTodos.Size = New System.Drawing.Size(51, 51)
        Me.barTodos.Text = "Todos"
        Me.barTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barKardex
        '
        Me.barKardex.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barKardex.ForeColor = System.Drawing.Color.Black
        Me.barKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.barKardex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barKardex.Name = "barKardex"
        Me.barKardex.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barKardex.Size = New System.Drawing.Size(59, 51)
        Me.barKardex.Text = "Kardex"
        Me.barKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuReimprimir
        '
        Me.mnuReimprimir.ForeColor = System.Drawing.Color.Black
        Me.mnuReimprimir.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.mnuReimprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuReimprimir.Name = "mnuReimprimir"
        Me.mnuReimprimir.Size = New System.Drawing.Size(78, 51)
        Me.mnuReimprimir.Text = "Reimprimir"
        Me.mnuReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "a9cb711ef930492fa931d2518ec24415"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1088, 5)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(212, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 20
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.F2)
        Me.GroupBox1.Controls.Add(Me.F1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(721, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 53)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.C1ThemeController1.SetTheme(Me.GroupBox1, "Office2010Blue")
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(135, 28)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 21)
        Me.F2.TabIndex = 171
        Me.F2.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F2, "Office2010Blue")
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(7, 28)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 170
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(159, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "al"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackColor = System.Drawing.Color.Transparent
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnFiltrar.Location = New System.Drawing.Point(279, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 33)
        Me.btnFiltrar.TabIndex = 168
        Me.btnFiltrar.Text = "Filtrar"
        Me.C1ThemeController1.SetTheme(Me.btnFiltrar, "Office2010Blue")
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Del"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'frmMinveSae
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 515)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMinveSae"
        Me.Text = "Movimintos al inventario"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barHoy As ToolStripMenuItem
    Friend WithEvents barEsteMes As ToolStripMenuItem
    Friend WithEvents barMesAnterior As ToolStripMenuItem
    Friend WithEvents barTodos As ToolStripMenuItem
    Friend WithEvents mnuReimprimir As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barKardex As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarRefrescar As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
