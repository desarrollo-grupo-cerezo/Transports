<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeducciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeducciones))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.TabIndex = 14
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.barEliminar, Me.BarExcel, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(737, 55)
        Me.barSalir.TabIndex = 13
        Me.barSalir.Text = "MenuStrip1"
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
        Me.barEliminar.Size = New System.Drawing.Size(62, 51)
        Me.barEliminar.Text = "Eliminar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(62, 51)
        Me.BarExcel.Text = "Eliminar"
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
        'frmDeducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 491)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDeducciones"
        Me.Text = "Deducciones"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
End Class
