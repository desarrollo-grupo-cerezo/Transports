<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImportAsigLlantasExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportAsigLlantasExcel))
        Me.CboHojas = New C1.Win.C1Input.C1ComboBox()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.TExcel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.ImportarBuenoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarClie_OP = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarOperadores = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarUnidades = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActCampSATclieOP = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCargarArchivoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarInven = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarMult = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1XLBook1 = New C1.C1Excel.C1XLBook()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.CboColumna = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboPos = New C1.Win.C1Input.C1ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CboNumEcon = New C1.Win.C1Input.C1ComboBox()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TBOX = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboTipoUnidad = New C1.Win.C1Input.C1ComboBox()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.CboHojas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboColumna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboNumEcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboHojas
        '
        Me.CboHojas.AllowSpinLoop = False
        Me.CboHojas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboHojas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboHojas.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboHojas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboHojas.GapHeight = 0
        Me.CboHojas.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboHojas.ItemsDisplayMember = ""
        Me.CboHojas.ItemsValueMember = ""
        Me.CboHojas.Location = New System.Drawing.Point(140, 108)
        Me.CboHojas.Name = "CboHojas"
        Me.CboHojas.Size = New System.Drawing.Size(164, 19)
        Me.CboHojas.TabIndex = 22
        Me.CboHojas.Tag = Nothing
        Me.CboHojas.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboHojas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnExcel
        '
        Me.BtnExcel.Location = New System.Drawing.Point(742, 70)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(27, 23)
        Me.BtnExcel.TabIndex = 21
        Me.BtnExcel.Text = "....."
        Me.BtnExcel.UseVisualStyleBackColor = True
        '
        'TExcel
        '
        Me.TExcel.AcceptsReturn = True
        Me.TExcel.AcceptsTab = True
        Me.TExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TExcel.Location = New System.Drawing.Point(140, 72)
        Me.TExcel.Name = "TExcel"
        Me.TExcel.Size = New System.Drawing.Size(596, 21)
        Me.TExcel.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(7, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Selecciona archivo Excel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(51, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Selecciona hoja"
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarBuenoToolStripMenuItem, Me.barCargarArchivoExcel, Me.BarEliminar, Me.BarGrabar, Me.BarInven, Me.ToolStripMenuItem1, Me.BarMult, Me.BarSalir, Me.ToolStripMenuItem2})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1377, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 24
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'ImportarBuenoToolStripMenuItem
        '
        Me.ImportarBuenoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarClientes, Me.BarClie_OP, Me.BarOperadores, Me.BarUnidades, Me.BarActCampSATclieOP})
        Me.ImportarBuenoToolStripMenuItem.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.ImportarBuenoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImportarBuenoToolStripMenuItem.Name = "ImportarBuenoToolStripMenuItem"
        Me.ImportarBuenoToolStripMenuItem.Size = New System.Drawing.Size(102, 51)
        Me.ImportarBuenoToolStripMenuItem.Text = "Importar Bueno"
        Me.ImportarBuenoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarClientes
        '
        Me.BarClientes.Name = "BarClientes"
        Me.BarClientes.Size = New System.Drawing.Size(310, 22)
        Me.BarClientes.Text = "Clientes"
        '
        'BarClie_OP
        '
        Me.BarClie_OP.Name = "BarClie_OP"
        Me.BarClie_OP.Size = New System.Drawing.Size(310, 22)
        Me.BarClie_OP.Text = "Clientes operativos"
        '
        'BarOperadores
        '
        Me.BarOperadores.Name = "BarOperadores"
        Me.BarOperadores.Size = New System.Drawing.Size(310, 22)
        Me.BarOperadores.Text = "Operadores"
        '
        'BarUnidades
        '
        Me.BarUnidades.Name = "BarUnidades"
        Me.BarUnidades.Size = New System.Drawing.Size(310, 22)
        Me.BarUnidades.Text = "Unidades"
        '
        'BarActCampSATclieOP
        '
        Me.BarActCampSATclieOP.Name = "BarActCampSATclieOP"
        Me.BarActCampSATclieOP.Size = New System.Drawing.Size(310, 22)
        Me.BarActCampSATclieOP.Text = "Actaulizar campos SAT en clientes operativos"
        '
        'barCargarArchivoExcel
        '
        Me.barCargarArchivoExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barCargarArchivoExcel.ForeColor = System.Drawing.Color.White
        Me.barCargarArchivoExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.barCargarArchivoExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCargarArchivoExcel.Name = "barCargarArchivoExcel"
        Me.barCargarArchivoExcel.ShortcutKeyDisplayString = ""
        Me.barCargarArchivoExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barCargarArchivoExcel.Size = New System.Drawing.Size(128, 51)
        Me.barCargarArchivoExcel.Text = "Cargar Archivo Excel"
        Me.barCargarArchivoExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarEliminar.ForeColor = System.Drawing.Color.White
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeyDisplayString = "F8-Eliminar partida"
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.BarEliminar.Size = New System.Drawing.Size(83, 51)
        Me.BarEliminar.Text = "Eliminar par."
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.White
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = ""
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(96, 51)
        Me.BarGrabar.Text = "Asignar llantas"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarInven
        '
        Me.BarInven.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarInven.ForeColor = System.Drawing.Color.White
        Me.BarInven.Image = Global.SGT_Transport.My.Resources.Resources.code5
        Me.BarInven.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarInven.Name = "BarInven"
        Me.BarInven.ShortcutKeyDisplayString = ""
        Me.BarInven.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarInven.Size = New System.Drawing.Size(48, 51)
        Me.BarInven.Text = "Inven"
        Me.BarInven.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Image = Global.SGT_Transport.My.Resources.Resources.fig1
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(127, 51)
        Me.ToolStripMenuItem1.Text = "Comparar columnas"
        Me.ToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarMult
        '
        Me.BarMult.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarMult.ForeColor = System.Drawing.Color.White
        Me.BarMult.Image = Global.SGT_Transport.My.Resources.Resources.M2
        Me.BarMult.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarMult.Name = "BarMult"
        Me.BarMult.ShortcutKeyDisplayString = ""
        Me.BarMult.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarMult.Size = New System.Drawing.Size(92, 51)
        Me.BarMult.Text = "Multialmacen"
        Me.BarMult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.White
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
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(12, 142)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 10
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.Size = New System.Drawing.Size(1142, 370)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 25
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.BackColor = System.Drawing.Color.Transparent
        Me.Lt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt6.Location = New System.Drawing.Point(915, 71)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(253, 20)
        Me.Lt6.TabIndex = 32
        Me.Lt6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Location = New System.Drawing.Point(309, 112)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(83, 13)
        Me.Label66.TabIndex = 204
        Me.Label66.Text = "Columna unidad"
        '
        'CboColumna
        '
        Me.CboColumna.AcceptsTab = True
        Me.CboColumna.AllowSpinLoop = True
        Me.CboColumna.AutoOpen = True
        Me.CboColumna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboColumna.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboColumna.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboColumna.GapHeight = 0
        Me.CboColumna.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboColumna.InitialSelection = C1.Win.C1Input.InitialSelectionEnum.SelectAll
        Me.CboColumna.ItemsDisplayMember = ""
        Me.CboColumna.ItemsValueMember = ""
        Me.CboColumna.Location = New System.Drawing.Point(395, 110)
        Me.CboColumna.Name = "CboColumna"
        Me.CboColumna.ShowFocusRectangle = True
        Me.CboColumna.Size = New System.Drawing.Size(51, 18)
        Me.CboColumna.TabIndex = 203
        Me.CboColumna.Tag = Nothing
        Me.CboColumna.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboColumna.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(451, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Posicion llanta"
        '
        'CboPos
        '
        Me.CboPos.AcceptsTab = True
        Me.CboPos.AllowSpinLoop = True
        Me.CboPos.AutoOpen = True
        Me.CboPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboPos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboPos.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboPos.GapHeight = 0
        Me.CboPos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboPos.InitialSelection = C1.Win.C1Input.InitialSelectionEnum.SelectAll
        Me.CboPos.ItemsDisplayMember = ""
        Me.CboPos.ItemsValueMember = ""
        Me.CboPos.Location = New System.Drawing.Point(528, 110)
        Me.CboPos.Name = "CboPos"
        Me.CboPos.ShowFocusRectangle = True
        Me.CboPos.Size = New System.Drawing.Size(51, 18)
        Me.CboPos.TabIndex = 205
        Me.CboPos.Tag = Nothing
        Me.CboPos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboPos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(589, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "num. eco."
        '
        'CboNumEcon
        '
        Me.CboNumEcon.AcceptsTab = True
        Me.CboNumEcon.AllowSpinLoop = True
        Me.CboNumEcon.AutoOpen = True
        Me.CboNumEcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboNumEcon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboNumEcon.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboNumEcon.GapHeight = 0
        Me.CboNumEcon.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboNumEcon.InitialSelection = C1.Win.C1Input.InitialSelectionEnum.SelectAll
        Me.CboNumEcon.ItemsDisplayMember = ""
        Me.CboNumEcon.ItemsValueMember = ""
        Me.CboNumEcon.Location = New System.Drawing.Point(645, 110)
        Me.CboNumEcon.Name = "CboNumEcon"
        Me.CboNumEcon.ShowFocusRectangle = True
        Me.CboNumEcon.Size = New System.Drawing.Size(51, 18)
        Me.CboNumEcon.TabIndex = 207
        Me.CboNumEcon.Tag = Nothing
        Me.CboNumEcon.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboNumEcon.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1124, 0)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(241, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 209
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Lt7
        '
        Me.Lt7.BackColor = System.Drawing.Color.Transparent
        Me.Lt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt7.Location = New System.Drawing.Point(915, 105)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(253, 20)
        Me.Lt7.TabIndex = 210
        Me.Lt7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBOX
        '
        Me.TBOX.Location = New System.Drawing.Point(824, 73)
        Me.TBOX.Name = "TBOX"
        Me.TBOX.Size = New System.Drawing.Size(51, 20)
        Me.TBOX.TabIndex = 211
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(705, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Tipo unidad"
        '
        'CboTipoUnidad
        '
        Me.CboTipoUnidad.AcceptsTab = True
        Me.CboTipoUnidad.AllowSpinLoop = True
        Me.CboTipoUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipoUnidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipoUnidad.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipoUnidad.GapHeight = 0
        Me.CboTipoUnidad.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipoUnidad.InitialSelection = C1.Win.C1Input.InitialSelectionEnum.SelectAll
        Me.CboTipoUnidad.ItemsDisplayMember = ""
        Me.CboTipoUnidad.ItemsValueMember = ""
        Me.CboTipoUnidad.Location = New System.Drawing.Point(774, 109)
        Me.CboTipoUnidad.Name = "CboTipoUnidad"
        Me.CboTipoUnidad.ShowFocusRectangle = True
        Me.CboTipoUnidad.Size = New System.Drawing.Size(117, 18)
        Me.CboTipoUnidad.TabIndex = 212
        Me.CboTipoUnidad.Tag = Nothing
        Me.CboTipoUnidad.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboTipoUnidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(126, 51)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'FrmImportAsigLlantasExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1377, 524)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboTipoUnidad)
        Me.Controls.Add(Me.TBOX)
        Me.Controls.Add(Me.Lt7)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CboNumEcon)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboPos)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.CboColumna)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboHojas)
        Me.Controls.Add(Me.BtnExcel)
        Me.Controls.Add(Me.TExcel)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImportAsigLlantasExcel"
        Me.Text = "Utilerias"
        CType(Me.CboHojas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboColumna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboNumEcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CboHojas As C1.Win.C1Input.C1ComboBox
    Friend WithEvents BtnExcel As Button
    Friend WithEvents TExcel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1XLBook1 As C1.C1Excel.C1XLBook
    Friend WithEvents barCargarArchivoExcel As ToolStripMenuItem
    Friend WithEvents Lt6 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents CboColumna As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CboPos As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CboNumEcon As C1.Win.C1Input.C1ComboBox
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Lt7 As Label
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarInven As ToolStripMenuItem
    Friend WithEvents BarMult As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImportarBuenoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarClientes As ToolStripMenuItem
    Friend WithEvents BarClie_OP As ToolStripMenuItem
    Friend WithEvents BarOperadores As ToolStripMenuItem
    Friend WithEvents BarUnidades As ToolStripMenuItem
    Friend WithEvents TBOX As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CboTipoUnidad As C1.Win.C1Input.C1ComboBox
    Friend WithEvents BarActCampSATclieOP As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class
