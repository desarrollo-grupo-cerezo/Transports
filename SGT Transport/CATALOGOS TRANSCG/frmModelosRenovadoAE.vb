Imports System.Data.SqlClient


Public Class frmModelosRenovadoAE

    Private Sub frmModelosRenovadoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmModelosRenovadoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

                
                tClave.Text = GET_MAX("GCMODELO_RENOVADO", "CVE_MODELO")
                tClave.Enabled = False
                tDescr.Text = ""
                tDescr.Select()

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

                SQL = "SELECT M.CVE_MODELO, M.STATUS, M.DESCR FROM GCMODELO_RENOVADO M WHERE CVE_MODELO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CVE_MODELO")

                    tDescr.Text = dr("DESCR")
                Else
                    tClave.Text = ""
                    
                    tDescr.Text = ""
                End If
                dr.Close()

                tClave.Enabled = False
                tDescr.Select()

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

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCMODELO_RENOVADO SET CVE_MODELO = @CVE_MODELO, DESCR = @DESCR " &
            "WHERE CVE_MODELO = @CVE_MODELO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMODELO_RENOVADO (CVE_MODELO, STATUS, DESCR) VALUES(@CVE_MODELO, 'A', @DESCR)"

        cmd.CommandText = SQL



        Try
            cmd.Parameters.Add("@CVE_MODELO", SqlDbType.VarChar).Value = tClave.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text

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
