<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGastosTotales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGastosTotales))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtSubtotal = New System.Windows.Forms.Label()
        Me.LtIeps = New System.Windows.Forms.Label()
        Me.LtDesc = New System.Windows.Forms.Label()
        Me.LtDesFin = New System.Windows.Forms.Label()
        Me.LtIVA = New System.Windows.Forms.Label()
        Me.LtImpu3 = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.LtImpu2 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sub-total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desc. financiero"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "I.E.P.S."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descuento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "I.V.A."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total compra"
        '
        'LtSubtotal
        '
        Me.LtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSubtotal.Location = New System.Drawing.Point(145, 18)
        Me.LtSubtotal.Name = "LtSubtotal"
        Me.LtSubtotal.Size = New System.Drawing.Size(160, 22)
        Me.LtSubtotal.TabIndex = 6
        Me.LtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIeps
        '
        Me.LtIeps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIeps.Location = New System.Drawing.Point(145, 93)
        Me.LtIeps.Name = "LtIeps"
        Me.LtIeps.Size = New System.Drawing.Size(160, 22)
        Me.LtIeps.TabIndex = 7
        Me.LtIeps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDesc
        '
        Me.LtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDesc.Location = New System.Drawing.Point(145, 43)
        Me.LtDesc.Name = "LtDesc"
        Me.LtDesc.Size = New System.Drawing.Size(160, 22)
        Me.LtDesc.TabIndex = 8
        Me.LtDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDesFin
        '
        Me.LtDesFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDesFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDesFin.Location = New System.Drawing.Point(145, 68)
        Me.LtDesFin.Name = "LtDesFin"
        Me.LtDesFin.Size = New System.Drawing.Size(160, 22)
        Me.LtDesFin.TabIndex = 9
        Me.LtDesFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIVA
        '
        Me.LtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtIVA.Location = New System.Drawing.Point(145, 168)
        Me.LtIVA.Name = "LtIVA"
        Me.LtIVA.Size = New System.Drawing.Size(160, 22)
        Me.LtIVA.TabIndex = 13
        Me.LtIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtImpu3
        '
        Me.LtImpu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImpu3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImpu3.Location = New System.Drawing.Point(145, 143)
        Me.LtImpu3.Name = "LtImpu3"
        Me.LtImpu3.Size = New System.Drawing.Size(160, 22)
        Me.LtImpu3.TabIndex = 12
        Me.LtImpu3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtTotal
        '
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.Location = New System.Drawing.Point(145, 193)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(160, 22)
        Me.LtTotal.TabIndex = 11
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtImpu2
        '
        Me.LtImpu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImpu2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImpu2.Location = New System.Drawing.Point(145, 118)
        Me.LtImpu2.Name = "LtImpu2"
        Me.LtImpu2.Size = New System.Drawing.Size(160, 22)
        Me.LtImpu2.TabIndex = 10
        Me.LtImpu2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(65, 249)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 30)
        Me.btnGrabar.TabIndex = 14
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(193, 249)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Tag = ""
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(22, 122)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(0, 17)
        Me.Lt1.TabIndex = 16
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(22, 147)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(0, 17)
        Me.Lt2.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "RET. ISR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "RET. IVA"
        '
        'FrmGastosTotales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 303)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.LtIVA)
        Me.Controls.Add(Me.LtImpu3)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.LtImpu2)
        Me.Controls.Add(Me.LtDesFin)
        Me.Controls.Add(Me.LtDesc)
        Me.Controls.Add(Me.LtIeps)
        Me.Controls.Add(Me.LtSubtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGastosTotales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Totales"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtSubtotal As Label
    Friend WithEvents LtIeps As Label
    Friend WithEvents LtDesc As Label
    Friend WithEvents LtDesFin As Label
    Friend WithEvents LtIVA As Label
    Friend WithEvents LtImpu3 As Label
    Friend WithEvents LtTotal As Label
    Friend WithEvents LtImpu2 As Label
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
