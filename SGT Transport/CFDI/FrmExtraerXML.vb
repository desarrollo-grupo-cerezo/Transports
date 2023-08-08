Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Public Class FrmExtraerXML
    Private Sub FrmExtraerXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmExtraerXML_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Dim XML_TABLA As String, FILE_XML As String, z As Integer = 0, y As Integer = 0

        If MsgBox("Realmente desea extraer los XML timbrados?", vbYesNo) = vbNo Then
            Return
        End If

        If TRUTA_DOC.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture o seleccione la carpeta en donde se extraeran los XML")
            Return
        End If

        If Not Directory.Exists(TRUTA_DOC.Text) Then
            If MsgBox("No existe la carpeta donde se extraeran los XML, desea crearla?", vbYesNo) = vbYes Then
                Try
                    Directory.CreateDirectory(TRUTA_DOC.Text)
                Catch ex As Exception
                    Return
                End Try
            Else
                Return
            End If
        End If
        Try
            File.Delete(Application.StartupPath & "\XML NO.txt")
        Catch ex As Exception
        End Try

        Try
            SQL = "SELECT TDOC, FACTURA, DOCUMENT, XML, FILE_XML FROM CFDI WHERE ESTATUS <> 'C' AND TIMBRADO = 'S'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        XML_TABLA = dr("XML")
                        If XML_TABLA.Trim.Length > 0 Then
                            FILE_XML = TRUTA_DOC.Text & "\" & dr("FACTURA") & " " & dr("DOCUMENT") & ".xml"

                            If Not File.Exists(FILE_XML) Then
                                File.WriteAllText(FILE_XML, XML_TABLA)
                                z += 1
                                Lt1.Text = "Archivos creados " & z
                            End If
                        Else
                            BACKUPTXT("XML NO", dr("FACTURA") & " " & dr("DOCUMENT"))
                            y += 1
                        End If
                    End While
                End Using
            End Using
            If y > 0 Then
                MsgBox("Se encontraron " & y & " documentos sin XML, se grabaron en el archivo de texto " & Application.StartupPath & "\XML NO.TXT")
            End If

            MsgBox("Proceso terminado, archivos creados " & z)

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnXML_Click(sender As Object, e As EventArgs) Handles BtnXML.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_DOC.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class
