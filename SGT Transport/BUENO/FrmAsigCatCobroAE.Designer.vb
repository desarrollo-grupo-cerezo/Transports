<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsigCatCobroAE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsigCatCobroAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TCVE_COBRO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChRetieneIva = New C1.Win.C1Input.C1CheckBox()
        Me.ChCausaIva = New C1.Win.C1Input.C1CheckBox()
        Me.TCENTRO_BENEF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCUENTA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboUMEFac = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCVE_PRODSERV = New C1.Win.C1Input.C1TextBox()
        Me.TCVE_UNIDAD = New C1.Win.C1Input.C1TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnCveUni = New C1.Win.C1Input.C1Button()
        Me.BtnProdServ = New C1.Win.C1Input.C1Button()
        Me.BtnCentroBenef = New C1.Win.C1Input.C1Button()
        Me.BtnCuenta = New C1.Win.C1Input.C1Button()
        Me.LtCuenta = New System.Windows.Forms.Label()
        Me.LtCentroBenef = New System.Windows.Forms.Label()
        Me.LtCveUnidad = New System.Windows.Forms.Label()
        Me.LtCveProdServ = New System.Windows.Forms.Label()
        Me.TORDEN = New C1.Win.C1Input.C1NumericEdit()
        Me.LtFolioF = New System.Windows.Forms.Label()
        Me.TOBS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TIVA = New C1.Win.C1Input.C1NumericEdit()
        Me.TRET = New C1.Win.C1Input.C1NumericEdit()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChRetieneIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChCausaIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboUMEFac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_PRODSERV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_UNIDAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCveUni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProdServ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCentroBenef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TORDEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(597, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TDESCR
        '
        Me.TDESCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(202, 102)
        Me.TDESCR.MaxLength = 60
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(383, 22)
        Me.TDESCR.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(119, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 406
        Me.Label6.Text = "Descripción"
        '
        'TCVE_COBRO
        '
        Me.TCVE_COBRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_COBRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_COBRO.Location = New System.Drawing.Point(202, 72)
        Me.TCVE_COBRO.Name = "TCVE_COBRO"
        Me.TCVE_COBRO.Size = New System.Drawing.Size(78, 22)
        Me.TCVE_COBRO.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(156, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 404
        Me.Label8.Text = "Clave"
        '
        'ChRetieneIva
        '
        Me.ChRetieneIva.AutoSize = True
        Me.ChRetieneIva.BackColor = System.Drawing.Color.Transparent
        Me.ChRetieneIva.BorderColor = System.Drawing.Color.Transparent
        Me.ChRetieneIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChRetieneIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChRetieneIva.ForeColor = System.Drawing.Color.Black
        Me.ChRetieneIva.Location = New System.Drawing.Point(398, 139)
        Me.ChRetieneIva.Name = "ChRetieneIva"
        Me.ChRetieneIva.Padding = New System.Windows.Forms.Padding(1)
        Me.ChRetieneIva.Size = New System.Drawing.Size(99, 22)
        Me.ChRetieneIva.TabIndex = 4
        Me.ChRetieneIva.Text = "Retiene IVA"
        Me.ChRetieneIva.UseVisualStyleBackColor = False
        Me.ChRetieneIva.Value = Nothing
        Me.ChRetieneIva.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChCausaIva
        '
        Me.ChCausaIva.AutoSize = True
        Me.ChCausaIva.BackColor = System.Drawing.Color.Transparent
        Me.ChCausaIva.BorderColor = System.Drawing.Color.Transparent
        Me.ChCausaIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChCausaIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCausaIva.ForeColor = System.Drawing.Color.Black
        Me.ChCausaIva.Location = New System.Drawing.Point(202, 139)
        Me.ChCausaIva.Name = "ChCausaIva"
        Me.ChCausaIva.Padding = New System.Windows.Forms.Padding(1)
        Me.ChCausaIva.Size = New System.Drawing.Size(91, 22)
        Me.ChCausaIva.TabIndex = 2
        Me.ChCausaIva.Text = "Causa IVA"
        Me.ChCausaIva.UseVisualStyleBackColor = False
        Me.ChCausaIva.Value = Nothing
        Me.ChCausaIva.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TCENTRO_BENEF
        '
        Me.TCENTRO_BENEF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCENTRO_BENEF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCENTRO_BENEF.Location = New System.Drawing.Point(202, 255)
        Me.TCENTRO_BENEF.MaxLength = 60
        Me.TCENTRO_BENEF.Name = "TCENTRO_BENEF"
        Me.TCENTRO_BENEF.Size = New System.Drawing.Size(132, 22)
        Me.TCENTRO_BENEF.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 619
        Me.Label1.Text = "Centro de beneficios"
        '
        'TCUENTA
        '
        Me.TCUENTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCUENTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUENTA.Location = New System.Drawing.Point(202, 223)
        Me.TCUENTA.Name = "TCUENTA"
        Me.TCUENTA.Size = New System.Drawing.Size(132, 22)
        Me.TCUENTA.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 618
        Me.Label2.Text = "Cuenta"
        '
        'CboUMEFac
        '
        Me.CboUMEFac.AllowSpinLoop = False
        Me.CboUMEFac.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboUMEFac.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboUMEFac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboUMEFac.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboUMEFac.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboUMEFac.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboUMEFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboUMEFac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboUMEFac.GapHeight = 0
        Me.CboUMEFac.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboUMEFac.ItemsDisplayMember = ""
        Me.CboUMEFac.ItemsValueMember = ""
        Me.CboUMEFac.Location = New System.Drawing.Point(202, 284)
        Me.CboUMEFac.Name = "CboUMEFac"
        Me.CboUMEFac.Size = New System.Drawing.Size(248, 20)
        Me.CboUMEFac.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboUMEFac.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboUMEFac.TabIndex = 9
        Me.CboUMEFac.Tag = Nothing
        Me.CboUMEFac.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 16)
        Me.Label3.TabIndex = 621
        Me.Label3.Text = "Descripción UME facturación"
        '
        'TCVE_PRODSERV
        '
        Me.TCVE_PRODSERV.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCVE_PRODSERV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_PRODSERV.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_PRODSERV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PRODSERV.Location = New System.Drawing.Point(202, 314)
        Me.TCVE_PRODSERV.Name = "TCVE_PRODSERV"
        Me.TCVE_PRODSERV.Size = New System.Drawing.Size(93, 20)
        Me.TCVE_PRODSERV.TabIndex = 10
        Me.TCVE_PRODSERV.Tag = Nothing
        Me.TCVE_PRODSERV.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNIDAD
        '
        Me.TCVE_UNIDAD.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCVE_UNIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_UNIDAD.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TCVE_UNIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNIDAD.Location = New System.Drawing.Point(202, 344)
        Me.TCVE_UNIDAD.Name = "TCVE_UNIDAD"
        Me.TCVE_UNIDAD.Size = New System.Drawing.Size(93, 20)
        Me.TCVE_UNIDAD.TabIndex = 22
        Me.TCVE_UNIDAD.Tag = Nothing
        Me.TCVE_UNIDAD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 316)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 16)
        Me.Label4.TabIndex = 624
        Me.Label4.Text = "Clave productlo servicio CFDI"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(79, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 16)
        Me.Label5.TabIndex = 625
        Me.Label5.Text = "Clave unidad CFDI"
        '
        'BtnCveUni
        '
        Me.BtnCveUni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCveUni.FlatAppearance.BorderSize = 0
        Me.BtnCveUni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCveUni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCveUni.Image = CType(resources.GetObject("BtnCveUni.Image"), System.Drawing.Image)
        Me.BtnCveUni.Location = New System.Drawing.Point(296, 343)
        Me.BtnCveUni.Name = "BtnCveUni"
        Me.BtnCveUni.Size = New System.Drawing.Size(22, 22)
        Me.BtnCveUni.TabIndex = 627
        Me.BtnCveUni.UseVisualStyleBackColor = True
        Me.BtnCveUni.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnProdServ
        '
        Me.BtnProdServ.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnProdServ.FlatAppearance.BorderSize = 0
        Me.BtnProdServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProdServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProdServ.Image = CType(resources.GetObject("BtnProdServ.Image"), System.Drawing.Image)
        Me.BtnProdServ.Location = New System.Drawing.Point(296, 313)
        Me.BtnProdServ.Name = "BtnProdServ"
        Me.BtnProdServ.Size = New System.Drawing.Size(22, 22)
        Me.BtnProdServ.TabIndex = 626
        Me.BtnProdServ.UseVisualStyleBackColor = True
        Me.BtnProdServ.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnCentroBenef
        '
        Me.BtnCentroBenef.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCentroBenef.FlatAppearance.BorderSize = 0
        Me.BtnCentroBenef.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCentroBenef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCentroBenef.Image = CType(resources.GetObject("BtnCentroBenef.Image"), System.Drawing.Image)
        Me.BtnCentroBenef.Location = New System.Drawing.Point(335, 254)
        Me.BtnCentroBenef.Name = "BtnCentroBenef"
        Me.BtnCentroBenef.Size = New System.Drawing.Size(22, 22)
        Me.BtnCentroBenef.TabIndex = 629
        Me.BtnCentroBenef.UseVisualStyleBackColor = True
        Me.BtnCentroBenef.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnCuenta
        '
        Me.BtnCuenta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCuenta.FlatAppearance.BorderSize = 0
        Me.BtnCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCuenta.Image = CType(resources.GetObject("BtnCuenta.Image"), System.Drawing.Image)
        Me.BtnCuenta.Location = New System.Drawing.Point(335, 222)
        Me.BtnCuenta.Name = "BtnCuenta"
        Me.BtnCuenta.Size = New System.Drawing.Size(22, 22)
        Me.BtnCuenta.TabIndex = 628
        Me.BtnCuenta.UseVisualStyleBackColor = True
        Me.BtnCuenta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCuenta
        '
        Me.LtCuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCuenta.Location = New System.Drawing.Point(361, 223)
        Me.LtCuenta.Name = "LtCuenta"
        Me.LtCuenta.Size = New System.Drawing.Size(224, 22)
        Me.LtCuenta.TabIndex = 630
        Me.LtCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LtCuenta.Visible = False
        '
        'LtCentroBenef
        '
        Me.LtCentroBenef.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCentroBenef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCentroBenef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCentroBenef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCentroBenef.Location = New System.Drawing.Point(361, 255)
        Me.LtCentroBenef.Name = "LtCentroBenef"
        Me.LtCentroBenef.Size = New System.Drawing.Size(224, 22)
        Me.LtCentroBenef.TabIndex = 631
        Me.LtCentroBenef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LtCentroBenef.Visible = False
        '
        'LtCveUnidad
        '
        Me.LtCveUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCveUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCveUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCveUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCveUnidad.Location = New System.Drawing.Point(322, 344)
        Me.LtCveUnidad.Name = "LtCveUnidad"
        Me.LtCveUnidad.Size = New System.Drawing.Size(263, 22)
        Me.LtCveUnidad.TabIndex = 633
        Me.LtCveUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LtCveUnidad.Visible = False
        '
        'LtCveProdServ
        '
        Me.LtCveProdServ.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCveProdServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCveProdServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCveProdServ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCveProdServ.Location = New System.Drawing.Point(322, 314)
        Me.LtCveProdServ.Name = "LtCveProdServ"
        Me.LtCveProdServ.Size = New System.Drawing.Size(263, 22)
        Me.LtCveProdServ.TabIndex = 632
        Me.LtCveProdServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LtCveProdServ.Visible = False
        '
        'TORDEN
        '
        Me.TORDEN.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TORDEN.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TORDEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TORDEN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TORDEN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TORDEN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TORDEN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TORDEN.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TORDEN.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TORDEN.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TORDEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TORDEN.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TORDEN.InterceptArrowKeys = False
        Me.TORDEN.Location = New System.Drawing.Point(202, 194)
        Me.TORDEN.Name = "TORDEN"
        Me.TORDEN.Size = New System.Drawing.Size(41, 19)
        Me.TORDEN.TabIndex = 6
        Me.TORDEN.Tag = Nothing
        Me.TORDEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TORDEN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TORDEN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtFolioF
        '
        Me.LtFolioF.AutoSize = True
        Me.LtFolioF.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtFolioF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFolioF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtFolioF.Location = New System.Drawing.Point(157, 195)
        Me.LtFolioF.Name = "LtFolioF"
        Me.LtFolioF.Size = New System.Drawing.Size(41, 15)
        Me.LtFolioF.TabIndex = 635
        Me.LtFolioF.Text = "Orden"
        '
        'TOBS
        '
        Me.TOBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBS.Location = New System.Drawing.Point(202, 373)
        Me.TOBS.MaxLength = 60
        Me.TOBS.Name = "TOBS"
        Me.TOBS.Size = New System.Drawing.Size(383, 22)
        Me.TOBS.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(99, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 16)
        Me.Label7.TabIndex = 637
        Me.Label7.Text = "Observaciones"
        '
        'TIVA
        '
        Me.TIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIVA.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIVA.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIVA.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TIVA.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIVA.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIVA.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIVA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIVA.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIVA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIVA.InterceptArrowKeys = False
        Me.TIVA.Location = New System.Drawing.Point(299, 140)
        Me.TIVA.Name = "TIVA"
        Me.TIVA.Size = New System.Drawing.Size(41, 19)
        Me.TIVA.TabIndex = 3
        Me.TIVA.Tag = Nothing
        Me.TIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TIVA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIVA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TRET
        '
        Me.TRET.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TRET.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TRET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TRET.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TRET.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TRET.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TRET.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TRET.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TRET.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TRET.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TRET.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRET.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TRET.InterceptArrowKeys = False
        Me.TRET.Location = New System.Drawing.Point(504, 140)
        Me.TRET.Name = "TRET"
        Me.TRET.Size = New System.Drawing.Size(41, 19)
        Me.TRET.TabIndex = 5
        Me.TRET.Tag = Nothing
        Me.TRET.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TRET.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TRET.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(344, 142)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(18, 15)
        Me.Lt1.TabIndex = 641
        Me.Lt1.Text = "%"
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt2.Location = New System.Drawing.Point(549, 142)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(18, 15)
        Me.Lt2.TabIndex = 642
        Me.Lt2.Text = "%"
        '
        'FrmAsigCatCobroAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 407)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TRET)
        Me.Controls.Add(Me.TIVA)
        Me.Controls.Add(Me.TOBS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TORDEN)
        Me.Controls.Add(Me.LtFolioF)
        Me.Controls.Add(Me.LtCveUnidad)
        Me.Controls.Add(Me.LtCveProdServ)
        Me.Controls.Add(Me.LtCentroBenef)
        Me.Controls.Add(Me.LtCuenta)
        Me.Controls.Add(Me.BtnCentroBenef)
        Me.Controls.Add(Me.BtnCuenta)
        Me.Controls.Add(Me.BtnCveUni)
        Me.Controls.Add(Me.BtnProdServ)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TCVE_PRODSERV)
        Me.Controls.Add(Me.TCVE_UNIDAD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboUMEFac)
        Me.Controls.Add(Me.TCENTRO_BENEF)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCUENTA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChRetieneIva)
        Me.Controls.Add(Me.ChCausaIva)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TCVE_COBRO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsigCatCobroAE"
        Me.ShowInTaskbar = False
        Me.Text = "Concepto de cobro"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChRetieneIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChCausaIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboUMEFac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_PRODSERV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_UNIDAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCveUni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProdServ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCentroBenef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TORDEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TCVE_COBRO As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ChRetieneIva As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChCausaIva As C1.Win.C1Input.C1CheckBox
    Friend WithEvents TCENTRO_BENEF As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TCUENTA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CboUMEFac As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TCVE_PRODSERV As C1.Win.C1Input.C1TextBox
    Friend WithEvents TCVE_UNIDAD As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnCveUni As C1.Win.C1Input.C1Button
    Friend WithEvents BtnProdServ As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCentroBenef As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCuenta As C1.Win.C1Input.C1Button
    Friend WithEvents LtCuenta As Label
    Friend WithEvents LtCveUnidad As Label
    Friend WithEvents LtCveProdServ As Label
    Friend WithEvents LtCentroBenef As Label
    Friend WithEvents TORDEN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents LtFolioF As Label
    Friend WithEvents TOBS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents TRET As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TIVA As C1.Win.C1Input.C1NumericEdit
End Class
