<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenDeTrabajoExtAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenDeTrabajoExtAE))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEnlazarDoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.barFinOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRemisionar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCancelarOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReimpresion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancPartNoEntr = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.L3 = New System.Windows.Forms.Label()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tNOTA = New System.Windows.Forms.TextBox()
        Me.tLUGAR_REP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LProgServ = New System.Windows.Forms.Label()
        Me.BtnServProg = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROG = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnProgServ = New C1.Win.C1Input.C1Button()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.L4 = New System.Windows.Forms.Label()
        Me.btnTipo = New C1.Win.C1Input.C1Button()
        Me.tEstatus = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tCVE_TIPO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tBotonMagico = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadLLantas = New System.Windows.Forms.RadioButton()
        Me.RadRescateCarr = New System.Windows.Forms.RadioButton()
        Me.radSinistro = New System.Windows.Forms.RadioButton()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radCorrectivo = New System.Windows.Forms.RadioButton()
        Me.radPreventivo = New System.Windows.Forms.RadioButton()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.tCVE_ORD = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.TabProductos = New C1.Win.C1Command.C1DockingTabPage()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.LtPar = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.LtPiezas = New System.Windows.Forms.Label()
        Me.LtDocAnt = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabServicios = New C1.Win.C1Command.C1DockingTabPage()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.FgS = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnAltaServicio = New C1.Win.C1Input.C1Button()
        Me.btnEliSer = New C1.Win.C1Input.C1Button()
        Me.TabDocDigitales = New C1.Win.C1Command.C1DockingTabPage()
        Me.GBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscaDoc = New System.Windows.Forms.Button()
        Me.btnFotDocA = New C1.Win.C1Input.C1Button()
        Me.LtFotoDoc = New System.Windows.Forms.Label()
        Me.btnFotDocE = New C1.Win.C1Input.C1Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FgD = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.tDescrFotDoc = New System.Windows.Forms.TextBox()
        Me.TabObser = New C1.Win.C1Command.C1DockingTabPage()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.BtnSetMovRealizado = New System.Windows.Forms.Button()
        Me.BtnDesCancel = New System.Windows.Forms.Button()
        Me.BtnMagix = New System.Windows.Forms.Button()
        Me.btnAltaProducto = New C1.Win.C1Input.C1Button()
        Me.btnEliProd = New C1.Win.C1Input.C1Button()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.LtNueva = New System.Windows.Forms.Label()
        Me.barMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.BtnServProg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProgServ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.TabProductos.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabServicios.SuspendLayout()
        CType(Me.FgS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocDigitales.SuspendLayout()
        Me.GBox1.SuspendLayout()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabObser.SuspendLayout()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.BarEnlazarDoc, Me.barFinOT, Me.BarRemisionar, Me.barCancelarOT, Me.BarKardex, Me.BarReimpresion, Me.BarCancPartNoEntr, Me.BarExcel, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1246, 39)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 1
        Me.barMenu.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = CType(resources.GetObject("barGrabar.Image"), System.Drawing.Image)
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 35)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEnlazarDoc
        '
        Me.BarEnlazarDoc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarEnlazarDoc.ForeColor = System.Drawing.Color.White
        Me.BarEnlazarDoc.Image = CType(resources.GetObject("BarEnlazarDoc.Image"), System.Drawing.Image)
        Me.BarEnlazarDoc.Name = "BarEnlazarDoc"
        Me.BarEnlazarDoc.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarEnlazarDoc.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEnlazarDoc.Size = New System.Drawing.Size(111, 35)
        Me.BarEnlazarDoc.Text = "Enlazar cotización"
        Me.BarEnlazarDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barFinOT
        '
        Me.barFinOT.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barFinOT.ForeColor = System.Drawing.Color.White
        Me.barFinOT.Image = CType(resources.GetObject("barFinOT.Image"), System.Drawing.Image)
        Me.barFinOT.Name = "barFinOT"
        Me.barFinOT.ShortcutKeyDisplayString = ""
        Me.barFinOT.Size = New System.Drawing.Size(152, 35)
        Me.barFinOT.Text = "Finalizar orden de trabajo"
        Me.barFinOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRemisionar
        '
        Me.BarRemisionar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarRemisionar.ForeColor = System.Drawing.Color.White
        Me.BarRemisionar.Image = CType(resources.GetObject("BarRemisionar.Image"), System.Drawing.Image)
        Me.BarRemisionar.Name = "BarRemisionar"
        Me.BarRemisionar.ShortcutKeyDisplayString = ""
        Me.BarRemisionar.Size = New System.Drawing.Size(76, 35)
        Me.BarRemisionar.Text = "Remisionar"
        Me.BarRemisionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCancelarOT
        '
        Me.barCancelarOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barCancelarOT.ForeColor = System.Drawing.Color.White
        Me.barCancelarOT.Image = CType(resources.GetObject("barCancelarOT.Image"), System.Drawing.Image)
        Me.barCancelarOT.Name = "barCancelarOT"
        Me.barCancelarOT.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barCancelarOT.Size = New System.Drawing.Size(155, 35)
        Me.barCancelarOT.Text = "Cancelar orden de trabajo"
        Me.barCancelarOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarKardex
        '
        Me.BarKardex.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarKardex.ForeColor = System.Drawing.Color.White
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarKardex.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarKardex.Size = New System.Drawing.Size(53, 35)
        Me.BarKardex.Text = "Kardex"
        Me.BarKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarReimpresion
        '
        Me.BarReimpresion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarReimpresion.ForeColor = System.Drawing.Color.White
        Me.BarReimpresion.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarReimpresion.Name = "BarReimpresion"
        Me.BarReimpresion.ShortcutKeyDisplayString = ""
        Me.BarReimpresion.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarReimpresion.Size = New System.Drawing.Size(83, 35)
        Me.BarReimpresion.Text = "Reimpresión"
        Me.BarReimpresion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCancPartNoEntr
        '
        Me.BarCancPartNoEntr.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarCancPartNoEntr.ForeColor = System.Drawing.Color.White
        Me.BarCancPartNoEntr.Image = Global.SGT_Transport.My.Resources.Resources.c6
        Me.BarCancPartNoEntr.Name = "BarCancPartNoEntr"
        Me.BarCancPartNoEntr.ShortcutKeyDisplayString = ""
        Me.BarCancPartNoEntr.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarCancPartNoEntr.Size = New System.Drawing.Size(168, 35)
        Me.BarCancPartNoEntr.Text = "Cancelar part. no entregadas"
        Me.BarCancPartNoEntr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.White
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarExcel.Size = New System.Drawing.Size(44, 35)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 35)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.Transparent
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(215, 53)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(300, 22)
        Me.L3.TabIndex = 133
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.Location = New System.Drawing.Point(91, 53)
        Me.tCVE_PROV.MaxLength = 10
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_PROV.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Cliente"
        '
        'tNOTA
        '
        Me.tNOTA.AcceptsReturn = True
        Me.tNOTA.AcceptsTab = True
        Me.tNOTA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOTA.Location = New System.Drawing.Point(518, 112)
        Me.tNOTA.MaxLength = 100
        Me.tNOTA.Name = "tNOTA"
        Me.tNOTA.Size = New System.Drawing.Size(161, 22)
        Me.tNOTA.TabIndex = 4
        '
        'tLUGAR_REP
        '
        Me.tLUGAR_REP.AcceptsReturn = True
        Me.tLUGAR_REP.AcceptsTab = True
        Me.tLUGAR_REP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLUGAR_REP.Location = New System.Drawing.Point(106, 112)
        Me.tLUGAR_REP.MaxLength = 50
        Me.tLUGAR_REP.Name = "tLUGAR_REP"
        Me.tLUGAR_REP.Size = New System.Drawing.Size(409, 22)
        Me.tLUGAR_REP.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(556, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "Odometro"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 15)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Lugar reparacion"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LProgServ)
        Me.Panel2.Controls.Add(Me.BtnServProg)
        Me.Panel2.Controls.Add(Me.tCVE_PROG)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.btnProgServ)
        Me.Panel2.Controls.Add(Me.tNOTA)
        Me.Panel2.Controls.Add(Me.tLUGAR_REP)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.L3)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnProv)
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.btnTipo)
        Me.Panel2.Controls.Add(Me.tCVE_PROV)
        Me.Panel2.Controls.Add(Me.tEstatus)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tCVE_TIPO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.btnUnidades)
        Me.Panel2.Controls.Add(Me.tCVE_UNI)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.ForeColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(342, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(715, 148)
        Me.Panel2.TabIndex = 39
        '
        'LProgServ
        '
        Me.LProgServ.BackColor = System.Drawing.Color.Transparent
        Me.LProgServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LProgServ.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LProgServ.Location = New System.Drawing.Point(215, 79)
        Me.LProgServ.Name = "LProgServ"
        Me.LProgServ.Size = New System.Drawing.Size(300, 22)
        Me.LProgServ.TabIndex = 150
        Me.LProgServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnServProg
        '
        Me.BtnServProg.Image = CType(resources.GetObject("BtnServProg.Image"), System.Drawing.Image)
        Me.BtnServProg.Location = New System.Drawing.Point(187, 79)
        Me.BtnServProg.Name = "BtnServProg"
        Me.BtnServProg.Size = New System.Drawing.Size(26, 20)
        Me.BtnServProg.TabIndex = 149
        Me.BtnServProg.UseVisualStyleBackColor = True
        Me.BtnServProg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_PROG
        '
        Me.tCVE_PROG.AcceptsReturn = True
        Me.tCVE_PROG.AcceptsTab = True
        Me.tCVE_PROG.Enabled = False
        Me.tCVE_PROG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROG.Location = New System.Drawing.Point(91, 79)
        Me.tCVE_PROG.MaxLength = 10
        Me.tCVE_PROG.Name = "tCVE_PROG"
        Me.tCVE_PROG.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_PROG.TabIndex = 147
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Prog. servicio"
        '
        'btnProgServ
        '
        Me.btnProgServ.Location = New System.Drawing.Point(534, 6)
        Me.btnProgServ.Name = "btnProgServ"
        Me.btnProgServ.Size = New System.Drawing.Size(28, 20)
        Me.btnProgServ.TabIndex = 146
        Me.btnProgServ.Text = "....."
        Me.btnProgServ.UseVisualStyleBackColor = True
        Me.btnProgServ.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(187, 53)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 20)
        Me.btnProv.TabIndex = 132
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'L4
        '
        Me.L4.BackColor = System.Drawing.Color.Transparent
        Me.L4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.Location = New System.Drawing.Point(215, 28)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(300, 22)
        Me.L4.TabIndex = 140
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTipo
        '
        Me.btnTipo.Image = CType(resources.GetObject("btnTipo.Image"), System.Drawing.Image)
        Me.btnTipo.Location = New System.Drawing.Point(187, 28)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.Size = New System.Drawing.Size(26, 20)
        Me.btnTipo.TabIndex = 139
        Me.btnTipo.UseVisualStyleBackColor = True
        Me.btnTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tEstatus
        '
        Me.tEstatus.AcceptsReturn = True
        Me.tEstatus.AcceptsTab = True
        Me.tEstatus.Enabled = False
        Me.tEstatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEstatus.Location = New System.Drawing.Point(518, 53)
        Me.tEstatus.Name = "tEstatus"
        Me.tEstatus.Size = New System.Drawing.Size(187, 22)
        Me.tEstatus.TabIndex = 2
        Me.tEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(585, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 15)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Estatus"
        '
        'tCVE_TIPO
        '
        Me.tCVE_TIPO.AcceptsReturn = True
        Me.tCVE_TIPO.AcceptsTab = True
        Me.tCVE_TIPO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TIPO.Location = New System.Drawing.Point(91, 28)
        Me.tCVE_TIPO.Name = "tCVE_TIPO"
        Me.tCVE_TIPO.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_TIPO.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(54, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Tipo"
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(215, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(300, 22)
        Me.L2.TabIndex = 131
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUnidades
        '
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(187, 3)
        Me.btnUnidades.Name = "btnUnidades"
        Me.btnUnidades.Size = New System.Drawing.Size(26, 20)
        Me.btnUnidades.TabIndex = 130
        Me.btnUnidades.UseVisualStyleBackColor = True
        Me.btnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(91, 3)
        Me.tCVE_UNI.MaxLength = 10
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(90, 22)
        Me.tCVE_UNI.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Unidad"
        '
        'tBotonMagico
        '
        Me.tBotonMagico.AcceptsReturn = True
        Me.tBotonMagico.AcceptsTab = True
        Me.tBotonMagico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBotonMagico.Location = New System.Drawing.Point(976, 144)
        Me.tBotonMagico.Name = "tBotonMagico"
        Me.tBotonMagico.Size = New System.Drawing.Size(53, 22)
        Me.tBotonMagico.TabIndex = 143
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadLLantas)
        Me.Panel1.Controls.Add(Me.RadRescateCarr)
        Me.Panel1.Controls.Add(Me.radSinistro)
        Me.Panel1.Controls.Add(Me.radExtra)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.radCorrectivo)
        Me.Panel1.Controls.Add(Me.radPreventivo)
        Me.Panel1.Controls.Add(Me.Label90)
        Me.Panel1.Controls.Add(Me.tCVE_ORD)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(6, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 148)
        Me.Panel1.TabIndex = 38
        '
        'RadLLantas
        '
        Me.RadLLantas.AutoSize = True
        Me.RadLLantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLLantas.Location = New System.Drawing.Point(230, 116)
        Me.RadLLantas.Name = "RadLLantas"
        Me.RadLLantas.Size = New System.Drawing.Size(65, 19)
        Me.RadLLantas.TabIndex = 159
        Me.RadLLantas.TabStop = True
        Me.RadLLantas.Text = "Llantas"
        Me.RadLLantas.UseVisualStyleBackColor = True
        '
        'RadRescateCarr
        '
        Me.RadRescateCarr.AutoSize = True
        Me.RadRescateCarr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadRescateCarr.Location = New System.Drawing.Point(97, 116)
        Me.RadRescateCarr.Name = "RadRescateCarr"
        Me.RadRescateCarr.Size = New System.Drawing.Size(122, 19)
        Me.RadRescateCarr.TabIndex = 158
        Me.RadRescateCarr.TabStop = True
        Me.RadRescateCarr.Text = "Rescate carretero"
        Me.RadRescateCarr.UseVisualStyleBackColor = True
        '
        'radSinistro
        '
        Me.radSinistro.AutoSize = True
        Me.radSinistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSinistro.Location = New System.Drawing.Point(8, 116)
        Me.radSinistro.Name = "radSinistro"
        Me.radSinistro.Size = New System.Drawing.Size(73, 19)
        Me.radSinistro.TabIndex = 157
        Me.radSinistro.TabStop = True
        Me.radSinistro.Text = "Siniestro"
        Me.radSinistro.UseVisualStyleBackColor = True
        '
        'radExtra
        '
        Me.radExtra.AutoSize = True
        Me.radExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radExtra.Location = New System.Drawing.Point(230, 89)
        Me.radExtra.Name = "radExtra"
        Me.radExtra.Size = New System.Drawing.Size(102, 19)
        Me.radExtra.TabIndex = 3
        Me.radExtra.TabStop = True
        Me.radExtra.Text = "Extraordinario"
        Me.radExtra.UseVisualStyleBackColor = True
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
        Me.F1.Location = New System.Drawing.Point(168, 24)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(147, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 22)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Tipo de servicio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'radCorrectivo
        '
        Me.radCorrectivo.AutoSize = True
        Me.radCorrectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCorrectivo.Location = New System.Drawing.Point(98, 89)
        Me.radCorrectivo.Name = "radCorrectivo"
        Me.radCorrectivo.Size = New System.Drawing.Size(79, 19)
        Me.radCorrectivo.TabIndex = 2
        Me.radCorrectivo.TabStop = True
        Me.radCorrectivo.Text = "Correctivo"
        Me.radCorrectivo.UseVisualStyleBackColor = True
        '
        'radPreventivo
        '
        Me.radPreventivo.AutoSize = True
        Me.radPreventivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPreventivo.Location = New System.Drawing.Point(8, 89)
        Me.radPreventivo.Name = "radPreventivo"
        Me.radPreventivo.Size = New System.Drawing.Size(81, 19)
        Me.radPreventivo.TabIndex = 1
        Me.radPreventivo.TabStop = True
        Me.radPreventivo.Text = "Preventivo"
        Me.radPreventivo.UseVisualStyleBackColor = True
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(126, 26)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(41, 15)
        Me.Label90.TabIndex = 153
        Me.Label90.Text = "Fecha"
        '
        'tCVE_ORD
        '
        Me.tCVE_ORD.AcceptsReturn = True
        Me.tCVE_ORD.AcceptsTab = True
        Me.tCVE_ORD.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tCVE_ORD.Location = New System.Drawing.Point(44, 22)
        Me.tCVE_ORD.Name = "tCVE_ORD"
        Me.tCVE_ORD.Size = New System.Drawing.Size(69, 22)
        Me.tCVE_ORD.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(10, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 15)
        Me.Label27.TabIndex = 149
        Me.Label27.Text = "Folio"
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.TabProductos)
        Me.Tab1.Controls.Add(Me.TabServicios)
        Me.Tab1.Controls.Add(Me.TabDocDigitales)
        Me.Tab1.Controls.Add(Me.TabObser)
        Me.Tab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.Location = New System.Drawing.Point(4, 208)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(1169, 327)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabsSpacing = 5
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'TabProductos
        '
        Me.TabProductos.Controls.Add(Me.Lt4)
        Me.TabProductos.Controls.Add(Me.LtPar)
        Me.TabProductos.Controls.Add(Me.Lt3)
        Me.TabProductos.Controls.Add(Me.LtPiezas)
        Me.TabProductos.Controls.Add(Me.LtDocAnt)
        Me.TabProductos.Controls.Add(Me.Label7)
        Me.TabProductos.Controls.Add(Me.Lt1)
        Me.TabProductos.Controls.Add(Me.L1)
        Me.TabProductos.Controls.Add(Me.Fg)
        Me.TabProductos.Location = New System.Drawing.Point(1, 25)
        Me.TabProductos.Name = "TabProductos"
        Me.TabProductos.Size = New System.Drawing.Size(1167, 301)
        Me.TabProductos.TabIndex = 0
        Me.TabProductos.Text = "Productos"
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.BackColor = System.Drawing.Color.Transparent
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.Location = New System.Drawing.Point(316, 270)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(81, 15)
        Me.Lt4.TabIndex = 144
        Me.Lt4.Text = "Total partidas"
        '
        'LtPar
        '
        Me.LtPar.BackColor = System.Drawing.Color.Transparent
        Me.LtPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPar.Location = New System.Drawing.Point(401, 267)
        Me.LtPar.Name = "LtPar"
        Me.LtPar.Size = New System.Drawing.Size(51, 22)
        Me.LtPar.TabIndex = 143
        Me.LtPar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.Transparent
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.Location = New System.Drawing.Point(478, 270)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(73, 15)
        Me.Lt3.TabIndex = 142
        Me.Lt3.Text = "Total piezas"
        '
        'LtPiezas
        '
        Me.LtPiezas.BackColor = System.Drawing.Color.Transparent
        Me.LtPiezas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPiezas.Location = New System.Drawing.Point(553, 267)
        Me.LtPiezas.Name = "LtPiezas"
        Me.LtPiezas.Size = New System.Drawing.Size(111, 22)
        Me.LtPiezas.TabIndex = 141
        Me.LtPiezas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDocAnt
        '
        Me.LtDocAnt.BackColor = System.Drawing.Color.Transparent
        Me.LtDocAnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDocAnt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocAnt.Location = New System.Drawing.Point(104, 267)
        Me.LtDocAnt.Name = "LtDocAnt"
        Me.LtDocAnt.Size = New System.Drawing.Size(164, 22)
        Me.LtDocAnt.TabIndex = 140
        Me.LtDocAnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Doc. enlazado"
        '
        'Lt1
        '
        Me.Lt1.BackColor = System.Drawing.Color.Transparent
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(967, 267)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(164, 22)
        Me.Lt1.TabIndex = 135
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(912, 270)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(49, 15)
        Me.L1.TabIndex = 134
        Me.L1.Text = "Importe"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(4, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 4
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.Size = New System.Drawing.Size(1127, 261)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'TabServicios
        '
        Me.TabServicios.Controls.Add(Me.Lt5)
        Me.TabServicios.Controls.Add(Me.L5)
        Me.TabServicios.Controls.Add(Me.FgS)
        Me.TabServicios.Controls.Add(Me.btnAltaServicio)
        Me.TabServicios.Controls.Add(Me.btnEliSer)
        Me.TabServicios.Location = New System.Drawing.Point(1, 25)
        Me.TabServicios.Name = "TabServicios"
        Me.TabServicios.Size = New System.Drawing.Size(1167, 301)
        Me.TabServicios.TabIndex = 3
        Me.TabServicios.Text = "Servicios"
        '
        'Lt5
        '
        Me.Lt5.BackColor = System.Drawing.Color.Transparent
        Me.Lt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(969, 274)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(164, 22)
        Me.Lt5.TabIndex = 140
        Me.Lt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.Transparent
        Me.L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L5.Location = New System.Drawing.Point(914, 277)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(49, 15)
        Me.L5.TabIndex = 139
        Me.L5.Text = "Importe"
        '
        'FgS
        '
        Me.FgS.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgS.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.FgS.BackColor = System.Drawing.Color.White
        Me.FgS.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgS.ColumnInfo = resources.GetString("FgS.ColumnInfo")
        Me.FgS.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.FgS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.FgS.ForeColor = System.Drawing.Color.Black
        Me.FgS.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgS.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgS.Location = New System.Drawing.Point(6, 40)
        Me.FgS.Name = "FgS"
        Me.FgS.PreserveEditMode = True
        Me.FgS.Rows.Count = 2
        Me.FgS.Rows.DefaultSize = 21
        Me.FgS.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgS.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgS.ShowCellLabels = True
        Me.FgS.Size = New System.Drawing.Size(1127, 221)
        Me.FgS.StyleInfo = resources.GetString("FgS.StyleInfo")
        Me.FgS.TabIndex = 136
        Me.FgS.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'btnAltaServicio
        '
        Me.btnAltaServicio.Image = CType(resources.GetObject("btnAltaServicio.Image"), System.Drawing.Image)
        Me.btnAltaServicio.Location = New System.Drawing.Point(921, 4)
        Me.btnAltaServicio.Name = "btnAltaServicio"
        Me.btnAltaServicio.Size = New System.Drawing.Size(27, 30)
        Me.btnAltaServicio.TabIndex = 1
        Me.btnAltaServicio.UseVisualStyleBackColor = True
        Me.btnAltaServicio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliSer
        '
        Me.btnEliSer.Image = CType(resources.GetObject("btnEliSer.Image"), System.Drawing.Image)
        Me.btnEliSer.Location = New System.Drawing.Point(967, 7)
        Me.btnEliSer.Name = "btnEliSer"
        Me.btnEliSer.Size = New System.Drawing.Size(35, 27)
        Me.btnEliSer.TabIndex = 3
        Me.btnEliSer.UseVisualStyleBackColor = True
        Me.btnEliSer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'TabDocDigitales
        '
        Me.TabDocDigitales.Controls.Add(Me.GBox1)
        Me.TabDocDigitales.Location = New System.Drawing.Point(1, 25)
        Me.TabDocDigitales.Name = "TabDocDigitales"
        Me.TabDocDigitales.Size = New System.Drawing.Size(1167, 301)
        Me.TabDocDigitales.TabIndex = 4
        Me.TabDocDigitales.Text = "Documentos digitales"
        '
        'GBox1
        '
        Me.GBox1.Controls.Add(Me.Label2)
        Me.GBox1.Controls.Add(Me.btnBuscaDoc)
        Me.GBox1.Controls.Add(Me.btnFotDocA)
        Me.GBox1.Controls.Add(Me.LtFotoDoc)
        Me.GBox1.Controls.Add(Me.btnFotDocE)
        Me.GBox1.Controls.Add(Me.Label8)
        Me.GBox1.Controls.Add(Me.FgD)
        Me.GBox1.Controls.Add(Me.Label78)
        Me.GBox1.Controls.Add(Me.tDescrFotDoc)
        Me.GBox1.Location = New System.Drawing.Point(3, 3)
        Me.GBox1.Name = "GBox1"
        Me.GBox1.Size = New System.Drawing.Size(1014, 268)
        Me.GBox1.TabIndex = 271
        Me.GBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(839, 20)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "Documentos digitales"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscaDoc
        '
        Me.btnBuscaDoc.AutoSize = True
        Me.btnBuscaDoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscaDoc.Image = CType(resources.GetObject("btnBuscaDoc.Image"), System.Drawing.Image)
        Me.btnBuscaDoc.Location = New System.Drawing.Point(556, 62)
        Me.btnBuscaDoc.Name = "btnBuscaDoc"
        Me.btnBuscaDoc.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscaDoc.TabIndex = 263
        Me.btnBuscaDoc.UseVisualStyleBackColor = True
        '
        'btnFotDocA
        '
        Me.btnFotDocA.Image = CType(resources.GetObject("btnFotDocA.Image"), System.Drawing.Image)
        Me.btnFotDocA.Location = New System.Drawing.Point(749, 44)
        Me.btnFotDocA.Name = "btnFotDocA"
        Me.btnFotDocA.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocA.TabIndex = 264
        Me.btnFotDocA.UseVisualStyleBackColor = True
        Me.btnFotDocA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.btnFotDocA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtFotoDoc
        '
        Me.LtFotoDoc.BackColor = System.Drawing.Color.Silver
        Me.LtFotoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFotoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFotoDoc.Location = New System.Drawing.Point(89, 64)
        Me.LtFotoDoc.Name = "LtFotoDoc"
        Me.LtFotoDoc.Size = New System.Drawing.Size(466, 19)
        Me.LtFotoDoc.TabIndex = 270
        Me.LtFotoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFotDocE
        '
        Me.btnFotDocE.Image = CType(resources.GetObject("btnFotDocE.Image"), System.Drawing.Image)
        Me.btnFotDocE.Location = New System.Drawing.Point(803, 44)
        Me.btnFotDocE.Name = "btnFotDocE"
        Me.btnFotDocE.Size = New System.Drawing.Size(48, 33)
        Me.btnFotDocE.TabIndex = 265
        Me.btnFotDocE.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(14, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 269
        Me.Label8.Text = "Documento"
        '
        'FgD
        '
        Me.FgD.AllowFiltering = True
        Me.FgD.BackColor = System.Drawing.Color.White
        Me.FgD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgD.ColumnInfo = resources.GetString("FgD.ColumnInfo")
        Me.FgD.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgD.ForeColor = System.Drawing.Color.Black
        Me.FgD.Location = New System.Drawing.Point(14, 86)
        Me.FgD.Name = "FgD"
        Me.FgD.Rows.DefaultSize = 19
        Me.FgD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgD.Size = New System.Drawing.Size(839, 163)
        Me.FgD.StyleInfo = resources.GetString("FgD.StyleInfo")
        Me.FgD.TabIndex = 266
        Me.FgD.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.Location = New System.Drawing.Point(14, 44)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(72, 15)
        Me.Label78.TabIndex = 268
        Me.Label78.Text = "Descripción"
        '
        'tDescrFotDoc
        '
        Me.tDescrFotDoc.AcceptsReturn = True
        Me.tDescrFotDoc.AcceptsTab = True
        Me.tDescrFotDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescrFotDoc.Location = New System.Drawing.Point(88, 41)
        Me.tDescrFotDoc.Multiline = True
        Me.tDescrFotDoc.Name = "tDescrFotDoc"
        Me.tDescrFotDoc.Size = New System.Drawing.Size(467, 20)
        Me.tDescrFotDoc.TabIndex = 262
        '
        'TabObser
        '
        Me.TabObser.Controls.Add(Me.tOBSER)
        Me.TabObser.Location = New System.Drawing.Point(1, 25)
        Me.TabObser.Name = "TabObser"
        Me.TabObser.Size = New System.Drawing.Size(1167, 301)
        Me.TabObser.TabIndex = 2
        Me.TabObser.Text = "Observaciones"
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.Location = New System.Drawing.Point(24, 27)
        Me.tOBSER.Multiline = True
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(695, 134)
        Me.tOBSER.TabIndex = 1
        '
        'BtnSetMovRealizado
        '
        Me.BtnSetMovRealizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetMovRealizado.Location = New System.Drawing.Point(1082, 123)
        Me.BtnSetMovRealizado.Name = "BtnSetMovRealizado"
        Me.BtnSetMovRealizado.Size = New System.Drawing.Size(107, 23)
        Me.BtnSetMovRealizado.TabIndex = 143
        Me.BtnSetMovRealizado.Text = "SetMovs.Realizado"
        Me.BtnSetMovRealizado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSetMovRealizado.UseVisualStyleBackColor = True
        Me.BtnSetMovRealizado.Visible = False
        '
        'BtnDesCancel
        '
        Me.BtnDesCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDesCancel.Location = New System.Drawing.Point(1159, 94)
        Me.BtnDesCancel.Name = "BtnDesCancel"
        Me.BtnDesCancel.Size = New System.Drawing.Size(68, 23)
        Me.BtnDesCancel.TabIndex = 142
        Me.BtnDesCancel.Text = "DesCancel"
        Me.BtnDesCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDesCancel.UseVisualStyleBackColor = True
        Me.BtnDesCancel.Visible = False
        '
        'BtnMagix
        '
        Me.BtnMagix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMagix.Location = New System.Drawing.Point(1078, 94)
        Me.BtnMagix.Name = "BtnMagix"
        Me.BtnMagix.Size = New System.Drawing.Size(75, 23)
        Me.BtnMagix.TabIndex = 141
        Me.BtnMagix.Text = "ReParMinve"
        Me.BtnMagix.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnMagix.UseVisualStyleBackColor = True
        Me.BtnMagix.Visible = False
        '
        'btnAltaProducto
        '
        Me.btnAltaProducto.Image = CType(resources.GetObject("btnAltaProducto.Image"), System.Drawing.Image)
        Me.btnAltaProducto.Location = New System.Drawing.Point(1078, 176)
        Me.btnAltaProducto.Name = "btnAltaProducto"
        Me.btnAltaProducto.Size = New System.Drawing.Size(35, 30)
        Me.btnAltaProducto.TabIndex = 137
        Me.btnAltaProducto.UseVisualStyleBackColor = True
        Me.btnAltaProducto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliProd
        '
        Me.btnEliProd.Image = CType(resources.GetObject("btnEliProd.Image"), System.Drawing.Image)
        Me.btnEliProd.Location = New System.Drawing.Point(1154, 176)
        Me.btnEliProd.Name = "btnEliProd"
        Me.btnEliProd.Size = New System.Drawing.Size(35, 30)
        Me.btnEliProd.TabIndex = 138
        Me.btnEliProd.UseVisualStyleBackColor = True
        Me.btnEliProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "a6137de5656b4e28ab66d15771ef08e3"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1207, 157)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 3
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.ShowSearchButton = False
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(219, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 144
        Me.C1FlexGridSearchPanel1.Watermark = "Introduzca texto a buscar"
        '
        'LtNueva
        '
        Me.LtNueva.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LtNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNueva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNueva.Location = New System.Drawing.Point(1001, 9)
        Me.LtNueva.Name = "LtNueva"
        Me.LtNueva.Size = New System.Drawing.Size(99, 22)
        Me.LtNueva.TabIndex = 158
        Me.LtNueva.Text = "Nueva OT"
        Me.LtNueva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LtNueva.Visible = False
        '
        'FrmOrdenDeTrabajoExtAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 546)
        Me.Controls.Add(Me.LtNueva)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BtnSetMovRealizado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnDesCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnMagix)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.barMenu)
        Me.Controls.Add(Me.tBotonMagico)
        Me.Controls.Add(Me.btnEliProd)
        Me.Controls.Add(Me.btnAltaProducto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmOrdenDeTrabajoExtAE"
        Me.Text = "Orden de Trabajo Externa"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BtnServProg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProgServ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.TabProductos.ResumeLayout(False)
        Me.TabProductos.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabServicios.ResumeLayout(False)
        Me.TabServicios.PerformLayout()
        CType(Me.FgS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocDigitales.ResumeLayout(False)
        Me.GBox1.ResumeLayout(False)
        Me.GBox1.PerformLayout()
        CType(Me.btnFotDocA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFotDocE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabObser.ResumeLayout(False)
        Me.TabObser.PerformLayout()
        CType(Me.btnAltaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents L3 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tNOTA As TextBox
    Friend WithEvents tLUGAR_REP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents L4 As Label
    Friend WithEvents btnTipo As C1.Win.C1Input.C1Button
    Friend WithEvents tEstatus As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tCVE_TIPO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents radCorrectivo As RadioButton
    Friend WithEvents radPreventivo As RadioButton
    Friend WithEvents Label90 As Label
    Friend WithEvents tCVE_ORD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents TabProductos As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents btnEliSer As C1.Win.C1Input.C1Button
    Friend WithEvents TabObser As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnAltaServicio As C1.Win.C1Input.C1Button
    Friend WithEvents barFinOT As ToolStripMenuItem
    Friend WithEvents Lt1 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents tBotonMagico As TextBox
    Friend WithEvents TabServicios As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Lt5 As Label
    Friend WithEvents L5 As Label
    Friend WithEvents FgS As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnAltaProducto As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliProd As C1.Win.C1Input.C1Button
    Friend WithEvents TabDocDigitales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents btnBuscaDoc As Button
    Friend WithEvents LtFotoDoc As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents tDescrFotDoc As TextBox
    Friend WithEvents btnFotDocE As C1.Win.C1Input.C1Button
    Friend WithEvents btnFotDocA As C1.Win.C1Input.C1Button
    Friend WithEvents FgD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnProgServ As C1.Win.C1Input.C1Button
    Friend WithEvents LProgServ As Label
    Friend WithEvents BtnServProg As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROG As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarEnlazarDoc As ToolStripMenuItem
    Friend WithEvents LtDocAnt As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RadLLantas As RadioButton
    Friend WithEvents RadRescateCarr As RadioButton
    Friend WithEvents radSinistro As RadioButton
    Friend WithEvents barCancelarOT As ToolStripMenuItem
    Friend WithEvents BarRemisionar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BtnMagix As Button
    Friend WithEvents BtnDesCancel As Button
    Friend WithEvents BtnSetMovRealizado As Button
    Friend WithEvents Lt3 As Label
    Friend WithEvents LtPiezas As Label
    Friend WithEvents Lt4 As Label
    Friend WithEvents LtPar As Label
    Friend WithEvents BarReimpresion As ToolStripMenuItem
    Friend WithEvents BarKardex As ToolStripMenuItem
    Friend WithEvents BarCancPartNoEntr As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents LtNueva As Label
    Friend WithEvents GBox1 As GroupBox
End Class
