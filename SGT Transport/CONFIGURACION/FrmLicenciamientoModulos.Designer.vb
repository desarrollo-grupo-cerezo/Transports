<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLicenciamientoModulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLicenciamientoModulos))
        Me.MenuHolder2 = New C1.Win.C1Command.C1CommandHolder()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder2
        '
        Me.MenuHolder2.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder2.Commands.Add(Me.BarGrabar)
        Me.MenuHolder2.Commands.Add(Me.BarSalir)
        Me.MenuHolder2.Owner = Me
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(475, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
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
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 63)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.Size = New System.Drawing.Size(460, 210)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 6
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
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
        'FrmLicenciamientoModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 522)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLicenciamientoModulos"
        Me.Text = "Licenciamiento Modulos"
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder2 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
