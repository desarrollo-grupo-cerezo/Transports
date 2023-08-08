Imports System.Data.SqlClient
Public Class frmNivelCombustibleAE
    Private Sub frmNivelCombustibleAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        tAltura.Value = 0
        tLitros.Value = 0
        F1.Value = Now

        tID_TABLA.Value = 0
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCNIVELCOMBUSTIBLE", "CLAVE")
                tClave.Enabled = False
                tID_TABLA.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CLAVE, ID_TABLA, M.ALTURA, M.LITROS, FECHA " &
                      "FROM GCNIVELCOMBUSTIBLE M WHERE CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CLAVE").ToString
                    tID_TABLA.Value = dr("ID_TABLA").ToString
                    tAltura.Value = dr("ALTURA").ToString
                    tLitros.Value = dr("LITROS").ToString
                    If IsDate(dr("FECHA")) Then
                        F1.Value = dr("FECHA")
                    End If
                End If
                dr.Close()

                tClave.Enabled = False
                tID_TABLA.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmNivelCombustibleAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmNivelCombustibleAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        tLitros.Focus()
        tAltura.Focus()

        SQL = "UPDATE GCNIVELCOMBUSTIBLE SET ID_TABLA = @ID_TABLA, ALTURA = @ALTURA, LITROS = @LITROS,  FECHA = @FECHA " &
            "WHERE CLAVE = @CLAVE " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCNIVELCOMBUSTIBLE (CLAVE, ID_TABLA, STATUS, ALTURA, LITROS, FECHA, FECHAELAB)  VALUES(@CLAVE, @ID_TABLA, 'A', @ALTURA, @LITROS, @FECHA, GETDATE())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tClave.Text)
            cmd.Parameters.Add("@ID_TABLA", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tID_TABLA.Value)
            cmd.Parameters.Add("@ALTURA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tAltura.Value)
            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tLitros.Value)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
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
    Private Sub frmNivelCombustibleAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

End Class
