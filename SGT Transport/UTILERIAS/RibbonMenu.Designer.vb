<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RibbonMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonMenu))
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkActualizar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.MenuHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtRFCDestino = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.LtPaisDestino = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.LtEstadoDestino = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.LtMunicipioDestino = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.LtCPDestino = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.LtLocalidadDestino = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.LtColoniaDestino = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.LtNumExtDestino = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.LtNumIntDestino = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.LtCalleDestino = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.C1Button4 = New C1.Win.C1Input.C1Button()
        Me.BtnRegimenFiscal = New C1.Win.C1Input.C1Button()
        Me.C1Button3 = New C1.Win.C1Input.C1Button()
        Me.C1Button2 = New C1.Win.C1Input.C1Button()
        Me.C1Button1 = New C1.Win.C1Input.C1Button()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.BarActualizar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarDisenador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Button4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnRegimenFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Button3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Button2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.BarNuevo
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.Text = "Nuevo"
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.BarEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Edit"
        '
        'LkEliminar
        '
        Me.LkEliminar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEliminar.Command = Me.BarEliminar
        Me.LkEliminar.Delimiter = True
        Me.LkEliminar.SortOrder = 2
        Me.LkEliminar.Text = "Cancelar"
        Me.LkEliminar.ToolTipText = "Cancelar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 7
        Me.LkSalir.ToolTipText = "SALIR"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkEliminar, Me.LkActualizar, Me.LkImprimir, Me.LkExcel, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1055, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkActualizar
        '
        Me.LkActualizar.Command = Me.BarActualizar
        Me.LkActualizar.Delimiter = True
        Me.LkActualizar.SortOrder = 3
        Me.LkActualizar.Text = "Actualizar"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.SortOrder = 4
        Me.LkImprimir.Text = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 5
        Me.LkExcel.Text = "Excel"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDisenador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 6
        Me.LkDisenador.Text = "Diseñador"
        '
        'MenuHolder1
        '
        Me.MenuHolder1.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder1.Commands.Add(Me.BarNuevo)
        Me.MenuHolder1.Commands.Add(Me.BarEdit)
        Me.MenuHolder1.Commands.Add(Me.BarEliminar)
        Me.MenuHolder1.Commands.Add(Me.BarSalir)
        Me.MenuHolder1.Commands.Add(Me.BarExcel)
        Me.MenuHolder1.Commands.Add(Me.BarActualizar)
        Me.MenuHolder1.Commands.Add(Me.BarImprimir)
        Me.MenuHolder1.Commands.Add(Me.BarDisenador)
        Me.MenuHolder1.Owner = Me
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'LtRFCDestino
        '
        Me.LtRFCDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtRFCDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFCDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFCDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtRFCDestino.Location = New System.Drawing.Point(313, 58)
        Me.LtRFCDestino.Name = "LtRFCDestino"
        Me.LtRFCDestino.Size = New System.Drawing.Size(209, 24)
        Me.LtRFCDestino.TabIndex = 168
        Me.LtRFCDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label62.Location = New System.Drawing.Point(272, 62)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(34, 16)
        Me.Label62.TabIndex = 167
        Me.Label62.Text = "RFC"
        '
        'LtPaisDestino
        '
        Me.LtPaisDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LtPaisDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPaisDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPaisDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtPaisDestino.Location = New System.Drawing.Point(692, 172)
        Me.LtPaisDestino.Name = "LtPaisDestino"
        Me.LtPaisDestino.Size = New System.Drawing.Size(93, 24)
        Me.LtPaisDestino.TabIndex = 166
        Me.LtPaisDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label55.Location = New System.Drawing.Point(652, 175)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(34, 16)
        Me.Label55.TabIndex = 165
        Me.Label55.Text = "Pais"
        '
        'LtEstadoDestino
        '
        Me.LtEstadoDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtEstadoDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEstadoDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEstadoDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtEstadoDestino.Location = New System.Drawing.Point(510, 171)
        Me.LtEstadoDestino.Name = "LtEstadoDestino"
        Me.LtEstadoDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtEstadoDestino.TabIndex = 164
        Me.LtEstadoDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label63.Location = New System.Drawing.Point(453, 175)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(50, 16)
        Me.Label63.TabIndex = 163
        Me.Label63.Text = "Estado"
        '
        'LtMunicipioDestino
        '
        Me.LtMunicipioDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtMunicipioDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMunicipioDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMunicipioDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtMunicipioDestino.Location = New System.Drawing.Point(313, 172)
        Me.LtMunicipioDestino.Name = "LtMunicipioDestino"
        Me.LtMunicipioDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtMunicipioDestino.TabIndex = 162
        Me.LtMunicipioDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label65.Location = New System.Drawing.Point(242, 176)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(64, 16)
        Me.Label65.TabIndex = 161
        Me.Label65.Text = "Municipio"
        '
        'LtCPDestino
        '
        Me.LtCPDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCPDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCPDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCPDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCPDestino.Location = New System.Drawing.Point(510, 144)
        Me.LtCPDestino.Name = "LtCPDestino"
        Me.LtCPDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtCPDestino.TabIndex = 160
        Me.LtCPDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(412, 147)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(91, 16)
        Me.Label67.TabIndex = 159
        Me.Label67.Text = "Codigo postal"
        '
        'LtLocalidadDestino
        '
        Me.LtLocalidadDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLocalidadDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLocalidadDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLocalidadDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLocalidadDestino.Location = New System.Drawing.Point(313, 144)
        Me.LtLocalidadDestino.Name = "LtLocalidadDestino"
        Me.LtLocalidadDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtLocalidadDestino.TabIndex = 158
        Me.LtLocalidadDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label69.Location = New System.Drawing.Point(239, 147)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(67, 16)
        Me.Label69.TabIndex = 157
        Me.Label69.Text = "Localidad"
        '
        'LtColoniaDestino
        '
        Me.LtColoniaDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtColoniaDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtColoniaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtColoniaDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtColoniaDestino.Location = New System.Drawing.Point(692, 116)
        Me.LtColoniaDestino.Name = "LtColoniaDestino"
        Me.LtColoniaDestino.Size = New System.Drawing.Size(92, 24)
        Me.LtColoniaDestino.TabIndex = 156
        Me.LtColoniaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label59.Location = New System.Drawing.Point(633, 120)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(53, 16)
        Me.Label59.TabIndex = 155
        Me.Label59.Text = "Colonia"
        '
        'LtNumExtDestino
        '
        Me.LtNumExtDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNumExtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumExtDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumExtDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNumExtDestino.Location = New System.Drawing.Point(510, 116)
        Me.LtNumExtDestino.Name = "LtNumExtDestino"
        Me.LtNumExtDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtNumExtDestino.TabIndex = 154
        Me.LtNumExtDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(442, 119)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(61, 16)
        Me.Label61.TabIndex = 153
        Me.Label61.Text = "Num. ext."
        '
        'LtNumIntDestino
        '
        Me.LtNumIntDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNumIntDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNumIntDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNumIntDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNumIntDestino.Location = New System.Drawing.Point(313, 116)
        Me.LtNumIntDestino.Name = "LtNumIntDestino"
        Me.LtNumIntDestino.Size = New System.Drawing.Size(76, 24)
        Me.LtNumIntDestino.TabIndex = 152
        Me.LtNumIntDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(249, 119)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(57, 16)
        Me.Label57.TabIndex = 151
        Me.Label57.Text = "Num. int."
        '
        'LtCalleDestino
        '
        Me.LtCalleDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtCalleDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCalleDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCalleDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtCalleDestino.Location = New System.Drawing.Point(313, 88)
        Me.LtCalleDestino.Name = "LtCalleDestino"
        Me.LtCalleDestino.Size = New System.Drawing.Size(469, 24)
        Me.LtCalleDestino.TabIndex = 150
        Me.LtCalleDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(268, 92)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(38, 16)
        Me.Label54.TabIndex = 149
        Me.Label54.Text = "Calle"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "5,1,0,0,0,95,Columns:"
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(15, 238)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(465, 177)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 312
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(608, 272)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(245, 106)
        Me.TableLayoutPanel1.TabIndex = 314
        '
        'C1Button4
        '
        Me.C1Button4.FlatAppearance.BorderSize = 0
        Me.C1Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1Button4.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.C1Button4.Location = New System.Drawing.Point(25, 114)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(23, 24)
        Me.C1Button4.TabIndex = 194
        Me.C1Button4.UseVisualStyleBackColor = True
        '
        'BtnRegimenFiscal
        '
        Me.BtnRegimenFiscal.FlatAppearance.BorderSize = 0
        Me.BtnRegimenFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegimenFiscal.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnRegimenFiscal.Location = New System.Drawing.Point(25, 84)
        Me.BtnRegimenFiscal.Name = "BtnRegimenFiscal"
        Me.BtnRegimenFiscal.Size = New System.Drawing.Size(23, 24)
        Me.BtnRegimenFiscal.TabIndex = 193
        Me.BtnRegimenFiscal.UseVisualStyleBackColor = True
        '
        'C1Button3
        '
        Me.C1Button3.Image = Global.SGT_Transport.My.Resources.Resources.lapiz21
        Me.C1Button3.Location = New System.Drawing.Point(564, 54)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(41, 33)
        Me.C1Button3.TabIndex = 174
        Me.C1Button3.UseVisualStyleBackColor = True
        '
        'C1Button2
        '
        Me.C1Button2.FlatAppearance.BorderSize = 0
        Me.C1Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1Button2.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.C1Button2.Location = New System.Drawing.Point(25, 150)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(23, 24)
        Me.C1Button2.TabIndex = 172
        Me.C1Button2.UseVisualStyleBackColor = True
        '
        'C1Button1
        '
        Me.C1Button1.Image = Global.SGT_Transport.My.Resources.Resources.cuadro2
        Me.C1Button1.Location = New System.Drawing.Point(528, 54)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(30, 33)
        Me.C1Button1.TabIndex = 170
        Me.C1Button1.UseVisualStyleBackColor = True
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.ShowShortcut = False
        Me.BarNuevo.ShowTextAsToolTip = False
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Edit"
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar1
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutText = ""
        Me.BarEliminar.ShowShortcut = False
        Me.BarEliminar.ShowTextAsToolTip = False
        Me.BarEliminar.Text = "Cancelar"
        '
        'BarActualizar
        '
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutText = ""
        Me.BarActualizar.Text = "Actualizar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarDisenador
        '
        Me.BarDisenador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDisenador.Name = "BarDisenador"
        Me.BarDisenador.ShortcutText = ""
        Me.BarDisenador.Text = "Diseñador"
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
        'RibbonMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 455)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1Button4)
        Me.Controls.Add(Me.BtnRegimenFiscal)
        Me.Controls.Add(Me.C1Button3)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.LtRFCDestino)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.LtPaisDestino)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.LtEstadoDestino)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.LtMunicipioDestino)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.LtCPDestino)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.LtLocalidadDestino)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.LtColoniaDestino)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.LtNumExtDestino)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.LtNumIntDestino)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.LtCalleDestino)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Name = "RibbonMenu"
        Me.Text = "RibbonForm2"
        CType(Me.MenuHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Button4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnRegimenFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Button3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Button2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents MenuHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents Label1 As Label
    Friend WithEvents LtRFCDestino As Label
    Private WithEvents Label62 As Label
    Friend WithEvents LtPaisDestino As Label
    Private WithEvents Label55 As Label
    Friend WithEvents LtEstadoDestino As Label
    Private WithEvents Label63 As Label
    Friend WithEvents LtMunicipioDestino As Label
    Private WithEvents Label65 As Label
    Friend WithEvents LtCPDestino As Label
    Private WithEvents Label67 As Label
    Friend WithEvents LtLocalidadDestino As Label
    Private WithEvents Label69 As Label
    Friend WithEvents LtColoniaDestino As Label
    Private WithEvents Label59 As Label
    Friend WithEvents LtNumExtDestino As Label
    Private WithEvents Label61 As Label
    Friend WithEvents LtNumIntDestino As Label
    Private WithEvents Label57 As Label
    Friend WithEvents LtCalleDestino As Label
    Private WithEvents Label54 As Label
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents BtnRegimenFiscal As C1.Win.C1Input.C1Button
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LkActualizar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDisenador As C1.Win.C1Command.C1Command
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarActualizar As C1.Win.C1Command.C1Command
End Class
