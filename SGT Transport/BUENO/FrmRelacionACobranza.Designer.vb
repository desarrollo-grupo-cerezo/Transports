<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRelacionACobranza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRelacionACobranza))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarDisenador = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.F4 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F3 = New C1.Win.Calendar.C1DateEdit()
        Me.TGUIA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnCliente = New C1.Win.C1Input.C1Button()
        Me.TCVE_REL = New System.Windows.Forms.TextBox()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.SplitM2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.SplitM1.SuspendLayout()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM2.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarDisenador)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutText = ""
        Me.BarDisenador.Text = "Diseñador"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.C1CommandLink1, Me.LkImprimir, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1019, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.BarExcel
        Me.C1CommandLink1.Delimiter = True
        Me.C1CommandLink1.SortOrder = 1
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 2
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDisenador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 3
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(1, 48)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.SplitM1)
        Me.SplitM.Panels.Add(Me.SplitM2)
        Me.SplitM.Size = New System.Drawing.Size(993, 431)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.TabIndex = 2
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitM1
        '
        Me.SplitM1.Controls.Add(Me.Label3)
        Me.SplitM1.Controls.Add(Me.F4)
        Me.SplitM1.Controls.Add(Me.Label2)
        Me.SplitM1.Controls.Add(Me.F3)
        Me.SplitM1.Controls.Add(Me.TGUIA)
        Me.SplitM1.Controls.Add(Me.Label1)
        Me.SplitM1.Controls.Add(Me.LtNombre)
        Me.SplitM1.Controls.Add(Me.TCLIENTE)
        Me.SplitM1.Controls.Add(Me.Label41)
        Me.SplitM1.Controls.Add(Me.BtnCliente)
        Me.SplitM1.Controls.Add(Me.TCVE_REL)
        Me.SplitM1.Controls.Add(Me.LtUnidad)
        Me.SplitM1.Controls.Add(Me.L1)
        Me.SplitM1.Controls.Add(Me.LtAl)
        Me.SplitM1.Controls.Add(Me.F2)
        Me.SplitM1.Controls.Add(Me.LtDel)
        Me.SplitM1.Controls.Add(Me.F1)
        Me.SplitM1.Height = 148
        Me.SplitM1.Location = New System.Drawing.Point(1, 1)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Size = New System.Drawing.Size(991, 148)
        Me.SplitM1.SizeRatio = 34.824R
        Me.SplitM1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(411, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 16)
        Me.Label3.TabIndex = 434
        Me.Label3.Text = "Fecha de modificación"
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
        Me.F4.Location = New System.Drawing.Point(558, 98)
        Me.F4.Name = "F4"
        Me.F4.Size = New System.Drawing.Size(105, 20)
        Me.F4.TabIndex = 433
        Me.F4.Tag = Nothing
        Me.F4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F4.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(446, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Fecha recepción"
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
        Me.F3.Location = New System.Drawing.Point(558, 72)
        Me.F3.Name = "F3"
        Me.F3.Size = New System.Drawing.Size(105, 20)
        Me.F3.TabIndex = 5
        Me.F3.Tag = Nothing
        Me.F3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F3.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TGUIA
        '
        Me.TGUIA.AcceptsReturn = True
        Me.TGUIA.AcceptsTab = True
        Me.TGUIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TGUIA.ForeColor = System.Drawing.Color.Black
        Me.TGUIA.Location = New System.Drawing.Point(112, 41)
        Me.TGUIA.MaxLength = 80
        Me.TGUIA.Name = "TGUIA"
        Me.TGUIA.Size = New System.Drawing.Size(310, 22)
        Me.TGUIA.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(73, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Guia"
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(306, 12)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(284, 22)
        Me.LtNombre.TabIndex = 426
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.ForeColor = System.Drawing.Color.Black
        Me.TCLIENTE.Location = New System.Drawing.Point(227, 12)
        Me.TCLIENTE.MaxLength = 10
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(51, 22)
        Me.TCLIENTE.TabIndex = 1
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(173, 15)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 16)
        Me.Label41.TabIndex = 427
        Me.Label41.Text = "Cliente"
        '
        'BtnCliente
        '
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.Image = CType(resources.GetObject("BtnCliente.Image"), System.Drawing.Image)
        Me.BtnCliente.Location = New System.Drawing.Point(279, 12)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(26, 22)
        Me.BtnCliente.TabIndex = 428
        Me.BtnCliente.UseVisualStyleBackColor = True
        Me.BtnCliente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_REL
        '
        Me.TCVE_REL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_REL.Location = New System.Drawing.Point(112, 12)
        Me.TCVE_REL.Name = "TCVE_REL"
        Me.TCVE_REL.Size = New System.Drawing.Size(50, 22)
        Me.TCVE_REL.TabIndex = 0
        '
        'LtUnidad
        '
        Me.LtUnidad.AutoSize = True
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(19, 14)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(89, 16)
        Me.LtUnidad.TabIndex = 388
        Me.LtUnidad.Text = "Núm. relación"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(3, 105)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(157, 16)
        Me.L1.TabIndex = 387
        Me.L1.Text = "Facturas en esta relación"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(234, 72)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(81, 16)
        Me.LtAl.TabIndex = 386
        Me.LtAl.Text = "Fecha envio"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(317, 70)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(105, 20)
        Me.F2.TabIndex = 4
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(63, 72)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(45, 16)
        Me.LtDel.TabIndex = 385
        Me.LtDel.Text = "Fecha"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(112, 70)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(105, 20)
        Me.F1.TabIndex = 3
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitM2
        '
        Me.SplitM2.Controls.Add(Me.Fg)
        Me.SplitM2.Height = 277
        Me.SplitM2.Location = New System.Drawing.Point(1, 153)
        Me.SplitM2.Name = "SplitM2"
        Me.SplitM2.Size = New System.Drawing.Size(991, 277)
        Me.SplitM2.TabIndex = 1
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(3, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(974, 173)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 16
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "ba5452e5851e4ff3bb34482585b24c5f"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmRelacionACobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 491)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRelacionACobranza"
        Me.ShowInTaskbar = False
        Me.Text = "Relación de cobranza"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.SplitM1.ResumeLayout(False)
        Me.SplitM1.PerformLayout()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM2.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitM2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents TCVE_REL As TextBox
    Friend WithEvents LtUnidad As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TGUIA As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F3 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents F4 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarDisenador As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
End Class
