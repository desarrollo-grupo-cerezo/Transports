<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmpresas
    Inherits C1.Win.C1Ribbon.C1RibbonForm


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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpresas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChVisible = New System.Windows.Forms.CheckBox()
        Me.CmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.TPass = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TBase = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tServidor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.MnuNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.gridEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridTipoServidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridServidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridBase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridPass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridVisile = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.BarraMenu.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(45, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nombre"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.ChVisible)
        Me.Panel1.Controls.Add(Me.CmdCancelar)
        Me.Panel1.Controls.Add(Me.CmdAceptar)
        Me.Panel1.Controls.Add(Me.TPass)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TUsuario)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TBase)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.tServidor)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cboEmpresa)
        Me.Panel1.Controls.Add(Me.TNombre)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(112, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(646, 305)
        Me.Panel1.TabIndex = 51
        Me.Panel1.Visible = False
        '
        'ChVisible
        '
        Me.ChVisible.AutoSize = True
        Me.ChVisible.Checked = True
        Me.ChVisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChVisible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChVisible.ForeColor = System.Drawing.Color.Transparent
        Me.ChVisible.Location = New System.Drawing.Point(375, 170)
        Me.ChVisible.Name = "ChVisible"
        Me.ChVisible.Size = New System.Drawing.Size(69, 19)
        Me.ChVisible.TabIndex = 68
        Me.ChVisible.Text = "Visible"
        Me.ChVisible.UseVisualStyleBackColor = True
        Me.ChVisible.Visible = False
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Location = New System.Drawing.Point(345, 259)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(94, 30)
        Me.CmdCancelar.TabIndex = 67
        Me.CmdCancelar.Text = "Cancelar"
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Location = New System.Drawing.Point(172, 259)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(108, 30)
        Me.CmdAceptar.TabIndex = 66
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'TPass
        '
        Me.TPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPass.Location = New System.Drawing.Point(104, 170)
        Me.TPass.Name = "TPass"
        Me.TPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TPass.Size = New System.Drawing.Size(228, 22)
        Me.TPass.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(32, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Contraseña"
        '
        'TUsuario
        '
        Me.TUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUsuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuario.Location = New System.Drawing.Point(104, 140)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(228, 22)
        Me.TUsuario.TabIndex = 56
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(52, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 15)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Usuario"
        '
        'TBase
        '
        Me.TBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBase.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBase.Location = New System.Drawing.Point(104, 110)
        Me.TBase.Name = "TBase"
        Me.TBase.Size = New System.Drawing.Size(514, 22)
        Me.TBase.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(17, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Base de datos"
        '
        'tServidor
        '
        Me.tServidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tServidor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tServidor.Location = New System.Drawing.Point(104, 82)
        Me.tServidor.Name = "tServidor"
        Me.tServidor.Size = New System.Drawing.Size(373, 22)
        Me.tServidor.TabIndex = 54
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(50, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Servidor"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(45, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 15)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "Empresa"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(104, 22)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(83, 24)
        Me.cboEmpresa.TabIndex = 51
        '
        'TNombre
        '
        Me.TNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNombre.Location = New System.Drawing.Point(104, 52)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(514, 22)
        Me.TNombre.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(50, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Nombre"
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNuevo, Me.MnuEdit, Me.MnuEliminar, Me.MnuSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(844, 55)
        Me.BarraMenu.TabIndex = 52
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'MnuNuevo
        '
        Me.MnuNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.MnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuNuevo.Name = "MnuNuevo"
        Me.MnuNuevo.Size = New System.Drawing.Size(54, 51)
        Me.MnuNuevo.Text = "Nuevo"
        Me.MnuNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuEdit
        '
        Me.MnuEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.MnuEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.Size = New System.Drawing.Size(70, 51)
        Me.MnuEdit.Text = "Modificar"
        Me.MnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuEliminar
        '
        Me.MnuEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.MnuEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuEliminar.Name = "MnuEliminar"
        Me.MnuEliminar.Size = New System.Drawing.Size(62, 51)
        Me.MnuEliminar.Text = "Eliminar"
        Me.MnuEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuSalir
        '
        Me.MnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.MnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.MnuSalir.Text = "Salir"
        Me.MnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gridEmpresa, Me.gridTipoServidor, Me.gridDescripcion, Me.gridServidor, Me.gridBase, Me.gridUsuario, Me.gridPass, Me.gridVisile})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(816, 380)
        Me.DataGridView1.TabIndex = 53
        '
        'gridEmpresa
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridEmpresa.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridEmpresa.DividerWidth = 1
        Me.gridEmpresa.HeaderText = "Empresa"
        Me.gridEmpresa.Name = "gridEmpresa"
        Me.gridEmpresa.ReadOnly = True
        Me.gridEmpresa.Width = 60
        '
        'gridTipoServidor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridTipoServidor.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridTipoServidor.DividerWidth = 1
        Me.gridTipoServidor.HeaderText = "Tipo servidor"
        Me.gridTipoServidor.Name = "gridTipoServidor"
        Me.gridTipoServidor.ReadOnly = True
        Me.gridTipoServidor.Visible = False
        Me.gridTipoServidor.Width = 70
        '
        'gridDescripcion
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridDescripcion.DefaultCellStyle = DataGridViewCellStyle4
        Me.gridDescripcion.DividerWidth = 1
        Me.gridDescripcion.HeaderText = "Descripción"
        Me.gridDescripcion.Name = "gridDescripcion"
        Me.gridDescripcion.ReadOnly = True
        Me.gridDescripcion.Width = 250
        '
        'gridServidor
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridServidor.DefaultCellStyle = DataGridViewCellStyle5
        Me.gridServidor.DividerWidth = 1
        Me.gridServidor.HeaderText = "Servidor"
        Me.gridServidor.Name = "gridServidor"
        Me.gridServidor.ReadOnly = True
        '
        'gridBase
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridBase.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridBase.DividerWidth = 1
        Me.gridBase.HeaderText = "Base"
        Me.gridBase.Name = "gridBase"
        Me.gridBase.ReadOnly = True
        '
        'gridUsuario
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridUsuario.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridUsuario.DividerWidth = 1
        Me.gridUsuario.HeaderText = "Usuario"
        Me.gridUsuario.Name = "gridUsuario"
        Me.gridUsuario.ReadOnly = True
        Me.gridUsuario.Width = 70
        '
        'gridPass
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.gridPass.DefaultCellStyle = DataGridViewCellStyle8
        Me.gridPass.DividerWidth = 1
        Me.gridPass.HeaderText = "Contraseña"
        Me.gridPass.Name = "gridPass"
        Me.gridPass.ReadOnly = True
        Me.gridPass.Width = 70
        '
        'gridVisile
        '
        Me.gridVisile.HeaderText = "Visible"
        Me.gridVisile.Name = "gridVisile"
        Me.gridVisile.ReadOnly = True
        Me.gridVisile.Visible = False
        Me.gridVisile.Width = 80
        '
        'FrmEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(844, 469)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BarraMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.BarraMenu
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmpresas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TPass As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TBase As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MnuNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents ChVisible As CheckBox
    Friend WithEvents gridEmpresa As DataGridViewTextBoxColumn
    Friend WithEvents gridTipoServidor As DataGridViewTextBoxColumn
    Friend WithEvents gridDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents gridServidor As DataGridViewTextBoxColumn
    Friend WithEvents gridBase As DataGridViewTextBoxColumn
    Friend WithEvents gridUsuario As DataGridViewTextBoxColumn
    Friend WithEvents gridPass As DataGridViewTextBoxColumn
    Friend WithEvents gridVisile As DataGridViewCheckBoxColumn
End Class
