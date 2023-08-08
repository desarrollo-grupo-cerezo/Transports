<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLineasAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLineasAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_LIN = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDESC_LIN = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCUENTA_COI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1CheckBox1 = New C1.Win.C1Input.C1CheckBox()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtEjemplo = New System.Windows.Forms.Label()
        Me.tSubGrupoColor = New C1.Win.C1Input.C1NumericEdit()
        Me.tSubGrupoTalla = New C1.Win.C1Input.C1NumericEdit()
        Me.tSep2 = New System.Windows.Forms.TextBox()
        Me.tSep1 = New System.Windows.Forms.TextBox()
        Me.tGrupo = New C1.Win.C1Input.C1NumericEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1DockingTab2 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1DockingTabPage4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu.SuspendLayout()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.tSubGrupoColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSubGrupoTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage2.SuspendLayout()
        CType(Me.C1DockingTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab2.SuspendLayout()
        Me.C1DockingTabPage3.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage4.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(493, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 4
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_LIN
        '
        Me.tCVE_LIN.AcceptsReturn = True
        Me.tCVE_LIN.AcceptsTab = True
        Me.tCVE_LIN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_LIN.Location = New System.Drawing.Point(109, 85)
        Me.tCVE_LIN.Name = "tCVE_LIN"
        Me.tCVE_LIN.Size = New System.Drawing.Size(110, 21)
        Me.tCVE_LIN.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(72, 88)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        '
        'tDESC_LIN
        '
        Me.tDESC_LIN.AcceptsReturn = True
        Me.tDESC_LIN.AcceptsTab = True
        Me.tDESC_LIN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDESC_LIN.Location = New System.Drawing.Point(109, 112)
        Me.tDESC_LIN.Name = "tDESC_LIN"
        Me.tDESC_LIN.Size = New System.Drawing.Size(205, 21)
        Me.tDESC_LIN.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(62, 115)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tCUENTA_COI
        '
        Me.tCUENTA_COI.AcceptsReturn = True
        Me.tCUENTA_COI.AcceptsTab = True
        Me.tCUENTA_COI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUENTA_COI.Location = New System.Drawing.Point(109, 139)
        Me.tCUENTA_COI.Name = "tCUENTA_COI"
        Me.tCUENTA_COI.Size = New System.Drawing.Size(205, 21)
        Me.tCUENTA_COI.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Cuenta contable"
        '
        'C1CheckBox1
        '
        Me.C1CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox1.Enabled = False
        Me.C1CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox1.Location = New System.Drawing.Point(24, 238)
        Me.C1CheckBox1.Name = "C1CheckBox1"
        Me.C1CheckBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox1.Size = New System.Drawing.Size(225, 24)
        Me.C1CheckBox1.TabIndex = 121
        Me.C1CheckBox1.Text = "Aplicar manejo de grupos y subgrupos"
        Me.C1CheckBox1.UseVisualStyleBackColor = False
        Me.C1CheckBox1.Value = Nothing
        Me.C1CheckBox1.Visible = False
        Me.C1CheckBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Location = New System.Drawing.Point(15, 268)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.Size = New System.Drawing.Size(465, 254)
        Me.C1DockingTab1.TabIndex = 122
        Me.C1DockingTab1.TabsSpacing = 5
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
        Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.LtEjemplo)
        Me.C1DockingTabPage1.Controls.Add(Me.tSubGrupoColor)
        Me.C1DockingTabPage1.Controls.Add(Me.tSubGrupoTalla)
        Me.C1DockingTabPage1.Controls.Add(Me.tSep2)
        Me.C1DockingTabPage1.Controls.Add(Me.tSep1)
        Me.C1DockingTabPage1.Controls.Add(Me.tGrupo)
        Me.C1DockingTabPage1.Controls.Add(Me.Label7)
        Me.C1DockingTabPage1.Controls.Add(Me.Label8)
        Me.C1DockingTabPage1.Controls.Add(Me.Label3)
        Me.C1DockingTabPage1.Controls.Add(Me.Label4)
        Me.C1DockingTabPage1.Controls.Add(Me.Label5)
        Me.C1DockingTabPage1.Controls.Add(Me.Label6)
        Me.C1DockingTabPage1.Controls.Add(Me.Label2)
        Me.C1DockingTabPage1.Enabled = False
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(463, 229)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Configuración de la clave"
        Me.C1DockingTabPage1.Visible = False
        '
        'LtEjemplo
        '
        Me.LtEjemplo.AutoSize = True
        Me.LtEjemplo.BackColor = System.Drawing.Color.Transparent
        Me.LtEjemplo.Location = New System.Drawing.Point(106, 179)
        Me.LtEjemplo.Name = "LtEjemplo"
        Me.LtEjemplo.Size = New System.Drawing.Size(0, 13)
        Me.LtEjemplo.TabIndex = 135
        '
        'tSubGrupoColor
        '
        Me.tSubGrupoColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tSubGrupoColor.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tSubGrupoColor.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSubGrupoColor.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSubGrupoColor.DataType = GetType(Short)
        Me.tSubGrupoColor.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tSubGrupoColor.Location = New System.Drawing.Point(204, 139)
        Me.tSubGrupoColor.Name = "tSubGrupoColor"
        Me.tSubGrupoColor.Size = New System.Drawing.Size(62, 18)
        Me.tSubGrupoColor.TabIndex = 134
        Me.tSubGrupoColor.Tag = Nothing
        Me.tSubGrupoColor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown
        '
        'tSubGrupoTalla
        '
        Me.tSubGrupoTalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tSubGrupoTalla.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tSubGrupoTalla.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSubGrupoTalla.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSubGrupoTalla.DataType = GetType(Short)
        Me.tSubGrupoTalla.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tSubGrupoTalla.Location = New System.Drawing.Point(204, 110)
        Me.tSubGrupoTalla.Name = "tSubGrupoTalla"
        Me.tSubGrupoTalla.Size = New System.Drawing.Size(62, 18)
        Me.tSubGrupoTalla.TabIndex = 133
        Me.tSubGrupoTalla.Tag = Nothing
        Me.tSubGrupoTalla.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown
        '
        'tSep2
        '
        Me.tSep2.AcceptsReturn = True
        Me.tSep2.AcceptsTab = True
        Me.tSep2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSep2.Location = New System.Drawing.Point(289, 110)
        Me.tSep2.Name = "tSep2"
        Me.tSep2.Size = New System.Drawing.Size(31, 21)
        Me.tSep2.TabIndex = 132
        Me.tSep2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tSep1
        '
        Me.tSep1.AcceptsReturn = True
        Me.tSep1.AcceptsTab = True
        Me.tSep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tSep1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSep1.Location = New System.Drawing.Point(289, 80)
        Me.tSep1.Name = "tSep1"
        Me.tSep1.Size = New System.Drawing.Size(31, 21)
        Me.tSep1.TabIndex = 131
        Me.tSep1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tGrupo
        '
        Me.tGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tGrupo.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tGrupo.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tGrupo.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tGrupo.DataType = GetType(Short)
        Me.tGrupo.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tGrupo.Location = New System.Drawing.Point(204, 81)
        Me.tGrupo.Name = "tGrupo"
        Me.tGrupo.Size = New System.Drawing.Size(62, 18)
        Me.tGrupo.TabIndex = 130
        Me.tGrupo.Tag = Nothing
        Me.tGrupo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(286, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Separador"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(210, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Longitud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(56, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Ejemplo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(56, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Subgrupo 1    Talla"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(56, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Grupo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(56, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Subgrupo 2    color"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(30, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(366, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Definir la estructura de la clave para los productos que pertenecen a la linea"
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.C1DockingTab2)
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(463, 229)
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "Alta de Talla y Color"
        '
        'C1DockingTab2
        '
        Me.C1DockingTab2.Controls.Add(Me.C1DockingTabPage3)
        Me.C1DockingTab2.Controls.Add(Me.C1DockingTabPage4)
        Me.C1DockingTab2.Location = New System.Drawing.Point(3, 3)
        Me.C1DockingTab2.Name = "C1DockingTab2"
        Me.C1DockingTab2.SelectedIndex = 1
        Me.C1DockingTab2.Size = New System.Drawing.Size(457, 223)
        Me.C1DockingTab2.TabIndex = 0
        Me.C1DockingTab2.TabsSpacing = 5
        Me.C1DockingTab2.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1DockingTab2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.Controls.Add(Me.Fg)
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(455, 198)
        Me.C1DockingTabPage3.TabIndex = 0
        Me.C1DockingTabPage3.Text = "Talla"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:79;Caption:""Talla"";AllowDragging:False;AllowEditing:" &
    "False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:307;Caption:""Descripcion"";AllowDragging:False;AllowEditing:False" &
    ";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(3, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(449, 184)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage4
        '
        Me.C1DockingTabPage4.Controls.Add(Me.Fg)
        Me.C1DockingTabPage4.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage4.Name = "C1DockingTabPage4"
        Me.C1DockingTabPage4.Size = New System.Drawing.Size(455, 198)
        Me.C1DockingTabPage4.TabIndex = 1
        Me.C1DockingTabPage4.Text = "Color"
        '
        'Fg2
        '
        Me.Fg2.AllowFiltering = True
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:67;Caption:""Color"";AllowDragging:False;AllowEditing:" &
    "False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:323;Caption:""Descripción"";AllowDragging:False;AllowEditing:False" &
    ";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.Location = New System.Drawing.Point(3, 11)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(449, 184)
        Me.Fg2.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg2.TabIndex = 11
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'FrmLineasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 220)
        Me.Controls.Add(Me.C1DockingTab1)
        Me.Controls.Add(Me.C1CheckBox1)
        Me.Controls.Add(Me.tCUENTA_COI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_LIN)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDESC_LIN)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLineasAE"
        Me.Text = "Lineas"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        CType(Me.tSubGrupoColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSubGrupoTalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage2.ResumeLayout(False)
        CType(Me.C1DockingTab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab2.ResumeLayout(False)
        Me.C1DockingTabPage3.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage4.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents tCVE_LIN As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDESC_LIN As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCUENTA_COI As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents C1CheckBox1 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTab2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tSubGrupoColor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tSubGrupoTalla As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tSep2 As TextBox
    Friend WithEvents tSep1 As TextBox
    Friend WithEvents tGrupo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents LtEjemplo As Label
End Class
