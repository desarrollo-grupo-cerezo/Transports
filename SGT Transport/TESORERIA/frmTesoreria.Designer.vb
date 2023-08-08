<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTesoreria
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
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.BarAutoriza = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDepositar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDepTrafico = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.FgF = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.c1Buscar = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barMenu.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        Me.Pag3.SuspendLayout()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag4.SuspendLayout()
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1247, 447)
        Me.Fg.TabIndex = 14
        '
        'barMenu
        '
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAutoriza, Me.BarDepositar, Me.BarActualizar, Me.BarCancelar, Me.barImprimir, Me.BarExcel, Me.BarDepTrafico, Me.BarSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1249, 55)
        Me.barMenu.TabIndex = 13
        Me.barMenu.Text = "MenuStrip1"
        '
        'BarAutoriza
        '
        Me.BarAutoriza.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarAutoriza.ForeColor = System.Drawing.Color.Black
        Me.BarAutoriza.Image = Global.SGT_Transport.My.Resources.Resources.TesoAutoGastos
        Me.BarAutoriza.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAutoriza.Name = "BarAutoriza"
        Me.BarAutoriza.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarAutoriza.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarAutoriza.Size = New System.Drawing.Size(67, 51)
        Me.BarAutoriza.Text = "Autorizar"
        Me.BarAutoriza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarAutoriza.ToolTipText = "F2-Nuevo"
        '
        'BarDepositar
        '
        Me.BarDepositar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarDepositar.ForeColor = System.Drawing.Color.Black
        Me.BarDepositar.Image = Global.SGT_Transport.My.Resources.Resources.banco1
        Me.BarDepositar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDepositar.Name = "BarDepositar"
        Me.BarDepositar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarDepositar.Size = New System.Drawing.Size(79, 51)
        Me.BarDepositar.Text = "Depositado"
        Me.BarDepositar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'barImprimir
        '
        Me.barImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barImprimir.ForeColor = System.Drawing.Color.Black
        Me.barImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.barImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barImprimir.Name = "barImprimir"
        Me.barImprimir.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barImprimir.Size = New System.Drawing.Size(65, 51)
        Me.barImprimir.Text = "Imprimir"
        Me.barImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDepTrafico
        '
        Me.BarDepTrafico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarDepTrafico.ForeColor = System.Drawing.Color.Black
        Me.BarDepTrafico.Image = Global.SGT_Transport.My.Resources.Resources.evaluacion
        Me.BarDepTrafico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDepTrafico.Name = "BarDepTrafico"
        Me.BarDepTrafico.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarDepTrafico.Size = New System.Drawing.Size(111, 51)
        Me.BarDepTrafico.Text = "Depositos  tráfico"
        Me.BarDepTrafico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Controls.Add(Me.Pag4)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 3
        Me.Tab1.Size = New System.Drawing.Size(1249, 472)
        Me.Tab1.TabIndex = 15
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.Fg)
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(1247, 447)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Autorización"
        '
        'Pag3
        '
        Me.Pag3.Controls.Add(Me.FgA)
        Me.Pag3.Location = New System.Drawing.Point(1, 24)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(1247, 447)
        Me.Pag3.TabIndex = 2
        Me.Pag3.Text = "Gastos autorizados"
        '
        'FgA
        '
        Me.FgA.AllowFiltering = True
        Me.FgA.AutoClipboard = True
        Me.FgA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgA.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgA.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.FgA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgA.Location = New System.Drawing.Point(0, 0)
        Me.FgA.Name = "FgA"
        Me.FgA.Rows.Count = 1
        Me.FgA.Rows.DefaultSize = 25
        Me.FgA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgA.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgA.Size = New System.Drawing.Size(1247, 447)
        Me.FgA.TabIndex = 15
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.Fg2)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(1247, 447)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Depósitos"
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.AutoClipboard = True
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg2.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(1247, 447)
        Me.Fg2.TabIndex = 15
        '
        'Pag4
        '
        Me.Pag4.Controls.Add(Me.FgF)
        Me.Pag4.Location = New System.Drawing.Point(1, 24)
        Me.Pag4.Name = "Pag4"
        Me.Pag4.Size = New System.Drawing.Size(1247, 447)
        Me.Pag4.TabIndex = 3
        Me.Pag4.Text = "Movimientos"
        '
        'FgF
        '
        Me.FgF.AllowFiltering = True
        Me.FgF.AutoClipboard = True
        Me.FgF.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.c1Buscar.SetC1FlexGridSearchPanel(Me.FgF, Me.c1Buscar)
        Me.FgF.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgF.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.FgF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgF.Location = New System.Drawing.Point(0, 0)
        Me.FgF.Name = "FgF"
        Me.FgF.Rows.Count = 1
        Me.FgF.Rows.DefaultSize = 25
        Me.FgF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgF.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgF.Size = New System.Drawing.Size(1247, 447)
        Me.FgF.TabIndex = 16
        '
        'c1Buscar
        '
        Me.c1Buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.c1Buscar.Location = New System.Drawing.Point(907, 5)
        Me.c1Buscar.Name = "c1Buscar"
        Me.c1Buscar.SearchDelay = 500
        Me.c1Buscar.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.c1Buscar.Size = New System.Drawing.Size(236, 44)
        Me.c1Buscar.TabIndex = 20
        Me.c1Buscar.Watermark = "Texto a buscar"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tab1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BarraAbajo)
        Me.SplitContainer1.Size = New System.Drawing.Size(1249, 510)
        Me.SplitContainer1.SplitterDistance = 472
        Me.SplitContainer1.TabIndex = 21
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BarraAbajo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 0)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1249, 34)
        Me.BarraAbajo.TabIndex = 17
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
        'FrmTesoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1249, 565)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.c1Buscar)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTesoreria"
        Me.Text = "Tesoreria"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag3.ResumeLayout(False)
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag4.ResumeLayout(False)
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents BarAutoriza As ToolStripMenuItem
    Friend WithEvents BarDepositar As ToolStripMenuItem
    Friend WithEvents BarCancelar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents c1Buscar As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents barImprimir As ToolStripMenuItem
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Pag4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents FgF As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarDepTrafico As ToolStripMenuItem
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
End Class
