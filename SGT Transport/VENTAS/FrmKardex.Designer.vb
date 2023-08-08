<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKardex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKardex))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.Lt11 = New System.Windows.Forms.Label()
        Me.Lt10 = New System.Windows.Forms.Label()
        Me.Lt9 = New System.Windows.Forms.Label()
        Me.Lt8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Lt12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FgA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.barMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarExcel, Me.BarRefresh, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1201, 55)
        Me.barMenu.TabIndex = 12
        Me.barMenu.Text = "MenuStrip1"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarExcel.Size = New System.Drawing.Size(68, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRefresh
        '
        Me.BarRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRefresh.ForeColor = System.Drawing.Color.Black
        Me.BarRefresh.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.BarRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarRefresh.Size = New System.Drawing.Size(93, 51)
        Me.BarRefresh.Text = "Actualizar"
        Me.BarRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(66, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.CellButtonImage = CType(resources.GetObject("Fg.CellButtonImage"), System.Drawing.Image)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1201, 269)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 6
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.Location = New System.Drawing.Point(26, 41)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(100, 15)
        Me.Lt.TabIndex = 187
        Me.Lt.Text = "Unidad de salida"
        Me.Lt.Visible = False
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(41, 139)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(85, 15)
        Me.Label94.TabIndex = 185
        Me.Label94.Text = "Stock maximo"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.Location = New System.Drawing.Point(44, 114)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(82, 15)
        Me.Label92.TabIndex = 184
        Me.Label92.Text = "Stock minimo"
        '
        'L1
        '
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(223, 13)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(494, 20)
        Me.L1.TabIndex = 183
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 15)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "Control de almacen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 15)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "Unidad de entrada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(79, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Articulo"
        '
        'Lt2
        '
        Me.Lt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(127, 38)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(90, 20)
        Me.Lt2.TabIndex = 193
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lt2.Visible = False
        '
        'Lt6
        '
        Me.Lt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(127, 136)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(90, 20)
        Me.Lt6.TabIndex = 192
        Me.Lt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt5
        '
        Me.Lt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(127, 111)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(90, 20)
        Me.Lt5.TabIndex = 191
        Me.Lt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt4
        '
        Me.Lt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.Location = New System.Drawing.Point(127, 87)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(90, 20)
        Me.Lt4.TabIndex = 190
        Me.Lt4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt3
        '
        Me.Lt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.Location = New System.Drawing.Point(127, 64)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(90, 20)
        Me.Lt3.TabIndex = 189
        Me.Lt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt1
        '
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(127, 13)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(90, 20)
        Me.Lt1.TabIndex = 188
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt7
        '
        Me.Lt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(340, 38)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(90, 20)
        Me.Lt7.TabIndex = 203
        Me.Lt7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lt7.Visible = False
        '
        'Lt11
        '
        Me.Lt11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt11.Location = New System.Drawing.Point(340, 136)
        Me.Lt11.Name = "Lt11"
        Me.Lt11.Size = New System.Drawing.Size(90, 20)
        Me.Lt11.TabIndex = 202
        Me.Lt11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt10
        '
        Me.Lt10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt10.Location = New System.Drawing.Point(340, 111)
        Me.Lt10.Name = "Lt10"
        Me.Lt10.Size = New System.Drawing.Size(90, 20)
        Me.Lt10.TabIndex = 201
        Me.Lt10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt9
        '
        Me.Lt9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt9.Location = New System.Drawing.Point(340, 87)
        Me.Lt9.Name = "Lt9"
        Me.Lt9.Size = New System.Drawing.Size(90, 20)
        Me.Lt9.TabIndex = 200
        Me.Lt9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt8
        '
        Me.Lt8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt8.Location = New System.Drawing.Point(340, 64)
        Me.Lt8.Name = "Lt8"
        Me.Lt8.Size = New System.Drawing.Size(90, 20)
        Me.Lt8.TabIndex = 199
        Me.Lt8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(233, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 15)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = "Fecha ult. compra"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(282, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 15)
        Me.Label11.TabIndex = 197
        Me.Label11.Text = "Entradas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(275, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 196
        Me.Label12.Text = "Existencia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(244, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 15)
        Me.Label13.TabIndex = 195
        Me.Label13.Text = "Costo promedio"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(251, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 15)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "Tipo de costeo"
        '
        'Lt12
        '
        Me.Lt12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt12.Location = New System.Drawing.Point(491, 136)
        Me.Lt12.Name = "Lt12"
        Me.Lt12.Size = New System.Drawing.Size(90, 20)
        Me.Lt12.TabIndex = 205
        Me.Lt12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(436, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 15)
        Me.Label16.TabIndex = 204
        Me.Label16.Text = "Salidas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FgA)
        Me.Panel1.Controls.Add(Me.cboAlmacen)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Lt1)
        Me.Panel1.Controls.Add(Me.Lt12)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Lt7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Lt11)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.Lt10)
        Me.Panel1.Controls.Add(Me.Label92)
        Me.Panel1.Controls.Add(Me.Lt9)
        Me.Panel1.Controls.Add(Me.Label94)
        Me.Panel1.Controls.Add(Me.Lt8)
        Me.Panel1.Controls.Add(Me.Lt)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Lt3)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Lt4)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Lt5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Lt6)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Lt2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1201, 163)
        Me.Panel1.TabIndex = 206
        '
        'FgA
        '
        Me.FgA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgA.AllowEditing = False
        Me.FgA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgA.ColumnInfo = resources.GetString("FgA.ColumnInfo")
        Me.FgA.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgA.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgA.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgA.Location = New System.Drawing.Point(740, 3)
        Me.FgA.Name = "FgA"
        Me.FgA.Rows.Count = 2
        Me.FgA.Rows.DefaultSize = 19
        Me.FgA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgA.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgA.Size = New System.Drawing.Size(372, 153)
        Me.FgA.StyleInfo = resources.GetString("FgA.StyleInfo")
        Me.FgA.TabIndex = 209
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboAlmacen.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(491, 68)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(226, 19)
        Me.cboAlmacen.TabIndex = 207
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(488, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Almacén"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(326, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(231, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 206
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Fg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 218)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1201, 269)
        Me.Panel2.TabIndex = 207
        '
        'frmKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 487)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.barMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmKardex"
        Me.ShowInTaskbar = False
        Me.Text = "Kardex"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Lt As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt6 As Label
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt4 As Label
    Friend WithEvents Lt3 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents Lt11 As Label
    Friend WithEvents Lt10 As Label
    Friend WithEvents Lt9 As Label
    Friend WithEvents Lt8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Lt12 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BarRefresh As ToolStripMenuItem
    Friend WithEvents FgA As C1.Win.C1FlexGrid.C1FlexGrid
End Class
