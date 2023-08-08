<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteDeRefacciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteDeRefacciones))
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TCVE_ORDEN2 = New System.Windows.Forms.TextBox()
        Me.BtnOrden2 = New C1.Win.C1Input.C1Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCVE_ORDEN1 = New System.Windows.Forms.TextBox()
        Me.BtnOrden1 = New C1.Win.C1Input.C1Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TLIN_PROD = New System.Windows.Forms.TextBox()
        Me.BtnLinea = New C1.Win.C1Input.C1Button()
        Me.chExterna = New C1.Win.C1Input.C1CheckBox()
        Me.chInterna = New C1.Win.C1Input.C1CheckBox()
        Me.RadTodos = New System.Windows.Forms.RadioButton()
        Me.RadLLantas = New System.Windows.Forms.RadioButton()
        Me.RadRescateCarr = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.radSinistro = New System.Windows.Forms.RadioButton()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.TCVE_UNI = New System.Windows.Forms.TextBox()
        Me.BtnUnidades = New C1.Win.C1Input.C1Button()
        Me.radCorrectivo = New System.Windows.Forms.RadioButton()
        Me.radPreventivo = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.BtnOrden2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOrden1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chExterna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chInterna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(1242, 43)
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TCVE_ORDEN2)
        Me.Panel2.Controls.Add(Me.BtnOrden2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.TCVE_ORDEN1)
        Me.Panel2.Controls.Add(Me.BtnOrden1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TLIN_PROD)
        Me.Panel2.Controls.Add(Me.BtnLinea)
        Me.Panel2.Controls.Add(Me.chExterna)
        Me.Panel2.Controls.Add(Me.chInterna)
        Me.Panel2.Controls.Add(Me.RadTodos)
        Me.Panel2.Controls.Add(Me.RadLLantas)
        Me.Panel2.Controls.Add(Me.RadRescateCarr)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.radSinistro)
        Me.Panel2.Controls.Add(Me.radExtra)
        Me.Panel2.Controls.Add(Me.TCVE_UNI)
        Me.Panel2.Controls.Add(Me.BtnUnidades)
        Me.Panel2.Controls.Add(Me.radCorrectivo)
        Me.Panel2.Controls.Add(Me.radPreventivo)
        Me.Panel2.Location = New System.Drawing.Point(313, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(771, 113)
        Me.Panel2.TabIndex = 329
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(211, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 340
        Me.Label6.Text = "a la orden"
        '
        'TCVE_ORDEN2
        '
        Me.TCVE_ORDEN2.AcceptsReturn = True
        Me.TCVE_ORDEN2.AcceptsTab = True
        Me.TCVE_ORDEN2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ORDEN2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ORDEN2.Location = New System.Drawing.Point(276, 81)
        Me.TCVE_ORDEN2.MaxLength = 10
        Me.TCVE_ORDEN2.Name = "TCVE_ORDEN2"
        Me.TCVE_ORDEN2.Size = New System.Drawing.Size(80, 22)
        Me.TCVE_ORDEN2.TabIndex = 5
        '
        'BtnOrden2
        '
        Me.BtnOrden2.Image = CType(resources.GetObject("BtnOrden2.Image"), System.Drawing.Image)
        Me.BtnOrden2.Location = New System.Drawing.Point(360, 81)
        Me.BtnOrden2.Name = "BtnOrden2"
        Me.BtnOrden2.Size = New System.Drawing.Size(26, 20)
        Me.BtnOrden2.TabIndex = 341
        Me.BtnOrden2.UseVisualStyleBackColor = True
        Me.BtnOrden2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 337
        Me.Label7.Text = "De la orden"
        '
        'TCVE_ORDEN1
        '
        Me.TCVE_ORDEN1.AcceptsReturn = True
        Me.TCVE_ORDEN1.AcceptsTab = True
        Me.TCVE_ORDEN1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_ORDEN1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ORDEN1.Location = New System.Drawing.Point(86, 81)
        Me.TCVE_ORDEN1.MaxLength = 10
        Me.TCVE_ORDEN1.Name = "TCVE_ORDEN1"
        Me.TCVE_ORDEN1.Size = New System.Drawing.Size(90, 22)
        Me.TCVE_ORDEN1.TabIndex = 4
        '
        'BtnOrden1
        '
        Me.BtnOrden1.Image = CType(resources.GetObject("BtnOrden1.Image"), System.Drawing.Image)
        Me.BtnOrden1.Location = New System.Drawing.Point(179, 82)
        Me.BtnOrden1.Name = "BtnOrden1"
        Me.BtnOrden1.Size = New System.Drawing.Size(26, 20)
        Me.BtnOrden1.TabIndex = 338
        Me.BtnOrden1.UseVisualStyleBackColor = True
        Me.BtnOrden1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 334
        Me.Label5.Text = "Linea"
        '
        'TLIN_PROD
        '
        Me.TLIN_PROD.AcceptsReturn = True
        Me.TLIN_PROD.AcceptsTab = True
        Me.TLIN_PROD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TLIN_PROD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLIN_PROD.Location = New System.Drawing.Point(59, 35)
        Me.TLIN_PROD.MaxLength = 10
        Me.TLIN_PROD.Name = "TLIN_PROD"
        Me.TLIN_PROD.Size = New System.Drawing.Size(119, 22)
        Me.TLIN_PROD.TabIndex = 3
        '
        'BtnLinea
        '
        Me.BtnLinea.Image = CType(resources.GetObject("BtnLinea.Image"), System.Drawing.Image)
        Me.BtnLinea.Location = New System.Drawing.Point(181, 35)
        Me.BtnLinea.Name = "BtnLinea"
        Me.BtnLinea.Size = New System.Drawing.Size(26, 20)
        Me.BtnLinea.TabIndex = 335
        Me.BtnLinea.UseVisualStyleBackColor = True
        Me.BtnLinea.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'chExterna
        '
        Me.chExterna.BackColor = System.Drawing.Color.Transparent
        Me.chExterna.BorderColor = System.Drawing.Color.Transparent
        Me.chExterna.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chExterna.ForeColor = System.Drawing.Color.Black
        Me.chExterna.Location = New System.Drawing.Point(243, 39)
        Me.chExterna.Name = "chExterna"
        Me.chExterna.Padding = New System.Windows.Forms.Padding(1)
        Me.chExterna.Size = New System.Drawing.Size(71, 24)
        Me.chExterna.TabIndex = 7
        Me.chExterna.Text = "Externa"
        Me.chExterna.UseVisualStyleBackColor = False
        Me.chExterna.Value = Nothing
        Me.chExterna.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'chInterna
        '
        Me.chInterna.BackColor = System.Drawing.Color.Transparent
        Me.chInterna.BorderColor = System.Drawing.Color.Transparent
        Me.chInterna.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chInterna.ForeColor = System.Drawing.Color.Black
        Me.chInterna.Location = New System.Drawing.Point(243, 8)
        Me.chInterna.Name = "chInterna"
        Me.chInterna.Padding = New System.Windows.Forms.Padding(1)
        Me.chInterna.Size = New System.Drawing.Size(71, 24)
        Me.chInterna.TabIndex = 6
        Me.chInterna.Text = "Interna"
        Me.chInterna.UseVisualStyleBackColor = False
        Me.chInterna.Value = Nothing
        Me.chInterna.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'RadTodos
        '
        Me.RadTodos.AutoSize = True
        Me.RadTodos.Checked = True
        Me.RadTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTodos.Location = New System.Drawing.Point(688, 39)
        Me.RadTodos.Name = "RadTodos"
        Me.RadTodos.Size = New System.Drawing.Size(59, 19)
        Me.RadTodos.TabIndex = 14
        Me.RadTodos.TabStop = True
        Me.RadTodos.Text = "Todos"
        Me.RadTodos.UseVisualStyleBackColor = True
        '
        'RadLLantas
        '
        Me.RadLLantas.AutoSize = True
        Me.RadLLantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLLantas.Location = New System.Drawing.Point(563, 39)
        Me.RadLLantas.Name = "RadLLantas"
        Me.RadLLantas.Size = New System.Drawing.Size(65, 19)
        Me.RadLLantas.TabIndex = 13
        Me.RadLLantas.TabStop = True
        Me.RadLLantas.Text = "Llantas"
        Me.RadLLantas.UseVisualStyleBackColor = True
        '
        'RadRescateCarr
        '
        Me.RadRescateCarr.AutoSize = True
        Me.RadRescateCarr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadRescateCarr.Location = New System.Drawing.Point(431, 39)
        Me.RadRescateCarr.Name = "RadRescateCarr"
        Me.RadRescateCarr.Size = New System.Drawing.Size(122, 19)
        Me.RadRescateCarr.TabIndex = 12
        Me.RadRescateCarr.TabStop = True
        Me.RadRescateCarr.Text = "Rescate carretero"
        Me.RadRescateCarr.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 321
        Me.Label4.Text = "Unidad"
        '
        'radSinistro
        '
        Me.radSinistro.AutoSize = True
        Me.radSinistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSinistro.Location = New System.Drawing.Point(341, 39)
        Me.radSinistro.Name = "radSinistro"
        Me.radSinistro.Size = New System.Drawing.Size(73, 19)
        Me.radSinistro.TabIndex = 11
        Me.radSinistro.TabStop = True
        Me.radSinistro.Text = "Siniestro"
        Me.radSinistro.UseVisualStyleBackColor = True
        '
        'radExtra
        '
        Me.radExtra.AutoSize = True
        Me.radExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radExtra.Location = New System.Drawing.Point(563, 7)
        Me.radExtra.Name = "radExtra"
        Me.radExtra.Size = New System.Drawing.Size(102, 19)
        Me.radExtra.TabIndex = 10
        Me.radExtra.TabStop = True
        Me.radExtra.Text = "Extraordinario"
        Me.radExtra.UseVisualStyleBackColor = True
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.AcceptsReturn = True
        Me.TCVE_UNI.AcceptsTab = True
        Me.TCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(59, 7)
        Me.TCVE_UNI.MaxLength = 10
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(119, 22)
        Me.TCVE_UNI.TabIndex = 2
        '
        'BtnUnidades
        '
        Me.BtnUnidades.Image = CType(resources.GetObject("BtnUnidades.Image"), System.Drawing.Image)
        Me.BtnUnidades.Location = New System.Drawing.Point(181, 7)
        Me.BtnUnidades.Name = "BtnUnidades"
        Me.BtnUnidades.Size = New System.Drawing.Size(26, 20)
        Me.BtnUnidades.TabIndex = 322
        Me.BtnUnidades.UseVisualStyleBackColor = True
        Me.BtnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'radCorrectivo
        '
        Me.radCorrectivo.AutoSize = True
        Me.radCorrectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCorrectivo.Location = New System.Drawing.Point(431, 7)
        Me.radCorrectivo.Name = "radCorrectivo"
        Me.radCorrectivo.Size = New System.Drawing.Size(79, 19)
        Me.radCorrectivo.TabIndex = 9
        Me.radCorrectivo.TabStop = True
        Me.radCorrectivo.Text = "Correctivo"
        Me.radCorrectivo.UseVisualStyleBackColor = True
        '
        'radPreventivo
        '
        Me.radPreventivo.AutoSize = True
        Me.radPreventivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPreventivo.Location = New System.Drawing.Point(341, 7)
        Me.radPreventivo.Name = "radPreventivo"
        Me.radPreventivo.Size = New System.Drawing.Size(81, 19)
        Me.radPreventivo.TabIndex = 8
        Me.radPreventivo.TabStop = True
        Me.radPreventivo.Text = "Preventivo"
        Me.radPreventivo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Lt1)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(12, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 113)
        Me.Panel1.TabIndex = 328
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Rango de fechas"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.Transparent
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.Black
        Me.Lt1.Location = New System.Drawing.Point(18, 86)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(63, 15)
        Me.Lt1.TabIndex = 331
        Me.Lt1.Text = "________"
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
        Me.F1.Location = New System.Drawing.Point(50, 31)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 0
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
        Me.F2.Location = New System.Drawing.Point(179, 31)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 1
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
        Me.Label2.Location = New System.Drawing.Point(18, 31)
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
        Me.Label3.Location = New System.Drawing.Point(156, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1090, 56)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(301, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 16
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
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
        Me.Fg.Location = New System.Drawing.Point(12, 168)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(1129, 288)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 15
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'frmReporteDeRefacciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 534)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReporteDeRefacciones"
        Me.Text = "frmReporteDeRefacciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BtnOrden2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOrden1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chExterna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chInterna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chExterna As C1.Win.C1Input.C1CheckBox
    Friend WithEvents chInterna As C1.Win.C1Input.C1CheckBox
    Friend WithEvents RadTodos As RadioButton
    Friend WithEvents RadLLantas As RadioButton
    Friend WithEvents RadRescateCarr As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents radSinistro As RadioButton
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents TCVE_UNI As TextBox
    Friend WithEvents BtnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents radCorrectivo As RadioButton
    Friend WithEvents radPreventivo As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents TLIN_PROD As TextBox
    Friend WithEvents BtnLinea As C1.Win.C1Input.C1Button
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents TCVE_ORDEN2 As TextBox
    Friend WithEvents BtnOrden2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TCVE_ORDEN1 As TextBox
    Friend WithEvents BtnOrden1 As C1.Win.C1Input.C1Button
End Class
