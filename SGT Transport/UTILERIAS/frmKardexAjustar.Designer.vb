<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardexAjustar
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
        Me.BtnAjustarKardex = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCVE_ART = New System.Windows.Forms.TextBox()
        Me.btnSalir = New C1.Win.C1Input.C1Button()
        Me.btAjustarExistViaKardex = New C1.Win.C1Input.C1Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.BtnArt = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnKardex = New C1.Win.C1Input.C1Button()
        CType(Me.BtnAjustarKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btAjustarExistViaKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAjustarKardex
        '
        Me.BtnAjustarKardex.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAjustarKardex.Location = New System.Drawing.Point(77, 24)
        Me.BtnAjustarKardex.Name = "BtnAjustarKardex"
        Me.BtnAjustarKardex.Size = New System.Drawing.Size(137, 45)
        Me.BtnAjustarKardex.TabIndex = 0
        Me.BtnAjustarKardex.Text = "Ajustar kardex"
        Me.BtnAjustarKardex.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Articulo"
        '
        'tCVE_ART
        '
        Me.tCVE_ART.Location = New System.Drawing.Point(102, 184)
        Me.tCVE_ART.Name = "tCVE_ART"
        Me.tCVE_ART.Size = New System.Drawing.Size(162, 20)
        Me.tCVE_ART.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(311, 24)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(92, 33)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btAjustarExistViaKardex
        '
        Me.btAjustarExistViaKardex.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAjustarExistViaKardex.Location = New System.Drawing.Point(77, 103)
        Me.btAjustarExistViaKardex.Name = "btAjustarExistViaKardex"
        Me.btAjustarExistViaKardex.Size = New System.Drawing.Size(137, 45)
        Me.btAjustarExistViaKardex.TabIndex = 4
        Me.btAjustarExistViaKardex.Text = "Ajustar existencia via kardex"
        Me.btAjustarExistViaKardex.UseVisualStyleBackColor = True
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.LightGray
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(102, 216)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(337, 20)
        Me.L1.TabIndex = 411
        '
        'BtnArt
        '
        Me.BtnArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArt.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.BtnArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnArt.Location = New System.Drawing.Point(265, 184)
        Me.BtnArt.Name = "BtnArt"
        Me.BtnArt.Size = New System.Drawing.Size(23, 20)
        Me.BtnArt.TabIndex = 410
        Me.BtnArt.UseVisualStyleBackColor = True
        Me.BtnArt.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.BtnArt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 412
        Me.Label2.Text = "Desceripcion"
        '
        'btnKardex
        '
        Me.btnKardex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKardex.Location = New System.Drawing.Point(383, 182)
        Me.btnKardex.Name = "btnKardex"
        Me.btnKardex.Size = New System.Drawing.Size(56, 28)
        Me.btnKardex.TabIndex = 413
        Me.btnKardex.Text = "Kardex"
        Me.btnKardex.UseVisualStyleBackColor = True
        '
        'frmKardexAjustar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 245)
        Me.Controls.Add(Me.btnKardex)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.BtnArt)
        Me.Controls.Add(Me.btAjustarExistViaKardex)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.tCVE_ART)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAjustarKardex)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKardexAjustar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kardex Ajustar"
        CType(Me.BtnAjustarKardex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSalir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btAjustarExistViaKardex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnKardex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAjustarKardex As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tCVE_ART As TextBox
    Friend WithEvents btnSalir As C1.Win.C1Input.C1Button
    Friend WithEvents btAjustarExistViaKardex As C1.Win.C1Input.C1Button
    Friend WithEvents L1 As Label
    Friend WithEvents BtnArt As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnKardex As C1.Win.C1Input.C1Button
End Class
