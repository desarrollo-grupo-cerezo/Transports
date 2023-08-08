<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFOLIOSF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFOLIOSF))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarNotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRemisiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDevoluciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPagoComplemento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarFacturas, Me.BarNotas, Me.BarRemisiones, Me.BarPedidos, Me.BarCotizaciones, Me.BarDevoluciones, Me.BarPagoComplemento, Me.ToolStripMenuItem1, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(870, 53)
        Me.BarraMenu.TabIndex = 15
        Me.BarraMenu.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.BarraMenu, "Office2010Blue")
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarNuevo.Size = New System.Drawing.Size(52, 49)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'BarFacturas
        '
        Me.BarFacturas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarFacturas.ForeColor = System.Drawing.Color.Black
        Me.BarFacturas.Image = Global.SGT_Transport.My.Resources.Resources.recibo
        Me.BarFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarFacturas.Name = "BarFacturas"
        Me.BarFacturas.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarFacturas.Size = New System.Drawing.Size(62, 49)
        Me.BarFacturas.Text = "Facturas"
        Me.BarFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarNotas
        '
        Me.BarNotas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarNotas.ForeColor = System.Drawing.Color.Black
        Me.BarNotas.Image = Global.SGT_Transport.My.Resources.Resources.lista_de_precios2
        Me.BarNotas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNotas.Name = "BarNotas"
        Me.BarNotas.ShortcutKeyDisplayString = ""
        Me.BarNotas.ShowShortcutKeys = False
        Me.BarNotas.Size = New System.Drawing.Size(49, 49)
        Me.BarNotas.Text = "Notas"
        Me.BarNotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRemisiones
        '
        Me.BarRemisiones.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarRemisiones.ForeColor = System.Drawing.Color.Black
        Me.BarRemisiones.Image = Global.SGT_Transport.My.Resources.Resources.reporte
        Me.BarRemisiones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRemisiones.Name = "BarRemisiones"
        Me.BarRemisiones.Size = New System.Drawing.Size(77, 49)
        Me.BarRemisiones.Text = "Remisiones"
        Me.BarRemisiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarPedidos
        '
        Me.BarPedidos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarPedidos.ForeColor = System.Drawing.Color.Black
        Me.BarPedidos.Image = Global.SGT_Transport.My.Resources.Resources.lista_de_precios3
        Me.BarPedidos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPedidos.Name = "BarPedidos"
        Me.BarPedidos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarPedidos.Size = New System.Drawing.Size(60, 49)
        Me.BarPedidos.Text = "Pedidos"
        Me.BarPedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCotizaciones
        '
        Me.BarCotizaciones.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarCotizaciones.ForeColor = System.Drawing.Color.Black
        Me.BarCotizaciones.Image = Global.SGT_Transport.My.Resources.Resources.licencia
        Me.BarCotizaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCotizaciones.Name = "BarCotizaciones"
        Me.BarCotizaciones.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarCotizaciones.Size = New System.Drawing.Size(84, 49)
        Me.BarCotizaciones.Text = "Cotizaciones"
        Me.BarCotizaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDevoluciones
        '
        Me.BarDevoluciones.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarDevoluciones.ForeColor = System.Drawing.Color.Black
        Me.BarDevoluciones.Image = Global.SGT_Transport.My.Resources.Resources.regreso2
        Me.BarDevoluciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDevoluciones.Name = "BarDevoluciones"
        Me.BarDevoluciones.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDevoluciones.Size = New System.Drawing.Size(88, 49)
        Me.BarDevoluciones.Text = "Devoluciones"
        Me.BarDevoluciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarPagoComplemento
        '
        Me.BarPagoComplemento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarPagoComplemento.ForeColor = System.Drawing.Color.Black
        Me.BarPagoComplemento.Image = Global.SGT_Transport.My.Resources.Resources.dinero23
        Me.BarPagoComplemento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPagoComplemento.Name = "BarPagoComplemento"
        Me.BarPagoComplemento.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarPagoComplemento.Size = New System.Drawing.Size(118, 49)
        Me.BarPagoComplemento.Text = "Pago complemento"
        Me.BarPagoComplemento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem1.Image = Global.SGT_Transport.My.Resources.Resources.docporte19
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(122, 49)
        Me.ToolStripMenuItem1.Text = "Carta porte traslado"
        Me.ToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 49)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(4, 62)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(645, 246)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 14
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'frmFOLIOSF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(870, 320)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.Fg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFOLIOSF"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folios ventas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarNotas As ToolStripMenuItem
    Friend WithEvents BarRemisiones As ToolStripMenuItem
    Friend WithEvents BarPedidos As ToolStripMenuItem
    Friend WithEvents BarCotizaciones As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BarDevoluciones As ToolStripMenuItem
    Friend WithEvents BarPagoComplemento As ToolStripMenuItem
    Friend WithEvents BarFacturas As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
