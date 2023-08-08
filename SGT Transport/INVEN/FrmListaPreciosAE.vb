Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmListaPreciosAE
    Private Sub frmListaPreciosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        If Var1 = "Nuevo" Then
            Try
                tCVE_PRECIO.Text = GET_MAX("PRECIOS" & Empresa, "CVE_PRECIO")
                tCVE_PRECIO.Enabled = False
                tDescr.Text = ""
                tDescr.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT E.CVE_PRECIO, E.DESCRIPCION FROM PRECIOS" & Empresa & " E WHERE CVE_PRECIO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PRECIO.Text = dr("CVE_PRECIO").ToString
                    tDescr.Text = dr("DESCRIPCION").ToString
                Else
                    tCVE_PRECIO.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_PRECIO.Enabled = False
                tDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmListaPreciosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmListaPreciosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmListaPreciosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE PRECIOS" & Empresa & " SET DESCRIPCION = @DESCRIPCION " &
            "WHERE CVE_PRECIO = @CVE_PRECIO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO PRECIOS" & Empresa & " (CVE_PRECIO, DESCRIPCION, CVE_BITA, STATUS, UUID, VERSION_SINC) " &
            "VALUES(@CVE_PRECIO, @DESCRIPCION, '0', 'A', NEWID(), GETDATE())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_PRECIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PRECIO.text)
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = tDescr.Text
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
