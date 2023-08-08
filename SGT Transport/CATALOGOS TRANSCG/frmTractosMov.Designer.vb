<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTractosMov
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
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1Label1 = New C1.Win.C1Input.C1Label()
        Me.tClave = New C1.Win.C1Input.C1TextBox()
        Me.tDescr = New C1.Win.C1Input.C1TextBox()
        Me.C1Label2 = New C1.Win.C1Input.C1Label()
        Me.barSalir.SuspendLayout()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDescr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGuardar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(558, 55)
        Me.barSalir.TabIndex = 6
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGuardar
        '
        Me.barGuardar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGuardar.Name = "barGuardar"
        Me.barGuardar.Size = New System.Drawing.Size(61, 51)
        Me.barGuardar.Text = "Guardar"
        Me.barGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1Label1
        '
        Me.C1Label1.AutoSize = True
        Me.C1Label1.BackColor = System.Drawing.Color.Transparent
        Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label1.ForeColor = System.Drawing.Color.Black
        Me.C1Label1.Location = New System.Drawing.Point(30, 90)
        Me.C1Label1.Name = "C1Label1"
        Me.C1Label1.Size = New System.Drawing.Size(34, 13)
        Me.C1Label1.TabIndex = 7
        Me.C1Label1.Tag = Nothing
        Me.C1Label1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1Label1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tClave
        '
        Me.tClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tClave.Location = New System.Drawing.Point(101, 85)
        Me.tClave.Name = "tClave"
        Me.tClave.Size = New System.Drawing.Size(113, 18)
        Me.tClave.TabIndex = 8
        Me.tClave.Tag = Nothing
        Me.tClave.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tClave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tDescr
        '
        Me.tDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescr.Location = New System.Drawing.Point(101, 130)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(345, 18)
        Me.tDescr.TabIndex = 10
        Me.tDescr.Tag = Nothing
        Me.tDescr.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tDescr.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1Label2
        '
        Me.C1Label2.AutoSize = True
        Me.C1Label2.BackColor = System.Drawing.Color.Transparent
        Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label2.ForeColor = System.Drawing.Color.Black
        Me.C1Label2.Location = New System.Drawing.Point(30, 135)
        Me.C1Label2.Name = "C1Label2"
        Me.C1Label2.Size = New System.Drawing.Size(63, 13)
        Me.C1Label2.TabIndex = 9
        Me.C1Label2.Tag = Nothing
        Me.C1Label2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.C1Label2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmTractosMov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 217)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.C1Label2)
        Me.Controls.Add(Me.tClave)
        Me.Controls.Add(Me.C1Label1)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmTractosMov"
        Me.Text = "Movimientos"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDescr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
    Friend WithEvents tClave As C1.Win.C1Input.C1TextBox
    Friend WithEvents tDescr As C1.Win.C1Input.C1TextBox
    Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
End Class
