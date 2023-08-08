<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRepLlantasSinAsignar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepLlantasSinAsignar))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarImprimir, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(940, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 27
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarImprimir
        '
        Me.BarImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImprimir.ForeColor = System.Drawing.Color.Black
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarImprimir.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarImprimir.Size = New System.Drawing.Size(65, 51)
        Me.BarImprimir.Text = "Imprimir"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
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
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 74)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(804, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 28
        '
        'FrmRepLlantasSinAsignar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 504)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRepLlantasSinAsignar"
        Me.Text = "Reporte Llantas sin asignar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarImprimir As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
