<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulosTOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulosTOT))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtN = New C1.Win.C1Input.C1NumericEdit()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.btnSelArt = New C1.Win.C1Input.C1Button()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.tEntregarEn = New System.Windows.Forms.TextBox()
        Me.tRefProv = New System.Windows.Forms.TextBox()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.tPROV = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tDesc = New C1.Win.C1Input.C1NumericEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.ToolStripSeparator1, Me.mnuSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1149, 33)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barAceptar
        '
        Me.barAceptar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barAceptar.ForeColor = System.Drawing.Color.White
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.Padding = New System.Windows.Forms.Padding(0)
        Me.barAceptar.ShortcutKeyDisplayString = ""
        Me.barAceptar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barAceptar.Size = New System.Drawing.Size(50, 33)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 33)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(717, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 353
        Me.Label2.Text = "Almacen"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(775, 166)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(142, 21)
        Me.cboAlmacen.TabIndex = 352
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BackColor = System.Drawing.Color.White
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.ForeColor = System.Drawing.Color.Red
        Me.LtCVE_DOC.Location = New System.Drawing.Point(257, 61)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(183, 24)
        Me.LtCVE_DOC.TabIndex = 351
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(180, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 350
        Me.Label5.Text = "Documento"
        '
        'txtN
        '
        Me.txtN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.txtN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.txtN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.txtN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.txtN.ImagePadding = New System.Windows.Forms.Padding(45, 0, 0, 0)
        Me.txtN.Location = New System.Drawing.Point(1061, 160)
        Me.txtN.Name = "txtN"
        Me.txtN.Size = New System.Drawing.Size(88, 18)
        Me.txtN.TabIndex = 349
        Me.txtN.Tag = Nothing
        Me.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtN.Visible = False
        Me.txtN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txt
        '
        Me.txt.AcceptsReturn = True
        Me.txt.AcceptsTab = True
        Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt.Location = New System.Drawing.Point(1061, 191)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(88, 20)
        Me.txt.TabIndex = 348
        Me.txt.Visible = False
        '
        'btnSelArt
        '
        Me.btnSelArt.AutoSize = True
        Me.btnSelArt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSelArt.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnSelArt.Location = New System.Drawing.Point(1106, 102)
        Me.btnSelArt.Name = "btnSelArt"
        Me.btnSelArt.Size = New System.Drawing.Size(22, 22)
        Me.btnSelArt.TabIndex = 347
        Me.btnSelArt.UseVisualStyleBackColor = True
        Me.btnSelArt.Visible = False
        Me.btnSelArt.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnSelArt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(585, 66)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(111, 19)
        Me.F1.TabIndex = 346
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tEntregarEn
        '
        Me.tEntregarEn.AcceptsReturn = True
        Me.tEntregarEn.AcceptsTab = True
        Me.tEntregarEn.Location = New System.Drawing.Point(83, 186)
        Me.tEntregarEn.Name = "tEntregarEn"
        Me.tEntregarEn.Size = New System.Drawing.Size(357, 20)
        Me.tEntregarEn.TabIndex = 315
        '
        'tRefProv
        '
        Me.tRefProv.AcceptsReturn = True
        Me.tRefProv.AcceptsTab = True
        Me.tRefProv.Location = New System.Drawing.Point(802, 115)
        Me.tRefProv.Name = "tRefProv"
        Me.tRefProv.Size = New System.Drawing.Size(114, 20)
        Me.tRefProv.TabIndex = 311
        '
        'btnProv
        '
        Me.btnProv.AutoSize = True
        Me.btnProv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnProv.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnProv.Location = New System.Drawing.Point(895, 90)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(22, 22)
        Me.btnProv.TabIndex = 344
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tPROV
        '
        Me.tPROV.AcceptsReturn = True
        Me.tPROV.AcceptsTab = True
        Me.tPROV.Location = New System.Drawing.Point(803, 91)
        Me.tPROV.Name = "tPROV"
        Me.tPROV.Size = New System.Drawing.Size(88, 20)
        Me.tPROV.TabIndex = 310
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(16, 187)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 15)
        Me.Label22.TabIndex = 341
        Me.Label22.Text = "Entregar a"
        '
        'tDesc
        '
        Me.tDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tDesc.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tDesc.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tDesc.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tDesc.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tDesc.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tDesc.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tDesc.Location = New System.Drawing.Point(802, 142)
        Me.tDesc.Name = "tDesc"
        Me.tDesc.Size = New System.Drawing.Size(114, 18)
        Me.tDesc.TabIndex = 313
        Me.tDesc.Tag = Nothing
        Me.tDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDesc.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(734, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 15)
        Me.Label16.TabIndex = 339
        Me.Label16.Text = "Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(741, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 15)
        Me.Label7.TabIndex = 337
        Me.Label7.Text = "Ref. Prov."
        '
        'LtCP
        '
        Me.LtCP.BackColor = System.Drawing.Color.Cornsilk
        Me.LtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP.Location = New System.Drawing.Point(355, 140)
        Me.LtCP.Name = "LtCP"
        Me.LtCP.Size = New System.Drawing.Size(85, 20)
        Me.LtCP.TabIndex = 332
        '
        'LtColonia
        '
        Me.LtColonia.BackColor = System.Drawing.Color.Cornsilk
        Me.LtColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtColonia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtColonia.Location = New System.Drawing.Point(498, 118)
        Me.LtColonia.Name = "LtColonia"
        Me.LtColonia.Size = New System.Drawing.Size(198, 20)
        Me.LtColonia.TabIndex = 323
        '
        'LtRFC
        '
        Me.LtRFC.BackColor = System.Drawing.Color.LemonChiffon
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.Location = New System.Drawing.Point(498, 141)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(198, 20)
        Me.LtRFC.TabIndex = 329
        '
        'LtEstado
        '
        Me.LtEstado.BackColor = System.Drawing.Color.Cornsilk
        Me.LtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEstado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEstado.Location = New System.Drawing.Point(498, 164)
        Me.LtEstado.Name = "LtEstado"
        Me.LtEstado.Size = New System.Drawing.Size(198, 20)
        Me.LtEstado.TabIndex = 327
        '
        'LtNumExt
        '
        Me.LtNumExt.BackColor = System.Drawing.Color.Cornsilk
        Me.LtNumExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumExt.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumExt.Location = New System.Drawing.Point(212, 140)
        Me.LtNumExt.Name = "LtNumExt"
        Me.LtNumExt.Size = New System.Drawing.Size(99, 20)
        Me.LtNumExt.TabIndex = 336
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(164, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 15)
        Me.Label21.TabIndex = 335
        Me.Label21.Text = "No.Ext."
        '
        'LtNumInt
        '
        Me.LtNumInt.BackColor = System.Drawing.Color.Cornsilk
        Me.LtNumInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumInt.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumInt.Location = New System.Drawing.Point(84, 140)
        Me.LtNumInt.Name = "LtNumInt"
        Me.LtNumInt.Size = New System.Drawing.Size(78, 20)
        Me.LtNumInt.TabIndex = 334
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(320, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 15)
        Me.Label20.TabIndex = 331
        Me.Label20.Text = "C.P."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(452, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 328
        Me.Label3.Text = "R.F.C."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(447, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 15)
        Me.Label12.TabIndex = 326
        Me.Label12.Text = "Estado"
        '
        'LtPoblacion
        '
        Me.LtPoblacion.BackColor = System.Drawing.Color.Cornsilk
        Me.LtPoblacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPoblacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPoblacion.Location = New System.Drawing.Point(84, 163)
        Me.LtPoblacion.Name = "LtPoblacion"
        Me.LtPoblacion.Size = New System.Drawing.Size(356, 20)
        Me.LtPoblacion.TabIndex = 325
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(443, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 322
        Me.Label8.Text = "Colonia"
        '
        'LtCalle
        '
        Me.LtCalle.BackColor = System.Drawing.Color.Cornsilk
        Me.LtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCalle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCalle.Location = New System.Drawing.Point(84, 117)
        Me.LtCalle.Name = "LtCalle"
        Me.LtCalle.Size = New System.Drawing.Size(356, 20)
        Me.LtCalle.TabIndex = 321
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.Cornsilk
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(84, 94)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(612, 20)
        Me.LtNombre.TabIndex = 319
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(540, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 317
        Me.Label1.Text = "Fecha"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(38, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 15)
        Me.Label18.TabIndex = 333
        Me.Label18.Text = "No.Int."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(763, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 15)
        Me.Label14.TabIndex = 330
        Me.Label14.Text = "Clave"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "Población"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(45, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 320
        Me.Label6.Text = "Calle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(2, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "Razon social"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(5, 212)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 300
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.Size = New System.Drawing.Size(989, 242)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 354
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'frmArticulosTOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 485)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.LtCVE_DOC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtN)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.btnSelArt)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.tEntregarEn)
        Me.Controls.Add(Me.tRefProv)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.tPROV)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tDesc)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtCP)
        Me.Controls.Add(Me.LtColonia)
        Me.Controls.Add(Me.LtRFC)
        Me.Controls.Add(Me.LtEstado)
        Me.Controls.Add(Me.LtNumExt)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LtNumInt)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LtPoblacion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtCalle)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmArticulosTOT"
        Me.Text = "Articulo TOT"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barAceptar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents txt As TextBox
    Friend WithEvents btnSelArt As C1.Win.C1Input.C1Button
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents tEntregarEn As TextBox
    Friend WithEvents tRefProv As TextBox
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tPROV As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents tDesc As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label16 As Label
    Friend WithEvents Label7 As Label
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
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
