<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmObserDocumento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmObserDocumento))
        Me.TObser = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        Me.C1SplitterPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TObser
        '
        Me.TObser.AcceptsReturn = True
        Me.TObser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TObser.Location = New System.Drawing.Point(0, 0)
        Me.TObser.Multiline = True
        Me.TObser.Name = "TObser"
        Me.TObser.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TObser.Size = New System.Drawing.Size(693, 279)
        Me.TObser.TabIndex = 0
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(359, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(212, 4)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(89, 26)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(695, 325)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.C1SplitContainer1.TabIndex = 3
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.BorderColor = System.Drawing.Color.Black
        Me.C1SplitterPanel1.Controls.Add(Me.TObser)
        Me.C1SplitterPanel1.Height = 279
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 1)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(693, 279)
        Me.C1SplitterPanel1.SizeRatio = 90.0R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.BorderColor = System.Drawing.Color.Black
        Me.C1SplitterPanel2.Controls.Add(Me.BtnCancelar)
        Me.C1SplitterPanel2.Controls.Add(Me.BtnAceptar)
        Me.C1SplitterPanel2.Height = 40
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(1, 284)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(693, 40)
        Me.C1SplitterPanel2.SizeRatio = 10.0R
        Me.C1SplitterPanel2.TabIndex = 1
        '
        'frmObserDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 325)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmObserDocumento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones documento"
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        Me.C1SplitterPanel1.PerformLayout()
        Me.C1SplitterPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TObser As TextBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
End Class
