<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiltroTesoreria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltroTesoreria))
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.chIncluirCanc = New C1.Win.C1Input.C1CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChAceptado = New C1.Win.C1Input.C1CheckBox()
        Me.ChAutorizado = New C1.Win.C1Input.C1CheckBox()
        Me.ChDepositado = New C1.Win.C1Input.C1CheckBox()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chIncluirCanc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChAceptado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChDepositado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(40, 307)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(94, 34)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(164, 307)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(94, 34)
        Me.BtnCancelar.TabIndex = 1
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(160, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Del"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(185, 69)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(95, 20)
        Me.F2.TabIndex = 5
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(62, 67)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(94, 20)
        Me.F1.TabIndex = 4
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chIncluirCanc
        '
        Me.chIncluirCanc.BackColor = System.Drawing.Color.Transparent
        Me.chIncluirCanc.BorderColor = System.Drawing.Color.Transparent
        Me.chIncluirCanc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chIncluirCanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chIncluirCanc.ForeColor = System.Drawing.Color.Black
        Me.chIncluirCanc.Location = New System.Drawing.Point(83, 125)
        Me.chIncluirCanc.Name = "chIncluirCanc"
        Me.chIncluirCanc.Padding = New System.Windows.Forms.Padding(1)
        Me.chIncluirCanc.Size = New System.Drawing.Size(164, 29)
        Me.chIncluirCanc.TabIndex = 8
        Me.chIncluirCanc.Text = "Incluir cancelados"
        Me.chIncluirCanc.UseVisualStyleBackColor = False
        Me.chIncluirCanc.Value = Nothing
        Me.chIncluirCanc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Rango de fechas"
        '
        'ChAceptado
        '
        Me.ChAceptado.BackColor = System.Drawing.Color.Transparent
        Me.ChAceptado.BorderColor = System.Drawing.Color.Transparent
        Me.ChAceptado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChAceptado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChAceptado.ForeColor = System.Drawing.Color.Black
        Me.ChAceptado.Location = New System.Drawing.Point(83, 160)
        Me.ChAceptado.Name = "ChAceptado"
        Me.ChAceptado.Padding = New System.Windows.Forms.Padding(1)
        Me.ChAceptado.Size = New System.Drawing.Size(164, 29)
        Me.ChAceptado.TabIndex = 12
        Me.ChAceptado.Text = "Aceptado"
        Me.ChAceptado.UseVisualStyleBackColor = False
        Me.ChAceptado.Value = Nothing
        Me.ChAceptado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChAutorizado
        '
        Me.ChAutorizado.BackColor = System.Drawing.Color.Transparent
        Me.ChAutorizado.BorderColor = System.Drawing.Color.Transparent
        Me.ChAutorizado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChAutorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChAutorizado.ForeColor = System.Drawing.Color.Black
        Me.ChAutorizado.Location = New System.Drawing.Point(83, 195)
        Me.ChAutorizado.Name = "ChAutorizado"
        Me.ChAutorizado.Padding = New System.Windows.Forms.Padding(1)
        Me.ChAutorizado.Size = New System.Drawing.Size(164, 29)
        Me.ChAutorizado.TabIndex = 14
        Me.ChAutorizado.Text = "Autorizado"
        Me.ChAutorizado.UseVisualStyleBackColor = False
        Me.ChAutorizado.Value = Nothing
        Me.ChAutorizado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ChDepositado
        '
        Me.ChDepositado.BackColor = System.Drawing.Color.Transparent
        Me.ChDepositado.BorderColor = System.Drawing.Color.Transparent
        Me.ChDepositado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChDepositado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDepositado.ForeColor = System.Drawing.Color.Black
        Me.ChDepositado.Location = New System.Drawing.Point(83, 230)
        Me.ChDepositado.Name = "ChDepositado"
        Me.ChDepositado.Padding = New System.Windows.Forms.Padding(1)
        Me.ChDepositado.Size = New System.Drawing.Size(164, 29)
        Me.ChDepositado.TabIndex = 13
        Me.ChDepositado.Text = "Depositado"
        Me.ChDepositado.UseVisualStyleBackColor = False
        Me.ChDepositado.Value = Nothing
        Me.ChDepositado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FrmFiltroTesoreria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 366)
        Me.Controls.Add(Me.ChAutorizado)
        Me.Controls.Add(Me.ChDepositado)
        Me.Controls.Add(Me.ChAceptado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chIncluirCanc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiltroTesoreria"
        Me.Text = "Filtro gastos de viaje"
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chIncluirCanc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChAceptado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChDepositado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents chIncluirCanc As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ChAceptado As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChAutorizado As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChDepositado As C1.Win.C1Input.C1CheckBox
End Class
