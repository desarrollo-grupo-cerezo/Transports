<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUnidades
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnidades))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarUnidadesEliminadas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.tBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarActualizar, Me.BarExcel, Me.BarUnidadesEliminadas, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1242, 55)
        Me.BarraMenu.TabIndex = 8
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
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
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 51)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(62, 51)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(48, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarUnidadesEliminadas
        '
        Me.BarUnidadesEliminadas.Image = Global.SGT_Transport.My.Resources.Resources.unidadroja
        Me.BarUnidadesEliminadas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarUnidadesEliminadas.Name = "BarUnidadesEliminadas"
        Me.BarUnidadesEliminadas.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarUnidadesEliminadas.Size = New System.Drawing.Size(128, 51)
        Me.BarUnidadesEliminadas.Text = "Unidades eliminadas"
        Me.BarUnidadesEliminadas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(4, 62)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 14
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(914, 6)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(310, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 15
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'tBox
        '
        Me.tBox.Location = New System.Drawing.Point(89, 14)
        Me.tBox.Name = "tBox"
        Me.tBox.Size = New System.Drawing.Size(237, 20)
        Me.tBox.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Texto a buscar"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(556, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 47)
        Me.Panel1.TabIndex = 18
        Me.Panel1.Visible = False
        '
        'FrmUnidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 558)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmUnidades"
        Me.Text = "Unidades"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents BarNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents tBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents BarUnidadesEliminadas As ToolStripMenuItem
End Class
