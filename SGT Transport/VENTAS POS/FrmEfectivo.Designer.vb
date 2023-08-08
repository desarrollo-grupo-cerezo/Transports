<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEfectivo
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEfectivo))
        Me.LtImporteTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TIMPORTE_RECIBIDO = New C1.Win.C1Input.C1TextBox()
        Me.LtCambio = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        CType(Me.TIMPORTE_RECIBIDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LtImporteTotal
        '
        Me.LtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporteTotal.Location = New System.Drawing.Point(161, 46)
        Me.LtImporteTotal.Name = "LtImporteTotal"
        Me.LtImporteTotal.Size = New System.Drawing.Size(130, 20)
        Me.LtImporteTotal.TabIndex = 357
        Me.LtImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(80, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 356
        Me.Label12.Text = "Importe total"
        '
        'TIMPORTE_RECIBIDO
        '
        Me.TIMPORTE_RECIBIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE_RECIBIDO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE_RECIBIDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIMPORTE_RECIBIDO.CustomFormat = "###,###,##0.000"
        Me.TIMPORTE_RECIBIDO.DataType = GetType(Decimal)
        Me.TIMPORTE_RECIBIDO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE_RECIBIDO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TIMPORTE_RECIBIDO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE_RECIBIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE_RECIBIDO.Location = New System.Drawing.Point(161, 71)
        Me.TIMPORTE_RECIBIDO.MarkEmpty = True
        Me.TIMPORTE_RECIBIDO.Name = "TIMPORTE_RECIBIDO"
        Me.TIMPORTE_RECIBIDO.Size = New System.Drawing.Size(130, 20)
        Me.TIMPORTE_RECIBIDO.TabIndex = 0
        Me.TIMPORTE_RECIBIDO.Tag = Nothing
        Me.TIMPORTE_RECIBIDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE_RECIBIDO.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TIMPORTE_RECIBIDO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCambio
        '
        Me.LtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCambio.Location = New System.Drawing.Point(161, 96)
        Me.LtCambio.Name = "LtCambio"
        Me.LtCambio.Size = New System.Drawing.Size(130, 20)
        Me.LtCambio.TabIndex = 355
        Me.LtCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(106, 96)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(54, 16)
        Me.Lt2.TabIndex = 354
        Me.Lt2.Text = "Cambio"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(56, 73)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(104, 16)
        Me.Lt1.TabIndex = 353
        Me.Lt1.Text = "Importe recibido"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(57, 171)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(103, 36)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(232, 171)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(103, 36)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'FrmEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 225)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LtImporteTotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TIMPORTE_RECIBIDO)
        Me.Controls.Add(Me.LtCambio)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEfectivo"
        Me.Text = "Captura Efectivo"
        CType(Me.TIMPORTE_RECIBIDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LtImporteTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TIMPORTE_RECIBIDO As C1.Win.C1Input.C1TextBox
    Friend WithEvents LtCambio As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
End Class
