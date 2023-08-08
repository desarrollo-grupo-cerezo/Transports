<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreOCDocs
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNueva = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(73, 62)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(268, 165)
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNueva, Me.BarModificar, Me.BarCancelar, Me.BarActualizar, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1454, 55)
        Me.BarraMenu.TabIndex = 9
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNueva
        '
        Me.BarNueva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarNueva.ForeColor = System.Drawing.Color.Black
        Me.BarNueva.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNueva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNueva.Name = "BarNueva"
        Me.BarNueva.ShortcutKeyDisplayString = ""
        Me.BarNueva.ShowShortcutKeys = False
        Me.BarNueva.Size = New System.Drawing.Size(53, 51)
        Me.BarNueva.Text = "Nueva"
        Me.BarNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNueva.ToolTipText = "F2-Nuevo"
        '
        'BarModificar
        '
        Me.BarModificar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarModificar.ForeColor = System.Drawing.Color.Black
        Me.BarModificar.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarModificar.Name = "BarModificar"
        Me.BarModificar.Size = New System.Drawing.Size(66, 51)
        Me.BarModificar.Text = "Consulta"
        Me.BarModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCancelar
        '
        Me.BarCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCancelar.ForeColor = System.Drawing.Color.Black
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarCancelar.Size = New System.Drawing.Size(65, 51)
        Me.BarCancelar.Text = "Cancelar"
        Me.BarCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 493)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1454, 25)
        Me.BarraAbajo.TabIndex = 12
        Me.BarraAbajo.Text = "ToolStrip1"
        '
        'BHoy
        '
        Me.BHoy.AutoSize = False
        Me.BHoy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BHoy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHoy.Name = "BHoy"
        Me.BHoy.Size = New System.Drawing.Size(80, 22)
        Me.BHoy.Text = "Hoy"
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(515, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 46)
        Me.Panel1.TabIndex = 13
        '
        'TBox
        '
        Me.TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBox.Location = New System.Drawing.Point(83, 14)
        Me.TBox.Name = "TBox"
        Me.TBox.Size = New System.Drawing.Size(155, 20)
        Me.TBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Texto a buscar"
        '
        'LtNUm
        '
        Me.LtNUm.AutoSize = True
        Me.LtNUm.Location = New System.Drawing.Point(1284, 14)
        Me.LtNUm.Name = "LtNUm"
        Me.LtNUm.Size = New System.Drawing.Size(157, 13)
        Me.LtNUm.TabIndex = 14
        Me.LtNUm.Text = "_________________________"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(38, 84)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.C1SplitterPanel1)
        Me.SplitM.Size = New System.Drawing.Size(505, 345)
        Me.SplitM.TabIndex = 23
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.Fg)
        Me.C1SplitterPanel1.Height = 343
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 1)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(503, 343)
        Me.C1SplitterPanel1.SizeRatio = 81.525R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'FrmPreOCDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 518)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.LtNUm)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPreOCDocs"
        Me.Text = "Compras"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarNueva As ToolStripMenuItem
    Friend WithEvents BarModificar As ToolStripMenuItem
    Friend WithEvents BarCancelar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TBox As TextBox
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents LtNUm As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel

End Class
