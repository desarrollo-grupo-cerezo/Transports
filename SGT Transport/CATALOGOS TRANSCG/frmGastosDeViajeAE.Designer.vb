<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGastosDeViajeAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGastosDeViajeAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtViaje = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tCVE_NUM = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.LtNumCpto = New System.Windows.Forms.Label()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtAutoriza = New System.Windows.Forms.Label()
        Me.tCVE_AUT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tLITROS = New C1.Win.C1Input.C1NumericEdit()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tTOTAL_COMB = New C1.Win.C1Input.C1NumericEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtUni2 = New System.Windows.Forms.Label()
        Me.tCVE_UNI2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chGEN_PAS = New C1.Win.C1Input.C1CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUni2 = New C1.Win.C1Input.C1Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.btnAutoriza = New C1.Win.C1Input.C1Button()
        Me.btnOper = New C1.Win.C1Input.C1Button()
        Me.btnViaje = New C1.Win.C1Input.C1Button()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.btnUnidad = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtGastos = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LtAnt = New System.Windows.Forms.Label()
        Me.LtDif = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnAlta2 = New C1.Win.C1Input.C1Button()
        Me.btnAlta = New C1.Win.C1Input.C1Button()
        Me.btnEliminar2 = New C1.Win.C1Input.C1Button()
        Me.btnEliminar = New C1.Win.C1Input.C1Button()
        Me.FgA = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir.SuspendLayout()
        CType(Me.tLITROS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tTOTAL_COMB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chGEN_PAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnUni2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAlta2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAlta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Padding = New System.Windows.Forms.Padding(6, 10, 0, 2)
        Me.barSalir.Size = New System.Drawing.Size(1126, 47)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 4
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 35)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 35)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.Transparent
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(640, 94)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(320, 20)
        Me.LtUnidad.TabIndex = 170
        Me.LtUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(544, 94)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_UNI.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(498, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "Unidad"
        '
        'LtViaje
        '
        Me.LtViaje.BackColor = System.Drawing.Color.Transparent
        Me.LtViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtViaje.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtViaje.Location = New System.Drawing.Point(640, 68)
        Me.LtViaje.Name = "LtViaje"
        Me.LtViaje.Size = New System.Drawing.Size(320, 20)
        Me.LtViaje.TabIndex = 167
        Me.LtViaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.Transparent
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(640, 42)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(320, 20)
        Me.LtOper.TabIndex = 166
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(544, 42)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_OPER.TabIndex = 5
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(544, 68)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_VIAJE.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(509, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Viaje"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(488, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "Operador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(23, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "Fecha"
        '
        'tCVE_NUM
        '
        Me.tCVE_NUM.AcceptsReturn = True
        Me.tCVE_NUM.AcceptsTab = True
        Me.tCVE_NUM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_NUM.Location = New System.Drawing.Point(64, 13)
        Me.tCVE_NUM.Name = "tCVE_NUM"
        Me.tCVE_NUM.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_NUM.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(26, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 173
        Me.Label27.Text = "Clave"
        '
        'LtNumCpto
        '
        Me.LtNumCpto.BackColor = System.Drawing.Color.Transparent
        Me.LtNumCpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumCpto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumCpto.Location = New System.Drawing.Point(160, 65)
        Me.LtNumCpto.Name = "LtNumCpto"
        Me.LtNumCpto.Size = New System.Drawing.Size(320, 20)
        Me.LtNumCpto.TabIndex = 182
        Me.LtNumCpto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(64, 65)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(69, 22)
        Me.tNUM_CPTO.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(7, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "Concepto"
        '
        'LtAutoriza
        '
        Me.LtAutoriza.BackColor = System.Drawing.Color.Transparent
        Me.LtAutoriza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtAutoriza.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAutoriza.Location = New System.Drawing.Point(160, 91)
        Me.LtAutoriza.Name = "LtAutoriza"
        Me.LtAutoriza.Size = New System.Drawing.Size(320, 20)
        Me.LtAutoriza.TabIndex = 186
        Me.LtAutoriza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_AUT
        '
        Me.tCVE_AUT.AcceptsReturn = True
        Me.tCVE_AUT.AcceptsTab = True
        Me.tCVE_AUT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_AUT.Location = New System.Drawing.Point(64, 91)
        Me.tCVE_AUT.Name = "tCVE_AUT"
        Me.tCVE_AUT.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_AUT.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(15, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "Autoriza"
        '
        'tLITROS
        '
        Me.tLITROS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tLITROS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tLITROS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.DisplayFormat.CustomFormat = "###,##0.00"
        Me.tLITROS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLITROS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLITROS.EditFormat.CustomFormat = "###,##0.00"
        Me.tLITROS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLITROS.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLITROS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLITROS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tLITROS.Location = New System.Drawing.Point(280, 18)
        Me.tLITROS.Name = "tLITROS"
        Me.tLITROS.Size = New System.Drawing.Size(139, 20)
        Me.tLITROS.TabIndex = 1
        Me.tLITROS.Tag = Nothing
        Me.tLITROS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLITROS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tLITROS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(242, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 15)
        Me.Label26.TabIndex = 267
        Me.Label26.Text = "Litros"
        '
        'tTOTAL_COMB
        '
        Me.tTOTAL_COMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tTOTAL_COMB.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tTOTAL_COMB.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTOTAL_COMB.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTOTAL_COMB.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.tTOTAL_COMB.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tTOTAL_COMB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTOTAL_COMB.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tTOTAL_COMB.Location = New System.Drawing.Point(483, 18)
        Me.tTOTAL_COMB.Name = "tTOTAL_COMB"
        Me.tTOTAL_COMB.Size = New System.Drawing.Size(141, 20)
        Me.tTOTAL_COMB.TabIndex = 2
        Me.tTOTAL_COMB.Tag = Nothing
        Me.tTOTAL_COMB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tTOTAL_COMB.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tTOTAL_COMB.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTOTAL_COMB.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(447, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 15)
        Me.Label11.TabIndex = 269
        Me.Label11.Text = "Total"
        '
        'LtUni2
        '
        Me.LtUni2.BackColor = System.Drawing.Color.Transparent
        Me.LtUni2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUni2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUni2.Location = New System.Drawing.Point(768, 18)
        Me.LtUni2.Name = "LtUni2"
        Me.LtUni2.Size = New System.Drawing.Size(224, 20)
        Me.LtUni2.TabIndex = 273
        Me.LtUni2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_UNI2
        '
        Me.tCVE_UNI2.AcceptsReturn = True
        Me.tCVE_UNI2.AcceptsTab = True
        Me.tCVE_UNI2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI2.Location = New System.Drawing.Point(694, 18)
        Me.tCVE_UNI2.Name = "tCVE_UNI2"
        Me.tCVE_UNI2.Size = New System.Drawing.Size(46, 22)
        Me.tCVE_UNI2.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(643, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 271
        Me.Label13.Text = "Unidad"
        '
        'chGEN_PAS
        '
        Me.chGEN_PAS.BackColor = System.Drawing.Color.Transparent
        Me.chGEN_PAS.BorderColor = System.Drawing.Color.Transparent
        Me.chGEN_PAS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chGEN_PAS.ForeColor = System.Drawing.Color.Black
        Me.chGEN_PAS.Location = New System.Drawing.Point(6, 18)
        Me.chGEN_PAS.Name = "chGEN_PAS"
        Me.chGEN_PAS.Padding = New System.Windows.Forms.Padding(1)
        Me.chGEN_PAS.Size = New System.Drawing.Size(220, 24)
        Me.chGEN_PAS.TabIndex = 0
        Me.chGEN_PAS.Text = "Generar pasivo en cuentas por pagar"
        Me.chGEN_PAS.UseVisualStyleBackColor = False
        Me.chGEN_PAS.Value = Nothing
        Me.chGEN_PAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.chGEN_PAS)
        Me.GroupBox1.Controls.Add(Me.tLITROS)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LtUni2)
        Me.GroupBox1.Controls.Add(Me.tTOTAL_COMB)
        Me.GroupBox1.Controls.Add(Me.btnUni2)
        Me.GroupBox1.Controls.Add(Me.tCVE_UNI2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(998, 50)
        Me.GroupBox1.TabIndex = 277
        Me.GroupBox1.TabStop = False
        '
        'btnUni2
        '
        Me.btnUni2.Image = CType(resources.GetObject("btnUni2.Image"), System.Drawing.Image)
        Me.btnUni2.Location = New System.Drawing.Point(741, 19)
        Me.btnUni2.Name = "btnUni2"
        Me.btnUni2.Size = New System.Drawing.Size(24, 21)
        Me.btnUni2.TabIndex = 272
        Me.btnUni2.UseVisualStyleBackColor = True
        Me.btnUni2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnUni2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tFECHA)
        Me.GroupBox2.Controls.Add(Me.tCVE_NUM)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tCVE_VIAJE)
        Me.GroupBox2.Controls.Add(Me.LtAutoriza)
        Me.GroupBox2.Controls.Add(Me.tCVE_OPER)
        Me.GroupBox2.Controls.Add(Me.btnAutoriza)
        Me.GroupBox2.Controls.Add(Me.btnOper)
        Me.GroupBox2.Controls.Add(Me.tCVE_AUT)
        Me.GroupBox2.Controls.Add(Me.btnViaje)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.LtOper)
        Me.GroupBox2.Controls.Add(Me.LtNumCpto)
        Me.GroupBox2.Controls.Add(Me.LtViaje)
        Me.GroupBox2.Controls.Add(Me.btnNumCpto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tNUM_CPTO)
        Me.GroupBox2.Controls.Add(Me.tCVE_UNI)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnUnidad)
        Me.GroupBox2.Controls.Add(Me.LtUnidad)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 126)
        Me.GroupBox2.TabIndex = 278
        Me.GroupBox2.TabStop = False
        '
        'tFECHA
        '
        Me.tFECHA.AllowSpinLoop = False
        Me.tFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tFECHA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFECHA.Location = New System.Drawing.Point(66, 39)
        Me.tFECHA.Name = "tFECHA"
        Me.tFECHA.Size = New System.Drawing.Size(108, 20)
        Me.tFECHA.TabIndex = 1
        Me.tFECHA.Tag = Nothing
        Me.tFECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnAutoriza
        '
        Me.btnAutoriza.Image = CType(resources.GetObject("btnAutoriza.Image"), System.Drawing.Image)
        Me.btnAutoriza.Location = New System.Drawing.Point(134, 92)
        Me.btnAutoriza.Name = "btnAutoriza"
        Me.btnAutoriza.Size = New System.Drawing.Size(23, 21)
        Me.btnAutoriza.TabIndex = 185
        Me.btnAutoriza.UseVisualStyleBackColor = True
        Me.btnAutoriza.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnAutoriza.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnOper
        '
        Me.btnOper.Image = CType(resources.GetObject("btnOper.Image"), System.Drawing.Image)
        Me.btnOper.Location = New System.Drawing.Point(613, 43)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 21)
        Me.btnOper.TabIndex = 164
        Me.btnOper.UseVisualStyleBackColor = True
        Me.btnOper.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnViaje
        '
        Me.btnViaje.Image = CType(resources.GetObject("btnViaje.Image"), System.Drawing.Image)
        Me.btnViaje.Location = New System.Drawing.Point(613, 69)
        Me.btnViaje.Name = "btnViaje"
        Me.btnViaje.Size = New System.Drawing.Size(24, 21)
        Me.btnViaje.TabIndex = 165
        Me.btnViaje.UseVisualStyleBackColor = True
        Me.btnViaje.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnViaje.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnNumCpto
        '
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(134, 66)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(23, 21)
        Me.btnNumCpto.TabIndex = 181
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnUnidad
        '
        Me.btnUnidad.Image = CType(resources.GetObject("btnUnidad.Image"), System.Drawing.Image)
        Me.btnUnidad.Location = New System.Drawing.Point(614, 95)
        Me.btnUnidad.Name = "btnUnidad"
        Me.btnUnidad.Size = New System.Drawing.Size(23, 21)
        Me.btnUnidad.TabIndex = 169
        Me.btnUnidad.UseVisualStyleBackColor = True
        Me.btnUnidad.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnUnidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.Location = New System.Drawing.Point(1010, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 120)
        Me.Label2.TabIndex = 274
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label7.Location = New System.Drawing.Point(1010, 465)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 121)
        Me.Label7.TabIndex = 291
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(765, 595)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Gastos registrados"
        '
        'LtGastos
        '
        Me.LtGastos.BackColor = System.Drawing.Color.Transparent
        Me.LtGastos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGastos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGastos.Location = New System.Drawing.Point(864, 591)
        Me.LtGastos.Name = "LtGastos"
        Me.LtGastos.Size = New System.Drawing.Size(142, 20)
        Me.LtGastos.TabIndex = 275
        Me.LtGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(755, 617)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 292
        Me.Label15.Text = "Anticipos registrados"
        '
        'LtAnt
        '
        Me.LtAnt.BackColor = System.Drawing.Color.Transparent
        Me.LtAnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtAnt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAnt.Location = New System.Drawing.Point(864, 612)
        Me.LtAnt.Name = "LtAnt"
        Me.LtAnt.Size = New System.Drawing.Size(142, 20)
        Me.LtAnt.TabIndex = 293
        Me.LtAnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDif
        '
        Me.LtDif.AutoSize = True
        Me.LtDif.BackColor = System.Drawing.Color.Transparent
        Me.LtDif.Location = New System.Drawing.Point(804, 637)
        Me.LtDif.Name = "LtDif"
        Me.LtDif.Size = New System.Drawing.Size(55, 13)
        Me.LtDif.TabIndex = 294
        Me.LtDif.Text = "Diferencia"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(864, 633)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(142, 20)
        Me.Label18.TabIndex = 295
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAlta2
        '
        Me.btnAlta2.AutoSize = True
        Me.btnAlta2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAlta2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlta2.Image = Global.SGT_Transport.My.Resources.Resources.mas120
        Me.btnAlta2.Location = New System.Drawing.Point(1010, 408)
        Me.btnAlta2.Name = "btnAlta2"
        Me.btnAlta2.Size = New System.Drawing.Size(26, 26)
        Me.btnAlta2.TabIndex = 297
        Me.btnAlta2.UseVisualStyleBackColor = True
        Me.btnAlta2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnAlta2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnAlta
        '
        Me.btnAlta.AutoSize = True
        Me.btnAlta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAlta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlta.Image = Global.SGT_Transport.My.Resources.Resources.mas120
        Me.btnAlta.Location = New System.Drawing.Point(1010, 227)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(26, 26)
        Me.btnAlta.TabIndex = 296
        Me.btnAlta.UseVisualStyleBackColor = True
        Me.btnAlta.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnAlta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnEliminar2
        '
        Me.btnEliminar2.AutoSize = True
        Me.btnEliminar2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEliminar2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar2.Image = Global.SGT_Transport.My.Resources.Resources.eli5
        Me.btnEliminar2.Location = New System.Drawing.Point(1012, 437)
        Me.btnEliminar2.Name = "btnEliminar2"
        Me.btnEliminar2.Size = New System.Drawing.Size(26, 26)
        Me.btnEliminar2.TabIndex = 3
        Me.btnEliminar2.UseVisualStyleBackColor = True
        Me.btnEliminar2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnEliminar2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnEliminar
        '
        Me.btnEliminar.AutoSize = True
        Me.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEliminar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.eli5
        Me.btnEliminar.Location = New System.Drawing.Point(1010, 255)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(26, 26)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnEliminar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'FgA
        '
        Me.FgA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgA.AutoClipboard = True
        Me.FgA.BackColor = System.Drawing.Color.White
        Me.FgA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgA.ColumnInfo = resources.GetString("FgA.ColumnInfo")
        Me.FgA.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgA.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgA.ForeColor = System.Drawing.Color.Black
        Me.FgA.IgnoreDiacritics = True
        Me.FgA.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgA.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgA.Location = New System.Drawing.Point(8, 409)
        Me.FgA.Name = "FgA"
        Me.FgA.PreserveEditMode = True
        Me.FgA.Rows.Count = 1
        Me.FgA.Rows.DefaultSize = 19
        Me.FgA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgA.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgA.Size = New System.Drawing.Size(998, 179)
        Me.FgA.StyleInfo = resources.GetString("FgA.StyleInfo")
        Me.FgA.TabIndex = 1
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.IgnoreDiacritics = True
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(8, 227)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.Size = New System.Drawing.Size(998, 179)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        '
        'frmGastosDeViajeAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 669)
        Me.Controls.Add(Me.btnAlta2)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.LtDif)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LtAnt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtGastos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEliminar2)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FgA)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGastosDeViajeAE"
        Me.Text = "Gastos de Viaje"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tLITROS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tTOTAL_COMB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chGEN_PAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnUni2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAlta2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAlta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents LtUnidad As Label
    Friend WithEvents btnUnidad As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LtViaje As Label
    Friend WithEvents LtOper As Label
    Friend WithEvents btnViaje As C1.Win.C1Input.C1Button
    Friend WithEvents btnOper As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tCVE_NUM As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents LtNumCpto As Label
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LtAutoriza As Label
    Friend WithEvents btnAutoriza As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_AUT As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tLITROS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label26 As Label
    Friend WithEvents tTOTAL_COMB As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents LtUni2 As Label
    Friend WithEvents btnUni2 As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents chGEN_PAS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents FgA As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tFECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents btnEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliminar2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtGastos As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LtAnt As Label
    Friend WithEvents LtDif As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btnAlta As C1.Win.C1Input.C1Button
    Friend WithEvents btnAlta2 As C1.Win.C1Input.C1Button
End Class
