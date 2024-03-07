Imports System.Data.SqlClient
Public Class frmSelSerie
    Private Sub frmSelSerie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                If Var15.Trim.Length > 0 Then
                    SQL = "SELECT * FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & Var14 & "'  AND TIPO!='T' AND TIPO = '" & Var15 & "' ORDER BY SERIE"
                Else
                    SQL = "SELECT * FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & Var14 & "' AND TIPO!='T' ORDER BY SERIE"
                End If

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("SERIE") & vbTab & IIf(dr("TIPO") = "I", "Impresión", "Digital"))
                        Fg.Rows(Fg.Rows.Count - 1).Height = 30
                    End While
                End Using
            End Using
            Var14 = ""
            Var18 = ""
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmSelSerie_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barSelSerie_Click(sender As Object, e As EventArgs) Handles barSelSerie.Click
        Try
            If Fg.Row > 0 Then
                Var14 = Fg(Fg.Row, 1)
                Var18 = Fg(Fg.Row, 2)
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            barSelSerie_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub
End Class
