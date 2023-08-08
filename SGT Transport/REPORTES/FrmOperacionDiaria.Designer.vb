<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperacionDiaria
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOperacionDiaria))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.TDIAS_MES1 = New C1.Win.C1Input.C1TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TDIAS_TRABAJADOS1 = New C1.Win.C1Input.C1TextBox()
        Me.TDIAS_MESP = New C1.Win.C1Input.C1TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TDIAS_TRABAJADOSP = New C1.Win.C1Input.C1TextBox()
        Me.TINGRESO_DIARIOP = New C1.Win.C1Input.C1TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TINGRESO_ACUMULADOP = New C1.Win.C1Input.C1TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TUNIDADES_MESP = New C1.Win.C1Input.C1TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TUNIDADES_DIAP = New C1.Win.C1Input.C1TextBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDIAS_MES1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDIAS_TRABAJADOS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDIAS_MESP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDIAS_TRABAJADOSP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TINGRESO_DIARIOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TINGRESO_ACUMULADOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TUNIDADES_MESP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TUNIDADES_DIAP, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(451, 43)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(182, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Rango de fechas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 185
        Me.Label2.Text = "al"
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
        Me.F2.Location = New System.Drawing.Point(275, 93)
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
        Me.Label1.Location = New System.Drawing.Point(59, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Del"
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
        Me.F1.Location = New System.Drawing.Point(93, 93)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
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
        Me.StiReport1.ReportGuid = "ae2d1ef6389e4f95b938d7a27cf17317"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'TDIAS_MES1
        '
        Me.TDIAS_MES1.AcceptsReturn = True
        Me.TDIAS_MES1.AcceptsTab = True
        Me.TDIAS_MES1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAS_MES1.CustomFormat = "###,###,##0"
        Me.TDIAS_MES1.DataType = GetType(Decimal)
        Me.TDIAS_MES1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_MES1.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_MES1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_MES1.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_MES1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAS_MES1.Location = New System.Drawing.Point(117, 197)
        Me.TDIAS_MES1.Name = "TDIAS_MES1"
        Me.TDIAS_MES1.Size = New System.Drawing.Size(40, 20)
        Me.TDIAS_MES1.TabIndex = 3
        Me.TDIAS_MES1.Tag = Nothing
        Me.TDIAS_MES1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDIAS_MES1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDIAS_MES1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 16)
        Me.Label10.TabIndex = 603
        Me.Label10.Text = "Días del mes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 16)
        Me.Label8.TabIndex = 604
        Me.Label8.Text = "Dias trabajados"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TDIAS_TRABAJADOS1
        '
        Me.TDIAS_TRABAJADOS1.AcceptsReturn = True
        Me.TDIAS_TRABAJADOS1.AcceptsTab = True
        Me.TDIAS_TRABAJADOS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAS_TRABAJADOS1.CustomFormat = "###,###,##0"
        Me.TDIAS_TRABAJADOS1.DataType = GetType(Decimal)
        Me.TDIAS_TRABAJADOS1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_TRABAJADOS1.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_TRABAJADOS1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_TRABAJADOS1.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_TRABAJADOS1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAS_TRABAJADOS1.Location = New System.Drawing.Point(117, 171)
        Me.TDIAS_TRABAJADOS1.Name = "TDIAS_TRABAJADOS1"
        Me.TDIAS_TRABAJADOS1.Size = New System.Drawing.Size(40, 20)
        Me.TDIAS_TRABAJADOS1.TabIndex = 2
        Me.TDIAS_TRABAJADOS1.Tag = Nothing
        Me.TDIAS_TRABAJADOS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDIAS_TRABAJADOS1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDIAS_TRABAJADOS1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDIAS_MESP
        '
        Me.TDIAS_MESP.AcceptsReturn = True
        Me.TDIAS_MESP.AcceptsTab = True
        Me.TDIAS_MESP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAS_MESP.CustomFormat = "###,###,##0"
        Me.TDIAS_MESP.DataType = GetType(Decimal)
        Me.TDIAS_MESP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_MESP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_MESP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_MESP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_MESP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAS_MESP.Location = New System.Drawing.Point(303, 199)
        Me.TDIAS_MESP.Name = "TDIAS_MESP"
        Me.TDIAS_MESP.Size = New System.Drawing.Size(40, 20)
        Me.TDIAS_MESP.TabIndex = 5
        Me.TDIAS_MESP.Tag = Nothing
        Me.TDIAS_MESP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDIAS_MESP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDIAS_MESP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 607
        Me.Label4.Text = "Días del mes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(194, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 608
        Me.Label5.Text = "Dias trabajados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TDIAS_TRABAJADOSP
        '
        Me.TDIAS_TRABAJADOSP.AcceptsReturn = True
        Me.TDIAS_TRABAJADOSP.AcceptsTab = True
        Me.TDIAS_TRABAJADOSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDIAS_TRABAJADOSP.CustomFormat = "###,###,##0"
        Me.TDIAS_TRABAJADOSP.DataType = GetType(Decimal)
        Me.TDIAS_TRABAJADOSP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_TRABAJADOSP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_TRABAJADOSP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDIAS_TRABAJADOSP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDIAS_TRABAJADOSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDIAS_TRABAJADOSP.Location = New System.Drawing.Point(303, 172)
        Me.TDIAS_TRABAJADOSP.Name = "TDIAS_TRABAJADOSP"
        Me.TDIAS_TRABAJADOSP.Size = New System.Drawing.Size(40, 20)
        Me.TDIAS_TRABAJADOSP.TabIndex = 4
        Me.TDIAS_TRABAJADOSP.Tag = Nothing
        Me.TDIAS_TRABAJADOSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDIAS_TRABAJADOSP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDIAS_TRABAJADOSP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TINGRESO_DIARIOP
        '
        Me.TINGRESO_DIARIOP.AcceptsReturn = True
        Me.TINGRESO_DIARIOP.AcceptsTab = True
        Me.TINGRESO_DIARIOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TINGRESO_DIARIOP.CustomFormat = "###,###,##0"
        Me.TINGRESO_DIARIOP.DataType = GetType(Decimal)
        Me.TINGRESO_DIARIOP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TINGRESO_DIARIOP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TINGRESO_DIARIOP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TINGRESO_DIARIOP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TINGRESO_DIARIOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TINGRESO_DIARIOP.Location = New System.Drawing.Point(303, 280)
        Me.TINGRESO_DIARIOP.Name = "TINGRESO_DIARIOP"
        Me.TINGRESO_DIARIOP.Size = New System.Drawing.Size(119, 20)
        Me.TINGRESO_DIARIOP.TabIndex = 8
        Me.TINGRESO_DIARIOP.Tag = Nothing
        Me.TINGRESO_DIARIOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TINGRESO_DIARIOP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TINGRESO_DIARIOP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(208, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 610
        Me.Label6.Text = "Ingreso diario"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TINGRESO_ACUMULADOP
        '
        Me.TINGRESO_ACUMULADOP.AcceptsReturn = True
        Me.TINGRESO_ACUMULADOP.AcceptsTab = True
        Me.TINGRESO_ACUMULADOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TINGRESO_ACUMULADOP.CustomFormat = "###,###,##0"
        Me.TINGRESO_ACUMULADOP.DataType = GetType(Decimal)
        Me.TINGRESO_ACUMULADOP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TINGRESO_ACUMULADOP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TINGRESO_ACUMULADOP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TINGRESO_ACUMULADOP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TINGRESO_ACUMULADOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TINGRESO_ACUMULADOP.Location = New System.Drawing.Point(303, 307)
        Me.TINGRESO_ACUMULADOP.Name = "TINGRESO_ACUMULADOP"
        Me.TINGRESO_ACUMULADOP.Size = New System.Drawing.Size(119, 20)
        Me.TINGRESO_ACUMULADOP.TabIndex = 9
        Me.TINGRESO_ACUMULADOP.Tag = Nothing
        Me.TINGRESO_ACUMULADOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TINGRESO_ACUMULADOP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TINGRESO_ACUMULADOP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(175, 308)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 16)
        Me.Label7.TabIndex = 612
        Me.Label7.Text = "Ingreso acumulado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(214, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 16)
        Me.Label9.TabIndex = 613
        Me.Label9.Text = "Presupuesto"
        '
        'TUNIDADES_MESP
        '
        Me.TUNIDADES_MESP.AcceptsReturn = True
        Me.TUNIDADES_MESP.AcceptsTab = True
        Me.TUNIDADES_MESP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUNIDADES_MESP.CustomFormat = "###,###,##0"
        Me.TUNIDADES_MESP.DataType = GetType(Decimal)
        Me.TUNIDADES_MESP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TUNIDADES_MESP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TUNIDADES_MESP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TUNIDADES_MESP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TUNIDADES_MESP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUNIDADES_MESP.Location = New System.Drawing.Point(303, 253)
        Me.TUNIDADES_MESP.Name = "TUNIDADES_MESP"
        Me.TUNIDADES_MESP.Size = New System.Drawing.Size(40, 20)
        Me.TUNIDADES_MESP.TabIndex = 7
        Me.TUNIDADES_MESP.Tag = Nothing
        Me.TUNIDADES_MESP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TUNIDADES_MESP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TUNIDADES_MESP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(202, 255)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 16)
        Me.Label11.TabIndex = 616
        Me.Label11.Text = "Unidades mes"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(209, 228)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 617
        Me.Label12.Text = "Unidades dia"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TUNIDADES_DIAP
        '
        Me.TUNIDADES_DIAP.AcceptsReturn = True
        Me.TUNIDADES_DIAP.AcceptsTab = True
        Me.TUNIDADES_DIAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUNIDADES_DIAP.CustomFormat = "###,###,##0"
        Me.TUNIDADES_DIAP.DataType = GetType(Decimal)
        Me.TUNIDADES_DIAP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TUNIDADES_DIAP.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TUNIDADES_DIAP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TUNIDADES_DIAP.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TUNIDADES_DIAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUNIDADES_DIAP.Location = New System.Drawing.Point(303, 226)
        Me.TUNIDADES_DIAP.Name = "TUNIDADES_DIAP"
        Me.TUNIDADES_DIAP.Size = New System.Drawing.Size(40, 20)
        Me.TUNIDADES_DIAP.TabIndex = 6
        Me.TUNIDADES_DIAP.Tag = Nothing
        Me.TUNIDADES_DIAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TUNIDADES_DIAP.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TUNIDADES_DIAP.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmOperacionDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 358)
        Me.Controls.Add(Me.TUNIDADES_MESP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TUNIDADES_DIAP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TINGRESO_ACUMULADOP)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TINGRESO_DIARIOP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TDIAS_MESP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TDIAS_TRABAJADOSP)
        Me.Controls.Add(Me.TDIAS_MES1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TDIAS_TRABAJADOS1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOperacionDiaria"
        Me.Text = "Reporte gerencial de operación"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDIAS_MES1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDIAS_TRABAJADOS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDIAS_MESP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDIAS_TRABAJADOSP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TINGRESO_DIARIOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TINGRESO_ACUMULADOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TUNIDADES_MESP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TUNIDADES_DIAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents TDIAS_MES1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TDIAS_TRABAJADOS1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents TDIAS_MESP As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TDIAS_TRABAJADOSP As C1.Win.C1Input.C1TextBox
    Friend WithEvents TINGRESO_ACUMULADOP As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TINGRESO_DIARIOP As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TUNIDADES_MESP As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TUNIDADES_DIAP As C1.Win.C1Input.C1TextBox
End Class
