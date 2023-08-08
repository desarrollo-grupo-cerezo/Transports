Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports SGT_Transport.WSFD

Public Class FrmAddendasAE
    Private Sub FrmAddendasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        If Var1 = "Nuevo" Then
            Try
                TCLAVE_ADD.Text = GET_MAX_TRY("GCADDENDAS", "CVE_ADD")
                TCLAVE_ADD.Enabled = False
                TNOMBRE.Text = ""
                TNOMBRE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT A.CVE_ADD, A.DESCR, A.STATUS, A.FECHAELAB
                    FROM GCADDENDAS A 
                    WHERE CVE_ADD = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCLAVE_ADD.Text = dr("CVE_ADD").ToString
                    TNOMBRE.Text = dr("DESCR").ToString
                Else
                    TCLAVE_ADD.Text = ""
                    TNOMBRE.Text = ""
                End If
                dr.Close()

                TCLAVE_ADD.Enabled = False
                TNOMBRE.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmAddendasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        SQL = "IF EXISTS (SELECT CVE_ADD FROM GCADDENDAS WHERE CVE_ADD = '" & TCLAVE_ADD.Text & "')
            UPDATE GCADDENDAS SET DESCR = @DESCR 
            WHERE CVE_ADD = @CVE_ADD
            ELSE
            INSERT INTO GCADDENDAS (CVE_ADD, DESCR, STATUS, FECHA, FECHAELAB, UUID)
            VALUES(@CVE_ADD, @DESCR, 'A', CONVERT(varchar, GETDATE(), 112), GETDATE(), NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ADD", SqlDbType.VarChar).Value = TCLAVE_ADD.Text
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TNOMBRE.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            MsgBox("El registro se grabo correctamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class