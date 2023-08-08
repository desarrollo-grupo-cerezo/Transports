<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCatGastosAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatGastosAE))
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.TLINEA = New System.Windows.Forms.TextBox()
        Me.BtnLinea = New System.Windows.Forms.Button()
        Me.LtLinea = New System.Windows.Forms.Label()
        Me.TCVE_ART = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TDESCR = New System.Windows.Forms.TextBox()
        Me.LtDescr = New System.Windows.Forms.Label()
        Me.TCVE_ESQIMPU = New System.Windows.Forms.TextBox()
        Me.BtnEsquema = New C1.Win.C1Input.C1Button()
        Me.LtEsquema = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TCOSTO = New C1.Win.C1Input.C1NumericEdit()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TCUENTA_CONT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraMenu.SuspendLayout()
        CType(Me.BtnEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCOSTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMenu
        '
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(639, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 5
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
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(101, 154)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(43, 17)
        Me.Lt1.TabIndex = 337
        Me.Lt1.Text = "Linea"
        '
        'TLINEA
        '
        Me.TLINEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLINEA.Location = New System.Drawing.Point(150, 151)
        Me.TLINEA.Name = "TLINEA"
        Me.TLINEA.Size = New System.Drawing.Size(56, 23)
        Me.TLINEA.TabIndex = 2
        '
        'BtnLinea
        '
        Me.BtnLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLinea.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnLinea.Location = New System.Drawing.Point(212, 150)
        Me.BtnLinea.Name = "BtnLinea"
        Me.BtnLinea.Size = New System.Drawing.Size(23, 23)
        Me.BtnLinea.TabIndex = 338
        Me.BtnLinea.UseVisualStyleBackColor = True
        '
        'LtLinea
        '
        Me.LtLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLinea.Location = New System.Drawing.Point(241, 149)
        Me.LtLinea.Name = "LtLinea"
        Me.LtLinea.Size = New System.Drawing.Size(360, 23)
        Me.LtLinea.TabIndex = 339
        '
        'TCVE_ART
        '
        Me.TCVE_ART.AcceptsReturn = True
        Me.TCVE_ART.AcceptsTab = True
        Me.TCVE_ART.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ART.Location = New System.Drawing.Point(150, 94)
        Me.TCVE_ART.Name = "TCVE_ART"
        Me.TCVE_ART.Size = New System.Drawing.Size(56, 23)
        Me.TCVE_ART.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(101, 97)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 17)
        Me.Label27.TabIndex = 335
        Me.Label27.Text = "Clave"
        '
        'TDESCR
        '
        Me.TDESCR.AcceptsReturn = True
        Me.TDESCR.AcceptsTab = True
        Me.TDESCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESCR.Location = New System.Drawing.Point(150, 122)
        Me.TDESCR.Name = "TDESCR"
        Me.TDESCR.Size = New System.Drawing.Size(451, 23)
        Me.TDESCR.TabIndex = 1
        '
        'LtDescr
        '
        Me.LtDescr.AutoSize = True
        Me.LtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescr.Location = New System.Drawing.Point(62, 125)
        Me.LtDescr.Name = "LtDescr"
        Me.LtDescr.Size = New System.Drawing.Size(82, 17)
        Me.LtDescr.TabIndex = 334
        Me.LtDescr.Text = "Descripción"
        '
        'TCVE_ESQIMPU
        '
        Me.TCVE_ESQIMPU.AcceptsReturn = True
        Me.TCVE_ESQIMPU.AcceptsTab = True
        Me.TCVE_ESQIMPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_ESQIMPU.Location = New System.Drawing.Point(150, 186)
        Me.TCVE_ESQIMPU.MaxLength = 5
        Me.TCVE_ESQIMPU.Name = "TCVE_ESQIMPU"
        Me.TCVE_ESQIMPU.Size = New System.Drawing.Size(55, 23)
        Me.TCVE_ESQIMPU.TabIndex = 3
        Me.TCVE_ESQIMPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnEsquema
        '
        Me.BtnEsquema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnEsquema.Image = CType(resources.GetObject("BtnEsquema.Image"), System.Drawing.Image)
        Me.BtnEsquema.Location = New System.Drawing.Point(212, 186)
        Me.BtnEsquema.Name = "BtnEsquema"
        Me.BtnEsquema.Size = New System.Drawing.Size(23, 23)
        Me.BtnEsquema.TabIndex = 342
        Me.BtnEsquema.UseVisualStyleBackColor = True
        Me.BtnEsquema.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtEsquema
        '
        Me.LtEsquema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtEsquema.Location = New System.Drawing.Point(241, 186)
        Me.LtEsquema.Name = "LtEsquema"
        Me.LtEsquema.Size = New System.Drawing.Size(360, 23)
        Me.LtEsquema.TabIndex = 341
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(77, 189)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 17)
        Me.Label21.TabIndex = 340
        Me.Label21.Text = "Esquema"
        '
        'TCOSTO
        '
        Me.TCOSTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO.CustomFormat = "###,###,##0.000"
        Me.TCOSTO.DisplayFormat.CustomFormat = "###,###,##0.000"
        Me.TCOSTO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TCOSTO.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO.Location = New System.Drawing.Point(150, 225)
        Me.TCOSTO.Name = "TCOSTO"
        Me.TCOSTO.Size = New System.Drawing.Size(117, 21)
        Me.TCOSTO.TabIndex = 4
        Me.TCOSTO.Tag = Nothing
        Me.TCOSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(100, 227)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(44, 17)
        Me.Label28.TabIndex = 344
        Me.Label28.Text = "Costo"
        '
        'TCUENTA_CONT
        '
        Me.TCUENTA_CONT.AcceptsReturn = True
        Me.TCUENTA_CONT.AcceptsTab = True
        Me.TCUENTA_CONT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCUENTA_CONT.Location = New System.Drawing.Point(150, 251)
        Me.TCUENTA_CONT.MaxLength = 25
        Me.TCUENTA_CONT.Name = "TCUENTA_CONT"
        Me.TCUENTA_CONT.Size = New System.Drawing.Size(291, 23)
        Me.TCUENTA_CONT.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 346
        Me.Label1.Text = "Cuenta contable"
        '
        'FrmCatGastosAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 300)
        Me.Controls.Add(Me.TCUENTA_CONT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCOSTO)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.TCVE_ESQIMPU)
        Me.Controls.Add(Me.BtnEsquema)
        Me.Controls.Add(Me.LtEsquema)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TLINEA)
        Me.Controls.Add(Me.BtnLinea)
        Me.Controls.Add(Me.LtLinea)
        Me.Controls.Add(Me.TCVE_ART)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TDESCR)
        Me.Controls.Add(Me.LtDescr)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCatGastosAE"
        Me.ShowInTaskbar = False
        Me.Text = "Concepto de gastos"
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.BtnEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCOSTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Lt1 As Label
    Friend WithEvents TLINEA As TextBox
    Private WithEvents BtnLinea As Button
    Friend WithEvents LtLinea As Label
    Friend WithEvents TCVE_ART As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TDESCR As TextBox
    Friend WithEvents LtDescr As Label
    Friend WithEvents TCVE_ESQIMPU As TextBox
    Friend WithEvents BtnEsquema As C1.Win.C1Input.C1Button
    Friend WithEvents LtEsquema As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TCOSTO As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label28 As Label
    Friend WithEvents TCUENTA_CONT As TextBox
    Friend WithEvents Label1 As Label
End Class
