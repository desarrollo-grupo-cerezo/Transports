Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmSolPagoProvAE
    Private PROCNEW As Boolean
    Private ENTRA As Boolean = False


    Private Sub FrmSolPagoProvAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MONTO_DISPONIBLE As Decimal = 0, SALDO As Decimal = 0, MONTO_ASIGNADO As Decimal = 0

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg.Styles("Alternate").BackColor = Color.PowderBlue
            Fg.Styles("Highlight").BackColor = Color.CornflowerBlue
            Fg.Styles("Focus").BackColor = Color.CornflowerBlue
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

        Catch ex As Exception
        End Try
        Me.CenterToScreen()
        Me.KeyPreview = True
        For Each tb As TextBox In Controls.OfType(Of TextBox)()
            AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
            AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
        Next

        If PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE = "BR3FRAJA" Then
            BarDiseñoPeporte.Visible = True
        Else
            BarDiseñoPeporte.Visible = False
        End If

        Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        Fg.Rows(0).Height = 40

        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.None
        Fg.Rows.DefaultSize = 20
        Fg.Rows.Count = 1
        Fg.DrawMode = DrawModeEnum.OwnerDraw

        Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

        Fg.Cols(3).Visible = False
        Fg.Cols(4).Visible = False


        Fg.Styles("Normal").Border.Color = Color.Black
        Fg.Styles("Fixed").Border.Color = Color.Black
        Fg.Styles("Fixed").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
        Fg.Styles("Fixed").Border.Width = 2

        'Fg.Styles("Normal").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat


        BtnProv.FlatStyle = FlatStyle.Flat
        BtnProv.FlatAppearance.BorderSize = 0
        BtnFormaPago.FlatStyle = FlatStyle.Flat
        BtnFormaPago.FlatAppearance.BorderSize = 0

        Me.KeyPreview = True
        TFECHA.Value = Date.Today
        TFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TFECHA.CustomFormat = "dd/MM/yyyy"
        TFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

        TCLAVE.Value = ""
        TCVE_PROV.Value = ""
        TFORMAPAGO.Value = ""
        TIMPORTE.Value = 0
        TCONCEPTO.Value = ""
        TSOLICITA.Value = ""
        TREV_AUT.Value = ""
        TTRANSFIERE.Value = ""
        PROCNEW = False

        If Var1 = "Nuevo" Then
            Try
                TCLAVE.Text = GET_MAX("SOL_PAGO", "CLAVE")
                TCLAVE.Enabled = False
                TCVE_PROV.Text = ""
                TCVE_PROV.Select()
                PROCNEW = True
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                SQL = "SELECT S.CLAVE, S.STATUS, S.FECHA_P, S.FORMAPAGO, C.DESCR, S.CVE_PROV, P.NOMBRE, 
                    S.IMPORTE, S.CONCEPTO, S.SOLICITA, S.REV_AUT, S.TRANSFIERE, ISNULL(L.CAMPLIB6,0) AS LIB6
                    FROM SOL_PAGO S 
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = S.CVE_PROV
                    LEFT JOIN PROV_CLIB" & Empresa & " L ON L.CVE_PROV = S.CVE_PROV
                    LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = S.FORMAPAGO
                    WHERE S.CLAVE = " & Var2
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                TCLAVE.Value = dr("CLAVE").ToString
                                TCVE_PROV.Value = dr("CVE_PROV").ToString
                                LtBenef.Text = dr("NOMBRE")
                                TFECHA.Value = dr("FECHA_P").ToString
                                TFORMAPAGO.Value = dr("FORMAPAGO").ToString
                                LtFormaPago.Text = dr("DESCR")
                                TIMPORTE.Value = dr("IMPORTE").ToString
                                TCONCEPTO.Value = dr("CONCEPTO").ToString
                                TSOLICITA.Value = dr("SOLICITA").ToString
                                TREV_AUT.Value = dr("REV_AUT").ToString
                                TTRANSFIERE.Value = dr("TRANSFIERE").ToString

                                MONTO_DISPONIBLE = dr("LIB6")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                TCLAVE.Enabled = False
                TCVE_PROV.Enabled = False
                TFECHA.Enabled = False
                TFORMAPAGO.Enabled = False
                TIMPORTE.Enabled = False
                TCONCEPTO.Enabled = False
                TSOLICITA.Enabled = False
                TREV_AUT.Enabled = False
                TTRANSFIERE.Enabled = False
                BtnFormaPago.Enabled = False
                BtnProv.Enabled = False

                TCLAVE.Enabled = False
                TCVE_PROV.Select()


                If MONTO_DISPONIBLE = 0 Then
                    MsgBox("El beneficiario no tiene capturado el monto disponible, verifique por favor")
                    Me.Close()
                    Return
                End If

                Try
                    Dim dt As DateTime = TFECHA.Value

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(SUM(IMPORTE),0) AS MONTO FROM SOL_PAGO 
                            WHERE STATUS = 'A' AND FORMAPAGO = 23 AND CVE_PROV = '" & TCVE_PROV.Value & "' AND
                            MONTH(FECHA_P) = " & dt.Month & " AND YEAR(FECHA_P) = " & dt.Year
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                MONTO_ASIGNADO = dr("MONTO")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                LtMonto.Text = Format(MONTO_DISPONIBLE, "###,###,##0.00")
                LtSaldo.Text = Format(MONTO_DISPONIBLE - MONTO_ASIGNADO, "###,###,##0.00")
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        Var10 = ""
        ENTRA = True
    End Sub
    Sub CALCULO_SALDO(FCVE_PROV As String, FMONTO_DISPONIBLE As Decimal)

        Try
            If FMONTO_DISPONIBLE = 0 Then
                MsgBox("El beneficiario no tiene capturado el monto disponible, " &
                       "por favor capture el monto en el campo libre 6 del proveedor:" & FCVE_PROV)
                TCVE_PROV.Value = ""
                TCVE_PROV.Select()
                Return
            End If

            Dim MONTO_ASIGNADO As Decimal
            Dim dt As DateTime = TFECHA.Value

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(SUM(IMPORTE),0) AS MONTO FROM SOL_PAGO 
                     WHERE STATUS = 'A' AND FORMAPAGO = 23 AND CVE_PROV = '" & FCVE_PROV & "' AND 
                     MONTH(FECHA_P) = " & dt.Month & " AND YEAR(FECHA_P) = " & dt.Year
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        MONTO_ASIGNADO = dr("MONTO")
                    End If
                End Using
            End Using

            LtMonto.Text = Format(FMONTO_DISPONIBLE, "###,###,##0.00")
            LtSaldo.Text = Format(FMONTO_DISPONIBLE - MONTO_ASIGNADO, "###,###,##0.00")

            If FMONTO_DISPONIBLE - MONTO_ASIGNADO <= 0.1 Then
                MsgBox("El saldo disponible ya fue asignado en su totalidad")
                TCVE_PROV.Select()
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try
            sender.BackColor = Color.FromArgb(176, 240, 0) 'Color.LemonChiffon
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Fg.Focus()

            TCLAVE.UpdateValueWithCurrentText()
            TCVE_PROV.UpdateValueWithCurrentText()
            TFORMAPAGO.UpdateValueWithCurrentText()
            TIMPORTE.UpdateValueWithCurrentText()
            TCONCEPTO.UpdateValueWithCurrentText()
            TSOLICITA.UpdateValueWithCurrentText()
            TREV_AUT.UpdateValueWithCurrentText()
            TTRANSFIERE.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If IsNumeric(LtSaldo.Text.Replace(",", "")) Then
            If CDec(LtSaldo.Text.Replace(",", "")) <= 0.1 Then
                MsgBox("El saldo disponible ya fue asignado en su totalidad")
                Return
            End If
        End If

        If TFORMAPAGO.Value.Trim.Length = 0 Then
            MsgBox("La formap de pago no debe quedar vacia, verifique por favor")
            Return
        End If
        If TIMPORTE.Value = 0 Then
            MsgBox("Por favor capture el importe")
            Return
        End If
        If TCONCEPTO.Value.Trim.Length = 0 Then
            MsgBox("El concepto no debe quedar vacia, verifique por favor")
            Return
        End If
        If TSOLICITA.Value.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        If TREV_AUT.Value.Trim.Length = 0 Then
            MsgBox("La revisión/autorización no debe quedar vacia, verifique por favor")
            Return
        End If
        If TTRANSFIERE.Value.Trim.Length = 0 Then
            MsgBox("El que transfiere no debe quedar vacia, verifique por favor")
            Return
        End If

        If MsgBox("Realmente desea grabar la solicitud?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            For k = 1 To Fg.Rows.Count - 1

                If Not IsNothing(Fg(k, 7)) Then
                    If IsNumeric(Fg(k, 7)) Then
                        If Fg(k, 7) > 0 Then

                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        SQL = "UPDATE SOL_PAGO SET CVE_PROV = @CVE_PROV, FORMAPAGO = @FORMAPAGO, FECHA_P = @FECHA_P, 
            IMPORTE = @IMPORTE, CONCEPTO = @CONCEPTO, SOLICITA = @SOLICITA, REV_AUT = @REV_AUT, 
            TRANSFIERE = @TRANSFIERE
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO SOL_PAGO (CLAVE, STATUS, FECHA_P, FORMAPAGO, CVE_PROV, IMPORTE, CONCEPTO, SOLICITA, 
            REV_AUT, TRANSFIERE, FECHAELAB, UUID) VALUES (
            ISNULL((SELECT MAX(CLAVE) + 1 FROM SOL_PAGO),1), 'A', @FECHA_P, @FORMAPAGO, @CVE_PROV, @IMPORTE, @CONCEPTO, 
            @SOLICITA, @REV_AUT, @TRANSFIERE, GETDATE(), NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Value
                cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = TCVE_PROV.Value
                cmd.Parameters.Add("@FECHA_P", SqlDbType.Date).Value = TFECHA.Value
                cmd.Parameters.Add("@FORMAPAGO", SqlDbType.SmallInt).Value = TFORMAPAGO.Value
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = TIMPORTE.Value
                cmd.Parameters.Add("@CONCEPTO", SqlDbType.VarChar).Value = TCONCEPTO.Value
                cmd.Parameters.Add("@SOLICITA", SqlDbType.VarChar).Value = TSOLICITA.Value
                cmd.Parameters.Add("@REV_AUT", SqlDbType.VarChar).Value = TREV_AUT.Value
                cmd.Parameters.Add("@TRANSFIERE", SqlDbType.VarChar).Value = TTRANSFIERE.Value
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        GRABAR_DOCUMENTOS()

                    End If
                End If
            End Using
            MsgBox("La solicitud de pago se grabo correctamente")
            Var9 = TCLAVE.Value
            Var10 = "IMPRIMIR"
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_DOCUMENTOS()

        SQL = "INSERT INTO SOL_PAGO_PAR (CLAVE, CVE_DOC, CVE_PROV, IMPORTE, FECHAELAB, UUID) VALUES (            
            @CLAVE, @CVE_DOC, @CVE_PROV, @IMPORTE, GETDATE(), NEWID())"
        Try
            For k = 1 To Fg.Rows.Count - 1

                If Not IsNothing(Fg(k, 7)) Then
                    If IsNumeric(Fg(k, 7)) Then
                        If Fg(k, 7) > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Value
                                cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = TCVE_PROV.Value
                                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = Fg(k, 2)
                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Fg(k, 7)
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmSolPagoProvAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnFormaPago_Click(sender As Object, e As EventArgs) Handles BtnFormaPago.Click
        Try
            If TCVE_PROV.Value.ToString.Length = 0 Then
                MsgBox("Por favor capture el beneficiario")
                TCVE_PROV.Select()
                Return
            End If

            Var2 = "ConcCxP"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFORMAPAGO.Text = Var4
                LtFormaPago.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TIMPORTE.Focus()
            End If
        Catch Ex As Exception
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TFORMAPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TFORMAPAGO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnFormaPago_Click(Nothing, Nothing)
                Return
            Else
                If TCVE_PROV.Value.ToString.Length = 0 Then
                    MsgBox("Por favor capture el beneficiario")
                    TCVE_PROV.Select()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TFORMAPAGO_Validated(sender As Object, e As EventArgs) Handles TFORMAPAGO.Validated
        Try
            If TFORMAPAGO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ConcCxP", TFORMAPAGO.Text)
                If DESCR <> "" Then
                    LtFormaPago.Text = DESCR
                Else
                    MsgBox("Forma de pago inexistente")
                    TFORMAPAGO.Text = ""
                    LtFormaPago.Text = ""
                End If
            Else
                LtFormaPago.Text = ""
            End If
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles BtnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROV.Text = Var4
                LtBenef.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TFECHA.Focus()
            End If

        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_PROV_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV.Validated
        Try
            If Not PROCNEW Then
                Return
            End If
            If TCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV.Text.Trim) Then
                    DESCR = TCVE_PROV.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV.Value = DESCR
                End If
                DESCR = BUSCA_CAT("ProvLib", TCVE_PROV.Text)
                If DESCR <> "" Then
                    LtBenef.Text = DESCR
                    If Not IsNumeric(Var6) Then
                        Var6 = "0"
                    End If
                    CALCULO_SALDO(TCVE_PROV.Value, CDec(Var6))

                    DESPLEGAR_SALDOS_PROV()

                    Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                    TIMPORTE.Value = 0
                Else
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV.Text = ""
                    LtBenef.Text = ""
                End If
            Else
                LtBenef.Text = ""
                Fg.Rows.Count = 1
                LtTotal.Text = "0.00"
                TIMPORTE.Value = 0
                LtSaldoGen.Text = "0.00"
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_SALDOS_PROV()
        Dim SUMA As Decimal = 0
        Fg.Rows.Count = 1

        SQL = "SELECT M.REFER, M.NO_FACTURA, M.DOCTO, M.CVE_PROV, M.FECHA_APLI, M.FECHA_VENC, M.IMPORTE,
            ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_M" & Empresa & " D WHERE D.REFER = M.REFER AND D.CVE_PROV = M.CVE_PROV),0) +
            ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D  WHERE D.REFER = M.REFER AND D.CVE_PROV = M.CVE_PROV AND D.ID_MOV = M.NUM_CPTO AND D.NUM_CARGO = M.NUM_CARGO),0) AS SALDO
            FROM PAGA_M" & Empresa & " M
            INNER JOIN PROV" & Empresa & " P ON M.CVE_PROV = P.CLAVE
            LEFT JOIN COMPC" & Empresa & " C ON M.REFER = C.CVE_DOC
            WHERE M.NUM_CPTO <> 9 AND
            (ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_M" & Empresa & " D WHERE D.REFER = M.REFER AND D.CVE_PROV = M.CVE_PROV),0) +
            ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D  WHERE D.REFER = M.REFER AND D.CVE_PROV = M.CVE_PROV AND D.ID_MOV = M.NUM_CPTO AND D.NUM_CARGO = M.NUM_CARGO),0)) > 0.1
            AND M.CVE_PROV = '" & TCVE_PROV.Text & "'
            ORDER BY M.FECHA_APLI"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If Not EXISTE_CVE_DOC(dr("REFER")) Then
                            Fg.AddItem("" & vbTab & "" & vbTab & dr("REFER") & vbTab & dr("NO_FACTURA") & vbTab & dr("DOCTO") & vbTab &
                                   dr("IMPORTE") & vbTab & dr("SALDO"))
                            SUMA += dr("SALDO")

                        End If
                    End While
                End Using
            End Using
            LtSaldoGen.Text = Format(SUMA, "###,###,###,##0.00")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Function EXISTE_CVE_DOC(FCVE_DOC As String) As Boolean
        Dim EXISTE As Boolean = False
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_DOC FROM SOL_PAGO_PAR WHERE CVE_DOC = '" & FCVE_DOC & "' AND CVE_PROV = '" & TCVE_PROV.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EXISTE = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return EXISTE

    End Function
    Private Sub FrmSolPagoProvAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub TIMPORTE_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim SALDO As Decimal = 0

            If Var1 <> "Nuevo" Then
                Return
            End If

            If TCVE_PROV.Value.ToString.Length = 0 And ENTRA Then
                MsgBox("Por favor capture el beneficiario")
                TIMPORTE.Value = 0
                TCVE_PROV.Select()
            End If

            If IsNumeric(LtSaldo.Text.Replace(",", "")) Then
                SALDO = CDec(LtSaldo.Text.Replace(",", ""))

                If TIMPORTE.Value > SALDO Then
                    MsgBox("El beneficiario rebaso el saldo disponible")
                    TIMPORTE.Value = 0
                End If
            End If

        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarReporte_Click(sender As Object, e As ClickEventArgs) Handles BarReporte.Click

        If PROCNEW Then
            MsgBox("Cuando la solicitud de pago en nueva se imprimirá al grabar")
            Return
        End If
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarReporte.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSolPagoProv.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CLAVE") = TCLAVE.Value

            'StiReport1("F3") = TFECHA.Value.ToString.Substring(0, 10)

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarReporte.Enabled = True
    End Sub

    Private Sub BarDiseñoPeporte_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñoPeporte.Click

        PrinterMRT("ReportSolPagoProv")
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then
                    Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
                End If

                If Fg(e.Row, e.Col) Then
                    Dim SALDO_DISP As Decimal, SUMA_ABONOS As Decimal = 0

                    If IsNumeric(LtSaldo.Text.Replace(",", "")) Then
                        SALDO_DISP = Convert.ToDecimal(LtSaldo.Text.Replace(",", ""))
                    Else
                        SALDO_DISP = 0
                    End If

                    If TIMPORTE.Value + Fg(e.Row, 6) <= SALDO_DISP Then
                        TIMPORTE.Value = TIMPORTE.Value + Fg(e.Row, 6)
                        Fg(e.Row, 7) = Fg(e.Row, 6)
                    Else
                        Fg(e.Row, 1) = False
                        Fg(e.Row, 7) = 0
                    End If

                    LtTotal.Text = Format(TIMPORTE.Value, "###,###,##0.0000")
                Else
                    TIMPORTE.Value = TIMPORTE.Value - Fg(e.Row, 6)
                    LtTotal.Text = Format(TIMPORTE.Value, "###,###,##0.0000")
                    Fg(e.Row, 7) = 0
                End If
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        Dim SALDO_DISP As Decimal

        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("cs1")
        cs1.BackColor = Color.PowderBlue
        cs1.ForeColor = Color.Black

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("cs2")
        cs2.BackColor = Color.White
        cs2.ForeColor = Color.Black



        If IsNumeric(LtSaldo.Text.Replace(",", "")) Then
            SALDO_DISP = Convert.ToDecimal(LtSaldo.Text.Replace(",", ""))
        Else
            SALDO_DISP = 0
        End If

        If Fg.Row > 0 Then

            TIMPORTE.Value = 0
            LtTotal.Text = "0.00"
            For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1

                If row / 2 = Int(row / 2) Then
                    Fg.SetCellStyle(row, 7, cs2)
                Else
                    Fg.SetCellStyle(row, 7, cs1)
                End If

                Fg.SetCellCheck(row, 1, state)
                If Fg(row, 1) Then
                    If TIMPORTE.Value + Fg(row, 6) <= SALDO_DISP Then
                        TIMPORTE.Value = TIMPORTE.Value + Fg(row, 6)
                        Fg(row, 7) = Fg(row, 6)
                    Else
                        Fg(row, 1) = False
                        Fg(row, 7) = 0
                    End If
                Else
                    Fg(row, 7) = 0
                End If
            Next
            LtTotal.Text = Format(TIMPORTE.Value, "###,###,##0.0000")
        End If
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If e.Row > 0 Then
            If e.Col <> 1 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Dim cs2 As CellStyle
            cs2 = Fg.Styles.Add("CS2")
            cs2.BackColor = Color.White
            cs2.ForeColor = Color.Red
            'cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

            Fg.SetCellStyle(e.Row, 6, cs2)

        End If
    End Sub

    Private Sub TIMPORTE_Validated(sender As Object, e As EventArgs) Handles TIMPORTE.Validated
        Try
            Dim IMPORTE As Decimal, SALDO As Decimal, SUMA As Decimal = 0
            Dim cs1 As CellStyle

            cs1 = Fg.Styles.Add("cs1")
            cs1.BackColor = Color.DodgerBlue
            cs1.ForeColor = Color.Black

            IMPORTE = TIMPORTE.Text
            SALDO = IMPORTE

            For k = 1 To Fg.Rows.Count - 1

                If SALDO >= Fg(k, 6) Then
                    Fg(k, 7) = Fg(k, 6)
                    SALDO -= Fg(k, 6)
                    SUMA += Fg(k, 7)
                    Fg(k, 1) = True
                Else
                    Fg(k, 7) = 0
                End If
            Next

            If SALDO > 0 Then
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 7) = 0 Then
                        If SALDO >= Fg(k, 6) Then
                            Fg(k, 7) = Fg(k, 6)
                            SALDO -= Fg(k, 6)
                            SUMA += Fg(k, 7)
                            Fg(k, 1) = True
                            Fg.SetCellStyle(k, 7, cs1)

                        Else
                            Fg(k, 7) = SALDO
                            SUMA += Fg(k, 7)
                            Fg(k, 1) = True

                            Fg.SetCellStyle(k, 7, cs1)

                            Exit For
                        End If
                    End If
                Next
            End If

            LtTotal.Text = Format(SUMA, "###,###,###,##0.0000")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
End Class