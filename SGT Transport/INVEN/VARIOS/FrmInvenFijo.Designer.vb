<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvenFijo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvenFijo))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.barPrecios = New System.Windows.Forms.ToolStripMenuItem()
        Me.barBaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.btnEliminar, Me.barRefresh, Me.barPrecios, Me.barBaja, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1155, 55)
        Me.barSalir.TabIndex = 11
        Me.barSalir.Text = "MenuStrip1"
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(56, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'barEdit
        '
        Me.barEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEdit.ForeColor = System.Drawing.Color.Black
        Me.barEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.barEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEdit.Name = "barEdit"
        Me.barEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barEdit.Size = New System.Drawing.Size(44, 51)
        Me.barEdit.Text = "Edit"
        Me.barEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.eliminar7
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnEliminar.Size = New System.Drawing.Size(63, 51)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barRefresh
        '
        Me.barRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barRefresh.ForeColor = System.Drawing.Color.Black
        Me.barRefresh.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.barRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRefresh.Name = "barRefresh"
        Me.barRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barRefresh.Size = New System.Drawing.Size(73, 51)
        Me.barRefresh.Text = "Refrescar"
        Me.barRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barPrecios
        '
        Me.barPrecios.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barPrecios.ForeColor = System.Drawing.Color.Black
        Me.barPrecios.Image = Global.SGT_Transport.My.Resources.Resources.CP
        Me.barPrecios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barPrecios.Name = "barPrecios"
        Me.barPrecios.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barPrecios.Size = New System.Drawing.Size(59, 51)
        Me.barPrecios.Text = "Precios"
        Me.barPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barBaja
        '
        Me.barBaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barBaja.ForeColor = System.Drawing.Color.Black
        Me.barBaja.Image = Global.SGT_Transport.My.Resources.Resources.letrar
        Me.barBaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barBaja.Name = "barBaja"
        Me.barBaja.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barBaja.Size = New System.Drawing.Size(96, 51)
        Me.barBaja.Text = "Registros baja"
        Me.barBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "51,1,0,0,0,95,Columns:"
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 61)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowErrors = True
        Me.Fg.Size = New System.Drawing.Size(1148, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Lt
        '
        Me.Lt.Location = New System.Drawing.Point(1033, 22)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(213, 23)
        Me.Lt.TabIndex = 18
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(532, 5)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(357, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 19
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'frmInvenFijo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 642)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInvenFijo"
        Me.Text = "frmInvenFijo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents barRefresh As ToolStripMenuItem
    Friend WithEvents barBaja As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Lt As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents barPrecios As ToolStripMenuItem
End Class
