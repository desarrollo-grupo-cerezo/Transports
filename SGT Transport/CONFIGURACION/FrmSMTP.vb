Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmSMTP
    Private Sub frmSMTP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCSMTP"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        tSERVIDOR.Text = dr.ReadNullAsEmptyString("SERVIDOR")
                        tPUERTO.Text = dr.ReadNullAsEmptyString("PUERTO")
                        tUSUARIO.Text = dr.ReadNullAsEmptyString("USUARIO")
                        Try
                            If dr.ReadNullAsEmptyString("PASS").ToString.Trim.Length > 0 Then
                                tPASS.Text = Desencriptar(dr.ReadNullAsEmptyString("PASS"))
                            Else
                                tPASS.Text = ""
                            End If
                        Catch ex As Exception
                            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        chSSL.Checked = IIf(dr.ReadNullAsEmptyInteger("SSL") = 1, True, False)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSMTP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim CLAVE As String

        SQL = "UPDATE GCSMTP SET SERVIDOR = @SERVIDOR, PUERTO = @PUERTO, USUARIO = @USUARIO, PASS = @PASS, SSL = @SSL
            IF @@ROWCOUNT = 0 
            INSERT INTO GCSMTP (SERVIDOR, PUERTO, USUARIO, PASS, SSL) VALUES(@SERVIDOR, @PUERTO, @USUARIO, @PASS, @SSL)"
        Try
            If tPASS.Text.Trim.Length = 0 Then
                CLAVE = ""
            Else
                CLAVE = Encriptar(tPASS.Text)
            End If

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@SERVIDOR", SqlDbType.VarChar).Value = tSERVIDOR.Text
                cmd.Parameters.Add("@PUERTO", SqlDbType.VarChar).Value = tPUERTO.Text
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tUSUARIO.Text
                cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = CLAVE
                cmd.Parameters.Add("@SSL", SqlDbType.SmallInt).Value = IIf(chSSL.Checked, 1, 0)
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se grabo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
