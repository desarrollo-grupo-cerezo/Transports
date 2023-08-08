<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmResumenFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResumenFacturas))
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CboTipVenta = New C1.Win.C1Input.C1ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCLASIFIC = New System.Windows.Forms.TextBox()
        Me.RadFechCarga = New System.Windows.Forms.RadioButton()
        Me.RadFechElab = New System.Windows.Forms.RadioButton()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCVE_CLIE2 = New System.Windows.Forms.TextBox()
        Me.BtnClie2 = New C1.Win.C1Input.C1Button()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.TCVE_CLIE1 = New System.Windows.Forms.TextBox()
        Me.BtnClie1 = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CVE_DOC = New System.Data.DataColumn()
        Me.CLIENTE = New System.Data.DataColumn()
        Me.NOMBRE = New System.Data.DataColumn()
        Me.ESTATUS = New System.Data.DataColumn()
        Me.SUBTOTAL = New System.Data.DataColumn()
        Me.IVA = New System.Data.DataColumn()
        Me.RETENCION = New System.Data.DataColumn()
        Me.IMPORTE = New System.Data.DataColumn()
        Me.FECHA_CARGA = New System.Data.DataColumn()
        Me.CARTA_PORTE = New System.Data.DataColumn()
        Me.UNIDAD = New System.Data.DataColumn()
        Me.FECHA_TIMBRADO = New System.Data.DataColumn()
        Me.FECHA_CANC = New System.Data.DataColumn()
        Me.FC1 = New System.Data.DataColumn()
        Me.FC2 = New System.Data.DataColumn()
        Me.CLIE1 = New System.Data.DataColumn()
        Me.CLIE2 = New System.Data.DataColumn()
        Me.CLASIFIC = New System.Data.DataColumn()
        Me.TIPO_VENTA = New System.Data.DataColumn()
        Me.POR_FECHA = New System.Data.DataColumn()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.CboTipVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(1189, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ThemeController1.SetTheme(Me.C1ToolBar1, "Office2010Blue")
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CboTipVenta)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TCLASIFIC)
        Me.Panel1.Controls.Add(Me.RadFechCarga)
        Me.Panel1.Controls.Add(Me.RadFechElab)
        Me.Panel1.Controls.Add(Me.Lt5)
        Me.Panel1.Controls.Add(Me.Lt7)
        Me.Panel1.Controls.Add(Me.TCVE_CLIE2)
        Me.Panel1.Controls.Add(Me.BtnClie2)
        Me.Panel1.Controls.Add(Me.Lt6)
        Me.Panel1.Controls.Add(Me.TCVE_CLIE1)
        Me.Panel1.Controls.Add(Me.BtnClie1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(12, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1140, 67)
        Me.Panel1.TabIndex = 317
        Me.C1ThemeController1.SetTheme(Me.Panel1, "Office2010Blue")
        '
        'CboTipVenta
        '
        Me.CboTipVenta.AllowSpinLoop = False
        Me.CboTipVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CboTipVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipVenta.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.CboTipVenta.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipVenta.GapHeight = 0
        Me.CboTipVenta.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipVenta.ItemsDisplayMember = ""
        Me.CboTipVenta.ItemsValueMember = ""
        Me.CboTipVenta.Location = New System.Drawing.Point(895, 7)
        Me.CboTipVenta.Name = "CboTipVenta"
        Me.CboTipVenta.Size = New System.Drawing.Size(117, 21)
        Me.CboTipVenta.TabIndex = 407
        Me.CboTipVenta.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.CboTipVenta, "(default)")
        Me.CboTipVenta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(817, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 364
        Me.Label6.Text = "Tipo venta"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(805, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "Clasificación"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'TCLASIFIC
        '
        Me.TCLASIFIC.AcceptsReturn = True
        Me.TCLASIFIC.AcceptsTab = True
        Me.TCLASIFIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCLASIFIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLASIFIC.ForeColor = System.Drawing.Color.Black
        Me.TCLASIFIC.Location = New System.Drawing.Point(895, 36)
        Me.TCLASIFIC.MaxLength = 10
        Me.TCLASIFIC.Name = "TCLASIFIC"
        Me.TCLASIFIC.Size = New System.Drawing.Size(117, 22)
        Me.TCLASIFIC.TabIndex = 361
        Me.C1ThemeController1.SetTheme(Me.TCLASIFIC, "Office2010Blue")
        '
        'RadFechCarga
        '
        Me.RadFechCarga.AutoSize = True
        Me.RadFechCarga.Checked = True
        Me.RadFechCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechCarga.Location = New System.Drawing.Point(19, 11)
        Me.RadFechCarga.Name = "RadFechCarga"
        Me.RadFechCarga.Size = New System.Drawing.Size(110, 19)
        Me.RadFechCarga.TabIndex = 360
        Me.RadFechCarga.TabStop = True
        Me.RadFechCarga.Text = "Fecha de carga"
        Me.C1ThemeController1.SetTheme(Me.RadFechCarga, "(default)")
        Me.RadFechCarga.UseVisualStyleBackColor = True
        '
        'RadFechElab
        '
        Me.RadFechElab.AutoSize = True
        Me.RadFechElab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechElab.Location = New System.Drawing.Point(19, 36)
        Me.RadFechElab.Name = "RadFechElab"
        Me.RadFechElab.Size = New System.Drawing.Size(128, 19)
        Me.RadFechElab.TabIndex = 359
        Me.RadFechElab.Text = "Fecha de timbrado"
        Me.C1ThemeController1.SetTheme(Me.RadFechElab, "(default)")
        Me.RadFechElab.UseVisualStyleBackColor = True
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt5.Location = New System.Drawing.Point(603, 11)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(98, 16)
        Me.Lt5.TabIndex = 358
        Me.Lt5.Text = "Rango clientes"
        Me.C1ThemeController1.SetTheme(Me.Lt5, "Office2010Blue")
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt7.Location = New System.Drawing.Point(653, 34)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(19, 16)
        Me.Lt7.TabIndex = 356
        Me.Lt7.Text = "al"
        Me.C1ThemeController1.SetTheme(Me.Lt7, "Office2010Blue")
        '
        'TCVE_CLIE2
        '
        Me.TCVE_CLIE2.AcceptsReturn = True
        Me.TCVE_CLIE2.AcceptsTab = True
        Me.TCVE_CLIE2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CLIE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE2.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CLIE2.Location = New System.Drawing.Point(676, 30)
        Me.TCVE_CLIE2.MaxLength = 10
        Me.TCVE_CLIE2.Name = "TCVE_CLIE2"
        Me.TCVE_CLIE2.Size = New System.Drawing.Size(78, 22)
        Me.TCVE_CLIE2.TabIndex = 355
        Me.C1ThemeController1.SetTheme(Me.TCVE_CLIE2, "Office2010Blue")
        '
        'BtnClie2
        '
        Me.BtnClie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie2.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.BtnClie2.Location = New System.Drawing.Point(757, 31)
        Me.BtnClie2.Name = "BtnClie2"
        Me.BtnClie2.Size = New System.Drawing.Size(23, 20)
        Me.BtnClie2.TabIndex = 357
        Me.C1ThemeController1.SetTheme(Me.BtnClie2, "Office2010Blue")
        Me.BtnClie2.UseVisualStyleBackColor = True
        Me.BtnClie2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt6.Location = New System.Drawing.Point(504, 33)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(29, 16)
        Me.Lt6.TabIndex = 353
        Me.Lt6.Text = "Del"
        Me.C1ThemeController1.SetTheme(Me.Lt6, "Office2010Blue")
        '
        'TCVE_CLIE1
        '
        Me.TCVE_CLIE1.AcceptsReturn = True
        Me.TCVE_CLIE1.AcceptsTab = True
        Me.TCVE_CLIE1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CLIE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE1.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CLIE1.Location = New System.Drawing.Point(537, 30)
        Me.TCVE_CLIE1.MaxLength = 10
        Me.TCVE_CLIE1.Name = "TCVE_CLIE1"
        Me.TCVE_CLIE1.Size = New System.Drawing.Size(78, 22)
        Me.TCVE_CLIE1.TabIndex = 352
        Me.C1ThemeController1.SetTheme(Me.TCVE_CLIE1, "Office2010Blue")
        '
        'BtnClie1
        '
        Me.BtnClie1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie1.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.BtnClie1.Location = New System.Drawing.Point(618, 31)
        Me.BtnClie1.Name = "BtnClie1"
        Me.BtnClie1.Size = New System.Drawing.Size(23, 20)
        Me.BtnClie1.TabIndex = 354
        Me.C1ThemeController1.SetTheme(Me.BtnClie1, "Office2010Blue")
        Me.BtnClie1.UseVisualStyleBackColor = True
        Me.BtnClie1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(314, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Rango de fechas"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(250, 29)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 306
        Me.F1.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F1, "Office2010Blue")
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(379, 29)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 308
        Me.F2.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.F2, "Office2010Blue")
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(218, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 15)
        Me.Label5.TabIndex = 305
        Me.Label5.Text = "Del"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(356, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 15)
        Me.Label4.TabIndex = 307
        Me.Label4.Text = "al"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(356, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(851, 2)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(301, 39)
        Me.C1FlexGridSearchPanel1.TabIndex = 316
        Me.C1ThemeController1.SetTheme(Me.C1FlexGridSearchPanel1, "Office2010Blue")
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
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 121)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1177, 340)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 315
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "f54878e080494f77b2b692ba1b4299a0"
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
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.CVE_DOC, Me.CLIENTE, Me.NOMBRE, Me.ESTATUS, Me.SUBTOTAL, Me.IVA, Me.RETENCION, Me.IMPORTE, Me.FECHA_CARGA, Me.CARTA_PORTE, Me.UNIDAD, Me.FECHA_TIMBRADO, Me.FECHA_CANC, Me.FC1, Me.FC2, Me.CLIE1, Me.CLIE2, Me.CLASIFIC, Me.TIPO_VENTA, Me.POR_FECHA})
        Me.DataTable1.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"CVE_DOC"}, True)})
        Me.DataTable1.PrimaryKey = New System.Data.DataColumn() {Me.CVE_DOC}
        Me.DataTable1.TableName = "Table1"
        '
        'CVE_DOC
        '
        Me.CVE_DOC.AllowDBNull = False
        Me.CVE_DOC.ColumnName = "CVE_DOC"
        '
        'CLIENTE
        '
        Me.CLIENTE.ColumnName = "CLIENTE"
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        Me.NOMBRE.DefaultValue = ""
        '
        'ESTATUS
        '
        Me.ESTATUS.ColumnName = "ESTATUS"
        Me.ESTATUS.DefaultValue = ""
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
        'RETENCION
        '
        Me.RETENCION.ColumnName = "RETENCION"
        Me.RETENCION.DataType = GetType(Decimal)
        '
        'IMPORTE
        '
        Me.IMPORTE.ColumnName = "IMPORTE"
        Me.IMPORTE.DataType = GetType(Decimal)
        '
        'FECHA_CARGA
        '
        Me.FECHA_CARGA.ColumnName = "FECHA_CARGA"
        Me.FECHA_CARGA.DataType = GetType(Date)
        '
        'CARTA_PORTE
        '
        Me.CARTA_PORTE.ColumnName = "CARTA_PORTE"
        '
        'UNIDAD
        '
        Me.UNIDAD.ColumnName = "UNIDAD"
        '
        'FECHA_TIMBRADO
        '
        Me.FECHA_TIMBRADO.ColumnName = "FECHA_TIMBRADO"
        Me.FECHA_TIMBRADO.DataType = GetType(Date)
        '
        'FECHA_CANC
        '
        Me.FECHA_CANC.ColumnName = "FECHA_CANC"
        Me.FECHA_CANC.DataType = GetType(Date)
        '
        'FC1
        '
        Me.FC1.ColumnName = "F1"
        Me.FC1.DataType = GetType(Date)
        '
        'FC2
        '
        Me.FC2.ColumnName = "F2"
        Me.FC2.DataType = GetType(Date)
        '
        'CLIE1
        '
        Me.CLIE1.ColumnName = "CLIE1"
        '
        'CLIE2
        '
        Me.CLIE2.ColumnName = "CLIE2"
        '
        'CLASIFIC
        '
        Me.CLASIFIC.ColumnName = "CLASIFIC"
        '
        'TIPO_VENTA
        '
        Me.TIPO_VENTA.ColumnName = "TIPO_VENTA"
        '
        'POR_FECHA
        '
        Me.POR_FECHA.ColumnName = "POR_FECHA"
        '
        'FrmResumenFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 580)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmResumenFacturas"
        Me.Text = "Resumen Facturas"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CboTipVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents TCVE_CLIE2 As TextBox
    Friend WithEvents BtnClie2 As C1.Win.C1Input.C1Button
    Friend WithEvents Lt6 As Label
    Friend WithEvents TCVE_CLIE1 As TextBox
    Friend WithEvents BtnClie1 As C1.Win.C1Input.C1Button
    Friend WithEvents RadFechCarga As RadioButton
    Friend WithEvents RadFechElab As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents TCLASIFIC As TextBox
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents CVE_DOC As DataColumn
    Friend WithEvents CLIENTE As DataColumn
    Friend WithEvents NOMBRE As DataColumn
    Friend WithEvents ESTATUS As DataColumn
    Friend WithEvents SUBTOTAL As DataColumn
    Friend WithEvents IVA As DataColumn
    Friend WithEvents RETENCION As DataColumn
    Friend WithEvents IMPORTE As DataColumn
    Friend WithEvents FECHA_CARGA As DataColumn
    Friend WithEvents CARTA_PORTE As DataColumn
    Friend WithEvents UNIDAD As DataColumn
    Friend WithEvents FECHA_TIMBRADO As DataColumn
    Friend WithEvents FECHA_CANC As DataColumn
    Friend WithEvents FC1 As DataColumn
    Friend WithEvents FC2 As DataColumn
    Friend WithEvents CLIE1 As DataColumn
    Friend WithEvents CLIE2 As DataColumn
    Friend WithEvents CLASIFIC As DataColumn
    Friend WithEvents TIPO_VENTA As DataColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents CboTipVenta As C1.Win.C1Input.C1ComboBox
    Friend WithEvents POR_FECHA As DataColumn
    Friend WithEvents DataSet1 As DataSet
End Class
