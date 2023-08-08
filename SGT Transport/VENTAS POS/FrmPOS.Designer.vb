<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOS))
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM1P1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitM3 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM3P1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.TARTICULO = New C1.Win.C1Input.C1TextBox()
        Me.SplitM3P2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.TXTN = New C1.Win.C1Input.C1NumericEdit()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitM3P3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtMonto = New C1.Win.C1Input.C1Label()
        Me.SplitM3P4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitM1P2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnClienteDatos = New C1.Win.C1Input.C1Button()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.SplitM1P3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitM2 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM2P1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtArticulo = New C1.Win.C1Input.C1Label()
        Me.LtPrecioXProducto = New C1.Win.C1Input.C1Label()
        Me.LtTotalArt = New C1.Win.C1Input.C1Label()
        Me.BtnCliente = New C1.Win.C1Input.C1Button()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.BtnCobrar = New C1.Win.C1Input.C1Button()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.SplitM1P1.SuspendLayout()
        CType(Me.SplitM3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM3.SuspendLayout()
        Me.SplitM3P1.SuspendLayout()
        CType(Me.TARTICULO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM3P2.SuspendLayout()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM3P3.SuspendLayout()
        CType(Me.LtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1P2.SuspendLayout()
        CType(Me.BtnClienteDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1P3.SuspendLayout()
        CType(Me.SplitM2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM2.SuspendLayout()
        Me.SplitM2P1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.LtArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtPrecioXProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtTotalArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCobrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.White
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SplitM1.FixedLineColor = System.Drawing.Color.Black
        Me.SplitM1.ForeColor = System.Drawing.Color.Black
        Me.SplitM1.Location = New System.Drawing.Point(0, 0)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.SplitM1P1)
        Me.SplitM1.Panels.Add(Me.SplitM1P2)
        Me.SplitM1.Panels.Add(Me.SplitM1P3)
        Me.SplitM1.Size = New System.Drawing.Size(1153, 703)
        Me.SplitM1.SplitterColor = System.Drawing.Color.Black
        Me.SplitM1.SplitterWidth = 1
        Me.SplitM1.TabIndex = 0
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitM1.UseParentVisualStyle = False
        '
        'SplitM1P1
        '
        Me.SplitM1P1.Controls.Add(Me.SplitM3)
        Me.SplitM1P1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.SplitM1P1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitM1P1.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center
        Me.SplitM1P1.Height = 701
        Me.SplitM1P1.Location = New System.Drawing.Point(1, 22)
        Me.SplitM1P1.Name = "SplitM1P1"
        Me.SplitM1P1.Size = New System.Drawing.Size(598, 680)
        Me.SplitM1P1.SizeRatio = 52.008R
        Me.SplitM1P1.TabIndex = 0
        Me.SplitM1P1.Text = "Su orden"
        Me.SplitM1P1.Width = 598
        '
        'SplitM3
        '
        Me.SplitM3.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM3.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM3.FixedLineColor = System.Drawing.Color.Black
        Me.SplitM3.Location = New System.Drawing.Point(0, 0)
        Me.SplitM3.Name = "SplitM3"
        Me.SplitM3.Panels.Add(Me.SplitM3P1)
        Me.SplitM3.Panels.Add(Me.SplitM3P2)
        Me.SplitM3.Panels.Add(Me.SplitM3P3)
        Me.SplitM3.Panels.Add(Me.SplitM3P4)
        Me.SplitM3.Size = New System.Drawing.Size(598, 680)
        Me.SplitM3.SplitterColor = System.Drawing.Color.Black
        Me.SplitM3.SplitterWidth = 1
        Me.SplitM3.TabIndex = 0
        Me.SplitM3.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitM3.UseParentVisualStyle = False
        '
        'SplitM3P1
        '
        Me.SplitM3P1.BorderColor = System.Drawing.Color.White
        Me.SplitM3P1.Controls.Add(Me.TARTICULO)
        Me.SplitM3P1.Height = 27
        Me.SplitM3P1.Location = New System.Drawing.Point(0, 0)
        Me.SplitM3P1.Name = "SplitM3P1"
        Me.SplitM3P1.Size = New System.Drawing.Size(598, 27)
        Me.SplitM3P1.SizeRatio = 4.0R
        Me.SplitM3P1.TabIndex = 0
        '
        'TARTICULO
        '
        Me.TARTICULO.AcceptsEscape = False
        Me.TARTICULO.AutoSize = False
        Me.TARTICULO.BackColor = System.Drawing.Color.White
        Me.TARTICULO.BorderColor = System.Drawing.Color.Blue
        Me.TARTICULO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TARTICULO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TARTICULO.ForeColor = System.Drawing.Color.Black
        Me.TARTICULO.Location = New System.Drawing.Point(11, 3)
        Me.TARTICULO.MaxLength = 20
        Me.TARTICULO.Name = "TARTICULO"
        Me.TARTICULO.NumericInput = False
        Me.TARTICULO.Size = New System.Drawing.Size(234, 24)
        Me.TARTICULO.TabIndex = 1
        Me.TARTICULO.Tag = Nothing
        Me.TARTICULO.WordWrap = False
        '
        'SplitM3P2
        '
        Me.SplitM3P2.Controls.Add(Me.TXTN)
        Me.SplitM3P2.Controls.Add(Me.Fg)
        Me.SplitM3P2.Height = 540
        Me.SplitM3P2.Location = New System.Drawing.Point(0, 28)
        Me.SplitM3P2.Name = "SplitM3P2"
        Me.SplitM3P2.Size = New System.Drawing.Size(598, 540)
        Me.SplitM3P2.SizeRatio = 82.911R
        Me.SplitM3P2.TabIndex = 0
        '
        'TXTN
        '
        Me.TXTN.CustomFormat = "###,###,##0.000"
        Me.TXTN.GapHeight = 0
        Me.TXTN.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TXTN.Location = New System.Drawing.Point(461, 427)
        Me.TXTN.Name = "TXTN"
        Me.TXTN.Size = New System.Drawing.Size(76, 24)
        Me.TXTN.TabIndex = 10
        Me.TXTN.Tag = Nothing
        Me.TXTN.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        Me.TXTN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg.AutoGenerateColumns = False
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.Fg.Location = New System.Drawing.Point(11, 21)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 300
        Me.Fg.Rows.DefaultSize = 24
        Me.Fg.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.Both
        Me.Fg.Size = New System.Drawing.Size(575, 358)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 9
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'SplitM3P3
        '
        Me.SplitM3P3.BorderWidth = 1
        Me.SplitM3P3.Controls.Add(Me.LtMonto)
        Me.SplitM3P3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitM3P3.Height = 70
        Me.SplitM3P3.Location = New System.Drawing.Point(1, 570)
        Me.SplitM3P3.Name = "SplitM3P3"
        Me.SplitM3P3.Size = New System.Drawing.Size(596, 68)
        Me.SplitM3P3.SizeRatio = 63.636R
        Me.SplitM3P3.TabIndex = 2
        '
        'LtMonto
        '
        Me.LtMonto.BackColor = System.Drawing.Color.Gold
        Me.LtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMonto.ForeColor = System.Drawing.Color.Black
        Me.LtMonto.Location = New System.Drawing.Point(11, 7)
        Me.LtMonto.Name = "LtMonto"
        Me.LtMonto.Size = New System.Drawing.Size(337, 41)
        Me.LtMonto.TabIndex = 0
        Me.LtMonto.Tag = Nothing
        Me.LtMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LtMonto.Value = "0.00"
        '
        'SplitM3P4
        '
        Me.SplitM3P4.Height = 40
        Me.SplitM3P4.Location = New System.Drawing.Point(0, 640)
        Me.SplitM3P4.Name = "SplitM3P4"
        Me.SplitM3P4.Size = New System.Drawing.Size(598, 40)
        Me.SplitM3P4.TabIndex = 3
        '
        'SplitM1P2
        '
        Me.SplitM1P2.Collapsible = True
        Me.SplitM1P2.Controls.Add(Me.BtnClienteDatos)
        Me.SplitM1P2.Controls.Add(Me.BtnCliente)
        Me.SplitM1P2.Controls.Add(Me.LtNombre)
        Me.SplitM1P2.Controls.Add(Me.TCLIENTE)
        Me.SplitM1P2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitM1P2.ForeColor = System.Drawing.Color.Black
        Me.SplitM1P2.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center
        Me.SplitM1P2.Height = 60
        Me.SplitM1P2.Location = New System.Drawing.Point(600, 22)
        Me.SplitM1P2.Name = "SplitM1P2"
        Me.SplitM1P2.Size = New System.Drawing.Size(552, 32)
        Me.SplitM1P2.SizeRatio = 8.571R
        Me.SplitM1P2.TabIndex = 1
        Me.SplitM1P2.Text = "Cliente"
        '
        'BtnClienteDatos
        '
        Me.BtnClienteDatos.BackColor = System.Drawing.Color.Black
        Me.BtnClienteDatos.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnClienteDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClienteDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClienteDatos.ForeColor = System.Drawing.Color.White
        Me.BtnClienteDatos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClienteDatos.Location = New System.Drawing.Point(3, 2)
        Me.BtnClienteDatos.Name = "BtnClienteDatos"
        Me.BtnClienteDatos.Size = New System.Drawing.Size(71, 25)
        Me.BtnClienteDatos.TabIndex = 195
        Me.BtnClienteDatos.Text = "Cliente"
        Me.BtnClienteDatos.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClienteDatos.UseVisualStyleBackColor = False
        '
        'LtNombre
        '
        Me.LtNombre.AutoSize = True
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(203, 6)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(104, 17)
        Me.LtNombre.TabIndex = 3
        Me.LtNombre.Text = "____________"
        '
        'TCLIENTE
        '
        Me.TCLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE.Location = New System.Drawing.Point(77, 3)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(91, 23)
        Me.TCLIENTE.TabIndex = 2
        '
        'SplitM1P3
        '
        Me.SplitM1P3.Controls.Add(Me.SplitM2)
        Me.SplitM1P3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.SplitM1P3.Location = New System.Drawing.Point(600, 62)
        Me.SplitM1P3.Name = "SplitM1P3"
        Me.SplitM1P3.Size = New System.Drawing.Size(552, 640)
        Me.SplitM1P3.TabIndex = 2
        Me.SplitM1P3.Width = 552
        '
        'SplitM2
        '
        Me.SplitM2.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM2.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM2.FixedLineColor = System.Drawing.Color.Black
        Me.SplitM2.Location = New System.Drawing.Point(0, 0)
        Me.SplitM2.Name = "SplitM2"
        Me.SplitM2.Panels.Add(Me.SplitM2P1)
        Me.SplitM2.Panels.Add(Me.C1SplitterPanel1)
        Me.SplitM2.Size = New System.Drawing.Size(552, 640)
        Me.SplitM2.SplitterColor = System.Drawing.Color.Black
        Me.SplitM2.SplitterWidth = 1
        Me.SplitM2.TabIndex = 0
        Me.SplitM2.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitM2.UseParentVisualStyle = False
        '
        'SplitM2P1
        '
        Me.SplitM2P1.Controls.Add(Me.PicFoto)
        Me.SplitM2P1.Controls.Add(Me.Pic)
        Me.SplitM2P1.Height = 482
        Me.SplitM2P1.Location = New System.Drawing.Point(0, 0)
        Me.SplitM2P1.Name = "SplitM2P1"
        Me.SplitM2P1.Size = New System.Drawing.Size(552, 482)
        Me.SplitM2P1.SizeRatio = 75.466R
        Me.SplitM2P1.TabIndex = 0
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.LtArticulo)
        Me.C1SplitterPanel1.Controls.Add(Me.LtPrecioXProducto)
        Me.C1SplitterPanel1.Controls.Add(Me.LtTotalArt)
        Me.C1SplitterPanel1.Controls.Add(Me.BtnCobrar)
        Me.C1SplitterPanel1.ForeColor = System.Drawing.Color.Black
        Me.C1SplitterPanel1.Height = 157
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 483)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(552, 157)
        Me.C1SplitterPanel1.SizeRatio = 30.0R
        Me.C1SplitterPanel1.TabIndex = 1
        '
        'LtArticulo
        '
        Me.LtArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtArticulo.BackColor = System.Drawing.Color.White
        Me.LtArticulo.BorderColor = System.Drawing.Color.Black
        Me.LtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtArticulo.ForeColor = System.Drawing.Color.Black
        Me.LtArticulo.Location = New System.Drawing.Point(0, 41)
        Me.LtArticulo.Name = "LtArticulo"
        Me.LtArticulo.Size = New System.Drawing.Size(539, 41)
        Me.LtArticulo.TabIndex = 2
        Me.LtArticulo.Tag = Nothing
        Me.LtArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LtArticulo.TextDetached = True
        Me.LtArticulo.Value = "0.00"
        '
        'LtPrecioXProducto
        '
        Me.LtPrecioXProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtPrecioXProducto.BackColor = System.Drawing.Color.White
        Me.LtPrecioXProducto.BorderColor = System.Drawing.Color.Black
        Me.LtPrecioXProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPrecioXProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPrecioXProducto.ForeColor = System.Drawing.Color.Black
        Me.LtPrecioXProducto.Location = New System.Drawing.Point(0, 0)
        Me.LtPrecioXProducto.Name = "LtPrecioXProducto"
        Me.LtPrecioXProducto.Size = New System.Drawing.Size(539, 41)
        Me.LtPrecioXProducto.TabIndex = 1
        Me.LtPrecioXProducto.Tag = Nothing
        Me.LtPrecioXProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LtPrecioXProducto.TextDetached = True
        Me.LtPrecioXProducto.Value = "0.00"
        '
        'LtTotalArt
        '
        Me.LtTotalArt.AutoSize = True
        Me.LtTotalArt.BackColor = System.Drawing.Color.White
        Me.LtTotalArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotalArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotalArt.ForeColor = System.Drawing.Color.Black
        Me.LtTotalArt.Location = New System.Drawing.Point(232, 48)
        Me.LtTotalArt.Name = "LtTotalArt"
        Me.LtTotalArt.Size = New System.Drawing.Size(2, 22)
        Me.LtTotalArt.TabIndex = 1
        Me.LtTotalArt.Tag = Nothing
        Me.LtTotalArt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LtTotalArt.TextDetached = True
        Me.LtTotalArt.Value = "0.00"
        '
        'BtnCliente
        '
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnCliente.Location = New System.Drawing.Point(170, 2)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(25, 25)
        Me.BtnCliente.TabIndex = 194
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'PicFoto
        '
        Me.PicFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFoto.InitialImage = CType(resources.GetObject("PicFoto.InitialImage"), System.Drawing.Image)
        Me.PicFoto.Location = New System.Drawing.Point(360, 43)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(101, 95)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFoto.TabIndex = 249
        Me.PicFoto.TabStop = False
        Me.PicFoto.Visible = False
        '
        'Pic
        '
        Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic.Location = New System.Drawing.Point(41, 43)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(313, 259)
        Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic.TabIndex = 248
        Me.Pic.TabStop = False
        '
        'BtnCobrar
        '
        Me.BtnCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCobrar.Image = Global.SGT_Transport.My.Resources.Resources.pago2
        Me.BtnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCobrar.Location = New System.Drawing.Point(5, 90)
        Me.BtnCobrar.Name = "BtnCobrar"
        Me.BtnCobrar.Size = New System.Drawing.Size(138, 56)
        Me.BtnCobrar.TabIndex = 1
        Me.BtnCobrar.Text = "F3 - Cobrar"
        Me.BtnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCobrar.UseVisualStyleBackColor = True
        Me.BtnCobrar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "888aadd8594245f7b3e4751d9213ca50"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 703)
        Me.Controls.Add(Me.SplitM1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPOS"
        Me.Text = "Punto de venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.SplitM1P1.ResumeLayout(False)
        CType(Me.SplitM3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM3.ResumeLayout(False)
        Me.SplitM3P1.ResumeLayout(False)
        CType(Me.TARTICULO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM3P2.ResumeLayout(False)
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM3P3.ResumeLayout(False)
        CType(Me.LtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1P2.ResumeLayout(False)
        Me.SplitM1P2.PerformLayout()
        CType(Me.BtnClienteDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1P3.ResumeLayout(False)
        CType(Me.SplitM2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM2.ResumeLayout(False)
        Me.SplitM2P1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.C1SplitterPanel1.PerformLayout()
        CType(Me.LtArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtPrecioXProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtTotalArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCobrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM1P1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM1P2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM1P3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM2 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM2P1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM3 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM3P1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM3P2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM3P3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents PicFoto As PictureBox
    Friend WithEvents Pic As PictureBox
    Friend WithEvents BtnCobrar As C1.Win.C1Input.C1Button
    Friend WithEvents SplitM3P4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents TARTICULO As C1.Win.C1Input.C1TextBox
    Friend WithEvents LtMonto As C1.Win.C1Input.C1Label
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LtNombre As Label
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents BtnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents TXTN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents LtTotalArt As C1.Win.C1Input.C1Label
    Friend WithEvents LtPrecioXProducto As C1.Win.C1Input.C1Label
    Friend WithEvents BtnClienteDatos As C1.Win.C1Input.C1Button
    Friend WithEvents LtArticulo As C1.Win.C1Input.C1Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
End Class
