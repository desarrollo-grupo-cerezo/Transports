<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSiniestroAE
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
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtVigenciaPoliza = New System.Windows.Forms.Label()
        Me.tPOLIZA = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnTipoPol = New System.Windows.Forms.Button()
        Me.LtPoliza = New System.Windows.Forms.Label()
        Me.tFOLIO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tNUM_SIN = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.tHORA = New C1.Win.Calendar.C1DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOper = New System.Windows.Forms.Button()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnUnidad = New System.Windows.Forms.Button()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.tUBICACION = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tLATITUD = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tDESCR = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tFECHA_ATENCION = New C1.Win.Calendar.C1DateEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tLONGITUD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tHORA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tFECHA_ATENCION, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(967, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 11
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
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tFECHA
        '
        Me.tFECHA.AllowSpinLoop = False
        Me.tFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tFECHA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFECHA.Location = New System.Drawing.Point(132, 123)
        Me.tFECHA.Name = "tFECHA"
        Me.tFECHA.Size = New System.Drawing.Size(170, 19)
        Me.tFECHA.TabIndex = 2
        Me.tFECHA.Tag = Nothing
        Me.tFECHA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(92, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 300
        Me.Label9.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 297
        Me.Label1.Text = "Vigencia poliza"
        '
        'LtVigenciaPoliza
        '
        Me.LtVigenciaPoliza.BackColor = System.Drawing.Color.LightGray
        Me.LtVigenciaPoliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtVigenciaPoliza.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtVigenciaPoliza.Location = New System.Drawing.Point(132, 176)
        Me.LtVigenciaPoliza.Name = "LtVigenciaPoliza"
        Me.LtVigenciaPoliza.Size = New System.Drawing.Size(347, 20)
        Me.LtVigenciaPoliza.TabIndex = 299
        '
        'tPOLIZA
        '
        Me.tPOLIZA.AcceptsReturn = True
        Me.tPOLIZA.AcceptsTab = True
        Me.tPOLIZA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPOLIZA.Location = New System.Drawing.Point(132, 149)
        Me.tPOLIZA.Name = "tPOLIZA"
        Me.tPOLIZA.Size = New System.Drawing.Size(69, 21)
        Me.tPOLIZA.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(95, 152)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(34, 13)
        Me.Label31.TabIndex = 294
        Me.Label31.Text = "Poliza"
        '
        'btnTipoPol
        '
        Me.btnTipoPol.AutoSize = True
        Me.btnTipoPol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTipoPol.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnTipoPol.Location = New System.Drawing.Point(200, 148)
        Me.btnTipoPol.Name = "btnTipoPol"
        Me.btnTipoPol.Size = New System.Drawing.Size(24, 23)
        Me.btnTipoPol.TabIndex = 295
        Me.btnTipoPol.UseVisualStyleBackColor = True
        '
        'LtPoliza
        '
        Me.LtPoliza.BackColor = System.Drawing.Color.LightGray
        Me.LtPoliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPoliza.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPoliza.Location = New System.Drawing.Point(225, 150)
        Me.LtPoliza.Name = "LtPoliza"
        Me.LtPoliza.Size = New System.Drawing.Size(254, 20)
        Me.LtPoliza.TabIndex = 296
        '
        'tFOLIO
        '
        Me.tFOLIO.AcceptsReturn = True
        Me.tFOLIO.AcceptsTab = True
        Me.tFOLIO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIO.Location = New System.Drawing.Point(132, 70)
        Me.tFOLIO.Name = "tFOLIO"
        Me.tFOLIO.Size = New System.Drawing.Size(92, 21)
        Me.tFOLIO.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(100, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 13)
        Me.Label27.TabIndex = 293
        Me.Label27.Text = "Folio"
        '
        'tNUM_SIN
        '
        Me.tNUM_SIN.AcceptsReturn = True
        Me.tNUM_SIN.AcceptsTab = True
        Me.tNUM_SIN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_SIN.Location = New System.Drawing.Point(132, 97)
        Me.tNUM_SIN.Name = "tNUM_SIN"
        Me.tNUM_SIN.Size = New System.Drawing.Size(92, 21)
        Me.tNUM_SIN.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(56, 100)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(73, 13)
        Me.Nombre.TabIndex = 292
        Me.Nombre.Text = "Num. siniestro"
        '
        'tHORA
        '
        Me.tHORA.AllowSpinLoop = False
        Me.tHORA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tHORA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tHORA.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tHORA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tHORA.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tHORA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tHORA.Location = New System.Drawing.Point(132, 203)
        Me.tHORA.Name = "tHORA"
        Me.tHORA.Size = New System.Drawing.Size(136, 19)
        Me.tHORA.TabIndex = 4
        Me.tHORA.Tag = Nothing
        Me.tHORA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown
        Me.tHORA.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tHORA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 302
        Me.Label5.Text = "Hora siniestro"
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(132, 254)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_OPER.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Operador"
        '
        'btnOper
        '
        Me.btnOper.AutoSize = True
        Me.btnOper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOper.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnOper.Location = New System.Drawing.Point(200, 253)
        Me.btnOper.Name = "btnOper"
        Me.btnOper.Size = New System.Drawing.Size(24, 23)
        Me.btnOper.TabIndex = 309
        Me.btnOper.UseVisualStyleBackColor = True
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.LightGray
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(225, 255)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(254, 20)
        Me.LtOper.TabIndex = 310
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(132, 229)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(69, 21)
        Me.tCVE_UNI.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(89, 233)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Unidad"
        '
        'btnUnidad
        '
        Me.btnUnidad.AutoSize = True
        Me.btnUnidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUnidad.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnUnidad.Location = New System.Drawing.Point(200, 228)
        Me.btnUnidad.Name = "btnUnidad"
        Me.btnUnidad.Size = New System.Drawing.Size(24, 23)
        Me.btnUnidad.TabIndex = 306
        Me.btnUnidad.UseVisualStyleBackColor = True
        '
        'LtUnidad
        '
        Me.LtUnidad.BackColor = System.Drawing.Color.LightGray
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(225, 230)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(254, 20)
        Me.LtUnidad.TabIndex = 307
        '
        'tUBICACION
        '
        Me.tUBICACION.AcceptsReturn = True
        Me.tUBICACION.AcceptsTab = True
        Me.tUBICACION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tUBICACION.Location = New System.Drawing.Point(132, 282)
        Me.tUBICACION.Name = "tUBICACION"
        Me.tUBICACION.Size = New System.Drawing.Size(494, 21)
        Me.tUBICACION.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 286)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 312
        Me.Label8.Text = "Ubicacion"
        '
        'tLATITUD
        '
        Me.tLATITUD.AcceptsReturn = True
        Me.tLATITUD.AcceptsTab = True
        Me.tLATITUD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLATITUD.Location = New System.Drawing.Point(132, 309)
        Me.tLATITUD.Name = "tLATITUD"
        Me.tLATITUD.Size = New System.Drawing.Size(170, 21)
        Me.tLATITUD.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(90, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 314
        Me.Label6.Text = "Latitud"
        '
        'tDESCR
        '
        Me.tDESCR.AcceptsReturn = True
        Me.tDESCR.AcceptsTab = True
        Me.tDESCR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESCR.Location = New System.Drawing.Point(132, 361)
        Me.tDESCR.Multiline = True
        Me.tDESCR.Name = "tDESCR"
        Me.tDESCR.Size = New System.Drawing.Size(823, 170)
        Me.tDESCR.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 365)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 13)
        Me.Label7.TabIndex = 316
        Me.Label7.Text = "Descripcion del siniestro"
        '
        'tFECHA_ATENCION
        '
        Me.tFECHA_ATENCION.AllowSpinLoop = False
        Me.tFECHA_ATENCION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFECHA_ATENCION.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.tFECHA_ATENCION.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA_ATENCION.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA_ATENCION.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.tFECHA_ATENCION.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tFECHA_ATENCION.Location = New System.Drawing.Point(132, 336)
        Me.tFECHA_ATENCION.Name = "tFECHA_ATENCION"
        Me.tFECHA_ATENCION.Size = New System.Drawing.Size(276, 19)
        Me.tFECHA_ATENCION.TabIndex = 9
        Me.tFECHA_ATENCION.Tag = Nothing
        Me.tFECHA_ATENCION.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tFECHA_ATENCION.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 339)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 319
        Me.Label11.Text = "Fecha hora de atencion"
        '
        'tLONGITUD
        '
        Me.tLONGITUD.AcceptsReturn = True
        Me.tLONGITUD.AcceptsTab = True
        Me.tLONGITUD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLONGITUD.Location = New System.Drawing.Point(358, 309)
        Me.tLONGITUD.Name = "tLONGITUD"
        Me.tLONGITUD.Size = New System.Drawing.Size(170, 21)
        Me.tLONGITUD.TabIndex = 320
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 321
        Me.Label4.Text = "Longitud"
        '
        'frmSiniestroAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 543)
        Me.Controls.Add(Me.tLONGITUD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tFECHA_ATENCION)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tDESCR)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tLATITUD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tUBICACION)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tCVE_OPER)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnOper)
        Me.Controls.Add(Me.LtOper)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnUnidad)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.tHORA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tFECHA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtVigenciaPoliza)
        Me.Controls.Add(Me.tPOLIZA)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btnTipoPol)
        Me.Controls.Add(Me.LtPoliza)
        Me.Controls.Add(Me.tFOLIO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tNUM_SIN)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmSiniestroAE"
        Me.Text = "Siniestro"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tFECHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tHORA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tFECHA_ATENCION, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tFECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LtVigenciaPoliza As Label
    Friend WithEvents tPOLIZA As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents btnTipoPol As Button
    Friend WithEvents LtPoliza As Label
    Friend WithEvents tFOLIO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tNUM_SIN As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents tHORA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOper As Button
    Friend WithEvents LtOper As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnUnidad As Button
    Friend WithEvents LtUnidad As Label
    Friend WithEvents tUBICACION As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tLATITUD As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tDESCR As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tFECHA_ATENCION As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents tLONGITUD As TextBox
    Friend WithEvents Label4 As Label
End Class
