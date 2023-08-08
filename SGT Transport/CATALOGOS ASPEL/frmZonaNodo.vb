Imports System.Data.SqlClient
Public Class frmZonaNodo

    Private CVE_ZONA As String
    Private TNODO As String

    Private Sub frmZonaNodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.CenterToScreen()
            TNODO = Var4
            If TNODO = "A" Then
                CVE_ZONA = GET_MAX("ZONA" & Empresa, "CVE_ZONA", 6)
            Else
                CVE_ZONA = Var2
            End If
            tNOMBRE.Text = Var3

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If TNODO <> "A" Then
            SQL = "UPDATE ZONA" & Empresa & " SET TEXTO = @TEXTO WHERE CVE_ZONA = @CVE_ZONA"

            cmd.CommandText = SQL

            Try
                cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = CVE_ZONA
                cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar).Value = tNOMBRE.Text
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
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else

            SQL = "INSERT INTO ZONA" & Empresa & " (CVE_ZONA, CVE_PADRE, TEXTO, TNODO, CTA_CONT, IMPUEFLETE, MONTOFLETE, FORMULA, STATUS) " &
                "VALUES (@CVE_ZONA, @CVE_PADRE, @TEXTO, @TNODO, @CTA_CONT, @IMPUEFLETE, @MONTOFLETE, @FORMULA)"

            cmd.CommandText = SQL

            Try
                cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = CVE_ZONA
                cmd.Parameters.Add("@CVE_PADRE", SqlDbType.VarChar).Value = "RAIZ"
                cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar).Value = tNOMBRE.Text
                cmd.Parameters.Add("@TNODO", SqlDbType.VarChar).Value = "A"
                cmd.Parameters.Add("@CTA_CONT", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@IMPUEFLETE", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@MONTOFLETE", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@FORMULA", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "A"
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
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub frmZonaNodo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
