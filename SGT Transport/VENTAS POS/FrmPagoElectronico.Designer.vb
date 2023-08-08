<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagoElectronico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoElectronico))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnConexExitosa = New C1.Win.C1Input.C1Button()
        Me.BtnConexionTerminal = New C1.Win.C1Input.C1Button()
        Me.LtImporte = New C1.Win.C1Input.C1Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.BtnConexExitosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnConexionTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(460, 42)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "PAGO ELECTRONICO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(122, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(227, 22)
        Me.Label10.TabIndex = 382
        Me.Label10.Text = "por favor Inserte tarjeta"
        '
        'BtnConexExitosa
        '
        Me.BtnConexExitosa.BackColor = System.Drawing.Color.White
        Me.BtnConexExitosa.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnConexExitosa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConexExitosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConexExitosa.Image = Global.SGT_Transport.My.Resources.Resources.terminal6
        Me.BtnConexExitosa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConexExitosa.Location = New System.Drawing.Point(114, 279)
        Me.BtnConexExitosa.Name = "BtnConexExitosa"
        Me.BtnConexExitosa.Size = New System.Drawing.Size(235, 52)
        Me.BtnConexExitosa.TabIndex = 384
        Me.BtnConexExitosa.Text = "Conección exitosa"
        Me.BtnConexExitosa.UseVisualStyleBackColor = False
        Me.BtnConexExitosa.Visible = False
        '
        'BtnConexionTerminal
        '
        Me.BtnConexionTerminal.BackColor = System.Drawing.Color.White
        Me.BtnConexionTerminal.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnConexionTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConexionTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConexionTerminal.Image = Global.SGT_Transport.My.Resources.Resources.terminal5
        Me.BtnConexionTerminal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConexionTerminal.Location = New System.Drawing.Point(114, 147)
        Me.BtnConexionTerminal.Name = "BtnConexionTerminal"
        Me.BtnConexionTerminal.Size = New System.Drawing.Size(235, 52)
        Me.BtnConexionTerminal.TabIndex = 383
        Me.BtnConexionTerminal.Text = "Conectar con terminal bancaria"
        Me.BtnConexionTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConexionTerminal.UseVisualStyleBackColor = False
        '
        'LtImporte
        '
        Me.LtImporte.BackColor = System.Drawing.Color.White
        Me.LtImporte.BorderColor = System.Drawing.Color.Blue
        Me.LtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporte.Location = New System.Drawing.Point(114, 69)
        Me.LtImporte.Name = "LtImporte"
        Me.LtImporte.Size = New System.Drawing.Size(235, 41)
        Me.LtImporte.TabIndex = 386
        Me.LtImporte.Tag = Nothing
        Me.LtImporte.Text = "0.00"
        Me.LtImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LtImporte.TextDetached = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(27, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 22)
        Me.Label12.TabIndex = 385
        Me.Label12.Text = "Importe"
        '
        'FrmPagoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 377)
        Me.Controls.Add(Me.LtImporte)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BtnConexExitosa)
        Me.Controls.Add(Me.BtnConexionTerminal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagoElectronico"
        Me.ShowInTaskbar = False
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
        CType(Me.BtnConexExitosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnConexionTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnConexionTerminal As C1.Win.C1Input.C1Button
    Friend WithEvents BtnConexExitosa As C1.Win.C1Input.C1Button
    Friend WithEvents LtImporte As C1.Win.C1Input.C1Label
    Friend WithEvents Label12 As Label
End Class
