<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtils
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BarUpdateLibUni = New System.Windows.Forms.Button()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label90 = New System.Windows.Forms.Label()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(393, 239)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 54)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Exportar Inven, Libres y precios"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'BarUpdateLibUni
        '
        Me.BarUpdateLibUni.Location = New System.Drawing.Point(8, 159)
        Me.BarUpdateLibUni.Name = "BarUpdateLibUni"
        Me.BarUpdateLibUni.Size = New System.Drawing.Size(120, 133)
        Me.BarUpdateLibUni.TabIndex = 1
        Me.BarUpdateLibUni.Text = "Alta placas y unidad en campo libre de remisiones"
        Me.BarUpdateLibUni.UseVisualStyleBackColor = True
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.ShowClearButton = False
        Me.F2.Calendar.ShowWeekNumbers = True
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(270, 258)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(111, 19)
        Me.F2.TabIndex = 163
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(320, 242)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 165
        Me.Label15.Text = "al"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.ShowClearButton = False
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(151, 258)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 19)
        Me.F1.TabIndex = 162
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Location = New System.Drawing.Point(196, 242)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(21, 13)
        Me.Label90.TabIndex = 164
        Me.Label90.Text = "del"
        '
        'frmUtils
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 318)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label90)
        Me.Controls.Add(Me.BarUpdateLibUni)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmUtils"
        Me.Text = "Utilerias"
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents BarUpdateLibUni As Button
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label90 As Label
End Class
