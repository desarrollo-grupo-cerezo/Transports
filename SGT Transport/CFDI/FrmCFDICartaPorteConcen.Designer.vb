<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCFDICartaPorteConcen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCFDICartaPorteConcen))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarMenu = New C1.Win.C1Command.C1CommandMenu()
        Me.BarCpSinPrecios = New C1.Win.C1Command.C1CommandLink()
        Me.BarReCPSinPrec = New C1.Win.C1Command.C1Command()
        Me.BarCpConPrecios = New C1.Win.C1Command.C1CommandLink()
        Me.BarReCPConPrec = New C1.Win.C1Command.C1Command()
        Me.BarCPCanc = New C1.Win.C1Command.C1CommandLink()
        Me.BarReCPCanc = New C1.Win.C1Command.C1Command()
        Me.BarReimpMasiva = New C1.Win.C1Command.C1CommandLink()
        Me.BarMReimpMasiva = New C1.Win.C1Command.C1Command()
        Me.BarEstatusCFDI = New C1.Win.C1Command.C1Command()
        Me.BarEnviarcorreo = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarExtraerXML = New C1.Win.C1Command.C1Command()
        Me.BarCancelar = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarExtraeXML = New C1.Win.C1Command.C1CommandMenu()
        Me.BarExtraeSelect = New C1.Win.C1Command.C1CommandLink()
        Me.BarExtraSel = New C1.Win.C1Command.C1Command()
        Me.BarExtraerTodos = New C1.Win.C1Command.C1CommandLink()
        Me.BarExtraTodos = New C1.Win.C1Command.C1Command()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LKMainPrinter = New C1.Win.C1Command.C1CommandLink()
        Me.LkCancelar = New C1.Win.C1Command.C1CommandLink()
        Me.LkEstatusCFDI = New C1.Win.C1Command.C1CommandLink()
        Me.LkEnviarcorreo = New C1.Win.C1Command.C1CommandLink()
        Me.LkExtraerXML = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarMenu)
        Me.MenuHolder.Commands.Add(Me.BarReCPSinPrec)
        Me.MenuHolder.Commands.Add(Me.BarReCPConPrec)
        Me.MenuHolder.Commands.Add(Me.BarReCPCanc)
        Me.MenuHolder.Commands.Add(Me.BarEstatusCFDI)
        Me.MenuHolder.Commands.Add(Me.BarEnviarcorreo)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarExtraerXML)
        Me.MenuHolder.Commands.Add(Me.BarCancelar)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarMReimpMasiva)
        Me.MenuHolder.Commands.Add(Me.BarExtraeXML)
        Me.MenuHolder.Commands.Add(Me.BarExtraSel)
        Me.MenuHolder.Commands.Add(Me.BarExtraTodos)
        Me.MenuHolder.Owner = Me
        '
        'BarMenu
        '
        Me.BarMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.BarCpSinPrecios, Me.BarCpConPrecios, Me.BarCPCanc, Me.BarReimpMasiva})
        Me.BarMenu.HideNonRecentLinks = False
        Me.BarMenu.Image = Global.SGT_Transport.My.Resources.Resources.impresora8
        Me.BarMenu.ImageBarWidth = 60
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.ShortcutText = ""
        Me.BarMenu.Text = "Re Impresión"
        Me.BarMenu.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarMenu.Width = 40
        '
        'BarCpSinPrecios
        '
        Me.BarCpSinPrecios.Command = Me.BarReCPSinPrec
        Me.BarCpSinPrecios.Text = "Carta porte sin precios"
        '
        'BarReCPSinPrec
        '
        Me.BarReCPSinPrec.Image = Global.SGT_Transport.My.Resources.Resources.printer22
        Me.BarReCPSinPrec.Name = "BarReCPSinPrec"
        Me.BarReCPSinPrec.ShortcutText = ""
        Me.BarReCPSinPrec.Text = "Carta porte sin precios"
        '
        'BarCpConPrecios
        '
        Me.BarCpConPrecios.Command = Me.BarReCPConPrec
        Me.BarCpConPrecios.SortOrder = 1
        Me.BarCpConPrecios.Text = "Carta porte con precios"
        '
        'BarReCPConPrec
        '
        Me.BarReCPConPrec.Image = Global.SGT_Transport.My.Resources.Resources.impresora4
        Me.BarReCPConPrec.Name = "BarReCPConPrec"
        Me.BarReCPConPrec.ShortcutText = ""
        Me.BarReCPConPrec.Text = "Carta porte con precios"
        '
        'BarCPCanc
        '
        Me.BarCPCanc.Command = Me.BarReCPCanc
        Me.BarCPCanc.SortOrder = 2
        Me.BarCPCanc.Text = "Cancelación carta porte"
        '
        'BarReCPCanc
        '
        Me.BarReCPCanc.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarReCPCanc.Name = "BarReCPCanc"
        Me.BarReCPCanc.ShortcutText = ""
        Me.BarReCPCanc.Text = "Cancelación carta porte"
        '
        'BarReimpMasiva
        '
        Me.BarReimpMasiva.Command = Me.BarMReimpMasiva
        Me.BarReimpMasiva.SortOrder = 3
        Me.BarReimpMasiva.Text = "Reimpresión masiva"
        '
        'BarMReimpMasiva
        '
        Me.BarMReimpMasiva.Image = Global.SGT_Transport.My.Resources.Resources.impresora17
        Me.BarMReimpMasiva.Name = "BarMReimpMasiva"
        Me.BarMReimpMasiva.ShortcutText = ""
        Me.BarMReimpMasiva.Text = "Reimpresión masiva"
        '
        'BarEstatusCFDI
        '
        Me.BarEstatusCFDI.Image = Global.SGT_Transport.My.Resources.Resources.status14
        Me.BarEstatusCFDI.Name = "BarEstatusCFDI"
        Me.BarEstatusCFDI.ShortcutText = ""
        Me.BarEstatusCFDI.Text = "Estatus CFDI"
        '
        'BarEnviarcorreo
        '
        Me.BarEnviarcorreo.Image = Global.SGT_Transport.My.Resources.Resources.D5
        Me.BarEnviarcorreo.Name = "BarEnviarcorreo"
        Me.BarEnviarcorreo.ShortcutText = ""
        Me.BarEnviarcorreo.Text = "Enviar correo"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarExtraerXML
        '
        Me.BarExtraerXML.Image = Global.SGT_Transport.My.Resources.Resources.xmln1
        Me.BarExtraerXML.Name = "BarExtraerXML"
        Me.BarExtraerXML.ShortcutText = ""
        Me.BarExtraerXML.Text = "Extraer XML"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutText = ""
        Me.BarCancelar.ShowShortcut = False
        Me.BarCancelar.ShowTextAsToolTip = False
        Me.BarCancelar.Text = "Cancelar carta porte"
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
        'BarExtraeXML
        '
        Me.BarExtraeXML.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.BarExtraeSelect, Me.BarExtraerTodos})
        Me.BarExtraeXML.HideNonRecentLinks = False
        Me.BarExtraeXML.Image = Global.SGT_Transport.My.Resources.Resources.xmln1
        Me.BarExtraeXML.ImageBarWidth = 60
        Me.BarExtraeXML.Name = "BarExtraeXML"
        Me.BarExtraeXML.ShortcutText = ""
        Me.BarExtraeXML.Text = "Extraer XML"
        Me.BarExtraeXML.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarExtraeXML.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarExtraeXML.Width = 40
        '
        'BarExtraeSelect
        '
        Me.BarExtraeSelect.Command = Me.BarExtraSel
        Me.BarExtraeSelect.Text = "Extraer seleccionados"
        '
        'BarExtraSel
        '
        Me.BarExtraSel.Image = Global.SGT_Transport.My.Resources.Resources.xmln4
        Me.BarExtraSel.Name = "BarExtraSel"
        Me.BarExtraSel.ShortcutText = ""
        Me.BarExtraSel.Text = "Extraer seleccionados"
        '
        'BarExtraerTodos
        '
        Me.BarExtraerTodos.Command = Me.BarExtraTodos
        Me.BarExtraerTodos.SortOrder = 1
        Me.BarExtraerTodos.Text = "Extraer todos"
        '
        'BarExtraTodos
        '
        Me.BarExtraTodos.Image = Global.SGT_Transport.My.Resources.Resources.xmln2
        Me.BarExtraTodos.Name = "BarExtraTodos"
        Me.BarExtraTodos.ShortcutText = ""
        Me.BarExtraTodos.Text = "Extraer todos"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(857, 10)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 200
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(278, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 345
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 74)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 22
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1047, 383)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 343
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.Border.Width = 4
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 95
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LKMainPrinter, Me.LkCancelar, Me.LkEstatusCFDI, Me.LkEnviarcorreo, Me.LkExtraerXML, Me.LkActualizar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1147, 72)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.Wrap = True
        Me.C1ToolBar1.WrapText = True
        '
        'LKMainPrinter
        '
        Me.LKMainPrinter.Command = Me.BarMenu
        Me.LKMainPrinter.Delimiter = True
        Me.LKMainPrinter.Text = "Re - Impresión"
        '
        'LkCancelar
        '
        Me.LkCancelar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCancelar.Command = Me.BarCancelar
        Me.LkCancelar.Delimiter = True
        Me.LkCancelar.SortOrder = 1
        Me.LkCancelar.Text = "Cancelar carta porte"
        Me.LkCancelar.ToolTipText = "Cancelar"
        '
        'LkEstatusCFDI
        '
        Me.LkEstatusCFDI.Command = Me.BarEstatusCFDI
        Me.LkEstatusCFDI.Delimiter = True
        Me.LkEstatusCFDI.SortOrder = 2
        Me.LkEstatusCFDI.Text = "Estatus CFDI"
        '
        'LkEnviarcorreo
        '
        Me.LkEnviarcorreo.Command = Me.BarEnviarcorreo
        Me.LkEnviarcorreo.Delimiter = True
        Me.LkEnviarcorreo.SortOrder = 3
        Me.LkEnviarcorreo.Text = "Enviar correo"
        '
        'LkExtraerXML
        '
        Me.LkExtraerXML.Command = Me.BarExtraeXML
        Me.LkExtraerXML.Delimiter = True
        Me.LkExtraerXML.SortOrder = 4
        Me.LkExtraerXML.Text = "Extraer XML"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.DefaultItem = True
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 5
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 6
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 7
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'LtNUm
        '
        Me.LtNUm.AutoSize = True
        Me.LtNUm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNUm.Location = New System.Drawing.Point(602, 29)
        Me.LtNUm.Name = "LtNUm"
        Me.LtNUm.Size = New System.Drawing.Size(42, 16)
        Me.LtNUm.TabIndex = 347
        Me.LtNUm.Text = "_____"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "243f72f0b0f241ce883f7da7d33e7599"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmCFDICartaPorteConcen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 560)
        Me.Controls.Add(Me.LtNUm)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCFDICartaPorteConcen"
        Me.Text = "CFDI Cartas porte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarExcel As C1.Win.C1Command.C1Command
    Private WithEvents BarCancelar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancelar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarExtraerXML As C1.Win.C1Command.C1Command
    Friend WithEvents LkExtraerXML As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarMenu As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents BarCpSinPrecios As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarCpConPrecios As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LKMainPrinter As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarCPCanc As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarReCPSinPrec As C1.Win.C1Command.C1Command
    Friend WithEvents BarReCPConPrec As C1.Win.C1Command.C1Command
    Friend WithEvents BarReCPCanc As C1.Win.C1Command.C1Command
    Friend WithEvents BarEstatusCFDI As C1.Win.C1Command.C1Command
    Friend WithEvents LkEstatusCFDI As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LtNUm As Label
    Friend WithEvents BarEnviarcorreo As C1.Win.C1Command.C1Command
    Friend WithEvents LkEnviarcorreo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents BarReimpMasiva As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarMReimpMasiva As C1.Win.C1Command.C1Command
    Friend WithEvents BarExtraeXML As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents BarExtraeSelect As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarExtraSel As C1.Win.C1Command.C1Command
    Friend WithEvents BarExtraerTodos As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarExtraTodos As C1.Win.C1Command.C1Command
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
