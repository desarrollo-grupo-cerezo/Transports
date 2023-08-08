<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicionCombustible
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicionCombustible))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.barEliminar, Me.BarExcel, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1145, 55)
        Me.barSalir.TabIndex = 10
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(54, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'barEdit
        '
        Me.barEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEdit.ForeColor = System.Drawing.Color.Black
        Me.barEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.barEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEdit.Name = "barEdit"
        Me.barEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barEdit.Size = New System.Drawing.Size(44, 51)
        Me.barEdit.Text = "Edit"
        Me.barEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEliminar.ShowShortcutKeys = False
        Me.barEliminar.Size = New System.Drawing.Size(65, 51)
        Me.barEliminar.Text = "Cancelar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(639, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 500
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(363, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
        Me.C1FlexGridSearchPanel1.Watermark = "Introdusca texto a buscar"
        '
        'frmMedicionCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 582)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMedicionCombustible"
        Me.Text = "Medición Combustible"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BarExcel As ToolStripMenuItem
End Class
