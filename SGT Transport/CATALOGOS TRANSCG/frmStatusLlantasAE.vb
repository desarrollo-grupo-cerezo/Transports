Imports System.Data.SqlClient

Public Class frmStatusLlantasAE

    Private Sub frmStatusLlantasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select

    End Sub

    Private Sub frmStatusLlantasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If

    End Sub

    Private Sub frmStatusLlantasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then

            Try

                tClave.Text = GET_MAX("GCLLANTA_STATUS", "CVE_STATUS")
                tClave.Enabled = False
                tDescr.Text = ""
                tClave.Focus()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT * FROM GCLLANTA_STATUS WHERE CVE_STATUS = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CVE_STATUS")
                    tDescr.Text = dr("DESCR")
                End If
                dr.Close()

                tClave.Enabled = False

            Catch ex As Exception
                msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCLLANTA_STATUS SET CVE_STATUS = @CVE_STATUS, DESCR = @DESCR" &
            " WHERE CVE_STATUS = @CVE_STATUS " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCLLANTA_STATUS (CVE_STATUS, STATUS, DESCR) VALUES(@CVE_STATUS, 'A', @DESCR)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_STATUS", SqlDbType.VarChar).Value = tClave.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text

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
        Catch ex As Exception
            msgbox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

        Me.Close()

    End Sub
End Class
