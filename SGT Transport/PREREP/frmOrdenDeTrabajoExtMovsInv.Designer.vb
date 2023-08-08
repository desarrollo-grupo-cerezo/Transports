<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenDeTrabajoExtMovsInv
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenDeTrabajoExtMovsInv))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.BarGenMinveOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarConsulTOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tBox = New System.Windows.Forms.TextBox()
        Me.Lt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.BarRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
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
        Me.Fg.Location = New System.Drawing.Point(0, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(709, 338)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 14
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.White
        Me.barSalir.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGenMinveOT, Me.BarRefrescar, Me.BarConsulTOT, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.barSalir.Size = New System.Drawing.Size(1143, 55)
        Me.barSalir.TabIndex = 13
        Me.barSalir.Text = "MenuStrip1"
        '
        'BarGenMinveOT
        '
        Me.BarGenMinveOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGenMinveOT.ForeColor = System.Drawing.Color.Black
        Me.BarGenMinveOT.Image = Global.SGT_Transport.My.Resources.Resources.inven8
        Me.BarGenMinveOT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGenMinveOT.Name = "BarGenMinveOT"
        Me.BarGenMinveOT.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarGenMinveOT.Size = New System.Drawing.Size(134, 51)
        Me.BarGenMinveOT.Text = "Generar Movs. Inv. OT"
        Me.BarGenMinveOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarConsulTOT
        '
        Me.BarConsulTOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarConsulTOT.ForeColor = System.Drawing.Color.Black
        Me.BarConsulTOT.Image = Global.SGT_Transport.My.Resources.Resources.arrow19
        Me.BarConsulTOT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarConsulTOT.Name = "BarConsulTOT"
        Me.BarConsulTOT.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarConsulTOT.Size = New System.Drawing.Size(88, 51)
        Me.BarConsulTOT.Text = "Consulta TOT"
        Me.BarConsulTOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tBox)
        Me.Panel1.Controls.Add(Me.Lt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(546, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 49)
        Me.Panel1.TabIndex = 18
        '
        'tBox
        '
        Me.tBox.Location = New System.Drawing.Point(12, 19)
        Me.tBox.Name = "tBox"
        Me.tBox.Size = New System.Drawing.Size(259, 20)
        Me.tBox.TabIndex = 14
        '
        'Lt
        '
        Me.Lt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.Location = New System.Drawing.Point(277, 16)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(172, 23)
        Me.Lt.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Texto a buscar"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.ToolStripSeparator4, Me.BAyer, Me.ToolStripSeparator1, Me.BEsteMes, Me.ToolStripSeparator2, Me.BMesAnterior, Me.ToolStripSeparator3, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 436)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1143, 25)
        Me.BarraAbajo.TabIndex = 19
        Me.BarraAbajo.Text = "ToolStrip1"
        '
        'BHoy
        '
        Me.BHoy.AutoSize = False
        Me.BHoy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BHoy.ForeColor = System.Drawing.Color.Black
        Me.BHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BHoy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHoy.Name = "BHoy"
        Me.BHoy.Size = New System.Drawing.Size(80, 22)
        Me.BHoy.Text = "Hoy"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BAyer
        '
        Me.BAyer.AutoSize = False
        Me.BAyer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BAyer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BAyer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAyer.Name = "BAyer"
        Me.BAyer.Size = New System.Drawing.Size(80, 22)
        Me.BAyer.Text = "Ayer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BEsteMes
        '
        Me.BEsteMes.AutoSize = False
        Me.BEsteMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BEsteMes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEsteMes.Name = "BEsteMes"
        Me.BEsteMes.Size = New System.Drawing.Size(80, 22)
        Me.BEsteMes.Text = "Este Mes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BMesAnterior
        '
        Me.BMesAnterior.AutoSize = False
        Me.BMesAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BMesAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMesAnterior.Name = "BMesAnterior"
        Me.BMesAnterior.Size = New System.Drawing.Size(80, 22)
        Me.BMesAnterior.Text = "Mes Anterior"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BTodos
        '
        Me.BTodos.AutoSize = False
        Me.BTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTodos.Name = "BTodos"
        Me.BTodos.Size = New System.Drawing.Size(80, 22)
        Me.BTodos.Text = "Todos"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'BarRefrescar
        '
        Me.BarRefrescar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRefrescar.ForeColor = System.Drawing.Color.Black
        Me.BarRefrescar.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarRefrescar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefrescar.Name = "BarRefrescar"
        Me.BarRefrescar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRefrescar.Size = New System.Drawing.Size(67, 51)
        Me.BarRefrescar.Text = "Refrescar"
        Me.BarRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmOrdenDeTrabajoExtMovsInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 461)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOrdenDeTrabajoExtMovsInv"
        Me.Text = "frmOrdenDeTrabajoExtMovsInv"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents BarGenMinveOT As ToolStripMenuItem
    Friend WithEvents BarConsulTOT As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tBox As TextBox
    Friend WithEvents Lt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents BarRefrescar As ToolStripMenuItem
End Class
