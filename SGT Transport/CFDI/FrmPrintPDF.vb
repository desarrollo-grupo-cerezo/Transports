Public Class FrmPrintPDF
    Private Sub FrmPrintPDF_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            'PdfViewer1.Open(FILE_PDF)
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPrintPDF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
