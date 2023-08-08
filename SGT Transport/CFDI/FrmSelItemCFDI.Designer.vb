<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelItemCFDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelItemCFDI))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoResize = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders
        Me.Fg.ColumnInfo = "4,1,0,0,0,53,Columns:1{AllowNull:False;Caption:""Clave"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:343;AllowNull:Fa" &
    "lse;Caption:""Nombre"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{AllowNull:False;Caption:""R.F.C."";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(506, 480)
        Me.Fg.TabIndex = 4
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAceptar, Me.ToolStripSeparator1, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(508, 54)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarAceptar
        '
        Me.BarAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarAceptar.Name = "BarAceptar"
        Me.BarAceptar.Size = New System.Drawing.Size(52, 51)
        Me.BarAceptar.Text = "Aceptar"
        Me.BarAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitContainer1.BorderWidth = 1
        Me.SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 54)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Panels.Add(Me.SplitPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(508, 503)
        Me.SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitContainer1.TabIndex = 5
        Me.SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitContainer1.UseParentVisualStyle = False
        '
        'SplitPanel1
        '
        Me.SplitPanel1.Controls.Add(Me.Fg)
        Me.SplitPanel1.Height = 501
        Me.SplitPanel1.Location = New System.Drawing.Point(1, 22)
        Me.SplitPanel1.Name = "SplitPanel1"
        Me.SplitPanel1.Size = New System.Drawing.Size(506, 480)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.Text = "__"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(199, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(216, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 16
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'FrmSelItemCFDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 557)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmSelItemCFDI"
        Me.Text = "Seleccione"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarAceptar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
End Class
