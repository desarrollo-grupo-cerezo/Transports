<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiltroInve
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltroInve))
        Me.ChExist = New C1.Win.C1Input.C1CheckBox()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.BarAplicarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.ChExist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarra.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChExist
        '
        Me.ChExist.BackColor = System.Drawing.Color.Transparent
        Me.ChExist.BorderColor = System.Drawing.Color.Transparent
        Me.ChExist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChExist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChExist.ForeColor = System.Drawing.Color.Black
        Me.ChExist.Location = New System.Drawing.Point(288, 12)
        Me.ChExist.Name = "ChExist"
        Me.ChExist.Padding = New System.Windows.Forms.Padding(1)
        Me.ChExist.Size = New System.Drawing.Size(195, 32)
        Me.ChExist.TabIndex = 215
        Me.ChExist.Text = "Solo con existencia"
        Me.ChExist.UseVisualStyleBackColor = False
        Me.ChExist.Value = False
        Me.ChExist.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'MenuBarra
        '
        Me.MenuBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAplicarFiltro, Me.BarSalir})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(482, 55)
        Me.MenuBarra.TabIndex = 216
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'BarAplicarFiltro
        '
        Me.BarAplicarFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarAplicarFiltro.ForeColor = System.Drawing.Color.Black
        Me.BarAplicarFiltro.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAplicarFiltro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAplicarFiltro.Name = "BarAplicarFiltro"
        Me.BarAplicarFiltro.ShortcutKeyDisplayString = ""
        Me.BarAplicarFiltro.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarAplicarFiltro.Size = New System.Drawing.Size(84, 51)
        Me.BarAplicarFiltro.Text = "Aplicar filtro"
        Me.BarAplicarFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "4,1,0,0,0,95,Columns:1{Width:67;Caption:""Seleccione"";Style:""DataType:System.Boole" &
    "an;TextAlign:LeftCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:61;Caption:""Linea"";}" &
    "" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Width:260;Caption:""Descripción"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(13, 76)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(457, 318)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 217
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'FrmFiltroInve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 410)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.ChExist)
        Me.Controls.Add(Me.MenuBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiltroInve"
        Me.ShowInTaskbar = False
        Me.Text = "Filtro inventario"
        CType(Me.ChExist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChExist As C1.Win.C1Input.C1CheckBox
    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents BarAplicarFiltro As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
