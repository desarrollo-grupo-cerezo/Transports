<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiltroConciValCombus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltroConciValCombus))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.BarAplicarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnProv = New C1.Win.C1Input.C1Button()
        Me.TCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.BtnProv2 = New C1.Win.C1Input.C1Button()
        Me.TCVE_PROV2 = New System.Windows.Forms.TextBox()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuBarra.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAplicarFiltro, Me.BarSalir})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(406, 55)
        Me.MenuBarra.TabIndex = 4
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'BarAplicarFiltro
        '
        Me.BarAplicarFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarAplicarFiltro.ForeColor = System.Drawing.Color.Black
        Me.BarAplicarFiltro.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAplicarFiltro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAplicarFiltro.Name = "BarAplicarFiltro"
        Me.BarAplicarFiltro.ShortcutKeyDisplayString = ""
        Me.BarAplicarFiltro.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarAplicarFiltro.Size = New System.Drawing.Size(84, 51)
        Me.BarAplicarFiltro.Text = "Aplicar filtro"
        Me.BarAplicarFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(198, 118)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(108, 21)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.CustomFormat = "dd/MM/yyyy"
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(62, 118)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(108, 21)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "al"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Del"
        '
        'BtnProv
        '
        Me.BtnProv.Image = CType(resources.GetObject("BtnProv.Image"), System.Drawing.Image)
        Me.BtnProv.Location = New System.Drawing.Point(154, 225)
        Me.BtnProv.Name = "BtnProv"
        Me.BtnProv.Size = New System.Drawing.Size(26, 21)
        Me.BtnProv.TabIndex = 332
        Me.BtnProv.UseVisualStyleBackColor = True
        Me.BtnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_PROV
        '
        Me.TCVE_PROV.AcceptsReturn = True
        Me.TCVE_PROV.AcceptsTab = True
        Me.TCVE_PROV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV.ForeColor = System.Drawing.Color.Black
        Me.TCVE_PROV.Location = New System.Drawing.Point(98, 225)
        Me.TCVE_PROV.MaxLength = 10
        Me.TCVE_PROV.Name = "TCVE_PROV"
        Me.TCVE_PROV.Size = New System.Drawing.Size(54, 22)
        Me.TCVE_PROV.TabIndex = 2
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt1.Location = New System.Drawing.Point(113, 191)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(130, 16)
        Me.Lt1.TabIndex = 6
        Me.Lt1.Text = "Rango proveedores"
        '
        'BtnProv2
        '
        Me.BtnProv2.Image = CType(resources.GetObject("BtnProv2.Image"), System.Drawing.Image)
        Me.BtnProv2.Location = New System.Drawing.Point(263, 224)
        Me.BtnProv2.Name = "BtnProv2"
        Me.BtnProv2.Size = New System.Drawing.Size(26, 21)
        Me.BtnProv2.TabIndex = 334
        Me.BtnProv2.UseVisualStyleBackColor = True
        Me.BtnProv2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_PROV2
        '
        Me.TCVE_PROV2.AcceptsReturn = True
        Me.TCVE_PROV2.AcceptsTab = True
        Me.TCVE_PROV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_PROV2.ForeColor = System.Drawing.Color.Black
        Me.TCVE_PROV2.Location = New System.Drawing.Point(207, 224)
        Me.TCVE_PROV2.MaxLength = 10
        Me.TCVE_PROV2.Name = "TCVE_PROV2"
        Me.TCVE_PROV2.Size = New System.Drawing.Size(54, 22)
        Me.TCVE_PROV2.TabIndex = 3
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.Location = New System.Drawing.Point(186, 230)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(15, 13)
        Me.Lt3.TabIndex = 10
        Me.Lt3.Text = "al"
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Location = New System.Drawing.Point(69, 229)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(23, 13)
        Me.Lt2.TabIndex = 9
        Me.Lt2.Text = "Del"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(134, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Rango de fechas"
        '
        'FrmFiltroConciValCombus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 346)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.BtnProv2)
        Me.Controls.Add(Me.TCVE_PROV2)
        Me.Controls.Add(Me.BtnProv)
        Me.Controls.Add(Me.TCVE_PROV)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiltroConciValCombus"
        Me.Text = "Filtro"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnProv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents BarAplicarFiltro As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnProv As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_PROV As TextBox
    Friend WithEvents Lt1 As Label
    Friend WithEvents BtnProv2 As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_PROV2 As TextBox
    Friend WithEvents Lt3 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Label5 As Label
End Class
