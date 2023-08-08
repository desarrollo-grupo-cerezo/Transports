Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmDeduccionesAE
    Private Sub FrmDeduccionesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        If Var1 = "Nuevo" Then
            Try
                TCVE_DED.Text = GET_MAX("GCDEDUCCIONES", "CVE_DED")
                TCVE_DED.Enabled = False
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

                SQL = "SELECT D.CVE_DED, D.STATUS, D.DESCR, D.CTA_CONTABLE 
                    FROM GCDEDUCCIONES D WHERE CVE_DED = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_DED.Text = dr("CVE_DED").ToString
                    TDESCR.Text = dr("DESCR").ToString
                    TCTA_CONTABLE.Text = dr.ReadNullAsEmptyString("CTA_CONTABLE").ToString
                Else
                    TCVE_DED.Text = ""
                    TDESCR.Text = ""
                End If
                dr.Close()

                TCVE_DED.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmDeduccionesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCDEDUCCIONES SET DESCR = @DESCR, CTA_CONTABLE = @CTA_CONTABLE
            WHERE CVE_DED = @CVE_DED
            IF @@ROWCOUNT = 0 
            INSERT INTO GCDEDUCCIONES (CVE_DED, STATUS, DESCR, CTA_CONTABLE, FECHAELAB, UUID) 
            VALUES (@CVE_DED, 'A', @DESCR, @CTA_CONTABLE, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_DED.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
            cmd.Parameters.Add("@CTA_CONTABLE", SqlDbType.VarChar).Value = TCTA_CONTABLE.Text
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
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        Me.Close()
    End Sub
End Class
