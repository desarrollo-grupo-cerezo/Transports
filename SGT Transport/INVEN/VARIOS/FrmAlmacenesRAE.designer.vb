<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAlmacenesRAE
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
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCUEN_CONT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barMenu.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(66, 92)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 13)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Almacen"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(120, 129)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(289, 21)
        Me.tDescr.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(51, 132)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(63, 13)
        Me.Nombre.TabIndex = 88
        Me.Nombre.Text = "Descripción"
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(441, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 2
        Me.barMenu.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
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
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(120, 90)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(68, 19)
        Me.cboAlmacen.TabIndex = 0
        Me.cboAlmacen.Tag = Nothing
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
        Me.tCUEN_CONT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCUEN_CONT.Location = New System.Drawing.Point(120, 165)
        Me.tCUEN_CONT.MaxLength = 28
        Me.tCUEN_CONT.Name = "tCUEN_CONT"
        Me.tCUEN_CONT.Size = New System.Drawing.Size(289, 21)
        Me.tCUEN_CONT.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Cuenta contable"
        '
        'frmAlmacenesRAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 212)
        Me.Controls.Add(Me.tCUEN_CONT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlmacenesRAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almacenes"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCUEN_CONT As TextBox
    Friend WithEvents Label1 As Label
End Class
