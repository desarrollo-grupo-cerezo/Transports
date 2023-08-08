Imports System.Data.SqlClient
Public Class FrmTesoreriaRefBan
    Private Sub FrmTesoreriaRefBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        TREF_BAN.Text = Var2
    End Sub

    Private Sub FrmTesoreriaRefBan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Try
            Var4 = TREF_BAN.Text
            If Var1.Trim.Length > 0 Then
                If IsNumeric(Var1) Then
                    SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET REF_BAN = '" & Var4 & "' WHERE FOLIO = " & Var1
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                        Me.Close()
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Var4 = "-"
        Me.Close()
    End Sub
End Class
