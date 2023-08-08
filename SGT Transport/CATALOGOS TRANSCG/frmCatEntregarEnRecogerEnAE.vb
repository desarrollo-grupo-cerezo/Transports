Imports System.Data.SqlClient
Public Class frmCatEntregarEnRecogerEnAE
    Private Sub frmCatEntregarEnRecogerEnAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tCVE_REG.Text = GET_MAX("GCRECOGER_EN_ENTREGAR_EN", "CVE_REG")
                tCVE_REG.Enabled = False
                tDESCR.Text = ""
                tDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT R.CVE_REG, R.STATUS, R.DESCR, R.UUID, CUEN_CONT FROM GCRECOGER_EN_ENTREGAR_EN R WHERE CVE_REG = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_REG.Text = dr("CVE_REG").ToString
                    tDESCR.Text = dr("DESCR").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                Else
                    tCVE_REG.Text = ""
                    tDESCR.Text = ""
                End If
                dr.Close()

                tCVE_REG.Enabled = False
                tDESCR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmCatEntregarEnRecogerEnAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCRECOGER_EN_ENTREGAR_EN SET DESCR = @DESCR, CUEN_CONT = @CUEN_CONT " &
            "WHERE CVE_REG = @CVE_REG " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCRECOGER_EN_ENTREGAR_EN (CVE_REG, STATUS, DESCR, CUEN_CONT, UUID) VALUES(@CVE_REG, 'A', @DESCR, @CUEN_CONT, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_REG", SqlDbType.VarChar).Value = tCVE_REG.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDESCR.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
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
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
