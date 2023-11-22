<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpresionReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpresionReportes))
        Me.StiViewerControl1 = New Stimulsoft.Report.Viewer.StiViewerControl()
        Me.SuspendLayout()
        '
        'StiViewerControl1
        '
        Me.StiViewerControl1.AllowDrop = True
        Me.StiViewerControl1.Location = New System.Drawing.Point(27, 30)
        Me.StiViewerControl1.Name = "StiViewerControl1"
        Me.StiViewerControl1.Report = Nothing
        Me.StiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StiViewerControl1.ShowZoom = True
        Me.StiViewerControl1.Size = New System.Drawing.Size(1235, 528)
        Me.StiViewerControl1.TabIndex = 0
        '
        'FrmImpresionReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 614)
        Me.Controls.Add(Me.StiViewerControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImpresionReportes"
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StiViewerControl1 As Stimulsoft.Report.Viewer.StiViewerControl
End Class
