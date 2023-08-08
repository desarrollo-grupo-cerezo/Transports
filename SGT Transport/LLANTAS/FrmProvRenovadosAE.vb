Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmProvRenovadosAE
    Private Sub FrmProvRenovadosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                TCVE_PRE.Text = GET_MAX("GCPROVRENOVADO", "CVE_PRE")
                TCVE_PRE.Enabled = False
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

                SQL = "SELECT P.CVE_PRE, P.STATUS, P.DESCR 
                    FROM GCPROVRENOVADO P 
                    WHERE CVE_PRE = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_PRE.Text = dr("CVE_PRE").ToString
                    TDESCR.Text = dr("DESCR").ToString
                Else
                    TCVE_PRE.Text = ""
                    TDESCR.Text = ""
                End If
                dr.Close()

                TCVE_PRE.Enabled = False
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmProvRenovadosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPROVRENOVADO SET DESCR = @DESCR
            WHERE CVE_PRE = @CVE_PRE
            IF @@ROWCOUNT = 0
            INSERT INTO GCPROVRENOVADO (CVE_PRE, STATUS, DESCR) VALUES(@CVE_PRE, 'A', @DESCR)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_PRE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_PRE.Text)
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El proveedore se grabo correctamente")
                        Me.Close()
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class