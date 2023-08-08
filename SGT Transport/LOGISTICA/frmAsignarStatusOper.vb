Imports System.Data.SqlClient
Public Class frmAsignarStatusOper
    Private Sub frmAsignarStatusOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ST_OPER, DESCR FROM GCSTATUS_OPER ORDER BY CVE_ST_OPER"
                Fg.Rows.Count = 1
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ST_OPER") & vbTab & dr("DESCR"))
                    End While
                End Using
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1) = Var45 Then
                        Fg.Row = k
                        Exit For
                    End If
                Next
            End Using
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAsignarStatusOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If Not String.IsNullOrEmpty(Fg(Fg.Row, 1)) Then
                Dim CVE_ST_OPER As Integer
                CVE_ST_OPER = Fg(Fg.Row, 1)

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCOPERADOR SET CVE_ST_OPER = @CVE_ST_OPER WHERE CLAVE = " & Var44
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Add("@CVE_ST_OPER", SqlDbType.Int).Value = CVE_ST_OPER
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                MsgBox("El registro se grabo satisfactoriamente")

                                If FORM_IS_OPEN("frmCatStatusUnidades") Then
                                    frmCatStatusUnidades.DESPLEGAR()
                                End If

                                Me.Close()
                            Else
                                MsgBox("No se logro grabar el registro")
                            End If
                        Else
                            MsgBox("No se logro grabar el registro")
                        End If
                    Catch ex As Exception
                        MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End Using
            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
