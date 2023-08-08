<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHorasGenerador
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHorasGenerador))
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
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarDisenador = New System.Windows.Forms.ToolStripButton()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.L2 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_TRACTOR, Me.CVE_TANQUE1, Me.CVE_TANQUE2, Me.ORIGEN, Me.NOMBRE_OPER, Me.DESTINO, Me.TON_TANQUE1, Me.TON_TANQUE2, Me.KM_RECORRIDO, Me.FEC1, Me.FEC2, Me.PRODUCTO, Me.FECHA_CARGA, Me.FECHA_DESCARGA, Me.CARTA_PORTE1, Me.CARTA_PORTE2, Me.PORFECHA, Me.FECHA_DOC, Me.CVE_VIAJE, Me.CLIENTE, Me.SUELDO, Me.KMS_RUTAS})
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarImprimir, Me.ToolStripSeparator1, Me.BarDisenador, Me.BarSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(456, 54)
        Me.ToolStrip1.TabIndex = 186
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
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDisenador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.Size = New System.Drawing.Size(64, 51)
        Me.BarDisenador.Text = "Diseñador"
        Me.BarDisenador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(46, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 367
        Me.Label10.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rango de fechas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 381
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.F2.BorderColor = System.Drawing.Color.Blue
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(261, 125)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 380
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.F1.BorderColor = System.Drawing.Color.Blue
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(106, 125)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(106, 235)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(291, 22)
        Me.L2.TabIndex = 4
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOper
        '
        Me.BtnOper.AutoSize = True
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnOper.Location = New System.Drawing.Point(188, 195)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 24)
        Me.BtnOper.TabIndex = 365
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 199)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 364
        Me.Label11.Text = "Operador"
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.Location = New System.Drawing.Point(106, 196)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_OPER.TabIndex = 3
        '
        'FrmHorasGenerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 322)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHorasGenerador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte horas generador"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents CVE_VIAJE As DataColumn
    Friend WithEvents CLIENTE As DataColumn
    Friend WithEvents SUELDO As DataColumn
    Friend WithEvents KMS_RUTAS As DataColumn
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BarSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label10 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents L2 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents Label11 As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents BarDisenador As ToolStripButton
End Class
