<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGoogleMaps1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(51, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(285, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(400, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(285, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GMapControl1
        '
        Me.GMapControl1.Bearing = 0!
        Me.GMapControl1.CanDragMap = True
        Me.GMapControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GMapControl1.EmptyTileColor = System.Drawing.Color.Navy
        Me.GMapControl1.GrayScaleMode = False
        Me.GMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GMapControl1.LevelsKeepInMemmory = 5
        Me.GMapControl1.Location = New System.Drawing.Point(0, 0)
        Me.GMapControl1.MarkersEnabled = True
        Me.GMapControl1.MaxZoom = 2
        Me.GMapControl1.MinZoom = 2
        Me.GMapControl1.MouseWheelZoomEnabled = True
        Me.GMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GMapControl1.Name = "GMapControl1"
        Me.GMapControl1.NegativeMode = False
        Me.GMapControl1.PolygonsEnabled = True
        Me.GMapControl1.RetryLoadTile = 0
        Me.GMapControl1.RoutesEnabled = True
        Me.GMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GMapControl1.ShowTileGridLines = False
        Me.GMapControl1.Size = New System.Drawing.Size(1164, 530)
        Me.GMapControl1.TabIndex = 3
        Me.GMapControl1.Zoom = 0R
        '
        'frmGoogleMaps1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 530)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GMapControl1)
        Me.Name = "frmGoogleMaps1"
        Me.Text = "frmGoogleMaps1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GMapControl1 As GMap.NET.WindowsForms.GMapControl
End Class
