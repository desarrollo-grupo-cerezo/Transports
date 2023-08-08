<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRelacionKM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRelacionKM))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.L1 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.FACTURA = New System.Data.DataColumn()
        Me.DOCUMENT = New System.Data.DataColumn()
        Me.DOCUMENT2 = New System.Data.DataColumn()
        Me.CVE_TRACTOR = New System.Data.DataColumn()
        Me.CVE_TANQUE1 = New System.Data.DataColumn()
        Me.CVE_TANQUE2 = New System.Data.DataColumn()
        Me.CVE_OPER = New System.Data.DataColumn()
        Me.NOMBRE = New System.Data.DataColumn()
        Me.OP_NOMBRE_O = New System.Data.DataColumn()
        Me.CIUDAD_O = New System.Data.DataColumn()
        Me.OP_NOMBRE_D = New System.Data.DataColumn()
        Me.CIUDAD_D = New System.Data.DataColumn()
        Me.PESO1 = New System.Data.DataColumn()
        Me.PESO2 = New System.Data.DataColumn()
        Me.KM_RECO = New System.Data.DataColumn()
        Me.FEC1 = New System.Data.DataColumn()
        Me.FEC2 = New System.Data.DataColumn()
        Me.DESCR = New System.Data.DataColumn()
        Me.FECHA_CARGA = New System.Data.DataColumn()
        Me.NUM = New System.Data.DataColumn()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(434, 43)
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
        Me.L1.Location = New System.Drawing.Point(159, 96)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(111, 16)
        Me.L1.TabIndex = 191
        Me.L1.Text = "Rango de fechas"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(213, 130)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(19, 16)
        Me.LtAl.TabIndex = 190
        Me.LtAl.Text = "al"
        '
        'F2
        '
        Me.F2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(252, 128)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 188
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(35, 132)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(29, 16)
        Me.LtDel.TabIndex = 189
        Me.LtDel.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(70, 128)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 187
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "b1f4fd45cf524466a51ca546cfd37149"
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
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.FACTURA, Me.DOCUMENT, Me.DOCUMENT2, Me.CVE_TRACTOR, Me.CVE_TANQUE1, Me.CVE_TANQUE2, Me.CVE_OPER, Me.NOMBRE, Me.OP_NOMBRE_O, Me.CIUDAD_O, Me.OP_NOMBRE_D, Me.CIUDAD_D, Me.PESO1, Me.PESO2, Me.KM_RECO, Me.FEC1, Me.FEC2, Me.DESCR, Me.FECHA_CARGA, Me.NUM})
        Me.DataTable1.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"FACTURA"}, True)})
        Me.DataTable1.PrimaryKey = New System.Data.DataColumn() {Me.FACTURA}
        Me.DataTable1.TableName = "Table1"
        '
        'FACTURA
        '
        Me.FACTURA.AllowDBNull = False
        Me.FACTURA.ColumnName = "FACTURA"
        '
        'DOCUMENT
        '
        Me.DOCUMENT.ColumnName = "DOCUMENT"
        '
        'DOCUMENT2
        '
        Me.DOCUMENT2.ColumnName = "DOCUMENT2"
        Me.DOCUMENT2.DefaultValue = ""
        '
        'CVE_TRACTOR
        '
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
        'CVE_OPER
        '
        Me.CVE_OPER.ColumnName = "CVE_OPER"
        Me.CVE_OPER.DefaultValue = ""
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        Me.NOMBRE.DefaultValue = ""
        '
        'OP_NOMBRE_O
        '
        Me.OP_NOMBRE_O.ColumnName = "OP_NOMBRE_O"
        Me.OP_NOMBRE_O.DefaultValue = ""
        '
        'CIUDAD_O
        '
        Me.CIUDAD_O.ColumnName = "CIUDAD_O"
        '
        'OP_NOMBRE_D
        '
        Me.OP_NOMBRE_D.ColumnName = "OP_NOMBRE_D"
        '
        'CIUDAD_D
        '
        Me.CIUDAD_D.ColumnName = "CIUDAD_D"
        Me.CIUDAD_D.DefaultValue = ""
        '
        'PESO1
        '
        Me.PESO1.ColumnName = "PESO1"
        Me.PESO1.DataType = GetType(Decimal)
        '
        'PESO2
        '
        Me.PESO2.ColumnName = "PESO2"
        Me.PESO2.DataType = GetType(Decimal)
        '
        'KM_RECO
        '
        Me.KM_RECO.ColumnName = "KM_RECO"
        Me.KM_RECO.DataType = GetType(Decimal)
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
        'DESCR
        '
        Me.DESCR.ColumnName = "DESCR"
        '
        'FECHA_CARGA
        '
        Me.FECHA_CARGA.ColumnName = "FECHA_CARGA"
        Me.FECHA_CARGA.DataType = GetType(Date)
        '
        'NUM
        '
        Me.NUM.ColumnName = "NUM"
        Me.NUM.DataType = GetType(Short)
        '
        'FrmRelacionKM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 223)
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
        Me.Name = "FrmRelacionKM"
        Me.ShowInTaskbar = False
        Me.Text = "Relación de kilometrajes"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents L1 As Label
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents FACTURA As DataColumn
    Friend WithEvents DOCUMENT As DataColumn
    Friend WithEvents DOCUMENT2 As DataColumn
    Friend WithEvents CVE_TRACTOR As DataColumn
    Friend WithEvents CVE_TANQUE1 As DataColumn
    Friend WithEvents CVE_TANQUE2 As DataColumn
    Friend WithEvents CVE_OPER As DataColumn
    Friend WithEvents NOMBRE As DataColumn
    Friend WithEvents OP_NOMBRE_O As DataColumn
    Friend WithEvents CIUDAD_O As DataColumn
    Friend WithEvents OP_NOMBRE_D As DataColumn
    Friend WithEvents CIUDAD_D As DataColumn
    Friend WithEvents PESO1 As DataColumn
    Friend WithEvents PESO2 As DataColumn
    Friend WithEvents KM_RECO As DataColumn
    Friend WithEvents FEC1 As DataColumn
    Friend WithEvents FEC2 As DataColumn
    Friend WithEvents DESCR As DataColumn
    Friend WithEvents FECHA_CARGA As DataColumn
    Friend WithEvents NUM As DataColumn
End Class
