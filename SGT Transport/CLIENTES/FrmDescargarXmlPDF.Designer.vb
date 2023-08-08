<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDescargarXmlPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescargarXmlPDF))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDescargar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkCorreo = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.BtnDoc = New System.Windows.Forms.Button()
        Me.TRUTA_DOC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1CheckBox1 = New C1.Win.C1Input.C1CheckBox()
        Me.C1List1 = New C1.Win.C1List.C1List()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDescargar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDescargar
        '
        Me.BarDescargar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar71
        Me.BarDescargar.Name = "BarDescargar"
        Me.BarDescargar.ShortcutText = ""
        Me.BarDescargar.ShowShortcut = False
        Me.BarDescargar.ShowTextAsToolTip = False
        Me.BarDescargar.Text = "Descargar"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkCorreo, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(622, 57)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'LkCorreo
        '
        Me.LkCorreo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCorreo.Command = Me.BarDescargar
        Me.LkCorreo.Delimiter = True
        Me.LkCorreo.Text = "Descargar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'BtnDoc
        '
        Me.BtnDoc.Location = New System.Drawing.Point(574, 288)
        Me.BtnDoc.Name = "BtnDoc"
        Me.BtnDoc.Size = New System.Drawing.Size(27, 23)
        Me.BtnDoc.TabIndex = 9
        Me.BtnDoc.Text = "....."
        Me.BtnDoc.UseVisualStyleBackColor = True
        '
        'TRUTA_DOC
        '
        Me.TRUTA_DOC.AcceptsReturn = True
        Me.TRUTA_DOC.AcceptsTab = True
        Me.TRUTA_DOC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRUTA_DOC.Location = New System.Drawing.Point(12, 314)
        Me.TRUTA_DOC.Name = "TRUTA_DOC"
        Me.TRUTA_DOC.Size = New System.Drawing.Size(589, 21)
        Me.TRUTA_DOC.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Seleccione carpeta a donde se descargaran el XML y PDF"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Descarga XML"
        Me.StiReport1.ReportGuid = "5eed13623f134001ae1d5b1e63d99857"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Descarga XML"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'C1CheckBox1
        '
        Me.C1CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox1.Checked = True
        Me.C1CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.C1CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox1.Location = New System.Drawing.Point(28, 341)
        Me.C1CheckBox1.Name = "C1CheckBox1"
        Me.C1CheckBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox1.Size = New System.Drawing.Size(236, 19)
        Me.C1CheckBox1.TabIndex = 12
        Me.C1CheckBox1.Text = "Abrir carpeta al finalizar la descarga"
        Me.C1CheckBox1.UseVisualStyleBackColor = False
        Me.C1CheckBox1.Value = True
        Me.C1CheckBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.SystemColors.Control
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Documentos"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.Control
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(86, 63)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Color = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.MultiSimple
        Me.C1List1.Size = New System.Drawing.Size(473, 214)
        Me.C1List1.TabIndex = 363
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'FrmDescargarXmlPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 380)
        Me.Controls.Add(Me.C1List1)
        Me.Controls.Add(Me.C1CheckBox1)
        Me.Controls.Add(Me.BtnDoc)
        Me.Controls.Add(Me.TRUTA_DOC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDescargarXmlPDF"
        Me.ShowInTaskbar = False
        Me.Text = "Descarga de XML y PDF"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDescargar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkCorreo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BtnDoc As Button
    Friend WithEvents TRUTA_DOC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1CheckBox1 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
End Class
