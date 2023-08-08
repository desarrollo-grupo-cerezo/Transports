Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmAnticiposViajeAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private Key_Pres As Integer
    Private ARTICULO As String


    Private Sub frmAnticiposViajeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        ENTRA_KEY = True
        ENTRA = True
        ENTRA_BTN = True

        tCVE_OPER.MaxLength = 10
        tCVE_VIAJE.MaxLength = 10
        tCVE_AUT.MaxLength = 10
        tIMPORTE.Enabled = False

        tFECHA.Value = Date.Today
        tFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.CustomFormat = "dd/MM/yyyy"
        tFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        tCVE_ANTVI.Text = ""
        tFECHA.Value = Now
        tCVE_OPER.Text = ""
        LtOper.Text = ""
        tCVE_VIAJE.Text = ""
        LtViaje.Text = ""
        tIMPORTE.Value = 0
        tCVE_AUT.Text = ""
        LtAutoriza.Text = ""
        tNUM_CPTO.Text = ""
        LtNumCpto.Text = ""
        tCVE_OBS.Text = ""

        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tCVE_ANTVI.Text = GET_MAX("GCANTICIPOS_VIAJE", "CVE_ANTVI")
                tCVE_ANTVI.Enabled = False

                tCVE_OPER.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT A.CVE_ANTVI, A.FECHA, A.CVE_OPER, A.CVE_VIAJE, A.IMPORTE, A.CVE_AUT, A.NUM_CPTO, A.CVE_OBS, OB.DESCR AS OBS_STR " &
                    "FROM GCANTICIPOS_VIAJE A " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = A.CVE_OBS " &
                    "WHERE CVE_ANTVI = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_ANTVI.Text = dr("CVE_ANTVI").ToString
                    If IsDate(dr("FECHA").ToString) Then
                        tFECHA.Value = dr("FECHA").ToString
                    Else
                        tFECHA.Value = Now
                    End If

                    tCVE_OPER.Text = dr("CVE_OPER").ToString
                    LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
                    tCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                    LtViaje.Text = BUSCA_CAT("Viajes", tCVE_VIAJE.Text)

                    tIMPORTE.Value = dr("IMPORTE").ToString

                    tCVE_AUT.Text = dr("CVE_AUT").ToString
                    LtAutoriza.Text = BUSCA_CAT("Autoriza", tCVE_AUT.Text)

                    tNUM_CPTO.Text = dr("NUM_CPTO").ToString
                    LtNumCpto.Text = BUSCA_CAT("GCConc", tNUM_CPTO.Text)

                    tCVE_OBS.Text = dr("OBS_STR").ToString
                    tCVE_OBS.Tag = dr("CVE_OBS").ToString
                End If
                dr.Close()

                ENTRA = True
                tCVE_ANTVI.Enabled = False
                tCVE_OPER.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmAnticiposViajeAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmAnticiposViajeAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA_KEY Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_OBS As Long
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tCVE_OPER.Text.Trim.Length = 0 Then
            MsgBox("La clave del operador no debe quedar vacia, verifique por favor")
            Return
        End If
        If tIMPORTE.Value = 0 Then
            MsgBox("El importe no debe ser cero, verifique por favor")
            Return
        End If
        If tNUM_CPTO.Text.Trim.Length = 0 Then
            MsgBox("El cocento no debe quedar vacia, verifique por favor")
            Return
        End If
        Try
            If tCVE_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(tCVE_OBS.Tag) Then
                    CVE_OBS = tCVE_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tCVE_OBS.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tCVE_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            End If

            tCVE_OBS.Tag = CVE_OBS

        Catch ex As Exception
            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        SQL = "UPDATE GCANTICIPOS_VIAJE SET FECHA = @FECHA, CVE_OPER = @CVE_OPER, CVE_VIAJE = @CVE_VIAJE, IMPORTE = @IMPORTE, CVE_AUT = @CVE_AUT, " &
            "NUM_CPTO = @NUM_CPTO, CVE_OBS = @CVE_OBS " &
            "WHERE CVE_ANTVI = @CVE_ANTVI " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCANTICIPOS_VIAJE (CVE_ANTVI, STATUS, FECHA, CVE_OPER, CVE_VIAJE, IMPORTE, CVE_AUT, NUM_CPTO, CVE_OBS)" &
            " VALUES(@CVE_ANTVI, 'A', @FECHA, @CVE_OPER, @CVE_VIAJE, @IMPORTE, @CVE_AUT, @NUM_CPTO, @CVE_OBS)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_ANTVI", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_ANTVI.Text)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = tFECHA.Text
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = tCVE_OPER.Text
            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = tCVE_VIAJE.Text
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tIMPORTE.Value)
            cmd.Parameters.Add("@CVE_AUT", SqlDbType.VarChar).Value = tCVE_AUT.Text
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
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
            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_VIAJE.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnViaje_Click(sender As Object, e As EventArgs) Handles btnViaje.Click
        Try
            Var2 = "Viajes" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_VIAJE.Text = Var4
                LtViaje.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_AUT.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "GCConc" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                LtNumCpto.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_OBS.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If tCVE_OPER.Text.Trim.Length > 0 Then
                LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
            End If
        End If
    End Sub
    Private Sub tCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_VIAJE.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnViaje_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If tCVE_VIAJE.Text.Trim.Length > 0 Then
                LtViaje.Text = BUSCA_CAT("Viajes", tCVE_VIAJE.Text)
            End If
        End If
    End Sub
    Private Sub tCVE_AUT_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_AUT.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnAutoriza_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If tCVE_AUT.Text.Trim.Length > 0 Then
                LtAutoriza.Text = BUSCA_CAT("Autoriza", tCVE_AUT.Text)
            End If
        End If
    End Sub
    Private Sub btnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        Try
            Var2 = "Autoriza" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_AUT.Text = Var4
                LtAutoriza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tIMPORTE.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNumCpto_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If tNUM_CPTO.Text.Trim.Length > 0 Then
                LtNumCpto.Text = BUSCA_CAT("GCConc", tNUM_CPTO.Text)
            End If
        End If
    End Sub

    Private Sub tCVE_OBS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OBS.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If CType(sender, TextBox).Multiline Then
                    e.SuppressKeyPress = True  'TAMBIEN SUPRIME DING
                End If
            End If
        Catch ex As Exception
            msgbox("112. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
