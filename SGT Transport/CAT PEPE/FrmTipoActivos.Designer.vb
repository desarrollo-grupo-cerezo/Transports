<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoActivos
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoActivos))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
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
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(55, 116)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(540, 206)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarRefresh, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(800, 55)
        Me.BarraMenu.TabIndex = 11
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(56, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
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
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(63, 51)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRefresh
        '
        Me.BarRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarRefresh.ForeColor = System.Drawing.Color.Black
        Me.BarRefresh.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRefresh.Size = New System.Drawing.Size(74, 51)
        Me.BarRefresh.Text = "Actualizar"
        Me.BarRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(63, 51)
        Me.BarExcel.Text = "Eliminar"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(531, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 500
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(218, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 16
        Me.C1FlexGridSearchPanel1.Watermark = "Introdusca texto a buscar"
        '
        'FrmTipoActivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTipoActivos"
        Me.Text = "Activos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents BarRefresh As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
End Class
