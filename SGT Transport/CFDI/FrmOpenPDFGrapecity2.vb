Imports C1.Win.C1Document

Public Class FrmOpenPDFGrapecity2
    Private Sub FrmOpenPDFGrapecity2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pds As New C1PdfDocumentSource()

        pds.LoadFromFile(FILE_PDF)
        C1FlexViewer1.DocumentSource = pds

        Me.Text = IIf(CTA_PORT2.Trim.Length = 0, CTA_PORT1, CTA_PORT2)

    End Sub

    Private Sub FrmOpenPDFGrapecity2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class