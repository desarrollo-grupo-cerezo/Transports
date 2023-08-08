<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEstatusUnidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstatusUnidades))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarStatusUnidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarArmarKits = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesasignarKits = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarObser = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAsigOper = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesAsigOper = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAsigOperPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesAsigOperPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEstatusOper = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 6.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 73)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        '
        'BarMenu
        '
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarStatusUnidad, Me.BarArmarKits, Me.BarDesasignarKits, Me.BarProducto, Me.BarObser, Me.BarAsigOper, Me.BarDesAsigOper, Me.BarAsigOperPos, Me.BarDesAsigOperPos, Me.BarEstatusOper, Me.BarActualizar, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(1490, 54)
        Me.BarMenu.TabIndex = 10
        Me.BarMenu.Text = "MenuStrip1"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1257, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(222, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 20
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'BarStatusUnidad
        '
        Me.BarStatusUnidad.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarStatusUnidad.ForeColor = System.Drawing.Color.Black
        Me.BarStatusUnidad.Image = Global.SGT_Transport.My.Resources.Resources.semaforo
        Me.BarStatusUnidad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarStatusUnidad.Name = "BarStatusUnidad"
        Me.BarStatusUnidad.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarStatusUnidad.Size = New System.Drawing.Size(90, 50)
        Me.BarStatusUnidad.Text = "Estatus unidad"
        Me.BarStatusUnidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarProducto
        '
        Me.BarProducto.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarProducto.ForeColor = System.Drawing.Color.Black
        Me.BarProducto.Image = Global.SGT_Transport.My.Resources.Resources.ProducyServ
        Me.BarProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarProducto.Name = "BarProducto"
        Me.BarProducto.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarProducto.Size = New System.Drawing.Size(103, 50)
        Me.BarProducto.Text = "Asignar producto"
        Me.BarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarArmarKits
        '
        Me.BarArmarKits.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarArmarKits.ForeColor = System.Drawing.Color.Black
        Me.BarArmarKits.Image = Global.SGT_Transport.My.Resources.Resources.agrupar4
        Me.BarArmarKits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarArmarKits.Name = "BarArmarKits"
        Me.BarArmarKits.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarArmarKits.Size = New System.Drawing.Size(78, 50)
        Me.BarArmarKits.Text = "Asignar kit's"
        Me.BarArmarKits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDesasignarKits
        '
        Me.BarDesasignarKits.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarDesasignarKits.ForeColor = System.Drawing.Color.Black
        Me.BarDesasignarKits.Image = Global.SGT_Transport.My.Resources.Resources.desgarupar1
        Me.BarDesasignarKits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesasignarKits.Name = "BarDesasignarKits"
        Me.BarDesasignarKits.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDesasignarKits.Size = New System.Drawing.Size(95, 50)
        Me.BarDesasignarKits.Text = "Desasignar kit's"
        Me.BarDesasignarKits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarObser
        '
        Me.BarObser.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarObser.ForeColor = System.Drawing.Color.Black
        Me.BarObser.Image = Global.SGT_Transport.My.Resources.Resources.kobser
        Me.BarObser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarObser.Name = "BarObser"
        Me.BarObser.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarObser.Size = New System.Drawing.Size(93, 50)
        Me.BarObser.Text = "Observaciones"
        Me.BarObser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarAsigOper
        '
        Me.BarAsigOper.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarAsigOper.ForeColor = System.Drawing.Color.Black
        Me.BarAsigOper.Image = Global.SGT_Transport.My.Resources.Resources.conductor2
        Me.BarAsigOper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAsigOper.Name = "BarAsigOper"
        Me.BarAsigOper.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarAsigOper.Size = New System.Drawing.Size(104, 50)
        Me.BarAsigOper.Text = "Asignar operador"
        Me.BarAsigOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDesAsigOper
        '
        Me.BarDesAsigOper.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarDesAsigOper.ForeColor = System.Drawing.Color.Black
        Me.BarDesAsigOper.Image = Global.SGT_Transport.My.Resources.Resources.desoper2
        Me.BarDesAsigOper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesAsigOper.Name = "BarDesAsigOper"
        Me.BarDesAsigOper.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDesAsigOper.Size = New System.Drawing.Size(121, 50)
        Me.BarDesAsigOper.Text = "Desasignar operador"
        Me.BarDesAsigOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarAsigOperPos
        '
        Me.BarAsigOperPos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarAsigOperPos.ForeColor = System.Drawing.Color.Black
        Me.BarAsigOperPos.Image = Global.SGT_Transport.My.Resources.Resources.conductor2
        Me.BarAsigOperPos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAsigOperPos.Name = "BarAsigOperPos"
        Me.BarAsigOperPos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarAsigOperPos.Size = New System.Drawing.Size(111, 50)
        Me.BarAsigOperPos.Text = "Asig. oper. postura"
        Me.BarAsigOperPos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDesAsigOperPos
        '
        Me.BarDesAsigOperPos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarDesAsigOperPos.ForeColor = System.Drawing.Color.Black
        Me.BarDesAsigOperPos.Image = Global.SGT_Transport.My.Resources.Resources.desoper2
        Me.BarDesAsigOperPos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesAsigOperPos.Name = "BarDesAsigOperPos"
        Me.BarDesAsigOperPos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDesAsigOperPos.Size = New System.Drawing.Size(131, 50)
        Me.BarDesAsigOperPos.Text = "Desasig. oper.  postura"
        Me.BarDesAsigOperPos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEstatusOper
        '
        Me.BarEstatusOper.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarEstatusOper.ForeColor = System.Drawing.Color.Black
        Me.BarEstatusOper.Image = Global.SGT_Transport.My.Resources.Resources.status4
        Me.BarEstatusOper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEstatusOper.Name = "BarEstatusOper"
        Me.BarEstatusOper.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEstatusOper.Size = New System.Drawing.Size(102, 50)
        Me.BarEstatusOper.Text = "Estatus operador"
        Me.BarEstatusOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(68, 50)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 50)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FrmEstatusUnidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1490, 532)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEstatusUnidades"
        Me.Text = "Estatus Unidades"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents BarStatusUnidad As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents BarProducto As ToolStripMenuItem
    Friend WithEvents BarObser As ToolStripMenuItem
    Friend WithEvents BarArmarKits As ToolStripMenuItem
    Friend WithEvents BarDesasignarKits As ToolStripMenuItem
    Friend WithEvents BarAsigOper As ToolStripMenuItem
    Friend WithEvents BarDesAsigOper As ToolStripMenuItem
    Friend WithEvents BarAsigOperPos As ToolStripMenuItem
    Friend WithEvents BarDesAsigOperPos As ToolStripMenuItem
    Friend WithEvents BarEstatusOper As ToolStripMenuItem
End Class
