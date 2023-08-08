<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParamOpcGen
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
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.TabGen = New C1.Win.C1Command.C1DockingTabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnXmlCompras = New System.Windows.Forms.Button()
        Me.tRUTA_XML = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnFormatos = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tRUTA_FORMATOS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnModelo = New System.Windows.Forms.Button()
        Me.tRUTA_MODELO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.btnDoc = New System.Windows.Forms.Button()
        Me.tRUTA_IMAGEN = New System.Windows.Forms.TextBox()
        Me.tRUTA_DOC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabTrans = New C1.Win.C1Command.C1DockingTabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboNivelCombustible = New C1.Win.C1Input.C1ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboOTE = New C1.Win.C1Input.C1ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboOT = New C1.Win.C1Input.C1ComboBox()
        Me.chDESC = New C1.Win.C1Input.C1CheckBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.TabGen.SuspendLayout()
        Me.TabTrans.SuspendLayout()
        CType(Me.cboNivelCombustible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chDESC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(662, 54)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.C1ThemeController1.SetTheme(Me.ToolStrip1, "Office2010Blue")
        '
        'barGrabar
        '
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
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
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.TabGen)
        Me.Tab1.Controls.Add(Me.TabTrans)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(0, 54)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(662, 419)
        Me.Tab1.TabIndex = 8
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1ThemeController1.SetTheme(Me.Tab1, "Office2010Blue")
        '
        'TabGen
        '
        Me.TabGen.Controls.Add(Me.Label12)
        Me.TabGen.Controls.Add(Me.BtnXmlCompras)
        Me.TabGen.Controls.Add(Me.tRUTA_XML)
        Me.TabGen.Controls.Add(Me.Label13)
        Me.TabGen.Controls.Add(Me.btnFormatos)
        Me.TabGen.Controls.Add(Me.Label7)
        Me.TabGen.Controls.Add(Me.tRUTA_FORMATOS)
        Me.TabGen.Controls.Add(Me.Label8)
        Me.TabGen.Controls.Add(Me.Label5)
        Me.TabGen.Controls.Add(Me.btnModelo)
        Me.TabGen.Controls.Add(Me.tRUTA_MODELO)
        Me.TabGen.Controls.Add(Me.Label6)
        Me.TabGen.Controls.Add(Me.Label4)
        Me.TabGen.Controls.Add(Me.Label3)
        Me.TabGen.Controls.Add(Me.btnImagen)
        Me.TabGen.Controls.Add(Me.btnDoc)
        Me.TabGen.Controls.Add(Me.tRUTA_IMAGEN)
        Me.TabGen.Controls.Add(Me.tRUTA_DOC)
        Me.TabGen.Controls.Add(Me.Label2)
        Me.TabGen.Controls.Add(Me.Label1)
        Me.TabGen.Location = New System.Drawing.Point(1, 24)
        Me.TabGen.Name = "TabGen"
        Me.TabGen.Size = New System.Drawing.Size(660, 394)
        Me.TabGen.TabIndex = 0
        Me.TabGen.Text = "Generales"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(108, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(158, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "(Por favor capture la ruta lógica)"
        Me.C1ThemeController1.SetTheme(Me.Label12, "Office2010Blue")
        '
        'BtnXmlCompras
        '
        Me.BtnXmlCompras.BackColor = System.Drawing.Color.Transparent
        Me.BtnXmlCompras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnXmlCompras.Location = New System.Drawing.Point(571, 65)
        Me.BtnXmlCompras.Name = "BtnXmlCompras"
        Me.BtnXmlCompras.Size = New System.Drawing.Size(27, 23)
        Me.BtnXmlCompras.TabIndex = 20
        Me.BtnXmlCompras.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.BtnXmlCompras, "Office2010Blue")
        Me.BtnXmlCompras.UseVisualStyleBackColor = True
        '
        'tRUTA_XML
        '
        Me.tRUTA_XML.AcceptsReturn = True
        Me.tRUTA_XML.AcceptsTab = True
        Me.tRUTA_XML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRUTA_XML.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA_XML.ForeColor = System.Drawing.Color.Black
        Me.tRUTA_XML.Location = New System.Drawing.Point(102, 94)
        Me.tRUTA_XML.Name = "tRUTA_XML"
        Me.tRUTA_XML.Size = New System.Drawing.Size(496, 21)
        Me.tRUTA_XML.TabIndex = 1
        Me.C1ThemeController1.SetTheme(Me.tRUTA_XML, "Office2010Blue")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(43, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Ruta XML"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2010Blue")
        '
        'btnFormatos
        '
        Me.btnFormatos.BackColor = System.Drawing.Color.Transparent
        Me.btnFormatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnFormatos.Location = New System.Drawing.Point(568, 244)
        Me.btnFormatos.Name = "btnFormatos"
        Me.btnFormatos.Size = New System.Drawing.Size(27, 23)
        Me.btnFormatos.TabIndex = 17
        Me.btnFormatos.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.btnFormatos, "Office2010Blue")
        Me.btnFormatos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(108, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "(Por favor capture la ruta lógica)"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2010Blue")
        '
        'tRUTA_FORMATOS
        '
        Me.tRUTA_FORMATOS.AcceptsReturn = True
        Me.tRUTA_FORMATOS.AcceptsTab = True
        Me.tRUTA_FORMATOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRUTA_FORMATOS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA_FORMATOS.ForeColor = System.Drawing.Color.Black
        Me.tRUTA_FORMATOS.Location = New System.Drawing.Point(102, 270)
        Me.tRUTA_FORMATOS.Name = "tRUTA_FORMATOS"
        Me.tRUTA_FORMATOS.Size = New System.Drawing.Size(496, 21)
        Me.tRUTA_FORMATOS.TabIndex = 4
        Me.C1ThemeController1.SetTheme(Me.tRUTA_FORMATOS, "Office2010Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(25, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ruta formatos"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2010Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(108, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "(Por favor capture la ruta lógica)"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2010Blue")
        '
        'btnModelo
        '
        Me.btnModelo.BackColor = System.Drawing.Color.Transparent
        Me.btnModelo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnModelo.Location = New System.Drawing.Point(572, 185)
        Me.btnModelo.Name = "btnModelo"
        Me.btnModelo.Size = New System.Drawing.Size(27, 23)
        Me.btnModelo.TabIndex = 12
        Me.btnModelo.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.btnModelo, "Office2010Blue")
        Me.btnModelo.UseVisualStyleBackColor = True
        '
        'tRUTA_MODELO
        '
        Me.tRUTA_MODELO.AcceptsReturn = True
        Me.tRUTA_MODELO.AcceptsTab = True
        Me.tRUTA_MODELO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRUTA_MODELO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA_MODELO.ForeColor = System.Drawing.Color.Black
        Me.tRUTA_MODELO.Location = New System.Drawing.Point(102, 211)
        Me.tRUTA_MODELO.Name = "tRUTA_MODELO"
        Me.tRUTA_MODELO.Size = New System.Drawing.Size(496, 21)
        Me.tRUTA_MODELO.TabIndex = 3
        Me.C1ThemeController1.SetTheme(Me.tRUTA_MODELO, "Office2010Blue")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(31, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Ruta modelo"
        Me.C1ThemeController1.SetTheme(Me.Label6, "Office2010Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(108, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "(Por favor capture la ruta lógica)"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2010Blue")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(108, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "(Por favor capture la ruta lógica, ejemplo : \\DACASPEL\)"
        Me.C1ThemeController1.SetTheme(Me.Label3, "Office2010Blue")
        '
        'btnImagen
        '
        Me.btnImagen.BackColor = System.Drawing.Color.Transparent
        Me.btnImagen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnImagen.Location = New System.Drawing.Point(571, 124)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(27, 23)
        Me.btnImagen.TabIndex = 7
        Me.btnImagen.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.btnImagen, "Office2010Blue")
        Me.btnImagen.UseVisualStyleBackColor = True
        '
        'btnDoc
        '
        Me.btnDoc.BackColor = System.Drawing.Color.Transparent
        Me.btnDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnDoc.Location = New System.Drawing.Point(571, 8)
        Me.btnDoc.Name = "btnDoc"
        Me.btnDoc.Size = New System.Drawing.Size(27, 23)
        Me.btnDoc.TabIndex = 6
        Me.btnDoc.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.btnDoc, "Office2010Blue")
        Me.btnDoc.UseVisualStyleBackColor = True
        '
        'tRUTA_IMAGEN
        '
        Me.tRUTA_IMAGEN.AcceptsReturn = True
        Me.tRUTA_IMAGEN.AcceptsTab = True
        Me.tRUTA_IMAGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRUTA_IMAGEN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA_IMAGEN.ForeColor = System.Drawing.Color.Black
        Me.tRUTA_IMAGEN.Location = New System.Drawing.Point(102, 153)
        Me.tRUTA_IMAGEN.Name = "tRUTA_IMAGEN"
        Me.tRUTA_IMAGEN.Size = New System.Drawing.Size(496, 21)
        Me.tRUTA_IMAGEN.TabIndex = 2
        Me.C1ThemeController1.SetTheme(Me.tRUTA_IMAGEN, "Office2010Blue")
        '
        'tRUTA_DOC
        '
        Me.tRUTA_DOC.AcceptsReturn = True
        Me.tRUTA_DOC.AcceptsTab = True
        Me.tRUTA_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRUTA_DOC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA_DOC.ForeColor = System.Drawing.Color.Black
        Me.tRUTA_DOC.Location = New System.Drawing.Point(102, 34)
        Me.tRUTA_DOC.Name = "tRUTA_DOC"
        Me.tRUTA_DOC.Size = New System.Drawing.Size(496, 21)
        Me.tRUTA_DOC.TabIndex = 0
        Me.C1ThemeController1.SetTheme(Me.tRUTA_DOC, "Office2010Blue")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ruta imagenes"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2010Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta documentos"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2010Blue")
        '
        'TabTrans
        '
        Me.TabTrans.Controls.Add(Me.Label11)
        Me.TabTrans.Controls.Add(Me.cboNivelCombustible)
        Me.TabTrans.Controls.Add(Me.Label10)
        Me.TabTrans.Controls.Add(Me.cboOTE)
        Me.TabTrans.Controls.Add(Me.Label9)
        Me.TabTrans.Controls.Add(Me.cboOT)
        Me.TabTrans.Location = New System.Drawing.Point(1, 24)
        Me.TabTrans.Name = "TabTrans"
        Me.TabTrans.Size = New System.Drawing.Size(660, 394)
        Me.TabTrans.TabIndex = 3
        Me.TabTrans.Text = "Transporte"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(50, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 15)
        Me.Label11.TabIndex = 321
        Me.Label11.Text = "Nivel de combustible"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2010Blue")
        '
        'cboNivelCombustible
        '
        Me.cboNivelCombustible.AllowSpinLoop = False
        Me.cboNivelCombustible.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboNivelCombustible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboNivelCombustible.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboNivelCombustible.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboNivelCombustible.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboNivelCombustible.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNivelCombustible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboNivelCombustible.GapHeight = 0
        Me.cboNivelCombustible.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboNivelCombustible.ItemsDisplayMember = ""
        Me.cboNivelCombustible.ItemsValueMember = ""
        Me.cboNivelCombustible.Location = New System.Drawing.Point(200, 112)
        Me.cboNivelCombustible.Name = "cboNivelCombustible"
        Me.cboNivelCombustible.Size = New System.Drawing.Size(218, 21)
        Me.cboNivelCombustible.TabIndex = 320
        Me.cboNivelCombustible.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboNivelCombustible, "Office2010Blue")
        Me.cboNivelCombustible.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(50, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 15)
        Me.Label10.TabIndex = 319
        Me.Label10.Text = "Orden de trabajo externa"
        Me.C1ThemeController1.SetTheme(Me.Label10, "Office2010Blue")
        '
        'cboOTE
        '
        Me.cboOTE.AllowSpinLoop = False
        Me.cboOTE.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboOTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboOTE.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboOTE.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboOTE.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboOTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboOTE.GapHeight = 0
        Me.cboOTE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboOTE.ItemsDisplayMember = ""
        Me.cboOTE.ItemsValueMember = ""
        Me.cboOTE.Location = New System.Drawing.Point(200, 69)
        Me.cboOTE.Name = "cboOTE"
        Me.cboOTE.Size = New System.Drawing.Size(218, 21)
        Me.cboOTE.TabIndex = 318
        Me.cboOTE.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboOTE, "Office2010Blue")
        Me.cboOTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(53, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 15)
        Me.Label9.TabIndex = 317
        Me.Label9.Text = "Orden de trabajo interna"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2010Blue")
        '
        'cboOT
        '
        Me.cboOT.AllowSpinLoop = False
        Me.cboOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.cboOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboOT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboOT.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.cboOT.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.cboOT.GapHeight = 0
        Me.cboOT.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboOT.ItemsDisplayMember = ""
        Me.cboOT.ItemsValueMember = ""
        Me.cboOT.Location = New System.Drawing.Point(200, 28)
        Me.cboOT.Name = "cboOT"
        Me.cboOT.Size = New System.Drawing.Size(218, 21)
        Me.cboOT.TabIndex = 316
        Me.cboOT.Tag = Nothing
        Me.C1ThemeController1.SetTheme(Me.cboOT, "Office2010Blue")
        Me.cboOT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chDESC
        '
        Me.chDESC.BackColor = System.Drawing.Color.Transparent
        Me.chDESC.BorderColor = System.Drawing.Color.Transparent
        Me.chDESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chDESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chDESC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.chDESC.Location = New System.Drawing.Point(32, 13)
        Me.chDESC.Name = "chDESC"
        Me.chDESC.Padding = New System.Windows.Forms.Padding(4, 1, 1, 1)
        Me.chDESC.Size = New System.Drawing.Size(218, 24)
        Me.chDESC.TabIndex = 323
        Me.chDESC.Text = "DESC"
        Me.C1ThemeController1.SetTheme(Me.chDESC, "Office2010Blue")
        Me.chDESC.UseVisualStyleBackColor = True
        Me.chDESC.Value = Nothing
        Me.chDESC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmParamGenerales
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(662, 473)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmParamGenerales"
        Me.ShowInTaskbar = False
        Me.Text = "Parametros Generales"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.TabGen.ResumeLayout(False)
        Me.TabGen.PerformLayout()
        Me.TabTrans.ResumeLayout(False)
        Me.TabTrans.PerformLayout()
        CType(Me.cboNivelCombustible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chDESC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barGrabar As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents TabGen As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tRUTA_IMAGEN As TextBox
    Friend WithEvents tRUTA_DOC As TextBox
    Friend WithEvents btnDoc As Button
    Friend WithEvents btnImagen As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnModelo As Button
    Friend WithEvents tRUTA_MODELO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnFormatos As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents tRUTA_FORMATOS As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TabTrans As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents cboOT As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboOTE As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboNivelCombustible As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BtnXmlCompras As Button
    Friend WithEvents tRUTA_XML As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents chDESC As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
