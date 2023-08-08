Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class frmSaldosClientes
    Private Sub FrmSaldosClientes_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            Fg.Width = Me.Width - 50
            Fg.Height = Me.Height - C1ToolBar1.Height - F1.Top - F1.Height
            Fg.Rows.Count = 1

            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

            If PASS_GRUPOCE <> "BUS" Then
                btnSaldos.Visible = False
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmSaldosClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Antiguedad de saldos clientes")
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR()
        Dim REFER As String, NO_FACTURA As String, S10 As Decimal = 0, SIGNO As Integer, NO_PARTIDA As Integer
        Dim CLIENTE As String = "", IMPORTE As Decimal = -99999999, CARGOS As Decimal = 0, ABONOS As Decimal = 0, CADENA As String = "", S4 As Decimal = 0, S5 As Decimal = 0
        Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, TCAMBIO As Decimal = 0, SUBTOTAL As Decimal = 0, IVA As Decimal = 0, SALDO As Decimal = 0
        Dim S16 As Decimal = 0, S19 As Decimal = 0, S24 As Decimal = 0, S25 As Decimal = 0
        Dim startTime As DateTime = DateTime.Now
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Violet
        NewStyle1.ForeColor = Color.Black

        Try
            Fg.Rows.Count = 1
            Fg.Redraw = False
            Cursor.Current = Cursors.WaitCursor

            If Not chConSaldo.Checked Then
                CADENA = "AND ABS((C1.IMPORTE * C1.SIGNO) + ISNULL((SELECT ISNULL(SUM(C4.IMPORTE * C4.SIGNO),0) As ABONOS FROM CUEN_DET" & Empresa & " C4 WHERE C4.REFER = C1.REFER AND C4.CVE_CLIE = C1.CVE_CLIE AND C4.ID_MOV = C1.NUM_CPTO AND C4.SIGNO = -1),0) + " &
                        "ISNULL((SELECT ISNULL(SUM(C5.IMPORTE * C5.SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C5 WHERE C5.REFER = C1.REFER AND C5.CVE_CLIE = C1.CVE_CLIE AND C5.ID_MOV = C1.NUM_CPTO AND C5.SIGNO = 1),0)) > .009 "
            End If
            SQL = "SELECT C1.CVE_CLIE, C1.REFER, ISNULL(C1.IMPORTE * C1.SIGNO,0) AS IMPORT, C.NOMBRE, C1.FECHA_APLI, ISNULL(C1.SIGNO,1) AS SIGN, " &
                    "C1.NUM_CPTO, C1.NUM_CARGO, ISNULL(F.IMP_TOT4,0) AS IVA, ISNULL(F.CAN_TOT,0) AS C_TOT, " &
                    "ISNULL((SELECT ISNULL(SUM(IMPORTE * SIGNO),0) AS ABONOS1 FROM CUEN_DET" & Empresa & " C3 WHERE C3.REFER = C1.REFER AND C3.CVE_CLIE = C1.CVE_CLIE AND C3.ID_MOV = C1.NUM_CPTO AND C3.SIGNO = -1 AND C1.FECHA_APLI <= '" & FSQL(F1.Value) & "'), 0) AS TABONO, " &
                    "ISNULL((SELECT ISNULL(SUM(IMPORTE * SIGNO),0) AS ABONOS2 FROM CUEN_DET" & Empresa & " C4 WHERE C4.REFER = C1.REFER AND C4.CVE_CLIE = C1.CVE_CLIE AND C4.ID_MOV = C1.NUM_CPTO AND C4.SIGNO = 1 AND C1.FECHA_APLI <= '" & FSQL(F1.Value) & "'), 0) AS TCARGO " &
                    "FROM CUEN_M" & Empresa & " C1 " &
                    "LEFT JOIN FACTF" & Empresa & " F On C1.REFER = F.CVE_DOC " &
                    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = C1.CVE_CLIE " &
                    "LEFT JOIN CONC" & Empresa & " T ON T.NUM_CPTO = C1.NUM_CPTO " &
                    "WHERE C1.FECHA_APLI <= '" & FSQL(F1.Value) & "' " & CADENA &
                    "ORDER BY C1.CVE_CLIE, FECHA_VENC"
            If Tipo = 0 Then
            Else
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                Application.DoEvents()
                                If CLIENTE <> dr("CVE_CLIE") Then
                                    If IMPORTE <> -99999999 Then
                                        CLIENTE = dr("CVE_CLIE")
                                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Cargos a la fecha" & vbTab & CARGOS & vbTab &
                                                   "Abonos a la fecha" & vbTab & ABONOS & vbTab & "Saldo" & vbTab & CARGOS + ABONOS)
                                        'Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                        'Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 7, NewStyle1)
                                        Fg.SetCellStyle(Fg.Rows.Count - 1, 8, NewStyle1)
                                        IMPORTE = 0 : CARGOS = 0 : ABONOS = 0
                                    End If
                                    Fg.AddItem("" & vbTab & "(" & dr("CVE_CLIE") & ") " & dr("NOMBRE"))
                                End If
                                TCAMBIO = 1
                                SUBTOTAL = dr("C_TOT")
                                IVA = dr("IVA")

                                IMPORTE = dr("TCARGO") + dr("TABONO")
                                SALDO = dr("IMPORT") + dr("TCARGO") + dr("TABONO")
                                Fg.AddItem("" & vbTab & dr("NOMBRE") & vbTab & dr("FECHA_APLI") & vbTab & dr("REFER") & vbTab & SUBTOTAL & vbTab &
                                           Format(IMPORTE, "###,###,##0.00") & vbTab & IVA & vbTab & Format(SALDO, "###,###,##0.00") & vbTab & (SUBTOTAL + IVA))
                                CLIENTE = dr("CVE_CLIE")

                                CARGOS = CARGOS + dr("IMPORT")
                                ABONOS = ABONOS + dr("TCARGO") + dr("TABONO")
                                S1 = S1 + dr("IMPORT")
                                S2 = S2 + dr("TCARGO") + dr("TABONO")
                                S3 = S3 + dr("IMPORT") + dr("TCARGO") + dr("TABONO")
                                S4 = S4 + dr("TCARGO")
                                S5 = S5 + dr("TABONO")

                            End While
                        End Using
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Total cargos" & vbTab & S1 & vbTab & "Total abonos" & vbTab & S2 & vbTab & "Saldo general" & vbTab & S3)
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Total cargos CUEN_DET" & vbTab & S4)
                        Fg.AddItem("" & vbTab & vbTab & "" & vbTab & "Total abonos CUEN_DET" & vbTab & S5)
                        Fg.AddItem("" & vbTab & vbTab & "" & vbTab & " " & vbTab & S4 + S5)
                    End Using
                Catch ex As Exception
                    Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("200. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
            '=====================================================================================================================
            '=====================================================================================================================

            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM CUEN_DET" & Empresa & " D WHERE FECHA_APLI <= '" & FSQL(F1.Value) & "'  AND NOT EXISTS " &
                        "(SELECT REFER FROM CUEN_M" & Empresa & " WHERE REFER  = D.REFER AND CVE_CLIE = D.CVE_CLIE)"
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        While dr2.Read
                            REFER = dr2("REFER")
                            NO_FACTURA = dr2("NO_FACTURA")
                            SIGNO = dr2("SIGNO")
                            NO_PARTIDA = dr2("NO_PARTIDA")

                            If Not chConSaldo.Checked Then
                                CADENA = "AND ABS((C1.IMPORTE * C1.SIGNO) + ISNULL((SELECT ISNULL(SUM(C4.IMPORTE * C4.SIGNO),0) As ABONOS FROM CUEN_DET" & Empresa & " C4 WHERE C4.REFER = C1.REFER AND C4.CVE_CLIE = C1.CVE_CLIE AND C4.ID_MOV = C1.NUM_CPTO AND C4.SIGNO = -1),0) +
                                  ISNULL((SELECT ISNULL(SUM(C5.IMPORTE * C5.SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C5 WHERE C5.REFER = C1.REFER AND C5.CVE_CLIE = C1.CVE_CLIE AND C5.ID_MOV = C1.NUM_CPTO AND C5.SIGNO = 1),0)) > .009"
                            End If
                            SQL = "SELECT C1.CVE_CLIE, C1.REFER, C1.NO_FACTURA, ISNULL(C1.IMPORTE * C1.SIGNO,0) AS IMPORTE_D, C.NOMBRE, C1.FECHA_APLI, 
                                ISNULL(C1.SIGNO,1) AS SIGN, ISNULL(F.IMP_TOT4,0) AS IVA, ISNULL(F.CAN_TOT,0) AS C_TOT,
                                ISNULL((SELECT TOP 1 REFER FROM CUEN_M" & Empresa & " WHERE REFER = C1.NO_FACTURA),'') AS REFER_M,
                                ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_M" & Empresa & " WHERE REFER = C1.NO_FACTURA),0) AS IMPORTE_M
                                FROM CUEN_DET" & Empresa & " C1
                                LEFT JOIN FACTF" & Empresa & " F On C1.REFER = F.CVE_DOC
                                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = C1.CVE_CLIE
                                LEFT JOIN CONC" & Empresa & " T ON T.NUM_CPTO = C1.NUM_CPTO
                                WHERE C1.FECHA_APLI <= '" & FSQL(F1.Value) & "' " & CADENA & "
                                AND C1.REFER = '" & REFER & "' AND C1.NO_FACTURA = '" & NO_FACTURA & "' AND C1.SIGNO =" & SIGNO & " AND C1.NO_PARTIDA = " & NO_PARTIDA & "
                                ORDER BY C1.CVE_CLIE, FECHA_VENC"
                            'S1 = 0 : S2 = 0 : S3 = 0
                            CARGOS = 0 : ABONOS = 0
                            IMPORTE = -99999999
                            CLIENTE = ""
                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        While dr.Read
                                            Application.DoEvents()
                                            If CLIENTE <> dr("CVE_CLIE") Then
                                                If IMPORTE <> -99999999 Then
                                                    CLIENTE = dr("CVE_CLIE")
                                                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Cargos a la fecha" & vbTab & CARGOS & vbTab &
                                                               "Abonos a la fecha" & vbTab & ABONOS & vbTab & "Saldo" & vbTab & CARGOS + ABONOS)
                                                    'Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                                    'Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 7, NewStyle1)
                                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 8, NewStyle1)
                                                    IMPORTE = 0 : CARGOS = 0 : ABONOS = 0
                                                End If
                                                Fg.AddItem("" & vbTab & "(" & dr("CVE_CLIE") & ") " & dr("NOMBRE"))
                                            End If
                                            TCAMBIO = 1
                                            SUBTOTAL = dr("C_TOT")
                                            IVA = dr("IVA")
                                            'Format(IMPORTE, "###,###,##0.00")
                                            'Format(SALDO, "###,###,##0.00")
                                            IMPORTE = dr("IMPORTE_D")
                                            SALDO = dr("IMPORTE_M") + dr("IMPORTE_D")
                                            Fg.AddItem("" & vbTab & dr("NOMBRE") & vbTab & dr("FECHA_APLI") & vbTab & NO_FACTURA & vbTab & SUBTOTAL & vbTab &
                                                       "" & vbTab & IVA & vbTab & "" & vbTab & (SUBTOTAL + IVA))
                                            CLIENTE = dr("CVE_CLIE")

                                            CARGOS = CARGOS + dr("IMPORTE_D")
                                            ABONOS = ABONOS + dr("IMPORTE_D")
                                            'S1 = S1 + (dr("IMPORT") * dr("SIGN"))
                                            'S2 = S2 + dr("IMPORTE_D")
                                            S10 = S10 + dr("IMPORTE_D")
                                            BACKUPTXT("CPTO 16", "REFER " & NO_FACTURA & " " & dr("IMPORTE_D"))
                                            'S3 = S3 + dr("TABONO")
                                            'S4 = S4 + dr("TABONO")
                                            'S5 = S5 + dr("TABONO")

                                        End While
                                    End Using

                                End Using
                            Catch ex As Exception
                                Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("250. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try

                        End While
                        'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Total cargos" & vbTab & S1 & vbTab & "Total abonos" & vbTab & S2 & vbTab & "Saldo general" & vbTab & S1 + S2)
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("300. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            Fg.AutoSizeCols()
            Fg.Redraw = True
            Fg.Select(Fg.Rows.Count - 1, 1)
            Cursor.Current = Cursors.Default
            Dim endTime As DateTime = DateTime.Now
            Dim span As TimeSpan = endTime.Subtract(startTime)
            L3.Text = "Minutos: " & span.Minutes & " Segundos: " & span.Seconds
            'MessageBox.Show("Proceso terminado")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnSaldos_Click(sender As Object, e As EventArgs) Handles btnSaldos.Click
        DESPLEGAR()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR_NEW()
        Dim z As Integer = 0
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Yellow
        NewStyle1.ForeColor = Color.Black

        Fg.Rows.Count = 1
        Fg.Redraw = False
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim CLIENTE As String = "", IMPORTE As Decimal = -99999999, ABONOS As Decimal = 0, CADENA As String = ""
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, SALDO As Decimal = 0
            Dim CARGOS As Decimal = 0, NDIAS As Integer


            If TCLIENTE.Text.Trim.Length > 0 Then
                CLIENTE = " AND M.CVE_CLIE = '" & TCLIENTE.Text & "'"
            Else
                CLIENTE = ""
            End If

            If chConSaldo.Checked Then
                CADENA = " AND (M.IMPORTE * M.SIGNO) + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " 
                            WHERE CVE_CLIE = M.CVE_CLIE AND REFER = M.REFER),0) > 0.9 "
            Else
                CADENA = ""
            End If
            Fg.Redraw = False

            SQL = "SELECT M.CVE_CLIE, T.NOMBRE, M.REFER, (M.IMPORTE * M.SIGNO) As IMPORTE_M, M.NUM_CPTO As CPTO_M, C.DESCR As DESCR_CONCEP_M, M.NO_FACTURA As NO_FAC_M,
                D.NO_FACTURA As NO_FAC_D, M.DOCTO As DOCTO_M, D.DOCTO As DOCTO_D, M.NUM_CARGO As NUM_CARGO_M, M.FECHA_APLI As FAPLI_M,
                M.FECHA_VENC, M.SIGNO As SIGNO_M, ISNULL(D.NO_PARTIDA,0) AS NO_PAR,
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO And SIGNO = -1 And REFER = M.REFER),0) As CARGOS, 
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO And SIGNO = 1 AND REFER = M.REFER),0) As ABONOS,
                ISNULL(D.FECHA_APLI,'') AS F_APLI_D, ISNULL(D.FECHA_VENC,'') AS F_VENC_D, ISNULL(D.SIGNO,1) As SIGNO_D, 
                ISNULL((D.IMPORTE * D.SIGNO),0) AS IMPORTE_D, 
                ISNULL(D.NUM_CPTO,0) As CPTO_D, ISNULL(C2.DESCR,'') As DES_CONC_D
                FROM CUEN_M" & Empresa & " M
                LEFT JOIN CUEN_DET" & Empresa & " D On M.CVE_CLIE = D.CVE_CLIE And M.REFER = D.REFER And M.NUM_CPTO = D.ID_MOV And M.NUM_CARGO = D.NUM_CARGO
                LEFT JOIN CLIE" & Empresa & " T ON T.CLAVE = M.CVE_CLIE
                LEFT JOIN CONC" & Empresa & " C On C.NUM_CPTO = M.NUM_CPTO
                LEFT JOIN CONC" & Empresa & " C2 On C2.NUM_CPTO = D.NUM_CPTO
                WHERE ISNULL(M.CVE_CLIE,'') <> '' " & CLIENTE & CADENA & "
                ORDER BY M.CVE_CLIE"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Application.DoEvents()
                            If CLIENTE <> dr("CVE_CLIE") Then
                                If IMPORTE <> -99999999 Then
                                    Fg.AddItem("-" & vbTab & "" & vbTab & ABONOS & vbTab & S2 & vbTab & S3 & vbTab & S4 & vbTab & S5)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                                    IMPORTE = 0 : CARGOS = 0 : ABONOS = 0
                                    S2 = 0 : S3 = 0 : S4 = 0 : S5 = 0
                                End If
                                Fg.AddItem("-" & vbTab & "(" & dr("CVE_CLIE") & ") " & dr("NOMBRE"))
                            End If
                            IMPORTE = dr("IMPORTE_M")
                            SALDO = IMPORTE + dr("ABONOS")
                            ABONOS += dr("ABONOS")
                            NDIAS = DateDiff(DateInterval.Day, dr("FECHA_VENC"), F1.Value)
                            Select Case NDIAS
                                Case 1 To 30
                                    CADENA = vbTab & SALDO
                                    S2 += SALDO
                                Case 31 To 60
                                    CADENA = vbTab & vbTab & SALDO
                                    S3 += SALDO
                                Case 61 To 90
                                    CADENA = vbTab & vbTab & vbTab & SALDO
                                    S4 += SALDO
                                Case > 90
                                    CADENA = vbTab & vbTab & vbTab & vbTab & SALDO & vbTab & NDIAS
                                    S5 += SALDO
                            End Select
                            Fg.AddItem(dr("CVE_CLIE") & vbTab & dr("REFER") & vbTab & dr("ABONOS") & CADENA)
                            CLIENTE = dr("CVE_CLIE")

                            S1 += IMPORTE

                        End While
                    End Using
                End Using
                Fg.AddItem("-" & vbTab & "" & vbTab & ABONOS & vbTab & S2 & vbTab & S3 & vbTab & S4 & vbTab & S5)
            Catch ex As Exception
                Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("670. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & vbTab & "" & vbTab & "" & vbTab & vbTab)
            Fg.AutoSizeCols()
            Fg.Redraw = True

            If Fg.Rows.Count > 1 Then
                Fg.Select(1, 1)
            Else
                MsgBox("ok")
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Antiguedad saldos clientes")
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        C1ToolBar1.Enabled = False

        DESPLEGAR_NEW()

        C1ToolBar1.Enabled = True
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "Clientes"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                Var2 = "" : Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            BITACORATPV("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length = 0 Then
                Return
            End If
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = TCLIENTE.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
