<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteViajesRealizados
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteViajesRealizados))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RadAgrupadoXUnidad = New System.Windows.Forms.RadioButton()
        Me.RadNormal = New System.Windows.Forms.RadioButton()
        Me.RadAgrupadoXCliente = New System.Windows.Forms.RadioButton()
        Me.TCLIENTE2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
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
        Me.CVE_VIAJE = New System.Data.DataColumn()
        Me.CLIENTE = New System.Data.DataColumn()
        Me.SUELDO = New System.Data.DataColumn()
        Me.KMS_RUTAS = New System.Data.DataColumn()
        Me.NOMBRE_CLIE = New System.Data.DataColumn()
        Me.FECHA_VIAJE = New System.Data.DataColumn()
        Me.FACTURA = New System.Data.DataColumn()
        Me.TONELADAS = New System.Data.DataColumn()
        Me.TIPO_UNI = New System.Data.DataColumn()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TCLIENTE1 = New System.Windows.Forms.TextBox()
        Me.TCVE_ART1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCVE_ART2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnArt2 = New C1.Win.C1Input.C1Button()
        Me.BTnCliente2 = New C1.Win.C1Input.C1Button()
        Me.BtnArt1 = New C1.Win.C1Input.C1Button()
        Me.BTnCliente1 = New C1.Win.C1Input.C1Button()
        Me.BtnDisenador2 = New C1.Win.C1Input.C1Button()
        Me.BtnDisenador1 = New C1.Win.C1Input.C1Button()
        Me.BtnDisenador3 = New C1.Win.C1Input.C1Button()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTnCliente2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTnCliente1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDisenador2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDisenador1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDisenador3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarImprimir, Me.ToolStripSeparator1, Me.BarSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(573, 54)
        Me.ToolStrip1.TabIndex = 185
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
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(36, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'RadAgrupadoXUnidad
        '
        Me.RadAgrupadoXUnidad.AutoSize = True
        Me.RadAgrupadoXUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAgrupadoXUnidad.Location = New System.Drawing.Point(382, 171)
        Me.RadAgrupadoXUnidad.Name = "RadAgrupadoXUnidad"
        Me.RadAgrupadoXUnidad.Size = New System.Drawing.Size(160, 21)
        Me.RadAgrupadoXUnidad.TabIndex = 4
        Me.RadAgrupadoXUnidad.TabStop = True
        Me.RadAgrupadoXUnidad.Text = "Agrupado por unidad"
        Me.RadAgrupadoXUnidad.UseVisualStyleBackColor = True
        '
        'RadNormal
        '
        Me.RadNormal.AutoSize = True
        Me.RadNormal.Checked = True
        Me.RadNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadNormal.Location = New System.Drawing.Point(45, 171)
        Me.RadNormal.Name = "RadNormal"
        Me.RadNormal.Size = New System.Drawing.Size(124, 21)
        Me.RadNormal.TabIndex = 2
        Me.RadNormal.TabStop = True
        Me.RadNormal.Text = "Reporte normal"
        Me.RadNormal.UseVisualStyleBackColor = True
        '
        'RadAgrupadoXCliente
        '
        Me.RadAgrupadoXCliente.AutoSize = True
        Me.RadAgrupadoXCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAgrupadoXCliente.Location = New System.Drawing.Point(206, 171)
        Me.RadAgrupadoXCliente.Name = "RadAgrupadoXCliente"
        Me.RadAgrupadoXCliente.Size = New System.Drawing.Size(158, 21)
        Me.RadAgrupadoXCliente.TabIndex = 3
        Me.RadAgrupadoXCliente.TabStop = True
        Me.RadAgrupadoXCliente.Text = "Agrupado por cliente"
        Me.RadAgrupadoXCliente.UseVisualStyleBackColor = True
        '
        'TCLIENTE2
        '
        Me.TCLIENTE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE2.Location = New System.Drawing.Point(360, 276)
        Me.TCLIENTE2.Name = "TCLIENTE2"
        Me.TCLIENTE2.Size = New System.Drawing.Size(80, 23)
        Me.TCLIENTE2.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(308, 279)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 17)
        Me.Label11.TabIndex = 358
        Me.Label11.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 377
        Me.Label3.Text = "Por fecha de viaje"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(273, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 17)
        Me.Label2.TabIndex = 376
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(303, 97)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 21)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(112, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 17)
        Me.Label1.TabIndex = 375
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
        Me.F1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(143, 97)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_TRACTOR, Me.CVE_TANQUE1, Me.CVE_TANQUE2, Me.ORIGEN, Me.NOMBRE_OPER, Me.DESTINO, Me.TON_TANQUE1, Me.TON_TANQUE2, Me.KM_RECORRIDO, Me.FEC1, Me.FEC2, Me.PRODUCTO, Me.FECHA_CARGA, Me.FECHA_DESCARGA, Me.CARTA_PORTE1, Me.CARTA_PORTE2, Me.PORFECHA, Me.FECHA_DOC, Me.CVE_VIAJE, Me.CLIENTE, Me.SUELDO, Me.KMS_RUTAS, Me.NOMBRE_CLIE, Me.FECHA_VIAJE, Me.FACTURA, Me.TONELADAS, Me.TIPO_UNI})
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
        'CVE_VIAJE
        '
        Me.CVE_VIAJE.ColumnName = "CVE_VIAJE"
        '
        'CLIENTE
        '
        Me.CLIENTE.ColumnName = "CLIENTE"
        '
        'SUELDO
        '
        Me.SUELDO.ColumnName = "SUELDO"
        Me.SUELDO.DataType = GetType(Decimal)
        '
        'KMS_RUTAS
        '
        Me.KMS_RUTAS.ColumnName = "KMS_RUTAS"
        Me.KMS_RUTAS.DataType = GetType(Decimal)
        '
        'NOMBRE_CLIE
        '
        Me.NOMBRE_CLIE.ColumnName = "NOMBRE_CLIE"
        '
        'FECHA_VIAJE
        '
        Me.FECHA_VIAJE.ColumnName = "FECHA_VIAJE"
        Me.FECHA_VIAJE.DataType = GetType(Date)
        '
        'FACTURA
        '
        Me.FACTURA.ColumnName = "FACTURA"
        '
        'TONELADAS
        '
        Me.TONELADAS.ColumnName = "TONELADAS"
        Me.TONELADAS.DataType = GetType(Decimal)
        '
        'TIPO_UNI
        '
        Me.TIPO_UNI.ColumnName = "TIPO_UNI"
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
        'TCLIENTE1
        '
        Me.TCLIENTE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE1.Location = New System.Drawing.Point(140, 276)
        Me.TCLIENTE1.Name = "TCLIENTE1"
        Me.TCLIENTE1.Size = New System.Drawing.Size(80, 23)
        Me.TCLIENTE1.TabIndex = 6
        '
        'TCVE_ART1
        '
        Me.TCVE_ART1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART1.Location = New System.Drawing.Point(140, 330)
        Me.TCVE_ART1.Name = "TCVE_ART1"
        Me.TCVE_ART1.Size = New System.Drawing.Size(80, 23)
        Me.TCVE_ART1.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(88, 279)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 364
        Me.Label7.Text = "Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(75, 333)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 358
        Me.Label4.Text = "Producto"
        '
        'TCVE_ART2
        '
        Me.TCVE_ART2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_ART2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART2.Location = New System.Drawing.Point(360, 330)
        Me.TCVE_ART2.Name = "TCVE_ART2"
        Me.TCVE_ART2.Size = New System.Drawing.Size(80, 23)
        Me.TCVE_ART2.TabIndex = 366
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(295, 333)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 367
        Me.Label5.Text = "Producto"
        '
        'BtnArt2
        '
        Me.BtnArt2.AutoSize = True
        Me.BtnArt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt2.Image = CType(resources.GetObject("BtnArt2.Image"), System.Drawing.Image)
        Me.BtnArt2.Location = New System.Drawing.Point(441, 329)
        Me.BtnArt2.Name = "BtnArt2"
        Me.BtnArt2.Size = New System.Drawing.Size(26, 24)
        Me.BtnArt2.TabIndex = 368
        Me.BtnArt2.UseVisualStyleBackColor = True
        Me.BtnArt2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BTnCliente2
        '
        Me.BTnCliente2.AutoSize = True
        Me.BTnCliente2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTnCliente2.Image = CType(resources.GetObject("BTnCliente2.Image"), System.Drawing.Image)
        Me.BTnCliente2.Location = New System.Drawing.Point(441, 275)
        Me.BTnCliente2.Name = "BTnCliente2"
        Me.BTnCliente2.Size = New System.Drawing.Size(26, 24)
        Me.BTnCliente2.TabIndex = 360
        Me.BTnCliente2.UseVisualStyleBackColor = True
        Me.BTnCliente2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnArt1
        '
        Me.BtnArt1.AutoSize = True
        Me.BtnArt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt1.Image = CType(resources.GetObject("BtnArt1.Image"), System.Drawing.Image)
        Me.BtnArt1.Location = New System.Drawing.Point(221, 329)
        Me.BtnArt1.Name = "BtnArt1"
        Me.BtnArt1.Size = New System.Drawing.Size(26, 24)
        Me.BtnArt1.TabIndex = 360
        Me.BtnArt1.UseVisualStyleBackColor = True
        Me.BtnArt1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BTnCliente1
        '
        Me.BTnCliente1.AutoSize = True
        Me.BTnCliente1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTnCliente1.Image = CType(resources.GetObject("BTnCliente1.Image"), System.Drawing.Image)
        Me.BTnCliente1.Location = New System.Drawing.Point(221, 274)
        Me.BTnCliente1.Name = "BTnCliente1"
        Me.BTnCliente1.Size = New System.Drawing.Size(26, 24)
        Me.BTnCliente1.TabIndex = 365
        Me.BTnCliente1.UseVisualStyleBackColor = True
        Me.BTnCliente1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnDisenador2
        '
        Me.BtnDisenador2.FlatAppearance.BorderSize = 0
        Me.BtnDisenador2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDisenador2.Image = Global.SGT_Transport.My.Resources.Resources.diseñador24
        Me.BtnDisenador2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDisenador2.Location = New System.Drawing.Point(263, 210)
        Me.BtnDisenador2.Name = "BtnDisenador2"
        Me.BtnDisenador2.Size = New System.Drawing.Size(27, 30)
        Me.BtnDisenador2.TabIndex = 594
        Me.BtnDisenador2.Text = "|"
        Me.BtnDisenador2.UseVisualStyleBackColor = True
        Me.BtnDisenador2.Visible = False
        Me.BtnDisenador2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnDisenador1
        '
        Me.BtnDisenador1.FlatAppearance.BorderSize = 0
        Me.BtnDisenador1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDisenador1.Image = Global.SGT_Transport.My.Resources.Resources.diseñador24
        Me.BtnDisenador1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDisenador1.Location = New System.Drawing.Point(89, 210)
        Me.BtnDisenador1.Name = "BtnDisenador1"
        Me.BtnDisenador1.Size = New System.Drawing.Size(27, 30)
        Me.BtnDisenador1.TabIndex = 593
        Me.BtnDisenador1.Text = "|"
        Me.BtnDisenador1.UseVisualStyleBackColor = True
        Me.BtnDisenador1.Visible = False
        Me.BtnDisenador1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnDisenador3
        '
        Me.BtnDisenador3.FlatAppearance.BorderSize = 0
        Me.BtnDisenador3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDisenador3.Image = Global.SGT_Transport.My.Resources.Resources.diseñador24
        Me.BtnDisenador3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDisenador3.Location = New System.Drawing.Point(445, 210)
        Me.BtnDisenador3.Name = "BtnDisenador3"
        Me.BtnDisenador3.Size = New System.Drawing.Size(27, 30)
        Me.BtnDisenador3.TabIndex = 595
        Me.BtnDisenador3.Text = "|"
        Me.BtnDisenador3.UseVisualStyleBackColor = True
        Me.BtnDisenador3.Visible = False
        Me.BtnDisenador3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmReporteViajesRealizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 383)
        Me.Controls.Add(Me.BtnDisenador3)
        Me.Controls.Add(Me.BtnDisenador2)
        Me.Controls.Add(Me.BtnDisenador1)
        Me.Controls.Add(Me.RadAgrupadoXUnidad)
        Me.Controls.Add(Me.RadNormal)
        Me.Controls.Add(Me.TCVE_ART2)
        Me.Controls.Add(Me.RadAgrupadoXCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnArt2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TCLIENTE2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCLIENTE1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.TCVE_ART1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTnCliente2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnArt1)
        Me.Controls.Add(Me.BTnCliente1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReporteViajesRealizados"
        Me.ShowInTaskbar = False
        Me.Text = "Viajes realizados"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTnCliente2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTnCliente1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDisenador2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDisenador1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDisenador3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BarSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents RadAgrupadoXUnidad As RadioButton
    Friend WithEvents RadNormal As RadioButton
    Friend WithEvents RadAgrupadoXCliente As RadioButton
    Friend WithEvents TCLIENTE2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BTnCliente2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
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
    Friend WithEvents FECHA_DESCARGA As DataColumn
    Friend WithEvents CARTA_PORTE1 As DataColumn
    Friend WithEvents CARTA_PORTE2 As DataColumn
    Friend WithEvents PORFECHA As DataColumn
    Friend WithEvents FECHA_DOC As DataColumn
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents CVE_VIAJE As DataColumn
    Friend WithEvents TCLIENTE1 As TextBox
    Friend WithEvents TCVE_ART1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BTnCliente1 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnArt1 As C1.Win.C1Input.C1Button
    Friend WithEvents CLIENTE As DataColumn
    Friend WithEvents SUELDO As DataColumn
    Friend WithEvents KMS_RUTAS As DataColumn
    Friend WithEvents TCVE_ART2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnArt2 As C1.Win.C1Input.C1Button
    Friend WithEvents NOMBRE_CLIE As DataColumn
    Friend WithEvents FECHA_VIAJE As DataColumn
    Friend WithEvents FACTURA As DataColumn
    Friend WithEvents TONELADAS As DataColumn
    Friend WithEvents BtnDisenador2 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnDisenador1 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnDisenador3 As C1.Win.C1Input.C1Button
    Friend WithEvents TIPO_UNI As DataColumn
End Class
