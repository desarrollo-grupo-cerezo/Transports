
Imports System.Drawing.Printing

Public Class FrmSelectPrinter
    Private Sub FrmSelectPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim strInstalledPrinters As String
        Dim prntDoc As New PrintDocument

        'check if there is installed printer
        If PrinterSettings.InstalledPrinters.Count = 0 Then
            MsgBox("No printer installed")
            Exit Sub
        End If

        'display installed printer into combobox list item
        For Each strInstalledPrinters In PrinterSettings.InstalledPrinters
            CboPrinter.Items.Add(strInstalledPrinters)
        Next strInstalledPrinters

        'Display current default printer on combobox texts
        CboPrinter.Text = prntDoc.PrinterSettings.PrinterName


    End Sub

    Private Sub FrmSelectPrinter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            'If SetDefaulPrinter(CboPrinter.Text) = True Then
            'MsgBox("Printer default menjadi " & ComboBox1.Text)
            'PrinterPublic2 = CboPrinter.Text
            'Else
            'PrinterPublic2 = ""
            'MsgBox("Printer name " & ComboBox1.Text & " is not valid!")
            'End If

            If CboPrinter.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione una impresora")
            Else
                PrinterPublic2 = CboPrinter.Text

                If SetDefaulPrinter(CboPrinter.Text) = True Then

                End If
                Me.Close()
            End If
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class
