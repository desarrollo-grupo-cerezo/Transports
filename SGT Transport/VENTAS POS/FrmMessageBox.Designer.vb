<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMessageBox))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New C1.Win.C1Input.C1Button()
        Me.LtTitulo = New System.Windows.Forms.Label()
        Me.LtMesage = New System.Windows.Forms.Label()
        Me.BtnOK = New C1.Win.C1Input.C1Button()
        Me.Panel1.SuspendLayout()
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCerrar)
        Me.Panel1.Controls.Add(Me.LtTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 35)
        Me.Panel1.TabIndex = 0
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnCerrar.FlatAppearance.BorderSize = 0
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar__1_
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(293, 0)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(37, 35)
        Me.BtnCerrar.TabIndex = 9
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'LtTitulo
        '
        Me.LtTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTitulo.ForeColor = System.Drawing.Color.White
        Me.LtTitulo.Location = New System.Drawing.Point(14, 6)
        Me.LtTitulo.Name = "LtTitulo"
        Me.LtTitulo.Size = New System.Drawing.Size(261, 20)
        Me.LtTitulo.TabIndex = 9
        '
        'LtMesage
        '
        Me.LtMesage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMesage.Location = New System.Drawing.Point(8, 44)
        Me.LtMesage.Name = "LtMesage"
        Me.LtMesage.Size = New System.Drawing.Size(310, 52)
        Me.LtMesage.TabIndex = 8
        Me.LtMesage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.Color.White
        Me.BtnOK.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.Image = Global.SGT_Transport.My.Resources.Resources.mano1
        Me.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK.Location = New System.Drawing.Point(180, 114)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(100, 32)
        Me.BtnOK.TabIndex = 7
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'FrmMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 160)
        Me.Controls.Add(Me.LtMesage)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMessageBox"
        Me.ShowInTaskbar = False
        Me.Text = "FrmMessageBox"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Blue
        Me.Panel1.ResumeLayout(False)
        CType(Me.BtnCerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnOK As C1.Win.C1Input.C1Button
    Friend WithEvents LtTitulo As Label
    Friend WithEvents LtMesage As Label
    Friend WithEvents BtnCerrar As C1.Win.C1Input.C1Button
End Class
