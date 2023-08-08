<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosOperFiltraOper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSaldosOperFiltraOper))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.BarAplicarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuBarra.SuspendLayout()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAplicarFiltro, Me.BarSalir})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(447, 55)
        Me.MenuBarra.TabIndex = 6
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
        'LOper
        '
        Me.LOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LOper.Location = New System.Drawing.Point(98, 141)
        Me.LOper.Name = "LOper"
        Me.LOper.Size = New System.Drawing.Size(323, 22)
        Me.LOper.TabIndex = 202
        Me.LOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.ForeColor = System.Drawing.Color.Black
        Me.TCVE_OPER.Location = New System.Drawing.Point(98, 105)
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(51, 22)
        Me.TCVE_OPER.TabIndex = 201
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(29, 108)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(66, 16)
        Me.Label41.TabIndex = 203
        Me.Label41.Text = "Operador"
        '
        'BtnOper
        '
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(155, 104)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(26, 22)
        Me.BtnOper.TabIndex = 204
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 205
        Me.Label1.Text = "Nombre"
        '
        'FrmSaldosOperFiltraOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 235)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LOper)
        Me.Controls.Add(Me.TCVE_OPER)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.BtnOper)
        Me.Controls.Add(Me.MenuBarra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaldosOperFiltraOper"
        Me.Text = "Filtrar por operador"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents BarAplicarFiltro As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents LOper As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As Label
End Class
