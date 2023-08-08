Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports System.Security.Cryptography
Public Class FrmBmovsAE
    Private CTA_BANC As String
    Private ENTRA As Boolean = True
    Private Sub FrmBmovsAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            Me.CenterToScreen()
            Me.KeyPreview = True
            For Each tb As TextBox In Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next

            BtnConcep.FlatStyle = FlatStyle.Flat
            BtnConcep.FlatAppearance.BorderSize = 0
            BtnFormaPago.FlatStyle = FlatStyle.Flat
            BtnFormaPago.FlatAppearance.BorderSize = 0
            BtnBenef.FlatStyle = FlatStyle.Flat
            BtnBenef.FlatAppearance.BorderSize = 0

            Me.KeyPreview = True
            TFECHA.Value = Date.Today
            TFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            TFECHA.CustomFormat = "dd/MM/yyyy"
            TFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            TFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

            TF_COBRO.Value = Date.Today
            TF_COBRO.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            TF_COBRO.CustomFormat = "dd/MM/yyyy"
            TF_COBRO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            TF_COBRO.EditFormat.CustomFormat = "dd/MM/yyyy"

            CTA_BANC = Var3

            TNUM_REG.Value = ""
            TCVE_CONCEP.Value = ""
            TREF1.Value = ""
            TREF2.Value = ""
            TMONTO_TOT.Value = 0
            TMONTO_IVA_TOT.Value = 0
            TCLPV.Value = ""
            TFORMAPAGO.Value = ""
            TMONTO_IVA_TOT.Tag = "0"
            TNUM_CHEQUE.Value = "0"

            TNUM_CHEQUE.CustomFormat = "###########"
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If Var1 = "Nuevo" Then
            Try
                BarImprimir.Enabled = False

                TNUM_REG.Value = GET_MAX("BMOV" & CTA_BANC, "NUM_REG")
                TNUM_REG.Enabled = False
                TCVE_CONCEP.Text = ""
                TCVE_CONCEP.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                If Var2 = "" Then Var2 = "0"
                SQL = "Select O.NUM_REG, O.CVE_CONCEP, O.CON_PART, O.NUM_CHEQUE, O.REF1, O.REF2, O.STATUS, O.FECHA,
                    O.F_COBRO, O.MONTO_TOT, O.MONTO_IVA_TOT, O.CLPV, O.X_OBSER, O.FORMAPAGOSAT, ISNULL(O.NUM_CHEQUE,0) AS NUMCHEQUE
                    From BMOV" & CTA_BANC & " O WHERE NUM_REG = " & CLng(Var2)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TNUM_REG.Value = dr.ReadNullAsEmptyString("NUM_REG").ToString
                            TCVE_CONCEP.Value = dr.ReadNullAsEmptyString("CVE_CONCEP").ToString
                            If TCVE_CONCEP.Value.ToString.Length > 0 Then
                                LtConcep.Text = BUSCA_ENCAT("CVE_CONCEP", TCVE_CONCEP.Text)
                            End If
                            TCLPV.Value = dr("CLPV")
                            If TCLPV.Value.ToString.Length > 0 Then
                                LtBenef.Text = BUSCA_ENCAT("BENEF", TCLPV.Text)
                            End If

                            TREF1.Value = dr.ReadNullAsEmptyString("REF1").ToString
                            TREF2.Value = dr.ReadNullAsEmptyString("REF2").ToString
                            TFECHA.Value = dr("FECHA").ToString
                            TF_COBRO.Value = dr("F_COBRO").ToString
                            TMONTO_TOT.Value = dr.ReadNullAsEmptyDecimal("MONTO_TOT").ToString
                            TMONTO_IVA_TOT.Value = dr.ReadNullAsEmptyDecimal("MONTO_IVA_TOT").ToString
                            TCLPV.Value = dr.ReadNullAsEmptyString("CLPV").ToString
                            TFORMAPAGO.Value = dr.ReadNullAsEmptyString("FORMAPAGOSAT").ToString
                            If TFORMAPAGO.Value.ToString.Trim.Length > 0 Then
                                LtFormaPago.Text = BUSCA_ENCAT("FORMAPAGOSAT", TFORMAPAGO.Text)
                            End If

                            TX_OBSER.Text = dr.ReadNullAsEmptyString("X_OBSER")

                            If dr("NUMCHEQUE") > 0 Then
                                TNUM_CHEQUE.Text = dr("NUMCHEQUE")
                            End If
                        End If
                    End Using
                End Using
                TNUM_REG.Enabled = False
                'TCVE_CONCEP.Enabled = False
                TCVE_CONCEP.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
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
    Private Sub FrmBmovsAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        If Not Valida_Conexion() Then
            Return
        End If
        Dim NUM_CHEQUE As Long
        Try
            TNUM_REG.UpdateValueWithCurrentText()
            TCVE_CONCEP.UpdateValueWithCurrentText()
            TREF1.UpdateValueWithCurrentText()
            TREF2.UpdateValueWithCurrentText()
            TMONTO_TOT.UpdateValueWithCurrentText()
            TMONTO_IVA_TOT.UpdateValueWithCurrentText()
            TCLPV.UpdateValueWithCurrentText()
            TFORMAPAGO.UpdateValueWithCurrentText()
            TNUM_CHEQUE.UpdateValueWithCurrentText()

            If IsNumeric(TNUM_CHEQUE.Value) Then
                NUM_CHEQUE = TNUM_CHEQUE.Value
            Else
                NUM_CHEQUE = 0
            End If
        Catch ex As Exception
        End Try

        SQL = "UPDATE BMOV" & CTA_BANC & " SET REF1 = @REF1, REF2 = @REF2, FECHA = @FECHA, 
            F_COBRO = @F_COBRO, MONTO_TOT = @MONTO_TOT, MONTO_IVA_TOT = @MONTO_IVA_TOT, 
            MONTO_EXT = @MONTO_TOT, CLPV = @CLPV, X_OBSER = @X_OBSER, FORMAPAGO = @FORMAPAGO, 
            FORMAPAGOSAT = @FORMAPAGOSAT, FACTOR = @FACTOR, NUM_CHEQUE = @NUM_CHEQUE
            WHERE NUM_REG = @NUM_REG
            IF @@ROWCOUNT = 0
            INSERT INTO BMOV" & CTA_BANC & " (NUM_REG, STATUS, CVE_CONCEP, REF1, REF2, FECHA, F_COBRO, 
            MONTO_TOT, MONTO_IVA_TOT, MONTO_EXT, MONEDA, T_CAMBIO, HORA, CLPV, X_OBSER, FACTOR, FORMAPAGO, 
            ASOCIADO, FORMAPAGOSAT, NUM_CHEQUE) VALUES (ISNULL((SELECT MAX(NUM_REG) + 1 FROM BMOV" & CTA_BANC & "),1), 'A',
            @CVE_CONCEP, @REF1, @REF2, @FECHA, @F_COBRO, @MONTO_TOT, @MONTO_IVA_TOT, @MONTO_TOT, 1, 1, 0, 
            @CLPV, @X_OBSER, @FACTOR, @FORMAPAGO, 'P', @FORMAPAGOSAT, @NUM_CHEQUE)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@NUM_REG", SqlDbType.Int).Value = CLng(TNUM_REG.Text)
                cmd.Parameters.Add("@CVE_CONCEP", SqlDbType.VarChar).Value = TCVE_CONCEP.Value
                cmd.Parameters.Add("@REF1", SqlDbType.VarChar).Value = TREF1.Value
                cmd.Parameters.Add("@REF2", SqlDbType.VarChar).Value = TREF2.Value
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = TFECHA.Value
                cmd.Parameters.Add("@F_COBRO", SqlDbType.DateTime).Value = TF_COBRO.Value
                cmd.Parameters.Add("@MONTO_TOT", SqlDbType.Float).Value = TMONTO_TOT.Value
                cmd.Parameters.Add("@MONTO_IVA_TOT", SqlDbType.Float).Value = TMONTO_IVA_TOT.Value
                cmd.Parameters.Add("@CLPV", SqlDbType.VarChar).Value = TCLPV.Value
                cmd.Parameters.Add("@X_OBSER", SqlDbType.VarChar).Value = TX_OBSER.Text
                cmd.Parameters.Add("@FORMAPAGO", SqlDbType.VarChar).Value = TFORMAPAGO.Value
                cmd.Parameters.Add("@FORMAPAGOSAT", SqlDbType.VarChar).Value = TFORMAPAGO.Value
                cmd.Parameters.Add("@FACTOR", SqlDbType.SmallInt).Value = 1
                cmd.Parameters.Add("@NUM_CHEQUE", SqlDbType.Int).Value = NUM_CHEQUE
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
            MsgBox("El movimiento se grabo correctamente")

            If TFORMAPAGO.Value = "02" Then
                IMPRIMIT_CHEQUE(TNUM_REG.Text)
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIT_CHEQUE(FNUM_REG As Long)
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMovs01.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            Dim entero As Integer = Int(TMONTO_TOT.Value)
            Dim decimales As Double = TMONTO_TOT.Value - entero
            Dim NUMTOLET As String
            NUMTOLET = "** ( " + Num2Text(entero) + " PESOS " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + "/100 M.N.)**"

            StiReport1.Load(RUTA_FORMATOS)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("NUM_REG") = CLng(TNUM_REG.Value)
            StiReport1("NUMTOLETRA") = NUMTOLET

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        IMPRIMIT_CHEQUE(TNUM_REG.Text)
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnConcep_Click(sender As Object, e As EventArgs) Handles BtnConcep.Click
        Try
            Var2 = "CVE_CONCEP"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItemBancos.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CONCEP.Text = Var4
                LtConcep.Text = Var5
                TMONTO_IVA_TOT.Tag = Var6

                Try
                    If IsNumeric(Var6) Then
                        TMONTO_IVA_TOT.Value = TMONTO_TOT.Value * CDec(Var6) / 100
                    End If
                Catch ex As Exception
                End Try

                TFORMAPAGO.Focus()
            End If
        Catch Ex As Exception
            Bitacora("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CONCEP_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CONCEP.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnConcep_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_CONCEP_Validated(sender As Object, e As EventArgs) Handles TCVE_CONCEP.Validated
        Try
            If TCVE_CONCEP.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_ENCAT("CVE_CONCEP", TCVE_CONCEP.Text)
                If DESCR <> "" Then
                    LtConcep.Text = DESCR
                    TMONTO_IVA_TOT.Tag = Var6
                    Try
                        If IsNumeric(Var6) Then
                            TMONTO_IVA_TOT.Value = TMONTO_TOT.Value * CDec(Var6) / 100
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    MsgBox("Concepto inexistente")
                    TCVE_CONCEP.Text = ""
                    LtConcep.Text = ""
                End If
            Else
                LtConcep.Text = ""
            End If

        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFormaPago_Click(sender As Object, e As EventArgs) Handles BtnFormaPago.Click
        Try
            Var2 = "FORMAPAGOSAT"
            Var4 = "" : Var5 = ""
            FrmSelItemBancos.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFORMAPAGO.Text = Var4
                LtFormaPago.Text = Var5
                TFECHA.Focus()
            End If
        Catch Ex As Exception
            Bitacora("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TFORMAPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TFORMAPAGO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnFormaPago_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TFORMAPAGO_Validated(sender As Object, e As EventArgs) Handles TFORMAPAGO.Validated
        Try
            If TFORMAPAGO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_ENCAT("FORMAPAGOSAT", TFORMAPAGO.Text)
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
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBenef_Click(sender As Object, e As EventArgs) Handles BtnBenef.Click
        Try
            Var2 = "BENEF"
            Var4 = "" : Var5 = ""
            FrmSelItemBancos.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLPV.Text = Var4
                LtBenef.Text = Var5
                TREF1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub


    Private Sub TCLPV_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLPV.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBenef_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCLPV_Validated(sender As Object, e As EventArgs) Handles TCLPV.Validated
        Try
            If TCLPV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_ENCAT("BENEF", TCLPV.Text)
                If DESCR <> "" Then
                    LtBenef.Text = DESCR
                Else
                    MsgBox("Forma de pago inexistente")
                    TCLPV.Text = ""
                    LtBenef.Text = ""
                End If
            Else
                LtBenef.Text = ""
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TX_OBSER_KeyDown(sender As Object, e As KeyEventArgs) Handles TX_OBSER.KeyDown

    End Sub
    Private Sub TX_OBSER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TX_OBSER.PreviewKeyDown

        If e.KeyCode = 9 Then
            TREF1.Focus()
        End If
        ENTRA = False
        If e.KeyCode = 13 Then
            TFECHA.Focus()
        End If
        ENTRA = True

    End Sub
    Private Sub FrmBmovsAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) And ENTRA Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub TMONTO_TOT_TextChanged(sender As Object, e As EventArgs)
        Try
            If IsNumeric(Var6) Then
                TMONTO_IVA_TOT.Value = TMONTO_TOT.Text * CDec(Var6) / 100
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarPolizaCheque_Click(sender As Object, e As ClickEventArgs) Handles BarPolizaCheque.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportPolCheque.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            Dim entero As Integer = Int(TMONTO_TOT.Value)
            Dim decimales As Double = TMONTO_TOT.Value - entero
            Dim NUMTOLET As String
            NUMTOLET = "** ( " + Num2Text(entero) + " PESOS " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + "/100 M.N.)**"

            StiReport1.Load(RUTA_FORMATOS)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("NUM_REG") = CLng(TNUM_REG.Value)
            StiReport1("NUMTOLETRA") = NUMTOLET

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
