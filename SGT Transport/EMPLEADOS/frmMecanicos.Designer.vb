﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMecanicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMecanicos))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarMecEliminadas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.barEliminar, Me.BarActualizar, Me.BarMecEliminadas, Me.BarExcel, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(910, 55)
        Me.barSalir.TabIndex = 9
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
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 69)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(595, 468)
        Me.Fg.TabIndex = 10
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(572, 11)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(313, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 17
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'BarMecEliminadas
        '
        Me.BarMecEliminadas.Image = Global.SGT_Transport.My.Resources.Resources.usuario10
        Me.BarMecEliminadas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarMecEliminadas.Name = "BarMecEliminadas"
        Me.BarMecEliminadas.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarMecEliminadas.Size = New System.Drawing.Size(137, 51)
        Me.BarMecEliminadas.Text = "Mecánicos eliminados"
        Me.BarMecEliminadas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmMecanicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 659)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMecanicos"
        Me.Text = "frmMecanicos"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
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
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarMecEliminadas As ToolStripMenuItem
    Friend WithEvents BarActualizar As ToolStripMenuItem
End Class
