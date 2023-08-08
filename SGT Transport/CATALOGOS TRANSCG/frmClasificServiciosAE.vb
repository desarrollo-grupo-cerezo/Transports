Imports System.Data.SqlClient

Public Class frmClasificServiciosAE

    Private Sub frmClasificServiciosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CloseTab("Tipo Llanta")
        Me.Dispose()
    End Sub

    Private Sub frmClasificServiciosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmClasificServiciosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCCLASIFIC_SERVICIOS", "CVE_CLA")
                tClave.Enabled = False
                tDescr.Text = ""
                tDescr.Focus()
            Catch ex As Exception
                MsgBox("1.0. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1.0. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT * FROM GCCLASIFIC_SERVICIOS WHERE CVE_CLA = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tClave.Text = dr("CVE_CLA")
                    tDescr.Text = dr("DESCR")
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                Loop
                dr.Close()

                tClave.Enabled = False
                tDescr.Focus()

            Catch ex As Exception
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
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

        SQL = "UPDATE GCCLASIFIC_SERVICIOS SET CVE_CLA = @CVE_CLA, DESCR = @DESCR, CUEN_CONT = @CUEN_CONT " &
            "WHERE CVE_CLA = @CVE_CLA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCLASIFIC_SERVICIOS (CVE_CLA, STATUS, DESCR, CUEN_CONT) VALUES(@CVE_CLA, 'A', @DESCR, @CUEN_CONT)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_CLA", SqlDbType.VarChar).Value = tClave.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If

            If FORM_IS_OPEN("frmClasificServicios") Then
                frmClasificServicios.DESPLEGAR()
            End If
            Me.Close()
        Catch ex As Exception
            msgbox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
