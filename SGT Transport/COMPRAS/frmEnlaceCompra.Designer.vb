<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnlaceCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnlaceCompra))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barEnlazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barOrdenCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRequisicion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lt = New System.Windows.Forms.Label()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barEnlazar, Me.barOrdenCompra, Me.barRequisicion, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(508, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 1
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barEnlazar
        '
        Me.barEnlazar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEnlazar.ForeColor = System.Drawing.Color.Black
        Me.barEnlazar.Image = Global.SGT_Transport.My.Resources.Resources.Hoja1
        Me.barEnlazar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEnlazar.Name = "barEnlazar"
        Me.barEnlazar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barEnlazar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barEnlazar.Size = New System.Drawing.Size(56, 51)
        Me.barEnlazar.Text = "Enlazar"
        Me.barEnlazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barEnlazar.ToolTipText = "F3  Enlazar"
        '
        'barOrdenCompra
        '
        Me.barOrdenCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barOrdenCompra.ForeColor = System.Drawing.Color.Black
        Me.barOrdenCompra.Image = Global.SGT_Transport.My.Resources.Resources.CO
        Me.barOrdenCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barOrdenCompra.Name = "barOrdenCompra"
        Me.barOrdenCompra.ShortcutKeyDisplayString = ""
        Me.barOrdenCompra.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barOrdenCompra.Size = New System.Drawing.Size(98, 51)
        Me.barOrdenCompra.Text = "Orden Compra"
        Me.barOrdenCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barRequisicion
        '
        Me.barRequisicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barRequisicion.ForeColor = System.Drawing.Color.Black
        Me.barRequisicion.Image = Global.SGT_Transport.My.Resources.Resources.CQ
        Me.barRequisicion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRequisicion.Name = "barRequisicion"
        Me.barRequisicion.ShortcutKeyDisplayString = ""
        Me.barRequisicion.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barRequisicion.Size = New System.Drawing.Size(80, 51)
        Me.barRequisicion.Text = "Requisición"
        Me.barRequisicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(506, 255)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(96, 53)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(301, 20)
        Me.LtNombre.TabIndex = 323
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'btnProv
        '
        Me.btnProv.AutoSize = True
        Me.btnProv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnProv.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnProv.Location = New System.Drawing.Point(160, 24)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(22, 22)
        Me.btnProv.TabIndex = 321
        Me.C1ThemeController1.SetTheme(Me.btnProv, "Office2010Blue")
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.ForeColor = System.Drawing.Color.Black
        Me.tCVE_PROV.Location = New System.Drawing.Point(96, 25)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(63, 20)
        Me.tCVE_PROV.TabIndex = 320
        Me.C1ThemeController1.SetTheme(Me.tCVE_PROV, "Office2010Blue")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(36, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 322
        Me.Label9.Text = "Proveedor"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(48, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 324
        Me.Label1.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt.Location = New System.Drawing.Point(284, 21)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(0, 20)
        Me.Lt.TabIndex = 327
        Me.C1ThemeController1.SetTheme(Me.Lt, "Office2010Blue")
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.HeaderLineWidth = 1
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(508, 359)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterMovingColor = System.Drawing.Color.Black
        Me.C1SplitContainer1.TabIndex = 328
        Me.C1ThemeController1.SetTheme(Me.C1SplitContainer1, "Office2010Blue")
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.LtNombre)
        Me.C1SplitterPanel1.Controls.Add(Me.Lt)
        Me.C1SplitterPanel1.Controls.Add(Me.Label9)
        Me.C1SplitterPanel1.Controls.Add(Me.Label1)
        Me.C1SplitterPanel1.Controls.Add(Me.tCVE_PROV)
        Me.C1SplitterPanel1.Controls.Add(Me.btnProv)
        Me.C1SplitterPanel1.Height = 98
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 1)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(506, 98)
        Me.C1SplitterPanel1.SizeRatio = 27.655R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.Fg)
        Me.C1SplitterPanel2.Height = 255
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(1, 103)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(506, 255)
        Me.C1SplitterPanel2.TabIndex = 1
        '
        'frmEnlaceCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 414)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEnlaceCompra"
        Me.Text = "Enlace Compra"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.C1SplitterPanel1.PerformLayout()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barEnlazar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents barOrdenCompra As ToolStripMenuItem
    Friend WithEvents barRequisicion As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtNombre As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Lt As Label
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
