Imports C1.C1Excel
Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmEdoCuentaGenOper
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmEdoCuentaGenOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If

        ProcessControls(Me)

    End Sub
    Private Sub FrmEdoCuentaGenOper_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim SPOR1 As Decimal, ANCHOSP As Integer

        SPOR1 = ((F1.Top + F1.Height) / Me.Height) * 100
        SPOR1 = Math.Round(SPOR1, 1) + 2
        'Split1.SizeRatio = SPOR1

        ANCHOSP = (100 - SPOR1) / 2
        'Split3.SizeRatio = ANCHOSP
        'Split2.SizeRatio = ANCHOSP

        Me.Refresh()

        If PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
            BarDiseñador.Visible = True
        Else
            BarDiseñador.Visible = False
        End If
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG

            Dim i As Integer = 1
            F1.Value = "01/01/" & Date.Today.Year
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"


            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 35

            SplitM.SplitterWidth = 1
            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Left
            Fg2.Dock = DockStyle.Left

            'Fg.Tree.Column = 1
            'Fg.Tree.Show(1)
            'Fg.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
            'Fg.Tree.LineColor = Color.DarkBlue
            'Fg.Cols(1).AllowEditing = True
            'Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg.Styles("Normal").Border.Color = Color.Gray

            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.WordWrap = False

            Fg.Cols(2).Width = 350
            Fg.Cols(3).Width = 100
            Fg.Cols(4).Width = 90
            Fg.Cols(5).Width = 110
            Fg.Cols(6).Width = 110
            Fg.Cols(7).Width = 110
            Fg.Width = 1010
            ' Create style used to show negative values.
            Fg.Styles.Add("Red").ForeColor = Color.Red
            ' Create style used to show values >= 1000.
            Fg.Styles.Add("Yellow").ForeColor = Color.RosyBrown
            Fg.Styles.Add("Blue").ForeColor = Color.Blue
            Fg.Styles.Add("Magenta").ForeColor = Color.Magenta
            Fg.Styles.Add("LightGreen").BackColor = Color.LightGreen
            Fg.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw


            Fg2.Rows.Count = 1
            Fg2.Rows(0).Height = 35
            Fg2.Tree.Column = 1
            Fg2.Tree.Show(1)
            Fg2.Tree.Style = TreeStyleFlags.Symbols
            Fg2.Tree.LineColor = Color.DarkBlue
            Fg2.Cols(1).AllowEditing = True
            Fg2.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg2.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg2.Styles.Normal.WordWrap = False
            Fg2.Styles("Normal").Border.Color = Color.LightGray

            Fg2.Cols(2).Width = 350
            Fg2.Cols(3).Width = 90
            Fg2.Cols(4).Width = 90
            Fg2.Cols(5).Width = 110
            Fg2.Cols(6).Width = 110
            Fg2.Cols(7).Width = 110

            Fg2.Width = 1010
            'Fg2.Cols(8).Width = 0
            ' Create style used to show negative values.
            Fg2.Styles.Add("Red").ForeColor = Color.Red
            ' Create style used to show values >= 1000.
            Fg2.Styles.Add("Yellow").ForeColor = Color.RosyBrown
            Fg2.Styles.Add("Blue").ForeColor = Color.Blue
            Fg2.Styles.Add("Magenta").ForeColor = Color.Magenta
            Fg2.Styles.Add("LightGreen").BackColor = Color.LightGreen
            Fg2.DrawMode = DrawModeEnum.OwnerDraw


        Catch ex As Exception
            Bitacora("750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim r As Row, S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, r_ As Integer
        Dim ABONO As Decimal, NUM_PAR As Integer, SALDO As Decimal = 0
        Dim t1 As DataTable = DataSet1.Tables(0)
        Dim t2 As DataTable = DataSet1.Tables(1)
        Dim r1 As DataRow
        Dim r2 As DataRow

        DataSet1.Clear()

        Fg.Rows.Count = 1
        Fg2.Rows.Count = 1
        If TCVE_OPER.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un operador")

            BtnOper_Click(Nothing, Nothing)
            Return
        End If
        If BUSCA_CAT("Operador", TCVE_OPER.Text) = "" Then
            MsgBox("Operador existenete verifique por favor")
            Return
        End If
        Fg.Redraw = False
        Fg2.Redraw = False
        Me.Cursor = Cursors.WaitCursor
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.FOLIO, GV.IMPORTE, ISNULL(C.DESCR,'') AS DESCR_GASTOS, GV.CVE_VIAJE, 
                    GV.CVE_LIQ, GV.FECHA, GV.CVE_NUM, ISNULL(GV.STATUS,'') AS ST
                    FROM GCASIGNACION_VIAJE_GASTOS GV
                    LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                    WHERE ISNULL(GV.STATUS,'A') <> 'C' AND GV.CVE_OPER = " & TCVE_OPER.Text & " AND 
                    FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'
                    ORDER BY GV.FOLIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If dr("ST") = "L" Then
                            ABONO = dr("IMPORTE")
                        Else
                            ABONO = 0
                        End If
                        Fg.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("CVE_NUM") & " " & dr("DESCR_GASTOS") & vbTab & dr("CVE_LIQ") & vbTab &
                                  dr("FECHA") & vbTab & dr("IMPORTE") & vbTab & ABONO & vbTab & dr("IMPORTE") - ABONO)

                        r1 = t1.NewRow()
                        r1("FOLIO") = dr("FOLIO")
                        r1("DESCR_GASTOS") = dr("CVE_NUM") & " " & dr("DESCR_GASTOS")
                        r1("CVE_LIQ") = dr("CVE_LIQ")
                        r1("FECHA") = dr("FECHA")
                        r1("IMPORTE") = dr("IMPORTE")
                        r1("SALDO") = dr("IMPORTE") - ABONO
                        r1("F1") = F1.Value
                        r1("F2") = F2.Value
                        r1("CVE_OPER") = TCVE_OPER.Text
                        r1("NOMBRE_OPER") = LOper.Text

                        t1.Rows.Add(r1)

                        S1 += dr("IMPORTE")
                        S2 += ABONO
                        S3 += dr("IMPORTE") - ABONO
                    End While
                End Using
            End Using
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab & S2 & vbTab & S3)
            SALDO = S3
        Catch ex As Exception
            Bitacora("750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("750. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        S1 = 0 : S2 = 0 : S3 = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT D.FOLIO AS FOLIO_DED, D.CVE_DED AS DC_DED, CASE WHEN D.STATUS = 'A' THEN 'PENDIENTE' ELSE 'PAGADO' END AS ST_DED, 
                    D.DESCR AS DESCR_DED, D.IMPORTE_PRESTAMO AS IMPORT_PRES, D.IMPORTE_PAGADO, D.SALDO, 
                    ISNULL((SELECT SUM(LD.IMPORTE) FROM GCDEDUC_OPER DD LEFT JOIN GCLIQ_DEDUCCIONES LD ON LD.CVE_DED = DD.FOLIO    
                    LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LD.CVE_LIQ WHERE L.CVE_ST_LIQ = 2 AND LD.STATUS = 'A' AND LD.CVE_DED = D.FOLIO),0) AS ABONOS,
                    D.PAGO_EN_LIQ, D.SALDO_ACTUAL, D.FECHA AS FECH, CVE_LIQ AS LIQ
                    FROM GCDEDUC_OPER D 
                    WHERE CVE_OPER = " & TCVE_OPER.Text & " AND D.STATUS = 'A' AND 
                    FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'
                    ORDER BY D.FOLIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg2.AddItem("" & vbTab & dr("FOLIO_DED") & vbTab & "(" & dr("DC_DED") & ")" & dr("DESCR_DED") & vbTab &
                               dr("LIQ") & vbTab & dr("FECH") & vbTab & dr("IMPORT_PRES") & vbTab & dr("ABONOS") * -1 & vbTab &
                               dr("IMPORT_PRES") - dr("ABONOS"))

                        r2 = t2.NewRow()
                        r2("FOLIO_DED") = dr("FOLIO_DED")
                        r2("DESCR_DED") = "(" & dr("DC_DED") & ")" & dr("DESCR_DED")
                        r2("LIQ") = dr("LIQ")
                        r2("FECHA2") = dr("FECH")
                        r2("IMPORT_PRES") = dr("IMPORT_PRES")
                        r2("ABONOS") = dr("ABONOS")
                        r2("SALDO") = dr("IMPORT_PRES") - dr("ABONOS")
                        t2.Rows.Add(r2)

                        r_ = Fg2.Rows.Count - 1
                        r = Fg2.Rows(Fg2.Rows.Count - 1)
                        r.IsNode = True
                        If Not IsNothing(r.Node) Then
                            r.Node.Level = 1
                        End If
                        NUM_PAR = 1
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_LIQ, DESCR, CVE_FOLIO, NUM_PAR, CVE_DED, FECHA, IMPORTE
                                    FROM GCLIQ_DEDUCCIONES D
                                    WHERE STATUS <> 'C' AND CVE_DED = " & dr("FOLIO_DED") & "
                                    ORDER BY D.CVE_DED, NUM_PAR"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        Fg2.AddItem("" & vbTab & NUM_PAR & vbTab & dr2("DESCR") & vbTab &
                                                    dr2("CVE_LIQ") & vbTab & dr2("FECHA") & vbTab & dr2("IMPORTE") * -1)

                                        r2 = t2.NewRow()
                                        r2("FOLIO_DED") = NUM_PAR
                                        r2("DESCR_DED") = dr2("DESCR")
                                        r2("LIQ") = dr2("CVE_LIQ")
                                        r2("FECHA2") = dr2("FECHA")
                                        r2("IMPORT_PRES") = dr2("IMPORTE")
                                        r2("ABONOS") = dr("ABONOS")
                                        r2("SALDO") = dr("IMPORT_PRES") - dr("ABONOS")

                                        t2.Rows.Add(r2)
                                        NUM_PAR += 1
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                        S1 += dr("IMPORT_PRES")
                        S2 += dr("ABONOS")
                        S3 += dr("IMPORT_PRES") - dr("ABONOS")
                    End While
                End Using
            End Using
            Fg2.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab & S2 * -1 & vbTab & S3)
            'FIN

            SALDO += S3
            LtSaldo.Text = Format(SALDO, "###,###,###,##0.00")

            r_ = Fg2.Rows.Count - 1
            r = Fg2.Rows(Fg2.Rows.Count - 1)
            r.IsNode = True
            If Not IsNothing(r.Node) Then
                r.Node.Level = 0
            End If

            For k = 1 To Fg2.Rows.Count - 1
                Try
                    Dim r11 As Row = Fg2.Rows(k)
                    If Not IsNothing(r11.Node) Then
                        r11.Node.Collapsed = True
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg2.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FrmEdoCuentaGenOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Edo. cuenta gen. oper")
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                BarDesplegar_Click(Nothing, Nothing)
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        PrinterMRT("ReportEdoCuentaGenOper")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            Dim C1XLBook1 As New C1XLBook()

            ' step 2: write content into some cells
            Dim sheet As XLSheet = C1XLBook1.Sheets(0)
            Dim i As Integer = 1
            Dim d1 As Date = F1.Value
            Dim d2 As Date = F2.Value

            sheet(0, 3).Value = RazonSocial
            sheet(2, 1).Value = "Rango de fechas"
            sheet(3, 0).Value = "Del"
            sheet(3, 1).Value = F1.Value.ToString.Substring(0, 10)
            sheet(3, 2).Value = "al"
            sheet(3, 3).Value = F2.Value.ToString.Substring(0, 10)

            sheet(2, 3).Value = "Operador"
            sheet(2, 4).Value = LOper.Text

            sheet(5, 0).Value = "Folio"
            sheet(5, 1).Value = "Descripcion"
            sheet(5, 2).Value = "Liquidacion"
            sheet(5, 3).Value = "Fecha"
            sheet(5, 4).Value = "Importe"
            sheet(5, 5).Value = "Abono"
            sheet(5, 6).Value = "Saldo"

            i = 6
            For k = 1 To Fg.Rows.Count - 1
                sheet(i, 0).Value = Fg(k, 1)
                sheet(i, 1).Value = Fg(k, 2)
                sheet(i, 2).Value = Fg(k, 3)
                sheet(i, 3).Value = Fg(k, 4)
                sheet(i, 4).Value = Fg(k, 5)
                sheet(i, 5).Value = Fg(k, 6)
                sheet(i, 6).Value = Fg(k, 7)
                i += 1
            Next

            i += 2
            sheet(i, 0).Value = "Folio"
            sheet(i, 1).Value = "Descripcion"
            sheet(i, 2).Value = "Liquidacion"
            sheet(i, 3).Value = "Fecha"
            sheet(i, 4).Value = "Importe"
            sheet(i, 5).Value = "Abono"
            sheet(i, 6).Value = "Saldo"

            i += 1
            For k = 1 To Fg2.Rows.Count - 1
                sheet(i, 0).Value = Fg2(k, 1)
                sheet(i, 1).Value = Fg2(k, 2)
                sheet(i, 2).Value = Fg2(k, 3)
                sheet(i, 3).Value = Fg2(k, 4)
                sheet(i, 4).Value = Fg2(k, 5)
                sheet(i, 5).Value = Fg2(k, 6)
                sheet(i, 6).Value = Fg2(k, 7)
                i += 1
            Next


            C1XLBook1.Save(RUTA_EXCEL & "\EdoCuenta opreador " & LOper.Text & ".xls")

            Process.Start(RUTA_EXCEL & "\EdoCuenta opreador " & LOper.Text & ".xls")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String

        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportEdoCuentaGenOper.mrt"
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
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class