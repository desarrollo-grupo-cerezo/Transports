Imports System.Data.SqlClient
Public Class frmAutorizaAE
    Private Sub frmAutorizaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                tCVE_AUT.Text = GET_MAX("GCAUTORIZA", "CVE_AUT")
                tCVE_AUT.Enabled = False
                tNOMBRE.Text = ""
                tMail.Text = ""
                tNOMBRE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT A.CVE_AUT, A.NOMBRE, A.STATUS, A.CORREO FROM GCAUTORIZA A WHERE CVE_AUT = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_AUT.Text = dr("CVE_AUT").ToString
                    tNOMBRE.Text = dr("NOMBRE").ToString
                    tMail.Text = dr("CORREO").ToString
                Else
                    tCVE_AUT.Text = ""
                    tNOMBRE.Text = ""
                    tMail.Text = ""
                End If
                dr.Close()

                tCVE_AUT.Enabled = False
                tNOMBRE.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmAutorizaAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmAutorizaAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        If tNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("El nombre no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCAUTORIZA SET NOMBRE = @NOMBRE, CORREO = @CORREO WHERE CVE_AUT = @CVE_AUT " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCAUTORIZA (CVE_AUT, NOMBRE, STATUS, CORREO) VALUES(@CVE_AUT, @NOMBRE, 'A', @CORREO)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_AUT", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_AUT.Text)
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNOMBRE.Text
            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = tMail.Text
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
