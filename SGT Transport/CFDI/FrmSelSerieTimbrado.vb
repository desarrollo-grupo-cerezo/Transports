Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class FrmSelSerieTimbrado
    Public TipoDocumento As String
    Public SerieTimbrado As String
    Private Sub FrmSelSerieTimbrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        CboSerie.Items.Clear()
        SerieTimbrado = ""

        Using cmd As SqlCommand = cnSAE.CreateCommand
            SQL = "SELECT SERIE FROM FOLIOSF" & Empresa & " WHERE  TIPO = 'T' AND TIP_DOC = '" & TipoDocumento & "'" '
            cmd.CommandText = SQL
            Using dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CboSerie.Items.Add(dr("SERIE"))
                End While
            End Using

            If CboSerie.Items.Count > 0 Then
                CboSerie.SelectedIndex = 0
            Else
                MsgBox("No existen configuradas series para Timbrado")
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        End Using

    End Sub
    Private Sub FrmSelSerieTimbrado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        SerieTimbrado = CboSerie.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class