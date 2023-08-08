<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnlazarComprasNuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnlazarComprasNuevo))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barEnlazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.tCLAVE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.tMagico2 = New System.Windows.Forms.TextBox()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barEnlazar, Me.barEliminar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(808, 53)
        Me.barSalir.TabIndex = 4
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barEnlazar
        '
        Me.barEnlazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barEnlazar.ForeColor = System.Drawing.Color.Black
        Me.barEnlazar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barEnlazar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEnlazar.Name = "barEnlazar"
        Me.barEnlazar.ShortcutKeyDisplayString = ""
        Me.barEnlazar.Size = New System.Drawing.Size(54, 49)
        Me.barEnlazar.Text = "Enlazar"
        Me.barEnlazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barEnlazar.ToolTipText = "F3-Enlazar"
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.Size = New System.Drawing.Size(76, 49)
        Me.barEliminar.Text = "Eliminar par."
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 49)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(210, 76)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(414, 20)
        Me.LtNombre.TabIndex = 364
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'btnProv
        '
        Me.btnProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProv.Image = Global.SGT_Transport.My.Resources.Resources.lupu20
        Me.btnProv.Location = New System.Drawing.Point(182, 74)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(27, 29)
        Me.btnProv.TabIndex = 363
        Me.C1ThemeController1.SetTheme(Me.btnProv, "Office2010Blue")
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCLAVE
        '
        Me.tCLAVE.AcceptsReturn = True
        Me.tCLAVE.AcceptsTab = True
        Me.tCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE.ForeColor = System.Drawing.Color.Black
        Me.tCLAVE.Location = New System.Drawing.Point(92, 74)
        Me.tCLAVE.Name = "tCLAVE"
        Me.tCLAVE.Size = New System.Drawing.Size(88, 22)
        Me.tCLAVE.TabIndex = 360
        Me.C1ThemeController1.SetTheme(Me.tCLAVE, "Office2010Blue")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(9, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 16)
        Me.Label14.TabIndex = 362
        Me.Label14.Text = "Clave prov."
        Me.C1ThemeController1.SetTheme(Me.Label14, "Office2010Blue")
        '
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 108)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(723, 210)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 361
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'Lt1
        '
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(383, 9)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(157, 31)
        Me.Lt1.TabIndex = 365
        Me.Lt1.Text = "Compras"
        Me.C1ThemeController1.SetTheme(Me.Lt1, "Office2010Blue")
        '
        'tMagico2
        '
        Me.tMagico2.AcceptsReturn = True
        Me.tMagico2.AcceptsTab = True
        Me.tMagico2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMagico2.ForeColor = System.Drawing.Color.Black
        Me.tMagico2.Location = New System.Drawing.Point(671, 18)
        Me.tMagico2.Name = "tMagico2"
        Me.tMagico2.Size = New System.Drawing.Size(36, 22)
        Me.tMagico2.TabIndex = 366
        Me.C1ThemeController1.SetTheme(Me.tMagico2, "Office2010Blue")
        '
        'frmEnlazarComprasNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 350)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.tCLAVE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tMagico2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEnlazarComprasNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enlazar compras"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barEnlazar As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents LtNombre As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tCLAVE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Lt1 As Label
    Friend WithEvents tMagico2 As TextBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
