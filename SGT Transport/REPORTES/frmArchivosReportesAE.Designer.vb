<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchivosReportesAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivosReportesAE))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnFormato = New C1.Win.C1Input.C1Button()
        Me.tFormato = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCVE_REP = New System.Windows.Forms.TextBox()
        Me.barMenu.SuspendLayout()
        CType(Me.btnFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(636, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 5
        Me.barMenu.Text = "MenuStrip1"
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnFormato
        '
        Me.btnFormato.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormato.Location = New System.Drawing.Point(436, 163)
        Me.btnFormato.Name = "btnFormato"
        Me.btnFormato.Size = New System.Drawing.Size(34, 21)
        Me.btnFormato.TabIndex = 4
        Me.btnFormato.Text = "...."
        Me.btnFormato.UseVisualStyleBackColor = True
        Me.btnFormato.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnFormato.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tFormato
        '
        Me.tFormato.AcceptsReturn = True
        Me.tFormato.AcceptsTab = True
        Me.tFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFormato.Location = New System.Drawing.Point(79, 163)
        Me.tFormato.MaxLength = 120
        Me.tFormato.Name = "tFormato"
        Me.tFormato.Size = New System.Drawing.Size(351, 21)
        Me.tFormato.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(22, 164)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 15)
        Me.Label25.TabIndex = 275
        Me.Label25.Text = "Formato"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(23, 102)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 15)
        Me.Label23.TabIndex = 280
        Me.Label23.Text = "Nombre"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(79, 130)
        Me.tDescr.MaxLength = 255
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(525, 21)
        Me.tDescr.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 132)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 15)
        Me.Label22.TabIndex = 279
        Me.Label22.Text = "Descripción"
        '
        'tNombre
        '
        Me.tNombre.AcceptsReturn = True
        Me.tNombre.AcceptsTab = True
        Me.tNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNombre.Location = New System.Drawing.Point(79, 99)
        Me.tNombre.MaxLength = 80
        Me.tNombre.Name = "tNombre"
        Me.tNombre.Size = New System.Drawing.Size(351, 21)
        Me.tNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 282
        Me.Label1.Text = "Clave"
        '
        'tCVE_REP
        '
        Me.tCVE_REP.AcceptsReturn = True
        Me.tCVE_REP.AcceptsTab = True
        Me.tCVE_REP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_REP.Location = New System.Drawing.Point(79, 70)
        Me.tCVE_REP.Name = "tCVE_REP"
        Me.tCVE_REP.Size = New System.Drawing.Size(73, 21)
        Me.tCVE_REP.TabIndex = 0
        '
        'frmArchivosReportesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 209)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_REP)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tNombre)
        Me.Controls.Add(Me.btnFormato)
        Me.Controls.Add(Me.tFormato)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArchivosReportesAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivo"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.btnFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnFormato As C1.Win.C1Input.C1Button
    Friend WithEvents tFormato As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents tNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tCVE_REP As TextBox
End Class
