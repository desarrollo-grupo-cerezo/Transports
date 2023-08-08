<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelItem))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lt = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.tBox = New System.Windows.Forms.TextBox()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barRefresh = New System.Windows.Forms.ToolStripButton()
        Me.barServicios = New System.Windows.Forms.ToolStripButton()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Texto a buscar"
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.Location = New System.Drawing.Point(286, 65)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(0, 13)
        Me.Lt.TabIndex = 4
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(286, 92)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(0, 13)
        Me.Lt1.TabIndex = 5
        '
        'tBox
        '
        Me.tBox.Location = New System.Drawing.Point(12, 87)
        Me.tBox.Name = "tBox"
        Me.tBox.Size = New System.Drawing.Size(237, 20)
        Me.tBox.TabIndex = 3
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
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders
        Me.Fg.ColumnInfo = "4,1,0,0,0,53,Columns:1{AllowNull:False;Caption:""Clave"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:343;AllowNull:Fa" &
    "lse;Caption:""Nombre"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{AllowNull:False;Caption:""R.F.C."";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(4, 113)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(567, 352)
        Me.Fg.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barBuscar, Me.ToolStripSeparator1, Me.barRefresh, Me.barServicios, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(581, 54)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barBuscar
        '
        Me.barBuscar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barBuscar.Name = "barBuscar"
        Me.barBuscar.Size = New System.Drawing.Size(52, 51)
        Me.barBuscar.Text = "Aceptar"
        Me.barBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'barRefresh
        '
        Me.barRefresh.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.barRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barRefresh.Name = "barRefresh"
        Me.barRefresh.Size = New System.Drawing.Size(59, 51)
        Me.barRefresh.Text = "Refrescar"
        Me.barRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barServicios
        '
        Me.barServicios.Image = Global.SGT_Transport.My.Resources.Resources.S16B
        Me.barServicios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barServicios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barServicios.Name = "barServicios"
        Me.barServicios.Size = New System.Drawing.Size(57, 51)
        Me.barServicios.Text = "Servicios"
        Me.barServicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'frmSelItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(581, 484)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.tBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelItem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lt As System.Windows.Forms.Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents tBox As TextBox
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barBuscar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barRefresh As ToolStripButton
    Friend WithEvents barServicios As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
