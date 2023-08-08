Imports System.Data.SqlClient
Public Class frmTramosOficialesAE
    Private Sub frmTramosOficialesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        Try
            tCVE_TOF.Text = ""
            tDescr.Text = ""
            tRPD.Text = ""
            tRUTA.Text = ""
            tCLASE.Text = ""
            tKMS.Value = 0
            tALERTAS.Text = ""
        Catch ex As Exception
        End Try
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tCVE_TOF.Text = GET_MAX("GCTRAMOS_OFI", "CVE_TOF")
                tCVE_TOF.Enabled = False
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

                SQL = "SELECT T.CVE_TOF, T.STATUS, T.DESCR, T.RPD, T.RUTA, T.CLASE, T.KMS, T.ALERTAS FROM GCTRAMOS_OFI T WHERE CVE_TOF = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_TOF.Text = dr("CVE_TOF").ToString

                    tDescr.Text = dr("DESCR").ToString
                    tRPD.Text = dr("RPD").ToString
                    tRUTA.Text = dr("RUTA").ToString
                    tCLASE.Text = dr("CLASE").ToString
                    tKMS.Value = dr("KMS").ToString
                    tALERTAS.Text = dr("ALERTAS").ToString

                End If
                dr.Close()

                tCVE_TOF.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmTramosOficialesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmTramosOficialesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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


        SQL = "UPDATE GCTRAMOS_OFI SET CVE_TOF = @CVE_TOF, DESCR = @DESCR, RPD = @RPD, RUTA = @RUTA, CLASE = @CLASE, " &
            "KMS = @KMS, ALERTAS = @ALERTAS" &
            " WHERE CVE_TOF = @CVE_TOF " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCTRAMOS_OFI (CVE_TOF, STATUS, DESCR, RPD, RUTA, CLASE, KMS, ALERTAS)" &
            " VALUES(@CVE_TOF, 'A', @DESCR, @RPD, @RUTA, @CLASE, @KMS, @ALERTAS)"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_TOF", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_TOF.Text)

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@RPD", SqlDbType.VarChar).Value = tRPD.Text
            cmd.Parameters.Add("@RUTA", SqlDbType.VarChar).Value = tRUTA.Text
            cmd.Parameters.Add("@CLASE", SqlDbType.VarChar).Value = tCLASE.Text
            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKMS.Value)
            cmd.Parameters.Add("@ALERTAS", SqlDbType.VarChar).Value = tALERTAS.Text

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
