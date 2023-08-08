Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmPreciosAE
    Private Sub frmPreciosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        tDESCRIPCION.MaxLength = 25
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try

                tCVE_PRECIO.Text = GET_MAX("GCPRECIOSAF", "CVE_PRECIO")
                tCVE_PRECIO.Enabled = False
                tDESCRIPCION.Text = ""
                tDESCRIPCION.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_PRECIO, P.DESCRIPCION, P.STATUS FROM GCPRECIOSAF P WHERE CVE_PRECIO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PRECIO.Text = dr("CVE_PRECIO").ToString
                    tDESCRIPCION.Text = dr("DESCRIPCION").ToString
                Else
                    tCVE_PRECIO.Text = 1
                    tDESCRIPCION.Text = ""
                End If
                dr.Close()

                tCVE_PRECIO.Enabled = False
                tDESCRIPCION.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmPreciosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmPreciosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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


        If tDESCRIPCION.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPRECIOSAF SET CVE_PRECIO = @CVE_PRECIO, DESCRIPCION = @DESCRIPCION" &
            " WHERE CVE_PRECIO = @CVE_PRECIO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPRECIOSAF (CVE_PRECIO, DESCRIPCION, STATUS) VALUES(@CVE_PRECIO, @DESCRIPCION, 'A')"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_PRECIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PRECIO.Text)
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = tDESCRIPCION.Text


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
