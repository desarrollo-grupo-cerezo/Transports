<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductosAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_PROD = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.PanelMatPeligro = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LTCveMaterialPeligroso = New System.Windows.Forms.Label()
        Me.LTEmbalaje = New System.Windows.Forms.Label()
        Me.BtnCveMaterialPeligroso = New System.Windows.Forms.Button()
        Me.BtnEmbalaje = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TEmbalaje = New System.Windows.Forms.TextBox()
        Me.TCveMaterialPeligroso = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TBienesTransp = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.TUnidadPeso = New System.Windows.Forms.TextBox()
        Me.BtnUnidadPeso = New System.Windows.Forms.Button()
        Me.LTBienesTransp = New System.Windows.Forms.Label()
        Me.LTUnidadPeso = New System.Windows.Forms.Label()
        Me.BtnBienesTransp = New System.Windows.Forms.Button()
        Me.CboMatPeligroso = New C1.Win.C1Input.C1ComboBox()
        Me.BarraMenu.SuspendLayout()
        Me.PanelMatPeligro.SuspendLayout()
        CType(Me.CboMatPeligroso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(733, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 2
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.Black
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = CType(resources.GetObject("BarSalir.Image"), System.Drawing.Image)
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_PROD
        '
        Me.tCVE_PROD.AcceptsReturn = True
        Me.tCVE_PROD.AcceptsTab = True
        Me.tCVE_PROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROD.Location = New System.Drawing.Point(172, 67)
        Me.tCVE_PROD.Name = "tCVE_PROD"
        Me.tCVE_PROD.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_PROD.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(125, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 16)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Clave"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(172, 95)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(451, 22)
        Me.tDescr.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(111, 98)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(56, 16)
        Me.Nombre.TabIndex = 87
        Me.Nombre.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tCUEN_CONT
        '
        Me.tCUEN_CONT.AcceptsReturn = True
        Me.tCUEN_CONT.AcceptsTab = True
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.Location = New System.Drawing.Point(172, 123)
        Me.tCUEN_CONT.MaxLength = 28
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 22)
        Me.tCUEN_CONT.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 322
        Me.Label4.Text = "Cuenta contable"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(52, 250)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(115, 16)
        Me.Label53.TabIndex = 334
        Me.Label53.Text = "Material peligroso"
        '
        'PanelMatPeligro
        '
        Me.PanelMatPeligro.Controls.Add(Me.Label15)
        Me.PanelMatPeligro.Controls.Add(Me.LTCveMaterialPeligroso)
        Me.PanelMatPeligro.Controls.Add(Me.LTEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.BtnCveMaterialPeligroso)
        Me.PanelMatPeligro.Controls.Add(Me.BtnEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.Label18)
        Me.PanelMatPeligro.Controls.Add(Me.TEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.TCveMaterialPeligroso)
        Me.PanelMatPeligro.Location = New System.Drawing.Point(7, 275)
        Me.PanelMatPeligro.Name = "PanelMatPeligro"
        Me.PanelMatPeligro.Size = New System.Drawing.Size(683, 64)
        Me.PanelMatPeligro.TabIndex = 332
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(153, 16)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "*Cve. material peligroso "
        '
        'LTCveMaterialPeligroso
        '
        Me.LTCveMaterialPeligroso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTCveMaterialPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTCveMaterialPeligroso.Location = New System.Drawing.Point(256, 5)
        Me.LTCveMaterialPeligroso.Name = "LTCveMaterialPeligroso"
        Me.LTCveMaterialPeligroso.Size = New System.Drawing.Size(369, 23)
        Me.LTCveMaterialPeligroso.TabIndex = 111
        '
        'LTEmbalaje
        '
        Me.LTEmbalaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTEmbalaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTEmbalaje.Location = New System.Drawing.Point(256, 35)
        Me.LTEmbalaje.Name = "LTEmbalaje"
        Me.LTEmbalaje.Size = New System.Drawing.Size(369, 23)
        Me.LTEmbalaje.TabIndex = 48
        '
        'BtnCveMaterialPeligroso
        '
        Me.BtnCveMaterialPeligroso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCveMaterialPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCveMaterialPeligroso.Image = Global.SGT_Transport.My.Resources.Resources.lupu31
        Me.BtnCveMaterialPeligroso.Location = New System.Drawing.Point(227, 5)
        Me.BtnCveMaterialPeligroso.Name = "BtnCveMaterialPeligroso"
        Me.BtnCveMaterialPeligroso.Size = New System.Drawing.Size(23, 23)
        Me.BtnCveMaterialPeligroso.TabIndex = 103
        Me.BtnCveMaterialPeligroso.UseVisualStyleBackColor = True
        '
        'BtnEmbalaje
        '
        Me.BtnEmbalaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEmbalaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmbalaje.Image = Global.SGT_Transport.My.Resources.Resources.lupu31
        Me.BtnEmbalaje.Location = New System.Drawing.Point(227, 37)
        Me.BtnEmbalaje.Name = "BtnEmbalaje"
        Me.BtnEmbalaje.Size = New System.Drawing.Size(23, 23)
        Me.BtnEmbalaje.TabIndex = 102
        Me.BtnEmbalaje.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(84, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 16)
        Me.Label18.TabIndex = 61
        Me.Label18.Text = "*Embalaje"
        '
        'TEmbalaje
        '
        Me.TEmbalaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEmbalaje.Location = New System.Drawing.Point(165, 37)
        Me.TEmbalaje.Name = "TEmbalaje"
        Me.TEmbalaje.Size = New System.Drawing.Size(56, 22)
        Me.TEmbalaje.TabIndex = 8
        '
        'TCveMaterialPeligroso
        '
        Me.TCveMaterialPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCveMaterialPeligroso.Location = New System.Drawing.Point(165, 6)
        Me.TCveMaterialPeligroso.Name = "TCveMaterialPeligroso"
        Me.TCveMaterialPeligroso.Size = New System.Drawing.Size(56, 22)
        Me.TCveMaterialPeligroso.TabIndex = 7
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(88, 220)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(79, 16)
        Me.Label40.TabIndex = 331
        Me.Label40.Text = "Descripción"
        '
        'TBienesTransp
        '
        Me.TBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBienesTransp.Location = New System.Drawing.Point(172, 184)
        Me.TBienesTransp.Name = "TBienesTransp"
        Me.TBienesTransp.Size = New System.Drawing.Size(103, 22)
        Me.TBienesTransp.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(70, 187)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 16)
        Me.Label20.TabIndex = 326
        Me.Label20.Text = "*Bienes transp."
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(77, 154)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(90, 16)
        Me.Lt1.TabIndex = 325
        Me.Lt1.Text = "*Unidad peso"
        '
        'TUnidadPeso
        '
        Me.TUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUnidadPeso.Location = New System.Drawing.Point(172, 151)
        Me.TUnidadPeso.Name = "TUnidadPeso"
        Me.TUnidadPeso.Size = New System.Drawing.Size(56, 22)
        Me.TUnidadPeso.TabIndex = 3
        '
        'BtnUnidadPeso
        '
        Me.BtnUnidadPeso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidadPeso.Image = Global.SGT_Transport.My.Resources.Resources.lupu31
        Me.BtnUnidadPeso.Location = New System.Drawing.Point(234, 150)
        Me.BtnUnidadPeso.Name = "BtnUnidadPeso"
        Me.BtnUnidadPeso.Size = New System.Drawing.Size(23, 23)
        Me.BtnUnidadPeso.TabIndex = 327
        Me.BtnUnidadPeso.UseVisualStyleBackColor = True
        '
        'LTBienesTransp
        '
        Me.LTBienesTransp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTBienesTransp.Location = New System.Drawing.Point(172, 217)
        Me.LTBienesTransp.Name = "LTBienesTransp"
        Me.LTBienesTransp.Size = New System.Drawing.Size(460, 23)
        Me.LTBienesTransp.TabIndex = 330
        '
        'LTUnidadPeso
        '
        Me.LTUnidadPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTUnidadPeso.Location = New System.Drawing.Point(263, 149)
        Me.LTUnidadPeso.Name = "LTUnidadPeso"
        Me.LTUnidadPeso.Size = New System.Drawing.Size(369, 23)
        Me.LTUnidadPeso.TabIndex = 329
        '
        'BtnBienesTransp
        '
        Me.BtnBienesTransp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBienesTransp.Image = Global.SGT_Transport.My.Resources.Resources.lupu31
        Me.BtnBienesTransp.Location = New System.Drawing.Point(281, 184)
        Me.BtnBienesTransp.Name = "BtnBienesTransp"
        Me.BtnBienesTransp.Size = New System.Drawing.Size(23, 23)
        Me.BtnBienesTransp.TabIndex = 328
        Me.BtnBienesTransp.UseVisualStyleBackColor = True
        '
        'CboMatPeligroso
        '
        Me.CboMatPeligroso.AllowSpinLoop = False
        Me.CboMatPeligroso.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CboMatPeligroso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboMatPeligroso.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboMatPeligroso.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.CboMatPeligroso.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboMatPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMatPeligroso.GapHeight = 0
        Me.CboMatPeligroso.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboMatPeligroso.ItemsDisplayMember = ""
        Me.CboMatPeligroso.ItemsValueMember = ""
        Me.CboMatPeligroso.Location = New System.Drawing.Point(172, 248)
        Me.CboMatPeligroso.Name = "CboMatPeligroso"
        Me.CboMatPeligroso.Size = New System.Drawing.Size(56, 21)
        Me.CboMatPeligroso.TabIndex = 6
        Me.CboMatPeligroso.Tag = Nothing
        Me.CboMatPeligroso.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmProductosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 363)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.PanelMatPeligro)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.TBienesTransp)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TUnidadPeso)
        Me.Controls.Add(Me.BtnUnidadPeso)
        Me.Controls.Add(Me.LTBienesTransp)
        Me.Controls.Add(Me.LTUnidadPeso)
        Me.Controls.Add(Me.BtnBienesTransp)
        Me.Controls.Add(Me.tCUEN_CONT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tCVE_PROD)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.CboMatPeligroso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductosAE"
        Me.ShowInTaskbar = False
        Me.Text = "Productos a cargar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.PanelMatPeligro.ResumeLayout(False)
        Me.PanelMatPeligro.PerformLayout()
        CType(Me.CboMatPeligroso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents tCVE_PROD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents PanelMatPeligro As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents LTCveMaterialPeligroso As Label
    Friend WithEvents LTEmbalaje As Label
    Private WithEvents BtnCveMaterialPeligroso As Button
    Private WithEvents BtnEmbalaje As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents TEmbalaje As TextBox
    Friend WithEvents TCveMaterialPeligroso As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TBienesTransp As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents TUnidadPeso As TextBox
    Private WithEvents BtnUnidadPeso As Button
    Friend WithEvents LTBienesTransp As Label
    Friend WithEvents LTUnidadPeso As Label
    Private WithEvents BtnBienesTransp As Button
    Friend WithEvents CboMatPeligroso As C1.Win.C1Input.C1ComboBox
End Class
