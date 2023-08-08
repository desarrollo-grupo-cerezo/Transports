<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeguimientoViajes
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeguimientoViajes))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM1P1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitM2 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM2P1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.SplitM2P2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitM1P2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1ToolBar2 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar2 = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir2 = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel2 = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador2 = New C1.Win.C1Command.C1CommandLink()
        Me.LKSalir2 = New C1.Win.C1Command.C1CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F4 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.F3 = New C1.Win.Calendar.C1DateEdit()
        Me.SplitM1P3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BtnFlecha2 = New C1.Win.C1Input.C1Button()
        Me.BtnFlecha1 = New C1.Win.C1Input.C1Button()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarDesplegar2 = New C1.Win.C1Command.C1Command()
        Me.BarImprimir2 = New C1.Win.C1Command.C1Command()
        Me.BarExcel2 = New C1.Win.C1Command.C1Command()
        Me.BarDiseñador2 = New C1.Win.C1Command.C1Command()
        Me.BarSalir2 = New C1.Win.C1Command.C1Command()
        Me.BtnFlecha4 = New C1.Win.C1Input.C1Button()
        Me.BtnFlecha3 = New C1.Win.C1Input.C1Button()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.SplitM1P1.SuspendLayout()
        CType(Me.SplitM2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM2.SuspendLayout()
        Me.SplitM2P1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM2P2.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1P2.SuspendLayout()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1P3.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFlecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFlecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFlecha4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFlecha3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarDesplegar2)
        Me.MenuHolder.Commands.Add(Me.BarImprimir2)
        Me.MenuHolder.Commands.Add(Me.BarExcel2)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador2)
        Me.MenuHolder.Commands.Add(Me.BarSalir2)
        Me.MenuHolder.Owner = Me
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
        Me.C1ToolBar1.ButtonWidth = 60
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkNuevo, Me.LkExcel, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 20
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(510, 40)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.BarImprimir
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.SortOrder = 1
        Me.LkNuevo.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 2
        Me.LkExcel.Text = "Excel"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDiseñador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 3
        Me.LkDisenador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 12)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.SplitM1P1)
        Me.SplitM1.Panels.Add(Me.SplitM1P2)
        Me.SplitM1.Panels.Add(Me.SplitM1P3)
        Me.SplitM1.Size = New System.Drawing.Size(1029, 452)
        Me.SplitM1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.TabIndex = 2
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitM1P1
        '
        Me.SplitM1P1.Controls.Add(Me.SplitM2)
        Me.SplitM1P1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.SplitM1P1.Location = New System.Drawing.Point(1, 1)
        Me.SplitM1P1.Name = "SplitM1P1"
        Me.SplitM1P1.Size = New System.Drawing.Size(512, 450)
        Me.SplitM1P1.TabIndex = 0
        Me.SplitM1P1.Width = 512
        '
        'SplitM2
        '
        Me.SplitM2.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM2.BorderWidth = 1
        Me.SplitM2.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM2.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM2.Location = New System.Drawing.Point(0, 0)
        Me.SplitM2.Name = "SplitM2"
        Me.SplitM2.Panels.Add(Me.SplitM2P1)
        Me.SplitM2.Panels.Add(Me.SplitM2P2)
        Me.SplitM2.Size = New System.Drawing.Size(512, 450)
        Me.SplitM2.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM2.TabIndex = 0
        Me.SplitM2.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitM2P1
        '
        Me.SplitM2P1.Controls.Add(Me.BtnFlecha2)
        Me.SplitM2P1.Controls.Add(Me.BtnFlecha1)
        Me.SplitM2P1.Controls.Add(Me.L1)
        Me.SplitM2P1.Controls.Add(Me.C1ToolBar1)
        Me.SplitM2P1.Controls.Add(Me.LtAl)
        Me.SplitM2P1.Controls.Add(Me.F2)
        Me.SplitM2P1.Controls.Add(Me.LtDel)
        Me.SplitM2P1.Controls.Add(Me.F1)
        Me.SplitM2P1.Height = 121
        Me.SplitM2P1.Location = New System.Drawing.Point(1, 1)
        Me.SplitM2P1.Name = "SplitM2P1"
        Me.SplitM2P1.Size = New System.Drawing.Size(510, 121)
        Me.SplitM2P1.SizeRatio = 27.252R
        Me.SplitM2P1.TabIndex = 0
        '
        'L1
        '
        Me.L1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(188, 58)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 361
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(234, 79)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 360
        Me.LtAl.Text = "al"
        '
        'F2
        '
        Me.F2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(273, 77)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 358
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(58, 79)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 359
        Me.LtDel.Text = "Del"
        '
        'F1
        '
        Me.F1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(91, 77)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 357
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitM2P2
        '
        Me.SplitM2P2.Controls.Add(Me.Fg)
        Me.SplitM2P2.Height = 323
        Me.SplitM2P2.Location = New System.Drawing.Point(1, 126)
        Me.SplitM2P2.Name = "SplitM2P2"
        Me.SplitM2P2.Size = New System.Drawing.Size(510, 323)
        Me.SplitM2P2.TabIndex = 1
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 6.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "6,1,0,0,0,95,Columns:1{Caption:""Unidad"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Caption:""Tanque"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Caption:""Operado" &
    "r"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Caption:""Origen"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Caption:""Cliente"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(25, 39)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(292, 199)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 24
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'SplitM1P2
        '
        Me.SplitM1P2.Controls.Add(Me.BtnFlecha4)
        Me.SplitM1P2.Controls.Add(Me.BtnFlecha3)
        Me.SplitM1P2.Controls.Add(Me.C1ToolBar2)
        Me.SplitM1P2.Controls.Add(Me.Label1)
        Me.SplitM1P2.Controls.Add(Me.Label2)
        Me.SplitM1P2.Controls.Add(Me.F4)
        Me.SplitM1P2.Controls.Add(Me.Label3)
        Me.SplitM1P2.Controls.Add(Me.F3)
        Me.SplitM1P2.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center
        Me.SplitM1P2.Height = 123
        Me.SplitM1P2.Location = New System.Drawing.Point(517, 1)
        Me.SplitM1P2.Name = "SplitM1P2"
        Me.SplitM1P2.Size = New System.Drawing.Size(511, 123)
        Me.SplitM1P2.SizeRatio = 27.578R
        Me.SplitM1P2.TabIndex = 1
        '
        'C1ToolBar2
        '
        Me.C1ToolBar2.AccessibleName = "Tool Bar"
        Me.C1ToolBar2.AutoSize = False
        Me.C1ToolBar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar2.BackImageInImageBar = True
        Me.C1ToolBar2.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar2.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar2.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar2.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar2.ButtonWidth = 60
        Me.C1ToolBar2.CommandHolder = Nothing
        Me.C1ToolBar2.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar2, Me.LkImprimir2, Me.LkExcel2, Me.LkDisenador2, Me.LKSalir2})
        Me.C1ToolBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar2.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar2.MinButtonSize = 20
        Me.C1ToolBar2.Movable = False
        Me.C1ToolBar2.Name = "C1ToolBar2"
        Me.C1ToolBar2.Size = New System.Drawing.Size(511, 40)
        Me.C1ToolBar2.Text = "C1ToolBar2"
        Me.C1ToolBar2.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar2
        '
        Me.LkDesplegar2.Command = Me.BarDesplegar2
        Me.LkDesplegar2.Delimiter = True
        Me.LkDesplegar2.Text = "Desplegar"
        '
        'LkImprimir2
        '
        Me.LkImprimir2.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir2.Command = Me.BarImprimir2
        Me.LkImprimir2.Delimiter = True
        Me.LkImprimir2.SortOrder = 1
        Me.LkImprimir2.Text = "Imprimir"
        '
        'LkExcel2
        '
        Me.LkExcel2.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkExcel2.Command = Me.BarExcel2
        Me.LkExcel2.Delimiter = True
        Me.LkExcel2.SortOrder = 2
        Me.LkExcel2.Text = "Excel"
        '
        'LkDisenador2
        '
        Me.LkDisenador2.Command = Me.BarDiseñador2
        Me.LkDisenador2.Delimiter = True
        Me.LkDisenador2.SortOrder = 3
        Me.LkDisenador2.Text = "Diseñador"
        '
        'LKSalir2
        '
        Me.LKSalir2.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LKSalir2.Command = Me.BarSalir2
        Me.LKSalir2.Delimiter = True
        Me.LKSalir2.SortOrder = 4
        Me.LKSalir2.ToolTipText = "SALIR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(239, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 361
        Me.Label1.Text = "Rango de fechas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(278, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 360
        Me.Label2.Text = "al"
        '
        'F4
        '
        Me.F4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F4.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F4.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F4.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F4.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F4.Location = New System.Drawing.Point(317, 76)
        Me.F4.Name = "F4"
        Me.F4.Size = New System.Drawing.Size(122, 20)
        Me.F4.TabIndex = 358
        Me.F4.Tag = Nothing
        Me.F4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F4.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Del"
        '
        'F3
        '
        Me.F3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F3.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F3.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F3.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F3.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F3.Location = New System.Drawing.Point(135, 76)
        Me.F3.Name = "F3"
        Me.F3.Size = New System.Drawing.Size(122, 20)
        Me.F3.TabIndex = 357
        Me.F3.Tag = Nothing
        Me.F3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F3.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitM1P3
        '
        Me.SplitM1P3.Controls.Add(Me.Fg2)
        Me.SplitM1P3.Height = 323
        Me.SplitM1P3.Location = New System.Drawing.Point(517, 128)
        Me.SplitM1P3.Name = "SplitM1P3"
        Me.SplitM1P3.Size = New System.Drawing.Size(511, 323)
        Me.SplitM1P3.TabIndex = 2
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.AutoClipboard = True
        Me.Fg2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg2.AutoSearchDelay = 6.0R
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg2.ColumnInfo = "6,1,0,0,0,95,Columns:1{Caption:""Unidad"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Caption:""Tanque"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Caption:""Operado" &
    "r"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Caption:""Origen"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Caption:""Cliente"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.Location = New System.Drawing.Point(29, 39)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 2
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(292, 220)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 25
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BtnFlecha2
        '
        Me.BtnFlecha2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFlecha2.AutoSize = True
        Me.BtnFlecha2.Image = Global.SGT_Transport.My.Resources.Resources.flecha17
        Me.BtnFlecha2.Location = New System.Drawing.Point(397, 74)
        Me.BtnFlecha2.Name = "BtnFlecha2"
        Me.BtnFlecha2.Size = New System.Drawing.Size(22, 23)
        Me.BtnFlecha2.TabIndex = 362
        Me.BtnFlecha2.UseVisualStyleBackColor = True
        Me.BtnFlecha2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BtnFlecha1
        '
        Me.BtnFlecha1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFlecha1.AutoSize = True
        Me.BtnFlecha1.Image = Global.SGT_Transport.My.Resources.Resources.flecha16
        Me.BtnFlecha1.Location = New System.Drawing.Point(34, 74)
        Me.BtnFlecha1.Name = "BtnFlecha1"
        Me.BtnFlecha1.Size = New System.Drawing.Size(22, 23)
        Me.BtnFlecha1.TabIndex = 171
        Me.BtnFlecha1.UseVisualStyleBackColor = True
        Me.BtnFlecha1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora61
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.ShowShortcut = False
        Me.BarExcel.ShowTextAsToolTip = False
        Me.BarExcel.Text = "Excel"
        '
        'BarDiseñador
        '
        Me.BarDiseñador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador.Name = "BarDiseñador"
        Me.BarDiseñador.ShortcutText = ""
        Me.BarDiseñador.Text = "Diseñador"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'BarDesplegar2
        '
        Me.BarDesplegar2.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar2.Name = "BarDesplegar2"
        Me.BarDesplegar2.ShortcutText = ""
        Me.BarDesplegar2.Text = "Desplegar"
        '
        'BarImprimir2
        '
        Me.BarImprimir2.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir2.Name = "BarImprimir2"
        Me.BarImprimir2.ShortcutText = ""
        Me.BarImprimir2.Text = "Imprimir"
        '
        'BarExcel2
        '
        Me.BarExcel2.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel2.Name = "BarExcel2"
        Me.BarExcel2.ShortcutText = ""
        Me.BarExcel2.Text = "Excel"
        '
        'BarDiseñador2
        '
        Me.BarDiseñador2.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador2.Name = "BarDiseñador2"
        Me.BarDiseñador2.ShortcutText = ""
        Me.BarDiseñador2.Text = "Diseñador"
        '
        'BarSalir2
        '
        Me.BarSalir2.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir2.Name = "BarSalir2"
        Me.BarSalir2.ShortcutText = ""
        Me.BarSalir2.Text = "Salir"
        '
        'BtnFlecha4
        '
        Me.BtnFlecha4.AutoSize = True
        Me.BtnFlecha4.Image = Global.SGT_Transport.My.Resources.Resources.flecha17
        Me.BtnFlecha4.Location = New System.Drawing.Point(440, 72)
        Me.BtnFlecha4.Name = "BtnFlecha4"
        Me.BtnFlecha4.Size = New System.Drawing.Size(22, 23)
        Me.BtnFlecha4.TabIndex = 365
        Me.BtnFlecha4.UseVisualStyleBackColor = True
        Me.BtnFlecha4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BtnFlecha3
        '
        Me.BtnFlecha3.AutoSize = True
        Me.BtnFlecha3.Image = Global.SGT_Transport.My.Resources.Resources.flecha16
        Me.BtnFlecha3.Location = New System.Drawing.Point(77, 72)
        Me.BtnFlecha3.Name = "BtnFlecha3"
        Me.BtnFlecha3.Size = New System.Drawing.Size(22, 23)
        Me.BtnFlecha3.TabIndex = 364
        Me.BtnFlecha3.UseVisualStyleBackColor = True
        Me.BtnFlecha3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "31320c5567ae426cbbe5fd03c0c610a8"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmSeguimientoViajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 486)
        Me.Controls.Add(Me.SplitM1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSeguimientoViajes"
        Me.Text = "FrmSeguimientoViajes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.SplitM1P1.ResumeLayout(False)
        CType(Me.SplitM2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM2.ResumeLayout(False)
        Me.SplitM2P1.ResumeLayout(False)
        Me.SplitM2P1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM2P2.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1P2.ResumeLayout(False)
        Me.SplitM1P2.PerformLayout()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1P3.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFlecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFlecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFlecha4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFlecha3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñador As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM1P1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitM1P2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM2 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM2P1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM2P2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM1P3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F4 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents F3 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1ToolBar2 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LKSalir2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDesplegar2 As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir2 As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel2 As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñador2 As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir2 As C1.Win.C1Command.C1Command
    Friend WithEvents BtnFlecha1 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnFlecha2 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnFlecha4 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnFlecha3 As C1.Win.C1Input.C1Button
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
End Class
