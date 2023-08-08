<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActividadesManteAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActividadesManteAE))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.TCVE_SER = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnServicios = New C1.Win.C1Input.C1Button()
        Me.BtnEliminar = New C1.Win.C1Input.C1Button()
        Me.BtnArticulo = New C1.Win.C1Input.C1Button()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(684, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 9
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Descripción"
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(114, 111)
        Me.TDESCR.MaxLength = 255
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(558, 21)
        Me.TDESCR.TabIndex = 1
        '
        'TCVE_SER
        '
        Me.TCVE_SER.AcceptsReturn = True
        Me.TCVE_SER.AcceptsTab = True
        Me.TCVE_SER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_SER.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_SER.Location = New System.Drawing.Point(114, 76)
        Me.TCVE_SER.Name = "TCVE_SER"
        Me.TCVE_SER.Size = New System.Drawing.Size(83, 21)
        Me.TCVE_SER.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(76, 79)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 216
        Me.Label27.Text = "Clave"
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(13, 232)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(659, 304)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 4
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(659, 26)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Servicios"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnServicios
        '
        Me.BtnServicios.Image = Global.SGT_Transport.My.Resources.Resources.mas10
        Me.BtnServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnServicios.Location = New System.Drawing.Point(100, 185)
        Me.BtnServicios.Name = "BtnServicios"
        Me.BtnServicios.Size = New System.Drawing.Size(82, 33)
        Me.BtnServicios.TabIndex = 6
        Me.BtnServicios.Text = "Servicio"
        Me.BtnServicios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnServicios.UseVisualStyleBackColor = True
        Me.BtnServicios.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.BtnServicios.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.equis
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(192, 185)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(87, 33)
        Me.BtnEliminar.TabIndex = 7
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnArticulo
        '
        Me.BtnArticulo.Image = Global.SGT_Transport.My.Resources.Resources.mas10
        Me.BtnArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnArticulo.Location = New System.Drawing.Point(12, 185)
        Me.BtnArticulo.Name = "BtnArticulo"
        Me.BtnArticulo.Size = New System.Drawing.Size(82, 33)
        Me.BtnArticulo.TabIndex = 5
        Me.BtnArticulo.Text = "Articulo"
        Me.BtnArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnArticulo.UseVisualStyleBackColor = True
        Me.BtnArticulo.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.BtnArticulo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmActividadesManteAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 538)
        Me.Controls.Add(Me.BtnServicios)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnArticulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.TCVE_SER)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.BarraMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActividadesManteAE"
        Me.Text = "Actividades Mantenimiento"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents TCVE_SER As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnArticulo As C1.Win.C1Input.C1Button
    Friend WithEvents BtnServicios As C1.Win.C1Input.C1Button
End Class
