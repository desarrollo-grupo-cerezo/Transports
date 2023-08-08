<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGMapNet
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barBuscar = New System.Windows.Forms.ToolStripButton()
        Me.barTrace = New System.Windows.Forms.ToolStripButton()
        Me.barRuta = New System.Windows.Forms.ToolStripButton()
        Me.barNew1 = New System.Windows.Forms.ToolStripButton()
        Me.BarTodasUnidades = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.MP1 = New GMap.NET.WindowsForms.GMapControl()
        Me.Lt = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barBuscar, Me.BarTodasUnidades, Me.barTrace, Me.barRuta, Me.barNew1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1122, 56)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barBuscar
        '
        Me.barBuscar.Image = Global.SGT_Transport.My.Resources.Resources.ruta12
        Me.barBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barBuscar.Name = "barBuscar"
        Me.barBuscar.Size = New System.Drawing.Size(69, 53)
        Me.barBuscar.Text = "Por unidad"
        Me.barBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barTrace
        '
        Me.barTrace.Image = Global.SGT_Transport.My.Resources.Resources.ruta10
        Me.barTrace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barTrace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barTrace.Name = "barTrace"
        Me.barTrace.Size = New System.Drawing.Size(38, 53)
        Me.barTrace.Text = "Trace"
        Me.barTrace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barTrace.Visible = False
        '
        'barRuta
        '
        Me.barRuta.Image = Global.SGT_Transport.My.Resources.Resources.doc19
        Me.barRuta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRuta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barRuta.Name = "barRuta"
        Me.barRuta.Size = New System.Drawing.Size(36, 53)
        Me.barRuta.Text = "Ruta"
        Me.barRuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barNew1
        '
        Me.barNew1.Image = Global.SGT_Transport.My.Resources.Resources.track29
        Me.barNew1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNew1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barNew1.Name = "barNew1"
        Me.barNew1.Size = New System.Drawing.Size(64, 53)
        Me.barNew1.Text = "New trace"
        Me.barNew1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNew1.Visible = False
        '
        'BarTodasUnidades
        '
        Me.BarTodasUnidades.Image = Global.SGT_Transport.My.Resources.Resources.ruta3
        Me.BarTodasUnidades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTodasUnidades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarTodasUnidades.Name = "BarTodasUnidades"
        Me.BarTodasUnidades.Size = New System.Drawing.Size(109, 53)
        Me.BarTodasUnidades.Text = "Todas las unidades"
        Me.BarTodasUnidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 53)
        Me.ToolStripButton1.Text = "Salir"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Pic)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1122, 56)
        Me.Panel1.TabIndex = 2
        '
        'Pic
        '
        Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic.Location = New System.Drawing.Point(833, 12)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(19, 18)
        Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic.TabIndex = 4
        Me.Pic.TabStop = False
        '
        'MP1
        '
        Me.MP1.Bearing = 0!
        Me.MP1.CanDragMap = True
        Me.MP1.EmptyTileColor = System.Drawing.Color.Navy
        Me.MP1.GrayScaleMode = False
        Me.MP1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.MP1.LevelsKeepInMemmory = 5
        Me.MP1.Location = New System.Drawing.Point(0, 54)
        Me.MP1.MarkersEnabled = True
        Me.MP1.MaxZoom = 2
        Me.MP1.MinZoom = 2
        Me.MP1.MouseWheelZoomEnabled = True
        Me.MP1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.MP1.Name = "MP1"
        Me.MP1.NegativeMode = False
        Me.MP1.PolygonsEnabled = True
        Me.MP1.RetryLoadTile = 0
        Me.MP1.RoutesEnabled = True
        Me.MP1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.MP1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.MP1.ShowTileGridLines = False
        Me.MP1.Size = New System.Drawing.Size(882, 374)
        Me.MP1.TabIndex = 3
        Me.MP1.Zoom = 0R
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.BackColor = System.Drawing.Color.Transparent
        Me.Lt.Location = New System.Drawing.Point(676, 75)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(0, 13)
        Me.Lt.TabIndex = 4
        Me.Lt.Visible = False
        '
        'frmGMapNet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 638)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.MP1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmGMapNet"
        Me.Text = "GMapNet"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'Friend WithEvents GMap As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents barBuscar As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Pic As PictureBox
    Friend WithEvents barTrace As ToolStripButton
    Friend WithEvents barRuta As ToolStripButton
    Friend WithEvents MP1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents barNew1 As ToolStripButton
    Friend WithEvents Lt As Label
    Friend WithEvents BarTodasUnidades As ToolStripButton
End Class
