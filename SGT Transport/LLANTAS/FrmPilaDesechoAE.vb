Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmPilaDesechoAE
    Private Sub FrmPilaDesechoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tCVE_PILA.Text = GET_MAX_TRY("GCPILADESECHO", "CVE_PILA")
                TCVE_PILA.Enabled = False
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

                SQL = "SELECT P.CVE_PILA, P.STATUS, P.DESCR FROM GCPILADESECHO P WHERE CVE_PILA = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_PILA.Text = dr("CVE_PILA").ToString
                    TDESCR.Text = dr("DESCR").ToString
                Else
                    TCVE_PILA.Text = ""
                    TDESCR.Text = ""
                End If
                dr.Close()

                TCVE_PILA.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmPilaDesechoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        SQL = "IF EXISTS (SELECT CVE_PILA FROM GCPILADESECHO WHERE CVE_PILA = @CVE_PILA)
            UPDATE GCPILADESECHO SET DESCR = @DESCR WHERE CVE_PILA = @CVE_PILA
            ELSE
            INSERT INTO GCPILADESECHO (CVE_PILA, STATUS, DESCR) VALUES(@CVE_PILA, 'A', @DESCR)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_PILA", SqlDbType.VarChar).Value = TCVE_PILA.Text
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
            MsgBox("El registro se grabo correctamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class