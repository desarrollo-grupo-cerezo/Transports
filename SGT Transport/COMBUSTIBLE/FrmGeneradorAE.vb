Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmGeneradorAE
    Private Sub FrmGeneradorAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.KeyPreview = True
            Me.CenterToScreen()

        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                TCVE_GEN.Text = GET_MAX("GCHORAS_GEN", "CVE_GEN")
                TCVE_GEN.Enabled = False
                TDESCR.Text = ""
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT H.CVE_GEN, H.STATUS, H.DESCR, H.UUID FROM GCHORAS_GEN H WHERE CVE_GEN = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_GEN.Text = dr("CVE_GEN").ToString
                    TDESCR.Text = dr("DESCR").ToString
                Else
                    TCVE_GEN.Text = 0
                    TDESCR.Text = ""
                End If
                dr.Close()

                TCVE_GEN.Enabled = False
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmGeneradorAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCHORAS_GEN SET DESCR = @DESCR
            WHERE CVE_GEN = @CVE_GEN
            IF @@ROWCOUNT = 0
            INSERT INTO GCHORAS_GEN (CVE_GEN, STATUS, DESCR, UUID)
            VALUES(@CVE_GEN, 'A', @DESCR, NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_GEN", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_GEN.Text)
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarraMenu.Click
        Me.Close()
    End Sub
End Class