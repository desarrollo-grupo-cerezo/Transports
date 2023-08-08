<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInven
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInven))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarListaPrecio = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAltaAlmacen = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarMenuOp = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCAMBIOESTATUS = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarESTATUSBAJA = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarPRECIOS = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarKITS = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarDesplegarArticulosServicios = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboLinea = New System.Windows.Forms.ToolStripComboBox()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Lt = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarraMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BtnEliminar, Me.BarRefresh, Me.BarListaPrecio, Me.BarAltaAlmacen, Me.BarKardex, Me.BarExcel, Me.BarMenuOp, Me.BarSalir, Me.ToolStripMenuItem1, Me.cboLinea})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1443, 55)
        Me.BarraMenu.TabIndex = 10
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarNuevo.Size = New System.Drawing.Size(54, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarNuevo.ToolTipText = "F2-Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarEdit.Size = New System.Drawing.Size(44, 51)
        Me.BarEdit.Text = "Edit"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BtnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 51)
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRefresh
        '
        Me.BarRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRefresh.ForeColor = System.Drawing.Color.Black
        Me.BarRefresh.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarRefresh.Size = New System.Drawing.Size(67, 51)
        Me.BarRefresh.Text = "Refrescar"
        Me.BarRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarListaPrecio
        '
        Me.BarListaPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarListaPrecio.ForeColor = System.Drawing.Color.Black
        Me.BarListaPrecio.Image = Global.SGT_Transport.My.Resources.Resources.FAC1
        Me.BarListaPrecio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarListaPrecio.Name = "BarListaPrecio"
        Me.BarListaPrecio.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarListaPrecio.Size = New System.Drawing.Size(57, 51)
        Me.BarListaPrecio.Text = "Precios"
        Me.BarListaPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarAltaAlmacen
        '
        Me.BarAltaAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarAltaAlmacen.ForeColor = System.Drawing.Color.Black
        Me.BarAltaAlmacen.Image = Global.SGT_Transport.My.Resources.Resources.Multi_almac
        Me.BarAltaAlmacen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAltaAlmacen.Name = "BarAltaAlmacen"
        Me.BarAltaAlmacen.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarAltaAlmacen.Size = New System.Drawing.Size(77, 51)
        Me.BarAltaAlmacen.Text = "Almacenes"
        Me.BarAltaAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarKardex
        '
        Me.BarKardex.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarKardex.ForeColor = System.Drawing.Color.Black
        Me.BarKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.BarKardex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarKardex.Name = "BarKardex"
        Me.BarKardex.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarKardex.Size = New System.Drawing.Size(55, 51)
        Me.BarKardex.Text = "Kardex"
        Me.BarKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(48, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarMenuOp
        '
        Me.BarMenuOp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarCAMBIOESTATUS, Me.BarESTATUSBAJA, Me.BarPRECIOS, Me.BarKITS, Me.BarDesplegarArticulosServicios})
        Me.BarMenuOp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarMenuOp.ForeColor = System.Drawing.Color.Black
        Me.BarMenuOp.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.BarMenuOp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarMenuOp.Name = "BarMenuOp"
        Me.BarMenuOp.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarMenuOp.Size = New System.Drawing.Size(69, 51)
        Me.BarMenuOp.Text = "Opciones"
        Me.BarMenuOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCAMBIOESTATUS
        '
        Me.BarCAMBIOESTATUS.Name = "BarCAMBIOESTATUS"
        Me.BarCAMBIOESTATUS.Size = New System.Drawing.Size(262, 22)
        Me.BarCAMBIOESTATUS.Text = "Cambio de estatus"
        '
        'BarESTATUSBAJA
        '
        Me.BarESTATUSBAJA.Name = "BarESTATUSBAJA"
        Me.BarESTATUSBAJA.Size = New System.Drawing.Size(262, 22)
        Me.BarESTATUSBAJA.Text = "Desplegar articulos con estatus baja"
        '
        'BarPRECIOS
        '
        Me.BarPRECIOS.Name = "BarPRECIOS"
        Me.BarPRECIOS.Size = New System.Drawing.Size(262, 22)
        Me.BarPRECIOS.Text = "Precios"
        '
        'BarKITS
        '
        Me.BarKITS.Name = "BarKITS"
        Me.BarKITS.Size = New System.Drawing.Size(262, 22)
        Me.BarKITS.Text = "Kit's"
        '
        'BarDesplegarArticulosServicios
        '
        Me.BarDesplegarArticulosServicios.Name = "BarDesplegarArticulosServicios"
        Me.BarDesplegarArticulosServicios.Size = New System.Drawing.Size(262, 22)
        Me.BarDesplegarArticulosServicios.Text = "Desplegar articulos servicios"
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(112, 51)
        Me.ToolStripMenuItem1.Text = "   Seleccione linea"
        '
        'cboLinea
        '
        Me.cboLinea.BackColor = System.Drawing.Color.White
        Me.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinea.DropDownWidth = 180
        Me.cboLinea.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboLinea.ForeColor = System.Drawing.Color.Black
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Size = New System.Drawing.Size(150, 51)
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "51,1,0,0,0,95,Columns:"
        Me.Fg.ExtendLastCol = True
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 80)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowErrors = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1004, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        '
        'Lt
        '
        Me.Lt.Location = New System.Drawing.Point(1218, 9)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(213, 23)
        Me.Lt.TabIndex = 16
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(900, 7)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(241, 41)
        Me.C1FlexGridSearchPanel1.TabIndex = 380
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'FrmInven
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1443, 524)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmInven"
        Me.Text = "Servicios de venta"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarNuevo As ToolStripMenuItem
    Friend WithEvents BarEdit As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Lt As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents BarMenuOp As ToolStripMenuItem
    Friend WithEvents BtnEliminar As ToolStripMenuItem
    Friend WithEvents BarRefresh As ToolStripMenuItem
    Friend WithEvents BarKardex As ToolStripMenuItem
    Friend WithEvents BarCAMBIOESTATUS As ToolStripMenuItem
    Friend WithEvents BarESTATUSBAJA As ToolStripMenuItem
    Friend WithEvents BarPRECIOS As ToolStripMenuItem
    Friend WithEvents BarKITS As ToolStripMenuItem
    Friend WithEvents cboLinea As ToolStripComboBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BarDesplegarArticulosServicios As ToolStripMenuItem
    Friend WithEvents BarAltaAlmacen As ToolStripMenuItem
    Friend WithEvents BarListaPrecio As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
End Class
