Imports System.Data.SqlClient
Public Class frmMotoresAE
    Private Sub frmMotoresAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        radFull.Checked = False
        radSencillo.Checked = False
        RadFullSencillo.Checked = False

        If Var1 = "Nuevo" Then
            Try
                tCVE_MOT.Text = GET_MAX("GCMOTORES", "CVE_MOT")
                tCVE_MOT.Enabled = False
                tDescr.Text = ""
                tMOTOR.Text = ""
                tMOTOR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_MOT, M.MOTOR, M.DESCR, M.TIPO_VIAJE FROM GCMOTORES M WHERE CVE_MOT = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_MOT.Text = dr("CVE_MOT").ToString
                    tMOTOR.Text = dr.ReadNullAsEmptyString("MOTOR").ToString
                    tDescr.Text = dr("DESCR").ToString
                    Select Case dr.ReadNullAsEmptyInteger("TIPO_VIAJE")
                        Case 0
                            radFull.Checked = True
                        Case 1
                            radSencillo.Checked = True
                        Case 2
                            RadFullSencillo.Checked = True
                    End Select
                Else
                    tCVE_MOT.Text = ""
                    tMOTOR.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_MOT.Enabled = False
                tMOTOR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmMotoresAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        Dim TIPO_VIAJE As Integer = -1

        If radFull.Checked Then
            TIPO_VIAJE = 0
        Else
            If radSencillo.Checked Then
                TIPO_VIAJE = 1
            Else
                If RadFullSencillo.Checked Then
                    TIPO_VIAJE = 2
                End If
            End If
        End If
        SQL = "UPDATE GCMOTORES SET MOTOR = @MOTOR, DESCR = @DESCR, TIPO_VIAJE = @TIPO_VIAJE " &
            " WHERE CVE_MOT = @CVE_MOT " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMOTORES (CVE_MOT, STATUS, MOTOR, DESCR, TIPO_VIAJE, UUID) VALUES(@CVE_MOT, 'A', @MOTOR, @DESCR, @TIPO_VIAJE, NEWID())"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_MOT", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_MOT.Text)
            cmd.Parameters.Add("@MOTOR", SqlDbType.VarChar).Value = tMOTOR.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.SmallInt).Value = TIPO_VIAJE
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
