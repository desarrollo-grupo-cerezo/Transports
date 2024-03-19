<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCasetasViajes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCasetasViajes))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(233, 55)
        Me.BarraMenu.TabIndex = 10
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'barAceptar
        '
        Me.barAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barAceptar.ForeColor = System.Drawing.Color.Black
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barAceptar.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barAceptar.Size = New System.Drawing.Size(60, 51)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barAceptar.ToolTipText = "F2-Nuevo"
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
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:60;Caption:""Seleccione"";Style:""DataType:System.Boole" &
    "an;TextAlign:LeftCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Caption:""Num. viaje"";Style" &
    ":""Font:Tahoma, 8pt;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 55)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(233, 252)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'FrmCasetasViajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 307)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmCasetasViajes"
        Me.Text = "Seleccione viajes"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents barAceptar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
