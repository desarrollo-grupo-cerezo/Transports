<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiltro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltro))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FC2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FC1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FD2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FD1 = New C1.Win.Calendar.C1DateEdit()
        Me.btnTractor = New C1.Win.C1Input.C1Button()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.tCVE_TRACTOR = New System.Windows.Forms.TextBox()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FC2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(230, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 16)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(275, 98)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 169
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(85, 98)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.ToolStripSeparator1, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(455, 54)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barAceptar
        '
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.Size = New System.Drawing.Size(52, 51)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Por fecha del viaje"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(166, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 16)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "Por fecha de carga"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(230, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 16)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "al"
        '
        'FC2
        '
        Me.FC2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.FC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FC2.Calendar.ClearText = "&Limpiar"
        Me.FC2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FC2.Calendar.TodayText = "&Hoy"
        Me.FC2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FC2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.FC2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FC2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.FC2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FC2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FC2.Location = New System.Drawing.Point(275, 180)
        Me.FC2.Name = "FC2"
        Me.FC2.Size = New System.Drawing.Size(122, 20)
        Me.FC2.TabIndex = 174
        Me.FC2.Tag = Nothing
        Me.FC2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FC2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 16)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "Del"
        '
        'FC1
        '
        Me.FC1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.FC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FC1.Calendar.ClearText = "&Limpiar"
        Me.FC1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FC1.Calendar.TodayText = "&Hoy"
        Me.FC1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FC1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.FC1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FC1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.FC1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FC1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FC1.Location = New System.Drawing.Point(85, 180)
        Me.FC1.Name = "FC1"
        Me.FC1.Size = New System.Drawing.Size(122, 20)
        Me.FC1.TabIndex = 172
        Me.FC1.Tag = Nothing
        Me.FC1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FC1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(166, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 16)
        Me.Label7.TabIndex = 181
        Me.Label7.Text = "Por fecha de descarga"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(230, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 16)
        Me.Label8.TabIndex = 180
        Me.Label8.Text = "al"
        '
        'FD2
        '
        Me.FD2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.FD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FD2.Calendar.ClearText = "&Limpiar"
        Me.FD2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FD2.Calendar.TodayText = "&Hoy"
        Me.FD2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FD2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.FD2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FD2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FD2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.FD2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FD2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FD2.Location = New System.Drawing.Point(275, 249)
        Me.FD2.Name = "FD2"
        Me.FD2.Size = New System.Drawing.Size(122, 20)
        Me.FD2.TabIndex = 179
        Me.FD2.Tag = Nothing
        Me.FD2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FD2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 16)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "Del"
        '
        'FD1
        '
        Me.FD1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.FD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FD1.Calendar.ClearText = "&Limpiar"
        Me.FD1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FD1.Calendar.TodayText = "&Hoy"
        Me.FD1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FD1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.FD1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FD1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FD1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.FD1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FD1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FD1.Location = New System.Drawing.Point(85, 249)
        Me.FD1.Name = "FD1"
        Me.FD1.Size = New System.Drawing.Size(122, 20)
        Me.FD1.TabIndex = 177
        Me.FD1.Tag = Nothing
        Me.FD1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FD1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnTractor
        '
        Me.btnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTractor.Image = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.btnTractor.Location = New System.Drawing.Point(153, 309)
        Me.btnTractor.Name = "btnTractor"
        Me.btnTractor.Size = New System.Drawing.Size(24, 24)
        Me.btnTractor.TabIndex = 164
        Me.btnTractor.UseVisualStyleBackColor = True
        Me.btnTractor.Visible = False
        Me.btnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(32, 313)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(52, 16)
        Me.Label100.TabIndex = 166
        Me.Label100.Text = "Unidad"
        Me.Label100.Visible = False
        '
        'tCVE_TRACTOR
        '
        Me.tCVE_TRACTOR.AcceptsReturn = True
        Me.tCVE_TRACTOR.AcceptsTab = True
        Me.tCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TRACTOR.Location = New System.Drawing.Point(85, 309)
        Me.tCVE_TRACTOR.Name = "tCVE_TRACTOR"
        Me.tCVE_TRACTOR.Size = New System.Drawing.Size(66, 22)
        Me.tCVE_TRACTOR.TabIndex = 165
        Me.tCVE_TRACTOR.Visible = False
        '
        'FrmFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 398)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FD2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.FD1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FC2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FC1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_TRACTOR)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.btnTractor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiltro"
        Me.Text = "Filtro"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FC2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barAceptar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents FC2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents FC1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents FD2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents FD1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents btnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents Label100 As Label
    Friend WithEvents tCVE_TRACTOR As TextBox
End Class
