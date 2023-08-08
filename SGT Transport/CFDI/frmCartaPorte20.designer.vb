<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCartaPorte20
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCartaPorte20))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.label36 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.richTextBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.label36, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1065, 635)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'richTextBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.richTextBox1, 2)
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.richTextBox1.Location = New System.Drawing.Point(3, 67)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(1059, 565)
        Me.richTextBox1.TabIndex = 26
        Me.richTextBox1.Text = resources.GetString("richTextBox1.Text")
        '
        'label36
        '
        Me.label36.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label36.AutoSize = True
        Me.label36.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.label36.Location = New System.Drawing.Point(3, 16)
        Me.label36.Margin = New System.Windows.Forms.Padding(3, 0, 200, 0)
        Me.label36.Name = "label36"
        Me.label36.Size = New System.Drawing.Size(228, 32)
        Me.label36.TabIndex = 23
        Me.label36.Text = "Cartera de clientes"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.AutoEllipsis = True
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardar.Image = Global.SGT_Transport.My.Resources.Resources.icons8_save_25
        Me.btnGuardar.Location = New System.Drawing.Point(981, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 52)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmCartaPorte20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 635)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCartaPorte20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Complemento de Carta Porte 2.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents label36 As System.Windows.Forms.Label
    Private WithEvents btnGuardar As System.Windows.Forms.Button
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
End Class
