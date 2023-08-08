<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReseteo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReseteo))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDesplegar = New System.Windows.Forms.Button()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TAB1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReactivarReseteo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarVales = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEditVale = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReActivarVale = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminarValesDiesel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReasignarValeDiesel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReporteVales = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarHorasGen = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImpresaionMasivaReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRecalculoGlobal = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRecalculoEvento2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMlla = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGrabarMalla = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCfgMalla = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TAB1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        Me.Pag2.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(972, 347)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarReactivarReseteo, Me.BarActualizar, Me.BarVales, Me.BarHorasGen, Me.BarImpresaionMasivaReset, Me.OpcionesToolStripMenuItem, Me.MnuMlla, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1620, 55)
        Me.barSalir.TabIndex = 10
        Me.barSalir.Text = "MenuStrip1"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1150, 3)
        Me.C1FlexGridSearchPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 500
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(199, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 0
        Me.C1FlexGridSearchPanel1.Watermark = "Introdusca texto a buscar"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 555)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1620, 25)
        Me.BarraAbajo.TabIndex = 13
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnDesplegar)
        Me.Panel2.Controls.Add(Me.F1)
        Me.Panel2.Controls.Add(Me.F2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(832, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(313, 51)
        Me.Panel2.TabIndex = 310
        '
        'btnDesplegar
        '
        Me.btnDesplegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesplegar.Location = New System.Drawing.Point(225, 14)
        Me.btnDesplegar.Name = "btnDesplegar"
        Me.btnDesplegar.Size = New System.Drawing.Size(79, 28)
        Me.btnDesplegar.TabIndex = 309
        Me.btnDesplegar.Text = "Desplegar"
        Me.btnDesplegar.UseVisualStyleBackColor = True
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(3, 22)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 306
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(111, 22)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 308
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 17)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 17)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'TAB1
        '
        Me.TAB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAB1.CanMoveTabs = True
        Me.TAB1.Controls.Add(Me.Pag1)
        Me.TAB1.Controls.Add(Me.Pag2)
        Me.TAB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TAB1.Location = New System.Drawing.Point(12, 72)
        Me.TAB1.Name = "TAB1"
        Me.TAB1.Size = New System.Drawing.Size(974, 375)
        Me.TAB1.TabIndex = 311
        Me.TAB1.TabsSpacing = 5
        Me.TAB1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.TAB1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.TAB1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.Fg)
        Me.Pag1.Location = New System.Drawing.Point(1, 27)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(972, 347)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Reseteos"
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.Fg1)
        Me.Pag2.Location = New System.Drawing.Point(1, 27)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(972, 347)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Vales de combustible"
        '
        'Fg1
        '
        Me.Fg1.AllowEditing = False
        Me.Fg1.AllowFiltering = True
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 1
        Me.Fg1.Rows.DefaultSize = 21
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg1.ShowCellLabels = True
        Me.Fg1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg1.Size = New System.Drawing.Size(972, 347)
        Me.Fg1.StyleInfo = resources.GetString("Fg1.StyleInfo")
        Me.Fg1.TabIndex = 208
        Me.Fg1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(54, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 51)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(62, 51)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarReactivarReseteo
        '
        Me.BarReactivarReseteo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarReactivarReseteo.ForeColor = System.Drawing.Color.Black
        Me.BarReactivarReseteo.Image = Global.SGT_Transport.My.Resources.Resources.reiniciar1
        Me.BarReactivarReseteo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReactivarReseteo.Name = "BarReactivarReseteo"
        Me.BarReactivarReseteo.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarReactivarReseteo.Size = New System.Drawing.Size(67, 51)
        Me.BarReactivarReseteo.Text = "Reactivar"
        Me.BarReactivarReseteo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'BarVales
        '
        Me.BarVales.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarEditVale, Me.BarReActivarVale, Me.BarEliminarValesDiesel, Me.BarReasignarValeDiesel, Me.BarReporteVales})
        Me.BarVales.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarVales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarVales.Name = "BarVales"
        Me.BarVales.ShowShortcutKeys = False
        Me.BarVales.Size = New System.Drawing.Size(45, 51)
        Me.BarVales.Text = "Vales"
        Me.BarVales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEditVale
        '
        Me.BarEditVale.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEditVale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEditVale.Name = "BarEditVale"
        Me.BarEditVale.Size = New System.Drawing.Size(176, 38)
        Me.BarEditVale.Text = "Edit vale"
        '
        'BarReActivarVale
        '
        Me.BarReActivarVale.Image = Global.SGT_Transport.My.Resources.Resources.reactivar2
        Me.BarReActivarVale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReActivarVale.Name = "BarReActivarVale"
        Me.BarReActivarVale.Size = New System.Drawing.Size(176, 38)
        Me.BarReActivarVale.Text = "Reactivar vale"
        '
        'BarEliminarValesDiesel
        '
        Me.BarEliminarValesDiesel.Image = Global.SGT_Transport.My.Resources.Resources.eliminar2
        Me.BarEliminarValesDiesel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminarValesDiesel.Name = "BarEliminarValesDiesel"
        Me.BarEliminarValesDiesel.Size = New System.Drawing.Size(176, 38)
        Me.BarEliminarValesDiesel.Text = "Eliminar vale"
        '
        'BarReasignarValeDiesel
        '
        Me.BarReasignarValeDiesel.Image = Global.SGT_Transport.My.Resources.Resources.note
        Me.BarReasignarValeDiesel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReasignarValeDiesel.Name = "BarReasignarValeDiesel"
        Me.BarReasignarValeDiesel.Size = New System.Drawing.Size(176, 38)
        Me.BarReasignarValeDiesel.Text = "Reasignar vale"
        '
        'BarReporteVales
        '
        Me.BarReporteVales.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarReporteVales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReporteVales.Name = "BarReporteVales"
        Me.BarReporteVales.Size = New System.Drawing.Size(176, 38)
        Me.BarReporteVales.Text = "Reporte de vales"
        '
        'BarHorasGen
        '
        Me.BarHorasGen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarHorasGen.ForeColor = System.Drawing.Color.Black
        Me.BarHorasGen.Image = Global.SGT_Transport.My.Resources.Resources.impresora32
        Me.BarHorasGen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarHorasGen.Name = "BarHorasGen"
        Me.BarHorasGen.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarHorasGen.Size = New System.Drawing.Size(107, 51)
        Me.BarHorasGen.Text = "Horas generador"
        Me.BarHorasGen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImpresaionMasivaReset
        '
        Me.BarImpresaionMasivaReset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImpresaionMasivaReset.ForeColor = System.Drawing.Color.Black
        Me.BarImpresaionMasivaReset.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImpresaionMasivaReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImpresaionMasivaReset.Name = "BarImpresaionMasivaReset"
        Me.BarImpresaionMasivaReset.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarImpresaionMasivaReset.Size = New System.Drawing.Size(112, 51)
        Me.BarImpresaionMasivaReset.Text = "Impresión masiva"
        Me.BarImpresaionMasivaReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarExcel, Me.BarRecalculoGlobal, Me.BarRecalculoEvento2})
        Me.OpcionesToolStripMenuItem.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.OpcionesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 51)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        Me.OpcionesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(180, 38)
        Me.BarExcel.Text = "Excel"
        '
        'BarRecalculoGlobal
        '
        Me.BarRecalculoGlobal.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarRecalculoGlobal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRecalculoGlobal.Name = "BarRecalculoGlobal"
        Me.BarRecalculoGlobal.Size = New System.Drawing.Size(180, 38)
        Me.BarRecalculoGlobal.Text = "Recalculo global"
        '
        'BarRecalculoEvento2
        '
        Me.BarRecalculoEvento2.Image = Global.SGT_Transport.My.Resources.Resources.engranaje3
        Me.BarRecalculoEvento2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRecalculoEvento2.Name = "BarRecalculoEvento2"
        Me.BarRecalculoEvento2.Size = New System.Drawing.Size(180, 38)
        Me.BarRecalculoEvento2.Text = "Recalculo evento"
        '
        'MnuMlla
        '
        Me.MnuMlla.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabarMalla, Me.BarCfgMalla})
        Me.MnuMlla.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MnuMlla.ForeColor = System.Drawing.Color.Black
        Me.MnuMlla.Image = Global.SGT_Transport.My.Resources.Resources.malla3
        Me.MnuMlla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuMlla.Name = "MnuMlla"
        Me.MnuMlla.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuMlla.Size = New System.Drawing.Size(48, 51)
        Me.MnuMlla.Text = "Malla"
        Me.MnuMlla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGrabarMalla
        '
        Me.BarGrabarMalla.Image = Global.SGT_Transport.My.Resources.Resources.malla2
        Me.BarGrabarMalla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabarMalla.Name = "BarGrabarMalla"
        Me.BarGrabarMalla.Size = New System.Drawing.Size(198, 38)
        Me.BarGrabarMalla.Text = "Grabar malla"
        '
        'BarCfgMalla
        '
        Me.BarCfgMalla.Image = Global.SGT_Transport.My.Resources.Resources.tol6
        Me.BarCfgMalla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCfgMalla.Name = "BarCfgMalla"
        Me.BarCfgMalla.Size = New System.Drawing.Size(198, 38)
        Me.BarCfgMalla.Text = "Configuración malla"
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
        'frmReseteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1620, 580)
        Me.Controls.Add(Me.TAB1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReseteo"
        Me.Text = "s"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TAB1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag2.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnDesplegar As Button
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BarReactivarReseteo As ToolStripMenuItem
    Friend WithEvents TAB1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents MnuMlla As ToolStripMenuItem
    Friend WithEvents BarGrabarMalla As ToolStripMenuItem
    Friend WithEvents BarCfgMalla As ToolStripMenuItem
    Friend WithEvents BarHorasGen As ToolStripMenuItem
    Friend WithEvents BarVales As ToolStripMenuItem
    Friend WithEvents BarEditVale As ToolStripMenuItem
    Friend WithEvents BarReActivarVale As ToolStripMenuItem
    Friend WithEvents BarEliminarValesDiesel As ToolStripMenuItem
    Friend WithEvents BarReasignarValeDiesel As ToolStripMenuItem
    Friend WithEvents BarReporteVales As ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarRecalculoGlobal As ToolStripMenuItem
    Friend WithEvents BarRecalculoEvento2 As ToolStripMenuItem
    Friend WithEvents BarImpresaionMasivaReset As ToolStripMenuItem
End Class
