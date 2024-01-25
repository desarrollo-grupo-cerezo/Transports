Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FrmPagoMultidocCxP
    Private ENTRA As Boolean = True
    Private ENVIA_ENTER As Boolean = False
    Private c_ As Integer
    Private Sub FrmPagoMultidocCxP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

            For Each tb As TextBox In Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next

        Catch ex As Exception
        End Try
        BtnProv.FlatStyle = FlatStyle.Flat
        BtnProv.FlatAppearance.BorderSize = 0
        BtnConc.FlatStyle = FlatStyle.Flat
        BtnConc.FlatAppearance.BorderSize = 0
        BtnDocto.FlatStyle = FlatStyle.Flat
        BtnDocto.FlatAppearance.BorderSize = 0

        Fg.Styles.EmptyArea.BackColor = ColoFondoFG

        AssignValidation(Me.TNUM_CPTO, ValidationType.Only_Numbers)

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        FECHA_DEP.Value = Date.Today
        FECHA_DEP.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FECHA_DEP.CustomFormat = "dd/MM/yyyy"
        FECHA_DEP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FECHA_DEP.EditFormat.CustomFormat = "dd/MM/yyyy"

        'Fg.Cols(6).Visible = False

        If Not CargaCuentasBancarias() Then
            MsgBox("No existen cuentas bancarias registradas, favor de verificar")
            Me.Close()
            Return
        End If

        If Var10 = "Compra" Then
            TPROV.Enabled = False
            TDOCTO.Enabled = False
        End If
        Try
            Fg.Rows.Count = 1
            '                    concepto       f2        descr concep   docto       importe 
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            TPROV.Select()
        Catch ex As Exception
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try
            sender.BackColor = Color.FromArgb(176, 240, 0)
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub

    Sub GUARDAR()
        BarGrabar_Click(Nothing, Nothing)
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Dim j As Integer, NUM_CPTO As Integer, IMPORTE As Decimal, NUM_PAGOS As Integer, SUMAPAGOS As Decimal
        Dim FORMAPAGO As String, DOCTO As String, REFER As String, NUM_CARGO As Integer
        Dim CVE_CTA As String

        If MsgBox("Realmente desea realizar el pago?", vbYesNo) = vbNo Then
            Return
        End If
        Try
            If IsNumeric(TNUM_CPTO.Text) Then
                NUM_CPTO = TNUM_CPTO.Text

                If NUM_CPTO = 0 Then
                    MsgBox("Por favor capture el concepto de la forma de pago")
                    TNUM_CPTO.Focus()
                    Return
                End If
            Else
                MsgBox("Por favor capture el concepto de la forma de pago")
                TNUM_CPTO.Focus()
                Return
            End If
            If TDOCTO.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el folio bancario")
                TDOCTO.Focus()
                Return
            End If

            DOCTO = TDOCTO.Text

            If CboCuentabancaria.SelectedIndex = -1 Then
                MsgBox("Por favor selecciones una cuenta bancaria")
                Return
            End If

            CVE_CTA = Split(CboCuentabancaria.Text, "|")(0).Trim

            NUM_PAGOS = 0 : SUMAPAGOS = 0
            ENTRA = False
            For j = 1 To Fg.Rows.Count - 1

                IMPORTE = 0
                If Not IsNothing(Fg(j, 4)) Then
                    If IsNumeric(Fg(j, 4)) Then
                        IMPORTE = Fg(j, 4)
                    End If
                End If
                REFER = ""
                If Not IsNothing(Fg(j, 1)) Then
                    REFER = Fg(j, 1)
                End If
                If IsNumeric(Fg(j, 3)) Then
                    NUM_CARGO = Fg(j, 3)
                Else
                    NUM_CARGO = 1
                End If


                If REFER.Trim.Length > 0 And IMPORTE > 0 Then
                    SUMAPAGOS = SUMAPAGOS + IMPORTE
                    PAGA_DET_COM(REFER, IMPORTE, NUM_CPTO, DOCTO, NUM_CARGO, CVE_CTA)
                    NUM_PAGOS = NUM_PAGOS + 1
                End If
            Next

            ENTRA = True

            FORMAPAGO = "S"
            LIMPIAR()
            MsgBox("El pago se realizo satisfactoriamente")
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub PAGA_DET_COM(fCVE_DOC As String, fIMPORTE As Decimal, fNUM_CPTO As Integer, fDOCTO As String, FNUM_CARGO As Integer, FCVE_CTA As String)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim IMPORTE As Decimal, AFEC_COI As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CTLPOL As Integer
        Dim CVE_FOLIO As String, TIPO_MOV As String, SIGNO As Integer, CVE_AUT As Integer, Usuario2 As Integer, REF_SIST As String, NO_PARTIDA As Integer

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        Try
            CVE_CLIE = TPROV.Text
            REFER = fCVE_DOC
            NO_FACTURA = fCVE_DOC
            NUM_CPTO = fNUM_CPTO

            ID_MOV = 1

            NUM_CARGO = FNUM_CARGO
            CVE_OBS = 0
            If fDOCTO.Trim.Length = 0 Then fDOCTO = fCVE_DOC
            IMPORTE = fIMPORTE
            AFEC_COI = "" : NUM_MONED = 1 : TCAMBIO = 1
            IMPMON_EXT = IMPORTE

            CTLPOL = 0 : CVE_FOLIO = "" : TIPO_MOV = "A" : SIGNO = -1 : CVE_AUT = 0 : Usuario2 = 0 : REF_SIST = "" : NO_PARTIDA = 1

            SQL = "INSERT INTO PAGA_DET" & Empresa & " (CVE_PROV, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, 
                IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, 
                SIGNO, CVE_AUT, USUARIO, REF_SIST, NO_PARTIDA, CVE_CTA) VALUES('" & CVE_CLIE & "','" & REFER & "','" & ID_MOV & "','" &
                NUM_CPTO & "','" & NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & fDOCTO & "','" &
                Math.Round(IMPORTE, 6) & "','" & FSQL(FECHA_DEP.Value) & "','" & FSQL(F1.Value) & "','" & AFEC_COI & "','" &
                NUM_MONED & "','" & TCAMBIO & "','" & Math.Round(IMPORTE, 6) & "',GETDATE(),'" & CTLPOL & "','" &
                CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','" & CVE_AUT & "','" & Usuario2 & "','" & REF_SIST & "',
                ISNULL((SELECT MAX(NO_PARTIDA) + 1 FROM PAGA_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_PROV = '" & CVE_CLIE & "'),1), '" & FCVE_CTA & "')"

            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    UPDATE_DATOS_PROV(IMPORTE, NO_FACTURA, CVE_CLIE, " - ")
                End If
            End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            TPROV.Text = ""
            TDOCTO.Text = ""

            Fg.Rows.Count = 1
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            F1.Value = Now
            FECHA_DEP.Value = Now
            'LtTotalPagos.Text = ""
            LtNombre.Text = ""
            TIMPORTE.Value = 0
            TDOCTO.Text = ""

            TPROV.Focus()

        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_CXP(FNO_PARTIDA As Integer)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxP" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxP.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = TDOCTO.Text
            StiReport1.Item("NO_PARTIDA") = FNO_PARTIDA
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
                Fg.Col = 1
            End If
        Catch ex As Exception
            Bitacora("18. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles BtnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPROV.Text = Var4
                LtNombre.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPagoMultidocCxP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TPROV_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                DESCR = TPROV.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TPROV.Text = DESCR
                End If
                TNUM_CPTO.Focus()
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV_Validated(sender As Object, e As EventArgs) Handles TPROV.Validated
        Try
            If TPROV.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TPROV.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TPROV.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Prov", TPROV.Text)
                If DESCR <> "" Then
                    Var11 = TPROV.Text
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    TPROV.Text = ""
                    LtNombre.Text = ""
                    TPROV.Focus()
                    TPROV.SelectAll()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function HayPartidas() As Boolean
        Dim SiHay As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 Then
                        SiHay = True
                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return SiHay
    End Function
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs) Handles BtnDocto.Click
        Try
            If HayPartidas() Then
                Return
            End If

            If TPROV.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un Proveedor ")
                Return
            End If
            Var2 = "ProvDocTo"
            Var4 = TPROV.Text
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TDOCTO.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TDOCTO.KeyDown
        Try
            'If e.KeyCode = Keys.F2 Then
            'BtnDoc_Click(Nothing, Nothing)
            'End If
            If e.KeyCode = 13 Then
                Fg.Select()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If
        Catch ex As Exception
            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TDOCTO.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Fg.Select()
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                Fg.StartEditing()
                'TXT.Focus()
                SendKeys.Send("{ENTER}")
            End If

        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDOCTO_Validated(sender As Object, e As EventArgs) Handles TDOCTO.Validated
        Dim FOLIOD As Long
        Try

            If TDOCTO.Text.Trim.Length > 9999 Then
                Dim DESCR As String

                If IsNumeric(TDOCTO.Text.Trim) Then
                    FOLIOD = TDOCTO.Text.Trim
                    TDOCTO.Text = Space(10) & Format(FOLIOD, "0000000000")
                End If
                Var4 = TPROV.Text
                Var5 = ""

                DESCR = BUSCA_CAT("ProvDocto", TDOCTO.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    'Fg.Focus()
                    'Fg.Row = 1
                    'Fg.Col = 1
                    'SendKeys.Send("{ENTER}")
                Else
                    MsgBox("El documento no existe")
                    TDOCTO.Text = ""
                    TDOCTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnConc_Click(sender As Object, e As EventArgs) Handles BtnConc.Click
        Try
            Var2 = "ConcCxPRef"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUM_CPTO.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TDOCTO.Focus()
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_CPTO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnConc_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxPRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    TDOCTO.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    TNUM_CPTO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_CPTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TNUM_CPTO.PreviewKeyDown
        Try
            If e.KeyCode = 13 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxPRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    TDOCTO.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    TNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles TNUM_CPTO.Validated
        Try
            If TNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("ConcCxPRefer", TNUM_CPTO.Text)
                If DESCR <> "" Then
                    LtConc.Text = DESCR
                    TDOCTO.Focus()
                Else
                    MsgBox("El concepto no existe")
                    TNUM_CPTO.Text = ""
                    TNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If (Fg.Col = 1 Or Fg.Col = 4) And ENTRA Then
                Fg.StartEditing()
            End If
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 4 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Or Fg.Col = 5 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 4 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_KeyDown(sender As Object, e As KeyEventArgs) Handles F1.KeyDown
        If e.KeyCode = 13 Then
            TNUM_CPTO.Focus()
        End If
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Var4 = ""
            Var5 = ""
            'Fg.FinishEditing()
            '2	10	13	15
            If Fg.Col = 2 Then

                ENVIA_ENTER = True
                SELDOC()
            End If
        Catch ex As Exception
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub SELDOC()
        If TPROV.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione el Proveedor ")
            TPROV.Focus()
            Return
        End If
        Try    'REFER
            'Var4 = Fg(Fg.Row, 1).ToString  'REFER
            'Var5 = Fg(Fg.Row, 2).ToString  'Proveedor 
            'Var7 = Fg(Fg.Row, 7) 'ABONOS
            'Var8 = Fg(Fg.Row, 8) 'IMPORTE
            'Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
            'Var6 = Fg(Fg.Row, 11).ToString  'NUM_CARGO
            'Var10 = Fg(Fg.Row, 12).ToString  'NUM_cpto

            Var2 = "ProvDocSaldos"
            Var4 = TPROV.Text
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If Var4.Trim.Length > 0 Then
                    If EXISTE_DOC(Var4, Fg.Row) Then
                        MsgBox("El documento ya fue agregado, verifique por favor")
                        Fg(Fg.Row, 1) = ""
                        c_ = 1
                        TMagico.Focus()
                        Fg.Col = c_
                        If ENVIA_ENTER Then
                            SendKeys.Send("{ENTER}")
                        End If
                        ENVIA_ENTER = False
                        Return
                    End If
                End If
                'ENTRA = False
                'Var4 = Fg(Fg.Row, 1) 'DOCUMENTO
                'Var5 = Fg(Fg.Row, 2) 'CLAVE
                'Var6 = Fg(Fg.Row, 3) 'NOMBRE
                'Var11 = Fg(Fg.Row, 6).ToString 'NO_FACTURA
                'Var7 = Fg(Fg.Row, 7).ToString 'ABONOS
                'Var8 = Fg(Fg.Row, 8).ToString 'IMPORTE
                'Var9 = Fg(Fg.Row, 9).ToString 'DOTO
                'Var12 = Fg(Fg.Row, 10).ToString
                'Var10 = Fg(Fg.Row, 10) 'NUM_CARGO

                TXT.Value = Var4
                Fg(Fg.Row, 1) = Var4
                Fg(Fg.Row, 3) = Var10
                Fg(Fg.Row, 4) = Math.Round(CDec(Var9), 6)
                Fg(Fg.Row, 5) = Math.Round(CDec(Var9), 6)
                Fg(Fg.Row, 6) = Math.Round(CDec(Var9), 6)
                Fg(Fg.Row, 7) = Var11
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Col = 1
                'SendKeys.Send("{ENTER}")
                'ENTRA = True
            End If
            Return
        Catch Ex As Exception
            Bitacora("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 13 And e.Col = 6 Then
                    'Fg.Col = 4
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If Fg.Row > 0 And ENTRA Then
            If e.KeyCode = 9 And Fg.Col = 4 Then
                AGREGA_ROW()
            End If
        End If
    End Sub
    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F7
                    BarEliminar_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F3
                    BarGrabar_Click(Nothing, Nothing)
            End Select

            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                'Fg.Col = 4
                            End If
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                ENTRA = False
                                Fg.Col = 4
                            End If
                            SendKeys.Send("{ENTER}")
                            ENTRA = True
                            Return
                        Case 19
                            If Fg.Row = Fg.Rows.Count - 1 Then

                            Else
                                Fg.Row = Fg.Row + 1
                            End If

                            Fg.Col = 1
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = Keys.F2 Then
                    Select Case Fg.Col
                        Case 1
                            ENVIA_ENTER = True
                            SELDOC()
                            'SendKeys.Send("{ENTER}")
                            ENTRA = True
                            Return
                    End Select

                End If
                If e.KeyCode = Keys.Left Then
                    Select Case Fg.Col
                        Case 1
                            e.SuppressKeyPress = True
                        Case 4
                            Fg.Col = 1
                    End Select
                End If
                If e.KeyCode = Keys.Right Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.SuppressKeyPress = True
                            Else
                                Fg.Col = 4
                                'SendKeys.Send("{ENTER}")
                            End If
                    End Select
                End If
                If e.KeyCode = Keys.Up Then
                    If Fg.Row = 1 Then
                        e.SuppressKeyPress = True
                    Else
                        Select Case Fg.Col
                            Case 1
                                Fg.Row = Fg.Row - 1
                                Fg.Col = 1
                                e.SuppressKeyPress = True
                                'SendKeys.Send("{ENTER}")
                        End Select
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    Select Case Fg.Col
                        Case 1
                            Try
                                ENTRA = False
                                If Fg.Row = Fg.Rows.Count - 1 Then
                                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0")
                                        Fg.Row = Fg.Rows.Count - 1
                                    Else

                                    End If
                                Else
                                    Fg.Row = Fg.Row + 1
                                End If
                                Fg.Col = 1
                                e.SuppressKeyPress = True
                                'SendKeys.Send("{ENTER}")
                                ENTRA = True
                            Catch ex As Exception
                                ENTRA = True
                                Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                'e.IsInputKey = True
                                'TXT.Focus()
                            Else
                                Fg.Col = 4
                            End If
                        Case 4
                            AGREGA_ROW()

                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function EXISTE_DOC(FREFER As String, FROW As Integer) As Boolean
        Dim existe As Boolean = False
        Try
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                If k <> FROW Then
                    If Fg(k, 1) = FREFER Then
                        existe = True
                        Exit For
                    End If
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return existe
    End Function
    Private Sub TXTN_TextChanged(sender As Object, e As EventArgs) Handles TXTN.TextChanged
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 4 Then
                    If TXTN.Value > Fg(Fg.Row, 6) Then
                        MsgBox("El pago no puede ser mayor al saldo veifique por favor")
                        TXTN.Value = 0
                        TMagico.Focus()
                        SendKeys.Send("{ENTER}")
                    Else
                        Fg(Fg.Row, 5) = Fg(Fg.Row, 6) - TXTN.Value
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 4
                            If TXTN.Value > 0 Then
                                AGREGA_ROW()
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 4
                            If TXTN.Value > 0 Then
                                AGREGA_ROW()
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub AGREGA_ROW()
        Try
            ENTRA = False
            If Fg.Row = Fg.Rows.Count - 1 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0")
                Fg.Row = Fg.Rows.Count - 1
            Else
                Fg.Row = Fg.Row + 1
            End If

            Fg.Col = 1
            SendKeys.Send("{ENTER}")

            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function CalculaPagos(FRow As Integer, Optional FPAGO As Decimal = 0) As Decimal
        Try
            Dim SUMA As Decimal
            ENTRA = False
            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                If k <> FRow Then
                    SUMA = SUMA + Fg(k, 4)
                Else
                    SUMA = SUMA + FPAGO
                End If
            Next
            ENTRA = True
            Return SUMA
        Catch ex As Exception
            ENTRA = True
            Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Private Sub FECHA_DEP_KeyDown(sender As Object, e As KeyEventArgs) Handles FECHA_DEP.KeyDown
        If e.KeyCode = 13 Then
            TNUM_CPTO.Focus()
        End If
    End Sub
    Private Sub TXT_Leave(sender As Object, e As EventArgs) Handles TXT.Leave
        '1
        Try
            If Fg.Row > 0 Then
                ENTRA = False
                Select Case Fg.Col
                    Case 1
                        If TXT.Text.Trim.Length > 0 Then
                            If EXISTE_DOC(TXT.Text, Fg.Row) Then
                                MsgBox("El documento ya fue agregado, verifique por favor")
                                Fg(Fg.Row, 1) = ""
                                TXT.Value = ""
                                TXT.Text = ""
                                TMagico.Focus()
                                ENTRA = True
                                Return
                            End If
                        End If
                        If TXT.Text.Trim.Length > 0 And Fg(Fg.Row, 4) = 0 Then

                        End If
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Dim DESCR As String, MONTO As Decimal = 0

        If TXT.Text.Trim.Length > 0 Then

            If IsNumeric(Fg(Fg.Row, 4)) Then
                MONTO = Fg(Fg.Row, 4)
            Else
                MONTO = 0
            End If
            If Fg.Col = 1 Then
                Var4 = TPROV.Text
                Var5 = ""
                DESCR = BUSCA_CAT("ProvDocSaldos2", Fg.Editor.Text)
                If DESCR <> "" Then
                    'Var4 = Fg(Fg.Row, 1).ToString  'REFER
                    'Var8 = Fg(Fg.Row, 8) 'IMPORTE
                    'Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
                    'Var6 = Fg(Fg.Row, 11).ToString  'NUM_CARGO
                    Fg(Fg.Row, 3) = Var6
                    If IsNumeric(Var9) Then
                        Fg(Fg.Row, 4) = Math.Round(CDec(Var9), 6)
                        Fg(Fg.Row, 5) = Math.Round(CDec(Var9), 6)
                        Fg(Fg.Row, 6) = Math.Round(CDec(Var9), 6)
                        Fg(Fg.Row, 7) = Var11

                    End If
                Else
                    TXT.Value = ""
                    Fg(Fg.Row, 1) = ""
                    MsgBox("Documento inexistente")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub TMagico_GotFocus(sender As Object, e As EventArgs) Handles TMagico.GotFocus
        TXT.Value = ""
        Fg.Focus()
        TXT.Focus()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Up
                If Fg.Row = 1 Then
                    'e.SuppressKeyPress = True
                Else
                    Select Case Fg.Col
                        Case 1
                            Fg.Row = Fg.Row - 1
                            Fg.Col = 1
                            'e.SuppressKeyPress = True
                            'SendKeys.Send("{ENTER}")
                    End Select
                End If
                Return True ' <-- If you want to suppress default handling of arrow keys

            Case Keys.Right
                Select Case Fg.Col
                    Case 1
                        If TXT.Text.Length = 0 Then
                            'e.SuppressKeyPress = True
                        Else
                            Fg.Col = 4
                            'SendKeys.Send("{ENTER}")
                        End If
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys

            Case Keys.Down
                Select Case Fg.Col
                    Case 1
                        Try
                            ENTRA = False
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0")
                                    Fg.Row = Fg.Rows.Count - 1
                                Else

                                End If
                            Else
                                Fg.Row = Fg.Row + 1
                            End If
                            Fg.Col = 1
                            'e.SuppressKeyPress = True
                            'SendKeys.Send("{ENTER}")
                            ENTRA = True
                        Catch ex As Exception
                            ENTRA = True
                            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys
            Case Keys.Left
                Select Case Fg.Col
                    Case 1
                        'e.SuppressKeyPress = True
                    Case 4
                        Fg.Col = 1
                End Select
                Return True ' <-- If you want to suppress default handling of arrow keys

        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub TXTN_Leave(sender As Object, e As EventArgs) Handles TXTN.Leave
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 4 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                        If Not IsNothing(TXTN.Value) Then
                            If TXTN.Value > 0 Then
                                TIMPORTE.Value = CalculaPagos(Fg.Row, TXTN.Value)

                            Else
                                MsgBox("El monto no puede ser cero verifique por favor")
                                Fg.Col = 1
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function CargaCuentasBancarias() As Boolean
        Try
            Dim dt As DataTable
            Dim exist As Boolean = False

            CboCuentabancaria.Items.Clear()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT TRY_PARSE(ISNULL(CLAVE,'0') AS INT) AS CVE, CUENTA_BANCARIA, ISNULL(NOMBRE_BANCO,'') AS NOMBRE
                    FROM CUENTA_BENEF" & Empresa & " 
                    WHERE ISNULL(STATUS,'A') = 'A' 
                    ORDER BY TRY_PARSE(CLAVE AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboCuentabancaria.Items.Add(String.Format("{0} | {1} | {2}", dr("CVE"), dr("CUENTA_BANCARIA"), dr("NOMBRE")))
                        exist = True
                    End While
                End Using
            End Using

            If CboCuentabancaria.Items.Count = 1 Then
                CboCuentabancaria.SelectedIndex = 0
            End If

            Return exist
        Catch ex As Exception
            Bitacora("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return False
        End Try
    End Function
End Class

