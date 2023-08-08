<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportDesigner
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
        Me.StiRibbonDesignerControl1 = New Stimulsoft.Report.Design.StiRibbonDesignerControl()
        Me.SuspendLayout()
        '
        'StiRibbonDesignerControl1
        '
        Me.StiRibbonDesignerControl1.BackColor = System.Drawing.Color.White
        Me.StiRibbonDesignerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StiRibbonDesignerControl1.Location = New System.Drawing.Point(0, 0)
        Me.StiRibbonDesignerControl1.Name = "StiRibbonDesignerControl1"
        Me.StiRibbonDesignerControl1.Size = New System.Drawing.Size(1158, 592)
        Me.StiRibbonDesignerControl1.TabIndex = 0
        '
        'frmReportDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 592)
        Me.Controls.Add(Me.StiRibbonDesignerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReportDesigner"
        Me.ShowInTaskbar = False
        Me.Text = "Reporteador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StiRibbonDesignerControl1 As Stimulsoft.Report.Design.StiRibbonDesignerControl
End Class
