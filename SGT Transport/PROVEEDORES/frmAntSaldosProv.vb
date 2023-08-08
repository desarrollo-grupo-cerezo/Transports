Imports C1.Win.C1FlexGrid
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.Drawing
Imports System.Diagnostics
Public Class frmAntSaldosProv
    Private Sub frmAntSaldosProv_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
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
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Violet
        NewStyle1.ForeColor = Color.Black
        Dim startTime As DateTime = DateTime.Now
        Try
            Fg.Rows.Count = 1
            Fg.Redraw = False

            Cursor.Current = Cursors.WaitCursor

        Catch ex As Exception
            Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("480. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            Dim CLIENTE As String = "", IMPORTE As Decimal = -99999999, CARGOS As Decimal = 0, ABONOS As Decimal = 0, CADENA As String = ""
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, TCAMBIO As Decimal = 0, SUBTOTAL As Decimal = 0, IVA As Decimal = 0


            If Not chConSaldo.Checked Then
                CADENA = "AND ABS((C1.IMPORTE * C1.SIGNO) + ISNULL((SELECT COALESCE(SUM(C4.IMPORTE * C4.SIGNO),0) As ABONOS FROM PAGA_DET" & Empresa & " C4 WHERE C4.REFER = C1.REFER AND C4.CVE_PROV = C1.CVE_PROV AND C4.ID_MOV = C1.NUM_CPTO AND C4.SIGNO = -1),0) + " &
                            "(SELECT COALESCE(SUM(C5.IMPORTE * C5.SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C5 WHERE C5.REFER = C1.REFER AND C5.CVE_PROV = C1.CVE_PROV AND C5.ID_MOV = C1.NUM_CPTO AND C5.SIGNO = 1)) > .009 "
            End If

            SQL = "SELECT C1.CVE_PROV AS CVE_CLIE, C1.REFER, C1.IMPORTE, C.NOMBRE, C1.FECHA_APLI, C1.SIGNO, C1.NUM_MONED, C1.TCAMBIO, " &
                "C1.NUM_CPTO, C1.NUM_CARGO, C1.FECHA_VENC, ISNULL(F.IMP_TOT4,0) AS IVA, ISNULL(F.CAN_TOT,0) AS C_TOT, " &
                "(SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 WHERE C3.REFER = C1.REFER AND C3.CVE_PROV = C1.CVE_PROV AND ID_MOV = C1.NUM_CPTO AND SIGNO = -1 AND C1.FECHA_APLI <= '" & FSQL(F1.Value) & "') AS TABONO, " &
                "(SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 WHERE C3.REFER = C1.REFER AND C3.CVE_PROV = C1.CVE_PROV AND ID_MOV = C1.NUM_CPTO AND SIGNO = 1 AND C1.FECHA_APLI <= '" & FSQL(F1.Value) & "') AS TCARGO " &
                "FROM PAGA_M" & Empresa & " C1 " &
                "LEFT JOIN COMPC" & Empresa & " F On C1.REFER = F.CVE_DOC " &
                "LEFT JOIN PROV" & Empresa & " C ON C.CLAVE = C1.CVE_PROV " &
                "LEFT JOIN CONC" & Empresa & " T ON T.NUM_CPTO = C1.NUM_CPTO " &
                "WHERE C1.FECHA_APLI <= '" & FSQL(F1.Value) & "' " & CADENA &
                "ORDER BY C1.CVE_PROV, FECHA_VENC"

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
                            IMPORTE = (dr("IMPORTE") * dr("SIGNO")) + dr("TCARGO") + dr("TABONO")
                            If dr("REFER") = "FCS20033" Then
                                CADENA = ""
                            End If

                            Fg.AddItem("" & vbTab & dr("NOMBRE") & vbTab & dr("FECHA_APLI") & vbTab & dr("REFER") & vbTab & SUBTOTAL & vbTab &
                                       Format(IMPORTE, "###,###,##0.00") & vbTab & IVA & "" & vbTab & vbTab & (SUBTOTAL + IVA))
                            CLIENTE = dr("CVE_CLIE")

                            CARGOS = CARGOS + (dr("IMPORTE") * dr("SIGNO"))
                            ABONOS = ABONOS + (dr("TCARGO") + dr("TABONO"))
                            S1 = S1 + (dr("IMPORTE") * TCAMBIO * dr("SIGNO"))
                            S2 = S2 + dr("TCARGO") + dr("TABONO")
                            S3 = S3 + ((dr("IMPORTE") * TCAMBIO) * dr("SIGNO")) + (dr("TCARGO") + dr("TABONO"))


                        End While
                    End Using
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Total cargos" & vbTab & S1 & vbTab &
                               "Total abonos" & vbTab & S2 & vbTab & "Saldo general" & vbTab & S3)
                End Using
            Catch ex As Exception
                Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("500. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()

            Fg.Redraw = True
            Cursor.Current = Cursors.Default
            Dim endTime As DateTime = DateTime.Now
            Dim span As TimeSpan = endTime.Subtract(startTime)
            L3.Text = "Minutos: " & span.Minutes & " Segundos: " & span.Seconds

            MessageBox.Show("Proceso terminado")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmAntSaldosProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Antiguedad de saldos proveedores")
            Me.Dispose()
        Catch ex As Exception
        End Try
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
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        C1ToolBar1.Enabled = False
        DESPLEGAR()

        C1ToolBar1.Enabled = True
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Antiguedad saldos Proveedores")
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
