Imports System.Data.SqlClient
Public Class frmTipoDescuentoAE
    Private Sub frmTipoDescuentoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                tClave.Text = GET_MAX("GCTIPO_DESC", "CVE_TIPO")
                tClave.Enabled = False
                tDescr.Text = ""
                tDescr.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT T.CVE_TIPO, T.DESCR, T.STATUS FROM GCTIPO_DESC T WHERE CVE_TIPO = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CVE_TIPO").ToString
                    tDescr.Text = dr("DESCR").ToString
                Else
                    tClave.Text = 0
                    tDescr.Text = ""
                End If
                dr.Close()

                tClave.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmTipoDescuentoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmTipoDescuentoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCTIPO_DESC SET CVE_TIPO = @CVE_TIPO, DESCR = @DESCR " &
            "WHERE CVE_TIPO = @CVE_TIPO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCTIPO_DESC (CVE_TIPO, DESCR, STATUS) VALUES(@CVE_TIPO, @DESCR, 'A')"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_TIPO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tClave.Text)
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
