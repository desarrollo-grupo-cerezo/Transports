<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParamOpcInvent
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripButton()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtLinea = New System.Windows.Forms.Label()
        Me.btnLinea = New C1.Win.C1Input.C1Button()
        Me.tCPROD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chAfecTablaInve = New C1.Win.C1Input.C1CheckBox()
        Me.cboALM_CONSIGNA = New C1.Win.C1Input.C1ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chMULTIALMACEN = New C1.Win.C1Input.C1CheckBox()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCveCptoOper = New C1.Win.C1Input.C1ComboBox()
        Me.cboCveCptoOT = New C1.Win.C1Input.C1ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCveCptoOTSAL = New C1.Win.C1Input.C1ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.btnLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAfecTablaInve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboALM_CONSIGNA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chMULTIALMACEN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage2.SuspendLayout()
        CType(Me.cboCveCptoOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCveCptoOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCveCptoOTSAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(557, 54)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.C1ThemeController1.SetTheme(Me.ToolStrip1, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.Size = New System.Drawing.Size(46, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage3)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.HotTrack = True
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 54)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.Size = New System.Drawing.Size(557, 340)
        Me.C1DockingTab1.TabIndex = 7
        Me.C1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.C1DockingTab1.TabsShowFocusCues = False
        Me.C1DockingTab1.TabsSpacing = 2
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1ThemeController1.SetTheme(Me.C1DockingTab1, "Office2010Blue")
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.LtLinea)
        Me.C1DockingTabPage1.Controls.Add(Me.btnLinea)
        Me.C1DockingTabPage1.Controls.Add(Me.tCPROD)
        Me.C1DockingTabPage1.Controls.Add(Me.Label1)
        Me.C1DockingTabPage1.Controls.Add(Me.chAfecTablaInve)
        Me.C1DockingTabPage1.Controls.Add(Me.cboALM_CONSIGNA)
        Me.C1DockingTabPage1.Controls.Add(Me.Label8)
        Me.C1DockingTabPage1.Controls.Add(Me.chMULTIALMACEN)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(555, 315)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Generales"
        '
        'LtLinea
        '
        Me.LtLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLinea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtLinea.Location = New System.Drawing.Point(318, 118)
        Me.LtLinea.Name = "LtLinea"
        Me.LtLinea.Size = New System.Drawing.Size(136, 19)
        Me.LtLinea.TabIndex = 325
        Me.C1ThemeController1.SetTheme(Me.LtLinea, "Office2010Blue")
        '
        'btnLinea
        '
        Me.btnLinea.AutoSize = True
        Me.btnLinea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLinea.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnLinea.Location = New System.Drawing.Point(290, 115)
        Me.btnLinea.Name = "btnLinea"
        Me.btnLinea.Size = New System.Drawing.Size(22, 22)
        Me.btnLinea.TabIndex = 324
        Me.C1ThemeController1.SetTheme(Me.btnLinea, "Office2010Blue")
        Me.btnLinea.UseVisualStyleBackColor = True
        Me.btnLinea.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCPROD
        '
        Me.tCPROD.ForeColor = System.Drawing.Color.Black
        Me.tCPROD.Location = New System.Drawing.Point(186, 116)
        Me.tCPROD.MaxLength = 5
        Me.tCPROD.Name = "tCPROD"
        Me.tCPROD.Size = New System.Drawing.Size(100, 20)
        Me.tCPROD.TabIndex = 319
        Me.C1ThemeController1.SetTheme(Me.tCPROD, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 15)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "Linea a filtrar servicios en OTE"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'chAfecTablaInve
        '
        Me.chAfecTablaInve.BackColor = System.Drawing.Color.Transparent
        Me.chAfecTablaInve.BorderColor = System.Drawing.Color.Transparent
        Me.chAfecTablaInve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chAfecTablaInve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chAfecTablaInve.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chAfecTablaInve.Location = New System.Drawing.Point(207, 26)
        Me.chAfecTablaInve.Name = "chAfecTablaInve"
        Me.chAfecTablaInve.Padding = New System.Windows.Forms.Padding(4, 1, 1, 1)
        Me.chAfecTablaInve.Size = New System.Drawing.Size(179, 20)
        Me.chAfecTablaInve.TabIndex = 317
        Me.chAfecTablaInve.Text = "Afectar tabla INVE"
        Me.C1ThemeController1.SetTheme(Me.chAfecTablaInve, "Office2010Blue")
        Me.chAfecTablaInve.UseVisualStyleBackColor = True
        Me.chAfecTablaInve.Value = Nothing
        Me.chAfecTablaInve.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'cboALM_CONSIGNA
        '
        Me.cboALM_CONSIGNA.AllowSpinLoop = False
        Me.cboALM_CONSIGNA.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboALM_CONSIGNA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboALM_CONSIGNA.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboALM_CONSIGNA.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboALM_CONSIGNA.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboALM_CONSIGNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboALM_CONSIGNA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboALM_CONSIGNA.GapHeight = 0
        Me.cboALM_CONSIGNA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboALM_CONSIGNA.ItemsDisplayMember = ""
        Me.cboALM_CONSIGNA.ItemsValueMember = ""
        Me.cboALM_CONSIGNA.Location = New System.Drawing.Point(186, 76)
        Me.cboALM_CONSIGNA.Name = "cboALM_CONSIGNA"
        Me.cboALM_CONSIGNA.Size = New System.Drawing.Size(68, 19)
        Me.cboALM_CONSIGNA.TabIndex = 172
        Me.cboALM_CONSIGNA.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboALM_CONSIGNA, "Office2010Blue")
        Me.cboALM_CONSIGNA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(33, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Almacén de consignación"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'chMULTIALMACEN
        '
        Me.chMULTIALMACEN.BackColor = System.Drawing.Color.Transparent
        Me.chMULTIALMACEN.BorderColor = System.Drawing.Color.Transparent
        Me.chMULTIALMACEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chMULTIALMACEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chMULTIALMACEN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chMULTIALMACEN.Location = New System.Drawing.Point(20, 26)
        Me.chMULTIALMACEN.Name = "chMULTIALMACEN"
        Me.chMULTIALMACEN.Padding = New System.Windows.Forms.Padding(4, 1, 1, 1)
        Me.chMULTIALMACEN.Size = New System.Drawing.Size(221, 20)
        Me.chMULTIALMACEN.TabIndex = 5
        Me.chMULTIALMACEN.Text = "Manejar multialmacén"
        Me.C1ThemeController1.SetTheme(Me.chMULTIALMACEN, "Office2010Blue")
        Me.chMULTIALMACEN.UseVisualStyleBackColor = True
        Me.chMULTIALMACEN.Value = Nothing
        Me.chMULTIALMACEN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.Label4)
        Me.C1DockingTabPage2.Controls.Add(Me.cboCveCptoOper)
        Me.C1DockingTabPage2.Controls.Add(Me.cboCveCptoOT)
        Me.C1DockingTabPage2.Controls.Add(Me.Label2)
        Me.C1DockingTabPage2.Controls.Add(Me.cboCveCptoOTSAL)
        Me.C1DockingTabPage2.Controls.Add(Me.Label3)
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(555, 315)
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "Movs. al inventario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 15)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "Concepto Minve. operador salida"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'cboCveCptoOper
        '
        Me.cboCveCptoOper.AllowSpinLoop = False
        Me.cboCveCptoOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboCveCptoOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboCveCptoOper.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboCveCptoOper.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboCveCptoOper.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboCveCptoOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCveCptoOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboCveCptoOper.GapHeight = 0
        Me.cboCveCptoOper.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboCveCptoOper.ItemsDisplayMember = ""
        Me.cboCveCptoOper.ItemsValueMember = ""
        Me.cboCveCptoOper.Location = New System.Drawing.Point(198, 131)
        Me.cboCveCptoOper.Name = "cboCveCptoOper"
        Me.cboCveCptoOper.Size = New System.Drawing.Size(216, 19)
        Me.cboCveCptoOper.TabIndex = 325
        Me.cboCveCptoOper.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboCveCptoOper, "Office2010Blue")
        Me.cboCveCptoOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'cboCveCptoOT
        '
        Me.cboCveCptoOT.AllowSpinLoop = False
        Me.cboCveCptoOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboCveCptoOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboCveCptoOT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboCveCptoOT.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboCveCptoOT.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboCveCptoOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCveCptoOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboCveCptoOT.GapHeight = 0
        Me.cboCveCptoOT.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboCveCptoOT.ItemsDisplayMember = ""
        Me.cboCveCptoOT.ItemsValueMember = ""
        Me.cboCveCptoOT.Location = New System.Drawing.Point(198, 30)
        Me.cboCveCptoOT.Name = "cboCveCptoOT"
        Me.cboCveCptoOT.Size = New System.Drawing.Size(216, 19)
        Me.cboCveCptoOT.TabIndex = 321
        Me.cboCveCptoOT.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboCveCptoOT, "Office2010Blue")
        Me.cboCveCptoOT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(40, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 15)
        Me.Label2.TabIndex = 320
        Me.Label2.Text = "Concepto Minve. OT salida"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'cboCveCptoOTSAL
        '
        Me.cboCveCptoOTSAL.AllowSpinLoop = False
        Me.cboCveCptoOTSAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboCveCptoOTSAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboCveCptoOTSAL.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboCveCptoOTSAL.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboCveCptoOTSAL.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboCveCptoOTSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCveCptoOTSAL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboCveCptoOTSAL.GapHeight = 0
        Me.cboCveCptoOTSAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboCveCptoOTSAL.ItemsDisplayMember = ""
        Me.cboCveCptoOTSAL.ItemsValueMember = ""
        Me.cboCveCptoOTSAL.Location = New System.Drawing.Point(198, 81)
        Me.cboCveCptoOTSAL.Name = "cboCveCptoOTSAL"
        Me.cboCveCptoOTSAL.Size = New System.Drawing.Size(216, 19)
        Me.cboCveCptoOTSAL.TabIndex = 323
        Me.cboCveCptoOTSAL.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboCveCptoOTSAL, "Office2010Blue")
        Me.cboCveCptoOTSAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(31, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 15)
        Me.Label3.TabIndex = 322
        Me.Label3.Text = "Concepto Minve. OT entrada"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(555, 315)
        Me.C1DockingTabPage3.TabIndex = 2
        Me.C1DockingTabPage3.Text = "Campos libres"
        '
        'frmParamInvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 394)
        Me.Controls.Add(Me.C1DockingTab1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmParamInvent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Parámetros inventario"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        CType(Me.btnLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAfecTablaInve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboALM_CONSIGNA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chMULTIALMACEN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.C1DockingTabPage2.PerformLayout()
        CType(Me.cboCveCptoOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCveCptoOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCveCptoOTSAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barGrabar As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents chMULTIALMACEN As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents cboALM_CONSIGNA As C1.Win.C1Input.C1ComboBox
    Friend WithEvents chAfecTablaInve As C1.Win.C1Input.C1CheckBox
    Friend WithEvents tCPROD As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboCveCptoOT As C1.Win.C1Input.C1ComboBox
    Friend WithEvents cboCveCptoOTSAL As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LtLinea As Label
    Friend WithEvents btnLinea As C1.Win.C1Input.C1Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cboCveCptoOper As C1.Win.C1Input.C1ComboBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
