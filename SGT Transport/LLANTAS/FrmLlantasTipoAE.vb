Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmLlantasTipoAE

    Private Sub FrmLlantasTipoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        C1SuperTooltip1.SetToolTip(BarGrabar, "F2 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then

            Try

                TClave.Text = GET_MAX("GCLLANTA_TIPO", "CVE_TIPO")
                TClave.Enabled = False
                TDescr.Text = ""
                TDescr.Select()

            Catch ex As Exception
                MsgBox("1.0. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1.0. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else

            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT CVE_TIPO, DESCR FROM GCLLANTA_TIPO WHERE CVE_TIPO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                Do While dr.Read
                    TClave.Text = dr("CVE_TIPO")
                    TDescr.Text = dr("DESCR")
                Loop
                dr.Close()

                TClave.Enabled = False
                TDescr.Select()

            Catch ex As Exception
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmLlantasTipoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmLlantasTipoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

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

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE


        SQL = "UPDATE GCLLANTA_TIPO SET CVE_TIPO = @CVE_TIPO, DESCR = @DESCR" &
            " WHERE CVE_TIPO = @CVE_TIPO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCLLANTA_TIPO (CVE_TIPO, STATUS, DESCR) VALUES(@CVE_TIPO, 'A', @DESCR)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_TIPO", SqlDbType.VarChar).Value = TClave.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDescr.Text

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
            MsgBox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
