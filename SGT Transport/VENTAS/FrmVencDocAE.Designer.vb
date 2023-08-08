<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVencDocAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVencDocAE))
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tBox1 = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New C1.Win.C1Input.C1Button()
        Me.btnCancelar = New C1.Win.C1Input.C1Button()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(117, 81)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(147, 19)
        Me.F1.TabIndex = 2
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Location = New System.Drawing.Point(76, 83)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(37, 13)
        Me.Label41.TabIndex = 134
        Me.Label41.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(69, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Nombre"
        '
        'tBox2
        '
        Me.tBox2.AcceptsReturn = True
        Me.tBox2.AcceptsTab = True
        Me.tBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBox2.Location = New System.Drawing.Point(117, 55)
        Me.tBox2.Name = "tBox2"
        Me.tBox2.Size = New System.Drawing.Size(394, 20)
        Me.tBox2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(51, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Documento"
        '
        'tBox1
        '
        Me.tBox1.AcceptsReturn = True
        Me.tBox1.AcceptsTab = True
        Me.tBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBox1.Location = New System.Drawing.Point(117, 32)
        Me.tBox1.Name = "tBox1"
        Me.tBox1.Size = New System.Drawing.Size(394, 20)
        Me.tBox1.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(163, 154)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(282, 154)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'FrmVencDocAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 215)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVencDocAE"
        Me.ShowInTaskbar = False
        Me.Text = "Captura de Vencimiento de documento"
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents btnCancelar As C1.Win.C1Input.C1Button
End Class
