<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEstacionTrabAE
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstacionTrabAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.ChLECTORHUELLA = New C1.Win.C1Input.C1CheckBox()
        Me.ChIMP_NOTA = New C1.Win.C1Input.C1CheckBox()
        Me.ChPROMOCIONES = New C1.Win.C1Input.C1CheckBox()
        Me.ChFLUJO = New C1.Win.C1Input.C1CheckBox()
        Me.ChMONEDERO = New C1.Win.C1Input.C1CheckBox()
        Me.ChPRECIOS = New C1.Win.C1Input.C1CheckBox()
        Me.ChPERMITE_DESC = New C1.Win.C1Input.C1CheckBox()
        Me.ChAGREGAR_PROD = New C1.Win.C1Input.C1CheckBox()
        Me.ChREIMPRIMIR_TICKET = New C1.Win.C1Input.C1CheckBox()
        Me.ChAGREGAR_CLIENTE = New C1.Win.C1Input.C1CheckBox()
        Me.ChTIEMPO_AIRE = New C1.Win.C1Input.C1CheckBox()
        Me.ChSOLECCIONAR_SERIES = New C1.Win.C1Input.C1CheckBox()
        Me.ChCOLUMNA_DESCUENTO = New C1.Win.C1Input.C1CheckBox()
        Me.ChPAGOS_PARCIALES = New C1.Win.C1Input.C1CheckBox()
        Me.ChPER_VEND_ABA_MIN = New C1.Win.C1Input.C1CheckBox()
        Me.ChNOVALIDAR_LIM_CRED = New C1.Win.C1Input.C1CheckBox()
        Me.ChVENDER_SIN_EXIST = New C1.Win.C1Input.C1CheckBox()
        Me.ChPER_VEND_ABA_COST = New C1.Win.C1Input.C1CheckBox()
        Me.ChART_CON_IMP_INCLU = New C1.Win.C1Input.C1CheckBox()
        Me.ChOCULTAR_CRE_ENG = New C1.Win.C1Input.C1CheckBox()
        Me.ChOCULTAR_CREDITO = New C1.Win.C1Input.C1CheckBox()
        Me.CboListaPrecPred = New C1.Win.C1Input.C1ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TDECIMALES = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCVE_VEND = New SGT_Transport.TextBoxEx()
        Me.TESTACION = New SGT_Transport.TextBoxEx()
        Me.TCLIE_MOSTR = New SGT_Transport.TextBoxEx()
        Me.BtnVend = New System.Windows.Forms.Button()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChLECTORHUELLA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChIMP_NOTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPROMOCIONES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChFLUJO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChMONEDERO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPRECIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPERMITE_DESC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChAGREGAR_PROD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChREIMPRIMIR_TICKET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChAGREGAR_CLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChTIEMPO_AIRE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChSOLECCIONAR_SERIES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChCOLUMNA_DESCUENTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPAGOS_PARCIALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPER_VEND_ABA_MIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChNOVALIDAR_LIM_CRED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChVENDER_SIN_EXIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChPER_VEND_ABA_COST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChART_CON_IMP_INCLU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChOCULTAR_CRE_ENG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChOCULTAR_CREDITO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboListaPrecPred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDECIMALES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
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
        Me.C1ToolBar1.ButtonWidth = 60
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(825, 43)
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
        'ChLECTORHUELLA
        '
        Me.ChLECTORHUELLA.BackColor = System.Drawing.Color.Transparent
        Me.ChLECTORHUELLA.BorderColor = System.Drawing.Color.Transparent
        Me.ChLECTORHUELLA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChLECTORHUELLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChLECTORHUELLA.ForeColor = System.Drawing.Color.Black
        Me.ChLECTORHUELLA.Location = New System.Drawing.Point(41, 107)
        Me.ChLECTORHUELLA.Name = "ChLECTORHUELLA"
        Me.ChLECTORHUELLA.Padding = New System.Windows.Forms.Padding(1)
        Me.ChLECTORHUELLA.Size = New System.Drawing.Size(228, 23)
        Me.ChLECTORHUELLA.TabIndex = 1
        Me.ChLECTORHUELLA.Text = "Lector huella"
        Me.ChLECTORHUELLA.UseVisualStyleBackColor = False
        Me.ChLECTORHUELLA.Value = Nothing
        Me.ChLECTORHUELLA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChIMP_NOTA
        '
        Me.ChIMP_NOTA.BackColor = System.Drawing.Color.Transparent
        Me.ChIMP_NOTA.BorderColor = System.Drawing.Color.Transparent
        Me.ChIMP_NOTA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChIMP_NOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChIMP_NOTA.ForeColor = System.Drawing.Color.Black
        Me.ChIMP_NOTA.Location = New System.Drawing.Point(41, 132)
        Me.ChIMP_NOTA.Name = "ChIMP_NOTA"
        Me.ChIMP_NOTA.Padding = New System.Windows.Forms.Padding(1)
        Me.ChIMP_NOTA.Size = New System.Drawing.Size(228, 23)
        Me.ChIMP_NOTA.TabIndex = 2
        Me.ChIMP_NOTA.Text = "Vista pre. venta"
        Me.ChIMP_NOTA.UseVisualStyleBackColor = False
        Me.ChIMP_NOTA.Value = Nothing
        Me.ChIMP_NOTA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChPROMOCIONES
        '
        Me.ChPROMOCIONES.BackColor = System.Drawing.Color.Transparent
        Me.ChPROMOCIONES.BorderColor = System.Drawing.Color.Transparent
        Me.ChPROMOCIONES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPROMOCIONES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPROMOCIONES.ForeColor = System.Drawing.Color.Black
        Me.ChPROMOCIONES.Location = New System.Drawing.Point(41, 157)
        Me.ChPROMOCIONES.Name = "ChPROMOCIONES"
        Me.ChPROMOCIONES.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPROMOCIONES.Size = New System.Drawing.Size(230, 23)
        Me.ChPROMOCIONES.TabIndex = 3
        Me.ChPROMOCIONES.Text = "No tomar en cuenta promociones"
        Me.ChPROMOCIONES.UseVisualStyleBackColor = False
        Me.ChPROMOCIONES.Value = Nothing
        Me.ChPROMOCIONES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChFLUJO
        '
        Me.ChFLUJO.BackColor = System.Drawing.Color.Transparent
        Me.ChFLUJO.BorderColor = System.Drawing.Color.Transparent
        Me.ChFLUJO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChFLUJO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChFLUJO.ForeColor = System.Drawing.Color.Black
        Me.ChFLUJO.Location = New System.Drawing.Point(41, 182)
        Me.ChFLUJO.Name = "ChFLUJO"
        Me.ChFLUJO.Padding = New System.Windows.Forms.Padding(1)
        Me.ChFLUJO.Size = New System.Drawing.Size(228, 23)
        Me.ChFLUJO.TabIndex = 4
        Me.ChFLUJO.Text = "Flujo"
        Me.ChFLUJO.UseVisualStyleBackColor = False
        Me.ChFLUJO.Value = Nothing
        Me.ChFLUJO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChMONEDERO
        '
        Me.ChMONEDERO.BackColor = System.Drawing.Color.Transparent
        Me.ChMONEDERO.BorderColor = System.Drawing.Color.Transparent
        Me.ChMONEDERO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChMONEDERO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChMONEDERO.ForeColor = System.Drawing.Color.Black
        Me.ChMONEDERO.Location = New System.Drawing.Point(41, 207)
        Me.ChMONEDERO.Name = "ChMONEDERO"
        Me.ChMONEDERO.Padding = New System.Windows.Forms.Padding(1)
        Me.ChMONEDERO.Size = New System.Drawing.Size(228, 23)
        Me.ChMONEDERO.TabIndex = 5
        Me.ChMONEDERO.Text = "Monedero"
        Me.ChMONEDERO.UseVisualStyleBackColor = False
        Me.ChMONEDERO.Value = Nothing
        Me.ChMONEDERO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChPRECIOS
        '
        Me.ChPRECIOS.BackColor = System.Drawing.Color.Transparent
        Me.ChPRECIOS.BorderColor = System.Drawing.Color.Transparent
        Me.ChPRECIOS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPRECIOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPRECIOS.ForeColor = System.Drawing.Color.Black
        Me.ChPRECIOS.Location = New System.Drawing.Point(41, 232)
        Me.ChPRECIOS.Name = "ChPRECIOS"
        Me.ChPRECIOS.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPRECIOS.Size = New System.Drawing.Size(228, 23)
        Me.ChPRECIOS.TabIndex = 7
        Me.ChPRECIOS.Text = "Seleccionar lista de precios"
        Me.ChPRECIOS.UseVisualStyleBackColor = False
        Me.ChPRECIOS.Value = Nothing
        Me.ChPRECIOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChPERMITE_DESC
        '
        Me.ChPERMITE_DESC.BackColor = System.Drawing.Color.Transparent
        Me.ChPERMITE_DESC.BorderColor = System.Drawing.Color.Transparent
        Me.ChPERMITE_DESC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPERMITE_DESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPERMITE_DESC.ForeColor = System.Drawing.Color.Black
        Me.ChPERMITE_DESC.Location = New System.Drawing.Point(41, 257)
        Me.ChPERMITE_DESC.Name = "ChPERMITE_DESC"
        Me.ChPERMITE_DESC.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPERMITE_DESC.Size = New System.Drawing.Size(228, 23)
        Me.ChPERMITE_DESC.TabIndex = 8
        Me.ChPERMITE_DESC.Text = "Permite hacer descuento"
        Me.ChPERMITE_DESC.UseVisualStyleBackColor = False
        Me.ChPERMITE_DESC.Value = Nothing
        Me.ChPERMITE_DESC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChAGREGAR_PROD
        '
        Me.ChAGREGAR_PROD.BackColor = System.Drawing.Color.Transparent
        Me.ChAGREGAR_PROD.BorderColor = System.Drawing.Color.Transparent
        Me.ChAGREGAR_PROD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChAGREGAR_PROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChAGREGAR_PROD.ForeColor = System.Drawing.Color.Black
        Me.ChAGREGAR_PROD.Location = New System.Drawing.Point(41, 282)
        Me.ChAGREGAR_PROD.Name = "ChAGREGAR_PROD"
        Me.ChAGREGAR_PROD.Padding = New System.Windows.Forms.Padding(1)
        Me.ChAGREGAR_PROD.Size = New System.Drawing.Size(228, 23)
        Me.ChAGREGAR_PROD.TabIndex = 9
        Me.ChAGREGAR_PROD.Text = "Alta producto"
        Me.ChAGREGAR_PROD.UseVisualStyleBackColor = False
        Me.ChAGREGAR_PROD.Value = Nothing
        Me.ChAGREGAR_PROD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChREIMPRIMIR_TICKET
        '
        Me.ChREIMPRIMIR_TICKET.BackColor = System.Drawing.Color.Transparent
        Me.ChREIMPRIMIR_TICKET.BorderColor = System.Drawing.Color.Transparent
        Me.ChREIMPRIMIR_TICKET.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChREIMPRIMIR_TICKET.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChREIMPRIMIR_TICKET.ForeColor = System.Drawing.Color.Black
        Me.ChREIMPRIMIR_TICKET.Location = New System.Drawing.Point(41, 599)
        Me.ChREIMPRIMIR_TICKET.Name = "ChREIMPRIMIR_TICKET"
        Me.ChREIMPRIMIR_TICKET.Padding = New System.Windows.Forms.Padding(1)
        Me.ChREIMPRIMIR_TICKET.Size = New System.Drawing.Size(174, 23)
        Me.ChREIMPRIMIR_TICKET.TabIndex = 22
        Me.ChREIMPRIMIR_TICKET.Text = "Reimprimir ticket"
        Me.ChREIMPRIMIR_TICKET.UseVisualStyleBackColor = False
        Me.ChREIMPRIMIR_TICKET.Value = Nothing
        Me.ChREIMPRIMIR_TICKET.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChAGREGAR_CLIENTE
        '
        Me.ChAGREGAR_CLIENTE.BackColor = System.Drawing.Color.Transparent
        Me.ChAGREGAR_CLIENTE.BorderColor = System.Drawing.Color.Transparent
        Me.ChAGREGAR_CLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChAGREGAR_CLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChAGREGAR_CLIENTE.ForeColor = System.Drawing.Color.Black
        Me.ChAGREGAR_CLIENTE.Location = New System.Drawing.Point(41, 574)
        Me.ChAGREGAR_CLIENTE.Name = "ChAGREGAR_CLIENTE"
        Me.ChAGREGAR_CLIENTE.Padding = New System.Windows.Forms.Padding(1)
        Me.ChAGREGAR_CLIENTE.Size = New System.Drawing.Size(174, 23)
        Me.ChAGREGAR_CLIENTE.TabIndex = 21
        Me.ChAGREGAR_CLIENTE.Text = "Alta cliente"
        Me.ChAGREGAR_CLIENTE.UseVisualStyleBackColor = False
        Me.ChAGREGAR_CLIENTE.Value = Nothing
        Me.ChAGREGAR_CLIENTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChTIEMPO_AIRE
        '
        Me.ChTIEMPO_AIRE.BackColor = System.Drawing.Color.Transparent
        Me.ChTIEMPO_AIRE.BorderColor = System.Drawing.Color.Transparent
        Me.ChTIEMPO_AIRE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChTIEMPO_AIRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChTIEMPO_AIRE.ForeColor = System.Drawing.Color.Black
        Me.ChTIEMPO_AIRE.Location = New System.Drawing.Point(41, 549)
        Me.ChTIEMPO_AIRE.Name = "ChTIEMPO_AIRE"
        Me.ChTIEMPO_AIRE.Padding = New System.Windows.Forms.Padding(1)
        Me.ChTIEMPO_AIRE.Size = New System.Drawing.Size(174, 23)
        Me.ChTIEMPO_AIRE.TabIndex = 20
        Me.ChTIEMPO_AIRE.Text = "Tiempo aire"
        Me.ChTIEMPO_AIRE.UseVisualStyleBackColor = False
        Me.ChTIEMPO_AIRE.Value = Nothing
        Me.ChTIEMPO_AIRE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChSOLECCIONAR_SERIES
        '
        Me.ChSOLECCIONAR_SERIES.BackColor = System.Drawing.Color.Transparent
        Me.ChSOLECCIONAR_SERIES.BorderColor = System.Drawing.Color.Transparent
        Me.ChSOLECCIONAR_SERIES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChSOLECCIONAR_SERIES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChSOLECCIONAR_SERIES.ForeColor = System.Drawing.Color.Black
        Me.ChSOLECCIONAR_SERIES.Location = New System.Drawing.Point(41, 524)
        Me.ChSOLECCIONAR_SERIES.Name = "ChSOLECCIONAR_SERIES"
        Me.ChSOLECCIONAR_SERIES.Padding = New System.Windows.Forms.Padding(1)
        Me.ChSOLECCIONAR_SERIES.Size = New System.Drawing.Size(174, 23)
        Me.ChSOLECCIONAR_SERIES.TabIndex = 19
        Me.ChSOLECCIONAR_SERIES.Text = "Soleccionar  series"
        Me.ChSOLECCIONAR_SERIES.UseVisualStyleBackColor = False
        Me.ChSOLECCIONAR_SERIES.Value = Nothing
        Me.ChSOLECCIONAR_SERIES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChCOLUMNA_DESCUENTO
        '
        Me.ChCOLUMNA_DESCUENTO.BackColor = System.Drawing.Color.Transparent
        Me.ChCOLUMNA_DESCUENTO.BorderColor = System.Drawing.Color.Transparent
        Me.ChCOLUMNA_DESCUENTO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChCOLUMNA_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCOLUMNA_DESCUENTO.ForeColor = System.Drawing.Color.Black
        Me.ChCOLUMNA_DESCUENTO.Location = New System.Drawing.Point(41, 499)
        Me.ChCOLUMNA_DESCUENTO.Name = "ChCOLUMNA_DESCUENTO"
        Me.ChCOLUMNA_DESCUENTO.Padding = New System.Windows.Forms.Padding(1)
        Me.ChCOLUMNA_DESCUENTO.Size = New System.Drawing.Size(174, 23)
        Me.ChCOLUMNA_DESCUENTO.TabIndex = 18
        Me.ChCOLUMNA_DESCUENTO.Text = "Columna descuento"
        Me.ChCOLUMNA_DESCUENTO.UseVisualStyleBackColor = False
        Me.ChCOLUMNA_DESCUENTO.Value = Nothing
        Me.ChCOLUMNA_DESCUENTO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChPAGOS_PARCIALES
        '
        Me.ChPAGOS_PARCIALES.BackColor = System.Drawing.Color.Transparent
        Me.ChPAGOS_PARCIALES.BorderColor = System.Drawing.Color.Transparent
        Me.ChPAGOS_PARCIALES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPAGOS_PARCIALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPAGOS_PARCIALES.ForeColor = System.Drawing.Color.Black
        Me.ChPAGOS_PARCIALES.Location = New System.Drawing.Point(41, 307)
        Me.ChPAGOS_PARCIALES.Name = "ChPAGOS_PARCIALES"
        Me.ChPAGOS_PARCIALES.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPAGOS_PARCIALES.Size = New System.Drawing.Size(227, 22)
        Me.ChPAGOS_PARCIALES.TabIndex = 10
        Me.ChPAGOS_PARCIALES.Text = "Ocultar pagos en parciales"
        Me.ChPAGOS_PARCIALES.UseVisualStyleBackColor = False
        Me.ChPAGOS_PARCIALES.Value = Nothing
        Me.ChPAGOS_PARCIALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChPER_VEND_ABA_MIN
        '
        Me.ChPER_VEND_ABA_MIN.BackColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_MIN.BorderColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_MIN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPER_VEND_ABA_MIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPER_VEND_ABA_MIN.ForeColor = System.Drawing.Color.Black
        Me.ChPER_VEND_ABA_MIN.Location = New System.Drawing.Point(41, 427)
        Me.ChPER_VEND_ABA_MIN.Name = "ChPER_VEND_ABA_MIN"
        Me.ChPER_VEND_ABA_MIN.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPER_VEND_ABA_MIN.Size = New System.Drawing.Size(225, 22)
        Me.ChPER_VEND_ABA_MIN.TabIndex = 15
        Me.ChPER_VEND_ABA_MIN.Text = "Permiri vender abajo del mínimo"
        Me.ChPER_VEND_ABA_MIN.UseVisualStyleBackColor = True
        Me.ChPER_VEND_ABA_MIN.Value = Nothing
        Me.ChPER_VEND_ABA_MIN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChNOVALIDAR_LIM_CRED
        '
        Me.ChNOVALIDAR_LIM_CRED.BackColor = System.Drawing.Color.Transparent
        Me.ChNOVALIDAR_LIM_CRED.BorderColor = System.Drawing.Color.Transparent
        Me.ChNOVALIDAR_LIM_CRED.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChNOVALIDAR_LIM_CRED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChNOVALIDAR_LIM_CRED.ForeColor = System.Drawing.Color.Black
        Me.ChNOVALIDAR_LIM_CRED.Location = New System.Drawing.Point(41, 379)
        Me.ChNOVALIDAR_LIM_CRED.Name = "ChNOVALIDAR_LIM_CRED"
        Me.ChNOVALIDAR_LIM_CRED.Padding = New System.Windows.Forms.Padding(1)
        Me.ChNOVALIDAR_LIM_CRED.Size = New System.Drawing.Size(225, 22)
        Me.ChNOVALIDAR_LIM_CRED.TabIndex = 13
        Me.ChNOVALIDAR_LIM_CRED.Text = "No validar límite de crédito"
        Me.ChNOVALIDAR_LIM_CRED.UseVisualStyleBackColor = True
        Me.ChNOVALIDAR_LIM_CRED.Value = Nothing
        Me.ChNOVALIDAR_LIM_CRED.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChVENDER_SIN_EXIST
        '
        Me.ChVENDER_SIN_EXIST.BackColor = System.Drawing.Color.Transparent
        Me.ChVENDER_SIN_EXIST.BorderColor = System.Drawing.Color.Transparent
        Me.ChVENDER_SIN_EXIST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChVENDER_SIN_EXIST.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChVENDER_SIN_EXIST.ForeColor = System.Drawing.Color.Black
        Me.ChVENDER_SIN_EXIST.Location = New System.Drawing.Point(41, 475)
        Me.ChVENDER_SIN_EXIST.Name = "ChVENDER_SIN_EXIST"
        Me.ChVENDER_SIN_EXIST.Padding = New System.Windows.Forms.Padding(1)
        Me.ChVENDER_SIN_EXIST.Size = New System.Drawing.Size(225, 22)
        Me.ChVENDER_SIN_EXIST.TabIndex = 17
        Me.ChVENDER_SIN_EXIST.Text = "Vender sin existencias"
        Me.ChVENDER_SIN_EXIST.UseVisualStyleBackColor = True
        Me.ChVENDER_SIN_EXIST.Value = Nothing
        Me.ChVENDER_SIN_EXIST.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChPER_VEND_ABA_COST
        '
        Me.ChPER_VEND_ABA_COST.BackColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_COST.BorderColor = System.Drawing.Color.Transparent
        Me.ChPER_VEND_ABA_COST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChPER_VEND_ABA_COST.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPER_VEND_ABA_COST.ForeColor = System.Drawing.Color.Black
        Me.ChPER_VEND_ABA_COST.Location = New System.Drawing.Point(41, 403)
        Me.ChPER_VEND_ABA_COST.Name = "ChPER_VEND_ABA_COST"
        Me.ChPER_VEND_ABA_COST.Padding = New System.Windows.Forms.Padding(1)
        Me.ChPER_VEND_ABA_COST.Size = New System.Drawing.Size(225, 22)
        Me.ChPER_VEND_ABA_COST.TabIndex = 14
        Me.ChPER_VEND_ABA_COST.Text = "Permirir vender abajo del costo"
        Me.ChPER_VEND_ABA_COST.UseVisualStyleBackColor = True
        Me.ChPER_VEND_ABA_COST.Value = Nothing
        Me.ChPER_VEND_ABA_COST.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChART_CON_IMP_INCLU
        '
        Me.ChART_CON_IMP_INCLU.BackColor = System.Drawing.Color.Transparent
        Me.ChART_CON_IMP_INCLU.BorderColor = System.Drawing.Color.Transparent
        Me.ChART_CON_IMP_INCLU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChART_CON_IMP_INCLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChART_CON_IMP_INCLU.ForeColor = System.Drawing.Color.Black
        Me.ChART_CON_IMP_INCLU.Location = New System.Drawing.Point(41, 451)
        Me.ChART_CON_IMP_INCLU.Name = "ChART_CON_IMP_INCLU"
        Me.ChART_CON_IMP_INCLU.Padding = New System.Windows.Forms.Padding(1)
        Me.ChART_CON_IMP_INCLU.Size = New System.Drawing.Size(225, 22)
        Me.ChART_CON_IMP_INCLU.TabIndex = 16
        Me.ChART_CON_IMP_INCLU.Text = "Artículos con impuesto incluido"
        Me.ChART_CON_IMP_INCLU.UseVisualStyleBackColor = True
        Me.ChART_CON_IMP_INCLU.Value = Nothing
        Me.ChART_CON_IMP_INCLU.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChOCULTAR_CRE_ENG
        '
        Me.ChOCULTAR_CRE_ENG.BackColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CRE_ENG.BorderColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CRE_ENG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChOCULTAR_CRE_ENG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChOCULTAR_CRE_ENG.ForeColor = System.Drawing.Color.Black
        Me.ChOCULTAR_CRE_ENG.Location = New System.Drawing.Point(41, 331)
        Me.ChOCULTAR_CRE_ENG.Name = "ChOCULTAR_CRE_ENG"
        Me.ChOCULTAR_CRE_ENG.Padding = New System.Windows.Forms.Padding(1)
        Me.ChOCULTAR_CRE_ENG.Size = New System.Drawing.Size(227, 22)
        Me.ChOCULTAR_CRE_ENG.TabIndex = 11
        Me.ChOCULTAR_CRE_ENG.Text = "Ocultar crédito con enganche"
        Me.ChOCULTAR_CRE_ENG.UseVisualStyleBackColor = False
        Me.ChOCULTAR_CRE_ENG.Value = Nothing
        Me.ChOCULTAR_CRE_ENG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChOCULTAR_CREDITO
        '
        Me.ChOCULTAR_CREDITO.BackColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CREDITO.BorderColor = System.Drawing.Color.Transparent
        Me.ChOCULTAR_CREDITO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChOCULTAR_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChOCULTAR_CREDITO.ForeColor = System.Drawing.Color.Black
        Me.ChOCULTAR_CREDITO.Location = New System.Drawing.Point(41, 355)
        Me.ChOCULTAR_CREDITO.Name = "ChOCULTAR_CREDITO"
        Me.ChOCULTAR_CREDITO.Padding = New System.Windows.Forms.Padding(1)
        Me.ChOCULTAR_CREDITO.Size = New System.Drawing.Size(227, 22)
        Me.ChOCULTAR_CREDITO.TabIndex = 12
        Me.ChOCULTAR_CREDITO.Text = "Ocultar crédito"
        Me.ChOCULTAR_CREDITO.UseVisualStyleBackColor = False
        Me.ChOCULTAR_CREDITO.Value = Nothing
        Me.ChOCULTAR_CREDITO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CboListaPrecPred
        '
        Me.CboListaPrecPred.AllowSpinLoop = False
        Me.CboListaPrecPred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboListaPrecPred.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboListaPrecPred.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboListaPrecPred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboListaPrecPred.GapHeight = 0
        Me.CboListaPrecPred.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboListaPrecPred.ItemsDisplayMember = ""
        Me.CboListaPrecPred.ItemsValueMember = ""
        Me.CboListaPrecPred.Location = New System.Drawing.Point(562, 135)
        Me.CboListaPrecPred.Name = "CboListaPrecPred"
        Me.CboListaPrecPred.Size = New System.Drawing.Size(250, 20)
        Me.CboListaPrecPred.TabIndex = 24
        Me.CboListaPrecPred.Tag = Nothing
        Me.CboListaPrecPred.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboListaPrecPred.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(355, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 16)
        Me.Label12.TabIndex = 341
        Me.Label12.Text = "Lista de precios predeterminada"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(444, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 338
        Me.Label11.Text = "Cliente mostrador"
        '
        'TDECIMALES
        '
        Me.TDECIMALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDECIMALES.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDECIMALES.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDECIMALES.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDECIMALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDECIMALES.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDECIMALES.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDECIMALES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDECIMALES.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDECIMALES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDECIMALES.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDECIMALES.InterceptArrowKeys = False
        Me.TDECIMALES.Location = New System.Drawing.Point(562, 161)
        Me.TDECIMALES.Name = "TDECIMALES"
        Me.TDECIMALES.Size = New System.Drawing.Size(39, 20)
        Me.TDECIMALES.TabIndex = 25
        Me.TDECIMALES.Tag = Nothing
        Me.TDECIMALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDECIMALES.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDECIMALES.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDECIMALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(484, 164)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 572
        Me.Label15.Text = "Decimales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(40, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 575
        Me.Label1.Text = "Estación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(489, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 577
        Me.Label2.Text = "Vendedor"
        '
        'TCVE_VEND
        '
        Me.TCVE_VEND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_VEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_VEND.Location = New System.Drawing.Point(562, 95)
        Me.TCVE_VEND.Name = "TCVE_VEND"
        Me.TCVE_VEND.Size = New System.Drawing.Size(79, 22)
        Me.TCVE_VEND.TabIndex = 576
        '
        'TESTACION
        '
        Me.TESTACION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TESTACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESTACION.Location = New System.Drawing.Point(105, 65)
        Me.TESTACION.Name = "TESTACION"
        Me.TESTACION.Size = New System.Drawing.Size(141, 22)
        Me.TESTACION.TabIndex = 0
        '
        'TCLIE_MOSTR
        '
        Me.TCLIE_MOSTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIE_MOSTR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIE_MOSTR.Location = New System.Drawing.Point(562, 67)
        Me.TCLIE_MOSTR.Name = "TCLIE_MOSTR"
        Me.TCLIE_MOSTR.Size = New System.Drawing.Size(79, 22)
        Me.TCLIE_MOSTR.TabIndex = 23
        '
        'BtnVend
        '
        Me.BtnVend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVend.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnVend.Location = New System.Drawing.Point(647, 94)
        Me.BtnVend.Name = "BtnVend"
        Me.BtnVend.Size = New System.Drawing.Size(23, 24)
        Me.BtnVend.TabIndex = 578
        Me.BtnVend.UseVisualStyleBackColor = True
        '
        'BtnCliente
        '
        Me.BtnCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCliente.Location = New System.Drawing.Point(647, 66)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(23, 24)
        Me.BtnCliente.TabIndex = 339
        Me.BtnCliente.UseVisualStyleBackColor = True
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
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(365, 218)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(39, 13)
        Me.Lt1.TabIndex = 580
        Me.Lt1.Text = "Label3"
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Location = New System.Drawing.Point(371, 260)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(39, 13)
        Me.Lt2.TabIndex = 581
        Me.Lt2.Text = "Label3"
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.Location = New System.Drawing.Point(367, 298)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(39, 13)
        Me.Lt3.TabIndex = 582
        Me.Lt3.Text = "Label3"
        '
        'FrmEstacionTrabAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 670)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnVend)
        Me.Controls.Add(Me.TCVE_VEND)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TESTACION)
        Me.Controls.Add(Me.TDECIMALES)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CboListaPrecPred)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.TCLIE_MOSTR)
        Me.Controls.Add(Me.ChPER_VEND_ABA_MIN)
        Me.Controls.Add(Me.ChNOVALIDAR_LIM_CRED)
        Me.Controls.Add(Me.ChVENDER_SIN_EXIST)
        Me.Controls.Add(Me.ChPER_VEND_ABA_COST)
        Me.Controls.Add(Me.ChART_CON_IMP_INCLU)
        Me.Controls.Add(Me.ChOCULTAR_CRE_ENG)
        Me.Controls.Add(Me.ChOCULTAR_CREDITO)
        Me.Controls.Add(Me.ChREIMPRIMIR_TICKET)
        Me.Controls.Add(Me.ChAGREGAR_CLIENTE)
        Me.Controls.Add(Me.ChTIEMPO_AIRE)
        Me.Controls.Add(Me.ChSOLECCIONAR_SERIES)
        Me.Controls.Add(Me.ChCOLUMNA_DESCUENTO)
        Me.Controls.Add(Me.ChPAGOS_PARCIALES)
        Me.Controls.Add(Me.ChAGREGAR_PROD)
        Me.Controls.Add(Me.ChPERMITE_DESC)
        Me.Controls.Add(Me.ChPRECIOS)
        Me.Controls.Add(Me.ChMONEDERO)
        Me.Controls.Add(Me.ChFLUJO)
        Me.Controls.Add(Me.ChPROMOCIONES)
        Me.Controls.Add(Me.ChIMP_NOTA)
        Me.Controls.Add(Me.ChLECTORHUELLA)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstacionTrabAE"
        Me.Text = "Estación de trabajo"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChLECTORHUELLA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChIMP_NOTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPROMOCIONES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChFLUJO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChMONEDERO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPRECIOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPERMITE_DESC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChAGREGAR_PROD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChREIMPRIMIR_TICKET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChAGREGAR_CLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChTIEMPO_AIRE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChSOLECCIONAR_SERIES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChCOLUMNA_DESCUENTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPAGOS_PARCIALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPER_VEND_ABA_MIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChNOVALIDAR_LIM_CRED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChVENDER_SIN_EXIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChPER_VEND_ABA_COST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChART_CON_IMP_INCLU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChOCULTAR_CRE_ENG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChOCULTAR_CREDITO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboListaPrecPred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDECIMALES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents ChLECTORHUELLA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChREIMPRIMIR_TICKET As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChAGREGAR_CLIENTE As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChTIEMPO_AIRE As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChSOLECCIONAR_SERIES As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChCOLUMNA_DESCUENTO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPAGOS_PARCIALES As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChAGREGAR_PROD As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPERMITE_DESC As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPRECIOS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChMONEDERO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChFLUJO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPROMOCIONES As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChIMP_NOTA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPER_VEND_ABA_MIN As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChNOVALIDAR_LIM_CRED As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChVENDER_SIN_EXIST As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChPER_VEND_ABA_COST As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChART_CON_IMP_INCLU As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChOCULTAR_CRE_ENG As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChOCULTAR_CREDITO As C1.Win.C1Input.C1CheckBox
    Friend WithEvents CboListaPrecPred As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnCliente As Button
    Friend WithEvents TCLIE_MOSTR As TextBoxEx
    Friend WithEvents TDECIMALES As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TESTACION As TextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnVend As Button
    Friend WithEvents TCVE_VEND As TextBoxEx
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt3 As Label
End Class
