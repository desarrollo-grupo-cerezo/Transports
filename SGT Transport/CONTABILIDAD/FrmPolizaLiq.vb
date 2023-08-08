Imports C1.Win.C1Themes
Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmPolizaLiq
    Private EmisorRfcCFD As String

    Private SerieCFD As String
    Private FolioCFD As String
    Private FechaEmision As String

    Private TotalCFD As Decimal
    Private SubtotalCFD As Decimal
    Private IVAcfd As Decimal
    Private RETcfd As Decimal

    Private VersionCFD As String
    Private MonedaCFD As String
    Private FormaPagoCFD As String
    Private UsoCFDICFD As String
    Private TipoComprobanteCFD As String

    Private UsoCFD As String
    Private CADENA As String = ""
    Private RUTA_MODELO As String = ""
    Private MOV As String = ""
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
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

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

            F1.Value = "01/05/2022"
            F2.Value = "31/05/2022"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40
            FgF.Rows(0).Height = 40

            FgF.DrawMode = DrawModeEnum.OwnerDraw
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            FgF.Styles.EmptyArea.BackColor = Color.White
            FgF.SetCellCheck(0, 1, CheckEnum.Unchecked)

            FgF.Cols(5).Width = 0

            Fg.Cols.Count = 10
            Fg.Rows.Count = 1
            Fg(0, 1) = "Cuenta contable"
            Dim c11 As Column = Fg.Cols(1)
            c11.DataType = GetType(String)

            Fg(0, 2) = ""
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Dim cs As CellStyle
            cs = Fg.Styles.Add("myStyle")
            cs.Font = New Font("Tahoma", 8, FontStyle.Regular)
            Fg.Cols(3).Style = cs

            Fg(0, 4) = "Cargo"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Abono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "XML"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Articulo"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Liquidacion"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Es deduccion"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)


            GET_RUTA_MODELO()

            Fg.Cols(6).Visible = False
            Fg.Cols(7).Visible = False
            Fg.Cols(8).Visible = False
            Fg.Cols(9).Visible = False

            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill

            FgF.Dock = DockStyle.Fill
            SplitM.BorderWidth = 1
            SplitterM2.BorderWidth = 1

            '----------------------------------
            FgF.Rows.Count = 1
            FgF.Cols.Count = 1
            FgF.Cols.Count = 10
            FgF.Rows(0).Height = 40

            FgF(0, 1) = "Seleccione"
            Dim cc11 As Column = FgF.Cols(1)
            cc11.DataType = GetType(Boolean)

            FgF(0, 2) = "Folio"
            Dim cc1 As Column = FgF.Cols(2)
            cc1.DataType = GetType(Int32)

            FgF(0, 3) = "Fecha"
            Dim cc2 As Column = FgF.Cols(3)
            cc2.DataType = GetType(DateTime)

            FgF(0, 4) = "Operador"
            Dim cc3 As Column = FgF.Cols(4)
            cc3.DataType = GetType(Int32)

            FgF(0, 5) = "Nombre"
            Dim cc4 As Column = FgF.Cols(5)
            cc4.DataType = GetType(String)

            FgF(0, 6) = "Unidad"
            Dim cc5 As Column = FgF.Cols(6)
            cc5.DataType = GetType(String)

            FgF(0, 7) = "Reseteo"
            Dim cc6 As Column = FgF.Cols(7)
            cc6.DataType = GetType(String)

            FgF(0, 8) = "Estatus liq."
            Dim cc7 As Column = FgF.Cols(8)
            cc7.DataType = GetType(String)

            FgF(0, 9) = "Importe"
            Dim cc8 As Column = FgF.Cols(9)
            cc8.DataType = GetType(Decimal)
            cc8.Format = "N2"

            FgF.Cols(2).Width = 45
            FgF.Cols(3).Width = 75
            FgF.Cols(4).Width = 0
            FgF.Cols(5).Width = 280
            FgF.Cols(6).Width = 55
            FgF.Cols(7).Width = 50
            FgF.Cols(8).Width = 70

            '---------------------------------------
            tPOLIZA.Text = "Poliza liquidaciones Fecha " & DateTime.Now.ToShortDateString
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaLiq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaLiq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Póliza liquidaciones")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub
    Private Sub FgF_CellChecked(sender As Object, e As RowColEventArgs) Handles FgF.CellChecked
        If e.Row = 0 Then
            ChangeState(FgF.GetCellCheck(e.Row, e.Col))
        End If
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = FgF.Rows.Fixed To FgF.Rows.Count - 1
            FgF.SetCellCheck(row, 1, state)
        Next
    End Sub
    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        Try
            FgF.Rows.Count = 1
            Fg.Rows.Count = 1
            FgF.SetCellCheck(0, 1, CheckEnum.Unchecked)

            tPOLIZA.Text = "Poliza liquidaciones Fecha " & DateTime.Now.ToShortDateString
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT L.CVE_LIQ, L.FECHA, L.CVE_OPER, O.NOMBRE, L.CVE_UNI, L.CVE_RES, ISNULL(S.DESCR,'EDICION') AS DESCR_ST_LIQ, IMPORTE,
                    ISNULL((SELECT COUNT(*) FROM GCLIQ_PARTIDAS WHERE CVE_LIQ = L.CVE_LIQ),0) AS NUM_VIAJES
                    FROM GCLIQUIDACIONES L
                    LEFT JOIN GCSTATUS_LIQUIDACION S ON S.CVE_LIQ = L.CVE_ST_LIQ
                    LEFT JOIN GCOPERADOR O ON O.CLAVE = L.CVE_OPER 
                    WHERE L.STATUS <> 'C' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'
                    ORDER BY CVE_LIQ DESC"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        FgF.AddItem("" & vbTab & "" & vbTab & dr("CVE_LIQ") & vbTab & dr("FECHA") & vbTab &
                                        dr("CVE_OPER") & vbTab & dr("NOMBRE") & vbTab & dr("CVE_UNI") & vbTab &
                                        dr("CVE_RES") & vbTab & dr("DESCR_ST_LIQ") & vbTab & dr("IMPORTE"))
                    End While
                End Using 'PAFA_DET
            End Using
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_LIQ As Long, SUMA As Decimal = 0, UNIDAD_SOLO_NUMERO As String, CTA3 As String, NETO_A_PAGAR As Decimal = 0
        Dim S1 As Decimal, S2 As Decimal, DES As String, DES2 As String, CTA1 As String = "", CTA2 As String = ""
        Dim CONCEPTO As String = ""

        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle
        Fg.Rows.Count = 1
        Fg.Redraw = False
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Red
        NewStyle2.ForeColor = Color.White

        Dim d1 As DateTime = F1.Value

        Try
            For k = 1 To FgF.Rows.Count - 1
                If FgF(k, 1) Then

                    CVE_LIQ = FgF(k, 2)
                    DES = ""
                    DES2 = ""
                    '-----------------------------SUELDOS
                    Try
                        SQL = "SELECT A.FECHA_CARGA, GV.SUELDO, ISNULL(U.CTA_CON_DIESEL,'') AS CTA_DIESEL, 
                            ISNULL(O.CTA_CONTA_PCIERR,'') AS CTA_PCIERR, ISNULL(NOMBRE,'') AS NOMBRE_OPER, 
                            GV.CVE_LIQ, L.CVE_RES, L.IMPORTE
                            FROM GCLIQ_PARTIDAS GV                            
                            LEFT JOIN GCASIGNACION_VIAJE A ON A.CVE_VIAJE = GV.CVE_VIAJE                                
                            LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = GV.CVE_UNI
                            LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = GV.CVE_LIQ
                            LEFT JOIN GCOPERADOR O ON O.CLAVE = L.CVE_OPER
                            WHERE GV.CVE_LIQ = " & CVE_LIQ & " ORDER BY GV.FECHAELAB"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    If Month(dr("FECHA_CARGA")) = d1.Month Then
                                        S1 += dr("SUELDO")
                                        CTA1 = dr("CTA_DIESEL")
                                        DES = dr("NOMBRE_OPER") & " - Reseteo:" & dr("CVE_RES") & " - Liquidación:" & dr("CVE_LIQ")
                                    Else
                                        S2 += dr("SUELDO")
                                        CTA2 = dr("CTA_PCIERR")
                                        DES2 = dr("NOMBRE_OPER") & " - Reseteo:" & dr("CVE_RES") & " - Liquidación:" & dr("CVE_LIQ")
                                        CONCEPTO = DES2
                                    End If
                                    NETO_A_PAGAR = dr("IMPORTE")
                                End While
                                If S1 > 0 Then Fg.AddItem("" & vbTab & CTA1 & vbTab & "0" & vbTab & DES & vbTab & S1)
                                If S2 > 0 Then Fg.AddItem("" & vbTab & CTA2 & vbTab & "0" & vbTab & DES2 & vbTab & S2)
                                SUMA += S1 + S2
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORA_LIQ("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    'GASTOS AUTORIZADOS
                    Try
                        Dim DESCUENTO_DIESEL As Decimal = 0, TOTAL As Decimal = 0, EXIS As Boolean = False, RowGA As Integer = 0
                        DES = "GASTOS AUTORIZADOS - INVE01"
                        SQL = "SELECT GC.CVE_LIQ, GC.CVE_DOC, GC.FECHA, GC.REFER, O.DESCR AS STR_OBS, GC.NUM_PAR, 
                            GC.CVE_ART, I.DESCR, GC.SUBTOTAL, GC.IVA, GC.TOTAL, GC.IEPS, 
                            ISNULL(I.CUENT_CONT, '') AS CTA_INVE, ISNULL(U.CTA_CON_DIESEL,'') AS CTA_DIESEL,
                            L.CVE_UNI, ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(CAMPLIB10,'') AS LIB10, 
                            ISNULL(CAMPLIB11,'') AS LIB11, ISNULL(CUENTA_CONTABLE,'') AS CTA_PROV
                            FROM GCLIQ_GASTOS_COMPROBADOS GC 
                            LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = GC.CVE_LIQ
                            LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = L.CVE_UNI
                            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = GC.CVE_ART
                            LEFT JOIN INVE_CLIB" & Empresa & " LB ON LB.CVE_PROD = I.CVE_ART
                            LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = GC.CVE_PROV
                            LEFT JOIN GCOBS O ON O.CVE_OBS = GC.CVE_OBS
                            WHERE GC.STATUS = 'A' AND GC.CVE_LIQ = " & CVE_LIQ
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    TOTAL = dr("TOTAL")

                                    If TOTAL > 0 Then

                                        Try
                                            DESCUENTO_DIESEL = 0
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "SELECT LD.CVE_LIQ, LD.CVE_FOLIO, LD.CVE_DED, LD.FECHA, LD.IMPORTE,
                                                    DO.IMPORTE_PRESTAMO, DO.IMPORTE_PAGADO, DO.SALDO, C.DESCR AS DED, 
                                                    DO.DESCR AS DES, DO.FOLIO AS FOLDED
                                                    FROM GCLIQ_DEDUCCIONES LD
                                                    LEFT JOIN GCDEDUC_OPER DO ON DO.FOLIO = LD.CVE_DED
                                                    LEFT JOIN GCDEDUCCIONES C ON C.CVE_DED = DO.CVE_DED 
                                                    WHERE LD.STATUS = 'A' AND LD.CVE_LIQ = " & CVE_LIQ & " AND 
                                                    LD.IMPORTE = " & dr("TOTAL")
                                                cmd2.CommandText = SQL
                                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                    While dr2.Read
                                                        DESCUENTO_DIESEL += dr2("IMPORTE")
                                                    End While
                                                End Using
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                        End Try

                                        TOTAL -= DESCUENTO_DIESEL

                                        BACKUPTXT("LIQ", TOTAL & "," & dr("IVA"))

                                        If TOTAL > 0.09 Then
                                            DES = dr("DESCR")
                                            If dr("LIB1") = "" Then
                                                Fg.AddItem("" & vbTab & dr("CTA_DIESEL") & dr("CTA_INVE") & vbTab & "0" & vbTab & DES & vbTab & TOTAL & vbTab & " " & vbTab & "" & vbTab & CVE_LIQ)
                                                SUMA += TOTAL
                                            Else
                                                If dr("LIB1") = "A" And dr("IVA") = 0 Then
                                                    Fg.AddItem("" & vbTab & dr("CTA_INVE") & vbTab & "1" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                    SUMA += TOTAL
                                                    CTA1 = dr("LIB10")
                                                    Fg.AddItem("" & vbTab & CTA1 & vbTab & "1" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                    SUMA += TOTAL
                                                    CTA1 = dr("LIB11")
                                                    Fg.AddItem("" & vbTab & CTA1 & vbTab & "1" & vbTab & DES & vbTab & "" & vbTab & TOTAL & vbTab & "" & vbTab & CVE_LIQ)
                                                Else
                                                    If dr("LIB1") = "B" And dr("IVA") = 0 Then
                                                        Fg.AddItem("" & vbTab & dr("CTA_PROV") & vbTab & "2" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                        SUMA += TOTAL
                                                        CTA1 = dr("LIB10")
                                                        Fg.AddItem("" & vbTab & CTA1 & vbTab & "2" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                        SUMA += TOTAL
                                                        CTA1 = dr("LIB11")
                                                        Fg.AddItem("" & vbTab & CTA1 & vbTab & "2" & vbTab & DES & vbTab & "" & vbTab & TOTAL & vbTab & "" & vbTab & CVE_LIQ)
                                                    Else
                                                        If dr("LIB1") = "C" Then
                                                            Fg.AddItem("" & vbTab & dr("CTA_INVE") & vbTab & "0" & vbTab & DES & vbTab & TOTAL & vbTab & " " & vbTab & "" & vbTab & CVE_LIQ)
                                                            SUMA += TOTAL
                                                        Else
                                                            If dr("LIB1") = "D" Then
                                                                If dr("CTA_DIESEL").ToString.Trim.Length >= 7 Then
                                                                    CTA1 = dr("CTA_DIESEL").ToString.Substring(0, 7) & dr("CTA_INVE")
                                                                Else
                                                                    CTA1 = dr("CTA_DIESEL") & dr("CTA_INVE")
                                                                End If
                                                                Fg.AddItem("" & vbTab & CTA1 & vbTab & "0" & vbTab & DES & vbTab & TOTAL & vbTab & " " & vbTab & "" & vbTab & CVE_LIQ)
                                                                SUMA += TOTAL
                                                            Else
                                                                If dr("LIB1") = "T" And dr("IVA") = 0 Then
                                                                    UNIDAD_SOLO_NUMERO = GetNumeric(dr("CVE_UNI"))
                                                                    CTA3 = dr("CTA_INVE").ToString.Replace("???", UNIDAD_SOLO_NUMERO)
                                                                    Fg.AddItem("" & vbTab & CTA3 & vbTab & "1" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                                    SUMA += TOTAL
                                                                    CTA1 = dr("LIB10")
                                                                    Fg.AddItem("" & vbTab & CTA1 & vbTab & "1" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                                    SUMA += TOTAL
                                                                    CTA1 = dr("LIB11")
                                                                    Fg.AddItem("" & vbTab & CTA1 & vbTab & "1" & vbTab & DES & vbTab & "" & vbTab & TOTAL & vbTab & "" & vbTab & CVE_LIQ)
                                                                Else
                                                                    If dr("IVA") > 0 And dr("CTA_PROV").ToString.Trim.Length > 0 Then
                                                                        Fg.AddItem("" & vbTab & dr("CTA_PROV") & vbTab & "3" & vbTab & DES & vbTab & TOTAL & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                                        SUMA += TOTAL
                                                                        Fg.AddItem("" & vbTab & "120-001-0000" & vbTab & "3" & vbTab & DES & vbTab & dr("IVA") & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                                        SUMA += dr("IVA")
                                                                        Fg.AddItem("" & vbTab & "121-001-0000" & vbTab & "3" & vbTab & DES & vbTab & "" & vbTab & dr("IVA") & vbTab & "" & vbTab & CVE_LIQ)
                                                                    Else
                                                                        If dr("IVA") > 0 Then
                                                                            Fg.AddItem("" & vbTab & "120-001-0000" & vbTab & "3" & vbTab & DES & vbTab & dr("IVA") & vbTab & "" & vbTab & "" & vbTab & CVE_LIQ)
                                                                            SUMA += dr("IVA")
                                                                            Fg.AddItem("" & vbTab & "121-001-0000" & vbTab & "3" & vbTab & DES & vbTab & "" & vbTab & dr("IVA") & vbTab & "" & vbTab & CVE_LIQ)
                                                                        Else
                                                                            Fg.AddItem("" & vbTab & "CASO NO CONSIDERADO:" & CVE_LIQ & vbTab & "4" & vbTab & dr("CVE_ART") & vbTab & "XXX" & vbTab & TOTAL & vbTab & dr("IVA") & vbTab & CVE_LIQ)
                                                                            Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle2)
                                                                            Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle2)
                                                                            Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle2)
                                                                            Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle2)
                                                                            Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle2)
                                                                        End If
                                                                    End If

                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else

                                        End If
                                    End If
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORA_LIQ("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    '****************************************
                    'GASTOS DE VIAJE O GASTOS DE TRAYECTO 
                    'GASTOS AUTORIZADOS
                    Try
                        Dim DESCUENTO_DIESEL As Decimal = 0, TOTAL As Decimal = 0

                        SQL = "SELECT C.DESCR, GV.CVE_VIAJE, GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, 
                            GV.FECHA, GV.CVE_NUM, GV.IMPORTE, GV.ST_GASTOS, ISNULL(C.CUEN_CONT,'') AS CTA1
                            FROM GCASIGNACION_VIAJE_GASTOS GV 
                            LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                            WHERE GV.CVE_LIQ = " & CVE_LIQ
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    If dr("IMPORTE") > 0 Then
                                        Fg.AddItem("" & vbTab & dr("CTA1") & vbTab & "0" & vbTab & "GASTOS TRAYECTO - Folio " & dr("FOLIO") & vbTab & "" & vbTab & dr("IMPORTE"))
                                    End If
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORA_LIQ("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If NETO_A_PAGAR > 0 Then
                        Fg.AddItem("" & vbTab & "109-001-0012" & vbTab & "0" & vbTab & CONCEPTO & vbTab & "" & vbTab & NETO_A_PAGAR & vbTab & "" & vbTab & "")
                    End If
                    'FIN GASTOS DE VIAJE O GASTOS DE TRAYECTO
                End If 'SELECCCION TRUE CHECK SI
            Next
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & SUMA & vbTab & SUMA)
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.AutoSizeCols()
        Fg.Redraw = True

        LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 2
        Fg.Select()

        MsgBox("Proceso terminado")
    End Sub
    Private Sub BarExcel2_Click(sender As Object, e As ClickEventArgs) Handles BarExcel2.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(FgF, "Poliza ventas flete documentos")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza ventas flete")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPOLIZA.KeyPress

        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub
    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click
        Dim s As String = "", nDoc As Integer = 0
        Dim CUENTA As String, CONCEPTO As String, IMPORTE1 As Decimal, IMPORTE2 As Decimal
        Dim CADENA1 As String, XML As String, CVE_LIQ As Long
        Dim NUM_PAR As Long = 12903, NUM_PARX As Long

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length = 0 Then
                    nDoc += 1
                End If
            Next
        Catch ex As Exception
        End Try

        If nDoc > 0 Then
            If MsgBox("Existen documentos sin CUENTA CONTABLE, Desea continuar?", vbYesNo) = vbNo Then
                Return
            End If
        End If

        If tPOLIZA.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre de la poliza")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor


        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA>"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""VersionCOI"" fieldtype=""i2""/>"
            s &= "<FIELD attrname=""TipoPoliz"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""DiaPoliz"" fieldtype=""string"" WIDTH=""2""/>"
            s &= "<FIELD attrname=""ConcepPoliz"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""UUID"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS>"
            s &= "<FIELD attrname=""Cuenta"" fieldtype=""string"" WIDTH=""21""/>"
            s &= "<FIELD attrname=""Depto"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""ConceptoPol"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""Monto"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""TipoCambio"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""DebeHaber"" fieldtype=""string"" WIDTH=""1""/>"
            s &= "<FIELD attrname=""ccostos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""proyectos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""Porcentaje"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""FRMPAGO"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""NUMCHEQUE"" fieldtype=""string"" WIDTH=""20""/>"
            s &= "<FIELD attrname=""MONTOBN"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""BANCO"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTAORIG"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""BENEF"" fieldtype=""string"" WIDTH=""300""/>"
            s &= "<FIELD attrname=""RFC"" fieldtype=""string"" WIDTH=""13""/>"
            s &= "<FIELD attrname=""BANCODEST"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTADEST"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""FECHACHEQUE"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""BANCOORIGEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""BANCODESTEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""IDUUID"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""IDFISCAL"" fieldtype=""string"" WIDTH=""40""/>"
            s &= "<FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested"">"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""NUMREG"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""UUIDTIMBRE"" fieldtype=""string"" WIDTH=""36""/>"
            s &= "<FIELD attrname=""MONTO"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""SERIE"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""FOLIO"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""RFCEMISOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""RFCRECEPTOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""FECHAUUID"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/>"
            s &= "</FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA><ROWDATA>"
            s &= "<ROW VersionCOI=""810"" TipoPoliz=""Tb"" DiaPoliz=""30"" ConcepPoliz=""" & tPOLIZA.Text & """><Partidas>"
            'BACKUPTXT("XML", s)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                CUENTA = Fg(k, 1)
                CONCEPTO = Fg(k, 3)
                IMPORTE1 = 0
                Try
                    IMPORTE1 = Fg(k, 4)
                Catch ex As Exception
                End Try
                IMPORTE2 = 0
                Try
                    IMPORTE2 = Fg(k, 5)
                Catch ex As Exception
                End Try

                If CUENTA.Trim.Length > 0 Then

                    If Fg(k, 6) IsNot Nothing Then
                        XML = Fg(k, 6)
                    Else
                        XML = ""
                    End If
                    CVE_LIQ = 0
                    If Fg(k, 7) IsNot Nothing Then
                        If IsNumeric(Fg(k, 7)) Then
                            CVE_LIQ = Fg(k, 7)
                        End If
                    End If
                    CADENA1 = ""
                    If XML.Trim.Length > 0 Then
                    Else
                        CADENA1 = ""
                        NUM_PARX = 0
                    End If

                    s &= "<ROWPartidas Cuenta=""" & CUENTA & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    If IMPORTE1 > 0 Then
                        s &= " Monto=""" & Math.Round(IMPORTE1, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    Else
                        s &= " Monto=""" & Math.Round(IMPORTE2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    End If

                    s &= " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" &
                        NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID>"
                    s &= "</ROWPartidas>"

                    If NUM_PARX <> 0 Then
                        NUM_PAR += 1
                    End If
                    'IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID></ROWPartidas>"
                End If
                Try
                    If CVE_LIQ > 0 Then
                        SQL = "UPDATE GCLIQUIDACIONES SET CONTABILIZADO = 'S' WHERE CVE_LIQ = " & CVE_LIQ
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            s &= "</Partidas></ROW></ROWDATA></DATAPACKET>"

            Var4 = "NO"

            BACKUPXML(RUTA_MODELO & "\" & tPOLIZA.Text.Replace("/", "-") & ".POL", s)

            If Var4 = "OK" Then
                MsgBox("La póliza modelo se grabo satisfactoriamente en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
                FrmConciValesCombus.DESPLEGAR3()
            Else
                MsgBox("No se logro crear la póliza modelo en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            End If
        Catch ex As Exception
            Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("655. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String, strMetodoPago As String
        Dim strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String
        Dim strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String
        Dim NoCertificadoSAT As String, UUID As String, UUIDR As String, FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String
        Dim Monto As String, FormaDePagoP As String, FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String
        Dim ImpPagado As String, ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String
        Dim concepto As XmlNodeList, Elemento As XmlNode, subnodo As XmlElement, IdDocumento As String
        Dim XML As String, xDoc As XmlDocument, xNodo As XmlNodeList, xAtt As XmlElement, Comprobante As XmlNode, Impuestos As XmlNode = Nothing
        Dim totalImpuestosTrasladados As Decimal, TotalImpuestosRetenidos As Decimal, vsTIT As Decimal, k As Integer
        'aqui
        If fFILE_XML.Trim.Length = 0 Then
            Return ""
        End If

        If Not File.Exists(fFILE_XML) Then
            Return ""
        End If

        strEmisorRfc = ""
        UUID = "" : strTipoComprobante = "" : strUsoCFDI = ""

        xDoc = New XmlDocument

        Try
            XML = fFILE_XML

            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try

                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")
                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")

                            SerieCFD = VarXml(xAtt, "Serie")
                            FolioCFD = VarXml(xAtt, "Folio")

                            FechaEmision = strFechaEmision
                            TotalCFD = strTotal
                            SubtotalCFD = strSubtotal

                            VersionCFD = strVersion
                            MonedaCFD = strMoneda
                            FormaPagoCFD = BUSCAR_FORMA_PAGO(strFormaPago)
                            VersionCFD = strVersion
                            UsoCFDICFD = strUsoCFDI
                            TipoComprobanteCFD = IIf(strTipoComprobante = "I", "Ingreso", "Egreso")
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo

                                strEmisorRfc = VarXml(xAtt, "rfc")
                                Try
                                    If strEmisorRfc.Trim.Length = 0 Then
                                        strEmisorRfc = VarXml(xAtt, "Rfc")
                                    End If
                                Catch ex As Exception
                                    Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                strEmisorNombre = VarXml(xAtt, "nombre")
                                Try
                                    If strEmisorNombre.Trim.Length = 0 Then
                                        strEmisorNombre = VarXml(xAtt, "Nombre")
                                    End If
                                Catch ex As Exception
                                    Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            EmisorRfcCFD = strEmisorRfc
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados").Value)
                    Catch ex As Exception
                        totalImpuestosTrasladados = 0
                    End Try
                    If totalImpuestosTrasladados = 0 Then
                        Try
                            Impuestos = Comprobante("cfdi:Impuestos")
                            totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados").Value)
                        Catch ex As Exception
                            totalImpuestosTrasladados = 0
                        End Try
                    End If
                    Try
                        If totalImpuestosTrasladados = 0 Then
                            vsTIT = 0
                            k = 1
                            For Each vRegIT As XmlElement In Impuestos.ChildNodes
                                If vRegIT.Name = "cfdi:Traslados" Then
                                    vsTIT += CDec(vRegIT.FirstChild.Attributes("importe").Value)
                                End If
                            Next
                        Else
                            vsTIT = totalImpuestosTrasladados
                        End If
                    Catch ex As Exception
                        'Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    IVAcfd = totalImpuestosTrasladados


                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        TotalImpuestosRetenidos = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos").Value)

                    Catch ex As Exception
                        TotalImpuestosRetenidos = 0
                    End Try

                    RETcfd = TotalImpuestosRetenidos


                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                                UsoCFD = strUsoCFDI
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then
            End If
            Return UUID
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub FgF_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgF.OwnerDrawCell
        If e.Row >= FgF.Rows.Fixed And e.Col = FgF.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - FgF.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
End Class
