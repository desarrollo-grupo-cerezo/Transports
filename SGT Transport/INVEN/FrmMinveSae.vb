Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.Data.SqlClient
Public Class FrmMinveSae
    Private CADENA As String = ""
    Private NUM_TOP As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Private Sub frmMinveSae_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Try
                If Not Valida_Conexion() Then
                    Return
                End If
            Catch ex As Exception
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barMenu, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            NUM_TOP = " TOP 5000 "
            CADENA = "WHERE TIPO_DOC = 'M' ORDER BY FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()

        Fg(0, 1) = "Documento"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Articulo"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Descripcion"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Linea"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Cliente/Prov"
        Dim c5 As Column = Fg.Cols(5)
        c2.DataType = GetType(String)

        Fg(0, 6) = "Almacen"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(Int32)

        Fg(0, 7) = "Tipo doc."
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(String)

        Fg(0, 8) = "Nombre"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(String)

        Fg(0, 9) = "Decripcion"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(String)

        Fg(0, 10) = "Fecha"
        Dim c10 As Column = Fg.Cols(10)
        c9.DataType = GetType(DateTime)

        Fg(0, 11) = "Cantidad"
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(Decimal)
        'Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 12) = "Costo"
        Dim c12 As Column = Fg.Cols(12)
        c12.DataType = GetType(Decimal)
        Fg.Cols(12).Format = "###,###,##0.00"

        Fg(0, 13) = "Costo prom."
        Dim c13 As Column = Fg.Cols(13)
        c13.DataType = GetType(Decimal)
        Fg.Cols(13).Format = "###,###,##0.00"

        Fg(0, 14) = "Folio"
        Dim c14 As Column = Fg.Cols(14)
        c14.DataType = GetType(String)

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            barMenu.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Fg.Cursor = Cursors.WaitCursor
        Catch ex As Exception
        End Try

        Fg.Redraw = False

        Try
            SQL = "SELECT " & NUM_TOP & " M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, 
                CASE TIPO_DOC 
                WHEN 'M' THEN 'Movimiento al inventario'
                WHEN 'c' THEN 'Compra'
                WHEN 'r' THEN 'Recepción'
                WHEN 'o' THEN 'Oeden de compra'
                WHEN 'q' THEN 'Requisición'
                WHEN 'F' THEN 'Factura'
                WHEN 'R' THEN 'Remision'
                WHEN 'V' THEN 'Nota de venta'
                WHEN 'D' THEN 'Devolución'
                ELSE TIPO_DOC END AS TIP_D,
                CASE M.CVE_CPTO
                WHEN 62 THEN (SELECT CAST(CVE_MEC AS VARCHAR(10)) + ' ' + DESCR FROM GCMECANICOS WHERE CAST(CVE_MEC AS VARCHAR(10)) = LTRIM(RTRIM(M.CLAVE_CLPV))) 
                WHEN 63 THEN (SELECT CAST(CLAVE AS VARCHAR(10)) + ' ' + NOMBRE FROM GCOPERADOR WHERE CAST(CLAVE AS VARCHAR(10)) = LTRIM(RTRIM(M.CLAVE_CLPV))) 
                WHEN 67 THEN (SELECT 'Unidad:' + CLAVEMONTE NOMBRE FROM GCUNIDADES WHERE CAST(CLAVE AS VARCHAR(10)) = LTRIM(RTRIM(M.CLAVE_CLPV)))
                ELSE CAST(C.DESCR AS VARCHAR(10))
                END AS NOMBRE_MECANICO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, I.COSTO_PROM, M.CVE_FOLIO
                From MINVE" & Empresa & " M 
                LEFT Join INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                Left Join CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                CADENA

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            'Fg.AddItem("" & vbTab & dr("REFER") & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("LIN_PROD") & vbTab &
            'dr("CLAVE_CLPV") & vbTab & dr("ALMACEN") & vbTab & dr("CVE_CPTO") & vbTab & dr("DES_CON") & vbTab & dr("FECHA_DOCU") & vbTab &
            'dr("CANT") & vbTab & dr("COSTO") & vbTab & dr("COSTO_PROM") & vbTab & dr("CVE_FOLIO"))
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try
            TITULOS()

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            barMenu.Enabled = True
            Me.Cursor = Cursors.Default
            Fg.Cursor = Cursors.Default
        Catch ex As Exception
        End Try

        Fg.Redraw = True
    End Sub
    Private Sub frmMinveSae_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Movimientos al Inventario")
        Me.Dispose()
    End Sub

    Private Sub frmMinveSae_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
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
            frmMinveSaeAE.ShowDialog()

            NUM_TOP = " TOP 1000 "
            CADENA = "WHERE TIPO_DOC = 'M' ORDER BY FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barHoy_Click(sender As Object, e As EventArgs) Handles barHoy.Click
        Try
            NUM_TOP = ""
            CADENA = "WHERE FECHA_DOCU = '" & FSQL(Now) & "' ORDER BY FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barEsteMes_Click(sender As Object, e As EventArgs) Handles barEsteMes.Click
        Try
            NUM_TOP = ""
            CADENA = "WHERE YEAR(FECHA_DOCU) = " & Year(Now) & " AND MONTH(FECHA_DOCU) = " & Month(Now) & " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barMesAnterior_Click(sender As Object, e As EventArgs) Handles barMesAnterior.Click
        Try
            NUM_TOP = ""
            CADENA = "WHERE YEAR(FECHA_DOCU) = " & Year(Now) - 1 & " AND MONTH(FECHA_DOCU) = " & Month(DateAdd("m", -1, Now)) & " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barTodos_Click(sender As Object, e As EventArgs) Handles barTodos.Click
        Try
            NUM_TOP = ""
            CADENA = "ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mnuReimprimir_Click(sender As Object, e As EventArgs) Handles mnuReimprimir.Click
        Dim REFER As String
        Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""

        Try
            If Fg.Row > 0 Then
                REFER = Fg(Fg.Row, 1)

                RUTA_FORMATOS = GET_RUTA_FORMATOS()

                If REFER.Substring(0, 2) = "OT" Then
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveOT" & Empresa & ".mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveOT.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If
                Else
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE" & Empresa & ".mrt"
                    '                               ReportMinveSAE14
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If
                End If

                StiReport1.Load(ARCHIVO_MRT)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("REFER") = REFER
                StiReport1.Render()
                StiReport1.Show()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace & ARCHIVO_MRT)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & ARCHIVO_MRT)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub barKardex_Click(sender As Object, e As EventArgs) Handles barKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 2)
                Var5 = Fg(Fg.Row, 3)
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarRefrescar_Click(sender As Object, e As EventArgs) Handles BarRefrescar.Click
        NUM_TOP = " TOP 5000 "
        CADENA = " ORDER BY FECHAELAB DESC"
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
    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            NUM_TOP = ""
            CADENA = "WHERE FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND FECHA_DOCU <= '" & FSQL(F2.Value) & "' ORDER BY FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Movimientos al inventario")
        Catch ex As Exception
        End Try
    End Sub
End Class
