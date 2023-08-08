Imports System.Data.SqlClient
Public Class frmCentroCostosAE
    Private Sub frmCentroCostosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        tDescr.MaxLength = 120
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tCVE_COSTOS.Text = GET_MAX("GCCENTRO_COSTOS", "CVE_COSTOS")
                tCVE_COSTOS.Enabled = False
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

                Me.KeyPreview = True

                SQL = "SELECT C.CVE_COSTOS, C.DESCR  FROM GCCENTRO_COSTOS C WHERE CVE_COSTOS = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_COSTOS.Text = dr("CVE_COSTOS").ToString
                    tDescr.Text = dr("DESCR").ToString
                Else
                    tCVE_COSTOS.Text = 0
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_COSTOS.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmCentroCostosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmCentroCostosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCCENTRO_COSTOS SET DESCR = @DESCR " &
            " WHERE CVE_COSTOS = @CVE_COSTOS " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCENTRO_COSTOS (CVE_COSTOS, DESCR, STATUS, GUID) VALUES(@CVE_COSTOS, @DESCR, 'A', NEWID())"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_COSTOS", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_COSTOS.text)
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
            msgbox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '==========================================================================
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
