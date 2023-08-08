Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmDeptosAE
    Private Sub frmDeptosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        Me.KeyPreview = True
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()

        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCDEPTOS", "CVE_DEPTO")
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

                SQL = "SELECT D.CVE_DEPTO, D.DESCR, D.STATUS FROM GCDEPTOS D WHERE CVE_DEPTO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tClave.Text = dr("CVE_DEPTO")
                    tDescr.Text = dr("DESCR")
                Else
                    tClave.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()
                tClave.Enabled = False
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

        SQL = "UPDATE GCDEPTOS SET CVE_DEPTO = @CVE_DEPTO, DESCR = @DESCR" &
            " WHERE CVE_DEPTO = @CVE_DEPTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCDEPTOS (CVE_DEPTO, DESCR, STATUS) VALUES(@CVE_DEPTO, @DESCR, 'A')"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_DEPTO", SqlDbType.VarChar).Value = tClave.Text
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
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
