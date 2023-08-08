<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConciValesCombusAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConciValesCombusAE))
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesplegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCerrarFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAdjuntarXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGrabarXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCxP = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimirVehiUtil = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSolicitudDePago = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TCVE_DOC = New System.Windows.Forms.TextBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.TCVE_COVC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tSUBTOTAL = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.tIVA = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.tNETO = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Splitter1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtUtils = New System.Windows.Forms.Label()
        Me.BtnGas = New C1.Win.C1Input.C1Button()
        Me.Ltg = New System.Windows.Forms.Label()
        Me.LtGas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtProv = New System.Windows.Forms.Label()
        Me.BtnProv = New C1.Win.C1Input.C1Button()
        Me.TCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtCanc = New System.Windows.Forms.Label()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.Splitter2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Splitter3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.BarMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.Splitter1.SuspendLayout()
        CType(Me.BtnGas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Splitter2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Splitter3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarMenu
        '
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarDesplegar, Me.BarCerrarFactura, Me.BarCancelar, Me.BarAdjuntarXML, Me.BarGrabarXML, Me.BarCxP, Me.BarExcel, Me.BarImprimir, Me.BarImprimirVehiUtil, Me.BarSolicitudDePago, Me.BarSalir})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(1142, 55)
        Me.BarMenu.Stretch = False
        Me.BarMenu.TabIndex = 26
        Me.BarMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarDesplegar.ForeColor = System.Drawing.Color.Black
        Me.BarDesplegar.Image = CType(resources.GetObject("BarDesplegar.Image"), System.Drawing.Image)
        Me.BarDesplegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutKeyDisplayString = ""
        Me.BarDesplegar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarDesplegar.Size = New System.Drawing.Size(71, 51)
        Me.BarDesplegar.Text = "Desplegar"
        Me.BarDesplegar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCerrarFactura
        '
        Me.BarCerrarFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCerrarFactura.ForeColor = System.Drawing.Color.Black
        Me.BarCerrarFactura.Image = Global.SGT_Transport.My.Resources.Resources.candado3
        Me.BarCerrarFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCerrarFactura.Name = "BarCerrarFactura"
        Me.BarCerrarFactura.ShortcutKeyDisplayString = ""
        Me.BarCerrarFactura.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarCerrarFactura.Size = New System.Drawing.Size(118, 51)
        Me.BarCerrarFactura.Text = "Cerrar conciliación"
        Me.BarCerrarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCancelar
        '
        Me.BarCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCancelar.ForeColor = System.Drawing.Color.Black
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cross_48
        Me.BarCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarCancelar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarCancelar.Size = New System.Drawing.Size(65, 51)
        Me.BarCancelar.Text = "Cancelar"
        Me.BarCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarAdjuntarXML
        '
        Me.BarAdjuntarXML.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarAdjuntarXML.ForeColor = System.Drawing.Color.Black
        Me.BarAdjuntarXML.Image = Global.SGT_Transport.My.Resources.Resources.xmln1
        Me.BarAdjuntarXML.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAdjuntarXML.Name = "BarAdjuntarXML"
        Me.BarAdjuntarXML.ShortcutKeyDisplayString = ""
        Me.BarAdjuntarXML.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarAdjuntarXML.Size = New System.Drawing.Size(92, 51)
        Me.BarAdjuntarXML.Text = "Adjuntar XML"
        Me.BarAdjuntarXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGrabarXML
        '
        Me.BarGrabarXML.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabarXML.ForeColor = System.Drawing.Color.Black
        Me.BarGrabarXML.Image = CType(resources.GetObject("BarGrabarXML.Image"), System.Drawing.Image)
        Me.BarGrabarXML.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabarXML.Name = "BarGrabarXML"
        Me.BarGrabarXML.ShortcutKeyDisplayString = ""
        Me.BarGrabarXML.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabarXML.Size = New System.Drawing.Size(81, 51)
        Me.BarGrabarXML.Text = "Grabar XML"
        Me.BarGrabarXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCxP
        '
        Me.BarCxP.Image = Global.SGT_Transport.My.Resources.Resources.centro_costo
        Me.BarCxP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCxP.Name = "BarCxP"
        Me.BarCxP.Size = New System.Drawing.Size(141, 51)
        Me.BarCxP.Text = "Generar cuenta x pagar"
        Me.BarCxP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarCxP.Visible = False
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeyDisplayString = ""
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimir
        '
        Me.BarImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImprimir.ForeColor = System.Drawing.Color.Black
        Me.BarImprimir.Image = CType(resources.GetObject("BarImprimir.Image"), System.Drawing.Image)
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutKeyDisplayString = ""
        Me.BarImprimir.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarImprimir.Size = New System.Drawing.Size(118, 51)
        Me.BarImprimir.Text = "Conciliación diesel"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimirVehiUtil
        '
        Me.BarImprimirVehiUtil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarImprimirVehiUtil.ForeColor = System.Drawing.Color.Black
        Me.BarImprimirVehiUtil.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimirVehiUtil.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimirVehiUtil.Name = "BarImprimirVehiUtil"
        Me.BarImprimirVehiUtil.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarImprimirVehiUtil.Size = New System.Drawing.Size(137, 51)
        Me.BarImprimirVehiUtil.Text = "Conciliación utilitarios"
        Me.BarImprimirVehiUtil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSolicitudDePago
        '
        Me.BarSolicitudDePago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSolicitudDePago.ForeColor = System.Drawing.Color.Black
        Me.BarSolicitudDePago.Image = Global.SGT_Transport.My.Resources.Resources.impresora1
        Me.BarSolicitudDePago.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSolicitudDePago.Name = "BarSolicitudDePago"
        Me.BarSolicitudDePago.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarSolicitudDePago.Size = New System.Drawing.Size(111, 51)
        Me.BarSolicitudDePago.Text = "Solicitud de pago"
        Me.BarSolicitudDePago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(593, 375)
        Me.Fg.TabIndex = 9
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'TCVE_DOC
        '
        Me.TCVE_DOC.AcceptsReturn = True
        Me.TCVE_DOC.AcceptsTab = True
        Me.TCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DOC.Location = New System.Drawing.Point(98, 101)
        Me.TCVE_DOC.Name = "TCVE_DOC"
        Me.TCVE_DOC.Size = New System.Drawing.Size(146, 22)
        Me.TCVE_DOC.TabIndex = 3
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.Location = New System.Drawing.Point(42, 104)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(52, 16)
        Me.Label114.TabIndex = 188
        Me.Label114.Text = "Factura"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(283, 46)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(106, 20)
        Me.F1.TabIndex = 4
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.Location = New System.Drawing.Point(190, 50)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(88, 16)
        Me.Label112.TabIndex = 190
        Me.Label112.Text = "Fecha factura"
        '
        'TCVE_COVC
        '
        Me.TCVE_COVC.AcceptsReturn = True
        Me.TCVE_COVC.AcceptsTab = True
        Me.TCVE_COVC.Enabled = False
        Me.TCVE_COVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_COVC.Location = New System.Drawing.Point(98, 13)
        Me.TCVE_COVC.Name = "TCVE_COVC"
        Me.TCVE_COVC.Size = New System.Drawing.Size(69, 22)
        Me.TCVE_COVC.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "Concilaición"
        '
        'tSUBTOTAL
        '
        Me.tSUBTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tSUBTOTAL.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUBTOTAL.Location = New System.Drawing.Point(641, 4)
        Me.tSUBTOTAL.Name = "tSUBTOTAL"
        Me.tSUBTOTAL.Size = New System.Drawing.Size(152, 25)
        Me.tSUBTOTAL.TabIndex = 196
        Me.tSUBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(571, 7)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(65, 17)
        Me.L1.TabIndex = 195
        Me.L1.Text = "Sub-total"
        '
        'tIVA
        '
        Me.tIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tIVA.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIVA.Location = New System.Drawing.Point(641, 31)
        Me.tIVA.Name = "tIVA"
        Me.tIVA.Size = New System.Drawing.Size(152, 25)
        Me.tIVA.TabIndex = 198
        Me.tIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(607, 36)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(29, 17)
        Me.L2.TabIndex = 197
        Me.L2.Text = "IVA"
        '
        'tNETO
        '
        Me.tNETO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNETO.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNETO.Location = New System.Drawing.Point(641, 57)
        Me.tNETO.Name = "tNETO"
        Me.tNETO.Size = New System.Drawing.Size(152, 25)
        Me.tNETO.TabIndex = 200
        Me.tNETO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(598, 60)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(38, 17)
        Me.L3.TabIndex = 199
        Me.L3.Text = "Neto"
        '
        'Fg2
        '
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 20
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(546, 375)
        Me.Fg2.TabIndex = 9
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
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
        Me.C1SplitContainer1.Panels.Add(Me.Splitter1)
        Me.C1SplitContainer1.Panels.Add(Me.Splitter2)
        Me.C1SplitContainer1.Panels.Add(Me.Splitter3)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1142, 659)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.TabIndex = 203
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'Splitter1
        '
        Me.Splitter1.Controls.Add(Me.Label3)
        Me.Splitter1.Controls.Add(Me.LtUtils)
        Me.Splitter1.Controls.Add(Me.BtnGas)
        Me.Splitter1.Controls.Add(Me.Ltg)
        Me.Splitter1.Controls.Add(Me.LtGas)
        Me.Splitter1.Controls.Add(Me.Label2)
        Me.Splitter1.Controls.Add(Me.LtProv)
        Me.Splitter1.Controls.Add(Me.BtnProv)
        Me.Splitter1.Controls.Add(Me.TCVE_PROV)
        Me.Splitter1.Controls.Add(Me.Label6)
        Me.Splitter1.Controls.Add(Me.Lt2)
        Me.Splitter1.Controls.Add(Me.Lt1)
        Me.Splitter1.Controls.Add(Me.LtCanc)
        Me.Splitter1.Controls.Add(Me.TCVE_COVC)
        Me.Splitter1.Controls.Add(Me.BtnRegresar)
        Me.Splitter1.Controls.Add(Me.BtnAgregar)
        Me.Splitter1.Controls.Add(Me.Label114)
        Me.Splitter1.Controls.Add(Me.TCVE_DOC)
        Me.Splitter1.Controls.Add(Me.Label112)
        Me.Splitter1.Controls.Add(Me.F1)
        Me.Splitter1.Controls.Add(Me.Label1)
        Me.Splitter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Splitter1.Height = 163
        Me.Splitter1.Location = New System.Drawing.Point(1, 1)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1140, 163)
        Me.Splitter1.SizeRatio = 25.0R
        Me.Splitter1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(567, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Viaje"
        '
        'LtUtils
        '
        Me.LtUtils.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUtils.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUtils.Location = New System.Drawing.Point(610, 50)
        Me.LtUtils.Name = "LtUtils"
        Me.LtUtils.Size = New System.Drawing.Size(183, 20)
        Me.LtUtils.TabIndex = 359
        Me.LtUtils.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGas
        '
        Me.BtnGas.Image = CType(resources.GetObject("BtnGas.Image"), System.Drawing.Image)
        Me.BtnGas.Location = New System.Drawing.Point(824, 16)
        Me.BtnGas.Name = "BtnGas"
        Me.BtnGas.Size = New System.Drawing.Size(26, 21)
        Me.BtnGas.TabIndex = 358
        Me.BtnGas.UseVisualStyleBackColor = True
        Me.BtnGas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Ltg
        '
        Me.Ltg.AutoSize = True
        Me.Ltg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ltg.Location = New System.Drawing.Point(525, 21)
        Me.Ltg.Name = "Ltg"
        Me.Ltg.Size = New System.Drawing.Size(80, 16)
        Me.Ltg.TabIndex = 357
        Me.Ltg.Text = "Gasolineras"
        '
        'LtGas
        '
        Me.LtGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGas.Location = New System.Drawing.Point(610, 17)
        Me.LtGas.Name = "LtGas"
        Me.LtGas.Size = New System.Drawing.Size(208, 20)
        Me.LtGas.TabIndex = 356
        Me.LtGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 355
        Me.Label2.Text = "Nombre"
        '
        'LtProv
        '
        Me.LtProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtProv.Location = New System.Drawing.Point(98, 73)
        Me.LtProv.Name = "LtProv"
        Me.LtProv.Size = New System.Drawing.Size(322, 20)
        Me.LtProv.TabIndex = 330
        Me.LtProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnProv
        '
        Me.BtnProv.Image = CType(resources.GetObject("BtnProv.Image"), System.Drawing.Image)
        Me.BtnProv.Location = New System.Drawing.Point(153, 46)
        Me.BtnProv.Name = "BtnProv"
        Me.BtnProv.Size = New System.Drawing.Size(26, 21)
        Me.BtnProv.TabIndex = 329
        Me.BtnProv.UseVisualStyleBackColor = True
        Me.BtnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_PROV
        '
        Me.TCVE_PROV.AcceptsReturn = True
        Me.TCVE_PROV.AcceptsTab = True
        Me.TCVE_PROV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV.Location = New System.Drawing.Point(98, 46)
        Me.TCVE_PROV.MaxLength = 10
        Me.TCVE_PROV.Name = "TCVE_PROV"
        Me.TCVE_PROV.Size = New System.Drawing.Size(54, 22)
        Me.TCVE_PROV.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 328
        Me.Label6.Text = "Proveedor"
        '
        'Lt2
        '
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(742, 105)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(230, 17)
        Me.Lt2.TabIndex = 205
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lt1
        '
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(283, 103)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(230, 17)
        Me.Lt1.TabIndex = 204
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtCanc
        '
        Me.LtCanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCanc.Location = New System.Drawing.Point(190, 11)
        Me.LtCanc.Name = "LtCanc"
        Me.LtCanc.Size = New System.Drawing.Size(326, 24)
        Me.LtCanc.TabIndex = 203
        Me.LtCanc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnRegresar
        '
        Me.BtnRegresar.Image = Global.SGT_Transport.My.Resources.Resources.fechaizq2
        Me.BtnRegresar.Location = New System.Drawing.Point(641, 86)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(56, 52)
        Me.BtnRegresar.TabIndex = 202
        Me.BtnRegresar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = Global.SGT_Transport.My.Resources.Resources.flechader
        Me.BtnAgregar.Location = New System.Drawing.Point(537, 86)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(56, 52)
        Me.BtnAgregar.TabIndex = 201
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'Splitter2
        '
        Me.Splitter2.Controls.Add(Me.SplitContainer1)
        Me.Splitter2.Height = 375
        Me.Splitter2.Location = New System.Drawing.Point(1, 168)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(1140, 375)
        Me.Splitter2.SizeRatio = 77.189R
        Me.Splitter2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1140, 375)
        Me.SplitContainer1.SplitterDistance = 593
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'Splitter3
        '
        Me.Splitter3.Controls.Add(Me.tSUBTOTAL)
        Me.Splitter3.Controls.Add(Me.tNETO)
        Me.Splitter3.Controls.Add(Me.L1)
        Me.Splitter3.Controls.Add(Me.L3)
        Me.Splitter3.Controls.Add(Me.L2)
        Me.Splitter3.Controls.Add(Me.tIVA)
        Me.Splitter3.Height = 111
        Me.Splitter3.Location = New System.Drawing.Point(1, 547)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(1140, 111)
        Me.Splitter3.TabIndex = 2
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "68e3a1b6f8e1433b8e798d61e66b8bb6"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmConciValesCombusAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 714)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.BarMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmConciValesCombusAE"
        Me.ShowInTaskbar = False
        Me.Text = "Conciliación"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.Splitter1.ResumeLayout(False)
        Me.Splitter1.PerformLayout()
        CType(Me.BtnGas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Splitter2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Splitter3.ResumeLayout(False)
        Me.Splitter3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TCVE_DOC As TextBox
    Friend WithEvents Label114 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label112 As Label
    Friend WithEvents TCVE_COVC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tSUBTOTAL As Label
    Friend WithEvents L1 As Label
    Friend WithEvents tIVA As Label
    Friend WithEvents L2 As Label
    Friend WithEvents tNETO As Label
    Friend WithEvents L3 As Label
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents BarCancelar As ToolStripMenuItem
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Splitter1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Splitter2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Splitter3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents BarCerrarFactura As ToolStripMenuItem
    Friend WithEvents LtCanc As Label
    Friend WithEvents BarDesplegar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarImprimir As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarAdjuntarXML As ToolStripMenuItem
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents LtProv As Label
    Friend WithEvents BtnProv As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_PROV As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Ltg As Label
    Friend WithEvents LtGas As Label
    Friend WithEvents BtnGas As C1.Win.C1Input.C1Button
    Friend WithEvents BarCxP As ToolStripMenuItem
    Friend WithEvents BarGrabarXML As ToolStripMenuItem
    Friend WithEvents LtUtils As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BarImprimirVehiUtil As ToolStripMenuItem
    Friend WithEvents BarSolicitudDePago As ToolStripMenuItem
End Class
