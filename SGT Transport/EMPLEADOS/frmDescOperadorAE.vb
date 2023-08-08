Imports System.Data.SqlClient

Public Class frmDescOperadorAE
    Private Sub frmDescOperadorAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.CustomFormat = "dd/MM/yyyy"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.EditFormat.CustomFormat = "dd/MM/yyyy"


        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        F1.Value = Now
        F2.Value = Now
        tFOLIO.Text = ""
        tCVE_OPER.Text = ""
        tNUM_CPTO.Text = ""
        tCVE_TIP.Text = ""
        tCVE_FOR.Text = ""
        tIMPORTE.Value = 0
        tSTR_OBS.Text = ""

        If Var1 = "Nuevo" Then
            Try
                tFOLIO.Text = GET_MAX("GCDESC_OPERADOR", "FOLIO")
                tFOLIO.Enabled = False
                F1.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT D.FOLIO, D.FECHA1, D.FECHA2, D.CVE_OPER, D.NUM_CPTO, D.CVE_TIP, D.CVE_FOR, D.STATUS, D.IMPORTE, D.CVE_OBS, 
                    OB.DESCR AS STR_OBS, CUEN_CONT
                    FROM GCDESC_OPERADOR D
                    LEFT JOIN GCOBS OB ON OB.CVE_OBS = D.CVE_OBS
                    WHERE FOLIO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tFOLIO.Text = dr("FOLIO").ToString
                    If IsDate(dr("FECHA1").ToString) Then
                        F1.Value = dr("FECHA1").ToString
                    Else
                        F1.Value = Now
                    End If
                    If IsDate(dr("FECHA2").ToString) Then
                        F2.Value = dr("FECHA2").ToString
                    Else
                        F2.Value = Now
                    End If
                    tCVE_OPER.Text = dr("CVE_OPER").ToString
                    LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)

                    tNUM_CPTO.Text = dr("NUM_CPTO").ToString
                    LtNumCpto.Text = BUSCA_CAT("GCConc", tNUM_CPTO.Text)

                    tCVE_TIP.Text = dr("CVE_TIP").ToString
                    LtTipoDesc.Text = BUSCA_CAT("TipoDescuento", tCVE_TIP.Text)

                    tCVE_FOR.Text = dr("CVE_FOR").ToString
                    LtFormaDesc.Text = BUSCA_CAT("FormaDescuento", tCVE_FOR.Text)

                    tIMPORTE.Value = dr("IMPORTE").ToString

                    tSTR_OBS.Text = dr("CVE_OBS").ToString
                    tSTR_OBS.Text = dr("STR_OBS").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                End If
                dr.Close()

                tFOLIO.Enabled = False
                F1.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmDescOperadorAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim CVE_OBS As Long
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            If tSTR_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(tSTR_OBS.Tag) Then
                    CVE_OBS = tSTR_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tSTR_OBS.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tSTR_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            End If

            tSTR_OBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCDESC_OPERADOR SET FOLIO = @FOLIO, FECHA1 = @FECHA1, FECHA2 = @FECHA2, CVE_OPER = @CVE_OPER, NUM_CPTO = @NUM_CPTO,
            CVE_TIP = @CVE_TIP, CVE_FOR = @CVE_FOR, IMPORTE = @IMPORTE, CVE_OBS = @CVE_OBS, CUEN_CONT = @CUEN_CONT
            WHERE FOLIO = @FOLIO 
            IF @@ROWCOUNT = 0
            INSERT INTO GCDESC_OPERADOR (FOLIO, FECHA1, FECHA2, CVE_OPER, NUM_CPTO, CVE_TIP, CVE_FOR, STATUS, IMPORTE, CVE_OBS, CUEN_CONT)
            VALUES(@FOLIO, @FECHA1, @FECHA2, @CVE_OPER, @NUM_CPTO, @CVE_TIP, @CVE_FOR, 'A', @IMPORTE, @CVE_OBS, @CUEN_CONT)"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFOLIO.Text)
            cmd.Parameters.Add("@FECHA1", SqlDbType.Date).Value = F1.Value
            cmd.Parameters.Add("@FECHA2", SqlDbType.Date).Value = F2.Value
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = tCVE_OPER.Text
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
            cmd.Parameters.Add("@CVE_TIP", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_TIP.Text)
            cmd.Parameters.Add("@CVE_FOR", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_FOR.Text)
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tIMPORTE.Value)
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
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

    Private Sub frmDescOperadorAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
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
                tNUM_CPTO.Focus()
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
                tCVE_TIP.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTipoDesc_Click(sender As Object, e As EventArgs) Handles btnTipoDesc.Click
        Try
            Var2 = "TipoDescuento" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TIP.Text = Var4
                LtTipoDesc.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_FOR.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFormaDesc_Click(sender As Object, e As EventArgs) Handles btnFormaDesc.Click
        Try
            Var2 = "FormaDescuento" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_FOR.Text = Var4
                LtFormaDesc.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tIMPORTE.Focus()
            End If
        Catch ex As Exception
            msgbox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
