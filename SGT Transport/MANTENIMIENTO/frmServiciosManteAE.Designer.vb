<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiciosManteAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiciosManteAE))
        Me.tTIEMPO_SERVICIO = New C1.Win.C1Input.C1NumericEdit()
        Me.tKM = New C1.Win.C1Input.C1NumericEdit()
        Me.tDIAS = New C1.Win.C1Input.C1NumericEdit()
        Me.tCOSTO_MO = New C1.Win.C1Input.C1NumericEdit()
        Me.BtnTipoUnidad = New System.Windows.Forms.Button()
        Me.BtnClasific = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.LtClass = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCVE_SER = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TCVE_CLAS = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Tab2 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.tHORAS = New C1.Win.C1Input.C1NumericEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tab3 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.RadCorrectivo = New System.Windows.Forms.RadioButton()
        Me.RadPreventivo = New System.Windows.Forms.RadioButton()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        CType(Me.tTIEMPO_SERVICIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDIAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCOSTO_MO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        Me.C1DockingTabPage2.SuspendLayout()
        CType(Me.tHORAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        Me.C1DockingTabPage3.SuspendLayout()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tTIEMPO_SERVICIO
        '
        Me.tTIEMPO_SERVICIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tTIEMPO_SERVICIO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tTIEMPO_SERVICIO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tTIEMPO_SERVICIO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tTIEMPO_SERVICIO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tTIEMPO_SERVICIO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tTIEMPO_SERVICIO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tTIEMPO_SERVICIO.Location = New System.Drawing.Point(116, 61)
        Me.tTIEMPO_SERVICIO.Name = "tTIEMPO_SERVICIO"
        Me.tTIEMPO_SERVICIO.Size = New System.Drawing.Size(134, 18)
        Me.tTIEMPO_SERVICIO.TabIndex = 1
        Me.tTIEMPO_SERVICIO.Tag = Nothing
        Me.tTIEMPO_SERVICIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tTIEMPO_SERVICIO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'tKM
        '
        Me.tKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKM.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tKM.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tKM.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tKM.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tKM.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKM.Location = New System.Drawing.Point(63, 88)
        Me.tKM.Name = "tKM"
        Me.tKM.Size = New System.Drawing.Size(137, 18)
        Me.tKM.TabIndex = 2
        Me.tKM.Tag = Nothing
        Me.tKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tKM.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'tDIAS
        '
        Me.tDIAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDIAS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tDIAS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tDIAS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tDIAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tDIAS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tDIAS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDIAS.Location = New System.Drawing.Point(63, 29)
        Me.tDIAS.Name = "tDIAS"
        Me.tDIAS.Size = New System.Drawing.Size(137, 18)
        Me.tDIAS.TabIndex = 0
        Me.tDIAS.Tag = Nothing
        Me.tDIAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDIAS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'tCOSTO_MO
        '
        Me.tCOSTO_MO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tCOSTO_MO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tCOSTO_MO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOSTO_MO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOSTO_MO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tCOSTO_MO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOSTO_MO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tCOSTO_MO.Location = New System.Drawing.Point(116, 32)
        Me.tCOSTO_MO.Name = "tCOSTO_MO"
        Me.tCOSTO_MO.Size = New System.Drawing.Size(134, 18)
        Me.tCOSTO_MO.TabIndex = 0
        Me.tCOSTO_MO.Tag = Nothing
        Me.tCOSTO_MO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tCOSTO_MO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'BtnTipoUnidad
        '
        Me.BtnTipoUnidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnTipoUnidad.Image = CType(resources.GetObject("BtnTipoUnidad.Image"), System.Drawing.Image)
        Me.BtnTipoUnidad.Location = New System.Drawing.Point(217, 207)
        Me.BtnTipoUnidad.Name = "BtnTipoUnidad"
        Me.BtnTipoUnidad.Size = New System.Drawing.Size(24, 23)
        Me.BtnTipoUnidad.TabIndex = 207
        Me.BtnTipoUnidad.UseVisualStyleBackColor = True
        '
        'BtnClasific
        '
        Me.BtnClasific.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClasific.Image = CType(resources.GetObject("BtnClasific.Image"), System.Drawing.Image)
        Me.BtnClasific.Location = New System.Drawing.Point(217, 174)
        Me.BtnClasific.Name = "BtnClasific"
        Me.BtnClasific.Size = New System.Drawing.Size(24, 23)
        Me.BtnClasific.TabIndex = 206
        Me.BtnClasific.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(7, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Kilometros"
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.LightGray
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Location = New System.Drawing.Point(243, 209)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(322, 20)
        Me.LtUnidad.TabIndex = 204
        '
        'LtClass
        '
        Me.LtClass.BackColor = System.Drawing.Color.LightGray
        Me.LtClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClass.Location = New System.Drawing.Point(243, 176)
        Me.LtClass.Name = "LtClass"
        Me.LtClass.Size = New System.Drawing.Size(322, 20)
        Me.LtClass.TabIndex = 203
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(14, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Tiempo de servicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(34, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "Dias"
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.AcceptsReturn = True
        Me.TCVE_UNI.AcceptsTab = True
        Me.TCVE_UNI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(134, 208)
        Me.TCVE_UNI.MaxLength = 10
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(83, 21)
        Me.TCVE_UNI.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Tipo Unidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Costo mano de obra"
        '
        'TCVE_SER
        '
        Me.TCVE_SER.AcceptsReturn = True
        Me.TCVE_SER.AcceptsTab = True
        Me.TCVE_SER.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_SER.Location = New System.Drawing.Point(134, 93)
        Me.TCVE_SER.Name = "TCVE_SER"
        Me.TCVE_SER.Size = New System.Drawing.Size(83, 21)
        Me.TCVE_SER.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(96, 96)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 197
        Me.Label27.Text = "Clave"
        '
        'TCVE_CLAS
        '
        Me.TCVE_CLAS.AcceptsReturn = True
        Me.TCVE_CLAS.AcceptsTab = True
        Me.TCVE_CLAS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLAS.Location = New System.Drawing.Point(134, 175)
        Me.TCVE_CLAS.MaxLength = 10
        Me.TCVE_CLAS.Name = "TCVE_CLAS"
        Me.TCVE_CLAS.Size = New System.Drawing.Size(83, 21)
        Me.TCVE_CLAS.TabIndex = 3
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(26, 179)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(105, 13)
        Me.Nombre.TabIndex = 196
        Me.Nombre.Text = "Clasificación servicio"
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(134, 128)
        Me.TDESCR.MaxLength = 255
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(431, 21)
        Me.TDESCR.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(67, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Descripción"
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.C1DockingTabPage1)
        Me.Tab1.Location = New System.Drawing.Point(28, 248)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(289, 148)
        Me.Tab1.TabIndex = 210
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.FillToEnd
        Me.Tab1.TabsSpacing = 5
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.CaptionText = "Costo y Tiempo"
        Me.C1DockingTabPage1.Controls.Add(Me.tTIEMPO_SERVICIO)
        Me.C1DockingTabPage1.Controls.Add(Me.Label1)
        Me.C1DockingTabPage1.Controls.Add(Me.Label4)
        Me.C1DockingTabPage1.Controls.Add(Me.tCOSTO_MO)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(287, 123)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Costo y Tiempo"
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.C1DockingTabPage2)
        Me.Tab2.Location = New System.Drawing.Point(324, 248)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(241, 148)
        Me.Tab2.TabIndex = 211
        Me.Tab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.FillToEnd
        Me.Tab2.TabsSpacing = 5
        Me.Tab2.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
        Me.Tab2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.tHORAS)
        Me.C1DockingTabPage2.Controls.Add(Me.Label6)
        Me.C1DockingTabPage2.Controls.Add(Me.tDIAS)
        Me.C1DockingTabPage2.Controls.Add(Me.Label5)
        Me.C1DockingTabPage2.Controls.Add(Me.Label7)
        Me.C1DockingTabPage2.Controls.Add(Me.tKM)
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(239, 123)
        Me.C1DockingTabPage2.TabIndex = 0
        Me.C1DockingTabPage2.Text = "Proporcionar servicio cada"
        '
        'tHORAS
        '
        Me.tHORAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tHORAS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tHORAS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tHORAS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tHORAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tHORAS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tHORAS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tHORAS.Location = New System.Drawing.Point(64, 58)
        Me.tHORAS.Name = "tHORAS"
        Me.tHORAS.Size = New System.Drawing.Size(136, 18)
        Me.tHORAS.TabIndex = 1
        Me.tHORAS.Tag = Nothing
        Me.tHORAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tHORAS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(27, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 207
        Me.Label6.Text = "Horas"
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.C1DockingTabPage3)
        Me.Tab3.Location = New System.Drawing.Point(29, 402)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Size = New System.Drawing.Size(535, 68)
        Me.Tab3.TabIndex = 212
        Me.Tab3.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.FillToEnd
        Me.Tab3.TabsSpacing = 5
        Me.Tab3.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
        Me.Tab3.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.Controls.Add(Me.RadCorrectivo)
        Me.C1DockingTabPage3.Controls.Add(Me.RadPreventivo)
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(533, 43)
        Me.C1DockingTabPage3.TabIndex = 0
        Me.C1DockingTabPage3.Text = "Tipo de servicio"
        '
        'RadCorrectivo
        '
        Me.RadCorrectivo.AutoSize = True
        Me.RadCorrectivo.BackColor = System.Drawing.Color.Transparent
        Me.RadCorrectivo.Location = New System.Drawing.Point(287, 14)
        Me.RadCorrectivo.Name = "RadCorrectivo"
        Me.RadCorrectivo.Size = New System.Drawing.Size(73, 17)
        Me.RadCorrectivo.TabIndex = 1
        Me.RadCorrectivo.TabStop = True
        Me.RadCorrectivo.Text = "Correctivo"
        Me.RadCorrectivo.UseVisualStyleBackColor = False
        '
        'RadPreventivo
        '
        Me.RadPreventivo.AutoSize = True
        Me.RadPreventivo.BackColor = System.Drawing.Color.Transparent
        Me.RadPreventivo.Location = New System.Drawing.Point(140, 14)
        Me.RadPreventivo.Name = "RadPreventivo"
        Me.RadPreventivo.Size = New System.Drawing.Size(76, 17)
        Me.RadPreventivo.TabIndex = 0
        Me.RadPreventivo.TabStop = True
        Me.RadPreventivo.Text = "Preventivo"
        Me.RadPreventivo.UseVisualStyleBackColor = False
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(592, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 5
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'frmServiciosManteAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 489)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.Tab3)
        Me.Controls.Add(Me.Tab2)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.BtnTipoUnidad)
        Me.Controls.Add(Me.BtnClasific)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.LtClass)
        Me.Controls.Add(Me.TCVE_UNI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCVE_SER)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TCVE_CLAS)
        Me.Controls.Add(Me.Nombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServiciosManteAE"
        Me.Text = "Servicios de mantenimiento"
        CType(Me.tTIEMPO_SERVICIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDIAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCOSTO_MO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.C1DockingTabPage2.PerformLayout()
        CType(Me.tHORAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.C1DockingTabPage3.ResumeLayout(False)
        Me.C1DockingTabPage3.PerformLayout()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tTIEMPO_SERVICIO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tKM As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tDIAS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tCOSTO_MO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents BtnTipoUnidad As Button
    Friend WithEvents BtnClasific As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents LtUnidad As Label
    Friend WithEvents LtClass As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TCVE_UNI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TCVE_SER As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TCVE_CLAS As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Tab2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tHORAS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents Tab3 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents RadCorrectivo As RadioButton
    Friend WithEvents RadPreventivo As RadioButton
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
End Class
