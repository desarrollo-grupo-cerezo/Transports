Imports System.Data.SqlClient
Public Class frmCarta_porte_cerrar
    Private Sub frmCarta_porte_cerrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Fg.Rows.Count = 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT S.CVE_CAP, S.DESCR FROM GCSTATUS_CARTA_PORTE S WHERE S.STATUS = 'A' ORDER BY CVE_CAP"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_CAP") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmCarta_porte_cerrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = 13 Then
                barOk_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barOk_Click(sender As Object, e As EventArgs) Handles barOk.Click
        Try
            Var9 = ""
            Var10 = ""
            If Fg.Row > 0 Then
                Var9 = Fg(Fg.Row, 1)
                Var10 = Fg(Fg.Row, 2)
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            barOk_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
