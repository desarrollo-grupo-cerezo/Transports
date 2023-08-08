Imports System.Data.SqlClient

Public Class frmFormaPagoAE

    Private Sub frmFormaPagoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()

        If Var1 = "Nuevo" Then

            Try

                tCVE_PAGO.Text = GET_MAX("GCFORMAPAGO", "CVE_PAGO")
                tCVE_PAGO.Enabled = False
                tDescr.Text = ""
                tCVE_PAGO.Focus()

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

                SQL = "SELECT F.CVE_PAGO, F.DESCR FROM GCFORMAPAGO F WHERE CVE_PAGO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PAGO.text = dr("CVE_PAGO")
                    tDescr.Text = dr("DESCR")

                Else
                    tCVE_PAGO.text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_PAGO.Enabled = False

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
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


        SQL = "UPDATE GCFORMAPAGO SET CVE_PAGO = @CVE_PAGO, DESCR = @DESCR" &
            " WHERE CVE_PAGO = @CVE_PAGO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCFORMAPAGO (CVE_PAGO, DESCR, STATUS) VALUES(@CVE_PAGO, @DESCR, 'A')"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_PAGO", SqlDbType.VarChar).Value = tCVE_PAGO.Text
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
            msgbox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

        Me.Close()

    End Sub
End Class
