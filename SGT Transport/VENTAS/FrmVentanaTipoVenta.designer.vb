<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentanaTipoVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVentanaTipoVenta))
        Me.radContado = New System.Windows.Forms.RadioButton()
        Me.radCredito = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New C1.Win.C1Input.C1Button()
        Me.btnCancelar = New C1.Win.C1Input.C1Button()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'radContado
        '
        Me.radContado.AutoSize = True
        Me.radContado.BackColor = System.Drawing.Color.Transparent
        Me.radContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radContado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radContado.Location = New System.Drawing.Point(77, 32)
        Me.radContado.Name = "radContado"
        Me.radContado.Size = New System.Drawing.Size(79, 21)
        Me.radContado.TabIndex = 0
        Me.radContado.TabStop = True
        Me.radContado.Text = "Contado"
        Me.C1ThemeController1.SetTheme(Me.radContado, "Office2010Blue")
        Me.radContado.UseVisualStyleBackColor = False
        '
        'radCredito
        '
        Me.radCredito.AutoSize = True
        Me.radCredito.BackColor = System.Drawing.Color.Transparent
        Me.radCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.radCredito.Location = New System.Drawing.Point(77, 86)
        Me.radCredito.Name = "radCredito"
        Me.radCredito.Size = New System.Drawing.Size(71, 21)
        Me.radCredito.TabIndex = 1
        Me.radCredito.TabStop = True
        Me.radCredito.Text = "Crédito"
        Me.C1ThemeController1.SetTheme(Me.radCredito, "Office2010Blue")
        Me.radCredito.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(35, 186)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.C1ThemeController1.SetTheme(Me.btnAceptar, "Office2010Blue")
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(131, 186)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.C1ThemeController1.SetTheme(Me.btnCancelar, "Office2010Blue")
        Me.btnCancelar.UseVisualStyleBackColor = True
        Me.btnCancelar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'frmVentanaTipoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 251)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.radCredito)
        Me.Controls.Add(Me.radContado)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentanaTipoVenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione forma de pago"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents radContado As RadioButton
    Friend WithEvents radCredito As RadioButton
    Friend WithEvents btnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents btnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
End Class
