<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedirNumViajesCopiar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedirNumViajesCopiar))
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.TNUM_VIAJES_COPIAR = New C1.Win.C1Input.C1NumericEdit()
        Me.C1Label1 = New C1.Win.C1Input.C1Label()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNUM_VIAJES_COPIAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(204, 126)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(88, 31)
        Me.BtnCancelar.TabIndex = 201
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(57, 126)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(88, 31)
        Me.BtnAceptar.TabIndex = 200
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
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
        Me.TNUM_VIAJES_COPIAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUM_VIAJES_COPIAR.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TNUM_VIAJES_COPIAR.InterceptArrowKeys = False
        Me.TNUM_VIAJES_COPIAR.Location = New System.Drawing.Point(139, 73)
        Me.TNUM_VIAJES_COPIAR.Name = "TNUM_VIAJES_COPIAR"
        Me.TNUM_VIAJES_COPIAR.ReadOnly = True
        Me.TNUM_VIAJES_COPIAR.Size = New System.Drawing.Size(66, 19)
        Me.TNUM_VIAJES_COPIAR.TabIndex = 656
        Me.TNUM_VIAJES_COPIAR.Tag = Nothing
        Me.TNUM_VIAJES_COPIAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TNUM_VIAJES_COPIAR.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TNUM_VIAJES_COPIAR.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TNUM_VIAJES_COPIAR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1Label1
        '
        Me.C1Label1.AutoSize = True
        Me.C1Label1.BackColor = System.Drawing.Color.Transparent
        Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Label1.ForeColor = System.Drawing.Color.Black
        Me.C1Label1.Location = New System.Drawing.Point(93, 38)
        Me.C1Label1.Name = "C1Label1"
        Me.C1Label1.Size = New System.Drawing.Size(173, 17)
        Me.C1Label1.TabIndex = 657
        Me.C1Label1.Tag = Nothing
        Me.C1Label1.Text = "Número de viajes a copiar"
        Me.C1Label1.TextDetached = True
        '
        'FrmPedirNumViajesCopiar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 182)
        Me.Controls.Add(Me.C1Label1)
        Me.Controls.Add(Me.TNUM_VIAJES_COPIAR)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPedirNumViajesCopiar"
        Me.Text = "Numero de viajes a copiar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Blue
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNUM_VIAJES_COPIAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents TNUM_VIAJES_COPIAR As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
End Class
