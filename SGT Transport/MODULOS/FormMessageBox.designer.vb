<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMessageBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMessageBox))
        Me.panelTitleBar = New System.Windows.Forms.Panel()
        Me.labelCaption = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.button3 = New C1.Win.C1Input.C1Button()
        Me.button2 = New C1.Win.C1Input.C1Button()
        Me.button1 = New C1.Win.C1Input.C1Button()
        Me.panelBody = New System.Windows.Forms.Panel()
        Me.labelMessage = New System.Windows.Forms.Label()
        Me.pictureBoxIcon = New System.Windows.Forms.PictureBox()
        Me.panelTitleBar.SuspendLayout()
        Me.panelButtons.SuspendLayout()
        CType(Me.button3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.button2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.button1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelBody.SuspendLayout()
        CType(Me.pictureBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelTitleBar
        '
        Me.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.panelTitleBar.Controls.Add(Me.labelCaption)
        Me.panelTitleBar.Controls.Add(Me.btnClose)
        Me.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTitleBar.Location = New System.Drawing.Point(0, 0)
        Me.panelTitleBar.Name = "panelTitleBar"
        Me.panelTitleBar.Size = New System.Drawing.Size(350, 35)
        Me.panelTitleBar.TabIndex = 1
        '
        'labelCaption
        '
        Me.labelCaption.AutoSize = True
        Me.labelCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCaption.ForeColor = System.Drawing.Color.White
        Me.labelCaption.Location = New System.Drawing.Point(9, 8)
        Me.labelCaption.Name = "labelCaption"
        Me.labelCaption.Size = New System.Drawing.Size(86, 17)
        Me.labelCaption.TabIndex = 4
        Me.labelCaption.Text = "labelCaption"
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(310, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'panelButtons
        '
        Me.panelButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.panelButtons.Controls.Add(Me.button3)
        Me.panelButtons.Controls.Add(Me.button2)
        Me.panelButtons.Controls.Add(Me.button1)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelButtons.Location = New System.Drawing.Point(0, 90)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(350, 60)
        Me.panelButtons.TabIndex = 2
        '
        'button3
        '
        Me.button3.BackColor = System.Drawing.Color.White
        Me.button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.button3.Location = New System.Drawing.Point(231, 13)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(100, 35)
        Me.button3.TabIndex = 10
        Me.button3.Text = "Ignorar"
        Me.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.button3.UseVisualStyleBackColor = False
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.White
        Me.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button2.Image = Global.SGT_Transport.My.Resources.Resources.cancelar__1_
        Me.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.button2.Location = New System.Drawing.Point(125, 13)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(100, 35)
        Me.button2.TabIndex = 9
        Me.button2.Text = "Cancelar"
        Me.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.button2.UseVisualStyleBackColor = False
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.White
        Me.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Image = Global.SGT_Transport.My.Resources.Resources.mano1
        Me.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.button1.Location = New System.Drawing.Point(19, 13)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(100, 35)
        Me.button1.TabIndex = 8
        Me.button1.Text = "Aceptar"
        Me.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.button1.UseVisualStyleBackColor = False
        '
        'panelBody
        '
        Me.panelBody.BackColor = System.Drawing.Color.Transparent
        Me.panelBody.Controls.Add(Me.labelMessage)
        Me.panelBody.Controls.Add(Me.pictureBoxIcon)
        Me.panelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBody.Location = New System.Drawing.Point(0, 35)
        Me.panelBody.Name = "panelBody"
        Me.panelBody.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.panelBody.Size = New System.Drawing.Size(350, 55)
        Me.panelBody.TabIndex = 3
        '
        'labelMessage
        '
        Me.labelMessage.AutoSize = True
        Me.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMessage.ForeColor = System.Drawing.Color.Black
        Me.labelMessage.Location = New System.Drawing.Point(50, 10)
        Me.labelMessage.MaximumSize = New System.Drawing.Size(600, 0)
        Me.labelMessage.Name = "labelMessage"
        Me.labelMessage.Padding = New System.Windows.Forms.Padding(5, 5, 10, 15)
        Me.labelMessage.Size = New System.Drawing.Size(110, 37)
        Me.labelMessage.TabIndex = 1
        Me.labelMessage.Text = "labelMessage"
        Me.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pictureBoxIcon
        '
        Me.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left
        Me.pictureBoxIcon.Image = Global.SGT_Transport.My.Resources.Resources.chat
        Me.pictureBoxIcon.Location = New System.Drawing.Point(10, 10)
        Me.pictureBoxIcon.Name = "pictureBoxIcon"
        Me.pictureBoxIcon.Size = New System.Drawing.Size(40, 45)
        Me.pictureBoxIcon.TabIndex = 0
        Me.pictureBoxIcon.TabStop = False
        Me.pictureBoxIcon.Visible = False
        '
        'FormMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 150)
        Me.Controls.Add(Me.panelBody)
        Me.Controls.Add(Me.panelButtons)
        Me.Controls.Add(Me.panelTitleBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(350, 150)
        Me.Name = "FormMessageBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormMessageBox"
        Me.panelTitleBar.ResumeLayout(False)
        Me.panelTitleBar.PerformLayout()
        Me.panelButtons.ResumeLayout(False)
        CType(Me.button3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.button2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.button1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelBody.ResumeLayout(False)
        Me.panelBody.PerformLayout()
        CType(Me.pictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelTitleBar As Panel
    Private WithEvents labelCaption As Label
    Private WithEvents btnClose As Button
    Private WithEvents panelButtons As Panel
    Private WithEvents panelBody As Panel
    Private WithEvents labelMessage As Label
    Private WithEvents pictureBoxIcon As PictureBox
    Friend WithEvents button1 As C1.Win.C1Input.C1Button
    Friend WithEvents button3 As C1.Win.C1Input.C1Button
    Friend WithEvents button2 As C1.Win.C1Input.C1Button
End Class
