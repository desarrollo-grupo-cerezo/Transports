<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientesOperativos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesOperativos))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TAB2 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage5 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1DockingTabPage6 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgR2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TAB3 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1DockingTabPage4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgD2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarMenu.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.TAB2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB2.SuspendLayout()
        Me.C1DockingTabPage5.SuspendLayout()
        Me.C1DockingTabPage6.SuspendLayout()
        CType(Me.FgR2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.TAB3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB3.SuspendLayout()
        Me.C1DockingTabPage3.SuspendLayout()
        Me.C1DockingTabPage4.SuspendLayout()
        CType(Me.FgD2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(16, 15)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(503, 340)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BarMenu
        '
        Me.BarMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarRefresh, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(1036, 55)
        Me.BarMenu.TabIndex = 10
        Me.BarMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarMenu, "Office2010Blue")
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(54, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 51)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(62, 51)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRefresh
        '
        Me.BarRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRefresh.ForeColor = System.Drawing.Color.Black
        Me.BarRefresh.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRefresh.Size = New System.Drawing.Size(71, 51)
        Me.BarRefresh.Text = "Actualizar"
        Me.BarRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(670, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 100
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(308, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 14
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.Location = New System.Drawing.Point(82, 27)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(536, 311)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.Fg2, "Office2010Blue")
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(437, 23)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(67, 13)
        Me.Lt1.TabIndex = 17
        Me.Lt1.Text = "__________"
        Me.C1ThemeController1.SetTheme(Me.Lt1, "(default)")
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.ItemSize = New System.Drawing.Size(0, 45)
        Me.Tab1.Location = New System.Drawing.Point(12, 89)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(991, 471)
        Me.Tab1.TabAreaBorder = True
        Me.Tab1.TabIndex = 18
        Me.Tab1.TabsSpacing = 5
        Me.C1ThemeController1.SetTheme(Me.Tab1, "(default)")
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.TAB2)
        Me.Pag1.Location = New System.Drawing.Point(1, 48)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(989, 422)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Remitentes"
        '
        'TAB2
        '
        Me.TAB2.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TAB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB2.Controls.Add(Me.C1DockingTabPage5)
        Me.TAB2.Controls.Add(Me.C1DockingTabPage6)
        Me.TAB2.ItemSize = New System.Drawing.Size(0, 35)
        Me.TAB2.Location = New System.Drawing.Point(20, 16)
        Me.TAB2.Name = "TAB2"
        Me.TAB2.SelectedTabBold = True
        Me.TAB2.Size = New System.Drawing.Size(814, 383)
        Me.TAB2.TabAreaBorder = True
        Me.TAB2.TabIndex = 14
        Me.TAB2.TabsSpacing = 5
        Me.TAB2.TextDirection = C1.Win.C1Command.TabTextDirectionEnum.Horizontal
        Me.C1ThemeController1.SetTheme(Me.TAB2, "(default)")
        Me.TAB2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage5
        '
        Me.C1DockingTabPage5.Controls.Add(Me.Fg)
        Me.C1DockingTabPage5.Location = New System.Drawing.Point(1, 1)
        Me.C1DockingTabPage5.Name = "C1DockingTabPage5"
        Me.C1DockingTabPage5.Size = New System.Drawing.Size(812, 344)
        Me.C1DockingTabPage5.TabIndex = 0
        Me.C1DockingTabPage5.Text = "Activos"
        '
        'C1DockingTabPage6
        '
        Me.C1DockingTabPage6.Controls.Add(Me.FgR2)
        Me.C1DockingTabPage6.Location = New System.Drawing.Point(1, 1)
        Me.C1DockingTabPage6.Name = "C1DockingTabPage6"
        Me.C1DockingTabPage6.Size = New System.Drawing.Size(812, 344)
        Me.C1DockingTabPage6.TabIndex = 1
        Me.C1DockingTabPage6.Text = "Cancelados"
        '
        'FgR2
        '
        Me.FgR2.AllowEditing = False
        Me.FgR2.AllowFiltering = True
        Me.FgR2.BackColor = System.Drawing.Color.White
        Me.FgR2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgR2.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.FgR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgR2.ForeColor = System.Drawing.Color.Black
        Me.FgR2.Location = New System.Drawing.Point(138, 24)
        Me.FgR2.Name = "FgR2"
        Me.FgR2.Rows.Count = 1
        Me.FgR2.Rows.DefaultSize = 19
        Me.FgR2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgR2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgR2.Size = New System.Drawing.Size(536, 311)
        Me.FgR2.StyleInfo = resources.GetString("FgR2.StyleInfo")
        Me.FgR2.TabIndex = 13
        Me.C1ThemeController1.SetTheme(Me.FgR2, "Office2010Blue")
        Me.FgR2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Pag2
        '
        Me.Pag2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Pag2.Controls.Add(Me.TAB3)
        Me.Pag2.Location = New System.Drawing.Point(1, 48)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(989, 422)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Destinatario"
        '
        'TAB3
        '
        Me.TAB3.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TAB3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB3.Controls.Add(Me.C1DockingTabPage3)
        Me.TAB3.Controls.Add(Me.C1DockingTabPage4)
        Me.TAB3.ItemSize = New System.Drawing.Size(0, 35)
        Me.TAB3.Location = New System.Drawing.Point(81, 16)
        Me.TAB3.Name = "TAB3"
        Me.TAB3.SelectedTabBold = True
        Me.TAB3.Size = New System.Drawing.Size(814, 383)
        Me.TAB3.TabAreaBorder = True
        Me.TAB3.TabIndex = 13
        Me.TAB3.TabsSpacing = 5
        Me.TAB3.TextDirection = C1.Win.C1Command.TabTextDirectionEnum.Horizontal
        Me.C1ThemeController1.SetTheme(Me.TAB3, "(default)")
        Me.TAB3.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.Controls.Add(Me.Fg2)
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 1)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(812, 344)
        Me.C1DockingTabPage3.TabIndex = 0
        Me.C1DockingTabPage3.Text = "Activos"
        '
        'C1DockingTabPage4
        '
        Me.C1DockingTabPage4.Controls.Add(Me.FgD2)
        Me.C1DockingTabPage4.Location = New System.Drawing.Point(1, 1)
        Me.C1DockingTabPage4.Name = "C1DockingTabPage4"
        Me.C1DockingTabPage4.Size = New System.Drawing.Size(812, 344)
        Me.C1DockingTabPage4.TabIndex = 1
        Me.C1DockingTabPage4.Text = "Cancelados"
        '
        'FgD2
        '
        Me.FgD2.AllowEditing = False
        Me.FgD2.AllowFiltering = True
        Me.FgD2.BackColor = System.Drawing.Color.White
        Me.FgD2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgD2.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.FgD2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgD2.ForeColor = System.Drawing.Color.Black
        Me.FgD2.Location = New System.Drawing.Point(138, 24)
        Me.FgD2.Name = "FgD2"
        Me.FgD2.Rows.Count = 1
        Me.FgD2.Rows.DefaultSize = 19
        Me.FgD2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgD2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgD2.Size = New System.Drawing.Size(536, 311)
        Me.FgD2.StyleInfo = resources.GetString("FgD2.StyleInfo")
        Me.FgD2.TabIndex = 13
        Me.C1ThemeController1.SetTheme(Me.FgD2, "Office2010Blue")
        Me.FgD2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'FrmClientesOperativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 582)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BarMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmClientesOperativos"
        Me.Text = "Clientes operativos"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        CType(Me.TAB2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB2.ResumeLayout(False)
        Me.C1DockingTabPage5.ResumeLayout(False)
        Me.C1DockingTabPage6.ResumeLayout(False)
        CType(Me.FgR2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        CType(Me.TAB3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB3.ResumeLayout(False)
        Me.C1DockingTabPage3.ResumeLayout(False)
        Me.C1DockingTabPage4.ResumeLayout(False)
        CType(Me.FgD2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BarRefresh As ToolStripMenuItem
    Friend WithEvents Lt1 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TAB3 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgD2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TAB2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage5 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage6 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgR2 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
