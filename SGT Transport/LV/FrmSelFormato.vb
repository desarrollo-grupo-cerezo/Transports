Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Input

Public Class FrmSelFormato
    Private Sub FrmSelFormato_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_REP, NOMBRE, DESCR, ARCHIVO FROM GCFORMATOS WHERE STATUS = 'A' ORDER BY CVE_REP"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboFormatos.Items.Add(dr("ARCHIVO"))
                    End While
                End Using
            End Using
            TFORMATO.Text = Var47

            Me.CenterToScreen()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmSelFormato_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Var47 = TFORMATO.Text
        Me.Close()
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Var47 = ""
        Me.Close()
    End Sub

    Private Sub CboFormatos_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboFormatos.DropDownClosed
        Try
            If CboFormatos.SelectedIndex > -1 Then
                TFORMATO.Text = CboFormatos.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Try

            Dim rutaCg As String = Application.StartupPath & "\REPORTES"

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaCg
            OpenFileDialog1.Filter = "Reporte mrt|*.mrt"
            If TFORMATO.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = TFORMATO.Text
            End If

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

                Dim copyToDir = Path.GetDirectoryName(OpenFileDialog1.FileName)
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)

                TFORMATO.Text = Path.GetFileName(OpenFileDialog1.FileName)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
End Class
