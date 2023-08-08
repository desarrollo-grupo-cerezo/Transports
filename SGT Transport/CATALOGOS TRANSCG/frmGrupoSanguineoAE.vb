Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmGrupoSanguineoAE
    Private Sub frmGrupoSanguineoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tCVE_GRUSAN.Text = GET_MAX("GCGRUPO_SANGUINEO", "CVE_GRUSAN")
                tCVE_GRUSAN.Enabled = False
                tDescr.Text = ""
                tCVE_GRUSAN.Focus()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT G.CVE_GRUSAN, G.STATUS, G.DESCR FROM GCGRUPO_SANGUINEO G WHERE CVE_GRUSAN = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_GRUSAN.Text = dr("CVE_GRUSAN")
                    tDescr.Text = dr("DESCR")
                Else
                    tCVE_GRUSAN.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_GRUSAN.Enabled = False
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmGrupoSanguineoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmGrupoSanguineoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCGRUPO_SANGUINEO SET CVE_GRUSAN = @CVE_GRUSAN, DESCR = @DESCR
            WHERE CVE_GRUSAN = @CVE_GRUSAN
            IF @@ROWCOUNT = 0
            INSERT INTO GCGRUPO_SANGUINEO (CVE_GRUSAN, STATUS, DESCR)
            VALUES(@CVE_GRUSAN, 'A', @DESCR)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_GRUSAN", SqlDbType.SmallInt).Value = tCVE_GRUSAN.Text
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
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
