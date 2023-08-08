<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGastosDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGastosDoc))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barNueva = New System.Windows.Forms.ToolStripMenuItem()
        Me.barModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtCompras = New System.Windows.Forms.Label()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(54, 36)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(333, 270)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNueva, Me.barModificar, Me.barCancelar, Me.BarActualizar, Me.BarExcel, Me.BarXML, Me.barSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1454, 55)
        Me.BarraMenu.TabIndex = 9
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'barNueva
        '
        Me.barNueva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barNueva.ForeColor = System.Drawing.Color.Black
        Me.barNueva.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNueva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNueva.Name = "barNueva"
        Me.barNueva.ShortcutKeyDisplayString = ""
        Me.barNueva.ShowShortcutKeys = False
        Me.barNueva.Size = New System.Drawing.Size(53, 51)
        Me.barNueva.Text = "Nueva"
        Me.barNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNueva.ToolTipText = "F2-Nuevo"
        '
        'barModificar
        '
        Me.barModificar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barModificar.ForeColor = System.Drawing.Color.Black
        Me.barModificar.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.barModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barModificar.Name = "barModificar"
        Me.barModificar.Size = New System.Drawing.Size(66, 51)
        Me.barModificar.Text = "Consulta"
        Me.barModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCancelar
        '
        Me.barCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barCancelar.ForeColor = System.Drawing.Color.Black
        Me.barCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.barCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCancelar.Name = "barCancelar"
        Me.barCancelar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barCancelar.Size = New System.Drawing.Size(65, 51)
        Me.barCancelar.Text = "Cancelar"
        Me.barCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarXML
        '
        Me.BarXML.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarXML.ForeColor = System.Drawing.Color.Black
        Me.BarXML.Image = Global.SGT_Transport.My.Resources.Resources.cfdi5
        Me.BarXML.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarXML.Name = "BarXML"
        Me.BarXML.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarXML.Size = New System.Drawing.Size(51, 51)
        Me.BarXML.Text = "XML's"
        Me.BarXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtCompras
        '
        Me.LtCompras.AutoSize = True
        Me.LtCompras.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCompras.Location = New System.Drawing.Point(1037, 4)
        Me.LtCompras.Name = "LtCompras"
        Me.LtCompras.Size = New System.Drawing.Size(114, 31)
        Me.LtCompras.TabIndex = 11
        Me.LtCompras.Text = "GASTOS"
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
        Me.Panel1.Controls.Add(Me.tBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(446, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 46)
        Me.Panel1.TabIndex = 13
        '
        'tBox
        '
        Me.tBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tBox.Location = New System.Drawing.Point(83, 14)
        Me.tBox.Name = "tBox"
        Me.tBox.Size = New System.Drawing.Size(155, 20)
        Me.tBox.TabIndex = 1
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.F2)
        Me.GroupBox1.Controls.Add(Me.F1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(692, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 53)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(135, 28)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 21)
        Me.F2.TabIndex = 171
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(7, 28)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 170
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "al"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(279, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 33)
        Me.btnFiltrar.TabIndex = 168
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Del"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(23, 79)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.C1SplitterPanel1)
        Me.SplitM.Size = New System.Drawing.Size(505, 345)
        Me.SplitM.TabIndex = 24
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
        'FrmGastosDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 518)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LtNUm)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.LtCompras)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmGastosDoc"
        Me.Text = "Compras"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barNueva As ToolStripMenuItem
    Friend WithEvents barModificar As ToolStripMenuItem
    Friend WithEvents barCancelar As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents LtCompras As Label
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents tBox As TextBox
    Friend WithEvents BarXML As ToolStripMenuItem
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents LtNUm As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
End Class
