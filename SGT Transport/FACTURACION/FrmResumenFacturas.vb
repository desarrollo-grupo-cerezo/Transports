Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmResumenFacturas
    Private CADENA As String
    Private Sub FrmResumenFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

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

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 1


            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - 50
            Fg.Rows(0).Height = 50

            CADENA = ""

            CboTipVenta.Items.Clear()
            CboTipVenta.Items.Add("Todos")
            CboTipVenta.Items.Add("Flete")
            CboTipVenta.Items.Add("Servicio")
            CboTipVenta.SelectedIndex = 0
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim z As Integer = 1
        Dim CAN_TOT As Decimal, IVA As Decimal, IMPORTE As Decimal, RET As Decimal
        Dim S1 As Decimal, S2 As Decimal, S3 As Decimal, S4 As Decimal

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Redraw = False
        Fg.Styles.Normal.WordWrap = True

        Try
            'INVE01.CAMPLIB3
            Fg.Rows.Count = 1
            SQL = "SELECT F.FACTURA, F.DOCUMENT, F.DOCUMENT2, P.CLIENTE, C.NOMBRE, (CASE ISNULL(F.ESTATUS,'A') WHEN 'C' THEN 'CANCELADA' ELSE 'EMITIDA' END) AS ST,
                F.FECHA_CANCELADA, VERSION, FECHA_CERT, ISNULL(CVE_TRACTOR,'') AS UNIDAD, P.FECHA_CARGA, P.FECHA_DESCARGA, 
                ISNULL(FECHA_TIMBRE, F.FECHAELAB) AS FECHA_TIMB, 
                ISNULL(P.FECHA_CARGA_TIMBRE,P.FECHA_CARGA) AS FECHA_CARG,
                ISNULL(P.CVE_DOCR,'') AS DOCR, ISNULL((SELECT CAMPLIB3 FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = P.CVE_MAT),'') AS LIB3,
                ISNULL((SELECT SUM(SUBTOTAL) FROM GCCARTA_PORTE WHERE CVE_FOLIO = F.DOCUMENT OR CVE_FOLIO = F.DOCUMENT2),0) AS SUBT, 
                ISNULL((SELECT SUM(RETENCION) FROM GCCARTA_PORTE WHERE CVE_FOLIO = F.DOCUMENT OR CVE_FOLIO = F.DOCUMENT2),0) AS RETE, 
                ISNULL((SELECT SUM(IVA) FROM GCCARTA_PORTE WHERE CVE_FOLIO = F.DOCUMENT OR CVE_FOLIO = F.DOCUMENT2),0) AS IVAT, 
                ISNULL((SELECT SUM(NETO) FROM GCCARTA_PORTE WHERE CVE_FOLIO = F.DOCUMENT OR CVE_FOLIO = F.DOCUMENT2),0) AS NETOT 
                FROM CFDI F
                LEFT JOIN GCCARTA_PORTE P ON P.CVE_FOLIO = F.DOCUMENT
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE " &
                CADENA & " ORDER BY F.FECHAELAB"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.CommandTimeout = 300
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        If dr("LIB3") = "F" Then
                            If dr("ST") = "CANCELADA" Then
                                CAN_TOT = 0 : IVA = 0 : RET = 0 : IMPORTE = 0
                            Else
                                CAN_TOT = dr.ReadNullAsEmptyDecimal("SUBT")
                                IVA = dr.ReadNullAsEmptyDecimal("IVAT")
                                RET = dr.ReadNullAsEmptyDecimal("RETE")
                                IMPORTE = dr.ReadNullAsEmptyDecimal("NETOT")
                                S1 += CAN_TOT
                                S2 += IVA
                                S3 += Math.Abs(RET)
                                IMPORTE = CAN_TOT + IVA + RET
                                S4 += IMPORTE
                            End If

                            Fg.AddItem(z & vbTab & "Factura" & vbTab & dr("FACTURA") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE") & vbTab &
                               dr("ST") & vbTab & dr("FECHA_TIMB") & vbTab & dr("FECHA_CANCELADA") & vbTab & CAN_TOT & vbTab & IVA & vbTab & RET & vbTab &
                               IMPORTE & vbTab & dr("FECHA_CARG") & vbTab & dr("DOCUMENT") & vbTab & dr("UNIDAD") & vbTab & dr("LIB3"))

                            If dr("ST") = "CANCELADA" Then
                                Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                            End If
                            z += 1
                        End If
                    End While
                    Fg.AddItem(z & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                               S1 & vbTab & S2 & vbTab & (S3 * -1) & vbTab & S4)
                End Using
            End Using
            Fg.Cols(1).Width = 60
            Fg.Cols(2).Width = 90
            Fg.Cols(3).Width = 45
            Fg.Cols(4).Width = 160
            Fg.Cols(5).Width = 70
            Fg.Cols(6).Width = 70 'fecha timbrado
            Fg.Cols(7).Width = 70 'fechacancelacion

            Fg.Cols(9).Width = 80 : Fg.Cols(10).Width = 80 : Fg.Cols(11).Width = 80
            'Fg.Cols(14).Width = 90 : Fg.Cols(15).Width = 90 'CARTA PORTE 1 Y 2
            'Fg.Cols(19).Width = 120

            Fg.AutoSizeRows()
            Fg.Rows(0).Height = 50

            If Fg.Rows.Count = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            If ex.Message.ToString.IndexOf("tiempo de espera") = -1 Then
                MsgBox("14. El servidor no responde vuelva a intentar generar el repote de facturas por favor")
            Else
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End If
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub FrmResumenFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Resumen de facturas")
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim CADENA_CLIE As String = "", CADENA_CLASIFIC As String = "", CADENA_TIPO_VENTA As String
        Dim CLIE1 As String, CLIE2 As String

        CLIE1 = TCVE_CLIE1.Text.Trim
        CLIE1 = Space(10 - Len(CLIE1)) & CLIE1
        TCVE_CLIE1.Text = CLIE1

        CLIE2 = TCVE_CLIE2.Text.Trim
        CLIE2 = Space(10 - Len(CLIE2)) & CLIE2
        TCVE_CLIE2.Text = CLIE2

        Try
            If RadFechCarga.Checked Then
                CADENA = " WHERE P.FECHA_CARGA_TIMBRE >= '" & FSQL(F1.Value) & " 00:00:00' AND P.FECHA_CARGA_TIMBRE <= '" & FSQL(F2.Value) & " 23:59:00'"
            Else
                'CADENA = " WHERE F.FECHA_TIMBRADO >= '" & FSQL(F1.Value) & " 00:00:00' AND F.FECHA_TIMBRADO <= '" & FSQL(F2.Value) & " 23:59:00'"
                CADENA = " WHERE TRY_PARSE(FECHA_CERT AS DATETIME USING 'es-mx') >= '" & FSQL(F1.Value) & " 00:00:00' AND 
                                 TRY_PARSE(FECHA_CERT AS DATETIME USING 'es-mx') <= '" & FSQL(F2.Value) & " 23:59:00'"
            End If

            If CLIE1.Trim.Length > 0 And CLIE2.Trim.Length > 0 Then
                CADENA_CLIE = " AND P.CLIENTE >= '" & CLIE1 & "' AND P.CLIENTE <= '" & CLIE2 & "'"
            Else
                If CLIE1.Trim.Length > 0 Then
                    CADENA_CLIE = " AND P.CLIENTE >= '" & CLIE1 & "'"
                Else
                    If CLIE2.Trim.Length > 0 Then
                        CADENA_CLIE = " AND P.CLIENTE <= '" & CLIE2 & "'"
                    End If
                End If
            End If

            Select Case CboTipVenta.SelectedIndex
                Case 0
                    CADENA_TIPO_VENTA = ""
                Case 1
                    CADENA_TIPO_VENTA = " AND ISNULL((SELECT CAMPLIB3 FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = P.CVE_MAT),'') = 'F'"
                Case 2
                    CADENA_TIPO_VENTA = " AND ISNULL((SELECT CAMPLIB3 FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = P.CVE_MAT),'') = 'S'"
                Case Else
                    CADENA_TIPO_VENTA = ""
            End Select

            If TCLASIFIC.Text.Trim.Length > 0 Then
                CADENA_CLASIFIC = " AND C.CLASIFIC = '" & TCLASIFIC.Text & "'"
            End If

            CADENA = CADENA & CADENA_CLIE & CADENA_CLASIFIC & CADENA_TIPO_VENTA
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Resumen de ventas")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim Rreporte_MRT As String
        Dim RUTA_FORMATOS As String
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow
        DataSet1.Clear()


        For k = 1 To Fg.Rows.Count - 1
            Try
                r = t.NewRow()
                If Not IsNothing(Fg(k, 2)) Then
                    If Fg(k, 2).ToString.Trim.Length > 0 Then
                        r("CVE_DOC") = Fg(k, 2)
                        r("CLIENTE") = Fg(k, 3)
                        If Fg(k, 5) = "CANCELADA" Then
                            r("NOMBRE") = "C A N C E L A D A"
                        Else
                            r("NOMBRE") = Fg(k, 4)
                        End If
                        r("ESTATUS") = Fg(k, 5)
                        r("FECHA_TIMBRADO") = Fg(k, 6)
                        If Not IsNothing(Fg(k, 7)) Then
                            r("FECHA_CANC") = Fg(k, 7)
                        End If
                        r("SUBTOTAL") = Math.Round(Fg(k, 8), 4)
                        r("IVA") = Math.Round(Fg(k, 9), 4)
                        r("RETENCION") = Math.Round(Fg(k, 10), 4)
                        r("IMPORTE") = Math.Round(Fg(k, 11), 4)
                        r("FECHA_CARGA") = Fg(k, 12)
                        r("CARTA_PORTE") = Fg(k, 13)
                        r("UNIDAD") = Fg(k, 14)
                        r("F1") = F1.Value
                        r("F2") = F2.Value
                        r("CLIE1") = TCVE_CLIE1.Text
                        r("CLIE2") = TCVE_CLIE2.Text
                        r("CLASIFIC") = TCLASIFIC.Text
                        r("TIPO_VENTA") = CboTipVenta.Text
                        If RadFechCarga.Checked Then
                            r("POR_FECHA") = "Por fecha de carga"
                        Else
                            r("POR_FECHA") = "Por fecha de elaboración"
                        End If
                        t.Rows.Add(r)
                    End If
                End If
            Catch ex As Exception
                Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        RUTA_FORMATOS = GET_RUTA_FORMATOS()
        Try
            Rreporte_MRT = RUTA_FORMATOS & "\" & "ReportResumenFacturas.mrt"
            If Not File.Exists(Rreporte_MRT) Then
                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                Return
            End If
            StiReport1.Load(Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
            'StiReport1.Design()
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnClie1_Click(sender As Object, e As EventArgs) Handles BtnClie1.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE1.Text = Var4

                Var2 = "" : Var3 = "" : Var4 = ""
                TCVE_CLIE2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnClie2_Click(sender As Object, e As EventArgs) Handles BtnClie2.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE2.Text = Var4

                Var2 = "" : Var3 = "" : Var4 = ""
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CLIE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnClie1_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_CLIE1_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE1.Validated
        Try
            If TCVE_CLIE1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCVE_CLIE1.Text.Trim) Then
                    DESCR = TCVE_CLIE1.Text.Trim
                    DESCR = Space(10 - Len(DESCR)) & DESCR
                    TCVE_CLIE1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE1.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE1.Text = ""
                    TCVE_CLIE1.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CLIE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnClie2_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_CLIE2_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE2.Validated
        Try
            If TCVE_CLIE2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCVE_CLIE2.Text.Trim) Then
                    DESCR = TCVE_CLIE2.Text.Trim
                    DESCR = Space(10 - Len(DESCR)) & DESCR
                    TCVE_CLIE2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE2.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE2.Text = ""
                    TCVE_CLIE2.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
