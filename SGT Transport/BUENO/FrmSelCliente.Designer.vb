<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelCliente
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelCliente))
        Me.TCLIENTE = New C1.Win.C1Input.C1TextBox()
        Me.C1Label1 = New C1.Win.C1Input.C1Label()
        Me.BtnCliente = New C1.Win.C1Input.C1Button()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.C1Label2 = New C1.Win.C1Input.C1Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        CType(Me.TCLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCLIENTE
        '
        Me.TCLIENTE.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TCLIENTE.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(79, 45)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(106, 21)
        Me.TCLIENTE.TabIndex = 0
        Me.TCLIENTE.Tag = Nothing
        Me.TCLIENTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Label1
        '
        Me.C1Label1.AutoSize = True
        Me.C1Label1.BackColor = System.Drawing.Color.Transparent
        Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Label1.ForeColor = System.Drawing.Color.Black
        Me.C1Label1.Location = New System.Drawing.Point(24, 45)
        Me.C1Label1.Name = "C1Label1"
        Me.C1Label1.Size = New System.Drawing.Size(51, 17)
        Me.C1Label1.TabIndex = 1
        Me.C1Label1.Tag = Nothing
        Me.C1Label1.Text = "Cliente"
        Me.C1Label1.TextDetached = True
        '
        'BtnCliente
        '
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnCliente.Location = New System.Drawing.Point(187, 44)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(24, 22)
        Me.BtnCliente.TabIndex = 197
        Me.BtnCliente.UseVisualStyleBackColor = True
        Me.BtnCliente.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(94, 158)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(88, 31)
        Me.BtnAceptar.TabIndex = 198
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(241, 158)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(88, 31)
        Me.BtnCancelar.TabIndex = 199
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'C1Label2
        '
        Me.C1Label2.AutoSize = True
        Me.C1Label2.BackColor = System.Drawing.Color.Transparent
        Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Label2.ForeColor = System.Drawing.Color.Black
        Me.C1Label2.Location = New System.Drawing.Point(17, 80)
        Me.C1Label2.Name = "C1Label2"
        Me.C1Label2.Size = New System.Drawing.Size(58, 17)
        Me.C1Label2.TabIndex = 200
        Me.C1Label2.Tag = Nothing
        Me.C1Label2.Text = "Nombre"
        Me.C1Label2.TextDetached = True
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(79, 80)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(373, 20)
        Me.LtNombre.TabIndex = 286
        '
        'FrmSelCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 231)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.C1Label2)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.C1Label1)
        Me.Controls.Add(Me.TCLIENTE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelCliente"
        Me.Text = "Seleccione cliente"
        CType(Me.TCLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCLIENTE As C1.Win.C1Input.C1TextBox
    Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
    Friend WithEvents BtnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
    Friend WithEvents LtNombre As Label
End Class
