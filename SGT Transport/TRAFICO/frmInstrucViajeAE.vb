Imports System.Data.SqlClient
Public Class frmInstrucViajeAE
    Private Sub frmInstrucViajeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If


        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tCVE_IV.Text = GET_MAX("GCINSTRUC_VIAJE", "CVE_IV")
                tCVE_IV.Enabled = False
                tDescr.Text = ""
                tDescr.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT I.CVE_IV, I.STATUS, I.DESCR FROM GCINSTRUC_VIAJE I WHERE CVE_IV = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_IV.Text = dr("CVE_IV").ToString
                    tDescr.Text = dr("DESCR").ToString
                Else
                    tCVE_IV.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_IV.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmInstrucViajeAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmInstrucViajeAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCINSTRUC_VIAJE SET DESCR = @DESCR " &
        "WHERE CVE_IV = @CVE_IV " &
        "IF @@ROWCOUNT = 0 " &
        "INSERT INTO GCINSTRUC_VIAJE (CVE_IV, STATUS, DESCR) VALUES(@CVE_IV, 'A', @DESCR)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_IV", SqlDbType.VarChar).Value = tCVE_IV.Text
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
