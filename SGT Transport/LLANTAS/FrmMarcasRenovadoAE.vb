Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmMarcasRenovadoAE
    Private Sub FrmMarcasRenovadoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                TClave.Text = GET_MAX("GCMARCAS_RENOVADO", "CVE_MARCA")
                TClave.Enabled = False
                TDESCR.Text = ""
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_MARCA, M.STATUS, M.DESCR
                    FROM GCMARCAS_RENOVADO M 
                    WHERE CVE_MARCA = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TClave.Text = dr("CVE_MARCA")
                    TDESCR.Text = dr("DESCR")
                Else
                    TClave.Text = ""
                    TDESCR.Text = ""
                End If
                dr.Close()

                TClave.Enabled = False
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmMarcasRenovadoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCMARCAS_RENOVADO SET CVE_MARCA = @CVE_MARCA, DESCR = @DESCR " &
            "WHERE CVE_MARCA = @CVE_MARCA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMARCAS_RENOVADO (CVE_MARCA, STATUS, DESCR) VALUES(@CVE_MARCA, 'A', @DESCR)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = TClave.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
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
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
