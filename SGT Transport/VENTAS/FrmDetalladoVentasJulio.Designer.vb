<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDetalladoVentasJulio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalladoVentasJulio))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadFechaTimbre = New System.Windows.Forms.RadioButton()
        Me.RadFechaCarga = New System.Windows.Forms.RadioButton()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadVentasOtro = New System.Windows.Forms.RadioButton()
        Me.RadVentasFlete = New System.Windows.Forms.RadioButton()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.FACTURA = New System.Data.DataColumn()
        Me.DOCUMENT = New System.Data.DataColumn()
        Me.CLAVE = New System.Data.DataColumn()
        Me.NOMBRE = New System.Data.DataColumn()
        Me.SUBTOTAL = New System.Data.DataColumn()
        Me.IVA = New System.Data.DataColumn()
        Me.IMPORTE = New System.Data.DataColumn()
        Me.FEC1 = New System.Data.DataColumn()
        Me.FEC2 = New System.Data.DataColumn()
        Me.FECHA = New System.Data.DataColumn()
        Me.RETENCION = New System.Data.DataColumn()
        Me.TITULO = New System.Data.DataColumn()
        Me.RadTodos = New System.Windows.Forms.RadioButton()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarActualizar)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.ShowShortcut = False
        Me.BarDesplegar.ShowTextAsToolTip = False
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
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
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.refresh
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkActualizar, Me.LkImprimir, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1080, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        Me.LkDesplegar.ToolTipText = "Nuevo servicio"
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.SortOrder = 1
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.SortOrder = 2
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 3
        Me.LkExcel.Text = "Excel"
        Me.LkExcel.ToolTipText = ""
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
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(12, 109)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 10
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(721, 323)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 28
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(667, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(241, 37)
        Me.C1FlexGridSearchPanel1.TabIndex = 30
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'LtNUm
        '
        Me.LtNUm.AutoSize = True
        Me.LtNUm.Location = New System.Drawing.Point(954, 70)
        Me.LtNUm.Name = "LtNUm"
        Me.LtNUm.Size = New System.Drawing.Size(157, 13)
        Me.LtNUm.TabIndex = 32
        Me.LtNUm.Text = "_________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadFechaTimbre)
        Me.GroupBox1.Controls.Add(Me.RadFechaCarga)
        Me.GroupBox1.Controls.Add(Me.F2)
        Me.GroupBox1.Controls.Add(Me.F1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 53)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'RadFechaTimbre
        '
        Me.RadFechaTimbre.AutoSize = True
        Me.RadFechaTimbre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechaTimbre.Location = New System.Drawing.Point(125, 19)
        Me.RadFechaTimbre.Name = "RadFechaTimbre"
        Me.RadFechaTimbre.Size = New System.Drawing.Size(124, 21)
        Me.RadFechaTimbre.TabIndex = 342
        Me.RadFechaTimbre.Text = "Fecha timbrado"
        Me.RadFechaTimbre.UseVisualStyleBackColor = True
        '
        'RadFechaCarga
        '
        Me.RadFechaCarga.AutoSize = True
        Me.RadFechaCarga.Checked = True
        Me.RadFechaCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechaCarga.Location = New System.Drawing.Point(6, 19)
        Me.RadFechaCarga.Name = "RadFechaCarga"
        Me.RadFechaCarga.Size = New System.Drawing.Size(105, 21)
        Me.RadFechaCarga.TabIndex = 343
        Me.RadFechaCarga.TabStop = True
        Me.RadFechaCarga.Text = "Fecha carga"
        Me.RadFechaCarga.UseVisualStyleBackColor = True
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(396, 28)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 21)
        Me.F2.TabIndex = 171
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(268, 28)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 170
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(400, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 17)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "al"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(265, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Del"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "f16a9097e9ab4b068a4d35fdac02e725"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadTodos)
        Me.GroupBox2.Controls.Add(Me.RadVentasOtro)
        Me.GroupBox2.Controls.Add(Me.RadVentasFlete)
        Me.GroupBox2.Location = New System.Drawing.Point(581, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(353, 53)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'RadVentasOtro
        '
        Me.RadVentasOtro.AutoSize = True
        Me.RadVentasOtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadVentasOtro.Location = New System.Drawing.Point(128, 19)
        Me.RadVentasOtro.Name = "RadVentasOtro"
        Me.RadVentasOtro.Size = New System.Drawing.Size(99, 21)
        Me.RadVentasOtro.TabIndex = 344
        Me.RadVentasOtro.Text = "Ventas otro"
        Me.RadVentasOtro.UseVisualStyleBackColor = True
        '
        'RadVentasFlete
        '
        Me.RadVentasFlete.AutoSize = True
        Me.RadVentasFlete.Checked = True
        Me.RadVentasFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadVentasFlete.Location = New System.Drawing.Point(9, 19)
        Me.RadVentasFlete.Name = "RadVentasFlete"
        Me.RadVentasFlete.Size = New System.Drawing.Size(101, 21)
        Me.RadVentasFlete.TabIndex = 345
        Me.RadVentasFlete.TabStop = True
        Me.RadVentasFlete.Text = "Ventas flete"
        Me.RadVentasFlete.UseVisualStyleBackColor = True
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.FACTURA, Me.DOCUMENT, Me.CLAVE, Me.NOMBRE, Me.SUBTOTAL, Me.IVA, Me.IMPORTE, Me.FEC1, Me.FEC2, Me.FECHA, Me.RETENCION, Me.TITULO})
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
        'CLAVE
        '
        Me.CLAVE.ColumnName = "CLAVE"
        Me.CLAVE.DefaultValue = ""
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        Me.NOMBRE.DefaultValue = ""
        '
        'SUBTOTAL
        '
        Me.SUBTOTAL.ColumnName = "SUBTOTAL"
        Me.SUBTOTAL.DataType = GetType(Decimal)
        '
        'IVA
        '
        Me.IVA.ColumnName = "IVA"
        Me.IVA.DataType = GetType(Decimal)
        '
        'IMPORTE
        '
        Me.IMPORTE.ColumnName = "IMPORTE"
        Me.IMPORTE.DataType = GetType(Decimal)
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
        'FECHA
        '
        Me.FECHA.ColumnName = "FECHA"
        Me.FECHA.DataType = GetType(Date)
        '
        'RETENCION
        '
        Me.RETENCION.ColumnName = "RETENCION"
        '
        'TITULO
        '
        Me.TITULO.ColumnName = "TITULO"
        '
        'RadTodos
        '
        Me.RadTodos.AutoSize = True
        Me.RadTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTodos.Location = New System.Drawing.Point(248, 19)
        Me.RadTodos.Name = "RadTodos"
        Me.RadTodos.Size = New System.Drawing.Size(66, 21)
        Me.RadTodos.TabIndex = 346
        Me.RadTodos.Text = "Todos"
        Me.RadTodos.UseVisualStyleBackColor = True
        '
        'FrmDetalladoVentasJulio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 467)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LtNUm)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDetalladoVentasJulio"
        Me.Text = "Detallado de compras"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Private WithEvents BarExcel As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents LtNUm As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents RadFechaCarga As RadioButton
    Friend WithEvents RadFechaTimbre As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadVentasOtro As RadioButton
    Friend WithEvents RadVentasFlete As RadioButton
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents FACTURA As DataColumn
    Friend WithEvents DOCUMENT As DataColumn
    Friend WithEvents CLAVE As DataColumn
    Friend WithEvents NOMBRE As DataColumn
    Friend WithEvents SUBTOTAL As DataColumn
    Friend WithEvents IVA As DataColumn
    Friend WithEvents IMPORTE As DataColumn
    Friend WithEvents FEC1 As DataColumn
    Friend WithEvents FEC2 As DataColumn
    Friend WithEvents FECHA As DataColumn
    Friend WithEvents RETENCION As DataColumn
    Friend WithEvents TITULO As DataColumn
    Friend WithEvents RadTodos As RadioButton
End Class
