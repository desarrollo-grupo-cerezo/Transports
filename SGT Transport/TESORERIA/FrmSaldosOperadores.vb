Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Public Class FrmSaldosOperadores
    Private CADENA As String
    Private CADENA_OPER As String
    Private CADENA_D As String
    Private CADENA_LD As String
    Private CADENA_GV As String

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50

            SplitM.SplitterWidth = 1
            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill

            Fg.Tree.Column = 1
            Fg.Tree.Show(1)
            Fg.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
            Fg.Tree.LineColor = Color.DarkBlue
            Fg.Cols(1).AllowEditing = True
            Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.WordWrap = False
            Fg.Cols(4).Width = 350
            Fg.Cols(5).Width = 110
            Fg.Cols(6).Width = 110
            Fg.Cols(7).Width = 110
            Fg.Cols(8).Width = 0
            ' Create style used to show negative values.
            Fg.Styles.Add("Red").ForeColor = Color.Red
            ' Create style used to show values >= 1000.
            Fg.Styles.Add("Yellow").ForeColor = Color.RosyBrown
            Fg.Styles.Add("Blue").ForeColor = Color.Blue
            Fg.Styles.Add("Magenta").ForeColor = Color.Magenta
            Fg.Styles.Add("LightGreen").BackColor = Color.LightGreen
            Fg.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw


            Fg2.Rows.Count = 1
            Fg2.Rows(0).Height = 50
            Fg2.Tree.Column = 1
            Fg2.Tree.Show(1)
            Fg2.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
            Fg2.Tree.LineColor = Color.DarkBlue
            Fg2.Cols(1).AllowEditing = True
            Fg2.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg2.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg2.Styles.Normal.WordWrap = False
            Fg2.Cols(4).Width = 350
            Fg2.Cols(3).Width = Fg.Cols(3).Width
            Fg2.Cols(2).Width = Fg.Cols(2).Width

            Fg2.Cols(8).Width = 0
            ' Create style used to show negative values.
            Fg2.Styles.Add("Red").ForeColor = Color.Red
            ' Create style used to show values >= 1000.
            Fg2.Styles.Add("Yellow").ForeColor = Color.RosyBrown
            Fg2.Styles.Add("Blue").ForeColor = Color.Blue
            Fg2.Styles.Add("Magenta").ForeColor = Color.Magenta
            Fg2.Styles.Add("LightGreen").BackColor = Color.LightGreen
            Fg2.DrawMode = DrawModeEnum.OwnerDraw

            CADENA = "AND ISNULL(CVE_LIQ,0) = 0"
            CADENA_D = ""
            CADENA_LD = ""
            CADENA_GV = ""
            CADENA_OPER = ""
            Var2 = "1"

            DESPLEGAR()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSaldosOperadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub DESPLEGAR()
        Dim r As Row, Sigue As Boolean, S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, r_ As Integer, SiDatos As Boolean
        Dim ST1 As Decimal = 0, ST2 As Decimal = 0, ST3 As Decimal = 0

        Fg.Rows.Count = 1
        Fg2.Rows.Count = 1
        Fg.Redraw = False
        Fg2.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, NOMBRE FROM GCOPERADOR " & CADENA_OPER & " ORDER BY CLAVE"
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    While dr2.Read
                        Sigue = True
                        SiDatos = False
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            'CADENA_F1 = "AND LD.FECHA >= '" & Var3 & "' AND LD.FECHA <= '" & Var4 & "'"
                            'CADENA_F2 = "AND GV.FECHA >= '" & Var3 & "' AND GV.FECHA <= '" & Var4 & "'"
                            'SOLO LOS LIQUIDADOS
                            'CADENA = "AND ISNULL(CVE_LIQ,0) = 0"
                            'If ChTodos.Checked Then
                            '   Var2 = "0"  TODOS
                            'Else
                            '   Var2 = "1"  SOLO LIQUIDADOS
                            'End If
                            'If Var2 = "1" Then
                            '   SOLO LOS LIQUIDADOS
                            '   CADENA = "AND ISNULL(CVE_LIQ,0) = 0"
                            'Else
                            '   TODOS
                            '   CADENA = ""
                            'End If
                            If Var2 = "1" Then
                                'LIQUIDADOS
                                SQL = "SELECT D.FOLIO AS FOLIO_DED, D.CVE_DED AS DC_DED, CASE WHEN D.STATUS = 'A' THEN 'PENDIENTE' ELSE 'PAGADO' END AS ST_DED, 
                                    D.DESCR AS DESCR_DED, D.IMPORTE_PRESTAMO AS IMPORT_PRES, D.IMPORTE_PAGADO, D.SALDO, 
                                    ISNULL((SELECT SUM(LD.IMPORTE) FROM GCDEDUC_OPER DD LEFT JOIN GCLIQ_DEDUCCIONES LD ON LD.CVE_DED = DD.FOLIO    
                                    LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LD.CVE_LIQ WHERE L.CVE_ST_LIQ = 2 AND LD.STATUS = 'A' AND LD.CVE_DED = D.FOLIO),0) AS ABONOS,
                                    D.PAGO_EN_LIQ, D.SALDO_ACTUAL, D.FECHA AS FECH, CVE_LIQ AS LIQ
                                    FROM GCDEDUC_OPER D 
                                    WHERE CVE_OPER = " & dr2("CLAVE") & " AND D.STATUS = 'A' " & CADENA & CADENA_D
                            Else
                                SQL = "SELECT MAX(LD.CVE_LIQ) AS LIQ, MAX(LD.CVE_DED) AS FOLIO_DED, MAX(LD.FECHA) AS FECH, MAX(D.CVE_DED) AS DC_DED, 
                                    MAX(D.DESCR) AS DESCR_DED, MAX(D.IMPORTE_PRESTAMO) AS IMPORT_PRES, SUM(IMPORTE) AS ABONOS, 
                                    CASE WHEN MAX(D.STATUS) = 'A' THEN 'PENDIENTE' ELSE 'PAGADO' END AS ST_DED
                                    FROM GCLIQ_DEDUCCIONES LD
                                    LEFT JOIN GCDEDUC_OPER D ON D.FOLIO = LD.CVE_DED 
                                    WHERE LD.STATUS = 'A' AND D.STATUS = 'A' AND D.CVE_OPER = " & dr2("CLAVE") & " " & CADENA & CADENA_LD & "
                                    GROUP BY D.CVE_OPER"
                            End If

                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    If Sigue Then
                                        SiDatos = True
                                        'dr2("CLAVE")
                                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                    dr2("NOMBRE") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1")
                                        r_ = Fg.Rows.Count - 1
                                        r = Fg.Rows(Fg.Rows.Count - 1)
                                        r.IsNode = True
                                        If Not IsNothing(r.Node) Then
                                            r.Node.Level = 1
                                        End If

                                        Sigue = False
                                    End If

                                    Fg.AddItem("" & vbTab & dr("LIQ") & vbTab & dr("FOLIO_DED") & vbTab & dr("FECH") & vbTab & "(" & dr("DC_DED") & ")" &
                                           dr("DESCR_DED") & vbTab & dr("IMPORT_PRES") & vbTab & dr("ABONOS") & vbTab &
                                           dr("IMPORT_PRES") - dr("ABONOS") & vbTab & "")
                                    S1 += dr("IMPORT_PRES")
                                    S2 += dr("ABONOS")
                                    S3 += dr("IMPORT_PRES") - dr("ABONOS")

                                    ST1 += dr("IMPORT_PRES")
                                    ST2 += dr("ABONOS")
                                    ST3 += dr("IMPORT_PRES") - dr("ABONOS")

                                End While
                                If SiDatos Then
                                    Fg(r_, 5) = S1
                                    Fg(r_, 6) = S2
                                    Fg(r_, 7) = S3
                                    S1 = 0 : S2 = 0 : S3 = 0
                                End If
                            End Using
                        End Using
                    End While
                End Using
            End Using
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & ST1 & vbTab & ST2 & vbTab & ST3)

            r_ = Fg.Rows.Count - 1
            r = Fg.Rows(Fg.Rows.Count - 1)
            r.IsNode = True
            If Not IsNothing(r.Node) Then
                r.Node.Level = 0
            End If

            If CADENA_OPER.Trim.Length = 0 Then
                For k = 1 To Fg.Rows.Count - 1
                    Try
                        Dim r1 As Row = Fg.Rows(k)
                        r1.Node.Collapsed = True
                    Catch ex As Exception
                    End Try
                Next
            End If
            'Fg.Subtotal(AggregateEnum.Clear)
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 5, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 7, "Grand Total")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, NOMBRE FROM GCOPERADOR " & CADENA_OPER & " ORDER BY CLAVE"
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    While dr2.Read
                        Sigue = True
                        SiDatos = False

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT GV.FOLIO, GV.IMPORTE, ISNULL(C.DESCR,'') AS DESCR_GASTOS, GV.CVE_VIAJE, 
                                GV.CVE_LIQ, GV.FECHA, GV.CVE_NUM
                                FROM GCASIGNACION_VIAJE_GASTOS GV
                                LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                                WHERE ISNULL(GV.STATUS,'A') = 'A' AND GV.CVE_OPER = " & dr2("CLAVE") & " " &
                                CADENA & CADENA_GV & "
                                ORDER BY GV.FOLIO"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    If Sigue Then
                                        SiDatos = True
                                        'dr2("CLAVE")
                                        Fg2.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                    dr2("NOMBRE") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1")
                                        r_ = Fg2.Rows.Count - 1
                                        r = Fg2.Rows(Fg2.Rows.Count - 1)
                                        r.IsNode = True
                                        If Not IsNothing(r.Node) Then
                                            r.Node.Level = 1
                                        End If

                                        Sigue = False
                                    End If
                                    Fg2.AddItem("" & vbTab & dr("CVE_LIQ") & vbTab & dr("FECHA") & vbTab & dr("CVE_NUM") & vbTab &
                                                dr("DESCR_GASTOS") & vbTab & dr("FOLIO") & vbTab & dr("CVE_VIAJE") & vbTab & dr("IMPORTE"))
                                    S1 += dr("IMPORTE")

                                    ST1 += dr("IMPORTE")
                                End While
                                If SiDatos Then
                                    Fg2(r_, 7) = S1
                                    S1 = 0
                                End If
                            End Using
                        End Using
                    End While
                End Using
            End Using
            Fg2.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & ST1)
            r = Fg2.Rows(Fg2.Rows.Count - 1)
            r.IsNode = True
            If Not IsNothing(r.Node) Then
                r.Node.Level = 0
            End If

            If CADENA_OPER.Trim.Length = 0 Then
                For k = 1 To Fg2.Rows.Count - 1
                    Try
                        Dim r1 As Row = Fg2.Rows(k)
                        r1.Node.Collapsed = True
                    Catch ex As Exception
                    End Try
                Next
            End If

        Catch SQLex As SqlException
            Dim SSS As SqlError, Sqlcadena As String = ""
            For Each SSS In SQLex.Errors
                Sqlcadena += SSS.Message & vbNewLine
            Next
            BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
        Catch ex As Exception
            Bitacora("750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("750. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        CADENA_OPER = ""
        Fg.Redraw = True
        Fg2.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BarFiltrar_Click(sender As Object, e As ClickEventArgs) Handles BarFiltrar.Click

        Var3 = ""
        Var4 = ""
        Var5 = ""
        Var6 = ""
        FrmSaldosOperFiltro.ShowDialog()
        If Var3.Trim.Length > 0 Then
            'Var3 = FSQL(F1.Value)
            'Var4 = FSQL(F2.Value)
            'Var5 = TCVE_OPER.Text
            'If ChIgnorarFechas.Checked Then
            '   Var6 = "Ignorar Fechas"
            'Else
            '   Var6 = "Con Fechas"
            'End If
            'If ChTodos.Checked Then
            '   Var2 = "0"
            'Else
            '   Var2 = "1"
            'End If

            If Var5.Trim.Length > 0 Then
                CADENA_OPER = "WHERE CLAVE = " & Var5
            Else
                CADENA_OPER = ""
            End If
            If Var6 = "Ignorar Fechas" Then
                CADENA_D = ""
                CADENA_LD = ""
                CADENA_GV = ""
            Else
                CADENA_D = "AND D.FECHA >= '" & Var3 & "' AND D.FECHA <= '" & Var4 & "'"
                CADENA_LD = "AND LD.FECHA >= '" & Var3 & "' AND LD.FECHA <= '" & Var4 & "'"
                CADENA_GV = "AND GV.FECHA >= '" & Var3 & "' AND GV.FECHA <= '" & Var4 & "'"

            End If

            If Var2 = "1" Then
                'SOLO LOS LIQUIDADOS
                CADENA = "AND ISNULL(CVE_LIQ,0) = 0"
            Else
                'TODOS
                CADENA = ""
            End If
            DESPLEGAR()
        End If
    End Sub

    Private Sub FrmSaldosOperadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Saldos operadores")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Saldos operadores")
        EXPORTAR_EXCEL_TRANSPORT(Fg2, "Folios dinero")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("CS2")
        cs2.BackColor = Color.Red

        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1

            e.Text = rowNumber.ToString()
            Select Case Fg(e.Row, 8)
                Case "1"
                    Fg.SetCellStyle(e.Row, 4, cs1)
            End Select
        End If
    End Sub

    Private Sub Fg2_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg2.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("CS2")
        cs2.BackColor = Color.Red

        If e.Row >= Fg2.Rows.Fixed And e.Col = Fg2.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg2.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Select Case Fg2(e.Row, 8)
                Case "1"
                    Fg2.SetCellStyle(e.Row, 4, cs1)
            End Select
        End If
    End Sub

    Private Sub BarFiltrarXOper_Click(sender As Object, e As ClickEventArgs) Handles BarFiltrarXOper.Click
        Var4 = ""

        FrmSaldosOperFiltraOper.ShowDialog()
        If Var4.Trim.Length > 0 Then
            CADENA = " AND ISNULL(CVE_LIQ,0) = 0"

            CADENA_OPER = "WHERE CLAVE = " & Var4
            Var2 = "1"
            DESPLEGAR()
        End If
    End Sub
End Class
