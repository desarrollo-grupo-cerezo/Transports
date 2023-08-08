<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMinveSaeAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMinveSaeAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barAgregar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarObser = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.barReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.LMec = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.tREFER = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.LtMec = New System.Windows.Forms.Label()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tBotonMagico = New System.Windows.Forms.TextBox()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.barSalir.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        Me.C1SplitterPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barAgregar, Me.barEliminar, Me.BarObser, Me.BarKardex, Me.barReimprimir, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(671, 55)
        Me.barSalir.TabIndex = 0
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = ""
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barGrabar.ToolTipText = "F2-Nuevo"
        '
        'barAgregar
        '
        Me.barAgregar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barAgregar.ForeColor = System.Drawing.Color.Black
        Me.barAgregar.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAgregar.Name = "barAgregar"
        Me.barAgregar.Size = New System.Drawing.Size(61, 51)
        Me.barAgregar.Text = "Agregar"
        Me.barAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cross_48
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.Size = New System.Drawing.Size(62, 51)
        Me.barEliminar.Text = "Eliminar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarObser
        '
        Me.BarObser.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarObser.ForeColor = System.Drawing.Color.Black
        Me.BarObser.Image = Global.SGT_Transport.My.Resources.Resources.doc33
        Me.BarObser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarObser.Name = "BarObser"
        Me.BarObser.Size = New System.Drawing.Size(96, 51)
        Me.BarObser.Text = "Observaciones"
        Me.BarObser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarKardex
        '
        Me.BarKardex.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarKardex.ForeColor = System.Drawing.Color.Black
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.BarKardex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.Size = New System.Drawing.Size(55, 51)
        Me.BarKardex.Text = "Kardex"
        Me.BarKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barReimprimir
        '
        Me.barReimprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barReimprimir.ForeColor = System.Drawing.Color.Black
        Me.barReimprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.barReimprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barReimprimir.Name = "barReimprimir"
        Me.barReimprimir.Size = New System.Drawing.Size(78, 51)
        Me.barReimprimir.Text = "Reimprimir"
        Me.barReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barReimprimir.Visible = False
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(428, 94)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(226, 18)
        Me.cboAlmacen.Style.DropDownBackColor = System.Drawing.Color.White
        Me.cboAlmacen.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.cboAlmacen.TabIndex = 4
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(375, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Almacén"
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.L3.Location = New System.Drawing.Point(10, 99)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(41, 15)
        Me.L3.TabIndex = 170
        Me.L3.Text = "Fecha"
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LMec
        '
        Me.LMec.AutoSize = True
        Me.LMec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LMec.Location = New System.Drawing.Point(167, 111)
        Me.LMec.Name = "LMec"
        Me.LMec.Size = New System.Drawing.Size(63, 15)
        Me.LMec.TabIndex = 171
        Me.LMec.Text = "Proveedor"
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(428, 30)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(187, 20)
        Me.L2.TabIndex = 134
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tREFER
        '
        Me.tREFER.AcceptsReturn = True
        Me.tREFER.AcceptsTab = True
        Me.tREFER.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tREFER.Location = New System.Drawing.Point(428, 59)
        Me.tREFER.MaxLength = 20
        Me.tREFER.Name = "tREFER"
        Me.tREFER.Size = New System.Drawing.Size(187, 22)
        Me.tREFER.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(352, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Documento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(392, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Tipo"
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(352, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(306, 22)
        Me.Label4.TabIndex = 157
        Me.Label4.Text = "Documento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.Location = New System.Drawing.Point(234, 110)
        Me.tCVE_PROV.MaxLength = 10
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(86, 22)
        Me.tCVE_PROV.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.F1)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.btnProv)
        Me.Panel5.Controls.Add(Me.cboAlmacen)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.LtMec)
        Me.Panel5.Controls.Add(Me.L2)
        Me.Panel5.Controls.Add(Me.btnNumCpto)
        Me.Panel5.Controls.Add(Me.tCVE_PROV)
        Me.Panel5.Controls.Add(Me.tREFER)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.L1)
        Me.Panel5.Controls.Add(Me.LMec)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.L3)
        Me.Panel5.Controls.Add(Me.tNUM_CPTO)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(2, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(662, 173)
        Me.Panel5.TabIndex = 0
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(12, 117)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 21)
        Me.F1.TabIndex = 174
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(166, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "Nombre"
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(323, 110)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 21)
        Me.btnProv.TabIndex = 167
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtMec
        '
        Me.LtMec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMec.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMec.Location = New System.Drawing.Point(233, 143)
        Me.LtMec.Name = "LtMec"
        Me.LtMec.Size = New System.Drawing.Size(190, 20)
        Me.LtMec.TabIndex = 165
        Me.LtMec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNumCpto
        '
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(133, 30)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(26, 20)
        Me.btnNumCpto.TabIndex = 10
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L1
        '
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(84, 59)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(256, 20)
        Me.L1.TabIndex = 134
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "Descripción"
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(84, 30)
        Me.tNUM_CPTO.MaxLength = 3
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(47, 22)
        Me.tNUM_CPTO.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Num.  cpto"
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(352, 22)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Concepto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "eca8d076ead5417eb9117a4b9bf30497"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = CType(resources.GetObject("Fg.CellButtonImage"), System.Drawing.Image)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(669, 224)
        Me.Fg.TabIndex = 3
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'tBotonMagico
        '
        Me.tBotonMagico.AcceptsReturn = True
        Me.tBotonMagico.AcceptsTab = True
        Me.tBotonMagico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBotonMagico.Location = New System.Drawing.Point(745, 22)
        Me.tBotonMagico.Name = "tBotonMagico"
        Me.tBotonMagico.Size = New System.Drawing.Size(53, 22)
        Me.tBotonMagico.TabIndex = 173
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(671, 456)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.TabIndex = 174
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.Panel5)
        Me.C1SplitterPanel1.Height = 182
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 1)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(669, 182)
        Me.C1SplitterPanel1.SizeRatio = 40.444R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.Fg)
        Me.C1SplitterPanel2.Height = 224
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(1, 187)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(669, 224)
        Me.C1SplitterPanel2.SizeRatio = 84.848R
        Me.C1SplitterPanel2.TabIndex = 1
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.Height = 40
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(1, 415)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(669, 40)
        Me.C1SplitterPanel3.SizeRatio = 1.0R
        Me.C1SplitterPanel3.TabIndex = 2
        '
        'frmMinveSaeAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 511)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tBotonMagico)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMinveSaeAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento al inventario"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.C1SplitterPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents barAgregar As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents barReimprimir As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents L3 As Label
    Friend WithEvents LMec As Label
    Friend WithEvents L2 As Label
    Friend WithEvents tREFER As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents L1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents tBotonMagico As TextBox
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LtMec As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarKardex As ToolStripMenuItem
    Friend WithEvents BarObser As ToolStripMenuItem
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
End Class
