Imports System.IO
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command

Public Class FrmLlantas
    Private ReadOnly BindingSource1 As New BindingSource
    Private CADENA As String
    Private CLAVE_LLANTA As String
    Private R11 As Decimal, R12 As Decimal
    Private R21 As Decimal, R22 As Decimal
    Private R31 As Decimal, R32 As Decimal
    Private NUM_TOP As String = " TOP 2000"

    Private ReadOnly list As New List(Of MyItem)()
    Private ReadOnly worker As New BackgroundWorker()
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
            Fg2.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg3.Styles.EmptyArea.BackColor = ColoFondoFG
            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)
        Catch ex As Exception
        End Try

        Try
            Dim j As Integer = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLLANTAS_RANGOS_DESGASTE ORDER BY CVE_DES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        Select Case j
                            Case 1
                                R11 = dr("DE")
                                R12 = dr("HASTA")
                            Case 2
                                R21 = dr("DE")
                                R22 = dr("HASTA")
                            Case 3
                                R31 = dr("DE")
                                R32 = dr("HASTA")
                        End Select
                        j += 1
                    Loop
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

            Tab1.Dock = DockStyle.Fill
            Tab1.ItemSize = New Size(120, 35)

            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill
            Fg3.Dock = DockStyle.Fill
            Fg.Rows.Count = 1
            Fg.Cols.Count = 1

            Fg.Rows(0).Height = 40

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg2.DrawMode = DrawModeEnum.OwnerDraw
            Fg2.Styles.Fixed.WordWrap = True

            Fg.Styles.Fixed.WordWrap = True

            CLAVE_LLANTA = ""
            CADENA = " WHERE LL.STATUS <> 'B'"
            DESPLEGAR2()

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        Select Case Tab1.SelectedIndex
            Case 0
                DESPLEGAR2()
            Case 1
                DESPLEGAR_INSPECCION()
        End Select
    End Sub

    Sub DESPLEGAR()
        Try
            Me.Cursor = Cursors.WaitCursor
            Fg.Cursor = Cursors.WaitCursor
            CADENA = " WHERE LL.STATUS <> 'B'"
            Lt1.Text = Now.ToLongTimeString


        Catch ex As Exception
            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Function LoadDataTable(Fsql As String) As DataTable
        ' NO UI/Control references allowed
        Dim dt = New DataTable

        Using cmd As SqlCommand = cnSAE.CreateCommand
            cmd.CommandText = Fsql
            dt.Load(cmd.ExecuteReader())
        End Using

        Return dt
    End Function

    Sub DESPLEGAR2()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            BarraMenu.Enabled = False
            Fg.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.BackColor = Color.Thistle
            NewStyle1.ForeColor = Color.Black

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT " & NUM_TOP & " CAST(LL.CVE_LLANTA As INT) As CVE_LLA, ISNULL(LL.STATUS_LLANTA,'2') + '. ' + ISNULL(SL.DESCR,'PENDIENTE POR ASIGNAR') AS ST_LLA, "

            SQL += "LL.UNIDAD, LL.POSICION, LL.NUM_ECONOMICO, CASE WHEN ISNULL(TIPO_NUEVA_RENO,0) = 0 or ISNULL(TIPO_NUEVA_RENO,0) = 1 THEN 'Original' ELSE 'Renovada' END AS TIPO_NEW_REN, 
                 TU.DESCR, LL.FECHA_MON, M.DESCR AS DESC_MARCA, 
                 D.DESCR AS DESC_MODELO, 
                 T.DESCR as 'Tipo llanta', LL.COSTO_LLANTA_MN, ISNULL(LL.STATUS_LLANTA,'2') AS STALLA, 
                 (SELECT TOP 1 FECHAELAB FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA ORDER BY FECHAELAB DESC) AS 'Fecha ult. act.',
                 PROFUNDIDAD_ACTUAL AS 'Profundidad actual',
                 (SELECT DATEDIFF(DAY, MIN(FECHAELAB), MAX(FECHAELAB)) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Dias', 
                 (SELECT MAX(PROFUNDIDAD) - MIN(PROFUNDIDAD) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Desgaste (mm)', 
                 KMS_MONTAR AS 'Kms. al montar', KMS_DESMONTAR AS 'Kms. al desmontar', LL.KMS_ACTUAL AS 'Kms. Actual', LL.NO_RENOVADOS AS 'Num. renovados', DOT as 'Dot',
                 MR.DESCR AS 'Marca renovado', PR.DESCR as 'Proveedor renovado', ISNULL(LL.CVE_PILA,'') AS 'Pila desecho'
                 FROM GCLLANTAS LL 
                 LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = LL.UNIDAD   
                 LEFT JOIN GCTIPO_UNIDAD TU ON TU.CVE_UNI = U.CVE_TIPO_UNI   
                 Left Join GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                 LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA   
                 LEFT JOIN GCLLANTA_MODELO D ON D.CVE_MODELO = LL.MODELO   
                 Left Join GCLLANTA_TIPO T ON T.CVE_TIPO = LL.TIPO_LLANTA
                 LEFT JOIN GCMARCAS_RENOVADO MR ON MR.CVE_MARCA = LL.CVE_MARCA
                 LEFT JOIN GCPROVRENOVADO PR ON PR.CVE_PRE = LL.CVE_PRE " &
                 CADENA & "
                 ORDER by TRY_PARSE(LL.NUM_ECONOMICO AS INT) DESC"

            ' PROFUNDIDAD_ACTUAL  15
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 280

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            TITULOS()

            Lt1.Text = "llantas " & Fg.Rows.Count - 1
            Try
                Dim z As Long = 0
                If CLAVE_LLANTA.Trim.Length > 0 Then
                    Fg.Row = Fg.RowSel
                End If
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Cols(0).Width = 50
            Fg.Cols(13).Visible = False
            If PASS_GRUPOCE = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & ". " & Fg(0, k)
                Next
            End If

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")

            '********************************
            Dim da2 As New SqlDataAdapter
            Dim dt2 As New DataTable

            SQL = "SELECT " & NUM_TOP & " CAST(LL.CVE_LLANTA As INT) As CVE_LLA, ISNULL(LL.STATUS_LLANTA,'2') + '. ' + ISNULL(SL.DESCR,'PENDIENTE POR ASIGNAR') AS ST_LLA, "

            SQL += "LL.UNIDAD, LL.POSICION, LL.NUM_ECONOMICO, CASE WHEN ISNULL(TIPO_NUEVA_RENO,0) = 0 or ISNULL(TIPO_NUEVA_RENO,0) = 1 THEN 'Original' ELSE 'Renovada' END AS TIPO_NEW_REN, 
                 TU.DESCR, LL.FECHA_MON, M.DESCR AS DESC_MARCA, 
                 D.DESCR AS DESC_MODELO, 
                 T.DESCR as 'Tipo llanta', LL.COSTO_LLANTA_MN, ISNULL(LL.STATUS_LLANTA,'2') AS STALLA, 
                 (SELECT TOP 1 FECHAELAB FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA ORDER BY FECHAELAB DESC) AS 'Fecha ult. act.',
                 PROFUNDIDAD_ACTUAL AS 'Profundidad actual',
                 (SELECT DATEDIFF(DAY, MIN(FECHAELAB), MAX(FECHAELAB)) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Dias', 
                 (SELECT MAX(PROFUNDIDAD) - MIN(PROFUNDIDAD) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Desgaste (mm)', 
                 KMS_MONTAR AS 'Kms. al montar', KMS_DESMONTAR AS 'Kms. al desmontar', LL.KMS_ACTUAL AS 'Kms. Actual', LL.NO_RENOVADOS AS 'Num. renovados',
                 ISNULL(LL.CVE_PILA,'') AS 'Pila desecho'
                 FROM GCLLANTAS LL 
                 LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = LL.UNIDAD   
                 LEFT JOIN GCTIPO_UNIDAD TU ON TU.CVE_UNI = U.CVE_TIPO_UNI   
                 Left Join GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                 LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA   
                 LEFT JOIN GCLLANTA_MODELO D ON D.CVE_MODELO = LL.MODELO   
                 Left Join GCLLANTA_TIPO T ON T.CVE_TIPO = LL.TIPO_LLANTA
                 WHERE LL.STATUS = 'B'
                 ORDER by TRY_PARSE(LL.NUM_ECONOMICO AS INT) DESC"
            da2 = New SqlDataAdapter(SQL, cnSAE)
            dt2 = New DataTable ' crear un DataTable
            da2.SelectCommand.CommandTimeout = 280

            da2.Fill(dt2)
            BindingSource1.DataSource = dt2
            Fg3.DataSource = BindingSource1.DataSource

            TITULOS2()

            Fg3.Cols(0).Width = 50
            Fg3.Cols(13).Visible = False
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        BarraMenu.Enabled = True

    End Sub
    Sub DESPLEGAR_INSPECCION()

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            BarraMenu.Enabled = False
            Fg.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            'L.MARCA, L.MODELO, I.TIPO_LLANTA, 
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT MAX(CVE_INS) AS CVEINS, MAX(UNIDAD) AS UNI, MAX(FECHA) AS FEC, CASE 
                WHEN MAX(STATUS) = 'E' THEN 'EDICION' 
                WHEN MAX(STATUS) = 'F' THEN 'FINALIZADO' 
                WHEN MAX(STATUS) = 'C' THEN 'CANCELADO' ELSE '' END AS 'Estatus'
                FROM GCINSPEC_LLANTAS I 
                GROUP BY CVE_INS
                ORDER BY CVE_INS DESC"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg2.DataSource = BindingSource1.DataSource

            TITULOS_INSC()

            Try
                If Not IsNothing(C1FlexGridSearchPanel1.ActiveControl) Then
                    C1FlexGridSearchPanel1.ActiveControl.Text = ""
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        BarraMenu.Enabled = True
    End Sub
    Sub TITULOS_INSC()

        Fg2.Rows(0).Height = 40

        Fg2(0, 1) = "Clave"
        Dim cc1 As Column = Fg2.Cols(1)
        cc1.DataType = GetType(String)

        Fg2(0, 2) = "Unidad"
        Dim cc2 As Column = Fg2.Cols(2)
        cc2.DataType = GetType(String)

        Fg2(0, 3) = "Estatus"
        Dim c3 As Column = Fg2.Cols(3)
        c3.DataType = GetType(String)

        Fg2(0, 3) = "Fecha"
        Dim c4 As Column = Fg2.Cols(4)
        c4.DataType = GetType(DateTime)

        Fg2.Cols(1).Width = 120
        Fg2.Cols(2).Width = 120
        Fg2.Cols(3).Width = 120
        Fg2.Cols(4).Width = 120

    End Sub

    Sub TITULOS()

        Fg(0, 1) = "Clave llanta"
        Dim c1 As Column = Fg.Cols(1)
        c1.DataType = GetType(Long)

        Fg(0, 2) = "Estatus llanta"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Unidad"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Posición"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)
        Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 5) = "Num. económico"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)
        Fg.Cols(5).TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 6) = "Nueva/renovada"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(String)
        Fg.Cols(6).TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 7) = "Tipo unidad"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(String)

        Fg(0, 8) = "Fecha mon."
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(DateTime)

        Fg(0, 9) = "Marca"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(String)

        Fg(0, 10) = "Modelo"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(String)

        Fg(0, 11) = "Tipo llanta"
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(String)

        Fg(0, 12) = "Costo llanta MN"
        Dim c12 As Column = Fg.Cols(12)
        c12.DataType = GetType(Decimal)
        Fg.Cols(12).Format = "###,###,##0.00"

        Fg(0, 13) = "Estatus llanta"
        Dim c13 As Column = Fg.Cols(13)
        c13.DataType = GetType(Decimal)
        Fg.Cols(13).Format = "###,###,##0.00"

        Fg(0, 14) = "Fecha"
        Dim c14 As Column = Fg.Cols(14)
        c14.DataType = GetType(Date)

        Fg(0, 15) = "Profundidad actual"
        Dim c15 As Column = Fg.Cols(15)
        c15.DataType = GetType(Decimal)
        Fg.Cols(15).Format = "###,###,##0.00"

        Fg(0, 16) = "Dias desgaste"
        Dim c16 As Column = Fg.Cols(16)
        c16.DataType = GetType(Integer)

        Fg(0, 17) = "Desgaste (mm)"
        Dim c17 As Column = Fg.Cols(17)
        c17.DataType = GetType(Decimal)
        Fg.Cols(17).Format = "###,###,##0.00"

        Fg(0, 18) = "Kms. al montar"
        Dim c18 As Column = Fg.Cols(18)
        c18.DataType = GetType(Decimal)
        Fg.Cols(18).Format = "###,###,##0.00"

        Fg(0, 19) = "Kms. al desmontar"
        Dim c19 As Column = Fg.Cols(19)
        c19.DataType = GetType(Decimal)
        Fg.Cols(19).Format = "###,###,##0.00"

        Fg(0, 20) = "Kms. actual"
        Dim c20 As Column = Fg.Cols(20)
        c20.DataType = GetType(Decimal)
        Fg.Cols(20).Format = "###,###,##0.00"

        Fg(0, 21) = "No. renovados"
        Dim c21 As Column = Fg.Cols(21)
        c21.DataType = GetType(Decimal)
        Fg.Cols(21).Format = "###,###,##0.00"

        Fg(0, 22) = "DOT"
        Dim c22 As Column = Fg.Cols(22)
        c22.DataType = GetType(String)

        'KMS_MONTAR AS 'Kms. al montar', KMS_DESMONTAR AS 'Kms. al desmontar', LL.KMS_ACTUAL AS 'Kms. Actual', LL.NO_RENOVADOS AS 'Num. renovados', DOT as 'Dot'

        Fg.Cols(16).Visible = False
        Fg.Cols(17).Visible = False

        For k = 1 To Fg.Cols.Count - 1
            Fg.Cols(k).StarWidth = "*"
        Next


    End Sub

    Sub TITULOS2()

        Fg3(0, 1) = "Clave llanta"
        Dim c1 As Column = Fg3.Cols(1)
        c1.DataType = GetType(Long)

        Fg3(0, 2) = "Estatus llanta"
        Dim c2 As Column = Fg3.Cols(2)
        c2.DataType = GetType(String)

        Fg3(0, 3) = "Unidad"
        Dim c3 As Column = Fg3.Cols(3)
        c3.DataType = GetType(String)

        Fg3(0, 4) = "Posición"
        Dim c4 As Column = Fg3.Cols(4)
        c4.DataType = GetType(String)
        Fg3.Cols(4).TextAlign = TextAlignEnum.CenterCenter

        Fg3(0, 5) = "Num. económico"
        Dim c5 As Column = Fg3.Cols(5)
        c5.DataType = GetType(String)
        Fg3.Cols(5).TextAlign = TextAlignEnum.CenterCenter

        Fg3(0, 6) = "Nueva/renovada"
        Dim c6 As Column = Fg3.Cols(6)
        c6.DataType = GetType(String)
        Fg3.Cols(6).TextAlign = TextAlignEnum.CenterCenter

        Fg3(0, 7) = "Tipo unidad"
        Dim c7 As Column = Fg3.Cols(7)
        c7.DataType = GetType(String)

        Fg3(0, 8) = "Fecha mon."
        Dim c8 As Column = Fg3.Cols(8)
        c8.DataType = GetType(DateTime)

        Fg3(0, 9) = "Marca"
        Dim c9 As Column = Fg3.Cols(9)
        c9.DataType = GetType(String)

        Fg3(0, 10) = "Modelo"
        Dim c10 As Column = Fg3.Cols(10)
        c10.DataType = GetType(String)

        Fg3(0, 11) = "Tipo llanta"
        Dim c11 As Column = Fg3.Cols(11)
        c11.DataType = GetType(String)

        Fg3(0, 12) = "Costo llanta MN"
        Dim c12 As Column = Fg3.Cols(12)
        c12.DataType = GetType(Decimal)
        Fg3.Cols(12).Format = "###,###,##0.00"

        Fg3(0, 13) = "Estatus llanta"
        Dim c13 As Column = Fg3.Cols(13)
        c13.DataType = GetType(Decimal)
        Fg3.Cols(13).Format = "###,###,##0.00"

        Fg3(0, 14) = "Fecha"
        Dim c14 As Column = Fg3.Cols(14)
        c14.DataType = GetType(Date)

        Fg3(0, 15) = "Profundidad actual"
        Dim c15 As Column = Fg3.Cols(15)
        c15.DataType = GetType(Decimal)
        Fg3.Cols(15).Format = "###,###,##0.00"

        Fg3(0, 16) = "Dias desgaste"
        Dim c16 As Column = Fg3.Cols(16)
        c16.DataType = GetType(Integer)

        Fg3(0, 17) = "Desgaste (mm)"
        Dim c17 As Column = Fg3.Cols(17)
        c17.DataType = GetType(Decimal)
        Fg3.Cols(17).Format = "###,###,##0.00"

        Fg3(0, 18) = "Kms. al montar"
        Dim c18 As Column = Fg3.Cols(18)
        c18.DataType = GetType(Decimal)
        Fg3.Cols(18).Format = "###,###,##0.00"

        Fg3(0, 19) = "Kms. al desmontar"
        Dim c19 As Column = Fg3.Cols(19)
        c19.DataType = GetType(Decimal)
        Fg3.Cols(19).Format = "###,###,##0.00"


        For k = 1 To Fg3.Cols.Count - 1
            Fg3.Cols(k).StarWidth = "*"
        Next

    End Sub

    Private Sub FrmLlantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Llantas")
    End Sub
    Private Sub FrmLlantas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case 27
                    TBUSCAR.Focus()
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            CREA_TAB(FrmLlantasAE, "Movimientos Llantas")
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            r_ = Fg.Row
            CLAVE_LLANTA = Var2
            CREA_TAB(FrmLlantasAE, "Movimientos Llantas")
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCLLANTAS SET STATUS = 'B' WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand With {
                    .Connection = cnSAE,
                    .CommandTimeout = 120,
                    .CommandText = SQL
                }
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Fg.RemoveItem(Fg.Row)
                        MsgBox("El registro se elimino satisfactoriamente")

                        '********************************
                        Dim da2 As New SqlDataAdapter
                        Dim dt2 As New DataTable

                        SQL = "SELECT " & NUM_TOP & " CAST(LL.CVE_LLANTA As INT) As CVE_LLA, ISNULL(LL.STATUS_LLANTA,'2') + '. ' + ISNULL(SL.DESCR,'PENDIENTE POR ASIGNAR') AS ST_LLA, "

                        SQL += "LL.UNIDAD, LL.POSICION, LL.NUM_ECONOMICO, CASE WHEN ISNULL(TIPO_NUEVA_RENO,0) = 0 or ISNULL(TIPO_NUEVA_RENO,0) = 1 THEN 'Original' ELSE 'Renovada' END AS TIPO_NEW_REN, 
                             TU.DESCR, LL.FECHA_MON, M.DESCR AS DESC_MARCA, 
                             D.DESCR AS DESC_MODELO, 
                             T.DESCR as 'Tipo llanta', LL.COSTO_LLANTA_MN, ISNULL(LL.STATUS_LLANTA,'2') AS STALLA, 
                             (SELECT TOP 1 FECHAELAB FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA ORDER BY FECHAELAB DESC) AS 'Fecha ult. act.',
                             PROFUNDIDAD_ACTUAL AS 'Profundidad actual',
                             (SELECT DATEDIFF(DAY, MIN(FECHAELAB), MAX(FECHAELAB)) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Dias', 
                             (SELECT MAX(PROFUNDIDAD) - MIN(PROFUNDIDAD) FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = LL.CVE_LLANTA GROUP BY CVE_LLANTA) AS 'Desgaste (mm)', 
                             KMS_MONTAR AS 'Kms. al montar', KMS_DESMONTAR AS 'Kms. al desmontar', LL.KMS_ACTUAL AS 'Kms. Actual', LL.NO_RENOVADOS AS 'Num. renovados'
                             FROM GCLLANTAS LL 
                             LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = LL.UNIDAD   
                             LEFT JOIN GCTIPO_UNIDAD TU ON TU.CVE_UNI = U.CVE_TIPO_UNI   
                             Left Join GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                             LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA   
                             LEFT JOIN GCLLANTA_MODELO D ON D.CVE_MODELO = LL.MODELO   
                             Left Join GCLLANTA_TIPO T ON T.CVE_TIPO = LL.TIPO_LLANTA
                             WHERE LL.STATUS = 'B'
                             ORDER by TRY_PARSE(LL.NUM_ECONOMICO AS INT) DESC"
                        da2 = New SqlDataAdapter(SQL, cnSAE)
                        dt2 = New DataTable ' crear un DataTable
                        da2.SelectCommand.CommandTimeout = 280

                        da2.Fill(dt2)
                        BindingSource1.DataSource = dt2
                        Fg3.DataSource = BindingSource1.DataSource

                        TITULOS2()

                        Fg3.Cols(0).Width = 50
                        Fg3.Cols(13).Visible = False
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuAsignacionDeLLantas_Click(sender As Object, e As EventArgs) Handles MnuAsignacionDeLLantas.Click
        Try
            If Fg.Row > 0 Then
                Var14 = ""
                Var15 = "1"
                Var16 = ""

                r_ = Fg.Row
                FrmAsignacionLlantas.ShowDialog()

                NUM_TOP = " TOP 1000"
                CADENA = " WHERE LL.STATUS <> 'B'"
                DESPLEGAR2()

            Else
                MsgBox("Por favor seleccione una llanta")
            End If
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuDesasignarLLantas_Click(sender As Object, e As EventArgs) Handles MnuDesasignarLLantas.Click

        Var14 = "" : Var15 = "2" : Var16 = ""
        r_ = Fg.Row
        FrmAsignacionLlantas.ShowDialog()

        NUM_TOP = " TOP 1000"
        CADENA = " WHERE LL.STATUS <> 'B'"
        DESPLEGAR2()
    End Sub
    Private Sub MnuStatusLlantas_Click(sender As Object, e As EventArgs) Handles MnuStatusLlantas.Click
        Try
            If Fg.Row > 0 Then
                Var13 = ""
                Var14 = ""
                Var15 = Fg(Fg.Row, 2)
                Var16 = Fg(Fg.Row, 1)
                Var17 = Fg(Fg.Row, 13)
                Var18 = Fg(Fg.Row, Fg.Cols.Count - 1)
                FrmLLantasStatus.ShowDialog()

                If Var14.Trim.Length > 0 Then

                    NUM_TOP = " TOP 1200"
                    CADENA = " WHERE LL.STATUS <> 'B'"

                    DESPLEGAR2()
                End If
            Else
                MsgBox("Por favor seleccione una llanta")
            End If
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuLlantasSinAsignar_Click(sender As Object, e As EventArgs) Handles MnuLlantasSinAsignar.Click
        Try

            CADENA = " WHERE LL.STATUS <> 'B' AND ISNULL((SELECT TOP 1 CLAVEMONTE FROM GCUNIDADES WHERE ISNULL(STATUS, 'A') = 'A' AND (CHLL1 = CVE_LLANTA OR CHLL2 = CVE_LLANTA OR CHLL3 = CVE_LLANTA OR " &
                 "CHLL4 = CVE_LLANTA OR CHLL5 = CVE_LLANTA OR CHLL6 = CVE_LLANTA OR CHLL7 = CVE_LLANTA OR CHLL8 = CVE_LLANTA OR " &
                 "CHLL9 = CVE_LLANTA OR CHLL10 = CVE_LLANTA OR CHLL11 = CVE_LLANTA OR CHLL12 = CVE_LLANTA)),'') = ''"
            'DESPLEGAR()
            DESPLEGAR2()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuBuscarXNumEconomico_Click(sender As Object, e As EventArgs) Handles MnuBuscarXNumEconomico.Click
        FrmBuscarNumEconomico.ShowDialog()
    End Sub
    Private Sub MnuImprimir_Click(sender As Object, e As EventArgs) Handles MnuImprimir.Click
        '  Get the grid's PrintDocument object.
        Dim pd As Printing.PrintDocument

        'DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        pd = Fg.PrintParameters.PrintDocument()
        'PrintPreviewDialog1.Document = pd
        '  Set up the page (landscape, 1.5" left margin).
        With pd.DefaultPageSettings
            .Landscape = True
            .Margins.Top = 40
            .Margins.Bottom = 40
            .Margins.Left = 35
            .Margins.Right = 35
        End With
        Try
            '  Set up the header and footer fonts.
            Fg.PrintParameters.HeaderFont = New Font("Arial Black", 10, FontStyle.Bold)
            Fg.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)
            '  Preview the grid.
            Fg.PrintGrid("Llantas sin asignar", PrintGridFlags.FitToPageWidth + PrintGridFlags.ShowPreviewDialog,
                "Llantas sin asignar" + Chr(9) + Chr(9) + Format(DateTime.Now, "d"), Chr(9) + Chr(9) + "Pag. {0} de {1}")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuExcel_Click(sender As Object, e As EventArgs)
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Llantas")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuUniSinLLanAsig_Click(sender As Object, e As EventArgs) Handles MnuUniSinLLanAsig.Click
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Return
            End If

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT U.CLAVE AS 'Clave', CLAVEMONTE AS 'Clave M', U.STATUS as 'Estatus', (CASE WHEN RENTADO = 1 THEN 'SI' ELSE '' END) 'RENTADO', " &
                "(CASE WHEN UNIDAD_PERMISI = 1 THEN 'SI' ELSE '' END) AS 'Unidad/Permisionario', U.DESCR AS 'Descripción', T.DESCR AS 'Tipo unidad', " &
                "CVE_SUC AS 'Sucursal', NOMBRE AS 'NombreOperador', M.DESCR AS 'Marca', D.DESCR AS 'Modelo', NUM_SERIE_UNI AS 'Num. serie unidad' " &
                "FROM GCUNIDADES U " &
                "LEFT JOIN GCOPERADOR O ON O.CLAVE = U.CVE_OPER " &
                "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                "LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA " &
                "LEFT JOIN GCMODELO_UNIDAD D ON D.CVE_MOD = U.CVE_MODELO " &
                "WHERE ISNULL(U.STATUS, 'A') = 'A' AND " &
                "ISNULL(CHLL1,'') = '' AND ISNULL(CHLL2,'') = '' AND ISNULL(CHLL3,'') = '' AND ISNULL(CHLL4,'') = '' AND ISNULL(CHLL5,'') = '' AND " &
                "ISNULL(CHLL6,'') = '' AND ISNULL(CHLL7,'') = '' AND ISNULL(CHLL8,'') = '' AND ISNULL(CHLL9,'') = '' AND ISNULL(CHLL10,'') = '' AND " &
                "ISNULL(CHLL11,'') = '' AND ISNULL(CHLL12,'') = '' " &
                "ORDER BY TRY_PARSE(U.CLAVE AS INT)"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Clave montellano"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estatus"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Rentado"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int16)

            Fg(0, 5) = "Unidad permisio."
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Int16)

            Fg(0, 6) = "Descripción"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Tipo unidad"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Int16)

            Fg(0, 8) = "Sucursal"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Int16)

            Fg(0, 9) = "Operador"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Int16)

            Fg(0, 10) = "Marca"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Modelo"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Int16)

            Fg(0, 12) = "Num. serie"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            NUM_TOP = " TOP 2000"
            CADENA = " WHERE LL.STATUS <> 'B'"
            DESPLEGAR2()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Llantas")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarDesgaste_Click(sender As Object, e As EventArgs) Handles BarDesgaste.Click
        Try
            If Fg.Row > 0 Then
                Var10 = Fg(Fg.Row, 1)
                Var11 = Fg(Fg.Row, 5)

                FrmLLantasHistorialDesgaste.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuMovsInvLlantas_Click(sender As Object, e As EventArgs) Handles MnuMovsInvLlantas.Click
        CREA_TAB(FrmLlantasMinve, "Movs. inv. llantas")
    End Sub
    Private Sub BarControlLLantas_Click(sender As Object, e As EventArgs) Handles BarControlLLantas.Click
        CREA_TAB(FrmControlLlantas, "Control llantas")
    End Sub
    Private Sub MnuConmLlantas_Click(sender As Object, e As EventArgs) Handles MnuConmLlantas.Click
        CREA_TAB(FrmLlantasConM, "Conceptos llantas")
    End Sub
    Private Sub BarInspeccionLlantas_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmInspeccionLlantas, "Inspección llantas")
    End Sub
    Private Sub CmdNuevo_Click(sender As Object, e As ClickEventArgs) Handles CmdNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmInspeccionLlantasAE.ShowDialog()
            DESPLEGAR_INSPECCION()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CmdEdit_Click(sender As Object, e As ClickEventArgs) Handles CmdEdit.Click
        Try
            Var1 = "Edit"
            Var2 = Fg2(Fg2.Row, 1)

            FrmInspeccionLlantasAE.ShowDialog()
            DESPLEGAR_INSPECCION()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDisenador_Click(sender As Object, e As ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportInspeccionLLantas")
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String

        Try

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportInspeccionLLantas.mrt"
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

            StiReport1.Item("CLAVE") = Convert.ToInt32(Fg2(Fg2.Row, 1))
            'StiReport1.Item("F2") = F2.Value

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CmdActualizar_Click(sender As Object, e As ClickEventArgs) Handles CmdActualizar.Click
        DESPLEGAR_INSPECCION()
    End Sub
    Private Sub CmdExcel_Click(sender As Object, e As ClickEventArgs) Handles CmdExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg2, "Inspeccion llantas")
    End Sub
    Private Sub CmdSalir_Click(sender As Object, e As ClickEventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Private Sub CmdCancelar_Click(sender As Object, e As ClickEventArgs) Handles CmdCancelar.Click

        If Fg2.Row <= 0 Then
            Dim result1 = RJMessageBox.Show("Por favor seleccione una inspección?",
                                       "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Return
        End If

        If Fg2(Fg2.Row, 4) = "FINALIZADO" Then
            Dim result1 = RJMessageBox.Show("La inspección se encuentra finalizada, no es posible cancelar, " &
                          vbNewLine & "antes debe reactivarla", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Return
        End If
        Dim result = RJMessageBox.Show("Realmente desea cancelar la inspección?",
                                       "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try
                SQL = "UPDATE GCINSPEC_LLANTAS SET STATUS = 'C' WHERE CVE_INS = " & Fg2(Fg2.Row, 1)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If Convert.ToDecimal(returnValue) > 0 Then

                            Dim result1 = RJMessageBox.Show("La inspección se cancelo correctamente, " & vbNewLine &
                                                            "Números económicos cancelados " &
                                                            returnValue, "Información", MessageBoxButtons.OK)
                            DESPLEGAR_INSPECCION()
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub BarReportSemaforeoLlantas_Click(sender As Object, e As EventArgs) Handles BarReportSemaforeoLlantas.Click
        Dim RUTA_FORMATOS As String

        If MsgBox("Realmente desea imprimir el reporte?", vbYesNo) = vbNo Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim j As Integer = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLLANTAS_RANGOS_DESGASTE ORDER BY CVE_DES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        Select Case j
                            Case 1
                                R11 = dr("DE")
                                R12 = dr("HASTA")
                            Case 2
                                R21 = dr("DE")
                                R22 = dr("HASTA")
                            Case 3
                                R31 = dr("DE")
                                R32 = dr("HASTA")
                        End Select
                        j += 1
                    Loop
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try '                    LEFT JOIN GCINSPEC_LLANTAS I ON I.NUM_ECONOMICO = L.NUM_ECONOMICO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO, SEMAFORO, ISNULL(PROFUNDIDAD_ACTUAL,0) AS PROF_ACTUAL
                    FROM GCLLANTAS WHERE STATUS <> 'B'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            If dr("PROF_ACTUAL") >= R11 And dr("PROF_ACTUAL") <= R12 Then
                                SQL = "UPDATE GCLLANTAS SET SEMAFORO = 'R' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                DOC_NEW = EXECUTE_QUERY_NET(SQL)
                            Else
                                If dr("PROF_ACTUAL") >= R21 And dr("PROF_ACTUAL") <= R22 Then
                                    SQL = "UPDATE GCLLANTAS SET SEMAFORO = 'A' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                    DOC_NEW = EXECUTE_QUERY_NET(SQL)
                                Else
                                    If dr("PROF_ACTUAL") >= R31 And dr("PROF_ACTUAL") <= R32 Then
                                        SQL = "UPDATE GCLLANTAS SET SEMAFORO = 'V' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                        DOC_NEW = EXECUTE_QUERY_NET(SQL)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSemaforeoLLantas.mrt"
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

            'StiReport1.Item("F1") = F1.Value
            'StiReport1.Item("F2") = F2.Value

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub BarDisenadorSemaforo_Click(sender As Object, e As EventArgs)
        PrinterMRT("ReportSemaforeoLLantas")
    End Sub
    Private Sub CmdFinalizar_Click(sender As Object, e As ClickEventArgs) Handles CmdFinalizar.Click
        Dim NumEcoUpdate As Integer = 0, FECHA As Date, CVE_LLANTA As String

        If Fg2.Row <= 0 Then
            Dim result1 = RJMessageBox.Show("Por favor seleccione una unidad?",
                                       "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Return
        End If

        Dim result2 = RJMessageBox.Show("Realmente desea finalizar la inspección de la llanta?",
                                       "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result2 = DialogResult.OK Then
            Try
                Dim CVE_INS As Long

                CVE_INS = Fg2(Fg2.Row, 1)

                'SQL = "SELECT MAX(CVE_INS) AS CVEINS, MAX(UNIDAD) AS UNI, MAX(FECHA) AS FEC, CASE 
                'WHEN MAX(STATUS) = 'E' THEN 'EDICION' 
                'WHEN MAX(STATUS) = 'F' THEN 'FINALIZADO' 
                'WHEN MAX(STATUS) = 'C' THEN 'CANCELADO' ELSE '' END AS 'Estatus'
                'From GCINSPEC_LLANTAS I 
                'GROUP BY CVE_INS
                'ORDER BY CVE_INS DESC"

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT NUM_ECONOMICO, KMS_DESMONTAR, FECHA, PROFUNDIDAD_ACTUAL, PROFUNDIDAD_ACTUAL2, PROFUNDIDAD_ACTUAL3, 
                            PROFUNDIDAD_ACTUAL4, KMS_ACTUAL
                            FROM GCINSPEC_LLANTAS 
                            WHERE CVE_INS = " & CVE_INS
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                SQL = "UPDATE GCINSPEC_LLANTAS SET STATUS = 'F' WHERE CVE_INS = '" & CVE_INS & "'"

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using

                                SQL = "UPDATE GCLLANTAS SET KMS_DESMONTAR = " & dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR") & ", 
                                    PROFUNDIDAD_ACTUAL = " & dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL") & ", 
                                    PROFUNDIDAD_ACTUAL2 = " & dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2") & ", 
                                    PROFUNDIDAD_ACTUAL3 = " & dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3") & ", 
                                    PROFUNDIDAD_ACTUAL4 = " & dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4") & ",
                                    KMS_ACTUAL = " & dr.ReadNullAsEmptyDecimal("KMS_ACTUAL") & "    
                                    WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            NumEcoUpdate += 1
                                        End If
                                    End If
                                End Using

                                If dr("FECHA") IsNot DBNull.Value Then
                                    FECHA = dr("FECHA")
                                Else
                                    FECHA = Now.ToShortDateString
                                End If

                                CVE_LLANTA = BUSCA_CVE_LLANTA(dr("NUM_ECONOMICO"))

                                SQL = "IF EXISTS (SELECT CVE_LLANTA FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = '" & CVE_LLANTA & "')
                                        UPDATE GCLLANTAS_DESGASTE SET PROFUNDIDAD = " & dr("PROFUNDIDAD_ACTUAL") & ", STATUS = 'A', FECHAELAB = '" & FSQL(FECHA) & "'
                                        WHERE CVE_LLANTA = '" & CVE_LLANTA & "'    
                                    ELSE
                                        INSERT INTO GCLLANTAS_DESGASTE (CVE_LLANTA, PROFUNDIDAD, STATUS, FECHAELAB, UUID) VALUES ('" &
                                        CVE_LLANTA & "','" & dr("PROFUNDIDAD_ACTUAL") & "','A','" & FSQL(FECHA) & "', NEWID())"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using

                            End While
                        End Using
                    End Using

                    MsgBox("La inspección se finalizó correctamente, numeros económicos actualizados " & NumEcoUpdate)
                    DESPLEGAR_INSPECCION()

                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try


            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub CmdReactivar_Click(sender As Object, e As ClickEventArgs) Handles CmdReactivar.Click

        If Fg2(Fg2.Row, 4) = "CANCELADO" Then
            Dim result1 = RJMessageBox.Show("La inspección se encuentra cancelada, reactivación abortada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Return
        End If

        Dim result = RJMessageBox.Show("Realmente desea reactivar la inspección de la llanta?",
                               "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try
                SQL = "UPDATE GCINSPEC_LLANTAS SET STATUS = 'E' WHERE CVE_INS = " & Fg2(Fg2.Row, 1)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If Convert.ToDecimal(returnValue) > 0 Then

                            Dim result1 = RJMessageBox.Show("La inspección se reactivo correctamente, " & vbNewLine &
                                                            "Números económicos reactivados " &
                                                            returnValue, "Información", MessageBoxButtons.OK)

                            DESPLEGAR_INSPECCION()
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub MnuImportLlantasExcel_Click(sender As Object, e As EventArgs) Handles MnuImportLlantasExcel.Click
        Try
            CREA_TAB(FrmImportLlantasEx, "Importar llantas")
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("cs1")
        cs1.BackColor = Color.Green
        cs1.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("cs2")
        cs2.BackColor = Color.FromArgb(255, 191, 0)
        cs2.ForeColor = Color.Black
        cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs3 As CellStyle
        cs3 = Fg.Styles.Add("cs3")
        cs3.BackColor = Color.Red
        cs3.ForeColor = Color.White
        cs3.Font = New Font("Tahoma", 9, FontStyle.Bold)

        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Try
                If Fg(e.Row, 15) >= R11 And Fg(e.Row, 15) <= R12 Then
                    Fg.SetCellStyle(e.Row, 15, cs3)
                Else
                    If Fg(e.Row, 15) >= R21 And Fg(e.Row, 15) <= R22 Then
                        Fg.SetCellStyle(e.Row, 15, cs2)
                    Else
                        If Fg(e.Row, 15) >= R31 And Fg(e.Row, 15) <= R32 Then
                            Fg.SetCellStyle(e.Row, 15, cs1)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        End If
    End Sub
    Private Sub Fg_SearchApplied(sender As Object, e As SearchAppliedEventArgs) Handles Fg.SearchApplied
        Try
            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)

            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarTodos_Click(sender As Object, e As EventArgs) Handles BarTodos.Click

        NUM_TOP = ""
        CADENA = " WHERE LL.STATUS <> 'B'"
        DESPLEGAR2()

    End Sub
    Private Sub BarFiltro_Click(sender As Object, e As EventArgs) Handles BarFiltro.Click
        Try
            Var14 = ""
            FrmLlantasFiltro.ShowDialog()
            If Var14.Trim.Length > 0 Then
                NUM_TOP = ""
                CADENA = " WHERE LL.STATUS <> 'B' AND STATUS_LLANTA IN (" & Var14 & ")"
                DESPLEGAR2()
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterFilter(sender As Object, e As EventArgs) Handles Fg.AfterFilter
        Try
            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)

            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarCostoPorKilometro_Click(sender As Object, e As EventArgs) Handles BarCostoPorKilometro.Click
        Dim RUTA_FORMATOS As String

        If MsgBox("Realmente desea imprimir el reporte?", vbYesNo) = vbNo Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCostoPorKilometro.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                PrinterMRT_Create("ReportCostoPorKilometro")
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

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarDetalladoDeLlantas_Click(sender As Object, e As EventArgs) Handles BarDetalladoDeLlantas.Click
        Dim RUTA_FORMATOS As String

        If MsgBox("Realmente desea imprimir el reporte?", vbYesNo) = vbNo Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDetalladoDeLlantas.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                PrinterMRT_Create("ReportDetalladoDeLlantas")
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

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarResumenDeLlantas_Click(sender As Object, e As EventArgs) Handles BarResumenDeLlantas.Click
        FrmResumenDiariaLlantas.ShowDialog()

    End Sub

    Private Sub BarIndicadoresGraficos_Click(sender As Object, e As EventArgs) Handles BarIndicadoresGraficos.Click
        Dim RUTA_FORMATOS As String

        If MsgBox("Realmente desea imprimir el reporte?", vbYesNo) = vbNo Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportIndicadoresGraficos.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                PrinterMRT_Create("ReportIndicadoresGraficos")
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

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BarReporteDeInspecciones_Click(sender As Object, e As EventArgs) Handles BarReporteDeInspecciones.Click
        Dim RUTA_FORMATOS As String

        If MsgBox("Realmente desea imprimir el reporte?", vbYesNo) = vbNo Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportInspecLlantas.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                PrinterMRT_Create("ReportInspecLlantas")
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

            'StiReport1("F1") = F1.Value
            'StiReport1("F2") = F2.Value

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BarReactivarLlanta_Click(sender As Object, e As EventArgs) Handles BarReactivarLlanta.Click
        Try
            If MsgBox("Realmente desea reactivar la llanta " & Fg3(Fg3.Row, 1) & "?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCLLANTAS SET STATUS = 'A' WHERE CVE_LLANTA = '" & Fg3(Fg3.Row, 1) & "'"
                EXECUTE_QUERY_NET(SQL)

                Tab1.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_MouseDown(sender As Object, e As MouseEventArgs) Handles Fg.MouseDown
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    If e.Button = MouseButtons.Right Then

                        If Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then
                            MsgBox("Primero desmontar la llanta")
                        Else
                            ContextMenuStrip1.Show(CType(sender, Control), e.Location)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuAsignarStatus_Click(sender As Object, e As EventArgs) Handles MnuAsignarStatus.Click
        Try
            Dim CVE_LLANTA As String = "", CVE_ST As String, OTRO As String, CVE1 As String = "", CVE2 As String = "999999"

            Var10 = ""
            Var11 = ""
            FrmLlantasAsigStSel.ShowDialog()
            If Var10.Trim.Length > 0 Then
                If Fg.Rows.Selected.Count > 0 Then
                    Try
                        Dim r_ As Row
                        CVE_ST = Var10

                        For k = 0 To Fg.Rows.Selected.Count - 1

                            r_ = Fg.Rows.Selected(k)
                            CVE_LLANTA = Fg(r_.Index, 1)

                            If k = 0 Then
                                CVE1 = CVE_LLANTA
                            End If
                            If k = Fg.Rows.Selected.Count - 1 Then
                                CVE2 = CVE_LLANTA
                            End If

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                If CVE_ST = 6 Then
                                    OTRO = Var11
                                Else
                                    OTRO = ""
                                End If
                                SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = " & CVE_ST & ", CVE_PILA = '" & OTRO & "'
                                    WHERE CVE_LLANTA = '" & CVE_LLANTA & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Next

                        MsgBox("El estatus se grabo satisfactoriamente")

                        NUM_TOP = " TOP 1200"
                        CADENA = " WHERE LL.STATUS <> 'B' AND ((CVE_LLANTA >= '" & CVE1 & "' AND CVE_LLANTA <= '" & CVE2 & "') OR (CVE_LLANTA >= '" & CVE2 & "' AND CVE_LLANTA <= '" & CVE1 & "'))"
                        DESPLEGAR2()
                    Catch ex As Exception
                        Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    MsgBox("Por favor seleccione al menos un documento")
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBUSCAR_TextChanged(sender As Object, e As EventArgs) Handles TBUSCAR.TextChanged
        Try
            NUM_TOP = ""

            CADENA = " WHERE LL.STATUS <> 'B' AND (UNIDAD LIKE '%" & TBUSCAR.Text & "%' OR CVE_LLANTA LIKE '%" & TBUSCAR.Text & "%' OR SL.DESCR LIKE '%" & TBUSCAR.Text & "%' OR 
                    LL.NUM_ECONOMICO LIKE '%" & TBUSCAR.Text & "%' OR T.DESCR LIKE '%" & TBUSCAR.Text & "%' OR KMS_MONTAR LIKE '%" & TBUSCAR.Text & "%' OR 
                    KMS_DESMONTAR LIKE '%" & TBUSCAR.Text & "%' OR KMS_ACTUAL LIKE '%" & TBUSCAR.Text & "%' OR 
                    M.DESCR LIKE '%" & TBUSCAR.Text & "%' OR D.DESCR LIKE '%" & TBUSCAR.Text & "%')"
            DESPLEGAR2()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarPilasDesecho_Click(sender As Object, e As EventArgs) Handles BarPilasDesecho.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPilaDesecho")
        CREA_TAB(FrmPilaDesecho, "Pila desecho")
    End Sub

    Private Sub BarInspeccionesDiarias_Click(sender As Object, e As EventArgs) Handles BarInspeccionesDiarias.Click
        Dim RUTA_FORMATOS As String

        Var2 = ""
        Var4 = ""
        FrmInspecDiarias.ShowDialog()
        If Var2.Trim.Length > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Try
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportInspeccionesDiarias.mrt"
                If Not File.Exists(RUTA_FORMATOS) Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                    PrinterMRT_Create("ReportInspeccionesDiarias")
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

                StiReport1("F1") = Var2
                StiReport1("F2") = Var4

                StiReport1.Render()
                StiReport1.Show()

            Catch ex As Exception
                MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Fg3_MouseDown(sender As Object, e As MouseEventArgs) Handles Fg3.MouseDown

        If Fg3.MouseRow < Fg3.Rows.Fixed Then
            Return
        End If

        If e.Button = MouseButtons.Right Then
            ContextMenuStrip2.Show(Control.MousePosition.X, Control.MousePosition.Y)
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If e.Row > 0 Then
            If e.Col < 15 Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If e.Row > 0 Then
                'KMS_ACTUAL AS 'Kms. Actual', LL.NO_RENOVADOS AS 'Num. renovados', DOT as 'Dot'
                Select Case e.Col
                    Case 15
                        If IsNumeric(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET PROFUNDIDAD_ACTUAL = " & Convert.ToDecimal(Fg.Editor.Text) & " WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                    Case 18
                        If IsNumeric(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET KMS_MONTAR = " & Convert.ToDecimal(Fg.Editor.Text) & " WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                    Case 19
                        If IsNumeric(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET KMS_DESMONTAR = " & Convert.ToDecimal(Fg.Editor.Text) & " WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                    Case 20
                        If IsNumeric(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET KMS_ACTUAL = " & Convert.ToDecimal(Fg.Editor.Text) & " WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                    Case 21
                        If IsNumeric(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET NO_RENOVADOS = " & Convert.ToDecimal(Fg.Editor.Text) & " WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                    Case 22
                        If Not IsNothing(Fg.Editor.Text) Then
                            SQL = "UPDATE GCLLANTAS SET DOT = '" & Fg.Editor.Text & "' WHERE CVE_LLANTA = '" & Fg(Fg.Row, 1) & "'"
                            EXECUTE_QUERY_NET(SQL)
                        End If
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmdFinalizar_CategoryChanged(sender As Object, e As EventArgs) Handles CmdFinalizar.CategoryChanged

    End Sub

    Private Sub Tab1_RightToLeftLayoutChanged(sender As Object, e As EventArgs) Handles Tab1.RightToLeftLayoutChanged

    End Sub
End Class

Public Class MyItem
    Public Property Clave As String
    Public Property Estatus As String
    Public Property Unidad As String
    Public Property Posición As Integer
    Public Property Num_economico As String
    Public Property O_R As String
    Public Property Fecha_mon As Date
    Public Property Marca As String
    Public Property Modelo As String
    Public Property Tipo_llanta As String
    Public Property Otro_motivo As String
    Public Property Costo_llanta As Single
End Class

