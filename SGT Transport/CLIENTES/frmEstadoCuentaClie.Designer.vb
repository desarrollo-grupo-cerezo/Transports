<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstadoCuentaClie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadoCuentaClie))
        Me.btnClie1 = New System.Windows.Forms.Button()
        Me.tCLAVE1 = New System.Windows.Forms.TextBox()
        Me.btnClie2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tCLAVE2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barDesplegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chSaldo = New C1.Win.C1Input.C1CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClie1
        '
        Me.btnClie1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClie1.Image = CType(resources.GetObject("btnClie1.Image"), System.Drawing.Image)
        Me.btnClie1.Location = New System.Drawing.Point(138, 90)
        Me.btnClie1.Name = "btnClie1"
        Me.btnClie1.Size = New System.Drawing.Size(24, 23)
        Me.btnClie1.TabIndex = 269
        Me.btnClie1.UseVisualStyleBackColor = True
        '
        'tCLAVE1
        '
        Me.tCLAVE1.AcceptsReturn = True
        Me.tCLAVE1.AcceptsTab = True
        Me.tCLAVE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE1.Location = New System.Drawing.Point(61, 91)
        Me.tCLAVE1.Name = "tCLAVE1"
        Me.tCLAVE1.Size = New System.Drawing.Size(77, 21)
        Me.tCLAVE1.TabIndex = 264
        '
        'btnClie2
        '
        Me.btnClie2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClie2.Image = CType(resources.GetObject("btnClie2.Image"), System.Drawing.Image)
        Me.btnClie2.Location = New System.Drawing.Point(285, 90)
        Me.btnClie2.Name = "btnClie2"
        Me.btnClie2.Size = New System.Drawing.Size(24, 23)
        Me.btnClie2.TabIndex = 267
        Me.btnClie2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 268
        Me.Label10.Text = "Desde"
        '
        'tCLAVE2
        '
        Me.tCLAVE2.AcceptsReturn = True
        Me.tCLAVE2.AcceptsTab = True
        Me.tCLAVE2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLAVE2.Location = New System.Drawing.Point(216, 91)
        Me.tCLAVE2.Name = "tCLAVE2"
        Me.tCLAVE2.Size = New System.Drawing.Size(69, 21)
        Me.tCLAVE2.TabIndex = 265
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(174, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 15)
        Me.Label13.TabIndex = 266
        Me.Label13.Text = "Hasta"
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barDesplegar, Me.barExcel, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(999, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 270
        Me.barSalir.Text = "MenuStrip1"
        '
        'barDesplegar
        '
        Me.barDesplegar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barDesplegar.ForeColor = System.Drawing.Color.Black
        Me.barDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.barDesplegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barDesplegar.Name = "barDesplegar"
        Me.barDesplegar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barDesplegar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barDesplegar.Size = New System.Drawing.Size(71, 51)
        Me.barDesplegar.Text = "Desplegar"
        Me.barDesplegar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barExcel
        '
        Me.barExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barExcel.ForeColor = System.Drawing.Color.Black
        Me.barExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.barExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barExcel.Name = "barExcel"
        Me.barExcel.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barExcel.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barExcel.Size = New System.Drawing.Size(46, 51)
        Me.barExcel.Text = "Excel"
        Me.barExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(130, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "Rango de clientes"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(375, 92)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 302
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(330, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Fecha"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(540, 92)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 304
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(495, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Fecha"
        '
        'chSaldo
        '
        Me.chSaldo.BackColor = System.Drawing.Color.Transparent
        Me.chSaldo.BorderColor = System.Drawing.Color.Transparent
        Me.chSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chSaldo.ForeColor = System.Drawing.Color.Black
        Me.chSaldo.Location = New System.Drawing.Point(675, 92)
        Me.chSaldo.Name = "chSaldo"
        Me.chSaldo.Padding = New System.Windows.Forms.Padding(1)
        Me.chSaldo.Size = New System.Drawing.Size(104, 24)
        Me.chSaldo.TabIndex = 305
        Me.chSaldo.Text = "Saldo vencido"
        Me.chSaldo.UseVisualStyleBackColor = True
        Me.chSaldo.Value = Nothing
        Me.chSaldo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(454, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "Rango de fechas"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(12, 122)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(950, 311)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 307
        '
        'frmEstadoCuentaClie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 475)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chSaldo)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.btnClie1)
        Me.Controls.Add(Me.tCLAVE1)
        Me.Controls.Add(Me.btnClie2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tCLAVE2)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEstadoCuentaClie"
        Me.Text = "Estado de Cuenta"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClie1 As Button
    Friend WithEvents tCLAVE1 As TextBox
    Friend WithEvents btnClie2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents tCLAVE2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barDesplegar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents chSaldo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barExcel As ToolStripMenuItem
End Class
