Imports System.Data.SqlClient
Public Class frmQuitarCaracEspeciales
    Private Sub frmQuitarCaracEspeciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmQuitarCaracEspeciales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim j As Long = 0, z As Integer = 0, CVE_ART As String = ""

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART FROM INVE" & Empresa & " ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE INVE" & Empresa & " SET CVE_ART = '" & RemoveCharacter(dr("CVE_ART")) & "' 
                                      WHERE CVE_ART = '" & dr("CVE_ART") & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z = z + 1
                                    End If
                                End If
                            End Using
                            j = j + 1
                            Lt1.Text = j
                            Lt3.Text = z
                            Lt2.Text = dr("CVE_ART")
                        Catch ex As Exception
                            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART FROM MINVE" & Empresa & " ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE MINVE" & Empresa & " SET CVE_ART = '" & RemoveCharacter(dr("CVE_ART")) & "' 
                                      WHERE CVE_ART = '" & dr("CVE_ART") & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z = z + 1
                                    End If
                                End If
                            End Using
                            j = j + 1
                            Lt1.Text = j
                            Lt3.Text = z
                            Lt2.Text = dr("CVE_ART")
                        Catch ex As Exception
                            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART FROM MULT" & Empresa & " ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE MULT" & Empresa & " SET CVE_ART = '" & RemoveCharacter(dr("CVE_ART")) & "' 
                                      WHERE CVE_ART = '" & dr("CVE_ART") & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z = z + 1
                                    End If
                                End If
                            End Using
                            j = j + 1
                            Lt1.Text = j
                            Lt3.Text = z
                            Lt2.Text = dr("CVE_ART")
                        Catch ex As Exception
                            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            BACKUPTXT("CVE_ART", CVE_ART)
                        End Try
                    End While
                End Using
            End Using

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnMinve_Click(sender As Object, e As EventArgs) Handles BtnMinve.Click
        Dim j As Long = 0, z As Integer = 0, CVE_ART As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART FROM MULT" & Empresa & " ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE MULT" & Empresa & " SET CVE_ART = '" & RemoveCharacter(dr("CVE_ART")) & "' 
                                      WHERE CVE_ART = '" & dr("CVE_ART") & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z = z + 1
                                    End If
                                End If
                            End Using
                            j = j + 1
                            Lt1.Text = j
                            Lt3.Text = z
                            Lt2.Text = dr("CVE_ART")
                        Catch ex As Exception
                            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                            BACKUPTXT("CARACTERES ESPECIALES CVE_ART", CVE_ART)
                        End Try
                    End While
                End Using
            End Using
            MsgBox("ok")
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
