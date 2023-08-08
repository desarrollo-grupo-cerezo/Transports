<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMinveSeguimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMinveSeguimiento))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarGenMinve = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarKardex = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkGenMinve = New C1.Win.C1Command.C1CommandLink()
        Me.LkKardex = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.chOcultarMovsRealzaidos = New C1.Win.C1Input.C1CheckBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chOcultarMovsRealzaidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarGenMinve)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarKardex)
        Me.MenuHolder.Owner = Me
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
        'BarGenMinve
        '
        Me.BarGenMinve.Image = Global.SGT_Transport.My.Resources.Resources.Mov_invent
        Me.BarGenMinve.Name = "BarGenMinve"
        Me.BarGenMinve.ShortcutText = ""
        Me.BarGenMinve.Text = "Genererar movimiento al inventario"
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
        'BarKardex
        '
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.K
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.ShortcutText = ""
        Me.BarKardex.Text = "Kardex"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookEnforceVert = True
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkGenMinve, Me.LkKardex, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1134, 69)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.Wrap = True
        Me.C1ToolBar1.WrapText = True
        '
        'LkDesplegar
        '
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = " Desplegar"
        '
        'LkGenMinve
        '
        Me.LkGenMinve.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGenMinve.Command = Me.BarGenMinve
        Me.LkGenMinve.Delimiter = True
        Me.LkGenMinve.SortOrder = 1
        Me.LkGenMinve.Text = "Genererar movimiento al inventario"
        Me.LkGenMinve.ToolTipText = ""
        '
        'LkKardex
        '
        Me.LkKardex.Command = Me.BarKardex
        Me.LkKardex.SortOrder = 2
        Me.LkKardex.Text = "Kardex"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.SortOrder = 3
        Me.LkExcel.Text = " Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.Text = " Salir"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 75)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1027, 292)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(601, 35)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(109, 13)
        Me.Lt1.TabIndex = 13
        Me.Lt1.Text = "_________________"
        '
        'chOcultarMovsRealzaidos
        '
        Me.chOcultarMovsRealzaidos.BackColor = System.Drawing.Color.Transparent
        Me.chOcultarMovsRealzaidos.BorderColor = System.Drawing.Color.Transparent
        Me.chOcultarMovsRealzaidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chOcultarMovsRealzaidos.ForeColor = System.Drawing.Color.Black
        Me.chOcultarMovsRealzaidos.Location = New System.Drawing.Point(338, 29)
        Me.chOcultarMovsRealzaidos.Name = "chOcultarMovsRealzaidos"
        Me.chOcultarMovsRealzaidos.Padding = New System.Windows.Forms.Padding(1)
        Me.chOcultarMovsRealzaidos.Size = New System.Drawing.Size(185, 24)
        Me.chOcultarMovsRealzaidos.TabIndex = 14
        Me.chOcultarMovsRealzaidos.Text = "Mostrar todos lo movimientos"
        Me.chOcultarMovsRealzaidos.UseVisualStyleBackColor = False
        Me.chOcultarMovsRealzaidos.Value = Nothing
        Me.chOcultarMovsRealzaidos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FrmMinveSeguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 402)
        Me.Controls.Add(Me.chOcultarMovsRealzaidos)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMinveSeguimiento"
        Me.Text = "Validacion movimientos al inventario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chOcultarMovsRealzaidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarGenMinve As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkGenMinve As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Lt1 As Label
    Friend WithEvents chOcultarMovsRealzaidos As C1.Win.C1Input.C1CheckBox
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarKardex As C1.Win.C1Command.C1Command
    Friend WithEvents LkKardex As C1.Win.C1Command.C1CommandLink
End Class
