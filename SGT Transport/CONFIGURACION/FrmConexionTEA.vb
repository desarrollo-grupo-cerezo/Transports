Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmConexionTEA
    Private Sub FrmConxionTEA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT SERVIDOR, BASE, USUARIO, PASS FROM TEA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TServidor.Text = dr("SERVIDOR")
                        TBase.Text = dr("BASE")
                        TUsuario.Text = dr("USUARIO")
                        TPass.Text = dr("PASS")
                    Else
                        TServidor.Text = Servidor_SAROCE
                        TBase.Text = "TEA_HA"
                        TUsuario.Text = Usuario_SAROCE
                        TPass.Text = Pass_SAROCE
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmConxionTEA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If TServidor.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del servidor")
            Return
        End If
        If TBase.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre de la base")
            Return
        End If
        If TUsuario.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del usuario")
            Return
        End If
        If TPass.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la contraseña")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Lt.Text = "Conectandose a la base TEA......"
        Lt.Refresh()

        If Not OpenSAE(TServidor.Text, TBase.Text, TUsuario.Text, TPass.Text) Then
            MsgBox("Imposible conectarse a la base TEA")
        Else
            Try
                SQL = "IF EXISTS (SELECT SERVIDOR FROM TEA)
                        UPDATE TEA SET 
                        SERVIDOR = '" & TServidor.Text & "', 
                        BASE = '" & TBase.Text & "', 
                        USUARIO = '" & TUsuario.Text & "', 
                        PASS = '" & TPass.Text & "'
                      ELSE
                        INSERT INTO TEA (SERVIDOR, BASE, USUARIO, PASS) VALUES ('" & TServidor.Text & "','" &
                        TBase.Text & "','" & TUsuario.Text & "','" & TPass.Text & "')"

                Using cmd As SqlCommand = cnSAROCE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End Using
                cnSQL.Close()

                Me.Cursor = Cursors.Default

                MsgBox("La configuración a la base TEA se reaaliza correctamente")
                Me.Close()
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
        Lt.Text = ""
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class