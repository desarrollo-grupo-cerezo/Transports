Imports System.Data.SqlClient
Public Class frmSt_Gastos_ViajeAE
    Private Sub frmSt_Gastos_ViajeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tCVE_GAV.Text = GET_MAX("GCSTATUS_GASTOS_VIAJE", "CVE_GAV")
                tCVE_GAV.Enabled = False
                tCLASIFIC.Text = ""
                tDescr.Text = ""
                tCLASIFIC.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                'CREA_CAMPO("GCSTATUS_GASTOS_VIAJE", "CLASIFIC", "VARCHAR", "40", "")
                SQL = "SELECT S.CVE_GAV, S.STATUS, S.CLASIFIC, S.DESCR FROM GCSTATUS_GASTOS_VIAJE S WHERE CVE_GAV = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_GAV.Text = dr("CVE_GAV").ToString
                    tCLASIFIC.Text = dr("CLASIFIC").ToString
                    tDescr.Text = dr("DESCR").ToString
                Else
                    tCVE_GAV.Text = ""
                    tCLASIFIC.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                tCVE_GAV.Enabled = False
                tCLASIFIC.Select()
            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmSt_Gastos_ViajeAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmSt_Gastos_ViajeAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCSTATUS_GASTOS_VIAJE SET CLASIFIC = @CLASIFIC, DESCR = @DESCR " &
            "WHERE CVE_GAV = @CVE_GAV " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCSTATUS_GASTOS_VIAJE (CVE_GAV, STATUS, CLASIFIC, DESCR, UUID) VALUES(@CVE_GAV, 'A', @CLASIFIC, @DESCR, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_GAV", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_GAV.Text)
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = tCLASIFIC.Text
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
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
