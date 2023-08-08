Public Class FrmPrintPDF2
    Private Sub FrmPrintPDF2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Me.PdfViewer1.Open(FILE_PDF)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmPrintPDF2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
