Imports C1.Win.C1Document

Public Class FrmOPenPDFGrapecity
    Private Sub FrmOPenPDFGrapecity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pds As New C1PdfDocumentSource()

        pds.LoadFromFile(FILE_PDF)
        C1FlexViewer1.DocumentSource = pds

        Me.Text = CTA_PORT1
    End Sub

    Private Sub FrmOPenPDFGrapecity_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class