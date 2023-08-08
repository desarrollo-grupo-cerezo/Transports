<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFOLIOSC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFOLIOSC))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraCompras = New System.Windows.Forms.MenuStrip()
        Me.BarDocNUevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRecepcion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarOrdeCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRequisicon = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGastos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPreOrdenCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraCompras.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 70)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(508, 240)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarraCompras
        '
        Me.BarraCompras.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraCompras.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDocNUevo, Me.BarEdit, Me.BarCompras, Me.BarRecepcion, Me.BarOrdeCompra, Me.BarRequisicon, Me.BarGastos, Me.BarPreOrdenCompra, Me.barSalir})
        Me.BarraCompras.Location = New System.Drawing.Point(0, 0)
        Me.BarraCompras.Name = "BarraCompras"
        Me.BarraCompras.Size = New System.Drawing.Size(707, 53)
        Me.BarraCompras.TabIndex = 13
        Me.BarraCompras.Text = "MenuStrip1"
        '
        'BarDocNUevo
        '
        Me.BarDocNUevo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarDocNUevo.ForeColor = System.Drawing.Color.Black
        Me.BarDocNUevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarDocNUevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDocNUevo.Name = "BarDocNUevo"
        Me.BarDocNUevo.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDocNUevo.Size = New System.Drawing.Size(52, 49)
        Me.BarDocNUevo.Text = "Nuevo"
        Me.BarDocNUevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEdit.Size = New System.Drawing.Size(44, 49)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCompras
        '
        Me.BarCompras.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarCompras.ForeColor = System.Drawing.Color.Black
        Me.BarCompras.Image = Global.SGT_Transport.My.Resources.Resources.letra_c
        Me.BarCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCompras.Name = "BarCompras"
        Me.BarCompras.ShortcutKeyDisplayString = ""
        Me.BarCompras.ShowShortcutKeys = False
        Me.BarCompras.Size = New System.Drawing.Size(64, 49)
        Me.BarCompras.Text = "Compras"
        Me.BarCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRecepcion
        '
        Me.BarRecepcion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarRecepcion.ForeColor = System.Drawing.Color.Black
        Me.BarRecepcion.Image = Global.SGT_Transport.My.Resources.Resources.letra_r
        Me.BarRecepcion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRecepcion.Name = "BarRecepcion"
        Me.BarRecepcion.Size = New System.Drawing.Size(83, 49)
        Me.BarRecepcion.Text = "Recepciones"
        Me.BarRecepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarOrdeCompra
        '
        Me.BarOrdeCompra.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarOrdeCompra.ForeColor = System.Drawing.Color.Black
        Me.BarOrdeCompra.Image = Global.SGT_Transport.My.Resources.Resources.letra_o
        Me.BarOrdeCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarOrdeCompra.Name = "BarOrdeCompra"
        Me.BarOrdeCompra.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarOrdeCompra.Size = New System.Drawing.Size(109, 49)
        Me.BarOrdeCompra.Text = "Orden de compra"
        Me.BarOrdeCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRequisicon
        '
        Me.BarRequisicon.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarRequisicon.ForeColor = System.Drawing.Color.Black
        Me.BarRequisicon.Image = Global.SGT_Transport.My.Resources.Resources.letra_q
        Me.BarRequisicon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRequisicon.Name = "BarRequisicon"
        Me.BarRequisicon.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRequisicon.Size = New System.Drawing.Size(79, 49)
        Me.BarRequisicon.Text = "Requisición"
        Me.BarRequisicon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGastos
        '
        Me.BarGastos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarGastos.ForeColor = System.Drawing.Color.Black
        Me.BarGastos.Image = Global.SGT_Transport.My.Resources.Resources.letra_g
        Me.BarGastos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGastos.Name = "BarGastos"
        Me.BarGastos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarGastos.Size = New System.Drawing.Size(54, 49)
        Me.BarGastos.Text = "Gastos"
        Me.BarGastos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarPreOrdenCompra
        '
        Me.BarPreOrdenCompra.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarPreOrdenCompra.ForeColor = System.Drawing.Color.Black
        Me.BarPreOrdenCompra.Image = Global.SGT_Transport.My.Resources.Resources.letra_p1
        Me.BarPreOrdenCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPreOrdenCompra.Name = "BarPreOrdenCompra"
        Me.BarPreOrdenCompra.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarPreOrdenCompra.Size = New System.Drawing.Size(129, 49)
        Me.BarPreOrdenCompra.Text = "Pre-Orden de compra"
        Me.BarPreOrdenCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 49)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FrmFOLIOSC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 322)
        Me.Controls.Add(Me.BarraCompras)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFOLIOSC"
        Me.ShowInTaskbar = False
        Me.Text = "Series compras"
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraCompras.ResumeLayout(False)
        Me.BarraCompras.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraCompras As MenuStrip
    Friend WithEvents BarCompras As ToolStripMenuItem
    Friend WithEvents BarRecepcion As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents BarOrdeCompra As ToolStripMenuItem
    Friend WithEvents BarRequisicon As ToolStripMenuItem
    Friend WithEvents BarDocNUevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarGastos As ToolStripMenuItem
    Friend WithEvents BarPreOrdenCompra As ToolStripMenuItem
End Class
