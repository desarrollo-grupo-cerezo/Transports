<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExistAUnaFecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExistAUnaFecha))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CVE_ART = New System.Data.DataColumn()
        Me.DESCR = New System.Data.DataColumn()
        Me.EXIST = New System.Data.DataColumn()
        Me.COSTO = New System.Data.DataColumn()
        Me.IMPORTE = New System.Data.DataColumn()
        Me.ALMACEN = New System.Data.DataColumn()
        Me.FECHA = New System.Data.DataColumn()
        Me.NUM_ALM = New System.Data.DataColumn()
        Me.StiReportDataSource15 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource14 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource4 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource3 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDescUnidad = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.chSoloExist = New C1.Win.C1Input.C1CheckBox()
        Me.StiReportDataSource5 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource6 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource7 = New Stimulsoft.Report.Design.StiReportDataSource("DataTable1", Me.DataTable1)
        Me.StiReportDataSource8 = New Stimulsoft.Report.Design.StiReportDataSource("DataTable1", Me.DataTable1)
        Me.StiReportDataSource9 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource10 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource11 = New Stimulsoft.Report.Design.StiReportDataSource("DataTable1", Me.DataTable1)
        Me.StiReportDataSource12 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.StiReportDataSource13 = New Stimulsoft.Report.Design.StiReportDataSource("NewDataSet", Me.DataSet1)
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.tCVE_PROV1 = New System.Windows.Forms.TextBox()
        Me.btnProv1 = New C1.Win.C1Input.C1Button()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCVE_PROV2 = New System.Windows.Forms.TextBox()
        Me.btnProv2 = New C1.Win.C1Input.C1Button()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.C1List1 = New C1.Win.C1List.C1List()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chSoloExist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
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
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportDataSources.Add(Me.StiReportDataSource15)
        Me.StiReport1.ReportGuid = "2152c5463f85443e93008a206feaff5d"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_ART, Me.DESCR, Me.EXIST, Me.COSTO, Me.IMPORTE, Me.ALMACEN, Me.FECHA, Me.NUM_ALM})
        Me.DataTable1.TableName = "Table1"
        '
        'CVE_ART
        '
        Me.CVE_ART.AllowDBNull = False
        Me.CVE_ART.ColumnName = "CVE_ART"
        '
        'DESCR
        '
        Me.DESCR.ColumnName = "DESCR"
        '
        'EXIST
        '
        Me.EXIST.ColumnName = "EXIST"
        Me.EXIST.DataType = GetType(Double)
        Me.EXIST.DefaultValue = 0R
        '
        'COSTO
        '
        Me.COSTO.ColumnName = "COSTO"
        Me.COSTO.DataType = GetType(Double)
        Me.COSTO.DefaultValue = 0R
        '
        'IMPORTE
        '
        Me.IMPORTE.ColumnName = "IMPORTE"
        Me.IMPORTE.DataType = GetType(Double)
        Me.IMPORTE.DefaultValue = 0R
        '
        'ALMACEN
        '
        Me.ALMACEN.ColumnName = "ALMACEN"
        Me.ALMACEN.DefaultValue = "0"
        '
        'FECHA
        '
        Me.FECHA.ColumnName = "FECHA"
        Me.FECHA.DefaultValue = " "
        '
        'NUM_ALM
        '
        Me.NUM_ALM.ColumnName = "NUM_ALM"
        Me.NUM_ALM.DataType = GetType(Short)
        '
        'StiReportDataSource15
        '
        Me.StiReportDataSource15.Item = Me.DataSet1
        Me.StiReportDataSource15.Name = "NewDataSet"
        '
        'StiReportDataSource14
        '
        Me.StiReportDataSource14.Item = Me.DataSet1
        Me.StiReportDataSource14.Name = "NewDataSet"
        '
        'StiReportDataSource4
        '
        Me.StiReportDataSource4.Item = Me.DataSet1
        Me.StiReportDataSource4.Name = "NewDataSet"
        '
        'StiReportDataSource3
        '
        Me.StiReportDataSource3.Item = Me.DataSet1
        Me.StiReportDataSource3.Name = "NewDataSet"
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(449, 43)
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
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(187, 55)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(110, 16)
        Me.L1.TabIndex = 186
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(226, 81)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(18, 16)
        Me.LtAl.TabIndex = 185
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
        Me.F2.Location = New System.Drawing.Point(265, 79)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 183
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(50, 81)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(28, 16)
        Me.LtDel.TabIndex = 184
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
        Me.F1.Location = New System.Drawing.Point(83, 79)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 182
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDescUnidad
        '
        Me.LtDescUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescUnidad.Location = New System.Drawing.Point(190, 142)
        Me.LtDescUnidad.Name = "LtDescUnidad"
        Me.LtDescUnidad.Size = New System.Drawing.Size(186, 22)
        Me.LtDescUnidad.TabIndex = 191
        Me.LtDescUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUnidades
        '
        Me.btnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(163, 142)
        Me.btnUnidades.Name = "btnUnidades"
        Me.btnUnidades.Size = New System.Drawing.Size(26, 22)
        Me.btnUnidades.TabIndex = 190
        Me.btnUnidades.UseVisualStyleBackColor = True
        Me.btnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(82, 142)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(80, 22)
        Me.tCVE_UNI.TabIndex = 189
        '
        'LtUnidad
        '
        Me.LtUnidad.AutoSize = True
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(26, 145)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(51, 16)
        Me.LtUnidad.TabIndex = 188
        Me.LtUnidad.Text = "Unidad"
        '
        'chSoloExist
        '
        Me.chSoloExist.BackColor = System.Drawing.Color.Transparent
        Me.chSoloExist.BorderColor = System.Drawing.Color.Transparent
        Me.chSoloExist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chSoloExist.Checked = True
        Me.chSoloExist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chSoloExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chSoloExist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chSoloExist.ForeColor = System.Drawing.Color.Black
        Me.chSoloExist.Location = New System.Drawing.Point(56, 110)
        Me.chSoloExist.Name = "chSoloExist"
        Me.chSoloExist.Padding = New System.Windows.Forms.Padding(1)
        Me.chSoloExist.Size = New System.Drawing.Size(160, 24)
        Me.chSoloExist.TabIndex = 343
        Me.chSoloExist.TabStop = False
        Me.chSoloExist.Text = "Solo con existencias"
        Me.chSoloExist.UseVisualStyleBackColor = True
        Me.chSoloExist.Value = True
        Me.chSoloExist.Visible = False
        Me.chSoloExist.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'StiReportDataSource5
        '
        Me.StiReportDataSource5.Item = Me.DataSet1
        Me.StiReportDataSource5.Name = "NewDataSet"
        '
        'StiReportDataSource6
        '
        Me.StiReportDataSource6.Item = Me.DataSet1
        Me.StiReportDataSource6.Name = "NewDataSet"
        '
        'StiReportDataSource7
        '
        Me.StiReportDataSource7.Item = Me.DataTable1
        Me.StiReportDataSource7.Name = "DataTable1"
        '
        'StiReportDataSource8
        '
        Me.StiReportDataSource8.Item = Me.DataTable1
        Me.StiReportDataSource8.Name = "DataTable1"
        '
        'StiReportDataSource9
        '
        Me.StiReportDataSource9.Item = Me.DataSet1
        Me.StiReportDataSource9.Name = "NewDataSet"
        '
        'StiReportDataSource10
        '
        Me.StiReportDataSource10.Item = Me.DataSet1
        Me.StiReportDataSource10.Name = "NewDataSet"
        '
        'StiReportDataSource11
        '
        Me.StiReportDataSource11.Item = Me.DataTable1
        Me.StiReportDataSource11.Name = "DataTable1"
        '
        'StiReportDataSource12
        '
        Me.StiReportDataSource12.Item = Me.DataSet1
        Me.StiReportDataSource12.Name = "NewDataSet"
        '
        'StiReportDataSource13
        '
        Me.StiReportDataSource13.Item = Me.DataSet1
        Me.StiReportDataSource13.Name = "NewDataSet"
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.Location = New System.Drawing.Point(36, 217)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(28, 16)
        Me.Lt6.TabIndex = 346
        Me.Lt6.Text = "Del"
        '
        'tCVE_PROV1
        '
        Me.tCVE_PROV1.AcceptsReturn = True
        Me.tCVE_PROV1.AcceptsTab = True
        Me.tCVE_PROV1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tCVE_PROV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV1.Location = New System.Drawing.Point(69, 214)
        Me.tCVE_PROV1.MaxLength = 10
        Me.tCVE_PROV1.Name = "tCVE_PROV1"
        Me.tCVE_PROV1.Size = New System.Drawing.Size(119, 22)
        Me.tCVE_PROV1.TabIndex = 345
        '
        'btnProv1
        '
        Me.btnProv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProv1.Image = CType(resources.GetObject("btnProv1.Image"), System.Drawing.Image)
        Me.btnProv1.Location = New System.Drawing.Point(190, 214)
        Me.btnProv1.Name = "btnProv1"
        Me.btnProv1.Size = New System.Drawing.Size(26, 20)
        Me.btnProv1.TabIndex = 347
        Me.btnProv1.UseVisualStyleBackColor = True
        Me.btnProv1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.Location = New System.Drawing.Point(227, 216)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(18, 16)
        Me.Lt7.TabIndex = 349
        Me.Lt7.Text = "al"
        '
        'TCVE_PROV2
        '
        Me.TCVE_PROV2.AcceptsReturn = True
        Me.TCVE_PROV2.AcceptsTab = True
        Me.TCVE_PROV2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_PROV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV2.Location = New System.Drawing.Point(254, 212)
        Me.TCVE_PROV2.MaxLength = 10
        Me.TCVE_PROV2.Name = "TCVE_PROV2"
        Me.TCVE_PROV2.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_PROV2.TabIndex = 348
        '
        'btnProv2
        '
        Me.btnProv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProv2.Image = CType(resources.GetObject("btnProv2.Image"), System.Drawing.Image)
        Me.btnProv2.Location = New System.Drawing.Point(379, 213)
        Me.btnProv2.Name = "btnProv2"
        Me.btnProv2.Size = New System.Drawing.Size(26, 20)
        Me.btnProv2.TabIndex = 350
        Me.btnProv2.UseVisualStyleBackColor = True
        Me.btnProv2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(160, 188)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(148, 16)
        Me.Lt5.TabIndex = 351
        Me.Lt5.Text = "Rango de proveedores"
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione almacenes"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(45, 279)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(367, 181)
        Me.C1List1.TabIndex = 353
        Me.C1List1.VisualStyle = C1.Win.C1List.VisualStyle.Office2010Blue
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'frmExistAUnaFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 484)
        Me.Controls.Add(Me.C1List1)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt7)
        Me.Controls.Add(Me.TCVE_PROV2)
        Me.Controls.Add(Me.btnProv2)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.tCVE_PROV1)
        Me.Controls.Add(Me.btnProv1)
        Me.Controls.Add(Me.chSoloExist)
        Me.Controls.Add(Me.LtDescUnidad)
        Me.Controls.Add(Me.btnUnidades)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.LtAl)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.LtDel)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExistAUnaFecha"
        Me.ShowInTaskbar = False
        Me.Text = "Existencias a la fecha"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chSoloExist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDescUnidad As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents LtUnidad As Label
    Friend WithEvents chSoloExist As C1.Win.C1Input.C1CheckBox
    Friend WithEvents StiReportDataSource2 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource1 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents CVE_ART As DataColumn
    Friend WithEvents DESCR As DataColumn
    Friend WithEvents EXIST As DataColumn
    Friend WithEvents COSTO As DataColumn
    Friend WithEvents IMPORTE As DataColumn
    Friend WithEvents ALMACEN As DataColumn
    Friend WithEvents FECHA As DataColumn
    Friend WithEvents StiReportDataSource3 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource4 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource5 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource6 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource7 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource8 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource9 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource10 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource11 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource12 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource13 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents StiReportDataSource14 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents NUM_ALM As DataColumn
    Friend WithEvents StiReportDataSource15 As Stimulsoft.Report.Design.StiReportDataSource
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents TCVE_PROV2 As TextBox
    Friend WithEvents btnProv2 As C1.Win.C1Input.C1Button
    Friend WithEvents Lt6 As Label
    Friend WithEvents tCVE_PROV1 As TextBox
    Friend WithEvents btnProv1 As C1.Win.C1Input.C1Button
    Friend WithEvents CboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents C1List1 As C1.Win.C1List.C1List
End Class
