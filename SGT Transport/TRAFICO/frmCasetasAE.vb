Imports System.Data.SqlClient
Public Class frmCasetasAE
    Private Sub frmCasetasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        Try
            cboTipoPago.Items.Clear()
            cboTipoPago.Items.Add("M")
            cboTipoPago.Items.Add("E")

            cboTipoPago.SelectedIndex = 0
            tCVE_CAS.Text = ""
            tDescr.Text = ""
            tIMPORTE1.Value = 0
            tImporte.Value = 0
            tImporte2.Value = 0
            tImporte3.Value = 0
            tImporte4.Value = 0
            tImporte5.Value = 0
            tImporte6.Value = 0
            tImporte7.Value = 0
            tImporte8.Value = 0
            tCVE_PLAZA.Tag = ""
            LtPlaza.Tag = ""
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tCVE_CAS.Text = GET_MAX("GCCASETAS", "CVE_CAS")
                tCVE_CAS.Enabled = False
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

                SQL = "SELECT C.CVE_CAS, C.STATUS, C.DESCR, C.TIPO_PAGO, C.IMPORTE1, C.IMPORTE, C.IMPORTE2, C.IMPORTE3, C.IMPORTE4, C.IMPORTE5,
                      C.IMPORTE6, C.IMPORTE7, C.IMPORTE8, ISNULL(C.CVE_PLAZA,0) AS CVE_PLA, ISNULL(P1.CIUDAD,'') AS PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                      FROM GCCASETAS C 
                      LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                      WHERE CVE_CAS = '" & Var2 & "' AND C.STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_CAS.Text = dr("CVE_CAS").ToString

                    tDescr.Text = dr("DESCR").ToString
                    If IsNumeric(dr("TIPO_PAGO").ToString) Then
                        If dr("TIPO_PAGO") = 0 Then
                            cboTipoPago.SelectedIndex = 0
                        Else
                            cboTipoPago.SelectedIndex = 1
                        End If
                    Else
                        cboTipoPago.SelectedIndex = 0
                    End If
                    tIMPORTE1.Value = dr.ReadNullAsEmptyDecimal("IMPORTE1")
                    tImporte.Value = dr.ReadNullAsEmptyDecimal("IMPORTE")
                    tImporte2.Value = dr.ReadNullAsEmptyDecimal("IMPORTE2")
                    tImporte3.Value = dr.ReadNullAsEmptyDecimal("IMPORTE3")
                    tImporte4.Value = dr.ReadNullAsEmptyDecimal("IMPORTE4")
                    tImporte5.Value = dr.ReadNullAsEmptyDecimal("IMPORTE5")
                    tImporte6.Value = dr.ReadNullAsEmptyDecimal("IMPORTE6")
                    tImporte7.Value = dr.ReadNullAsEmptyDecimal("IMPORTE7")
                    tImporte8.Value = dr.ReadNullAsEmptyDecimal("IMPORTE8")

                    tCVE_PLAZA.Text = dr("CVE_PLA")
                    tCVE_PLAZA.Tag = dr("ST_PLAZA")
                    LtPlaza.Tag = tCVE_PLAZA.Text

                    If tCVE_PLAZA.Text = "0" Then tCVE_PLAZA.Text = ""
                    LtPlaza.Text = dr("PLAZA")
                End If
                dr.Close()

                tCVE_CAS.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmCasetasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
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
        ', CLAVE_OP = @CLAVE_OP, IAVE = @IAVE
        SQL = "UPDATE GCCASETAS SET DESCR = @DESCR, TIPO_PAGO = @TIPO_PAGO, IMPORTE1 = @IMPORTE1, IMPORTE = @IMPORTE, IMPORTE2 = @IMPORTE2, 
            IMPORTE3 = @IMPORTE3, IMPORTE4 = @IMPORTE4, IMPORTE5 = @IMPORTE5, IMPORTE6 = @IMPORTE6, IMPORTE7 = @IMPORTE7, IMPORTE8 = @IMPORTE8,
            CVE_PLAZA = @CVE_PLAZA
            WHERE CVE_CAS = @CVE_CAS
            If @@ROWCOUNT = 0
            INSERT INTO GCCASETAS (CVE_CAS, STATUS, DESCR, TIPO_PAGO, IMPORTE1, IMPORTE, IMPORTE2, IMPORTE3, IMPORTE4, IMPORTE5, IMPORTE6, IMPORTE7, IMPORTE8,
            CVE_PLAZA) VALUES(@CVE_CAS, 'A', @DESCR, @TIPO_PAGO, @IMPORTE1, @IMPORTE, @IMPORTE2, @IMPORTE3, @IMPORTE4, @IMPORTE5, @IMPORTE6,
            @IMPORTE7, @IMPORTE8, @CVE_PLAZA)"

        ', CLAVE_OP, IAVE       , @CLAVE_OP, @IAVE
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_CAS", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_CAS.Text)

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.VarChar).Value = cboTipoPago.Text
            cmd.Parameters.Add("@IMPORTE1", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tIMPORTE1.Text)
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte.Text)
            cmd.Parameters.Add("@IMPORTE2", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte2.Text)
            cmd.Parameters.Add("@IMPORTE3", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte3.Text)
            cmd.Parameters.Add("@IMPORTE4", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte4.Text)
            cmd.Parameters.Add("@IMPORTE5", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte5.Text)
            cmd.Parameters.Add("@IMPORTE6", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte6.Text)
            cmd.Parameters.Add("@IMPORTE7", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte7.Text)
            cmd.Parameters.Add("@IMPORTE8", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tImporte8.Text)
            cmd.Parameters.Add("@CVE_PLAZA", SqlDbType.VarChar).Value = tCVE_PLAZA.Text
            'cmd.Parameters.Add("@CLAVE_OP", SqlDbType.VarChar).Value = tCLAVE_O.Text
            'cmd.Parameters.Add("@IAVE", SqlDbType.VarChar).Value = TIAVE.Text
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

    Private Sub frmCasetasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub btnPlaza_Click(sender As Object, e As EventArgs) Handles btnPlaza.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCLAVE_O.Focus()
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        Try
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                    tCLAVE_O.Focus()
                Else
                    If tCVE_PLAZA.Tag <> "B" And tCVE_PLAZA.Text <> LtPlaza.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA.Focus()
                        tCVE_PLAZA.Text = ""
                        LtPlaza.Text = ""
                    End If
                End If
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles btnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLAVE_O.Text = Var4
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TIAVE.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCLAVE_O_Validated(sender As Object, e As EventArgs) Handles tCLAVE_O.Validated
        Try
            If tCLAVE_O.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente operativo", tCLAVE_O.Text)
                If DESCR.Trim.Length > 0 Then
                    LtNombre1.Text = DESCR
                Else
                    MsgBox("Cliente operativo inexistente")
                    LtNombre1.Text = ""
                End If
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_CheckedChanged(sender As Object, e As EventArgs) Handles barGrabar.CheckedChanged

    End Sub
End Class
