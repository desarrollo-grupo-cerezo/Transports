<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturacionAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturacionAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tCVE_CON = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.LtCalle = New System.Windows.Forms.Label()
        Me.LtRFC = New System.Windows.Forms.Label()
        Me.LtCiudad = New System.Windows.Forms.Label()
        Me.LtEstado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtClave = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.LtSubTotal = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.LtIva = New System.Windows.Forms.Label()
        Me.LtRet = New System.Windows.Forms.Label()
        Me.LtDesc = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.LtCP = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LtCol = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.LtNoExt = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LtNoINt = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnViaje = New System.Windows.Forms.Button()
        Me.LtViaje = New System.Windows.Forms.Label()
        Me.tDesc = New C1.Win.C1Input.C1NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.LtFecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1027, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 26
        Me.barSalir.Text = "MenuStrip1"
        Me.C1ThemeController1.SetTheme(Me.barSalir, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(27, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 236
        Me.Label13.Text = "Nombre"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2010Blue")
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(31, 190)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 240
        Me.Label24.Text = "Ciudad"
        Me.C1ThemeController1.SetTheme(Me.Label24, "Office2010Blue")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(34, 168)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 237
        Me.Label21.Text = "R.F.C."
        Me.C1ThemeController1.SetTheme(Me.Label21, "Office2010Blue")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(19, 148)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 238
        Me.Label19.Text = "Dirección"
        Me.C1ThemeController1.SetTheme(Me.Label19, "Office2010Blue")
        '
        'tCVE_CON
        '
        Me.tCVE_CON.AcceptsReturn = True
        Me.tCVE_CON.AcceptsTab = True
        Me.tCVE_CON.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_CON.ForeColor = System.Drawing.Color.Black
        Me.tCVE_CON.Location = New System.Drawing.Point(74, 69)
        Me.tCVE_CON.Name = "tCVE_CON"
        Me.tCVE_CON.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_CON.TabIndex = 266
        Me.C1ThemeController1.SetTheme(Me.tCVE_CON, "Office2010Blue")
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(8, 72)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(63, 14)
        Me.Label31.TabIndex = 265
        Me.Label31.Text = "Contrato"
        Me.C1ThemeController1.SetTheme(Me.Label31, "Office2010Blue")
        '
        'btnContrato
        '
        Me.btnContrato.AutoSize = True
        Me.btnContrato.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnContrato.BackColor = System.Drawing.Color.Transparent
        Me.btnContrato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnContrato.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnContrato.Location = New System.Drawing.Point(144, 69)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(24, 23)
        Me.btnContrato.TabIndex = 267
        Me.C1ThemeController1.SetTheme(Me.btnContrato, "Office2010Blue")
        Me.btnContrato.UseVisualStyleBackColor = True
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(74, 122)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(376, 20)
        Me.LtNombre.TabIndex = 269
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtNombre, "Office2010Blue")
        '
        'LtCalle
        '
        Me.LtCalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCalle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCalle.Location = New System.Drawing.Point(74, 144)
        Me.LtCalle.Name = "LtCalle"
        Me.LtCalle.Size = New System.Drawing.Size(375, 20)
        Me.LtCalle.TabIndex = 270
        Me.LtCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCalle, "Office2010Blue")
        '
        'LtRFC
        '
        Me.LtRFC.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtRFC.Location = New System.Drawing.Point(74, 166)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(117, 20)
        Me.LtRFC.TabIndex = 271
        Me.LtRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtRFC, "Office2010Blue")
        '
        'LtCiudad
        '
        Me.LtCiudad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCiudad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCiudad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCiudad.Location = New System.Drawing.Point(74, 188)
        Me.LtCiudad.Name = "LtCiudad"
        Me.LtCiudad.Size = New System.Drawing.Size(213, 20)
        Me.LtCiudad.TabIndex = 272
        Me.LtCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCiudad, "Office2010Blue")
        '
        'LtEstado
        '
        Me.LtEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEstado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtEstado.Location = New System.Drawing.Point(331, 188)
        Me.LtEstado.Name = "LtEstado"
        Me.LtEstado.Size = New System.Drawing.Size(118, 20)
        Me.LtEstado.TabIndex = 274
        Me.LtEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtEstado, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(291, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 273
        Me.Label6.Text = "Estado"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'LtClave
        '
        Me.LtClave.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtClave.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtClave.Location = New System.Drawing.Point(666, 95)
        Me.LtClave.Name = "LtClave"
        Me.LtClave.Size = New System.Drawing.Size(69, 20)
        Me.LtClave.TabIndex = 276
        Me.LtClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtClave, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(626, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Clave"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(11, 220)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 5
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(992, 179)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 277
        Me.C1ThemeController1.SetTheme(Me.Fg, "Office2010Blue")
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.C1ThemeController1.SetTheme(Me.C1SuperTooltip1, "Office2010Blue")
        '
        'LtSubTotal
        '
        Me.LtSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSubTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtSubTotal.Location = New System.Drawing.Point(759, 429)
        Me.LtSubTotal.Name = "LtSubTotal"
        Me.LtSubTotal.Size = New System.Drawing.Size(140, 20)
        Me.LtSubTotal.TabIndex = 289
        Me.LtSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtSubTotal, "Office2010Blue")
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(697, 432)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(61, 14)
        Me.Lt1.TabIndex = 288
        Me.Lt1.Text = "Subtotal"
        Me.C1ThemeController1.SetTheme(Me.Lt1, "Office2010Blue")
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtTotal.Location = New System.Drawing.Point(759, 517)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(140, 20)
        Me.LtTotal.TabIndex = 285
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTotal, "Office2010Blue")
        '
        'LtIva
        '
        Me.LtIva.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtIva.Location = New System.Drawing.Point(759, 495)
        Me.LtIva.Name = "LtIva"
        Me.LtIva.Size = New System.Drawing.Size(140, 20)
        Me.LtIva.TabIndex = 284
        Me.LtIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtIva, "Office2010Blue")
        '
        'LtRet
        '
        Me.LtRet.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtRet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtRet.Location = New System.Drawing.Point(759, 473)
        Me.LtRet.Name = "LtRet"
        Me.LtRet.Size = New System.Drawing.Size(140, 20)
        Me.LtRet.TabIndex = 283
        Me.LtRet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtRet, "Office2010Blue")
        '
        'LtDesc
        '
        Me.LtDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtDesc.Location = New System.Drawing.Point(759, 451)
        Me.LtDesc.Name = "LtDesc"
        Me.LtDesc.Size = New System.Drawing.Size(140, 20)
        Me.LtDesc.TabIndex = 282
        Me.LtDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtDesc, "Office2010Blue")
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt2.Location = New System.Drawing.Point(686, 454)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(72, 14)
        Me.Lt2.TabIndex = 278
        Me.Lt2.Text = "Descuento"
        Me.C1ThemeController1.SetTheme(Me.Lt2, "Office2010Blue")
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt5.Location = New System.Drawing.Point(720, 520)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(38, 14)
        Me.Lt5.TabIndex = 281
        Me.Lt5.Text = "Total"
        Me.C1ThemeController1.SetTheme(Me.Lt5, "Office2010Blue")
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt4.Location = New System.Drawing.Point(717, 498)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(41, 14)
        Me.Lt4.TabIndex = 279
        Me.Lt4.Text = "I.V.A."
        Me.C1ThemeController1.SetTheme(Me.Lt4, "Office2010Blue")
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt3.Location = New System.Drawing.Point(663, 477)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(95, 14)
        Me.Lt3.TabIndex = 280
        Me.Lt3.Text = "Retención IVA"
        Me.C1ThemeController1.SetTheme(Me.Lt3, "Office2010Blue")
        '
        'LtCP
        '
        Me.LtCP.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCP.Location = New System.Drawing.Point(225, 166)
        Me.LtCP.Name = "LtCP"
        Me.LtCP.Size = New System.Drawing.Size(63, 20)
        Me.LtCP.TabIndex = 291
        Me.LtCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCP, "Office2010Blue")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(198, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 290
        Me.Label12.Text = "C.P."
        Me.C1ThemeController1.SetTheme(Me.Label12, "Office2010Blue")
        '
        'LtCol
        '
        Me.LtCol.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCol.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCol.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCol.Location = New System.Drawing.Point(331, 166)
        Me.LtCol.Name = "LtCol"
        Me.LtCol.Size = New System.Drawing.Size(118, 20)
        Me.LtCol.TabIndex = 293
        Me.LtCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCol, "Office2010Blue")
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(289, 169)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 13)
        Me.Label26.TabIndex = 292
        Me.Label26.Text = "Colonia"
        Me.C1ThemeController1.SetTheme(Me.Label26, "Office2010Blue")
        '
        'LtNoExt
        '
        Me.LtNoExt.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNoExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNoExt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNoExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNoExt.Location = New System.Drawing.Point(511, 166)
        Me.LtNoExt.Name = "LtNoExt"
        Me.LtNoExt.Size = New System.Drawing.Size(63, 20)
        Me.LtNoExt.TabIndex = 297
        Me.LtNoExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtNoExt, "Office2010Blue")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(460, 169)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 296
        Me.Label28.Text = "No. Ext."
        Me.C1ThemeController1.SetTheme(Me.Label28, "Office2010Blue")
        '
        'LtNoINt
        '
        Me.LtNoINt.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNoINt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNoINt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNoINt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNoINt.Location = New System.Drawing.Point(511, 144)
        Me.LtNoINt.Name = "LtNoINt"
        Me.LtNoINt.Size = New System.Drawing.Size(63, 20)
        Me.LtNoINt.TabIndex = 295
        Me.LtNoINt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtNoINt, "Office2010Blue")
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(463, 147)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 13)
        Me.Label30.TabIndex = 294
        Me.Label30.Text = "No. Int."
        Me.C1ThemeController1.SetTheme(Me.Label30, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(601, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 299
        Me.Label1.Text = "Descuento"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.ForeColor = System.Drawing.Color.Black
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(74, 95)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_VIAJE.TabIndex = 301
        Me.C1ThemeController1.SetTheme(Me.tCVE_VIAJE, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(35, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 300
        Me.Label2.Text = "Viaje"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'btnViaje
        '
        Me.btnViaje.AutoSize = True
        Me.btnViaje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnViaje.BackColor = System.Drawing.Color.Transparent
        Me.btnViaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnViaje.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnViaje.Location = New System.Drawing.Point(143, 95)
        Me.btnViaje.Name = "btnViaje"
        Me.btnViaje.Size = New System.Drawing.Size(24, 23)
        Me.btnViaje.TabIndex = 302
        Me.C1ThemeController1.SetTheme(Me.btnViaje, "Office2010Blue")
        Me.btnViaje.UseVisualStyleBackColor = True
        '
        'LtViaje
        '
        Me.LtViaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtViaje.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtViaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtViaje.Location = New System.Drawing.Point(167, 95)
        Me.LtViaje.Name = "LtViaje"
        Me.LtViaje.Size = New System.Drawing.Size(283, 20)
        Me.LtViaje.TabIndex = 303
        Me.LtViaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtViaje, "Office2010Blue")
        '
        'tDesc
        '
        Me.tDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDesc.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tDesc.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDesc.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.tDesc.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tDesc.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tDesc.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDesc.Location = New System.Drawing.Point(666, 122)
        Me.tDesc.Name = "tDesc"
        Me.tDesc.Size = New System.Drawing.Size(101, 18)
        Me.tDesc.TabIndex = 304
        Me.tDesc.Tag = Nothing
        Me.tDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.C1ThemeController1.SetTheme(Me.tDesc, "Office2010Blue")
        Me.tDesc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(561, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "Folio"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(597, 69)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(138, 20)
        Me.LtCVE_DOC.TabIndex = 306
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtCVE_DOC, "Office2010Blue")
        '
        'LtFecha
        '
        Me.LtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFecha.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtFecha.Location = New System.Drawing.Point(352, 69)
        Me.LtFecha.Name = "LtFecha"
        Me.LtFecha.Size = New System.Drawing.Size(97, 20)
        Me.LtFecha.TabIndex = 308
        Me.LtFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.C1ThemeController1.SetTheme(Me.LtFecha, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(307, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 307
        Me.Label5.Text = "Fecha"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'frmFacturacionAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 550)
        Me.Controls.Add(Me.LtFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtCVE_DOC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tDesc)
        Me.Controls.Add(Me.LtViaje)
        Me.Controls.Add(Me.tCVE_VIAJE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnViaje)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtNoExt)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.LtNoINt)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.LtCol)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.LtCP)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LtSubTotal)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.LtIva)
        Me.Controls.Add(Me.LtRet)
        Me.Controls.Add(Me.LtDesc)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt4)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.LtClave)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtEstado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LtCiudad)
        Me.Controls.Add(Me.LtRFC)
        Me.Controls.Add(Me.LtCalle)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.tCVE_CON)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btnContrato)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacionAE"
        Me.Text = "Facturación"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Label13 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents tCVE_CON As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents btnContrato As Button
    Friend WithEvents LtNombre As Label
    Friend WithEvents LtCalle As Label
    Friend WithEvents LtRFC As Label
    Friend WithEvents LtCiudad As Label
    Friend WithEvents LtEstado As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtClave As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents LtSubTotal As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents LtTotal As Label
    Friend WithEvents LtIva As Label
    Friend WithEvents LtRet As Label
    Friend WithEvents LtDesc As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt4 As Label
    Friend WithEvents Lt3 As Label
    Friend WithEvents LtCP As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LtCol As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents LtNoExt As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LtNoINt As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnViaje As Button
    Friend WithEvents LtViaje As Label
    Friend WithEvents tDesc As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents LtFecha As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
