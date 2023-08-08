<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaMovsInvOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaMovsInvOT))
        Me.MenuHolder2 = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder2
        '
        Me.MenuHolder2.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder2.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder2.Commands.Add(Me.BarExcel)
        Me.MenuHolder2.Commands.Add(Me.BarSalir)
        Me.MenuHolder2.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.ShowShortcut = False
        Me.BarDesplegar.ShowTextAsToolTip = False
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(754, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 1
        Me.LkExcel.Text = "Excel"
        Me.LkExcel.ToolTipText = ""
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 5
        Me.Fg.Rows.DefaultSize = 25
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(642, 221)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 312
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(12, 71)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Size = New System.Drawing.Size(644, 282)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.TabIndex = 313
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.F2)
        Me.Split1.Controls.Add(Me.Label2)
        Me.Split1.Controls.Add(Me.Label3)
        Me.Split1.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Split1.Height = 55
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(642, 55)
        Me.Split1.SizeRatio = 19.928R
        Me.Split1.TabIndex = 0
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(59, 20)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 315
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(188, 20)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 316
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(27, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 15)
        Me.Label2.TabIndex = 317
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(165, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 318
        Me.Label3.Text = "al"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(341, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(301, 48)
        Me.C1FlexGridSearchPanel1.TabIndex = 314
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 221
        Me.Split2.Location = New System.Drawing.Point(1, 60)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(642, 221)
        Me.Split2.TabIndex = 1
        '
        'FrmConsultaMovsInvOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 520)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConsultaMovsInvOT"
        Me.Text = "Consulta movs. inv. OT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder2 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Private WithEvents BarExcel As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
