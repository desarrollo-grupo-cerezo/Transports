Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmPropietariosAE

    Private Sub frmPropiedtariosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmPropiedtariosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub frmPropiedtariosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                
                tCVE_PROP.Text = GET_MAX("GCPROPIETARIOS", "CVE_PROP")
                tCVE_PROP.Enabled = False
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

                SQL = "SELECT P.CVE_PROP, P.STATUS, P.NOMBRE FROM GCPROPIETARIOS P WHERE CVE_PROP = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PROP.text = dr("CVE_PROP")

                    tNOMBRE.text = dr("NOMBRE")
                Else
                    tCVE_PROP.text = ""
                    
                    tNOMBRE.text = ""
                End If
                dr.Close()

                tCVE_PROP.Enabled = False
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


        If tNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPROPIETARIOS SET CVE_PROP = @CVE_PROP, NOMBRE = @NOMBRE" &
            " WHERE CVE_PROP = @CVE_PROP " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPROPIETARIOS (CVE_PROP, STATUS, NOMBRE) VALUES(@CVE_PROP, 'A', @NOMBRE)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_PROP", SqlDbType.SmallInt).Value = tCVE_PROP.Text

            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNOMBRE.Text

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
            msgbox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub
End Class
