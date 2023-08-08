Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmEmbalajeBuenoAE
    Private Sub FrmEmbalajeBuenoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                TCLAVE.Text = GET_MAX_TRY("GCEMBALAJE", "CLAVE")
                TCLAVE.Enabled = False
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

                Me.KeyPreview = True

                SQL = "SELECT E.CLAVE, E.DESCR FROM GCEMBALAJE E WHERE  CLAVE = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCLAVE.Text = dr("CLAVE").ToString
                    TDESCR.Text = dr("DESCR").ToString
                Else
                    TCLAVE.Text = ""
                    TDESCR.Text = ""
                End If
                dr.Close
                TCLAVE.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmEmbalajeBuenoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        SQL = "IF EXISTS (SELECT CLAVE FROM GCEMBALAJE WHERE CLAVE = '" & TCLAVE.Text & "')
            UPDATE GCEMBALAJE SET DESCR = @DESCR
            WHERE CLAVE = @CLAVE
            ELSE
            INSERT INTO GCEMBALAJE (CLAVE, DESCR, STATUS, FECHAELAB, UUID)
            VALUES(@CLAVE, @DESCR, 'A', GETDATE(), NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Text
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class