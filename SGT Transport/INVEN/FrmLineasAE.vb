Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

Public Class FrmLineasAE
    Private Sub frmLIenasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)
        Catch ex As Exception
        End Try

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then

            Try


                'tCVE_LIN.Text = GET_MAX("CLIN01", "CVE_LIN")
                tCVE_LIN.Enabled = True
                tCVE_LIN.Text = ""
                tDESC_LIN.Text = ""
                tCVE_LIN.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT I.CVE_LIN, I.DESC_LIN, I.ESUNGPO, I.CUENTA_COI, I.STATUS FROM CLIN" & Empresa & " I WHERE CVE_LIN = '" & Var2 & "' AND ISNULL(STATUS, 'A') = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_LIN.Text = dr("CVE_LIN").ToString
                    tDESC_LIN.Text = dr("DESC_LIN").ToString
                    tCUENTA_COI.Text = dr("CUENTA_COI").ToString

                Else
                    tCVE_LIN.Text = ""
                    tDESC_LIN.Text = ""
                    tCUENTA_COI.Text = ""

                End If
                dr.Close()

                tCVE_LIN.Enabled = False
                tDESC_LIN.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmLIenasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmLIenasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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


        If tCVE_LIN.Text.Trim.Length = 0 Then
            MsgBox("La clave no debe quedar vacia, verifique por favor")
            Return
        End If

        If tDESC_LIN.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE CLIN" & Empresa & " SET CVE_LIN = @CVE_LIN, DESC_LIN = @DESC_LIN, CUENTA_COI = @CUENTA_COI" &
            " WHERE CVE_LIN = @CVE_LIN " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO CLIN" & Empresa & " (CVE_LIN, DESC_LIN, CUENTA_COI, STATUS) VALUES(@CVE_LIN, @DESC_LIN, @CUENTA_COI, 'A')"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_LIN", SqlDbType.VarChar).Value = tCVE_LIN.Text
            cmd.Parameters.Add("@DESC_LIN", SqlDbType.VarChar).Value = tDESC_LIN.Text
            cmd.Parameters.Add("@CUENTA_COI", SqlDbType.VarChar).Value = tCUENTA_COI.Text


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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
