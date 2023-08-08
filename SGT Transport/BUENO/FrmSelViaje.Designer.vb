<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelViaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelViaje))
        Me.TCVE_VIAJE = New C1.Win.C1Input.C1TextBox()
        Me.Lt3 = New C1.Win.C1Input.C1Label()
        Me.BtnSelViaje = New C1.Win.C1Input.C1Button()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.TNUM_VIAJES_COPIAR = New C1.Win.C1Input.C1NumericEdit()
        Me.Lt1 = New C1.Win.C1Input.C1Label()
        Me.Lt2 = New C1.Win.C1Input.C1Label()
        Me.TCVE_DOC = New C1.Win.C1Input.C1TextBox()
        Me.BtnFactura = New C1.Win.C1Input.C1Button()
        CType(Me.TCVE_VIAJE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSelViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_VIAJES_COPIAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_DOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCVE_VIAJE
        '
        Me.TCVE_VIAJE.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TCVE_VIAJE.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCVE_VIAJE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_VIAJE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_VIAJE.Location = New System.Drawing.Point(168, 41)
        Me.TCVE_VIAJE.Name = "TCVE_VIAJE"
        Me.TCVE_VIAJE.Size = New System.Drawing.Size(106, 20)
        Me.TCVE_VIAJE.TabIndex = 0
        Me.TCVE_VIAJE.Tag = Nothing
        Me.TCVE_VIAJE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.BackColor = System.Drawing.Color.Transparent
        Me.Lt3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.ForeColor = System.Drawing.Color.Black
        Me.Lt3.Location = New System.Drawing.Point(36, 44)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(107, 16)
        Me.Lt3.TabIndex = 1
        Me.Lt3.Tag = Nothing
        Me.Lt3.Text = "Seleccione viaje"
        Me.Lt3.TextDetached = True
        '
        'BtnSelViaje
        '
        Me.BtnSelViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelViaje.Image = CType(resources.GetObject("BtnSelViaje.Image"), System.Drawing.Image)
        Me.BtnSelViaje.Location = New System.Drawing.Point(280, 40)
        Me.BtnSelViaje.Name = "BtnSelViaje"
        Me.BtnSelViaje.Size = New System.Drawing.Size(24, 22)
        Me.BtnSelViaje.TabIndex = 197
        Me.BtnSelViaje.UseVisualStyleBackColor = True
        Me.BtnSelViaje.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(73, 156)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(111, 31)
        Me.BtnAceptar.TabIndex = 198
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(220, 156)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(111, 31)
        Me.BtnCancelar.TabIndex = 199
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'TNUM_VIAJES_COPIAR
        '
        Me.TNUM_VIAJES_COPIAR.BackColor = System.Drawing.Color.Transparent
        Me.TNUM_VIAJES_COPIAR.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TNUM_VIAJES_COPIAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TNUM_VIAJES_COPIAR.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TNUM_VIAJES_COPIAR.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TNUM_VIAJES_COPIAR.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TNUM_VIAJES_COPIAR.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TNUM_VIAJES_COPIAR.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TNUM_VIAJES_COPIAR.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.TNUM_VIAJES_COPIAR.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TNUM_VIAJES_COPIAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_VIAJES_COPIAR.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TNUM_VIAJES_COPIAR.InterceptArrowKeys = False
        Me.TNUM_VIAJES_COPIAR.Location = New System.Drawing.Point(168, 87)
        Me.TNUM_VIAJES_COPIAR.Name = "TNUM_VIAJES_COPIAR"
        Me.TNUM_VIAJES_COPIAR.Size = New System.Drawing.Size(48, 20)
        Me.TNUM_VIAJES_COPIAR.TabIndex = 658
        Me.TNUM_VIAJES_COPIAR.Tag = Nothing
        Me.TNUM_VIAJES_COPIAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TNUM_VIAJES_COPIAR.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TNUM_VIAJES_COPIAR.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TNUM_VIAJES_COPIAR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.Transparent
        Me.Lt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.Black
        Me.Lt1.Location = New System.Drawing.Point(36, 89)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(129, 16)
        Me.Lt1.TabIndex = 659
        Me.Lt1.Tag = Nothing
        Me.Lt1.Text = "Núm. viajes a copiar"
        Me.Lt1.TextDetached = True
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.Transparent
        Me.Lt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.ForeColor = System.Drawing.Color.Black
        Me.Lt2.Location = New System.Drawing.Point(36, 116)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(118, 16)
        Me.Lt2.TabIndex = 661
        Me.Lt2.Tag = Nothing
        Me.Lt2.Text = "Seleccione factura"
        Me.Lt2.TextDetached = True
        Me.Lt2.Visible = False
        '
        'TCVE_DOC
        '
        Me.TCVE_DOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TCVE_DOC.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DOC.Location = New System.Drawing.Point(168, 113)
        Me.TCVE_DOC.Name = "TCVE_DOC"
        Me.TCVE_DOC.Size = New System.Drawing.Size(106, 20)
        Me.TCVE_DOC.TabIndex = 660
        Me.TCVE_DOC.Tag = Nothing
        Me.TCVE_DOC.Visible = False
        Me.TCVE_DOC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BtnFactura
        '
        Me.BtnFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFactura.Image = CType(resources.GetObject("BtnFactura.Image"), System.Drawing.Image)
        Me.BtnFactura.Location = New System.Drawing.Point(280, 114)
        Me.BtnFactura.Name = "BtnFactura"
        Me.BtnFactura.Size = New System.Drawing.Size(24, 22)
        Me.BtnFactura.TabIndex = 662
        Me.BtnFactura.UseVisualStyleBackColor = True
        Me.BtnFactura.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmSelViaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 222)
        Me.Controls.Add(Me.BtnFactura)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.TCVE_DOC)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.TNUM_VIAJES_COPIAR)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnSelViaje)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.TCVE_VIAJE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelViaje"
        Me.Text = "Seleccione el viaje"
        CType(Me.TCVE_VIAJE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSelViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_VIAJES_COPIAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_DOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TCVE_VIAJE As C1.Win.C1Input.C1TextBox
    Friend WithEvents Lt3 As C1.Win.C1Input.C1Label
    Friend WithEvents BtnSelViaje As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents TNUM_VIAJES_COPIAR As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Lt1 As C1.Win.C1Input.C1Label
    Friend WithEvents Lt2 As C1.Win.C1Input.C1Label
    Friend WithEvents TCVE_DOC As C1.Win.C1Input.C1TextBox
    Friend WithEvents BtnFactura As C1.Win.C1Input.C1Button
End Class
