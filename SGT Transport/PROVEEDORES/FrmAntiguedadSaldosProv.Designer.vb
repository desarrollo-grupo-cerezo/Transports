<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAntiguedadSaldosProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAntiguedadSaldosProv))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkDiseñador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnProv1 = New System.Windows.Forms.Button()
        Me.TPROV1 = New System.Windows.Forms.TextBox()
        Me.BtnProv2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TPROV2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChDetalle = New C1.Win.C1Input.C1CheckBox()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CLIENTE = New System.Data.DataColumn()
        Me.NOMBRE = New System.Data.DataColumn()
        Me.IMPORTE = New System.Data.DataColumn()
        Me.SALDO = New System.Data.DataColumn()
        Me.ABONOS = New System.Data.DataColumn()
        Me.NDIAS30 = New System.Data.DataColumn()
        Me.NDIAS60 = New System.Data.DataColumn()
        Me.NDIAS90 = New System.Data.DataColumn()
        Me.NDIASMAYOR90 = New System.Data.DataColumn()
        Me.CLASIFIC = New System.Data.DataColumn()
        Me.FECHA1 = New System.Data.DataColumn()
        Me.FECHA_APLI = New System.Data.DataColumn()
        Me.REFER = New System.Data.DataColumn()
        Me.CLIENTE1 = New System.Data.DataColumn()
        Me.CLIENTE2 = New System.Data.DataColumn()
        Me.DEL_AL = New System.Data.DataColumn()
        Me.CLIE_PROV = New System.Data.DataColumn()
        Me.DIASCRED = New System.Data.DataColumn()
        Me.FECHA_VENC = New System.Data.DataColumn()
        Me.NDIAS = New System.Data.DataColumn()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.SU_REFER = New System.Data.DataColumn()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
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
        'BarDiseñador
        '
        Me.BarDiseñador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador.Name = "BarDiseñador"
        Me.BarDiseñador.ShortcutText = ""
        Me.BarDiseñador.ShowShortcut = False
        Me.BarDiseñador.ShowTextAsToolTip = False
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkDiseñador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(411, 43)
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
        'LkDiseñador
        '
        Me.LkDiseñador.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkDiseñador.Command = Me.BarDiseñador
        Me.LkDiseñador.Delimiter = True
        Me.LkDiseñador.SortOrder = 1
        Me.LkDiseñador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 2
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha de referencia"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(157, 93)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Rango de proveedores"
        '
        'BtnProv1
        '
        Me.BtnProv1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnProv1.FlatAppearance.BorderSize = 0
        Me.BtnProv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProv1.Image = CType(resources.GetObject("BtnProv1.Image"), System.Drawing.Image)
        Me.BtnProv1.Location = New System.Drawing.Point(157, 190)
        Me.BtnProv1.Name = "BtnProv1"
        Me.BtnProv1.Size = New System.Drawing.Size(25, 24)
        Me.BtnProv1.TabIndex = 8
        Me.BtnProv1.UseVisualStyleBackColor = True
        '
        'TPROV1
        '
        Me.TPROV1.AcceptsReturn = True
        Me.TPROV1.AcceptsTab = True
        Me.TPROV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROV1.Location = New System.Drawing.Point(80, 191)
        Me.TPROV1.Name = "TPROV1"
        Me.TPROV1.Size = New System.Drawing.Size(77, 21)
        Me.TPROV1.TabIndex = 1
        '
        'BtnProv2
        '
        Me.BtnProv2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnProv2.FlatAppearance.BorderSize = 0
        Me.BtnProv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProv2.Image = CType(resources.GetObject("BtnProv2.Image"), System.Drawing.Image)
        Me.BtnProv2.Location = New System.Drawing.Point(304, 190)
        Me.BtnProv2.Name = "BtnProv2"
        Me.BtnProv2.Size = New System.Drawing.Size(25, 24)
        Me.BtnProv2.TabIndex = 9
        Me.BtnProv2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(33, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Desde"
        '
        'TPROV2
        '
        Me.TPROV2.AcceptsReturn = True
        Me.TPROV2.AcceptsTab = True
        Me.TPROV2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROV2.Location = New System.Drawing.Point(235, 191)
        Me.TPROV2.Name = "TPROV2"
        Me.TPROV2.Size = New System.Drawing.Size(69, 21)
        Me.TPROV2.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(193, 194)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Hasta"
        '
        'ChDetalle
        '
        Me.ChDetalle.BackColor = System.Drawing.Color.Transparent
        Me.ChDetalle.BorderColor = System.Drawing.Color.Transparent
        Me.ChDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChDetalle.ForeColor = System.Drawing.Color.Black
        Me.ChDetalle.Location = New System.Drawing.Point(28, 265)
        Me.ChDetalle.Name = "ChDetalle"
        Me.ChDetalle.Padding = New System.Windows.Forms.Padding(1)
        Me.ChDetalle.Size = New System.Drawing.Size(154, 24)
        Me.ChDetalle.TabIndex = 3
        Me.ChDetalle.Text = "Detalle"
        Me.ChDetalle.UseVisualStyleBackColor = True
        Me.ChDetalle.Value = Nothing
        Me.ChDetalle.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "AntiSaldosClie"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CLIENTE, Me.NOMBRE, Me.IMPORTE, Me.SALDO, Me.ABONOS, Me.NDIAS30, Me.NDIAS60, Me.NDIAS90, Me.NDIASMAYOR90, Me.CLASIFIC, Me.FECHA1, Me.FECHA_APLI, Me.REFER, Me.CLIENTE1, Me.CLIENTE2, Me.DEL_AL, Me.CLIE_PROV, Me.DIASCRED, Me.FECHA_VENC, Me.NDIAS, Me.SU_REFER})
        Me.DataTable1.TableName = "Table1"
        '
        'CLIENTE
        '
        Me.CLIENTE.ColumnName = "CLIENTE"
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        '
        'IMPORTE
        '
        Me.IMPORTE.ColumnName = "IMPORTE"
        Me.IMPORTE.DataType = GetType(Decimal)
        '
        'SALDO
        '
        Me.SALDO.ColumnName = "SALDO"
        Me.SALDO.DataType = GetType(Decimal)
        '
        'ABONOS
        '
        Me.ABONOS.ColumnName = "ABONOS"
        Me.ABONOS.DataType = GetType(Decimal)
        '
        'NDIAS30
        '
        Me.NDIAS30.ColumnName = "NDIAS30"
        Me.NDIAS30.DataType = GetType(Decimal)
        '
        'NDIAS60
        '
        Me.NDIAS60.ColumnName = "NDIAS60"
        Me.NDIAS60.DataType = GetType(Decimal)
        '
        'NDIAS90
        '
        Me.NDIAS90.ColumnName = "NDIAS90"
        Me.NDIAS90.DataType = GetType(Decimal)
        '
        'NDIASMAYOR90
        '
        Me.NDIASMAYOR90.ColumnName = "NDIASMAYOR90"
        Me.NDIASMAYOR90.DataType = GetType(Decimal)
        '
        'CLASIFIC
        '
        Me.CLASIFIC.ColumnName = "CLASIFIC"
        '
        'FECHA1
        '
        Me.FECHA1.ColumnName = "FECHA1"
        Me.FECHA1.DataType = GetType(Date)
        '
        'FECHA_APLI
        '
        Me.FECHA_APLI.ColumnName = "FECHA_APLI"
        Me.FECHA_APLI.DataType = GetType(Date)
        '
        'REFER
        '
        Me.REFER.ColumnName = "REFER"
        '
        'CLIENTE1
        '
        Me.CLIENTE1.ColumnName = "CLIENTE1"
        '
        'CLIENTE2
        '
        Me.CLIENTE2.ColumnName = "CLIENTE2"
        '
        'DEL_AL
        '
        Me.DEL_AL.ColumnName = "DEL_AL"
        '
        'CLIE_PROV
        '
        Me.CLIE_PROV.ColumnName = "CLIE_PROV"
        '
        'DIASCRED
        '
        Me.DIASCRED.ColumnName = "DIASCRED"
        Me.DIASCRED.DataType = GetType(Short)
        '
        'FECHA_VENC
        '
        Me.FECHA_VENC.ColumnName = "FECHA_VENC"
        Me.FECHA_VENC.DataType = GetType(Date)
        '
        'NDIAS
        '
        Me.NDIAS.ColumnName = "NDIAS"
        Me.NDIAS.DataType = GetType(Short)
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "354b71f22efd467bae2f1e05428a6200"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'SU_REFER
        '
        Me.SU_REFER.ColumnName = "SU_REFER"
        '
        'FrmAntiguedadSaldosProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 323)
        Me.Controls.Add(Me.ChDetalle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnProv1)
        Me.Controls.Add(Me.TPROV1)
        Me.Controls.Add(Me.BtnProv2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TPROV2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAntiguedadSaldosProv"
        Me.ShowInTaskbar = False
        Me.Text = "Antiguedad de saldos de proveedores"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñador As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDiseñador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label4 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnProv1 As Button
    Friend WithEvents TPROV1 As TextBox
    Friend WithEvents BtnProv2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TPROV2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ChDetalle As C1.Win.C1Input.C1CheckBox
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents CLIENTE As DataColumn
    Friend WithEvents NOMBRE As DataColumn
    Friend WithEvents IMPORTE As DataColumn
    Friend WithEvents SALDO As DataColumn
    Friend WithEvents ABONOS As DataColumn
    Friend WithEvents NDIAS30 As DataColumn
    Friend WithEvents NDIAS60 As DataColumn
    Friend WithEvents NDIAS90 As DataColumn
    Friend WithEvents NDIASMAYOR90 As DataColumn
    Friend WithEvents CLASIFIC As DataColumn
    Friend WithEvents FECHA1 As DataColumn
    Friend WithEvents FECHA_APLI As DataColumn
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents REFER As DataColumn
    Friend WithEvents CLIENTE1 As DataColumn
    Friend WithEvents CLIENTE2 As DataColumn
    Friend WithEvents DEL_AL As DataColumn
    Friend WithEvents CLIE_PROV As DataColumn
    Friend WithEvents DIASCRED As DataColumn
    Friend WithEvents FECHA_VENC As DataColumn
    Friend WithEvents NDIAS As DataColumn
    Friend WithEvents SU_REFER As DataColumn
End Class
