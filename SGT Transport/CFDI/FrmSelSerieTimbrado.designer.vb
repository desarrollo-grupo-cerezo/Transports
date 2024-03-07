<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelSerieTimbrado
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelSerieTimbrado))
        Me.Lt3 = New C1.Win.C1Input.C1Label()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.CboSerie = New C1.Win.C1Input.C1ComboBox()
        CType(Me.Lt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.Transparent
        Me.Lt3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.Black
        Me.Lt3.Location = New System.Drawing.Point(12, 25)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(122, 16)
        Me.Lt3.TabIndex = 1
        Me.Lt3.Tag = Nothing
        Me.Lt3.Text = "Seleccione la serie"
        Me.Lt3.TextDetached = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(23, 69)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(111, 31)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(187, 69)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(111, 31)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'CboSerie
        '
        Me.CboSerie.AllowSpinLoop = False
        Me.CboSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerie.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerie.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerie.DropDownWidth = 450
        Me.CboSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerie.GapHeight = 0
        Me.CboSerie.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerie.ItemsDisplayMember = ""
        Me.CboSerie.ItemsValueMember = ""
        Me.CboSerie.Location = New System.Drawing.Point(162, 23)
        Me.CboSerie.Name = "CboSerie"
        Me.CboSerie.Size = New System.Drawing.Size(136, 20)
        Me.CboSerie.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboSerie.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboSerie.TabIndex = 578
        Me.CboSerie.Tag = Nothing
        Me.CboSerie.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboSerie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmSelSerieTimbrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 120)
        Me.Controls.Add(Me.CboSerie)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Lt3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelSerieTimbrado"
        Me.Text = "Serie de Timbrado"
        CType(Me.Lt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lt3 As C1.Win.C1Input.C1Label
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents CboSerie As C1.Win.C1Input.C1ComboBox
End Class
