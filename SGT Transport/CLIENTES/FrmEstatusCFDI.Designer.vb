<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEstatusCFDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstatusCFDI))
        Me.MenuHolder2 = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LTRFC_RECEPTOR = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LTNOMBRE_EMISOR = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LRFC_EMISOR = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LTNOMBRE_RECEPTOR = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LT_PAC = New System.Windows.Forms.Label()
        Me.LTFECHA_CER = New System.Windows.Forms.Label()
        Me.LTFECHA_EXP = New System.Windows.Forms.Label()
        Me.LTFOLIO_FISCAL = New System.Windows.Forms.Label()
        Me.LTSTATUS_CANC = New System.Windows.Forms.Label()
        Me.LTESTADO_CFDI = New System.Windows.Forms.Label()
        Me.LTEFECTO_COMPROBANTE = New System.Windows.Forms.Label()
        Me.LTTOTAL_CFDI = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.RFC_EMISOR = New System.Data.DataColumn()
        Me.NOMBRE_EMISOR = New System.Data.DataColumn()
        Me.RFC_RECEPTOR = New System.Data.DataColumn()
        Me.NOMBRE_RECEPTOR = New System.Data.DataColumn()
        Me.UUID = New System.Data.DataColumn()
        Me.FECHA_EXP = New System.Data.DataColumn()
        Me.FRECHA_CER = New System.Data.DataColumn()
        Me.PAC_CER = New System.Data.DataColumn()
        Me.TOTAL_CFDI = New System.Data.DataColumn()
        Me.TIPO_COMPROBANTE = New System.Data.DataColumn()
        Me.ESTADO_CFDI = New System.Data.DataColumn()
        Me.STATUS_CANC = New System.Data.DataColumn()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder2
        '
        Me.MenuHolder2.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder2.Commands.Add(Me.BarImprimir)
        Me.MenuHolder2.Commands.Add(Me.BarSalir)
        Me.MenuHolder2.Owner = Me
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
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(801, 43)
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
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(144, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(483, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Verificación de comprobantes fiscales digitales por internet"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(399, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 16)
        Me.Label5.TabIndex = 588
        Me.Label5.Text = "Fecha de expedición"
        '
        'LTRFC_RECEPTOR
        '
        Me.LTRFC_RECEPTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTRFC_RECEPTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTRFC_RECEPTOR.Location = New System.Drawing.Point(376, 181)
        Me.LTRFC_RECEPTOR.Name = "LTRFC_RECEPTOR"
        Me.LTRFC_RECEPTOR.Size = New System.Drawing.Size(116, 23)
        Me.LTRFC_RECEPTOR.TabIndex = 587
        Me.LTRFC_RECEPTOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 586
        Me.Label4.Text = "R.F.C. del Emisor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTNOMBRE_EMISOR
        '
        Me.LTNOMBRE_EMISOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTNOMBRE_EMISOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTNOMBRE_EMISOR.Location = New System.Drawing.Point(143, 181)
        Me.LTNOMBRE_EMISOR.MaximumSize = New System.Drawing.Size(215, 44)
        Me.LTNOMBRE_EMISOR.Name = "LTNOMBRE_EMISOR"
        Me.LTNOMBRE_EMISOR.Size = New System.Drawing.Size(215, 22)
        Me.LTNOMBRE_EMISOR.TabIndex = 585
        Me.LTNOMBRE_EMISOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 584
        Me.Label3.Text = "Folio fiscal"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LRFC_EMISOR
        '
        Me.LRFC_EMISOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LRFC_EMISOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRFC_EMISOR.Location = New System.Drawing.Point(23, 181)
        Me.LRFC_EMISOR.Name = "LRFC_EMISOR"
        Me.LRFC_EMISOR.Size = New System.Drawing.Size(104, 23)
        Me.LRFC_EMISOR.TabIndex = 583
        Me.LRFC_EMISOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 16)
        Me.Label2.TabIndex = 589
        Me.Label2.Text = "Nombre o razón social del emisor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(373, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 590
        Me.Label6.Text = "R.F.C. del receptor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(582, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 16)
        Me.Label7.TabIndex = 591
        Me.Label7.Text = "Fecha certificación"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTNOMBRE_RECEPTOR
        '
        Me.LTNOMBRE_RECEPTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTNOMBRE_RECEPTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTNOMBRE_RECEPTOR.Location = New System.Drawing.Point(509, 181)
        Me.LTNOMBRE_RECEPTOR.MaximumSize = New System.Drawing.Size(215, 44)
        Me.LTNOMBRE_RECEPTOR.Name = "LTNOMBRE_RECEPTOR"
        Me.LTNOMBRE_RECEPTOR.Size = New System.Drawing.Size(215, 22)
        Me.LTNOMBRE_RECEPTOR.TabIndex = 594
        Me.LTNOMBRE_RECEPTOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(609, 313)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 16)
        Me.Label9.TabIndex = 595
        Me.Label9.Text = "PAC que certificó"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LT_PAC
        '
        Me.LT_PAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LT_PAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LT_PAC.Location = New System.Drawing.Point(612, 336)
        Me.LT_PAC.Name = "LT_PAC"
        Me.LT_PAC.Size = New System.Drawing.Size(149, 23)
        Me.LT_PAC.TabIndex = 599
        Me.LT_PAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTFECHA_CER
        '
        Me.LTFECHA_CER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTFECHA_CER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTFECHA_CER.Location = New System.Drawing.Point(585, 257)
        Me.LTFECHA_CER.Name = "LTFECHA_CER"
        Me.LTFECHA_CER.Size = New System.Drawing.Size(142, 23)
        Me.LTFECHA_CER.TabIndex = 598
        Me.LTFECHA_CER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTFECHA_EXP
        '
        Me.LTFECHA_EXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTFECHA_EXP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTFECHA_EXP.Location = New System.Drawing.Point(397, 257)
        Me.LTFECHA_EXP.Name = "LTFECHA_EXP"
        Me.LTFECHA_EXP.Size = New System.Drawing.Size(172, 23)
        Me.LTFECHA_EXP.TabIndex = 597
        Me.LTFECHA_EXP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTFOLIO_FISCAL
        '
        Me.LTFOLIO_FISCAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTFOLIO_FISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTFOLIO_FISCAL.Location = New System.Drawing.Point(23, 257)
        Me.LTFOLIO_FISCAL.Name = "LTFOLIO_FISCAL"
        Me.LTFOLIO_FISCAL.Size = New System.Drawing.Size(368, 23)
        Me.LTFOLIO_FISCAL.TabIndex = 596
        Me.LTFOLIO_FISCAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTSTATUS_CANC
        '
        Me.LTSTATUS_CANC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTSTATUS_CANC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTSTATUS_CANC.Location = New System.Drawing.Point(429, 336)
        Me.LTSTATUS_CANC.Name = "LTSTATUS_CANC"
        Me.LTSTATUS_CANC.Size = New System.Drawing.Size(177, 23)
        Me.LTSTATUS_CANC.TabIndex = 607
        Me.LTSTATUS_CANC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTESTADO_CFDI
        '
        Me.LTESTADO_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTESTADO_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTESTADO_CFDI.Location = New System.Drawing.Point(283, 336)
        Me.LTESTADO_CFDI.Name = "LTESTADO_CFDI"
        Me.LTESTADO_CFDI.Size = New System.Drawing.Size(142, 23)
        Me.LTESTADO_CFDI.TabIndex = 606
        Me.LTESTADO_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTEFECTO_COMPROBANTE
        '
        Me.LTEFECTO_COMPROBANTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTEFECTO_COMPROBANTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTEFECTO_COMPROBANTE.Location = New System.Drawing.Point(131, 336)
        Me.LTEFECTO_COMPROBANTE.Name = "LTEFECTO_COMPROBANTE"
        Me.LTEFECTO_COMPROBANTE.Size = New System.Drawing.Size(148, 23)
        Me.LTEFECTO_COMPROBANTE.TabIndex = 605
        Me.LTEFECTO_COMPROBANTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LTTOTAL_CFDI
        '
        Me.LTTOTAL_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTTOTAL_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTTOTAL_CFDI.Location = New System.Drawing.Point(23, 336)
        Me.LTTOTAL_CFDI.Name = "LTTOTAL_CFDI"
        Me.LTTOTAL_CFDI.Size = New System.Drawing.Size(104, 23)
        Me.LTTOTAL_CFDI.TabIndex = 604
        Me.LTTOTAL_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(426, 313)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(128, 16)
        Me.Lt2.TabIndex = 603
        Me.Lt2.Text = "Estatus cancelación"
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(283, 313)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(84, 16)
        Me.Lt1.TabIndex = 602
        Me.Lt1.Text = "Estado CFDI"
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(128, 313)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(151, 16)
        Me.Label20.TabIndex = 601
        Me.Label20.Text = "Efecto del comprobante"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(26, 313)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(94, 16)
        Me.Label21.TabIndex = 600
        Me.Label21.Text = "Total del CFDI"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(506, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(218, 16)
        Me.Label22.TabIndex = 609
        Me.Label22.Text = "Nombre o razón social del receptor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.RFC_EMISOR, Me.NOMBRE_EMISOR, Me.RFC_RECEPTOR, Me.NOMBRE_RECEPTOR, Me.UUID, Me.FECHA_EXP, Me.FRECHA_CER, Me.PAC_CER, Me.TOTAL_CFDI, Me.TIPO_COMPROBANTE, Me.ESTADO_CFDI, Me.STATUS_CANC})
        Me.DataTable1.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"RFC_EMISOR"}, True)})
        Me.DataTable1.PrimaryKey = New System.Data.DataColumn() {Me.RFC_EMISOR}
        Me.DataTable1.TableName = "Table1"
        '
        'RFC_EMISOR
        '
        Me.RFC_EMISOR.AllowDBNull = False
        Me.RFC_EMISOR.Caption = "RFC_EMISOR"
        Me.RFC_EMISOR.ColumnName = "RFC_EMISOR"
        '
        'NOMBRE_EMISOR
        '
        Me.NOMBRE_EMISOR.Caption = "NOMBRE_EMISOR"
        Me.NOMBRE_EMISOR.ColumnName = "NOMBRE_EMISOR"
        '
        'RFC_RECEPTOR
        '
        Me.RFC_RECEPTOR.ColumnName = "RFC_RECEPTOR"
        '
        'NOMBRE_RECEPTOR
        '
        Me.NOMBRE_RECEPTOR.ColumnName = "NOMBRE_RECEPTOR"
        Me.NOMBRE_RECEPTOR.DefaultValue = ""
        '
        'UUID
        '
        Me.UUID.ColumnName = "UUID"
        '
        'FECHA_EXP
        '
        Me.FECHA_EXP.ColumnName = "FECHA_EXP"
        '
        'FRECHA_CER
        '
        Me.FRECHA_CER.ColumnName = "FRECHA_CER"
        '
        'PAC_CER
        '
        Me.PAC_CER.ColumnName = "PAC_CER"
        '
        'TOTAL_CFDI
        '
        Me.TOTAL_CFDI.ColumnName = "TOTAL_CFDI"
        '
        'TIPO_COMPROBANTE
        '
        Me.TIPO_COMPROBANTE.ColumnName = "TIPO_COMPROBANTE"
        '
        'ESTADO_CFDI
        '
        Me.ESTADO_CFDI.ColumnName = "ESTADO_CFDI"
        '
        'STATUS_CANC
        '
        Me.STATUS_CANC.ColumnName = "STATUS_CANC"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "b12949ef4f0d4f0b914dcc11894de08f"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 16)
        Me.Label8.TabIndex = 612
        Me.Label8.Text = "Documento"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(112, 107)
        Me.LtCVE_DOC.MaximumSize = New System.Drawing.Size(215, 44)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(190, 22)
        Me.LtCVE_DOC.TabIndex = 611
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmEstatusCFDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 404)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtCVE_DOC)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.LTSTATUS_CANC)
        Me.Controls.Add(Me.LTESTADO_CFDI)
        Me.Controls.Add(Me.LTEFECTO_COMPROBANTE)
        Me.Controls.Add(Me.LTTOTAL_CFDI)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LT_PAC)
        Me.Controls.Add(Me.LTFECHA_CER)
        Me.Controls.Add(Me.LTFECHA_EXP)
        Me.Controls.Add(Me.LTFOLIO_FISCAL)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LTNOMBRE_RECEPTOR)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LTRFC_RECEPTOR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LTNOMBRE_EMISOR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LRFC_EMISOR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstatusCFDI"
        Me.Text = "Estatus CFDI"
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder2 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LTRFC_RECEPTOR As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LTNOMBRE_EMISOR As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LRFC_EMISOR As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LTSTATUS_CANC As Label
    Friend WithEvents LTESTADO_CFDI As Label
    Friend WithEvents LTEFECTO_COMPROBANTE As Label
    Friend WithEvents LTTOTAL_CFDI As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents LT_PAC As Label
    Friend WithEvents LTFECHA_CER As Label
    Friend WithEvents LTFECHA_EXP As Label
    Friend WithEvents LTFOLIO_FISCAL As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LTNOMBRE_RECEPTOR As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents RFC_EMISOR As DataColumn
    Friend WithEvents NOMBRE_EMISOR As DataColumn
    Friend WithEvents RFC_RECEPTOR As DataColumn
    Friend WithEvents NOMBRE_RECEPTOR As DataColumn
    Friend WithEvents UUID As DataColumn
    Friend WithEvents FECHA_EXP As DataColumn
    Friend WithEvents FRECHA_CER As DataColumn
    Friend WithEvents PAC_CER As DataColumn
    Friend WithEvents TOTAL_CFDI As DataColumn
    Friend WithEvents TIPO_COMPROBANTE As DataColumn
    Friend WithEvents ESTADO_CFDI As DataColumn
    Friend WithEvents STATUS_CANC As DataColumn
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Label8 As Label
    Friend WithEvents LtCVE_DOC As Label
End Class
