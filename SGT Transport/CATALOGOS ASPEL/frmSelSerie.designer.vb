<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelSerie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelSerie))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barSelSerie = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(6, 60)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(300, 185)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 13
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barSelSerie, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(306, 55)
        Me.barSalir.TabIndex = 12
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barSelSerie
        '
        Me.barSelSerie.ForeColor = System.Drawing.Color.Black
        Me.barSelSerie.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barSelSerie.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSelSerie.Name = "barSelSerie"
        Me.barSelSerie.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barSelSerie.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barSelSerie.Size = New System.Drawing.Size(54, 51)
        Me.barSelSerie.Text = "Nuevo"
        Me.barSelSerie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barSelSerie.ToolTipText = "F2-Nuevo"
        '
        'mnuSalir
        '
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmSelSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 254)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelSerie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione serie"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barSelSerie As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
