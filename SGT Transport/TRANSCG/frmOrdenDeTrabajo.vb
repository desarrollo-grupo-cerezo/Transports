Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmOrdenDeTrabajo
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Private Sub frmOrdenDeTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            CARGA_PARAM_INVENT()

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 17
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            If Var16 = "OT" Then
                BarGenMinveOT.Visible = False
            Else
                barNuevo.Visible = False
                barEdit.Visible = False
                barEliminar.Visible = False
                BarGenMinveOT.Visible = True
            End If

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try

            SQL = "SELECT O.CVE_ORD, CASE WHEN O.STATUS <> 'B' THEN O.ESTATUS ELSE 'CANCELADA' END AS 'Estatus', O.FECHA, U.DESCR, (SELECT TOP 1 DESCR FROM GCORDEN_TRA_SER WHERE CVE_ORD = O.CVE_ORD) AS ACTIVIDAD, " &
                "O.LUGAR_REP, O.NOTA, O.CVE_SER, CASE TIPO_SERVICIO WHEN 0 THEN 'Preventivo' WHEN 1 THEN 'Correctivo' ELSE 'Extraordinario' END, " &
                "O.CVE_UNI, O.CVE_TIPO, O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM " &
                "FROM GCORDEN_TRABAJO O " &
                "LEFT JOIN GCUNIDADES U ON U.CLAVE = O.CVE_UNI " &
                "ORDER BY FECHAELAB DESC"

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Fecha"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(DateTime)

            Fg(0, 4) = "Unidad"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Actividad"   'NUEVO
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Lugar rep."
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Nota"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Servicio"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Tipo servicio"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Int16)

            Fg(0, 10) = "Cve. Unidad"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Tipo"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "Clave prov."
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Factura"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            Fg(0, 14) = "Vida rep. año"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Vida rep. KM"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmOrdenDeTrabajo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Orden de Trabajo")
        Me.Dispose()
    End Sub

    Private Sub frmOrdenDeTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            'frmOrdenDeTrabajoAE.ShowDialog()

            CREA_TAB(frmOrdenDeTrabajoAE, "Orden de trabajo ")

            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            If Fg(Fg.Row, 2) = "CANCELADA" Then
                MsgBox("La orden de trabajo se encuentra cancelada")
            Else
                'frmOrdenDeTrabajoAE.ShowDialog()
                'DESPLEGAR()
                CREA_TAB(frmOrdenDeTrabajoAE, "Orden de trabajo OT")
            End If

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub


    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            SQL = "(CVE_ORD LIKE '%" & tBox.Text & "%' OR NOTA LIKE '%" & tBox.Text & "%')"
            BindingSource1.Sort = "CVE_ORD"

            BindingSource1.RemoveFilter()

            If tBox.Text.Trim.Length > 0 Then
                BindingSource1.Filter = SQL
            Else
                BindingSource1.Filter = ""
            End If
            ' enlzar el datagridview al BindingSource  
            Fg.DataSource = BindingSource1.DataSource

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            barEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barImprimir_Click(sender As Object, e As EventArgs)
        Try
            If Fg.Rows.Count > 0 Then
                Dim RUTA_FORMATOS As String

                RUTA_FORMATOS = GET_RUTA_FORMATOS()
                If Not File.Exists(RUTA_FORMATOS & "\ReportAntidoping.mrt") Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportAntidoping.mrt, verifique por favor")
                    Return
                End If
                StiReport1.Load(RUTA_FORMATOS & "\ReportAntidoping.mrt")

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                'StiReport1.Item("CVE_OPER") = tCLAVE.Text
                'StiReport1.Item("CVE_FOLIO") = FOLIO
                StiReport1.Render()
                StiReport1.Show()
                'StiReport1.Print(True)
            Else
                MsgBox("No existen ordenes a imprimir")
            End If

        Catch ex As Exception
            Bitacora("301. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("301. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 2) = "CANCELADA" Then
                    MsgBox("La orden de trabajo se encuentra actualmente cancelada")
                    Return
                End If

                If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                    SQL = "UPDATE GCORDEN_TRABAJO SET STATUS = 'B' WHERE CVE_ORD = '" & Fg(Fg.Row, 1) & "'"

                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                            CANCELAR_ORDEN_SERVICIO(Fg(Fg.Row, 1))

                            MsgBox("El registro se elimino satisfactoriamente")
                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro eliminar el registro")
                        End If
                    Else
                        MsgBox("!!NO se logro eliminar el registro!!")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CANCELAR_ORDEN_SERVICIO(fCVE_ORD As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(CVE_ART,'') AS CVEART, ISNULL(CANT,0) AS CAN, ISNULL(NUM_ALM, 1) AS ALM " &
                    "FROM GCORDEN_TRA_SER " &
                    "WHERE CVE_ORD = '" & fCVE_ORD & "' AND STATUS = 'M'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        GRABAR_MINVE(fCVE_ORD, dr("CVEART"), dr("CAN"), dr("ALM"))
                    End While
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Sub GRABAR_MINVE(fCVE_ORDEN As String, fCVE_ART As String, fCANT As Decimal, fNUM_ALM As Integer)
        Dim CVE_ART As String
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = 1, COSTEADO As String = "S", COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = "", E_LTPD As String = ""
        Dim CVE_DOC As String, CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE

            CANT = fCANT
            CVE_ART = fCVE_ART
            CVE_DOC = fCVE_ORDEN

            Try
                SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE FROM GCINVER WHERE CVE_ART = '" & CVE_ART & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    EXIST = dr("EXIST")
                    UNI_MED = dr("UNI_MED")
                    COSTO = dr("ULT_COSTO")
                    COSTO_PROM = dr("COSTO_PROM")
                    TIPO_PROD = dr("TIPO_ELE")
                    ExistProd = True
                End If
                dr.Close()
            Catch ex As Exception
                Bitacora("204. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("204. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If TIPO_PROD = "P" And ExistProd Then
                CANT = fCANT
                ALMACEN = fNUM_ALM
                If ALMACEN = 0 Then ALMACEN = 1

                COSTO_PROM_INI = COSTO_PROM
                COSTO_PROM_FIN = COSTO_PROM

                Try
                    SQL = "UPDATE GCINVER SET EXIST = EXIST + " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("212. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("212. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    SQL = "INSERT INTO GCMINVER" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, " &
                        "REFER, CLAVE_CLPV, VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, " &
                        "TIPO_PROD, FACTOR_CON, FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, " &
                        "DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" & CVE_ART & "','" & ALMACEN & "'," &
                        "(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM GCMINVER" & Empresa & "),'" & CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" &
                        TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" & CANT & "','" & CANT & "','" &
                        PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                        "(SELECT EXIST FROM GCINVER WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                    If MULTIALMACEN = 1 Then
                        SQL = SQL & "COALESCE((SELECT EXIST FROM GCMULTER" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                    Else
                        SQL = SQL & "(SELECT EXIST FROM GCINVER WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                    End If
                    SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ISNULL(ULT_CVE,0) + 1 FROM GCTBLCONTROL WHERE ID_TABLA = 32),'" &
                                    SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO_PROM & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("213. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("213. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                SQL = "UPDATE GCTBLCONTROL SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM GCMINVER" & Empresa & ") WHERE ID_TABLA = 32"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If

                SQL = "UPDATE GCTBLCONTROL SET ULT_CVE = (SELECT ISNULL(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("221. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("221. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGenMinveOT_Click(sender As Object, e As EventArgs) Handles BarGenMinveOT.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var15 = "TOTINT"
            Var2 = Fg(Fg.Row, 1)
            If Fg(Fg.Row, 2) = "CANCELADA" Then
                MsgBox("La orden de trabajo se encuentra cancelada")
            Else
                BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                CREA_TAB(FrmMovsInvOT, "Movs. Inv. OT")
            End If
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub tBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
