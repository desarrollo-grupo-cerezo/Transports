Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmDeducOperAE
    Private IsNew As Boolean
    Private SeGrabo As Boolean = False
    Private Sub FrmDeducOperAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FOLIO As Long

        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG

            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            BtnDeduc.FlatStyle = FlatStyle.Flat
            BtnDeduc.FlatAppearance.BorderSize = 0
        Catch ex As Exception
        End Try
        Me.WindowState = FormWindowState.Maximized

        Try
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1

            LtFOLIO.Tag = ""
        Catch ex As Exception
        End Try

        FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
        LtFOLIO.Text = Format(FOLIO, "00000000")


        If Var1 = "Nuevo" Then
            Try
                IsNew = True
                TCVE_OPER.Text = ""
                TCVE_OPER.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                TCVE_OPER.Enabled = False
                BtnOper.Enabled = False

                IsNew = False

                If Not IsNumeric(Var2) Then
                    Var2 = "0"
                End If
                SQL = "SELECT D.CVE_DED_OPER, D.FOLIO, D.CVE_OPER, D.CVE_DED, CASE WHEN D.STATUS = 'A' THEN 'PENDIENTE' ELSE 'PAGADO' END AS ST_DED, 
                    D.DESCR, D.IMPORTE_PRESTAMO, D.IMPORTE_PAGADO, D.SALDO, 
                    ISNULL((SELECT SUM(LD.IMPORTE) FROM GCDEDUC_OPER DD
                    LEFT JOIN GCLIQ_DEDUCCIONES LD ON LD.CVE_DED = DD.FOLIO    
                    LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LD.CVE_LIQ
                    WHERE L.CVE_ST_LIQ = 2 AND LD.STATUS = 'A' AND LD.CVE_DED = D.FOLIO),0) AS SALDO2,
                    D.PAGO_EN_LIQ, D.SALDO_ACTUAL, D.FECHA, C.DESCR AS DESCR_DED
                    FROM GCDEDUC_OPER D 
                    LEFT JOIN GCDEDUCCIONES C ON C.CVE_DED = D.CVE_DED
                    WHERE CVE_OPER = '" & Var2 & "' AND D.STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                Do While dr.Read
                    TCVE_OPER.Text = dr("CVE_OPER")
                    Fg.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("DESCR") & vbTab &
                               dr("CVE_DED") & vbTab & dr("DESCR_DED") & vbTab & dr("IMPORTE_PRESTAMO") & vbTab & dr("SALDO2") & vbTab &
                               dr("IMPORTE_PRESTAMO") - dr("SALDO2") & vbTab & dr("ST_DED"))
                Loop
                dr.Close()
                TDESCR.Select()

                LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmDeducOperAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Deduccion operador")

        If SeGrabo Then
            FrmDeducOper.DESPLEGAR()
        End If

    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click
        Try
            For k = 1 To Fg2.Rows.Count - 1
                Try

                Catch ex As Exception
                    Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        If TCVE_OPER.Text.Trim.Length = 0 Then
            MsgBox("Por favor captura el operador")
            TCVE_OPER.Select()
            Return
        End If
        If TCVE_DED.Text.Trim.Length = 0 Then
            MsgBox("Por favor captura la deduccion")
            TCVE_DED.Select()
            Return
        End If
        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la descripción")
            TDESCR.Select()
            Return
        End If

        If MsgBox("Realmente desea grabar la deducción?", vbYesNo) = vbNo Then
            Return
        End If
        Dim FOLIO As Long, IMPORTE As Decimal, CVE_DED_OPER As Long

        Fg.Select()
        Try
            If IsNothing(TIMPORTE.Value) Then
                IMPORTE = 0
            Else
                If Not IsNumeric(TIMPORTE.Value) Then
                    If Not IsNumeric(TIMPORTE.Text) Then
                        IMPORTE = 0
                    Else
                        IMPORTE = TIMPORTE.Text
                    End If
                Else
                    IMPORTE = TIMPORTE.Value
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If IMPORTE = 0 Then
            MsgBox("Por favor capture el importe")
            TIMPORTE.Select()
            Return
        End If

        If IsNew Then
            If LtFOLIO.Tag = "VERIFICADO" Then
                CVE_DED_OPER = LtFOLIO.Text
            Else
                CVE_DED_OPER = CLng(LtFOLIO.Text)
                CVE_DED_OPER = VERIFICAR_SIGUIENTE_FOLIO_GCDEDUC_OPER(CVE_DED_OPER)
            End If
        Else
            CVE_DED_OPER = LtFOLIO.Text
        End If

        FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
        SQL = "INSERT INTO GCDEDUC_OPER (CVE_DED_OPER, FOLIO, CVE_OPER, CVE_DED, STATUS, DESCR, IMPORTE_PRESTAMO, IMPORTE_PAGADO, SALDO, 
            PAGO_EN_LIQ, SALDO_ACTUAL, FECHA, FECHAELAB, UUID) VALUES (@CVE_DED_OPER, @FOLIO, @CVE_OPER, @CVE_DED, 'A', @DESCR, 
            @IMPORTE_PRESTAMO, @IMPORTE_PAGADO, @SALDO, @PAGO_EN_LIQ, @SALDO_ACTUAL, @FECHA, GETDATE(), NEWID())"
        Try
            For k = 1 To 5
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_DED_OPER", SqlDbType.Int).Value = CVE_DED_OPER
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                        cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                        cmd.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_DED.Text)
                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                        cmd.Parameters.Add("@IMPORTE_PRESTAMO", SqlDbType.Float).Value = IMPORTE
                        cmd.Parameters.Add("@IMPORTE_PAGADO", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@SALDO", SqlDbType.Float).Value = IMPORTE
                        cmd.Parameters.Add("@PAGO_EN_LIQ", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Fg.AddItem("" & vbTab & FOLIO & vbTab & F1.Value & vbTab & TDESCR.Text & vbTab &
                                           TCVE_DED.Text & vbTab & LtDeduc.Text & vbTab & TIMPORTE.Value & vbTab & "0" & vbTab & TIMPORTE.Value)

                                LtFOLIO.Tag = "VERIFICADO"
                                LtFOLIO.Text = Format(CVE_DED_OPER, "00000000")
                                TCVE_OPER.ReadOnly = True
                                BtnOper.Enabled = False

                                SeGrabo = True
                                TCVE_DED.Text = ""
                                TDESCR.Text = ""
                                LtDeduc.Text = ""
                                TIMPORTE.Value = 0
                                F1.Value = Now
                                TCVE_DED.Select()
                                Exit For
                            End If
                        End If
                    End Using
                    FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
                Catch ex As Exception
                    Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Function VERIFICAR_SIGUIENTE_FOLIO_GCDEDUC_OPER(fCVE_DED_OPER As Long) As Long
        Dim SIGUE As Boolean = True
        Try
            Do While SIGUE

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_DED_OPER FROM GCDEDUC_OPER WHERE CVE_DED_OPER = " & fCVE_DED_OPER
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            fCVE_DED_OPER += 1
                        Else
                            SIGUE = False
                        End If
                    End Using
                End Using

            Loop
            Return fCVE_DED_OPER
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return fCVE_DED_OPER
        End Try
    End Function
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_DED.Select()
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_DED.Select()
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                    TCVE_OPER.Select()
                End If
            Else
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnDeduc_Click(sender As Object, e As EventArgs) Handles BtnDeduc.Click
        Try
            Var2 = "Deducciones"
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_DED.Text = Var4
                LtDeduc.Text = Var5

                BUSCA_DEDUCCIONES(CLng(Var4))

                TDESCR.Select()
            End If
        Catch ex As Exception
            Bitacora("1540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_DED_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DED.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnDeduc_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_DED_Validated(sender As Object, e As EventArgs) Handles TCVE_DED.Validated
        Try
            If TCVE_DED.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Deduccion", TCVE_DED.Text)
                If DESCR <> "" Then
                    LtDeduc.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TDESCR.Select()
                Else
                    MsgBox("Deducción inexistente")
                    LtDeduc.Text = ""
                    TCVE_DED.Text = ""
                    TCVE_DED.Select()
                End If
            Else
                LtDeduc.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles F1.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                TCVE_OPER.Select()
                TCVE_OPER.Focus()
                TCVE_OPER.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmDeducOperAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Sub BUSCA_DEDUCCIONES(fDEDUC As Long)
        Try
            Dim SALDO As Decimal = 0, IMPORTE_PRESTAMO As Decimal = 0

            If Fg.Row > 0 Then

                If IsNumeric(Fg(Fg.Row, 6)) Then
                    IMPORTE_PRESTAMO = CDec(Fg(Fg.Row, 6))
                Else
                    IMPORTE_PRESTAMO = 0
                End If

                SALDO = IMPORTE_PRESTAMO
                Fg2.Rows.Count = 1
                If IsNumeric(fDEDUC) Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT D.FOLIO, LD.FECHA, LD.CVE_LIQ, LD.IMPORTE, D.IMPORTE_PRESTAMO, SALDO
                            FROM GCDEDUC_OPER D
                            LEFT JOIN GCLIQ_DEDUCCIONES LD ON LD.CVE_DED = D.FOLIO    
                            LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LD.CVE_LIQ
                            WHERE L.CVE_ST_LIQ = 2 AND LD.STATUS = 'A' AND LD.CVE_DED = " & fDEDUC
                        'CVE_ST_LIQ
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                SALDO -= dr("IMPORTE")

                                Fg2.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("CVE_LIQ") & vbTab &
                                    dr("IMPORTE_PRESTAMO") & vbTab & dr("IMPORTE") & vbTab & SALDO)
                            End While
                        End Using
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then
                BUSCA_DEDUCCIONES(CLng(Fg(Fg.Row, 1)))
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
