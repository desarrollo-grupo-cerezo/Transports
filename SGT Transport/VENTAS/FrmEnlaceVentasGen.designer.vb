<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEnlaceVentasGen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnlaceVentasGen))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.tCLAVE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.tMagico2 = New System.Windows.Forms.TextBox()
        Me.btnClie = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarEnlazar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarNotaVenta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarRemision = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarCotizacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarPedido = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.Location = New System.Drawing.Point(12, 168)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 22
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(761, 313)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 1
        '
        'Lt1
        '
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(334, 83)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(157, 31)
        Me.Lt1.TabIndex = 355
        Me.Lt1.Text = "Cotizaciones"
        '
        'tCLAVE
        '
        Me.tCLAVE.AcceptsReturn = True
        Me.tCLAVE.AcceptsTab = True
        Me.tCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE.Location = New System.Drawing.Point(78, 87)
        Me.tCLAVE.Name = "tCLAVE"
        Me.tCLAVE.Size = New System.Drawing.Size(88, 22)
        Me.tCLAVE.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 16)
        Me.Label14.TabIndex = 357
        Me.Label14.Text = "Cliente"
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(77, 125)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(414, 22)
        Me.LtNombre.TabIndex = 359
        '
        'tMagico2
        '
        Me.tMagico2.AcceptsReturn = True
        Me.tMagico2.AcceptsTab = True
        Me.tMagico2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMagico2.Location = New System.Drawing.Point(963, 83)
        Me.tMagico2.Name = "tMagico2"
        Me.tMagico2.Size = New System.Drawing.Size(36, 22)
        Me.tMagico2.TabIndex = 2
        '
        'btnClie
        '
        Me.btnClie.FlatAppearance.BorderSize = 0
        Me.btnClie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClie.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.btnClie.Location = New System.Drawing.Point(167, 85)
        Me.btnClie.Name = "btnClie"
        Me.btnClie.Size = New System.Drawing.Size(24, 27)
        Me.btnClie.TabIndex = 358
        Me.btnClie.UseVisualStyleBackColor = True
        Me.btnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "Nombre"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(526, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(252, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 361
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarEnlazar, Me.ToolStripSeparator1, Me.BarEliminar, Me.ToolStripSeparator2, Me.BarNotaVenta, Me.ToolStripSeparator3, Me.BarRemision, Me.ToolStripSeparator4, Me.BarCotizacion, Me.ToolStripSeparator5, Me.BarPedido, Me.ToolStripSeparator6, Me.BarSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(785, 54)
        Me.ToolStrip1.TabIndex = 362
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarEnlazar
        '
        Me.BarEnlazar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarEnlazar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEnlazar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarEnlazar.Name = "BarEnlazar"
        Me.BarEnlazar.Size = New System.Drawing.Size(48, 51)
        Me.BarEnlazar.Text = "Enlazar"
        Me.BarEnlazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.Size = New System.Drawing.Size(81, 51)
        Me.BarEliminar.Text = "Eliminar part."
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'BarNotaVenta
        '
        Me.BarNotaVenta.Image = Global.SGT_Transport.My.Resources.Resources.ventas2
        Me.BarNotaVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNotaVenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarNotaVenta.Name = "BarNotaVenta"
        Me.BarNotaVenta.Size = New System.Drawing.Size(85, 51)
        Me.BarNotaVenta.Text = "Nota de venta"
        Me.BarNotaVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'BarRemision
        '
        Me.BarRemision.Image = Global.SGT_Transport.My.Resources.Resources.Remision
        Me.BarRemision.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRemision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarRemision.Name = "BarRemision"
        Me.BarRemision.Size = New System.Drawing.Size(60, 51)
        Me.BarRemision.Text = "Remisión"
        Me.BarRemision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'BarCotizacion
        '
        Me.BarCotizacion.Image = Global.SGT_Transport.My.Resources.Resources.solicitucotizacion
        Me.BarCotizacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCotizacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarCotizacion.Name = "BarCotizacion"
        Me.BarCotizacion.Size = New System.Drawing.Size(67, 51)
        Me.BarCotizacion.Text = "Cotización"
        Me.BarCotizacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
        '
        'BarPedido
        '
        Me.BarPedido.Image = Global.SGT_Transport.My.Resources.Resources.recibo
        Me.BarPedido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarPedido.Name = "BarPedido"
        Me.BarPedido.Size = New System.Drawing.Size(48, 51)
        Me.BarPedido.Text = "Pedido"
        Me.BarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 54)
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(36, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmEnlaceVentasGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 495)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tMagico2)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.btnClie)
        Me.Controls.Add(Me.tCLAVE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEnlaceVentasGen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enlace documento"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Lt1 As Label
    Friend WithEvents btnClie As C1.Win.C1Input.C1Button
    Friend WithEvents tCLAVE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents tMagico2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarEnlazar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BarEliminar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BarNotaVenta As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BarRemision As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BarCotizacion As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BarPedido As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents BarSalir As ToolStripButton
End Class
