Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmEstadosAE
    Private Sub frmEstadosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        Try
            tID.Text = ""
            TCLAVE_SAT_EST.Text = ""
            tNOMBRE.Text = ""
            TPAIS.Text = ""
            TCLAVE_SAT_PAIS.Text = ""
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tID.Text = GET_MAX("GCESTADOS", "CVE_ESTADO")
                tID.Enabled = False
                tNOMBRE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT E.CVE_ESTADO, E.NUM_ESTADO, E.NOMBRE, E.PAIS, CLAVE_SAT_EST, CLAVE_SAT_PAIS 
                    FROM GCESTADOS E WHERE CVE_ESTADO = " & Var2 & " AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tID.Text = dr("CVE_ESTADO")
                    tNOMBRE.Text = dr.ReadNullAsEmptyString("NOMBRE")
                    TCLAVE_SAT_EST.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                    If dr.ReadNullAsEmptyString("PAIS").ToString.Trim.Length = 0 Then
                        TPAIS.Text = "MEXICO"
                        TCLAVE_SAT_PAIS.Text = "MEX"
                    Else
                        TPAIS.Text = dr.ReadNullAsEmptyString("PAIS")
                        TCLAVE_SAT_PAIS.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                    End If
                Else
                    tID.Text = ""
                    TCLAVE_SAT_EST.Text = ""
                    tNOMBRE.Text = ""
                    TPAIS.Text = ""
                    TCLAVE_SAT_PAIS.Text = ""
                End If
                dr.Close()

                tID.Enabled = False
                tNOMBRE.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmEstadosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub
    Private Sub frmEstadosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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


        SQL = "UPDATE GCESTADOS SET NOMBRE = @NOMBRE, CLAVE_SAT_EST = @CLAVE_SAT_EST, PAIS = @PAIS, CLAVE_SAT_PAIS = @CLAVE_SAT_PAIS
            WHERE CVE_ESTADO = @CVE_ESTADO
            IF @@ROWCOUNT = 0
            INSERT INTO GCESTADOS (CVE_ESTADO, STATUS, NOMBRE, CLAVE_SAT_EST, PAIS, CLAVE_SAT_PAIS)  VALUES 
            (@CVE_ESTADO, 'A', @NOMBRE, @CLAVE_SAT_EST, @PAIS, @CLAVE_SAT_PAIS)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_ESTADO", SqlDbType.Int).Value = tID.Text
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNOMBRE.Text
            cmd.Parameters.Add("@CLAVE_SAT_EST", SqlDbType.VarChar).Value = TCLAVE_SAT_EST.Text
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text
            cmd.Parameters.Add("@CLAVE_SAT_PAIS", SqlDbType.VarChar).Value = TCLAVE_SAT_PAIS.Text
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

        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
End Class
