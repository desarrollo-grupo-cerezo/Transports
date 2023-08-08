<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectPrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectPrinter))
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.CboPrinter = New C1.Win.C1Input.C1ComboBox()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(70, 148)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(125, 34)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(224, 148)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(125, 34)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'CboPrinter
        '
        Me.CboPrinter.AllowSpinLoop = False
        Me.CboPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboPrinter.GapHeight = 0
        Me.CboPrinter.ImagePadding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.CboPrinter.ItemsDisplayMember = ""
        Me.CboPrinter.ItemsValueMember = ""
        Me.CboPrinter.Location = New System.Drawing.Point(70, 75)
        Me.CboPrinter.Name = "CboPrinter"
        Me.CboPrinter.Size = New System.Drawing.Size(279, 18)
        Me.CboPrinter.TabIndex = 3
        Me.CboPrinter.Tag = Nothing
        '
        'FrmSelectPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 221)
        Me.Controls.Add(Me.CboPrinter)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSelectPrinter"
        Me.Text = "Seleccione impresora"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Blue
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents CboPrinter As C1.Win.C1Input.C1ComboBox
End Class
