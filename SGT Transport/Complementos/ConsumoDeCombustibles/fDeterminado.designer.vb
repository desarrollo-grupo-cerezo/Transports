<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fDeterminado
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
        Me.components = New System.ComponentModel.Container()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.nudImporte = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.cbImpuesto = New System.Windows.Forms.ComboBox()
        Me.nudTasaOCuota = New System.Windows.Forms.NumericUpDown()
        Me.flowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lError = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tableLayoutPanel1.SuspendLayout()
        Me.tableLayoutPanel5.SuspendLayout()
        Me.tableLayoutPanel6.SuspendLayout()
        CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTasaOCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.tableLayoutPanel5, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.tableLayoutPanel6, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel2, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.lError, 0, 2)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(15)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.Padding = New System.Windows.Forms.Padding(15, 15, 15, 5)
        Me.tableLayoutPanel1.RowCount = 4
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(353, 252)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'tableLayoutPanel5
        '
        Me.tableLayoutPanel5.BackgroundImage = Global.SGT_Transport.My.Resources.Resources.Untitled_2
        Me.tableLayoutPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tableLayoutPanel5.ColumnCount = 1
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel5.Controls.Add(Me.label1, 0, 0)
        Me.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel5.Location = New System.Drawing.Point(15, 15)
        Me.tableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel5.Name = "tableLayoutPanel5"
        Me.tableLayoutPanel5.RowCount = 1
        Me.tableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel5.Size = New System.Drawing.Size(323, 35)
        Me.tableLayoutPanel5.TabIndex = 20
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(3, 9)
        Me.label1.Margin = New System.Windows.Forms.Padding(3)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(89, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Determinado"
        '
        'tableLayoutPanel6
        '
        Me.tableLayoutPanel6.BackColor = System.Drawing.SystemColors.Control
        Me.tableLayoutPanel6.ColumnCount = 2
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel6.Controls.Add(Me.nudImporte, 1, 2)
        Me.tableLayoutPanel6.Controls.Add(Me.label2, 0, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.label15, 0, 1)
        Me.tableLayoutPanel6.Controls.Add(Me.label14, 0, 2)
        Me.tableLayoutPanel6.Controls.Add(Me.cbImpuesto, 1, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.nudTasaOCuota, 1, 1)
        Me.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel6.Location = New System.Drawing.Point(18, 50)
        Me.tableLayoutPanel6.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.tableLayoutPanel6.Name = "tableLayoutPanel6"
        Me.tableLayoutPanel6.RowCount = 3
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel6.Size = New System.Drawing.Size(317, 128)
        Me.tableLayoutPanel6.TabIndex = 0
        '
        'nudImporte
        '
        Me.nudImporte.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.nudImporte.DecimalPlaces = 2
        Me.nudImporte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudImporte.Location = New System.Drawing.Point(139, 93)
        Me.nudImporte.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nudImporte.Name = "nudImporte"
        Me.nudImporte.Size = New System.Drawing.Size(138, 25)
        Me.nudImporte.TabIndex = 22
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.label2.Location = New System.Drawing.Point(67, 12)
        Me.label2.Margin = New System.Windows.Forms.Padding(3)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(66, 17)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Impuesto"
        '
        'label15
        '
        Me.label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.label15.Location = New System.Drawing.Point(48, 54)
        Me.label15.Margin = New System.Windows.Forms.Padding(3)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(85, 17)
        Me.label15.TabIndex = 0
        Me.label15.Text = "Tasa o cuota"
        '
        'label14
        '
        Me.label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.label14.Location = New System.Drawing.Point(76, 97)
        Me.label14.Margin = New System.Windows.Forms.Padding(3)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(57, 17)
        Me.label14.TabIndex = 0
        Me.label14.Text = "Importe"
        Me.ToolTip1.SetToolTip(Me.label14, "Atributo requerido para definir el importe o monto del impuesto")
        '
        'cbImpuesto
        '
        Me.cbImpuesto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpuesto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpuesto.FormattingEnabled = True
        Me.cbImpuesto.Items.AddRange(New Object() {"IVA", "IEPS"})
        Me.cbImpuesto.Location = New System.Drawing.Point(139, 8)
        Me.cbImpuesto.Name = "cbImpuesto"
        Me.cbImpuesto.Size = New System.Drawing.Size(138, 25)
        Me.cbImpuesto.TabIndex = 20
        '
        'nudTasaOCuota
        '
        Me.nudTasaOCuota.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.nudTasaOCuota.DecimalPlaces = 6
        Me.nudTasaOCuota.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTasaOCuota.Location = New System.Drawing.Point(139, 50)
        Me.nudTasaOCuota.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudTasaOCuota.Name = "nudTasaOCuota"
        Me.nudTasaOCuota.Size = New System.Drawing.Size(138, 25)
        Me.nudTasaOCuota.TabIndex = 21
        '
        'flowLayoutPanel2
        '
        Me.flowLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowLayoutPanel2.Controls.Add(Me.btnGuardar)
        Me.flowLayoutPanel2.Controls.Add(Me.btnCancelar)
        Me.flowLayoutPanel2.Location = New System.Drawing.Point(68, 205)
        Me.flowLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.flowLayoutPanel2.Name = "flowLayoutPanel2"
        Me.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.flowLayoutPanel2.Size = New System.Drawing.Size(267, 39)
        Me.flowLayoutPanel2.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(139, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(125, 34)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(8, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCancelar.Size = New System.Drawing.Size(125, 34)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'lError
        '
        Me.lError.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lError.AutoSize = True
        Me.lError.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lError.ForeColor = System.Drawing.Color.Red
        Me.lError.Location = New System.Drawing.Point(18, 181)
        Me.lError.Name = "lError"
        Me.lError.Size = New System.Drawing.Size(0, 17)
        Me.lError.TabIndex = 21
        '
        'fDeterminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 252)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fDeterminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Determinado"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.tableLayoutPanel5.ResumeLayout(False)
        Me.tableLayoutPanel5.PerformLayout()
        Me.tableLayoutPanel6.ResumeLayout(False)
        Me.tableLayoutPanel6.PerformLayout()
        CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTasaOCuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents flowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents btnGuardar As System.Windows.Forms.Button
    Private WithEvents btnCancelar As System.Windows.Forms.Button
    Private WithEvents tableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents nudImporte As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents cbImpuesto As System.Windows.Forms.ComboBox
    Friend WithEvents nudTasaOCuota As System.Windows.Forms.NumericUpDown
    Friend WithEvents lError As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
