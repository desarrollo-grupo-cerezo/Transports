<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOPenPDFGrapecity
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOPenPDFGrapecity))
        Me.C1FlexViewer1 = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexViewer1
        '
        Me.C1FlexViewer1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.C1FlexViewer1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.C1FlexViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexViewer1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexViewer1.Name = "C1FlexViewer1"
        Me.C1FlexViewer1.OpenExportedFile = True
        Me.C1FlexViewer1.Size = New System.Drawing.Size(966, 617)
        Me.C1FlexViewer1.TabIndex = 0
        '
        'FrmOPenPDFGrapecity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 617)
        Me.Controls.Add(Me.C1FlexViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOPenPDFGrapecity"
        Me.Text = "FrmOPenPDFGrapecity"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1FlexViewer1 As C1.Win.FlexViewer.C1FlexViewer
End Class
