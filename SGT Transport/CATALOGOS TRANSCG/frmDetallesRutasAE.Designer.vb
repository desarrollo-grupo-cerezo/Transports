<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallesRutasAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetallesRutasAE))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_RUTA = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tORIGEN = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.tDESTINO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCOSTO_CASETAS = New C1.Win.C1Input.C1NumericEdit()
        Me.tKM_RECORRIDOS = New C1.Win.C1Input.C1NumericEdit()
        Me.tDESCANSOS = New C1.Win.C1Input.C1NumericEdit()
        Me.tTIEMPO_TOTAL = New C1.Win.C1Input.C1NumericEdit()
        Me.tPARADAS_TOTALES = New C1.Win.C1Input.C1NumericEdit()
        Me.tEJES = New C1.Win.C1Input.C1NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.C1NumericEdit7 = New C1.Win.C1Input.C1NumericEdit()
        Me.tGASOLINERAS = New C1.Win.C1Input.C1NumericEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tTRAMOS = New C1.Win.C1Input.C1NumericEdit()
        Me.tALERTAS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtCasetasSinIva = New System.Windows.Forms.Label()
        Me.btnPlaza1 = New System.Windows.Forms.Button()
        Me.btnPlaza2 = New System.Windows.Forms.Button()
        Me.LtPlaza1 = New System.Windows.Forms.Label()
        Me.LtPlaza2 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.tCOSTO_CASETAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKM_RECORRIDOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDESCANSOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tTIEMPO_TOTAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPARADAS_TOTALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tEJES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1NumericEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tGASOLINERAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tTRAMOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(596, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 14
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_RUTA
        '
        Me.tCVE_RUTA.AcceptsReturn = True
        Me.tCVE_RUTA.AcceptsTab = True
        Me.tCVE_RUTA.BackColor = System.Drawing.Color.White
        Me.tCVE_RUTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_RUTA.ForeColor = System.Drawing.Color.Black
        Me.tCVE_RUTA.Location = New System.Drawing.Point(160, 70)
        Me.tCVE_RUTA.Name = "tCVE_RUTA"
        Me.tCVE_RUTA.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_RUTA.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(112, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        '
        'tORIGEN
        '
        Me.tORIGEN.AcceptsReturn = True
        Me.tORIGEN.AcceptsTab = True
        Me.tORIGEN.BackColor = System.Drawing.Color.White
        Me.tORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tORIGEN.ForeColor = System.Drawing.Color.Black
        Me.tORIGEN.Location = New System.Drawing.Point(160, 111)
        Me.tORIGEN.Name = "tORIGEN"
        Me.tORIGEN.Size = New System.Drawing.Size(54, 22)
        Me.tORIGEN.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(107, 113)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(48, 16)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Origen"
        '
        'tDESTINO
        '
        Me.tDESTINO.AcceptsReturn = True
        Me.tDESTINO.AcceptsTab = True
        Me.tDESTINO.BackColor = System.Drawing.Color.White
        Me.tDESTINO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESTINO.ForeColor = System.Drawing.Color.Black
        Me.tDESTINO.Location = New System.Drawing.Point(160, 141)
        Me.tDESTINO.Name = "tDESTINO"
        Me.tDESTINO.Size = New System.Drawing.Size(54, 22)
        Me.tDESTINO.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(101, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Destino"
        '
        'tCOSTO_CASETAS
        '
        Me.tCOSTO_CASETAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tCOSTO_CASETAS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tCOSTO_CASETAS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tCOSTO_CASETAS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tCOSTO_CASETAS.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tCOSTO_CASETAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tCOSTO_CASETAS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOSTO_CASETAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOSTO_CASETAS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tCOSTO_CASETAS.Location = New System.Drawing.Point(160, 170)
        Me.tCOSTO_CASETAS.Name = "tCOSTO_CASETAS"
        Me.tCOSTO_CASETAS.Size = New System.Drawing.Size(128, 20)
        Me.tCOSTO_CASETAS.TabIndex = 4
        Me.tCOSTO_CASETAS.Tag = Nothing
        Me.tCOSTO_CASETAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tCOSTO_CASETAS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tCOSTO_CASETAS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tCOSTO_CASETAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tKM_RECORRIDOS
        '
        Me.tKM_RECORRIDOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKM_RECORRIDOS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tKM_RECORRIDOS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM_RECORRIDOS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM_RECORRIDOS.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tKM_RECORRIDOS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tKM_RECORRIDOS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tKM_RECORRIDOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tKM_RECORRIDOS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKM_RECORRIDOS.Location = New System.Drawing.Point(444, 167)
        Me.tKM_RECORRIDOS.Name = "tKM_RECORRIDOS"
        Me.tKM_RECORRIDOS.Size = New System.Drawing.Size(110, 20)
        Me.tKM_RECORRIDOS.TabIndex = 5
        Me.tKM_RECORRIDOS.Tag = Nothing
        Me.tKM_RECORRIDOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tKM_RECORRIDOS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tKM_RECORRIDOS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tKM_RECORRIDOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tDESCANSOS
        '
        Me.tDESCANSOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDESCANSOS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tDESCANSOS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCANSOS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCANSOS.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tDESCANSOS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tDESCANSOS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tDESCANSOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESCANSOS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDESCANSOS.Location = New System.Drawing.Point(444, 245)
        Me.tDESCANSOS.Name = "tDESCANSOS"
        Me.tDESCANSOS.Size = New System.Drawing.Size(110, 20)
        Me.tDESCANSOS.TabIndex = 7
        Me.tDESCANSOS.Tag = Nothing
        Me.tDESCANSOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDESCANSOS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tDESCANSOS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDESCANSOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tTIEMPO_TOTAL
        '
        Me.tTIEMPO_TOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tTIEMPO_TOTAL.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tTIEMPO_TOTAL.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTIEMPO_TOTAL.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTIEMPO_TOTAL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tTIEMPO_TOTAL.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tTIEMPO_TOTAL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tTIEMPO_TOTAL.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tTIEMPO_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTIEMPO_TOTAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tTIEMPO_TOTAL.Location = New System.Drawing.Point(160, 245)
        Me.tTIEMPO_TOTAL.Name = "tTIEMPO_TOTAL"
        Me.tTIEMPO_TOTAL.Size = New System.Drawing.Size(87, 20)
        Me.tTIEMPO_TOTAL.TabIndex = 6
        Me.tTIEMPO_TOTAL.Tag = Nothing
        Me.tTIEMPO_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tTIEMPO_TOTAL.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tTIEMPO_TOTAL.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTIEMPO_TOTAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tPARADAS_TOTALES
        '
        Me.tPARADAS_TOTALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tPARADAS_TOTALES.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tPARADAS_TOTALES.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPARADAS_TOTALES.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPARADAS_TOTALES.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tPARADAS_TOTALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tPARADAS_TOTALES.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tPARADAS_TOTALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPARADAS_TOTALES.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tPARADAS_TOTALES.Location = New System.Drawing.Point(444, 275)
        Me.tPARADAS_TOTALES.Name = "tPARADAS_TOTALES"
        Me.tPARADAS_TOTALES.Size = New System.Drawing.Size(110, 20)
        Me.tPARADAS_TOTALES.TabIndex = 9
        Me.tPARADAS_TOTALES.Tag = Nothing
        Me.tPARADAS_TOTALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tPARADAS_TOTALES.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tPARADAS_TOTALES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPARADAS_TOTALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tEJES
        '
        Me.tEJES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tEJES.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tEJES.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEJES.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEJES.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tEJES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tEJES.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tEJES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEJES.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tEJES.Location = New System.Drawing.Point(160, 275)
        Me.tEJES.Name = "tEJES"
        Me.tEJES.Size = New System.Drawing.Size(87, 20)
        Me.tEJES.TabIndex = 8
        Me.tEJES.Tag = Nothing
        Me.tEJES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tEJES.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tEJES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEJES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Descansos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(335, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Kms. Recorridos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 16)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Costo casetas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(72, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 16)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Tiempo total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(339, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Paradas totales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(120, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 16)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Ejes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(384, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "Casetas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(74, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 16)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Gasolineras"
        '
        'C1NumericEdit7
        '
        Me.C1NumericEdit7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.C1NumericEdit7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1NumericEdit7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1NumericEdit7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1NumericEdit7.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.C1NumericEdit7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.C1NumericEdit7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.C1NumericEdit7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1NumericEdit7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.C1NumericEdit7.Location = New System.Drawing.Point(444, 305)
        Me.C1NumericEdit7.Name = "C1NumericEdit7"
        Me.C1NumericEdit7.Size = New System.Drawing.Size(110, 20)
        Me.C1NumericEdit7.TabIndex = 11
        Me.C1NumericEdit7.Tag = Nothing
        Me.C1NumericEdit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1NumericEdit7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.C1NumericEdit7.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1NumericEdit7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tGASOLINERAS
        '
        Me.tGASOLINERAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tGASOLINERAS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tGASOLINERAS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tGASOLINERAS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tGASOLINERAS.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tGASOLINERAS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tGASOLINERAS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tGASOLINERAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGASOLINERAS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tGASOLINERAS.Location = New System.Drawing.Point(160, 305)
        Me.tGASOLINERAS.Name = "tGASOLINERAS"
        Me.tGASOLINERAS.Size = New System.Drawing.Size(87, 20)
        Me.tGASOLINERAS.TabIndex = 10
        Me.tGASOLINERAS.Tag = Nothing
        Me.tGASOLINERAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tGASOLINERAS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tGASOLINERAS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tGASOLINERAS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(100, 338)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 16)
        Me.Label10.TabIndex = 138
        Me.Label10.Text = "Tramos"
        '
        'tTRAMOS
        '
        Me.tTRAMOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tTRAMOS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tTRAMOS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTRAMOS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTRAMOS.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.tTRAMOS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tTRAMOS.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tTRAMOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTRAMOS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tTRAMOS.Location = New System.Drawing.Point(160, 335)
        Me.tTRAMOS.Name = "tTRAMOS"
        Me.tTRAMOS.Size = New System.Drawing.Size(87, 20)
        Me.tTRAMOS.TabIndex = 12
        Me.tTRAMOS.Tag = Nothing
        Me.tTRAMOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tTRAMOS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tTRAMOS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tTRAMOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tALERTAS
        '
        Me.tALERTAS.AcceptsReturn = True
        Me.tALERTAS.AcceptsTab = True
        Me.tALERTAS.BackColor = System.Drawing.Color.White
        Me.tALERTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tALERTAS.ForeColor = System.Drawing.Color.Black
        Me.tALERTAS.Location = New System.Drawing.Point(160, 366)
        Me.tALERTAS.Name = "tALERTAS"
        Me.tALERTAS.Size = New System.Drawing.Size(394, 22)
        Me.tALERTAS.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(105, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 16)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Alertas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 16)
        Me.Label12.TabIndex = 431
        Me.Label12.Text = "Costo casetas sin IVA"
        '
        'LtCasetasSinIva
        '
        Me.LtCasetasSinIva.BackColor = System.Drawing.Color.LightGray
        Me.LtCasetasSinIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCasetasSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCasetasSinIva.Location = New System.Drawing.Point(160, 204)
        Me.LtCasetasSinIva.Name = "LtCasetasSinIva"
        Me.LtCasetasSinIva.Size = New System.Drawing.Size(128, 22)
        Me.LtCasetasSinIva.TabIndex = 430
        Me.LtCasetasSinIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPlaza1
        '
        Me.btnPlaza1.AutoSize = True
        Me.btnPlaza1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza1.Image = CType(resources.GetObject("btnPlaza1.Image"), System.Drawing.Image)
        Me.btnPlaza1.Location = New System.Drawing.Point(217, 110)
        Me.btnPlaza1.Name = "btnPlaza1"
        Me.btnPlaza1.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza1.TabIndex = 434
        Me.btnPlaza1.UseVisualStyleBackColor = True
        '
        'btnPlaza2
        '
        Me.btnPlaza2.AutoSize = True
        Me.btnPlaza2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPlaza2.Image = CType(resources.GetObject("btnPlaza2.Image"), System.Drawing.Image)
        Me.btnPlaza2.Location = New System.Drawing.Point(217, 139)
        Me.btnPlaza2.Name = "btnPlaza2"
        Me.btnPlaza2.Size = New System.Drawing.Size(24, 23)
        Me.btnPlaza2.TabIndex = 435
        Me.btnPlaza2.UseVisualStyleBackColor = True
        '
        'LtPlaza1
        '
        Me.LtPlaza1.BackColor = System.Drawing.Color.LightGray
        Me.LtPlaza1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza1.Location = New System.Drawing.Point(247, 113)
        Me.LtPlaza1.Name = "LtPlaza1"
        Me.LtPlaza1.Size = New System.Drawing.Size(307, 22)
        Me.LtPlaza1.TabIndex = 436
        Me.LtPlaza1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtPlaza2
        '
        Me.LtPlaza2.BackColor = System.Drawing.Color.LightGray
        Me.LtPlaza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPlaza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPlaza2.Location = New System.Drawing.Point(247, 139)
        Me.LtPlaza2.Name = "LtPlaza2"
        Me.LtPlaza2.Size = New System.Drawing.Size(307, 22)
        Me.LtPlaza2.TabIndex = 437
        Me.LtPlaza2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDetallesRutasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 424)
        Me.Controls.Add(Me.LtPlaza2)
        Me.Controls.Add(Me.LtPlaza1)
        Me.Controls.Add(Me.btnPlaza2)
        Me.Controls.Add(Me.btnPlaza1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LtCasetasSinIva)
        Me.Controls.Add(Me.tALERTAS)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tTRAMOS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.C1NumericEdit7)
        Me.Controls.Add(Me.tGASOLINERAS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tPARADAS_TOTALES)
        Me.Controls.Add(Me.tEJES)
        Me.Controls.Add(Me.tDESCANSOS)
        Me.Controls.Add(Me.tTIEMPO_TOTAL)
        Me.Controls.Add(Me.tKM_RECORRIDOS)
        Me.Controls.Add(Me.tCOSTO_CASETAS)
        Me.Controls.Add(Me.tDESTINO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_RUTA)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tORIGEN)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetallesRutasAE"
        Me.Text = "Detalles Rutas"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tCOSTO_CASETAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKM_RECORRIDOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDESCANSOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tTIEMPO_TOTAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPARADAS_TOTALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tEJES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1NumericEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tGASOLINERAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tTRAMOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_RUTA As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tORIGEN As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents tDESTINO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tCOSTO_CASETAS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tKM_RECORRIDOS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tDESCANSOS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tTIEMPO_TOTAL As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tPARADAS_TOTALES As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tEJES As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents C1NumericEdit7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tGASOLINERAS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents tTRAMOS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tALERTAS As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LtCasetasSinIva As Label
    Friend WithEvents btnPlaza1 As Button
    Friend WithEvents btnPlaza2 As Button
    Friend WithEvents LtPlaza1 As Label
    Friend WithEvents LtPlaza2 As Label
End Class
