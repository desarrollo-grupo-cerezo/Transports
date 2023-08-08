Imports System.Data.SqlClient

Public Class frmPuestosAE
    Private Sub frmPuestosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        If Var1 = "Nuevo" Then

            Try

                tClave.Text = GET_MAX("GCPUESTOS", "CVE_PUESTO")
                tClave.Enabled = False
                tDescr.Text = ""
                tClave.Focus()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_PUESTO, P.DESCR, P.STATUS FROM GCPUESTOS P WHERE CVE_PUESTO = '" & Var2 & "' AND STATUS = 'A'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CVE_PUESTO")
                    tDescr.Text = dr("DESCR")
                Else
                    tClave.Text = ""
                    tDescr.Text = ""

                End If
                dr.Close()

                tClave.Enabled = False

                tDescr.Focus()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
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

        SQL = "UPDATE GCPUESTOS SET CVE_PUESTO = @CVE_PUESTO, DESCR = @DESCR " &
            "WHERE CVE_PUESTO = @CVE_PUESTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPUESTOS (CVE_PUESTO, DESCR, STATUS) VALUES(@CVE_PUESTO, @DESCR, 'A')"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_PUESTO", SqlDbType.VarChar).Value = tClave.Text
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
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

        Me.Close()

    End Sub
End Class
