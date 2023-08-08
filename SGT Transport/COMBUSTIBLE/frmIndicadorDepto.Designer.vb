<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIndicadorDepto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIndicadorDepto))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.RadCalifOper = New System.Windows.Forms.RadioButton()
        Me.RadMotor = New System.Windows.Forms.RadioButton()
        Me.RadRendiFull = New System.Windows.Forms.RadioButton()
        Me.RadRendiSencillo = New System.Windows.Forms.RadioButton()
        Me.RadPTORalenti = New System.Windows.Forms.RadioButton()
        Me.RadRendXMotorFull = New System.Windows.Forms.RadioButton()
        Me.RadRendiGlobal = New System.Windows.Forms.RadioButton()
        Me.RadLtsDesconXOper = New System.Windows.Forms.RadioButton()
        Me.RadRendXUnidad = New System.Windows.Forms.RadioButton()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.tPORC_TOL = New System.Windows.Forms.TextBox()
        Me.L4 = New System.Windows.Forms.Label()
        Me.tPRECIO_DIESEL = New System.Windows.Forms.TextBox()
        Me.L5 = New System.Windows.Forms.Label()
        Me.RadPorcVarDiesel = New System.Windows.Forms.RadioButton()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.KMS_TAB = New System.Data.DataColumn()
        Me.NOMBRE_OPER = New System.Data.DataColumn()
        Me.VIAJES = New System.Data.DataColumn()
        Me.UNIDADES = New System.Data.DataColumn()
        Me.KMSECM = New System.Data.DataColumn()
        Me.LTSECM = New System.Data.DataColumn()
        Me.REND_ECM = New System.Data.DataColumn()
        Me.LTSREAL = New System.Data.DataColumn()
        Me.REND_REAL = New System.Data.DataColumn()
        Me.LTSTAB = New System.Data.DataColumn()
        Me.REND_TAB = New System.Data.DataColumn()
        Me.VAR_LTS_REAL_VS_LTS_ECM = New System.Data.DataColumn()
        Me.VAR_LTS_REAL_VS_LTS_TAB = New System.Data.DataColumn()
        Me.P_VAR_LTS_REAL_VS_LTS_ECM = New System.Data.DataColumn()
        Me.P_VAR_LTS_AUTO_VS_LTS_ECM = New System.Data.DataColumn()
        Me.LTS_DESCONTAR = New System.Data.DataColumn()
        Me.P_RALENTI = New System.Data.DataColumn()
        Me.FAC_CARGA1 = New System.Data.DataColumn()
        Me.FAC_CARGA2 = New System.Data.DataColumn()
        Me.CALIF_FC = New System.Data.DataColumn()
        Me.CALIF_RAL = New System.Data.DataColumn()
        Me.SUM_GLOBAL_GLO_EVA = New System.Data.DataColumn()
        Me.SUM_BONO_RES = New System.Data.DataColumn()
        Me.LTSAUTO = New System.Data.DataColumn()
        Me.P_VAR_LTS_REAL_VS_LTS_TAB = New System.Data.DataColumn()
        Me.FECHA1 = New System.Data.DataColumn()
        Me.FECHA2 = New System.Data.DataColumn()
        Me.LTS_AUTORIZADOS2 = New System.Data.DataColumn()
        Me.LTS_DESCONTAR2 = New System.Data.DataColumn()
        Me.EVENTO = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.LTS_PTO_RALENTI = New System.Data.DataColumn()
        Me.HRS_PTO_RALENTI = New System.Data.DataColumn()
        Me.HRS_TRABAJO = New System.Data.DataColumn()
        Me.PRECIO_X_LTS = New System.Data.DataColumn()
        Me.PRECIO_X_LTS2 = New System.Data.DataColumn()
        Me.PORC_TOL_EVENTO2 = New System.Data.DataColumn()
        Me.DESCXLITROS2 = New System.Data.DataColumn()
        Me.CVE_EVA = New System.Data.DataColumn()
        Me.DataSet2 = New System.Data.DataSet()
        Me.DataTable2 = New System.Data.DataTable()
        Me.VIAJES2 = New System.Data.DataColumn()
        Me.KMSECM2 = New System.Data.DataColumn()
        Me.LTSECM2 = New System.Data.DataColumn()
        Me.LTSREAL2 = New System.Data.DataColumn()
        Me.REND_ECM2 = New System.Data.DataColumn()
        Me.REND_REAL2 = New System.Data.DataColumn()
        Me.P_VAR_LTS_REAL_VS_LTS_ECM2 = New System.Data.DataColumn()
        Me.P_RALENTI2 = New System.Data.DataColumn()
        Me.MARCA2 = New System.Data.DataColumn()
        Me.DESCR_MOTOR2 = New System.Data.DataColumn()
        Me.NOMBRE_MOTOR2 = New System.Data.DataColumn()
        Me.T_VIAJE2 = New System.Data.DataColumn()
        Me.LTSPTO2 = New System.Data.DataColumn()
        Me.FEC1 = New System.Data.DataColumn()
        Me.FEC2 = New System.Data.DataColumn()
        Me.TIPO_VIAJE = New System.Data.DataColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadFull_Sencillo = New System.Windows.Forms.RadioButton()
        Me.RadSencillo = New System.Windows.Forms.RadioButton()
        Me.RadFull = New System.Windows.Forms.RadioButton()
        Me.PnlEventos = New System.Windows.Forms.Panel()
        Me.RadEvento2 = New System.Windows.Forms.RadioButton()
        Me.RadEvento1 = New System.Windows.Forms.RadioButton()
        Me.RadBonoPorTab = New System.Windows.Forms.RadioButton()
        Me.PnlSubEvento2 = New System.Windows.Forms.Panel()
        Me.RadLtsTab = New System.Windows.Forms.RadioButton()
        Me.RadLtsECM = New System.Windows.Forms.RadioButton()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.RadAnalisisRutas = New System.Windows.Forms.RadioButton()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PnlEventos.SuspendLayout()
        Me.PnlSubEvento2.SuspendLayout()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.traza4
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.ShowShortcut = False
        Me.BarDesplegar.ShowTextAsToolTip = False
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkExcel, Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1472, 41)
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
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 1
        Me.LkExcel.Text = "Excel"
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 2
        Me.LkImprimir.Text = "Imprimir"
        Me.LkImprimir.ToolTipText = "Imprimir"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 3
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(34, 19)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(322, 134)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 320
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(24, 15)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(155, 113)
        Me.Panel1.TabIndex = 319
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Rango de fechas"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(43, 43)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 306
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(43, 74)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 308
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 15)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(882, 1)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(279, 38)
        Me.C1FlexGridSearchPanel1.TabIndex = 327
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'RadCalifOper
        '
        Me.RadCalifOper.AutoSize = True
        Me.RadCalifOper.Location = New System.Drawing.Point(196, 13)
        Me.RadCalifOper.Name = "RadCalifOper"
        Me.RadCalifOper.Size = New System.Drawing.Size(123, 17)
        Me.RadCalifOper.TabIndex = 342
        Me.RadCalifOper.TabStop = True
        Me.RadCalifOper.Text = "Bono por evaluación"
        Me.RadCalifOper.UseVisualStyleBackColor = True
        '
        'RadMotor
        '
        Me.RadMotor.AutoSize = True
        Me.RadMotor.Location = New System.Drawing.Point(364, 17)
        Me.RadMotor.Name = "RadMotor"
        Me.RadMotor.Size = New System.Drawing.Size(131, 17)
        Me.RadMotor.TabIndex = 343
        Me.RadMotor.TabStop = True
        Me.RadMotor.Text = "Rendimiento por motor"
        Me.RadMotor.UseVisualStyleBackColor = True
        '
        'RadRendiFull
        '
        Me.RadRendiFull.AutoSize = True
        Me.RadRendiFull.Location = New System.Drawing.Point(632, 8)
        Me.RadRendiFull.Name = "RadRendiFull"
        Me.RadRendiFull.Size = New System.Drawing.Size(152, 17)
        Me.RadRendiFull.TabIndex = 344
        Me.RadRendiFull.TabStop = True
        Me.RadRendiFull.Text = "Rendimiento por operación"
        Me.RadRendiFull.UseVisualStyleBackColor = True
        '
        'RadRendiSencillo
        '
        Me.RadRendiSencillo.AutoSize = True
        Me.RadRendiSencillo.Location = New System.Drawing.Point(1251, 154)
        Me.RadRendiSencillo.Name = "RadRendiSencillo"
        Me.RadRendiSencillo.Size = New System.Drawing.Size(122, 17)
        Me.RadRendiSencillo.TabIndex = 345
        Me.RadRendiSencillo.TabStop = True
        Me.RadRendiSencillo.Text = "Rendimiento sencillo"
        Me.RadRendiSencillo.UseVisualStyleBackColor = True
        Me.RadRendiSencillo.Visible = False
        '
        'RadPTORalenti
        '
        Me.RadPTORalenti.AutoSize = True
        Me.RadPTORalenti.Location = New System.Drawing.Point(364, 67)
        Me.RadPTORalenti.Name = "RadPTORalenti"
        Me.RadPTORalenti.Size = New System.Drawing.Size(91, 17)
        Me.RadPTORalenti.TabIndex = 348
        Me.RadPTORalenti.TabStop = True
        Me.RadPTORalenti.Text = "PTO y Ralenti"
        Me.RadPTORalenti.UseVisualStyleBackColor = True
        '
        'RadRendXMotorFull
        '
        Me.RadRendXMotorFull.AutoSize = True
        Me.RadRendXMotorFull.Location = New System.Drawing.Point(364, 42)
        Me.RadRendXMotorFull.Name = "RadRendXMotorFull"
        Me.RadRendXMotorFull.Size = New System.Drawing.Size(152, 17)
        Me.RadRendXMotorFull.TabIndex = 347
        Me.RadRendXMotorFull.TabStop = True
        Me.RadRendXMotorFull.Text = "Rendimiento x tipo de viaje"
        Me.RadRendXMotorFull.UseVisualStyleBackColor = True
        '
        'RadRendiGlobal
        '
        Me.RadRendiGlobal.AutoSize = True
        Me.RadRendiGlobal.Location = New System.Drawing.Point(196, 88)
        Me.RadRendiGlobal.Name = "RadRendiGlobal"
        Me.RadRendiGlobal.Size = New System.Drawing.Size(115, 17)
        Me.RadRendiGlobal.TabIndex = 346
        Me.RadRendiGlobal.TabStop = True
        Me.RadRendiGlobal.Text = "Rendimiento global"
        Me.RadRendiGlobal.UseVisualStyleBackColor = True
        '
        'RadLtsDesconXOper
        '
        Me.RadLtsDesconXOper.AutoSize = True
        Me.RadLtsDesconXOper.Location = New System.Drawing.Point(632, 85)
        Me.RadLtsDesconXOper.Name = "RadLtsDesconXOper"
        Me.RadLtsDesconXOper.Size = New System.Drawing.Size(172, 17)
        Me.RadLtsDesconXOper.TabIndex = 352
        Me.RadLtsDesconXOper.TabStop = True
        Me.RadLtsDesconXOper.Text = "Litros decontados por operador"
        Me.RadLtsDesconXOper.UseVisualStyleBackColor = True
        '
        'RadRendXUnidad
        '
        Me.RadRendXUnidad.AutoSize = True
        Me.RadRendXUnidad.Location = New System.Drawing.Point(196, 113)
        Me.RadRendXUnidad.Name = "RadRendXUnidad"
        Me.RadRendXUnidad.Size = New System.Drawing.Size(137, 17)
        Me.RadRendXUnidad.TabIndex = 350
        Me.RadRendXUnidad.TabStop = True
        Me.RadRendXUnidad.Text = "Rendimiento por unidad"
        Me.RadRendXUnidad.UseVisualStyleBackColor = True
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "77113a4247c844b484c56d3664cea49a"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'tPORC_TOL
        '
        Me.tPORC_TOL.AcceptsReturn = True
        Me.tPORC_TOL.AcceptsTab = True
        Me.tPORC_TOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tPORC_TOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPORC_TOL.ForeColor = System.Drawing.Color.Black
        Me.tPORC_TOL.Location = New System.Drawing.Point(289, 36)
        Me.tPORC_TOL.Name = "tPORC_TOL"
        Me.tPORC_TOL.Size = New System.Drawing.Size(44, 21)
        Me.tPORC_TOL.TabIndex = 354
        Me.tPORC_TOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.BackColor = System.Drawing.Color.Transparent
        Me.L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.Location = New System.Drawing.Point(196, 38)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(92, 15)
        Me.L4.TabIndex = 355
        Me.L4.Text = "Porc. tolerancia"
        '
        'tPRECIO_DIESEL
        '
        Me.tPRECIO_DIESEL.AcceptsReturn = True
        Me.tPRECIO_DIESEL.AcceptsTab = True
        Me.tPRECIO_DIESEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tPRECIO_DIESEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPRECIO_DIESEL.ForeColor = System.Drawing.Color.Black
        Me.tPRECIO_DIESEL.Location = New System.Drawing.Point(544, 65)
        Me.tPRECIO_DIESEL.Name = "tPRECIO_DIESEL"
        Me.tPRECIO_DIESEL.Size = New System.Drawing.Size(50, 21)
        Me.tPRECIO_DIESEL.TabIndex = 357
        Me.tPRECIO_DIESEL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tPRECIO_DIESEL.Visible = False
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.Transparent
        Me.L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L5.Location = New System.Drawing.Point(463, 67)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(78, 15)
        Me.L5.TabIndex = 358
        Me.L5.Text = "Precio diesel"
        Me.L5.Visible = False
        '
        'RadPorcVarDiesel
        '
        Me.RadPorcVarDiesel.AutoSize = True
        Me.RadPorcVarDiesel.Location = New System.Drawing.Point(364, 92)
        Me.RadPorcVarDiesel.Name = "RadPorcVarDiesel"
        Me.RadPorcVarDiesel.Size = New System.Drawing.Size(167, 17)
        Me.RadPorcVarDiesel.TabIndex = 360
        Me.RadPorcVarDiesel.TabStop = True
        Me.RadPorcVarDiesel.Text = "Porcentaje de variación diesel"
        Me.RadPorcVarDiesel.UseVisualStyleBackColor = True
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.KMS_TAB, Me.NOMBRE_OPER, Me.VIAJES, Me.UNIDADES, Me.KMSECM, Me.LTSECM, Me.REND_ECM, Me.LTSREAL, Me.REND_REAL, Me.LTSTAB, Me.REND_TAB, Me.VAR_LTS_REAL_VS_LTS_ECM, Me.VAR_LTS_REAL_VS_LTS_TAB, Me.P_VAR_LTS_REAL_VS_LTS_ECM, Me.P_VAR_LTS_AUTO_VS_LTS_ECM, Me.LTS_DESCONTAR, Me.P_RALENTI, Me.FAC_CARGA1, Me.FAC_CARGA2, Me.CALIF_FC, Me.CALIF_RAL, Me.SUM_GLOBAL_GLO_EVA, Me.SUM_BONO_RES, Me.LTSAUTO, Me.P_VAR_LTS_REAL_VS_LTS_TAB, Me.FECHA1, Me.FECHA2, Me.LTS_AUTORIZADOS2, Me.LTS_DESCONTAR2, Me.EVENTO, Me.DataColumn1, Me.LTS_PTO_RALENTI, Me.HRS_PTO_RALENTI, Me.HRS_TRABAJO, Me.PRECIO_X_LTS, Me.PRECIO_X_LTS2, Me.PORC_TOL_EVENTO2, Me.DESCXLITROS2, Me.CVE_EVA})
        Me.DataTable1.TableName = "Table1"
        '
        'KMS_TAB
        '
        Me.KMS_TAB.AllowDBNull = False
        Me.KMS_TAB.ColumnName = "KMS_TAB"
        Me.KMS_TAB.DataType = GetType(Decimal)
        '
        'NOMBRE_OPER
        '
        Me.NOMBRE_OPER.ColumnName = "NOMBRE_OPER"
        '
        'VIAJES
        '
        Me.VIAJES.ColumnName = "VIAJES"
        Me.VIAJES.DataType = GetType(Short)
        '
        'UNIDADES
        '
        Me.UNIDADES.ColumnName = "UNIDADES"
        Me.UNIDADES.DefaultValue = ""
        '
        'KMSECM
        '
        Me.KMSECM.ColumnName = "KMSECM"
        Me.KMSECM.DataType = GetType(Decimal)
        '
        'LTSECM
        '
        Me.LTSECM.ColumnName = "LTSECM"
        Me.LTSECM.DataType = GetType(Decimal)
        '
        'REND_ECM
        '
        Me.REND_ECM.ColumnName = "REND_ECM"
        Me.REND_ECM.DataType = GetType(Decimal)
        '
        'LTSREAL
        '
        Me.LTSREAL.ColumnName = "LTSREAL"
        Me.LTSREAL.DataType = GetType(Decimal)
        '
        'REND_REAL
        '
        Me.REND_REAL.ColumnName = "REND_REAL"
        Me.REND_REAL.DataType = GetType(Decimal)
        '
        'LTSTAB
        '
        Me.LTSTAB.ColumnName = "LTSTAB"
        Me.LTSTAB.DataType = GetType(Decimal)
        '
        'REND_TAB
        '
        Me.REND_TAB.ColumnName = "REND_TAB"
        Me.REND_TAB.DataType = GetType(Decimal)
        '
        'VAR_LTS_REAL_VS_LTS_ECM
        '
        Me.VAR_LTS_REAL_VS_LTS_ECM.ColumnName = "VAR_LTS_REAL_VS_LTS_ECM"
        Me.VAR_LTS_REAL_VS_LTS_ECM.DataType = GetType(Decimal)
        '
        'VAR_LTS_REAL_VS_LTS_TAB
        '
        Me.VAR_LTS_REAL_VS_LTS_TAB.ColumnName = "VAR_LTS_REAL_VS_LTS_TAB"
        Me.VAR_LTS_REAL_VS_LTS_TAB.DataType = GetType(Decimal)
        '
        'P_VAR_LTS_REAL_VS_LTS_ECM
        '
        Me.P_VAR_LTS_REAL_VS_LTS_ECM.ColumnName = "P_VAR_LTS_REAL_VS_LTS_ECM"
        Me.P_VAR_LTS_REAL_VS_LTS_ECM.DataType = GetType(Decimal)
        '
        'P_VAR_LTS_AUTO_VS_LTS_ECM
        '
        Me.P_VAR_LTS_AUTO_VS_LTS_ECM.ColumnName = "P_VAR_LTS_AUTO_VS_LTS_ECM"
        Me.P_VAR_LTS_AUTO_VS_LTS_ECM.DataType = GetType(Decimal)
        '
        'LTS_DESCONTAR
        '
        Me.LTS_DESCONTAR.ColumnName = "LTS_DESCONTAR"
        Me.LTS_DESCONTAR.DataType = GetType(Decimal)
        '
        'P_RALENTI
        '
        Me.P_RALENTI.ColumnName = "P_RALENTI"
        Me.P_RALENTI.DataType = GetType(Decimal)
        '
        'FAC_CARGA1
        '
        Me.FAC_CARGA1.ColumnName = "FAC_CARGA1"
        '
        'FAC_CARGA2
        '
        Me.FAC_CARGA2.ColumnName = "FAC_CARGA2"
        '
        'CALIF_FC
        '
        Me.CALIF_FC.ColumnName = "CALIF_FC"
        Me.CALIF_FC.DataType = GetType(Decimal)
        '
        'CALIF_RAL
        '
        Me.CALIF_RAL.ColumnName = "CALIF_RAL"
        Me.CALIF_RAL.DataType = GetType(Decimal)
        '
        'SUM_GLOBAL_GLO_EVA
        '
        Me.SUM_GLOBAL_GLO_EVA.ColumnName = "SUM_GLOBAL_GLO_EVA"
        Me.SUM_GLOBAL_GLO_EVA.DataType = GetType(Decimal)
        '
        'SUM_BONO_RES
        '
        Me.SUM_BONO_RES.ColumnName = "SUM_BONO_RES"
        Me.SUM_BONO_RES.DataType = GetType(Decimal)
        '
        'LTSAUTO
        '
        Me.LTSAUTO.ColumnName = "LTSAUTO"
        Me.LTSAUTO.DataType = GetType(Decimal)
        '
        'P_VAR_LTS_REAL_VS_LTS_TAB
        '
        Me.P_VAR_LTS_REAL_VS_LTS_TAB.ColumnName = "P_VAR_LTS_REAL_VS_LTS_TAB"
        Me.P_VAR_LTS_REAL_VS_LTS_TAB.DataType = GetType(Decimal)
        '
        'FECHA1
        '
        Me.FECHA1.ColumnName = "FECHA1"
        '
        'FECHA2
        '
        Me.FECHA2.ColumnName = "FECHA2"
        '
        'LTS_AUTORIZADOS2
        '
        Me.LTS_AUTORIZADOS2.ColumnName = "LTS_AUTORIZADOS2"
        Me.LTS_AUTORIZADOS2.DataType = GetType(Decimal)
        '
        'LTS_DESCONTAR2
        '
        Me.LTS_DESCONTAR2.ColumnName = "LTS_DESCONTAR2"
        Me.LTS_DESCONTAR2.DataType = GetType(Decimal)
        '
        'EVENTO
        '
        Me.EVENTO.ColumnName = "EVENTO"
        Me.EVENTO.DataType = GetType(Short)
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "CVE_OPER"
        Me.DataColumn1.DataType = GetType(Integer)
        '
        'LTS_PTO_RALENTI
        '
        Me.LTS_PTO_RALENTI.ColumnName = "LTS_PTO_RALENTI"
        Me.LTS_PTO_RALENTI.DataType = GetType(Decimal)
        '
        'HRS_PTO_RALENTI
        '
        Me.HRS_PTO_RALENTI.ColumnName = "HRS_PTO_RALENTI"
        Me.HRS_PTO_RALENTI.DataType = GetType(Decimal)
        '
        'HRS_TRABAJO
        '
        Me.HRS_TRABAJO.ColumnName = "HRS_TRABAJO"
        Me.HRS_TRABAJO.DataType = GetType(Decimal)
        '
        'PRECIO_X_LTS
        '
        Me.PRECIO_X_LTS.ColumnName = "PRECIO_X_LTS"
        Me.PRECIO_X_LTS.DataType = GetType(Decimal)
        '
        'PRECIO_X_LTS2
        '
        Me.PRECIO_X_LTS2.ColumnName = "PRECIO_X_LTS2"
        Me.PRECIO_X_LTS2.DataType = GetType(Decimal)
        '
        'PORC_TOL_EVENTO2
        '
        Me.PORC_TOL_EVENTO2.ColumnName = "PORC_TOL_EVENTO2"
        Me.PORC_TOL_EVENTO2.DataType = GetType(Decimal)
        '
        'DESCXLITROS2
        '
        Me.DESCXLITROS2.ColumnName = "DESCXLITROS2"
        Me.DESCXLITROS2.DataType = GetType(Decimal)
        '
        'CVE_EVA
        '
        Me.CVE_EVA.ColumnName = "CVE_EVA"
        Me.CVE_EVA.DataType = GetType(Short)
        '
        'DataSet2
        '
        Me.DataSet2.DataSetName = "NewDataSet"
        Me.DataSet2.Tables.AddRange(New System.Data.DataTable() {Me.DataTable2})
        '
        'DataTable2
        '
        Me.DataTable2.Columns.AddRange(New System.Data.DataColumn() {Me.VIAJES2, Me.KMSECM2, Me.LTSECM2, Me.LTSREAL2, Me.REND_ECM2, Me.REND_REAL2, Me.P_VAR_LTS_REAL_VS_LTS_ECM2, Me.P_RALENTI2, Me.MARCA2, Me.DESCR_MOTOR2, Me.NOMBRE_MOTOR2, Me.T_VIAJE2, Me.LTSPTO2, Me.FEC1, Me.FEC2, Me.TIPO_VIAJE})
        Me.DataTable2.TableName = "Table1"
        '
        'VIAJES2
        '
        Me.VIAJES2.Caption = "VIAJES"
        Me.VIAJES2.ColumnName = "VIAJES"
        Me.VIAJES2.DataType = GetType(Short)
        '
        'KMSECM2
        '
        Me.KMSECM2.ColumnName = "KMSECM"
        Me.KMSECM2.DataType = GetType(Decimal)
        '
        'LTSECM2
        '
        Me.LTSECM2.ColumnName = "LTSECM"
        Me.LTSECM2.DataType = GetType(Decimal)
        '
        'LTSREAL2
        '
        Me.LTSREAL2.ColumnName = "LTSREAL"
        Me.LTSREAL2.DataType = GetType(Decimal)
        '
        'REND_ECM2
        '
        Me.REND_ECM2.ColumnName = "REND_ECM"
        Me.REND_ECM2.DataType = GetType(Decimal)
        '
        'REND_REAL2
        '
        Me.REND_REAL2.ColumnName = "REND_REAL"
        Me.REND_REAL2.DataType = GetType(Decimal)
        '
        'P_VAR_LTS_REAL_VS_LTS_ECM2
        '
        Me.P_VAR_LTS_REAL_VS_LTS_ECM2.ColumnName = "P_VAR_LTS_REAL_VS_LTS_ECM"
        Me.P_VAR_LTS_REAL_VS_LTS_ECM2.DataType = GetType(Decimal)
        '
        'P_RALENTI2
        '
        Me.P_RALENTI2.ColumnName = "P_RALENTI"
        Me.P_RALENTI2.DataType = GetType(Decimal)
        '
        'MARCA2
        '
        Me.MARCA2.ColumnName = "MARCA"
        '
        'DESCR_MOTOR2
        '
        Me.DESCR_MOTOR2.ColumnName = "DESCR_MOTOR"
        '
        'NOMBRE_MOTOR2
        '
        Me.NOMBRE_MOTOR2.ColumnName = "NOMBRE_MOTOR"
        '
        'T_VIAJE2
        '
        Me.T_VIAJE2.ColumnName = "T_VIAJE"
        '
        'LTSPTO2
        '
        Me.LTSPTO2.ColumnName = "LTSPTO"
        Me.LTSPTO2.DataType = GetType(Decimal)
        '
        'FEC1
        '
        Me.FEC1.ColumnName = "FEC1"
        '
        'FEC2
        '
        Me.FEC2.ColumnName = "FEC2"
        '
        'TIPO_VIAJE
        '
        Me.TIPO_VIAJE.ColumnName = "TIPO_VIAJE"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadFull_Sencillo)
        Me.Panel2.Controls.Add(Me.RadSencillo)
        Me.Panel2.Controls.Add(Me.RadFull)
        Me.Panel2.Location = New System.Drawing.Point(632, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(235, 27)
        Me.Panel2.TabIndex = 362
        '
        'RadFull_Sencillo
        '
        Me.RadFull_Sencillo.AutoSize = True
        Me.RadFull_Sencillo.Location = New System.Drawing.Point(138, 5)
        Me.RadFull_Sencillo.Name = "RadFull_Sencillo"
        Me.RadFull_Sencillo.Size = New System.Drawing.Size(83, 17)
        Me.RadFull_Sencillo.TabIndex = 2
        Me.RadFull_Sencillo.Text = "Full/Sencillo"
        Me.RadFull_Sencillo.UseVisualStyleBackColor = True
        '
        'RadSencillo
        '
        Me.RadSencillo.AutoSize = True
        Me.RadSencillo.Location = New System.Drawing.Point(62, 5)
        Me.RadSencillo.Name = "RadSencillo"
        Me.RadSencillo.Size = New System.Drawing.Size(62, 17)
        Me.RadSencillo.TabIndex = 1
        Me.RadSencillo.Text = "Sencillo"
        Me.RadSencillo.UseVisualStyleBackColor = True
        '
        'RadFull
        '
        Me.RadFull.AutoSize = True
        Me.RadFull.Checked = True
        Me.RadFull.Location = New System.Drawing.Point(7, 5)
        Me.RadFull.Name = "RadFull"
        Me.RadFull.Size = New System.Drawing.Size(41, 17)
        Me.RadFull.TabIndex = 0
        Me.RadFull.TabStop = True
        Me.RadFull.Text = "Full"
        Me.RadFull.UseVisualStyleBackColor = True
        '
        'PnlEventos
        '
        Me.PnlEventos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlEventos.Controls.Add(Me.RadEvento2)
        Me.PnlEventos.Controls.Add(Me.RadEvento1)
        Me.PnlEventos.Location = New System.Drawing.Point(632, 108)
        Me.PnlEventos.Name = "PnlEventos"
        Me.PnlEventos.Size = New System.Drawing.Size(189, 27)
        Me.PnlEventos.TabIndex = 363
        '
        'RadEvento2
        '
        Me.RadEvento2.AutoSize = True
        Me.RadEvento2.Location = New System.Drawing.Point(93, 5)
        Me.RadEvento2.Name = "RadEvento2"
        Me.RadEvento2.Size = New System.Drawing.Size(68, 17)
        Me.RadEvento2.TabIndex = 1
        Me.RadEvento2.Text = "Evento 2"
        Me.RadEvento2.UseVisualStyleBackColor = True
        '
        'RadEvento1
        '
        Me.RadEvento1.AutoSize = True
        Me.RadEvento1.Checked = True
        Me.RadEvento1.Location = New System.Drawing.Point(7, 5)
        Me.RadEvento1.Name = "RadEvento1"
        Me.RadEvento1.Size = New System.Drawing.Size(68, 17)
        Me.RadEvento1.TabIndex = 0
        Me.RadEvento1.TabStop = True
        Me.RadEvento1.Text = "Evento 1"
        Me.RadEvento1.UseVisualStyleBackColor = True
        '
        'RadBonoPorTab
        '
        Me.RadBonoPorTab.AutoSize = True
        Me.RadBonoPorTab.Location = New System.Drawing.Point(196, 62)
        Me.RadBonoPorTab.Name = "RadBonoPorTab"
        Me.RadBonoPorTab.Size = New System.Drawing.Size(115, 17)
        Me.RadBonoPorTab.TabIndex = 365
        Me.RadBonoPorTab.TabStop = True
        Me.RadBonoPorTab.Text = "Bono por tabulador"
        Me.RadBonoPorTab.UseVisualStyleBackColor = True
        '
        'PnlSubEvento2
        '
        Me.PnlSubEvento2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlSubEvento2.Controls.Add(Me.RadLtsTab)
        Me.PnlSubEvento2.Controls.Add(Me.RadLtsECM)
        Me.PnlSubEvento2.Location = New System.Drawing.Point(827, 108)
        Me.PnlSubEvento2.Name = "PnlSubEvento2"
        Me.PnlSubEvento2.Size = New System.Drawing.Size(189, 27)
        Me.PnlSubEvento2.TabIndex = 364
        '
        'RadLtsTab
        '
        Me.RadLtsTab.AutoSize = True
        Me.RadLtsTab.Location = New System.Drawing.Point(93, 5)
        Me.RadLtsTab.Name = "RadLtsTab"
        Me.RadLtsTab.Size = New System.Drawing.Size(97, 17)
        Me.RadLtsTab.TabIndex = 1
        Me.RadLtsTab.Text = "Litros tabulador"
        Me.RadLtsTab.UseVisualStyleBackColor = True
        '
        'RadLtsECM
        '
        Me.RadLtsECM.AutoSize = True
        Me.RadLtsECM.Checked = True
        Me.RadLtsECM.Location = New System.Drawing.Point(7, 5)
        Me.RadLtsECM.Name = "RadLtsECM"
        Me.RadLtsECM.Size = New System.Drawing.Size(76, 17)
        Me.RadLtsECM.TabIndex = 0
        Me.RadLtsECM.TabStop = True
        Me.RadLtsECM.Text = "Litros ECM"
        Me.RadLtsECM.UseVisualStyleBackColor = True
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 59)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.Split1)
        Me.SplitM1.Panels.Add(Me.Split2)
        Me.SplitM1.Size = New System.Drawing.Size(1149, 486)
        Me.SplitM1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.SplitterWidth = 1
        Me.SplitM1.TabIndex = 367
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.BorderWidth = 1
        Me.Split1.Controls.Add(Me.RadAnalisisRutas)
        Me.Split1.Controls.Add(Me.PnlSubEvento2)
        Me.Split1.Controls.Add(Me.Panel1)
        Me.Split1.Controls.Add(Me.RadCalifOper)
        Me.Split1.Controls.Add(Me.RadBonoPorTab)
        Me.Split1.Controls.Add(Me.RadMotor)
        Me.Split1.Controls.Add(Me.RadRendiFull)
        Me.Split1.Controls.Add(Me.PnlEventos)
        Me.Split1.Controls.Add(Me.RadRendiGlobal)
        Me.Split1.Controls.Add(Me.Panel2)
        Me.Split1.Controls.Add(Me.RadRendXMotorFull)
        Me.Split1.Controls.Add(Me.RadPorcVarDiesel)
        Me.Split1.Controls.Add(Me.RadPTORalenti)
        Me.Split1.Controls.Add(Me.tPRECIO_DIESEL)
        Me.Split1.Controls.Add(Me.RadRendXUnidad)
        Me.Split1.Controls.Add(Me.L5)
        Me.Split1.Controls.Add(Me.RadLtsDesconXOper)
        Me.Split1.Controls.Add(Me.tPORC_TOL)
        Me.Split1.Controls.Add(Me.L4)
        Me.Split1.Height = 193
        Me.Split1.Location = New System.Drawing.Point(2, 2)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1145, 191)
        Me.Split1.SizeRatio = 40.0R
        Me.Split1.TabIndex = 0
        '
        'RadAnalisisRutas
        '
        Me.RadAnalisisRutas.AutoSize = True
        Me.RadAnalisisRutas.Location = New System.Drawing.Point(364, 115)
        Me.RadAnalisisRutas.Name = "RadAnalisisRutas"
        Me.RadAnalisisRutas.Size = New System.Drawing.Size(106, 17)
        Me.RadAnalisisRutas.TabIndex = 366
        Me.RadAnalisisRutas.TabStop = True
        Me.RadAnalisisRutas.Text = "Análisis de Rutas"
        Me.RadAnalisisRutas.UseVisualStyleBackColor = True
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 290
        Me.Split2.Location = New System.Drawing.Point(1, 195)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1147, 290)
        Me.Split2.SizeRatio = 60.0R
        Me.Split2.TabIndex = 1
        '
        'FrmIndicadorDepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 566)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.RadRendiSencillo)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmIndicadorDepto"
        Me.Text = "NKJÑ. HHYU.ÑGHIÑ-U"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PnlEventos.ResumeLayout(False)
        Me.PnlEventos.PerformLayout()
        Me.PnlSubEvento2.ResumeLayout(False)
        Me.PnlSubEvento2.PerformLayout()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents RadRendiSencillo As RadioButton
    Friend WithEvents RadRendiFull As RadioButton
    Friend WithEvents RadMotor As RadioButton
    Friend WithEvents RadCalifOper As RadioButton
    Friend WithEvents RadPTORalenti As RadioButton
    Friend WithEvents RadRendXMotorFull As RadioButton
    Friend WithEvents RadRendiGlobal As RadioButton
    Friend WithEvents RadLtsDesconXOper As RadioButton
    Friend WithEvents RadRendXUnidad As RadioButton
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents tPORC_TOL As TextBox
    Friend WithEvents L4 As Label
    Friend WithEvents tPRECIO_DIESEL As TextBox
    Friend WithEvents L5 As Label
    Friend WithEvents RadPorcVarDiesel As RadioButton
    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents KMS_TAB As DataColumn
    Friend WithEvents NOMBRE_OPER As DataColumn
    Friend WithEvents VIAJES As DataColumn
    Friend WithEvents UNIDADES As DataColumn
    Friend WithEvents KMSECM As DataColumn
    Friend WithEvents LTSECM As DataColumn
    Friend WithEvents REND_ECM As DataColumn
    Friend WithEvents LTSREAL As DataColumn
    Friend WithEvents REND_REAL As DataColumn
    Friend WithEvents LTSTAB As DataColumn
    Friend WithEvents REND_TAB As DataColumn
    Friend WithEvents VAR_LTS_REAL_VS_LTS_ECM As DataColumn
    Friend WithEvents VAR_LTS_REAL_VS_LTS_TAB As DataColumn
    Friend WithEvents P_VAR_LTS_REAL_VS_LTS_ECM As DataColumn
    Friend WithEvents P_VAR_LTS_AUTO_VS_LTS_ECM As DataColumn
    Friend WithEvents P_VAR_LTS_REAL_VS_LTS_TAB As DataColumn
    Friend WithEvents LTS_DESCONTAR As DataColumn
    Friend WithEvents P_RALENTI As DataColumn
    Friend WithEvents FAC_CARGA1 As DataColumn
    Friend WithEvents FAC_CARGA2 As DataColumn
    Friend WithEvents CALIF_FC As DataColumn
    Friend WithEvents CALIF_RAL As DataColumn
    Friend WithEvents SUM_GLOBAL_GLO_EVA As DataColumn
    Friend WithEvents SUM_BONO_RES As DataColumn
    Friend WithEvents LTSAUTO As DataColumn
    Friend WithEvents FECHA1 As DataColumn
    Friend WithEvents FECHA2 As DataColumn
    Friend WithEvents LTS_AUTORIZADOS2 As DataColumn
    Friend WithEvents LTS_DESCONTAR2 As DataColumn
    Friend WithEvents DataSet2 As DataSet
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents VIAJES2 As DataColumn
    Friend WithEvents KMSECM2 As DataColumn
    Friend WithEvents LTSECM2 As DataColumn
    Friend WithEvents LTSREAL2 As DataColumn
    Friend WithEvents REND_ECM2 As DataColumn
    Friend WithEvents REND_REAL2 As DataColumn
    Friend WithEvents P_VAR_LTS_REAL_VS_LTS_ECM2 As DataColumn
    Friend WithEvents P_RALENTI2 As DataColumn
    Friend WithEvents MARCA2 As DataColumn
    Friend WithEvents DESCR_MOTOR2 As DataColumn
    Friend WithEvents NOMBRE_MOTOR2 As DataColumn
    Friend WithEvents T_VIAJE2 As DataColumn
    Friend WithEvents LTSPTO2 As DataColumn
    Friend WithEvents FEC1 As DataColumn
    Friend WithEvents FEC2 As DataColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RadSencillo As RadioButton
    Friend WithEvents RadFull As RadioButton
    Friend WithEvents TIPO_VIAJE As DataColumn
    Friend WithEvents EVENTO As DataColumn
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents RadFull_Sencillo As RadioButton
    Friend WithEvents LTS_PTO_RALENTI As DataColumn
    Friend WithEvents HRS_PTO_RALENTI As DataColumn
    Friend WithEvents HRS_TRABAJO As DataColumn
    Friend WithEvents PRECIO_X_LTS As DataColumn
    Friend WithEvents PRECIO_X_LTS2 As DataColumn
    Friend WithEvents PORC_TOL_EVENTO2 As DataColumn
    Friend WithEvents DESCXLITROS2 As DataColumn
    Friend WithEvents CVE_EVA As DataColumn
    Friend WithEvents PnlEventos As Panel
    Friend WithEvents RadEvento2 As RadioButton
    Friend WithEvents RadEvento1 As RadioButton
    Friend WithEvents RadBonoPorTab As RadioButton
    Friend WithEvents PnlSubEvento2 As Panel
    Friend WithEvents RadLtsTab As RadioButton
    Friend WithEvents RadLtsECM As RadioButton
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents RadAnalisisRutas As RadioButton
End Class
