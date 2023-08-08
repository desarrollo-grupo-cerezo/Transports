<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearAlmacenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearAlmacenes))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGenerar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_ART2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tCVE_ART1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tLINEA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.btnLinea = New C1.Win.C1Input.C1Button()
        Me.btnProd2 = New C1.Win.C1Input.C1Button()
        Me.btnProd1 = New C1.Win.C1Input.C1Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.barMenu.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProd1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGenerar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(470, 53)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 0
        Me.barMenu.Text = "MenuStrip1"
        '
        'barGenerar
        '
        Me.barGenerar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barGenerar.ForeColor = System.Drawing.Color.Black
        Me.barGenerar.Image = Global.SGT_Transport.My.Resources.Resources.Multi_almac
        Me.barGenerar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGenerar.Name = "barGenerar"
        Me.barGenerar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGenerar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGenerar.Size = New System.Drawing.Size(60, 49)
        Me.barGenerar.Text = "Generar"
        Me.barGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 49)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_ART2
        '
        Me.tCVE_ART2.AcceptsReturn = True
        Me.tCVE_ART2.AcceptsTab = True
        Me.tCVE_ART2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ART2.Location = New System.Drawing.Point(279, 28)
        Me.tCVE_ART2.Name = "tCVE_ART2"
        Me.tCVE_ART2.Size = New System.Drawing.Size(120, 22)
        Me.tCVE_ART2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(232, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Hasta"
        '
        'tCVE_ART1
        '
        Me.tCVE_ART1.AcceptsReturn = True
        Me.tCVE_ART1.AcceptsTab = True
        Me.tCVE_ART1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ART1.Location = New System.Drawing.Point(75, 28)
        Me.tCVE_ART1.Name = "tCVE_ART1"
        Me.tCVE_ART1.Size = New System.Drawing.Size(120, 22)
        Me.tCVE_ART1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Desde"
        '
        'tLINEA
        '
        Me.tLINEA.AcceptsReturn = True
        Me.tLINEA.AcceptsTab = True
        Me.tLINEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLINEA.Location = New System.Drawing.Point(75, 67)
        Me.tLINEA.Name = "tLINEA"
        Me.tLINEA.Size = New System.Drawing.Size(76, 22)
        Me.tLINEA.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Linea"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(47, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Almacén"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(108, 30)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(175, 20)
        Me.cboAlmacen.TabIndex = 0
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnLinea
        '
        Me.btnLinea.Image = CType(resources.GetObject("btnLinea.Image"), System.Drawing.Image)
        Me.btnLinea.Location = New System.Drawing.Point(152, 67)
        Me.btnLinea.Name = "btnLinea"
        Me.btnLinea.Size = New System.Drawing.Size(26, 22)
        Me.btnLinea.TabIndex = 149
        Me.btnLinea.UseVisualStyleBackColor = True
        Me.btnLinea.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnProd2
        '
        Me.btnProd2.Image = CType(resources.GetObject("btnProd2.Image"), System.Drawing.Image)
        Me.btnProd2.Location = New System.Drawing.Point(400, 28)
        Me.btnProd2.Name = "btnProd2"
        Me.btnProd2.Size = New System.Drawing.Size(26, 20)
        Me.btnProd2.TabIndex = 146
        Me.btnProd2.UseVisualStyleBackColor = True
        Me.btnProd2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnProd1
        '
        Me.btnProd1.Image = CType(resources.GetObject("btnProd1.Image"), System.Drawing.Image)
        Me.btnProd1.Location = New System.Drawing.Point(196, 28)
        Me.btnProd1.Name = "btnProd1"
        Me.btnProd1.Size = New System.Drawing.Size(27, 22)
        Me.btnProd1.TabIndex = 144
        Me.btnProd1.UseVisualStyleBackColor = True
        Me.btnProd1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tCVE_ART1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnProd1)
        Me.GroupBox1.Controls.Add(Me.btnLinea)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tLINEA)
        Me.GroupBox1.Controls.Add(Me.tCVE_ART2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnProd2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 110)
        Me.GroupBox1.TabIndex = 311
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboAlmacen)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 70)
        Me.GroupBox2.TabIndex = 312
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'frmCrearAlmacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 328)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.barMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCrearAlmacenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear Almacenes"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProd1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGenerar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents btnProd2 As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_ART2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnProd1 As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_ART1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnLinea As C1.Win.C1Input.C1Button
    Friend WithEvents tLINEA As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
