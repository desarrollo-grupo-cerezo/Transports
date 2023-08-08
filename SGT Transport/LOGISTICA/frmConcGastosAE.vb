Imports System.Data.SqlClient
Public Class frmConcGastosAE
    Private Sub frmConcGastosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                tClave.Text = GET_MAX("GCCONC_GASTOS", "CVE_GAS")
                tClave.Enabled = False
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

                SQL = "SELECT C.CVE_GAS, C.STATUS, C.DESCR, ISNULL(CLASIFIC,'') AS CLASIF, ISNULL(USUARIO,'') AS USUA, CUEN_CONT 
                    FROM GCCONC_GASTOS C WHERE CVE_GAS = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tClave.Text = dr("CVE_GAS")
                    tDescr.Text = dr("DESCR")
                    tCLASIFIC.Text = dr("CLASIF")
                    tUSUARIO.Text = dr("USUA")
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                Else
                    tClave.Text = ""
                    tDescr.Text = ""
                    tUSUARIO.Text = ""
                    tCUEN_CONT.Text = ""
                End If
                dr.Close()

                tClave.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmConcGastosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmConcGastosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCCONC_GASTOS SET CVE_GAS = @CVE_GAS, DESCR = @DESCR, CLASIFIC = @CLASIFIC, USUARIO = @USUARIO, CUEN_CONT = @CUEN_CONT " &
            "WHERE CVE_GAS = @CVE_GAS " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCONC_GASTOS (CVE_GAS, STATUS, DESCR, USUARIO, CUEN_CONT) VALUES(@CVE_GAS, 'A', @DESCR, @USUARIO, @CUEN_CONT)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_GAS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tClave.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = tCLASIFIC.Text
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tUSUARIO.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
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
    Private Sub frmConcGastosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        Try
            Var2 = "Usuario"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tUSUARIO.Text = Var4
                LtUsuario.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tClave.Focus()
            End If
        Catch Ex As Exception
            MsgBox("103. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("103. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tUSUARIO_KeyDown(sender As Object, e As KeyEventArgs) Handles tUSUARIO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUsuario_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tUSUARIO_Validated(sender As Object, e As EventArgs) Handles tUSUARIO.Validated
        Try
            If tUSUARIO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Usuario", tUSUARIO.Text)
                If DESCR <> "" Then
                    LtUsuario.Text = DESCR
                Else
                    MsgBox("Usuario inexistente")
                    tUSUARIO.Text = ""
                    tUSUARIO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
