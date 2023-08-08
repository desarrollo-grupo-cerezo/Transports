Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command
Public Class frmCatStatusOperAE
    Private Sub frmCatStatusOperAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AssignValidation(Me.tPRIORIDAD, ValidationType.Only_Numbers)

        If Var1 = "Nuevo" Then
            Try
                tCVE_ST_OPER.Text = GET_MAX("GCSTATUS_OPER", "CVE_ST_OPER")
                tCVE_ST_OPER.Enabled = False
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

                SQL = "SELECT S.CVE_ST_OPER, S.STATUS, S.DESCR, PRIORIDAD FROM GCSTATUS_OPER S WHERE CVE_ST_OPER = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_ST_OPER.Text = dr("CVE_ST_OPER").ToString
                    tDESCR.Text = dr("DESCR").ToString
                    tPRIORIDAD.Text = dr("PRIORIDAD").ToString
                Else
                    tCVE_ST_OPER.Text = ""
                    tDESCR.Text = ""
                End If
                dr.Close()

                tCVE_ST_OPER.Enabled = False
                tDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmCatStatusOperAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCSTATUS_OPER SET DESCR = @DESCR, PRIORIDAD = @PRIORIDAD " &
            "WHERE CVE_ST_OPER = @CVE_ST_OPER " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCSTATUS_OPER (CVE_ST_OPER, STATUS, DESCR, PRIORIDAD, FECHAELAB, UUID) " &
            "VALUES (@CVE_ST_OPER, 'A', @DESCR, @PRIORIDAD, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_ST_OPER", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_ST_OPER.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDESCR.Text
            cmd.Parameters.Add("@PRIORIDAD", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tPRIORIDAD.Text)
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
End Class
