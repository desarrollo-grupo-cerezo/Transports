<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstatusUnidadesStOper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstatusUnidadesStOper))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:41;Caption:""Clave"";AllowDragging:False;AllowEditing:" &
    "False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:285;Caption:""Descripcion"";AllowDragging:False;AllowEditing:False" &
    ";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(2, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(378, 218)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 29
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarMenu
        '
        Me.BarMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAceptar, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(392, 55)
        Me.BarMenu.Stretch = False
        Me.BarMenu.TabIndex = 28
        Me.BarMenu.Text = "MenuStrip1"
        '
        'BarAceptar
        '
        Me.BarAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarAceptar.ForeColor = System.Drawing.Color.Black
        Me.BarAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAceptar.Name = "BarAceptar"
        Me.BarAceptar.ShortcutKeyDisplayString = ""
        Me.BarAceptar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarAceptar.Size = New System.Drawing.Size(63, 51)
        Me.BarAceptar.Text = "Aceptar"
        Me.BarAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'FrmEstatusUnidadesStOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 299)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstatusUnidadesStOper"
        Me.Text = "Estatus operador"
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarAceptar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
End Class
