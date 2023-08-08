Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class frmTipoOperacionAE
    Private Sub frmTipoOperacionAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tCVE_TIPO.Text = GET_MAX("GCTIPO_OPERACION", "CVE_TIPO")
                tCVE_TIPO.Enabled = False
                tDescr.Text = ""
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT T.CVE_TIPO, T.STATUS, T.DESCR FROM GCTIPO_OPERACION T WHERE CVE_TIPO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_TIPO.Text = dr("CVE_TIPO")

                    tDescr.Text = dr("DESCR")
                Else
                    tCVE_TIPO.Text = ""

                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_TIPO.Enabled = False

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmTipoOperacionAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmTipoOperacionAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCTIPO_OPERACION SET CVE_TIPO = @CVE_TIPO, DESCR = @DESCR" &
            " WHERE CVE_TIPO = @CVE_TIPO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCTIPO_OPERACION (CVE_TIPO, STATUS, DESCR) VALUES(@CVE_TIPO, 'A', @DESCR)"

        cmd.CommandText = SQL



        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_TIPO", SqlDbType.SmallInt).Value = tCVE_TIPO.Text

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
        Try
            Me.Close()
        Catch ex As Exception
            msgbox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
