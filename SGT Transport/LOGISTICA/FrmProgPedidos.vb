Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmProgPedidos
    Private CADENA As String = ""
    Private N_TOP As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Private Sub FrmProgPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized

            DERECHOS()

            Fg.Rows.Count = 1
            Fg.Cols.Count = 14

            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg.AllowFiltering = True

            N_TOP = "TOP 500"
            CADENA = " ORDER BY P.FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False

            SQL = "SELECT " & N_TOP & " P.CVE_DOC AS 'Documento', CASE WHEN P.STATUS = 'C' THEN 'CANCELADO' ELSE '' END AS 'Estatus', 
                ISNULL(T.CVE_TAB,'') AS 'Tabulador', C3.NOMBRE  AS 'Nombre', 
                CASE WHEN ISNULL(P.CVE_ART,'') = '' THEN I.DESCR ELSE I2.DESCR END AS 'Descripción', 
                P.FECHA_CARGA AS 'Fecha carga', P.FECHA_DESCARGA AS 'Fecha descarga', 
                RE.DESCR AS 'Recoger en', EE.DESCR AS 'Entregar en', O.NOMBRE AS 'Operador', P.CVE_TRACTOR AS 'Tractor', 
                P.CVE_TANQUE1 AS 'Tanque1', P.CVE_TANQUE2 AS 'Tanque 2', P.FECHA  AS 'Fecha'
                FROM GCPEDIDOSPROG P 
                LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                LEFT JOIN GCTAB_RUTAS_F T ON T.CVE_CON = CT.CVE_CON
                LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = CT.CVE_ART 
                LEFT JOIN GCPRODUCTOS I2 ON I2.CVE_PROD = P.CVE_ART 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN 
                WHERE P.STATUS = 'A' AND 
                NOT EXISTS (SELECT PED_ENLAZADO FROM GCPEDIDOS WHERE PED_ENLAZADO = P.CVE_DOC)" & CADENA
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg.AutoSizeCols()
            'TITULOS()

            LtNUm.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                barNuevo.Visible = False
                barEdit.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                CLAVE >= 24000 AND CLAVE <= 24200"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 24040 'NUEVO
                                    barNuevo.Visible = True
                                Case 24045 'EDIT
                                    barEdit.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmProgPedidos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Programación de pedidos")
        Me.Dispose()
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click

        Try
            Var1 = "Nuevo"
            Var3 = ""
            FrmProgPedidosAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Dim Nrow As Long
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1) 'CVE_DOC PEDIDO
                Var3 = Fg(Fg.Row, 2) 'Viaje asignado
                Nrow = Fg.Row

                FrmProgPedidosAE.ShowDialog()
                DESPLEGAR()

                If IsNumeric(Nrow) Then
                    If Nrow > 0 Then
                        Fg.Row = Nrow
                    End If
                End If
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Nrow =" & Nrow)
            'MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PROG. PEDIDOS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarRefrescar_Click(sender As Object, e As EventArgs) Handles BarRefrescar.Click
        N_TOP = "TOP 500"

        CADENA = " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
        DESPLEGAR()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        N_TOP = ""
        CADENA = " AND FECHA = '" & FSQL(Date.Now) & "' ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " AND FECHA = '" & FSQL(dt) & "' ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        CADENA = " AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""
        CADENA = " AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""
        CADENA = " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub
End Class
