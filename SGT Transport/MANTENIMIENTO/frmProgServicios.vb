Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmProgServicios
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmProgServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            Me.WindowState = FormWindowState.Maximized

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            SQL=""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                Var1 = "Nuevo"
                frmProgServiciosAE.ShowDialog()
                SQL = ""
                DESPLEGAR()
            Case Keys.F3
                Var1 = "Edit"
                frmProgServiciosAE.ShowDialog()
                SQL = ""
                DESPLEGAR()
            Case Keys.F5
                Me.Close()
            Case Keys.Escape
            Case Else
        End Select

        Return True
    End Function
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            If SQL.Trim.Length = 0 Then
                SQL = "SELECT CVE_PROG, CASE P.STATUS WHEN 'I' THEN 'Iniciado' WHEN 'F' THEN 'Finalizado' WHEN 'C' THEN 'Cancelado' ELSE 'Creado' END AS 'Estatus', " &
                    "CLAVEMONTE, T.DESCR AS 'Tipo unidad', ISNULL(SM.DESCR,'') AS DESCR_SM, FECHA_CREA, FECHA_PROG, FECHA_INI_SER, FECHA_FIN, KM_ACTUAL, KM_PROX_SERVICIO, " &
                    "CVE_ORD, ISNULL(P.CVE_OBS,'') AS OBS_STR " &
                    "FROM GCPROGAMACION_SERVICIOS P " &
                    "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                    "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                    "LEFT JOIN GCSERVICIOS_MANTE SM ON SM.CVE_SER = P.CVE_SER " &
                    "ORDER BY CAST(CVE_PROG AS INT) DESC"
            End If
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            ENCABEZADO()
            Fg.AutoSizeCols()


        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ENCABEZADO()
        Try
            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Unidad"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Tipo unidad"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Servicio de mantenimiento"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha creacion"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Fecha prog."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Fecha inic. serv."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Fecha fina. serv."
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Km actual"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Km prox. servicio"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Orden de trabajo"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Observaciones"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmProgServicios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Programación de Servicios")
        Me.Dispose()
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Nuevo"
                    Try
                        Var1 = "Nuevo"
                        frmProgServiciosAE.ShowDialog()
                        SQL = ""
                        DESPLEGAR()
                    Catch ex As Exception
                        MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "Edit"
                    If Fg.Row > 0 Then
                        Var1 = "Edit"
                        Var2 = Fg(Fg.Row, 1)
                        Var4 = Fg(Fg.Row, 2)
                        frmProgServiciosAE.ShowDialog()
                        SQL = ""
                        DESPLEGAR()
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case "Refrescar"
                    SQL = ""
                    DESPLEGAR()
                Case "Todos"
                    SQL = "SELECT CVE_PROG, CASE P.STATUS WHEN 'I' THEN 'Iniciado' WHEN 'F' THEN 'Finalizado' WHEN 'C' THEN 'Cancelado' ELSE 'Creado' END AS 'Estatus', " &
                        "CLAVEMONTE, T.DESCR AS 'Tipo unidad', FECHA_CREA, FECHA_PROG, FECHA_INI_SER, KM_ACTUAL, KM_PROX_SERVICIO, " &
                        "ISNULL(P.CVE_OVS,'') AS OBS_STR " &
                        "FROM GCUNIDADES U " &
                        "LEFT JOIN GCPROGAMACION_SERVICIOS P ON U.CLAVEMONTE = P.CVE_UNI " &
                        "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                        "WHERE ISNULL(STATUS, 'A') = 'A'"

                    DESPLEGAR()
                Case "Cambio estatus"
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception

        End Try
    End Sub
End Class
