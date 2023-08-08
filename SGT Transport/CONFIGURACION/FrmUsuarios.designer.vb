<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUSUARIOS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUSUARIOS))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBorrarHuella = New C1.Win.C1Input.C1Button()
        Me.BtnVerificarHuella = New C1.Win.C1Input.C1Button()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BtnCaptutaHuellas = New C1.Win.C1Input.C1Button()
        Me.BtnQuitarFoto = New C1.Win.C1Input.C1Button()
        Me.BtnSelFoto = New C1.Win.C1Input.C1Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TPASS_ALTERNA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCLAVE_SAE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.CboNivel = New System.Windows.Forms.ComboBox()
        Me.TPass = New System.Windows.Forms.TextBox()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.FgU = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BarraMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.BtnBorrarHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnVerificarHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCaptutaHuellas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnQuitarFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSelFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag3.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarNuevo, Me.BarEdit, Me.BarEliminar, Me.BarSalir2})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1340, 55)
        Me.BarraMenu.TabIndex = 1
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarNuevo
        '
        Me.BarNuevo.ForeColor = System.Drawing.Color.Black
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.Size = New System.Drawing.Size(54, 51)
        Me.BarNuevo.Text = "Nuevo"
        Me.BarNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEdit
        '
        Me.BarEdit.ForeColor = System.Drawing.Color.Black
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.Size = New System.Drawing.Size(70, 51)
        Me.BarEdit.Text = "Modificar"
        Me.BarEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEliminar
        '
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.Size = New System.Drawing.Size(62, 51)
        Me.BarEliminar.Text = "Eliminar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir2
        '
        Me.BarSalir2.ForeColor = System.Drawing.Color.Black
        Me.BarSalir2.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir2.Name = "BarSalir2"
        Me.BarSalir2.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir2.Text = "Salir"
        Me.BarSalir2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnBorrarHuella)
        Me.Panel1.Controls.Add(Me.BtnVerificarHuella)
        Me.Panel1.Controls.Add(Me.C1ToolBar1)
        Me.Panel1.Controls.Add(Me.BtnCaptutaHuellas)
        Me.Panel1.Controls.Add(Me.BtnQuitarFoto)
        Me.Panel1.Controls.Add(Me.BtnSelFoto)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.Tab1)
        Me.Panel1.Controls.Add(Me.TPASS_ALTERNA)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TCLAVE_SAE)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Lt4)
        Me.Panel1.Controls.Add(Me.CboNivel)
        Me.Panel1.Controls.Add(Me.TPass)
        Me.Panel1.Controls.Add(Me.Lt3)
        Me.Panel1.Controls.Add(Me.TNombre)
        Me.Panel1.Controls.Add(Me.Lt2)
        Me.Panel1.Controls.Add(Me.TUsuario)
        Me.Panel1.Controls.Add(Me.Lt1)
        Me.Panel1.Location = New System.Drawing.Point(52, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1076, 517)
        Me.Panel1.TabIndex = 81
        Me.Panel1.Visible = False
        '
        'BtnBorrarHuella
        '
        Me.BtnBorrarHuella.BackColor = System.Drawing.Color.White
        Me.BtnBorrarHuella.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnBorrarHuella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBorrarHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrarHuella.Image = Global.SGT_Transport.My.Resources.Resources.huella21
        Me.BtnBorrarHuella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBorrarHuella.Location = New System.Drawing.Point(302, 432)
        Me.BtnBorrarHuella.Name = "BtnBorrarHuella"
        Me.BtnBorrarHuella.Size = New System.Drawing.Size(161, 41)
        Me.BtnBorrarHuella.TabIndex = 10
        Me.BtnBorrarHuella.Text = "Borrar huella"
        Me.BtnBorrarHuella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBorrarHuella.UseVisualStyleBackColor = False
        '
        'BtnVerificarHuella
        '
        Me.BtnVerificarHuella.BackColor = System.Drawing.Color.White
        Me.BtnVerificarHuella.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnVerificarHuella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVerificarHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerificarHuella.Image = Global.SGT_Transport.My.Resources.Resources.huella18
        Me.BtnVerificarHuella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVerificarHuella.Location = New System.Drawing.Point(302, 387)
        Me.BtnVerificarHuella.Name = "BtnVerificarHuella"
        Me.BtnVerificarHuella.Size = New System.Drawing.Size(161, 41)
        Me.BtnVerificarHuella.TabIndex = 9
        Me.BtnVerificarHuella.Text = "Verificar huella"
        Me.BtnVerificarHuella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVerificarHuella.UseVisualStyleBackColor = False
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(1074, 43)
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
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
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
        'BtnCaptutaHuellas
        '
        Me.BtnCaptutaHuellas.BackColor = System.Drawing.Color.White
        Me.BtnCaptutaHuellas.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnCaptutaHuellas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCaptutaHuellas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCaptutaHuellas.Image = Global.SGT_Transport.My.Resources.Resources.huella12_e
        Me.BtnCaptutaHuellas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCaptutaHuellas.Location = New System.Drawing.Point(302, 342)
        Me.BtnCaptutaHuellas.Name = "BtnCaptutaHuellas"
        Me.BtnCaptutaHuellas.Size = New System.Drawing.Size(161, 41)
        Me.BtnCaptutaHuellas.TabIndex = 8
        Me.BtnCaptutaHuellas.Text = "Captura huellas"
        Me.BtnCaptutaHuellas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCaptutaHuellas.UseVisualStyleBackColor = False
        '
        'BtnQuitarFoto
        '
        Me.BtnQuitarFoto.BackColor = System.Drawing.Color.White
        Me.BtnQuitarFoto.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnQuitarFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitarFoto.Image = Global.SGT_Transport.My.Resources.Resources.equis2
        Me.BtnQuitarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuitarFoto.Location = New System.Drawing.Point(302, 297)
        Me.BtnQuitarFoto.Name = "BtnQuitarFoto"
        Me.BtnQuitarFoto.Size = New System.Drawing.Size(161, 41)
        Me.BtnQuitarFoto.TabIndex = 7
        Me.BtnQuitarFoto.Text = "Quitar foto"
        Me.BtnQuitarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuitarFoto.UseVisualStyleBackColor = False
        '
        'BtnSelFoto
        '
        Me.BtnSelFoto.BackColor = System.Drawing.Color.White
        Me.BtnSelFoto.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnSelFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelFoto.Image = Global.SGT_Transport.My.Resources.Resources.pic1_e
        Me.BtnSelFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSelFoto.Location = New System.Drawing.Point(302, 252)
        Me.BtnSelFoto.Name = "BtnSelFoto"
        Me.BtnSelFoto.Size = New System.Drawing.Size(161, 41)
        Me.BtnSelFoto.TabIndex = 6
        Me.BtnSelFoto.Text = "Seleccionar foto"
        Me.BtnSelFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSelFoto.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Image = Global.SGT_Transport.My.Resources.Resources.picx1
        Me.PictureBox5.InitialImage = Global.SGT_Transport.My.Resources.Resources.picx1
        Me.PictureBox5.Location = New System.Drawing.Point(57, 273)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(171, 200)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 118
        Me.PictureBox5.TabStop = False
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Location = New System.Drawing.Point(511, 61)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(552, 451)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabsSpacing = 5
        '
        'Pag3
        '
        Me.Pag3.Controls.Add(Me.Fg)
        Me.Pag3.Location = New System.Drawing.Point(1, 24)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(550, 426)
        Me.Pag3.TabIndex = 0
        Me.Pag3.Text = "Parámetros"
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 23
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(502, 326)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 1
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.Fg2)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(550, 426)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Empresas"
        '
        'Fg2
        '
        Me.Fg2.AllowFiltering = True
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.Location = New System.Drawing.Point(3, 3)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.Rows.DefaultSize = 22
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(528, 351)
        Me.Fg2.StyleInfo = resources.GetString("Fg2.StyleInfo")
        Me.Fg2.TabIndex = 0
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'TPASS_ALTERNA
        '
        Me.TPASS_ALTERNA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPASS_ALTERNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPASS_ALTERNA.Location = New System.Drawing.Point(376, 128)
        Me.TPASS_ALTERNA.Name = "TPASS_ALTERNA"
        Me.TPASS_ALTERNA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TPASS_ALTERNA.Size = New System.Drawing.Size(125, 23)
        Me.TPASS_ALTERNA.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(222, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 17)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Contraseña alternativa"
        '
        'TCLAVE_SAE
        '
        Me.TCLAVE_SAE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLAVE_SAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE_SAE.Location = New System.Drawing.Point(89, 187)
        Me.TCLAVE_SAE.Name = "TCLAVE_SAE"
        Me.TCLAVE_SAE.Size = New System.Drawing.Size(125, 23)
        Me.TCLAVE_SAE.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Clave"
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.BackColor = System.Drawing.Color.Transparent
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.ForeColor = System.Drawing.Color.White
        Me.Lt4.Location = New System.Drawing.Point(45, 160)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(39, 17)
        Me.Lt4.TabIndex = 92
        Me.Lt4.Text = "Nivel"
        '
        'CboNivel
        '
        Me.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboNivel.FormattingEnabled = True
        Me.CboNivel.Items.AddRange(New Object() {"Administrador", "Secretarial", "Supervisor"})
        Me.CboNivel.Location = New System.Drawing.Point(89, 157)
        Me.CboNivel.Name = "CboNivel"
        Me.CboNivel.Size = New System.Drawing.Size(139, 24)
        Me.CboNivel.TabIndex = 3
        '
        'TPass
        '
        Me.TPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPass.Location = New System.Drawing.Point(89, 128)
        Me.TPass.Name = "TPass"
        Me.TPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TPass.Size = New System.Drawing.Size(125, 23)
        Me.TPass.TabIndex = 2
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.Transparent
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.White
        Me.Lt3.Location = New System.Drawing.Point(3, 131)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(81, 17)
        Me.Lt3.TabIndex = 88
        Me.Lt3.Text = "Contraseña"
        '
        'TNombre
        '
        Me.TNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNombre.Location = New System.Drawing.Point(89, 100)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(412, 23)
        Me.TNombre.TabIndex = 1
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.Transparent
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.White
        Me.Lt2.Location = New System.Drawing.Point(26, 104)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(58, 17)
        Me.Lt2.TabIndex = 87
        Me.Lt2.Text = "Nombre"
        '
        'TUsuario
        '
        Me.TUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuario.Location = New System.Drawing.Point(89, 72)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(172, 23)
        Me.TUsuario.TabIndex = 0
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.Transparent
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.White
        Me.Lt1.Location = New System.Drawing.Point(27, 75)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(57, 17)
        Me.Lt1.TabIndex = 86
        Me.Lt1.Text = "Usuario"
        '
        'FgU
        '
        Me.FgU.AllowEditing = False
        Me.FgU.AllowFiltering = True
        Me.FgU.BackColor = System.Drawing.Color.White
        Me.FgU.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgU.ColumnInfo = resources.GetString("FgU.ColumnInfo")
        Me.FgU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgU.ForeColor = System.Drawing.Color.Black
        Me.FgU.Location = New System.Drawing.Point(5, 58)
        Me.FgU.Name = "FgU"
        Me.FgU.Rows.DefaultSize = 19
        Me.FgU.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgU.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgU.Size = New System.Drawing.Size(1325, 423)
        Me.FgU.StyleInfo = resources.GetString("FgU.StyleInfo")
        Me.FgU.TabIndex = 82
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmUSUARIOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 607)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FgU)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUSUARIOS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BtnBorrarHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnVerificarHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCaptutaHuellas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnQuitarFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSelFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag3.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents BarNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarSalir2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TPass As System.Windows.Forms.TextBox
    Friend WithEvents Lt3 As System.Windows.Forms.Label
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents Lt2 As System.Windows.Forms.Label
    Friend WithEvents TUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Lt1 As System.Windows.Forms.Label
    Friend WithEvents Lt4 As System.Windows.Forms.Label
    Friend WithEvents CboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents TCLAVE_SAE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FgU As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TPASS_ALTERNA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents PictureBox5 As PictureBox
    Friend WithEvents BtnCaptutaHuellas As C1.Win.C1Input.C1Button
    Friend WithEvents BtnQuitarFoto As C1.Win.C1Input.C1Button
    Friend WithEvents BtnSelFoto As C1.Win.C1Input.C1Button
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BtnVerificarHuella As C1.Win.C1Input.C1Button
    Friend WithEvents BtnBorrarHuella As C1.Win.C1Input.C1Button
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Private WithEvents BarGrabar As C1.Win.C1Command.C1Command
End Class
