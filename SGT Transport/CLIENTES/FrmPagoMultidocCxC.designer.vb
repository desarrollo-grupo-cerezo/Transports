<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagoMultidocCxC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoMultidocCxC))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnClie = New C1.Win.C1Input.C1Button()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnDocto = New C1.Win.C1Input.C1Button()
        Me.TDOCTO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TMagico = New System.Windows.Forms.TextBox()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.FECHA_DEP = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtConc = New System.Windows.Forms.Label()
        Me.BtnConc = New C1.Win.C1Input.C1Button()
        Me.TNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TIMPORTE = New C1.Win.C1Input.C1TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT = New C1.Win.C1Input.C1TextBox()
        Me.TXTN = New C1.Win.C1Input.C1NumericEdit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDocto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FECHA_DEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnConc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit) _
            Or C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys) _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(10, 226)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.DefaultSize = 24
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(664, 268)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 5
        '
        'BarraMenu
        '
        Me.BarraMenu.AutoSize = False
        Me.BarraMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.BarraMenu.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarEliminar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.BarraMenu.Size = New System.Drawing.Size(686, 60)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 8
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarGrabar.ShortcutKeyDisplayString = ""
        Me.BarGrabar.ShowShortcutKeys = False
        Me.BarGrabar.Size = New System.Drawing.Size(54, 52)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarGrabar.ToolTipText = "F2-Nuevo"
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.Size = New System.Drawing.Size(102, 52)
        Me.BarEliminar.Text = "Eliminar partida"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 52)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnClie
        '
        Me.BtnClie.AutoSize = True
        Me.BtnClie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClie.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnClie.Location = New System.Drawing.Point(201, 74)
        Me.BtnClie.Name = "BtnClie"
        Me.BtnClie.Size = New System.Drawing.Size(22, 22)
        Me.BtnClie.TabIndex = 8
        Me.BtnClie.UseVisualStyleBackColor = True
        Me.BtnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(110, 75)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(88, 22)
        Me.TCLIENTE.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(64, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 16)
        Me.Label14.TabIndex = 297
        Me.Label14.Text = "Clave"
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(291, 75)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(338, 20)
        Me.LtNombre.TabIndex = 300
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(233, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "Nombre"
        '
        'F1
        '
        Me.F1.AutoSize = False
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(110, 106)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(110, 22)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 301
        Me.Label3.Text = "Fecha"
        '
        'BtnDocto
        '
        Me.BtnDocto.AutoSize = True
        Me.BtnDocto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnDocto.Image = CType(resources.GetObject("BtnDocto.Image"), System.Drawing.Image)
        Me.BtnDocto.Location = New System.Drawing.Point(245, 198)
        Me.BtnDocto.Name = "BtnDocto"
        Me.BtnDocto.Size = New System.Drawing.Size(22, 22)
        Me.BtnDocto.TabIndex = 10
        Me.BtnDocto.UseVisualStyleBackColor = True
        Me.BtnDocto.Visible = False
        Me.BtnDocto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDOCTO
        '
        Me.TDOCTO.AcceptsReturn = True
        Me.TDOCTO.AcceptsTab = True
        Me.TDOCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDOCTO.Location = New System.Drawing.Point(110, 199)
        Me.TDOCTO.Name = "TDOCTO"
        Me.TDOCTO.Size = New System.Drawing.Size(132, 22)
        Me.TDOCTO.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 304
        Me.Label4.Text = "Folio bancario"
        '
        'TMagico
        '
        Me.TMagico.AcceptsReturn = True
        Me.TMagico.AcceptsTab = True
        Me.TMagico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMagico.Location = New System.Drawing.Point(748, 289)
        Me.TMagico.Name = "TMagico"
        Me.TMagico.Size = New System.Drawing.Size(57, 22)
        Me.TMagico.TabIndex = 8
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "ceda627063734c60b959d6fbcfcde1a8"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FECHA_DEP
        '
        Me.FECHA_DEP.AutoSize = False
        Me.FECHA_DEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FECHA_DEP.Calendar.ClearText = "&Limpiar"
        Me.FECHA_DEP.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FECHA_DEP.Calendar.TodayText = "&Hoy"
        Me.FECHA_DEP.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA_DEP.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA_DEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FECHA_DEP.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FECHA_DEP.Location = New System.Drawing.Point(341, 106)
        Me.FECHA_DEP.Name = "FECHA_DEP"
        Me.FECHA_DEP.Size = New System.Drawing.Size(110, 22)
        Me.FECHA_DEP.TabIndex = 2
        Me.FECHA_DEP.Tag = Nothing
        Me.FECHA_DEP.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FECHA_DEP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FECHA_DEP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(233, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "Fecha deposito"
        '
        'LtConc
        '
        Me.LtConc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtConc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtConc.Location = New System.Drawing.Point(236, 137)
        Me.LtConc.Name = "LtConc"
        Me.LtConc.Size = New System.Drawing.Size(338, 20)
        Me.LtConc.TabIndex = 363
        Me.LtConc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnConc
        '
        Me.BtnConc.AutoSize = True
        Me.BtnConc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnConc.Image = CType(resources.GetObject("BtnConc.Image"), System.Drawing.Image)
        Me.BtnConc.Location = New System.Drawing.Point(201, 136)
        Me.BtnConc.Name = "BtnConc"
        Me.BtnConc.Size = New System.Drawing.Size(22, 22)
        Me.BtnConc.TabIndex = 9
        Me.BtnConc.UseVisualStyleBackColor = True
        Me.BtnConc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TNUM_CPTO
        '
        Me.TNUM_CPTO.AcceptsReturn = True
        Me.TNUM_CPTO.AcceptsTab = True
        Me.TNUM_CPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_CPTO.Location = New System.Drawing.Point(110, 137)
        Me.TNUM_CPTO.Name = "TNUM_CPTO"
        Me.TNUM_CPTO.Size = New System.Drawing.Size(88, 22)
        Me.TNUM_CPTO.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 16)
        Me.Label6.TabIndex = 361
        Me.Label6.Text = "Concepto"
        '
        'TIMPORTE
        '
        Me.TIMPORTE.AcceptsReturn = True
        Me.TIMPORTE.AcceptsTab = True
        Me.TIMPORTE.AutoSize = False
        Me.TIMPORTE.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TIMPORTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIMPORTE.CustomFormat = "###,###,##0.00"
        Me.TIMPORTE.DataType = GetType(Decimal)
        Me.TIMPORTE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TIMPORTE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE.Location = New System.Drawing.Point(110, 168)
        Me.TIMPORTE.Name = "TIMPORTE"
        Me.TIMPORTE.ReadOnly = True
        Me.TIMPORTE.Size = New System.Drawing.Size(132, 22)
        Me.TIMPORTE.TabIndex = 373
        Me.TIMPORTE.Tag = Nothing
        Me.TIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 374
        Me.Label5.Text = "Importe"
        '
        'TXT
        '
        Me.TXT.BackColor = System.Drawing.Color.PaleTurquoise
        Me.TXT.BorderColor = System.Drawing.Color.Black
        Me.TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT.Location = New System.Drawing.Point(729, 182)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(127, 19)
        Me.TXT.TabIndex = 6
        Me.TXT.Tag = Nothing
        Me.TXT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TXTN
        '
        Me.TXTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TXTN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.CustomFormat = "###,###,###,##0.000000"
        Me.TXTN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TXTN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TXTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTN.ImagePadding = New System.Windows.Forms.Padding(45, 0, 0, 0)
        Me.TXTN.Location = New System.Drawing.Point(748, 227)
        Me.TXTN.Name = "TXTN"
        Me.TXTN.Size = New System.Drawing.Size(88, 19)
        Me.TXTN.TabIndex = 7
        Me.TXTN.Tag = Nothing
        Me.TXTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTN.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TXTN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TXTN.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmPagoMultidocCxC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(686, 509)
        Me.Controls.Add(Me.TXTN)
        Me.Controls.Add(Me.TXT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TIMPORTE)
        Me.Controls.Add(Me.LtConc)
        Me.Controls.Add(Me.BtnConc)
        Me.Controls.Add(Me.TNUM_CPTO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FECHA_DEP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TMagico)
        Me.Controls.Add(Me.BtnDocto)
        Me.Controls.Add(Me.TDOCTO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClie)
        Me.Controls.Add(Me.TCLIENTE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagoMultidocCxC"
        Me.ShowInTaskbar = False
        Me.Text = "Recepción de pagos multidocumento CxC"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDocto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FECHA_DEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnConc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents BtnClie As C1.Win.C1Input.C1Button
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnDocto As C1.Win.C1Input.C1Button
    Friend WithEvents TDOCTO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TMagico As TextBox
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents FECHA_DEP As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents LtConc As Label
    Friend WithEvents BtnConc As C1.Win.C1Input.C1Button
    Friend WithEvents TNUM_CPTO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TIMPORTE As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT As C1.Win.C1Input.C1TextBox
    Friend WithEvents TXTN As C1.Win.C1Input.C1NumericEdit
End Class
