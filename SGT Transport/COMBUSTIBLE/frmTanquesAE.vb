Imports System.Data.SqlClient
Public Class frmTanquesAE
    Private Sub frmTanquesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        AssignValidation(Me.tT1_ANCHO, ValidationType.Only_Numbers)
        AssignValidation(Me.tT1_ALTO, ValidationType.Only_Numbers)
        AssignValidation(Me.tT1_PROFUNDIDAD, ValidationType.Only_Numbers)
        AssignValidation(Me.tT1_LITROS, ValidationType.Only_Numbers)

        AssignValidation(Me.tT2_ANCHO, ValidationType.Only_Numbers)
        AssignValidation(Me.tT2_ALTO, ValidationType.Only_Numbers)
        AssignValidation(Me.tT2_PROFUNDIDAD, ValidationType.Only_Numbers)
        AssignValidation(Me.tT2_LITROS, ValidationType.Only_Numbers)

        If Var1 = "Nuevo" Then
            Try
                tCVE_TAQ.Text = GET_MAX("GCTANQUES", "CVE_TAQ")
                tCVE_TAQ.Enabled = False
                tT1_ANCHO.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT T.CVE_TAQ, T.T1_ANCHO, T.T1_ALTO, T.T1_PROFUNDIDAD, T.T1_LITROS, T.T2_ANCHO, T.T2_ALTO, T.T2_PROFUNDIDAD, 
                      T.T2_LITROS, T.UUID FROM GCTANQUES T WHERE CVE_TAQ = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_TAQ.Text = dr("CVE_TAQ").ToString
                    tT1_ANCHO.Text = dr("T1_ANCHO").ToString
                    tT1_ALTO.Text = dr("T1_ALTO").ToString
                    tT1_PROFUNDIDAD.Text = dr("T1_PROFUNDIDAD").ToString
                    tT1_LITROS.Text = dr("T1_LITROS").ToString
                    tT2_ANCHO.Text = dr("T2_ANCHO").ToString
                    tT2_ALTO.Text = dr("T2_ALTO").ToString
                    tT2_PROFUNDIDAD.Text = dr("T2_PROFUNDIDAD").ToString
                    tT2_LITROS.Text = dr("T2_LITROS").ToString
                Else
                    tCVE_TAQ.Text = 0
                    tT1_ANCHO.Text = 0
                    tT1_ALTO.Text = 0
                    tT1_PROFUNDIDAD.Text = 0
                    tT1_LITROS.Text = 0
                    tT2_ANCHO.Text = 0
                    tT2_ALTO.Text = 0
                    tT2_PROFUNDIDAD.Text = 0
                    tT2_LITROS.Text = 0
                End If
                dr.Close()

                tCVE_TAQ.Enabled = False
                tT1_ANCHO.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmTanquesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCTANQUES SET T1_ANCHO = @T1_ANCHO, T1_ALTO = @T1_ALTO, T1_PROFUNDIDAD = @T1_PROFUNDIDAD, 
            T1_LITROS = @T1_LITROS, T2_ANCHO = @T2_ANCHO, T2_ALTO = @T2_ALTO, T2_PROFUNDIDAD = @T2_PROFUNDIDAD, T2_LITROS = @T2_LITROS
            WHERE CVE_TAQ = @CVE_TAQ 
            IF @@ROWCOUNT = 0 
            INSERT INTO GCTANQUES (CVE_TAQ, STATUS, T1_ANCHO, T1_ALTO, T1_PROFUNDIDAD, T1_LITROS, T2_ANCHO, T2_ALTO, T2_PROFUNDIDAD, T2_LITROS, UUID)
            VALUES (@CVE_TAQ, 'A', @T1_ANCHO, @T1_ALTO, @T1_PROFUNDIDAD, @T1_LITROS, @T2_ANCHO, @T2_ALTO, @T2_PROFUNDIDAD, @T2_LITROS, NEWID())"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_TAQ", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_TAQ.Text)
            cmd.Parameters.Add("@T1_ANCHO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT1_ANCHO.Text)
            cmd.Parameters.Add("@T1_ALTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT1_ALTO.Text)
            cmd.Parameters.Add("@T1_PROFUNDIDAD", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT1_PROFUNDIDAD.Text)
            cmd.Parameters.Add("@T1_LITROS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT1_LITROS.Text)
            cmd.Parameters.Add("@T2_ANCHO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT2_ANCHO.Text)
            cmd.Parameters.Add("@T2_ALTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT2_ALTO.Text)
            cmd.Parameters.Add("@T2_PROFUNDIDAD", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT2_PROFUNDIDAD.Text)
            cmd.Parameters.Add("@T2_LITROS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tT2_LITROS.Text)
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
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub frmTanquesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
End Class
