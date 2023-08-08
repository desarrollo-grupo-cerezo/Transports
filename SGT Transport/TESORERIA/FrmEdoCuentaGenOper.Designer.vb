<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEdoCuentaGenOper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEdoCuentaGenOper))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.LOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtSaldo = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.FOLIO = New System.Data.DataColumn()
        Me.DESCR_GASTOS = New System.Data.DataColumn()
        Me.CVE_LIQ = New System.Data.DataColumn()
        Me.FC1 = New System.Data.DataColumn()
        Me.FC2 = New System.Data.DataColumn()
        Me.LINEA = New System.Data.DataColumn()
        Me.CANT = New System.Data.DataColumn()
        Me.SALDO = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataTable2 = New System.Data.DataTable()
        Me.FOLIO_DED = New System.Data.DataColumn()
        Me.DESCR_DED = New System.Data.DataColumn()
        Me.LIQ = New System.Data.DataColumn()
        Me.FECHA2 = New System.Data.DataColumn()
        Me.IMPORT_PRES = New System.Data.DataColumn()
        Me.ABONOS = New System.Data.DataColumn()
        Me.SALDO2 = New System.Data.DataColumn()
        Me.CVE_OPER = New System.Data.DataColumn()
        Me.NOMBRE_OPER = New System.Data.DataColumn()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split3.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MenuHolder.Owner = Me
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkNuevo, Me.LkExcel, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(933, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
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
        'LOper
        '
        Me.LOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LOper.Location = New System.Drawing.Point(447, 46)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(303, 22)
        Me.LOper.TabIndex = 431
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(447, 20)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_OPER.TabIndex = 430
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(378, 23)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 16)
        Me.Label41.TabIndex = 432
        Me.Label41.Text = "Operador"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(124, 20)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 429
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(169, 46)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 428
        Me.LtAl.Text = "al"
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
        Me.F2.Location = New System.Drawing.Point(195, 44)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(105, 20)
        Me.F2.TabIndex = 426
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(25, 46)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 427
        Me.LtDel.Text = "Del"
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
        Me.F1.Location = New System.Drawing.Point(58, 44)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(105, 20)
        Me.F1.TabIndex = 425
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(387, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "Nombre"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "6a299de2867d4844866c6fc0dd22f5f2"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(4, 49)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Panels.Add(Me.Split3)
        Me.SplitM.Size = New System.Drawing.Size(921, 491)
        Me.SplitM.TabIndex = 436
        Me.SplitM.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Collapsible = True
        Me.Split1.Controls.Add(Me.Label2)
        Me.Split1.Controls.Add(Me.LtSaldo)
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Controls.Add(Me.LtDel)
        Me.Split1.Controls.Add(Me.LOper)
        Me.Split1.Controls.Add(Me.F2)
        Me.Split1.Controls.Add(Me.TCVE_OPER)
        Me.Split1.Controls.Add(Me.LtAl)
        Me.Split1.Controls.Add(Me.Label41)
        Me.Split1.Controls.Add(Me.L1)
        Me.Split1.Controls.Add(Me.BtnOper)
        Me.Split1.Height = 107
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(919, 100)
        Me.Split1.SizeRatio = 22.062R
        Me.Split1.TabIndex = 357
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(574, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 436
        Me.Label2.Text = "Saldo"
        '
        'LtSaldo
        '
        Me.LtSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSaldo.Location = New System.Drawing.Point(623, 20)
        Me.LtSaldo.Name = "LtSaldo"
        Me.LtSaldo.Size = New System.Drawing.Size(127, 22)
        Me.LtSaldo.TabIndex = 435
        Me.LtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(504, 19)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 22)
        Me.BtnOper.TabIndex = 433
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Split2
        '
        Me.Split2.Collapsible = True
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 188
        Me.Split2.Location = New System.Drawing.Point(1, 112)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(919, 181)
        Me.Split2.SizeRatio = 50.267R
        Me.Split2.TabIndex = 358
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.Location = New System.Drawing.Point(7, 12)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(838, 131)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 359
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Split3
        '
        Me.Split3.Collapsible = True
        Me.Split3.Controls.Add(Me.Fg2)
        Me.Split3.Height = 186
        Me.Split3.Location = New System.Drawing.Point(1, 304)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(919, 186)
        Me.Split3.TabIndex = 359
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg2.AutoClipboard = True
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg2.Location = New System.Drawing.Point(6, 15)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(914, 131)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 360
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.FOLIO, Me.DESCR_GASTOS, Me.CVE_LIQ, Me.FC1, Me.FC2, Me.LINEA, Me.CANT, Me.SALDO, Me.DataColumn1, Me.CVE_OPER, Me.NOMBRE_OPER})
        Me.DataTable1.TableName = "Table1"
        '
        'FOLIO
        '
        Me.FOLIO.AllowDBNull = False
        Me.FOLIO.ColumnName = "FOLIO"
        '
        'DESCR_GASTOS
        '
        Me.DESCR_GASTOS.ColumnName = "DESCR_GASTOS"
        '
        'CVE_LIQ
        '
        Me.CVE_LIQ.ColumnName = "CVE_LIQ"
        Me.CVE_LIQ.DefaultValue = ""
        '
        'FC1
        '
        Me.FC1.ColumnName = "F1"
        Me.FC1.DataType = GetType(Date)
        '
        'FC2
        '
        Me.FC2.ColumnName = "F2"
        Me.FC2.DataType = GetType(Date)
        '
        'LINEA
        '
        Me.LINEA.ColumnName = "IMPORTE"
        Me.LINEA.DataType = GetType(Decimal)
        '
        'CANT
        '
        Me.CANT.ColumnName = "ABONO"
        Me.CANT.DataType = GetType(Decimal)
        '
        'SALDO
        '
        Me.SALDO.ColumnName = "SALDO"
        Me.SALDO.DataType = GetType(Decimal)
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "FECHA"
        Me.DataColumn1.DataType = GetType(Date)
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.FOLIO_DED, Me.DESCR_DED, Me.LIQ, Me.FECHA2, Me.IMPORT_PRES, Me.ABONOS, Me.SALDO2})
        Me.DataTable2.TableName = "Table2"
        '
        'FOLIO_DED
        '
        Me.FOLIO_DED.ColumnName = "FOLIO_DED"
        '
        'DESCR_DED
        '
        Me.DESCR_DED.ColumnName = "DESCR_DED"
        '
        'LIQ
        '
        Me.LIQ.ColumnName = "LIQ"
        '
        'FECHA2
        '
        Me.FECHA2.ColumnName = "FECHA2"
        Me.FECHA2.DataType = GetType(Date)
        '
        'IMPORT_PRES
        '
        Me.IMPORT_PRES.ColumnName = "IMPORT_PRES"
        Me.IMPORT_PRES.DataType = GetType(Decimal)
        '
        'ABONOS
        '
        Me.ABONOS.ColumnName = "ABONOS"
        Me.ABONOS.DataType = GetType(Decimal)
        '
        'SALDO2
        '
        Me.SALDO2.ColumnName = "SALDO"
        Me.SALDO2.DataType = GetType(Decimal)
        '
        'CVE_OPER
        '
        Me.CVE_OPER.ColumnName = "CVE_OPER"
        Me.CVE_OPER.DataType = GetType(Short)
        '
        'NOMBRE_OPER
        '
        Me.NOMBRE_OPER.ColumnName = "NOMBRE_OPER"
        '
        'FrmEdoCuentaGenOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 583)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEdoCuentaGenOper"
        Me.Text = "Estado de cuenta general operadores"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split3.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñador As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents LtSaldo As Label
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents FOLIO As DataColumn
    Friend WithEvents DESCR_GASTOS As DataColumn
    Friend WithEvents CVE_LIQ As DataColumn
    Friend WithEvents FC1 As DataColumn
    Friend WithEvents FC2 As DataColumn
    Friend WithEvents LINEA As DataColumn
    Friend WithEvents CANT As DataColumn
    Friend WithEvents SALDO As DataColumn
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents FOLIO_DED As DataColumn
    Friend WithEvents DESCR_DED As DataColumn
    Friend WithEvents LIQ As DataColumn
    Friend WithEvents FECHA2 As DataColumn
    Friend WithEvents IMPORT_PRES As DataColumn
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents ABONOS As DataColumn
    Friend WithEvents SALDO2 As DataColumn
    Friend WithEvents CVE_OPER As DataColumn
    Friend WithEvents NOMBRE_OPER As DataColumn
End Class
