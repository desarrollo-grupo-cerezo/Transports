<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReportViajesLiq
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportViajesLiq))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RadViaje = New System.Windows.Forms.RadioButton()
        Me.RadCarga = New System.Windows.Forms.RadioButton()
        Me.RadLiq = New System.Windows.Forms.RadioButton()
        Me.Box1 = New System.Windows.Forms.GroupBox()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CVE_TRACTOR = New System.Data.DataColumn()
        Me.CVE_TANQUE1 = New System.Data.DataColumn()
        Me.CVE_TANQUE2 = New System.Data.DataColumn()
        Me.ORIGEN = New System.Data.DataColumn()
        Me.NOMBRE_OPER = New System.Data.DataColumn()
        Me.DESTINO = New System.Data.DataColumn()
        Me.TON_TANQUE1 = New System.Data.DataColumn()
        Me.TON_TANQUE2 = New System.Data.DataColumn()
        Me.KM_RECORRIDO = New System.Data.DataColumn()
        Me.FEC1 = New System.Data.DataColumn()
        Me.FEC2 = New System.Data.DataColumn()
        Me.PRODUCTO = New System.Data.DataColumn()
        Me.FECHA_CARGA = New System.Data.DataColumn()
        Me.FECHA_DESCARGA = New System.Data.DataColumn()
        Me.CARTA_PORTE1 = New System.Data.DataColumn()
        Me.CARTA_PORTE2 = New System.Data.DataColumn()
        Me.PORFECHA = New System.Data.DataColumn()
        Me.FECHA_DOC = New System.Data.DataColumn()
        Me.UNIDAD = New System.Data.DataColumn()
        Me.RadNormal = New System.Windows.Forms.RadioButton()
        Me.RadAgrupadoXOper = New System.Windows.Forms.RadioButton()
        Me.RadAgrupadoXUnidad = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadCargaCartaPorte = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SUELDO = New System.Data.DataColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Box1.SuspendLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(181, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 187
        Me.Label3.Text = "Por fecha de"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(246, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 16)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "al"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarImprimir, Me.ToolStripSeparator1, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(504, 54)
        Me.ToolStrip1.TabIndex = 184
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.Size = New System.Drawing.Size(57, 51)
        Me.BarImprimir.Text = "Imprimir"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(291, 177)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(101, 177)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 16)
        Me.Label10.TabIndex = 362
        Me.Label10.Text = "Nombre"
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(95, 56)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(291, 22)
        Me.L2.TabIndex = 361
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(177, 18)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 24)
        Me.BtnOper.TabIndex = 360
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.Location = New System.Drawing.Point(95, 19)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_OPER.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(25, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 358
        Me.Label11.Text = "Operador"
        '
        'RadViaje
        '
        Me.RadViaje.AutoSize = True
        Me.RadViaje.Checked = True
        Me.RadViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadViaje.Location = New System.Drawing.Point(15, 19)
        Me.RadViaje.Name = "RadViaje"
        Me.RadViaje.Size = New System.Drawing.Size(57, 20)
        Me.RadViaje.TabIndex = 363
        Me.RadViaje.TabStop = True
        Me.RadViaje.Text = "Viaje"
        Me.RadViaje.UseVisualStyleBackColor = False
        '
        'RadCarga
        '
        Me.RadCarga.AutoSize = True
        Me.RadCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCarga.Location = New System.Drawing.Point(94, 19)
        Me.RadCarga.Name = "RadCarga"
        Me.RadCarga.Size = New System.Drawing.Size(63, 20)
        Me.RadCarga.TabIndex = 364
        Me.RadCarga.Text = "Carga"
        Me.RadCarga.UseVisualStyleBackColor = False
        '
        'RadLiq
        '
        Me.RadLiq.AutoSize = True
        Me.RadLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLiq.Location = New System.Drawing.Point(326, 19)
        Me.RadLiq.Name = "RadLiq"
        Me.RadLiq.Size = New System.Drawing.Size(95, 20)
        Me.RadLiq.TabIndex = 365
        Me.RadLiq.Text = "Liquidación"
        Me.RadLiq.UseVisualStyleBackColor = False
        '
        'Box1
        '
        Me.Box1.Controls.Add(Me.TCVE_OPER)
        Me.Box1.Controls.Add(Me.Label11)
        Me.Box1.Controls.Add(Me.BtnOper)
        Me.Box1.Controls.Add(Me.L2)
        Me.Box1.Controls.Add(Me.Label10)
        Me.Box1.Location = New System.Drawing.Point(30, 288)
        Me.Box1.Name = "Box1"
        Me.Box1.Size = New System.Drawing.Size(435, 91)
        Me.Box1.TabIndex = 367
        Me.Box1.TabStop = False
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
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_TRACTOR, Me.CVE_TANQUE1, Me.CVE_TANQUE2, Me.ORIGEN, Me.NOMBRE_OPER, Me.DESTINO, Me.TON_TANQUE1, Me.TON_TANQUE2, Me.KM_RECORRIDO, Me.FEC1, Me.FEC2, Me.PRODUCTO, Me.FECHA_CARGA, Me.FECHA_DESCARGA, Me.CARTA_PORTE1, Me.CARTA_PORTE2, Me.PORFECHA, Me.FECHA_DOC, Me.SUELDO})
        Me.DataTable1.TableName = "Table1"
        '
        'CVE_TRACTOR
        '
        Me.CVE_TRACTOR.AllowDBNull = False
        Me.CVE_TRACTOR.ColumnName = "CVE_TRACTOR"
        Me.CVE_TRACTOR.DefaultValue = ""
        '
        'CVE_TANQUE1
        '
        Me.CVE_TANQUE1.ColumnName = "CVE_TANQUE1"
        Me.CVE_TANQUE1.DefaultValue = ""
        '
        'CVE_TANQUE2
        '
        Me.CVE_TANQUE2.ColumnName = "CVE_TANQUE2"
        Me.CVE_TANQUE2.DefaultValue = ""
        '
        'ORIGEN
        '
        Me.ORIGEN.ColumnName = "ORIGEN"
        '
        'NOMBRE_OPER
        '
        Me.NOMBRE_OPER.ColumnName = "NOMBRE_OPER"
        '
        'DESTINO
        '
        Me.DESTINO.ColumnName = "DESTINO"
        Me.DESTINO.DefaultValue = ""
        '
        'TON_TANQUE1
        '
        Me.TON_TANQUE1.ColumnName = "TON_TANQUE1"
        Me.TON_TANQUE1.DataType = GetType(Decimal)
        '
        'TON_TANQUE2
        '
        Me.TON_TANQUE2.ColumnName = "TON_TANQUE2"
        Me.TON_TANQUE2.DataType = GetType(Decimal)
        '
        'KM_RECORRIDO
        '
        Me.KM_RECORRIDO.ColumnName = "KM_RECORRIDO"
        Me.KM_RECORRIDO.DataType = GetType(Decimal)
        '
        'FEC1
        '
        Me.FEC1.ColumnName = "FEC1"
        Me.FEC1.DataType = GetType(Date)
        '
        'FEC2
        '
        Me.FEC2.ColumnName = "FEC2"
        Me.FEC2.DataType = GetType(Date)
        '
        'PRODUCTO
        '
        Me.PRODUCTO.ColumnName = "PRODUCTO"
        '
        'FECHA_CARGA
        '
        Me.FECHA_CARGA.ColumnName = "FECHA_CARGA"
        Me.FECHA_CARGA.DataType = GetType(Date)
        '
        'FECHA_DESCARGA
        '
        Me.FECHA_DESCARGA.ColumnName = "FECHA_DESCARGA"
        Me.FECHA_DESCARGA.DataType = GetType(Date)
        '
        'CARTA_PORTE1
        '
        Me.CARTA_PORTE1.ColumnName = "CARTA_PORTE1"
        '
        'CARTA_PORTE2
        '
        Me.CARTA_PORTE2.ColumnName = "CARTA_PORTE2"
        '
        'PORFECHA
        '
        Me.PORFECHA.ColumnName = "PORFECHA"
        '
        'FECHA_DOC
        '
        Me.FECHA_DOC.ColumnName = "FECHA_DOC"
        Me.FECHA_DOC.DataType = GetType(Date)
        '
        'RadNormal
        '
        Me.RadNormal.AutoSize = True
        Me.RadNormal.Checked = True
        Me.RadNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadNormal.Location = New System.Drawing.Point(10, 28)
        Me.RadNormal.Name = "RadNormal"
        Me.RadNormal.Size = New System.Drawing.Size(111, 19)
        Me.RadNormal.TabIndex = 368
        Me.RadNormal.TabStop = True
        Me.RadNormal.Text = "Reporte normal"
        Me.RadNormal.UseVisualStyleBackColor = True
        '
        'RadAgrupadoXOper
        '
        Me.RadAgrupadoXOper.AutoSize = True
        Me.RadAgrupadoXOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAgrupadoXOper.Location = New System.Drawing.Point(124, 28)
        Me.RadAgrupadoXOper.Name = "RadAgrupadoXOper"
        Me.RadAgrupadoXOper.Size = New System.Drawing.Size(152, 19)
        Me.RadAgrupadoXOper.TabIndex = 369
        Me.RadAgrupadoXOper.TabStop = True
        Me.RadAgrupadoXOper.Text = "Agrupado por operador"
        Me.RadAgrupadoXOper.UseVisualStyleBackColor = True
        '
        'RadAgrupadoXUnidad
        '
        Me.RadAgrupadoXUnidad.AutoSize = True
        Me.RadAgrupadoXUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAgrupadoXUnidad.Location = New System.Drawing.Point(279, 28)
        Me.RadAgrupadoXUnidad.Name = "RadAgrupadoXUnidad"
        Me.RadAgrupadoXUnidad.Size = New System.Drawing.Size(140, 19)
        Me.RadAgrupadoXUnidad.TabIndex = 370
        Me.RadAgrupadoXUnidad.TabStop = True
        Me.RadAgrupadoXUnidad.Text = "Agrupado por unidad"
        Me.RadAgrupadoXUnidad.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadCargaCartaPorte)
        Me.GroupBox1.Controls.Add(Me.RadLiq)
        Me.GroupBox1.Controls.Add(Me.RadViaje)
        Me.GroupBox1.Controls.Add(Me.RadCarga)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 53)
        Me.GroupBox1.TabIndex = 371
        Me.GroupBox1.TabStop = False
        '
        'RadCargaCartaPorte
        '
        Me.RadCargaCartaPorte.AutoSize = True
        Me.RadCargaCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCargaCartaPorte.Location = New System.Drawing.Point(179, 19)
        Me.RadCargaCartaPorte.Name = "RadCargaCartaPorte"
        Me.RadCargaCartaPorte.Size = New System.Drawing.Size(125, 20)
        Me.RadCargaCartaPorte.TabIndex = 366
        Me.RadCargaCartaPorte.Text = "Carta carta porte"
        Me.RadCargaCartaPorte.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadAgrupadoXUnidad)
        Me.GroupBox2.Controls.Add(Me.RadNormal)
        Me.GroupBox2.Controls.Add(Me.RadAgrupadoXOper)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(435, 64)
        Me.GroupBox2.TabIndex = 372
        Me.GroupBox2.TabStop = False
        '
        'SUELDO
        '
        Me.SUELDO.ColumnName = "SUELDO"
        Me.SUELDO.DataType = GetType(Decimal)
        '
        'FrmReportViajesLiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 425)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Box1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportViajesLiq"
        Me.ShowInTaskbar = False
        Me.Text = "Reporte de viajes liquidados"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Box1.ResumeLayout(False)
        Me.Box1.PerformLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FD2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents FD1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents FC2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents FC1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Label10 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents UNIDAD As DataColumn
    Friend WithEvents CVE_TRACTOR As DataColumn
    Friend WithEvents CVE_TANQUE1 As DataColumn
    Friend WithEvents CVE_TANQUE2 As DataColumn
    Friend WithEvents ORIGEN As DataColumn
    Friend WithEvents NOMBRE_OPER As DataColumn
    Friend WithEvents DESTINO As DataColumn
    Friend WithEvents TON_TANQUE1 As DataColumn
    Friend WithEvents TON_TANQUE2 As DataColumn
    Friend WithEvents KM_RECORRIDO As DataColumn
    Friend WithEvents FEC1 As DataColumn
    Friend WithEvents FEC2 As DataColumn
    Friend WithEvents PRODUCTO As DataColumn
    Friend WithEvents FECHA_CARGA As DataColumn
    Friend WithEvents RadViaje As RadioButton
    Friend WithEvents RadCarga As RadioButton
    Friend WithEvents RadLiq As RadioButton
    Friend WithEvents FECHA_DESCARGA As DataColumn
    Friend WithEvents CARTA_PORTE1 As DataColumn
    Friend WithEvents CARTA_PORTE2 As DataColumn
    Friend WithEvents PORFECHA As DataColumn
    Friend WithEvents Box1 As GroupBox
    Friend WithEvents RadNormal As RadioButton
    Friend WithEvents RadAgrupadoXOper As RadioButton
    Friend WithEvents RadAgrupadoXUnidad As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadCargaCartaPorte As RadioButton
    Friend WithEvents FECHA_DOC As DataColumn
    Friend WithEvents SUELDO As DataColumn
End Class
