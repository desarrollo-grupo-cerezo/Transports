Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO

Public Class FrmAcercaDe
    Private streamReader As StreamReader
    Private printingFont As Font
    Private printerSettings As System.Drawing.Printing.PageSettings
    Private Sub frmAcercaDe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        L1.Text = "Serial: " & GET_ID()

    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        File.WriteAllText(Application.StartupPath & "\Acuerdolicencia.txt", RichTextBox1.Text)
        Try
            streamReader = New StreamReader(Application.StartupPath & "\Acuerdolicencia.txt")
            Try
                printingFont = New Font("Arial", 7)
                Dim pd As New PrintDocument()
                Dim name As String = "Letter"
                Dim width As Integer = 580  'Ancho en Centesimas de pulgada
                Dim height As Integer = 830 'Alto en Centesimas de pulgada
                Dim TipoPapel As New PaperSize(name, width, height)
                pd.DefaultPageSettings.PaperSize = TipoPapel

                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                'If Not printerSettings Is Nothing Then
                'pd.DefaultPageSettings = printerSettings
                'End If
                'pd.DefaultPageSettings.Margins = New Margins(30, 30, 20, 30)
                'pd.DefaultPageSettings.Landscape = True
                With PrintPreviewDialog1
                    .Document = pd
                    .ShowDialog()
                End With

            Finally
                streamReader.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 50
        Dim count As Integer = 0
        Dim leftMargin As Single = 30 'ev.MarginBounds.Left
        Dim topMargin As Single = 30 'ev.MarginBounds.Top
        Dim line As String = Nothing


        linesPerPage = ev.MarginBounds.Height / printingFont.GetHeight(ev.Graphics)

        While count < linesPerPage
            line = StreamReader.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printingFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printingFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        If Not (line Is Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub
    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        e.Graphics.DrawRectangle(Pens.Black, 50, 100, 50, 350)
        e.Graphics.DrawLine(Pens.Black, 150, 150, 250, 450)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
