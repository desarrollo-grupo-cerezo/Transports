﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEdoCuentaProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEdoCuentaProv))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.chSaldo = New C1.Win.C1Input.C1CheckBox()
        Me.SplitMain = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnFiltro = New C1.Win.C1Input.C1Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.LtClave = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtSaldo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CLIENTE = New System.Data.DataColumn()
        Me.NOMBRE = New System.Data.DataColumn()
        Me.CALLE = New System.Data.DataColumn()
        Me.RFC = New System.Data.DataColumn()
        Me.CLASIFICACION = New System.Data.DataColumn()
        Me.DIAS_CREDITO = New System.Data.DataColumn()
        Me.LIMITE_CREDITO = New System.Data.DataColumn()
        Me.SALDO_GEN = New System.Data.DataColumn()
        Me.CLAVE = New System.Data.DataColumn()
        Me.CVE_DOC = New System.Data.DataColumn()
        Me.NUM = New System.Data.DataColumn()
        Me.FECHA_APLI = New System.Data.DataColumn()
        Me.FECHA_VENC = New System.Data.DataColumn()
        Me.CARGOS = New System.Data.DataColumn()
        Me.ABONOS = New System.Data.DataColumn()
        Me.SALDO = New System.Data.DataColumn()
        Me.CP = New System.Data.DataColumn()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.SU_REFER = New System.Data.DataColumn()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMain.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        Me.Split3.SuspendLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarEliminar)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Owner = Me
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar1
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutText = ""
        Me.BarEliminar.Text = "BarEliminar pago"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
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
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutText = ""
        Me.BarActualizar.Text = "Actualizar"
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
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkEliminar, Me.LkActualizar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1096, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkEliminar
        '
        Me.LkEliminar.Command = Me.BarEliminar
        Me.LkEliminar.SortOrder = 1
        Me.LkEliminar.Text = "Eliminar pago"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.SortOrder = 2
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 3
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1033, 326)
        Me.Fg.TabIndex = 309
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'chSaldo
        '
        Me.chSaldo.BackColor = System.Drawing.Color.Transparent
        Me.chSaldo.BorderColor = System.Drawing.Color.Transparent
        Me.chSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chSaldo.ForeColor = System.Drawing.Color.Black
        Me.chSaldo.Location = New System.Drawing.Point(190, 56)
        Me.chSaldo.Name = "chSaldo"
        Me.chSaldo.Padding = New System.Windows.Forms.Padding(1)
        Me.chSaldo.Size = New System.Drawing.Size(104, 24)
        Me.chSaldo.TabIndex = 311
        Me.chSaldo.Text = "Saldo vencido"
        Me.chSaldo.UseVisualStyleBackColor = True
        Me.chSaldo.Value = Nothing
        Me.chSaldo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitMain
        '
        Me.SplitMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitMain.BorderWidth = 1
        Me.SplitMain.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitMain.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitMain.Location = New System.Drawing.Point(0, 43)
        Me.SplitMain.Name = "SplitMain"
        Me.SplitMain.Panels.Add(Me.Split1)
        Me.SplitMain.Panels.Add(Me.Split2)
        Me.SplitMain.Panels.Add(Me.Split3)
        Me.SplitMain.Size = New System.Drawing.Size(1035, 457)
        Me.SplitMain.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitMain.TabIndex = 313
        Me.SplitMain.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitMain.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.BtnFiltro)
        Me.Split1.Controls.Add(Me.Label3)
        Me.Split1.Controls.Add(Me.Label4)
        Me.Split1.Controls.Add(Me.F2)
        Me.Split1.Controls.Add(Me.Label6)
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.LtClave)
        Me.Split1.Controls.Add(Me.Label2)
        Me.Split1.Controls.Add(Me.LtNombre)
        Me.Split1.Controls.Add(Me.Label5)
        Me.Split1.Controls.Add(Me.chSaldo)
        Me.Split1.Controls.Add(Me.LtSaldo)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Height = 81
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1033, 81)
        Me.Split1.SizeRatio = 17.984R
        Me.Split1.TabIndex = 0
        '
        'BtnFiltro
        '
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltro.Location = New System.Drawing.Point(838, 45)
        Me.BtnFiltro.Name = "BtnFiltro"
        Me.BtnFiltro.Size = New System.Drawing.Size(78, 30)
        Me.BtnFiltro.TabIndex = 382
        Me.BtnFiltro.Text = "Filtrar"
        Me.BtnFiltro.UseVisualStyleBackColor = True
        Me.BtnFiltro.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(622, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 381
        Me.Label3.Text = "Rango de fechas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(672, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 16)
        Me.Label4.TabIndex = 380
        Me.Label4.Text = "al"
        '
        'F2
        '
        Me.F2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(698, 54)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 378
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(509, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 379
        Me.Label6.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(543, 54)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 377
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtClave
        '
        Me.LtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtClave.Location = New System.Drawing.Point(54, 21)
        Me.LtClave.Name = "LtClave"
        Me.LtClave.Size = New System.Drawing.Size(52, 20)
        Me.LtClave.TabIndex = 320
        Me.LtClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(113, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 319
        Me.Label2.Text = "Nombre"
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(176, 21)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(321, 20)
        Me.LtNombre.TabIndex = 318
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 317
        Me.Label5.Text = "Clave"
        '
        'LtSaldo
        '
        Me.LtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldo.Location = New System.Drawing.Point(357, 57)
        Me.LtSaldo.Name = "LtSaldo"
        Me.LtSaldo.Size = New System.Drawing.Size(139, 20)
        Me.LtSaldo.TabIndex = 316
        Me.LtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 315
        Me.Label1.Text = "Saldo"
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 326
        Me.Split2.Location = New System.Drawing.Point(1, 86)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1033, 326)
        Me.Split2.SizeRatio = 89.071R
        Me.Split2.TabIndex = 1
        '
        'Split3
        '
        Me.Split3.Controls.Add(Me.Lt2)
        Me.Split3.Controls.Add(Me.Lt1)
        Me.Split3.Controls.Add(Me.Lt3)
        Me.Split3.Height = 40
        Me.Split3.Location = New System.Drawing.Point(1, 416)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1033, 40)
        Me.Split3.TabIndex = 2
        '
        'Lt2
        '
        Me.Lt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(590, 11)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(104, 20)
        Me.Lt2.TabIndex = 323
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt1
        '
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(487, 11)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(104, 20)
        Me.Lt1.TabIndex = 322
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt3
        '
        Me.Lt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.Location = New System.Drawing.Point(693, 11)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(104, 20)
        Me.Lt3.TabIndex = 321
        Me.Lt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "5201e7a40e864825932dc29c15f17156"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "EdoCuenProv"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CLIENTE, Me.NOMBRE, Me.CALLE, Me.RFC, Me.CLASIFICACION, Me.DIAS_CREDITO, Me.LIMITE_CREDITO, Me.SALDO_GEN, Me.CLAVE, Me.CVE_DOC, Me.NUM, Me.FECHA_APLI, Me.FECHA_VENC, Me.CARGOS, Me.ABONOS, Me.SALDO, Me.CP, Me.SU_REFER})
        Me.DataTable1.TableName = "Table1"
        '
        'CLIENTE
        '
        Me.CLIENTE.AllowDBNull = False
        Me.CLIENTE.ColumnName = "CLIENTE"
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        '
        'CALLE
        '
        Me.CALLE.ColumnName = "CALLE"
        '
        'RFC
        '
        Me.RFC.ColumnName = "RFC"
        Me.RFC.DefaultValue = ""
        '
        'CLASIFICACION
        '
        Me.CLASIFICACION.ColumnName = "CLASIFICACION"
        '
        'DIAS_CREDITO
        '
        Me.DIAS_CREDITO.ColumnName = "DIAS_CREDITO"
        Me.DIAS_CREDITO.DataType = GetType(Short)
        '
        'LIMITE_CREDITO
        '
        Me.LIMITE_CREDITO.ColumnName = "LIMITE_CREDITO"
        Me.LIMITE_CREDITO.DataType = GetType(Decimal)
        '
        'SALDO_GEN
        '
        Me.SALDO_GEN.ColumnName = "SALDO_GEN"
        Me.SALDO_GEN.DataType = GetType(Decimal)
        '
        'CLAVE
        '
        Me.CLAVE.ColumnName = "CLAVE"
        '
        'CVE_DOC
        '
        Me.CVE_DOC.ColumnName = "CVE_DOC"
        '
        'NUM
        '
        Me.NUM.ColumnName = "NUM"
        Me.NUM.DataType = GetType(Short)
        '
        'FECHA_APLI
        '
        Me.FECHA_APLI.ColumnName = "FECHA_APLI"
        Me.FECHA_APLI.DataType = GetType(Date)
        '
        'FECHA_VENC
        '
        Me.FECHA_VENC.ColumnName = "FECHA_VENC"
        Me.FECHA_VENC.DataType = GetType(Date)
        '
        'CARGOS
        '
        Me.CARGOS.ColumnName = "CARGOS"
        Me.CARGOS.DataType = GetType(Decimal)
        '
        'ABONOS
        '
        Me.ABONOS.ColumnName = "ABONOS"
        Me.ABONOS.DataType = GetType(Decimal)
        '
        'SALDO
        '
        Me.SALDO.ColumnName = "SALDO"
        Me.SALDO.DataType = GetType(Decimal)
        '
        'CP
        '
        Me.CP.ColumnName = "CP"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(675, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(231, 38)
        Me.C1FlexGridSearchPanel1.TabIndex = 383
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'SU_REFER
        '
        Me.SU_REFER.ColumnName = "SU_REFER"
        '
        'FrmEdoCuentaProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 552)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.SplitMain)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEdoCuentaProv"
        Me.ShowInTaskbar = False
        Me.Text = "Estado de cuenta proveedor"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMain.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        Me.Split3.ResumeLayout(False)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents chSaldo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents SplitMain As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LtSaldo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtClave As Label
    Friend WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents CLIENTE As DataColumn
    Friend WithEvents NOMBRE As DataColumn
    Friend WithEvents CALLE As DataColumn
    Friend WithEvents RFC As DataColumn
    Friend WithEvents CLASIFICACION As DataColumn
    Friend WithEvents DIAS_CREDITO As DataColumn
    Friend WithEvents LIMITE_CREDITO As DataColumn
    Friend WithEvents SALDO_GEN As DataColumn
    Friend WithEvents CLAVE As DataColumn
    Friend WithEvents CVE_DOC As DataColumn
    Friend WithEvents NUM As DataColumn
    Friend WithEvents FECHA_APLI As DataColumn
    Friend WithEvents FECHA_VENC As DataColumn
    Friend WithEvents CARGOS As DataColumn
    Friend WithEvents ABONOS As DataColumn
    Friend WithEvents SALDO As DataColumn
    Friend WithEvents CP As DataColumn
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt3 As Label
    Friend WithEvents BtnFiltro As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents SU_REFER As DataColumn
End Class
