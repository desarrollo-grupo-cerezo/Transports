<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuitarCaracEspeciales
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
        Me.btnAceptar = New C1.Win.C1Input.C1Button()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.BtnMinve = New C1.Win.C1Input.C1Button()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnMinve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(58, 185)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(93, 39)
        Me.btnAceptar.TabIndex = 76
        Me.btnAceptar.Text = "Iniciar proceso"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.Black
        Me.Lt1.Location = New System.Drawing.Point(124, 28)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(147, 15)
        Me.Lt1.TabIndex = 78
        Me.Lt1.Text = "____________________"
        Me.Lt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.Black
        Me.Lt2.Location = New System.Drawing.Point(77, 117)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(224, 15)
        Me.Lt2.TabIndex = 77
        Me.Lt2.Text = "_______________________________"
        Me.Lt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(199, 185)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(93, 39)
        Me.BtnCancelar.TabIndex = 79
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.Black
        Me.Lt3.Location = New System.Drawing.Point(124, 73)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(147, 15)
        Me.Lt3.TabIndex = 80
        Me.Lt3.Text = "____________________"
        Me.Lt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnMinve
        '
        Me.BtnMinve.Location = New System.Drawing.Point(340, 185)
        Me.BtnMinve.Name = "BtnMinve"
        Me.BtnMinve.Size = New System.Drawing.Size(93, 39)
        Me.BtnMinve.TabIndex = 81
        Me.BtnMinve.Text = "Iniciar proceso MINVE"
        Me.BtnMinve.UseVisualStyleBackColor = True
        '
        'frmQuitarCaracEspeciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 249)
        Me.Controls.Add(Me.BtnMinve)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "frmQuitarCaracEspeciales"
        Me.Text = "Quitar Caracacteres Especiales en inventario"
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnMinve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents Lt3 As Label
    Friend WithEvents BtnMinve As C1.Win.C1Input.C1Button
End Class
