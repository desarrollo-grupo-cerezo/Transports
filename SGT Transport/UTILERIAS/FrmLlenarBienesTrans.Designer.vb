<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLlenarBienesTrans
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLlenarBienesTrans))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.CboMatPeligroso = New C1.Win.C1Input.C1ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.PanelMatPeligro = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LTCveMaterialPeligroso = New System.Windows.Forms.Label()
        Me.LTEmbalaje = New System.Windows.Forms.Label()
        Me.BtnCveMaterialPeligroso = New System.Windows.Forms.Button()
        Me.BtnEmbalaje = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TEmbalaje = New System.Windows.Forms.TextBox()
        Me.TCveMaterialPeligroso = New System.Windows.Forms.TextBox()
        Me.LTBienesTransp = New System.Windows.Forms.Label()
        Me.LTUnidadPeso = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.TBienesTransp = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TUnidadPeso = New System.Windows.Forms.TextBox()
        Me.BtnUnidadPeso = New System.Windows.Forms.Button()
        Me.BtnBienesTransp = New System.Windows.Forms.Button()
        Me.Lt2 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMatPeligroso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMatPeligro.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(818, 43)
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
        'CboMatPeligroso
        '
        Me.CboMatPeligroso.AllowSpinLoop = False
        Me.CboMatPeligroso.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.CboMatPeligroso.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.CboMatPeligroso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboMatPeligroso.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboMatPeligroso.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.CboMatPeligroso.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboMatPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMatPeligroso.GapHeight = 0
        Me.CboMatPeligroso.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboMatPeligroso.ItemsDisplayMember = ""
        Me.CboMatPeligroso.ItemsValueMember = ""
        Me.CboMatPeligroso.Location = New System.Drawing.Point(179, 138)
        Me.CboMatPeligroso.Name = "CboMatPeligroso"
        Me.CboMatPeligroso.Size = New System.Drawing.Size(56, 21)
        Me.CboMatPeligroso.TabIndex = 348
        Me.CboMatPeligroso.Tag = Nothing
        Me.CboMatPeligroso.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(-130, 75)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(114, 16)
        Me.Label41.TabIndex = 355
        Me.Label41.Text = "CARTA PORTE"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(52, 138)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(115, 16)
        Me.Label53.TabIndex = 357
        Me.Label53.Text = "Material peligroso"
        '
        'PanelMatPeligro
        '
        Me.PanelMatPeligro.Controls.Add(Me.Label23)
        Me.PanelMatPeligro.Controls.Add(Me.LTCveMaterialPeligroso)
        Me.PanelMatPeligro.Controls.Add(Me.LTEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.BtnCveMaterialPeligroso)
        Me.PanelMatPeligro.Controls.Add(Me.BtnEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.Label40)
        Me.PanelMatPeligro.Controls.Add(Me.TEmbalaje)
        Me.PanelMatPeligro.Controls.Add(Me.TCveMaterialPeligroso)
        Me.PanelMatPeligro.Location = New System.Drawing.Point(14, 165)
        Me.PanelMatPeligro.Name = "PanelMatPeligro"
        Me.PanelMatPeligro.Size = New System.Drawing.Size(683, 64)
        Me.PanelMatPeligro.TabIndex = 356
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(4, 10)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(153, 16)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "*Cve. material peligroso "
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
        Me.BtnCveMaterialPeligroso.Image = CType(resources.GetObject("BtnCveMaterialPeligroso.Image"), System.Drawing.Image)
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
        Me.BtnEmbalaje.Image = CType(resources.GetObject("BtnEmbalaje.Image"), System.Drawing.Image)
        Me.BtnEmbalaje.Location = New System.Drawing.Point(227, 37)
        Me.BtnEmbalaje.Name = "BtnEmbalaje"
        Me.BtnEmbalaje.Size = New System.Drawing.Size(23, 23)
        Me.BtnEmbalaje.TabIndex = 102
        Me.BtnEmbalaje.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(84, 40)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(70, 16)
        Me.Label40.TabIndex = 61
        Me.Label40.Text = "*Embalaje"
        '
        'TEmbalaje
        '
        Me.TEmbalaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEmbalaje.Location = New System.Drawing.Point(165, 37)
        Me.TEmbalaje.Name = "TEmbalaje"
        Me.TEmbalaje.Size = New System.Drawing.Size(56, 22)
        Me.TEmbalaje.TabIndex = 4
        '
        'TCveMaterialPeligroso
        '
        Me.TCveMaterialPeligroso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCveMaterialPeligroso.Location = New System.Drawing.Point(165, 6)
        Me.TCveMaterialPeligroso.Name = "TCveMaterialPeligroso"
        Me.TCveMaterialPeligroso.Size = New System.Drawing.Size(56, 22)
        Me.TCveMaterialPeligroso.TabIndex = 3
        '
        'LTBienesTransp
        '
        Me.LTBienesTransp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTBienesTransp.Location = New System.Drawing.Point(317, 110)
        Me.LTBienesTransp.Name = "LTBienesTransp"
        Me.LTBienesTransp.Size = New System.Drawing.Size(460, 23)
        Me.LTBienesTransp.TabIndex = 354
        '
        'LTUnidadPeso
        '
        Me.LTUnidadPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTUnidadPeso.Location = New System.Drawing.Point(270, 81)
        Me.LTUnidadPeso.Name = "LTUnidadPeso"
        Me.LTUnidadPeso.Size = New System.Drawing.Size(369, 23)
        Me.LTUnidadPeso.TabIndex = 353
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(77, 85)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(90, 16)
        Me.Lt1.TabIndex = 349
        Me.Lt1.Text = "*Unidad peso"
        '
        'TBienesTransp
        '
        Me.TBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBienesTransp.Location = New System.Drawing.Point(179, 111)
        Me.TBienesTransp.Name = "TBienesTransp"
        Me.TBienesTransp.Size = New System.Drawing.Size(103, 22)
        Me.TBienesTransp.TabIndex = 347
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(70, 113)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(97, 16)
        Me.Label42.TabIndex = 350
        Me.Label42.Text = "*Bienes transp."
        '
        'TUnidadPeso
        '
        Me.TUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUnidadPeso.Location = New System.Drawing.Point(179, 83)
        Me.TUnidadPeso.Name = "TUnidadPeso"
        Me.TUnidadPeso.Size = New System.Drawing.Size(56, 22)
        Me.TUnidadPeso.TabIndex = 346
        '
        'BtnUnidadPeso
        '
        Me.BtnUnidadPeso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidadPeso.Image = CType(resources.GetObject("BtnUnidadPeso.Image"), System.Drawing.Image)
        Me.BtnUnidadPeso.Location = New System.Drawing.Point(241, 82)
        Me.BtnUnidadPeso.Name = "BtnUnidadPeso"
        Me.BtnUnidadPeso.Size = New System.Drawing.Size(23, 23)
        Me.BtnUnidadPeso.TabIndex = 351
        Me.BtnUnidadPeso.UseVisualStyleBackColor = True
        '
        'BtnBienesTransp
        '
        Me.BtnBienesTransp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBienesTransp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBienesTransp.Image = CType(resources.GetObject("BtnBienesTransp.Image"), System.Drawing.Image)
        Me.BtnBienesTransp.Location = New System.Drawing.Point(288, 110)
        Me.BtnBienesTransp.Name = "BtnBienesTransp"
        Me.BtnBienesTransp.Size = New System.Drawing.Size(23, 23)
        Me.BtnBienesTransp.TabIndex = 352
        Me.BtnBienesTransp.UseVisualStyleBackColor = True
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(336, 248)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(35, 16)
        Me.Lt2.TabIndex = 112
        Me.Lt2.Text = "____"
        '
        'FrmLlenarBienesTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 273)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.CboMatPeligroso)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.PanelMatPeligro)
        Me.Controls.Add(Me.LTBienesTransp)
        Me.Controls.Add(Me.LTUnidadPeso)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TBienesTransp)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.TUnidadPeso)
        Me.Controls.Add(Me.BtnUnidadPeso)
        Me.Controls.Add(Me.BtnBienesTransp)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLlenarBienesTrans"
        Me.Text = "Llenar Bienes Transportados"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMatPeligroso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMatPeligro.ResumeLayout(False)
        Me.PanelMatPeligro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents CboMatPeligroso As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents PanelMatPeligro As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents LTCveMaterialPeligroso As Label
    Friend WithEvents LTEmbalaje As Label
    Private WithEvents BtnCveMaterialPeligroso As Button
    Private WithEvents BtnEmbalaje As Button
    Friend WithEvents Label40 As Label
    Friend WithEvents TEmbalaje As TextBox
    Friend WithEvents TCveMaterialPeligroso As TextBox
    Friend WithEvents LTBienesTransp As Label
    Friend WithEvents LTUnidadPeso As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents TBienesTransp As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents TUnidadPeso As TextBox
    Private WithEvents BtnUnidadPeso As Button
    Private WithEvents BtnBienesTransp As Button
    Friend WithEvents Lt2 As Label
End Class
