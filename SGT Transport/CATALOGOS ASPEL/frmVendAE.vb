Imports System.Data.SqlClient

Public Class frmVendAE

    Private Sub frmVendAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmVendAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub frmVendAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then

            Try


                tNOMBRE.Text = ""
                tCOMI.Value = ""
                tCLASIFIC.Text = ""
                tCORREOE.Text = ""

                tCVE_VEND.Text = GET_MAX("VEND" & Empresa, "CVE_VEND", 5)
                tCVE_VEND.Enabled = False
                tNOMBRE.Text = ""
                tNOMBRE.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT N.CVE_VEND, N.STATUS, N.NOMBRE, N.COMI, N.CLASIFIC, N.CORREOE FROM VEND" & Empresa & " N WHERE CVE_VEND = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_VEND.Text = dr("CVE_VEND")
                    tNOMBRE.Text = dr("NOMBRE")
                    tCOMI.Value = dr("COMI")
                    tCLASIFIC.Text = dr("CLASIFIC")
                    tCORREOE.Text = dr("CORREOE")
                Else
                    tCVE_VEND.Text = ""

                    tNOMBRE.Text = ""
                    tCOMI.Value = 0
                    tCLASIFIC.Text = ""
                    tCORREOE.Text = ""
                End If
                dr.Close()

                tCVE_VEND.Enabled = False
                tNOMBRE.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE VEND" & Empresa & " SET CVE_VEND = @CVE_VEND, NOMBRE = @NOMBRE, COMI = @COMI, " &
            "CLASIFIC = @CLASIFIC, CORREOE = @CORREOE " &
            "WHERE CVE_VEND = @CVE_VEND " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO VEND" & Empresa & " (CVE_VEND, STATUS, NOMBRE, COMI, CLASIFIC, CORREOE)" &
            " VALUES(@CVE_VEND, 'A', @NOMBRE, @COMI, @CLASIFIC, @CORREOE)"

        cmd.CommandText = SQL



        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = tCVE_VEND.Text

            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNOMBRE.Text
            cmd.Parameters.Add("@COMI", SqlDbType.Float).Value = tCOMI.Value
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = tCLASIFIC.Text
            cmd.Parameters.Add("@CORREOE", SqlDbType.VarChar).Value = tCORREOE.Text
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
