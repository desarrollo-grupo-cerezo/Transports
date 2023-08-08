<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelFactura
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelFactura))
        Me.TCVE_DOC = New C1.Win.C1Input.C1TextBox()
        Me.C1Label1 = New C1.Win.C1Input.C1Label()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.TACEPTAR = New C1.Win.C1Input.C1Button()
        Me.TCANCELAR = New C1.Win.C1Input.C1Button()
        CType(Me.TCVE_DOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TACEPTAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCANCELAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCVE_DOC
        '
        Me.TCVE_DOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TCVE_DOC.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DOC.Location = New System.Drawing.Point(150, 53)
        Me.TCVE_DOC.Name = "TCVE_DOC"
        Me.TCVE_DOC.Size = New System.Drawing.Size(106, 21)
        Me.TCVE_DOC.TabIndex = 0
        Me.TCVE_DOC.Tag = Nothing
        Me.TCVE_DOC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Label1
        '
        Me.C1Label1.AutoSize = True
        Me.C1Label1.BackColor = System.Drawing.Color.Transparent
        Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Label1.ForeColor = System.Drawing.Color.Black
        Me.C1Label1.Location = New System.Drawing.Point(21, 54)
        Me.C1Label1.Name = "C1Label1"
        Me.C1Label1.Size = New System.Drawing.Size(125, 17)
        Me.C1Label1.TabIndex = 1
        Me.C1Label1.Tag = Nothing
        Me.C1Label1.Text = "Seleccione factura"
        Me.C1Label1.TextDetached = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnAceptar.Location = New System.Drawing.Point(259, 53)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(24, 22)
        Me.BtnAceptar.TabIndex = 197
        Me.BtnAceptar.UseVisualStyleBackColor = True
        Me.BtnAceptar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TACEPTAR
        '
        Me.TACEPTAR.Location = New System.Drawing.Point(62, 148)
        Me.TACEPTAR.Name = "TACEPTAR"
        Me.TACEPTAR.Size = New System.Drawing.Size(111, 31)
        Me.TACEPTAR.TabIndex = 198
        Me.TACEPTAR.Text = "Aceptar"
        Me.TACEPTAR.UseVisualStyleBackColor = True
        '
        'TCANCELAR
        '
        Me.TCANCELAR.Location = New System.Drawing.Point(209, 148)
        Me.TCANCELAR.Name = "TCANCELAR"
        Me.TCANCELAR.Size = New System.Drawing.Size(111, 31)
        Me.TCANCELAR.TabIndex = 199
        Me.TCANCELAR.Text = "Cancelar"
        Me.TCANCELAR.UseVisualStyleBackColor = True
        '
        'FrmSelFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 206)
        Me.Controls.Add(Me.TCANCELAR)
        Me.Controls.Add(Me.TACEPTAR)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.C1Label1)
        Me.Controls.Add(Me.TCVE_DOC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelFactura"
        Me.Text = "Seleccione factura"
        CType(Me.TCVE_DOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TACEPTAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCANCELAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCVE_DOC As C1.Win.C1Input.C1TextBox
    Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents TACEPTAR As C1.Win.C1Input.C1Button
    Friend WithEvents TCANCELAR As C1.Win.C1Input.C1Button
End Class
