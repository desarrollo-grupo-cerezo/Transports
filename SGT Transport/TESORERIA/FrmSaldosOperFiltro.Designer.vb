<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosOperFiltro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSaldosOperFiltro))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.BarAplicarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChTodos = New C1.Win.C1Input.C1CheckBox()
        Me.ChIgnorarFechas = New C1.Win.C1Input.C1CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.MenuBarra.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChTodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChIgnorarFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAplicarFiltro, Me.BarSalir})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(415, 55)
        Me.MenuBarra.TabIndex = 5
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(39, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Rango de fechas"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.CustomFormat = "dd/MM/yyyy"
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(204, 134)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(108, 20)
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
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(68, 134)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(108, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(182, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "al"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Del"
        '
        'ChTodos
        '
        Me.ChTodos.BackColor = System.Drawing.Color.Transparent
        Me.ChTodos.BorderColor = System.Drawing.Color.Transparent
        Me.ChTodos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChTodos.ForeColor = System.Drawing.Color.Black
        Me.ChTodos.Location = New System.Drawing.Point(30, 304)
        Me.ChTodos.Name = "ChTodos"
        Me.ChTodos.Padding = New System.Windows.Forms.Padding(1)
        Me.ChTodos.Size = New System.Drawing.Size(101, 32)
        Me.ChTodos.TabIndex = 4
        Me.ChTodos.Text = "Todos"
        Me.ChTodos.UseVisualStyleBackColor = False
        Me.ChTodos.Value = False
        Me.ChTodos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChIgnorarFechas
        '
        Me.ChIgnorarFechas.BackColor = System.Drawing.Color.Transparent
        Me.ChIgnorarFechas.BorderColor = System.Drawing.Color.Transparent
        Me.ChIgnorarFechas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChIgnorarFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChIgnorarFechas.ForeColor = System.Drawing.Color.Black
        Me.ChIgnorarFechas.Location = New System.Drawing.Point(185, 91)
        Me.ChIgnorarFechas.Name = "ChIgnorarFechas"
        Me.ChIgnorarFechas.Padding = New System.Windows.Forms.Padding(1)
        Me.ChIgnorarFechas.Size = New System.Drawing.Size(166, 32)
        Me.ChIgnorarFechas.TabIndex = 6
        Me.ChIgnorarFechas.Text = "Ignorar fechas"
        Me.ChIgnorarFechas.UseVisualStyleBackColor = False
        Me.ChIgnorarFechas.Value = False
        Me.ChIgnorarFechas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Nombre"
        '
        'LOper
        '
        Me.LOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LOper.Location = New System.Drawing.Point(80, 244)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(323, 22)
        Me.LOper.TabIndex = 3
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(80, 208)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_OPER.TabIndex = 2
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(11, 211)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 16)
        Me.Label41.TabIndex = 208
        Me.Label41.Text = "Operador"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(137, 207)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 22)
        Me.BtnOper.TabIndex = 209
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmSaldosOperFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 389)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LOper)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.ChIgnorarFechas)
        Me.Controls.Add(Me.ChTodos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MenuBarra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaldosOperFiltro"
        Me.Text = "Filtro saldo operadores"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChTodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChIgnorarFechas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents BarAplicarFiltro As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ChTodos As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChIgnorarFechas As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
End Class
