<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContapAE
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
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tNCONTACTO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tNOMBRE = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.LtProv = New System.Windows.Forms.Label()
        Me.btnZona = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tDIRECCION = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoContacto = New C1.Win.C1Input.C1ComboBox()
        Me.tEMAIL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tTELEFONO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.btnZona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(633, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 7
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
        'tNCONTACTO
        '
        Me.tNCONTACTO.AcceptsReturn = True
        Me.tNCONTACTO.AcceptsTab = True
        Me.tNCONTACTO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNCONTACTO.Location = New System.Drawing.Point(132, 80)
        Me.tNCONTACTO.Name = "tNCONTACTO"
        Me.tNCONTACTO.Size = New System.Drawing.Size(64, 21)
        Me.tNCONTACTO.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(78, 83)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Contacto"
        '
        'tNOMBRE
        '
        Me.tNOMBRE.AcceptsReturn = True
        Me.tNOMBRE.AcceptsTab = True
        Me.tNOMBRE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOMBRE.Location = New System.Drawing.Point(132, 140)
        Me.tNOMBRE.Name = "tNOMBRE"
        Me.tNOMBRE.Size = New System.Drawing.Size(488, 21)
        Me.tNOMBRE.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(84, 144)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Nombre.TabIndex = 87
        Me.Nombre.Text = "Nombre"
        '
        'LtProv
        '
        Me.LtProv.BackColor = System.Drawing.Color.LightGray
        Me.LtProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtProv.Location = New System.Drawing.Point(225, 111)
        Me.LtProv.Name = "LtProv"
        Me.LtProv.Size = New System.Drawing.Size(395, 20)
        Me.LtProv.TabIndex = 256
        '
        'btnZona
        '
        Me.btnZona.AutoSize = True
        Me.btnZona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZona.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnZona.Location = New System.Drawing.Point(197, 109)
        Me.btnZona.Name = "btnZona"
        Me.btnZona.Size = New System.Drawing.Size(22, 22)
        Me.btnZona.TabIndex = 8
        Me.btnZona.UseVisualStyleBackColor = True
        Me.btnZona.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnZona.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Location = New System.Drawing.Point(132, 110)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(64, 20)
        Me.tCVE_PROV.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(72, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 253
        Me.Label11.Text = "Proveedor"
        '
        'tDIRECCION
        '
        Me.tDIRECCION.AcceptsReturn = True
        Me.tDIRECCION.AcceptsTab = True
        Me.tDIRECCION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDIRECCION.Location = New System.Drawing.Point(132, 170)
        Me.tDIRECCION.Name = "tDIRECCION"
        Me.tDIRECCION.Size = New System.Drawing.Size(383, 21)
        Me.tDIRECCION.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Direccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(55, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 260
        Me.Label4.Text = "Tipo contacto"
        '
        'cboTipoContacto
        '
        Me.cboTipoContacto.AllowSpinLoop = False
        Me.cboTipoContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboTipoContacto.GapHeight = 0
        Me.cboTipoContacto.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboTipoContacto.ItemsDisplayMember = ""
        Me.cboTipoContacto.ItemsValueMember = ""
        Me.cboTipoContacto.Location = New System.Drawing.Point(132, 230)
        Me.cboTipoContacto.Name = "cboTipoContacto"
        Me.cboTipoContacto.Size = New System.Drawing.Size(173, 18)
        Me.cboTipoContacto.TabIndex = 5
        Me.cboTipoContacto.Tag = Nothing
        Me.cboTipoContacto.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboTipoContacto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tEMAIL
        '
        Me.tEMAIL.AcceptsReturn = True
        Me.tEMAIL.AcceptsTab = True
        Me.tEMAIL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEMAIL.Location = New System.Drawing.Point(132, 260)
        Me.tEMAIL.Name = "tEMAIL"
        Me.tEMAIL.Size = New System.Drawing.Size(383, 21)
        Me.tEMAIL.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Correo electronico"
        '
        'tTELEFONO
        '
        Me.tTELEFONO.AcceptsReturn = True
        Me.tTELEFONO.AcceptsTab = True
        Me.tTELEFONO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTELEFONO.Location = New System.Drawing.Point(132, 200)
        Me.tTELEFONO.Name = "tTELEFONO"
        Me.tTELEFONO.Size = New System.Drawing.Size(383, 21)
        Me.tTELEFONO.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Telefono"
        '
        'frmContapAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 311)
        Me.Controls.Add(Me.tTELEFONO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tEMAIL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTipoContacto)
        Me.Controls.Add(Me.tDIRECCION)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtProv)
        Me.Controls.Add(Me.btnZona)
        Me.Controls.Add(Me.tCVE_PROV)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tNCONTACTO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tNOMBRE)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmContapAE"
        Me.Text = "Contactos de proveedores"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.btnZona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tNCONTACTO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tNOMBRE As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents LtProv As Label
    Friend WithEvents btnZona As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tDIRECCION As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTipoContacto As C1.Win.C1Input.C1ComboBox
    Friend WithEvents tEMAIL As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tTELEFONO As TextBox
    Friend WithEvents Label3 As Label
End Class
