<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBancosAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_BANCO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCalle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCiudad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tTelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tCorreo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tRFC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tCTA_BANCARIA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tEJECUTIVO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tSALDO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tALIAS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tCLABE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tSUCURSAL = New System.Windows.Forms.TextBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.BarraMenu.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.MnuSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(596, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 14
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuSalir
        '
        Me.MnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MnuSalir.ForeColor = System.Drawing.Color.Black
        Me.MnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.MnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.MnuSalir.Text = "Salir"
        Me.MnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_BANCO
        '
        Me.tCVE_BANCO.AcceptsReturn = True
        Me.tCVE_BANCO.AcceptsTab = True
        Me.tCVE_BANCO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_BANCO.Location = New System.Drawing.Point(111, 90)
        Me.tCVE_BANCO.MaxLength = 10
        Me.tCVE_BANCO.Name = "tCVE_BANCO"
        Me.tCVE_BANCO.Size = New System.Drawing.Size(110, 21)
        Me.tCVE_BANCO.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(73, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(111, 115)
        Me.tDescr.MaxLength = 90
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(414, 21)
        Me.tDescr.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(63, 116)
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
        'tCalle
        '
        Me.tCalle.AcceptsReturn = True
        Me.tCalle.AcceptsTab = True
        Me.tCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCalle.Location = New System.Drawing.Point(111, 340)
        Me.tCalle.MaxLength = 120
        Me.tCalle.Name = "tCalle"
        Me.tCalle.Size = New System.Drawing.Size(414, 21)
        Me.tCalle.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Calle"
        '
        'tCiudad
        '
        Me.tCiudad.AcceptsReturn = True
        Me.tCiudad.AcceptsTab = True
        Me.tCiudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCiudad.Location = New System.Drawing.Point(111, 365)
        Me.tCiudad.MaxLength = 60
        Me.tCiudad.Name = "tCiudad"
        Me.tCiudad.Size = New System.Drawing.Size(289, 21)
        Me.tCiudad.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 369)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Ciudad"
        '
        'tTelefono
        '
        Me.tTelefono.AcceptsReturn = True
        Me.tTelefono.AcceptsTab = True
        Me.tTelefono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTelefono.Location = New System.Drawing.Point(111, 390)
        Me.tTelefono.MaxLength = 60
        Me.tTelefono.Name = "tTelefono"
        Me.tTelefono.Size = New System.Drawing.Size(289, 21)
        Me.tTelefono.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 394)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Telefono"
        '
        'tCorreo
        '
        Me.tCorreo.AcceptsReturn = True
        Me.tCorreo.AcceptsTab = True
        Me.tCorreo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCorreo.Location = New System.Drawing.Point(111, 415)
        Me.tCorreo.MaxLength = 60
        Me.tCorreo.Name = "tCorreo"
        Me.tCorreo.Size = New System.Drawing.Size(414, 21)
        Me.tCorreo.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 419)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Correo"
        '
        'tRFC
        '
        Me.tRFC.AcceptsReturn = True
        Me.tRFC.AcceptsTab = True
        Me.tRFC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRFC.Location = New System.Drawing.Point(111, 315)
        Me.tRFC.MaxLength = 20
        Me.tRFC.Name = "tRFC"
        Me.tRFC.Size = New System.Drawing.Size(135, 21)
        Me.tRFC.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 319)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "R.F.C."
        '
        'tCTA_BANCARIA
        '
        Me.tCTA_BANCARIA.AcceptsReturn = True
        Me.tCTA_BANCARIA.AcceptsTab = True
        Me.tCTA_BANCARIA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCTA_BANCARIA.Location = New System.Drawing.Point(111, 140)
        Me.tCTA_BANCARIA.MaxLength = 60
        Me.tCTA_BANCARIA.Name = "tCTA_BANCARIA"
        Me.tCTA_BANCARIA.Size = New System.Drawing.Size(289, 21)
        Me.tCTA_BANCARIA.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Cuenta bancaria"
        '
        'tEJECUTIVO
        '
        Me.tEJECUTIVO.AcceptsReturn = True
        Me.tEJECUTIVO.AcceptsTab = True
        Me.tEJECUTIVO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEJECUTIVO.Location = New System.Drawing.Point(111, 240)
        Me.tEJECUTIVO.MaxLength = 120
        Me.tEJECUTIVO.Name = "tEJECUTIVO"
        Me.tEJECUTIVO.Size = New System.Drawing.Size(414, 21)
        Me.tEJECUTIVO.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Ejecutivo"
        '
        'tSALDO
        '
        Me.tSALDO.AcceptsReturn = True
        Me.tSALDO.AcceptsTab = True
        Me.tSALDO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSALDO.Location = New System.Drawing.Point(111, 215)
        Me.tSALDO.Name = "tSALDO"
        Me.tSALDO.Size = New System.Drawing.Size(135, 21)
        Me.tSALDO.TabIndex = 5
        Me.tSALDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(44, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "Saldo inicial"
        '
        'tALIAS
        '
        Me.tALIAS.AcceptsReturn = True
        Me.tALIAS.AcceptsTab = True
        Me.tALIAS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tALIAS.Location = New System.Drawing.Point(111, 265)
        Me.tALIAS.MaxLength = 60
        Me.tALIAS.Name = "tALIAS"
        Me.tALIAS.Size = New System.Drawing.Size(414, 21)
        Me.tALIAS.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Fecha apertura"
        '
        'tCLABE
        '
        Me.tCLABE.AcceptsReturn = True
        Me.tCLABE.AcceptsTab = True
        Me.tCLABE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLABE.Location = New System.Drawing.Point(111, 165)
        Me.tCLABE.MaxLength = 80
        Me.tCLABE.Name = "tCLABE"
        Me.tCLABE.Size = New System.Drawing.Size(289, 21)
        Me.tCLABE.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(66, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "CLABE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(59, 295)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Sucursal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(78, 270)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 139
        Me.Label12.Text = "Alias"
        '
        'tSUCURSAL
        '
        Me.tSUCURSAL.AcceptsReturn = True
        Me.tSUCURSAL.AcceptsTab = True
        Me.tSUCURSAL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUCURSAL.Location = New System.Drawing.Point(111, 290)
        Me.tSUCURSAL.MaxLength = 80
        Me.tSUCURSAL.Name = "tSUCURSAL"
        Me.tSUCURSAL.Size = New System.Drawing.Size(414, 21)
        Me.tSUCURSAL.TabIndex = 8
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(111, 193)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(138, 19)
        Me.F1.TabIndex = 301
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'frmBancosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 462)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.tSUCURSAL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tCTA_BANCARIA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tEJECUTIVO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tSALDO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tALIAS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tCLABE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tRFC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tCorreo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tTelefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tCiudad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCalle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_BANCO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBancosAE"
        Me.ShowInTaskbar = False
        Me.Text = "Banco"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents BarGrabar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tCVE_BANCO As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tDescr As System.Windows.Forms.TextBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCalle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tCiudad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tCTA_BANCARIA As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tEJECUTIVO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tSALDO As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tALIAS As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tCLABE As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tSUCURSAL As TextBox
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
End Class
