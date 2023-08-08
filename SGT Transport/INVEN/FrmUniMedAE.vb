﻿Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmUniMedAE
    Private Sub frmUniMedAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tCVE_MED.Text = GET_MAX("GCUNI_MED", "CVE_MED")
                tCVE_MED.Enabled = False
                tDESCR.Text = ""
                tDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT U.CVE_MED, U.STATUS, U.DESCR FROM GCUNI_MED U WHERE CVE_MED = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_MED.Text = dr("CVE_MED").ToString
                    tDESCR.text = dr("DESCR").ToString
                Else
                    tCVE_MED.Text = ""
                    
                    tDESCR.text = ""
                End If
                dr.Close()

                tCVE_MED.Enabled = False
                tDESCR.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmUniMedAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If


        SQL = "UPDATE GCUNI_MED SET CVE_MED = @CVE_MED, DESCR = @DESCR " &
            "WHERE CVE_MED = @CVE_MED " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCUNI_MED (CVE_MED, STATUS, DESCR) VALUES(@CVE_MED, 'A', @DESCR)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_MED", SqlDbType.VarChar).Value = tCVE_MED.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDESCR.Text

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

    Private Sub frmUniMedAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
End Class
