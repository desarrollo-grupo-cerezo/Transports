<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaCxC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaCxC))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.BarRefresch = New System.Windows.Forms.ToolStripMenuItem()
        Me.barMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.BarRefresch, Me.barSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(925, 55)
        Me.barMenu.TabIndex = 10
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
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.Fg.Location = New System.Drawing.Point(12, 70)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(386, 8)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(357, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 18
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'C1ThemeController1
        '
        Me.C1ThemeController1.Theme = "Office2010Blue"
        '
        'BarRefresch
        '
        Me.BarRefresch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarRefresch.ForeColor = System.Drawing.Color.Black
        Me.BarRefresch.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarRefresch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefresch.Name = "BarRefresch"
        Me.BarRefresch.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarRefresch.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarRefresch.Size = New System.Drawing.Size(74, 51)
        Me.BarRefresch.Text = "Actualizar"
        Me.BarRefresch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarRefresch.ToolTipText = "F2-Nuevo"
        '
        'frmAltaCxC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 618)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAltaCxC"
        Me.Text = "Alta cuentas x cobrar"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BarRefresch As ToolStripMenuItem
End Class
