<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TUSUARIO = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LtOk = New System.Windows.Forms.Label()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture
        '
        Me.Picture.BackColor = System.Drawing.SystemColors.Window
        Me.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture.Location = New System.Drawing.Point(130, 28)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(213, 257)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture.TabIndex = 24
        Me.Picture.TabStop = False
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(127, 9)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(225, 17)
        Me.Lt1.TabIndex = 25
        Me.Lt1.Text = "Coloque el dedo para verificar huella"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Usuario"
        '
        'TUSUARIO
        '
        Me.TUSUARIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUSUARIO.Enabled = False
        Me.TUSUARIO.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUSUARIO.Location = New System.Drawing.Point(130, 291)
        Me.TUSUARIO.Name = "TUSUARIO"
        Me.TUSUARIO.ReadOnly = True
        Me.TUSUARIO.Size = New System.Drawing.Size(213, 25)
        Me.TUSUARIO.TabIndex = 34
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 369)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(449, 23)
        Me.ProgressBar1.TabIndex = 36
        '
        'LtOk
        '
        Me.LtOk.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOk.Location = New System.Drawing.Point(98, 330)
        Me.LtOk.Name = "LtOk"
        Me.LtOk.Size = New System.Drawing.Size(271, 21)
        Me.LtOk.TabIndex = 37
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(477, 397)
        Me.Controls.Add(Me.LtOk)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TUSUARIO)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Picture)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificar huella dactilar"
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Picture As System.Windows.Forms.PictureBox
    Friend WithEvents Lt1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TUSUARIO As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LtOk As Label
End Class
