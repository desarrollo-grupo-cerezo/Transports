﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTPV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTPV))
        Me.BarraMENU = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTotales = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEnlaceDocumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTimbrarNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCFD = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSerie = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarObserDoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarObserPar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAltaProv = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAltaArticulo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCerrarPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReactivarPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtAlm = New System.Windows.Forms.Label()
        Me.CboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.Ldocu = New System.Windows.Forms.Label()
        Me.tEsquema = New C1.Win.C1Input.C1NumericEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.tEntregarEn = New System.Windows.Forms.TextBox()
        Me.TCVE_PEDI = New System.Windows.Forms.TextBox()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CboTipoVenta = New C1.Win.C1Input.C1ComboBox()
        Me.LEntregarEn = New System.Windows.Forms.Label()
        Me.tDesFin = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TDESC = New C1.Win.C1Input.C1NumericEdit()
        Me.LtDEsc = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtCP = New System.Windows.Forms.Label()
        Me.LtColonia = New System.Windows.Forms.Label()
        Me.LtRFC = New System.Windows.Forms.Label()
        Me.LtEstado = New System.Windows.Forms.Label()
        Me.LtNumExt = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LtNumInt = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtPoblacion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtCalle = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtVenta = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.tMagico2 = New System.Windows.Forms.TextBox()
        Me.TCVE_VEND = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtDocAnt = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LtSuc = New System.Windows.Forms.Label()
        Me.LtTOTAL = New System.Windows.Forms.Label()
        Me.tCONDICION = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LtFormaPagoSat = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtMetodoPago = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboPrecio = New C1.Win.C1Input.C1ComboBox()
        Me.LtFactura = New System.Windows.Forms.Label()
        Me.LtDocSig = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Page1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtImporte = New System.Windows.Forms.Label()
        Me.LtDocRel = New System.Windows.Forms.Label()
        Me.BtnCampos = New System.Windows.Forms.Button()
        Me.LtObra = New System.Windows.Forms.Label()
        Me.BtnObra = New C1.Win.C1Input.C1Button()
        Me.TOBRA = New System.Windows.Forms.TextBox()
        Me.LtOb1 = New System.Windows.Forms.Label()
        Me.btnEsquema = New C1.Win.C1Input.C1Button()
        Me.btnEntregarEn = New C1.Win.C1Input.C1Button()
        Me.BtnClie = New C1.Win.C1Input.C1Button()
        Me.BtnVend = New C1.Win.C1Input.C1Button()
        Me.Page2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.CboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txTC = New C1.Win.C1Input.C1TextBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.BtnDocRel = New C1.Win.C1Input.C1Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LtCorreo = New System.Windows.Forms.Label()
        Me.cbMetodoPago = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbRegimenesFiscales = New System.Windows.Forms.ComboBox()
        Me.cbUsoCfdi = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.BtnRefreshRegFisc = New System.Windows.Forms.Button()
        Me.Page3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtFAC_CVE_DOC = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LtUUID = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BtnFactura = New C1.Win.C1Input.C1Button()
        Me.LtCanc = New System.Windows.Forms.Label()
        Me.TXTN = New C1.Win.C1Input.C1NumericEdit()
        Me.TXT = New System.Windows.Forms.TextBox()
        Me.CboALmacenFG = New C1.Win.C1Input.C1ComboBox()
        Me.BarCancNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraMENU.SuspendLayout()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDesFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDESC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Page1.SuspendLayout()
        CType(Me.BtnObra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEntregarEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page2.SuspendLayout()
        CType(Me.txTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDocRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page3.SuspendLayout()
        CType(Me.BtnFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboALmacenFG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMENU
        '
        Me.BarraMENU.AutoSize = False
        Me.BarraMENU.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.BarraMENU.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.BarraMENU.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarTotales, Me.BarEnlaceDocumento, Me.BarKardex, Me.BarImprimir, Me.BarTimbrarNC, Me.BarCancNC, Me.MnuCFD, Me.BarSalir})
        Me.BarraMENU.Location = New System.Drawing.Point(0, 0)
        Me.BarraMENU.Name = "BarraMENU"
        Me.BarraMENU.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.BarraMENU.Size = New System.Drawing.Size(1513, 60)
        Me.BarraMENU.Stretch = False
        Me.BarraMENU.TabIndex = 9
        Me.BarraMENU.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarGrabar.ShortcutKeyDisplayString = "F3-Guardar"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(51, 52)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarGrabar.ToolTipText = "F2-Nuevo"
        '
        'BarTotales
        '
        Me.BarTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarTotales.ForeColor = System.Drawing.Color.Black
        Me.BarTotales.Image = Global.SGT_Transport.My.Resources.Resources.calc1
        Me.BarTotales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTotales.Name = "BarTotales"
        Me.BarTotales.ShortcutKeyDisplayString = "F4-Totales"
        Me.BarTotales.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarTotales.Size = New System.Drawing.Size(54, 52)
        Me.BarTotales.Text = "Totales"
        Me.BarTotales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEnlaceDocumento
        '
        Me.BarEnlaceDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEnlaceDocumento.ForeColor = System.Drawing.Color.Black
        Me.BarEnlaceDocumento.Image = Global.SGT_Transport.My.Resources.Resources.cont_poliza_traf
        Me.BarEnlaceDocumento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEnlaceDocumento.Name = "BarEnlaceDocumento"
        Me.BarEnlaceDocumento.ShortcutKeyDisplayString = "F5-Enlazar documento"
        Me.BarEnlaceDocumento.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarEnlaceDocumento.Size = New System.Drawing.Size(108, 52)
        Me.BarEnlaceDocumento.Text = "Enlace documento"
        Me.BarEnlaceDocumento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarKardex
        '
        Me.BarKardex.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarKardex.ForeColor = System.Drawing.Color.Black
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.BarKardex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.BarKardex.Size = New System.Drawing.Size(55, 52)
        Me.BarKardex.Text = "Kardex"
        Me.BarKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutKeyDisplayString = "F7 - Reimprimir"
        Me.BarImprimir.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.BarImprimir.Size = New System.Drawing.Size(78, 52)
        Me.BarImprimir.Text = "Reimprimir"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarTimbrarNC
        '
        Me.BarTimbrarNC.Image = Global.SGT_Transport.My.Resources.Resources.CFDI31_e
        Me.BarTimbrarNC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTimbrarNC.Name = "BarTimbrarNC"
        Me.BarTimbrarNC.Size = New System.Drawing.Size(143, 52)
        Me.BarTimbrarNC.Text = "Timbrar nota de crédito"
        Me.BarTimbrarNC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarTimbrarNC.Visible = False
        '
        'MnuCFD
        '
        Me.MnuCFD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarSerie, Me.BarCancelar, Me.BarCancelar2, Me.BarEliminar, Me.BarObserDoc, Me.BarObserPar, Me.BarLimpiar, Me.BarAltaProv, Me.BarAltaArticulo, Me.BarExcel, Me.BarCerrarPedido, Me.BarReactivarPedido})
        Me.MnuCFD.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.MnuCFD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuCFD.Name = "MnuCFD"
        Me.MnuCFD.Size = New System.Drawing.Size(78, 52)
        Me.MnuCFD.Text = "Opciones 1"
        Me.MnuCFD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSerie
        '
        Me.BarSerie.Image = Global.SGT_Transport.My.Resources.Resources.bin
        Me.BarSerie.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSerie.Name = "BarSerie"
        Me.BarSerie.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.BarSerie.Size = New System.Drawing.Size(257, 38)
        Me.BarSerie.Text = "Series"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.X1
        Me.BarCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.BarCancelar.Size = New System.Drawing.Size(257, 38)
        Me.BarCancelar.Text = "Cancelar"
        '
        'BarCancelar2
        '
        Me.BarCancelar2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarCancelar2.Image = Global.SGT_Transport.My.Resources.Resources.cancel1
        Me.BarCancelar2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelar2.Name = "BarCancelar2"
        Me.BarCancelar2.Size = New System.Drawing.Size(257, 38)
        Me.BarCancelar2.Text = "Cancelar especial"
        Me.BarCancelar2.Visible = False
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeyDisplayString = ""
        Me.BarEliminar.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.BarEliminar.Size = New System.Drawing.Size(257, 38)
        Me.BarEliminar.Text = "Eliminar par."
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarObserDoc
        '
        Me.BarObserDoc.Image = Global.SGT_Transport.My.Resources.Resources.finalizar53
        Me.BarObserDoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarObserDoc.Name = "BarObserDoc"
        Me.BarObserDoc.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.BarObserDoc.Size = New System.Drawing.Size(257, 38)
        Me.BarObserDoc.Text = "Observaciones documento"
        '
        'BarObserPar
        '
        Me.BarObserPar.Image = Global.SGT_Transport.My.Resources.Resources.finalizar23
        Me.BarObserPar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarObserPar.Name = "BarObserPar"
        Me.BarObserPar.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.BarObserPar.Size = New System.Drawing.Size(257, 38)
        Me.BarObserPar.Text = "Observaciones partida"
        '
        'BarLimpiar
        '
        Me.BarLimpiar.Image = Global.SGT_Transport.My.Resources.Resources.file_new
        Me.BarLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarLimpiar.Name = "BarLimpiar"
        Me.BarLimpiar.Size = New System.Drawing.Size(257, 38)
        Me.BarLimpiar.Text = "Limpiar"
        '
        'BarAltaProv
        '
        Me.BarAltaProv.Image = Global.SGT_Transport.My.Resources.Resources.Altacliente
        Me.BarAltaProv.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAltaProv.Name = "BarAltaProv"
        Me.BarAltaProv.Size = New System.Drawing.Size(257, 38)
        Me.BarAltaProv.Text = "Alta cliente"
        '
        'BarAltaArticulo
        '
        Me.BarAltaArticulo.Image = Global.SGT_Transport.My.Resources.Resources.Uni_med
        Me.BarAltaArticulo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAltaArticulo.Name = "BarAltaArticulo"
        Me.BarAltaArticulo.Size = New System.Drawing.Size(257, 38)
        Me.BarAltaArticulo.Text = "Alta articulo"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(257, 38)
        Me.BarExcel.Text = "Excel"
        '
        'BarCerrarPedido
        '
        Me.BarCerrarPedido.Image = Global.SGT_Transport.My.Resources.Resources.folder3
        Me.BarCerrarPedido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCerrarPedido.Name = "BarCerrarPedido"
        Me.BarCerrarPedido.Size = New System.Drawing.Size(257, 38)
        Me.BarCerrarPedido.Text = "Cerrar pedido"
        '
        'BarReactivarPedido
        '
        Me.BarReactivarPedido.Image = Global.SGT_Transport.My.Resources.Resources.folder3
        Me.BarReactivarPedido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReactivarPedido.Name = "BarReactivarPedido"
        Me.BarReactivarPedido.Size = New System.Drawing.Size(257, 38)
        Me.BarReactivarPedido.Text = "Reactivar pedido"
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarSalir.Size = New System.Drawing.Size(44, 52)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtAlm
        '
        Me.LtAlm.AutoSize = True
        Me.LtAlm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAlm.Location = New System.Drawing.Point(808, 130)
        Me.LtAlm.Name = "LtAlm"
        Me.LtAlm.Size = New System.Drawing.Size(60, 16)
        Me.LtAlm.TabIndex = 353
        Me.LtAlm.Text = "Almacen"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.AcceptsTab = True
        Me.CboAlmacen.AllowSpinLoop = False
        Me.CboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlmacen.GapHeight = 0
        Me.CboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboAlmacen.ItemsDisplayMember = ""
        Me.CboAlmacen.ItemsValueMember = ""
        Me.CboAlmacen.Location = New System.Drawing.Point(873, 129)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(153, 19)
        Me.CboAlmacen.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboAlmacen.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboAlmacen.TabIndex = 7
        Me.CboAlmacen.Tag = Nothing
        Me.CboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(302, 2)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(169, 31)
        Me.LtCVE_DOC.TabIndex = 351
        Me.LtCVE_DOC.Text = "0000000009"
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ldocu
        '
        Me.Ldocu.AutoSize = True
        Me.Ldocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ldocu.Location = New System.Drawing.Point(211, 9)
        Me.Ldocu.Name = "Ldocu"
        Me.Ldocu.Size = New System.Drawing.Size(89, 17)
        Me.Ldocu.TabIndex = 350
        Me.Ldocu.Text = "Documento"
        '
        'tEsquema
        '
        Me.tEsquema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tEsquema.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tEsquema.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEsquema.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEsquema.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tEsquema.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEsquema.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tEsquema.Location = New System.Drawing.Point(1445, 56)
        Me.tEsquema.Name = "tEsquema"
        Me.tEsquema.Size = New System.Drawing.Size(88, 20)
        Me.tEsquema.TabIndex = 10
        Me.tEsquema.Tag = Nothing
        Me.tEsquema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tEsquema.Visible = False
        Me.tEsquema.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.tEsquema.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tEsquema.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Enabled = False
        Me.F1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(574, 9)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(110, 22)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tEntregarEn
        '
        Me.tEntregarEn.AcceptsReturn = True
        Me.tEntregarEn.AcceptsTab = True
        Me.tEntregarEn.Location = New System.Drawing.Point(1445, 30)
        Me.tEntregarEn.MaxLength = 10
        Me.tEntregarEn.Name = "tEntregarEn"
        Me.tEntregarEn.Size = New System.Drawing.Size(79, 20)
        Me.tEntregarEn.TabIndex = 9
        Me.tEntregarEn.Visible = False
        '
        'TCVE_PEDI
        '
        Me.TCVE_PEDI.AcceptsReturn = True
        Me.TCVE_PEDI.AcceptsTab = True
        Me.TCVE_PEDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PEDI.Location = New System.Drawing.Point(873, 29)
        Me.TCVE_PEDI.Name = "TCVE_PEDI"
        Me.TCVE_PEDI.Size = New System.Drawing.Size(114, 22)
        Me.TCVE_PEDI.TabIndex = 3
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(873, 4)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(88, 22)
        Me.TCLIENTE.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 15)
        Me.Label19.TabIndex = 343
        Me.Label19.Text = "Tipo de venta"
        Me.Label19.Visible = False
        '
        'CboTipoVenta
        '
        Me.CboTipoVenta.AcceptsTab = True
        Me.CboTipoVenta.AllowSpinLoop = False
        Me.CboTipoVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTipoVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTipoVenta.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoVenta.GapHeight = 0
        Me.CboTipoVenta.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTipoVenta.ItemsDisplayMember = ""
        Me.CboTipoVenta.ItemsValueMember = ""
        Me.CboTipoVenta.Location = New System.Drawing.Point(96, 9)
        Me.CboTipoVenta.Name = "CboTipoVenta"
        Me.CboTipoVenta.Size = New System.Drawing.Size(64, 21)
        Me.CboTipoVenta.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboTipoVenta.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboTipoVenta.TabIndex = 0
        Me.CboTipoVenta.Tag = Nothing
        Me.CboTipoVenta.Visible = False
        Me.CboTipoVenta.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboTipoVenta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LEntregarEn
        '
        Me.LEntregarEn.AutoSize = True
        Me.LEntregarEn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEntregarEn.Location = New System.Drawing.Point(1377, 34)
        Me.LEntregarEn.Name = "LEntregarEn"
        Me.LEntregarEn.Size = New System.Drawing.Size(62, 13)
        Me.LEntregarEn.TabIndex = 342
        Me.LEntregarEn.Text = "Entregar en"
        Me.LEntregarEn.Visible = False
        '
        'tDesFin
        '
        Me.tDesFin.AcceptsTab = True
        Me.tDesFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDesFin.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tDesFin.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDesFin.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDesFin.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tDesFin.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tDesFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDesFin.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDesFin.Location = New System.Drawing.Point(1445, 84)
        Me.tDesFin.Name = "tDesFin"
        Me.tDesFin.Size = New System.Drawing.Size(73, 20)
        Me.tDesFin.TabIndex = 11
        Me.tDesFin.Tag = Nothing
        Me.tDesFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDesFin.UseWaitCursor = True
        Me.tDesFin.Visible = False
        Me.tDesFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tDesFin.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDesFin.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1380, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 16)
        Me.Label15.TabIndex = 341
        Me.Label15.Text = "Desc. fin."
        Me.Label15.UseWaitCursor = True
        Me.Label15.Visible = False
        '
        'TDESC
        '
        Me.TDESC.AcceptsTab = True
        Me.TDESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESC.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESC.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESC.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESC.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TDESC.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESC.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESC.Location = New System.Drawing.Point(873, 80)
        Me.TDESC.Name = "TDESC"
        Me.TDESC.Size = New System.Drawing.Size(73, 20)
        Me.TDESC.TabIndex = 5
        Me.TDESC.Tag = Nothing
        Me.TDESC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESC.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDEsc
        '
        Me.LtDEsc.AutoSize = True
        Me.LtDEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDEsc.Location = New System.Drawing.Point(796, 83)
        Me.LtDEsc.Name = "LtDEsc"
        Me.LtDEsc.Size = New System.Drawing.Size(72, 16)
        Me.LtDEsc.TabIndex = 340
        Me.LtDEsc.Text = "Descuento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1375, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 16)
        Me.Label13.TabIndex = 339
        Me.Label13.Text = "Esquema"
        Me.Label13.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(788, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 338
        Me.Label7.Text = "Cve. pedido"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(6, 244)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 300
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1446, 253)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 9
        '
        'LtCP
        '
        Me.LtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP.Location = New System.Drawing.Point(436, 82)
        Me.LtCP.Name = "LtCP"
        Me.LtCP.Size = New System.Drawing.Size(57, 18)
        Me.LtCP.TabIndex = 333
        '
        'LtColonia
        '
        Me.LtColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtColonia.Location = New System.Drawing.Point(574, 36)
        Me.LtColonia.Name = "LtColonia"
        Me.LtColonia.Size = New System.Drawing.Size(182, 20)
        Me.LtColonia.TabIndex = 324
        '
        'LtRFC
        '
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.Location = New System.Drawing.Point(574, 59)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(182, 20)
        Me.LtRFC.TabIndex = 330
        '
        'LtEstado
        '
        Me.LtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEstado.Location = New System.Drawing.Point(574, 82)
        Me.LtEstado.Name = "LtEstado"
        Me.LtEstado.Size = New System.Drawing.Size(182, 18)
        Me.LtEstado.TabIndex = 328
        '
        'LtNumExt
        '
        Me.LtNumExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumExt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumExt.Location = New System.Drawing.Point(272, 82)
        Me.LtNumExt.Name = "LtNumExt"
        Me.LtNumExt.Size = New System.Drawing.Size(100, 18)
        Me.LtNumExt.TabIndex = 337
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(227, 85)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 13)
        Me.Label21.TabIndex = 336
        Me.Label21.Text = "No.Ext."
        '
        'LtNumInt
        '
        Me.LtNumInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumInt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumInt.Location = New System.Drawing.Point(96, 82)
        Me.LtNumInt.Name = "LtNumInt"
        Me.LtNumInt.Size = New System.Drawing.Size(100, 18)
        Me.LtNumInt.TabIndex = 335
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(410, 85)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(21, 13)
        Me.Label20.TabIndex = 332
        Me.Label20.Text = "CP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(532, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 329
        Me.Label3.Text = "R.F.C."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(529, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 327
        Me.Label12.Text = "Estado"
        '
        'LtPoblacion
        '
        Me.LtPoblacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPoblacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPoblacion.Location = New System.Drawing.Point(96, 102)
        Me.LtPoblacion.Name = "LtPoblacion"
        Me.LtPoblacion.Size = New System.Drawing.Size(398, 22)
        Me.LtPoblacion.TabIndex = 326
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(527, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 323
        Me.Label8.Text = "Colonia"
        '
        'LtCalle
        '
        Me.LtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCalle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCalle.Location = New System.Drawing.Point(96, 59)
        Me.LtCalle.Name = "LtCalle"
        Me.LtCalle.Size = New System.Drawing.Size(397, 22)
        Me.LtCalle.TabIndex = 322
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(96, 36)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(398, 22)
        Me.LtNombre.TabIndex = 320
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(528, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "Fecha"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(52, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 334
        Me.Label18.Text = "No.Int."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(826, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 16)
        Me.Label14.TabIndex = 331
        Me.Label14.Text = "Clave"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 325
        Me.Label10.Text = "Población"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(61, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 321
        Me.Label6.Text = "Calle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 319
        Me.Label4.Text = "Razón social"
        '
        'LtVenta
        '
        Me.LtVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtVenta.Location = New System.Drawing.Point(1187, 10)
        Me.LtVenta.Name = "LtVenta"
        Me.LtVenta.Size = New System.Drawing.Size(314, 42)
        Me.LtVenta.TabIndex = 354
        Me.LtVenta.Text = "Nota de Venta"
        Me.LtVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "a992036792244b64ba7feedd77324348"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'tMagico2
        '
        Me.tMagico2.AcceptsReturn = True
        Me.tMagico2.AcceptsTab = True
        Me.tMagico2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMagico2.Location = New System.Drawing.Point(890, 23)
        Me.tMagico2.Name = "tMagico2"
        Me.tMagico2.Size = New System.Drawing.Size(36, 22)
        Me.tMagico2.TabIndex = 355
        '
        'TCVE_VEND
        '
        Me.TCVE_VEND.AcceptsReturn = True
        Me.TCVE_VEND.AcceptsTab = True
        Me.TCVE_VEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_VEND.Location = New System.Drawing.Point(873, 54)
        Me.TCVE_VEND.Name = "TCVE_VEND"
        Me.TCVE_VEND.Size = New System.Drawing.Size(88, 22)
        Me.TCVE_VEND.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(801, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 357
        Me.Label9.Text = "Vendedor"
        '
        'LtDocAnt
        '
        Me.LtDocAnt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocAnt.Location = New System.Drawing.Point(112, 512)
        Me.LtDocAnt.Name = "LtDocAnt"
        Me.LtDocAnt.Size = New System.Drawing.Size(101, 81)
        Me.LtDocAnt.TabIndex = 394
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(11, 513)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(94, 16)
        Me.Label30.TabIndex = 393
        Me.Label30.Text = "Doc. enlazado"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtSuc
        '
        Me.LtSuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSuc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSuc.Location = New System.Drawing.Point(1435, 36)
        Me.LtSuc.Name = "LtSuc"
        Me.LtSuc.Size = New System.Drawing.Size(226, 20)
        Me.LtSuc.TabIndex = 402
        Me.LtSuc.Visible = False
        '
        'LtTOTAL
        '
        Me.LtTOTAL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTOTAL.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTOTAL.Location = New System.Drawing.Point(1072, 500)
        Me.LtTOTAL.Name = "LtTOTAL"
        Me.LtTOTAL.Size = New System.Drawing.Size(373, 101)
        Me.LtTOTAL.TabIndex = 403
        Me.LtTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tCONDICION
        '
        Me.tCONDICION.AcceptsReturn = True
        Me.tCONDICION.AcceptsTab = True
        Me.tCONDICION.Location = New System.Drawing.Point(1467, 86)
        Me.tCONDICION.Name = "tCONDICION"
        Me.tCONDICION.Size = New System.Drawing.Size(182, 20)
        Me.tCONDICION.TabIndex = 5
        Me.tCONDICION.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1526, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 405
        Me.Label16.Text = "Condición"
        Me.Label16.Visible = False
        '
        'LtFormaPagoSat
        '
        Me.LtFormaPagoSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFormaPagoSat.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFormaPagoSat.Location = New System.Drawing.Point(680, 103)
        Me.LtFormaPagoSat.Name = "LtFormaPagoSat"
        Me.LtFormaPagoSat.Size = New System.Drawing.Size(76, 20)
        Me.LtFormaPagoSat.TabIndex = 409
        Me.LtFormaPagoSat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(574, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 13)
        Me.Label11.TabIndex = 407
        Me.Label11.Text = "Forma de pago SAT"
        '
        'LtMetodoPago
        '
        Me.LtMetodoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMetodoPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMetodoPago.Location = New System.Drawing.Point(680, 126)
        Me.LtMetodoPago.Name = "LtMetodoPago"
        Me.LtMetodoPago.Size = New System.Drawing.Size(76, 20)
        Me.LtMetodoPago.TabIndex = 413
        Me.LtMetodoPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(591, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 13)
        Me.Label17.TabIndex = 411
        Me.Label17.Text = "Metodo de pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(766, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 16)
        Me.Label2.TabIndex = 416
        Me.Label2.Text = "Lista de precios"
        '
        'CboPrecio
        '
        Me.CboPrecio.AcceptsTab = True
        Me.CboPrecio.AllowSpinLoop = False
        Me.CboPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboPrecio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboPrecio.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPrecio.GapHeight = 0
        Me.CboPrecio.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboPrecio.ItemsDisplayMember = ""
        Me.CboPrecio.ItemsValueMember = ""
        Me.CboPrecio.Location = New System.Drawing.Point(873, 105)
        Me.CboPrecio.Name = "CboPrecio"
        Me.CboPrecio.Size = New System.Drawing.Size(153, 19)
        Me.CboPrecio.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboPrecio.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboPrecio.TabIndex = 6
        Me.CboPrecio.Tag = Nothing
        Me.CboPrecio.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboPrecio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtFactura
        '
        Me.LtFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFactura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFactura.Location = New System.Drawing.Point(400, 501)
        Me.LtFactura.Name = "LtFactura"
        Me.LtFactura.Size = New System.Drawing.Size(169, 32)
        Me.LtFactura.TabIndex = 420
        Me.LtFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LtFactura.Visible = False
        '
        'LtDocSig
        '
        Me.LtDocSig.AutoSize = True
        Me.LtDocSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocSig.Location = New System.Drawing.Point(331, 511)
        Me.LtDocSig.Name = "LtDocSig"
        Me.LtDocSig.Size = New System.Drawing.Size(63, 17)
        Me.LtDocSig.TabIndex = 419
        Me.LtDocSig.Text = "Factura"
        Me.LtDocSig.Visible = False
        '
        'Tab1
        '
        Me.Tab1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.CanAutoHide = True
        Me.Tab1.Controls.Add(Me.Page1)
        Me.Tab1.Controls.Add(Me.Page2)
        Me.Tab1.Controls.Add(Me.Page3)
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(5, 63)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(1448, 179)
        Me.Tab1.TabIndex = 421
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Page1
        '
        Me.Page1.Controls.Add(Me.LtImporte)
        Me.Page1.Controls.Add(Me.LtDocRel)
        Me.Page1.Controls.Add(Me.BtnCampos)
        Me.Page1.Controls.Add(Me.LtObra)
        Me.Page1.Controls.Add(Me.BtnObra)
        Me.Page1.Controls.Add(Me.TOBRA)
        Me.Page1.Controls.Add(Me.LtOb1)
        Me.Page1.Controls.Add(Me.tCONDICION)
        Me.Page1.Controls.Add(Me.LtCVE_DOC)
        Me.Page1.Controls.Add(Me.Label4)
        Me.Page1.Controls.Add(Me.Label13)
        Me.Page1.Controls.Add(Me.Label6)
        Me.Page1.Controls.Add(Me.Label10)
        Me.Page1.Controls.Add(Me.Label15)
        Me.Page1.Controls.Add(Me.Label14)
        Me.Page1.Controls.Add(Me.Label18)
        Me.Page1.Controls.Add(Me.tDesFin)
        Me.Page1.Controls.Add(Me.Label1)
        Me.Page1.Controls.Add(Me.LtNombre)
        Me.Page1.Controls.Add(Me.LEntregarEn)
        Me.Page1.Controls.Add(Me.LtCalle)
        Me.Page1.Controls.Add(Me.Label8)
        Me.Page1.Controls.Add(Me.btnEsquema)
        Me.Page1.Controls.Add(Me.LtPoblacion)
        Me.Page1.Controls.Add(Me.Label2)
        Me.Page1.Controls.Add(Me.Label12)
        Me.Page1.Controls.Add(Me.tEntregarEn)
        Me.Page1.Controls.Add(Me.Label3)
        Me.Page1.Controls.Add(Me.CboPrecio)
        Me.Page1.Controls.Add(Me.Label20)
        Me.Page1.Controls.Add(Me.tEsquema)
        Me.Page1.Controls.Add(Me.LtNumInt)
        Me.Page1.Controls.Add(Me.LtMetodoPago)
        Me.Page1.Controls.Add(Me.Label21)
        Me.Page1.Controls.Add(Me.btnEntregarEn)
        Me.Page1.Controls.Add(Me.LtNumExt)
        Me.Page1.Controls.Add(Me.LtEstado)
        Me.Page1.Controls.Add(Me.LtSuc)
        Me.Page1.Controls.Add(Me.LtRFC)
        Me.Page1.Controls.Add(Me.Label16)
        Me.Page1.Controls.Add(Me.LtColonia)
        Me.Page1.Controls.Add(Me.LtCP)
        Me.Page1.Controls.Add(Me.Label17)
        Me.Page1.Controls.Add(Me.Label7)
        Me.Page1.Controls.Add(Me.LtFormaPagoSat)
        Me.Page1.Controls.Add(Me.LtDEsc)
        Me.Page1.Controls.Add(Me.TDESC)
        Me.Page1.Controls.Add(Me.CboTipoVenta)
        Me.Page1.Controls.Add(Me.Label11)
        Me.Page1.Controls.Add(Me.Label19)
        Me.Page1.Controls.Add(Me.TCLIENTE)
        Me.Page1.Controls.Add(Me.BtnClie)
        Me.Page1.Controls.Add(Me.TCVE_PEDI)
        Me.Page1.Controls.Add(Me.BtnVend)
        Me.Page1.Controls.Add(Me.F1)
        Me.Page1.Controls.Add(Me.TCVE_VEND)
        Me.Page1.Controls.Add(Me.Ldocu)
        Me.Page1.Controls.Add(Me.Label9)
        Me.Page1.Controls.Add(Me.CboAlmacen)
        Me.Page1.Controls.Add(Me.LtAlm)
        Me.Page1.Location = New System.Drawing.Point(1, 24)
        Me.Page1.Name = "Page1"
        Me.Page1.Size = New System.Drawing.Size(1446, 154)
        Me.Page1.TabIndex = 0
        Me.Page1.Text = "Datos documento"
        '
        'LtImporte
        '
        Me.LtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporte.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporte.Location = New System.Drawing.Point(1026, 62)
        Me.LtImporte.Name = "LtImporte"
        Me.LtImporte.Size = New System.Drawing.Size(125, 25)
        Me.LtImporte.TabIndex = 426
        Me.LtImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDocRel
        '
        Me.LtDocRel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDocRel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocRel.Location = New System.Drawing.Point(1026, 28)
        Me.LtDocRel.Name = "LtDocRel"
        Me.LtDocRel.Size = New System.Drawing.Size(125, 25)
        Me.LtDocRel.TabIndex = 425
        Me.LtDocRel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnCampos
        '
        Me.BtnCampos.Location = New System.Drawing.Point(514, 107)
        Me.BtnCampos.Name = "BtnCampos"
        Me.BtnCampos.Size = New System.Drawing.Size(49, 23)
        Me.BtnCampos.TabIndex = 424
        Me.BtnCampos.Text = "...."
        Me.BtnCampos.UseVisualStyleBackColor = True
        Me.BtnCampos.Visible = False
        '
        'LtObra
        '
        Me.LtObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtObra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtObra.Location = New System.Drawing.Point(254, 125)
        Me.LtObra.Name = "LtObra"
        Me.LtObra.Size = New System.Drawing.Size(239, 22)
        Me.LtObra.TabIndex = 423
        '
        'BtnObra
        '
        Me.BtnObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnObra.Image = CType(resources.GetObject("BtnObra.Image"), System.Drawing.Image)
        Me.BtnObra.Location = New System.Drawing.Point(227, 126)
        Me.BtnObra.Name = "BtnObra"
        Me.BtnObra.Size = New System.Drawing.Size(23, 20)
        Me.BtnObra.TabIndex = 422
        Me.BtnObra.UseVisualStyleBackColor = True
        Me.BtnObra.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TOBRA
        '
        Me.TOBRA.AcceptsReturn = True
        Me.TOBRA.AcceptsTab = True
        Me.TOBRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBRA.Location = New System.Drawing.Point(114, 125)
        Me.TOBRA.Name = "TOBRA"
        Me.TOBRA.Size = New System.Drawing.Size(107, 22)
        Me.TOBRA.TabIndex = 8
        '
        'LtOb1
        '
        Me.LtOb1.AutoSize = True
        Me.LtOb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOb1.Location = New System.Drawing.Point(4, 128)
        Me.LtOb1.Name = "LtOb1"
        Me.LtOb1.Size = New System.Drawing.Size(106, 16)
        Me.LtOb1.TabIndex = 420
        Me.LtOb1.Text = "Seleccione obra"
        '
        'btnEsquema
        '
        Me.btnEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEsquema.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnEsquema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsquema.Location = New System.Drawing.Point(1537, 55)
        Me.btnEsquema.Name = "btnEsquema"
        Me.btnEsquema.Size = New System.Drawing.Size(23, 20)
        Me.btnEsquema.TabIndex = 346
        Me.btnEsquema.UseVisualStyleBackColor = True
        Me.btnEsquema.Visible = False
        Me.btnEsquema.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEntregarEn
        '
        Me.btnEntregarEn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntregarEn.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnEntregarEn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEntregarEn.Location = New System.Drawing.Point(1525, 30)
        Me.btnEntregarEn.Name = "btnEntregarEn"
        Me.btnEntregarEn.Size = New System.Drawing.Size(23, 20)
        Me.btnEntregarEn.TabIndex = 401
        Me.btnEntregarEn.UseVisualStyleBackColor = True
        Me.btnEntregarEn.Visible = False
        Me.btnEntregarEn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnClie
        '
        Me.BtnClie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie.Image = CType(resources.GetObject("BtnClie.Image"), System.Drawing.Image)
        Me.BtnClie.Location = New System.Drawing.Point(963, 4)
        Me.BtnClie.Name = "BtnClie"
        Me.BtnClie.Size = New System.Drawing.Size(23, 20)
        Me.BtnClie.TabIndex = 345
        Me.BtnClie.UseVisualStyleBackColor = True
        Me.BtnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnVend
        '
        Me.BtnVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVend.Image = CType(resources.GetObject("BtnVend.Image"), System.Drawing.Image)
        Me.BtnVend.Location = New System.Drawing.Point(963, 55)
        Me.BtnVend.Name = "BtnVend"
        Me.BtnVend.Size = New System.Drawing.Size(23, 20)
        Me.BtnVend.TabIndex = 358
        Me.BtnVend.UseVisualStyleBackColor = True
        Me.BtnVend.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.CboMoneda)
        Me.Page2.Controls.Add(Me.Label22)
        Me.Page2.Controls.Add(Me.txTC)
        Me.Page2.Controls.Add(Me.Lt2)
        Me.Page2.Controls.Add(Me.BtnDocRel)
        Me.Page2.Controls.Add(Me.Label28)
        Me.Page2.Controls.Add(Me.LtCorreo)
        Me.Page2.Controls.Add(Me.cbMetodoPago)
        Me.Page2.Controls.Add(Me.Label24)
        Me.Page2.Controls.Add(Me.Label26)
        Me.Page2.Controls.Add(Me.cbFormaPago)
        Me.Page2.Controls.Add(Me.Label27)
        Me.Page2.Controls.Add(Me.Label5)
        Me.Page2.Controls.Add(Me.cbRegimenesFiscales)
        Me.Page2.Controls.Add(Me.cbUsoCfdi)
        Me.Page2.Controls.Add(Me.Label38)
        Me.Page2.Controls.Add(Me.BtnRefreshRegFisc)
        Me.Page2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Page2.Location = New System.Drawing.Point(1, 24)
        Me.Page2.Name = "Page2"
        Me.Page2.Size = New System.Drawing.Size(1446, 154)
        Me.Page2.TabIndex = 1
        Me.Page2.Text = "Datos CFDI"
        Me.Page2.Visible = False
        '
        'CboMoneda
        '
        Me.CboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoneda.DropDownWidth = 200
        Me.CboMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMoneda.FormattingEnabled = True
        Me.CboMoneda.Location = New System.Drawing.Point(145, 65)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(223, 24)
        Me.CboMoneda.TabIndex = 424
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(386, 72)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 16)
        Me.Label22.TabIndex = 423
        Me.Label22.Text = "T. C."
        '
        'txTC
        '
        Me.txTC.AcceptsReturn = True
        Me.txTC.AcceptsTab = True
        Me.txTC.AutoSize = False
        Me.txTC.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.txTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txTC.CustomFormat = "###,###,##0.000000"
        Me.txTC.DataType = GetType(Decimal)
        Me.txTC.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.txTC.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txTC.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txTC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txTC.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTC.Location = New System.Drawing.Point(426, 69)
        Me.txTC.Name = "txTC"
        Me.txTC.Size = New System.Drawing.Size(89, 22)
        Me.txTC.TabIndex = 422
        Me.txTC.Tag = Nothing
        Me.txTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txTC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(1076, 120)
        Me.Lt2.Margin = New System.Windows.Forms.Padding(3)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(71, 15)
        Me.Lt2.TabIndex = 421
        Me.Lt2.Text = "________"
        Me.Lt2.Visible = False
        '
        'BtnDocRel
        '
        Me.BtnDocRel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDocRel.Location = New System.Drawing.Point(1064, 66)
        Me.BtnDocRel.Name = "BtnDocRel"
        Me.BtnDocRel.Size = New System.Drawing.Size(128, 48)
        Me.BtnDocRel.TabIndex = 420
        Me.BtnDocRel.Text = "Documentos relacionados"
        Me.BtnDocRel.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(630, 118)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 16)
        Me.Label28.TabIndex = 418
        Me.Label28.Text = "Correo"
        '
        'LtCorreo
        '
        Me.LtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCorreo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCorreo.Location = New System.Drawing.Point(684, 115)
        Me.LtCorreo.Name = "LtCorreo"
        Me.LtCorreo.Size = New System.Drawing.Size(331, 20)
        Me.LtCorreo.TabIndex = 419
        '
        'cbMetodoPago
        '
        Me.cbMetodoPago.DisplayMember = "ClaveYDescripcion"
        Me.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMetodoPago.DropDownWidth = 250
        Me.cbMetodoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMetodoPago.FormattingEnabled = True
        Me.cbMetodoPago.Location = New System.Drawing.Point(684, 66)
        Me.cbMetodoPago.Name = "cbMetodoPago"
        Me.cbMetodoPago.Size = New System.Drawing.Size(253, 23)
        Me.cbMetodoPago.TabIndex = 416
        Me.cbMetodoPago.ValueMember = "Id"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(77, 71)
        Me.Label24.Margin = New System.Windows.Forms.Padding(3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 16)
        Me.Label24.TabIndex = 412
        Me.Label24.Text = "*Moneda"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(39, 115)
        Me.Label26.Margin = New System.Windows.Forms.Padding(3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 16)
        Me.Label26.TabIndex = 413
        Me.Label26.Text = "Forma de pago"
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DisplayMember = "ClaveYDescripcion"
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.DropDownWidth = 250
        Me.cbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(145, 111)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(279, 24)
        Me.cbFormaPago.TabIndex = 417
        Me.cbFormaPago.ValueMember = "Id"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(571, 71)
        Me.Label27.Margin = New System.Windows.Forms.Padding(3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(107, 16)
        Me.Label27.TabIndex = 414
        Me.Label27.Text = "Metodo de pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(577, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 16)
        Me.Label5.TabIndex = 409
        Me.Label5.Text = "*Regimen fiscal"
        '
        'cbRegimenesFiscales
        '
        Me.cbRegimenesFiscales.DisplayMember = "ClaveYDescripcion"
        Me.cbRegimenesFiscales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegimenesFiscales.DropDownWidth = 500
        Me.cbRegimenesFiscales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRegimenesFiscales.FormattingEnabled = True
        Me.cbRegimenesFiscales.Location = New System.Drawing.Point(684, 21)
        Me.cbRegimenesFiscales.Name = "cbRegimenesFiscales"
        Me.cbRegimenesFiscales.Size = New System.Drawing.Size(294, 24)
        Me.cbRegimenesFiscales.TabIndex = 410
        Me.cbRegimenesFiscales.ValueMember = "Id"
        '
        'cbUsoCfdi
        '
        Me.cbUsoCfdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUsoCfdi.DropDownWidth = 500
        Me.cbUsoCfdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUsoCfdi.FormattingEnabled = True
        Me.cbUsoCfdi.ItemHeight = 16
        Me.cbUsoCfdi.Location = New System.Drawing.Point(145, 21)
        Me.cbUsoCfdi.Name = "cbUsoCfdi"
        Me.cbUsoCfdi.Size = New System.Drawing.Size(223, 24)
        Me.cbUsoCfdi.TabIndex = 13
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(50, 26)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(89, 16)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "*Uso de CFDI"
        '
        'BtnRefreshRegFisc
        '
        Me.BtnRefreshRegFisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefreshRegFisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefreshRegFisc.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BtnRefreshRegFisc.Location = New System.Drawing.Point(1013, 21)
        Me.BtnRefreshRegFisc.Name = "BtnRefreshRegFisc"
        Me.BtnRefreshRegFisc.Size = New System.Drawing.Size(28, 23)
        Me.BtnRefreshRegFisc.TabIndex = 411
        Me.BtnRefreshRegFisc.UseVisualStyleBackColor = True
        '
        'Page3
        '
        Me.Page3.Controls.Add(Me.LtFAC_CVE_DOC)
        Me.Page3.Controls.Add(Me.Label23)
        Me.Page3.Controls.Add(Me.LtUUID)
        Me.Page3.Controls.Add(Me.Label25)
        Me.Page3.Controls.Add(Me.BtnFactura)
        Me.Page3.Location = New System.Drawing.Point(1, 24)
        Me.Page3.Name = "Page3"
        Me.Page3.Size = New System.Drawing.Size(1446, 154)
        Me.Page3.TabIndex = 2
        Me.Page3.Text = "Datos relacionados"
        '
        'LtFAC_CVE_DOC
        '
        Me.LtFAC_CVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFAC_CVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFAC_CVE_DOC.Location = New System.Drawing.Point(134, 41)
        Me.LtFAC_CVE_DOC.Name = "LtFAC_CVE_DOC"
        Me.LtFAC_CVE_DOC.Size = New System.Drawing.Size(223, 24)
        Me.LtFAC_CVE_DOC.TabIndex = 408
        Me.LtFAC_CVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(76, 44)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 16)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Factura"
        '
        'LtUUID
        '
        Me.LtUUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUUID.Location = New System.Drawing.Point(134, 84)
        Me.LtUUID.Name = "LtUUID"
        Me.LtUUID.Size = New System.Drawing.Size(337, 24)
        Me.LtUUID.TabIndex = 405
        Me.LtUUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 87)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(118, 16)
        Me.Label25.TabIndex = 407
        Me.Label25.Text = "CFDI Relacionado"
        '
        'BtnFactura
        '
        Me.BtnFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFactura.Image = CType(resources.GetObject("BtnFactura.Image"), System.Drawing.Image)
        Me.BtnFactura.Location = New System.Drawing.Point(361, 43)
        Me.BtnFactura.Name = "BtnFactura"
        Me.BtnFactura.Size = New System.Drawing.Size(24, 21)
        Me.BtnFactura.TabIndex = 406
        Me.BtnFactura.UseVisualStyleBackColor = True
        Me.BtnFactura.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCanc
        '
        Me.LtCanc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LtCanc.AutoSize = True
        Me.LtCanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCanc.ForeColor = System.Drawing.Color.Red
        Me.LtCanc.Location = New System.Drawing.Point(1016, 10)
        Me.LtCanc.Name = "LtCanc"
        Me.LtCanc.Size = New System.Drawing.Size(165, 29)
        Me.LtCanc.TabIndex = 422
        Me.LtCanc.Text = "CANCELADA"
        Me.LtCanc.Visible = False
        '
        'TXTN
        '
        Me.TXTN.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTN.BorderColor = System.Drawing.Color.Blue
        Me.TXTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TXTN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TXTN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TXTN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TXTN.CustomFormat = "###,###,###,##0.0000"
        Me.TXTN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TXTN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TXTN.ImagePadding = New System.Windows.Forms.Padding(45, 0, 0, 0)
        Me.TXTN.Location = New System.Drawing.Point(698, 512)
        Me.TXTN.Name = "TXTN"
        Me.TXTN.Size = New System.Drawing.Size(88, 18)
        Me.TXTN.TabIndex = 10
        Me.TXTN.Tag = Nothing
        Me.TXTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTN.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TXTN.Visible = False
        Me.TXTN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TXTN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TXT
        '
        Me.TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT.Location = New System.Drawing.Point(698, 543)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(88, 20)
        Me.TXT.TabIndex = 11
        Me.TXT.Visible = False
        '
        'CboALmacenFG
        '
        Me.CboALmacenFG.AllowSpinLoop = False
        Me.CboALmacenFG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboALmacenFG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboALmacenFG.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboALmacenFG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboALmacenFG.GapHeight = 0
        Me.CboALmacenFG.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboALmacenFG.ItemsDisplayMember = ""
        Me.CboALmacenFG.ItemsValueMember = ""
        Me.CboALmacenFG.Location = New System.Drawing.Point(645, 569)
        Me.CboALmacenFG.Name = "CboALmacenFG"
        Me.CboALmacenFG.Size = New System.Drawing.Size(141, 19)
        Me.CboALmacenFG.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboALmacenFG.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboALmacenFG.TabIndex = 532
        Me.CboALmacenFG.Tag = Nothing
        Me.CboALmacenFG.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboALmacenFG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BarCancNC
        '
        Me.BarCancNC.Image = Global.SGT_Transport.My.Resources.Resources.cfdi6
        Me.BarCancNC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancNC.Name = "BarCancNC"
        Me.BarCancNC.Size = New System.Drawing.Size(148, 52)
        Me.BarCancNC.Text = "Cancelar nota de crédito"
        Me.BarCancNC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarCancNC.Visible = False
        '
        'FrmTPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1513, 641)
        Me.Controls.Add(Me.CboALmacenFG)
        Me.Controls.Add(Me.LtCanc)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.LtFactura)
        Me.Controls.Add(Me.LtDocSig)
        Me.Controls.Add(Me.LtTOTAL)
        Me.Controls.Add(Me.LtDocAnt)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.LtVenta)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMENU)
        Me.Controls.Add(Me.tMagico2)
        Me.Controls.Add(Me.TXTN)
        Me.Controls.Add(Me.TXT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTPV"
        Me.ShowInTaskbar = False
        Me.Text = "Punto de venta"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMENU.ResumeLayout(False)
        Me.BarraMENU.PerformLayout()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDesFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDESC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Page1.ResumeLayout(False)
        Me.Page1.PerformLayout()
        CType(Me.BtnObra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEntregarEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page2.ResumeLayout(False)
        Me.Page2.PerformLayout()
        CType(Me.txTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDocRel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page3.ResumeLayout(False)
        Me.Page3.PerformLayout()
        CType(Me.BtnFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboALmacenFG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMENU As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarTotales As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents LtAlm As Label
    Friend WithEvents CboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Ldocu As Label
    Friend WithEvents tEsquema As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents tEntregarEn As TextBox
    Friend WithEvents TCVE_PEDI As TextBox
    Friend WithEvents btnEsquema As C1.Win.C1Input.C1Button
    Friend WithEvents BtnClie As C1.Win.C1Input.C1Button
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents CboTipoVenta As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LEntregarEn As Label
    Friend WithEvents tDesFin As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents TDESC As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents LtDEsc As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtCP As Label
    Friend WithEvents LtColonia As Label
    Friend WithEvents LtRFC As Label
    Friend WithEvents LtEstado As Label
    Friend WithEvents LtNumExt As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents LtNumInt As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LtPoblacion As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LtCalle As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LtVenta As Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents tMagico2 As TextBox
    Friend WithEvents BarEnlaceDocumento As ToolStripMenuItem
    Friend WithEvents BtnVend As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_VEND As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LtDocAnt As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents btnEntregarEn As C1.Win.C1Input.C1Button
    Friend WithEvents LtSuc As Label
    Friend WithEvents LtTOTAL As Label
    Friend WithEvents tCONDICION As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents LtFormaPagoSat As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LtMetodoPago As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CboPrecio As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LtFactura As Label
    Friend WithEvents LtDocSig As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Page1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Page2 As C1.Win.C1Command.C1DockingTabPage
    Private WithEvents cbUsoCfdi As ComboBox
    Private WithEvents Label38 As Label
    Private WithEvents Label23 As Label
    Friend WithEvents LtUUID As Label
    Friend WithEvents BtnFactura As C1.Win.C1Input.C1Button
    Friend WithEvents LtFAC_CVE_DOC As Label
    Private WithEvents Label25 As Label
    Friend WithEvents MnuCFD As ToolStripMenuItem
    Friend WithEvents BarSerie As ToolStripMenuItem
    Friend WithEvents BarCancelar As ToolStripMenuItem
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents BarKardex As ToolStripMenuItem
    Private WithEvents Label5 As Label
    Private WithEvents cbRegimenesFiscales As ComboBox
    Private WithEvents BtnRefreshRegFisc As Button
    Private WithEvents cbMetodoPago As ComboBox
    Private WithEvents Label24 As Label
    Private WithEvents Label26 As Label
    Private WithEvents cbFormaPago As ComboBox
    Private WithEvents Label27 As Label
    Friend WithEvents Page3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BarImprimir As ToolStripMenuItem
    Friend WithEvents Label28 As Label
    Friend WithEvents LtCorreo As Label
    Friend WithEvents LtCanc As Label
    Friend WithEvents BtnDocRel As C1.Win.C1Input.C1Button
    Private WithEvents Lt2 As Label
    Friend WithEvents BarObserDoc As ToolStripMenuItem
    Friend WithEvents BarObserPar As ToolStripMenuItem
    Friend WithEvents BarLimpiar As ToolStripMenuItem
    Friend WithEvents BarAltaProv As ToolStripMenuItem
    Friend WithEvents BarAltaArticulo As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarCancelar2 As ToolStripMenuItem
    Friend WithEvents BarTimbrarNC As ToolStripMenuItem
    Friend WithEvents LtObra As Label
    Friend WithEvents BtnObra As C1.Win.C1Input.C1Button
    Friend WithEvents TOBRA As TextBox
    Friend WithEvents LtOb1 As Label
    Friend WithEvents BtnCampos As Button
    Friend WithEvents BarCerrarPedido As ToolStripMenuItem
    Friend WithEvents BarReactivarPedido As ToolStripMenuItem
    Friend WithEvents TXTN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TXT As TextBox
    Friend WithEvents CboALmacenFG As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txTC As C1.Win.C1Input.C1TextBox
    Private WithEvents CboMoneda As ComboBox
    Friend WithEvents LtDocRel As Label
    Friend WithEvents LtImporte As Label
    Friend WithEvents BarCancNC As ToolStripMenuItem
End Class
