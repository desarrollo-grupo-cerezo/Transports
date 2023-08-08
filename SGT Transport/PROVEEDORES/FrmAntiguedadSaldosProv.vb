Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.IO

Public Class FrmAntiguedadSaldosProv
    Private Sub FrmAntiguedadSaldosProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        If PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE = "BR3FRAJA" Then
            BarDiseñador.Visible = True
        Else
            BarDiseñador.Visible = False
        End If

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        BtnProv1.FlatStyle = FlatStyle.Flat
        BtnProv1.FlatAppearance.BorderSize = 0
        BtnProv2.FlatStyle = FlatStyle.Flat
        BtnProv2.FlatAppearance.BorderSize = 0

    End Sub

    Private Sub FrmAntiguedadSaldosProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnClie1_Click(sender As Object, e As EventArgs) Handles BtnProv1.Click
        Try
            Var2 = "Prov"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPROV1.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV1_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROV1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TPROV1_Validated(sender As Object, e As EventArgs) Handles TPROV1.Validated
        Try
            If TPROV1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TPROV1.Text.Trim) Then
                    DESCR = Space(10 - TPROV1.Text.Trim.Length) & TPROV1.Text.Trim
                    TPROV1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TPROV1.Text)
                If DESCR = "" Then
                    MsgBox("Proveedor inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProv2_Click(sender As Object, e As EventArgs) Handles BtnProv2.Click
        Try
            Var2 = "Prov"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPROV2.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV2_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROV2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProv2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TPROV2_Validated(sender As Object, e As EventArgs) Handles TPROV2.Validated
        Try
            If TPROV2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TPROV2.Text.Trim) Then
                    DESCR = Space(10 - TPROV2.Text.Trim.Length) & TPROV2.Text.Trim
                    TPROV2.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Prov", TPROV2.Text)
                If DESCR = "" Then
                    MsgBox("Proveedor inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        PrinterMRT("ReportAntiguedadSaldosClie")
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If
            Dim PROV As String = "", IMPORTE As Decimal = -99999999, ABONOS As Decimal = 0, CADENA As String = ""
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, SALDO As Decimal = 0
            Dim CARGOS As Decimal = 0, NDIAS As Integer
            Dim RUTA_FORMATOS As String = "", j As Integer = 0, FECHA_REF As String
            Dim SALDO30 As Decimal, SALDO60 As Decimal, SALDO90 As Decimal, SALDO91 As Decimal
            Dim t As DataTable = DataSet1.Tables(0)
            Dim r As DataRow
            DataSet1.Clear()

            Try
                If TPROV1.Text.Trim.Length > 0 Then
                    Dim DESCR As String

                    If IsNumeric(TPROV1.Text.Trim) Then
                        DESCR = Space(10 - TPROV1.Text.Trim.Length) & TPROV1.Text.Trim
                        TPROV1.Text = DESCR
                    End If

                    DESCR = BUSCA_CAT("Prov", TPROV1.Text)
                    If DESCR = "" Then
                        MsgBox("Proveedor inexistente")
                        Return
                    End If
                End If
                If TPROV2.Text.Trim.Length > 0 Then
                    Dim DESCR As String

                    If IsNumeric(TPROV2.Text.Trim) Then
                        DESCR = Space(10 - TPROV2.Text.Trim.Length) & TPROV2.Text.Trim
                        TPROV2.Text = DESCR
                    End If

                    DESCR = BUSCA_CAT("Prov", TPROV2.Text)
                    If DESCR = "" Then
                        MsgBox("Proveedor inexistente")
                        Return
                    End If
                End If
            Catch ex As Exception
                Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            ChDetalle.Focus()
            BarImprimir.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            FECHA_REF = " AND M.FECHA_APLI <= '" & FSQL(F1.Value) & "'"

            If TPROV1.Text.Trim.Length > 0 And TPROV2.Text.Trim.Length > 0 Then
                PROV = " AND M.CVE_PROV >= '" & TPROV1.Text & "' AND M.CVE_PROV <= '" & TPROV2.Text & "'"
            Else
                If TPROV1.Text.Trim.Length > 0 And TPROV2.Text.Trim.Length = 0 Then
                    PROV = " AND M.CVE_PROV >= '" & TPROV1.Text & "'"
                Else
                    If TPROV1.Text.Trim.Length = 0 And TPROV2.Text.Trim.Length > 0 Then
                        PROV = " AND M.CVE_PROV <= '" & TPROV2.Text & "'"
                    Else
                        PROV = ""
                    End If
                End If
            End If

            CADENA = " AND (M.IMPORTE * M.SIGNO) + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " 
                    WHERE CVE_PROV = M.CVE_PROV AND ID_MOV = M.NUM_CPTO AND REFER = M.REFER),0) > 0.9 "

            SQL = "SELECT M.CVE_PROV, T.NOMBRE, T.CLASIFIC, M.REFER, (M.IMPORTE * M.SIGNO) As IMPORTE_M, 
                D.NO_FACTURA As NO_FAC_D, D.DOCTO As DOCTO_D, ISNULL(M.FECHA_APLI,'') AS F_APLI_M, 
                M.FECHA_VENC, 
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM PAGA_DET" & Empresa & " WHERE CVE_PROV = M.CVE_PROV AND ID_MOV = M.NUM_CPTO And SIGNO = -1 And REFER = M.REFER),0) As CARGOS, 
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM PAGA_DET" & Empresa & " WHERE CVE_PROV = M.CVE_PROV AND ID_MOV = M.NUM_CPTO And SIGNO = 1 AND REFER = M.REFER),0) As ABONOS,
                ISNULL(D.FECHA_APLI,'') AS F_APLI_D, ISNULL(D.FECHA_VENC,'') AS F_VENC_D, ISNULL(D.SIGNO,1) As SIGNO_D, 
                ISNULL((D.IMPORTE * D.SIGNO),0) AS IMPORTE_D 
                FROM PAGA_M" & Empresa & " M
                LEFT JOIN PAGA_DET" & Empresa & " D On M.CVE_PROV = D.CVE_PROV And M.REFER = D.REFER And M.NUM_CPTO = D.ID_MOV And M.NUM_CARGO = D.NUM_CARGO
                LEFT JOIN PROV" & Empresa & " T ON T.CLAVE = M.CVE_PROV
                WHERE ISNULL(M.CVE_PROV,'') <> '' " & FECHA_REF & PROV & CADENA & "
                ORDER BY M.CVE_PROV"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()
                        IMPORTE = dr("IMPORTE_M")
                        SALDO = IMPORTE + dr("ABONOS")
                        ABONOS += dr("ABONOS")
                        NDIAS = DateDiff(DateInterval.Day, dr("FECHA_VENC"), F1.Value)
                        SALDO30 = 0 : SALDO60 = 0 : SALDO90 = 0 : SALDO91 = 0
                        Select Case NDIAS
                            Case 1 To 30
                                SALDO30 = SALDO
                            Case 31 To 60
                                SALDO60 = SALDO
                            Case 61 To 90
                                SALDO90 = SALDO
                            Case > 90
                                SALDO91 = SALDO
                        End Select
                        r = t.NewRow()
                        r("REFER") = dr("REFER")
                        r("CLIENTE") = dr("CVE_PROV")
                        r("NOMBRE") = dr("NOMBRE")
                        r("IMPORTE") = dr("IMPORTE_M")
                        r("SALDO") = SALDO
                        r("ABONOS") = ABONOS
                        r("NDIAS30") = SALDO30
                        r("NDIAS60") = SALDO60
                        r("NDIAS90") = SALDO90
                        r("NDIASMAYOR90") = SALDO91
                        r("CLASIFIC") = dr("CLASIFIC")
                        r("FECHA_APLI") = dr("F_APLI_M")
                        r("FECHA1") = F1.Value.ToString.Substring(0, 10)
                        r("CLIENTE1") = TPROV1.Text
                        r("CLIENTE2") = TPROV2.Text

                        If dr("REFER") = "          0000008915" Or dr("REFER") = "          0000008920" Then
                            Debug.Print("")
                        End If

                        If TPROV1.Text.Trim.Length > 0 Or TPROV2.Text.Trim.Length > 0 Then
                            r("DEL_AL") = "Desde el proveedor  " & TPROV1.Text.Trim & "      hasta el proveedor " & TPROV2.Text.Trim
                        Else
                            r("DEL_AL") = "Proveedores:       Todos"
                        End If
                        r("CLIE_PROV") = "PROVEEDORES"
                        t.Rows.Add(r)
                    End While
                End Using
            End Using

            Cursor.Current = Cursors.Default
            BarImprimir.Enabled = True

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportAntiguedadSaldosClie.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS)

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()

            If PASS_GRUPOCE = "BUS" Then
                StiReport1.Design()
            Else
                StiReport1.Show()
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Cursor.Current = Cursors.Default
        BarImprimir.Enabled = True
    End Sub
End Class