<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLlantas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLlantas))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesgaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarMenuLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAsignacionDeLLantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesasignarLLantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStatusLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuConmLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuLlantasSinAsignar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBuscarXNumEconomico = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUniSinLLanAsig = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMovsInvLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarControlLLantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuImportLlantasExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPilasDesecho = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReportSemaforeoLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCostoPorKilometro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDetalladoDeLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarResumenDeLlantas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarIndicadoresGraficos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReporteDeInspecciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarInspeccionesDiarias = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuAsignarStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TBUSCAR = New C1.Win.C1Input.C1TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.CmdNuevo = New C1.Win.C1Command.C1Command()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.CmdEdit = New C1.Win.C1Command.C1Command()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.CmdCancelar = New C1.Win.C1Command.C1Command()
        Me.LkFinalizar = New C1.Win.C1Command.C1CommandLink()
        Me.CmdFinalizar = New C1.Win.C1Command.C1Command()
        Me.LkReactivar = New C1.Win.C1Command.C1CommandLink()
        Me.CmdReactivar = New C1.Win.C1Command.C1Command()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.CmdActualizar = New C1.Win.C1Command.C1Command()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.CmdExcel = New C1.Win.C1Command.C1Command()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.BarDisenador = New C1.Win.C1Command.C1Command()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.CmdSalir = New C1.Win.C1Command.C1Command()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BarReactivarLlanta = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.TBUSCAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag3.SuspendLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarActualizar, Me.BarFiltro, Me.BarTodos, Me.BarDesgaste, Me.BarMenuLlantas, Me.BarReportSemaforeoLlantas, Me.ToolStripMenuItem1, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.BarraMenu.Size = New System.Drawing.Size(1131, 50)
        Me.BarraMenu.TabIndex = 7
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(51, 49)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 49)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarEliminar.Size = New System.Drawing.Size(55, 49)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(65, 49)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarFiltro
        '
        Me.BarFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarFiltro.ForeColor = System.Drawing.Color.Black
        Me.BarFiltro.Image = Global.SGT_Transport.My.Resources.Resources.filtro21
        Me.BarFiltro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarFiltro.Name = "BarFiltro"
        Me.BarFiltro.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarFiltro.Size = New System.Drawing.Size(44, 49)
        Me.BarFiltro.Text = "Filtro"
        Me.BarFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarTodos
        '
        Me.BarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarTodos.ForeColor = System.Drawing.Color.Black
        Me.BarTodos.Image = Global.SGT_Transport.My.Resources.Resources.LLANT1
        Me.BarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTodos.Name = "BarTodos"
        Me.BarTodos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarTodos.Size = New System.Drawing.Size(49, 49)
        Me.BarTodos.Text = "Todas"
        Me.BarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDesgaste
        '
        Me.BarDesgaste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarDesgaste.ForeColor = System.Drawing.Color.Black
        Me.BarDesgaste.Image = Global.SGT_Transport.My.Resources.Resources.Desgast_llanta
        Me.BarDesgaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesgaste.Name = "BarDesgaste"
        Me.BarDesgaste.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarDesgaste.Size = New System.Drawing.Size(64, 49)
        Me.BarDesgaste.Text = "Desgaste"
        Me.BarDesgaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarMenuLlantas
        '
        Me.BarMenuLlantas.BackColor = System.Drawing.Color.Transparent
        Me.BarMenuLlantas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BarMenuLlantas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAsignacionDeLLantas, Me.MnuDesasignarLLantas, Me.MnuStatusLlantas, Me.MnuConmLlantas, Me.MnuLlantasSinAsignar, Me.MnuBuscarXNumEconomico, Me.MnuImprimir, Me.MnuUniSinLLanAsig, Me.MnuMovsInvLlantas, Me.BarControlLLantas, Me.MnuImportLlantasExcel, Me.BarPilasDesecho})
        Me.BarMenuLlantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarMenuLlantas.ForeColor = System.Drawing.Color.Black
        Me.BarMenuLlantas.Image = Global.SGT_Transport.My.Resources.Resources.llantas_llantas
        Me.BarMenuLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarMenuLlantas.Name = "BarMenuLlantas"
        Me.BarMenuLlantas.Size = New System.Drawing.Size(53, 49)
        Me.BarMenuLlantas.Text = "Llantas"
        Me.BarMenuLlantas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuAsignacionDeLLantas
        '
        Me.MnuAsignacionDeLLantas.Image = Global.SGT_Transport.My.Resources.Resources.Asign_llantas
        Me.MnuAsignacionDeLLantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuAsignacionDeLLantas.Name = "MnuAsignacionDeLLantas"
        Me.MnuAsignacionDeLLantas.Size = New System.Drawing.Size(242, 38)
        Me.MnuAsignacionDeLLantas.Text = "Asignación llantas"
        '
        'MnuDesasignarLLantas
        '
        Me.MnuDesasignarLLantas.Image = Global.SGT_Transport.My.Resources.Resources.llantaX1
        Me.MnuDesasignarLLantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuDesasignarLLantas.Name = "MnuDesasignarLLantas"
        Me.MnuDesasignarLLantas.Size = New System.Drawing.Size(242, 38)
        Me.MnuDesasignarLLantas.Text = "Desasignar llantas"
        '
        'MnuStatusLlantas
        '
        Me.MnuStatusLlantas.Image = Global.SGT_Transport.My.Resources.Resources.status_llantas
        Me.MnuStatusLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuStatusLlantas.Name = "MnuStatusLlantas"
        Me.MnuStatusLlantas.Size = New System.Drawing.Size(242, 38)
        Me.MnuStatusLlantas.Text = "Estatus llantas"
        '
        'MnuConmLlantas
        '
        Me.MnuConmLlantas.Image = Global.SGT_Transport.My.Resources.Resources.carta7
        Me.MnuConmLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuConmLlantas.Name = "MnuConmLlantas"
        Me.MnuConmLlantas.Size = New System.Drawing.Size(242, 38)
        Me.MnuConmLlantas.Text = "Conceptos movs. inv. llantas"
        '
        'MnuLlantasSinAsignar
        '
        Me.MnuLlantasSinAsignar.Image = Global.SGT_Transport.My.Resources.Resources.llantas_sin_asignar
        Me.MnuLlantasSinAsignar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuLlantasSinAsignar.Name = "MnuLlantasSinAsignar"
        Me.MnuLlantasSinAsignar.Size = New System.Drawing.Size(242, 38)
        Me.MnuLlantasSinAsignar.Text = "Llantas sin asignar"
        '
        'MnuBuscarXNumEconomico
        '
        Me.MnuBuscarXNumEconomico.Image = Global.SGT_Transport.My.Resources.Resources.buscar_no_econo
        Me.MnuBuscarXNumEconomico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuBuscarXNumEconomico.Name = "MnuBuscarXNumEconomico"
        Me.MnuBuscarXNumEconomico.Size = New System.Drawing.Size(242, 38)
        Me.MnuBuscarXNumEconomico.Text = "Buscar núm. económico"
        '
        'MnuImprimir
        '
        Me.MnuImprimir.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.MnuImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuImprimir.Name = "MnuImprimir"
        Me.MnuImprimir.Size = New System.Drawing.Size(242, 38)
        Me.MnuImprimir.Text = "Imprimir"
        '
        'MnuUniSinLLanAsig
        '
        Me.MnuUniSinLLanAsig.Image = Global.SGT_Transport.My.Resources.Resources.Unida_sin_ll_asig
        Me.MnuUniSinLLanAsig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuUniSinLLanAsig.Name = "MnuUniSinLLanAsig"
        Me.MnuUniSinLLanAsig.Size = New System.Drawing.Size(242, 38)
        Me.MnuUniSinLLanAsig.Text = "Unidades sin llantas asignadas"
        '
        'MnuMovsInvLlantas
        '
        Me.MnuMovsInvLlantas.Image = Global.SGT_Transport.My.Resources.Resources.Mov_invent
        Me.MnuMovsInvLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuMovsInvLlantas.Name = "MnuMovsInvLlantas"
        Me.MnuMovsInvLlantas.Size = New System.Drawing.Size(242, 38)
        Me.MnuMovsInvLlantas.Text = "Movimientos al inventario llantas"
        '
        'BarControlLLantas
        '
        Me.BarControlLLantas.Image = Global.SGT_Transport.My.Resources.Resources.llantas4
        Me.BarControlLLantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarControlLLantas.Name = "BarControlLLantas"
        Me.BarControlLLantas.Size = New System.Drawing.Size(242, 38)
        Me.BarControlLLantas.Text = "Control llantas"
        '
        'MnuImportLlantasExcel
        '
        Me.MnuImportLlantasExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel7
        Me.MnuImportLlantasExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuImportLlantasExcel.Name = "MnuImportLlantasExcel"
        Me.MnuImportLlantasExcel.Size = New System.Drawing.Size(242, 38)
        Me.MnuImportLlantasExcel.Text = "Importar llantas desde excel"
        '
        'BarPilasDesecho
        '
        Me.BarPilasDesecho.Image = Global.SGT_Transport.My.Resources.Resources.llanta16
        Me.BarPilasDesecho.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarPilasDesecho.Name = "BarPilasDesecho"
        Me.BarPilasDesecho.Size = New System.Drawing.Size(242, 38)
        Me.BarPilasDesecho.Text = "Pilas desecho"
        '
        'BarReportSemaforeoLlantas
        '
        Me.BarReportSemaforeoLlantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarReportSemaforeoLlantas.ForeColor = System.Drawing.Color.Black
        Me.BarReportSemaforeoLlantas.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarReportSemaforeoLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReportSemaforeoLlantas.Name = "BarReportSemaforeoLlantas"
        Me.BarReportSemaforeoLlantas.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarReportSemaforeoLlantas.Size = New System.Drawing.Size(103, 49)
        Me.BarReportSemaforeoLlantas.Text = "Semaforeo llantas"
        Me.BarReportSemaforeoLlantas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarCostoPorKilometro, Me.BarDetalladoDeLlantas, Me.BarResumenDeLlantas, Me.BarIndicadoresGraficos, Me.BarReporteDeInspecciones, Me.BarInspeccionesDiarias})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem1.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(62, 49)
        Me.ToolStripMenuItem1.Text = "Reportes"
        Me.ToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCostoPorKilometro
        '
        Me.BarCostoPorKilometro.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarCostoPorKilometro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCostoPorKilometro.Name = "BarCostoPorKilometro"
        Me.BarCostoPorKilometro.Size = New System.Drawing.Size(208, 38)
        Me.BarCostoPorKilometro.Text = "Costo por kilometro"
        '
        'BarDetalladoDeLlantas
        '
        Me.BarDetalladoDeLlantas.Image = Global.SGT_Transport.My.Resources.Resources.impresora25
        Me.BarDetalladoDeLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDetalladoDeLlantas.Name = "BarDetalladoDeLlantas"
        Me.BarDetalladoDeLlantas.Size = New System.Drawing.Size(208, 38)
        Me.BarDetalladoDeLlantas.Text = "Detallado de llantas"
        '
        'BarResumenDeLlantas
        '
        Me.BarResumenDeLlantas.Image = Global.SGT_Transport.My.Resources.Resources.printer22
        Me.BarResumenDeLlantas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarResumenDeLlantas.Name = "BarResumenDeLlantas"
        Me.BarResumenDeLlantas.Size = New System.Drawing.Size(208, 38)
        Me.BarResumenDeLlantas.Text = "Resumen de llantas"
        '
        'BarIndicadoresGraficos
        '
        Me.BarIndicadoresGraficos.Image = Global.SGT_Transport.My.Resources.Resources.impresora29
        Me.BarIndicadoresGraficos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarIndicadoresGraficos.Name = "BarIndicadoresGraficos"
        Me.BarIndicadoresGraficos.Size = New System.Drawing.Size(208, 38)
        Me.BarIndicadoresGraficos.Text = "Indicadores graficos"
        '
        'BarReporteDeInspecciones
        '
        Me.BarReporteDeInspecciones.Image = Global.SGT_Transport.My.Resources.Resources.impresora32
        Me.BarReporteDeInspecciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReporteDeInspecciones.Name = "BarReporteDeInspecciones"
        Me.BarReporteDeInspecciones.Size = New System.Drawing.Size(208, 38)
        Me.BarReporteDeInspecciones.Text = "Reporte de inspecciones"
        '
        'BarInspeccionesDiarias
        '
        Me.BarInspeccionesDiarias.Image = Global.SGT_Transport.My.Resources.Resources.impresora16
        Me.BarInspeccionesDiarias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarInspeccionesDiarias.Name = "BarInspeccionesDiarias"
        Me.BarInspeccionesDiarias.Size = New System.Drawing.Size(208, 38)
        Me.BarInspeccionesDiarias.Text = "Inspecciones diarias"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(45, 49)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 49)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 5.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Top
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.Location = New System.Drawing.Point(0, 50)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1131, 248)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 8
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAsignarStatus})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(149, 26)
        '
        'MnuAsignarStatus
        '
        Me.MnuAsignarStatus.Image = Global.SGT_Transport.My.Resources.Resources.unidadroja1
        Me.MnuAsignarStatus.Name = "MnuAsignarStatus"
        Me.MnuAsignarStatus.Size = New System.Drawing.Size(148, 22)
        Me.MnuAsignarStatus.Text = "Asignar status"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(424, 13)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 17
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(697, 16)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(17, 17)
        Me.Lt1.TabIndex = 18
        Me.Lt1.Text = "_"
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.ItemSize = New System.Drawing.Size(140, 30)
        Me.Tab1.Location = New System.Drawing.Point(4, 12)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(1133, 423)
        Me.Tab1.SplitterWidth = 1
        Me.Tab1.TabIndex = 19
        Me.Tab1.TabsSpacing = 5
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.TBUSCAR)
        Me.Pag1.Controls.Add(Me.Lt1)
        Me.Pag1.Controls.Add(Me.Label1)
        Me.Pag1.Controls.Add(Me.Fg)
        Me.Pag1.Controls.Add(Me.BarraMenu)
        Me.Pag1.Location = New System.Drawing.Point(1, 33)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(1131, 389)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Llantas"
        '
        'TBUSCAR
        '
        Me.TBUSCAR.AcceptsReturn = True
        Me.TBUSCAR.AcceptsTab = True
        Me.TBUSCAR.AllowDrop = True
        Me.TBUSCAR.AutoSize = False
        Me.TBUSCAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBUSCAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TBUSCAR.Location = New System.Drawing.Point(947, 11)
        Me.TBUSCAR.MaxLength = 50
        Me.TBUSCAR.Name = "TBUSCAR"
        Me.TBUSCAR.Padding = New System.Windows.Forms.Padding(4)
        Me.TBUSCAR.ShowFocusRectangle = True
        Me.TBUSCAR.Size = New System.Drawing.Size(175, 27)
        Me.TBUSCAR.TabIndex = 1
        Me.TBUSCAR.Tag = Nothing
        Me.TBUSCAR.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        Me.TBUSCAR.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TBUSCAR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TBUSCAR.WordWrap = False
        Me.TBUSCAR.WrapDateTimeFields = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(854, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Texto a buscar"
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.Fg2)
        Me.Pag2.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Pag2.Controls.Add(Me.C1ToolBar1)
        Me.Pag2.Location = New System.Drawing.Point(1, 33)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(1131, 389)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Inspecciones"
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.AutoClipboard = True
        Me.Fg2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg2.AutoSearchDelay = 5.0R
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg2.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg2.Location = New System.Drawing.Point(47, 83)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(709, 247)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 312
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(787, 3)
        Me.C1FlexGridSearchPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.ShowClearButton = False
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(248, 41)
        Me.C1FlexGridSearchPanel1.TabIndex = 17
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 70
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkEliminar, Me.LkFinalizar, Me.LkReactivar, Me.LkActualizar, Me.LkImprimir, Me.LkExcel, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1131, 47)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.CmdNuevo
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.Text = "Nuevo"
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.CmdNuevo.ShortcutText = ""
        Me.CmdNuevo.ShowShortcut = False
        Me.CmdNuevo.ShowTextAsToolTip = False
        Me.CmdNuevo.Text = "Nuevo"
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.CmdEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Edit"
        '
        'CmdEdit
        '
        Me.CmdEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.CmdEdit.ShortcutText = ""
        Me.CmdEdit.Text = "Edit"
        '
        'LkEliminar
        '
        Me.LkEliminar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEliminar.Command = Me.CmdCancelar
        Me.LkEliminar.Delimiter = True
        Me.LkEliminar.SortOrder = 2
        Me.LkEliminar.Text = "Cancelar"
        Me.LkEliminar.ToolTipText = "Cancelar"
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar1
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.ShortcutText = ""
        Me.CmdCancelar.ShowShortcut = False
        Me.CmdCancelar.ShowTextAsToolTip = False
        Me.CmdCancelar.Text = "Cancelar"
        '
        'LkFinalizar
        '
        Me.LkFinalizar.Command = Me.CmdFinalizar
        Me.LkFinalizar.Delimiter = True
        Me.LkFinalizar.SortOrder = 3
        Me.LkFinalizar.Text = "Finalizar"
        '
        'CmdFinalizar
        '
        Me.CmdFinalizar.Image = Global.SGT_Transport.My.Resources.Resources.fin4
        Me.CmdFinalizar.Name = "CmdFinalizar"
        Me.CmdFinalizar.ShortcutText = ""
        Me.CmdFinalizar.Text = "Finalizar"
        '
        'LkReactivar
        '
        Me.LkReactivar.Command = Me.CmdReactivar
        Me.LkReactivar.Delimiter = True
        Me.LkReactivar.SortOrder = 4
        Me.LkReactivar.Text = "Reactivar"
        '
        'CmdReactivar
        '
        Me.CmdReactivar.Image = Global.SGT_Transport.My.Resources.Resources.react4
        Me.CmdReactivar.Name = "CmdReactivar"
        Me.CmdReactivar.ShortcutText = ""
        Me.CmdReactivar.Text = "Reactivar"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.CmdActualizar
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 5
        Me.LkActualizar.Text = "Actualizar"
        '
        'CmdActualizar
        '
        Me.CmdActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.ShortcutText = ""
        Me.CmdActualizar.Text = "Actualizar"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 6
        Me.LkImprimir.Text = "Imprimir"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.CmdExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 7
        Me.LkExcel.Text = "Excel"
        '
        'CmdExcel
        '
        Me.CmdExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.CmdExcel.Name = "CmdExcel"
        Me.CmdExcel.ShortcutText = ""
        Me.CmdExcel.Text = "Excel"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDisenador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 8
        Me.LkDisenador.Text = "Diseñador"
        '
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutText = ""
        Me.BarDisenador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.CmdSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 9
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.CmdSalir.ShortcutText = ""
        Me.CmdSalir.ShowShortcut = False
        Me.CmdSalir.ShowTextAsToolTip = False
        Me.CmdSalir.Text = "Salir"
        '
        'Pag3
        '
        Me.Pag3.Controls.Add(Me.Fg3)
        Me.Pag3.Location = New System.Drawing.Point(1, 33)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(1131, 389)
        Me.Pag3.TabIndex = 2
        Me.Pag3.Text = "Cancelados"
        '
        'Fg3
        '
        Me.Fg3.AllowEditing = False
        Me.Fg3.AllowFiltering = True
        Me.Fg3.AutoClipboard = True
        Me.Fg3.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg3.AutoSearchDelay = 5.0R
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg3.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg3.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg3.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Fg3.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg3.Location = New System.Drawing.Point(17, 39)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.Rows.Count = 1
        Me.Fg3.Rows.DefaultSize = 19
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg3.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg3.Size = New System.Drawing.Size(709, 247)
        Me.Fg3.StyleInfo = resources.GetString("Fg3.StyleInfo")
        Me.Fg3.TabIndex = 313
        Me.Fg3.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarReactivarLlanta})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(155, 26)
        '
        'BarReactivarLlanta
        '
        Me.BarReactivarLlanta.Image = Global.SGT_Transport.My.Resources.Resources.llantaX2
        Me.BarReactivarLlanta.Name = "BarReactivarLlanta"
        Me.BarReactivarLlanta.Size = New System.Drawing.Size(154, 22)
        Me.BarReactivarLlanta.Text = "Reactivar llanta"
        '
        'MenuHolder1
        '
        Me.MenuHolder1.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder1.Commands.Add(Me.CmdNuevo)
        Me.MenuHolder1.Commands.Add(Me.CmdEdit)
        Me.MenuHolder1.Commands.Add(Me.CmdCancelar)
        Me.MenuHolder1.Commands.Add(Me.CmdFinalizar)
        Me.MenuHolder1.Commands.Add(Me.CmdReactivar)
        Me.MenuHolder1.Commands.Add(Me.CmdSalir)
        Me.MenuHolder1.Commands.Add(Me.CmdExcel)
        Me.MenuHolder1.Commands.Add(Me.CmdActualizar)
        Me.MenuHolder1.Commands.Add(Me.BarImprimir)
        Me.MenuHolder1.Commands.Add(Me.BarDisenador)
        Me.MenuHolder1.Owner = Me
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "b21af5aec9bf409786cf0d51b60989e0"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmLlantas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 485)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.lblStatus)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLlantas"
        Me.Text = "Llantas"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.TBUSCAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag3.ResumeLayout(False)
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents BarNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarMenuLlantas As ToolStripMenuItem
    Friend WithEvents MnuAsignacionDeLLantas As ToolStripMenuItem
    Friend WithEvents MnuStatusLlantas As ToolStripMenuItem
    Friend WithEvents MnuLlantasSinAsignar As ToolStripMenuItem
    Friend WithEvents MnuBuscarXNumEconomico As ToolStripMenuItem
    Friend WithEvents MnuImprimir As ToolStripMenuItem
    Friend WithEvents MnuUniSinLLanAsig As ToolStripMenuItem
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarDesgaste As ToolStripMenuItem
    Friend WithEvents MnuMovsInvLlantas As ToolStripMenuItem
    Friend WithEvents MnuDesasignarLLantas As ToolStripMenuItem
    Friend WithEvents BarControlLLantas As ToolStripMenuItem
    Friend WithEvents MnuConmLlantas As ToolStripMenuItem
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents MenuHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Private WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LkFinalizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkReactivar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarReportSemaforeoLlantas As ToolStripMenuItem
    Friend WithEvents MnuImportLlantasExcel As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MnuAsignarStatus As ToolStripMenuItem
    Friend WithEvents TBUSCAR As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BarFiltro As ToolStripMenuItem
    Friend WithEvents BarTodos As ToolStripMenuItem
    Private WithEvents BarDisenador As C1.Win.C1Command.C1Command
    Private WithEvents CmdNuevo As C1.Win.C1Command.C1Command
    Private WithEvents CmdEdit As C1.Win.C1Command.C1Command
    Private WithEvents CmdSalir As C1.Win.C1Command.C1Command
    Private WithEvents CmdExcel As C1.Win.C1Command.C1Command
    Private WithEvents CmdActualizar As C1.Win.C1Command.C1Command
    Private WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Private WithEvents CmdFinalizar As C1.Win.C1Command.C1Command
    Private WithEvents CmdReactivar As C1.Win.C1Command.C1Command
    Private WithEvents CmdCancelar As C1.Win.C1Command.C1Command
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BarCostoPorKilometro As ToolStripMenuItem
    Friend WithEvents BarDetalladoDeLlantas As ToolStripMenuItem
    Friend WithEvents BarResumenDeLlantas As ToolStripMenuItem
    Friend WithEvents BarIndicadoresGraficos As ToolStripMenuItem
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents BarReactivarLlanta As ToolStripMenuItem
    Friend WithEvents BarReporteDeInspecciones As ToolStripMenuItem
    Friend WithEvents BarPilasDesecho As ToolStripMenuItem
    Friend WithEvents BarInspeccionesDiarias As ToolStripMenuItem
End Class
