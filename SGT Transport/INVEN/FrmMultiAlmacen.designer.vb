<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMultiAlmacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMultiAlmacen))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCrearAlmacenes = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sep2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboAlmacen = New System.Windows.Forms.ToolStripComboBox()
        Me.Sep1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.barAlm1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.barAlm2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.barAlm3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 55)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(1172, 436)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 9
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.barEliminar, Me.barActualizar, Me.barCrearAlmacenes, Me.Sep2, Me.cboAlmacen, Me.Sep1, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1172, 55)
        Me.barSalir.TabIndex = 8
        Me.barSalir.Text = "MenuStrip1"
        '
        'barNuevo
        '
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
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEliminar.Size = New System.Drawing.Size(62, 51)
        Me.barEliminar.Text = "Eliminar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barActualizar
        '
        Me.barActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.barActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barActualizar.Name = "barActualizar"
        Me.barActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barActualizar.Size = New System.Drawing.Size(71, 51)
        Me.barActualizar.Text = "Actualizar"
        Me.barActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCrearAlmacenes
        '
        Me.barCrearAlmacenes.Image = Global.SGT_Transport.My.Resources.Resources.MULT1
        Me.barCrearAlmacenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCrearAlmacenes.Name = "barCrearAlmacenes"
        Me.barCrearAlmacenes.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barCrearAlmacenes.Size = New System.Drawing.Size(106, 51)
        Me.barCrearAlmacenes.Text = "Crear almacenes"
        Me.barCrearAlmacenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Size = New System.Drawing.Size(34, 51)
        Me.Sep2.Text = "     "
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cboAlmacen.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboAlmacen.ForeColor = System.Drawing.Color.Black
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(150, 51)
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Size = New System.Drawing.Size(34, 51)
        Me.Sep1.Text = "     "
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAlm1, Me.barAlm2, Me.barAlm3})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 491)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1172, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'barAlm1
        '
        Me.barAlm1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.barAlm1.ForeColor = System.Drawing.Color.White
        Me.barAlm1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAlm1.Name = "barAlm1"
        Me.barAlm1.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barAlm1.Size = New System.Drawing.Size(50, 20)
        Me.barAlm1.Text = "Todos"
        Me.barAlm1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barAlm1.ToolTipText = "F2-Nuevo"
        '
        'barAlm2
        '
        Me.barAlm2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.barAlm2.ForeColor = System.Drawing.Color.White
        Me.barAlm2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAlm2.Name = "barAlm2"
        Me.barAlm2.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barAlm2.Size = New System.Drawing.Size(63, 20)
        Me.barAlm2.Text = "Exist > 0"
        Me.barAlm2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barAlm3
        '
        Me.barAlm3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.barAlm3.ForeColor = System.Drawing.Color.White
        Me.barAlm3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAlm3.Name = "barAlm3"
        Me.barAlm3.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barAlm3.Size = New System.Drawing.Size(104, 20)
        Me.barAlm3.Text = "Predeterminado"
        Me.barAlm3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(688, 5)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(357, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 20
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'frmMultiAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 515)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.barSalir)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMultiAlmacen"
        Me.Text = "Multialmacen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents barAlm1 As ToolStripMenuItem
    Friend WithEvents barAlm2 As ToolStripMenuItem
    Friend WithEvents barAlm3 As ToolStripMenuItem
    Friend WithEvents cboAlmacen As ToolStripComboBox
    Friend WithEvents Sep2 As ToolStripMenuItem
    Friend WithEvents Sep1 As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents barCrearAlmacenes As ToolStripMenuItem
    Friend WithEvents barActualizar As ToolStripMenuItem
End Class
